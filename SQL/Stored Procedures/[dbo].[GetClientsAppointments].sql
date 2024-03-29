USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetClientsAppointments]    Script Date: 11.02.2024 22:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetClientsAppointments] 
	@Id INT
AS
BEGIN
	SELECT 
	C.[Id], SI.[Id] AS IntervalId, SI.[Date],
	W.[Name] AS WorkerName,
	S.[Name] ServiceName, SA.[price] AS Price 
	FROM dbo.[Clients] AS C
	join dbo.[Appointment] AS A on C.Id=A.ClientId
	join dbo.[Service_Appointment] AS SA on A.Id=SA.AppointmentId
	join dbo.[ScheduleInterval] AS SI on A.Id=SI.AppointmentId
	join dbo.[Workers] AS W on SI.WorkerId=W.Id
	join dbo.[Services] AS S on SA.ServicesId = S.Id
	WHERE C.[Id]=@Id AND A.[IsDeleted]=0
	GROUP BY C.[Id], SI.[Id], SI.[Date], W.[Name], S.[Name], SA.[price]
END