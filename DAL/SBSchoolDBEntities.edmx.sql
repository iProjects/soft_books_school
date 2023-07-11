
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/22/2013 11:24:22
-- Generated from EDMX file: C:\working projects\Tests\SBSchool\DAL\SBSchoolDBEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SBSchoolDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Accounts_AccountTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_AccountTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Accounts_COA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_COA];
GO
IF OBJECT_ID(N'[dbo].[FK_Accounts_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_Customers];
GO
IF OBJECT_ID(N'[dbo].[FK_Attendances_Students]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Attendances] DROP CONSTRAINT [FK_Attendances_Students];
GO
IF OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankBranches] DROP CONSTRAINT [FK_BankBranch_Banks];
GO
IF OBJECT_ID(N'[dbo].[FK_Class_FK00]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SchoolClasses] DROP CONSTRAINT [FK_Class_FK00];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassSubjects_SchoolClasses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_SchoolClasses];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Subjects];
GO
IF OBJECT_ID(N'[dbo].[FK_Discipline_DisciplinaryCategories]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Discipline] DROP CONSTRAINT [FK_Discipline_DisciplinaryCategories];
GO
IF OBJECT_ID(N'[dbo].[FK_Discipline_Students]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Discipline] DROP CONSTRAINT [FK_Discipline_Students];
GO
IF OBJECT_ID(N'[dbo].[FK_Exam_ExamPeriod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exam] DROP CONSTRAINT [FK_Exam_ExamPeriod];
GO
IF OBJECT_ID(N'[dbo].[FK_FeeStructureAcademic_FeesStructure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FeeStructureAcademic] DROP CONSTRAINT [FK_FeeStructureAcademic_FeesStructure];
GO
IF OBJECT_ID(N'[dbo].[FK_FeeStructureOthers_FeesStructure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FeeStructureOthers] DROP CONSTRAINT [FK_FeeStructureOthers_FeesStructure];
GO
IF OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GradingSystemDets] DROP CONSTRAINT [FK_GradingSystemDet_GradingSystems];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationProperties_Locations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationProperties] DROP CONSTRAINT [FK_LocationProperties_Locations];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgrammeCourses_Programmes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgrammeYearCourses] DROP CONSTRAINT [FK_ProgrammeCourses_Programmes];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgrammeYears_Programmes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgrammeYears] DROP CONSTRAINT [FK_ProgrammeYears_Programmes];
GO
IF OBJECT_ID(N'[dbo].[FK_RegisteredExams_Exam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_Exam];
GO
IF OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_ExamTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Reports_FK00]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_Reports_FK00];
GO
IF OBJECT_ID(N'[dbo].[FK_ResidenceHallRooms_ResidenceHalls]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResidenceHallRooms] DROP CONSTRAINT [FK_ResidenceHallRooms_ResidenceHalls];
GO
IF OBJECT_ID(N'[dbo].[FK_SchoolClasses_ProgrammeYears]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SchoolClasses] DROP CONSTRAINT [FK_SchoolClasses_ProgrammeYears];
GO
IF OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Settings] DROP CONSTRAINT [FK_Settings_SettingsGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentExams] DROP CONSTRAINT [FK_StudentExams_RegisteredExams1];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentExams_Students]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentExams] DROP CONSTRAINT [FK_StudentExams_Students];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentProgresses] DROP CONSTRAINT [FK_StudentProgresses_Students];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentsExamResults_Exam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentsExamResults] DROP CONSTRAINT [FK_StudentsExamResults_Exam];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentsExamResultsDetail_StudentsExamResults]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentsExamResultsDetail] DROP CONSTRAINT [FK_StudentsExamResultsDetail_StudentsExamResults];
GO
IF OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubSubjects] DROP CONSTRAINT [FK_SubSubjects_Subjects];
GO
IF OBJECT_ID(N'[dbo].[FK_TimeTable_ClassStreams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimeTables] DROP CONSTRAINT [FK_TimeTable_ClassStreams];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_Accounts];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_FK01]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_FK01];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_PasswordQuestion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[AccountTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountTypes];
GO
IF OBJECT_ID(N'[dbo].[Attendances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attendances];
GO
IF OBJECT_ID(N'[dbo].[BankBranches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankBranches];
GO
IF OBJECT_ID(N'[dbo].[Banks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Banks];
GO
IF OBJECT_ID(N'[dbo].[ClassStreams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassStreams];
GO
IF OBJECT_ID(N'[dbo].[ClassSubjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassSubjects];
GO
IF OBJECT_ID(N'[dbo].[COA]', 'U') IS NOT NULL
    DROP TABLE [dbo].[COA];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[DisciplinaryCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DisciplinaryCategories];
GO
IF OBJECT_ID(N'[dbo].[Discipline]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Discipline];
GO
IF OBJECT_ID(N'[dbo].[Exam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exam];
GO
IF OBJECT_ID(N'[dbo].[ExamPeriod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExamPeriod];
GO
IF OBJECT_ID(N'[dbo].[ExamTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExamTypes];
GO
IF OBJECT_ID(N'[dbo].[FeesStructure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeesStructure];
GO
IF OBJECT_ID(N'[dbo].[FeeStructureAcademic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeeStructureAcademic];
GO
IF OBJECT_ID(N'[dbo].[FeeStructureOthers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeeStructureOthers];
GO
IF OBJECT_ID(N'[dbo].[GradingSystemDets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GradingSystemDets];
GO
IF OBJECT_ID(N'[dbo].[GradingSystems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GradingSystems];
GO
IF OBJECT_ID(N'[dbo].[spUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spUsers];
GO
IF OBJECT_ID(N'[dbo].[LocationProperties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationProperties];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[MarksheetArchives]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarksheetArchives];
GO
IF OBJECT_ID(N'[dbo].[MarkSheetExams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarkSheetExams];
GO
IF OBJECT_ID(N'[dbo].[MarkSheetStudents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarkSheetStudents];
GO
IF OBJECT_ID(N'[dbo].[Parents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parents];
GO
IF OBJECT_ID(N'[dbo].[Programmes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Programmes];
GO
IF OBJECT_ID(N'[dbo].[ProgrammeYearCourses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgrammeYearCourses];
GO
IF OBJECT_ID(N'[dbo].[ProgrammeYears]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgrammeYears];
GO
IF OBJECT_ID(N'[dbo].[RegisteredExams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegisteredExams];
GO
IF OBJECT_ID(N'[dbo].[ReportGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReportGroups];
GO
IF OBJECT_ID(N'[dbo].[Reports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reports];
GO
IF OBJECT_ID(N'[dbo].[ResidenceHallRooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResidenceHallRooms];
GO
IF OBJECT_ID(N'[dbo].[ResidenceHalls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResidenceHalls];
GO
IF OBJECT_ID(N'[dbo].[Residences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Residences];
GO
IF OBJECT_ID(N'[dbo].[RoleRights]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleRights];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[RuleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RuleSet];
GO
IF OBJECT_ID(N'[dbo].[SchoolClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SchoolClasses];
GO
IF OBJECT_ID(N'[dbo].[Schools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schools];
GO
IF OBJECT_ID(N'[dbo].[SecurityQuestions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecurityQuestions];
GO
IF OBJECT_ID(N'[dbo].[Settings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Settings];
GO
IF OBJECT_ID(N'[dbo].[SettingsGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SettingsGroups];
GO
IF OBJECT_ID(N'[dbo].[StudentExams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentExams];
GO
IF OBJECT_ID(N'[dbo].[StudentProgresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentProgresses];
GO
IF OBJECT_ID(N'[dbo].[StudentProgresses_Temp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentProgresses_Temp];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[StudentsExamResults]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsExamResults];
GO
IF OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsExamResultsDetail];
GO
IF OBJECT_ID(N'[dbo].[StudentSubjectTagets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSubjectTagets];
GO
IF OBJECT_ID(N'[dbo].[Subjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subjects];
GO
IF OBJECT_ID(N'[dbo].[SubSubjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubSubjects];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teachers];
GO
IF OBJECT_ID(N'[dbo].[TimeTableDets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeTableDets];
GO
IF OBJECT_ID(N'[dbo].[TimeTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeTables];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO
IF OBJECT_ID(N'[dbo].[TransactionTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionTypes];
GO
IF OBJECT_ID(N'[dbo].[Transport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transport];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[SBSchoolDBModelStoreContainer].[vwBankBranches]', 'U') IS NOT NULL
    DROP TABLE [SBSchoolDBModelStoreContainer].[vwBankBranches];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [AccountID] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [AccountName] nvarchar(255)  NOT NULL,
    [AccountNo] nvarchar(50)  NOT NULL,
    [AccountTypeId] int  NULL,
    [COAId] int  NOT NULL,
    [Branch] nvarchar(50)  NULL,
    [SchoolBranch] int  NULL,
    [PassFlag] nvarchar(50)  NULL,
    [BookBalance] decimal(19,4)  NOT NULL,
    [ClearedBalance] decimal(19,4)  NOT NULL,
    [InterestRate] float  NOT NULL,
    [AccruedInt] decimal(19,4)  NOT NULL,
    [Limit] decimal(19,4)  NOT NULL,
    [Bal30] decimal(19,4)  NULL,
    [Bal60] decimal(19,4)  NULL,
    [Bal90] decimal(19,4)  NULL,
    [BalOver90] decimal(19,4)  NULL,
    [IntRate30] float  NULL,
    [IntRate60] float  NULL,
    [IntRate90] float  NULL,
    [IntRateOver90] float  NULL,
    [Closed] bit  NULL
);
GO

-- Creating table 'AccountTypes'
CREATE TABLE [dbo].[AccountTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nchar(10)  NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'Attendances'
CREATE TABLE [dbo].[Attendances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [SubjectShortCode] nvarchar(10)  NOT NULL,
    [StartDateTime] datetime  NOT NULL,
    [EndDateTime] datetime  NOT NULL,
    [Attended] bit  NOT NULL,
    [ReasonForNotAttending] nvarchar(150)  NULL
);
GO

-- Creating table 'BankBranches'
CREATE TABLE [dbo].[BankBranches] (
    [BankSortCode] nvarchar(50)  NOT NULL,
    [BranchCode] nvarchar(50)  NOT NULL,
    [BankCode] nvarchar(50)  NOT NULL,
    [BranchName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Banks'
CREATE TABLE [dbo].[Banks] (
    [BankCode] nvarchar(50)  NOT NULL,
    [BankName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ClassStreams'
CREATE TABLE [dbo].[ClassStreams] (
    [ClassStreamId] int IDENTITY(1,1) NOT NULL,
    [SchoolClass] int  NOT NULL,
    [Description] varchar(50)  NULL
);
GO

-- Creating table 'ClassSubjects'
CREATE TABLE [dbo].[ClassSubjects] (
    [ClassSubjectId] int IDENTITY(1,1) NOT NULL,
    [ClassId] int  NOT NULL,
    [SubjectCode] nvarchar(10)  NOT NULL,
    [SubjectTeacher] int  NULL,
    [Status] nchar(1)  NULL,
    [Room] nvarchar(50)  NULL
);
GO

-- Creating table 'COAs'
CREATE TABLE [dbo].[COAs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nchar(10)  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [COALevel] int  NOT NULL,
    [Parent] int  NOT NULL,
    [Rorder] int  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [CustomerNo] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(50)  NULL,
    [Telephone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Branch] nvarchar(50)  NULL,
    [BillToName] nvarchar(250)  NULL,
    [BillToAddress] nvarchar(250)  NULL,
    [BillToTelephone] nvarchar(250)  NULL,
    [BillToEmail] nvarchar(250)  NULL,
    [StudentId] int  NULL
);
GO

-- Creating table 'DisciplinaryCategories'
CREATE TABLE [dbo].[DisciplinaryCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nchar(10)  NOT NULL,
    [Description] varchar(50)  NOT NULL
);
GO

-- Creating table 'Disciplines'
CREATE TABLE [dbo].[Disciplines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [DisciplineCategoryId] int  NOT NULL,
    [DisciplinaryDate] datetime  NOT NULL,
    [Incident] nvarchar(300)  NOT NULL,
    [Severity] int  NOT NULL,
    [ActionRecommended] nvarchar(100)  NULL,
    [ActionTaken] nvarchar(100)  NULL,
    [DisciplineRating] nvarchar(100)  NULL,
    [Review] nvarchar(100)  NULL
);
GO

-- Creating table 'Exams'
CREATE TABLE [dbo].[Exams] (
    [ExamId] int IDENTITY(1,1) NOT NULL,
    [ExamPeriodId] int  NOT NULL,
    [ClassId] int  NOT NULL,
    [SubjectShortCode] nvarchar(10)  NOT NULL,
    [LastModified] datetime  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [Enabled] bit  NOT NULL,
    [Closed] bit  NOT NULL
);
GO

-- Creating table 'ExamPeriods'
CREATE TABLE [dbo].[ExamPeriods] (
    [ExamPeriodId] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Term] int  NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [Status] nchar(10)  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL
);
GO

-- Creating table 'ExamTypes'
CREATE TABLE [dbo].[ExamTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nchar(5)  NULL,
    [Description] nvarchar(50)  NULL,
    [ROrder] int  NULL,
    [PercentageContribution] int  NULL
);
GO

-- Creating table 'FeesStructures'
CREATE TABLE [dbo].[FeesStructures] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [Year] int  NOT NULL
);
GO

-- Creating table 'FeeStructureAcademics'
CREATE TABLE [dbo].[FeeStructureAcademics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FeeStructureId] int  NULL,
    [SchoolClassId] int  NOT NULL,
    [AccountId] int  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [AmountPeriod] nchar(1)  NOT NULL
);
GO

-- Creating table 'FeeStructureOthers'
CREATE TABLE [dbo].[FeeStructureOthers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FeeStructureId] int  NULL,
    [AccountId] int  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [AmountPeriod] nchar(1)  NOT NULL,
    [ApplicableTo] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'GradingSystemDets'
CREATE TABLE [dbo].[GradingSystemDets] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GradingSystemId] int  NOT NULL,
    [LMark] float  NOT NULL,
    [UMark] float  NOT NULL,
    [Grade] nchar(10)  NOT NULL,
    [Point] float  NULL
);
GO

-- Creating table 'GradingSystems'
CREATE TABLE [dbo].[GradingSystems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'spUsers'
CREATE TABLE [dbo].[spUsers] (
    [UserId] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NULL,
    [Role] nvarchar(50)  NULL,
    [Locked] bit  NULL
);
GO

-- Creating table 'LocationProperties'
CREATE TABLE [dbo].[LocationProperties] (
    [LocKey] varchar(20)  NOT NULL,
    [LocValue] varchar(max)  NULL,
    [LocValueType] varchar(50)  NULL,
    [Description] varchar(50)  NULL,
    [LocationId] int  NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Parent] int  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [TransportCost] decimal(19,4)  NULL,
    [BoardingCost] decimal(19,4)  NULL
);
GO

-- Creating table 'MarksheetArchives'
CREATE TABLE [dbo].[MarksheetArchives] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Year] int  NULL,
    [Term] int  NULL,
    [ExamType] nvarchar(50)  NULL,
    [Class] varchar(50)  NULL,
    [Teacher] int  NULL,
    [Student] int  NULL,
    [Subject] nvarchar(50)  NULL,
    [Mark] int  NULL,
    [OutOf] int  NULL,
    [Grade] nvarchar(1)  NULL
);
GO

-- Creating table 'MarkSheetExams'
CREATE TABLE [dbo].[MarkSheetExams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Year] int  NULL,
    [Term] int  NULL,
    [ExamDate] datetime  NULL,
    [Class] nvarchar(50)  NULL,
    [Subject] nvarchar(50)  NULL,
    [ExamType] nvarchar(50)  NULL,
    [LastModified] datetime  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [Enabled] bit  NOT NULL,
    [Closed] bit  NOT NULL
);
GO

-- Creating table 'MarkSheetStudents'
CREATE TABLE [dbo].[MarkSheetStudents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExamId] int  NULL,
    [StudentId] int  NULL,
    [Mark] int  NULL,
    [LastModified] datetime  NULL,
    [ModifiedBy] nvarchar(50)  NULL
);
GO

-- Creating table 'Parents'
CREATE TABLE [dbo].[Parents] (
    [ParentId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Gender] nchar(1)  NULL,
    [CellPhoneNo] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [Occupation] nvarchar(255)  NULL,
    [Maritalstatus] nchar(1)  NULL,
    [Relationship] nvarchar(50)  NULL
);
GO

-- Creating table 'Programmes'
CREATE TABLE [dbo].[Programmes] (
    [ProgrammeId] nchar(10)  NOT NULL,
    [Description] varchar(250)  NOT NULL,
    [Hours] int  NULL,
    [Fees] decimal(19,4)  NULL
);
GO

-- Creating table 'ProgrammeYearCourses'
CREATE TABLE [dbo].[ProgrammeYearCourses] (
    [ProgrammeCourseId] int IDENTITY(1,1) NOT NULL,
    [ProgrammeId] nchar(10)  NOT NULL,
    [ProgrammeYearId] int  NOT NULL,
    [CourseId] nvarchar(10)  NOT NULL,
    [Semester] int  NOT NULL,
    [NoOfHrs] int  NULL,
    [TuitionFees] decimal(19,4)  NULL,
    [ExamFees] decimal(19,4)  NULL,
    [ResitFees] decimal(19,4)  NULL
);
GO

-- Creating table 'ProgrammeYears'
CREATE TABLE [dbo].[ProgrammeYears] (
    [ProgrammeYearId] int IDENTITY(1,1) NOT NULL,
    [ProgrammeId] nchar(10)  NOT NULL,
    [Year] int  NOT NULL,
    [Description] nvarchar(250)  NULL,
    [NextYr] int  NULL,
    [Fees] decimal(19,4)  NULL
);
GO

-- Creating table 'RegisteredExams'
CREATE TABLE [dbo].[RegisteredExams] (
    [RegdExamId] int IDENTITY(1,1) NOT NULL,
    [ExamId] int  NOT NULL,
    [ExamTypeId] int  NOT NULL,
    [RoomId] int  NULL,
    [ExamDate] datetime  NULL,
    [LastModified] datetime  NULL,
    [Invilgilator] nvarchar(50)  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [Status] nchar(10)  NULL,
    [Contribution] float  NULL,
    [ContributionFlag] bit  NOT NULL
);
GO

-- Creating table 'ReportGroups'
CREATE TABLE [dbo].[ReportGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReportGroup1] nvarchar(50)  NULL
);
GO

-- Creating table 'Reports'
CREATE TABLE [dbo].[Reports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReportName] nvarchar(50)  NULL,
    [ReportGroup] int  NULL,
    [ResouceFile] nvarchar(50)  NULL
);
GO

-- Creating table 'ResidenceHallRooms'
CREATE TABLE [dbo].[ResidenceHallRooms] (
    [RoomId] int IDENTITY(1,1) NOT NULL,
    [HallId] int  NOT NULL,
    [Room] nvarchar(150)  NULL,
    [Cost] decimal(19,4)  NULL
);
GO

-- Creating table 'ResidenceHalls'
CREATE TABLE [dbo].[ResidenceHalls] (
    [HallId] int IDENTITY(1,1) NOT NULL,
    [HallName] nvarchar(150)  NULL,
    [Location] nvarchar(150)  NULL
);
GO

-- Creating table 'Residences'
CREATE TABLE [dbo].[Residences] (
    [ResidenceId] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Cost] decimal(19,4)  NULL,
    [GPSCordinates] varchar(50)  NULL,
    [Title] varchar(50)  NULL
);
GO

-- Creating table 'RoleRights'
CREATE TABLE [dbo].[RoleRights] (
    [RoleRightId] int IDENTITY(1,1) NOT NULL,
    [RoleId] char(2)  NOT NULL,
    [Object] varchar(250)  NULL,
    [ObjectType] varchar(50)  NULL,
    [ObjectRight] char(3)  NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [RoomId] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nvarchar(10)  NULL,
    [Description] nvarchar(50)  NULL,
    [Capacity] nchar(10)  NULL
);
GO

-- Creating table 'RuleSets'
CREATE TABLE [dbo].[RuleSets] (
    [Name] nvarchar(128)  NOT NULL,
    [MajorVersion] int  NOT NULL,
    [MinorVersion] int  NOT NULL,
    [RuleSet1] nvarchar(max)  NOT NULL,
    [Status] smallint  NULL,
    [AssemblyPath] nvarchar(256)  NULL,
    [ActivityName] nvarchar(128)  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'SchoolClasses'
CREATE TABLE [dbo].[SchoolClasses] (
    [ClassId] int IDENTITY(1,1) NOT NULL,
    [ShortCode] varchar(15)  NOT NULL,
    [ClassName] nvarchar(100)  NOT NULL,
    [ProgrammeYearId] int  NOT NULL,
    [NoOfSubjects] int  NOT NULL,
    [ClassTeacher] int  NULL,
    [CurrentYrLevel] int  NULL,
    [NextYrLevel] int  NULL,
    [Remarks] nvarchar(250)  NULL
);
GO

-- Creating table 'Schools'
CREATE TABLE [dbo].[Schools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SchoolIndex] nvarchar(50)  NOT NULL,
    [SchoolName] nvarchar(50)  NOT NULL,
    [SchoolType] int  NOT NULL,
    [GradingSystem] int  NOT NULL,
    [Cellphone] nvarchar(50)  NULL,
    [Telephone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Address1] nvarchar(50)  NULL,
    [Address2] nvarchar(50)  NULL,
    [SMTPServer] nvarchar(50)  NULL,
    [SMSGateway] nvarchar(50)  NULL,
    [DefaultSchool] bit  NOT NULL,
    [GLCustomerId] int  NULL
);
GO

-- Creating table 'SecurityQuestions'
CREATE TABLE [dbo].[SecurityQuestions] (
    [PasswordQuestion] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Settings'
CREATE TABLE [dbo].[Settings] (
    [SSKey] varchar(20)  NOT NULL,
    [SSValue] varchar(max)  NULL,
    [SSValueType] varchar(50)  NULL,
    [Description] varchar(50)  NULL,
    [SGroup] int  NULL,
    [SSSystem] bit  NULL
);
GO

-- Creating table 'SettingsGroups'
CREATE TABLE [dbo].[SettingsGroups] (
    [Id] int  NOT NULL,
    [GroupName] varchar(50)  NOT NULL,
    [Parent] int  NOT NULL
);
GO

-- Creating table 'StudentExams'
CREATE TABLE [dbo].[StudentExams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [RegdExamId] int  NOT NULL,
    [Mark] float  NULL,
    [Status] nchar(10)  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [LastModified] datetime  NULL
);
GO

-- Creating table 'StudentProgresses'
CREATE TABLE [dbo].[StudentProgresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [Year] int  NOT NULL,
    [Term] int  NOT NULL,
    [ClassShortCode] nvarchar(50)  NOT NULL,
    [ExamTypeShortCode] nchar(10)  NOT NULL,
    [TeacherId] int  NULL,
    [TotalMarks] float  NULL,
    [TotalPoints] float  NULL,
    [Position] int  NULL,
    [MeanMarks] float  NULL,
    [MeanGrade] nvarchar(5)  NULL,
    [ClassTeacherRemark] nvarchar(max)  NULL,
    [HeadTeacherRemark] nvarchar(max)  NULL
);
GO

-- Creating table 'StudentProgresses_Temp'
CREATE TABLE [dbo].[StudentProgresses_Temp] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [Year] int  NOT NULL,
    [Term] int  NOT NULL,
    [ClassShortCode] nvarchar(50)  NOT NULL,
    [ExamTypeShortCode] nchar(10)  NOT NULL,
    [TeacherId] int  NULL,
    [TotalMarks] float  NULL,
    [TotalPoints] float  NULL,
    [Position] int  NULL,
    [MeanMarks] float  NULL,
    [MeanGrade] nvarchar(5)  NULL,
    [ClassTeacherRemark] nvarchar(max)  NULL,
    [HeadTeacherRemark] nvarchar(max)  NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [StudentId] int IDENTITY(1,1) NOT NULL,
    [SchoolId] int  NOT NULL,
    [CurrentClass] int  NOT NULL,
    [AdminNo] nvarchar(15)  NOT NULL,
    [StudentSurName] nvarchar(50)  NOT NULL,
    [StudentOtherNames] nvarchar(50)  NOT NULL,
    [Gender] nvarchar(10)  NOT NULL,
    [DateOfBirth] datetime  NULL,
    [Phone] nvarchar(20)  NULL,
    [Email] nvarchar(100)  NULL,
    [Homepage] nvarchar(100)  NULL,
    [StudentAddress] nvarchar(max)  NULL,
    [Status] nchar(5)  NULL,
    [KCPE] nchar(10)  NULL,
    [KCSE] nchar(10)  NULL,
    [AdmissionDate] datetime  NULL,
    [AdmittedBy] nvarchar(50)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [Photo] nvarchar(max)  NULL,
    [LastModifiedTime] datetime  NULL,
    [GLAccount] int  NULL,
    [CustomerID] int  NULL,
    [FatherName] nvarchar(50)  NULL,
    [FatherCellPhone] nvarchar(20)  NULL,
    [FatherOfficePhone] nvarchar(20)  NULL,
    [FatherEmail] nvarchar(100)  NULL,
    [MotherName] nvarchar(50)  NULL,
    [MotherCellPhone] nvarchar(20)  NULL,
    [MotherOfficePhone] nvarchar(20)  NULL,
    [MotherEmail] nvarchar(100)  NULL,
    [GuardianName] nvarchar(50)  NULL,
    [GuardianCellPhone] nvarchar(20)  NULL,
    [GuardianOfficePhone] nvarchar(20)  NULL,
    [GuardianEmail] nvarchar(100)  NULL,
    [PrevSchoolId] nvarchar(50)  NULL,
    [PrevSchoolName] nvarchar(100)  NULL,
    [PrevSchoolPhone] nvarchar(20)  NULL,
    [PrevSchoolAddress] nvarchar(100)  NULL,
    [ReasonForLeaving] nvarchar(max)  NULL,
    [ExtraCurricular1] nvarchar(50)  NULL,
    [ExtraCurricular2] nvarchar(50)  NULL,
    [ExtraCurricular3] nvarchar(50)  NULL,
    [Term1MeanGrade] nchar(10)  NULL,
    [Term2MeanGrade] nchar(10)  NULL,
    [Term3MeanGrade] nchar(10)  NULL,
    [Eligible] bit  NULL,
    [RequireTransport] bit  NULL,
    [TransportChargeType] nchar(1)  NULL,
    [FeesPayPlan] nchar(1)  NULL,
    [Boarder] bit  NULL,
    [ResidenceHallRoomId] int  NULL,
    [ResidenceId] int  NULL,
    [DoctorName] nvarchar(50)  NULL,
    [Ailments] nvarchar(50)  NULL,
    [Foods] nvarchar(50)  NULL,
    [Allergies] nvarchar(50)  NULL,
    [HostelName] nvarchar(50)  NULL,
    [BedNo] nvarchar(50)  NULL
);
GO

-- Creating table 'StudentsExamResults'
CREATE TABLE [dbo].[StudentsExamResults] (
    [StudentExamResultId] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [Examid] int  NOT NULL,
    [SchoolClass] int  NOT NULL,
    [TeacherId] int  NULL,
    [TotalMarks_Target] float  NULL,
    [TotalPoints_Target] float  NULL,
    [Position_Target] int  NULL,
    [MeanMarks_Target] float  NULL,
    [MeanGrade_Target] nvarchar(5)  NULL,
    [TotalMarks] float  NULL,
    [TotalPoints] float  NULL,
    [Position] int  NULL,
    [MeanMarks] float  NULL,
    [MeanGrade] nvarchar(5)  NULL,
    [ClassTeacherRemark] nvarchar(max)  NULL,
    [HeadTeacherRemark] nvarchar(max)  NULL,
    [Status] nchar(10)  NULL
);
GO

-- Creating table 'StudentsExamResultsDetails'
CREATE TABLE [dbo].[StudentsExamResultsDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentExamResultId] int  NULL,
    [Subject] nvarchar(10)  NULL,
    [Mark_Target] float  NULL,
    [Grade_Target] nchar(10)  NULL,
    [Mark] float  NULL,
    [Grade] nchar(10)  NULL
);
GO

-- Creating table 'StudentSubjectTagets'
CREATE TABLE [dbo].[StudentSubjectTagets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NULL,
    [SubjectShortCode] nchar(10)  NULL,
    [Target] float  NULL
);
GO

-- Creating table 'Subjects'
CREATE TABLE [dbo].[Subjects] (
    [ShortCode] nvarchar(10)  NOT NULL,
    [Description] nvarchar(250)  NULL,
    [OutOf] int  NULL,
    [PassMark] int  NULL,
    [Status] nchar(10)  NULL,
    [ROrder] int  NULL,
    [Remarks] nvarchar(250)  NULL,
    [NoOfRequiredHours] int  NULL,
    [Fees] decimal(19,4)  NULL
);
GO

-- Creating table 'SubSubjects'
CREATE TABLE [dbo].[SubSubjects] (
    [SubsubjectsId] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(10)  NOT NULL,
    [Description] nvarchar(50)  NULL,
    [OutOf] int  NULL,
    [PassMark] int  NULL,
    [GroupingFactor] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Teachers'
CREATE TABLE [dbo].[Teachers] (
    [TeacherId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [IDNo] nvarchar(50)  NOT NULL,
    [TSCNo] nvarchar(50)  NULL,
    [Position] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Status] nchar(10)  NULL,
    [DateJoined] datetime  NULL,
    [DateLeft] datetime  NULL
);
GO

-- Creating table 'TimeTableDets'
CREATE TABLE [dbo].[TimeTableDets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimeTableId] int  NOT NULL,
    [SubjectId] int  NULL,
    [RoomId] int  NULL,
    [Recurrent] nchar(1)  NULL,
    [Activity] varchar(50)  NULL,
    [Venue] varchar(50)  NULL,
    [Text] varchar(50)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [A] int  NOT NULL,
    [R] int  NOT NULL,
    [G] int  NOT NULL,
    [B] int  NOT NULL
);
GO

-- Creating table 'TimeTables'
CREATE TABLE [dbo].[TimeTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassStreamId] int  NOT NULL,
    [ClassTimeTableXML] varchar(max)  NOT NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [TransactionID] int IDENTITY(1,1) NOT NULL,
    [TransactionTypeId] int  NOT NULL,
    [AccountID] int  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [PostDate] datetime  NOT NULL,
    [RecordDate] datetime  NOT NULL,
    [ValueDate] datetime  NULL,
    [Narrative] nvarchar(255)  NULL,
    [StatementFlag] nvarchar(255)  NULL,
    [Authorizer] nvarchar(255)  NULL,
    [UserID] nvarchar(255)  NULL
);
GO

-- Creating table 'TransactionTypes'
CREATE TABLE [dbo].[TransactionTypes] (
    [TransactionTypeID] int IDENTITY(1,1) NOT NULL,
    [DebitCredit] char(1)  NOT NULL,
    [ShortCode] nvarchar(5)  NOT NULL,
    [Description] nvarchar(255)  NULL,
    [DefaultAmount] decimal(19,4)  NULL,
    [DefaultCreditAccount] int  NULL,
    [DefaultDebitAccount] int  NULL,
    [DefaultCreditNarrative] nvarchar(255)  NULL,
    [DefaultDebitNarrative] nvarchar(255)  NULL,
    [TxnTypeView] char(1)  NULL,
    [CommissionType] char(2)  NULL,
    [FlatRate] decimal(18,0)  NULL,
    [PercentageRate] float  NULL,
    [DialogFlag] char(1)  NULL,
    [ForcePost] nchar(1)  NULL
);
GO

-- Creating table 'Transports'
CREATE TABLE [dbo].[Transports] (
    [TransportId] int IDENTITY(1,1) NOT NULL,
    [ResidenceId] int  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [RoleId] char(2)  NOT NULL,
    [RoleName] nchar(15)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Name] nvarchar(50)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Email] nvarchar(100)  NULL,
    [PasswordHash] nvarchar(100)  NOT NULL,
    [PasswordSalt] nvarchar(10)  NOT NULL,
    [PasswordQuestion] nvarchar(200)  NOT NULL,
    [PasswordAnswerHash] nvarchar(100)  NOT NULL,
    [PasswordAnswerSalt] nvarchar(10)  NOT NULL,
    [UserType] char(1)  NOT NULL,
    [ProfileReset] tinyint  NOT NULL
);
GO

-- Creating table 'vwBankBranches'
CREATE TABLE [dbo].[vwBankBranches] (
    [BankBranchName] nvarchar(103)  NOT NULL,
    [BankSortCode] nvarchar(50)  NOT NULL,
    [BankName] nvarchar(50)  NOT NULL,
    [BankCode] nvarchar(50)  NOT NULL,
    [BranchCode] nvarchar(50)  NOT NULL,
    [BranchName] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AccountID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([AccountID] ASC);
GO

-- Creating primary key on [Id] in table 'AccountTypes'
ALTER TABLE [dbo].[AccountTypes]
ADD CONSTRAINT [PK_AccountTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Attendances'
ALTER TABLE [dbo].[Attendances]
ADD CONSTRAINT [PK_Attendances]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BankSortCode] in table 'BankBranches'
ALTER TABLE [dbo].[BankBranches]
ADD CONSTRAINT [PK_BankBranches]
    PRIMARY KEY CLUSTERED ([BankSortCode] ASC);
GO

-- Creating primary key on [BankCode] in table 'Banks'
ALTER TABLE [dbo].[Banks]
ADD CONSTRAINT [PK_Banks]
    PRIMARY KEY CLUSTERED ([BankCode] ASC);
GO

-- Creating primary key on [ClassStreamId] in table 'ClassStreams'
ALTER TABLE [dbo].[ClassStreams]
ADD CONSTRAINT [PK_ClassStreams]
    PRIMARY KEY CLUSTERED ([ClassStreamId] ASC);
GO

-- Creating primary key on [ClassSubjectId] in table 'ClassSubjects'
ALTER TABLE [dbo].[ClassSubjects]
ADD CONSTRAINT [PK_ClassSubjects]
    PRIMARY KEY CLUSTERED ([ClassSubjectId] ASC);
GO

-- Creating primary key on [Id] in table 'COAs'
ALTER TABLE [dbo].[COAs]
ADD CONSTRAINT [PK_COAs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [Id] in table 'DisciplinaryCategories'
ALTER TABLE [dbo].[DisciplinaryCategories]
ADD CONSTRAINT [PK_DisciplinaryCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Disciplines'
ALTER TABLE [dbo].[Disciplines]
ADD CONSTRAINT [PK_Disciplines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ExamId] in table 'Exams'
ALTER TABLE [dbo].[Exams]
ADD CONSTRAINT [PK_Exams]
    PRIMARY KEY CLUSTERED ([ExamId] ASC);
GO

-- Creating primary key on [ExamPeriodId] in table 'ExamPeriods'
ALTER TABLE [dbo].[ExamPeriods]
ADD CONSTRAINT [PK_ExamPeriods]
    PRIMARY KEY CLUSTERED ([ExamPeriodId] ASC);
GO

-- Creating primary key on [Id] in table 'ExamTypes'
ALTER TABLE [dbo].[ExamTypes]
ADD CONSTRAINT [PK_ExamTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeesStructures'
ALTER TABLE [dbo].[FeesStructures]
ADD CONSTRAINT [PK_FeesStructures]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeeStructureAcademics'
ALTER TABLE [dbo].[FeeStructureAcademics]
ADD CONSTRAINT [PK_FeeStructureAcademics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeeStructureOthers'
ALTER TABLE [dbo].[FeeStructureOthers]
ADD CONSTRAINT [PK_FeeStructureOthers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'GradingSystemDets'
ALTER TABLE [dbo].[GradingSystemDets]
ADD CONSTRAINT [PK_GradingSystemDets]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'GradingSystems'
ALTER TABLE [dbo].[GradingSystems]
ADD CONSTRAINT [PK_GradingSystems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'spUsers'
ALTER TABLE [dbo].[spUsers]
ADD CONSTRAINT [PK_ISUserLogins]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [LocKey] in table 'LocationProperties'
ALTER TABLE [dbo].[LocationProperties]
ADD CONSTRAINT [PK_LocationProperties]
    PRIMARY KEY CLUSTERED ([LocKey] ASC);
GO

-- Creating primary key on [Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarksheetArchives'
ALTER TABLE [dbo].[MarksheetArchives]
ADD CONSTRAINT [PK_MarksheetArchives]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarkSheetExams'
ALTER TABLE [dbo].[MarkSheetExams]
ADD CONSTRAINT [PK_MarkSheetExams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarkSheetStudents'
ALTER TABLE [dbo].[MarkSheetStudents]
ADD CONSTRAINT [PK_MarkSheetStudents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ParentId] in table 'Parents'
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [PK_Parents]
    PRIMARY KEY CLUSTERED ([ParentId] ASC);
GO

-- Creating primary key on [ProgrammeId] in table 'Programmes'
ALTER TABLE [dbo].[Programmes]
ADD CONSTRAINT [PK_Programmes]
    PRIMARY KEY CLUSTERED ([ProgrammeId] ASC);
GO

-- Creating primary key on [ProgrammeCourseId] in table 'ProgrammeYearCourses'
ALTER TABLE [dbo].[ProgrammeYearCourses]
ADD CONSTRAINT [PK_ProgrammeYearCourses]
    PRIMARY KEY CLUSTERED ([ProgrammeCourseId] ASC);
GO

-- Creating primary key on [ProgrammeYearId] in table 'ProgrammeYears'
ALTER TABLE [dbo].[ProgrammeYears]
ADD CONSTRAINT [PK_ProgrammeYears]
    PRIMARY KEY CLUSTERED ([ProgrammeYearId] ASC);
GO

-- Creating primary key on [RegdExamId] in table 'RegisteredExams'
ALTER TABLE [dbo].[RegisteredExams]
ADD CONSTRAINT [PK_RegisteredExams]
    PRIMARY KEY CLUSTERED ([RegdExamId] ASC);
GO

-- Creating primary key on [Id] in table 'ReportGroups'
ALTER TABLE [dbo].[ReportGroups]
ADD CONSTRAINT [PK_ReportGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [PK_Reports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RoomId] in table 'ResidenceHallRooms'
ALTER TABLE [dbo].[ResidenceHallRooms]
ADD CONSTRAINT [PK_ResidenceHallRooms]
    PRIMARY KEY CLUSTERED ([RoomId] ASC);
GO

-- Creating primary key on [HallId] in table 'ResidenceHalls'
ALTER TABLE [dbo].[ResidenceHalls]
ADD CONSTRAINT [PK_ResidenceHalls]
    PRIMARY KEY CLUSTERED ([HallId] ASC);
GO

-- Creating primary key on [ResidenceId] in table 'Residences'
ALTER TABLE [dbo].[Residences]
ADD CONSTRAINT [PK_Residences]
    PRIMARY KEY CLUSTERED ([ResidenceId] ASC);
GO

-- Creating primary key on [RoleRightId] in table 'RoleRights'
ALTER TABLE [dbo].[RoleRights]
ADD CONSTRAINT [PK_RoleRights]
    PRIMARY KEY CLUSTERED ([RoleRightId] ASC);
GO

-- Creating primary key on [RoomId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([RoomId] ASC);
GO

-- Creating primary key on [Name], [MajorVersion], [MinorVersion] in table 'RuleSets'
ALTER TABLE [dbo].[RuleSets]
ADD CONSTRAINT [PK_RuleSets]
    PRIMARY KEY CLUSTERED ([Name], [MajorVersion], [MinorVersion] ASC);
GO

-- Creating primary key on [ClassId] in table 'SchoolClasses'
ALTER TABLE [dbo].[SchoolClasses]
ADD CONSTRAINT [PK_SchoolClasses]
    PRIMARY KEY CLUSTERED ([ClassId] ASC);
GO

-- Creating primary key on [Id] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [PK_Schools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PasswordQuestion] in table 'SecurityQuestions'
ALTER TABLE [dbo].[SecurityQuestions]
ADD CONSTRAINT [PK_SecurityQuestions]
    PRIMARY KEY CLUSTERED ([PasswordQuestion] ASC);
GO

-- Creating primary key on [SSKey] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [PK_Settings]
    PRIMARY KEY CLUSTERED ([SSKey] ASC);
GO

-- Creating primary key on [Id] in table 'SettingsGroups'
ALTER TABLE [dbo].[SettingsGroups]
ADD CONSTRAINT [PK_SettingsGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentExams'
ALTER TABLE [dbo].[StudentExams]
ADD CONSTRAINT [PK_StudentExams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentProgresses'
ALTER TABLE [dbo].[StudentProgresses]
ADD CONSTRAINT [PK_StudentProgresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentProgresses_Temp'
ALTER TABLE [dbo].[StudentProgresses_Temp]
ADD CONSTRAINT [PK_StudentProgresses_Temp]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [StudentId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- Creating primary key on [StudentExamResultId] in table 'StudentsExamResults'
ALTER TABLE [dbo].[StudentsExamResults]
ADD CONSTRAINT [PK_StudentsExamResults]
    PRIMARY KEY CLUSTERED ([StudentExamResultId] ASC);
GO

-- Creating primary key on [Id] in table 'StudentsExamResultsDetails'
ALTER TABLE [dbo].[StudentsExamResultsDetails]
ADD CONSTRAINT [PK_StudentsExamResultsDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentSubjectTagets'
ALTER TABLE [dbo].[StudentSubjectTagets]
ADD CONSTRAINT [PK_StudentSubjectTagets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ShortCode] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [PK_Subjects]
    PRIMARY KEY CLUSTERED ([ShortCode] ASC);
GO

-- Creating primary key on [SubsubjectsId] in table 'SubSubjects'
ALTER TABLE [dbo].[SubSubjects]
ADD CONSTRAINT [PK_SubSubjects]
    PRIMARY KEY CLUSTERED ([SubsubjectsId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TeacherId] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [PK_Teachers]
    PRIMARY KEY CLUSTERED ([TeacherId] ASC);
GO

-- Creating primary key on [Id] in table 'TimeTableDets'
ALTER TABLE [dbo].[TimeTableDets]
ADD CONSTRAINT [PK_TimeTableDets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimeTables'
ALTER TABLE [dbo].[TimeTables]
ADD CONSTRAINT [PK_TimeTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TransactionID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([TransactionID] ASC);
GO

-- Creating primary key on [TransactionTypeID] in table 'TransactionTypes'
ALTER TABLE [dbo].[TransactionTypes]
ADD CONSTRAINT [PK_TransactionTypes]
    PRIMARY KEY CLUSTERED ([TransactionTypeID] ASC);
GO

-- Creating primary key on [TransportId] in table 'Transports'
ALTER TABLE [dbo].[Transports]
ADD CONSTRAINT [PK_Transports]
    PRIMARY KEY CLUSTERED ([TransportId] ASC);
GO

-- Creating primary key on [RoleId] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [Name] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [BankBranchName], [BankSortCode], [BankName], [BankCode], [BranchCode], [BranchName] in table 'vwBankBranches'
ALTER TABLE [dbo].[vwBankBranches]
ADD CONSTRAINT [PK_vwBankBranches]
    PRIMARY KEY CLUSTERED ([BankBranchName], [BankSortCode], [BankName], [BankCode], [BranchCode], [BranchName] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountTypeId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_Accounts_AccountTypes]
    FOREIGN KEY ([AccountTypeId])
    REFERENCES [dbo].[AccountTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Accounts_AccountTypes'
CREATE INDEX [IX_FK_Accounts_AccountTypes]
ON [dbo].[Accounts]
    ([AccountTypeId]);
GO

-- Creating foreign key on [COAId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_Accounts_COA]
    FOREIGN KEY ([COAId])
    REFERENCES [dbo].[COAs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Accounts_COA'
CREATE INDEX [IX_FK_Accounts_COA]
ON [dbo].[Accounts]
    ([COAId]);
GO

-- Creating foreign key on [CustomerId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_Accounts_Customers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Accounts_Customers'
CREATE INDEX [IX_FK_Accounts_Customers]
ON [dbo].[Accounts]
    ([CustomerId]);
GO

-- Creating foreign key on [AccountID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_Accounts]
    FOREIGN KEY ([AccountID])
    REFERENCES [dbo].[Accounts]
        ([AccountID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_Accounts'
CREATE INDEX [IX_FK_Transactions_Accounts]
ON [dbo].[Transactions]
    ([AccountID]);
GO

-- Creating foreign key on [StudentId] in table 'Attendances'
ALTER TABLE [dbo].[Attendances]
ADD CONSTRAINT [FK_Attendances_Students]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Attendances_Students'
CREATE INDEX [IX_FK_Attendances_Students]
ON [dbo].[Attendances]
    ([StudentId]);
GO

-- Creating foreign key on [BankCode] in table 'BankBranches'
ALTER TABLE [dbo].[BankBranches]
ADD CONSTRAINT [FK_BankBranch_Banks]
    FOREIGN KEY ([BankCode])
    REFERENCES [dbo].[Banks]
        ([BankCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBranch_Banks'
CREATE INDEX [IX_FK_BankBranch_Banks]
ON [dbo].[BankBranches]
    ([BankCode]);
GO

-- Creating foreign key on [ClassStreamId] in table 'TimeTables'
ALTER TABLE [dbo].[TimeTables]
ADD CONSTRAINT [FK_TimeTable_ClassStreams]
    FOREIGN KEY ([ClassStreamId])
    REFERENCES [dbo].[ClassStreams]
        ([ClassStreamId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TimeTable_ClassStreams'
CREATE INDEX [IX_FK_TimeTable_ClassStreams]
ON [dbo].[TimeTables]
    ([ClassStreamId]);
GO

-- Creating foreign key on [ClassId] in table 'ClassSubjects'
ALTER TABLE [dbo].[ClassSubjects]
ADD CONSTRAINT [FK_ClassSubjects_SchoolClasses]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[SchoolClasses]
        ([ClassId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassSubjects_SchoolClasses'
CREATE INDEX [IX_FK_ClassSubjects_SchoolClasses]
ON [dbo].[ClassSubjects]
    ([ClassId]);
GO

-- Creating foreign key on [SubjectCode] in table 'ClassSubjects'
ALTER TABLE [dbo].[ClassSubjects]
ADD CONSTRAINT [FK_ClassSubjects_Subjects]
    FOREIGN KEY ([SubjectCode])
    REFERENCES [dbo].[Subjects]
        ([ShortCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassSubjects_Subjects'
CREATE INDEX [IX_FK_ClassSubjects_Subjects]
ON [dbo].[ClassSubjects]
    ([SubjectCode]);
GO

-- Creating foreign key on [DisciplineCategoryId] in table 'Disciplines'
ALTER TABLE [dbo].[Disciplines]
ADD CONSTRAINT [FK_Discipline_DisciplinaryCategories]
    FOREIGN KEY ([DisciplineCategoryId])
    REFERENCES [dbo].[DisciplinaryCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Discipline_DisciplinaryCategories'
CREATE INDEX [IX_FK_Discipline_DisciplinaryCategories]
ON [dbo].[Disciplines]
    ([DisciplineCategoryId]);
GO

-- Creating foreign key on [StudentId] in table 'Disciplines'
ALTER TABLE [dbo].[Disciplines]
ADD CONSTRAINT [FK_Discipline_Students]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Discipline_Students'
CREATE INDEX [IX_FK_Discipline_Students]
ON [dbo].[Disciplines]
    ([StudentId]);
GO

-- Creating foreign key on [ExamPeriodId] in table 'Exams'
ALTER TABLE [dbo].[Exams]
ADD CONSTRAINT [FK_Exam_ExamPeriod]
    FOREIGN KEY ([ExamPeriodId])
    REFERENCES [dbo].[ExamPeriods]
        ([ExamPeriodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Exam_ExamPeriod'
CREATE INDEX [IX_FK_Exam_ExamPeriod]
ON [dbo].[Exams]
    ([ExamPeriodId]);
GO

-- Creating foreign key on [ExamId] in table 'RegisteredExams'
ALTER TABLE [dbo].[RegisteredExams]
ADD CONSTRAINT [FK_RegisteredExams_Exam]
    FOREIGN KEY ([ExamId])
    REFERENCES [dbo].[Exams]
        ([ExamId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RegisteredExams_Exam'
CREATE INDEX [IX_FK_RegisteredExams_Exam]
ON [dbo].[RegisteredExams]
    ([ExamId]);
GO

-- Creating foreign key on [Examid] in table 'StudentsExamResults'
ALTER TABLE [dbo].[StudentsExamResults]
ADD CONSTRAINT [FK_StudentsExamResults_Exam]
    FOREIGN KEY ([Examid])
    REFERENCES [dbo].[Exams]
        ([ExamId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentsExamResults_Exam'
CREATE INDEX [IX_FK_StudentsExamResults_Exam]
ON [dbo].[StudentsExamResults]
    ([Examid]);
GO

-- Creating foreign key on [ExamTypeId] in table 'RegisteredExams'
ALTER TABLE [dbo].[RegisteredExams]
ADD CONSTRAINT [FK_RegisteredExams_ExamTypes]
    FOREIGN KEY ([ExamTypeId])
    REFERENCES [dbo].[ExamTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RegisteredExams_ExamTypes'
CREATE INDEX [IX_FK_RegisteredExams_ExamTypes]
ON [dbo].[RegisteredExams]
    ([ExamTypeId]);
GO

-- Creating foreign key on [FeeStructureId] in table 'FeeStructureAcademics'
ALTER TABLE [dbo].[FeeStructureAcademics]
ADD CONSTRAINT [FK_FeeStructureAcademic_FeesStructure]
    FOREIGN KEY ([FeeStructureId])
    REFERENCES [dbo].[FeesStructures]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FeeStructureAcademic_FeesStructure'
CREATE INDEX [IX_FK_FeeStructureAcademic_FeesStructure]
ON [dbo].[FeeStructureAcademics]
    ([FeeStructureId]);
GO

-- Creating foreign key on [FeeStructureId] in table 'FeeStructureOthers'
ALTER TABLE [dbo].[FeeStructureOthers]
ADD CONSTRAINT [FK_FeeStructureOthers_FeesStructure]
    FOREIGN KEY ([FeeStructureId])
    REFERENCES [dbo].[FeesStructures]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FeeStructureOthers_FeesStructure'
CREATE INDEX [IX_FK_FeeStructureOthers_FeesStructure]
ON [dbo].[FeeStructureOthers]
    ([FeeStructureId]);
GO

-- Creating foreign key on [GradingSystemId] in table 'GradingSystemDets'
ALTER TABLE [dbo].[GradingSystemDets]
ADD CONSTRAINT [FK_GradingSystemDet_GradingSystems]
    FOREIGN KEY ([GradingSystemId])
    REFERENCES [dbo].[GradingSystems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GradingSystemDet_GradingSystems'
CREATE INDEX [IX_FK_GradingSystemDet_GradingSystems]
ON [dbo].[GradingSystemDets]
    ([GradingSystemId]);
GO

-- Creating foreign key on [LocationId] in table 'LocationProperties'
ALTER TABLE [dbo].[LocationProperties]
ADD CONSTRAINT [FK_LocationProperties_Locations]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationProperties_Locations'
CREATE INDEX [IX_FK_LocationProperties_Locations]
ON [dbo].[LocationProperties]
    ([LocationId]);
GO

-- Creating foreign key on [ProgrammeId] in table 'ProgrammeYearCourses'
ALTER TABLE [dbo].[ProgrammeYearCourses]
ADD CONSTRAINT [FK_ProgrammeCourses_Programmes]
    FOREIGN KEY ([ProgrammeId])
    REFERENCES [dbo].[Programmes]
        ([ProgrammeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgrammeCourses_Programmes'
CREATE INDEX [IX_FK_ProgrammeCourses_Programmes]
ON [dbo].[ProgrammeYearCourses]
    ([ProgrammeId]);
GO

-- Creating foreign key on [ProgrammeId] in table 'ProgrammeYears'
ALTER TABLE [dbo].[ProgrammeYears]
ADD CONSTRAINT [FK_ProgrammeYears_Programmes]
    FOREIGN KEY ([ProgrammeId])
    REFERENCES [dbo].[Programmes]
        ([ProgrammeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgrammeYears_Programmes'
CREATE INDEX [IX_FK_ProgrammeYears_Programmes]
ON [dbo].[ProgrammeYears]
    ([ProgrammeId]);
GO

-- Creating foreign key on [ProgrammeYearId] in table 'SchoolClasses'
ALTER TABLE [dbo].[SchoolClasses]
ADD CONSTRAINT [FK_SchoolClasses_ProgrammeYears]
    FOREIGN KEY ([ProgrammeYearId])
    REFERENCES [dbo].[ProgrammeYears]
        ([ProgrammeYearId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolClasses_ProgrammeYears'
CREATE INDEX [IX_FK_SchoolClasses_ProgrammeYears]
ON [dbo].[SchoolClasses]
    ([ProgrammeYearId]);
GO

-- Creating foreign key on [RegdExamId] in table 'StudentExams'
ALTER TABLE [dbo].[StudentExams]
ADD CONSTRAINT [FK_StudentExams_RegisteredExams1]
    FOREIGN KEY ([RegdExamId])
    REFERENCES [dbo].[RegisteredExams]
        ([RegdExamId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentExams_RegisteredExams1'
CREATE INDEX [IX_FK_StudentExams_RegisteredExams1]
ON [dbo].[StudentExams]
    ([RegdExamId]);
GO

-- Creating foreign key on [ReportGroup] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [FK_Reports_FK00]
    FOREIGN KEY ([ReportGroup])
    REFERENCES [dbo].[ReportGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Reports_FK00'
CREATE INDEX [IX_FK_Reports_FK00]
ON [dbo].[Reports]
    ([ReportGroup]);
GO

-- Creating foreign key on [HallId] in table 'ResidenceHallRooms'
ALTER TABLE [dbo].[ResidenceHallRooms]
ADD CONSTRAINT [FK_ResidenceHallRooms_ResidenceHalls]
    FOREIGN KEY ([HallId])
    REFERENCES [dbo].[ResidenceHalls]
        ([HallId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ResidenceHallRooms_ResidenceHalls'
CREATE INDEX [IX_FK_ResidenceHallRooms_ResidenceHalls]
ON [dbo].[ResidenceHallRooms]
    ([HallId]);
GO

-- Creating foreign key on [ClassTeacher] in table 'SchoolClasses'
ALTER TABLE [dbo].[SchoolClasses]
ADD CONSTRAINT [FK_Class_FK00]
    FOREIGN KEY ([ClassTeacher])
    REFERENCES [dbo].[Teachers]
        ([TeacherId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Class_FK00'
CREATE INDEX [IX_FK_Class_FK00]
ON [dbo].[SchoolClasses]
    ([ClassTeacher]);
GO

-- Creating foreign key on [PasswordQuestion] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_PasswordQuestion]
    FOREIGN KEY ([PasswordQuestion])
    REFERENCES [dbo].[SecurityQuestions]
        ([PasswordQuestion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_PasswordQuestion'
CREATE INDEX [IX_FK_Users_PasswordQuestion]
ON [dbo].[Users]
    ([PasswordQuestion]);
GO

-- Creating foreign key on [SGroup] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [FK_Settings_SettingsGroups]
    FOREIGN KEY ([SGroup])
    REFERENCES [dbo].[SettingsGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Settings_SettingsGroups'
CREATE INDEX [IX_FK_Settings_SettingsGroups]
ON [dbo].[Settings]
    ([SGroup]);
GO

-- Creating foreign key on [StudentId] in table 'StudentExams'
ALTER TABLE [dbo].[StudentExams]
ADD CONSTRAINT [FK_StudentExams_Students]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentExams_Students'
CREATE INDEX [IX_FK_StudentExams_Students]
ON [dbo].[StudentExams]
    ([StudentId]);
GO

-- Creating foreign key on [StudentId] in table 'StudentProgresses'
ALTER TABLE [dbo].[StudentProgresses]
ADD CONSTRAINT [FK_StudentProgresses_Students]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentProgresses_Students'
CREATE INDEX [IX_FK_StudentProgresses_Students]
ON [dbo].[StudentProgresses]
    ([StudentId]);
GO

-- Creating foreign key on [StudentExamResultId] in table 'StudentsExamResultsDetails'
ALTER TABLE [dbo].[StudentsExamResultsDetails]
ADD CONSTRAINT [FK_StudentsExamResultsDetail_StudentsExamResults]
    FOREIGN KEY ([StudentExamResultId])
    REFERENCES [dbo].[StudentsExamResults]
        ([StudentExamResultId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentsExamResultsDetail_StudentsExamResults'
CREATE INDEX [IX_FK_StudentsExamResultsDetail_StudentsExamResults]
ON [dbo].[StudentsExamResultsDetails]
    ([StudentExamResultId]);
GO

-- Creating foreign key on [Subject] in table 'SubSubjects'
ALTER TABLE [dbo].[SubSubjects]
ADD CONSTRAINT [FK_SubSubjects_Subjects]
    FOREIGN KEY ([Subject])
    REFERENCES [dbo].[Subjects]
        ([ShortCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubSubjects_Subjects'
CREATE INDEX [IX_FK_SubSubjects_Subjects]
ON [dbo].[SubSubjects]
    ([Subject]);
GO

-- Creating foreign key on [TransactionTypeId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_FK01]
    FOREIGN KEY ([TransactionTypeId])
    REFERENCES [dbo].[TransactionTypes]
        ([TransactionTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_FK01'
CREATE INDEX [IX_FK_Transactions_FK01]
ON [dbo].[Transactions]
    ([TransactionTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------