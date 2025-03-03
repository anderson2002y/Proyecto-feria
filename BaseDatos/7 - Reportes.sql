USE [Ferreteria]
GO

Create procedure [dbo].[Reporte_Cuentas_por_pagar_proveedor]
as
select P.NombreCompañia aS [Proveedor], p.RUC, sum(c.Total) as Deuda,count(C.NoFactura)as [Facturas Pendientes] from Compra c
inner join Proveedor p
on p.IdProveedor=c.IdProveedor
where c.Estadotransaccion = 'Crédito'
Group by p.NombreCompañia,p.RUC
----------------------
CREATE Procedure [dbo].[Reporte_Devolucion_Compra_Por_Estado]
@Estado varchar(8)
as
Select pv.NombreCompañia,
pv.RUC,
dvc.Fecha,
c.NoFactura,
p.Nombre as Producto,
p.Marca,
p.Modelo,
p.Contenido,
dvc.Cantidad,
dvc.Observacion as Observacion
From DevolucionCompra dvc
inner join DetalleCompra dc
on dc.IdDetalleCompra=dvc.IdDetalleCompra
inner join Producto p
on dc.IdProducto = P.IdProducto
inner join Compra c
on c.IdCompra = dc.IdCompra
inner join Proveedor pv
on pv.IdProveedor = c.IdProveedor
Where dvc.Estado=@Estado
----------------------------------------------
Create procedure Reporte_Devolucion_Venta_Por_Estado
@Estado varchar(11)
as
declare  @temp  table(
NoFactura Int,
Fecha date,
Cliente varchar (120),
Producto varchar(60),
Marca varchar (50),
Modelo varchar (50),
Cantidad int,
Monto money,
Observacion varchar (60))

Insert into @temp (NoFactura,Fecha,Cliente,Producto,Marca,Modelo,Cantidad,Monto,Observacion)
(
Select f.NoFactura,DV.Fecha,cn.PrimerNombre +' '+ cn.SegundoNombre+ ' ' +cn.PrimerApellido +' '+cn.SegundoApellido as Cliente ,p.Nombre ,p.Marca,p.Modelo,dv.Cantidad,dv.Monto,dv.Observacion from DevolucionVenta dv
inner join Factura f
on dv.IdFactura = f.IdFactura
inner join Venta v
on v.IdVenta = f.IdVenta
inner join Cliente c
on c.IdCliente = v.IdCliente
inner Join ClienteNatural cn
on c.IdCliente= cn.IdCliente
inner join Producto p
on p.IdProducto=dv.IdProducto
where dv.Estado =@Estado
)
Insert into @temp (NoFactura,Fecha,Cliente,Producto,Marca,Modelo,Cantidad,Monto,Observacion)
(
Select f.NoFactura,DV.Fecha,cj.NombreCompañia as Cliente ,p.Nombre ,p.Marca,p.Modelo,dv.Cantidad,dv.Monto,dv.Observacion from DevolucionVenta dv
inner join Factura f
on dv.IdFactura = f.IdFactura
inner join Venta v
on v.IdVenta = f.IdVenta
inner join Cliente c
on c.IdCliente = v.IdCliente
inner Join ClienteJuridico cj
on c.IdCliente= cj.IdCliente
inner join Producto p
on p.IdProducto=dv.IdProducto
where dv.Estado =@Estado
)
Select * from @temp
-----------------------------------------------------------------

CREATE procedure Top10_Productos_Mas_Vendido
@desde date,@hasta date
as
select TOP 10 p.Nombre as Producto,p.Marca,p.Modelo,sum(dv.Cantidad) as Cantidad from DetalleVenta dv
inner join Producto p
on p.IdProducto= dv.IdProducto
inner join Factura f
on f.IdVenta=dv.IdVenta

where 
convert(date, f.Fecha) BETWEEN @desde AND @hasta
group by  p.Nombre ,p.Marca,p.Modelo,dv.Cantidad
order by dv.Cantidad desc
--------------------------------------------------------------------
exec Top10_Productos_Mas_Vendido '2019-02-01','2019-02-28'
--------------------------------------------------------------------

create procedure Reporte_Compra_entre_Fechas
@desde date,@hasta date
as

Select p.NombreCompañia,
C.NoFactura,
c.Fecha,
c.Subtotal,
c.Descuento,
C.Iva,
C.Total, 
SUM(DC.Cantidad) as Cantidad,
c.Estadotransaccion AS [Estado_de_compra]  
from Compra c
inner join Proveedor p
on p.IdProveedor=c.IdProveedor
inner join DetalleCompra  dc
on dc.IdCompra = c.IdCompra
where
convert(date, c.Fecha) BETWEEN @desde AND @hasta
GROUP BY  p.NombreCompañia,C.NoFactura,C.Total,c.Subtotal,C.Iva,c.Estadotransaccion,c.Descuento,c.Fecha

-----------------------------------------------------------
exec Reporte_Compra_entre_Fechas '01/01/2019','31/01/2019'
------------------------------------------------------------
CREATE procedure Reporte_Productos_Mayor_Recaudacion
@desde date,@hasta date
as
select 
p.Nombre as Producto,
p.Marca,
p.Modelo,
p.Contenido,
p.Peso,
SUM(dv.Cantidad) as [Unidades_vendidas], 
sum(dv.Cantidad *dv.Precio) as Recaudación 
from DetalleVenta dv
inner join Producto p
on p.IdProducto= dv.IdProducto
inner join Factura f
on f.IdVenta=dv.IdVenta
where 
convert(date, f.Fecha) BETWEEN @desde AND @hasta
group by  p.Nombre,dv.Cantidad,dv.Precio,p.Marca,p.Modelo, p.Contenido, p.Peso
order by Recaudación desc
--------------------------------------------------------------¡
exec Reporte_Productos_Mayor_Recaudacion '01/02/2019','28/02/2019'
----------------------------------------------------------------
------------------------------------------------------------------

create procedure Reporte_Ingresos_Por_Cliente
as
declare @temp table(
Cliente varchar (120),
SubTotal money,
Descuento money,
Total money,
Cantidad_Productos int
)
insert into @temp(Cliente,SubTotal,Descuento,Total,Cantidad_Productos)
(
select cn.PrimerNombre +' '+ cn.SegundoNombre+ ' ' +cn.PrimerApellido +' '+cn.SegundoApellido as Cliente ,sum(f.Subtotal) as SubTotal, sum(f.Descuento) as Descuento,sum(Total) as Total,sum(dv.Cantidad)as [Cantidad_Productos] from Factura f
inner join Venta v
on f.IdVenta= v.IdVenta
inner join Cliente c
on c.IdCliente= v.IdCliente
inner join ClienteNatural cn
on cn.IdCliente= c.IdCliente
inner join DetalleVenta dv
on dv.IdVenta =f.IdVenta
Group by cn.PrimerNombre +' '+ cn.SegundoNombre+ ' ' +cn.PrimerApellido +' '+cn.SegundoApellido
)

insert into @temp(Cliente,SubTotal,Descuento,Total,Cantidad_Productos)
(
select cj.NombreCompañia as Cliente ,sum(f.Subtotal) as SubTotal, sum(f.Descuento) as Descuento,sum(Total) as Total,sum(dv.Cantidad)as [Cantidad_Productos] from Factura f
inner join Venta v
on f.IdVenta= v.IdVenta
inner join Cliente c
on c.IdCliente= v.IdCliente
inner join ClienteJuridico cj
on cj.IdCliente= c.IdCliente
inner join DetalleVenta dv
on dv.IdVenta =f.IdVenta
Group by cj.NombreCompañia
)

SELECT * FROM @temp ORDER BY Total DESC