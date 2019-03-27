use clinica
go
-- =============================================
-- Author:		<Jhon Mario Perez>
-- Create date: <2019/03/27>
-- Description:	<Gestionar Paciente>
-- =============================================
CREATE PROCEDURE USP_GestionarPaciente

	@Nombre varchar(60),
	@cedula varchar(13),
	@telefono varchar(16),
	@oper varchar(1)
AS
BEGIN
if(@oper = 'G')--guardar
begin
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