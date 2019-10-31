CREATE PROC migracion_insert_tipos_de_pago AS
BEGIN
	INSERT INTO Tipo_de_pago
		(tipo_de_pago_descripcion)
	SELECT DISTINCT Tipo_Pago_Desc
	FROM gd_esquema.Maestra
	WHERE Tipo_Pago_Desc IS NOT NULL;
END

/*
EXEC migracion_insert_tipos_de_pago;
SELECT * FROM Tipo_de_pago;
*/