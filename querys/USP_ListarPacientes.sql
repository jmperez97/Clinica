USE [clinica]
GO
/****** Object:  StoredProcedure [dbo].[USP_ListarTipo]    Script Date: 3/29/2019 8:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[USP_ListarPacientes]


AS
BEGIN
select Id as Id,Nombre as Nombre from Paciente
end 