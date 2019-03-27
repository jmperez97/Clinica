use clinica
go
-- =============================================
-- Author:		<Jhon Mario Perez>
-- Create date: <2019/03/27>
-- Description:	<listar cita>
-- =============================================
CREATE PROCEDURE USP_ListarCita


AS
BEGIN
select c.id, p.Nombre, t.Descrip as Tipo, fecha,  case when c.estado = 0 then 'Cancelada' else 'Activa'  end as estado
 from cita c
 join Paciente p  on p.Id = c.IdPaciente
 join tipo t on t.IdTipo = c.IdTipo
end 