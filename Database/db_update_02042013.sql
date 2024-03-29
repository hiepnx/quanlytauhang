/*
   Wednesday, April 03, 201312:04:22 AM
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
ALTER TABLE dbo.tblToKhaiTau
	DROP CONSTRAINT FK_tblToKhaiTau_tblChuyenTau
GO
ALTER TABLE dbo.tblChuyenTau SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblToKhaiTau
	DROP COLUMN TrainID
GO
ALTER TABLE dbo.tblToKhaiTau SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
