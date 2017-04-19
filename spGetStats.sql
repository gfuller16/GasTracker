USE [Sample1]
GO
/****** Object:  StoredProcedure [dbo].[spGetStats]    Script Date: 4/19/2017 2:08:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[spGetStats]
  @type1 INT, --Total Type
  @type2 INT --Individual Type
  AS
  BEGIN

  /**********************************
	@type1 = 0 AND @type2 = 0  :  TOTAL AVERAGES
	@type1 = 1 AND @type2 = 0  :  TOTAL MAX'S	
	@type1 = 2 AND @type2 = 0  :  TOTAL MIN'S

	@type1 = 0 AND @type2 = 1  :  TOP 1 MaxMiles
	@type1 = 1 AND @type2 = 1  :  TOP 1 MaxGallons
	@type1 = 2 AND @type2 = 1  :  TOP 1 MaxMPG
	@type1 = 3 AND @type2 = 1  :  TOP 1 MaxPrice

	@type1 = 0 AND @type2 = 2  :  TOP 1 MinMiles
	@type1 = 1 AND @type2 = 2  :  TOP 1 MinGallons
	@type1 = 2 AND @type2 = 2  :  TOP 1 MinMPG
	@type1 = 3 AND @type2 = 2  :  TOP 1 MinPrice
  ***********************************/
	
	IF(@type1 = 0) AND (@type2 = 0) --AVERAGES
		BEGIN
			
			SELECT CONVERT(DECIMAL(4,1),AVG(gMiles)) as AvgMiles,
				   CONVERT(DECIMAL(5,3),AVG(gGallons)) as AvgGallons,
				   CONVERT(DECIMAL(5,3),AVG(gMPG)) as AvgMPG,
				   CONVERT(DECIMAL(3,2),AVG(gPricePaid)) as AvgPrice
			FROM dbo.tblGasTracker
		END

	IF(@type1 = 1) AND (@type2 = 0) --MAX'S
		BEGIN
			
			SELECT CONVERT(DECIMAL(4,1),MAX(gMiles)) as MaxMiles,
				   CONVERT(DECIMAL(5,3),MAX(gGallons)) as MaxGallons,
				   CONVERT(DECIMAL(5,3),MAX(gMPG)) as MaxMPG,
				   CONVERT(DECIMAL(3,2),MAX(gPricePaid)) as MaxPrice
			FROM dbo.tblGasTracker
		END

	IF(@type1 = 2) AND (@type2 = 0) --MIN'S
		BEGIN
			
			SELECT CONVERT(DECIMAL(4,1),MIN(gMiles)) as MinMiles,
				   CONVERT(DECIMAL(5,3),MIN(gGallons)) as MinGallons,
				   CONVERT(DECIMAL(5,3),MIN(gMPG)) as MinMPG,
				   CONVERT(DECIMAL(3,2),MIN(gPricePaid)) as MinPrice
			FROM dbo.tblGasTracker
		END

	IF(@type1 = 0) AND (@type2 = 1)
		BEGIN
			
			SELECT TOP 1 CONVERT(DECIMAL(4,1),MAX(gMiles)) AS MaxMiles
					,[gGallons]
					,[gMPG]
					,[gPricePaid]
					,[gDate]
			FROM [Sample1].[dbo].[tblGasTracker]
			GROUP BY [gGallons]
					,[gMPG]
					,[gPricePaid]
					,[gDate]
			ORDER BY MAX(gMiles) DESC

		END

	IF(@type1 = 1) AND (@type2 = 1)
		BEGIN
			
			SELECT TOP 1 [gMiles] 
					 ,CONVERT(DECIMAL(5,3),MAX(gGallons)) AS MaxGallons
					 ,[gMPG]
					 ,[gPricePaid]
					 ,[gDate]
			 FROM [Sample1].[dbo].[tblGasTracker]
			 GROUP BY [gMiles]
					 ,[gMPG]
					 ,[gPricePaid]
					 ,[gDate]
			 ORDER BY MAX([gGallons]) DESC

		END

	IF(@type1 = 2) AND (@type2 = 1)
		BEGIN
			
			SELECT TOP 1 [gMiles] 
					 ,[gGallons]
					 ,CONVERT(DECIMAL(5,3),MAX(gMPG)) AS MaxMPG
					 ,[gPricePaid]
					 ,[gDate]
			 FROM [Sample1].[dbo].[tblGasTracker]
			 GROUP BY [gMiles]
					 ,[gGallons]
					 ,[gPricePaid]
					 ,[gDate]
			 ORDER BY MAX([gMPG]) DESC

		END

	IF(@type1 = 3) AND (@type2 = 1)
		BEGIN
			
			SELECT TOP 1 [gMiles] 
					 ,[gGallons]
					 ,[gMPG]
					 ,CONVERT(DECIMAL(3,2),MAX(gPricePaid)) AS MaxPrice
					 ,[gDate]
			 FROM [Sample1].[dbo].[tblGasTracker]
			 GROUP BY [gMiles]
					 ,[gGallons]
					 ,[gMPG]
					 ,[gDate]
			 ORDER BY MAX([gPricePaid]) DESC

		END
		/*
				   CONVERT(DECIMAL(4,1),MIN(gMiles)) as MinMiles,
				   CONVERT(DECIMAL(5,3),MIN(gGallons)) as MinGallons,
				   CONVERT(DECIMAL(5,3),MIN(gMPG)) as MinMPG,
				   CONVERT(DECIMAL(3,2),MIN(gPricePaid)) as MinPrice
				   */
	IF(@type1 = 0) AND (@type2 = 2)
		BEGIN
			
			SELECT TOP 1 CONVERT(DECIMAL(4,1),MIN(gMiles)) AS MinMiles
					 ,[gGallons]
					 ,[gMPG]
					 ,[gPricePaid]
					 ,[gDate]
			 FROM [Sample1].[dbo].[tblGasTracker]
			 GROUP BY [gGallons]
					 ,[gMPG]
					 ,[gPricePaid]
					 ,[gDate]
			 ORDER BY MIN([gMiles])

		END

	IF(@type1 = 1) AND (@type2 = 2)
		BEGIN
			
			SELECT TOP 1 [gMiles]
					 ,CONVERT(DECIMAL(5,3),MIN(gGallons)) AS MinGallons
					 ,[gMPG]
					 ,[gPricePaid]
					 ,[gDate]
			 FROM [Sample1].[dbo].[tblGasTracker]
			 GROUP BY [gMiles]
					 ,[gMPG]
					 ,[gPricePaid]
					 ,[gDate]
			 ORDER BY MIN([gGallons])

		END

	IF(@type1 = 2) AND (@type2 = 2)
		BEGIN
			
			SELECT TOP 1 [gMiles]
					 ,[gGallons]
					 ,CONVERT(DECIMAL(5,3),MIN(gMPG)) AS MinMPG
					 ,[gPricePaid]
					 ,[gDate]
			 FROM [Sample1].[dbo].[tblGasTracker]
			 GROUP BY [gMiles]
					 ,[gGallons]
					 ,[gPricePaid]
					 ,[gDate]
			 ORDER BY MIN([gMPG])

		END

	IF(@type1 = 3) AND (@type2 = 2)
		BEGIN
			
			SELECT TOP 1 [gMiles]
					 ,[gGallons]
					 ,[gMPG]
					 ,CONVERT(DECIMAL(3,2),MIN(gPricePaid)) AS MinPricePaid
					 ,[gDate]
			 FROM [Sample1].[dbo].[tblGasTracker]
			 WHERE [gPricePaid] IS NOT NULL
			 GROUP BY [gMiles]
					 ,[gGallons]
					 ,[gMPG]
					 ,[gDate]
			 ORDER BY MIN([gPricePaid])

		END

  END
