--DROP PROC migracion_insert_cupones;
CREATE PROC migracion_insert_cupones AS
BEGIN
	DECLARE
		@cupon_clie_dni_consumo numeric(18, 0),
		@cupon_clie_id_consumo int,
		@cupon_fecha_consumo datetime,
		@cupon_fecha_compra datetime,
		@cupon_ofer_id nvarchar(50),
		@cupon_clie_id_compra int,
		@cupon_clie_dni_compra numeric(18, 0);
	-- inserts para compras de cupón:
	DECLARE curs_cupones_comprados CURSOR FOR (
		SELECT Cli_Dni, Oferta_Codigo, Oferta_Fecha_Compra
		FROM gd_esquema.Maestra
		WHERE Oferta_Codigo IS NOT NULL
			AND Oferta_Entregado_Fecha IS NULL
			AND Factura_Fecha IS NULL
	);
	OPEN curs_cupones_comprados;
	FETCH NEXT FROM curs_cupones_comprados INTO
		@cupon_clie_dni_compra,
		@cupon_ofer_id,
		@cupon_fecha_compra;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT
			@cupon_clie_id_compra = Cliente.clie_id
		FROM Cliente
		WHERE Cliente.clie_dni = @cupon_clie_dni_compra;
		INSERT INTO Cupon (
			cupon_clie_id_compra,
			cupon_fecha_compra,
			cupon_ofer_id
		) VALUES (
			@cupon_clie_id_compra,
			@cupon_fecha_compra,
			@cupon_ofer_id
		);
		FETCH NEXT FROM curs_cupones_comprados INTO
			@cupon_clie_dni_compra,
			@cupon_ofer_id,
			@cupon_fecha_compra;
	END
	CLOSE curs_cupones_comprados;
	DEALLOCATE curs_cupones_comprados;
	-- updates para consumiciones de cupón: ALGO ANDA MAL
	DECLARE curs_cupones_consumidos CURSOR FOR (
		SELECT
			Cli_Dni,
			Oferta_Codigo,
			Oferta_Fecha_Compra,
			Oferta_Entregado_Fecha
		FROM gd_esquema.Maestra
		WHERE Oferta_Codigo IS NOT NULL
			AND Oferta_Entregado_Fecha IS NOT NULL
	);
	OPEN curs_cupones_consumidos;
	FETCH NEXT FROM curs_cupones_consumidos INTO
		@cupon_clie_dni_consumo,
		@cupon_ofer_id,
		@cupon_fecha_compra,
		@cupon_fecha_consumo;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT -- trae clie_id mediante dni
			@cupon_clie_id_consumo = Cliente.clie_id
		FROM Cliente
		WHERE Cliente.clie_dni = @cupon_clie_dni_consumo;
		UPDATE TOP (1) Cupon
		SET
			cupon_clie_id_consumo = @cupon_clie_id_consumo,
			cupon_fecha_consumo = @cupon_fecha_consumo
		WHERE Cupon.cupon_clie_id_compra = @cupon_clie_id_consumo
			AND Cupon.cupon_ofer_id = @cupon_ofer_id
			AND Cupon.cupon_fecha_compra = @cupon_fecha_compra
			AND Cupon.cupon_fecha_consumo IS NULL;
		FETCH NEXT FROM curs_cupones_consumidos INTO
			@cupon_clie_dni_consumo,
			@cupon_ofer_id,
			@cupon_fecha_compra,
			@cupon_fecha_consumo;
	END
	CLOSE curs_cupones_consumidos;
	DEALLOCATE curs_cupones_consumidos;
END

/*
SELECT
	Oferta_Fecha_Compra,
	Oferta_Codigo,
	Cli_Dni,
	Oferta_Entregado_Fecha
FROM gd_esquema.Maestra
WHERE Provee_Ciudad IS NOT NULL;

SELECT COUNT(*)
FROM Cupon
WHERE cupon_fecha_consumo IS NOT NULL;
*/