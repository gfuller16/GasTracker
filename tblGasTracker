USE [Sample1]
GO

/****** Object:  Table [dbo].[tblGasTracker]    Script Date: 4/19/2017 2:08:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblGasTracker](
	[gID] [int] NOT NULL,
	[gMiles] [decimal](6, 3) NOT NULL,
	[gGallons] [decimal](6, 3) NOT NULL,
	[gMPG] [decimal](6, 3) NOT NULL,
	[gPricePaid] [decimal](6, 3) NULL,
	[gDate] [datetime] NULL,
	[gDaysBetween] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[gID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblGasTracker] ADD  DEFAULT ((0)) FOR [gMiles]
GO

ALTER TABLE [dbo].[tblGasTracker] ADD  DEFAULT ((0)) FOR [gGallons]
GO

ALTER TABLE [dbo].[tblGasTracker] ADD  DEFAULT ((0)) FOR [gMPG]
GO

ALTER TABLE [dbo].[tblGasTracker] ADD  DEFAULT ((0)) FOR [gPricePaid]
GO

ALTER TABLE [dbo].[tblGasTracker] ADD  DEFAULT (getdate()) FOR [gDate]
GO

ALTER TABLE [dbo].[tblGasTracker] ADD  DEFAULT ((0)) FOR [gDaysBetween]
GO
