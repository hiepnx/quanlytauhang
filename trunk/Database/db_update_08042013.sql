/*
   Monday, April 08, 201310:46:15 PM
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
ALTER TABLE dbo.tblToaTau
	DROP CONSTRAINT FK_tblToaTau_tblChuyenTau
GO
ALTER TABLE dbo.tblChuyenTau SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblToaTau
	(
	ToaTauID bigint NOT NULL IDENTITY (1, 1),
	Ma_ToaTau nvarchar(50) NULL,
	So_VanTai_Don nvarchar(50) NULL,
	Ngay_VanTai_Don datetime NULL,
	Ten_DoiTac nvarchar(250) NULL,
	Ma_DoanhNghiep nvarchar(50) NULL,
	Ten_Hang nvarchar(250) NULL,
	Trong_Luong nvarchar(50) NULL,
	Don_Vi_Tinh nvarchar(50) NULL,
	Seal_VanTai nvarchar(50) NULL,
	Seal_VanTai2 nvarchar(50) NULL,
	Seal_HaiQuan nvarchar(50) NULL,
	Seal_HaiQuan2 nvarchar(50) NULL,
	ImportExportType smallint NULL,
	LoaiToaTau smallint NULL,
	Ghi_Chu nvarchar(500) NULL,
	CreatedDate datetime NULL,
	CreatedBy int NULL,
	ModifiedDate datetime NULL,
	ModifiedBy int NULL,
	TrainID bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblToaTau SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_tblToaTau ON
GO
IF EXISTS(SELECT * FROM dbo.tblToaTau)
	 EXEC('INSERT INTO dbo.Tmp_tblToaTau (ToaTauID, Ma_ToaTau, So_VanTai_Don, Ngay_VanTai_Don, Ten_DoiTac, Ma_DoanhNghiep, Ten_Hang, Trong_Luong, Don_Vi_Tinh, Seal_VanTai, Seal_VanTai2, Seal_HaiQuan, Seal_HaiQuan2, Ghi_Chu, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, TrainID)
		SELECT ToaTauID, Ma_ToaTau, So_VanTai_Don, Ngay_VanTai_Don, Ten_DoiTac, Ma_DoanhNghiep, Ten_Hang, Trong_Luong, Don_Vi_Tinh, Seal_VanTai, Seal_VanTai2, Seal_HaiQuan, Seal_HaiQuan2, Ghi_Chu, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, TrainID FROM dbo.tblToaTau WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblToaTau OFF
GO
ALTER TABLE dbo.tblToKhaiTauResource
	DROP CONSTRAINT FK_tblToKhaiTauResource_tblToaTau
GO
ALTER TABLE dbo.tblHandoverResource
	DROP CONSTRAINT FK_tblHandoverResource_tblToaTau
GO
DROP TABLE dbo.tblToaTau
GO
EXECUTE sp_rename N'dbo.Tmp_tblToaTau', N'tblToaTau', 'OBJECT' 
GO
ALTER TABLE dbo.tblToaTau ADD CONSTRAINT
	PK_tblToaTau PRIMARY KEY CLUSTERED 
	(
	ToaTauID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tblToaTau ADD CONSTRAINT
	FK_tblToaTau_tblChuyenTau FOREIGN KEY
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
	FK_tblHandoverResource_tblToaTau FOREIGN KEY
	(
	ToaTauID
	) REFERENCES dbo.tblToaTau
	(
	ToaTauID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.tblHandoverResource SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblToKhaiTauResource ADD CONSTRAINT
	FK_tblToKhaiTauResource_tblToaTau FOREIGN KEY
	(
	ToaTauID
	) REFERENCES dbo.tblToaTau
	(
	ToaTauID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.tblToKhaiTauResource SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
