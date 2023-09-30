# RegistroCitas
#Ejecutar este script
CREATE PROCEDURE Sp_CreateCliente
	-- Add the parameters for the stored procedure here
	@idespecialidad  int,
	@nombreCompleto  nvarchar(100),
	@id_Tipodocumento  int = 1,
	@nroDocumento nvarchar(9)
AS
BEGIN
	INSERT INTO [dbo].[Cliente]
           ([nombreCompleto]
           ,[nroDocumento]
           ,[id_especialidad]
           ,[created_at]
           ,[TipoDocumento])
     VALUES
           (@nombreCompleto
           ,@nroDocumento
           ,@idespecialidad
           ,GETDATE()
           ,@id_Tipodocumento);

		   end

GO


CREATE PROCEDURE Sp_EliminarCliente 
	@idCliente int
AS
BEGIN
	DELETE FROM [dbo].[Cliente]
      WHERE idCliente= @idCliente;

END
GO


CREATE PROCEDURE Sp_udpateCliente
	@idCliente int,
	@idespecialidad  int,
	@nombreCompleto  nvarchar(100),
	@id_Tipodocumento  int = 1,
	@nroDocumento nvarchar(9)
AS
BEGIN
	update  [dbo].[Cliente] set id_especialidad =  @idespecialidad, nombreCompleto= @nombreCompleto, nroDocumento = @nroDocumento , TipoDocumento=@id_Tipodocumento
      WHERE idCliente= @idCliente;

END
GO

CREATE PROCEDURE SP_consultarCliente
	@idCliente int
AS
BEGIN
	select*from [dbo].[Cliente] a where a.idCliente=@idCliente;

END
GO

create or alter PROCEDURE SP_existePersonaConDocumento 
	@nroDocumento nvarchar(9)
AS
BEGIN
	select count(*) as existeUusario from [dbo].[Cliente] a where a.nroDocumento=@nroDocumento;

END
GO


CREATE or alter PROCEDURE Sp_listarCliente  
	@nroDocumento nvarchar(9) = ''
AS
BEGIN
	IF(@nroDocumento = '')
		select*from [dbo].[Cliente];
	ELSE
		select*from [dbo].[Cliente] where nroDocumento= @nroDocumento;
	

END
GO

