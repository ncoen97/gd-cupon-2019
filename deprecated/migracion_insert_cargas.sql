-- DROP PROC migracion_insert_cargas;
CREATE PROC migracion_insert_cargas AS
BEGIN
	DECLARE
		@carg_fecha datetime,
		@carg_clie_dni numeric(18, 0),
		@carg_clie_id int,
		@carg_tipo_de_pago_desc nvarchar(100),
		@carg_tipo_de_pago_id int,
		@carg_monto numeric(18, 2);
	DECLARE curs_cargas CURSOR FOR
		SELECT
			Cli_Dni,
			Carga_Credito,
			Carga_Fecha,
			Tipo_Pago_Desc
		FROM gd_esquema.Maestra
		WHERE Carga_Credito IS NOT NULL;
	OPEN curs_cargas;
	FETCH NEXT FROM curs_cargas INTO
		@carg_clie_dni,
		@carg_monto,
		@carg_fecha,
		@carg_tipo_de_pago_desc;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT
			@carg_clie_id = Cliente.clie_id
		FROM Cliente
		WHERE Cliente.clie_dni = @carg_clie_dni;
		SELECT
			@carg_tipo_de_pago_id = Tipo_de_pago.tipo_de_pago_id
		FROM Tipo_de_pago
		WHERE Tipo_de_pago.tipo_de_pago_descripcion = @carg_tipo_de_pago_desc;
		INSERT INTO Carga (
			carg_clie_id,
			carg_fecha,
			carg_monto,
			carg_tipo_de_pago_id
		) VALUES (
			@carg_clie_id,
			@carg_fecha,
			@carg_monto,
			@carg_tipo_de_pago_id
		);
		FETCH NEXT FROM curs_cargas INTO
			@carg_clie_dni,
			@carg_monto,
			@carg_fecha,
			@carg_tipo_de_pago_desc;
	END
	CLOSE curs_cargas;
	DEALLOCATE curs_cargas;
END

/*

SELECT COUNT(*)
FROM Cliente;
SELECT COUNT(DISTINCT Cli_Dni) FROM gd_esquema.Maestra;
SELECT * FROM Carga;
DELETE FROM CARGA;
*/