USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblTrain]    Script Date: 03/31/2013 11:14:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTrain]') AND type in (N'U'))
DROP TABLE [dbo].[tblTrain]
GO

USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblTrain]    Script Date: 03/31/2013 11:14:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblTrain](
	[TrainID] [bigint] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NULL,
	[Type] [smallint] NULL,
	[IsImport] [bit] NULL,
	[DateImport] [datetime] NULL,
	[IsExport] [bit] NULL,
	[DateExport] [datetime] NULL,
	[NumberHandover] [nvarchar](50) NULL,
	[DateHandover] [datetime] NULL,
	[CodeStation] [nvarchar](50) NULL,
	[CodeStationFromTo] [nvarchar](50) NULL,
	[StatusVehicle] [nvarchar](200) NULL,
	[StatusGoods] [nvarchar](200) NULL,
	[NumberPartTrain] [nchar](10) NULL,
	[Jounery] [nvarchar](200) NULL,
	[PassengerVN] [int] NULL,
	[PassengerForegin] [int] NULL,
	[Staff] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblTrain] PRIMARY KEY CLUSTERED 
(
	[TrainID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


