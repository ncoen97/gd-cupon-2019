-- DROP PROC migracion_insert_cupones;
CREATE PROC migracion_insert_cupones AS
BEGIN
	DECLARE
		@cupon_clie_dni numeric(18, 0),
		@cupon_clie_id int,
		@cupon_fecha_consumo datetime,
		@cupon_fecha_compra datetime,
		@cupon_ofer_id nvarchar(50);
	DECLARE curs_cupones CURSOR FOR
		SELECT
			Oferta_Codigo,
			Cli_Dni,
			Oferta_Fecha_Compra,
			Oferta_Entregado_Fecha
		FROM gd_esquema.Maestra
		WHERE Oferta_Codigo IS NOT NULL AND Factura_Fecha IS NULL
		ORDER BY Oferta_Codigo, Cli_Dni, Oferta_Entregado_Fecha DESC;
	OPEN curs_cupones;
	FETCH NEXT FROM curs_cupones INTO
		@cupon_ofer_id,
		@cupon_clie_dni,
		@cupon_fecha_compra,
		@cupon_fecha_consumo;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT
			@cupon_clie_id = Cliente.clie_id
		FROM Cliente
		WHERE Cliente.clie_dni = @cupon_clie_dni;
		IF @cupon_fecha_consumo IS NOT NULL
		BEGIN
			INSERT INTO Cupon (
				cupon_clie_id_compra,
				cupon_fecha_compra,
				cupon_ofer_id,
				cupon_clie_id_consumo,
				cupon_fecha_consumo
			) VALUES (
				@cupon_clie_id,
				@cupon_fecha_compra,
				@cupon_ofer_id,
				@cupon_clie_id,
				@cupon_fecha_consumo
			);
			FETCH NEXT FROM curs_cupones INTO
				@cupon_ofer_id,
				@cupon_clie_dni,
				@cupon_fecha_compra,
				@cupon_fecha_consumo;
		END
		ELSE
		BEGIN
			INSERT INTO Cupon (
				cupon_clie_id_compra,
				cupon_fecha_compra,
				cupon_ofer_id
			) VALUES (
				@cupon_clie_id,
				@cupon_fecha_compra,
				@cupon_ofer_id
			);
		END
		FETCH NEXT FROM curs_cupones INTO
			@cupon_ofer_id,
			@cupon_clie_dni,
			@cupon_fecha_compra,
			@cupon_fecha_consumo;
	END
	CLOSE curs_cupones;
	DEALLOCATE curs_cupones;
END

/*
SELECT
	Oferta_Codigo,
	Cli_Dni,
	Oferta_Fecha_Compra,
	COUNT(*)
FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
GROUP BY
	Oferta_Codigo,
	Cli_Dni,
	Oferta_Fecha_Compra
HAVING COUNT(*) > 3
ORDER BY Oferta_Codigo, Cli_Dni;
*/