use clinica
go
-- =============================================
-- Author:		<Jhon Mario Perez>
-- Create date: <2019/03/27>
-- Description:	<listar paciente>
-- =============================================
CREATE PROCEDURE USP_ListarPaciente


AS
BEGIN
select id, Nombre, cedula,telefono, case when estado = 0 then 'Inactivo' else 'Activo'  end as estado
 from Paciente
end 