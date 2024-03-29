USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkersIntervalsForDate]    Script Date: 14.02.2024 13:50:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetWorkersIntervalsForDate]
	@Id int,
	@Date datetime
AS
BEGIN
	SELECT
	SI.[Id], SI.[Date]
	FROM
	[dbo].[Workers] as W
	left join [dbo].[ScheduleInterval] as SI on W.[Id]=SI.[WorkerId]
	left join [dbo].[Appointment] as A on SI.[AppointmentId]=A.[Id]
	WHERE W.[Id]=@Id 
	AND (SI.[AppointmentId] IS NULL OR A.[IsDeleted]=1)
	AND SI.[IsBusy]=0
	AND (SI.[Date] >= @Date AND SI.[Date] <= DATEADD(day, 1, @Date))
END