USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[AddAppointment1]    Script Date: 11.02.2024 21:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[AddAppointment1] 
@ClientId int
as 
begin 
	insert dbo.[Appointment]
	values (@ClientId)
end