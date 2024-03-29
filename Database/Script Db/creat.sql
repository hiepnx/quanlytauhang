USE [dbTrain]
GO
/****** Object:  ForeignKey [FK_tblHandover_tblChuyenTau]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandover_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandover]'))
ALTER TABLE [dbo].[tblHandover] DROP CONSTRAINT [FK_tblHandover_tblChuyenTau]
GO
/****** Object:  ForeignKey [FK_tblHandoverResource_tblHandover]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblHandover]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource] DROP CONSTRAINT [FK_tblHandoverResource_tblHandover]
GO
/****** Object:  ForeignKey [FK_tblHandoverResource_tblToaTau]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource] DROP CONSTRAINT [FK_tblHandoverResource_tblToaTau]
GO
/****** Object:  ForeignKey [FK_tblTauKhachDetail_tblChuyenTau]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblTauKhachDetail_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblTauKhachDetail]'))
ALTER TABLE [dbo].[tblTauKhachDetail] DROP CONSTRAINT [FK_tblTauKhachDetail_tblChuyenTau]
GO
/****** Object:  ForeignKey [FK_tblToaTau_tblChuyenTau]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToaTau_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToaTau]'))
ALTER TABLE [dbo].[tblToaTau] DROP CONSTRAINT [FK_tblToaTau_tblChuyenTau]
GO
/****** Object:  ForeignKey [FK_tblToKhaiTau_tblChuyenTau]    Script Date: 01/07/2013 11:52:45 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTau_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTau]'))
ALTER TABLE [dbo].[tblToKhaiTau] DROP CONSTRAINT [FK_tblToKhaiTau_tblChuyenTau]
GO
/****** Object:  ForeignKey [FK_tblToKhaiTauResource_tblToaTau]    Script Date: 01/07/2013 11:52:45 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTauResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]'))
ALTER TABLE [dbo].[tblToKhaiTauResource] DROP CONSTRAINT [FK_tblToKhaiTauResource_tblToaTau]
GO
/****** Object:  ForeignKey [FK_tblToKhaiTauResource_tblToKhaiTau]    Script Date: 01/07/2013 11:52:45 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTauResource_tblToKhaiTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]'))
ALTER TABLE [dbo].[tblToKhaiTauResource] DROP CONSTRAINT [FK_tblToKhaiTauResource_tblToKhaiTau]
GO
/****** Object:  Table [dbo].[tblHandoverResource]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblHandover]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource] DROP CONSTRAINT [FK_tblHandoverResource_tblHandover]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource] DROP CONSTRAINT [FK_tblHandoverResource_tblToaTau]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]') AND type in (N'U'))
DROP TABLE [dbo].[tblHandoverResource]
GO
/****** Object:  Table [dbo].[tblToKhaiTauResource]    Script Date: 01/07/2013 11:52:45 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTauResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]'))
ALTER TABLE [dbo].[tblToKhaiTauResource] DROP CONSTRAINT [FK_tblToKhaiTauResource_tblToaTau]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTauResource_tblToKhaiTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]'))
ALTER TABLE [dbo].[tblToKhaiTauResource] DROP CONSTRAINT [FK_tblToKhaiTauResource_tblToKhaiTau]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]') AND type in (N'U'))
DROP TABLE [dbo].[tblToKhaiTauResource]
GO
/****** Object:  Table [dbo].[tblHandover]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandover_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandover]'))
ALTER TABLE [dbo].[tblHandover] DROP CONSTRAINT [FK_tblHandover_tblChuyenTau]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblHandover]') AND type in (N'U'))
DROP TABLE [dbo].[tblHandover]
GO
/****** Object:  Table [dbo].[tblTauKhachDetail]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblTauKhachDetail_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblTauKhachDetail]'))
ALTER TABLE [dbo].[tblTauKhachDetail] DROP CONSTRAINT [FK_tblTauKhachDetail_tblChuyenTau]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTauKhachDetail]') AND type in (N'U'))
DROP TABLE [dbo].[tblTauKhachDetail]
GO
/****** Object:  Table [dbo].[tblToaTau]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToaTau_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToaTau]'))
ALTER TABLE [dbo].[tblToaTau] DROP CONSTRAINT [FK_tblToaTau_tblChuyenTau]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblToaTau]') AND type in (N'U'))
DROP TABLE [dbo].[tblToaTau]
GO
/****** Object:  Table [dbo].[tblToKhaiTau]    Script Date: 01/07/2013 11:52:45 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTau_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTau]'))
ALTER TABLE [dbo].[tblToKhaiTau] DROP CONSTRAINT [FK_tblToKhaiTau_tblChuyenTau]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblToKhaiTau]') AND type in (N'U'))
DROP TABLE [dbo].[tblToKhaiTau]
GO
/****** Object:  Table [dbo].[tblChuyenTau]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblChuyenTau]') AND type in (N'U'))
DROP TABLE [dbo].[tblChuyenTau]
GO
/****** Object:  Table [dbo].[tblCompany]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCompany]') AND type in (N'U'))
DROP TABLE [dbo].[tblCompany]
GO
/****** Object:  Table [dbo].[tblCustoms]    Script Date: 01/07/2013 11:52:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCustoms]') AND type in (N'U'))
DROP TABLE [dbo].[tblCustoms]
GO
/****** Object:  Table [dbo].[tblTrain]    Script Date: 01/07/2013 11:52:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTrain]') AND type in (N'U'))
DROP TABLE [dbo].[tblTrain]
GO
/****** Object:  Table [dbo].[tblType]    Script Date: 01/07/2013 11:52:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblType]') AND type in (N'U'))
DROP TABLE [dbo].[tblType]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 01/07/2013 11:52:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
DROP TABLE [dbo].[tblUser]
GO
/****** Object:  View [dbo].[ViewGetCurrentDate]    Script Date: 01/07/2013 11:52:46 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewGetCurrentDate]'))
DROP VIEW [dbo].[ViewGetCurrentDate]
GO
/****** Object:  View [dbo].[ViewGetCurrentDate]    Script Date: 01/07/2013 11:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ViewGetCurrentDate]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[ViewGetCurrentDate] AS SELECT     GETDATE() AS CurrentDateTime

'
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 01/07/2013 11:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Sex] [int] NULL,
	[Birthday] [datetime] NULL,
	[Address] [nvarchar](300) NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](300) NULL,
	[PermissionID] [int] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblType]    Script Date: 01/07/2013 11:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblType](
	[TypeCode] [nvarchar](50) NOT NULL,
	[TypeName] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblType_1] PRIMARY KEY CLUSTERED 
(
	[TypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblTrain]    Script Date: 01/07/2013 11:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTrain]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[tblCustoms]    Script Date: 01/07/2013 11:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCustoms]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCustoms](
	[CustomsCode] [nvarchar](50) NOT NULL,
	[CustomsName] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblCustoms_1] PRIMARY KEY CLUSTERED 
(
	[CustomsCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblCompany]    Script Date: 01/07/2013 11:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCompany]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCompany](
	[CompanyCode] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](500) NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblCompany_1] PRIMARY KEY CLUSTERED 
(
	[CompanyCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblChuyenTau]    Script Date: 01/07/2013 11:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblChuyenTau]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblChuyenTau](
	[TrainID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ma_Chuyen_Tau] [nvarchar](50) NULL,
	[Type] [smallint] NULL,
	[Ngay_XNC] [datetime] NULL,
	[IsPassengerTrain] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tblChuyenTau] PRIMARY KEY CLUSTERED 
(
	[TrainID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblToKhaiTau]    Script Date: 01/07/2013 11:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblToKhaiTau]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblToKhaiTau](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Number] [int] NULL,
	[DateDeclaration] [datetime] NULL,
	[TypeCode] [nvarchar](50) NULL,
	[CustomCode] [nvarchar](50) NULL,
	[CompanyCode] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[TrainID] [bigint] NOT NULL,
 CONSTRAINT [PK_tblToKhaiTau_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblToaTau]    Script Date: 01/07/2013 11:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblToaTau]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblToaTau](
	[ToaTauID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ma_ToaTau] [nvarchar](50) NULL,
	[So_VanTai_Don] [nvarchar](50) NULL,
	[Ngay_VanTai_Don] [datetime] NULL,
	[Ten_DoiTac] [nvarchar](250) NULL,
	[Ma_DoanhNghiep] [nvarchar](50) NULL,
	[Ten_Hang] [nvarchar](250) NULL,
	[Trong_Luong] [nvarchar](50) NULL,
	[Don_Vi_Tinh] [nvarchar](50) NULL,
	[Seal_VanTai] [nvarchar](50) NULL,
	[Seal_HaiQuan] [nvarchar](50) NULL,
	[Ghi_Chu] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[TrainID] [bigint] NOT NULL,
 CONSTRAINT [PK_tblToaTau] PRIMARY KEY CLUSTERED 
(
	[ToaTauID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblTauKhachDetail]    Script Date: 01/07/2013 11:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTauKhachDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblTauKhachDetail](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TrainID] [bigint] NOT NULL,
	[Jounery] [nvarchar](200) NULL,
	[PassengerVN] [int] NULL,
	[PassengerForegin] [int] NULL,
	[Staff] [int] NULL,
 CONSTRAINT [PK_tblTauKhachDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblHandover]    Script Date: 01/07/2013 11:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblHandover]') AND type in (N'U'))
BEGIN
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
 CONSTRAINT [PK_tblHandover] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblToKhaiTauResource]    Script Date: 01/07/2013 11:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblToKhaiTauResource](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ToKhaiTauID] [bigint] NOT NULL,
	[ToaTauID] [bigint] NOT NULL,
 CONSTRAINT [PK_tblToKhaiTauResource] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblHandoverResource]    Script Date: 01/07/2013 11:52:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblHandoverResource](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[HandoverID] [bigint] NOT NULL,
	[ToaTauID] [bigint] NOT NULL,
 CONSTRAINT [PK_tblHandoverResource] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  ForeignKey [FK_tblHandover_tblChuyenTau]    Script Date: 01/07/2013 11:52:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandover_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandover]'))
ALTER TABLE [dbo].[tblHandover]  WITH CHECK ADD  CONSTRAINT [FK_tblHandover_tblChuyenTau] FOREIGN KEY([TrainID])
REFERENCES [dbo].[tblChuyenTau] ([TrainID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandover_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandover]'))
ALTER TABLE [dbo].[tblHandover] CHECK CONSTRAINT [FK_tblHandover_tblChuyenTau]
GO
/****** Object:  ForeignKey [FK_tblHandoverResource_tblHandover]    Script Date: 01/07/2013 11:52:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblHandover]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource]  WITH CHECK ADD  CONSTRAINT [FK_tblHandoverResource_tblHandover] FOREIGN KEY([HandoverID])
REFERENCES [dbo].[tblHandover] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblHandover]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource] CHECK CONSTRAINT [FK_tblHandoverResource_tblHandover]
GO
/****** Object:  ForeignKey [FK_tblHandoverResource_tblToaTau]    Script Date: 01/07/2013 11:52:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource]  WITH CHECK ADD  CONSTRAINT [FK_tblHandoverResource_tblToaTau] FOREIGN KEY([ToaTauID])
REFERENCES [dbo].[tblToaTau] ([ToaTauID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblHandoverResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblHandoverResource]'))
ALTER TABLE [dbo].[tblHandoverResource] CHECK CONSTRAINT [FK_tblHandoverResource_tblToaTau]
GO
/****** Object:  ForeignKey [FK_tblTauKhachDetail_tblChuyenTau]    Script Date: 01/07/2013 11:52:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblTauKhachDetail_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblTauKhachDetail]'))
ALTER TABLE [dbo].[tblTauKhachDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblTauKhachDetail_tblChuyenTau] FOREIGN KEY([TrainID])
REFERENCES [dbo].[tblChuyenTau] ([TrainID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblTauKhachDetail_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblTauKhachDetail]'))
ALTER TABLE [dbo].[tblTauKhachDetail] CHECK CONSTRAINT [FK_tblTauKhachDetail_tblChuyenTau]
GO
/****** Object:  ForeignKey [FK_tblToaTau_tblChuyenTau]    Script Date: 01/07/2013 11:52:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToaTau_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToaTau]'))
ALTER TABLE [dbo].[tblToaTau]  WITH CHECK ADD  CONSTRAINT [FK_tblToaTau_tblChuyenTau] FOREIGN KEY([TrainID])
REFERENCES [dbo].[tblChuyenTau] ([TrainID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToaTau_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToaTau]'))
ALTER TABLE [dbo].[tblToaTau] CHECK CONSTRAINT [FK_tblToaTau_tblChuyenTau]
GO
/****** Object:  ForeignKey [FK_tblToKhaiTau_tblChuyenTau]    Script Date: 01/07/2013 11:52:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTau_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTau]'))
ALTER TABLE [dbo].[tblToKhaiTau]  WITH CHECK ADD  CONSTRAINT [FK_tblToKhaiTau_tblChuyenTau] FOREIGN KEY([TrainID])
REFERENCES [dbo].[tblChuyenTau] ([TrainID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTau_tblChuyenTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTau]'))
ALTER TABLE [dbo].[tblToKhaiTau] CHECK CONSTRAINT [FK_tblToKhaiTau_tblChuyenTau]
GO
/****** Object:  ForeignKey [FK_tblToKhaiTauResource_tblToaTau]    Script Date: 01/07/2013 11:52:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTauResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]'))
ALTER TABLE [dbo].[tblToKhaiTauResource]  WITH CHECK ADD  CONSTRAINT [FK_tblToKhaiTauResource_tblToaTau] FOREIGN KEY([ToaTauID])
REFERENCES [dbo].[tblToaTau] ([ToaTauID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTauResource_tblToaTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]'))
ALTER TABLE [dbo].[tblToKhaiTauResource] CHECK CONSTRAINT [FK_tblToKhaiTauResource_tblToaTau]
GO
/****** Object:  ForeignKey [FK_tblToKhaiTauResource_tblToKhaiTau]    Script Date: 01/07/2013 11:52:45 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTauResource_tblToKhaiTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]'))
ALTER TABLE [dbo].[tblToKhaiTauResource]  WITH CHECK ADD  CONSTRAINT [FK_tblToKhaiTauResource_tblToKhaiTau] FOREIGN KEY([ToKhaiTauID])
REFERENCES [dbo].[tblToKhaiTau] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblToKhaiTauResource_tblToKhaiTau]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblToKhaiTauResource]'))
ALTER TABLE [dbo].[tblToKhaiTauResource] CHECK CONSTRAINT [FK_tblToKhaiTauResource_tblToKhaiTau]
GO
