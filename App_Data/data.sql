USE [FixtureManagement]
GO
/****** Object:  Table [dbo].[FixtureDefinition]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureDefinition](
	[ID] [int] NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[FamilyID] [int] NOT NULL,
	[Model] [nvarchar](100) NOT NULL,
	[PartNo] [nvarchar](100) NOT NULL,
	[UPL] [int] NOT NULL,
	[UsedFor] [nvarchar](50) NOT NULL,
	[PMPeriod] [int] NOT NULL,
	[Owner] [nvarchar](20) NOT NULL,
	[RecOn] [datetime] NOT NULL,
	[RecBy] [nvarchar](20) NOT NULL,
	[EditOn] [datetime] NOT NULL,
	[EditBy] [nvarchar](20) NOT NULL,
	[WorkCellID] [int] NOT NULL,
 CONSTRAINT [PK_FixtureDefinition] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureEntity]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureEntity](
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[BillNo] [nvarchar](20) NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[UsedCount] [int] NOT NULL,
	[Location] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_FixtureEntity_1] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[SeqID] ASC,
	[BillNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureFamily]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureFamily](
	[FamilyID] [int] IDENTITY(1,1) NOT NULL,
	[FamilyName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_FixtureFamily] PRIMARY KEY CLUSTERED 
(
	[FamilyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureInRecord]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureInRecord](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[RetDate] [datetime] NOT NULL,
	[RetByName] [nvarchar](20) NOT NULL,
	[OperationByName] [nvarchar](20) NOT NULL,
	[ProdLineID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureOutRecord]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureOutRecord](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[UsedDate] [datetime] NOT NULL,
	[UsedByName] [nvarchar](20) NOT NULL,
	[OperationByName] [nvarchar](20) NOT NULL,
	[ProdLineID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixturePurchaseApp]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixturePurchaseApp](
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[BillNo] [nvarchar](20) NOT NULL,
	[AppBy] [nvarchar](20) NOT NULL,
	[AppByName] [nvarchar](20) NOT NULL,
	[FamilyID] [int] NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[Pic] [nvarchar](20) NULL,
	[State] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_FixturePurchaseApp] PRIMARY KEY CLUSTERED 
(
	[BillNo] ASC,
	[Code] ASC,
	[SeqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureRepairRecord]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureRepairRecord](
	[RepBy] [nvarchar](20) NOT NULL,
	[RepByName] [nvarchar](20) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[faultDes] [nvarchar](100) NOT NULL,
	[faultPic] [nvarchar](20) NOT NULL,
	[DealBy] [nvarchar](20) NOT NULL,
	[DealByName] [nvarchar](20) NOT NULL,
	[DealRes] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureScrapRecord]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureScrapRecord](
	[ScrapBy] [nvarchar](20) NOT NULL,
	[ScrapByName] [nvarchar](20) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[UsedCount] [int] NOT NULL,
	[ScrapReason] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuNode]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuNode](
	[MenuID] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[ParentMenuID] [nvarchar](20) NULL,
	[ControllerName] [nvarchar](20) NULL,
	[ActionName] [nvarchar](40) NULL,
	[NodeIcon] [nvarchar](40) NULL,
	[ExpandIcon] [nvarchar](40) NULL,
	[CollapseIcon] [nvarchar](40) NULL,
 CONSTRAINT [PK_MenuNode] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionLine]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionLine](
	[ProdLineID] [int] NOT NULL,
	[ProdLineName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ProductionLine] PRIMARY KEY CLUSTERED 
(
	[ProdLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [nvarchar](20) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_RoleMenu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[WorkCellID] [int] NOT NULL,
 CONSTRAINT [PK_TestUser] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [nvarchar](20) NOT NULL,
	[RoleID] [int] NULL,
	[WorkCell] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkCell]    Script Date: 2020/5/19 星期二 8:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkCell](
	[WorkCellID] [int] NOT NULL,
	[WorkCellName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_WorkCell] PRIMARY KEY CLUSTERED 
(
	[WorkCellID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1093, N'EF0789', N'MOD 3XM2 陶瓷组装夹具     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 2, N'陶瓷组装', 30, N'1284663', CAST(N'2019-07-04T16:12:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-04T16:12:00.000' AS DateTime), N'1215072             ', 8)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1123, N'EF0798', N'MOD 刷锡膏夹具           ', 79, N'FU', N'PNA90320/1 PNA90320/2 PNA90322/1', 2, N'MOD 刷锡膏', 30, N'1230936', CAST(N'2019-07-18T15:59:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-18T15:59:00.000' AS DateTime), N'1215072             ', 8)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1102, N'EF2184', N'MOD 3XM2 防旋转夹具      ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 2, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-07-12T08:04:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-12T08:04:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1094, N'EF2185', N'MOD 防旋转夹具           ', 79, N'FU', N'PNA90320/1 PNA90320/2 PNA90322/1', 2, N'波导防旋转', 30, N'1230936', CAST(N'2019-07-04T16:13:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-04T16:13:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1101, N'EF2186', N'MOD 3XM2 保护夹具       ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'保护', 30, N'1230936', CAST(N'2019-07-12T08:03:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-12T08:03:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1095, N'EF2187', N'MOD 盖板螺丝夹具          ', 79, N'FU', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'AIB盖板螺丝', 30, N'1230936', CAST(N'2019-07-04T16:14:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-04T16:14:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1096, N'EF2188', N'MOD 底座夹具            ', 79, N'FU', N'PNA90320/1 PNA90320/2 PNA90322/1', 2, N'MOD 底座', 30, N'1230936', CAST(N'2019-07-04T16:15:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-04T16:15:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1091, N'EF2189', N'MOD 3XM2 调谐夹具       ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 3, N'打调谐盖板', 30, N'1230936', CAST(N'2019-07-04T16:09:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-04T16:09:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1098, N'EF2190', N'MOD 盖板螺丝夹具          ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 3, N'MOD 打盖板螺丝', 30, N'1230936', CAST(N'2019-07-04T16:17:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-04T16:17:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1092, N'EF2191', N'MOD 3XM2 陶瓷安装夹具     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'陶瓷安装', 30, N'1230936', CAST(N'2019-07-04T16:11:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-04T16:11:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1103, N'EF2192', N'MOD 3XM2 最终组装夹具     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 最终组装', 30, N'1230936', CAST(N'2019-07-12T08:05:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-12T08:05:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1097, N'EF2203', N'MOD 波导防旋转夹具         ', 79, N'FU', N'PNA90320/1 PNA90320/2 PNA90322/1', 2, N'MOD 波导防旋转', 30, N'1230936', CAST(N'2019-07-04T16:15:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-04T16:15:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1110, N'EF2207', N'MOD 3XM2 交叉耦合防旋转夹具  ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 交叉耦合防旋转', 30, N'1230936', CAST(N'2019-07-16T15:16:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-16T15:16:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1109, N'EF2208', N'MOD 3XM2 耦合防旋转夹具1   ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 RX耦合防旋转', 30, N'1230936', CAST(N'2019-07-16T15:15:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-16T15:15:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1111, N'EF2209', N'MOD 3XM2 RX耦合防旋转夹具2 ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 RX耦合防旋转', 30, N'1230936', CAST(N'2019-07-16T15:18:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-16T15:18:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1124, N'EF2210', N'MOD 盖板螺丝夹具          ', 79, N'FU', N'PNA90320/1 PNA90320/2 PNA90322/1', 3, N'MOD 盖板螺丝', 30, N'1230936', CAST(N'2019-07-18T16:00:00.000' AS DateTime), N'1215072             ', CAST(N'2019-07-18T16:00:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1176, N'EF2234', N'MOD 3XM2 防旋转夹具1     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-10-31T10:03:00.000' AS DateTime), N'1215072             ', CAST(N'2019-11-01T08:23:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1177, N'EF2235', N'MOD 3XM2 防旋转夹具2     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-10-31T10:04:00.000' AS DateTime), N'1215072             ', CAST(N'2019-11-01T08:23:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1178, N'EF2236', N'MOD 3XM2 防旋转夹具1     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-10-31T10:05:00.000' AS DateTime), N'1215072             ', CAST(N'2019-11-01T08:24:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1179, N'EF2237', N'MOD 3XM2 防旋转夹具2     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-10-31T10:06:00.000' AS DateTime), N'1215072             ', CAST(N'2019-11-01T08:24:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1180, N'EF2238', N'MOD 3XM2 防旋转夹具1     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-10-31T10:07:00.000' AS DateTime), N'1215072             ', CAST(N'2019-11-01T08:24:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1181, N'EF2239', N'MOD 3XM2 防旋转夹具2     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-10-31T10:07:00.000' AS DateTime), N'1215072             ', CAST(N'2019-11-01T08:25:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1182, N'EF2240', N'MOD 3XM2 防旋转夹具1     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-10-31T10:08:00.000' AS DateTime), N'1215072             ', CAST(N'2019-11-01T08:25:00.000' AS DateTime), N'1215072             ', 7)
INSERT [dbo].[FixtureDefinition] ([ID], [Code], [Name], [FamilyID], [Model], [PartNo], [UPL], [UsedFor], [PMPeriod], [Owner], [RecOn], [RecBy], [EditOn], [EditBy], [WorkCellID]) VALUES (1183, N'EF2241', N'MOD 3XM2 防旋转夹具2     ', 79, N'MOD 3XM2', N'PNA90320/1 PNA90320/2 PNA90322/1', 1, N'MOD 3XM2 防旋转', 30, N'1230936', CAST(N'2019-10-31T10:09:00.000' AS DateTime), N'1215072             ', CAST(N'2019-11-07T10:01:00.000' AS DateTime), N'1284663             ', 7)
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF0789', 1, N'BO19070500000002', CAST(N'2019-07-05T16:42:00.000' AS DateTime), 9, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF0789', 2, N'BO19070500000001', CAST(N'2019-07-05T16:42:00.000' AS DateTime), 33, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF0798', 1, N'BO19072900000018', CAST(N'2019-07-29T08:54:00.000' AS DateTime), 19, N'7-A1')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF0798', 2, N'BO19090900000002', CAST(N'2019-09-11T08:45:00.000' AS DateTime), 5, N'7-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2184', 1, N'BO19071200000004', CAST(N'2019-07-12T09:03:00.000' AS DateTime), 4, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2184', 2, N'BO19071200000003', CAST(N'2019-07-12T09:03:00.000' AS DateTime), 3, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2185', 1, N'BO19070600000006', CAST(N'2019-07-09T15:48:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2185', 2, N'BO19070900000003', CAST(N'2019-07-10T08:50:00.000' AS DateTime), 1, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2186', 1, N'BO19071200000002', CAST(N'2019-07-12T09:03:00.000' AS DateTime), 0, N'16-A1-1')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2187', 1, N'BO19070500000003', CAST(N'2019-07-05T16:42:00.000' AS DateTime), 1, N'16-A1-2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2188', 1, N'BO19070500000005', CAST(N'2019-07-05T16:42:00.000' AS DateTime), 1, N'8-A2-2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2188', 2, N'BO19070500000004', CAST(N'2019-07-05T16:42:00.000' AS DateTime), 23, N'8-A2-1')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2189', 1, N'BO19070600000007', CAST(N'2019-07-09T15:48:00.000' AS DateTime), 0, N'8-B2-1')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2189', 2, N'BO19082700000002', CAST(N'2019-08-27T09:24:00.000' AS DateTime), 0, N'8-C2-1')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2189', 3, N'BO19082700000001', CAST(N'2019-08-27T09:24:00.000' AS DateTime), 0, N'8-B2-2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2190', 1, N'BO19070500000006', CAST(N'2019-07-05T16:42:00.000' AS DateTime), 0, N'16-A1-5')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2190', 2, N'BO19070600000005', CAST(N'2019-07-09T15:48:00.000' AS DateTime), 45, N'16-A1-4')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2190', 3, N'BO19070600000004', CAST(N'2019-07-09T15:48:00.000' AS DateTime), 0, N'16-A1-3')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2191', 1, N'BO19070500000007', CAST(N'2019-07-05T16:42:00.000' AS DateTime), 0, N'8-C2-2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2192', 1, N'BO19071200000005', CAST(N'2019-07-12T09:03:00.000' AS DateTime), 0, N'8-A2-3')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2203', 3, N'BO19080900000001', CAST(N'2019-08-09T16:32:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2203', 4, N'BO19080900000002', CAST(N'2019-08-09T16:33:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2207', 1, N'BO19071600000002', CAST(N'2019-07-16T16:09:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2208', 1, N'BO19071600000003', CAST(N'2019-07-16T16:09:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2209', 1, N'BO19071600000004', CAST(N'2019-07-16T16:09:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2210', 1, N'BO19072900000030', CAST(N'2019-07-29T08:53:00.000' AS DateTime), 0, N'8-C1-4')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2210', 2, N'BO19080200000015', CAST(N'2019-08-07T08:35:00.000' AS DateTime), 0, N'8-C1-6')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2210', 3, N'BO19080200000014', CAST(N'2019-08-07T08:35:00.000' AS DateTime), 0, N'8-C1-5')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2234', 1, N'BO19103100000001', CAST(N'2019-10-31T12:42:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2235', 1, N'BO19103100000002', CAST(N'2019-10-31T12:42:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2236', 1, N'BO19103100000003', CAST(N'2019-10-31T12:42:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2237', 1, N'BO19103100000004', CAST(N'2019-10-31T12:42:00.000' AS DateTime), 1, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2238', 1, N'BO19103100000005', CAST(N'2019-10-31T12:42:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2239', 1, N'BO19103100000006', CAST(N'2019-10-31T12:42:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2240', 1, N'BO19103100000007', CAST(N'2019-10-31T12:41:00.000' AS DateTime), 0, N'16-A2')
INSERT [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo], [RegDate], [UsedCount], [Location]) VALUES (N'EF2241', 1, N'BO19103100000008', CAST(N'2019-10-31T12:41:00.000' AS DateTime), 1, N'16-A2')
SET IDENTITY_INSERT [dbo].[FixtureFamily] ON 

INSERT [dbo].[FixtureFamily] ([FamilyID], [FamilyName]) VALUES (79, N'JABIL FU')
SET IDENTITY_INSERT [dbo].[FixtureFamily] OFF
SET IDENTITY_INSERT [dbo].[FixtureInRecord] ON 

INSERT [dbo].[FixtureInRecord] ([ID], [Code], [SeqID], [RetDate], [RetByName], [OperationByName], [ProdLineID]) VALUES (5, N'EF0798', 2, CAST(N'2020-12-12T12:12:12.000' AS DateTime), N'test', N'Lei Qian', 18)
SET IDENTITY_INSERT [dbo].[FixtureInRecord] OFF
SET IDENTITY_INSERT [dbo].[FixtureOutRecord] ON 

INSERT [dbo].[FixtureOutRecord] ([ID], [Code], [SeqID], [UsedDate], [UsedByName], [OperationByName], [ProdLineID]) VALUES (43, N'EF0789', 1, CAST(N'2020-12-12T12:12:12.000' AS DateTime), N'test', N'Lei Qian', 18)
INSERT [dbo].[FixtureOutRecord] ([ID], [Code], [SeqID], [UsedDate], [UsedByName], [OperationByName], [ProdLineID]) VALUES (44, N'EF2184', 2, CAST(N'2020-05-18T00:44:00.000' AS DateTime), N'test', N'Abin Liu', 19)
INSERT [dbo].[FixtureOutRecord] ([ID], [Code], [SeqID], [UsedDate], [UsedByName], [OperationByName], [ProdLineID]) VALUES (41, N'EF2241', 1, CAST(N'2020-12-11T20:15:15.000' AS DateTime), N'19', N'Lei Qian', 19)
INSERT [dbo].[FixtureOutRecord] ([ID], [Code], [SeqID], [UsedDate], [UsedByName], [OperationByName], [ProdLineID]) VALUES (45, N'EF2185', 2, CAST(N'2020-05-18T10:40:00.000' AS DateTime), N'test', N'Lei Qian', 18)
INSERT [dbo].[FixtureOutRecord] ([ID], [Code], [SeqID], [UsedDate], [UsedByName], [OperationByName], [ProdLineID]) VALUES (46, N'EF2237', 1, CAST(N'2020-05-18T12:06:00.000' AS DateTime), N'etr', N'Lei Qian', 19)
SET IDENTITY_INSERT [dbo].[FixtureOutRecord] OFF
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'Family', N'类别管理', N'FamilyManager', N'ManagerFamily', N'Index', N'fa fa-th-list', NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'FamilyAdd', N'添加类别', N'-1', N'ManagerFamily', N'AddFamilyRecord', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'FamilyDelete', N'删除类别', N'-1', N'ManagerFamily', N'DeleteFamilyRecords', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'FamilyEdit', N'修改类别', N'-1', N'ManagerFamily', N'EditFamilyRecord', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'FamilyManager', N'工夹具类别管理', N'0', NULL, NULL, N'fa fa-list-alt', N'fa fa-th-list', N'fa fa-th-list')
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'FamilyRead', N'读取所有类别', N'-1', N'ManagerFamily', N'ReadFamilyRecord', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'InOutRecord', N'夹具出入库登记', N'0', N'', N'', N'fa fa-edit fa-2x', N'fa fa-plus fa-2x ', N'fa fa-minus fa-2x')
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'InRecord', N'归还 ( 入库 )登记', N'InOutRecord', N'InRecord', N'Index', N'fa fa-arrow-left fa-lg', NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'InRecordAdd', N'添加归还记录', N'-1', N'InRecord', N'AddInRecord', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'InRecordDelete', N'删除归还记录', N'-1', N'InRecord', N'DeleteInRecords', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'InRecordRead', N'读取归还记录', N'-1', N'InRecord', N'ReadInRecords', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'InRecordUpdate', N'修改归还记录', N'-1', N'InRecord', N'UpdateInRecord', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'OutRecord', N'领用 ( 出库 )登记', N'InOutRecord', N'OutRecord', N'Index', N'fa fa-arrow-right fa-lg', NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'OutRecordAdd', N'添加领用记录', N'-1', N'OutRecord', N'AddOutRecord', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'OutRecordDelete', N'删除领用记录', N'-1', N'OutRecord', N'DeleteOutRecords', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'OutRecordRead', N'读取领用记录', N'-1', N'OutRecord', N'ReadOutRecords', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'OutRecordUpdate', N'修改领用记录', N'-1', N'OutRecord', N'UpdateOutRecord', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'User', N'用户管理', N'UserPermissions', N'User', N'Index', N'fa fa-users fa-lg', NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'UserAdd', N'添加部门用户', N'-1', N'User', N'AddUser', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'UserDelete', N'删除部门用户', N'-1', N'User', N'DeleteUsers', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'UserPermissions', N'用户权限管理', N'0', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'UserRead', N'读取部门用户', N'-1', N'User', N'ReadUsers', NULL, NULL, NULL)
INSERT [dbo].[MenuNode] ([MenuID], [Name], [ParentMenuID], [ControllerName], [ActionName], [NodeIcon], [ExpandIcon], [CollapseIcon]) VALUES (N'UserUpdate', N'修改部门用户', N'-1', N'User', N'UpdateUser', NULL, NULL, NULL)
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (9, N'BLKA10-L2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (10, N'BLKA13_L2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (11, N'BLKA14_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (12, N'BLKA15-L2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (13, N'BLKA15_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (14, N'BLKA15_L3')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (15, N'BLKA15_L4')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (16, N'BLKA16_2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (17, N'BLKA16_L2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (18, N'BLKA18_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (19, N'BLKC01_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (20, N'BLKC01_L2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (21, N'BLKC03_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (22, N'BLKC05_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (23, N'BLKC06_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (24, N'BLKC06_L2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (25, N'BLKC07_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (26, N'BLKC07_L2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (27, N'BLKC21_L1')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (28, N'BLKC21_L2')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (29, N'BLKC21_L3')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (30, N'BLKA09')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (31, N'MSUP')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (32, N'SAU')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (33, N'SCU')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (34, N'Super   line')
INSERT [dbo].[ProductionLine] ([ProdLineID], [ProdLineName]) VALUES (35, N'SXU 0501')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'WorkCellManager')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Supervisor')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (4, N'Operator II')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (5, N'Operator I')
SET IDENTITY_INSERT [dbo].[RoleMenu] ON 

INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (24, N'Family', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (18, N'Family', 3)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (25, N'FamilyAdd', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (23, N'FamilyAdd', 3)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (27, N'FamilyDelete', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (21, N'FamilyDelete', 3)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (29, N'FamilyEdit', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (22, N'FamilyEdit', 3)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (26, N'FamilyManager', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (19, N'FamilyManager', 3)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (28, N'FamilyRead', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (20, N'FamilyRead', 3)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (30, N'InOutRecord', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (1, N'InOutRecord', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (31, N'InRecord', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (2, N'InRecord', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (32, N'InRecordAdd', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (3, N'InRecordAdd', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (33, N'InRecordDelete', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (4, N'InRecordDelete', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (34, N'InRecordRead', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (5, N'InRecordRead', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (35, N'InRecordUpdate', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (6, N'InRecordUpdate', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (36, N'OutRecord', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (7, N'OutRecord', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (37, N'OutRecordAdd', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (8, N'OutRecordAdd', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (38, N'OutRecordDelete', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (9, N'OutRecordDelete', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (40, N'OutRecordRead', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (10, N'OutRecordRead', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (39, N'OutRecordUpdate', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (11, N'OutRecordUpdate', 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (13, N'User', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (14, N'UserAdd', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (15, N'UserDelete', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (12, N'UserPermissions', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (16, N'UserRead', 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (17, N'UserUpdate', 1)
SET IDENTITY_INSERT [dbo].[RoleMenu] OFF
INSERT [dbo].[User] ([Code], [Name], [Password], [WorkCellID]) VALUES (N'1000001', N'test', N'1000001', 7)
INSERT [dbo].[User] ([Code], [Name], [Password], [WorkCellID]) VALUES (N'1215072', N'Xianghai Zhang', N'1215072', 8)
INSERT [dbo].[User] ([Code], [Name], [Password], [WorkCellID]) VALUES (N'1230936', N'Lei Qian', N'1230936', 7)
INSERT [dbo].[User] ([Code], [Name], [Password], [WorkCellID]) VALUES (N'1284663', N'Abin Liu', N'1284663', 7)
INSERT [dbo].[User] ([Code], [Name], [Password], [WorkCellID]) VALUES (N'12846633', N'test', N'12846633', 7)
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([ID], [UserCode], [RoleID], [WorkCell]) VALUES (8, N'1230936', 5, N'JW05')
INSERT [dbo].[UserRole] ([ID], [UserCode], [RoleID], [WorkCell]) VALUES (17, N'1215072', 1, N'JW06')
INSERT [dbo].[UserRole] ([ID], [UserCode], [RoleID], [WorkCell]) VALUES (10, N'1230936', 5, N'JW06')
INSERT [dbo].[UserRole] ([ID], [UserCode], [RoleID], [WorkCell]) VALUES (11, N'1284663', 1, N'JW05')
INSERT [dbo].[UserRole] ([ID], [UserCode], [RoleID], [WorkCell]) VALUES (19, N'1284663', 1, N'JW06')
INSERT [dbo].[UserRole] ([ID], [UserCode], [RoleID], [WorkCell]) VALUES (21, N'12846633', 3, N'JW06')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
INSERT [dbo].[WorkCell] ([WorkCellID], [WorkCellName]) VALUES (7, N'JW05')
INSERT [dbo].[WorkCell] ([WorkCellID], [WorkCellName]) VALUES (8, N'JW06')
ALTER TABLE [dbo].[FixtureEntity] ADD  CONSTRAINT [DF_FixtureEntity_UsedCount]  DEFAULT ((0)) FOR [UsedCount]
GO
ALTER TABLE [dbo].[FixtureDefinition]  WITH CHECK ADD  CONSTRAINT [FK_FixtureDefinition_FixtureFamily] FOREIGN KEY([FamilyID])
REFERENCES [dbo].[FixtureFamily] ([FamilyID])
GO
ALTER TABLE [dbo].[FixtureDefinition] CHECK CONSTRAINT [FK_FixtureDefinition_FixtureFamily]
GO
ALTER TABLE [dbo].[FixtureDefinition]  WITH CHECK ADD  CONSTRAINT [FK_FixtureDefinition_WorkCell] FOREIGN KEY([WorkCellID])
REFERENCES [dbo].[WorkCell] ([WorkCellID])
GO
ALTER TABLE [dbo].[FixtureDefinition] CHECK CONSTRAINT [FK_FixtureDefinition_WorkCell]
GO
ALTER TABLE [dbo].[FixtureEntity]  WITH NOCHECK ADD  CONSTRAINT [FK_FixtureEntity_FixtureEntity] FOREIGN KEY([Code], [SeqID], [BillNo])
REFERENCES [dbo].[FixtureEntity] ([Code], [SeqID], [BillNo])
GO
ALTER TABLE [dbo].[FixtureEntity] CHECK CONSTRAINT [FK_FixtureEntity_FixtureEntity]
GO
ALTER TABLE [dbo].[FixtureInRecord]  WITH NOCHECK ADD  CONSTRAINT [FK_FixtureInRecord_ProductionLine] FOREIGN KEY([ProdLineID])
REFERENCES [dbo].[ProductionLine] ([ProdLineID])
GO
ALTER TABLE [dbo].[FixtureInRecord] CHECK CONSTRAINT [FK_FixtureInRecord_ProductionLine]
GO
ALTER TABLE [dbo].[FixtureOutRecord]  WITH NOCHECK ADD  CONSTRAINT [FK_FixtureOutRecord_ProductionLine] FOREIGN KEY([ProdLineID])
REFERENCES [dbo].[ProductionLine] ([ProdLineID])
GO
ALTER TABLE [dbo].[FixtureOutRecord] CHECK CONSTRAINT [FK_FixtureOutRecord_ProductionLine]
GO
ALTER TABLE [dbo].[FixturePurchaseApp]  WITH NOCHECK ADD  CONSTRAINT [FK_FixturePurchaseApp_FixtureDefinition] FOREIGN KEY([BillNo])
REFERENCES [dbo].[FixtureDefinition] ([Code])
GO
ALTER TABLE [dbo].[FixturePurchaseApp] CHECK CONSTRAINT [FK_FixturePurchaseApp_FixtureDefinition]
GO
ALTER TABLE [dbo].[FixturePurchaseApp]  WITH CHECK ADD  CONSTRAINT [FK_FixturePurchaseApp_FixtureFamily] FOREIGN KEY([FamilyID])
REFERENCES [dbo].[FixtureFamily] ([FamilyID])
GO
ALTER TABLE [dbo].[FixturePurchaseApp] CHECK CONSTRAINT [FK_FixturePurchaseApp_FixtureFamily]
GO
ALTER TABLE [dbo].[FixturePurchaseApp]  WITH CHECK ADD  CONSTRAINT [FK_FixturePurchaseApp_User] FOREIGN KEY([AppByName])
REFERENCES [dbo].[User] ([Code])
GO
ALTER TABLE [dbo].[FixturePurchaseApp] CHECK CONSTRAINT [FK_FixturePurchaseApp_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_WorkCell] FOREIGN KEY([WorkCellID])
REFERENCES [dbo].[WorkCell] ([WorkCellID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_WorkCell]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserCode])
REFERENCES [dbo].[User] ([Code])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具所属大类 id  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'FamilyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具模组 多个' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'Model'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具料号 多个' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'PartNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具在产线上需配备数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'UPL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具用途' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'UsedFor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具保养点检查周期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'PMPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'责任人代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'Owner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'录入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'RecOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'录入人 代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'RecBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'EditOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'EditBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具所属工作部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'WorkCellID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'与夹具定义表关联' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureEntity', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区分同一夹具定义下的多个夹具实体' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureEntity', @level2type=N'COLUMN',@level2name=N'SeqID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购单据号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureEntity', @level2type=N'COLUMN',@level2name=N'BillNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureEntity', @level2type=N'COLUMN',@level2name=N'RegDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureEntity', @level2type=N'COLUMN',@level2name=N'UsedCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存放库位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureEntity', @level2type=N'COLUMN',@level2name=N'Location'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具大类代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureFamily', @level2type=N'COLUMN',@level2name=N'FamilyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'大类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureFamily', @level2type=N'COLUMN',@level2name=N'FamilyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'归还人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureInRecord', @level2type=N'COLUMN',@level2name=N'RetByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'SeqID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'UsedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'UsedByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'OperationByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产线代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'ProdLineID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具代码 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'SeqID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'BillNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请人 代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'AppBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'AppByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具类别代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'FamilyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购入库日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'RegDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pic 存放的 服务器url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'Pic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报修人代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'RepBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报修人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'RepByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'SeqID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'故障描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'faultDes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'故障照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'faultPic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理人代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'DealBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'DealByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理结果' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureRepairRecord', @level2type=N'COLUMN',@level2name=N'DealRes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报废人代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureScrapRecord', @level2type=N'COLUMN',@level2name=N'ScrapBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报废人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureScrapRecord', @level2type=N'COLUMN',@level2name=N'ScrapByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureScrapRecord', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureScrapRecord', @level2type=N'COLUMN',@level2name=N'SeqID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureScrapRecord', @level2type=N'COLUMN',@level2name=N'UsedCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报废原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureScrapRecord', @level2type=N'COLUMN',@level2name=N'ScrapReason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父节点id 为0 代表本身为初始父节点 为-1 代表 为action' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuNode', @level2type=N'COLUMN',@level2name=N'ParentMenuID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果是父亲节点不显示该图标 子节点图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuNode', @level2type=N'COLUMN',@level2name=N'NodeIcon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果是父亲节点 则有值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuNode', @level2type=N'COLUMN',@level2name=N'ExpandIcon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如果是父亲节点则有值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuNode', @level2type=N'COLUMN',@level2name=N'CollapseIcon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产线ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductionLine', @level2type=N'COLUMN',@level2name=N'ProdLineID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产线名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductionLine', @level2type=N'COLUMN',@level2name=N'ProdLineName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户代码（员工号)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'指明用户 在那个部门拥有哪那个角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'WorkCell'
GO
