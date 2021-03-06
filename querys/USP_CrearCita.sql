USE [clinica]
GO
/****** Object:  StoredProcedure [dbo].[USP_CrearCita]    Script Date: 3/28/2019 8:02:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jhon Mario Perez>
-- Create date: <2019/03/27>
-- Description:	<crear cita>
-- =============================================
create PROCEDURE [dbo].[USP_CrearCita]

	@Paciente int,
	@tipo int,
	@fecha varchar(200)
AS
BEGIN
if((select count(*) from cita where IdPaciente =@Paciente   and CONVERT(date, getdate()) = CONVERT(date, fecha) and estado = 1)=0 )
begin
	insert into Cita values(@Paciente,@tipo,@fecha,1)
	select 'Cita Agendada con éxito' as mensaje
end
else
begin
select 'No se pueden crear varias citas para el mismo día ' as mensaje
end

END
