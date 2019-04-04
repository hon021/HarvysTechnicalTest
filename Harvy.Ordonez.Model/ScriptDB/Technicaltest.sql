/*
 Navicat Premium Data Transfer

 Source Server         : LocalSQLServer
 Source Server Type    : SQL Server
 Source Server Version : 12002000
 Source Host           : ANALISTAIT-PC\SQLEXPRESS:1433
 Source Catalog        : Technicaltest
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 12002000
 File Encoding         : 65001

 Date: 03/04/2019 22:41:26
*/


-- ----------------------------
-- Table structure for Invoice
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type IN ('U'))
	DROP TABLE [dbo].[Invoice]
GO

CREATE TABLE [dbo].[Invoice] (
  [IdInvoice] int  IDENTITY(1,1) NOT NULL,
  [InvoiceDate] datetime  NULL,
  [Amount] decimal(10,2)  NULL,
  [TotalAmount] decimal(10,2)  NULL,
  [TotalTax] decimal(10,2)  NULL,
  [Active] bit  NULL,
  [CreatedAt] datetime  NULL,
  [UpadteAt] datetime  NULL,
  [DeleteAt] datetime  NULL
)
GO

ALTER TABLE [dbo].[Invoice] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for InvoiceDetail
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[InvoiceDetail]') AND type IN ('U'))
	DROP TABLE [dbo].[InvoiceDetail]
GO

CREATE TABLE [dbo].[InvoiceDetail] (
  [IdInvoiceDetail] int  IDENTITY(1,1) NOT NULL,
  [IdItem] int  NULL,
  [IdInvoice] int  NULL,
  [TaxValue] decimal(10,2)  NULL,
  [Quantity] numeric(10)  NULL,
  [Price] decimal(10,2)  NULL,
  [Active] bit  NULL,
  [CreatedAt] datetime  NULL,
  [UpadteAt] datetime  NULL,
  [DeleteAt] datetime  NULL
)
GO

ALTER TABLE [dbo].[InvoiceDetail] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Item
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type IN ('U'))
	DROP TABLE [dbo].[Item]
GO

CREATE TABLE [dbo].[Item] (
  [IdItem] int  IDENTITY(1,1) NOT NULL,
  [TypeItem] varchar(128) COLLATE Modern_Spanish_CI_AS  NULL,
  [Name] varchar(128) COLLATE Modern_Spanish_CI_AS  NULL,
  [Quantity] numeric(10)  NULL,
  [SalePrice] decimal(10,2)  NULL,
  [Photo] varchar(4096) COLLATE Modern_Spanish_CI_AS  NULL,
  [IsTax] bit  NULL,
  [IsInventory] bit  NULL,
  [Active] bit  NULL,
  [CreatedAt] datetime  NULL,
  [UpadteAt] datetime  NULL,
  [DeleteAt] datetime  NULL
)
GO

ALTER TABLE [dbo].[Item] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table Invoice
-- ----------------------------
ALTER TABLE [dbo].[Invoice] ADD CONSTRAINT [PK_Invoice] PRIMARY KEY NONCLUSTERED ([IdInvoice])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table InvoiceDetail
-- ----------------------------
ALTER TABLE [dbo].[InvoiceDetail] ADD CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY NONCLUSTERED ([IdInvoiceDetail])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Item
-- ----------------------------
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_Item] PRIMARY KEY NONCLUSTERED ([IdItem])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table InvoiceDetail
-- ----------------------------
ALTER TABLE [dbo].[InvoiceDetail] ADD CONSTRAINT [FK_InvoiceD_InvoiceIN_Invoice] FOREIGN KEY ([IdInvoice]) REFERENCES [dbo].[Invoice] ([IdInvoice]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[InvoiceDetail] ADD CONSTRAINT [FK_InvoiceD_ItemInvoi_Item] FOREIGN KEY ([IdItem]) REFERENCES [dbo].[Item] ([IdItem]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

