USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetAllServicesName]    Script Date: 21.02.2024 23:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetAllServicesName] 
as 
begin 
	select 
	S.[Id], S.[Name]
	from dbo.[Services] as S
	WHERE S.[IsDeleted]=0
end