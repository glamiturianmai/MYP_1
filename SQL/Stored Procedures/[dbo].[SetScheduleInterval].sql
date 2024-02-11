USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[SetScheduleInterval]    Script Date: 11.02.2024 20:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SetScheduleInterval]
@Date datetime,
@WorkerId int
AS
BEGIN
	INSERT [dbo].[ScheduleInterval]
	values (@Date, @WorkerId, NULL, 0)
END