USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[AddAppointment2]    Script Date: 11.02.2024 21:31:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[AddAppointment2] 
@ServicesId int,
@AppointmentId int,
@WorkerId int,
@Price int
as 
begin 
	insert dbo.[Service_Appointment]
	values (@ServicesId, @AppointmentId, @WorkerId, @Price)
end