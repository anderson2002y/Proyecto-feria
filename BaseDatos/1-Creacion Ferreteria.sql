/*
	Base de datos del modelo de Negocio Ferretería Salmerón,
	ubicado en el municipio de Ciudad Sandino

	Autor: Andersón Sanchez
*/

create database Ferreteria
GO
use Ferreteria
GO

--

CREATE TABLE Cliente(
IdCliente int primary key identity(1,1) not null,
Estado varchar(8) --Activo /inactivo
)
GO
create table ClienteNatural
(
	IdClienteNatural int IDENTITY(1,1) primary key,
	IdCliente int foreign key references Cliente(IdCliente),
	PrimerNombre nvarchar(30),
	SegundoNombre nvarchar(30),
	PrimerApellido nvarchar(30),
	SegundoApellido nvarchar(30),
	Telefono char(8),
	Correo nvarchar(50),
	Direccion nvarchar(100),
)
GO
CREATE TABLE ClienteJuridico
(
	IdClienteJuridico int primary key identity(1,1) not null,
	IdCliente int foreign key references Cliente(IdCliente),
	NombreCompañia nvarchar(50) not null,
	NoRuc varchar(14) not null,
	PrimerNombre nvarchar(30),
	SegundoNombre nvarchar(30),
	PrimerApellido nvarchar(30),
	SegundoApellido nvarchar(30),
	Telefono char(8),
	Correo nvarchar(50),
	Direccion nvarchar(100)
)

GO
--
create table Empleado
(
	IdEmpleado int IDENTITY(1,1) primary key,
	PrimerNombre nvarchar(30),
	SegundoNombre nvarchar(30),
	PrimerApellido nvarchar(30),
	SegundoApellido nvarchar(30),
	Cargo varchar(30),
	Salario money,
	Telefono char(8),
	Correo nvarchar(50),
	Direccion nvarchar(100),
	Estado varchar(8)
) 
GO
--
CREATE TABLE Usuario(
	IdUsuario int identity(1,1) primary key,
	IdEmpleado int foreign key references Empleado(IdEmpleado),
	Username varchar(30),
	Contraseña nvarchar(80),
	Rol varchar (30),
	Estado varchar(8),
) 
GO

--
create table Producto
(
	IdProducto int IDENTITY(1,1) primary key,
	Nombre varchar(60),
	Marca varchar(50),
	Modelo varchar(50),
	Peso int,
	Contenido varchar(10),
	Precio money,
	UnidadesDisponibles int,
	UnidadesOrdenadas int,
	UnidadesRequeridas int,
	Estado varchar(8)
) 
GO

---
create table Proveedor
(
	IdProveedor int IDENTITY(1,1) primary key,
	RUC varchar(14),
	NombreCompañia nvarchar(50),
	Telefono varchar(8),
	Correo varchar(50),
	Credito money,
	Estado varchar(8)
) 
GO
--
create table Departamento
(
	IdDepartamento int IDENTITY(1,1) primary key,
	Nombre varchar(50),
	Region nvarchar(30)
) 
GO
--
create table Municipio
(	
	IdMunicipio int IDENTITY(1,1) primary key,
	IdDepartamento int,
	Nombre varchar(50),

	foreign key(IdDepartamento) references Departamento(IdDepartamento)
) 
GO

---
create table Compra
(
	IdCompra int IDENTITY(1,1) primary key,
	IdProveedor int,
	NoFactura varchar(30),
	Fecha date,
	Estadotransaccion nvarchar(8),
	Subtotal money,
	Descuento money,
	Iva money,
	Total money,

	foreign key(IdProveedor) references Proveedor(IdProveedor)
) 
GO
--
create table CreditoPago
(
	IdCredito int IDENTITY(1,1) primary key,
	IdCompra int,
	Fecha date,
	Pago money,

	foreign key(IdCompra) references Compra(IdCompra)
) 
GO

Create table DetalleCompra
(
	IdDetalleCompra int IDENTITY(1,1) primary key,	
	IdProducto int,
	IdCompra int,
	Precio money,
	Cantidad int,
	DescuentoUnidad money,
	Iva money,

	FOREIGN KEY(IdCompra) REFERENCES Compra(IdCompra),
	FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto)
) 
GO
--
Create table DevolucionCompra
(
	IdDevolucion int IDENTITY(1,1) primary key,
	IdDetalleCompra int,
	Fecha date,
	Cantidad int,
	Observacion nvarchar(60),
	Estado varchar(8),

	FOREIGN KEY(IdDetalleCompra) REFERENCES DetalleCompra(IdDetalleCompra)
) 
GO
--
create table Venta
(
	IdVenta int IDENTITY(1,1) primary key,
	IdCliente int,
	IdEmpleado int,
	
	foreign key(IdCliente) references Cliente(IdCliente),
	foreign key(IdEmpleado) references Empleado(IdEmpleado)
) 
GO

---
create table Envio
(
	IdEnvio int IDENTITY(1,1) primary key,
	IdVenta int,
	IdMunicipio int,
	Direccion nvarchar(60),
	foreign key(IdMunicipio) references Municipio(IdMunicipio),
	foreign key(IdVenta) references Venta(IdVenta)
) 
GO

---
create table DetalleVenta
(
	IdVenta int,
	IdProducto int,
	Cantidad int,
	Precio money,
	DescuentoUnidad money,
	FOREIGN KEY(IdVenta) REFERENCES Venta(IdVenta),
	FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto),
	PRIMARY KEY(IdVenta,IdProducto)
) 
GO

create table Factura
(
	IdFactura int IDENTITY(1,1) primary key,
	IdVenta int,
	NoFactura int,
	Fecha datetime,
	Subtotal money,
	CostoEnvio money,
	Descuento money,
	Total money,
	Estado varchar(9),	FOREIGN KEY(IdVenta) REFERENCES Venta(IdVenta)
) 
GO

Create table DevolucionVenta
(
	IdDevolucion int IDENTITY(1,1) primary key,
	IdFactura int,
	IdProducto int,
	Fecha date,
	Monto money,
	Cantidad int,
	Observacion nvarchar(60),
	Estado varchar(11),

	FOREIGN KEY(IdFactura) REFERENCES Factura(IdFactura),
	FOREIGN KEY(IdProducto) REFERENCES Producto(IdProducto)
) 
GO

