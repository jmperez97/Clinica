use clinica
go
-- =============================================
-- Author:		<Jhon Mario Perez>
-- Create date: <2019/03/27>
-- Description:	<cancelar cita>
-- =============================================
CREATE PROCEDURE USP_CancelarCita

	@id int 
AS
BEGIN
if(DATEDIFF(HOUR,(select fecha from Cita where ID = @id),getdate() )>24)
begin
update cita set estado = 0 where ID = @id
end
else
begin
select 'Las citas se deben cancelar con 24 horas de antelación' as mensaje
end
end 