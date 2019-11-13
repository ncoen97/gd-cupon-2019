IF OBJECT_ID('[SOCORRO].Item', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Item;
IF OBJECT_ID('[SOCORRO].Factura', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Factura;
IF OBJECT_ID('[SOCORRO].Carga', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Carga;
IF OBJECT_ID('[SOCORRO].Cupon', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Cupon;
IF OBJECT_ID('[SOCORRO].Oferta', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Oferta;
IF OBJECT_ID('[SOCORRO].Cliente', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Cliente;
IF OBJECT_ID('[SOCORRO].Tipo_de_pago', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Tipo_de_pago;
IF OBJECT_ID('[SOCORRO].Tarjeta', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Tarjeta;
IF OBJECT_ID('[SOCORRO].Proveedor', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Proveedor;
IF OBJECT_ID('[SOCORRO].Rubro', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Rubro;
IF OBJECT_ID('[SOCORRO].Administrador', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Administrador;
IF OBJECT_ID('[SOCORRO].RolxUsuario', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].RolxUsuario;
IF OBJECT_ID('[SOCORRO].FuncionalidadxRol', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].FuncionalidadxRol;
IF OBJECT_ID('[SOCORRO].Rol', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Rol;
IF OBJECT_ID('[SOCORRO].Funcionalidad', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Funcionalidad;
IF OBJECT_ID('[SOCORRO].Usuario', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Usuario;



IF OBJECT_ID('SOCORRO.migracion_insert_rubros') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_rubros;
IF OBJECT_ID('SOCORRO.migracion_insert_roles') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_roles;
IF OBJECT_ID('SOCORRO.migracion_insert_funcionalidades') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_funcionalidades;
IF OBJECT_ID('SOCORRO.migracion_insert_funcionalidadesxrol') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_funcionalidadesxrol;
IF OBJECT_ID('SOCORRO.migracion_insert_tipos_de_pago') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_tipos_de_pago;
IF OBJECT_ID('SOCORRO.migracion_insert_proveedores') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_proveedores;
IF OBJECT_ID('SOCORRO.migracion_insert_clientes') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_clientes;
IF OBJECT_ID('SOCORRO.migracion_insert_ofertas') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_ofertas;
IF OBJECT_ID('SOCORRO.migracion_insert_cargas') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_cargas;
IF OBJECT_ID('SOCORRO.migracion_insert_cupones') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_cupones;
IF OBJECT_ID('SOCORRO.migracion_insert_facturas') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_facturas; 
IF OBJECT_ID('SOCORRO.migracion_insert_items') IS NOT NULL
	DROP PROCEDURE SOCORRO.migracion_insert_items; 
IF OBJECT_ID('SOCORRO.fnIsBlockedUser') IS NOT NULL
	DROP FUNCTION SOCORRO.fnIsBlockedUser; 
IF OBJECT_ID('SOCORRO.validarLogin') IS NOT NULL
	DROP PROCEDURE SOCORRO.validarLogin;
IF OBJECT_ID('SOCORRO.fnValidarNuevoUsername') IS NOT NULL
	DROP FUNCTION SOCORRO.fn_validar_nuevo_username;
IF OBJECT_ID('SOCORRO.getRolesUsuario') IS NOT NULL
	DROP FUNCTION SOCORRO.getRolesUsuario
IF OBJECT_ID('SOCORRO.sp_registro_cliente') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_registro_cliente;

USE GD2C2019;
SET NOCOUNT ON;
GO

IF NOT EXISTS
	(SELECT *
	FROM sys.schemas
	WHERE name = 'SOCORRO')
BEGIN
	EXEC('CREATE SCHEMA SOCORRO AUTHORIZATION gd');
END
GO

CREATE TABLE SOCORRO.Cliente (
  clie_id int IDENTITY PRIMARY KEY,
  clie_user_id int,
  clie_nombre nvarchar(255),
  clie_apellido nvarchar(255),
  clie_dni numeric(18,0),
  clie_email nvarchar(255),
  clie_telefono numeric(18,0),
  clie_direccion nvarchar(255),
  clie_codigo_postal char(5),
  clie_fecha_nacimiento datetime,
  clie_ciudad nvarchar(255),
  clie_saldo numeric(18, 2),
  clie_habilitado bit DEFAULT 1
);

CREATE TABLE SOCORRO.Proveedor (
  prov_id int IDENTITY PRIMARY KEY,
  prov_user_id int,
  prov_razon_social nvarchar(100),
  prov_email nvarchar(50),
  prov_telefono numeric(18, 0),
  prov_direccion nvarchar(100),
  prov_codigo_postal char(4),
  prov_ciudad nvarchar(255),
  prov_cuit nvarchar(20),
  prov_rubro_id int,
  prov_habilitado bit DEFAULT 1
);

CREATE TABLE SOCORRO.Carga (
  carg_id int IDENTITY PRIMARY KEY,
  carg_fecha datetime,
  carg_clie_id int,
  carg_tipo_de_pago_id int,
  carg_monto numeric(18, 2),
  carg_tarj_id int
);

CREATE TABLE SOCORRO.Rubro (
  rubro_id int IDENTITY PRIMARY KEY,
  rubro_descripcion nvarchar(100)
);

CREATE TABLE SOCORRO.Tarjeta (
  tarj_id int IDENTITY PRIMARY KEY,
  tarj_numero int,
  tarj_vencimiento datetime,
  tarj_titular nvarchar(50)
);

CREATE TABLE SOCORRO.Oferta (
  ofer_id nvarchar(50) PRIMARY KEY,
  ofer_descripcion nvarchar(255),
  ofer_fecha_publicacion datetime,
  ofer_fecha_vencimiento datetime,
  ofer_precio_oferta numeric(18, 2),
  ofer_precio_lista numeric(18, 2),
  ofer_prov_id int,
  ofer_stock numeric(18, 0),
  ofer_max_cupon_por_usuario int,
  ofer_habilitada bit DEFAULT 1
);

CREATE TABLE SOCORRO.Cupon (
  cupon_id int IDENTITY PRIMARY KEY,
  cupon_fecha_compra datetime,
  cupon_ofer_id nvarchar(50),
  cupon_clie_id_compra int,
  cupon_fecha_consumo datetime,
  cupon_clie_id_consumo int
);

CREATE TABLE SOCORRO.Administrador (
	admin_id int IDENTITY PRIMARY KEY,
	admin_user_id int,
	admin_nombre nvarchar(255),
	admin_apellido nvarchar(255)
);

CREATE TABLE SOCORRO.Factura (
  fact_id numeric(18, 0) PRIMARY KEY,
  fact_fecha_desde datetime,
  fact_fecha_hasta datetime,
  fact_admin_id int,
  fact_prov_id int
);

CREATE TABLE SOCORRO.Item (
  item_fact_id numeric(18, 0),
  item_id int,
  item_ofer_id nvarchar(50),
  item_precio numeric(18, 2),
  item_cantidad int,
  PRIMARY KEY (item_fact_id, item_id)
);

CREATE TABLE SOCORRO.Usuario (
  user_id int IDENTITY PRIMARY KEY,
  user_username nvarchar(20),
  user_pass nvarchar(255),
  user_intentos int DEFAULT 0,
  user_habilitado bit DEFAULT 1
);

CREATE TABLE SOCORRO.Tipo_de_pago (
  tipo_de_pago_id int IDENTITY PRIMARY KEY,
  tipo_de_pago_descripcion nvarchar(100),
  tipo_de_pago_habilitado bit DEFAULT 1
);

CREATE TABLE SOCORRO.RolxUsuario (
  [user_id] int,
  rol_id int,
  PRIMARY KEY ([user_id], rol_id)
);

CREATE TABLE SOCORRO.Rol (
  rol_id int PRIMARY KEY,
  rol_nombre nvarchar(20),
  rol_habilitado bit DEFAULT 1
);

CREATE TABLE SOCORRO.Funcionalidad (
  func_id int PRIMARY KEY,
  func_descripcion nvarchar(255)
);

CREATE TABLE SOCORRO.FuncionalidadxRol (
  func_id int,
  rol_id int,
  PRIMARY KEY (func_id, rol_id)
);

ALTER TABLE SOCORRO.Cliente ADD FOREIGN KEY (clie_user_id) REFERENCES SOCORRO.Usuario ([user_id]);

ALTER TABLE SOCORRO.RolxUsuario ADD FOREIGN KEY ([user_id]) REFERENCES SOCORRO.Usuario ([user_id]);

ALTER TABLE SOCORRO.RolxUsuario ADD FOREIGN KEY (rol_id) REFERENCES SOCORRO.Rol (rol_id);

ALTER TABLE SOCORRO.Administrador ADD FOREIGN KEY (admin_user_id) REFERENCES SOCORRO.Usuario ([user_id]);

ALTER TABLE SOCORRO.Proveedor ADD FOREIGN KEY (prov_user_id) REFERENCES SOCORRO.Usuario ([user_id]);

ALTER TABLE SOCORRO.Proveedor ADD FOREIGN KEY (prov_rubro_id) REFERENCES SOCORRO.Rubro (rubro_id);

ALTER TABLE SOCORRO.Carga ADD FOREIGN KEY (carg_clie_id) REFERENCES SOCORRO.Cliente (clie_id);

ALTER TABLE SOCORRO.Carga ADD FOREIGN KEY (carg_tarj_id) REFERENCES SOCORRO.Tarjeta (tarj_id);

ALTER TABLE SOCORRO.Carga ADD FOREIGN KEY (carg_tipo_de_pago_id) REFERENCES SOCORRO.Tipo_de_pago (tipo_de_pago_id);

ALTER TABLE SOCORRO.Oferta ADD FOREIGN KEY (ofer_prov_id) REFERENCES SOCORRO.Proveedor (prov_id);

ALTER TABLE SOCORRO.Cupon ADD FOREIGN KEY (cupon_clie_id_compra) REFERENCES SOCORRO.Cliente (clie_id);

ALTER TABLE SOCORRO.Cupon ADD FOREIGN KEY (cupon_clie_id_consumo) REFERENCES SOCORRO.Cliente (clie_id);

ALTER TABLE SOCORRO.Cupon ADD FOREIGN KEY (cupon_ofer_id) REFERENCES SOCORRO.Oferta (ofer_id);

ALTER TABLE SOCORRO.Factura ADD FOREIGN KEY (fact_prov_id) REFERENCES SOCORRO.Proveedor (prov_id);

ALTER TABLE SOCORRO.Factura ADD FOREIGN KEY (fact_admin_id) REFERENCES SOCORRO.Administrador (admin_id);

ALTER TABLE SOCORRO.Item ADD FOREIGN KEY (item_fact_id) REFERENCES SOCORRO.Factura (fact_id);

ALTER TABLE SOCORRO.Item ADD FOREIGN KEY (item_ofer_id) REFERENCES SOCORRO.Oferta (ofer_id);

ALTER TABLE SOCORRO.FuncionalidadxRol ADD FOREIGN KEY (rol_id) REFERENCES SOCORRO.Rol (rol_id);

ALTER TABLE SOCORRO.FuncionalidadxRol ADD FOREIGN KEY (func_id) REFERENCES SOCORRO.Funcionalidad (func_id);

PRINT SYSDATETIME();
PRINT '(1/13) - Tablas creadas.' + CHAR(13);

GO

CREATE TRIGGER SOCORRO.tr_item_id
ON SOCORRO.Item
INSTEAD OF INSERT
AS
BEGIN
	DECLARE
		@item_fact_id numeric(18, 0),
		@item_ofer_id nvarchar(50),
		@item_precio numeric(18, 2),
		@item_cantidad int,
		@item_id int;
	DECLARE curs_items CURSOR FOR
		SELECT
			item_fact_id,
			item_ofer_id,
			item_precio,
			item_cantidad
		FROM inserted
		ORDER BY item_fact_id;
	OPEN curs_items;
	FETCH NEXT FROM curs_items INTO
		@item_fact_id,
		@item_ofer_id,
		@item_precio,
		@item_cantidad;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @item_fact_id IN (SELECT item_fact_id FROM SOCORRO.Item)
		BEGIN
			SELECT
				@item_id = MAX(item_id) + 1
			FROM SOCORRO.Item
			WHERE item_fact_id = @item_fact_id;
		END
		ELSE
		BEGIN
			SET @item_id = 1;
		END
		INSERT INTO SOCORRO.Item (
			item_id,
			item_fact_id,
			item_ofer_id,
			item_precio,
			item_cantidad
		) VALUES (
			@item_id,
			@item_fact_id,
			@item_ofer_id,
			@item_precio,
			@item_cantidad
		);
		FETCH NEXT FROM curs_items INTO
			@item_fact_id,
			@item_ofer_id,
			@item_precio,
			@item_cantidad;
	END
	CLOSE curs_items;
	DEALLOCATE curs_items;
END
GO

CREATE PROC SOCORRO.migracion_insert_funcionalidades AS
BEGIN
	INSERT INTO SOCORRO.Funcionalidad (func_id, func_descripcion)
	VALUES
		(1, 'ABM de Rol'),
		(2, 'ABM de Clientes'),
		(3, 'ABM de Proveedor'),
		(4, 'Carga de Crédito'),
		(5, 'Confección y Publicación de Ofertas'),
		(6, 'Comprar Oferta'),
		(7, 'Consumo de Oferta'),
		(8, 'Facturación a Proveedor'),
		(9, 'Listado Estadístico');
END
GO

CREATE PROC SOCORRO.migracion_insert_funcionalidadesxrol AS
BEGIN
	INSERT INTO SOCORRO.FuncionalidadxRol (rol_id, func_id)
	VALUES
		-- clientes:
		(1, 2),
		(1, 4),
		(1, 6),
		-- proveedores:
		(2, 3),
		(2, 5),
		(2, 7),
		-- admins:
		(3, 1),
		(3, 8),
		(3, 9);
END
GO

CREATE PROC SOCORRO.migracion_insert_rubros AS
BEGIN
	INSERT INTO SOCORRO.Rubro (
		rubro_descripcion
	)
	SELECT DISTINCT Provee_Rubro
	FROM gd_esquema.Maestra
	WHERE Provee_Rubro IS NOT NULL;
END
GO

CREATE PROC SOCORRO.migracion_insert_roles AS
BEGIN
	INSERT INTO SOCORRO.Rol (rol_id, rol_nombre)
	VALUES
		(1, 'Cliente'),
		(2, 'Proveedor'),
		(3, 'Administrador');
END
GO

CREATE PROC SOCORRO.migracion_insert_tipos_de_pago AS
BEGIN
	INSERT INTO SOCORRO.Tipo_de_pago
		(tipo_de_pago_descripcion)
	SELECT DISTINCT Tipo_Pago_Desc
	FROM gd_esquema.Maestra
	WHERE Tipo_Pago_Desc IS NOT NULL;
END
GO

CREATE PROC SOCORRO.migracion_insert_proveedores AS
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
			@prov_rubro_id = r.rubro_id
		FROM Rubro r
		WHERE r.rubro_descripcion = @prov_rubro;
		-- creo un usuario para el proveedor
		-- con los valores por defecto
		-- (el user_id va autoincrementando y 
		-- lo demás es null por no inventar datos)
		INSERT INTO SOCORRO.Usuario DEFAULT VALUES;
		-- para tener el user_id recién usado:
		SET @prov_user_id = SCOPE_IDENTITY();
		INSERT INTO SOCORRO.RolxUsuario (
			[user_id],
			rol_id
		) VALUES (
			@prov_user_id,
			2
		);
		INSERT INTO SOCORRO.Proveedor (
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
GO

CREATE PROC SOCORRO.migracion_insert_clientes AS
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
		INSERT INTO SOCORRO.Usuario DEFAULT VALUES;
		-- para tener el user_id recién usado:
		SET @clie_user_id = SCOPE_IDENTITY();
		INSERT INTO SOCORRO.RolxUsuario (
			[user_id],
			rol_id
		) VALUES (
			@clie_user_id,
			1
		);
		INSERT INTO SOCORRO.Cliente(
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
GO

CREATE PROC SOCORRO.migracion_insert_ofertas AS
BEGIN
	INSERT INTO SOCORRO.Oferta (
		ofer_id,
		ofer_descripcion,
		ofer_fecha_publicacion,
		ofer_fecha_vencimiento,
		ofer_precio_oferta,
		ofer_precio_lista,
		ofer_prov_id,
		ofer_stock
	)
	SELECT DISTINCT
		Oferta_Codigo,
		Oferta_Descripcion,
		Oferta_Fecha,
		Oferta_Fecha_Venc,
		Oferta_Precio,
		Oferta_Precio_Ficticio,
		(SELECT
			p.prov_id
		FROM SOCORRO.Proveedor p
		WHERE p.prov_cuit = maestra.Provee_CUIT) prov_id,
		Oferta_Cantidad
	FROM gd_esquema.Maestra maestra
	WHERE Oferta_Codigo IS NOT NULL;
END
GO

CREATE PROC SOCORRO.migracion_insert_cargas AS
BEGIN
	INSERT INTO SOCORRO.Carga (
		carg_clie_id,
		carg_monto,
		carg_fecha,
		carg_tipo_de_pago_id
	)
	SELECT
		(SELECT c.clie_id
		FROM SOCORRO.Cliente c
		WHERE c.clie_dni = maestra.Cli_Dni) clie_id,
		Carga_Credito,
		Carga_Fecha,
		(SELECT t.tipo_de_pago_id
		FROM SOCORRO.Tipo_de_pago t
		WHERE t.tipo_de_pago_descripcion = maestra.Tipo_Pago_Desc) tipo_de_pago_id
	FROM gd_esquema.Maestra maestra
	WHERE Carga_Credito IS NOT NULL;
END
GO

CREATE PROC SOCORRO.migracion_insert_cupones AS
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
			@cupon_clie_id = c.clie_id
		FROM SOCORRO.Cliente c
		WHERE c.clie_dni = @cupon_clie_dni;
		IF @cupon_fecha_consumo IS NOT NULL
		BEGIN
			INSERT INTO SOCORRO.Cupon (
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
			INSERT INTO SOCORRO.Cupon (
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
GO

CREATE PROC SOCORRO.migracion_insert_facturas AS
BEGIN
	DECLARE
		@fact_prov_id int,
		@fact_prov_rs nvarchar(100),
		@fact_id numeric(18, 0),
		@fact_fecha_hasta datetime;
	DECLARE curs_facturas CURSOR FOR (
		SELECT DISTINCT
			Provee_RS,
			Factura_Nro,
			Factura_Fecha
		FROM gd_esquema.Maestra
		WHERE Factura_Fecha IS NOT NULL
	);
	OPEN curs_facturas;
	FETCH NEXT FROM curs_facturas INTO
		@fact_prov_rs,
		@fact_id,
		@fact_fecha_hasta;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT
			@fact_prov_id = p.prov_id
		FROM SOCORRO.Proveedor p
		WHERE p.prov_razon_social = @fact_prov_rs;
		INSERT INTO SOCORRO.Factura (
			fact_id,
			fact_prov_id,
			fact_fecha_hasta
		) VALUES (
			@fact_id,
			@fact_prov_id,
			@fact_fecha_hasta
		);
		FETCH NEXT FROM curs_facturas INTO
			@fact_prov_rs,
			@fact_id,
			@fact_fecha_hasta;
	END
	CLOSE curs_facturas;
	DEALLOCATE curs_facturas;
END
GO

CREATE PROC SOCORRO.migracion_insert_items AS
BEGIN
	INSERT INTO SOCORRO.Item (
		item_fact_id,
		item_ofer_id,
		item_precio,
		item_cantidad
	)
	SELECT
		Factura_Nro,
		Oferta_Codigo,
		Oferta_Precio,
		1
	FROM gd_esquema.Maestra
	WHERE Factura_Fecha IS NOT NULL;
END
GO

EXEC SOCORRO.migracion_insert_rubros;
PRINT SYSDATETIME();
PRINT '(2/13) - Rubros insertados.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_roles;
PRINT SYSDATETIME();
PRINT '(3/13) - Roles insertados.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_funcionalidades;
PRINT SYSDATETIME();
PRINT '(4/13) - Funcionalidades insertadas.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_funcionalidadesxrol;
PRINT SYSDATETIME();
PRINT '(5/13) - Funcionalidades por Rol insertadas.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_tipos_de_pago;
PRINT SYSDATETIME();
PRINT '(6/13) - Tipos de Pago insertados.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_proveedores;
PRINT SYSDATETIME();
PRINT '(7/13) - Proveedores insertados.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_clientes;
PRINT SYSDATETIME();
PRINT '(8/13) - Clientes insertados.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_ofertas;
PRINT SYSDATETIME();
PRINT '(9/13) - Ofertas insertadas.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_cargas;
PRINT SYSDATETIME();
PRINT '(10/13) - Cargas insertadas.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_cupones;
PRINT SYSDATETIME();
PRINT '(11/13) - Cupones insertados.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_facturas;
PRINT SYSDATETIME();
PRINT '(12/13) - Facturas insertadas.' + CHAR(13);
GO
EXEC SOCORRO.migracion_insert_items;
PRINT SYSDATETIME();
PRINT '(13/13) - Items insertados.' + CHAR(13);
GO

/*	PROCEDURE 	*/

CREATE FUNCTION [SOCORRO].fnIsBlockedUser(@username nvarchar(50))
RETURNS bit
AS
 BEGIN
	IF ((SELECT user_intentos FROM [SOCORRO].Usuario WHERE user_username = @username) >= 3)
		RETURN 1
	RETURN 0
 END	
go

create PROCEDURE [SOCORRO].validarLogin(@username nvarchar(20),@password nvarchar(20))
as
begin
	IF ((SELECT SOCORRO.fnIsBlockedUser(@username)) = 1)
			RETURN -2 /*Usuario bloqueado*/
	DECLARE @hash nvarchar(255)
	DECLARE @user_id int

	SET @hash = HASHBYTES('SHA2_256', CONVERT(nvarchar(32),@password))
	SET @user_id = (SELECT user_id FROM [SOCORRO].Usuario WHERE user_username = @username AND user_pass = @hash)
	
	IF (@user_id IS NOT NULL)
		BEGIN 
		UPDATE [SOCORRO].Usuario SET user_intentos = 0 WHERE user_username = @username
		RETURN @user_id /*Usuario ok*/
		END
	ELSE 	
		BEGIN 
		UPDATE [SOCORRO].Usuario SET user_intentos = user_intentos + 1 WHERE user_username = @username
		RETURN -1 /*Usuario o Contraseña incorrecta*/
		END

end
go

CREATE FUNCTION [SOCORRO].getRolesUsuario(@username nvarchar(50))
RETURNS table
AS
	 RETURN (SELECT r.rol_id, rol_nombre, r.rol_habilitado FROM [SOCORRO].Rol r
             JOIN [SOCORRO].RolxUsuario rxu ON (rxu.rol_id = r.rol_id) 
             JOIN [SOCORRO].Usuario u ON (u.user_id = rxu.user_id)
             WHERE u.user_username = @username AND r.rol_habilitado = 1)
GO


CREATE FUNCTION [SOCORRO].fnValidarNuevoUsername (
    @username nvarchar(20)
) RETURNS int AS
BEGIN
    IF EXISTS (
        SELECT user_username
        FROM SOCORRO.Usuario u
        WHERE u.user_username = @username
    ) RETURN 1;
    RETURN 0;
END
go

CREATE PROC [SOCORRO].sp_registro_cliente (
    @user_username nvarchar(20),
    @user_pass nvarchar(255),
    @clie_nombre nvarchar(255),
    @clie_apellido nvarchar(255),
    @clie_dni numeric(18,0),
    @clie_email nvarchar(255),
    @clie_telefono numeric(18,0),
    @clie_direccion nvarchar(255),
    @clie_codigo_postal char(5),
    @clie_fecha_nacimiento datetime,
    @clie_ciudad nvarchar(255)
) AS
BEGIN
    SET XACT_ABORT ON;
    BEGIN TRY
        BEGIN TRANSACTION
            IF (SOCORRO.fnValidarNuevoUsername(@user_username) = 1)
                RETURN 1;
            DECLARE
                @user_id int,
                @pass_hashed nvarchar(255);
            INSERT INTO SOCORRO.Usuario (
                user_username,
                user_pass,
                user_intentos
            ) VALUES (
                @user_username,
                HASHBYTES('SHA2_256', @user_pass),
                0
            );
            SET @user_id = SCOPE_IDENTITY();
            INSERT INTO Cliente (
                clie_user_id,
                clie_nombre,
                clie_apellido,
                clie_dni,
                clie_email,
                clie_telefono,
                clie_direccion,
                clie_codigo_postal,
                clie_fecha_nacimiento,
                clie_ciudad
            ) VALUES (
                @user_id,
                @clie_nombre,
                @clie_apellido,
                @clie_dni,
                @clie_email,
                @clie_telefono,
                @clie_direccion,
                @clie_codigo_postal,
                @clie_fecha_nacimiento,
                @clie_ciudad
            );
        COMMIT
    END TRY
    BEGIN CATCH
        PRINT 'Algún error saltó.';
        IF @@TRANCOUNT > 0
            ROLLBACK
    END CATCH
END