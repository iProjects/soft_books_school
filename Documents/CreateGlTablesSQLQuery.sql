/****** Object:  Table [dbo].[gl_Accounts]    Script Date: 10/03/2012 08:49:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Accounts]
GO
/****** Object:  Table [dbo].[gl_Coa]    Script Date: 10/03/2012 08:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Coa]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Coa]
GO
/****** Object:  Table [dbo].[gl_Accounts]    Script Date: 10/03/2012 08:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Accounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Accounts](
	[AccountID] [int] NOT NULL,
	[COA] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccountType] [int] NULL,
	[AccountName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountingPeriod] [datetime] NULL,
	[DateofEntry] [datetime] NULL,
	[TimeofEntry] [datetime] NULL,
	[Authorizer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GLNumber] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClearedBalance] [money] NULL,
	[BookBalance] [money] NULL,
	[AccruedInterest] [money] NULL,
	[InterestYTD] [money] NULL,
	[JointOwnership] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanAccountNumber] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrincipalAmount] [decimal](18, 0) NULL,
	[Annualyield] [decimal](18, 0) NULL,
	[CurrentBalance] [decimal](18, 0) NULL,
	[PayoffAmount] [decimal](18, 0) NULL,
	[Costoffunds] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Accounts_1] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC,
	[COA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO

/****** Object:  Table [dbo].[gl_Coa]    Script Date: 10/03/2012 08:49:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Coa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Coa](
	[Id] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nchar](30) COLLATE Latin1_General_CI_AS NOT NULL,
	[Level] [int] NOT NULL,
	[Parent] [nvarchar](20) COLLATE Latin1_General_CI_AS NOT NULL,
	[Lorder] [int] NOT NULL,
 CONSTRAINT [PK_Coa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'A                   ', N'ASSET                         ', 0, N'0                   ', 1)
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'C                   ', N'CAPITAL                       ', 0, N'0                   ', 5)
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'E                   ', N'EXPENSES                      ', 0, N'0                   ', 4)
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'I                   ', N'INCOME                        ', 0, N'0                   ', 3)
INSERT [dbo].[gl_Coa] ([Id], [Description], [Level], [Parent], [Lorder]) VALUES (N'L                   ', N'LIABILITIES                   ', 0, N'0                   ', 2)

/****** Object:  ForeignKey [FK_Accounts_Coa]    Script Date: 10/03/2012 08:49:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Coa]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_Accounts]'))
ALTER TABLE [dbo].[gl_Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Coa] FOREIGN KEY([COA])
REFERENCES [dbo].[gl_Coa] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Coa]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_Accounts]'))
ALTER TABLE [dbo].[gl_Accounts] CHECK CONSTRAINT [FK_Accounts_Coa]
GO