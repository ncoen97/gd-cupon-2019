-- cupones comprados (pseudorepetidos, 200)
SELECT Cli_Dni, Oferta_Codigo, Oferta_Fecha, Oferta_Entregado_Fecha
FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
	AND Oferta_Entregado_Fecha IS NULL
	AND Factura_Fecha IS NULL;

-- cupones comprados (sin pseudorepetidos, 200)
SELECT DISTINCT Cli_Dni, Oferta_Codigo, Oferta_Fecha, Oferta_Entregado_Fecha
FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
	AND Oferta_Entregado_Fecha IS NULL
	AND Factura_Fecha IS NULL;


-- NO HAY CUPONES REGALADOS EN LA MAESTRA
-- and here's the proof:
-- "dame los cupones"
SELECT DISTINCT ppal.Oferta_Codigo
FROM gd_esquema.Maestra ppal
WHERE
	-- "que no hayan sido comprados por un cliente X"
	NOT EXISTS (
		SELECT *
		FROM gd_esquema.Maestra subq
		WHERE Oferta_Codigo IS NOT NULL --> solo trae rows de cupones
			AND Oferta_Entregado_Fecha IS NULL	--\
												-- > de compra
			AND Factura_Fecha IS NULL			--/  
			AND ppal.Cli_Dni = subq.Cli_Dni
	)
	-- "pero hayan sido canjeados por ese mismo cliente X"
	AND ppal.Oferta_Entregado_Fecha IS NOT NULL;


-- todos los cupones ordenados p/comparar manual
SELECT Cli_Nombre, Cli_Apellido, Cli_Dni, Oferta_Codigo,
		Oferta_Fecha_Compra, Oferta_Entregado_Fecha, Factura_Fecha
FROM gd_esquema.Maestra
WHERE Oferta_Codigo IS NOT NULL
ORDER BY Oferta_Codigo, Oferta_Fecha_Compra;

-- cantidad de cupones por estado
SELECT COUNT(*) entregados
FROM gd_esquema.Maestra
WHERE Oferta_Entregado_Fecha IS NOT NULL;
SELECT COUNT(*) facturados
FROM gd_esquema.Maestra
WHERE Factura_Fecha IS NOT NULL;
SELECT COUNT(*) comprados
FROM gd_esquema.Maestra
WHERE Oferta_Entregado_Fecha IS NULL
	AND Factura_Fecha IS NULL
	AND Oferta_Codigo IS NOT NULL;