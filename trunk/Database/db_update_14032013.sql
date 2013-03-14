USE [dbTrain]
GO

DROP TABLE [dbo].[tblHandoverResource]

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandover_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandover]'))
ALTER TABLE [dbo].[tblHandover] DROP CONSTRAINT [FK_tblHandover_tblChuyenTau]
GO

USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblHandover]    Script Date: 03/14/2013 23:31:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblHandover]') AND type in (N'U'))
DROP TABLE [dbo].[tblHandover]
GO

USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblHandover]    Script Date: 03/14/2013 23:31:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblHandover](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TrainID] [bigint] NOT NULL,
	[NumberHandover] [nvarchar](50) NULL,
	[DateHandover] [datetime] NULL,
	[CodeStation] [nvarchar](50) NULL,
	[CodeStationFromTo] [nvarchar](50) NULL,
	[StatusGoods] [nvarchar](200) NULL,
	[StatusVehicle] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsReplied] [bit] NULL,
	[NumberReply] [nvarchar](50) NULL,
	[DateReply] [datetime] NULL,
	[NoteReply] [nvarchar](500) NULL,
	[Note] [nvarchar](500) NULL,
	[Type] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tblHandover] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblHandover]  WITH CHECK ADD  CONSTRAINT [FK_tblHandover_tblChuyenTau] FOREIGN KEY([TrainID])
REFERENCES [dbo].[tblChuyenTau] ([TrainID])
GO

ALTER TABLE [dbo].[tblHandover] CHECK CONSTRAINT [FK_tblHandover_tblChuyenTau]
GO


USE [dbTrain]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblHandover]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource] DROP CONSTRAINT [FK_tblHandoverResource_tblHandover]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource] DROP CONSTRAINT [FK_tblHandoverResource_tblToaTau]
GO

USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblHandoverResource]    Script Date: 03/14/2013 23:31:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]') AND type in (N'U'))
DROP TABLE [dbo].[tblHandoverResource]
GO

USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblHandoverResource]    Script Date: 03/14/2013 23:31:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblHandoverResource](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[HandoverID] [bigint] NOT NULL,
	[ToaTauID] [bigint] NOT NULL,
 CONSTRAINT [PK_tblHandoverResource] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblHandoverResource]  WITH CHECK ADD  CONSTRAINT [FK_tblHandoverResource_tblHandover] FOREIGN KEY([HandoverID])
REFERENCES [dbo].[tblHandover] ([ID])
GO

ALTER TABLE [dbo].[tblHandoverResource] CHECK CONSTRAINT [FK_tblHandoverResource_tblHandover]
GO

ALTER TABLE [dbo].[tblHandoverResource]  WITH CHECK ADD  CONSTRAINT [FK_tblHandoverResource_tblToaTau] FOREIGN KEY([ToaTauID])
REFERENCES [dbo].[tblToaTau] ([ToaTauID])
GO

ALTER TABLE [dbo].[tblHandoverResource] CHECK CONSTRAINT [FK_tblHandoverResource_tblToaTau]
GO


