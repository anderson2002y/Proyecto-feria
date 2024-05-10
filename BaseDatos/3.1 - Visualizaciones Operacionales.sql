USE Ferreteria
GO
--Crear,Ver,Actualizar,Cambiar,Buscar y Validar acceso

ALTER PROCEDURE Visualizar_Ventas 
AS
DECLARE @Ventas as Table
(IdFactura int,IdVenta int,NoFactura int,Fecha datetime,Cliente varchar(100),Subtotal money,CostoEnvio money, Descuento money, Total money, Estado varchar(10))
INSERT INTO @Ventas(IdFactura,IdVenta,NoFactura,Fecha,Cliente,Subtotal,CostoEnvio,Descuento,Total,Estado)
(
	SELECT
	f.IdFactura,
	f.IdVenta,
	f.NoFactura,
	f.Fecha,
	cn.PrimerNombre + ' ' + cn.SegundoNombre + ' ' + cn.PrimerApellido + ' ' + cn.SegundoApellido as Cliente,
	f.Subtotal,
	f.CostoEnvio,
	f.Descuento,
	f.Total,
	f.Estado
	FROM Factura f
	inner join Venta v
	on f.IdVenta = v.IdVenta
	inner join Cliente c
	on v.IdCliente = c.IdCliente
	inner join ClienteNatural cn
	on c.IdCliente = cn.IdCliente
)

INSERT INTO @Ventas (IdFactura,IdVenta,NoFactura,Fecha,Cliente,Subtotal,CostoEnvio,Descuento,Total,Estado)
(
	SELECT
	f.IdFactura,
	f.IdVenta,
	f.NoFactura,
	f.Fecha,
	cj.NombreCompañia as Cliente,
	f.Subtotal,
	f.CostoEnvio,
	f.Descuento,
	f.Total,
	f.Estado
	FROM Factura f
	inner join Venta v
	on f.IdVenta = v.IdVenta
	inner join Cliente c
	on v.IdCliente = c.IdCliente
	inner join ClienteJuridico cj
	on c.IdCliente = cj.IdCliente
)

SELECT TOP 100 
IdFactura,
IdVenta,
NoFactura as Factura,
CONVERT(VARCHAR, Fecha, 100) AS Fecha,
Cliente,
'C$' + CONVERT(VARCHAR,CAST(Subtotal AS MONEY),1) as Subtotal,
'C$' + CONVERT(VARCHAR,CAST(CostoEnvio AS MONEY),1) as Envio,
'C$' + CONVERT(VARCHAR,CAST(Descuento AS MONEY),1) as Descuento,
'C$' + CONVERT(VARCHAR,CAST(Total AS MONEY),1) as Total,
Estado
FROM @Ventas ORDER BY IdFactura DESC

CREATE PROCEDURE Visualizar_DetVenta @IdVenta int
AS
SELECT
p.IdProducto as IdProducto,
p.Marca + ' ' + p.Nombre +  ' ' + p.Modelo as [Producto],
'C$' + CONVERT(VARCHAR,CAST(dv.Precio AS MONEY),1) as Precio,
dv.Cantidad as Cantidad,
CAST (dv.DescuentoUnidad * 100 as varchar) + '%' as [% Descuento],
'C$' + CONVERT(VARCHAR,CAST(dv.Precio * dv.Cantidad AS MONEY),1) as SubTotal,
'C$' + CONVERT(VARCHAR,CAST(dv.DescuentoUnidad * dv.Precio *  dv.Cantidad AS MONEY),1) as [Descuento],
'C$' + CONVERT(VARCHAR,CAST(dv.Precio * dv.Cantidad - dv.Precio*dv.Cantidad*dv.DescuentoUnidad AS MONEY),1) as Total
FROM DetalleVenta dv
inner join Producto p
on dv.IdProducto = p.IdProducto
WHERE dv.IdVenta = @IdVenta

ALTER PROCEDURE Visualizar_Compras
AS
SELECT
c.IdCompra as IdCompra,
p.NombreCompañia as [Razón social],
c.NoFactura as [Factura],
CONVERT(VARCHAR, c.Fecha, 6) AS Fecha,
c.Tipo as Tipo,
'C$' + CONVERT(VARCHAR,CAST(c.Subtotal AS MONEY),1) as Subtotal,
'C$' + CONVERT(VARCHAR,CAST(c.Iva AS MONEY),1) as Iva,
'C$' + CONVERT(VARCHAR,CAST(c.Descuento AS MONEY),1) as Descuento,
'C$' + CONVERT(VARCHAR,CAST(c.Total AS MONEY),1) as Total,
c.Estado as Estado
FROM Compra c
inner join Proveedor p
on c.IdProveedor =  p.IdProveedor

ALTER PROCEDURE Visualizar_ComprasPeriodo @FechaInicial date, @FechaFinal date
AS
SELECT
c.IdCompra as IdCompra,
p.NombreCompañia as [Razon social],
c.NoFactura as [No Factura],
c.Fecha as Fecha,
c.Tipo as Tipo,
c.Subtotal as Subtotal,
c.Iva as Iva,
c.Descuento as Descuento,
c.Total as Total,
c.Estado as Estado
FROM Compra c
inner join Proveedor p
on c.IdProveedor =  p.IdProveedor
WHERE CONVERT(date,c.Fecha) BETWEEN @FechaInicial and @FechaFinal
ORDER BY IdCompra DESC

ALTER PROCEDURE Visualizar_DetComprasPeriodo @FechaInicial date, @FechaFinal date
AS
SELECT
c.IdCompra as IdCompra,
c.NoFactura as NoFactura,
p.Nombre as Nombre,
p.Marca as Marca,
p.Modelo as Modelo,
p.Peso as Peso,
p.Medida as Contenido,
dc.Precio as Precio,
dc.Cantidad as Cantidad,
dc.DescuentoUnidad as DescuentoUnidad,
dc.Precio * dc.Cantidad as Subtotal,
dc.Precio * dc.Cantidad * dc.DescuentoUnidad as Descuento,
dc.Iva * dc.Cantidad as Iva,
(dc.Precio * dc.Cantidad) * (1-dc.DescuentoUnidad) + dc.Iva * dc.Cantidad as Total
FROM Compra c
INNER JOIN DetalleCompra dc
on c.IdCompra = dc.IdCompra
inner join Producto p
on dc.IdProducto = p.IdProducto
WHERE CONVERT(date,c.Fecha) BETWEEN @FechaInicial and @FechaFinal
ORDER BY IdCompra DESC

--EXEC Visualizar_ComprasPeriodo '01-01-2019','31-01-2019'
--EXEC Visualizar_DetComprasPeriodo '01-01-2019','31-01-2019'

ALTER PROCEDURE Visualizar_DetCompras @IdCompra int
AS
SELECT
p.IdProducto as IdProducto,
p.Marca + ' ' + p.Nombre + ' ' + p.Modelo as Nombre,
'C$' + CONVERT(VARCHAR,CAST(dc.Precio AS MONEY),1) as Precio,
dc.Cantidad as Cantidad,
CAST (dc.DescuentoUnidad * 100 as varchar) + '%' [% Descuento],
'C$' + CONVERT(VARCHAR,CAST(dc.Precio * dc.Cantidad AS MONEY),1) as Subtotal,
'C$' + CONVERT(VARCHAR,CAST(dc.Precio * dc.DescuentoUnidad * dc.Cantidad AS MONEY),1) as Descuento,
'C$' + CONVERT(VARCHAR,CAST(dc.Iva * dc.Cantidad AS MONEY),1) as Iva,
'C$' + CONVERT(VARCHAR,CAST(((dc.Precio - dc.Precio*dc.DescuentoUnidad) + dc.Iva) * dc.Cantidad AS MONEY),1) as Total
FROM
DetalleCompra dc
inner join Producto p
on dc.IdProducto = p.IdProducto
WHERE dc.IdCompra = @IdCompra

ALTER PROCEDURE Visualizar_DevCompras
AS
SELECT 
devc.IdDevolucion as IdDevolucion,
devc.IdDetalleCompra as IdDetalleCompra,
c.NoFactura as [Factura],
CONVERT(VARCHAR, devc.Fecha, 6) as [Fecha devolución],
p.Marca + ' ' + p.Nombre + ' ' + p.Modelo as Producto,
devc.Cantidad as Cantidad,
devc.Observacion as Observación,
devc.Estado [Estado]
FROM DevolucionCompra devc
inner join DetalleCompra dc
on dc.IdDetalleCompra =  devc.IdDetalleCompra
inner join Compra c
on c.IdCompra = dc.IdCompra
inner join Producto p
on dc.IdProducto = p.IdProducto

ALTER PROCEDURE Visualizar_PagosCredito
AS
SELECT
cp.IdCompra as IdCompra,
c.NoFactura as [Factura],
p.NombreCompañia as [Razón social],
CONVERT(VARCHAR, cp.Fecha, 6) as [Fecha pago],
'C$' + CONVERT(VARCHAR,CAST(cp.Pago AS MONEY),1) as Monto
FROM CreditoPago cp
inner join Compra c
on cp.IdCompra = c.IdCompra
inner join Proveedor p
on c.IdProveedor = p.IdProveedor

ALTER PROCEDURE Visualizar_DevVentas
AS
SELECT
dvv.IdDevolucion as IdDevolucion,
f.NoFactura as [Factura],
CONVERT(VARCHAR, dvV.Fecha, 6) as Fecha,
p.Marca + ' ' + p.Nombre + p.Modelo as Producto,
'C$' + CONVERT(VARCHAR,CAST(dvV.Monto AS MONEY),1) as Monto,
dvV.Cantidad as Cantidad,
dvV.Observacion as Observación,
dvV.Estado as Estado
FROM
DevolucionVenta dvV
inner join Factura f
on dvV.IdFactura = f.IdFactura
inner join Producto p
on dvV.IdProducto = p.IdProducto

CREATE PROCEDURE Visualizar_VentasPeriodo @FechaInicial date, @FechaFinal date
AS
DECLARE @Ventas as Table
(IdFactura int,IdVenta int,NoFactura int,Fecha datetime,Cliente varchar(100),Subtotal money,CostoEnvio money, Descuento money, Total money, Estado varchar(10))
INSERT INTO @Ventas(IdFactura,IdVenta,NoFactura,Fecha,Cliente,Subtotal,CostoEnvio,Descuento,Total,Estado)
(
	SELECT
	f.IdFactura,
	f.IdVenta,
	f.NoFactura,
	f.Fecha,
	cn.PrimerNombre + ' ' + cn.SegundoNombre + ' ' + cn.PrimerApellido + ' ' + cn.SegundoApellido as Cliente,
	f.Subtotal,
	f.CostoEnvio,
	f.Descuento,
	f.Total,
	f.Estado
	FROM Factura f
	inner join Venta v
	on f.IdVenta = v.IdVenta
	inner join Cliente c
	on v.IdCliente = c.IdCliente
	inner join ClienteNatural cn
	on c.IdCliente = cn.IdCliente
	WHERE CONVERT(date,f.Fecha) BETWEEN @FechaInicial and @FechaFinal
)

INSERT INTO @Ventas (IdFactura,IdVenta,NoFactura,Fecha,Cliente,Subtotal,CostoEnvio,Descuento,Total,Estado)
(
	SELECT
	f.IdFactura,
	f.IdVenta,
	f.NoFactura,
	f.Fecha,
	cj.NombreCompañia as Cliente,
	f.Subtotal,
	f.CostoEnvio,
	f.Descuento,
	f.Total,
	f.Estado
	FROM Factura f
	inner join Venta v
	on f.IdVenta = v.IdVenta
	inner join Cliente c
	on v.IdCliente = c.IdCliente
	inner join ClienteJuridico cj
	on c.IdCliente = cj.IdCliente
	WHERE CONVERT(date,f.Fecha) BETWEEN @FechaInicial and @FechaFinal
)

SELECT TOP 100 * FROM @Ventas ORDER BY IdFactura DESC

CREATE PROCEDURE Visualizar_DetVentasPeriodo @FechaInicial date, @FechaFinal date
AS
DECLARE @Ventas as Table
(IdVenta int,NoFactura int,Descripcion varchar(100),Marca varchar(50),Modelo varchar(50),Precio money, Cantidad money, DescuentoUnit money, SubTotal money,Descuento money, Total money)

INSERT INTO @Ventas(IdVenta,NoFactura,Descripcion,Marca,Modelo,Precio,Cantidad,DescuentoUnit,SubTotal,Descuento,Total)
(
	SELECT 
	v.IdVenta as IdVenta,
	f.NoFactura,
	p.Nombre as Descripcion,
	p.Marca as Marca,
	p.Modelo as Modelo,
	dv.Precio as Precio,
	dv.Cantidad as Cantidad,
	dv.DescuentoUnidad * 100 as DescuentoUnitario,
	dv.Precio*dv.Cantidad as Subtotal,
	dv.Precio * dv.Cantidad * dv.DescuentoUnidad as Descuento,
	dv.Precio * dv.Cantidad * (1-dv.DescuentoUnidad) as Total
	FROM
	Factura f
	inner join Venta v
	on f.IdVenta = v.IdVenta
	inner join DetalleVenta dv
	on v.IdVenta = dv.IdVenta
	inner join Producto p
	on p.IdProducto = dv.IdProducto
	WHERE CONVERT(date,f.Fecha) BETWEEN @FechaInicial and @FechaFinal
)

SELECT * FROM @Ventas ORDER BY NoFactura ASC

CREATE PROCEDURE Ver_Factura @IdFactura int
AS
DECLARE @Ventas as Table
(IdFactura int,IdVenta int,NoFactura int,Fecha datetime,Cliente varchar(100),Empleado varchar(100),Subtotal money,CostoEnvio money, Descuento money, Total money, Estado varchar(10))
INSERT INTO @Ventas(IdFactura,IdVenta,NoFactura,Fecha,Cliente,Empleado,Subtotal,CostoEnvio,Descuento,Total,Estado)
(
	SELECT
	f.IdFactura,
	f.IdVenta,
	f.NoFactura,
	f.Fecha,
	cn.PrimerNombre + ' ' + cn.SegundoNombre + ' ' + cn.PrimerApellido + ' ' + cn.SegundoApellido as Cliente,
	e.PrimerNombre + ' ' + e.PrimerApellido as Empleado,
	f.Subtotal,
	f.CostoEnvio,
	f.Descuento,
	f.Total,
	f.Estado
	FROM Factura f
	inner join Venta v
	on f.IdVenta = v.IdVenta
	inner join Cliente c
	on v.IdCliente = c.IdCliente
	inner join ClienteNatural cn
	on c.IdCliente = cn.IdCliente
	inner join Empleado e
	on e.IdEmpleado = v.IdEmpleado
)

INSERT INTO @Ventas (IdFactura,IdVenta,NoFactura,Fecha,Cliente,Empleado,Subtotal,CostoEnvio,Descuento,Total,Estado)
(
	SELECT
	f.IdFactura,
	f.IdVenta,
	f.NoFactura,
	f.Fecha,
	cj.NombreCompañia as Cliente,
	e.PrimerNombre + ' ' + e.PrimerApellido,
	f.Subtotal,
	f.CostoEnvio,
	f.Descuento,
	f.Total,
	f.Estado
	FROM Factura f
	inner join Venta v
	on f.IdVenta = v.IdVenta
	inner join Cliente c
	on v.IdCliente = c.IdCliente
	inner join ClienteJuridico cj
	on c.IdCliente = cj.IdCliente
	inner join Empleado e
	on e.IdEmpleado = v.IdEmpleado
)

SELECT TOP 100 * FROM @Ventas WHERE IdFactura = @IdFactura

CREATE PROCEDURE Visualizar_DevVentasPeriodo @FechaInicial date, @FechaFinal date
AS
SELECT
f.NoFactura as [No Factura],
dvV.Fecha as Fecha,
p.Nombre as Descripcion,
p.Marca as Marca,
p.Modelo as Modelo,
dvV.Monto as Monto,
dvV.Cantidad as Cantidad,
dvV.Observacion as Observacion,
dvV.Estado as Estado
FROM
DevolucionVenta dvV
inner join Factura f
on dvV.IdFactura = f.IdFactura
inner join Producto p
on dvV.IdProducto = p.IdProducto
WHERE CONVERT(date,dvV.Fecha) BETWEEN @FechaInicial and @FechaFinal

CREATE PROCEDURE Visualizar_DevComprasPeriodo @FechaInicial date, @FechaFinal date
AS
SELECT 
devc.IdDetalleCompra as IdDetalleCompra,
c.NoFactura as [Factura compra],
devc.Fecha as [Fecha devolucion],
p.Nombre as NombreProducto,
p.Marca as Marca,
p.Modelo as Modelo,
devc.Cantidad as Cantidad,
devc.Observacion as Observacion,
devc.Estado [Estado]
FROM DevolucionCompra devc
inner join DetalleCompra dc
on dc.IdDetalleCompra =  devc.IdDetalleCompra
inner join Compra c
on c.IdCompra = dc.IdCompra
inner join Producto p
on dc.IdProducto = p.IdProducto
WHERE CONVERT(date,devc.Fecha) BETWEEN @FechaInicial and @FechaFinal