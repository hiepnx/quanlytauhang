USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblListHandoverReply]    Script Date: 03/21/2013 23:54:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblListHandoverReply]') AND type in (N'U'))
DROP TABLE [dbo].[tblListHandoverReply]
GO

USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblListHandoverReply]    Script Date: 03/21/2013 23:54:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblListHandoverReply](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ListReplyNumber] [varchar](100) NULL,
	[ReplyStatusGoods] [varchar](500) NULL,
	[ListReplyDate] [datetime] NULL,
	[ReportFromDate] [datetime] NULL,
	[ReportToDate] [datetime] NULL,
	[CustomsCodeReceiver] [nvarchar](50) NULL,
	[Note] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblListHandoverReply] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/*
   Thursday, March 21, 201311:22:08 PM
   User: sa
   Server: THANHTUNG-PC
   Database: dbTrain
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblHandover ADD
	ListReplyID bigint NULL,
	FOREIGN KEY (ListReplyID) REFERENCES tblListHandoverReply(ID)
GO
ALTER TABLE dbo.tblHandover SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


USE [dbTrain]
GO

/****** Object:  View [dbo].[ViewListHanoverReply]    Script Date: 03/23/2013 22:16:23 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewListHanoverReply]'))
DROP VIEW [dbo].[ViewListHanoverReply]
GO

USE [dbTrain]
GO

/****** Object:  View [dbo].[ViewListHanoverReply]    Script Date: 03/23/2013 22:16:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewListHanoverReply]
AS
SELECT     dbo.tblListHandoverReply.ID, dbo.tblListHandoverReply.ListReplyNumber, dbo.tblListHandoverReply.ReplyStatusGoods, dbo.tblListHandoverReply.ListReplyDate, 
                      dbo.tblListHandoverReply.ReportFromDate, dbo.tblListHandoverReply.ReportToDate, dbo.tblListHandoverReply.CustomsCodeReceiver, 
                      dbo.tblListHandoverReply.Note, dbo.tblListHandoverReply.CreatedDate, dbo.tblListHandoverReply.CreatedBy, dbo.tblListHandoverReply.ModifiedDate, 
                      dbo.tblListHandoverReply.ModifiedBy, dbo.tblCustoms.CustomsName AS CustomsReceiverName
FROM         dbo.tblListHandoverReply INNER JOIN
                      dbo.tblCustoms ON dbo.tblListHandoverReply.CustomsCodeReceiver = dbo.tblCustoms.CustomsCode

GO
