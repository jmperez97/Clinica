USE [clinica]
GO
/****** Object:  StoredProcedure [dbo].[USP_ListarCita]    Script Date: 3/28/2019 7:26:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jhon Mario Perez>
-- Create date: <2019/03/27>
-- Description:	<listar tipos>
-- =============================================
create PROCEDURE [dbo].[USP_ListarTipo]


AS
BEGIN
select IdTipo as Id,Descrip as Nombre from Tipo
end 