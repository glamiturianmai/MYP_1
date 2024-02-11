USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAppointment]    Script Date: 11.02.2024 22:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteAppointment]
	@Id int
AS
BEGIN
	UPDATE [dbo].[Appointment]
	SET IsDeleted=1
	WHERE Id=@Id
END