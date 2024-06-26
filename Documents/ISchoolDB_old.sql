/****** Object:  ForeignKey [FK_Accounts_Customer]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_Customer]
GO
/****** Object:  ForeignKey [FK_Attendances_Students]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendances_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances] DROP CONSTRAINT [FK_Attendances_Students]
GO
/****** Object:  ForeignKey [FK_BankBranch_Banks]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[BankBranch]'))
ALTER TABLE [dbo].[BankBranch] DROP CONSTRAINT [FK_BankBranch_Banks]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Classes]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Classes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Classes]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Subjects]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Teachers]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Teachers]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Teachers]
GO
/****** Object:  ForeignKey [FK_ExamPeriod_ExamTypes]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExamPeriod_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExamPeriod]'))
ALTER TABLE [dbo].[ExamPeriod] DROP CONSTRAINT [FK_ExamPeriod_ExamTypes]
GO
/****** Object:  ForeignKey [FK_GradingSystemDet_GradingSystems]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]'))
ALTER TABLE [dbo].[GradingSystemDet] DROP CONSTRAINT [FK_GradingSystemDet_GradingSystems]
GO
/****** Object:  ForeignKey [FK_MarkSheetStudents_FK00]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents] DROP CONSTRAINT [FK_MarkSheetStudents_FK00]
GO
/****** Object:  ForeignKey [FK_ProgrammeCourses_Programmes]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeCourses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeCourses]'))
ALTER TABLE [dbo].[ProgrammeCourses] DROP CONSTRAINT [FK_ProgrammeCourses_Programmes]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ClassSubjects]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ClassSubjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_ClassSubjects]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ExamPeriod]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_ExamPeriod]
GO
/****** Object:  ForeignKey [FK_Reports_FK00]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_Reports_FK00]
GO
/****** Object:  ForeignKey [FK_SchoolClasses_Programmes]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SchoolClasses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses] DROP CONSTRAINT [FK_SchoolClasses_Programmes]
GO
/****** Object:  ForeignKey [FK_StudentExams_RegisteredExams]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] DROP CONSTRAINT [FK_StudentExams_RegisteredExams]
GO
/****** Object:  ForeignKey [FK_StudentExams_Students]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] DROP CONSTRAINT [FK_StudentExams_Students]
GO
/****** Object:  ForeignKey [FK_StudentProgresses_Students1]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students1]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses] DROP CONSTRAINT [FK_StudentProgresses_Students1]
GO
/****** Object:  ForeignKey [FK_SubSubjects_Subjects]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects] DROP CONSTRAINT [FK_SubSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_Transactions_FK00]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_FK00]
GO
/****** Object:  ForeignKey [FK_Transactions_FK01]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_FK01]
GO
/****** Object:  ForeignKey [FK_Users_PasswordQuestion]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_PasswordQuestion]
GO
/****** Object:  Table [dbo].[StudentExams]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND type in (N'U'))
DROP TABLE [dbo].[StudentExams]
GO
/****** Object:  View [dbo].[vwTermlyFeeStatement]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwTermlyFeeStatement]'))
DROP VIEW [dbo].[vwTermlyFeeStatement]
GO
/****** Object:  Table [dbo].[RegisteredExams]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND type in (N'U'))
DROP TABLE [dbo].[RegisteredExams]
GO
/****** Object:  Table [dbo].[ClassSubjects]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND type in (N'U'))
DROP TABLE [dbo].[ClassSubjects]
GO
/****** Object:  View [dbo].[vwBankBranches]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwBankBranches]'))
DROP VIEW [dbo].[vwBankBranches]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND type in (N'U'))
DROP TABLE [dbo].[Transactions]
GO
/****** Object:  Table [dbo].[SubSubjects]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubSubjects]') AND type in (N'U'))
DROP TABLE [dbo].[SubSubjects]
GO
/****** Object:  View [dbo].[vwStatement]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwStatement]'))
DROP VIEW [dbo].[vwStatement]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[StudentProgresses]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses]') AND type in (N'U'))
DROP TABLE [dbo].[StudentProgresses]
GO
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND type in (N'U'))
DROP TABLE [dbo].[SchoolClasses]
GO
/****** Object:  Table [dbo].[ExamPeriod]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamPeriod]') AND type in (N'U'))
DROP TABLE [dbo].[ExamPeriod]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[Accounts]
GO
/****** Object:  Table [dbo].[Attendances]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendances]') AND type in (N'U'))
DROP TABLE [dbo].[Attendances]
GO
/****** Object:  Table [dbo].[BankBranch]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankBranch]') AND type in (N'U'))
DROP TABLE [dbo].[BankBranch]
GO
/****** Object:  Table [dbo].[MarkSheetStudents]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]') AND type in (N'U'))
DROP TABLE [dbo].[MarkSheetStudents]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
DROP TABLE [dbo].[Reports]
GO
/****** Object:  Table [dbo].[GradingSystemDet]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]') AND type in (N'U'))
DROP TABLE [dbo].[GradingSystemDet]
GO
/****** Object:  Table [dbo].[ProgrammeCourses]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeCourses]') AND type in (N'U'))
DROP TABLE [dbo].[ProgrammeCourses]
GO
/****** Object:  Table [dbo].[Programmes]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programmes]') AND type in (N'U'))
DROP TABLE [dbo].[Programmes]
GO
/****** Object:  Table [dbo].[GradingSystems]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystems]') AND type in (N'U'))
DROP TABLE [dbo].[GradingSystems]
GO
/****** Object:  Table [dbo].[ISUserLogin]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ISUserLogin]') AND type in (N'U'))
DROP TABLE [dbo].[ISUserLogin]
GO
/****** Object:  Table [dbo].[MarksheetArchives]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarksheetArchives]') AND type in (N'U'))
DROP TABLE [dbo].[MarksheetArchives]
GO
/****** Object:  Table [dbo].[MarkSheetExams]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetExams]') AND type in (N'U'))
DROP TABLE [dbo].[MarkSheetExams]
GO
/****** Object:  Table [dbo].[RoleRights]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleRights]') AND type in (N'U'))
DROP TABLE [dbo].[RoleRights]
GO
/****** Object:  Table [dbo].[Parents]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parents]') AND type in (N'U'))
DROP TABLE [dbo].[Parents]
GO
/****** Object:  Table [dbo].[ReportGroups]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportGroups]') AND type in (N'U'))
DROP TABLE [dbo].[ReportGroups]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banks]') AND type in (N'U'))
DROP TABLE [dbo].[Banks]
GO
/****** Object:  Table [dbo].[ClassStreams]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassStreams]') AND type in (N'U'))
DROP TABLE [dbo].[ClassStreams]
GO
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamTypes]') AND type in (N'U'))
DROP TABLE [dbo].[ExamTypes]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schools]') AND type in (N'U'))
DROP TABLE [dbo].[Schools]
GO
/****** Object:  Table [dbo].[SecurityQuestions]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestions]') AND type in (N'U'))
DROP TABLE [dbo].[SecurityQuestions]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
DROP TABLE [dbo].[Settings]
GO
/****** Object:  Table [dbo].[SettingsGroup]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SettingsGroup]') AND type in (N'U'))
DROP TABLE [dbo].[SettingsGroup]
GO
/****** Object:  Table [dbo].[SettingsGroups]    Script Date: 01/05/2013 15:03:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SettingsGroups]') AND type in (N'U'))
DROP TABLE [dbo].[SettingsGroups]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
DROP TABLE [dbo].[Students]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
DROP TABLE [dbo].[Subjects]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teachers]') AND type in (N'U'))
DROP TABLE [dbo].[Teachers]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTable]') AND type in (N'U'))
DROP TABLE [dbo].[TimeTable]
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionTypes]') AND type in (N'U'))
DROP TABLE [dbo].[TransactionTypes]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 01/05/2013 15:03:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 01/05/2013 15:03:30 ******/
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
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 01/05/2013 15:03:30 ******/
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
	[ForcePost] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] ON
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [DebitCredit], [ShortCode], [Description], [DefaultAmount], [DefaultCreditAccount], [DefaultDebitAccount], [DefaultDebitNarrative], [DefaultCreditNarrative], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [ForcePost]) VALUES (1, N'D', N'FEE', N'Fees', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [DebitCredit], [ShortCode], [Description], [DefaultAmount], [DefaultCreditAccount], [DefaultDebitAccount], [DefaultDebitNarrative], [DefaultCreditNarrative], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [ForcePost]) VALUES (2, N'C', N'FP', N'Fee Payment', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TransactionTypes] OFF
/****** Object:  Table [dbo].[TimeTable]    Script Date: 01/05/2013 15:03:30 ******/
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
/****** Object:  Table [dbo].[Teachers]    Script Date: 01/05/2013 15:03:30 ******/
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
	[DateJoined] [date] NULL,
	[DateLeft] [date] NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON
INSERT [dbo].[Teachers] ([TeacherId], [TSCNo], [Name], [IDNo], [Position], [Status], [DateJoined], [DateLeft], [Email]) VALUES (1, N'3456', N'MARYANNE WANJA', N'45423565', N'HEAD OF DEPARTMENT COMMUNICATION', 1, CAST(0x74360B00 AS Date), CAST(0x81360B00 AS Date), N'maryannewanja@gmail.com')
INSERT [dbo].[Teachers] ([TeacherId], [TSCNo], [Name], [IDNo], [Position], [Status], [DateJoined], [DateLeft], [Email]) VALUES (2, N'79878', N'KIM KINGORI', N'46456456', N'HEAD TEACHER', 2, CAST(0x74360B00 AS Date), CAST(0x7E360B00 AS Date), N'kimkingori@yahoo.com')
INSERT [dbo].[Teachers] ([TeacherId], [TSCNo], [Name], [IDNo], [Position], [Status], [DateJoined], [DateLeft], [Email]) VALUES (3, N'42342', N'MATIN MONIGI', N'324234324', N'HOD ICT', 2, CAST(0x7F360B00 AS Date), CAST(0x7F360B00 AS Date), N'matinkingori@gmail.com')
INSERT [dbo].[Teachers] ([TeacherId], [TSCNo], [Name], [IDNo], [Position], [Status], [DateJoined], [DateLeft], [Email]) VALUES (4, N'3534535', N'STEVESON JUMA', N'345345623', N'HOD BIT', 3, CAST(0x7F360B00 AS Date), CAST(0x7F360B00 AS Date), N'stevej@yahoo.com')
INSERT [dbo].[Teachers] ([TeacherId], [TSCNo], [Name], [IDNo], [Position], [Status], [DateJoined], [DateLeft], [Email]) VALUES (5, N'3424234324324324323423423423', N'GEOGINA SHIRU', N'34234235325345', N'CLASS TEACHER', 1, CAST(0xAC240B00 AS Date), CAST(0x7F360B00 AS Date), N'georginashiru@yahoo.com')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
/****** Object:  Table [dbo].[Subjects]    Script Date: 01/05/2013 15:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Subjects](
	[ShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OutOf] [int] NULL,
	[PassMark] [int] NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ROrder] [int] NULL,
	[Remarks] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[ShortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Students]    Script Date: 01/05/2013 15:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SchoolId] [int] NOT NULL,
	[AdminNo] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentSurName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentOtherNames] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentAddress] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CurrentClass] [int] NULL,
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
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModifiedTime] [datetime] NULL,
	[GLAccount] [int] NULL,
	[CustomerID] [int] NULL,
	[Term1MeanGrade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term2MeanGrade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term3MeanGrade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Students] ON
INSERT [dbo].[Students] ([Id], [SchoolId], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime], [GLAccount], [CustomerID], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade]) VALUES (1, 20, N'768957867567845', N'SASHA', N'CHEPKITO', N'4456456, KAKAMEGA', N'0723456543', CAST(0x00008ED200000000 AS DateTime), N'F', N'sashchp@gmail.com', 2, N'www.facebook.com/sashachepkito', N'HHHHHHHHH', N'HHHHHHHHHHHHH', N'BBBBBBBBBBBBBB', N'jhhjhj', N'HHHHHHHHH', N'HHHHHHHHH', N'98JJ989J', N'9JH889', N'9JJJ8J89JU89', CAST(0x0000A13800000000 AS DateTime), N'GEORGINA DOMBA', N'IBNUUUH', N'IUIHUHHH', N'JH9J89HJ89', N'9J98J89J98', N'oij9898j89j89j89j98j898jhyybybyubybyubbbybbbbbbbbbubyubyub', N'handball', N'drama', N'swimming', N'good morals, excellent in academics,have good leadership skillz.', N'A         ', CAST(0x0000A13A00000000 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([Id], [SchoolId], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime], [GLAccount], [CustomerID], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade]) VALUES (2, 20, N'456745676576457', N'MATIN', N'KARANJA', N'565646, DANDORA', N'0723546756', CAST(0x0000A13800000000 AS DateTime), N'M', N'matorijak@yahoo.com', 1, N'www.facebook.com/matinkaranja', N'VVVVVVVVVVVV', N'BBBBBBBBBBB', N'', N'', N'JJJJJJJJJJJJ', N'GGGGGGGGGGGGGGGG', N'', N'', N'', CAST(0x0000A13800000000 AS DateTime), N'WILLLIAM SAITOTI', N'', N'', N'', N'', N'', N'music festival', N'football', N'rugby', N'excellent in academics, good in sports and has good leadership  skillz.', N'A         ', CAST(0x0000A13A00000000 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([Id], [SchoolId], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime], [GLAccount], [CustomerID], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade]) VALUES (3, 20, N'334535435435345', N'SADRA', N'ACHIENG', N'45345, LIMURU', N'0725478965', CAST(0x0000A13A00000000 AS DateTime), N'M', N'sandra@yahoo.com', 1, NULL, N'KALONZO KIVETI', N'0712587456', NULL, NULL, N'MIRRIAM KIVETI', N'0726985478', NULL, NULL, NULL, CAST(0x0000A13A00000000 AS DateTime), N'JANET MROMBO', NULL, NULL, NULL, NULL, NULL, N'drama', NULL, NULL, N'excellent in academics', N'A         ', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([Id], [SchoolId], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime], [GLAccount], [CustomerID], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade]) VALUES (4, 20, N'864489478484848', N'RICHARD', N'TUVA', N'36636, LODWANI', N'0713456789', CAST(0x0000A13A00000000 AS DateTime), N'M', N'richardtuva@gmail.com', 1, NULL, N'JAMES KINGORI', N'0723456785', NULL, NULL, N'RACHEL KINGORI', N'0734564333', NULL, NULL, NULL, CAST(0x0000A13A00000000 AS DateTime), N'SAMSON JESHI', NULL, NULL, NULL, NULL, NULL, N'drama', NULL, NULL, N'excellent leadership skillz. good in sports.', N'A         ', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([Id], [SchoolId], [AdminNo], [StudentSurName], [StudentOtherNames], [StudentAddress], [Phone], [DateOfBirth], [Gender], [Email], [CurrentClass], [Homepage], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [ResidencePhone], [ResidenceAddress], [AdmissionDate], [AdmittedBy], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricala1], [ExtraCurricala2], [ExtraCurricala3], [Remarks], [Status], [LastModifiedTime], [GLAccount], [CustomerID], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade]) VALUES (5, 20, N'234234234534553', N'FAITH', N'KINYA', N'43563346, NKUBU', N'0713453890', CAST(0x00007F8200000000 AS DateTime), N'F', N'faithk@yahoo.com', 2, N'www.facebok.com/faithkinya', N'JAMES OTACH', N'0765980654', N'5453-65643635523', N'jamesotach@gmail.com', N'DAINA OTACH', N'0754321234', N'3221-231231233', N'3213-213232424', N'2324, RUNDA', CAST(0x0000A13A00000000 AS DateTime), N'DENNIS BURUNDI', N'1', N'HIGHRIDGE HIGH SCHOOL', N'0734567432', N'345325, HILLCKREST AVENUE,  MOMBASA', N'expelled for skiving out of school at nyt.', N'music festival', N'drama', N'football', N'excellent in academics, good in sports and good leadershipskillz.', N'A         ', CAST(0x0000A13A00000000 AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
/****** Object:  Table [dbo].[SettingsGroups]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[SettingsGroup]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SettingsGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SettingsGroup](
	[Id] [int] NOT NULL,
	[GroupName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Parent] [int] NOT NULL,
 CONSTRAINT [PK_SettingsGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (1, N'Setttings', 0)
INSERT [dbo].[SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (2, N'Statutory Computations', 1)
INSERT [dbo].[SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (3, N'General', 1)
INSERT [dbo].[SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (4, N'NSSF', 6)
INSERT [dbo].[SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (5, N'PAYE', 2)
INSERT [dbo].[SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (6, N'Pension', 2)
INSERT [dbo].[SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (7, N'Security', 1)
/****** Object:  Table [dbo].[Settings]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[SecurityQuestions]    Script Date: 01/05/2013 15:03:29 ******/
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
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'In what city is your vacation home? (Enter full name of city)')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'In what city was your father born? (Enter full name of city)')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'In what city was your high school? (Enter full name of city)')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'In what city were you married? (Enter full name of city)')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What is the first name of your oldest nephew?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What is the first name of your oldest niece?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What is the name of the first company you worked for?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What is your best friend''s first name?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What is your father''s middle name?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What is your maternal grandfather''s first name?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What is your maternal grandmother''s first name?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What is your paternal grandmother''s first name?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What was the first name of your first manager?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What was the name of your first girlfriend/boyfriend?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What was the name of your first pet?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What was the name of your High School?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What was the nickname of your grandfather?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What was your dream job as a child?')
INSERT [dbo].[SecurityQuestions] ([PasswordQuestion]) VALUES (N'What was your high school mascot?')
/****** Object:  Table [dbo].[Schools]    Script Date: 01/05/2013 15:03:29 ******/
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
INSERT [dbo].[Schools] ([Id], [Index], [SchoolName], [Telephone], [Cellphone], [Email], [Address1], [Address2], [SMTPServer], [SMSGateway]) VALUES (18, N'1', N'BRAEBURN', N'0203456543', N'0716789900', N'info@braeburnschools.co.ke', N'46545, LANGATA', NULL, NULL, NULL)
INSERT [dbo].[Schools] ([Id], [Index], [SchoolName], [Telephone], [Cellphone], [Email], [Address1], [Address2], [SMTPServer], [SMSGateway]) VALUES (19, N'2', N'RIARA GROUP OF SCHOOLS', N'024567890997', N'0713432123', N'info@riaragroupofschools.co.ke', N'576575, LINET ROAD ,  KILIMANI', NULL, NULL, NULL)
INSERT [dbo].[Schools] ([Id], [Index], [SchoolName], [Telephone], [Cellphone], [Email], [Address1], [Address2], [SMTPServer], [SMSGateway]) VALUES (20, N'3', N'ST.NICHOLAS', N'023478980099', N'0723456789', N'info@stnicholasschools.co.ke', N'46456, NGONG ROAD', NULL, NULL, NULL)
INSERT [dbo].[Schools] ([Id], [Index], [SchoolName], [Telephone], [Cellphone], [Email], [Address1], [Address2], [SMTPServer], [SMSGateway]) VALUES (21, N'4', N'MAKINI', N'0234455656454', N'0717345654', N'info@makini.co.ke', N'46645, MURINGA ROAD KILIMANI', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Schools] OFF
/****** Object:  Table [dbo].[Customers]    Script Date: 01/05/2013 15:03:29 ******/
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
	[StudentId] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (1, N'Joan', N'box 4125', N'072544200', N'joan@softwareproviders.co.ke', 11, N'Njoroge', N'box 224550', N'07225506345', N'njoroge@kk.com', NULL)
INSERT [dbo].[Customers] ([CustomerId], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (2, N'James', N'box 2654', N'07321540', N'james@verylonongemailaddress.com', 136, N'Father John', N'box 23541', N'07361000', N'fatherjorhn@catholic.com', NULL)
SET IDENTITY_INSERT [dbo].[Customers] OFF
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[ClassStreams]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassStreams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassStreams](
	[ClassStreamId] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SchoolClass] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ClassStreams] PRIMARY KEY CLUSTERED 
(
	[ClassStreamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Banks](
	[BankCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BankName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED 
(
	[BankCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'01', N'Kenya Commercial Bank Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'02', N'Standard Chartered Bank')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'03', N'Barclays Bank of Kenya Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'05', N'Bank of India')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'06', N'Bank of Baroda (Kenya) Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'07', N'Commercial Bank of Africa Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'08', N'Habib Bank Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'09', N'Central Bank of Kenya')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'10', N'Prime Bank Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'11', N'Co-operative Bank Of Kenya')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'12', N'National Bank of Kenya')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'14', N'Oriental Commercial Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'16', N'Citi Bank')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'17', N'Habib Bank')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'18', N'Middle East Bank')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'19', N'Bank of Africa Kenya Ltd.')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'20', N' Dubai Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'23', N'Consolidated Bank of Kenya')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'25', N' Credit Bank Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'26', N'Trans-National Bank Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'30', N'Chase Bank')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'31', N'Cfc Stanbic Bank ')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'35', N' African BankingCorporation Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'39', N'Imperial Bank Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'41', N'NIC Bank Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'42', N' Giro Commercial')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'43', N'Ecobank Kenya Limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'49', N'Equatorial Commercial Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'50', N'Paramount Universal Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'51', N'Jamii Bora Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'53', N'Fina Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'54', N'Victoria Commercial Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'55', N'Guardian Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'57', N'I & M Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'59', N'Development Bank of Kenya Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'60', N'Fidelity Commercial Bank Ltd.')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'63', N'Diamond Trust Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'66', N'K-Rep Bank limited')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'68', N'Equity Bank ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'70', N'Family Bank ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'72', N'Gulf African Bank')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'74', N'First Community Bank Ltd')
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'76', N'UBA Kenya Bank')
/****** Object:  Table [dbo].[ReportGroups]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[Parents]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[RoleRights]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[MarkSheetExams]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[MarksheetArchives]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[ISUserLogin]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[GradingSystems]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[Programmes]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programmes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Programmes](
	[ProgrammeId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Programmes] PRIMARY KEY CLUSTERED 
(
	[ProgrammeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ProgrammeCourses]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeCourses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProgrammeCourses](
	[ProgrammeCourseId] [int] IDENTITY(1,1) NOT NULL,
	[ProgrammeId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CourseId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Year] [int] NULL,
	[Semester] [int] NULL,
 CONSTRAINT [PK_ProgrammeCourses] PRIMARY KEY CLUSTERED 
(
	[ProgrammeCourseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeCourses]') AND name = N'IX_FK_ProgrammeCourses_Programmes')
CREATE NONCLUSTERED INDEX [IX_FK_ProgrammeCourses_Programmes] ON [dbo].[ProgrammeCourses] 
(
	[ProgrammeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[GradingSystemDet]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[Reports]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[MarkSheetStudents]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[BankBranch]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankBranch]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BankBranch](
	[BankSortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BranchCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Bank] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BranchName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_BankBranch] PRIMARY KEY CLUSTERED 
(
	[BankSortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01091', N'091', N'01', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01092', N'092', N'01', N'CPC')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01094', N'094', N'01', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01095', N'095', N'01', N'Wote')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01100', N'100', N'01', N'Moi Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01101', N'101', N'01', N'Kipande House')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01102', N'102', N'01', N'Treasury Square')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01103', N'103', N'01', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01104', N'104', N'01', N'KICC')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01105', N'105', N'01', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01106', N'106', N'01', N'Kericho')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01107', N'107', N'01', N'Tom Mboya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01108', N'108', N'01', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01109', N'109', N'01', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01110', N'110', N'01', N'Kakamega')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01111', N'111', N'01', N'Kilindini')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01112', N'112', N'01', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01113', N'113', N'01', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01114', N'114', N'01', N'River Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01115', N'115', N'01', N'Muranga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01116', N'116', N'01', N'Embu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01117', N'117', N'01', N'Kangema')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01119', N'119', N'01', N'Kiambu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01120', N'120', N'01', N'Karatina')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01121', N'121', N'01', N'Siaya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01122', N'122', N'01', N'Nyahururu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01123', N'123', N'01', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01124', N'124', N'01', N'Mumias')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01125', N'125', N'01', N'Nanyuki')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01127', N'127', N'01', N'Moyale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01129', N'129', N'01', N'Kikuyu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01130', N'130', N'01', N'Tala')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01131', N'131', N'01', N'Kajiado')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01133', N'133', N'01', N'Custody Services')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01134', N'134', N'01', N'Matuu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01135', N'135', N'01', N'Kitui')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01136', N'136', N'01', N'Mvita')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01137', N'137', N'01', N'Jogoo Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01140', N'140', N'01', N'Marsabit')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01141', N'141', N'01', N'Sarit Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01142', N'142', N'01', N'Loitokitok')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01143', N'143', N'01', N'Nandi Hills')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01144', N'144', N'01', N'Lodwar')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01145', N'145', N'01', N'UN Gigiri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01146', N'146', N'01', N'Hola')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01147', N'147', N'01', N'Ruiru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01148', N'148', N'01', N'Mwingi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01149', N'149', N'01', N'Kitale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01150', N'150', N'01', N'Mandera')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01151', N'151', N'01', N'Kapenguria')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01152', N'152', N'01', N'Kabarnet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01153', N'153', N'01', N'Wajir')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01154', N'154', N'01', N'Maralal')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01155', N'155', N'01', N'Limuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01157', N'157', N'01', N'Ukunda')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01161', N'161', N'01', N'Ongata Rongai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01162', N'162', N'01', N'Kitengela')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01163', N'163', N'01', N'Eldama Ravine')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01164', N'164', N'01', N'Kibwezi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01166', N'166', N'01', N'Kapsabet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01167', N'167', N'01', N'University Way')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01168', N'168', N'01', N'Eldoret West')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01169', N'169', N'01', N'Garissa ')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01173', N'173', N'01', N'Lamu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01174', N'174', N'01', N'Kilifi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01175', N'175', N'01', N'Milimani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01176', N'176', N'01', N'Nyamira')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01177', N'177', N'01', N'Mukurwe-ini')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01180', N'180', N'01', N'Village Market')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01181', N'181', N'01', N'Bomet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01183', N'183', N'01', N'Mbale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01184', N'184', N'01', N'Narok')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01185', N'158', N'01', N'Iten')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01186', N'186', N'01', N'Voi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01188', N'188', N'01', N'Webuye')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01189', N'159', N'01', N'Gilgil')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01190', N'190', N'01', N'Naivasha')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01191', N'191', N'01', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01192', N'192', N'01', N'Migori')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01193', N'193', N'01', N'Githunguri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01194', N'194', N'01', N'Machakos')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01195', N'195', N'01', N'Kerugoya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01196', N'196', N'01', N'Chuka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01197', N'197', N'01', N'Bungoma')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01198', N'198', N'01', N'Wundanyi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01199', N'199', N'01', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01201', N'201', N'01', N'Capital Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01202', N'202', N'01', N'Karen')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01203', N'203', N'01', N'Lokichogio')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01204', N'204', N'01', N'Gateway')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01205', N'205', N'01', N'Buruburu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01206', N'206', N'01', N'Chogoria')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01207', N'207', N'01', N'Kangari')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01208', N'208', N'01', N'Kianyaga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01209', N'209', N'01', N'Nkubu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01210', N'210', N'01', N'Ol Kalou')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01211', N'211', N'01', N'Makuyu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01212', N'212', N'01', N'Mwea')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01213', N'213', N'01', N'Njabini')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01214', N'214', N'01', N'Gatundu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01215', N'215', N'01', N'Emali')
GO
print 'Processed 100 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01216', N'216', N'01', N'Isiolo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01217', N'217', N'01', N'Flamingo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01218', N'218', N'01', N'Njoro')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01219', N'219', N'01', N'Mutomo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01220', N'220', N'01', N'Mariakani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01221', N'221', N'01', N'Mpeketoni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01222', N'222', N'01', N'Mtito Andei')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01223', N'223', N'01', N'Mtwapa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01224', N'224', N'01', N'Taveta')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01225', N'225', N'01', N'Kengeleni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01226', N'226', N'01', N'Garsen')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01227', N'227', N'01', N'Watamu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01228', N'228', N'01', N'Bondo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01229', N'229', N'01', N'Busia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01230', N'230', N'01', N'Homa Bay')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01231', N'231', N'01', N'Kapsowar')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01232', N'232', N'01', N'Kehancha')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01233', N'233', N'01', N'Keroka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01234', N'234', N'01', N'Kilgoris')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01235', N'235', N'01', N'Kimilili')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01236', N'236', N'01', N'Litein')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01237', N'237', N'01', N'Londiani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01238', N'238', N'01', N'Luanda')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01239', N'239', N'01', N'Malaba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01240', N'240', N'01', N'Muhoroni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01241', N'241', N'01', N'Oyugis')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01242', N'242', N'01', N'Ugunja')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01243', N'243', N'01', N'United Mall')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01244', N'244', N'01', N'Serem')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01245', N'245', N'01', N'Sondu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01246', N'246', N'01', N'Kisumu West')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01247', N'247', N'01', N'Marigat')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01248', N'248', N'01', N'Moi''s Bridge')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01249', N'249', N'01', N'Mashariki')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01250', N'250', N'01', N'Naro Moru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01251', N'251', N'01', N'Kiriaini')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01252', N'252', N'01', N'Egerton University')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01253', N'253', N'01', N'Maua')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01254', N'254', N'01', N'Kawangware')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01255', N'255', N'01', N'Kimathi Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01256', N'256', N'01', N'Namanga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01257', N'257', N'01', N'Gikomba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01258', N'258', N'01', N'Kwale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01259', N'259', N'01', N'Prestige Plaza')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01260', N'260', N'01', N'Kariobangi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01263', N'263', N'01', N'Biashara Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01266', N'266', N'01', N'Ngara')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01267', N'267', N'01', N'Kyuso')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01270', N'270', N'01', N'Masii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01271', N'271', N'01', N'Menengai Crater')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01272', N'272', N'01', N'Town Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01278', N'278', N'01', N'Makindu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01283', N'283', N'01', N'Rongo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01284', N'284', N'01', N'Isibania')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01285', N'285', N'01', N'Kiserian')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01286', N'286', N'01', N'Mwembe Tayari')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01287', N'287', N'01', N'Kisauni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01288', N'288', N'01', N'Haile Selassie')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01289', N'289', N'01', N'Mama Ngina')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01290', N'290', N'01', N'Garden Plaza')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01291', N'291', N'01', N'Sarit Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01292', N'292', N'01', N'CPC Bulk Corporate Chqs')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'01293', N'293', N'01', N'Trade Services')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02000', N'000', N'02', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02001', N'001', N'02', N'Kericho')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02002', N'002', N'02', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02003', N'003', N'02', N'Kitale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02004', N'004', N'02', N'Treasury Square')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02005', N'005', N'02', N'Maritime')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02006', N'006', N'02', N'Kenyatta')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02007', N'007', N'02', N'Kimathi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02008', N'008', N'02', N'Moi Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02009', N'009', N'02', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02010', N'010', N'02', N'Nanyuki')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02011', N'011', N'02', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02012', N'012', N'02', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02015', N'015', N'02', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02016', N'016', N'02', N'Machakos')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02017', N'017', N'02', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02019', N'019', N'02', N'Harambee')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02020', N'020', N'02', N'Kiambu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02053', N'053', N'02', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02054', N'054', N'02', N'Kakamega')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02060', N'060', N'02', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02063', N'063', N'02', N'Haile Selassie')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02064', N'064', N'02', N'Koinange Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02071', N'071', N'02', N'Yaya Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02072', N'072', N'02', N'Ruaraka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02074', N'074', N'02', N'Langata')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02075', N'075', N'02', N'Makupa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02076', N'076', N'02', N'Karen')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02077', N'077', N'02', N'Muthaiga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02078', N'078', N'02', N'Customer Service Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02079', N'079', N'02', N'Customer Service Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02080', N'080', N'02', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02081', N'081', N'02', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02082', N'082', N'02', N'Uper Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02083', N'083', N'02', N'Mombasa-Nyali')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02084', N'084', N'02', N'Chiromo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03002', N'002', N'03', N'Kapsabet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03003', N'003', N'03', N'Eldoret Std & Prestige')
GO
print 'Processed 200 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03004', N'004', N'03', N'Embu Std & Prestige')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03005', N'005', N'03', N'Murang''a')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03006', N'006', N'03', N'Kapenguria')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03007', N'007', N'03', N'Kericho')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03008', N'008', N'03', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03009', N'009', N'03', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03010', N'010', N'03', N'South C')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03011', N'011', N'03', N'Limuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03012', N'012', N'03', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03013', N'013', N'03', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03014', N'014', N'03', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03015', N'015', N'03', N'Kitui')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03016', N'016', N'03', N'Nkrumah Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03017', N'017', N'03', N'Garissa ')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03018', N'018', N'03', N'Nyamira')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03019', N'019', N'03', N'Kilifi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03020', N'020', N'03', N'Waiyaki Way')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03023', N'023', N'03', N'Gilgil')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03024', N'024', N'03', N'Githurai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03027', N'027', N'03', N'Nakuru East')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03028', N'028', N'03', N'Buruburu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03029', N'029', N'03', N'Bomet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03030', N'030', N'03', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03031', N'031', N'03', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03032', N'032', N'03', N'Port Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03033', N'033', N'03', N'Gikomba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03034', N'034', N'03', N'Kawangware')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03035', N'035', N'03', N'Mbale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03036', N'036', N'03', N'Plaza Premier Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03037', N'037', N'03', N'River Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03038', N'038', N'03', N'Upper River Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03039', N'039', N'03', N'Mumias')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03040', N'040', N'03', N'Machakos')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03042', N'042', N'03', N'Isiolo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03043', N'043', N'03', N'Ngong')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03044', N'044', N'03', N'Maua')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03045', N'045', N'03', N'Hurlingham')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03046', N'046', N'03', N'Makupa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03047', N'047', N'03', N'Development Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03049', N'049', N'03', N'Lavington')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03050', N'050', N'03', N'Eastleigh II')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03051', N'051', N'03', N'Homa Bay')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03052', N'052', N'03', N'Rongai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03053', N'053', N'03', N'Othaya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03054', N'054', N'03', N'Voi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03055', N'055', N'03', N'Muthaiga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03057', N'057', N'03', N'Githunguri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03058', N'058', N'03', N'Webuye')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03060', N'060', N'03', N'Chuka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03061', N'061', N'03', N'Nakumatt Westgate')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03062', N'062', N'03', N'Kabarnet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03063', N'063', N'03', N'Kerugoya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03064', N'064', N'03', N'Taveta')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03065', N'065', N'03', N'Karen Std&Prestige')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03066', N'066', N'03', N'Wundanyi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03067', N'067', N'03', N'Ruaraka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03069', N'069', N'03', N'Wote')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03070', N'070', N'03', N'Enterprise prestige centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03071', N'071', N'03', N'Nakumatt Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03072', N'072', N'03', N'Juja')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03073', N'073', N'03', N'ABC Prestige')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03074', N'074', N'03', N'Kikuyu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03075', N'075', N'03', N'Moi Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03077', N'077', N'03', N'Plaza Business Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03078', N'078', N'03', N'Kiriaini')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03079', N'079', N'03', N'Avon Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03080', N'080', N'03', N'Migori')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03082', N'082', N'03', N'Haile Selassie')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03083', N'083', N'03', N'University of Nairobi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03086', N'086', N'03', N'Nairobi west')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03087', N'087', N'03', N'Parkland Highbridge')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03088', N'088', N'03', N'Busia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03089', N'089', N'03', N'Pangani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03093', N'093', N'03', N'Kariobangi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03094', N'094', N'03', N'QueensWay')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03095', N'095', N'03', N'Nakumatt Ebakasi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'05000', N'000', N'05', N'Nairobi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'05001', N'001', N'05', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'05002', N'002', N'05', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'05003', N'003', N'05', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06000', N'000', N'06', N'Nairobi Main')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06002', N'002', N'06', N'Digo rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06004', N'004', N'06', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06005', N'005', N'06', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06006', N'006', N'06', N'Sarit Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06007', N'007', N'06', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06008', N'008', N'06', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06009', N'009', N'06', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07000', N'000', N'07', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07001', N'001', N'07', N'Upper Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07002', N'002', N'07', N'Wabera')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07003', N'003', N'07', N'Mama Ngina Br/Hilton Agency')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07004', N'004', N'07', N'Westlands Br/ILRI Agency')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07005', N'005', N'07', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07006', N'006', N'07', N'Mamlaka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07007', N'007', N'07', N'Village Mkt Br/US Emb/Icraf Ag')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07008', N'008', N'07', N'Cargo Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07009', N'009', N'07', N'Park Side')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07016', N'016', N'07', N'Galleria')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07017', N'017', N'07', N'Junction')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07020', N'020', N'07', N'Moi Avenue Mombasa')
GO
print 'Processed 300 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07021', N'021', N'07', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07022', N'022', N'07', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07023', N'023', N'07', N'Bamburi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07024', N'024', N'07', N'Diani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07025', N'025', N'07', N'Changamwe')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07026', N'026', N'07', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07027', N'027', N'07', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'08046', N'046', N'08', N'Mobasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'08047', N'047', N'08', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'08048', N'048', N'08', N'Nairobi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09000', N'000', N'09', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09001', N'001', N'09', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09002', N'002', N'09', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09003', N'003', N'09', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09004', N'004', N'09', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10000', N'000', N'10', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10001', N'001', N'10', N'Kenindia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10002', N'002', N'10', N'Biashara')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10003', N'003', N'10', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10004', N'004', N'10', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10005', N'005', N'10', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10006', N'006', N'10', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10007', N'007', N'10', N'Parklands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10008', N'008', N'10', N'Riverside Drive')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10009', N'009', N'10', N'Card centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10010', N'010', N'10', N'Hurlingham')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10011', N'011', N'10', N'Capital Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10012', N'012', N'10', N'Nyali')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10014', N'014', N'10', N'Kamukunji')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10015', N'015', N'10', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11000', N'000', N'11', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11002', N'002', N'11', N'Co-op Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11003', N'003', N'11', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11004', N'004', N'11', N'Nkrumah Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11005', N'005', N'11', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11006', N'006', N'11', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11007', N'007', N'11', N'Industrial Are')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11008', N'008', N'11', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11009', N'009', N'11', N'Machakos')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11010', N'010', N'11', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11011', N'011', N'11', N'Ukulima')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11012', N'012', N'11', N'Chuka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11013', N'013', N'11', N'Wakulima Market')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11014', N'014', N'11', N'Moi Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11015', N'015', N'11', N'Naivasha')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11017', N'017', N'11', N'Nyahururu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11018', N'018', N'11', N'Chuka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11019', N'019', N'11', N'Wakulima Market')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11020', N'020', N'11', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11021', N'021', N'11', N'Kiambu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11022', N'022', N'11', N'Homabay')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11023', N'023', N'11', N'Embu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11024', N'024', N'11', N'Kericho')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11025', N'025', N'11', N'Bungoma')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11026', N'026', N'11', N'Muranga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11027', N'027', N'11', N'Kayole')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11028', N'028', N'11', N'Karatina')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11029', N'029', N'11', N'Ukunda')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11030', N'030', N'11', N'Mtwapa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11031', N'031', N'11', N'University way')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11032', N'032', N'11', N'BuruBuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11033', N'033', N'11', N'AthiRiver')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11034', N'034', N'11', N'Mumias')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11035', N'035', N'11', N'Stima Plaza')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11036', N'036', N'11', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11037', N'037', N'11', N'Upper Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11038', N'038', N'11', N'Ongata Rongai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11039', N'039', N'11', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11040', N'040', N'11', N'Nacico Plaza')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11041', N'041', N'11', N'Kariobangi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11042', N'042', N'11', N'Kawangware')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11043', N'043', N'11', N'Makutano')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11044', N'044', N'11', N'Parliament Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11045', N'045', N'11', N'Kimathi Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11046', N'046', N'11', N'Kitale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11047', N'047', N'11', N'Githurai Agency')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11048', N'048', N'11', N'Maua')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11049', N'049', N'11', N'City Hall')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11050', N'050', N'11', N'Digo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11051', N'051', N'11', N'Nairobi Business Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11052', N'052', N'11', N'Kakamega')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11053', N'053', N'11', N'Migori')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11055', N'055', N'11', N'Nkubu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11056', N'056', N'11', N'Enterprise Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11057', N'057', N'11', N'Busia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11058', N'058', N'11', N'Siaya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11059', N'059', N'11', N'Voi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11060', N'060', N'11', N'Mariakani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11061', N'061', N'11', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11062', N'062', N'11', N'Zimmerman')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11063', N'063', N'11', N'Nakuru East')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11064', N'064', N'11', N'Kitengela')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11065', N'065', N'11', N'Aga Khan Walk')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11066', N'066', N'11', N'Narok')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11067', N'067', N'11', N'Kitui')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11068', N'068', N'11', N'Nanyuki')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11069', N'069', N'11', N'Embakasi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11070', N'070', N'11', N'Kibera')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11071', N'071', N'11', N'Siakago')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11072', N'072', N'11', N'Kapsabet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11073', N'073', N'11', N'Mbita')
GO
print 'Processed 400 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11074', N'074', N'11', N'Kangemi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11075', N'075', N'11', N'Dandora')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11077', N'077', N'11', N'Tala')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11078', N'078', N'11', N'Gikomba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11079', N'079', N'11', N'River Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11080', N'080', N'11', N'Nyamira')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11081', N'081', N'11', N'Garissa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11082', N'082', N'11', N'Bomet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11083', N'083', N'11', N'Keroka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11084', N'084', N'11', N'Gilgil')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11085', N'085', N'11', N'Tom Mboya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11086', N'086', N'11', N'Likoni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11088', N'088', N'11', N'Mwingi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11089', N'089', N'11', N'Mwingi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11090', N'090', N'11', N'Webuye')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11100', N'100', N'11', N'Ndhiwa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11102', N'102', N'11', N'Isiolo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12002', N'002', N'12', N'Kenyatta Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12003', N'003', N'12', N'Harambee Avenue NBK  Building')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12004', N'004', N'12', N'Hill Plaza')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12005', N'005', N'12', N'Busia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12006', N'006', N'12', N'Kiambu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12007', N'007', N'12', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12008', N'008', N'12', N'Karatina')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12009', N'009', N'12', N'Narok')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12010', N'010', N'12', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12011', N'011', N'12', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12012', N'012', N'12', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12013', N'013', N'12', N'Kitale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12015', N'015', N'12', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12016', N'016', N'12', N'Limuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12017', N'017', N'12', N'Kitui')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12019', N'019', N'12', N'Bungoma')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12020', N'020', N'12', N'Nkurumah Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12021', N'021', N'12', N'Kapsabet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12022', N'022', N'12', N'Awendo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12023', N'023', N'12', N'Portway Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12025', N'025', N'12', N'Hospital')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12026', N'026', N'12', N'Ruiru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12027', N'027', N'12', N'Ongata Rongai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12028', N'028', N'12', N'Embu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12029', N'029', N'12', N'Kakamega')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12031', N'031', N'12', N'Ukunda')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12032', N'032', N'12', N'Upper Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12033', N'033', N'12', N'Nandi Hills')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12034', N'034', N'12', N'Migori')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12035', N'035', N'12', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12036', N'036', N'12', N'Times Tower')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12037', N'037', N'12', N'Maua')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12038', N'038', N'12', N'Wilson Airport')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12039', N'039', N'12', N'J.K.I.A.')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12040', N'040', N'12', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12042', N'042', N'12', N'Mutomo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12043', N'043', N'12', N'Kianjai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12044', N'044', N'12', N'Kenyatta University')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12045', N'045', N'12', N'St. Paul''s University')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12046', N'046', N'12', N'Moi University')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12047', N'047', N'12', N'Moi International Airport, Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12050', N'050', N'12', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'12099', N'099', N'12', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14000', N'000', N'14', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14004', N'004', N'14', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14005', N'005', N'14', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14006', N'006', N'14', N'Kitale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14007', N'007', N'14', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'16000', N'000', N'16', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'16400', N'400', N'16', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'17000', N'000', N'17', N'Main Branch')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'17001', N'001', N'17', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'17002', N'002', N'17', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'18000', N'000', N'18', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'18002', N'002', N'18', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'18003', N'003', N'18', N'Milimani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'18004', N'004', N'18', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19000', N'000', N'19', N'Nairobi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19001', N'001', N'19', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19002', N'002', N'19', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19003', N'003', N'19', N'Uhuru Highway')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19004', N'004', N'19', N'River Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19006', N'006', N'19', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19007', N'007', N'19', N'Ruaraka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19008', N'008', N'19', N'Monrovia Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19009', N'009', N'19', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19010', N'010', N'19', N'Ngong Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19011', N'011', N'19', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19012', N'012', N'19', N'Embakasi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19013', N'013', N'19', N'Kericho')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19014', N'014', N'19', N'Changamwe')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19015', N'015', N'19', N'Bungoma')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19017', N'017', N'19', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19018', N'018', N'19', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'20001', N'001', N'20', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'20002', N'002', N'20', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'20003', N'003', N'20', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'20004', N'004', N'20', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23000', N'000', N'23', N'Harambee Avenue Harambee Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23001', N'001', N'23', N'Murang''a')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23002', N'002', N'23', N'Embu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23003', N'003', N'23', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23004', N'004', N'23', N'Koinange Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23005', N'005', N'23', N'Thika')
GO
print 'Processed 500 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23006', N'006', N'23', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23007', N'007', N'23', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23009', N'009', N'23', N'Maua')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23010', N'010', N'23', N'Isiolo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23011', N'011', N'23', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23013', N'013', N'23', N'Umoja')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23014', N'014', N'23', N'River Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23015', N'015', N'23', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23016', N'016', N'23', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25000', N'000', N'25', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25001', N'001', N'25', N'Koinange Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25002', N'002', N'25', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25003', N'003', N'25', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25004', N'004', N'25', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25005', N'005', N'25', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25006', N'006', N'25', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26001', N'001', N'26', N'Nairobi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26002', N'002', N'26', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26003', N'003', N'26', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26005', N'005', N'26', N'MIA')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26006', N'006', N'26', N'JKIA')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26007', N'007', N'26', N'Kirinyaga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26008', N'008', N'26', N'Kabarak')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26009', N'009', N'26', N'Olenguruone')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26010', N'010', N'26', N'Kericho')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26011', N'011', N'26', N'Nandi Hills')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26012', N'012', N'26', N'EPZ')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26013', N'013', N'26', N'Sheikh Karume')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26014', N'014', N'26', N'Kabarnet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30000', N'000', N'30', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30001', N'001', N'30', N'City Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30003', N'003', N'30', N'Village Market')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30004', N'004', N'30', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30005', N'005', N'30', N'Hurlingham')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30006', N'006', N'30', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30007', N'007', N'30', N'Parklands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30008', N'008', N'30', N'Riverside Mews')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30009', N'009', N'30', N'Iman Banking Centre Riverside Mews')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30010', N'010', N'30', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30011', N'011', N'30', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30012', N'012', N'30', N'Donholm')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30014', N'014', N'30', N'Ngara Mini Branch Peace Towers')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30015', N'015', N'30', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30016', N'016', N'30', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31000', N'000', N'31', N'Clearing Centre,Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31002', N'002', N'31', N'Kenyatta Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31003', N'003', N'31', N'Digo Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31004', N'004', N'31', N'Waiyaki Way')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31005', N'005', N'31', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31006', N'006', N'31', N'Harambee Avenue Nairobi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31007', N'007', N'31', N'Chiromo Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31008', N'008', N'31', N'International House')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31009', N'009', N'31', N'Nkrumah')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31010', N'010', N'31', N'Upper Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31011', N'011', N'31', N'Naivasha')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31012', N'012', N'31', N'Westgate')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31013', N'013', N'31', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31014', N'014', N'31', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31015', N'015', N'31', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31016', N'016', N'31', N'Nyerere')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31017', N'017', N'31', N'Nanyuki')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31018', N'018', N'31', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31020', N'020', N'31', N'Gikomba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31021', N'021', N'31', N'Ruaraka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31022', N'022', N'31', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31023', N'023', N'31', N'Karen')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31024', N'024', N'31', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31999', N'999', N'31', N'Central Processing CfC Centre,HeadOffice')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35000', N'000', N'35', N'Koinange Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35001', N'001', N'35', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35002', N'002', N'35', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35004', N'004', N'35', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35005', N'005', N'35', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35006', N'006', N'35', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35007', N'007', N'35', N'Libra House')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35008', N'008', N'35', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39001', N'001', N'39', N'IPS')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39002', N'002', N'39', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39003', N'003', N'39', N'Upper Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39004', N'004', N'39', N'Parklands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39006', N'006', N'39', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39007', N'007', N'39', N'Watamu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39008', N'008', N'39', N'Diani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39009', N'009', N'39', N'Kilifi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39010', N'010', N'39', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39011', N'011', N'39', N'Karen')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39012', N'012', N'39', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39014', N'014', N'39', N'Changamwe')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39015', N'015', N'39', N'Riverside')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39016', N'016', N'39', N'Likoni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39018', N'018', N'39', N'Village Market')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41000', N'000', N'41', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41101', N'101', N'41', N'City Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41102', N'102', N'41', N'NIC Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41103', N'103', N'41', N'Harbor Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41105', N'105', N'41', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41106', N'106', N'41', N'Junction')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41107', N'107', N'41', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41108', N'108', N'41', N'Nyali')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41109', N'109', N'41', N'Nkurumah Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41111', N'111', N'41', N'Prestige')
GO
print 'Processed 600 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41112', N'112', N'41', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41113', N'113', N'41', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41114', N'114', N'41', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41115', N'115', N'41', N'Galleria (Bomas)')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41116', N'116', N'41', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41117', N'117', N'41', N'Village Market')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41118', N'118', N'41', N'Mombasa Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42001', N'001', N'42', N'Banda Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42004', N'004', N'42', N'Kimathi Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42005', N'005', N'42', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42006', N'006', N'42', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42007', N'007', N'42', N'Parklands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43000', N'000', N'43', N'Ecobank Towers')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43002', N'002', N'43', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43003', N'003', N'43', N'Plaza 2000')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43004', N'004', N'43', N'Westminister')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43005', N'005', N'43', N'Chambers')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43007', N'007', N'43', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43008', N'008', N'43', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43009', N'009', N'43', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43010', N'010', N'43', N'Kitale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43011', N'011', N'43', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43012', N'012', N'43', N'Karatina')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43013', N'013', N'43', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43014', N'014', N'43', N'United Mall')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43015', N'015', N'43', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43016', N'016', N'43', N'Jomo Kenyatta Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43017', N'017', N'43', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43018', N'018', N'43', N'Busia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43019', N'019', N'43', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43020', N'020', N'43', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43021', N'021', N'43', N'Gikomba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43023', N'023', N'43', N'Valley Arcade')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43100', N'100', N'43', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49000', N'000', N'49', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49001', N'001', N'49', N'Nairobi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49002', N'002', N'49', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49003', N'003', N'49', N'Westlands The Mall The Mall')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49005', N'005', N'49', N'Chester')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49007', N'007', N'49', N'Waiyaki Way')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49008', N'008', N'49', N'Kakamega')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49009', N'009', N'49', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49011', N'011', N'49', N'Nyali')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49012', N'012', N'49', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49013', N'013', N'49', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'50000', N'000', N'50', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'50001', N'001', N'50', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'50002', N'002', N'50', N'Parklands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'50003', N'003', N'50', N'Koinange Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'5004', N'004', N'50', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'51000', N'000', N'51', N'Koinange Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53001', N'001', N'53', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53002', N'002', N'53', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53003', N'003', N'53', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53004', N'004', N'53', N'Lavington')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53005', N'005', N'53', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53006', N'006', N'53', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53007', N'007', N'53', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53008', N'008', N'53', N'Muthaiga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53010', N'010', N'53', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53011', N'011', N'53', N'Gikomba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53012', N'012', N'53', N'Ngong Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53013', N'013', N'53', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'54001', N'001', N'54', N'Nairobi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'54002', N'002', N'54', N'Riverside Drive')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55001', N'001', N'55', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55002', N'002', N'55', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55004', N'004', N'55', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55005', N'005', N'55', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55006', N'006', N'55', N'Main Branch')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55007', N'007', N'55', N'Mombasa Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57000', N'000', N'57', N'Kenyatta Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57001', N'001', N'57', N'2nd Ngong Avenue I & M Bank House')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57002', N'002', N'57', N'Sarit Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57003', N'003', N'57', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57004', N'004', N'57', N'Biashara')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57005', N'005', N'57', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57007', N'007', N'57', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57008', N'008', N'57', N'Karen')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57009', N'009', N'57', N'Panari Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57010', N'010', N'57', N'Parklands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57011', N'011', N'57', N'Wilson Airport')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57012', N'012', N'57', N'Ongata Rongai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57013', N'013', N'57', N'South C Shopping South C')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57014', N'014', N'57', N'Nyali Cinemax')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57015', N'015', N'57', N'Langata Link')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57016', N'016', N'57', N'Lavington')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57018', N'018', N'57', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57098', N'098', N'57', N'Card Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'59001', N'001', N'59', N'Loita Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'59002', N'002', N'59', N'Ngong Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60000', N'000', N'60', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60001', N'001', N'60', N'City Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60002', N'002', N'60', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60003', N'003', N'60', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60004', N'004', N'60', N'Diani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60006', N'006', N'60', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63000', N'000', N'63', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63001', N'001', N'63', N'Nation Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63002', N'002', N'63', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63003', N'003', N'63', N'Kisumu')
GO
print 'Processed 700 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63005', N'005', N'63', N'Parklands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63006', N'006', N'63', N'Westgate')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63008', N'008', N'63', N'Mombasa Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63009', N'009', N'63', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63011', N'011', N'63', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63012', N'012', N'63', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63013', N'013', N'63', N'OTC')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63014', N'014', N'63', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63015', N'015', N'63', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63016', N'016', N'63', N'Changamwe')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63017', N'017', N'63', N'T-Mall')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63018', N'018', N'63', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63019', N'019', N'63', N'Village Market')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63020', N'020', N'63', N'Diani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63021', N'021', N'63', N'Bungoma')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63023', N'023', N'63', N'Prestige')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63024', N'024', N'63', N'Buru Buru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63025', N'025', N'63', N'Kitengela')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63026', N'026', N'63', N'Jomo Kenyatta')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63027', N'027', N'63', N'Kakamega')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63028', N'028', N'63', N'Kericho')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63029', N'029', N'63', N'Upper Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63030', N'030', N'63', N'Wabera Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63031', N'031', N'63', N'Karen')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63032', N'032', N'63', N'Voi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63034', N'034', N'63', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63035', N'035', N'63', N'Diamond Plaza')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63036', N'036', N'63', N'Cross Roads')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63050', N'050', N'63', N'Tom Mboya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66000', N'000', N'66', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66001', N'001', N'66', N'Naivasha Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66002', N'002', N'66', N'Moi Avenue -Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66003', N'003', N'66', N'Kenyatta Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66004', N'004', N'66', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66005', N'005', N'66', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66007', N'007', N'66', N'Embu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66008', N'008', N'66', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66009', N'009', N'66', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66010', N'010', N'66', N'Kericho')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66011', N'011', N'66', N'Kangemi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66012', N'012', N'66', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66013', N'013', N'66', N'Kerugoya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66014', N'014', N'66', N'Kenyatta Mkt')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66015', N'015', N'66', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66016', N'016', N'66', N'Chuka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66017', N'017', N'66', N'Kitui')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66018', N'018', N'66', N'Machakos')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66019', N'019', N'66', N'Nanyuki')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66021', N'021', N'66', N'Emali')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66022', N'022', N'66', N'Naivasha')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66023', N'023', N'66', N'Nyahururu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66024', N'024', N'66', N'Isiolo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66025', N'025', N'66', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66026', N'026', N'66', N'Kitale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66027', N'027', N'66', N'Kibwezi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66028', N'028', N'66', N'Bungoma')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66031', N'031', N'66', N'Mtwapa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66033', N'033', N'66', N'Moi Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66034', N'034', N'66', N'Mwea')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66035', N'035', N'66', N'Kengeleni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66036', N'036', N'66', N'Kilimani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68000', N'000', N'68', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68001', N'001', N'68', N'Corporate')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68002', N'002', N'68', N'Fourways')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68003', N'003', N'68', N'Kangema')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68004', N'004', N'68', N'Karatina')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68006', N'006', N'68', N'Muraradia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68007', N'007', N'68', N'Kangari')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68008', N'008', N'68', N'Othaya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68009', N'009', N'68', N'Thika Plaza')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68010', N'010', N'68', N'Kerugoya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68011', N'011', N'68', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68012', N'012', N'68', N'Tom Mboya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68013', N'013', N'68', N'Nakuru Gatehouse Gate Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68014', N'014', N'68', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68015', N'015', N'68', N'Mama Ngina')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68017', N'017', N'68', N'Community')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68018', N'018', N'68', N'Community Corporate')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68019', N'019', N'68', N'Embu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68020', N'020', N'68', N'Naivasha')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68021', N'021', N'68', N'Chuka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68022', N'022', N'68', N'Murang''a')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68023', N'023', N'68', N'Molo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68024', N'024', N'68', N'Harambee')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68025', N'025', N'68', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68026', N'026', N'68', N'Kimathi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68027', N'027', N'68', N'Nanyuki')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68029', N'029', N'68', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68030', N'030', N'68', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68031', N'031', N'68', N'Nakuru Kenyatta Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68032', N'032', N'68', N'Kariobangi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68033', N'033', N'68', N'Kitale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68034', N'034', N'68', N'Thika Kenyatta Highway')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68035', N'035', N'68', N'Knut Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68036', N'036', N'68', N'Narok')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68037', N'037', N'68', N'Nkubu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68038', N'038', N'68', N'Mwea')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68040', N'040', N'68', N'Maua')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68041', N'041', N'68', N'Isiolo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68042', N'042', N'68', N'Kagio')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68043', N'043', N'68', N'Gikomba')
GO
print 'Processed 800 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68044', N'044', N'68', N'Ukunda')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68045', N'045', N'68', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68046', N'046', N'68', N'Mombasa Digo Rd Digo Rd')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68047', N'047', N'68', N'Moi Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68048', N'048', N'68', N'Bungoma')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68049', N'049', N'68', N'Kapsabet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68050', N'050', N'68', N'Kakamega')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68052', N'052', N'68', N'Nyamira')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68053', N'053', N'68', N'Litein')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68055', N'055', N'68', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68056', N'056', N'68', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68057', N'057', N'68', N'Kikuyu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68058', N'058', N'68', N'Garissa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68059', N'059', N'68', N'Mwingi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68060', N'060', N'68', N'Machakos')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68061', N'061', N'68', N'Ongata Rongai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68062', N'062', N'68', N'Ol-Kalou')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68064', N'064', N'68', N'Kiambu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68065', N'065', N'68', N'Kayole')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68066', N'066', N'68', N'Gatundu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68067', N'067', N'68', N'Wote')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68068', N'068', N'68', N'Mumias')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68069', N'069', N'68', N'Limuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68070', N'070', N'68', N'Kitengela')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68071', N'071', N'68', N'Githurai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68072', N'072', N'68', N'Kitui')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68073', N'073', N'68', N'Ngong')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68074', N'074', N'68', N'Loitoktok')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68076', N'076', N'68', N'Mbita')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68077', N'077', N'68', N'Gilgil')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68078', N'078', N'68', N'Busia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68079', N'079', N'68', N'Voi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68080', N'080', N'68', N'Enterprise Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68081', N'081', N'68', N'Equity Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68082', N'082', N'68', N'Donholm')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68083', N'083', N'68', N'Mukurwe-ini')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68084', N'084', N'68', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68085', N'085', N'68', N'Namanga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68088', N'088', N'68', N'OTC')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68089', N'089', N'68', N'Kenol')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68090', N'090', N'68', N'Tala')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68091', N'091', N'68', N'Ngara')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68092', N'092', N'68', N'Nandi Hills')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68093', N'093', N'68', N'Githunguri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68094', N'094', N'68', N'Tea Room')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68095', N'095', N'68', N'Buru Buru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68096', N'096', N'68', N'Mbale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68097', N'097', N'68', N'Siaya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68098', N'098', N'68', N'Homa Bay')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68099', N'099', N'68', N'Lodwar')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68100', N'100', N'68', N'Mandera')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68101', N'101', N'68', N'Marsabit')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68102', N'102', N'68', N'Moyale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68103', N'103', N'68', N'Wajir')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68104', N'104', N'68', N'Meru Makutano')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68105', N'105', N'68', N'Malaba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68106', N'106', N'68', N'Kilifi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68107', N'107', N'68', N'Kapenguria')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68108', N'108', N'68', N'Mombasa Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68110', N'110', N'68', N'Maralal')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68111', N'111', N'68', N'Kimende')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68112', N'112', N'68', N'Luanda')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68113', N'113', N'68', N'KU')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68114', N'114', N'68', N'Kengeleni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68115', N'115', N'68', N'Nyeri Kimathi Way EK Wachira Bldg')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68116', N'116', N'68', N'Migori')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68117', N'117', N'68', N'Kibera')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68118', N'118', N'68', N'Kasarani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68119', N'119', N'68', N'Mtwapa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68120', N'120', N'68', N'Changamwe')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68122', N'122', N'68', N'Bomet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68123', N'123', N'68', N'Kilgoris')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68124', N'124', N'68', N'Keroka')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68125', N'125', N'68', N'Karen')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68126', N'126', N'68', N'Kisumu Angawa Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68127', N'127', N'68', N'Mpeketoni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68128', N'128', N'68', N'Nairobi West')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68129', N'129', N'68', N'Kenyatta Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68130', N'130', N'68', N'City Hall')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68131', N'131', N'68', N'Eldama Ravine')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70000', N'000', N'70', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70001', N'001', N'70', N'Kiambu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70002', N'002', N'70', N'Githunguri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70003', N'003', N'70', N'Sonalux')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70004', N'004', N'70', N'Gatundu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70005', N'005', N'70', N'Thika')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70006', N'006', N'70', N'Murang''a')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70007', N'007', N'70', N'kangari')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70008', N'008', N'70', N'Kiria-ini')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70009', N'009', N'70', N'Kangema')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70011', N'011', N'70', N'Othaya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70014', N'014', N'70', N'Cargen Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70018', N'018', N'70', N'Nakuru Finance')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70019', N'019', N'70', N'Nakuru Njoro Hse')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70021', N'021', N'70', N'Dagoreti')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70023', N'023', N'70', N'Nyahururu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70024', N'024', N'70', N'Ruiru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70025', N'025', N'70', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70026', N'026', N'70', N'Nyamira')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70027', N'027', N'70', N'Kisii')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70031', N'031', N'70', N'Industrial Area')
GO
print 'Processed 900 total records'
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70033', N'033', N'70', N'Donholm')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70035', N'035', N'70', N'Fourways Retail')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70038', N'038', N'70', N'KTDA Plaza')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70041', N'041', N'70', N'Kariobangi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70042', N'042', N'70', N'Gikomba Area 42')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70043', N'043', N'70', N'Gikomba')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70045', N'045', N'70', N'Githurai')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70046', N'046', N'70', N'Kilimani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70047', N'047', N'70', N'Limuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70049', N'049', N'70', N'Kagwe')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70051', N'051', N'70', N'Banana')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70053', N'053', N'70', N'Naivasha')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70055', N'055', N'70', N'Nyeri')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70057', N'057', N'70', N'Kerugoya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70058', N'058', N'70', N'Tom Mboya')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70059', N'059', N'70', N'River Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70061', N'061', N'70', N'Kayole')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70062', N'062', N'70', N'Nkubu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70063', N'063', N'70', N'Meru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70065', N'065', N'70', N'KTDA Corporate')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70069', N'069', N'70', N'Kitui')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70071', N'071', N'70', N'Kitengela')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70072', N'072', N'70', N'Kitui')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70073', N'073', N'70', N'Machakos')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70075', N'075', N'70', N'Embu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70077', N'077', N'70', N'Bungoma')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70078', N'078', N'70', N'Kakamega')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70079', N'079', N'70', N'Busia')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70083', N'083', N'70', N'Molo')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70085', N'085', N'70', N'Eldoret')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70095', N'095', N'70', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70096', N'096', N'70', N'Kenyatta Avenue,Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70097', N'097', N'70', N'Kapsabet')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72000', N'000', N'72', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72001', N'001', N'72', N'Central Clearing Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72002', N'002', N'72', N'Upperhill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72003', N'003', N'72', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72004', N'004', N'72', N'Kenyatta Avenue')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72005', N'005', N'72', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72007', N'007', N'72', N'Lamu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72008', N'008', N'72', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72009', N'009', N'72', N'Muthaiga')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72010', N'010', N'72', N'Bondeni')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74001', N'001', N'74', N'Wabera Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74002', N'002', N'74', N'Eastleigh')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74003', N'003', N'74', N'Mombasa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74004', N'004', N'74', N'Garissa')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74005', N'005', N'74', N'Eastleigh II')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74006', N'006', N'74', N'Malindi')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74007', N'007', N'74', N'Kisumu')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74008', N'008', N'74', N'Kimathi Street')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74009', N'009', N'74', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74010', N'010', N'74', N'South C')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74011', N'011', N'74', N'Industrial Area')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74012', N'012', N'74', N'Masalani')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74013', N'013', N'74', N'Habaswein')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74014', N'014', N'74', N'Wajir')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74015', N'015', N'74', N'Moyale')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74016', N'016', N'74', N'Nakuru')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74017', N'017', N'74', N'Mombasa 11')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74999', N'999', N'74', N'Head Office/Clearing Centre')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'76001', N'001', N'76', N'Westlands')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'76002', N'002', N'76', N'Enterprise Road')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'76003', N'003', N'76', N'Upper Hill')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'76099', N'099', N'76', N'Head Office')
INSERT [dbo].[BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'95000', N'000', N'59', N'Head Office')
/****** Object:  Table [dbo].[Attendances]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendances]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Attendances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SchoolDate] [datetime] NULL,
	[StudentId] [int] NULL,
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
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 01/05/2013 15:03:29 ******/
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
	[BookBalance] [money] NOT NULL,
	[ClearedBalance] [money] NOT NULL,
	[Branch] [int] NULL,
	[Limit] [money] NOT NULL,
	[AccruedInt] [money] NOT NULL,
	[InterestRate] [float] NOT NULL,
	[Bal30] [money] NULL,
	[Bal60] [money] NULL,
	[Bal90] [money] NULL,
	[BalOver90] [money] NULL,
	[IntRate30] [float] NULL,
	[IntRate60] [float] NULL,
	[IntRate90] [float] NULL,
	[IntRateOver90] [float] NULL,
	[AccountNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PassFlag] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SchoolBranch] [int] NULL,
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
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountType], [BookBalance], [ClearedBalance], [Branch], [Limit], [AccruedInt], [InterestRate], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [AccountNo], [PassFlag], [SchoolBranch]) VALUES (1, 1, N'School fees', N'11', 0.0000, 0.0000, 12, 0.0000, 0.0000, 0, 0.0000, 20000.0000, 0.0000, 0.0000, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountType], [BookBalance], [ClearedBalance], [Branch], [Limit], [AccruedInt], [InterestRate], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [AccountNo], [PassFlag], [SchoolBranch]) VALUES (2, 1, N'Library Fund', N'22', 200.0000, 2200.0000, 0, 0.0000, 0.0000, 0, 2300.0000, 325500.0000, 36200.0000, 36500.0000, 0, 0, 0, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
/****** Object:  Table [dbo].[ExamPeriod]    Script Date: 01/05/2013 15:03:29 ******/
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
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SchoolClasses](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProgrammeId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NextClass] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassTeacher] [int] NULL,
	[Remarks] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_SchoolClasses] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[SchoolClasses] ON
INSERT [dbo].[SchoolClasses] ([ClassId], [ShortCode], [ProgrammeId], [NextClass], [ClassName], [ClassTeacher], [Remarks]) VALUES (1, NULL, NULL, N'2', N'1a', 1, N'good')
INSERT [dbo].[SchoolClasses] ([ClassId], [ShortCode], [ProgrammeId], [NextClass], [ClassName], [ClassTeacher], [Remarks]) VALUES (2, NULL, NULL, N'3', N'1b', 2, N'good')
SET IDENTITY_INSERT [dbo].[SchoolClasses] OFF
/****** Object:  Table [dbo].[StudentProgresses]    Script Date: 01/05/2013 15:03:30 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 01/05/2013 15:03:30 ******/
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
INSERT [dbo].[Users] ([Name], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [PasswordQuestion], [PasswordAnswerHash], [PasswordAnswerSalt], [UserType], [ProfileReset]) VALUES (N'admin1', N'Fred', N'Bloggs', NULL, N'LvnDL3Iy/h2nm1FO2/rD0yrch24sKSrCZpmTv4wQc4PmILDLhgpcfqCgXWi06WyM3Mx2AY93oJzNwVqVrER/rQ==', N'I1nIRw==', N'In what city is your vacation home? (Enter full name of city)', N'teIPQA==', N'X0najw==', N'A ', 1)
INSERT [dbo].[Users] ([Name], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [PasswordQuestion], [PasswordAnswerHash], [PasswordAnswerSalt], [UserType], [ProfileReset]) VALUES (N'kevin', N'kevin', N'mutugi', N'kevin@softwareproviders.co.ke', N'GXd7BeWsgtxXZ0KpwlPPqs+l81aPLPMQjqxTVPlXF84fQu/4vwQdZOQZiCMtbKsJG2L/dTopS9byeQZ9uL1mcA==', N'LsLAqg==', N'In what city is your vacation home? (Enter full name of city)', N'Zcd5wg==', N'sgVE2g==', N'U ', 1)
INSERT [dbo].[Users] ([Name], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [PasswordQuestion], [PasswordAnswerHash], [PasswordAnswerSalt], [UserType], [ProfileReset]) VALUES (N'user1', N'John', N'Doe', NULL, N'p13yuVCMCIgTy6jOf0ypzUPKWdSkYqcqYJAUwC2WGAOdk9EQD5ciEBD8s8hVPd+i36icrnH4SK+1sWLUQ5ZTpg==', N'qUCPFQ==', N'In what city is your vacation home? (Enter full name of city)', N'kqTjVA==', N'iCQYWA==', N'U ', 1)
/****** Object:  View [dbo].[vwStatement]    Script Date: 01/05/2013 15:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwStatement]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwStatement]
AS
SELECT     dbo.Schools.[Index], dbo.Schools.SchoolName, dbo.Schools.Telephone, dbo.Schools.Cellphone, dbo.Schools.Email, dbo.Schools.Address1, dbo.Schools.Address2, 
                      dbo.Schools.SMTPServer, dbo.Schools.SMSGateway, dbo.Students.Id, dbo.Students.SchoolId, dbo.Students.AdminNo, dbo.Students.StudentSurName, 
                      dbo.Students.StudentOtherNames, dbo.Students.StudentAddress, dbo.Students.Phone, dbo.Students.DateOfBirth, dbo.Students.Gender, dbo.Students.Email AS Expr1, 
                      dbo.Students.CurrentClass, dbo.Students.Homepage, dbo.Students.FatherName, dbo.Students.FatherCellPhone, dbo.Students.FatherOfficePhone, 
                      dbo.Students.FatherEmail, dbo.Students.MotherName, dbo.Students.MotherCellPhone, dbo.Students.MotherOfficePhone, dbo.Students.ResidencePhone, 
                      dbo.Students.AdmissionDate, dbo.Students.ResidenceAddress, dbo.Students.AdmittedBy, dbo.Students.LastModifiedTime, dbo.Students.Status, 
                      dbo.Students.Remarks, dbo.Students.ExtraCurricala3, dbo.Students.ExtraCurricala2, dbo.Students.ExtraCurricala1, dbo.Students.ReasonForLeaving, 
                      dbo.Students.PrevSchoolAddress, dbo.Students.PrevSchoolPhone, dbo.Students.PrevSchoolName, dbo.Students.PrevSchoolId
FROM         dbo.Schools INNER JOIN
                      dbo.Students ON dbo.Schools.Id = dbo.Students.Id
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vwStatement', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Schools"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Students"
            Begin Extent = 
               Top = 6
               Left = 227
               Bottom = 114
               Right = 405
            End
            DisplayFlags = 280
            TopColumn = 0
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwStatement'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vwStatement', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwStatement'
GO
/****** Object:  Table [dbo].[SubSubjects]    Script Date: 01/05/2013 15:03:30 ******/
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
/****** Object:  Table [dbo].[Transactions]    Script Date: 01/05/2013 15:03:30 ******/
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
	[Amount] [money] NOT NULL,
	[Narrative] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserID] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Authorizer] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StatementFlag] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostDate] [date] NOT NULL,
	[ValueDate] [date] NULL,
	[RecordDate] [date] NOT NULL,
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
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [Narrative], [UserID], [Authorizer], [StatementFlag], [PostDate], [ValueDate], [RecordDate]) VALUES (2, 1, 1, 25040.0000, N'Fees ', NULL, NULL, NULL, CAST(0x27350B00 AS Date), CAST(0x27350B00 AS Date), CAST(0x27350B00 AS Date))
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [Narrative], [UserID], [Authorizer], [StatementFlag], [PostDate], [ValueDate], [RecordDate]) VALUES (3, 1, 1, -6500.0000, N'Fee Payemt', NULL, NULL, NULL, CAST(0x28350B00 AS Date), CAST(0x28350B00 AS Date), CAST(0x28350B00 AS Date))
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [Narrative], [UserID], [Authorizer], [StatementFlag], [PostDate], [ValueDate], [RecordDate]) VALUES (5, 2, 1, -13000.0000, N'Fee Payment', NULL, NULL, NULL, CAST(0x45350B00 AS Date), CAST(0x45350B00 AS Date), CAST(0x45350B00 AS Date))
SET IDENTITY_INSERT [dbo].[Transactions] OFF
/****** Object:  View [dbo].[vwBankBranches]    Script Date: 01/05/2013 15:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwBankBranches]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwBankBranches]
AS
SELECT     dbo.Banks.BankName + '' - '' + dbo.BankBranch.BranchName AS BankBranchName, dbo.BankBranch.BankSortCode, dbo.Banks.BankName, dbo.BankBranch.Bank, 
                      dbo.BankBranch.BranchCode, dbo.BankBranch.BranchName, dbo.Banks.BankCode
FROM         dbo.BankBranch INNER JOIN
                      dbo.Banks ON dbo.BankBranch.Bank = dbo.Banks.BankCode
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vwBankBranches', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[37] 4[4] 2[25] 3) )"
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BankBranch"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 181
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Banks"
            Begin Extent = 
               Top = 6
               Left = 227
               Bottom = 169
               Right = 378
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 4995
         Width = 2535
         Width = 2415
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwBankBranches'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vwBankBranches', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwBankBranches'
GO
/****** Object:  Table [dbo].[ClassSubjects]    Script Date: 01/05/2013 15:03:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassSubjects](
	[ClassSubjectId] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[SubjectCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Teacher] [int] NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
/****** Object:  Table [dbo].[RegisteredExams]    Script Date: 01/05/2013 15:03:29 ******/
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
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_RegisteredExams] PRIMARY KEY CLUSTERED 
(
	[RegdExamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  View [dbo].[vwTermlyFeeStatement]    Script Date: 01/05/2013 15:03:30 ******/
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
/****** Object:  Table [dbo].[StudentExams]    Script Date: 01/05/2013 15:03:30 ******/
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
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND name = N'IX_FK_StudentExams_Students')
CREATE NONCLUSTERED INDEX [IX_FK_StudentExams_Students] ON [dbo].[StudentExams] 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  ForeignKey [FK_Accounts_Customer]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Customer]
GO
/****** Object:  ForeignKey [FK_Attendances_Students]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendances_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [FK_Attendances_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendances_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [FK_Attendances_Students]
GO
/****** Object:  ForeignKey [FK_BankBranch_Banks]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[BankBranch]'))
ALTER TABLE [dbo].[BankBranch]  WITH CHECK ADD  CONSTRAINT [FK_BankBranch_Banks] FOREIGN KEY([Bank])
REFERENCES [dbo].[Banks] ([BankCode])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[BankBranch]'))
ALTER TABLE [dbo].[BankBranch] CHECK CONSTRAINT [FK_BankBranch_Banks]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Classes]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Classes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ClassSubjects_Classes] FOREIGN KEY([ClassId])
REFERENCES [dbo].[SchoolClasses] ([ClassId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Classes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] CHECK CONSTRAINT [FK_ClassSubjects_Classes]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Subjects]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ClassSubjects_Subjects] FOREIGN KEY([SubjectCode])
REFERENCES [dbo].[Subjects] ([ShortCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] CHECK CONSTRAINT [FK_ClassSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Teachers]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Teachers]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ClassSubjects_Teachers] FOREIGN KEY([Teacher])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Teachers]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] CHECK CONSTRAINT [FK_ClassSubjects_Teachers]
GO
/****** Object:  ForeignKey [FK_ExamPeriod_ExamTypes]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExamPeriod_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExamPeriod]'))
ALTER TABLE [dbo].[ExamPeriod]  WITH CHECK ADD  CONSTRAINT [FK_ExamPeriod_ExamTypes] FOREIGN KEY([ExamType])
REFERENCES [dbo].[ExamTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExamPeriod_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExamPeriod]'))
ALTER TABLE [dbo].[ExamPeriod] CHECK CONSTRAINT [FK_ExamPeriod_ExamTypes]
GO
/****** Object:  ForeignKey [FK_GradingSystemDet_GradingSystems]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]'))
ALTER TABLE [dbo].[GradingSystemDet]  WITH CHECK ADD  CONSTRAINT [FK_GradingSystemDet_GradingSystems] FOREIGN KEY([GradingSystemId])
REFERENCES [dbo].[GradingSystems] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDet]'))
ALTER TABLE [dbo].[GradingSystemDet] CHECK CONSTRAINT [FK_GradingSystemDet_GradingSystems]
GO
/****** Object:  ForeignKey [FK_MarkSheetStudents_FK00]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents]  WITH CHECK ADD  CONSTRAINT [FK_MarkSheetStudents_FK00] FOREIGN KEY([ExamId])
REFERENCES [dbo].[MarkSheetExams] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MarkSheetStudents_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]'))
ALTER TABLE [dbo].[MarkSheetStudents] CHECK CONSTRAINT [FK_MarkSheetStudents_FK00]
GO
/****** Object:  ForeignKey [FK_ProgrammeCourses_Programmes]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeCourses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeCourses]'))
ALTER TABLE [dbo].[ProgrammeCourses]  WITH CHECK ADD  CONSTRAINT [FK_ProgrammeCourses_Programmes] FOREIGN KEY([ProgrammeId])
REFERENCES [dbo].[Programmes] ([ProgrammeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeCourses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeCourses]'))
ALTER TABLE [dbo].[ProgrammeCourses] CHECK CONSTRAINT [FK_ProgrammeCourses_Programmes]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ClassSubjects]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ClassSubjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredExams_ClassSubjects] FOREIGN KEY([ClassSubjectId])
REFERENCES [dbo].[ClassSubjects] ([ClassSubjectId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ClassSubjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] CHECK CONSTRAINT [FK_RegisteredExams_ClassSubjects]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ExamPeriod]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredExams_ExamPeriod] FOREIGN KEY([ExamPeriodId])
REFERENCES [dbo].[ExamPeriod] ([ExamPeriodId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] CHECK CONSTRAINT [FK_RegisteredExams_ExamPeriod]
GO
/****** Object:  ForeignKey [FK_Reports_FK00]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_FK00] FOREIGN KEY([ReportGroup])
REFERENCES [dbo].[ReportGroups] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_FK00]
GO
/****** Object:  ForeignKey [FK_SchoolClasses_Programmes]    Script Date: 01/05/2013 15:03:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SchoolClasses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses]  WITH CHECK ADD  CONSTRAINT [FK_SchoolClasses_Programmes] FOREIGN KEY([ProgrammeId])
REFERENCES [dbo].[Programmes] ([ProgrammeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SchoolClasses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses] CHECK CONSTRAINT [FK_SchoolClasses_Programmes]
GO
/****** Object:  ForeignKey [FK_StudentExams_RegisteredExams]    Script Date: 01/05/2013 15:03:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams]  WITH CHECK ADD  CONSTRAINT [FK_StudentExams_RegisteredExams] FOREIGN KEY([RegdExamId])
REFERENCES [dbo].[RegisteredExams] ([RegdExamId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] CHECK CONSTRAINT [FK_StudentExams_RegisteredExams]
GO
/****** Object:  ForeignKey [FK_StudentExams_Students]    Script Date: 01/05/2013 15:03:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams]  WITH CHECK ADD  CONSTRAINT [FK_StudentExams_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] CHECK CONSTRAINT [FK_StudentExams_Students]
GO
/****** Object:  ForeignKey [FK_StudentProgresses_Students1]    Script Date: 01/05/2013 15:03:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students1]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses]  WITH CHECK ADD  CONSTRAINT [FK_StudentProgresses_Students1] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students1]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses] CHECK CONSTRAINT [FK_StudentProgresses_Students1]
GO
/****** Object:  ForeignKey [FK_SubSubjects_Subjects]    Script Date: 01/05/2013 15:03:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects]  WITH CHECK ADD  CONSTRAINT [FK_SubSubjects_Subjects] FOREIGN KEY([Subject])
REFERENCES [dbo].[Subjects] ([ShortCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects] CHECK CONSTRAINT [FK_SubSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_Transactions_FK00]    Script Date: 01/05/2013 15:03:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_FK00] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_FK00]
GO
/****** Object:  ForeignKey [FK_Transactions_FK01]    Script Date: 01/05/2013 15:03:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_FK01] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[TransactionTypes] ([TransactionTypeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_FK01]
GO
/****** Object:  ForeignKey [FK_Users_PasswordQuestion]    Script Date: 01/05/2013 15:03:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PasswordQuestion] FOREIGN KEY([PasswordQuestion])
REFERENCES [dbo].[SecurityQuestions] ([PasswordQuestion])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PasswordQuestion]
GO
