USE [FixtureManagement]
GO
/****** Object:  User [Fixture]    Script Date: 2020/3/11 星期三 9:09:22 ******/
CREATE USER [Fixture] FOR LOGIN [Fixture] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Fixture]
GO
/****** Object:  Table [dbo].[FixtureDefinition]    Script Date: 2020/3/11 星期三 9:09:22 ******/
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
	[partNo] [nvarchar](100) NOT NULL,
	[UPL] [int] NOT NULL,
	[UsedFor] [nvarchar](50) NOT NULL,
	[PMPeriod] [int] NOT NULL,
	[Owner] [nvarchar](20) NOT NULL,
	[RecOn] [smalldatetime] NOT NULL,
	[RecBy] [nchar](20) NOT NULL,
	[EditOn] [smalldatetime] NOT NULL,
	[EditBy] [nchar](20) NOT NULL,
	[WorkCellID] [int] NOT NULL,
 CONSTRAINT [PK_FixtureDefinition] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureEntity]    Script Date: 2020/3/11 星期三 9:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureEntity](
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[BillNo] [nvarchar](20) NOT NULL,
	[RegDate] [smalldatetime] NOT NULL,
	[UsedCount] [int] NOT NULL,
	[Location] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_FixtureEntity] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[SeqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureFamily]    Script Date: 2020/3/11 星期三 9:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureFamily](
	[FamilyID] [int] NOT NULL,
	[FamilyName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_FixtureFamily] PRIMARY KEY CLUSTERED 
(
	[FamilyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureInRecord]    Script Date: 2020/3/11 星期三 9:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureInRecord](
	[RetByName] [nvarchar](20) NOT NULL,
	[OperationByName] [nvarchar](20) NOT NULL,
	[ProdLineID] [int] NOT NULL,
	[RetDate] [smalldatetime] NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureOutRecord]    Script Date: 2020/3/11 星期三 9:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixtureOutRecord](
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[UsedByName] [nvarchar](20) NOT NULL,
	[OperationByName] [nvarchar](20) NOT NULL,
	[ProLineID] [int] NOT NULL,
	[UsedDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_FixtureOutRecord] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[SeqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixturePurchaseApp]    Script Date: 2020/3/11 星期三 9:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FixturePurchaseApp](
	[AppBy] [nvarchar](20) NOT NULL,
	[AppByName] [nvarchar](20) NOT NULL,
	[FamilyID] [int] NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[SeqID] [int] NOT NULL,
	[BillNo] [nvarchar](20) NOT NULL,
	[RegDate] [smalldatetime] NOT NULL,
	[Pic] [nvarchar](20) NULL,
	[State] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_FixturePurchaseApp] PRIMARY KEY CLUSTERED 
(
	[BillNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FixtureRepairRecord]    Script Date: 2020/3/11 星期三 9:09:22 ******/
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
/****** Object:  Table [dbo].[FixtureScrapRecord]    Script Date: 2020/3/11 星期三 9:09:22 ******/
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
/****** Object:  Table [dbo].[ProductionLine]    Script Date: 2020/3/11 星期三 9:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionLine](
	[ProLineID] [int] NOT NULL,
	[ProLineName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ProductionLine] PRIMARY KEY CLUSTERED 
(
	[ProLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestUser]    Script Date: 2020/3/11 星期三 9:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestUser](
	[ID] [int] NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_TestUser] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkCell]    Script Date: 2020/3/11 星期三 9:09:22 ******/
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
ALTER TABLE [dbo].[FixtureEntity]  WITH CHECK ADD  CONSTRAINT [FK_FixtureEntity_FixtureDefinition] FOREIGN KEY([Code])
REFERENCES [dbo].[FixtureDefinition] ([Code])
GO
ALTER TABLE [dbo].[FixtureEntity] CHECK CONSTRAINT [FK_FixtureEntity_FixtureDefinition]
GO
ALTER TABLE [dbo].[FixturePurchaseApp]  WITH CHECK ADD  CONSTRAINT [FK_FixturePurchaseApp_FixtureEntity] FOREIGN KEY([Code], [SeqID])
REFERENCES [dbo].[FixtureEntity] ([Code], [SeqID])
GO
ALTER TABLE [dbo].[FixturePurchaseApp] CHECK CONSTRAINT [FK_FixturePurchaseApp_FixtureEntity]
GO
ALTER TABLE [dbo].[FixturePurchaseApp]  WITH CHECK ADD  CONSTRAINT [FK_FixturePurchaseApp_FixtureFamily] FOREIGN KEY([FamilyID])
REFERENCES [dbo].[FixtureFamily] ([FamilyID])
GO
ALTER TABLE [dbo].[FixturePurchaseApp] CHECK CONSTRAINT [FK_FixturePurchaseApp_FixtureFamily]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具所属大类 id  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'FamilyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具模组 多个' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'Model'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具料号 多个' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureDefinition', @level2type=N'COLUMN',@level2name=N'partNo'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'UsedByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'OperationByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产线代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'ProLineID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixtureOutRecord', @level2type=N'COLUMN',@level2name=N'UsedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请人 代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'AppBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'AppByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具类别代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'FamilyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具代码 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'夹具序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'SeqID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FixturePurchaseApp', @level2type=N'COLUMN',@level2name=N'BillNo'
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产线ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductionLine', @level2type=N'COLUMN',@level2name=N'ProLineID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产线名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductionLine', @level2type=N'COLUMN',@level2name=N'ProLineName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增列' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TestUser', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户代码（员工号)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TestUser', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TestUser', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TestUser', @level2type=N'COLUMN',@level2name=N'Password'
GO
