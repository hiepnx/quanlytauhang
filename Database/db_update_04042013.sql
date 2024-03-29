/*
   Thursday, April 04, 20139:53:54 PM
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
CREATE TABLE dbo.Tmp_tblToKhaiTau
	(
	ID bigint NOT NULL IDENTITY (1, 1),
	Number bigint NULL,
	Type smallint NULL,
	DateDeclaration datetime NULL,
	TypeCode nvarchar(50) NULL,
	CustomCode nvarchar(50) NULL,
	CompanyCode nvarchar(50) NULL,
	CreatedDate datetime NULL,
	CreatedBy int NULL,
	ModifiedDate datetime NULL,
	ModifiedBy int NULL,
	IsDeleted bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblToKhaiTau SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_tblToKhaiTau ON
GO
IF EXISTS(SELECT * FROM dbo.tblToKhaiTau)
	 EXEC('INSERT INTO dbo.Tmp_tblToKhaiTau (ID, Number, Type, DateDeclaration, TypeCode, CustomCode, CompanyCode, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, IsDeleted)
		SELECT ID, CONVERT(bigint, Number), Type, DateDeclaration, TypeCode, CustomCode, CompanyCode, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, IsDeleted FROM dbo.tblToKhaiTau WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblToKhaiTau OFF
GO
ALTER TABLE dbo.tblToKhaiTauResource
	DROP CONSTRAINT FK_tblToKhaiTauResource_tblToKhaiTau
GO
DROP TABLE dbo.tblToKhaiTau
GO
EXECUTE sp_rename N'dbo.Tmp_tblToKhaiTau', N'tblToKhaiTau', 'OBJECT' 
GO
ALTER TABLE dbo.tblToKhaiTau ADD CONSTRAINT
	PK_tblToKhaiTau_1 PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblToKhaiTauResource ADD CONSTRAINT
	FK_tblToKhaiTauResource_tblToKhaiTau FOREIGN KEY
	(
	ToKhaiTauID
	) REFERENCES dbo.tblToKhaiTau
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.tblToKhaiTauResource SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
