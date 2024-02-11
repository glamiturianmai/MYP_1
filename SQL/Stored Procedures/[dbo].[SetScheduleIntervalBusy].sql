USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[SetScheduleIntervalBusy]    Script Date: 11.02.2024 20:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SetScheduleIntervalBusy]
	@Date datetime
AS
BEGIN
	UPDATE [dbo].[ScheduleInterval]
	SET [IsBusy]=1
	WHERE [Date]=@Date
END