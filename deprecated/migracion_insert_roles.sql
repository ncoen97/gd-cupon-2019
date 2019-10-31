-- DROP PROC migracion_insert_roles;
CREATE PROC migracion_insert_roles AS
BEGIN
	INSERT INTO Rol (rol_id, rol_nombre)
	VALUES
		(1, 'Cliente'),
		(2, 'Proveedor'),
		(3, 'Administrador');
END