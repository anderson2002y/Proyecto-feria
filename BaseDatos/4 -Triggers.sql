/*
	Creación de Triggers para aumentar o disminuir inventario
	1. Al realizar una compra, se debe aumentar inventario HECHO
	2. Al realizar una venta, se debe bajar inventario HECHO
	3. En una dev. de compra, al aceptarse se baja inventario, y al recibirse vuelve a subir HECHO
	4. En una dev. de venta, al aceptarse, aumenta inventario y al entregarse disminuye HECHO

	Autor: Jimmy Soza
*/
USE Ferreteria
--Actualizar inventario por una venta
CREATE TRIGGER DetVenta_Insert ON DetalleVenta
AFTER INSERT
AS
DECLARE @IdProducto int
DECLARE @Cantidad int

SET @IdProducto = (SELECT IdProducto FROM inserted)
SET @Cantidad = (SELECT Cantidad FROM inserted)

UPDATE Producto SET UnidadesDisponibles = UnidadesDisponibles - @Cantidad
WHERE IdProducto = @IdProducto

---------------------------------------
--Actualizar inventario cuando se inserta una devolucion
CREATE TRIGGER DevVenta_Insert
On DevolucionVenta
AFTER INSERT
AS
DECLARE @IdProducto int
DECLARE @Cantidad int
SET @IdProducto =  (SELECT IdProducto FROM inserted)
SET @Cantidad = (SELECT Cantidad FROM inserted)

IF ((SELECT Estado FROM inserted) = 'Aceptado')
BEGIN
	UPDATE Producto Set UnidadesDisponibles =  UnidadesDisponibles + @Cantidad
	WHERE IdProducto = @IdProducto
END

---------------------------------------
--Actualizar inventario cuando se actualiza el estado de la devolucion
CREATE TRIGGER DevVenta_Update
ON DevolucionVenta
AFTER UPDATE
AS
DECLARE @IdProducto int
DECLARE @Cantidad int
SET @IdProducto =  (SELECT IdProducto FROM inserted)
SET @Cantidad = (SELECT Cantidad FROM inserted)

IF (SELECT Estado FROM inserted) = 'Entregado'
BEGIN
	UPDATE Producto SET UnidadesDisponibles = UnidadesDisponibles - @Cantidad
	WHERE IdProducto = @IdProducto
END
ELSE IF (SELECT Estado FROM inserted) = 'Aceptado'
BEGIN
	UPDATE Producto	SET UnidadesDisponibles = UnidadesDisponibles + @Cantidad
	WHERE IdProducto = @IdProducto
END

----------------------------------
--Actualizar inventario cuando se inserta una nueva compra
CREATE TRIGGER DetCompra_Insert ON DetalleCompra
AFTER INSERT
AS
DECLARE @IdProducto int
DECLARE @Cantidad int

SET @IdProducto = (SELECT IdProducto FROM inserted)
SET @Cantidad = (SELECT Cantidad FROM inserted)

UPDATE Producto SET UnidadesDisponibles = UnidadesDisponibles + @Cantidad
WHERE IdProducto = @IdProducto

---------------------------------
--Actualizar inventario cuando se inserta una devolucion de compra
CREATE TRIGGER DevCompra_Insert
On DevolucionCompra
AFTER INSERT
AS
DECLARE @IdProducto int
DECLARE @Cantidad int
SET @IdProducto =  (SELECT dc.IdProducto FROM inserted dv inner join DetalleCompra dc on dv.IdDetalleCompra = dc.IdDetalleCompra)
SET @Cantidad = (SELECT Cantidad FROM inserted)

IF ((SELECT Estado FROM inserted) = 'Aceptado')
BEGIN
	UPDATE Producto Set UnidadesDisponibles =  UnidadesDisponibles - @Cantidad
	WHERE IdProducto = @IdProducto
END

---------------------------------------
--Actualizar inventario cuando se cambia el estado de la devolucion de Compra
CREATE TRIGGER DevCompra_Update
ON DevolucionCompra
AFTER UPDATE
AS
DECLARE @IdProducto int
DECLARE @Cantidad int
SET @IdProducto =  (SELECT IdProducto FROM inserted dv inner join DetalleCompra dc on dv.IdDetalleCompra = dc.IdDetalleCompra)
SET @Cantidad = (SELECT Cantidad FROM inserted)

IF (SELECT Estado FROM inserted) = 'Recibido'
BEGIN
	UPDATE Producto SET UnidadesDisponibles = UnidadesDisponibles + @Cantidad
	WHERE IdProducto = @IdProducto
END
ELSE IF (SELECT Estado FROM inserted) = 'Aceptado'
BEGIN
	UPDATE Producto	SET UnidadesDisponibles = UnidadesDisponibles - @Cantidad
	WHERE IdProducto = @IdProducto
END

--Actualizar Compra si se pagó el monto a deber
CREATE TRIGGER CompraEstado_Update
ON CreditoPago
AFTER INSERT
as
DECLARE @IdCompra int
SET @IdCompra = (Select IdCompra from inserted)
IF ( (SELECT SUM(Pago) FROM CreditoPago WHERE IdCompra = @IdCompra) = (SELECT Total FROM Compra WHERE IdCompra = @IdCompra and Estadotransaccion = 'Crédito'))
	BEGIN
	UPDATE Compra SET
	Estadotransaccion = 'Pagado' WHERE IdCompra = @IdCompra
	END

CREATE TRIGGER Factura_Update
ON Factura
AFTER UPDATE
AS
DECLARe @IdVenta INT
SET @IdVenta =  (select IdVenta from inserted)

if ((select Estado from inserted where IdVenta = @IdVenta) = 'Anulado')
BEGIN
DECLARE @productos int 

DECLARE @contador int
SET @contador = 0

DECLARE @IdProducto int
SET @IdProducto = 0

DECLARE @cantidad int
SET @cantidad = 0

DECLARE @Temp as Table(IdVenta int,IdProducto int,cantidad int)
INSERT INTO @Temp(IdVenta,IdProducto,cantidad) 
(SELECT IdVenta,IdProducto,Cantidad FROM DetalleVenta WHERE IdVenta = @IdVenta)

SET @productos = (SELECT COUNT(*) FROM @Temp)

WHILE (@contador < @productos)
	BEGIN
	SET @IdProducto = (SELECT Top 1 IdProducto FROM @Temp)
	SET @cantidad = ((SELECT Top 1 cantidad FROM @Temp))

	UPDATE Producto SET UnidadesDisponibles = UnidadesDisponibles + @cantidad WHERE IdProducto = @IdProducto
	DELETE @Temp WHERE IdProducto  = @IdProducto
	END
END