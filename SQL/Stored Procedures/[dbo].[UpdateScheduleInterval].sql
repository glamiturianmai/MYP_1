USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[UpdateScheduleInterval]    Script Date: 11.02.2024 21:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateScheduleInterval]
AS
BEGIN
	DELETE FROM [dbo].[ScheduleInterval]
END