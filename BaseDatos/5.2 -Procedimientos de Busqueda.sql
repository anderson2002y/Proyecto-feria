/*
	Autor: Anderson Sanchez
*/
use ferreteria
----Procedimiento de buscar empleado
create procedure Buscar_Empleado
	@Buscar nvarchar(20)
	as
select
e.IdEmpleado as IdEmpleado,
e.PrimerNombre + ' ' + e.SegundoNombre + ' ' + e.PrimerApellido + ' ' + e.SegundoApellido as Empleado,
e.Cargo as Cargo,
e.Salario as Salario,
e.Telefono as Teléfono,
e.Correo as Correo,
e.Direccion as Dirección,
e.Estado as Estado
from Empleado e
where e.PrimerNombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or e.SegundoNombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or e.PrimerApellido COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or e.SegundoApellido COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or e.Cargo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'


	--Procedimiento de buscar Cliente
CREATE PROCEDURE Buscar_Cliente @Buscar nvarchar(30)
AS
DECLARE @Temp as TABLE
(IdCliente int,Cliente varchar(120),Telefono char(8),Correo nvarchar(50),Direccion nvarchar(100),Estado varchar(8))

INSERT INTO @Temp(IdCliente,Cliente,Telefono,Correo,Direccion,Estado)
(select
c.IdCliente as IdCliente,
cn.PrimerNombre + ' ' + cn.SegundoNombre + ' ' + cn.PrimerApellido + ' ' + cn.SegundoApellido, 
cn.Telefono as Teléfono,
cn.Correo as Correo,
cn.Direccion as Dirección,
c.Estado
from ClienteNatural cn inner join Cliente c
on c.IdCliente = cn.IdCliente)

INSERT INTO @Temp(IdCliente,Cliente,Telefono,Correo,Direccion,Estado)
(select
c.IdCliente as IdCliente,
cj.NombreCompañia,
cj.Telefono as Teléfono,
cj.Correo as Correo,
cj.Direccion as Dirección,
c.Estado
from ClienteJuridico cj inner join Cliente c
on c.IdCliente = cj.IdCliente)

SELECT * FROM @Temp c
WHERE c.Cliente COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
OR c.Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
OR c.Telefono COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
OR c.Correo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 

-------Buscar cliente sea natural o juridico ------------
CREATE PROCEDURE Buscar_ClienteTipo @IdCliente int
AS
IF EXISTS (SELECT * FROM ClienteNatural WHERE IdCliente  = @IdCliente)
BEGIN
	SELECT 'CN',IdCliente,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Telefono,Correo,Direccion FROM ClienteNatural WHERE IdCliente  = @IdCliente
END
ELSE
BEGIN
	SELECT 'CJ',IdCliente,NombreCompañia,NoRuc,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Telefono,Correo,Direccion FROM ClienteJuridico WHERE IdCliente  = @IdCliente
END

	---procedimiento de buscar productos
create procedure Buscar_Producto
	@Buscar nvarchar(30)
	as
	select 
	p.IdProducto as Id,
	p.Nombre as Nombre,
	p.Marca as Marca,
	p.Modelo as Modelo,
	p.Peso as Peso,
	p.Contenido as Contenido,
	p.Precio as Precio,
	p.UnidadesDisponibles as [Unidades disponibles],
	p.UnidadesOrdenadas as [Unidades ordenadas],
	p.UnidadesRequeridas as [Unidades requeridas],
	p.Estado as Estado
	from Producto p
where p.IdProducto like '%'+ @Buscar+ '%'
	or p.Nombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or p.Marca COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or p.Modelo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or p.Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'

	
---procedimiento de buscar Provedor
CREATE procedure Buscar_Proveedor
	@Buscar nvarchar(30)
	as
	select
	p.IdProveedor as Id,
	p.NombreCompañia as Compañía,
	p.RUC as RUC,
	p.Telefono as Teléfono,
	p.Correo as Correo,
	p.Credito as Crédito,
	p.Estado as Estado
	from Proveedor p
where RUC COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or NombreCompañia COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or Correo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'

	
	---procedimiento para buscar factura
ALTER PROCEDURE Buscar_Factura
@Buscar nvarchar(30)
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
FROM @Ventas 
	where Fecha  like '%'+ @Buscar+ '%' 
	or Cliente COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or NoFactura   like '%'+ @Buscar+ '%'
	ORDER BY NoFactura DESC

	
	---procedimiento para buscar compra
	ALTER PROCEDURE Buscar_Compra
	@Buscar nvarchar(30)
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
	where p.NombreCompañia COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or c.Tipo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or c.Fecha   like '%'+ @Buscar+ '%'
	or c.NoFactura   like '%'+ @Buscar+ '%'
	or c.Estado like '%'+@Buscar+'%'
	
CREATE PROCEDURE Buscar_Envio
	@IdFactura int
	AS
	SELECT
	e.IdEnvio as IdEnvio,
	f.NoFactura as [No factura],
	e.Direccion as Direccion,
	d.Nombre as Nombre,
	m.Nombre as Municipio,
	f.CostoEnvio as [Costo del envio],
	f.Estado as [Estado]
	FROM Envio e
	inner join Venta v
	on e.IdVenta = v.IdVenta
	inner join Factura f
	on f.IdVenta = v.IdVenta
	inner join Municipio m
	on e.IdMunicipio = m.IdMunicipio
	inner join Departamento d
	on m.IdDepartamento = d.IdDepartamento
	where f.IdFactura = @IdFactura

	ALTER PROCEDURE Buscar_DevCompras
	@Buscar nvarchar(30)
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
	where p.Nombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or p.Marca COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or p.Modelo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or devc.Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or c.NoFactura COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or devc.Fecha like '%'+ @Buscar+ '%'

	ALTER PROCEDURE Buscar_DevVentas
	@Buscar nvarchar(30)
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
	where p.Nombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or p.Marca COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or p.Modelo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or dvV.Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or dvV.Fecha like '%'+ @Buscar+ '%'

	ALTER PROCEDURE Buscar_PagosCredito
	@Buscar nvarchar(30)
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
	where p.NombreCompañia COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or c.NoFactura COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or cp.Fecha like '%'+ @Buscar+ '%'
	