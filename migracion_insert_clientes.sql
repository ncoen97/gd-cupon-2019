-----------------------
-- CARGA DE CLIENTES --
-----------------------

/*    << RESUMEN >>
 * Es un stored procedure que
 * hace un SELECT de los clientes de la maestra
 * y los carga con un cursor en la tabla nueva,
 * creando un usuario para cada uno.
 */
 
-- DROP PROC migracion_insert_clientes;
CREATE PROC migracion_insert_clientes AS
BEGIN
	DECLARE -- todos los campos que necesita la tabla
		@clie_user_id int,
		@clie_nombre nvarchar(255),
		@clie_apellido nvarchar(255),
		@clie_dni numeric(18, 0),
		@clie_direccion nvarchar(255),
		@clie_telefono numeric(18, 0),
		@clie_email nvarchar(255),
		@clie_fecha_nacimiento datetime,
		@clie_ciudad nvarchar(255);
	DECLARE curs_cliente CURSOR FOR
		SELECT DISTINCT			-- este select trae los
			Cli_Nombre,			-- datos de clientes
			Cli_Apellido,		-- sin repetir
			Cli_Dni,
			Cli_Direccion,
			Cli_Telefono,
			Cli_Mail,
			Cli_Fecha_Nac,
			Cli_Ciudad
		FROM gd_esquema.Maestra;
	OPEN curs_cliente;
	FETCH NEXT FROM curs_cliente INTO
		@clie_nombre,
		@clie_apellido,
		@clie_dni,
		@clie_direccion,
		@clie_telefono,
		@clie_email,
		@clie_fecha_nacimiento,
		@clie_ciudad;	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- creo un usuario para el cliente
		-- con los valores por defecto
		-- (el user_id va autoincrementando y 
		-- lo demás es null por no inventar datos)
		INSERT INTO Usuario DEFAULT VALUES;
		-- para tener el user_id recién usado:
		SET @clie_user_id = SCOPE_IDENTITY();
		INSERT INTO RolxUsuario (
			[user_id],
			rol_id
		) VALUES (
			@clie_user_id,
			1
		);
		INSERT INTO Cliente(
			clie_user_id,
			clie_nombre,
			clie_apellido,
			clie_dni,
			clie_direccion,
			clie_telefono,
			clie_email,
			clie_fecha_nacimiento,
			clie_ciudad
		) VALUES (
			@clie_user_id,
			@clie_nombre,
			@clie_apellido,
			@clie_dni,
			@clie_direccion,
			@clie_telefono,
			@clie_email,
			@clie_fecha_nacimiento,
			@clie_ciudad
		);
		FETCH NEXT FROM curs_cliente INTO
			@clie_nombre,
			@clie_apellido,
			@clie_dni,
			@clie_direccion,
			@clie_telefono,
			@clie_email,
			@clie_fecha_nacimiento,
			@clie_ciudad;	
	END
	CLOSE curs_cliente;
	DEALLOCATE curs_cliente;
END

/*
EXEC migracion_insert_clientes;
SELECT * FROM gd_esquema.Maestra;
SELECT * FROM Cliente;
*/