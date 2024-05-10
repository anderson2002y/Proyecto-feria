CREATE DATABASE Ferreteria
GO
USE [Ferreteria]
GO
/****** Object:  UserDefinedFunction [dbo].[Buscar_PrecioProducto]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Buscar_PrecioProducto](@IdProducto int)
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
GO
/****** Object:  UserDefinedFunction [dbo].[Buscar_PrecioProducto_Factura]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Buscar_PrecioProducto_Factura](@IdFactura int,@IdProducto int)
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
GO
/****** Object:  UserDefinedFunction [dbo].[Calcular_IvaUnitario]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Calcular_IvaUnitario](@Precio money,@Descuento float)
	RETURNS money
	AS
	BEGIN
	DECLARE @Iva money
	SET @Iva = (@Precio - @Precio*@Descuento) * (0.15) 

	RETURN @Iva
	END
GO
/****** Object:  UserDefinedFunction [dbo].[GET_NAME]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[GET_NAME](@idC as int)
returns varchar(max)
as
BEGIN
	declare @name as varchar(max)
	if (EXISTS (SELECT * FROM ClienteNatural where IdCliente = @idC))
		set @name = (SELECT top 1 n.PrimerNombre + ' ' + COALESCE(n.SegundoNombre, '') + ' ' 
+ n.PrimerApellido + ' ' + COALESCE(n.SegundoApellido, '') FROM ClienteNatural n where IdCliente = @idC)
	else if (EXISTS (SELECT * FROM ClienteJuridico where IdCliente = @idC))
		set @name = (SELECT top 1 j.NombreCompañia FROM ClienteJuridico j where IdCliente = @idC)

	return @name
END
GO
/****** Object:  UserDefinedFunction [dbo].[GET_PRODUCT_INFO]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[GET_PRODUCT_INFO](@IDP as int)
returns varchar(max)
as
begin
	declare @name as varchar(max)

	set @name = (Select p.Marca + ' ' +p.Nombre + ' ' + CAST(p.Peso AS VARCHAR) + ' ' + p.Medida from Producto p where IdProducto = @IDP)

	return @name
end 
GO
/****** Object:  UserDefinedFunction [dbo].[GET_PRODUCT_Q]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GET_PRODUCT_Q](@IDP as int, @FI DATE, @FF DATE, @idc int)
returns INT
as
begin
	declare @Q as INT

	set @Q = (select SUM(D.Cantidad) from Producto P  
	INNER JOIN DetalleVenta D ON D.IdProducto = P.IdProducto 
	INNER JOIN Factura F ON F.IdVenta= D.IdVenta 
	INNER JOIN Venta v ON v.IdVenta=d.IdVenta
	WHERE F.Fecha BETWEEN @FI AND @FF AND D.IdProducto = @IDP AND v.IdCliente = @idc) 

	return @Q
end 
GO
/****** Object:  UserDefinedFunction [dbo].[Suma_DescuentoCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Suma_DescuentoCompra]
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
GO
/****** Object:  UserDefinedFunction [dbo].[Suma_DescuentoVenta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Suma_DescuentoVenta](@IdVenta int)
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
GO
/****** Object:  UserDefinedFunction [dbo].[Suma_IvaCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Suma_IvaCompra]
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
GO
/****** Object:  UserDefinedFunction [dbo].[Suma_SubTotalCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Suma_SubTotalCompra](@IdCompra int)
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
GO
/****** Object:  UserDefinedFunction [dbo].[Suma_SubTotalVenta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Suma_SubTotalVenta](@IdVenta int)
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
GO
/****** Object:  UserDefinedFunction [dbo].[Ultima_Venta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Ultima_Venta]()
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
GO
/****** Object:  UserDefinedFunction [dbo].[UltimaCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[UltimaCompra]()
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
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteJuridico]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteJuridico](
	[IdClienteJuridico] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[NombreCompañia] [nvarchar](50) NOT NULL,
	[NoRuc] [varchar](14) NOT NULL,
	[PrimerNombre] [nvarchar](30) NULL,
	[SegundoNombre] [nvarchar](30) NULL,
	[PrimerApellido] [nvarchar](30) NULL,
	[SegundoApellido] [nvarchar](30) NULL,
	[Telefono] [char](8) NULL,
	[Correo] [nvarchar](50) NULL,
	[Direccion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdClienteJuridico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteNatural]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteNatural](
	[IdClienteNatural] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[PrimerNombre] [nvarchar](30) NULL,
	[SegundoNombre] [nvarchar](30) NULL,
	[PrimerApellido] [nvarchar](30) NULL,
	[SegundoApellido] [nvarchar](30) NULL,
	[Telefono] [char](8) NULL,
	[Correo] [nvarchar](50) NULL,
	[Direccion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdClienteNatural] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdProveedor] [int] NULL,
	[NoFactura] [varchar](30) NULL,
	[Fecha] [date] NULL,
	[Tipo] [nvarchar](12) NULL,
	[Subtotal] [money] NULL,
	[Descuento] [money] NULL,
	[Iva] [money] NULL,
	[Total] [money] NULL,
	[Estado] [nvarchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditoPago]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditoPago](
	[IdCredito] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NULL,
	[Fecha] [date] NULL,
	[Pago] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCredito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[IdDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Region] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[IdCompra] [int] NULL,
	[Precio] [money] NULL,
	[Cantidad] [int] NULL,
	[DescuentoUnidad] [money] NULL,
	[Iva] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NULL,
	[Precio] [money] NULL,
	[DescuentoUnidad] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevolucionCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevolucionCompra](
	[IdDevolucion] [int] IDENTITY(1,1) NOT NULL,
	[IdDetalleCompra] [int] NULL,
	[Fecha] [date] NULL,
	[Cantidad] [int] NULL,
	[Observacion] [nvarchar](60) NULL,
	[Estado] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDevolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevolucionVenta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevolucionVenta](
	[IdDevolucion] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NULL,
	[IdProducto] [int] NULL,
	[Fecha] [date] NULL,
	[Monto] [money] NULL,
	[Cantidad] [int] NULL,
	[Observacion] [nvarchar](60) NULL,
	[Estado] [varchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDevolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [nvarchar](30) NULL,
	[SegundoNombre] [nvarchar](30) NULL,
	[PrimerApellido] [nvarchar](30) NULL,
	[SegundoApellido] [nvarchar](30) NULL,
	[Cargo] [varchar](30) NULL,
	[Salario] [money] NULL,
	[Telefono] [char](8) NULL,
	[Correo] [nvarchar](50) NULL,
	[Direccion] [nvarchar](100) NULL,
	[Estado] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Envio]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Envio](
	[IdEnvio] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdMunicipio] [int] NULL,
	[Direccion] [nvarchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEnvio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[NoFactura] [int] NULL,
	[Fecha] [datetime] NULL,
	[Subtotal] [money] NULL,
	[CostoEnvio] [money] NULL,
	[Descuento] [money] NULL,
	[Total] [money] NULL,
	[Estado] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipio]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipio](
	[IdMunicipio] [int] IDENTITY(1,1) NOT NULL,
	[IdDepartamento] [int] NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMunicipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion](
	[IdOperacion] [int] IDENTITY(1,1) NOT NULL,
	[IdModulo] [int] NULL,
	[Operacion] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](60) NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[Peso] [int] NULL,
	[Medida] [varchar](10) NULL,
	[Precio] [money] NULL,
	[UnidadesDisponibles] [int] NULL,
	[UnidadesRequeridas] [int] NULL,
	[Estado] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[RUC] [varchar](14) NULL,
	[NombreCompañia] [nvarchar](50) NULL,
	[Telefono] [varchar](8) NULL,
	[Correo] [varchar](50) NULL,
	[Credito] [money] NULL,
	[Estado] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolOperacion]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolOperacion](
	[IdRolOperacion] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[IdOperacion] [int] NULL,
	[Estado] [bit] not null,
PRIMARY KEY CLUSTERED 
(
	[IdRolOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NULL,
	[IdRol] [int] NULL,
	[Username] [varchar](30) NULL,
	[Contraseña] [nvarchar](80) NULL,
	[Estado] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdEmpleado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClienteJuridico]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[ClienteNatural]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[CreditoPago]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([IdCompra])
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([IdCompra])
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[DevolucionCompra]  WITH CHECK ADD FOREIGN KEY([IdDetalleCompra])
REFERENCES [dbo].[DetalleCompra] ([IdDetalleCompra])
GO
ALTER TABLE [dbo].[DevolucionVenta]  WITH CHECK ADD FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[DevolucionVenta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD FOREIGN KEY([IdMunicipio])
REFERENCES [dbo].[Municipio] ([IdMunicipio])
GO
ALTER TABLE [dbo].[Envio]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[Municipio]  WITH CHECK ADD FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[Departamento] ([IdDepartamento])
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulo] ([IdModulo])
GO
ALTER TABLE [dbo].[RolOperacion]  WITH CHECK ADD FOREIGN KEY([IdOperacion])
REFERENCES [dbo].[Operacion] ([IdOperacion])
GO
ALTER TABLE [dbo].[RolOperacion]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_ClienteJuridico]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Actualizar_ClienteJuridico]
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
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_ClienteNatural]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Actualizar_ClienteNatural]
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
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Empleado]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Actualizar_Empleado]
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
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Producto]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Actualizar_Producto]
	@IdProducto int,
	@Nombre varchar(50),
	@Marca varchar(50),
	@Modelo varchar(50),
	@Peso float,
	@Medida varchar(10),
	@Precio money,
	@UnidadesRequeridas int
	as
	update Producto set Nombre=@Nombre, Marca = @Marca, Modelo =@Modelo, Peso = @Peso,Medida = @Medida,Precio=@Precio, 
	UnidadesRequeridas= @UnidadesRequeridas
	where IdProducto= @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Proveedor]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Actualizar_Proveedor]
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
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Usuario]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Actualizar_Usuario]
	@IdUsuario int,
	@IdRol varchar(30)
	as 
	update Usuario set IdRol=@IdRol
	where IdUsuario = @IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Cliente]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_Cliente] @Buscar nvarchar(30)
AS
DECLARE @Temp as TABLE
(IdCliente int,Cliente varchar(120),Telefono char(8),Correo nvarchar(50),Direccion nvarchar(100))

INSERT INTO @Temp(IdCliente,Cliente,Telefono,Correo,Direccion)
(select
c.IdCliente as IdCliente,
cn.PrimerNombre + ' ' + cn.SegundoNombre + ' ' + cn.PrimerApellido + ' ' + cn.SegundoApellido, 
cn.Telefono as Teléfono,
cn.Correo as Correo,
cn.Direccion as Dirección
from ClienteNatural cn inner join Cliente c
on c.IdCliente = cn.IdCliente)

INSERT INTO @Temp(IdCliente,Cliente,Telefono,Correo,Direccion)
(select
c.IdCliente as IdCliente,
cj.NombreCompañia,
cj.Telefono as Teléfono,
cj.Correo as Correo,
cj.Direccion as Dirección
from ClienteJuridico cj inner join Cliente c
on c.IdCliente = cj.IdCliente)

SELECT * FROM @Temp c
WHERE c.Cliente COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
OR c.Telefono COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
OR c.Correo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
GO
/****** Object:  StoredProcedure [dbo].[Buscar_ClienteTipo]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_ClienteTipo] @IdCliente int
AS
IF EXISTS (SELECT * FROM ClienteNatural WHERE IdCliente  = @IdCliente)
BEGIN
	SELECT 'CN',IdCliente,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Telefono,Correo,Direccion FROM ClienteNatural WHERE IdCliente  = @IdCliente
END
ELSE
BEGIN
	SELECT 'CJ',IdCliente,NombreCompañia,NoRuc,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Telefono,Correo,Direccion FROM ClienteJuridico WHERE IdCliente  = @IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Compra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_Compra]
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
	ORDER BY c.IdCompra DESC
GO
/****** Object:  StoredProcedure [dbo].[Buscar_DevCompras]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_DevCompras]
	@Buscar nvarchar(30)
	AS
	SELECT 
	devc.IdDevolucion as IdDevolucion,
	devc.IdDetalleCompra as IdDetalleCompra,
	c.NoFactura as [Factura],
	CONVERT(VARCHAR, devc.Fecha, 6) as [Fecha devolución],
	p.Nombre as Producto,
	p.Marca as Marca,
	p.Modelo as Modelo,
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
GO
/****** Object:  StoredProcedure [dbo].[Buscar_DevVentas]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_DevVentas]
	@Buscar nvarchar(30)
	AS
	SELECT
	dvv.IdDevolucion as IdDevolucion,
	f.NoFactura as [Factura],
	CONVERT(VARCHAR, dvV.Fecha, 6) as Fecha,
	p.Nombre as Producto,
	p.Marca as Marca,
	p.Modelo as Modelo,
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
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Empleado]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Buscar_Empleado]
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
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Envio]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_Envio]
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
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Envios]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_Envios]
	@Buscar nvarchar(30)
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
	where e.Direccion COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or f.Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or d.Nombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or m.Nombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Factura]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_Factura]
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
GO
/****** Object:  StoredProcedure [dbo].[Buscar_PagosCredito]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_PagosCredito]
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
	
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Producto]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Buscar_Producto]
	@Buscar nvarchar(30)
	as
	select 
	p.IdProducto as Id,
	p.Nombre as Nombre,
	p.Marca as Marca,
	p.Modelo as Modelo,
	p.Peso as Peso,
	p.Medida as Contenido,
	p.Precio as Precio,
	p.UnidadesDisponibles as [Existencias],
	p.UnidadesRequeridas as [Requeridas],
	p.Estado as Estado
	from Producto p
where p.IdProducto like '%'+ @Buscar+ '%'
	or p.Nombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%' 
	or p.Marca COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or p.Modelo COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
	or p.Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+ @Buscar+ '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Proveedor]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Buscar_Proveedor]
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
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Usuarios]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Buscar_Usuarios]
	@Buscar nvarchar(20)
    as 
	Select
	IdUsuario as [Id usuario],
	e.PrimerNombre + ' ' + e.PrimerApellido as Nombre,
    u.Username as [Nombre de usuario],
	r.Rol as Rol,
	u.Estado as Estado
	from Usuario u
	inner join Empleado e
	on u.IdEmpleado = e.IdEmpleado
	inner join Rol r 
	on u.IdRol = r.IdRol
	where u.Username COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or r.Rol COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or u.Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or e.PrimerNombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or e.PrimerApellido COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
GO
/****** Object:  StoredProcedure [dbo].[Cambiar_Contraseña_Usuario]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Cambiar_Contraseña_Usuario]
		@IdUsuario int,
	@Username varchar(30),
	@Contraseña varchar(30),
	@nueva varchar (30)
	as 
	 if exists (Select username from Usuario 
			where cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as varchar(100)) = @contraseña
			and username = @Username and Estado = 'Activo'and cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as  varchar(100)) != @nueva)
	BEGIN
	Select 'Contraseña Actualizada con exito' as Resultado from Usuario u
	inner join Empleado e
	on e.IdEmpleado = u.IdEmpleado
	where cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as  varchar(100)) = @contraseña
	update Usuario set
	Contraseña =ENCRYPTBYPASSPHRASE(@nueva,@nueva) 
	where IdUsuario = @IdUsuario
	END
	else if exists (Select username from Usuario 
			where cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as varchar(100)) = @contraseña
			and cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as  varchar(100)) = @nueva)
	BEGIN
	SELECT 'No debe poner la misma contraseña' as Resultado
	END
	else
	Select 'Acceso Denegado' as Resultado
GO
/****** Object:  StoredProcedure [dbo].[Cambiar_Estado_Usuario]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Cambiar_Estado_Usuario]
	@IdUsuario int
	AS
	IF exists (
			   SELECT
			   *
			   FROM Usuario WHERE IdUsuario = @IdUsuario and Estado = 'Activo'
			   )
	BEGIN
	UPDATE Usuario SET
	Estado = 'Inactivo' WHERE IdUsuario = @IdUsuario
	END
	ELSE if exists (SELECT
					*
					FROM Usuario WHERE IdUsuario = @IdUsuario and Estado = 'Inactivo')
	BEGIN
	UPDATE Usuario SET
	Estado = 'Activo' WHERE IdUsuario = @IdUsuario
	END
GO
/****** Object:  StoredProcedure [dbo].[Cambiar_EstadoEmpleado]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Cambiar_EstadoEmpleado]
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
GO
/****** Object:  StoredProcedure [dbo].[Cambiar_EstadoFactura]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Cambiar_EstadoFactura]
@IdFactura int
AS
IF exists (
           SELECT
		   *
		   FROM Factura WHERE IdFactura = @IdFactura and Estado = 'Facturado'
           )
BEGIN
UPDATE Factura SET
Estado = 'Entregado' WHERE IdFactura = @IdFactura
END
ELSE if exists (SELECT
		        *
		        FROM Factura WHERE IdFactura = @IdFactura and Estado = 'Entregado')
BEGIN
UPDATE Factura SET
Estado = 'Anulado' WHERE IdFactura = @IdFactura
END
GO
/****** Object:  StoredProcedure [dbo].[Cambiar_EstadoProducto]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	Create procedure [dbo].[Cambiar_EstadoProducto]
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
GO
/****** Object:  StoredProcedure [dbo].[Cambiar_EstadoProveedor]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Cambiar_EstadoProveedor]
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

GO
/****** Object:  StoredProcedure [dbo].[CambiarEstado_DevolucionCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CambiarEstado_DevolucionCompra]
@IdDevolucion int
AS
IF exists (
           SELECT
		   *
		   FROM DevolucionCompra WHERE IdDevolucion = @IdDevolucion and Estado = 'Aceptado'
           )
BEGIN
UPDATE DevolucionCompra SET
Estado = 'Recibido' WHERE IdDevolucion = @IdDevolucion
END
ELSE
BEGIN
UPDATE DevolucionCompra SET
Estado = 'Aceptado' WHERE IdDevolucion= @IdDevolucion
END
GO
/****** Object:  StoredProcedure [dbo].[CambiarEstado_DevolucionVenta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CambiarEstado_DevolucionVenta]
@IdDevolucion int
AS
IF exists (
           SELECT
		   *
		   FROM DevolucionVenta WHERE IdDevolucion = @IdDevolucion and Estado = 'Aceptado'
           )
BEGIN
UPDATE DevolucionVenta SET
Estado = 'Entregado' WHERE IdDevolucion = @IdDevolucion
END
ELSE
BEGIN
UPDATE DevolucionVenta SET
Estado = 'Aceptado' WHERE IdDevolucion= @IdDevolucion
END
GO
/****** Object:  StoredProcedure [dbo].[Insertar_ClienteJuridico]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Insertar_ClienteJuridico]
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
	DECLARE @IdCliente int
	SET @IdCliente = (SELECT COUNT(*) FROM Cliente) + 1
	DECLARE @IdClienteNatural int
	SET @IdClienteNatural = (SELECT COUNT(*) FROM ClienteJuridico) + 1

	INSERT INTO Cliente(IdCliente) VALUES (@IdCliente)
	insert into ClienteJuridico(IdCliente,NombreCompañia,NoRuc,PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Telefono, Correo, Direccion)
			values ((SELECT TOP 1 IdCliente FROM Cliente Order by IdCliente Desc),@NombreCompañia,@NoRuc,@PrimerNombre, @SegundoApellido, @PrimerApellido, @SegundoApellido, @Telefono, @Correo, @Direccion)
end
GO
/****** Object:  StoredProcedure [dbo].[Insertar_ClienteNatural]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertar_ClienteNatural]
	@PrimerNombre nvarchar(30),
	@SegundoNombre nvarchar(30),
	@PrimerApellido nvarchar(30),
	@SegundoApellido nvarchar(30),
	@Telefono char(8),
	@Correo nvarchar(50),
	@Direccion nvarchar(100)
	as
	begin
	DECLARE @IdCliente int
	SET @IdCliente = (SELECT COUNT(*) FROM Cliente) + 1
	DECLARE @IdClienteNatural int
	SET @IdClienteNatural = (SELECT COUNT(*) FROM ClienteNatural) + 1

	INSERT INTO Cliente(IdCliente) VALUES (@IdCliente)

	insert into ClienteNatural( IdCliente,PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Telefono, Correo, Direccion)
			values ((SELECT TOP 1 IdCliente FROM Cliente Order by IdCliente Desc),@PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @Telefono, @Correo, @Direccion)
end
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Empleado]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertar_Empleado]
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
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Producto]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Insertar_Producto]
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
	values ( @Nombre, @Marca, @Modelo, @Peso, @Contenido, @Precio,0, @UnidadesRequeridas, 'Activo' )
	end
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Proveedor]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Insertar_Proveedor]
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
GO
/****** Object:  StoredProcedure [dbo].[Insertar_Usuario]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertar_Usuario] 
	@IdEmpleado int,
	@IdRol INT,
	@Contraseña varchar (30)
	as
	declare @user varchar(50)
	SET @user = (select LOWER(PrimerNombre + PrimerApellido) from Empleado where IdEmpleado = @IdEmpleado)

	if exists  (Select * from Usuario WHERE IdEmpleado = @IdEmpleado)
	BEGIN
	 SELECT 'El empleado tiene ya un usuario'
	 RETURN
	END
	else if exists (Select Username from Usuario where Username = @user)
	BEGIN
		DECLARE @Cantidad int
		SET @Cantidad = (select COUNT(*) from Empleado WHERE @user = LOWER(PrimerNombre + PrimerApellido)) + 1
		SET @user = @user + CONVERT(varchar(5),@Cantidad)
	END

	insert into Usuario(IdEmpleado, Username, Contraseña, IdRol,Estado) 
	values (@IdEmpleado, @user, ENCRYPTBYPASSPHRASE(@Contraseña,@Contraseña), @IdRol, 'Activo')
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Cliente]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Mostrar_Cliente]
AS
DECLARE @Temp as TABLE
(IdCliente int,Cliente varchar(120),Telefono char(8),Correo nvarchar(50),Direccion nvarchar(100))

INSERT INTO @Temp(IdCliente,Cliente,Telefono,Correo,Direccion)
(select
c.IdCliente as IdCliente,
cn.PrimerNombre + ' ' + cn.SegundoNombre + ' ' + cn.PrimerApellido + ' ' + cn.SegundoApellido, 
cn.Telefono as Teléfono,
cn.Correo as Correo,
cn.Direccion as Dirección
from ClienteNatural cn inner join Cliente c
on c.IdCliente = cn.IdCliente)

INSERT INTO @Temp(IdCliente,Cliente,Telefono,Correo,Direccion)
(select
c.IdCliente as IdCliente,
cj.NombreCompañia,
cj.Telefono as Teléfono,
cj.Correo as Correo,
cj.Direccion as Dirección
from ClienteJuridico cj inner join Cliente c
on c.IdCliente = cj.IdCliente)

SELECT * FROM @Temp Order By IdCliente ASC
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Departamentos]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Mostrar_Departamentos]
AS
SELECT * FROM Departamento
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Empleado]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Mostrar_Empleado]
as 
select
e.IdEmpleado as IdEmpleado,
e.PrimerNombre + ' ' + e.SegundoNombre + ' ' + e.PrimerApellido + ' ' + e.SegundoApellido as Empleado,
e.Cargo as Cargo,
'C$' + CONVERT(VARCHAR,CAST(e.Salario AS MONEY),1) as Salario,
e.Telefono as Teléfono,
e.Correo as Correo,
e.Direccion as Dirección,
e.Estado as Estado
from Empleado e
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Municipios]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Mostrar_Municipios] @IdDepartamento int
AS
SELECT IdMunicipio,Nombre FROM Municipio WHERE IdDepartamento = @IdDepartamento
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Productos]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Mostrar_Productos]
	as
	select 
	p.IdProducto as IdProducto,
	p.Nombre as Nombre,
	p.Marca as Marca,
	p.Modelo as Modelo,
	p.Peso as Peso,
	p.Medida as Medida,
	'C$' + CONVERT(VARCHAR,CAST(p.Precio AS MONEY),1) as Precio,
	p.UnidadesDisponibles as [Existencias],
	p.UnidadesRequeridas as [Requeridas],
	p.Estado as Estado
	from Producto p
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Proveedor]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE procedure [dbo].[Mostrar_Proveedor]
	as
	select
	p.IdProveedor as IdProveedor,
	p.NombreCompañia as Compañía,
	p.RUC as RUC,
	p.Telefono as Teléfono,
	p.Correo as Correo,
	'C$' + CONVERT(VARCHAR,CAST(p.Credito AS MONEY),1) as Crédito,
	p.Estado as Estado
	from Proveedor p
GO
/****** Object:  StoredProcedure [dbo].[Nueva_DevCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Nueva_DevCompra] @IdDetalleCompra int, @Cantidad int, @Observacion nvarchar(60),@Estado varchar(8)
AS
INSERT INTO DevolucionCompra VALUES
(@IdDetalleCompra,GETDATE(),@Cantidad,@Observacion,@Estado)
GO
/****** Object:  StoredProcedure [dbo].[Nueva_DevVenta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Nueva_DevVenta] @IdFactura int, @IdProducto int, @Cantidad int, @Observacion nvarchar(60), @Estado varchar(11)
AS
INSERT INTO DevolucionVenta VALUES
(@IdFactura,@IdProducto,GETDATE(),dbo.Buscar_PrecioProducto_Factura(@IdFactura,@IdProducto),@Cantidad,@Observacion,@Estado)
GO
/****** Object:  StoredProcedure [dbo].[Precio_Producto]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Precio_Producto]
@IdProducto int
as
select TOP 1 Precio-(Precio*DescuentoUnidad)+Iva from DetalleCompra
where IdProducto = @IdProducto
ORDER BY IdCompra desc
GO
/****** Object:  StoredProcedure [dbo].[Registrar_Compra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_Compra]
@IdProveedor int, 
@Tipo varchar(20),
@NoFactura varchar(20),
@Fecha date
AS
Declare @Estado Varchar(15)
if (@Tipo='Crédito')
set @Estado='Pendiente'
else 
set @Estado='Registrado'
INSERT INTO Compra(IdProveedor,Tipo, NoFactura,Fecha,Subtotal,Descuento,Iva,Total,Estado) VALUES
(@IdProveedor,
@Tipo,
@NoFactura,
@Fecha,
0,
0,
0,
0,
@Estado
)
GO
/****** Object:  StoredProcedure [dbo].[Registrar_DetCompra]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_DetCompra] 
@IdProducto int,
@Cantidad int,
@Descuento money,
@Precio money
AS
INSERT INTO 
DetalleCompra VALUES
(@IdProducto,dbo.UltimaCompra(),@Precio*0.85,@Cantidad,@Descuento, dbo.Calcular_IvaUnitario(@Precio,@Descuento))
GO
/****** Object:  StoredProcedure [dbo].[Registrar_DetVenta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_DetVenta] @IdProducto int, @Cantidad int, @Descuento money
AS
INSERT INTO DetalleVenta VALUES
(dbo.Ultima_Venta(),@IdProducto,@Cantidad,dbo.Buscar_PrecioProducto(@IdProducto),@Descuento)
GO
/****** Object:  StoredProcedure [dbo].[Registrar_Envio]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_Envio] @IdMunicipio int, @Direccion varchar(100)
AS
INSERT INTO Envio VALUES
( (SELECT Top 1 IdVenta FROM Venta ORDER BY IdVenta DESC),@IdMunicipio,@Direccion)
GO
/****** Object:  StoredProcedure [dbo].[Registrar_Factura]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_Factura] @CostoEnvio money,@Estado varchar(10)
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
GO
/****** Object:  StoredProcedure [dbo].[Registrar_FacturaTemp]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_FacturaTemp] @Fecha datetime,@CostoEnvio money,@Estado varchar(10)
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
GO
/****** Object:  StoredProcedure [dbo].[Registrar_PagoCredito]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Registrar_PagoCredito] @IdCompra int,@Fecha date,@Monto money
AS

IF EXISTS(SELECT * FROM Compra WHERE IdCompra = @IdCompra and Tipo = 'Contado')
	BEGIN
	SELECT 'Compra pagada' as Mensaje
	END
ELSE IF EXISTS (SELECT * FROM Compra WHERE IdCompra = @IdCompra and Tipo = 'Pagado')
	BEGIN
	SELECT 'Compra pagada' as Mensaje
	END
else
	BEGIN
	INSERT INTO CreditoPago VALUES
	(@IdCompra,@Fecha,@Monto)
	END
SELECT 'Pago realizado' as Mensaje
GO
/****** Object:  StoredProcedure [dbo].[Registrar_Venta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_Venta] @IdCliente int, @IdEmpleado int
AS
INSERT INTO Venta VALUES
(@IdCliente,@IdEmpleado)
GO
/****** Object:  StoredProcedure [dbo].[Repaldar_BD]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Repaldar_BD]
AS
BACKUP DATABASE Ferreteria
TO DISK = 'C:\Respaldos\Ferreteria.bak'
GO
/****** Object:  StoredProcedure [dbo].[Reporte_Compra_entre_Fechas]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Reporte_Compra_entre_Fechas]
@desde date,@hasta date
as

Select p.NombreCompañia,
C.NoFactura,
c.Fecha,
c.Tipo,
c.Subtotal,
c.Descuento,
C.Iva,
C.Total, 
SUM(DC.Cantidad) as Items,
c.Estado AS [Estado_de_compra]  
from Compra c
inner join Proveedor p
on p.IdProveedor=c.IdProveedor
inner join DetalleCompra  dc
on dc.IdCompra = c.IdCompra
where
convert(date, c.Fecha) BETWEEN @desde AND @hasta
GROUP BY  p.NombreCompañia,C.NoFactura,c.Tipo,C.Total,c.Subtotal,C.Iva,c.Estado,c.Descuento,c.Fecha
GO
/****** Object:  StoredProcedure [dbo].[Reporte_Cuentas_por_pagar_proveedor]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Reporte_Cuentas_por_pagar_proveedor]
as
select P.NombreCompañia aS [Proveedor], p.RUC, sum(c.Total) as Deuda,count(C.NoFactura)as [FacturasPendientes] from Compra c
inner join Proveedor p
on p.IdProveedor=c.IdProveedor
where c.Tipo = 'Crédito' and c.Estado = 'Pendiente'
Group by p.NombreCompañia,p.RUC
GO
/****** Object:  StoredProcedure [dbo].[Reporte_Devolucion_Compra_Entre_Fechas]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Reporte_Devolucion_Compra_Entre_Fechas]
@FechaInicio date,
@FechaFinal date
as
Select pv.NombreCompañia,
pv.RUC,
dvc.Fecha,
c.NoFactura,
p.Nombre as Producto,
p.Marca,
p.Modelo,
p.Medida,
dvc.Cantidad,
dvc.Fecha,
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
Where CONVERT(date,dvc.Fecha) BETWEEN @FechaInicio and @FechaFinal
GO
/****** Object:  StoredProcedure [dbo].[Reporte_Devolucion_Compra_Entre_Fechas_Por_Estado]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Reporte_Devolucion_Compra_Entre_Fechas_Por_Estado]
@FechaInicio date,
@FechaFinal date,
@Estado varchar(14)
as

if(@Estado ='Aceptado' or @Estado='No Aceptado' OR @Estado = 'Recibido')
begin
Select pv.NombreCompañia,
pv.RUC,
dvc.Fecha,
c.NoFactura,
p.Nombre as Producto,
p.Marca,
p.Modelo,
p.Medida,
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
Where dvc.Estado=@Estado and
CONVERT(date,dvc.Fecha) BETWEEN @FechaInicio and @FechaFinal
end
else
begin
Select pv.NombreCompañia,
pv.RUC,
dvc.Fecha,
c.NoFactura,
p.Nombre as Producto,
p.Marca,
p.Modelo,
p.Medida,
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
Where 
CONVERT(date,dvc.Fecha) BETWEEN @FechaInicio and @FechaFinal
end
GO
/****** Object:  StoredProcedure [dbo].[Reporte_Devolucion_Venta_Entre_Fechas]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Reporte_Devolucion_Venta_Entre_Fechas]
@FechaInicio date,
@FechaFinal date
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
where 
CONVERT(date,dv.Fecha) BETWEEN @FechaInicio and @FechaFinal

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
where 
CONVERT(date,dv.Fecha) BETWEEN @FechaInicio and @FechaFinal
)
Select * from @temp
GO
/****** Object:  StoredProcedure [dbo].[Reporte_Devolucion_Venta_Entre_Fechas_Por_Estado]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Reporte_Devolucion_Venta_Entre_Fechas_Por_Estado]
@FechaInicio date,
@FechaFinal date,
@Estado varchar(12)
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

if(@Estado = 'No Aceptado' or @Estado ='Aceptado' or @Estado = 'Entregado')
Begin
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
where dv.Estado =@Estado and
CONVERT(date,dv.Fecha) BETWEEN @FechaInicio and @FechaFinal

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
where dv.Estado =@Estado and
CONVERT(date,dv.Fecha) BETWEEN @FechaInicio and @FechaFinal
)
Select * from @temp
end 
Else
begin
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
where 
CONVERT(date,dv.Fecha) BETWEEN @FechaInicio and @FechaFinal

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
where 
CONVERT(date,dv.Fecha) BETWEEN @FechaInicio and @FechaFinal
)
Select * from @temp
end
GO
/****** Object:  StoredProcedure [dbo].[Reporte_Ingresos_Por_Cliente_Entre_Fechas]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Reporte_Ingresos_Por_Cliente_Entre_Fechas]
@FechaInicio DATE,
@FechaFinal DATE
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
WHERE CONVERT(date,f.Fecha) BETWEEN @FechaInicio and @FechaFinal
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
WHERE CONVERT(date,f.Fecha) BETWEEN @FechaInicio and @FechaFinal
Group by cj.NombreCompañia
)

SELECT * FROM @temp ORDER BY Total DESC
GO
/****** Object:  StoredProcedure [dbo].[Reporte_Productos_Mayor_Recaudacion]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Reporte_Productos_Mayor_Recaudacion]
@desde date,@hasta date
as
select 
p.Nombre as Producto,
p.Marca,
p.Modelo,
p.Medida,
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
group by  p.Nombre,dv.Cantidad,dv.Precio,p.Marca,p.Modelo, p.Medida, p.Peso
order by Recaudación desc
GO
/****** Object:  StoredProcedure [dbo].[ReporteFrecuenciaClientes]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReporteFrecuenciaClientes]
@FechaInicio Date,
@FechaFinal Date
AS
BEGIN
Select
	dbo.GET_NAME(c.IdCliente) as Nombre_cliente,
	DBO.GET_PRODUCT_INFO(( SELECT top 1 p.IdProducto FROM Producto p INNER JOIN DetalleVenta d ON p.IdProducto = d.IdProducto
	INNER JOIN FACTURA f ON d.IdVenta = F.IdVenta
	inner jOIN Venta V ON v.IdVenta = d.IdVenta
	WHERE v.IdCliente = c.IdCliente AND f.Fecha BETWEEN @FechaInicio AND @FechaFinal GROUP BY p.IdProducto ORDER BY (SUM(d.Cantidad)) desc )) AS Producto_mas_comprado,
	DBO.GET_PRODUCT_Q(( SELECT top 1 p.IdProducto FROM Producto p 
	INNER JOIN DetalleVenta d ON p.IdProducto = d.IdProducto
	INNER JOIN FACTURA f ON d.IdVenta = F.IdVenta 
	inner jOIN Venta V ON v.IdVenta = d.IdVenta
	WHERE v.IdCliente = c.IdCliente AND f.Fecha BETWEEN @FechaInicio AND @FechaFinal GROUP BY p.IdProducto ORDER BY (SUM(d.Cantidad)) desc ), @FechaInicio, @FechaFinal, C.IdCliente) as Cantidad_comprada,
	COUNT(v.IdVenta) as Total_de_ventas_realizadas
from Cliente c
INNER JOIN Venta v
ON v.IdCliente = c.IdCliente
INNER jOIN Factura F
ON F.IdVenta=v.IdVenta
WHERE f.Fecha BETWEEN @FechaInicio AND @FechaFinal
GROUP BY c.IdCliente
ORDER BY  Total_de_ventas_realizadas desc
END
GO
/****** Object:  StoredProcedure [dbo].[Top10_Productos_Mas_Vendido]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Top10_Productos_Mas_Vendido]
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
GO
/****** Object:  StoredProcedure [dbo].[Validar_Acceso]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Validar_Acceso]
@usuario varchar(50),
@contraseña varchar(50)

as
if exists (Select username from Usuario 
			where cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as varchar(100)) = @contraseña
			and username = @usuario and Estado = 'Activo')
BEGIN
Select 'Acceso Exitoso' as Resultado,e.PrimerNombre+' '+ e.PrimerApellido as Usuario,u.Username, r.Rol,e.Cargo,u.IdUsuario from Usuario u
inner join Empleado e
on e.IdEmpleado = u.IdEmpleado
Inner join Rol r
on r.IdRol = u.IdRol
where cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as  varchar(100)) = @contraseña
and username = @usuario and u.Estado = 'Activo'
END
else if exists (Select username from Usuario 
			where cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as varchar(100)) = @contraseña
			and username = @usuario and Estado = 'Inactivo')
BEGIN
SELECT 'Acceso revocado'
END
else
Select 'Acceso Denegado' as Resultado
GO
/****** Object:  StoredProcedure [dbo].[Validar_Creacion_Usuario]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Validar_Creacion_Usuario]
@usuario varchar(50)

as
if exists (Select Username from Usuario where Username = @usuario)
Select 'Acceso Denegado' as Resultado
else
Select 'Acceso Exitoso' as Resultado
GO
/****** Object:  StoredProcedure [dbo].[Ver_Factura]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ver_Factura] @IdFactura int
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_Compras]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_Compras]
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
ORDER BY c.IdCompra DESC
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_ComprasPeriodo]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_ComprasPeriodo] @FechaInicial date, @FechaFinal date
AS
SELECT
c.IdCompra as IdCompra,
p.NombreCompañia as [Razónsocial],
c.NoFactura as [NoFactura],
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_DetCompras]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Visualizar_DetCompras] @IdCompra int
AS
SELECT
p.IdProducto as IdProducto,
p.Marca + ' ' + p.Nombre + ' ' + p.Modelo as Nombre,
'C$' + CONVERT(VARCHAR,CAST(dc.Precio + dc.Iva AS MONEY),1) as Precio,
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_DetComprasPeriodo]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_DetComprasPeriodo] @FechaInicial date, @FechaFinal date
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_DetVenta]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_DetVenta] @IdVenta int
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_DetVentasPeriodo]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_DetVentasPeriodo] @FechaInicial date, @FechaFinal date
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_DevCompras]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_DevCompras]
AS
SELECT 
devc.IdDevolucion as IdDevolucion,
devc.IdDetalleCompra as IdDetalleCompra,
c.NoFactura as [Factura],
CONVERT(VARCHAR, devc.Fecha, 6) as [Fecha devolución],
p.Nombre as Producto,
p.Marca as Marca,
p.Modelo as Modelo,
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_DevComprasPeriodo]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_DevComprasPeriodo] @FechaInicial date, @FechaFinal date
AS
SELECT 
devc.IdDetalleCompra as IdDetalleCompra,
c.NoFactura as [Factura],
devc.Fecha as [Fechadevolucion],
p.Nombre as Producto,
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_DevVentas]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_DevVentas]
AS
SELECT
dvv.IdDevolucion as IdDevolucion,
f.NoFactura as [Factura],
CONVERT(VARCHAR, dvV.Fecha, 6) as Fecha,
p.Nombre as Producto,
p.Marca as Marca,
p.Modelo as Modelo,
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
ORDER BY dvv.IdDevolucion DESC
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_DevVentasPeriodo]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_DevVentasPeriodo] @FechaInicial date, @FechaFinal date
AS
SELECT
f.NoFactura as [Factura],
dvV.Fecha as Fecha,
p.Nombre as Producto,
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_Envíos]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_Envíos]
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_PagosCredito]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_PagosCredito]
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_Usuarios]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[Visualizar_Usuarios]
    as 
	Select
	IdUsuario as [Id usuario],
	e.PrimerNombre + ' ' + e.PrimerApellido as Nombre,
    u.Username as [Nombre de usuario],
	r.Rol as Rol,
	u.Estado as Estado
	from Usuario u
	inner join Empleado e
	on u.IdEmpleado = e.IdEmpleado
	inner join Rol r
	on r.IdRol = u.IdRol
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_Ventas]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_Ventas] 
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
GO
/****** Object:  StoredProcedure [dbo].[Visualizar_VentasPeriodo]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Visualizar_VentasPeriodo] @FechaInicial date, @FechaFinal date
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
GO
/****** Object:  Trigger [dbo].[CompraEstado_Update]    Script Date: 12/21/2022 9:44:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[CompraEstado_Update]
ON [dbo].[CreditoPago]
AFTER INSERT
as
DECLARE @IdCompra int
SET @IdCompra = (Select IdCompra from inserted)
IF ( (SELECT SUM(Pago) FROM CreditoPago WHERE IdCompra = @IdCompra) = (SELECT Total FROM Compra WHERE IdCompra = @IdCompra and Tipo = 'Crédito'))
	BEGIN
	UPDATE Compra SET
	Estado = 'Pagado' WHERE IdCompra = @IdCompra
	END
GO
ALTER TABLE [dbo].[CreditoPago] ENABLE TRIGGER [CompraEstado_Update]
GO
/****** Object:  Trigger [dbo].[DetCompra_Insert]    Script Date: 12/21/2022 9:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DetCompra_Insert] ON [dbo].[DetalleCompra]
AFTER INSERT
AS
DECLARE @IdProducto int
DECLARE @Cantidad int
DECLARE @Precio money
DECLARE @Descuento money
DECLARE @Iva money

SET @IdProducto = (SELECT IdProducto FROM inserted)
SET @Cantidad = (SELECT Cantidad FROM inserted)
SET @Precio = (SELECT Precio FROM inserted)
SET @Descuento = (SELECT DescuentoUnidad FROM inserted)
SET @Iva = (SELECT Iva FROM inserted)

UPDATE Producto SET UnidadesDisponibles = UnidadesDisponibles + @Cantidad
WHERE IdProducto = @IdProducto

UPDATE Compra SET Subtotal = Subtotal + @Precio * @Cantidad,
				Descuento = Descuento + @Precio * @Descuento * @Cantidad,
				Iva = Iva + @Iva * @Cantidad WHERE IdCompra = dbo.UltimaCompra()

UPDATE COMPRA SET Total =  Subtotal - Descuento + Iva WHERE IdCompra = dbo.UltimaCompra()

GO
ALTER TABLE [dbo].[DetalleCompra] ENABLE TRIGGER [DetCompra_Insert]
GO
/****** Object:  Trigger [dbo].[DetVenta_Insert]    Script Date: 12/21/2022 9:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DetVenta_Insert] ON [dbo].[DetalleVenta]
AFTER INSERT
AS
DECLARE @IdProducto int
DECLARE @Cantidad int

SET @IdProducto = (SELECT IdProducto FROM inserted)
SET @Cantidad = (SELECT Cantidad FROM inserted)

UPDATE Producto SET UnidadesDisponibles = UnidadesDisponibles - @Cantidad
WHERE IdProducto = @IdProducto
GO
ALTER TABLE [dbo].[DetalleVenta] ENABLE TRIGGER [DetVenta_Insert]
GO
/****** Object:  Trigger [dbo].[DevCompra_Insert]    Script Date: 12/21/2022 9:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DevCompra_Insert]
On [dbo].[DevolucionCompra]
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
GO
ALTER TABLE [dbo].[DevolucionCompra] ENABLE TRIGGER [DevCompra_Insert]
GO
/****** Object:  Trigger [dbo].[DevCompra_Update]    Script Date: 12/21/2022 9:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DevCompra_Update]
ON [dbo].[DevolucionCompra]
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
GO
ALTER TABLE [dbo].[DevolucionCompra] ENABLE TRIGGER [DevCompra_Update]
GO
/****** Object:  Trigger [dbo].[DevVenta_Insert]    Script Date: 12/21/2022 9:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DevVenta_Insert]
On [dbo].[DevolucionVenta]
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
GO
ALTER TABLE [dbo].[DevolucionVenta] ENABLE TRIGGER [DevVenta_Insert]
GO
/****** Object:  Trigger [dbo].[DevVenta_Update]    Script Date: 12/21/2022 9:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DevVenta_Update]
ON [dbo].[DevolucionVenta]
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
GO
ALTER TABLE [dbo].[DevolucionVenta] ENABLE TRIGGER [DevVenta_Update]
GO
/****** Object:  Trigger [dbo].[Factura_Update]    Script Date: 12/21/2022 9:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[Factura_Update]
ON [dbo].[Factura]
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
GO
ALTER TABLE [dbo].[Factura] ENABLE TRIGGER [Factura_Update]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Reporte_Productos_Mayor_Recaudacion]
@desde date,@hasta date
as
select 
p.Nombre as Producto,
p.Marca,
p.Modelo,
p.Medida,
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
group by  p.Nombre,p.Marca,p.Modelo, p.Medida, p.Peso
order by Recaudación desc
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[DetCompra_Insert] ON [dbo].[DetalleCompra]
AFTER INSERT
AS
DECLARE @IdProducto int
DECLARE @Cantidad int
DECLARE @IdCompra int
DECLARE @Precio money
DECLARE @Descuento money
DECLARE @Iva money

SET @IdCompra = (SELECT IdCompra FROM inserted)
SET @IdProducto = (SELECT IdProducto FROM inserted)
SET @Cantidad = (SELECT Cantidad FROM inserted)
SET @Precio = (SELECT Precio FROM inserted)
SET @Descuento = (SELECT DescuentoUnidad FROM inserted)
SET @Iva = (SELECT Iva FROM inserted)

UPDATE Producto SET UnidadesDisponibles = UnidadesDisponibles + @Cantidad
WHERE IdProducto = @IdProducto

UPDATE Compra SET Subtotal = Subtotal + @Precio * @Cantidad * 0.85,
				Descuento = Descuento + @Precio *0.85 * @Descuento * @Cantidad,
				Iva = Iva + @Iva * @Cantidad WHERE IdCompra = @IdCompra

UPDATE COMPRA SET Total =  Subtotal - Descuento + Iva WHERE IdCompra = @IdCompra
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Reporte_Cuentas_por_pagar_proveedor]
as
select 
P.NombreCompañia aS [Proveedor], 
p.RUC, 
c.Total - sum(CP.Pago)  as Deuda,
count(DISTINCT C.NoFactura) as [Facturas_Pendientes] 
from Compra c
inner join Proveedor p
on p.IdProveedor=c.IdProveedor
inner join CreditoPago cp
on cp.IdCompra = c.IdCompra
where c.Tipo = 'Crédito' and c.Estado = 'Pendiente'
Group by p.NombreCompañia,p.RUC,c.Total
SELECT * FROM Compra WHERE Estado = 'Pendiente' and Tipo = 'Crédito'

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[Calcular_IvaUnitario](@Precio money,@Descuento float)
	RETURNS money
	AS
	BEGIN
	DECLARE @Iva money
	IF (@Descuento = 0)
	BEGIN
	SET @Iva = @Precio * 0.15
	END
	ELSE
	BEGIN
	SET @Iva = (@Precio*0.85 - @Precio*@Descuento*0.85) * (0.15) 
	END
	RETURN @Iva
	END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Registrar_DetCompra] 
@IdProducto int,
@Cantidad int,
@Descuento money,
@Precio money
AS
INSERT INTO 
DetalleCompra VALUES
(@IdProducto,dbo.UltimaCompra(),@Precio,@Cantidad,@Descuento, dbo.Calcular_IvaUnitario(@Precio,@Descuento))

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Visualizar_DetCompras] @IdCompra int
AS
SELECT
p.IdProducto as IdProducto,
p.Marca + ' ' + p.Nombre + ' ' + p.Modelo as Nombre,
'C$' + CONVERT(VARCHAR,CAST(dc.Precio  AS MONEY),1) as Precio,
dc.Cantidad as Cantidad,
CAST (dc.DescuentoUnidad * 100 as varchar) + '%' [% Descuento],
'C$' + CONVERT(VARCHAR,CAST(dc.Precio * dc.Cantidad * 0.85 AS MONEY),1) as Subtotal,
'C$' + CONVERT(VARCHAR,CAST(dc.Precio * dc.DescuentoUnidad * dc.Cantidad  * 0.85 AS MONEY),1) as Descuento,
'C$' + CONVERT(VARCHAR,CAST(dc.Iva * dc.Cantidad AS MONEY),1) as Iva,
'C$' + CONVERT(VARCHAR,CAST(((dc.Precio *0.85- dc.Precio*dc.DescuentoUnidad*0.85) + dc.Iva) * dc.Cantidad AS MONEY),1) as Total
FROM
DetalleCompra dc
inner join Producto p
on dc.IdProducto = p.IdProducto
WHERE dc.IdCompra = @IdCompra

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Validar_Factura @IdProveedor int,@factura varchar(20)
AS
IF EXISTS(SELECT * FROM Compra WHERE NoFactura = @factura and IdProveedor = @IdProveedor)
BEGIN
Select 1
END
ELSE
BEGIN
SELECT 0
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Visualizar_DetVentaFactura] @IdVenta int
AS
SELECT
p.IdProducto as IdProducto,
p.Marca + ' ' + p.Nombre +  ' ' + p.Modelo as [Producto],
dv.Precio as Precio,
dv.Cantidad as Cantidad,
dv.DescuentoUnidad as [DescuentoUnit],
dv.Precio * dv.Cantidad as SubTotal,
dv.DescuentoUnidad * dv.Precio *  dv.Cantidad as [Descuento],
dv.Precio * dv.Cantidad - dv.Precio*dv.Cantidad*dv.DescuentoUnidad as Total
FROM DetalleVenta dv
inner join Producto p
on dv.IdProducto = p.IdProducto
WHERE dv.IdVenta = @IdVenta

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[Top10_Productos_Mas_Vendido]
@desde date,@hasta date
as
select  TOP 10 p.Nombre as Producto,p.Marca,p.Modelo,sum(dv.Cantidad) as Cantidad from DetalleVenta dv
inner join Producto p
on p.IdProducto= dv.IdProducto
inner join Factura f
on f.IdVenta=dv.IdVenta
where 
convert(date, f.Fecha) BETWEEN @desde AND @hasta
group by  p.Nombre ,p.Marca,p.Modelo
order by Cantidad desc

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Buscar_DevProductoCompra @IdCompra  int, @IdProducto int
AS
SELECT
*
FROM DetalleCompra
WHERE IdCompra = @IdCompra and IdProducto = @IdProducto