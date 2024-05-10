Use Ferreteria
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CrearModulo]
@Modulo Varchar(50)
as
begin
Insert into Modulo (Modulo)
values (@Modulo)
end
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure CrearRol
@Rol varchar (150)
as
begin
Insert INTO Rol VALUES(@Rol)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure CrearOperacion
@IdModulo int,
@Operacion varchar (100)
as
begin
Insert into Operacion (IdModulo,Operacion) values (@IdModulo,@Operacion)
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure AsignarOperacion
@IdRol int,
@IdOperacion int
as
INSERT INTO RolOperacion (IdRol,IdOperacion,Estado) VALUES(@IdRol,@IdOperacion,1)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AccesoRol]
@IdUsuario int,
@IdModulo int
as
select
o.IdOperacion,
ro.IdRolOperacion,
o.Operacion , 
ro.Estado
from Usuario u
inner join Rol r
on r.IdRol=U.IdRol
inner join RolOperacion ro
on ro.IdRol=r.IdRol
inner join Operacion o
on o.IdOperacion = ro.IdOperacion
inner join Modulo m
on m.IdModulo=o.IdModulo
where u.IdUsuario = @IdUsuario and o.IdModulo=@IdModulo

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure AccesoRolModulo
@IdUsuario int
as

select distinct m.IdModulo,m.Modulo
from Usuario u
inner join Rol r
on r.IdRol=U.IdRol
inner join RolOperacion ro
on ro.IdRol=r.IdRol
inner join Operacion o
on o.IdOperacion = ro.IdOperacion
inner join Modulo m
on m.IdModulo=o.IdModulo
where u.IdUsuario = @IdUsuario 


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure MostrarRoles
as
select 
IdRol,
Rol
from Rol

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure  MostrarOperacionesAsignadas
as
select
ro.IdRolOperacion,
R.IdRol,
o.IdOperacion,
r.Rol,
o.Operacion,
ro.Estado
from RolOperacion ro
inner join Rol r on
r.IdRol=RO.IdRol
INNER JOIN Operacion o on
o.IdOperacion = ro.IdOperacion

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure MostrarOperaciones @IdModulo int
as
select m.IdModulo,
o.IdOperacion,
ro.IdRolOperacion,
o.Operacion , 
m.Modulo 
from Usuario u
inner join Rol r
on r.IdRol=U.IdRol
inner join RolOperacion ro
on ro.IdRol=r.IdRol
inner join Operacion o
on o.IdOperacion = ro.IdOperacion
inner join Modulo m
on m.IdModulo=o.IdModulo
WHERE m.IdModulo = @IdModulo

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure MostrarModulos
as
Select * from Modulo
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

exec CrearRol 'Administrador'
exec CrearRol 'Vendedor'
exec CrearRol 'Contador'
exec CrearRol 'Gerente'

exec CrearModulo 'Catalogos'
exec CrearModulo 'Operaciones'
exec CrearModulo 'Reportes'
EXEC CrearModulo 'Seguridad'


exec CrearOperacion 1, 'Agregar cliente'
exec CrearOperacion 1, 'Visualizar cliente'
exec CrearOperacion 1, 'Actualizar cliente'
exec CrearOperacion 1, 'Agregar proveedor'
EXEC CrearOperacion 1, 'Visualizar proveedor'
EXEC CrearOperacion 1, 'Actualizar proveedor'
EXEC CrearOperacion 1, 'Cambiar estado de proveedor'
EXEC CrearOperacion 1, 'Agregar empleado'
EXEC CrearOperacion 1, 'Visualizar empleado'
EXEC CrearOperacion 1, 'Actualizar empleado'
EXEC CrearOperacion 1, 'Cambiar estado de empleado'
EXEC CrearOperacion 1, 'Agregar producto'
EXEC CrearOperacion 1, 'Visualizar producto'
EXEC CrearOperacion 1, 'Actualizar producto'
EXEC CrearOperacion 1, 'Cambiar estado de producto'
EXEC CrearOperacion 2, 'Registrar compra'
EXEC CrearOperacion 2, 'Visualizar compra'
EXEC CrearOperacion 2, 'Imprimir compra'
EXEC CrearOperacion 2, 'Cambiar estado de compra'
EXEC CrearOperacion 2, 'Pagar factura de compra'
EXEC CrearOperacion 2, 'Anular compra'
EXEC CrearOperacion 2, 'Registrar venta'
EXEC CrearOperacion 2, 'Visualizar venta'
EXEC CrearOperacion 2, 'Imprimir venta'
EXEC CrearOperacion 2, 'Cambiar estado de venta'
EXEC CrearOperacion 2, 'Anular venta'
EXEC CrearOperacion 2, 'Registrar devolución de compra'
EXEC CrearOperacion 2, 'Visualizar devolución de compra'
EXEC CrearOperacion 2, 'Imprimir devolución de compra'
EXEC CrearOperacion 2, 'Cambiar estado devolución de compra'
EXEC CrearOperacion 2, 'Registrar devolución de venta'
EXEC CrearOperacion 2, 'Visualizar devolución de venta'
EXEC CrearOperacion 2, 'Imprimir devolución de venta'
EXEC CrearOperacion 2, 'Cambiar estado devolución de venta'
EXEC CrearOperacion 3, 'Ver reporte de compras'
EXEC CrearOperacion 3, 'Ver reporte de ventas'
EXEC CrearOperacion 3, 'Ver reporte de devoluciones de compras'
EXEC CrearOperacion 3, 'Ver reporte de devoluciones de ventas'
EXEC CrearOperacion 3, 'Ver reporte de cuentas por pagar'
EXEC CrearOperacion 3, 'Ver reporte de clientes con mayor recaudación'
EXEC CrearOperacion 3, 'Ver reporte de clientes con mayores ventas realizadas'
EXEC CrearOperacion 3, 'Ver reporte de productos con mayor recaudación'
EXEC CrearOperacion 3, 'Ver reporte de productos más vendidos'
EXEC CrearOperacion 3, 'Ver otros tipos de reportes'

--Catalogo: 
--Vendedor
exec AsignarOperacion  2,1
exec AsignarOperacion  2,2
exec AsignarOperacion  2,3
EXEC AsignarOperacion 2,13

--Contador
EXEC AsignarOperacion 3,3
EXEC AsignarOperacion 3,5
EXEC AsignarOperacion 3,9
EXEC AsignarOperacion 3,13

--Gerente
EXEC AsignarOperacion 4,1
EXEC AsignarOperacion 4,2
EXEC AsignarOperacion 4,3
EXEC AsignarOperacion 4,4
EXEC AsignarOperacion 4,5
EXEC AsignarOperacion 4,6
EXEC AsignarOperacion 4,7
EXEC AsignarOperacion 4,8
EXEC AsignarOperacion 4,9
EXEC AsignarOperacion 4,10
EXEC AsignarOperacion 4,11
EXEC AsignarOperacion 4,12
EXEC AsignarOperacion 4,13
EXEC AsignarOperacion 4,14
EXEC AsignarOperacion 4,15

EXEC Insertar_Usuario 1,4,'carlos1234'
EXEC Insertar_Usuario 2,2,'luis1234'
EXEC Insertar_Usuario 3,2,'juan1234'
EXEC Insertar_Usuario 4,3,'adriana1234'
EXEC Insertar_Usuario 6,1,'jimmy1234'
EXEC Insertar_Usuario 7,1,'jeison1234'
EXEC Insertar_Usuario 8,1,'anderson1234'

--Operaciones
--Gerente
EXEC AsignarOperacion 4,16
EXEC AsignarOperacion 4,17
EXEC AsignarOperacion 4,18
EXEC AsignarOperacion 4,19
EXEC AsignarOperacion 4,20
EXEC AsignarOperacion 4,21
EXEC AsignarOperacion 4,27
EXEC AsignarOperacion 4,28
EXEC AsignarOperacion 4,29
EXEC AsignarOperacion 4,30

--Vendedor
EXEC AsignarOperacion 2,22
EXEC AsignarOperacion 2,23
EXEC AsignarOperacion 2,24
EXEC AsignarOperacion 2,25
EXEC AsignarOperacion 2,26
EXEC AsignarOperacion 2,31
EXEC AsignarOperacion 2,32
EXEC AsignarOperacion 2,33
EXEC AsignarOperacion 2,34

--Contador
EXEC AsignarOperacion 3,17
EXEC AsignarOperacion 3,23
EXEC AsignarOperacion 3,28
EXEC AsignarOperacion 3,32


--Reportes
--Gerente
EXEC AsignarOperacion 4,35
EXEC AsignarOperacion 4,36
EXEC AsignarOperacion 4,37
EXEC AsignarOperacion 4,38
EXEC AsignarOperacion 4,39
EXEC AsignarOperacion 4,40
EXEC AsignarOperacion 4,41
EXEC AsignarOperacion 4,42
EXEC AsignarOperacion 4,43
EXEC AsignarOperacion 4,44

--Contador
EXEC AsignarOperacion 3,35
EXEC AsignarOperacion 3,36
EXEC AsignarOperacion 3,37
EXEC AsignarOperacion 3,38
EXEC AsignarOperacion 3,39
EXEC AsignarOperacion 3,40
EXEC AsignarOperacion 3,41
EXEC AsignarOperacion 3,42
EXEC AsignarOperacion 3,43
EXEC AsignarOperacion 3,44