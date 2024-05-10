/*
	Al momento de realizar una venta se crea un registro venta,
	para luego guardar el detalle de la venta y a continuación
	se hace una factura con los montos totales
*/
USE Ferreteria
CREATE PROCEDURE Registrar_Venta @IdCliente int, @IdEmpleado int
AS
INSERT INTO Venta VALUES
(@IdCliente,@IdEmpleado)

CREATE PROCEDURE Registrar_DetVenta @IdProducto int, @Cantidad int, @Descuento money
AS
INSERT INTO DetalleVenta VALUES
(dbo.Ultima_Venta(),@IdProducto,@Cantidad,dbo.Buscar_PrecioProducto(@IdProducto),@Descuento)


CREATE PROCEDURE Registrar_Factura @CostoEnvio money,@Estado varchar(10)
AS
INSERT INTO Factura(IdVenta,NoFactura,Fecha,Subtotal,CostoEnvio,Descuento,Total,Estado) VALUES
(dbo.Ultima_Venta(),
dbo.Ultima_Venta(),
GETDATE(),
dbo.Suma_SubTotalVenta(dbo.Ultima_Venta()),
@CostoEnvio,
dbo.Suma_DescuentoVenta(dbo.Ultima_Venta()),
dbo.Suma_SubTotalVenta(dbo.Ultima_Venta()) + @CostoEnvio - dbo.Suma_DescuentoVenta(dbo.Ultima_Venta()),
@Estado
)

--Uso temporal para la inserccion de ventas por SP
CREATE PROCEDURE Registrar_FacturaTemp @Fecha datetime,@CostoEnvio money,@Estado varchar(10)
AS
INSERT INTO Factura(IdVenta,NoFactura,Fecha,Subtotal,CostoEnvio,Descuento,Total,Estado) VALUES
(dbo.Ultima_Venta(),
dbo.Ultima_Venta(),
@Fecha,
dbo.Suma_SubTotalVenta(dbo.Ultima_Venta()),
@CostoEnvio,
dbo.Suma_DescuentoVenta(dbo.Ultima_Venta()),
dbo.Suma_SubTotalVenta(dbo.Ultima_Venta()) + @CostoEnvio - dbo.Suma_DescuentoVenta(dbo.Ultima_Venta()),
@Estado
)

CREATE PROCEDURE Registrar_Envio @IdMunicipio int, @Direccion varchar(100)
AS
INSERT INTO Envio VALUES
( (SELECT Top 1 IdVenta FROM Venta ORDER BY IdVenta DESC),@IdMunicipio,@Direccion)
------------------------------------

CREATE PROCEDURE Registrar_Compra
@IdProveedor int, 
@EstadoTransaccion varchar(20),
@NoFactura varchar(20),
@Fecha date
AS
INSERT INTO Compra(IdProveedor,Estadotransaccion, NoFactura,Fecha) VALUES
(@IdProveedor,
@EstadoTransaccion,
@NoFactura,
@Fecha
)

CREATE PROCEDURE Registrar_DetCompra 
@IdProducto int,
@Cantidad int,
@Descuento money,
@Precio money
AS
INSERT INTO 
DetalleCompra VALUES
(@IdProducto,dbo.UltimaCompra(),@Precio*0.85,@Cantidad,@Descuento, (@Precio*0.85 - @Precio*0.85*@Descuento)*0.15)
	
	--Precio = Subtotal - Descuento + Iva

	--Precio  = 85% + 15% - d%

CREATE PROCEDURE ActualizarCompra
AS
update  Compra set
SubTotal = dbo.Suma_SubTotalCompra(dbo.UltimaCompra()),
Descuento = dbo.Suma_DescuentoCompra(dbo.UltimaCompra()),
Iva = dbo.Suma_IvaCompra(dbo.UltimaCompra()),
Total = dbo.Suma_SubTotalCompra(dbo.UltimaCompra()) - dbo.Suma_DescuentoCompra(dbo.UltimaCompra()) + dbo.Suma_IvaCompra(dbo.UltimaCompra())
where IdCompra = dbo.UltimaCompra()

CREATE PROCEDURE Registrar_PagoCredito @IdCompra int,@Fecha date,@Monto money
AS

IF EXISTS(SELECT * FROM Compra WHERE IdCompra = @IdCompra and Estadotransaccion = 'Contado')
	BEGIN
	SELECT 'Compra pagada' as Mensaje
	END
ELSE IF EXISTS (SELECT * FROM Compra WHERE IdCompra = @IdCompra and Estadotransaccion = 'Pagado')
	BEGIN
	SELECT 'Compra pagada' as Mensaje
	END
else
	BEGIN
	INSERT INTO CreditoPago VALUES
	(@IdCompra,@Fecha,@Monto)
	END
SELECT 'Pago realizado' as Mensaje

---------------------DEVOLUCIONES---------------------------
CREATE PROCEDURE Nueva_DevVenta @IdFactura int, @IdProducto int, @Cantidad int, @Observacion nvarchar(60), @Estado varchar(11)
AS
INSERT INTO DevolucionVenta VALUES
(@IdFactura,@IdProducto,GETDATE(),dbo.Buscar_PrecioProducto_Factura(@IdFactura,@IdProducto),@Cantidad,@Observacion,@Estado)

CREATE PROCEDURE Nueva_DevCompra @IdDetalleCompra int, @Cantidad int, @Observacion nvarchar(60),@Estado varchar(8)
AS
INSERT INTO DevolucionCompra VALUES
(@IdDetalleCompra,GETDATE(),@Cantidad,@Observacion,@Estado)