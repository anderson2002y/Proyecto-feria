USE Ferreteria

CREATE FUNCTION Suma_SubTotalVenta(@IdVenta int)
RETURNS money
AS
BEGIN
DECLARE @SubTotal money
SET @SubTotal =
(
	SELECT
	SUM(Precio * Cantidad)
	FROM DetalleVenta
	WHERE IdVenta = @IdVenta
)
RETURN @SubTotal
END

CREATE FUNCTION Suma_DescuentoVenta(@IdVenta int)
RETURNS money
AS
BEGIN
DECLARE @Descuento money
SET @Descuento =
(
	SELECT
	SUM(Precio * Cantidad * DescuentoUnidad)
	FROM DetalleVenta
	WHERE IdVenta = @IdVenta
)
RETURN @Descuento
END

CREATE FUNCTION Ultima_Venta()
RETURNS int
WITH EXECUTE AS CALLER
AS
BEGIN
DECLARE @IdVenta int
SET @IdVenta = ( 
SELECT TOP 1
v.IdVenta
FROM Venta v
ORDER BY v.IdVenta DESC)
RETURN @IdVenta
END

CREATE FUNCTION Buscar_PrecioProducto(@IdProducto int)
RETURNS money
AS
BEGIN
DECLARE @Precio money
SET @Precio = 
(
	SELECT
	p.Precio
	FROM
	Producto p
	where p.IdProducto = @IdProducto
)

RETURN @Precio
END

CREATE FUNCTION Suma_SubTotalCompra(@IdCompra int)
	RETURNS money
	AS
	BEGIN
	DECLARE @SubTotal money
	SET @SubTotal =
	(
		SELECT
		SUM(Precio * Cantidad)
		FROM DetalleCompra
		WHERE IdCompra = @IdCompra
)
RETURN @SubTotal
END

CREATE FUNCTION UltimaCompra()
	RETURNS int
	WITH EXECUTE AS CALLER
	AS
	BEGIN
	DECLARE @IdCompra int
	SET @IdCompra = ( 
	SELECT TOP 1
	c.IdCompra
	FROM Compra c
	ORDER BY c.IdCompra DESC)
	RETURN @IdCompra 
	END

	CREATE FUNCTION Suma_DescuentoCompra
	(@IdCompra int)
	RETURNS money
	AS
	BEGIN
	DECLARE @Descuento money
	SET @Descuento =
	(
		SELECT
		SUM(Precio * Cantidad * DescuentoUnidad)
		FROM DetalleCompra
		WHERE IdCompra = @IdCompra
	)
	RETURN @Descuento
	END

	CREATE FUNCTION Suma_IvaCompra
	(@IdCompra int)
	RETURNS money
	AS
	BEGIN
	DECLARE @Iva money
	SET @Iva =
	(
		SELECT
		SUM(Iva * Cantidad)
		FROM DetalleCompra
		WHERE IdCompra = @IdCompra
	)
	RETURN @Iva
	END

CREATE FUNCTION Buscar_PrecioProducto_Factura(@IdFactura int,@IdProducto int)
RETURNS money
AS
BEGIN
DECLARE @Precio money
SET @Precio = 
(
	SELECT
	dv.Precio * (1-DescuentoUnidad)
	FROM
	DetalleVenta dv
	where dv.IdProducto = @IdProducto and IdVenta = @IdFactura
)

RETURN @Precio
END