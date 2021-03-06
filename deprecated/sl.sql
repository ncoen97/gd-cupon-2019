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
DROP TABLE Rol;
DROP TABLE Usuario;

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

EXEC migracion_insert_rubros;
EXEC migracion_insert_roles;
EXEC migracion_insert_tipos_de_pago;
EXEC migracion_insert_proveedores;
EXEC migracion_insert_clientes;
EXEC migracion_insert_ofertas;
EXEC migracion_insert_cargas;
EXEC migracion_insert_cupones;
--> EXEC migracion_insert_facturas;
--> EXEC migracion_insert_items;

/*
SELECT *
FROM Proveedor
JOIN Rubro
	ON Rubro.rubro_id = Proveedor.prov_rubro_id
JOIN RolxUsuario
	ON Proveedor.prov_user_id = RolxUsuario.user_id;

SELECT * FROM RolxUsuario;

SELECT * FROM Ofertas;
*/
