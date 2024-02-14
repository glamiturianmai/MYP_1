USE [MassageSalonThreeKorochki]
GO
/****** Object:  StoredProcedure [dbo].[SetService]    Script Date: 08.02.2024 0:17:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SetService] 
	@Name nvarchar(255),
	@Cost INT,
	@Time INT
AS
BEGIN
	INSERT [dbo].[Services]
	values (@Name, @Cost, 0, @Time)
END

