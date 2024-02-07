USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkerAppointments]    Script Date: 07.02.2024 23:59:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetWorkerAppointments] 
	@Id INT
AS
BEGIN
	SELECT 
	W.[Id], SI.[Id] AS IntervalId, SI.[Date],
	C.[Username] AS ClientName,
	S.[Name] ServiceName
	FROM dbo.[Clients] AS C
	join dbo.[Appointment] AS A on C.Id=A.ClientId
	join dbo.[Service_Appointment] AS SA on A.Id=SA.AppointmentId
	join dbo.[ScheduleInterval] AS SI on A.Id=SI.AppointmentId
	join dbo.[Workers] AS W on SI.WorkerId=W.Id
	join dbo.[Services] AS S on SA.ServicesId = S.Id
	WHERE W.[Id]=@Id
	GROUP BY W.[Id], SI.[Id], SI.[Date], C.[Username], S.[Name]
END

