/****** Object:  ForeignKey [FK_Accounts_Customer]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_Customer]
GO
/****** Object:  ForeignKey [FK_Attendance_FK00]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendance_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances] DROP CONSTRAINT [FK_Attendance_FK00]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Classes]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Classes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Classes]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Subjects]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Teachers]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Teachers]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Teachers]
GO
/****** Object:  ForeignKey [FK_ExamPeriod_ExamTypes]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExamPeriod_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExamPeriod]'))
ALTER TABLE [dbo].[ExamPeriod] DROP CONSTRAINT [FK_ExamPeriod_ExamTypes]
GO
/****** Object:  ForeignKey [FK_GradingSystemDet_GradingSystems]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]'))
ALTER TABLE [dbo].[GradingSystemDet] DROP CONSTRAINT [FK_GradingSystemDet_GradingSystems]
GO
/****** Object:  ForeignKey [FK_MarkSheetStudents_FK00]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents] DROP CONSTRAINT [FK_MarkSheetStudents_FK00]
GO
/****** Object:  ForeignKey [FK_MarkSheetStudents_FK01]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents] DROP CONSTRAINT [FK_MarkSheetStudents_FK01]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ClassSubjects]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ClassSubjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_ClassSubjects]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ExamPeriod]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_ExamPeriod]
GO
/****** Object:  ForeignKey [FK_Reports_FK00]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_Reports_FK00]
GO
/****** Object:  ForeignKey [FK_StudentExams_RegisteredExams]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] DROP CONSTRAINT [FK_StudentExams_RegisteredExams]
GO
/****** Object:  ForeignKey [FK_StudentProgresses_Students]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses] DROP CONSTRAINT [FK_StudentProgresses_Students]
GO
/****** Object:  ForeignKey [FK_SubSubjects_Subjects]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects] DROP CONSTRAINT [FK_SubSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_Transactions_FK00]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_FK00]
GO
/****** Object:  ForeignKey [FK_Transactions_FK01]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_FK01]
GO
/****** Object:  ForeignKey [FK_Users_PasswordQuestion]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_PasswordQuestion]
GO
/****** Object:  Table [dbo].[StudentExams]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND type in (N'U'))
DROP TABLE [dbo].[StudentExams]
GO
/****** Object:  View [dbo].[vwTermlyFeeStatement]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwTermlyFeeStatement]'))
DROP VIEW [dbo].[vwTermlyFeeStatement]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND type in (N'U'))
DROP TABLE [dbo].[Transactions]
GO
/****** Object:  Table [dbo].[RegisteredExams]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND type in (N'U'))
DROP TABLE [dbo].[RegisteredExams]
GO
/****** Object:  Table [dbo].[GradingSystemDet]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]') AND type in (N'U'))
DROP TABLE [dbo].[GradingSystemDet]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[Accounts]
GO
/****** Object:  Table [dbo].[Attendances]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendances]') AND type in (N'U'))
DROP TABLE [dbo].[Attendances]
GO
/****** Object:  Table [dbo].[ClassSubjects]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND type in (N'U'))
DROP TABLE [dbo].[ClassSubjects]
GO
/****** Object:  Table [dbo].[ExamPeriod]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamPeriod]') AND type in (N'U'))
DROP TABLE [dbo].[ExamPeriod]
GO
/****** Object:  Table [dbo].[StudentProgresses]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses]') AND type in (N'U'))
DROP TABLE [dbo].[StudentProgresses]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
DROP TABLE [dbo].[Reports]
GO
/****** Object:  Table [dbo].[SubSubjects]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubSubjects]') AND type in (N'U'))
DROP TABLE [dbo].[SubSubjects]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[MarkSheetStudents]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]') AND type in (N'U'))
DROP TABLE [dbo].[MarkSheetStudents]
GO
/****** Object:  Table [dbo].[Parents]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parents]') AND type in (N'U'))
DROP TABLE [dbo].[Parents]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teachers]') AND type in (N'U'))
DROP TABLE [dbo].[Teachers]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTable]') AND type in (N'U'))
DROP TABLE [dbo].[TimeTable]
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionTypes]') AND type in (N'U'))
DROP TABLE [dbo].[TransactionTypes]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[RoleRights]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleRights]') AND type in (N'U'))
DROP TABLE [dbo].[RoleRights]
GO
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND type in (N'U'))
DROP TABLE [dbo].[SchoolClasses]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schools]') AND type in (N'U'))
DROP TABLE [dbo].[Schools]
GO
/****** Object:  Table [dbo].[SecurityQuestions]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestions]') AND type in (N'U'))
DROP TABLE [dbo].[SecurityQuestions]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
DROP TABLE [dbo].[Settings]
GO
/****** Object:  Table [dbo].[SettingsGroups]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SettingsGroups]') AND type in (N'U'))
DROP TABLE [dbo].[SettingsGroups]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
DROP TABLE [dbo].[Students]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
DROP TABLE [dbo].[Subjects]
GO
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamTypes]') AND type in (N'U'))
DROP TABLE [dbo].[ExamTypes]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[GradingSystems]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystems]') AND type in (N'U'))
DROP TABLE [dbo].[GradingSystems]
GO
/****** Object:  Table [dbo].[ISUserLogin]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ISUserLogin]') AND type in (N'U'))
DROP TABLE [dbo].[ISUserLogin]
GO
/****** Object:  Table [dbo].[MarksheetArchives]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarksheetArchives]') AND type in (N'U'))
DROP TABLE [dbo].[MarksheetArchives]
GO
/****** Object:  Table [dbo].[MarkSheetExams]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetExams]') AND type in (N'U'))
DROP TABLE [dbo].[MarkSheetExams]
GO
/****** Object:  Table [dbo].[ReportGroups]    Script Date: 12/29/2012 16:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportGroups]') AND type in (N'U'))
DROP TABLE [dbo].[ReportGroups]
GO
/****** Object:  Table [dbo].[ReportGroups]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportGroups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReportGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportGroup1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReportGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[MarkSheetExams]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetExams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MarkSheetExams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NULL,
	[Term] [int] NULL,
	[ExamDate] [datetime] NULL,
	[Class] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Subject] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExamType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Enabled] [bit] NOT NULL,
	[Closed] [bit] NOT NULL,
 CONSTRAINT [PK_MarkSheetExams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[MarksheetArchives]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarksheetArchives]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MarksheetArchives](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NULL,
	[Term] [int] NULL,
	[ExamType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Class] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Teacher] [int] NULL,
	[Student] [int] NULL,
	[Subject] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mark] [int] NULL,
	[OutOf] [int] NULL,
	[Grade] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_MarksheetArchives] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ISUserLogin]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ISUserLogin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ISUserLogin](
	[UserId] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Role] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Locked] [bit] NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[ISUserLogin] ([UserId], [Password], [Role], [Locked]) VALUES (N'joan', N'purple', N'ADMINISTRATOR', 0)
INSERT [dbo].[ISUserLogin] ([UserId], [Password], [Role], [Locked]) VALUES (N'kevin', N'kevin', N'ADMINISTRATOR', 0)
INSERT [dbo].[ISUserLogin] ([UserId], [Password], [Role], [Locked]) VALUES (N'muraya', N'muraya', N'USER', 0)
INSERT [dbo].[ISUserLogin] ([UserId], [Password], [Role], [Locked]) VALUES (N'sys', N'sys', N'ADMINISTRATOR', 0)
/****** Object:  Table [dbo].[GradingSystems]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GradingSystems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_GradingSystems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[GradingSystems] ON
INSERT [dbo].[GradingSystems] ([Id], [Description]) VALUES (1, N'KCPE Grading System')
INSERT [dbo].[GradingSystems] ([Id], [Description]) VALUES (2, N'KCSE Grading System')
INSERT [dbo].[GradingSystems] ([Id], [Description]) VALUES (3, N'College Grading System')
SET IDENTITY_INSERT [dbo].[GradingSystems] OFF
/****** Object:  Table [dbo].[Customers]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Branch] [int] NULL,
	[BillToName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToAddress] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToTelephone] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToEmail] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail]) VALUES (1, N'Joan', N'box 4125', N'072544200', N'joan@softwareproviders.co.ke', 11, N'Njoroge', N'box 224550', N'07225506345', N'njoroge@kk.com')
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail]) VALUES (2, N'James', N'box 2654', N'07321540', N'james@verylonongemailaddress.com', 136, N'Father John', N'box 23541', N'07361000', N'fatherjorhn@catholic.com')
SET IDENTITY_INSERT [dbo].[Customers] OFF
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExamTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ROrder] [int] NULL,
 CONSTRAINT [PK_ExamTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Subjects](
	[ShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OutOf] [float] NULL,
	[PassMark] [float] NULL,
	[Status] [int] NULL,
	[ROrder] [int] NULL,
	[Remarks] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[ShortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminNo] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentSurName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentOtherNames] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CurrentClass] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Homepage] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherCellPhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherOfficePhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherEmail] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherCellPhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherOfficePhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ResidencePhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ResidenceAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AdmissionDate] [datetime] NULL,
	[AdmittedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolPhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReasonForLeaving] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricala1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricala2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricala3] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Remarks] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [int] NULL,
	[LastModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND name = N'IX_Students')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Students] ON [dbo].[Students] 
(
	[AdminNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET IDENTITY_INSERT [dbo].[Students] ON
INSERT [dbo].[Students] ([Id], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime]) VALUES (1, N'254', N'jojo', N'frank', N'4543', NULL, NULL, NULL, NULL, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([Id], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime]) VALUES (2, N'733', N'Franko', NULL, NULL, NULL, NULL, NULL, NULL, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([Id], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime]) VALUES (3, N'268', N'Moojmm', NULL, NULL, NULL, NULL, NULL, NULL, N'2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([Id], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime]) VALUES (4, N'433', N'Lucy', NULL, NULL, NULL, NULL, NULL, NULL, N'2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
/****** Object:  Table [dbo].[SettingsGroups]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SettingsGroups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SettingsGroups](
	[Id] [int] NOT NULL,
	[GroupName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Parent] [int] NOT NULL,
 CONSTRAINT [PK_SettingsGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (1, N'Setttings', 0)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (2, N'Statutory Computations', 1)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (3, N'General', 1)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (4, N'NSSF', 6)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (5, N'PAYE', 2)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (6, N'Pension', 2)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (7, N'Security', 1)
/****** Object:  Table [dbo].[Settings]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Settings](
	[SSKey] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SSValue] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SSValueType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SGroup] [int] NULL,
	[SSSystem] [bit] NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[SSKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'COMPANYLOGO', N'C:\Users\Administrator\Documents\backup\SPPayroll\kra_logo.gif', N'S', N'Company Logo', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'COMPANYSLOGAN', N'Solutions for all', N'S', N'Company Slogan', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'DEFCONTR', N'20000', N'N', N'Max Defined Contribution', 6, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'DEFCONTRSCHEME', N'2', N'E1,2,3', N'Default contribution scheme', 6, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'EMPNSSF', N'200', N'N', N'Employers NSFF contribution', 4, 1)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'GRADINGSYS', N'2', N'N', N'Grading System', 2, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MAXTRIES', N'3', N'N', N'Maximum password retries', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MINAGE', N'18', N'N', N'Minimum employement age', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MRELIEF', N'1162', N'N', N'Married persons relief', 2, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'NSSFMAX', N'200', N'N', N'Max NSSF contribution', 4, 1)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'NSSFVAL', N'5', N'N', N'NSSFVAL', 4, 1)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PAYEEMIN', N'11136', N'N', N'Minimum earning to start charging PAYE', 5, 1)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PAYSLIPDETAILS', N'1', N'N', N'Payslip details layout', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PAYSLIPPERPAGE', N'2', N'N', N'Payslips per page. Valid values 1 or 2', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PAYSLIPTYPE', N'VIKE', N'S', N'Payslip to display', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PEN1E', N'6', N'N', N'Employee''s pension contribution %', 6, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PEN1R', N'7.5', N'N', N'Employer''s pension contribution %', 6, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PRELIEF', N'1162', N'N', N'Personal relief', 2, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PWDSIZE', N'5', N'N', N'Password size', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'REPFORMNAME', N'TRANSCRIPT', N'S', N'Report Form Name', 2, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'REPORTPATH', N'C:\Projects\SPPayroll\Dev\Reports', N'S', N'Report Output Path', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'RESOURCEPATH', N'C:\SPPayroll\Resource', N'S', N'Resource Path', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SPLANMAX', N'4000', N'N', N'Savings Plan Maximum', 6, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SRELIEF', N'1162', N'N', N'Single Personal Relief', 2, 0)
/****** Object:  Table [dbo].[SecurityQuestions]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SecurityQuestions](
	[PasswordQuestion] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_SecurityQuestions] PRIMARY KEY CLUSTERED 
(
	[PasswordQuestion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schools]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Schools](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Index] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SchoolName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Cellphone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SMTPServer] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SMSGateway] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Schools] ON
INSERT [dbo].[Schools] ([Id], [Index], [SchoolName], [Telephone], [Cellphone], [Email], [Address1], [Address2], [SMTPServer], [SMSGateway]) VALUES (1, N'00012', N'Kiserian Academy', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Schools] OFF
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SchoolClasses](
	[ClassId] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[NextClass] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassTeacher] [int] NULL,
	[Remarks] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_SchoolClasses] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[SchoolClasses] ([ClassId], [NextClass], [ClassName], [ClassTeacher], [Remarks]) VALUES (N'1', N'2', N'1a', 1, N'good')
INSERT [dbo].[SchoolClasses] ([ClassId], [NextClass], [ClassName], [ClassTeacher], [Remarks]) VALUES (N'2', N'3', N'1b', 2, N'good')
/****** Object:  Table [dbo].[RoleRights]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleRights]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RoleRights](
	[RoleRightId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Object] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ObjectType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ObjectRight] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_RoleRights] PRIMARY KEY CLUSTERED 
(
	[RoleRightId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserRoles](
	[RoleId] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleName] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TransactionTypes](
	[TransactionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DebitCredit] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ShortCode] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultAmount] [decimal](19, 4) NULL,
	[DefaultCreditAccount] [int] NULL,
	[DefaultDebitAccount] [int] NULL,
	[DefaultDebitNarrative] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultCreditNarrative] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TxnTypeView] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CommissionType] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FlatRate] [decimal](18, 0) NULL,
	[PercentageRate] [float] NULL,
	[DialogFlag] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] ON
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [DebitCredit], [ShortCode], [Description], [DefaultAmount], [DefaultCreditAccount], [DefaultDebitAccount], [DefaultDebitNarrative], [DefaultCreditNarrative], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag]) VALUES (1, N'D', N'FEE', N'Fees', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [DebitCredit], [ShortCode], [Description], [DefaultAmount], [DefaultCreditAccount], [DefaultDebitAccount], [DefaultDebitNarrative], [DefaultCreditNarrative], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag]) VALUES (2, N'C', N'FP', N'Fee Payment', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TransactionTypes] OFF
/****** Object:  Table [dbo].[TimeTable]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TimeTable](
	[ClassID] [int] NOT NULL,
	[ClassTeacher] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Week] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Period] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Monday] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Tuesday] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wednesday] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Thursday] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Friday] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teachers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TSCNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IDNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Position] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [int] NULL,
	[DateJoined] [datetime] NULL,
	[DateLeft] [datetime] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON
INSERT [dbo].[Teachers] ([TeacherId], [TSCNo], [Name], [IDNo], [Position], [Status], [DateJoined], [DateLeft]) VALUES (1, N'155', N'LUCY QUNCIY', N'654120', N'P2', 2, CAST(0x0000A12100000000 AS DateTime), CAST(0x0000A121012F57B1 AS DateTime))
INSERT [dbo].[Teachers] ([TeacherId], [TSCNo], [Name], [IDNo], [Position], [Status], [DateJoined], [DateLeft]) VALUES (2, N'1201', N'JOAN', N'1002541000', N'P1', 1, CAST(0x0000A12100000000 AS DateTime), CAST(0x0000A121012F20DC AS DateTime))
SET IDENTITY_INSERT [dbo].[Teachers] OFF
/****** Object:  Table [dbo].[Parents]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Parents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Gender] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Occupation] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phonenumber] [int] NULL,
	[Email] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Maritalstatus] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Relationship] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Parents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[MarkSheetStudents]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MarkSheetStudents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamId] [int] NULL,
	[StudentId] [int] NULL,
	[Mark] [int] NULL,
	[LastModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_MarkSheetStudents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]') AND name = N'IX_FK_MarkSheetStudents_FK00')
CREATE NONCLUSTERED INDEX [IX_FK_MarkSheetStudents_FK00] ON [dbo].[MarkSheetStudents] 
(
	[ExamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]') AND name = N'IX_FK_MarkSheetStudents_FK01')
CREATE NONCLUSTERED INDEX [IX_FK_MarkSheetStudents_FK01] ON [dbo].[MarkSheetStudents] 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FirstName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PasswordHash] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordSalt] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordQuestion] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordAnswerHash] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordAnswerSalt] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserType] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProfileReset] [tinyint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'IX_FK_Users_PasswordQuestion')
CREATE NONCLUSTERED INDEX [IX_FK_Users_PasswordQuestion] ON [dbo].[Users] 
(
	[PasswordQuestion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[SubSubjects]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubSubjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SubSubjects](
	[SubsubjectsId] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OutOf] [int] NULL,
	[PassMark] [int] NULL,
	[GroupingFactor] [int] NULL,
 CONSTRAINT [PK_SubSubjects] PRIMARY KEY CLUSTERED 
(
	[SubsubjectsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SubSubjects]') AND name = N'IX_FK_SubSubjects_Subjects')
CREATE NONCLUSTERED INDEX [IX_FK_SubSubjects_Subjects] ON [dbo].[SubSubjects] 
(
	[Subject] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReportGroup] [int] NULL,
	[ResouceFile] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND name = N'IX_FK_Reports_FK00')
CREATE NONCLUSTERED INDEX [IX_FK_Reports_FK00] ON [dbo].[Reports] 
(
	[ReportGroup] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[StudentProgresses]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentProgresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[ExamPeriod] [int] NOT NULL,
	[MeanMarks] [float] NOT NULL,
	[MeanGrade] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClassTeacherRemark] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HeadTeacherRemark] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_StudentProgresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses]') AND name = N'IX_FK_StudentProgresses_Students')
CREATE NONCLUSTERED INDEX [IX_FK_StudentProgresses_Students] ON [dbo].[StudentProgresses] 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[ExamPeriod]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamPeriod]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExamPeriod](
	[ExamPeriodId] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[Term] [int] NOT NULL,
	[ExamType] [int] NOT NULL,
	[LastModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Enabled] [bit] NOT NULL,
	[Closed] [bit] NOT NULL,
 CONSTRAINT [PK_ExamPeriod] PRIMARY KEY CLUSTERED 
(
	[ExamPeriodId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ClassSubjects]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassSubjects](
	[ClassSubjectId] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SubjectCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Teacher] [int] NULL,
 CONSTRAINT [PK_ClassSubjects] PRIMARY KEY CLUSTERED 
(
	[ClassSubjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND name = N'IX_FK_ClassSubjects_Classes')
CREATE NONCLUSTERED INDEX [IX_FK_ClassSubjects_Classes] ON [dbo].[ClassSubjects] 
(
	[ClassId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND name = N'IX_FK_ClassSubjects_Subjects')
CREATE NONCLUSTERED INDEX [IX_FK_ClassSubjects_Subjects] ON [dbo].[ClassSubjects] 
(
	[SubjectCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND name = N'IX_FK_ClassSubjects_Teachers')
CREATE NONCLUSTERED INDEX [IX_FK_ClassSubjects_Teachers] ON [dbo].[ClassSubjects] 
(
	[Teacher] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Attendances]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendances]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Attendances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SchoolDate] [datetime] NULL,
	[Student] [int] NULL,
	[Attended] [bit] NOT NULL,
	[ReasonForNotAttending] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Attendances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Attendances]') AND name = N'IX_FK_Attendance_FK00')
CREATE NONCLUSTERED INDEX [IX_FK_Attendance_FK00] ON [dbo].[Attendances] 
(
	[Student] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AccountName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccountType] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BookBalance] [decimal](19, 4) NOT NULL,
	[ClearedBalance] [decimal](19, 4) NOT NULL,
	[Branch] [int] NULL,
	[Limit] [decimal](19, 4) NOT NULL,
	[AccruedInt] [decimal](19, 4) NOT NULL,
	[InterestRate] [float] NOT NULL,
	[Bal30] [decimal](19, 4) NULL,
	[Bal60] [decimal](19, 4) NULL,
	[Bal90] [decimal](19, 4) NULL,
	[BalOver90] [decimal](19, 4) NULL,
	[IntRate30] [float] NULL,
	[IntRate60] [float] NULL,
	[IntRate90] [float] NULL,
	[IntRateOver90] [float] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND name = N'IX_FK_Accounts_Customer')
CREATE NONCLUSTERED INDEX [IX_FK_Accounts_Customer] ON [dbo].[Accounts] 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountType], [BookBalance], [ClearedBalance], [Branch], [Limit], [AccruedInt], [InterestRate], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90]) VALUES (1, 1, N'School fees', N'11', CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), 12, CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), 0, CAST(0.0000 AS Decimal(19, 4)), CAST(20000.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), 0, 0, 0, 0)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountType], [BookBalance], [ClearedBalance], [Branch], [Limit], [AccruedInt], [InterestRate], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90]) VALUES (2, 1, N'Library Fund', N'22', CAST(200.0000 AS Decimal(19, 4)), CAST(2200.0000 AS Decimal(19, 4)), 0, CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), 0, CAST(2300.0000 AS Decimal(19, 4)), CAST(325500.0000 AS Decimal(19, 4)), CAST(36200.0000 AS Decimal(19, 4)), CAST(36500.0000 AS Decimal(19, 4)), 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
/****** Object:  Table [dbo].[GradingSystemDet]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GradingSystemDet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GradingSystemId] [int] NOT NULL,
	[LMark] [float] NOT NULL,
	[UMark] [float] NOT NULL,
	[Grade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_GradingSystemDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[GradingSystemDet] ON
INSERT [dbo].[GradingSystemDet] ([ID], [GradingSystemId], [LMark], [UMark], [Grade]) VALUES (1, 2, 80, 100, N'A         ')
INSERT [dbo].[GradingSystemDet] ([ID], [GradingSystemId], [LMark], [UMark], [Grade]) VALUES (2, 2, 70, 79, N'A-        ')
INSERT [dbo].[GradingSystemDet] ([ID], [GradingSystemId], [LMark], [UMark], [Grade]) VALUES (3, 2, 60, 69, N'B+        ')
INSERT [dbo].[GradingSystemDet] ([ID], [GradingSystemId], [LMark], [UMark], [Grade]) VALUES (4, 2, 50, 59, N'B         ')
INSERT [dbo].[GradingSystemDet] ([ID], [GradingSystemId], [LMark], [UMark], [Grade]) VALUES (5, 2, 40, 49, N'B-        ')
INSERT [dbo].[GradingSystemDet] ([ID], [GradingSystemId], [LMark], [UMark], [Grade]) VALUES (6, 2, 30, 39, N'C+        ')
INSERT [dbo].[GradingSystemDet] ([ID], [GradingSystemId], [LMark], [UMark], [Grade]) VALUES (8, 2, 20, 29, N'C         ')
INSERT [dbo].[GradingSystemDet] ([ID], [GradingSystemId], [LMark], [UMark], [Grade]) VALUES (9, 2, 0, 19, N'D         ')
SET IDENTITY_INSERT [dbo].[GradingSystemDet] OFF
/****** Object:  Table [dbo].[RegisteredExams]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RegisteredExams](
	[RegdExamId] [int] IDENTITY(1,1) NOT NULL,
	[ExamPeriodId] [int] NOT NULL,
	[ExamDate] [datetime] NULL,
	[ClassSubjectId] [int] NULL,
	[Room] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Invilgilator] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Enabled] [bit] NOT NULL,
	[Closed] [bit] NOT NULL,
 CONSTRAINT [PK_RegisteredExams] PRIMARY KEY CLUSTERED 
(
	[RegdExamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[AccountID] [int] NOT NULL,
	[Amount] [decimal](19, 4) NOT NULL,
	[Narrative] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserID] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Authorizer] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StatementFlag] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostDate] [datetime] NOT NULL,
	[ValueDate] [datetime] NULL,
	[RecordDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND name = N'IX_FK_Transactions_FK00')
CREATE NONCLUSTERED INDEX [IX_FK_Transactions_FK00] ON [dbo].[Transactions] 
(
	[AccountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND name = N'IX_FK_Transactions_FK01')
CREATE NONCLUSTERED INDEX [IX_FK_Transactions_FK01] ON [dbo].[Transactions] 
(
	[TransactionTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [Narrative], [UserID], [Authorizer], [StatementFlag], [PostDate], [ValueDate], [RecordDate]) VALUES (2, 1, 1, CAST(25040.0000 AS Decimal(19, 4)), N'Fees ', NULL, NULL, NULL, CAST(0x00009FCC00000000 AS DateTime), CAST(0x00009FCC00000000 AS DateTime), CAST(0x00009FCC00000000 AS DateTime))
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [Narrative], [UserID], [Authorizer], [StatementFlag], [PostDate], [ValueDate], [RecordDate]) VALUES (3, 1, 1, CAST(-6500.0000 AS Decimal(19, 4)), N'Fee Payemt', NULL, NULL, NULL, CAST(0x00009FCD00000000 AS DateTime), CAST(0x00009FCD00000000 AS DateTime), CAST(0x00009FCD00000000 AS DateTime))
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [Narrative], [UserID], [Authorizer], [StatementFlag], [PostDate], [ValueDate], [RecordDate]) VALUES (5, 2, 1, CAST(-13000.0000 AS Decimal(19, 4)), N'Fee Payment', NULL, NULL, NULL, CAST(0x00009FEA00000000 AS DateTime), CAST(0x00009FEA00000000 AS DateTime), CAST(0x00009FEA00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Transactions] OFF
/****** Object:  View [dbo].[vwTermlyFeeStatement]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwTermlyFeeStatement]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwTermlyFeeStatement]
AS
SELECT        dbo.Schools.SchoolName, dbo.Schools.Address1, dbo.Schools.Address2, dbo.Schools.Telephone, dbo.Schools.Email, dbo.Schools.Cellphone, 
                         dbo.Students.StudentSurName, dbo.Students.StudentOtherNames, dbo.Students.StudentAddress, dbo.Students.Phone, dbo.Students.Id, dbo.Students.AdminNo, 
                         dbo.Transactions.Amount, dbo.Transactions.Narrative, dbo.Transactions.PostDate, dbo.Transactions.ValueDate, dbo.Transactions.RecordDate, 
                         dbo.Transactions.Authorizer
FROM            dbo.Students INNER JOIN
                         dbo.Schools ON dbo.Students.Id = dbo.Schools.Id CROSS JOIN
                         dbo.Transactions
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vwTermlyFeeStatement', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[48] 4[14] 2[9] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -101
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Students"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Schools"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 114
               Right = 415
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Transactions"
            Begin Extent = 
               Top = 118
               Left = 39
               Bottom = 259
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwTermlyFeeStatement'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vwTermlyFeeStatement', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwTermlyFeeStatement'
GO
/****** Object:  Table [dbo].[StudentExams]    Script Date: 12/29/2012 16:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentExams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegdExamId] [int] NULL,
	[StudentId] [int] NULL,
	[Mark] [int] NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_StudentExams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  ForeignKey [FK_Accounts_Customer]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Customer]
GO
/****** Object:  ForeignKey [FK_Attendance_FK00]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendance_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_FK00] FOREIGN KEY([Student])
REFERENCES [dbo].[Students] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendance_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [FK_Attendance_FK00]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Classes]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Classes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ClassSubjects_Classes] FOREIGN KEY([ClassId])
REFERENCES [dbo].[SchoolClasses] ([ClassId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Classes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] CHECK CONSTRAINT [FK_ClassSubjects_Classes]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Subjects]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ClassSubjects_Subjects] FOREIGN KEY([SubjectCode])
REFERENCES [dbo].[Subjects] ([ShortCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] CHECK CONSTRAINT [FK_ClassSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Teachers]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Teachers]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ClassSubjects_Teachers] FOREIGN KEY([Teacher])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Teachers]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] CHECK CONSTRAINT [FK_ClassSubjects_Teachers]
GO
/****** Object:  ForeignKey [FK_ExamPeriod_ExamTypes]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExamPeriod_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExamPeriod]'))
ALTER TABLE [dbo].[ExamPeriod]  WITH CHECK ADD  CONSTRAINT [FK_ExamPeriod_ExamTypes] FOREIGN KEY([ExamType])
REFERENCES [dbo].[ExamTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExamPeriod_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExamPeriod]'))
ALTER TABLE [dbo].[ExamPeriod] CHECK CONSTRAINT [FK_ExamPeriod_ExamTypes]
GO
/****** Object:  ForeignKey [FK_GradingSystemDet_GradingSystems]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]'))
ALTER TABLE [dbo].[GradingSystemDet]  WITH CHECK ADD  CONSTRAINT [FK_GradingSystemDet_GradingSystems] FOREIGN KEY([GradingSystemId])
REFERENCES [dbo].[GradingSystems] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]'))
ALTER TABLE [dbo].[GradingSystemDet] CHECK CONSTRAINT [FK_GradingSystemDet_GradingSystems]
GO
/****** Object:  ForeignKey [FK_MarkSheetStudents_FK00]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents]  WITH CHECK ADD  CONSTRAINT [FK_MarkSheetStudents_FK00] FOREIGN KEY([ExamId])
REFERENCES [dbo].[MarkSheetExams] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents] CHECK CONSTRAINT [FK_MarkSheetStudents_FK00]
GO
/****** Object:  ForeignKey [FK_MarkSheetStudents_FK01]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents]  WITH CHECK ADD  CONSTRAINT [FK_MarkSheetStudents_FK01] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents] CHECK CONSTRAINT [FK_MarkSheetStudents_FK01]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ClassSubjects]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ClassSubjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredExams_ClassSubjects] FOREIGN KEY([ClassSubjectId])
REFERENCES [dbo].[ClassSubjects] ([ClassSubjectId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ClassSubjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] CHECK CONSTRAINT [FK_RegisteredExams_ClassSubjects]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ExamPeriod]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredExams_ExamPeriod] FOREIGN KEY([ExamPeriodId])
REFERENCES [dbo].[ExamPeriod] ([ExamPeriodId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] CHECK CONSTRAINT [FK_RegisteredExams_ExamPeriod]
GO
/****** Object:  ForeignKey [FK_Reports_FK00]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_FK00] FOREIGN KEY([ReportGroup])
REFERENCES [dbo].[ReportGroups] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_FK00]
GO
/****** Object:  ForeignKey [FK_StudentExams_RegisteredExams]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams]  WITH CHECK ADD  CONSTRAINT [FK_StudentExams_RegisteredExams] FOREIGN KEY([RegdExamId])
REFERENCES [dbo].[RegisteredExams] ([RegdExamId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] CHECK CONSTRAINT [FK_StudentExams_RegisteredExams]
GO
/****** Object:  ForeignKey [FK_StudentProgresses_Students]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses]  WITH CHECK ADD  CONSTRAINT [FK_StudentProgresses_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses] CHECK CONSTRAINT [FK_StudentProgresses_Students]
GO
/****** Object:  ForeignKey [FK_SubSubjects_Subjects]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects]  WITH CHECK ADD  CONSTRAINT [FK_SubSubjects_Subjects] FOREIGN KEY([Subject])
REFERENCES [dbo].[Subjects] ([ShortCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects] CHECK CONSTRAINT [FK_SubSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_Transactions_FK00]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_FK00] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_FK00]
GO
/****** Object:  ForeignKey [FK_Transactions_FK01]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_FK01] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[TransactionTypes] ([TransactionTypeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_FK01]
GO
/****** Object:  ForeignKey [FK_Users_PasswordQuestion]    Script Date: 12/29/2012 16:27:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PasswordQuestion] FOREIGN KEY([PasswordQuestion])
REFERENCES [dbo].[SecurityQuestions] ([PasswordQuestion])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PasswordQuestion]
GO
