/*
   Wednesday, March 27, 201311:30:45 PM
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
CREATE TABLE dbo.Tmp_tblListHandoverReply
	(
	ID bigint NOT NULL IDENTITY (1, 1),
	ListReplyNumber varchar(100) NULL,
	ReplyStatusGoods nvarchar(500) NULL,
	ListReplyDate datetime NULL,
	ReportFromDate datetime NULL,
	ReportToDate datetime NULL,
	CustomsCodeReceiver nvarchar(50) NULL,
	Note nvarchar(500) NULL,
	CreatedDate datetime NULL,
	CreatedBy int NULL,
	ModifiedDate datetime NULL,
	ModifiedBy int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblListHandoverReply SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_tblListHandoverReply ON
GO
IF EXISTS(SELECT * FROM dbo.tblListHandoverReply)
	 EXEC('INSERT INTO dbo.Tmp_tblListHandoverReply (ID, ListReplyNumber, ReplyStatusGoods, ListReplyDate, ReportFromDate, ReportToDate, CustomsCodeReceiver, Note, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy)
		SELECT ID, ListReplyNumber, CONVERT(nvarchar(500), ReplyStatusGoods), ListReplyDate, ReportFromDate, ReportToDate, CustomsCodeReceiver, CONVERT(nvarchar(500), Note), CreatedDate, CreatedBy, ModifiedDate, ModifiedBy FROM dbo.tblListHandoverReply WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblListHandoverReply OFF
GO
ALTER TABLE dbo.tblHandover
	DROP CONSTRAINT FK__tblHandov__ListR__06CD04F7
GO
DROP TABLE dbo.tblListHandoverReply
GO
EXECUTE sp_rename N'dbo.Tmp_tblListHandoverReply', N'tblListHandoverReply', 'OBJECT' 
GO
ALTER TABLE dbo.tblListHandoverReply ADD CONSTRAINT
	PK_tblListHandoverReply PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblHandover ADD CONSTRAINT
	FK__tblHandov__ListR__06CD04F7 FOREIGN KEY
	(
	ListReplyID
	) REFERENCES dbo.tblListHandoverReply
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.tblHandover SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
