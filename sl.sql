CREATE TABLE Cliente (
  clie_id int PRIMARY KEY,
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
  prov_id int PRIMARY KEY,
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
  carg_id int PRIMARY KEY,
  carg_fecha datetime,
  carg_clie_id int,
  carg_tipo_de_pago_id int,
  carg_monto numeric(18, 2),
  carg_tarj_id int
);

CREATE TABLE Rubro (
  rubro_id int PRIMARY KEY,
  rubro_descripcion nvarchar(100)
);

CREATE TABLE Tarjeta (
  tarj_id int PRIMARY KEY,
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
  cupon_id int PRIMARY KEY,
  cupon_fecha_compra datetime,
  cupon_ofer_id nvarchar(50),
  cupon_clie_id int
);

CREATE TABLE Canje (
  canj_cupon_id int PRIMARY KEY,
  canj_fecha_consumo datetime,
  canj_clie_id int
);

CREATE TABLE Factura (
  fact_id numeric(18, 0) PRIMARY KEY,
  fact_fecha_fact datetime,
  fact_prov_id int
);

CREATE TABLE Usuario (
  user_id int PRIMARY KEY,
  user_username nvarchar(20),
  user_pass nvarchar(30),
  user_intentos int
);

CREATE TABLE Tipo_de_pago (
  tipo_de_pago_id int PRIMARY KEY,
  tipo_de_pago_descripcion nvarchar(100)
);

CREATE TABLE RolxUsuario (
  user_id int,
  rol_id int,
  PRIMARY KEY (user_id, rol_id)
);

CREATE TABLE Rol (
  rol_id int PRIMARY KEY,
  rol_nombre nvarchar(20)
);

ALTER TABLE Cliente ADD FOREIGN KEY (clie_user_id) REFERENCES Usuario (user_id);

ALTER TABLE RolxUsuario ADD FOREIGN KEY (user_id) REFERENCES Usuario (user_id);

ALTER TABLE RolxUsuario ADD FOREIGN KEY (rol_id) REFERENCES Rol (rol_id);

ALTER TABLE Proveedor ADD FOREIGN KEY (prov_user_id) REFERENCES Usuario (user_id);

ALTER TABLE Proveedor ADD FOREIGN KEY (prov_rubro_id) REFERENCES Rubro (rubro_id);

ALTER TABLE Carga ADD FOREIGN KEY (carg_clie_id) REFERENCES Cliente (clie_id);

ALTER TABLE Carga ADD FOREIGN KEY (carg_tarj_id) REFERENCES Tarjeta (tarj_id);

ALTER TABLE Carga ADD FOREIGN KEY (carg_tipo_de_pago_id) REFERENCES Tipo_de_pago (tipo_de_pago_id);

ALTER TABLE Oferta ADD FOREIGN KEY (ofer_prov_id) REFERENCES Proveedor (prov_id);

ALTER TABLE Cupon ADD FOREIGN KEY (cupon_clie_id) REFERENCES Cliente (clie_id);

ALTER TABLE Cupon ADD FOREIGN KEY (cupon_ofer_id) REFERENCES Oferta (ofer_id);

ALTER TABLE Canje ADD FOREIGN KEY (canj_cupon_id) REFERENCES Cupon (cupon_id);

ALTER TABLE Canje ADD FOREIGN KEY (canj_clie_id) REFERENCES Cliente (clie_id);

ALTER TABLE Factura ADD FOREIGN KEY (fact_prov_id) REFERENCES Proveedor (prov_id);
