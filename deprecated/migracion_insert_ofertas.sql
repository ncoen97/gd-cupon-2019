-- DROP PROC migracion_insert_ofertas
CREATE PROC migracion_insert_ofertas AS
BEGIN
	DECLARE
		@ofer_id nvarchar(50),
		@ofer_descripcion nvarchar(255),
		@ofer_fecha_publicacion datetime,
		@ofer_fecha_vencimiento datetime,
		@ofer_precio_oferta numeric(18, 2),
		@ofer_precio_lista numeric(18, 2),
		@ofer_prov_cuit nvarchar(20),
		@ofer_prov_id int,
		@ofer_stock numeric(18, 0);
	DECLARE curs_ofertas CURSOR FOR
		SELECT DISTINCT
			Oferta_Codigo,
			Oferta_Descripcion,
			Oferta_Fecha,
			Oferta_Fecha_Venc,
			Oferta_Precio,
			Oferta_Precio_Ficticio,
			Provee_CUIT, --> para buscar el provee_id
			Oferta_Cantidad
		FROM gd_esquema.Maestra
		WHERE Oferta_Codigo IS NOT NULL;
	OPEN curs_ofertas;
	FETCH NEXT FROM curs_ofertas INTO
		@ofer_id,
		@ofer_descripcion,
		@ofer_fecha_publicacion,
		@ofer_fecha_vencimiento,
		@ofer_precio_oferta,
		@ofer_precio_lista,
		@ofer_prov_cuit,
		@ofer_stock;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SELECT
			@ofer_prov_id = Proveedor.prov_id
		FROM Proveedor
		WHERE Proveedor.prov_cuit = @ofer_prov_cuit;
		INSERT INTO Oferta (
			ofer_id,
			ofer_descripcion,
			ofer_fecha_publicacion,
			ofer_fecha_vencimiento,
			ofer_precio_oferta,
			ofer_precio_lista,
			ofer_prov_id,
			ofer_stock
		) VALUES (
			@ofer_id,
			@ofer_descripcion,
			@ofer_fecha_publicacion,
			@ofer_fecha_vencimiento,
			@ofer_precio_oferta,
			@ofer_precio_lista,
			@ofer_prov_id,
			@ofer_stock
		);
		FETCH NEXT FROM curs_ofertas INTO
			@ofer_id,
			@ofer_descripcion,
			@ofer_fecha_publicacion,
			@ofer_fecha_vencimiento,
			@ofer_precio_oferta,
			@ofer_precio_lista,
			@ofer_prov_cuit,
			@ofer_stock;
	END
	CLOSE curs_ofertas;
	DEALLOCATE curs_ofertas;
END

/*

SELECT *
FROM gd_esquema.Maestra
WHERE Provee_RS IS NOT NULL
ORDER BY Oferta_Codigo, Oferta_Fecha_Compra, Oferta_Entregado_Fecha;

*/