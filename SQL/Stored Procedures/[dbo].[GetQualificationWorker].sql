USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetQualificationWorker]    Script Date: 11.02.2024 21:38:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetQualificationWorker] 
@WorkerId int
as 
begin 
	select 
	W.[Id], W.[Name], Q.[Id] AS QualificationId, Q.[Name] AS QualificationName, Q.[ProcentToPrice]
	from dbo.[Workers] as W
	join dbo.[Qualification] as Q on W.[QualificationId]=Q.[Id]
	where W.[Id]=@WorkerId
end