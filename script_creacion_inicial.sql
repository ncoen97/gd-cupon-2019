USE [GD2C2019]
SET NOCOUNT ON;
GO
-------------------------------------------------------------------
IF OBJECT_ID('[SOCORRO].Item', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Item;
IF OBJECT_ID('[SOCORRO].Factura', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Factura;
IF OBJECT_ID('[SOCORRO].Carga', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Carga;
IF OBJECT_ID('[SOCORRO].Cupon', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Cupon;
IF OBJECT_ID('[SOCORRO].Tarjeta', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Tarjeta;
IF OBJECT_ID('[SOCORRO].Oferta', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Oferta;
IF OBJECT_ID('[SOCORRO].Cliente', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Cliente;
IF OBJECT_ID('[SOCORRO].Tipo_de_pago', 'U') IS NOT NULL
	DROP TABLE [SOCORRO].Tipo_de_pago;
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
	DROP FUNCTION SOCORRO.fnValidarNuevoUsername;
IF OBJECT_ID('SOCORRO.getRolesUsuario') IS NOT NULL
	DROP FUNCTION SOCORRO.getRolesUsuario
IF OBJECT_ID('SOCORRO.sp_registro_cliente') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_registro_cliente;
IF OBJECT_ID('SOCORRO.sp_registro_proveedor') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_registro_proveedor;
IF OBJECT_ID('SOCORRO.sp_deshabilitar_cliente') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_deshabilitar_cliente;
IF OBJECT_ID('SOCORRO.sp_rehabilitar_cliente') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_rehabilitar_cliente;
IF OBJECT_ID('SOCORRO.sp_deshabilitar_proveedor') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_deshabilitar_proveedor;
IF OBJECT_ID('SOCORRO.sp_rehabilitar_proveedor') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_rehabilitar_proveedor;
IF OBJECT_ID('SOCORRO.sp_modificar_cliente') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_modificar_cliente;
IF OBJECT_ID('SOCORRO.sp_modificar_proveedor') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_modificar_proveedor;
IF OBJECT_ID('SOCORRO.sp_cargar_credito') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_cargar_credito;
IF OBJECT_ID('SOCORRO.sp_buscar_clientes') IS NOT NULL
	DROP PROCEDURE SOCORRO.sp_buscar_clientes;


IF NOT EXISTS
	(SELECT *
	FROM sys.schemas
	WHERE name = 'SOCORRO')
BEGIN
	EXEC('CREATE SCHEMA SOCORRO AUTHORIZATION gdCupon2019');
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
  prov_nombre_contacto nvarchar(255), --> TODO: revisar?
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
  tarj_clie_id int,
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

ALTER TABLE SOCORRO.Tarjeta ADD FOREIGN KEY (tarj_clie_id) REFERENCES SOCORRO.Cliente (clie_id);

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
		(4, 'Carga de Cr�dito'),
		(5, 'Confecci�n y Publicaci�n de Ofertas'),
		(6, 'Comprar Oferta'),
		(7, 'Consumo de Oferta'),
		(8, 'Facturaci�n a Proveedor'),
		(9, 'Listado Estad�stico');
END
GO

CREATE PROC SOCORRO.migracion_insert_funcionalidadesxrol AS
BEGIN
	INSERT INTO SOCORRO.FuncionalidadxRol (rol_id, func_id)
	VALUES
		-- clientes:
		(1, 4),
		(1, 6),
		-- proveedores:
		(2, 5),
		(2, 7),
		-- admins: TODO: todas???? qué pasa si publico oferta como admin???
		(3, 1),
		(3, 2),
		(3, 3),
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
		-- lo dem�s es null por no inventar datos)
		INSERT INTO SOCORRO.Usuario DEFAULT VALUES;
		-- para tener el user_id reci�n usado:
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
		-- lo dem�s es null por no inventar datos)
		INSERT INTO SOCORRO.Usuario DEFAULT VALUES;
		-- para tener el user_id reci�n usado:
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

--=====================================================
--    PROCEDURES Y FUNCTIONS PARA LA APLICACION
--=====================================================

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
		RETURN -1 /*Usuario o Contrase�a incorrecta*/
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

--DROP PROC SOCORRO.sp_registro_cliente;
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
			BEGIN
				PRINT 'REGISTRANDO CLIENTE '+@clie_nombre+': el username ya existe';
				ROLLBACK;
                RETURN 1;
			END
			PRINT 'REGISTRANDO CLIENTE '+@clie_nombre+': el username no existia; es valido';
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
			PRINT 'REGISTRANDO CLIENTE '+@clie_nombre+': usuario creado';
            SET @user_id = SCOPE_IDENTITY();
			INSERT INTO SOCORRO.RolxUsuario (
				[user_id],
				rol_id
			) VALUES (
				@user_id,
				1
			);
			PRINT 'REGISTRANDO CLIENTE '+@clie_nombre+': rol asignado';
            INSERT INTO SOCORRO.Cliente (
                clie_user_id,
                clie_nombre,
                clie_apellido,
                clie_dni,
                clie_email,
                clie_telefono,
                clie_direccion,
                clie_codigo_postal,
                clie_fecha_nacimiento,
                clie_ciudad,
				clie_saldo
            ) VALUES (
                @user_id,
                @clie_nombre,
                @clie_apellido,
                @clie_dni,
                @clie_email,
                @clie_telefono,
                @clie_direccion,
                @clie_codigo_postal,
                CAST(@clie_fecha_nacimiento AS datetime),
                @clie_ciudad,
				200
            );
			PRINT 'REGISTRANDO CLIENTE '+@clie_nombre+': datos de cliente registrados';
        COMMIT;
    END TRY
    BEGIN CATCH
        PRINT 'REGISTRANDO CLIENTE '+@clie_nombre+': Alg�n error salt�.';
        ROLLBACK;
    END CATCH
END
GO

--DROP PROC SOCORRO.sp_registro_proveedor;
CREATE PROC [SOCORRO].sp_registro_proveedor (
    @user_username nvarchar(20),
    @user_pass nvarchar(255),
	@prov_rs nvarchar(100),
	@prov_email nvarchar(50),
	@prov_dom nvarchar(100),
	@prov_cp char(4),
	@prov_ciudad nvarchar(255),
	@prov_telefono numeric(18, 0),
	@prov_cuit nvarchar(20),
	@prov_rubro_id int,
	@prov_nombre_contacto nvarchar(255)
) AS
BEGIN
    SET XACT_ABORT ON;
    BEGIN TRY --primero intento hacer la transaccion
        BEGIN TRANSACTION
			--si el user esta tomado, rollbackea y devuelve 1 (error)
            IF (SOCORRO.fnValidarNuevoUsername(@user_username) = 1)
			BEGIN
				PRINT 'REGISTRANDO PROVEEDOR '+@prov_rs+': el usuario ya figura!';
				ROLLBACK;
                RETURN 1;
            END
			PRINT 'REGISTRANDO PROVEEDOR '+@prov_rs+': el usuario no figura';
			DECLARE
                @user_id int,
                @pass_hashed nvarchar(255);
			--inserto el usuario primero
            INSERT INTO SOCORRO.Usuario (
                user_username,
                user_pass,
                user_intentos
            ) VALUES (
                @user_username,
                HASHBYTES('SHA2_256', @user_pass),
                0
            );
			PRINT 'REGISTRANDO PROVEEDOR '+@prov_rs+': el usuario fue creado';
			--busco el user_id recien asignado
            SET @user_id = SCOPE_IDENTITY();
			--asigno rol correspondiente a dicho usuario
			INSERT INTO SOCORRO.RolxUsuario (
				[user_id],
				rol_id
			) VALUES (
				@user_id,
				2
			);
			PRINT 'REGISTRANDO PROVEEDOR '+@prov_rs+': el rol fue asignado';
			--cargo finalmente los datos de proveedor
            INSERT INTO SOCORRO.Proveedor(
				prov_user_id,
                prov_razon_social,
				prov_email,
				prov_telefono,
				prov_direccion,
				prov_codigo_postal,
				prov_ciudad,
				prov_cuit,
				prov_rubro_id,
				prov_nombre_contacto
            ) VALUES (
				@user_id,
                @prov_rs,
                @prov_email,
                @prov_telefono,
                @prov_dom,
                @prov_cp,
                @prov_ciudad,
                @prov_cuit,
                @prov_rubro_id,
				@prov_nombre_contacto
            );
			PRINT 'REGISTRANDO PROVEEDOR '+@prov_rs+': el proveedor se cargo';
        COMMIT;
    END TRY
    BEGIN CATCH
		--si algo inseperado sucede, se va a ver este print
        PRINT 'REGISTRANDO PROVEEDOR '+@prov_rs+': Algun error salto.';
		--y se rollbackean todos los inserts
        ROLLBACK;
    END CATCH
END
GO

CREATE PROC SOCORRO.sp_deshabilitar_cliente (
	@clie_id int
) AS
BEGIN
	IF NOT(@clie_id IN (SELECT clie_id FROM SOCORRO.Cliente))
	BEGIN
		PRINT 'no existe el cliente';
		RETURN 1
	END
	UPDATE Cliente
	SET clie_habilitado = 0
	WHERE clie_id = @clie_id;
	RETURN 0
END
GO

CREATE PROC SOCORRO.sp_rehabilitar_cliente (
	@clie_id int
) AS
BEGIN
	IF NOT(@clie_id IN (SELECT clie_id FROM SOCORRO.Cliente))
	BEGIN
		PRINT 'no existe el cliente';
		RETURN 1
	END
	UPDATE Cliente
	SET clie_habilitado = 1
	WHERE clie_id = @clie_id;
	RETURN 0
END
GO

CREATE PROC SOCORRO.sp_deshabilitar_proveedor (
	@prov_id int
) AS
BEGIN
	IF NOT(@prov_id IN (SELECT prov_id FROM SOCORRO.Proveedor))
	BEGIN
		PRINT 'no existe el proveedor';
		RETURN 1
	END
	UPDATE SOCORRO.Proveedor
	SET prov_habilitado = 0
	WHERE prov_id = @prov_id;
	RETURN 0
END
GO

CREATE PROC SOCORRO.sp_rehabilitar_proveedor (
	@prov_id int
) AS
BEGIN
	IF NOT(@prov_id IN (SELECT prov_id FROM SOCORRO.Proveedor))
	BEGIN
		PRINT 'no existe el proveedor';
		RETURN 1
	END
	UPDATE SOCORRO.Proveedor
	SET prov_habilitado = 1
	WHERE prov_id = @prov_id;
	RETURN 0
END
GO

CREATE PROC SOCORRO.sp_modificar_cliente (
	@clie_id int,
	@nuevo_nombre nvarchar(255),
    @nuevo_apellido nvarchar(255),
    @nuevo_dni numeric(18,0),
    @nuevo_email nvarchar(255),
    @nuevo_telefono numeric(18,0),
    @nuevo_direccion nvarchar(255),
    @nuevo_codigo_postal char(5),
    @nuevo_fecha_nacimiento datetime,
    @nuevo_ciudad nvarchar(255) --> duda, ver enunciado (ABM Cliente)
) AS
BEGIN
	IF NOT(@clie_id IN (SELECT c.clie_id FROM SOCORRO.Cliente c))
	BEGIN
		PRINT 'no existe el cliente';
		RETURN 1;
	END
	UPDATE SOCORRO.Cliente
	SET
		clie_nombre = @nuevo_nombre,
		clie_apellido = @nuevo_apellido,
		clie_dni = @nuevo_dni,
		clie_email = @nuevo_email,
		clie_telefono = @nuevo_telefono,
		clie_direccion = @nuevo_direccion,
		clie_codigo_postal = @nuevo_codigo_postal,
		clie_fecha_nacimiento = @nuevo_fecha_nacimiento,
		clie_ciudad = @nuevo_ciudad;
	RETURN 0;
END
GO

CREATE PROC SOCORRO.sp_modificar_proveedor (
	@prov_id int,
	@nuevo_rs nvarchar(100),
	@nuevo_email nvarchar(50),
	@nuevo_dom nvarchar(100),
	@nuevo_cp char(4),
	@nuevo_ciudad nvarchar(255),
	@nuevo_telefono numeric(18, 0),
	@nuevo_cuit nvarchar(20),
	@nuevo_rubro_id int,
	@nuevo_nombre_contacto nvarchar(255)
) AS
BEGIN
	IF NOT(@prov_id IN (SELECT p.prov_id FROM SOCORRO.Proveedor p))
	BEGIN
		PRINT 'no existe el proveedor';
		RETURN 1;
	END
	UPDATE SOCORRO.Proveedor
	SET
		prov_razon_social = @nuevo_rs,
		prov_email = @nuevo_email,
		prov_direccion = @nuevo_dom,
		prov_codigo_postal = @nuevo_cp,
		prov_ciudad = @nuevo_ciudad,
		prov_telefono = @nuevo_telefono,
		prov_cuit = @nuevo_cuit,
		prov_rubro_id = @nuevo_rubro_id,
		prov_nombre_contacto = @nuevo_nombre_contacto;
	RETURN 0;
END
GO

CREATE PROC SOCORRO.sp_cargar_credito (
	@clie_id int,
	@monto int,
	@tarj_id int = NULL --> TODO: es int?
) AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			--check si cliente existe
			IF NOT(@clie_id IN (SELECT c.clie_id
								FROM SOCORRO.Cliente c))
			BEGIN
				ROLLBACK;
				PRINT 'no existe el cliente';
				RETURN 1;
			END
			--check si cliente habilitado
			IF (0 = (SELECT c.clie_habilitado
					FROM SOCORRO.Cliente c
					WHERE @clie_id = c.clie_id))
			BEGIN
				ROLLBACK;
				PRINT 'cliente no habilitado';
				RETURN 2;
			END
			--
			IF (@monto < 1)
			BEGIN
				ROLLBACK;
				PRINT 'monto menor a 1';
				RETURN 3;
			END
			-- TODO: faltan checks?
			IF (@tarj_id IN (SELECT t.tarj_id
								FROM SOCORRO.Tarjeta t
								WHERE t.tarj_clie_id = @clie_id))
			BEGIN
				INSERT INTO SOCORRO.Carga (
					carg_clie_id,
					carg_fecha,
					carg_monto,
					carg_tipo_de_pago_id,
					carg_tarj_id
				) VALUES (
					@clie_id,
					GETDATE(), --> TODO: esto esta mal! ver enunciado
					@monto,
					2,
					@tarj_id
				);
			END
			ELSE
			BEGIN
				INSERT INTO SOCORRO.Carga (
					carg_clie_id,
					carg_fecha,
					carg_monto,
					carg_tipo_de_pago_id
				) VALUES (
					@clie_id,
					GETDATE(), --> TODO: esto esta mal! ver enunciado
					@monto,
					1
				);
			END
		COMMIT;
	END TRY
	BEGIN CATCH
		PRINT 'algun error loco hay';
		ROLLBACK;
	END CATCH
END
GO

-- DROP PROC SOCORRO.sp_buscar_clientes
CREATE PROC SOCORRO.sp_buscar_clientes (
	@nombre varchar(255) = NULL,
	@apellido varchar(255) = NULL,
	@dni int = NULL,
	@email varchar(255) = NULL
) AS
BEGIN
	SELECT
		c.clie_nombre,
		c.clie_apellido,
		c.clie_dni,
		c.clie_email
	FROM SOCORRO.Cliente c
	WHERE ((c.clie_nombre LIKE '%'+@nombre+'%') OR (@nombre IS NULL))
		AND ((c.clie_apellido LIKE '%'+@apellido+'%') OR (@apellido IS NULL))
		AND ((c.clie_dni = @dni) OR (@dni IS NULL))
		AND ((c.clie_email LIKE '%'+@email+'%') OR (@email IS NULL));
END
GO

-- <ADMINISTRADOR PEDIDO EN PAG 14>
BEGIN
	DECLARE
		@user_id int,
		@pass nvarchar(20);
	SET @pass = 'w23e';
	INSERT INTO SOCORRO.Usuario (
		user_username,
		user_pass
	) VALUES (
		'admin',
		HASHBYTES('SHA2_256', @pass)
	);
	SET @user_id = SCOPE_IDENTITY();
	INSERT INTO SOCORRO.Administrador (
		admin_nombre,
		admin_apellido,
		admin_user_id
	) VALUES (
		'Administrador General',
		'',
		 @user_id
	);
	INSERT INTO SOCORRO.RolxUsuario (
		rol_id,
		[user_id]
	) VALUES (
		3,
		@user_id
	);
END
GO


-- </ADMINISTRADOR PEDIDO EN PAG 14>


--==============================================
--            DATOS DE TESTEO
--==============================================

EXEC SOCORRO.sp_registro_cliente
	@user_username = 'cliente',
	@user_pass = 'cliente',
	@clie_nombre = 'Pepe',
	@clie_apellido = 'Cualquiera',
	@clie_dni = 12345678,
	@clie_email = 'jaja_saludos@gmail.com',
	@clie_telefono = 1109876543,
	@clie_direccion = 'Calle Cualquiera 123',
	@clie_codigo_postal = '4321',
	@clie_fecha_nacimiento = '1995-05-05 00:00:00.000',
	@clie_ciudad = 'Tranquilandia';
GO

EXEC SOCORRO.sp_registro_proveedor
	@user_username = 'prov',
	@user_pass = 'prov',
	@prov_rs = 'Fulanoide SA',
	@prov_cuit = 12123456792,
	@prov_email = 'juass@gmail.com',
	@prov_telefono = 1109876345,
	@prov_dom = 'Calle Cualquiera 124',
	@prov_cp = '4321',
	@prov_ciudad = 'Tranquilandia',
	@prov_rubro_id = 2,
	@prov_nombre_contacto = 'Sr. Fulano';
GO

EXEC SOCORRO.sp_deshabilitar_cliente 219; --> pepe
GO

EXEC SOCORRO.sp_rehabilitar_cliente 219; --> pepe
GO

EXEC SOCORRO.sp_deshabilitar_proveedor 38; --> fulanoide
GO

EXEC SOCORRO.sp_rehabilitar_proveedor 38; --> fulanoide
GO

BEGIN
    INSERT INTO SOCORRO.Administrador (
        admin_nombre,
        admin_apellido,
        admin_user_id
    ) VALUES (
        'Pepe',
        'Cualquiera',
        257
    );
    INSERT INTO SOCORRO.RolxUsuario (
        rol_id,
        [user_id]
    ) VALUES (
        3,
        257
    );
END

/*
--cosas para probar usuario con rol doble
BEGIN
	INSERT INTO SOCORRO.Administrador (
		admin_nombre,
		admin_apellido,
		admin_user_id
	) VALUES (
		'Pepe',
		'Cualquiera',
		256
	);
	INSERT INTO SOCORRO.RolxUsuario (
		rol_id,
		[user_id]
	) VALUES (
		3,
		256
	);
END

SELECT *
FROM SOCORRO.Usuario u
JOIN SOCORRO.RolxUsuario rxu
	ON rxu.user_id = u.user_id
JOIN SOCORRO.Rol r
	ON r.rol_id = rxu.rol_id
WHERE u.user_id = 256;


SELECT *
FROM SOCORRO.Usuario u
ORDER BY u.user_id DESC


SELECT *
FROM SOCORRO.Proveedor p
WHERE p.prov_razon_social = 'Fulanoide SA';

-- trae los datos de pepe
SELECT *
FROM SOCORRO.Cliente c
JOIN SOCORRO.RolxUsuario rxu
	ON rxu.user_id = c.clie_user_id
WHERE clie_nombre = 'Pepe';

-- borra todo lo de pepe de la db:
DELETE FROM SOCORRO.Cliente WHERE clie_nombre = 'Pepe';
DELETE FROM SOCORRO.RolxUsuario WHERE [user_id] = 256;
DELETE FROM SOCORRO.Usuario
WHERE NOT (SOCORRO.Usuario.[user_id] IN
	(SELECT DISTINCT c.clie_user_id FROM SOCORRO.Cliente c
	UNION
	SELECT DISTINCT p.prov_user_id FROM SOCORRO.Proveedor p));

-- trae los roles de admin:
SELECT * FROM SOCORRO.getRolesUsuario('admin');
*/


