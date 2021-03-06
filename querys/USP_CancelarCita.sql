USE [clinica]
GO
/****** Object:  StoredProcedure [dbo].[USP_CancelarCita]    Script Date: 3/29/2019 9:58:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jhon Mario Perez>
-- Create date: <2019/03/27>
-- Description:	<cancelar cita>
-- =============================================
ALTER PROCEDURE [dbo].[USP_CancelarCita]

	@idCita int 
AS
BEGIN
if(ABS(DATEDIFF(HOUR,(select fecha from Cita where ID = @idCita),getdate() ))>24)
begin
update cita set estado = 0 where ID = @idCita
select 'Cita cancelada con éxito' as mensaje
end
else
begin
select 'Las citas se deben cancelar con 24 horas de antelación' as mensaje
end
end


