/*

-- Ejecutar este comment
-- para empezar de cero.

DROP TABLE Item;
DROP TABLE Factura;
DROP TABLE Carga;
DROP TABLE Cupon;
DROP TABLE Oferta;
DROP TABLE Cliente;
DROP TABLE Tipo_de_pago;
DROP TABLE Tarjeta;
DROP TABLE Proveedor;
DROP TABLE Rubro;
DROP TABLE Administrador;
DROP TABLE RolxUsuario;
DROP TABLE FuncionalidadxRol;
DROP TABLE Rol;
DROP TABLE Funcionalidad;
DROP TABLE Usuario;

DROP PROC migracion_insert_rubros;
DROP PROC migracion_insert_roles;
DROP PROC migracion_insert_funcionalidades;
DROP PROC migracion_insert_funcionalidadesxrol;
DROP PROC migracion_insert_tipos_de_pago;
DROP PROC migracion_insert_proveedores;
DROP PROC migracion_insert_clientes;
DROP PROC migracion_insert_ofertas;
DROP PROC migracion_insert_cargas;
DROP PROC migracion_insert_cupones;
DROP PROC migracion_insert_facturas;
DROP PROC migracion_insert_items;

*/

USE GD2C2019;
SET NOCOUNT ON;

CREATE TABLE Cliente (
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
  clie_saldo numeric(18, 2)
);

CREATE TABLE Proveedor (
  prov_id int IDENTITY PRIMARY KEY,
  prov_user_id int,
  prov_razon_social nvarchar(100),
  prov_email nvarchar(50),
  prov_telefono numeric(18, 0),
  prov_direccion nvarchar(100),
  prov_codigo_postal char(4),
  prov_ciudad nvarchar(255),
  prov_cuit nvarchar(20),
  prov_rubro_id int
);

CREATE TABLE Carga (
  carg_id int IDENTITY PRIMARY KEY,
  carg_fecha datetime,
  carg_clie_id int,
  carg_tipo_de_pago_id int,
  carg_monto numeric(18, 2),
  carg_tarj_id int
);

CREATE TABLE Rubro (
  rubro_id int IDENTITY PRIMARY KEY,
  rubro_descripcion nvarchar(100)
);

CREATE TABLE Tarjeta (
  tarj_id int IDENTITY PRIMARY KEY,
  tarj_numero int,
  tarj_vencimiento datetime,
  tarj_titular nvarchar(50)
);

CREATE TABLE Oferta (
  ofer_id nvarchar(50) PRIMARY KEY,
  ofer_descripcion nvarchar(255),
  ofer_fecha_publicacion datetime,
  ofer_fecha_vencimiento datetime,
  ofer_precio_oferta numeric(18, 2),
  ofer_precio_lista numeric(18, 2),
  ofer_prov_id int,
  ofer_stock numeric(18, 0),
  ofer_max_cupon_por_usuario int
);

CREATE TABLE Cupon (
  cupon_id int IDENTITY PRIMARY KEY,
  cupon_fecha_compra datetime,
  cupon_ofer_id nvarchar(50),
  cupon_clie_id_compra int,
  cupon_fecha_consumo datetime,
  cupon_clie_id_consumo int
);

CREATE TABLE Administrador (
	admin_id int IDENTITY PRIMARY KEY,
	admin_user_id int,
	admin_nombre nvarchar(255),
	admin_apellido nvarchar(255)
);

CREATE TABLE Factura (
  fact_id numeric(18, 0) PRIMARY KEY,
  fact_fecha_desde datetime,
  fact_fecha_hasta datetime,
  fact_admin_id int,
  fact_prov_id int
);

CREATE TABLE Item (
  item_fact_id numeric(18, 0),
  item_id int,
  item_ofer_id nvarchar(50),
  item_precio numeric(18, 2),
  item_cantidad int,
  PRIMARY KEY (item_fact_id, item_id)
);

CREATE TABLE Usuario (
  [user_id] int IDENTITY PRIMARY KEY,
  user_username nvarchar(20),
  user_pass nvarchar(30),
  user_intentos int DEFAULT 0
);

CREATE TABLE Tipo_de_pago (
  tipo_de_pago_id int IDENTITY PRIMARY KEY,
  tipo_de_pago_descripcion nvarchar(100)
);

CREATE TABLE RolxUsuario (
  [user_id] int,
  rol_id int,
  PRIMARY KEY ([user_id], rol_id)
);

CREATE TABLE Rol (
  rol_id int PRIMARY KEY,
  rol_nombre nvarchar(20)
);

CREATE TABLE Funcionalidad (
  func_id int PRIMARY KEY,
  func_descripcion nvarchar(255)
);

CREATE TABLE FuncionalidadxRol (
  func_id int,
  rol_id int,
  PRIMARY KEY (func_id, rol_id)
);

ALTER TABLE Cliente ADD FOREIGN KEY (clie_user_id) REFERENCES Usuario ([user_id]);

ALTER TABLE RolxUsuario ADD FOREIGN KEY ([user_id]) REFERENCES Usuario ([user_id]);

ALTER TABLE RolxUsuario ADD FOREIGN KEY (rol_id) REFERENCES Rol (rol_id);

ALTER TABLE Administrador ADD FOREIGN KEY (admin_user_id) REFERENCES Usuario ([user_id]);

ALTER TABLE Proveedor ADD FOREIGN KEY (prov_user_id) REFERENCES Usuario ([user_id]);

ALTER TABLE Proveedor ADD FOREIGN KEY (prov_rubro_id) REFERENCES Rubro (rubro_id);

ALTER TABLE Carga ADD FOREIGN KEY (carg_clie_id) REFERENCES Cliente (clie_id);

ALTER TABLE Carga ADD FOREIGN KEY (carg_tarj_id) REFERENCES Tarjeta (tarj_id);

ALTER TABLE Carga ADD FOREIGN KEY (carg_tipo_de_pago_id) REFERENCES Tipo_de_pago (tipo_de_pago_id);

ALTER TABLE Oferta ADD FOREIGN KEY (ofer_prov_id) REFERENCES Proveedor (prov_id);

ALTER TABLE Cupon ADD FOREIGN KEY (cupon_clie_id_compra) REFERENCES Cliente (clie_id);

ALTER TABLE Cupon ADD FOREIGN KEY (cupon_clie_id_consumo) REFERENCES Cliente (clie_id);

ALTER TABLE Cupon ADD FOREIGN KEY (cupon_ofer_id) REFERENCES Oferta (ofer_id);

ALTER TABLE Factura ADD FOREIGN KEY (fact_prov_id) REFERENCES Proveedor (prov_id);

ALTER TABLE Factura ADD FOREIGN KEY (fact_admin_id) REFERENCES Administrador (admin_id);

ALTER TABLE Item ADD FOREIGN KEY (item_fact_id) REFERENCES Factura (fact_id);

ALTER TABLE Item ADD FOREIGN KEY (item_ofer_id) REFERENCES Oferta (ofer_id);

ALTER TABLE FuncionalidadxRol ADD FOREIGN KEY (rol_id) REFERENCES Rol (rol_id);

ALTER TABLE FuncionalidadxRol ADD FOREIGN KEY (func_id) REFERENCES Funcionalidad (func_id);

PRINT SYSDATETIME();
PRINT '(1/13) - Tablas creadas.' + CHAR(13);

GO

CREATE TRIGGER trg_item_id
ON Item
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
		IF @item_fact_id IN (SELECT item_fact_id FROM Item)
		BEGIN
			SELECT
				@item_id = MAX(item_id) + 1
			FROM Item
			WHERE item_fact_id = @item_fact_id;
		END
		ELSE
		BEGIN
			SET @item_id = 1;
		END
		INSERT INTO Item (
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

CREATE PROC migracion_insert_funcionalidades AS
BEGIN
	INSERT INTO Funcionalidad (func_id, func_descripcion)
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

CREATE PROC migracion_insert_funcionalidadesxrol AS
BEGIN
	INSERT INTO FuncionalidadxRol (rol_id, func_id)
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

CREATE PROC migracion_insert_rubros AS
BEGIN
	INSERT INTO Rubro (
		rubro_descripcion
	)
	SELECT DISTINCT Provee_Rubro
	FROM gd_esquema.Maestra
	WHERE Provee_Rubro IS NOT NULL;
END
GO

CREATE PROC migracion_insert_roles AS
BEGIN
	INSERT INTO Rol (rol_id, rol_nombre)
	VALUES
		(1, 'Cliente'),
		(2, 'Proveedor'),
		(3, 'Administrador');
END
GO

CREATE PROC migracion_insert_tipos_de_pago AS
BEGIN
	INSERT INTO Tipo_de_pago
		(tipo_de_pago_descripcion)
	SELECT DISTINCT Tipo_Pago_Desc
	FROM gd_esquema.Maestra
	WHERE Tipo_Pago_Desc IS NOT NULL;
END
GO

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
GO

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
GO

CREATE PROC migracion_insert_ofertas AS
BEGIN
	INSERT INTO Oferta (
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
			Proveedor.prov_id
		FROM Proveedor
		WHERE Proveedor.prov_cuit = maestra.Provee_CUIT) prov_id,
		Oferta_Cantidad
	FROM gd_esquema.Maestra maestra
	WHERE Oferta_Codigo IS NOT NULL;
END
GO

CREATE PROC migracion_insert_cargas AS
BEGIN
	INSERT INTO Carga (
		carg_clie_id,
		carg_monto,
		carg_fecha,
		carg_tipo_de_pago_id
	)
	SELECT
		(SELECT Cliente.clie_id
		FROM Cliente
		WHERE Cliente.clie_dni = maestra.Cli_Dni) clie_id,
		Carga_Credito,
		Carga_Fecha,
		(SELECT Tipo_de_pago.tipo_de_pago_id
		FROM Tipo_de_pago
		WHERE Tipo_de_pago.tipo_de_pago_descripcion = maestra.Tipo_Pago_Desc) tipo_de_pago_id
	FROM gd_esquema.Maestra maestra
	WHERE Carga_Credito IS NOT NULL;
END
GO

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
GO

CREATE PROC migracion_insert_facturas AS
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
			@fact_prov_id = Proveedor.prov_id
		FROM Proveedor
		WHERE Proveedor.prov_razon_social = @fact_prov_rs;
		INSERT INTO Factura (
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

CREATE PROC migracion_insert_items AS
BEGIN
	INSERT INTO Item (
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

EXEC migracion_insert_rubros;
PRINT SYSDATETIME();
PRINT '(2/13) - Rubros insertados.' + CHAR(13);
GO
EXEC migracion_insert_roles;
PRINT SYSDATETIME();
PRINT '(3/13) - Roles insertados.' + CHAR(13);
GO
EXEC migracion_insert_funcionalidades;
PRINT SYSDATETIME();
PRINT '(4/13) - Funcionalidades insertadas.' + CHAR(13);
GO
EXEC migracion_insert_funcionalidadesxrol;
PRINT SYSDATETIME();
PRINT '(5/13) - Funcionalidades por Rol insertadas.' + CHAR(13);
GO
EXEC migracion_insert_tipos_de_pago;
PRINT SYSDATETIME();
PRINT '(6/13) - Tipos de Pago insertados.' + CHAR(13);
GO
EXEC migracion_insert_proveedores;
PRINT SYSDATETIME();
PRINT '(7/13) - Proveedores insertados.' + CHAR(13);
GO
EXEC migracion_insert_clientes;
PRINT SYSDATETIME();
PRINT '(8/13) - Clientes insertados.' + CHAR(13);
GO
EXEC migracion_insert_ofertas;
PRINT SYSDATETIME();
PRINT '(9/13) - Ofertas insertadas.' + CHAR(13);
GO
EXEC migracion_insert_cargas;
PRINT SYSDATETIME();
PRINT '(10/13) - Cargas insertadas.' + CHAR(13);
GO
EXEC migracion_insert_cupones;
PRINT SYSDATETIME();
PRINT '(11/13) - Cupones insertados.' + CHAR(13);
GO
EXEC migracion_insert_facturas;
PRINT SYSDATETIME();
PRINT '(12/13) - Facturas insertadas.' + CHAR(13);
GO
EXEC migracion_insert_items;
PRINT SYSDATETIME();
PRINT '(13/13) - Items insertados.' + CHAR(13);
GO