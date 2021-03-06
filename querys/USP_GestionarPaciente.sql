USE [clinica]
GO
/****** Object:  StoredProcedure [dbo].[USP_GestionarPaciente]    Script Date: 3/29/2019 8:25:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jhon Mario Perez>
-- Create date: <2019/03/27>
-- Description:	<Gestionar Paciente>
-- =============================================
ALTER PROCEDURE [dbo].[USP_GestionarPaciente]

	@Nombre varchar(60),
	@cedula varchar(13),
	@telefono varchar(16),
	@oper varchar(1)
AS
BEGIN
if(@oper = 'G')--guardar
begin
if((select count(*) from Paciente where cedula = @cedula)=0)
	insert into Paciente values(@Nombre,@cedula,@telefono,1)
end
else if (@oper = 'A')--actualizar
begin
	update Paciente set Nombre = @Nombre, telefono = @telefono where cedula =@cedula
end
else if(@oper = 'D')--Desactivar
begin
	update paciente set estado =0 where cedula = @cedula
end
end 