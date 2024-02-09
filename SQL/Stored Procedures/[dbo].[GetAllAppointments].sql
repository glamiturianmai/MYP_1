USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetAllAppointments]    Script Date: 09.02.2024 22:15:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllAppointments]
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
	GROUP BY W.[Id], W.[Name], SI.[Date], C.[Username], C.[IpInf], S.[Name]
END