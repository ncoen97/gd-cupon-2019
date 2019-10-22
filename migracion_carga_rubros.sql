CREATE PROC migracion_carga_rubros AS
BEGIN
	INSERT INTO Rubro (
		rubro_descripcion
	)
	SELECT DISTINCT Provee_Rubro
	FROM gd_esquema.Maestra
	WHERE Provee_Rubro IS NOT NULL;
END