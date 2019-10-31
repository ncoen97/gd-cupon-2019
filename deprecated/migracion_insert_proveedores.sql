--------------------------
-- CARGA DE PROVEEDORES --
--------------------------

/*    << RESUMEN >>
 * Es un stored procedure que
 * hace un SELECT de los proveedores de la maestra
 * y los carga con un cursor en la tabla nueva,
 * creando un usuario para cada uno
 * y guardando el rubro_id correspondiente.
 */
 
-- DROP PROC migracion_insert_proveedores;
CREATE PROC migracion_insert_proveedores AS
BEGIN
	DECLARE -- todos los campos que necesita la tabla
		@prov_user_id int,
		@prov_rs nvarchar(100),
		@prov_dom nvarchar(100),
		@prov_ciudad nvarchar(255),
		@prov_telefono numeric(18, 0),
		@prov_cuit nvarchar(20),
		@prov_rubro nvarchar(100),	-- trae el rubro como string
		@prov_rubro_id int;			-- pero lo guarda como id (int)
	DECLARE curs_proveedor CURSOR FOR
		SELECT DISTINCT		-- este select trae los
			Provee_RS,		-- datos de proveedores
			Provee_Dom,		-- sin repetir
			Provee_Ciudad,
			Provee_Telefono,
			Provee_CUIT,
			Provee_Rubro
		FROM gd_esquema.Maestra
		WHERE Provee_RS IS NOT NULL;
	OPEN curs_proveedor;
	FETCH NEXT FROM curs_proveedor INTO
		@prov_rs,
		@prov_dom,
		@prov_ciudad,
		@prov_telefono,
		@prov_cuit,
		@prov_rubro;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT	-- selecciono el rubro_id correspondiente!
			@prov_rubro_id = Rubro.rubro_id
		FROM Rubro
		WHERE Rubro.rubro_descripcion = @prov_rubro;
		-- creo un usuario para el proveedor
		-- con los valores por defecto
		-- (el user_id va autoincrementando y 
		-- lo demás es null por no inventar datos)
		INSERT INTO Usuario DEFAULT VALUES;
		-- para tener el user_id recién usado:
		SET @prov_user_id = SCOPE_IDENTITY();
		INSERT INTO RolxUsuario (
			[user_id],
			rol_id
		) VALUES (
			@prov_user_id,
			2
		);
		INSERT INTO Proveedor (
			prov_user_id,
			prov_razon_social,
			prov_direccion,
			prov_ciudad,
			prov_telefono,
			prov_cuit,
			prov_rubro_id
		) VALUES (
			@prov_user_id,
			@prov_rs,
			@prov_dom,
			@prov_ciudad,
			@prov_telefono,
			@prov_cuit,
			@prov_rubro_id
		);
		FETCH NEXT FROM curs_proveedor INTO
			@prov_rs,
			@prov_dom,
			@prov_ciudad,
			@prov_telefono,
			@prov_cuit,
			@prov_rubro;
	END
	CLOSE curs_proveedor;
	DEALLOCATE curs_proveedor;
END

/*
EXEC migracion_carga_proveedores;

SELECT * FROM Proveedor
JOIN Rubro ON Rubro.rubro_id = Proveedor.prov_rubro_id;

SELECT * FROM gd_esquema.Maestra;
*/