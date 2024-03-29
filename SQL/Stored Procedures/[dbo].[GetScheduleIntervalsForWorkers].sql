USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[GetScheduleIntervalsForWorkers]    Script Date: 21.02.2024 23:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetScheduleIntervalsForWorkers]
	@Id int
as
begin
	select 
	SI.[Id], SI.[Date]
	from
	[dbo].[ScheduleInterval] as SI
	left join [dbo].[Appointment] as A on A.[Id]=SI.[AppointmentId]
	Where 
	SI.[WorkerId]=@Id
	and (SI.[AppointmentId] IS NULL or A.[IsDeleted]=1) 
	and SI.[IsBusy]=0
end