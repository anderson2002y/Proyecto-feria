USE Ferreteria

    create procedure Visualizar_Usuarios
    as 
	Select
	IdUsuario as [Id usuario],
	e.PrimerNombre + ' ' + e.PrimerApellido as Nombre,
    u.Username as [Nombre de usuario],
	u.Rol as Rol,
	u.Estado as Estado
	from Usuario u
	inner join Empleado e
	on u.IdEmpleado = e.IdEmpleado

	create procedure Buscar_Usuarios
	@Buscar nvarchar(20)
    as 
	Select
	IdUsuario as [Id usuario],
	e.PrimerNombre + ' ' + e.PrimerApellido as Nombre,
    u.Username as [Nombre de usuario],
	u.Rol as Rol,
	u.Estado as Estado
	from Usuario u
	inner join Empleado e
	on u.IdEmpleado = e.IdEmpleado
	where u.Username COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or u.Rol COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or u.Estado COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or e.PrimerNombre COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 
	or e.PrimerApellido COLLATE SQL_Latin1_General_Cp1_CI_AI  like '%'+@Buscar+ '%' 

	----procedimiento de ingresar usuarios
	CREATE procedure [dbo].[Insertar_Usuario] 
	@IdEmpleado int,
	@Rol varchar (30),
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

	insert into Usuario(IdEmpleado, Username, Contraseña, Rol,Estado) 
	values (@IdEmpleado, @user, ENCRYPTBYPASSPHRASE(@Contraseña,@Contraseña), @Rol, 'Activo')

		----procedimiento de actualizar usuarios
CREATE procedure [dbo].[Actualizar_Usuario]
	@IdUsuario int,
	@rol varchar(30)
	as 
	update Usuario set Rol=@rol
	where IdUsuario = @IdUsuario

	---Cambiar estado de usuario 
	Create procedure Cambiar_Estado_Usuario
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


create PROCEDURE [dbo].[Validar_Creacion_Usuario]
@usuario varchar(50)

as
if exists (Select Username from Usuario where Username = @usuario)
Select 'Acceso Denegado' as Resultado
else
Select 'Acceso Exitoso' as Resultado


CREATE PROCEDURE [dbo].[Validar_Acceso]
@usuario varchar(50),
@contraseña varchar(50)

as
if exists (Select username from Usuario 
			where cast(DECRYPTBYPASSPHRASE(@contraseña,Contraseña) as varchar(100)) = @contraseña
			and username = @usuario and Estado = 'Activo')
BEGIN
Select 'Acceso Exitoso' as Resultado,e.PrimerNombre+' '+ e.PrimerApellido as Usuario,u.Username, Rol,e.Cargo,u.IdUsuario from Usuario u
inner join Empleado e
on e.IdEmpleado = u.IdEmpleado
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