USE [dbTrain]
GO
/****** Object:  Table [dbo].[tblPermission]    Script Date: 05/22/2013 23:04:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPermission]') AND type in (N'U'))
DROP TABLE [dbo].[tblPermission]
GO

CREATE TABLE [dbo].[tblPermission](
	[PermissionID] [int] NOT NULL,
	[Permission] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (1, N'Phân quyền và quản lý người dùng')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (2, N'Quản lý tàu hàng xuất nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (3, N'Quản lý tàu khách xuất nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (4, N'Quản lý tờ khai')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (5, N'Quản lý biên bản bàn giao và hồi báo')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (6, N'Quản lý thông tin doanh nghiệp')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (61, N'Tra cứu thông tin doanh nghiệp')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (71, N'Tạo sổ theo dõi tàu hàng xuất nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (72, N'Tạo sổ theo dõi tàu khách xuất nhập cảnh')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (73, N'Tạo sổ theo dõi Biên bản bàn giao')
INSERT [dbo].[tblPermission] ([PermissionID], [Permission]) VALUES (74, N'Tạo sổ theo dõi Bảng kê hồi báo biên bản bàn giao')
