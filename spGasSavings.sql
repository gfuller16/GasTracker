USE [Sample1]
GO
/****** Object:  StoredProcedure [dbo].[spGasSavings]    Script Date: 3/6/2018 8:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGasSavings] --50.1,19.1
@DistanceFromWork DECIMAL(5,2),
@DistanceFromChurch DECIMAL(5,2)
AS
BEGIN
	
	DECLARE @TotalDrive DECIMAL(7,2) = (@DistanceFromWork * 2)
	DECLARE @AvgMPG DECIMAL(5,2) = (SELECT AVG(gMPG) FROM tblGasTracker)
	DECLARE @AvgPrice DECIMAL(4,2) = (SELECT AVG(gPricePaid) FROM tblGasTracker)
	DECLARE @TankSize DECIMAL(4,2) = (SELECT AVG(gGallons) FROM tblGasTracker)
	DECLARE @DaysinMonth DECIMAL(4,2) = 30.42

	DECLARE @MilesPerMonth DECIMAL(7,2) = (@TotalDrive * @DaysinMonth) + ((@DistanceFromChurch * 2) * 4)
	DECLARE @MilesPerTank DECIMAL(7,2) = @AvgMPG * @TankSize
	DECLARE @FillupsPerMonth DECIMAL(4,2) = @MilesPerMonth / @MilesPerTank
	DECLARE @PricePerMonth DECIMAL(6,2) = (@AvgPrice * @TankSize) * @FillupsPerMonth

	DECLARE @String VARCHAR(275) =
	'Drive Distance:    ' + CONVERT(VARCHAR,@TotalDrive) + ' mi
'
	+ 'Avg MPG:           ' + CONVERT(VARCHAR,@AvgMPG) + ' mpg
'
	+ 'Avg Price:         $' + CONVERT(VARCHAR,@AvgPrice)
	
	+ '
	   Tank Size:         ' + CONVERT(VARCHAR,@TankSize) + ' gal
'
	+ 'Days in Month:     ' + CONVERT(VARCHAR,@DaysinMonth) + ' days
'
	+ 'Miles Per Tank:    ' + CONVERT(VARCHAR,@MilesPerTank) + ' mi
'
	+ 'Miles Per Month:   ' + CONVERT(VARCHAR,@MilesPerMonth) + ' mi
'
	+ 'Fillups Per Month: ' + CONVERT(VARCHAR,@FillupsPerMonth) + ' fillups

'
	+ 'Price Per Month:   $' + CONVERT(VARCHAR,@PricePerMonth) + '
'

	SELECT @String AS [Output1]

END
