USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[DeleteService]    Script Date: 08.02.2024 0:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[DeleteService] 
	@Id INT
AS
BEGIN
	UPDATE [dbo].[Services]
	SET [IsDeleted]=1
	WHERE [Id]=@Id
END
