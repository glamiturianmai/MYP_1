USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkersByServiceId]    Script Date: 11.02.2024 21:22:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetWorkersByServiceId]
	@Id int
AS
BEGIN
	SELECT 
	W.[Id], W.[Name], Q.[Name] AS QualificationName
	FROM
	[dbo].[Workers] AS W
	join [dbo].[Worker_Service] AS WS ON W.[Id]=WS.[WorkerID]
	join [dbo].[Qualification] AS Q ON W.[QualificationId]=Q.[Id]
	WHERE W.IsDeleted=0 AND WS.[ServicesId]=@Id
END