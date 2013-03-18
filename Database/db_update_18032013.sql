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
ALTER TABLE dbo.tblHandover
	DROP CONSTRAINT FK_tblHandover_tblChuyenTau
GO
ALTER TABLE dbo.tblChuyenTau SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblHandover
	(
	ID bigint NOT NULL IDENTITY (1, 1),
	TrainID bigint NOT NULL,
	NumberHandover nvarchar(50) NULL,
	DateHandover datetime NULL,
	CodeStation nvarchar(50) NULL,
	CodeStationFromTo nvarchar(50) NULL,
	StatusGoods nvarchar(200) NULL,
	StatusVehicle nvarchar(200) NULL,
	CreatedDate datetime NULL,
	CreatedBy int NULL,
	ModifiedDate datetime NULL,
	ModifiedBy int NULL,
	IsReplied bit NULL,
	NumberReply nvarchar(50) NULL,
	DateReply datetime NULL,
	NoteReply nvarchar(500) NULL,
	ReplyStatusGoods nvarchar(500) NULL,
	Note nvarchar(500) NULL,
	Type nvarchar(200) NULL,
	IsDeleted bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblHandover SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_tblHandover ON
GO
IF EXISTS(SELECT * FROM dbo.tblHandover)
	 EXEC('INSERT INTO dbo.Tmp_tblHandover (ID, TrainID, NumberHandover, DateHandover, CodeStation, CodeStationFromTo, StatusGoods, StatusVehicle, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, IsReplied, NumberReply, DateReply, NoteReply, Note, Type, IsDeleted)
		SELECT ID, TrainID, NumberHandover, DateHandover, CodeStation, CodeStationFromTo, StatusGoods, StatusVehicle, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, IsReplied, NumberReply, DateReply, NoteReply, Note, Type, IsDeleted FROM dbo.tblHandover WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblHandover OFF
GO
ALTER TABLE dbo.tblHandoverResource
	DROP CONSTRAINT FK_tblHandoverResource_tblHandover
GO
DROP TABLE dbo.tblHandover
GO
EXECUTE sp_rename N'dbo.Tmp_tblHandover', N'tblHandover', 'OBJECT' 
GO
ALTER TABLE dbo.tblHandover ADD CONSTRAINT
	PK_tblHandover PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tblHandover ADD CONSTRAINT
	FK_tblHandover_tblChuyenTau FOREIGN KEY
	(
	TrainID
	) REFERENCES dbo.tblChuyenTau
	(
	TrainID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblHandoverResource ADD CONSTRAINT
	FK_tblHandoverResource_tblHandover FOREIGN KEY
	(
	HandoverID
	) REFERENCES dbo.tblHandover
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.tblHandoverResource SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblNumberGenerate]    Script Date: 03/18/2013 23:58:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNumberGenerate]') AND type in (N'U'))
DROP TABLE [dbo].[tblNumberGenerate]
GO

USE [dbTrain]
GO

/****** Object:  Table [dbo].[tblNumberGenerate]    Script Date: 03/18/2013 23:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblNumberGenerate](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[HandoverNumber] [bigint]  NOT NULL,
	[ReplyReportNumber] [bigint]  NOT NULL,
 CONSTRAINT [PK_tblNumberGenerate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO