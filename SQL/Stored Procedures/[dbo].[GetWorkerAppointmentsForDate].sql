USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetWorkerAppointmentsForDate]    Script Date: 11.02.2024 22:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetWorkerAppointmentsForDate]
	@Id int,
	@Date DATETIME
AS
BEGIN
	SELECT 
	W.[Id], W.[Name],
	SI.[Date], C.[Username], C.[IpInf],
	S.[Name] as ServiceName
	FROM
	[dbo].[Workers] AS W
	join [dbo].[Service_Appointment] AS SA ON W.Id=SA.WorkerId
	join [dbo].[ScheduleInterval] AS SI ON W.Id=SI.WorkerId 
	join [dbo].[Appointment] AS A ON SA.AppointmentId=A.Id
	join [dbo].[Clients] AS C ON A.ClientId=C.Id
	join [dbo].[Services] AS S ON SA.ServicesId=S.Id
	WHERE SI.[AppointmentId] IS NOT NULL 
	AND (SI.[Date] >= @Date AND SI.[Date] <= DATEADD(day, 1, @Date))
	AND W.[Id]=@Id
	AND A.[IsDeleted]=0
	GROUP BY W.[Id], W.[Name], SI.[Date], C.[Username], C.[IpInf], S.[Name]
END