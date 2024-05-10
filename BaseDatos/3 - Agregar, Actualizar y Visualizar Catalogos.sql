use Ferreteria

/*
	Autor: Anderson Sanchez
*/
--------------------------------------------------------- EMPLEADOS CRUD
CREATE procedure Insertar_Empleado
	@PrimerNombre nvarchar(30),
	@SegundoNombre nvarchar(30),
	@PrimerApellido nvarchar(30),
	@SegundoApellido nvarchar(30),
	@Cargo varchar(30),
	@Salario money,
	@Telefono char(8),
	@Correo nvarchar(50),
	@Direccion nvarchar(100)
	as
	begin
	insert into Empleado(PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido,Cargo, Salario, Telefono, Correo, Direccion, Estado)
			values (@PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido,@Cargo, @Salario, @Telefono, @Correo, @Direccion, 'Activo')
end

---
Create procedure Actualizar_Empleado
	@IdEmpleado int,
	@PrimerNombre nvarchar(30),
	@SegundoNombre nvarchar(30),
	@PrimerApellido nvarchar(30),
	@SegundoApellido nvarchar(30),
	@Cargo varchar(30),
	@Salario money,
	@Telefono char(8),
	@Correo nvarchar(50),
	@Direccion nvarchar(100)
	as
	update Empleado set PrimerNombre= @PrimerNombre,SegundoNombre= @SegundoNombre, 
						PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido,
						Cargo = @Cargo, Salario = @Salario,
						Telefono=@Telefono, Correo=@Correo, Direccion =@Direccion
	Where IdEmpleado=@IdEmpleado;

	
---Mostrar Empleado
create procedure Mostrar_Empleado
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

---Cambiar estado de empleado 
Create procedure Cambiar_EstadoEmpleado
@IdEmpleado int
AS
IF exists (
           SELECT
		   *
		   FROM Empleado WHERE IdEmpleado = @IdEmpleado and Estado = 'Activo'
           )
BEGIN
UPDATE Empleado SET
Estado = 'Inactivo' WHERE IdEmpleado = @IdEmpleado
END
ELSE if exists (SELECT
		        *
		        FROM Empleado WHERE IdEmpleado = @IdEmpleado and Estado = 'Inactivo')
BEGIN
UPDATE Empleado SET
Estado = 'Activo' WHERE IdEmpleado = @IdEmpleado
END

------------------------------	CLIENTES CRUD	-----------------------------------

---insertar los clientes
create procedure Insertar_ClienteNatural
	@PrimerNombre nvarchar(30),
	@SegundoNombre nvarchar(30),
	@PrimerApellido nvarchar(30),
	@SegundoApellido nvarchar(30),
	@Telefono char(8),
	@Correo nvarchar(50),
	@Direccion nvarchar(100)
	as
	begin
	INSERT INTO Cliente VALUES
	('Activo')

	insert into ClienteNatural( IdCliente,PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Telefono, Correo, Direccion)
			values ((SELECT TOP 1 IdCliente FROM Cliente Order by IdCliente Desc),@PrimerNombre, @SegundoApellido, @PrimerApellido, @SegundoApellido, @Telefono, @Correo, @Direccion)
end

create procedure Insertar_ClienteJuridico
	@NombreCompañia nvarchar(50),
	@NoRuc varchar(14),
	@PrimerNombre nvarchar(30),
	@SegundoNombre nvarchar(30),
	@PrimerApellido nvarchar(30),
	@SegundoApellido nvarchar(30),
	@Telefono char(8),
	@Correo nvarchar(50),
	@Direccion nvarchar(100)
	as
	begin
	INSERT INTO Cliente VALUES
	('Activo')

	insert into ClienteJuridico(IdCliente,NombreCompañia,NoRuc,PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Telefono, Correo, Direccion)
			values ((SELECT TOP 1 IdCliente FROM Cliente Order by IdCliente Desc),@NombreCompañia,@NoRuc,@PrimerNombre, @SegundoApellido, @PrimerApellido, @SegundoApellido, @Telefono, @Correo, @Direccion)
end

--Actualizar clientes
CREATE procedure Actualizar_ClienteNatural
	@IdCliente int,
	@PrimerNombre nvarchar(30),
	@SegundoNombre nvarchar(30),
	@PrimerApellido nvarchar(30),
	@SegundoApellido nvarchar(30),
	@Telefono char(8),
	@Correo nvarchar(50),
	@Direccion nvarchar(100)
	as
	update ClienteNatural set PrimerNombre= @PrimerNombre,SegundoNombre= @SegundoNombre, 
						PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, 
						Telefono=@Telefono, Correo=@Correo, Direccion =@Direccion
	Where IdCliente=@IdCliente;

Create procedure Actualizar_ClienteJuridico
	@IdCliente int,
	@NombreCompañia nvarchar(50),
	@NoRuc varchar(14),
	@PrimerNombre nvarchar(30),
	@SegundoNombre nvarchar(30),
	@PrimerApellido nvarchar(30),
	@SegundoApellido nvarchar(30),
	@Telefono char(8),
	@Correo nvarchar(50),
	@Direccion nvarchar(100)
	as
	update ClienteJuridico set NombreCompañia = @NombreCompañia, NoRuc = @NoRuc,PrimerNombre= @PrimerNombre,SegundoNombre= @SegundoNombre, 
						PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, 
						Telefono=@Telefono, Correo=@Correo, Direccion =@Direccion
	Where IdClienteJuridico=@IdCliente;

---Mostrar Cliente
CREATE PROCEDURE Mostrar_Cliente
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

SELECT * FROM @Temp Order By IdCliente ASC

---Cambiar estado de cliente
CREATE procedure Cambiar_EstadoCliente
@IdCliente int
AS
IF exists (
           (SELECT
		   *
		   FROM Cliente WHERE IdCliente = @IdCliente and Estado = 'Activo')
		   )	
	BEGIN
	UPDATE Cliente SET
	Estado = 'Inactivo' WHERE IdCliente = @IdCliente
	END
ELSE if exists (SELECT
		        *
		        FROM Cliente WHERE IdCliente = @IdCliente and Estado = 'Inactivo')
	BEGIN
	UPDATE Cliente SET
	Estado = 'Activo' WHERE IdCliente = @IdCliente
	END
ELSE IF exists (
           (SELECT
		   *
		   FROM Cliente WHERE IdCliente = @IdCliente and Estado = 'Activo')
		   )
	BEGIN
	UPDATE Cliente SET
	Estado = 'Inactivo' WHERE IdCliente = @IdCliente
	END
	ELSE if exists (SELECT
		        *
		        FROM Cliente WHERE IdCliente = @IdCliente and Estado = 'Inactivo')
	BEGIN
	UPDATE Cliente SET
	Estado = 'Activo' WHERE IdCliente = @IdCliente
	END

-------------------------------- PRODUCTO CRUD	---------------------------------------
	Create procedure Insertar_Producto
	@Nombre varchar(50),
	@Marca varchar(50),
	@Modelo varchar(50),
	@Peso float,
	@Contenido varchar(10),
	@Precio money,
	@UnidadesRequeridas int
	as
	BEGIN
	insert into  Producto
	values ( @Nombre, @Marca, @Modelo, @Peso, @Contenido, @Precio,0,0, @UnidadesRequeridas, 'Activo' )
	end
	
	Create procedure Actualizar_Producto
	@IdProducto int,
	@Nombre varchar(50),
	@Marca varchar(50),
	@Modelo varchar(50),
	@Peso float,
	@Contenido varchar(10),
	@Precio money,
	@UnidadesRequeridas int
	as
	update Producto set Nombre=@Nombre, Marca = @Marca, Modelo =@Modelo, Peso = @Peso,Contenido = @Contenido,Precio=@Precio, 
	UnidadesRequeridas= @UnidadesRequeridas
	where IdProducto= @IdProducto


	--Mostrar productos
	CREATE procedure Mostrar_Productos
	as
	select 
	p.IdProducto as IdProducto,
	p.Nombre as Nombre,
	p.Marca as Marca,
	p.Modelo as Modelo,
	p.Peso as Peso,
	p.Contenido as Contenido,
	p.Precio as Precio,
	p.UnidadesDisponibles as [Unidades Disponibles],
	p.UnidadesOrdenadas as [Unidades Ordenadas],
	p.UnidadesRequeridas as [Unidades requeridas],
	p.Estado as Estado
	from Producto p

	Create procedure Cambiar_EstadoProducto
@IdProducto int
AS
IF exists (
           SELECT
		   *
		   FROM Producto WHERE IdProducto = @IdProducto and Estado = 'Activo'
           )
BEGIN
UPDATE Producto SET
Estado = 'Inactivo' WHERE IdProducto = @IdProducto
END
ELSE IF exists (SELECT
		        *
		        FROM Producto WHERE IdProducto = @IdProducto and Estado = 'Inactivo')
BEGIN
UPDATE Producto SET
Estado = 'Activo' WHERE IdProducto = @IdProducto
END

----------------------------------	PROVEEDOR CRUD	----------------------------------------
---Insertar Proveedor
	create Procedure Insertar_Proveedor
	@RUC varchar(14),
	@NombreCompañia nvarchar(50),
	@Telefono varchar(8),
	@Correo varchar(50),
	@Credito money
	as 
	begin 
	insert into Proveedor(RUC, NombreCompañia, Telefono, Correo, Credito, Estado)
			values(@RUC, @NombreCompañia, @Telefono, @Correo, @Credito, 'Activo')
	end

	----
	Create procedure Actualizar_Proveedor
	@IdProveedor int,
	@RUC varchar(14),
	@NombreCompañia nvarchar(50),
	@Telefono varchar(8),
	@Correo varchar(50),
	@Credito money
	as
	update Proveedor set RUC=@RUC, NombreCompañia = @NombreCompañia, Telefono= @Telefono,
						Correo = @Correo, Credito = @Credito
	where IdProveedor =@IdProveedor

	----MostrarProveedor
	CREATE procedure Mostrar_Proveedor
	as
	select
	p.IdProveedor as IdProveedor,
	p.NombreCompañia as Compañía,
	p.RUC as RUC,
	p.Telefono as Teléfono,
	p.Correo as Correo,
	p.Credito as Crédito,
	p.Estado as Estado
	from Proveedor p

Create procedure Cambiar_EstadoProveedor
@IdProveedor int
AS
IF exists (
           SELECT
		   *
FROM Proveedor WHERE IdProveedor = @IdProveedor and Estado = 'Activo'
           )
BEGIN
UPDATE Proveedor SET
Estado = 'Inactivo' WHERE IdProveedor = @IdProveedor
END
ELSE if exists (SELECT
		        *
		        FROM Proveedor WHERE IdProveedor = @IdProveedor and Estado = 'Inactivo')
BEGIN
UPDATE Proveedor SET
Estado = 'Activo' WHERE IdProveedor = @IdProveedor
END

-- LOCALIDAD 
CREATE PROCEDURE Mostrar_Departamentos
AS
SELECT * FROM Departamento

CREATE PROCEDURE Mostrar_Municipios @IdDepartamento int
AS
SELECT IdMunicipio,Nombre FROM Municipio WHERE IdDepartamento = @IdDepartamento