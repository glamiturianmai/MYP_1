USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkersIntervalsForDate]    Script Date: 11.02.2024 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetWorkersIntervalsForDate]
	@Id int
AS
BEGIN
	SELECT
	SI.[Id], SI.[Date]
	FROM
	[dbo].[Workers] as W
	join [dbo].[ScheduleInterval] as SI on W.[Id]=SI.[WorkerId]
	WHERE W.[Id]=@Id AND SI.[AppointmentId] IS NULL AND SI.[IsBusy]=0
END