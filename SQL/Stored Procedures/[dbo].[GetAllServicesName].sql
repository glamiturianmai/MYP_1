USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetAllServicesName]    Script Date: 11.02.2024 21:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetAllServicesName] 
as 
begin 
	select 
	S.[Id], S.[Name], T.[Id] AS TypeId, T.[Name] AS TypeName
	from dbo.[Services] as S
	join dbo.[Services_Type] as ST on S.[Id]=ST.[ServiceId]
	join dbo.[Type] as T on ST.[TypeId]=T.[Id]

end