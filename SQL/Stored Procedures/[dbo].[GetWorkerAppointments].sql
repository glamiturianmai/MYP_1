USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkerAppointments]    Script Date: 11.02.2024 22:31:36 ******/
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
	FROM [dbo].[Workers] AS W
	join [dbo].[Service_Appointment] AS SA ON W.Id=SA.WorkerId
	join [dbo].[ScheduleInterval] AS SI ON W.Id=SI.WorkerId 
	join [dbo].[Appointment] AS A ON SA.AppointmentId=A.Id
	join [dbo].[Clients] AS C ON A.ClientId=C.Id
	join [dbo].[Services] AS S ON SA.ServicesId=S.Id
	WHERE W.[Id]=@Id AND SI.[AppointmentId] IS NOT NULL AND A.[IsDeleted]=0
	GROUP BY W.[Id], SI.[Id], SI.[Date], C.[Username], S.[Name]
END