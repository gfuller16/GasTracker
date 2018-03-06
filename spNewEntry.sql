USE [Sample1]
GO
/****** Object:  StoredProcedure [dbo].[spNewEntry]    Script Date: 3/6/2018 8:44:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spNewEntry] --360.4,14.296,2.16
  @Miles DECIMAL(5,2),
  @Gallons DECIMAL(5,3),
  @Price DECIMAL(3,2),
  @Date varchar(10)
  AS
  BEGIN
	
	DECLARE @cnt INT = (SELECT (MAX(gID) + 1) FROM [Sample1].[dbo].[tblGasTracker])
	DECLARE @StartDate DATETIME = (SELECT gDate FROM [Sample1].[dbo].[tblGasTracker] WHERE (gID = @cnt - 1))

	INSERT INTO [Sample1].[dbo].[tblGasTracker](gID,gMiles,gGallons,gMPG,gPricePaid,gDate,gDaysBetween)
	VALUES(@cnt,@Miles,@Gallons,(@Miles / @Gallons),@Price,CONVERT(DATE,@Date),DATEDIFF(DAY,@StartDate,CONVERT(DATE,@Date)))

  END
