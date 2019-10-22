-- DROP PROC migracion_insert_rubros;
CREATE PROC migracion_insert_rubros AS
BEGIN
	INSERT INTO Rubro (
		rubro_descripcion
	)
	SELECT DISTINCT Provee_Rubro
	FROM gd_esquema.Maestra
	WHERE Provee_Rubro IS NOT NULL;
END