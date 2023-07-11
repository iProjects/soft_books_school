
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/14/2022 20:21:39
-- Generated from EDMX file: D:\wakxpx\csharp\visualstudio\2010\SBSchool\DAL\SBSchoolDBEntities.edmx
-- --------------------------------------------------
 

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BankBranches_Banks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankBranches] DROP CONSTRAINT [FK_BankBranches_Banks];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassStreams_SchoolClasses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassStreams] DROP CONSTRAINT [FK_ClassStreams_SchoolClasses];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassSubjects_SchoolClasses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_SchoolClasses];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Subjects];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassSubjects_Teachers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Teachers];
GO
IF OBJECT_ID(N'[dbo].[FK_Exam_ExamPeriod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exam] DROP CONSTRAINT [FK_Exam_ExamPeriod];
GO
IF OBJECT_ID(N'[dbo].[FK_Exam_SchoolClasses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exam] DROP CONSTRAINT [FK_Exam_SchoolClasses];
GO
IF OBJECT_ID(N'[dbo].[FK_Exam_Subjects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exam] DROP CONSTRAINT [FK_Exam_Subjects];
GO
IF OBJECT_ID(N'[dbo].[FK_GradingSystemDets_GradingSystems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GradingSystemDets] DROP CONSTRAINT [FK_GradingSystemDets_GradingSystems];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationProperties_Locations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationProperties] DROP CONSTRAINT [FK_LocationProperties_Locations];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgrammeYearCourses_Programmes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgrammeYearCourses] DROP CONSTRAINT [FK_ProgrammeYearCourses_Programmes];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgrammeYearCourses_ProgrammeYears]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgrammeYearCourses] DROP CONSTRAINT [FK_ProgrammeYearCourses_ProgrammeYears];
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
IF OBJECT_ID(N'[dbo].[FK_RegisteredExams_Rooms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_Rooms];
GO
IF OBJECT_ID(N'[dbo].[FK_SchoolClasses_ProgrammeYears]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SchoolClasses] DROP CONSTRAINT [FK_SchoolClasses_ProgrammeYears];
GO
IF OBJECT_ID(N'[dbo].[FK_SchoolClasses_Teachers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SchoolClasses] DROP CONSTRAINT [FK_SchoolClasses_Teachers];
GO
IF OBJECT_ID(N'[dbo].[FK_Schools_GradingSystems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Schools] DROP CONSTRAINT [FK_Schools_GradingSystems];
GO
IF OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Settings] DROP CONSTRAINT [FK_Settings_SettingsGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_spAllowedReportsRolesMenus_spReportsMenuItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[spAllowedReportsRolesMenus] DROP CONSTRAINT [FK_spAllowedReportsRolesMenus_spReportsMenuItems];
GO
IF OBJECT_ID(N'[dbo].[FK_spAllowedRoleMenus_spMenuItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[spAllowedRoleMenus] DROP CONSTRAINT [FK_spAllowedRoleMenus_spMenuItems];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentProgresses] DROP CONSTRAINT [FK_StudentProgresses_Students];
GO
IF OBJECT_ID(N'[dbo].[FK_Students_ClassStreams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_Students_ClassStreams];
GO
IF OBJECT_ID(N'[dbo].[FK_Students_Schools]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_Students_Schools];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_Accounts];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_TransactionTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_TransactionTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionsAuthorizations_TransactionTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionsAuthorizations] DROP CONSTRAINT [FK_TransactionsAuthorizations_TransactionTypes];
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
IF OBJECT_ID(N'[dbo].[BS_Level1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BS_Level1];
GO
IF OBJECT_ID(N'[dbo].[BS_Level2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BS_Level2];
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
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[DisciplinaryCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DisciplinaryCategories];
GO
IF OBJECT_ID(N'[dbo].[Discipline]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Discipline];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Employers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employers];
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
IF OBJECT_ID(N'[dbo].[InformDb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InformDb];
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
IF OBJECT_ID(N'[dbo].[PL_Level1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PL_Level1];
GO
IF OBJECT_ID(N'[dbo].[PL_Level2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PL_Level2];
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
IF OBJECT_ID(N'[dbo].[SBSchoolMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SBSchoolMessages];
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
IF OBJECT_ID(N'[dbo].[SmsMessageStore]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SmsMessageStore];
GO
IF OBJECT_ID(N'[dbo].[spAllowedReportsRolesMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spAllowedReportsRolesMenus];
GO
IF OBJECT_ID(N'[dbo].[spAllowedRoleMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spAllowedRoleMenus];
GO
IF OBJECT_ID(N'[dbo].[spAllowedRoleMenusweb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spAllowedRoleMenusweb];
GO
IF OBJECT_ID(N'[dbo].[spMenuItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spMenuItems];
GO
IF OBJECT_ID(N'[dbo].[spMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spMenus];
GO
IF OBJECT_ID(N'[dbo].[spReportsMenuItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spReportsMenuItems];
GO
IF OBJECT_ID(N'[dbo].[spRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spRoles];
GO
IF OBJECT_ID(N'[dbo].[spUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spUsers];
GO
IF OBJECT_ID(N'[dbo].[spUsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spUsersInRoles];
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
IF OBJECT_ID(N'[dbo].[StudentsExamResults_Temp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsExamResults_Temp];
GO
IF OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsExamResultsDetail];
GO
IF OBJECT_ID(N'[dbo].[StudentsExamResultsDetail_Temp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsExamResultsDetail_Temp];
GO
IF OBJECT_ID(N'[dbo].[StudentSubjectTargets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSubjectTargets];
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
IF OBJECT_ID(N'[dbo].[TechParams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TechParams];
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
IF OBJECT_ID(N'[dbo].[TransactionsAuthorizations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionsAuthorizations];
GO
IF OBJECT_ID(N'[dbo].[TransactionTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionTypes];
GO
IF OBJECT_ID(N'[dbo].[Transport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transport];
GO
IF OBJECT_ID(N'[dbo].[UserProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfile];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[webpages_Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Membership];
GO
IF OBJECT_ID(N'[dbo].[webpages_OAuthMembership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_OAuthMembership];
GO
IF OBJECT_ID(N'[dbo].[webpages_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Roles];
GO
IF OBJECT_ID(N'[dbo].[webpages_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_UsersInRoles];
GO
IF OBJECT_ID(N'[SBSchoolDBModelStoreContainer].[vwBankBranches]', 'U') IS NOT NULL
    DROP TABLE [SBSchoolDBModelStoreContainer].[vwBankBranches];
GO
IF OBJECT_ID(N'[SBSchoolDBModelStoreContainer].[vwExamResults]', 'U') IS NOT NULL
    DROP TABLE [SBSchoolDBModelStoreContainer].[vwExamResults];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [AccountName] nvarchar(200)  NOT NULL,
    [AccountNo] nvarchar(50)  NOT NULL,
    [AccountTypeId] int  NULL,
    [COAId] int  NOT NULL,
    [BankBranch] int  NULL,
    [SchoolBranch] int  NULL,
    [BookBalance] decimal(19,4)  NOT NULL,
    [ClearedBalance] decimal(19,4)  NOT NULL,
    [InterestRate] float  NOT NULL,
    [AccruedInt] decimal(19,4)  NOT NULL,
    [Limit] decimal(19,4)  NOT NULL,
    [PassFlag] nvarchar(50)  NULL,
    [Bal30] decimal(19,4)  NULL,
    [Bal60] decimal(19,4)  NULL,
    [Bal90] decimal(19,4)  NULL,
    [BalOver90] decimal(19,4)  NULL,
    [IntRate30] float  NULL,
    [IntRate60] float  NULL,
    [IntRate90] float  NULL,
    [IntRateOver90] float  NULL,
    [Closed] bit  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'AccountTypes'
CREATE TABLE [dbo].[AccountTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nchar(10)  NULL,
    [Description] nvarchar(50)  NULL,
    [Status] nchar(1)  NULL,
    [IsDeleted] bit  NULL
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
    [ReasonForNotAttending] nvarchar(150)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'BankBranches'
CREATE TABLE [dbo].[BankBranches] (
    [BankSortCode] nvarchar(50)  NOT NULL,
    [BranchCode] nvarchar(50)  NOT NULL,
    [BankCode] nvarchar(50)  NOT NULL,
    [BranchName] nvarchar(50)  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Banks'
CREATE TABLE [dbo].[Banks] (
    [BankCode] nvarchar(50)  NOT NULL,
    [BankName] nvarchar(50)  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'BS_Level1'
CREATE TABLE [dbo].[BS_Level1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [BSGroup] nchar(10)  NULL,
    [ROrder] int  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'BS_Level2'
CREATE TABLE [dbo].[BS_Level2] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [AccField] nvarchar(50)  NOT NULL,
    [BSCriteria] nvarchar(50)  NOT NULL,
    [Yr1Amount] decimal(19,4)  NOT NULL,
    [Yr2Amount] decimal(19,4)  NOT NULL,
    [ROrder] int  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ClassStreams'
CREATE TABLE [dbo].[ClassStreams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassId] int  NOT NULL,
    [Description] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ClassSubjects'
CREATE TABLE [dbo].[ClassSubjects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassId] int  NOT NULL,
    [SubjectCode] nvarchar(10)  NOT NULL,
    [SubjectTeacherId] int  NULL,
    [Room] nvarchar(50)  NULL,
    [Status] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'COAs'
CREATE TABLE [dbo].[COAs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nchar(10)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [COALevel] int  NOT NULL,
    [Parent] int  NOT NULL,
    [Rorder] int  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerName] nvarchar(100)  NOT NULL,
    [CustomerNo] nvarchar(100)  NULL,
    [Address] nvarchar(100)  NULL,
    [Telephone] nvarchar(100)  NULL,
    [Email] nvarchar(100)  NULL,
    [Branch] int  NULL,
    [BillToName] nvarchar(100)  NULL,
    [BillToAddress] nvarchar(100)  NULL,
    [BillToTelephone] nvarchar(100)  NULL,
    [BillToEmail] nvarchar(100)  NULL,
    [StudentId] int  NULL,
    [DateofCreation] datetime  NULL,
    [Status] nchar(1)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(2)  NULL,
    [Description] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'DisciplinaryCategories'
CREATE TABLE [dbo].[DisciplinaryCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nvarchar(50)  NOT NULL,
    [Description] varchar(250)  NOT NULL,
    [Status] nchar(1)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Disciplines'
CREATE TABLE [dbo].[Disciplines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [DisciplineCategoryId] int  NOT NULL,
    [DisciplinaryDate] datetime  NOT NULL,
    [Incident] nvarchar(300)  NOT NULL,
    [DisciplineRating] nvarchar(1)  NULL,
    [Severity] nvarchar(1)  NULL,
    [ActionRecommended] nvarchar(100)  NULL,
    [ActionTaken] nvarchar(100)  NULL,
    [Review] nvarchar(100)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpNo] nvarchar(250)  NULL,
    [Surname] nvarchar(250)  NULL,
    [OtherNames] nvarchar(250)  NULL,
    [Email] nvarchar(250)  NULL,
    [DoB] datetime  NULL,
    [MaritalStatus] nvarchar(1)  NULL,
    [Gender] nvarchar(1)  NULL,
    [Photo] nvarchar(max)  NULL,
    [DoE] datetime  NULL,
    [BasicComputation] nvarchar(1)  NULL,
    [BasicPay] decimal(19,4)  NULL,
    [PersonalRelief] decimal(19,4)  NULL,
    [MortgageRelief] decimal(19,4)  NULL,
    [InsuranceRelief] decimal(19,4)  NULL,
    [NSSFNo] nvarchar(250)  NULL,
    [NHIFNo] nvarchar(250)  NULL,
    [IDNo] nvarchar(250)  NULL,
    [PINNo] nvarchar(250)  NULL,
    [DepartmentId] int  NULL,
    [EmployerId] int  NOT NULL,
    [PayPoint] nvarchar(250)  NULL,
    [EmpGroup] nvarchar(250)  NULL,
    [EmpSchool] nvarchar(250)  NULL,
    [PrevEmployer] nvarchar(250)  NULL,
    [DateLeft] datetime  NULL,
    [PaymentMode] nvarchar(250)  NULL,
    [TelephoneNo] nvarchar(250)  NULL,
    [ChequeNo] nvarchar(250)  NULL,
    [BankCode] nvarchar(250)  NULL,
    [BankAccount] nvarchar(250)  NULL,
    [LeaveBalance] nvarchar(250)  NULL,
    [IsActive] bit  NULL,
    [CreatedBy] nvarchar(250)  NULL,
    [CreatedOn] datetime  NULL,
    [IsDeleted] bit  NULL,
    [SystemId] nvarchar(250)  NULL
);
GO

-- Creating table 'Employers'
CREATE TABLE [dbo].[Employers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Email] nvarchar(250)  NULL,
    [Telephone] nvarchar(250)  NULL,
    [Address1] nvarchar(250)  NULL,
    [Address2] nvarchar(250)  NULL,
    [Slogan] nvarchar(250)  NULL,
    [AuthorizedSignatory] nvarchar(250)  NULL,
    [PIN] nvarchar(250)  NULL,
    [NHIF] nvarchar(250)  NULL,
    [NSSF] nvarchar(250)  NULL,
    [BankBranchSortCode] nvarchar(250)  NULL,
    [AccountName] nvarchar(250)  NULL,
    [AccountNo] nvarchar(250)  NULL,
    [Logo] nvarchar(250)  NULL,
    [IsDefault] bit  NULL,
    [IsActive] bit  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Exams'
CREATE TABLE [dbo].[Exams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExamPeriodId] int  NOT NULL,
    [ClassId] int  NOT NULL,
    [SubjectShortCode] nvarchar(10)  NOT NULL,
    [LastModified] datetime  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [Enabled] bit  NOT NULL,
    [Closed] bit  NOT NULL,
    [Processed] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'ExamPeriods'
CREATE TABLE [dbo].[ExamPeriods] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [Term] int  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [Status] nchar(1)  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ExamTypes'
CREATE TABLE [dbo].[ExamTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nvarchar(50)  NULL,
    [Description] nvarchar(250)  NULL,
    [ROrder] int  NULL,
    [PercentageContribution] int  NULL,
    [Status] nchar(1)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'FeesStructures'
CREATE TABLE [dbo].[FeesStructures] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [Year] int  NOT NULL,
    [IsDefault] bit  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'FeeStructureAcademics'
CREATE TABLE [dbo].[FeeStructureAcademics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FeeStructureId] int  NOT NULL,
    [SchoolClassId] int  NOT NULL,
    [Term] int  NOT NULL,
    [AccountId] int  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [AmountPeriod] nchar(1)  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'FeeStructureOthers'
CREATE TABLE [dbo].[FeeStructureOthers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FeeStructureId] int  NOT NULL,
    [AccountId] int  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [AmountPeriod] nchar(1)  NOT NULL,
    [ApplicableTo] nchar(1)  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'GradingSystemDets'
CREATE TABLE [dbo].[GradingSystemDets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GradingSystemId] int  NOT NULL,
    [LMark] float  NOT NULL,
    [UMark] float  NOT NULL,
    [Grade] nchar(10)  NOT NULL,
    [Point] float  NULL,
    [Remarks] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'GradingSystems'
CREATE TABLE [dbo].[GradingSystems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'InformDbs'
CREATE TABLE [dbo].[InformDbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AddressTo] nvarchar(250)  NULL,
    [Status] nvarchar(250)  NULL,
    [Body] nvarchar(max)  NULL,
    [MessageType] nvarchar(1)  NULL,
    [AddressFrom] nvarchar(250)  NULL,
    [MessageDate] datetime  NULL,
    [Subject] nvarchar(250)  NULL
);
GO

-- Creating table 'LocationProperties'
CREATE TABLE [dbo].[LocationProperties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LocKey] nvarchar(50)  NOT NULL,
    [LocValue] nvarchar(max)  NULL,
    [LocValueType] nvarchar(50)  NULL,
    [Description] nvarchar(250)  NULL,
    [LocationId] int  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Parent] int  NOT NULL,
    [Description] nvarchar(250)  NOT NULL,
    [TransportCost] decimal(19,4)  NULL,
    [BoardingCost] decimal(19,4)  NULL,
    [IsDeleted] bit  NULL
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
    [Grade] nvarchar(1)  NULL,
    [IsDeleted] bit  NULL
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
    [Closed] bit  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'MarkSheetStudents'
CREATE TABLE [dbo].[MarkSheetStudents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExamId] int  NULL,
    [StudentId] int  NULL,
    [Mark] int  NULL,
    [LastModified] datetime  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
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
    [Relationship] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'PL_Level1'
CREATE TABLE [dbo].[PL_Level1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [ROrder] int  NOT NULL,
    [PLGroup] nchar(10)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'PL_Level2'
CREATE TABLE [dbo].[PL_Level2] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [AccField] nvarchar(50)  NOT NULL,
    [PLCriteria] nvarchar(50)  NOT NULL,
    [Yr1Amount] decimal(19,4)  NOT NULL,
    [Yr2Amount] decimal(19,4)  NOT NULL,
    [ROrder] int  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Programmes'
CREATE TABLE [dbo].[Programmes] (
    [Id] nvarchar(10)  NOT NULL,
    [Description] nvarchar(200)  NOT NULL,
    [Hours] int  NULL,
    [Fees] decimal(19,4)  NULL,
    [Status] nvarchar(1)  NULL,
    [IsDefault] bit  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ProgrammeYearCourses'
CREATE TABLE [dbo].[ProgrammeYearCourses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProgrammeId] nvarchar(10)  NOT NULL,
    [ProgrammeYearId] int  NOT NULL,
    [CourseId] nvarchar(10)  NOT NULL,
    [Semester] int  NOT NULL,
    [NoOfHrs] int  NULL,
    [TuitionFees] decimal(19,4)  NULL,
    [ExamFees] decimal(19,4)  NULL,
    [ResitFees] decimal(19,4)  NULL,
    [Status] nvarchar(1)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ProgrammeYears'
CREATE TABLE [dbo].[ProgrammeYears] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProgrammeId] nvarchar(10)  NOT NULL,
    [Year] int  NOT NULL,
    [Description] nvarchar(250)  NULL,
    [NextYr] int  NULL,
    [Fees] decimal(19,4)  NULL,
    [Status] nvarchar(1)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'RegisteredExams'
CREATE TABLE [dbo].[RegisteredExams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExamId] int  NOT NULL,
    [ExamTypeId] int  NOT NULL,
    [RoomId] int  NULL,
    [ExamDate] datetime  NULL,
    [Invilgilator] nvarchar(50)  NULL,
    [Status] nchar(1)  NULL,
    [ContributionFlag] bit  NOT NULL,
    [Contribution] float  NULL,
    [OutOf] int  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [LastModified] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ReportGroups'
CREATE TABLE [dbo].[ReportGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReportGroup1] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Reports'
CREATE TABLE [dbo].[Reports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReportName] nvarchar(50)  NULL,
    [ReportGroup] int  NULL,
    [ResouceFile] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ResidenceHallRooms'
CREATE TABLE [dbo].[ResidenceHallRooms] (
    [RoomId] int IDENTITY(1,1) NOT NULL,
    [HallId] int  NOT NULL,
    [Room] nvarchar(150)  NULL,
    [Cost] decimal(19,4)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ResidenceHalls'
CREATE TABLE [dbo].[ResidenceHalls] (
    [HallId] int IDENTITY(1,1) NOT NULL,
    [HallName] nvarchar(150)  NULL,
    [Location] nvarchar(150)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Residences'
CREATE TABLE [dbo].[Residences] (
    [ResidenceId] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Cost] decimal(19,4)  NULL,
    [GPSCordinates] varchar(50)  NULL,
    [Title] varchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'RoleRights'
CREATE TABLE [dbo].[RoleRights] (
    [RoleRightId] int IDENTITY(1,1) NOT NULL,
    [RoleId] char(2)  NOT NULL,
    [Object] varchar(250)  NULL,
    [ObjectType] varchar(50)  NULL,
    [ObjectRight] char(3)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nvarchar(50)  NULL,
    [Description] nvarchar(250)  NULL,
    [Capacity] int  NULL,
    [Status] nchar(1)  NULL,
    [IsDeleted] bit  NULL
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
    [ModifiedDate] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'SBSchoolMessages'
CREATE TABLE [dbo].[SBSchoolMessages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MemberId] int  NULL,
    [SenderTelno] nvarchar(250)  NULL,
    [CustomerTelno] nvarchar(250)  NULL,
    [Command] nvarchar(50)  NULL,
    [MessageType] int  NULL,
    [Status] nvarchar(250)  NULL,
    [Body] nvarchar(max)  NULL,
    [MessageDate] datetime  NULL,
    [AccountId] int  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [Amount] decimal(19,4)  NULL,
    [HM_Param] nvarchar(250)  NULL,
    [BE_AccLabel] nvarchar(250)  NULL,
    [ST_StartDate] datetime  NULL,
    [ST_EndDate] datetime  NULL,
    [OfferId] int  NULL,
    [Email] nvarchar(250)  NULL,
    [Pwd] nvarchar(250)  NULL,
    [NotificationMethod] nvarchar(250)  NULL,
    [MO_Term] int  NULL,
    [MO_Interest] float  NULL,
    [CP_NewPassword] nvarchar(250)  NULL,
    [CP_ConfirmPassword] nvarchar(250)  NULL,
    [NationalID] nvarchar(50)  NULL,
    [MpesaRef] nvarchar(50)  NULL,
    [MpesaSentDate] datetime  NULL,
    [MpesaBal] decimal(19,4)  NULL,
    [Exception] nvarchar(max)  NULL
);
GO

-- Creating table 'SchoolClasses'
CREATE TABLE [dbo].[SchoolClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nvarchar(20)  NOT NULL,
    [ClassName] nvarchar(100)  NOT NULL,
    [ProgrammeYearId] int  NOT NULL,
    [NoOfSubjects] int  NOT NULL,
    [TeacherId] int  NULL,
    [CurrentYrLevel] int  NULL,
    [NextYrLevel] int  NULL,
    [Remarks] nvarchar(250)  NULL,
    [Status] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Schools'
CREATE TABLE [dbo].[Schools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SchoolIndex] nvarchar(250)  NOT NULL,
    [SchoolName] nvarchar(250)  NOT NULL,
    [SchoolType] nvarchar(1)  NOT NULL,
    [GradingSystem] int  NOT NULL,
    [DefaultSchool] bit  NOT NULL,
    [GLCustomerId] int  NOT NULL,
    [Cellphone] nvarchar(250)  NULL,
    [Telephone] nvarchar(250)  NULL,
    [Email] nvarchar(250)  NULL,
    [Address1] nvarchar(250)  NULL,
    [Address2] nvarchar(250)  NULL,
    [SMTPServer] nvarchar(250)  NULL,
    [SMSGateway] nvarchar(250)  NULL,
    [Status] nvarchar(1)  NULL,
    [Logo] nvarchar(max)  NULL,
    [Slogan] nvarchar(max)  NULL,
    [IsDeleted] bit  NULL
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
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupName] varchar(50)  NOT NULL,
    [Parent] int  NOT NULL
);
GO

-- Creating table 'SmsMessageStores'
CREATE TABLE [dbo].[SmsMessageStores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserDataText] nvarchar(max)  NULL,
    [OriginatingAddress] nvarchar(max)  NULL,
    [SCTimestamp] nvarchar(max)  NULL,
    [MessageStatus] nvarchar(max)  NULL,
    [Storage] nvarchar(max)  NULL,
    [SmscAddressType] nvarchar(max)  NULL,
    [SmscAddress] nvarchar(max)  NULL,
    [OriginatingAddressType] nvarchar(max)  NULL,
    [MessageType] nvarchar(max)  NULL,
    [MessageIndex] nvarchar(max)  NULL,
    [MessageBody] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NULL,
    [Processed] bit  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'spAllowedReportsRolesMenus'
CREATE TABLE [dbo].[spAllowedReportsRolesMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [MenuItemId] int  NOT NULL,
    [Allowed] bit  NOT NULL
);
GO

-- Creating table 'spAllowedRoleMenus'
CREATE TABLE [dbo].[spAllowedRoleMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [MenuItemId] int  NOT NULL,
    [Allowed] bit  NOT NULL
);
GO

-- Creating table 'spAllowedRoleMenuswebs'
CREATE TABLE [dbo].[spAllowedRoleMenuswebs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NULL,
    [MenuItemId] int  NULL,
    [Allowed] bit  NULL
);
GO

-- Creating table 'spMenuItems'
CREATE TABLE [dbo].[spMenuItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [mnuName] nvarchar(100)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'spMenus'
CREATE TABLE [dbo].[spMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [mnuName] nvarchar(100)  NULL,
    [Description] nvarchar(100)  NULL
);
GO

-- Creating table 'spReportsMenuItems'
CREATE TABLE [dbo].[spReportsMenuItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [mnuName] nvarchar(100)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'spRoles'
CREATE TABLE [dbo].[spRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nvarchar(50)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'spUsers'
CREATE TABLE [dbo].[spUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [UserName] nvarchar(250)  NOT NULL,
    [Password] nvarchar(250)  NOT NULL,
    [Status] nvarchar(1)  NOT NULL,
    [Locked] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [SystemId] nvarchar(250)  NOT NULL,
    [Surname] nvarchar(200)  NULL,
    [OtherNames] nvarchar(200)  NULL,
    [NationalID] nvarchar(200)  NULL,
    [DateOfBirth] datetime  NULL,
    [Gender] nvarchar(50)  NULL,
    [Telephone] nvarchar(200)  NULL,
    [Email] nvarchar(200)  NULL,
    [DateJoined] datetime  NULL,
    [InformBy] nvarchar(200)  NULL,
    [Photo] nvarchar(max)  NULL
);
GO

-- Creating table 'spUsersInRoles'
CREATE TABLE [dbo].[spUsersInRoles] (
    [UserId] int  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- Creating table 'StudentExams'
CREATE TABLE [dbo].[StudentExams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [RegdExamId] int  NOT NULL,
    [Mark] float  NULL,
    [Status] nvarchar(1)  NULL,
    [ModifiedBy] nvarchar(50)  NULL,
    [LastModified] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'StudentProgresses'
CREATE TABLE [dbo].[StudentProgresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [ExamId] int  NOT NULL,
    [SchoolClassId] int  NOT NULL,
    [Year] int  NOT NULL,
    [Term] int  NOT NULL,
    [ClassShortCode] nvarchar(50)  NOT NULL,
    [SubjectShortCode] nchar(10)  NOT NULL,
    [TeacherId] int  NULL,
    [TotalMarks] float  NULL,
    [TotalPoints] float  NULL,
    [Position] int  NULL,
    [MeanMarks] float  NULL,
    [MeanGrade] nvarchar(5)  NULL,
    [ClassTeacherRemark] nvarchar(max)  NULL,
    [HeadTeacherRemark] nvarchar(max)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'StudentProgresses_Temp'
CREATE TABLE [dbo].[StudentProgresses_Temp] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [ExamId] int  NOT NULL,
    [SchoolClassId] int  NOT NULL,
    [Year] int  NOT NULL,
    [Term] int  NOT NULL,
    [ClassShortCode] nvarchar(50)  NOT NULL,
    [SubjectShortCode] nchar(10)  NOT NULL,
    [TeacherId] int  NULL,
    [TotalMarks] float  NULL,
    [TotalPoints] float  NULL,
    [Position] int  NULL,
    [MeanMarks] float  NULL,
    [MeanGrade] nvarchar(5)  NULL,
    [ClassTeacherRemark] nvarchar(max)  NULL,
    [HeadTeacherRemark] nvarchar(max)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SchoolId] int  NOT NULL,
    [ClassStreamId] int  NOT NULL,
    [AdminNo] nvarchar(50)  NOT NULL,
    [StudentSurName] nvarchar(50)  NOT NULL,
    [StudentOtherNames] nvarchar(50)  NOT NULL,
    [Gender] nvarchar(1)  NOT NULL,
    [DateOfBirth] datetime  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [Homepage] nvarchar(100)  NULL,
    [StudentAddress] nvarchar(max)  NULL,
    [AdmissionType] nvarchar(1)  NULL,
    [Status] nchar(1)  NULL,
    [KCPE] nvarchar(50)  NULL,
    [KCSE] nvarchar(50)  NULL,
    [AdmissionDate] datetime  NULL,
    [AdmittedBy] nvarchar(50)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [Photo] nvarchar(max)  NULL,
    [LastModifiedTime] datetime  NULL,
    [GLAccountId] int  NULL,
    [CustomerId] int  NULL,
    [FatherName] nvarchar(50)  NULL,
    [FatherCellPhone] nvarchar(50)  NULL,
    [FatherOfficePhone] nvarchar(50)  NULL,
    [FatherEmail] nvarchar(100)  NULL,
    [MotherName] nvarchar(50)  NULL,
    [MotherCellPhone] nvarchar(50)  NULL,
    [MotherOfficePhone] nvarchar(50)  NULL,
    [MotherEmail] nvarchar(100)  NULL,
    [GuardianName] nvarchar(50)  NULL,
    [GuardianCellPhone] nvarchar(50)  NULL,
    [GuardianOfficePhone] nvarchar(50)  NULL,
    [GuardianEmail] nvarchar(100)  NULL,
    [PrevSchoolId] nvarchar(50)  NULL,
    [PrevSchoolName] nvarchar(100)  NULL,
    [PrevSchoolPhone] nvarchar(50)  NULL,
    [PrevSchoolAddress] nvarchar(100)  NULL,
    [ReasonForLeaving] nvarchar(max)  NULL,
    [ExtraCurricular1] nvarchar(50)  NULL,
    [ExtraCurricular2] nvarchar(50)  NULL,
    [ExtraCurricular3] nvarchar(50)  NULL,
    [Term1MeanGrade] nvarchar(50)  NULL,
    [Term2MeanGrade] nvarchar(50)  NULL,
    [Term3MeanGrade] nvarchar(50)  NULL,
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
    [BedNo] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'StudentsExamResults'
CREATE TABLE [dbo].[StudentsExamResults] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [Examid] int  NOT NULL,
    [SchoolClassId] int  NOT NULL,
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
    [Status] nchar(10)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'StudentsExamResults_Temp'
CREATE TABLE [dbo].[StudentsExamResults_Temp] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [Examid] int  NOT NULL,
    [SchoolClassId] int  NOT NULL,
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
    [Status] nchar(10)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'StudentsExamResultsDetails'
CREATE TABLE [dbo].[StudentsExamResultsDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentsExamResultsId] int  NULL,
    [SubjectShortCode] nvarchar(10)  NULL,
    [Mark] float  NULL,
    [Grade] nchar(10)  NULL,
    [Mark_Target] float  NULL,
    [Grade_Target] nchar(10)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'StudentsExamResultsDetail_Temp'
CREATE TABLE [dbo].[StudentsExamResultsDetail_Temp] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentsExamResults_TempId] int  NULL,
    [SubjectShortCode] nvarchar(10)  NULL,
    [Mark] float  NULL,
    [Grade] nchar(10)  NULL,
    [Mark_Target] float  NULL,
    [Grade_Target] nchar(10)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'StudentSubjectTargets'
CREATE TABLE [dbo].[StudentSubjectTargets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NULL,
    [SubjectShortCode] nchar(10)  NULL,
    [Target] float  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Subjects'
CREATE TABLE [dbo].[Subjects] (
    [ShortCode] nvarchar(10)  NOT NULL,
    [Description] nvarchar(200)  NULL,
    [OutOf] int  NULL,
    [PassMark] int  NULL,
    [NoOfRequiredHours] int  NULL,
    [Fees] decimal(19,4)  NULL,
    [ROrder] int  NULL,
    [Status] nchar(1)  NULL,
    [Remarks] nvarchar(200)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'SubSubjects'
CREATE TABLE [dbo].[SubSubjects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubjectShortCode] nvarchar(10)  NOT NULL,
    [Description] nvarchar(50)  NULL,
    [OutOf] int  NULL,
    [PassMark] int  NULL,
    [GroupingFactor] int  NULL,
    [IsDeleted] bit  NULL
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
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [IDNo] nvarchar(50)  NOT NULL,
    [TSCNo] nvarchar(50)  NULL,
    [Position] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Status] nvarchar(1)  NULL,
    [DateJoined] datetime  NULL,
    [DateLeft] datetime  NULL,
    [IsLeft] bit  NULL,
    [HighestQualification] nvarchar(2)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'TechParams'
CREATE TABLE [dbo].[TechParams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [strtdt] datetime  NULL,
    [edc] int  NULL
);
GO

-- Creating table 'TimeTableDets'
CREATE TABLE [dbo].[TimeTableDets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimeTableId] int  NOT NULL,
    [SubjectShortCode] nvarchar(10)  NULL,
    [RoomId] int  NULL,
    [Recurrent] nchar(1)  NULL,
    [Activity] nvarchar(150)  NULL,
    [Venue] nvarchar(150)  NULL,
    [Text] nvarchar(150)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [A] int  NOT NULL,
    [R] int  NOT NULL,
    [G] int  NOT NULL,
    [B] int  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'TimeTables'
CREATE TABLE [dbo].[TimeTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassStreamId] int  NOT NULL,
    [ClassTimeTableXML] varchar(max)  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TransactionTypeId] int  NOT NULL,
    [AccountId] int  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [PostDate] datetime  NOT NULL,
    [RecordDate] datetime  NOT NULL,
    [ValueDate] datetime  NULL,
    [Narrative] nvarchar(max)  NULL,
    [StatementFlag] nvarchar(255)  NULL,
    [Authorizer] nvarchar(255)  NULL,
    [UserName] nvarchar(250)  NULL,
    [TransRef] nvarchar(255)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'TransactionsAuthorizations'
CREATE TABLE [dbo].[TransactionsAuthorizations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserRoleId] int  NOT NULL,
    [TransactionTypeId] int  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'TransactionTypes'
CREATE TABLE [dbo].[TransactionTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [DebitCredit] nchar(1)  NOT NULL,
    [TxnTypeView] nchar(1)  NULL,
    [CommissionType] nchar(1)  NULL,
    [FlatRate] decimal(19,4)  NULL,
    [PercentageRate] float  NULL,
    [DialogFlag] nchar(1)  NULL,
    [UseDefaultAmount] bit  NULL,
    [DefaultAmount] decimal(19,4)  NULL,
    [UseDefaultCreditAccount] bit  NULL,
    [DefaultCreditAccount] int  NULL,
    [UseDefaultDebitAccount] bit  NULL,
    [DefaultDebitAccount] int  NULL,
    [UseDefaultCreditNarrative] bit  NULL,
    [DefaultCreditNarrative] nvarchar(max)  NULL,
    [UseDefaultDebitNarrative] bit  NULL,
    [DefaultDebitNarrative] nvarchar(max)  NULL,
    [ScreenViewCreditAccountField] nchar(1)  NULL,
    [ScreenViewCreditNarrativeField] nchar(1)  NULL,
    [ScreenViewDebitAccountField] nchar(1)  NULL,
    [ScreenViewDebitNarrativeField] nchar(1)  NULL,
    [ScreenViewAmountField] nchar(1)  NULL,
    [ScreenViewModeofPaymentField] nchar(1)  NULL,
    [ScreenViewValueDateField] nchar(1)  NULL,
    [PrintReceipt] bit  NULL,
    [ReceiptLayout] nvarchar(max)  NULL,
    [PrintReceiptPrompt] bit  NULL,
    [ForcePost] nchar(1)  NULL,
    [NarrativeFlag] nchar(1)  NULL,
    [StatementFlag] nchar(1)  NULL,
    [ValueDays] int  NULL,
    [Status] nchar(1)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Transports'
CREATE TABLE [dbo].[Transports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResidenceId] int  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'UserProfiles'
CREATE TABLE [dbo].[UserProfiles] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NULL
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
    [ProfileReset] tinyint  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'webpages_Membership'
CREATE TABLE [dbo].[webpages_Membership] (
    [UserId] int  NOT NULL,
    [CreateDate] datetime  NULL,
    [ConfirmationToken] nvarchar(128)  NULL,
    [IsConfirmed] bit  NULL,
    [LastPasswordFailureDate] datetime  NULL,
    [PasswordFailuresSinceLastSuccess] int  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordChangedDate] datetime  NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [PasswordVerificationToken] nvarchar(128)  NULL,
    [PasswordVerificationTokenExpirationDate] datetime  NULL
);
GO

-- Creating table 'webpages_OAuthMembership'
CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [Provider] nvarchar(30)  NOT NULL,
    [ProviderUserId] nvarchar(100)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'webpages_Roles'
CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'webpages_UsersInRoles'
CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [UserId] int  NOT NULL,
    [RoleId] int  NOT NULL
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

-- Creating table 'vwExamResults'
CREATE TABLE [dbo].[vwExamResults] (
    [ExamPeriodId] int  NOT NULL,
    [ClassId] int  NOT NULL,
    [Id] int  NOT NULL,
    [StudentId] int  NOT NULL,
    [SubjectShortCode] nvarchar(10)  NOT NULL,
    [Description] nvarchar(200)  NULL,
    [ContributionFlag] bit  NOT NULL,
    [ExamMark] float  NULL,
    [CombinedOutOf] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id] in table 'BS_Level1'
ALTER TABLE [dbo].[BS_Level1]
ADD CONSTRAINT [PK_BS_Level1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BS_Level2'
ALTER TABLE [dbo].[BS_Level2]
ADD CONSTRAINT [PK_BS_Level2]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassStreams'
ALTER TABLE [dbo].[ClassStreams]
ADD CONSTRAINT [PK_ClassStreams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassSubjects'
ALTER TABLE [dbo].[ClassSubjects]
ADD CONSTRAINT [PK_ClassSubjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'COAs'
ALTER TABLE [dbo].[COAs]
ADD CONSTRAINT [PK_COAs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employers'
ALTER TABLE [dbo].[Employers]
ADD CONSTRAINT [PK_Employers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Exams'
ALTER TABLE [dbo].[Exams]
ADD CONSTRAINT [PK_Exams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExamPeriods'
ALTER TABLE [dbo].[ExamPeriods]
ADD CONSTRAINT [PK_ExamPeriods]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id] in table 'GradingSystemDets'
ALTER TABLE [dbo].[GradingSystemDets]
ADD CONSTRAINT [PK_GradingSystemDets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GradingSystems'
ALTER TABLE [dbo].[GradingSystems]
ADD CONSTRAINT [PK_GradingSystems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InformDbs'
ALTER TABLE [dbo].[InformDbs]
ADD CONSTRAINT [PK_InformDbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationProperties'
ALTER TABLE [dbo].[LocationProperties]
ADD CONSTRAINT [PK_LocationProperties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id] in table 'PL_Level1'
ALTER TABLE [dbo].[PL_Level1]
ADD CONSTRAINT [PK_PL_Level1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PL_Level2'
ALTER TABLE [dbo].[PL_Level2]
ADD CONSTRAINT [PK_PL_Level2]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Programmes'
ALTER TABLE [dbo].[Programmes]
ADD CONSTRAINT [PK_Programmes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgrammeYearCourses'
ALTER TABLE [dbo].[ProgrammeYearCourses]
ADD CONSTRAINT [PK_ProgrammeYearCourses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgrammeYears'
ALTER TABLE [dbo].[ProgrammeYears]
ADD CONSTRAINT [PK_ProgrammeYears]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegisteredExams'
ALTER TABLE [dbo].[RegisteredExams]
ADD CONSTRAINT [PK_RegisteredExams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Name], [MajorVersion], [MinorVersion] in table 'RuleSets'
ALTER TABLE [dbo].[RuleSets]
ADD CONSTRAINT [PK_RuleSets]
    PRIMARY KEY CLUSTERED ([Name], [MajorVersion], [MinorVersion] ASC);
GO

-- Creating primary key on [Id] in table 'SBSchoolMessages'
ALTER TABLE [dbo].[SBSchoolMessages]
ADD CONSTRAINT [PK_SBSchoolMessages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SchoolClasses'
ALTER TABLE [dbo].[SchoolClasses]
ADD CONSTRAINT [PK_SchoolClasses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id] in table 'SmsMessageStores'
ALTER TABLE [dbo].[SmsMessageStores]
ADD CONSTRAINT [PK_SmsMessageStores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spAllowedReportsRolesMenus'
ALTER TABLE [dbo].[spAllowedReportsRolesMenus]
ADD CONSTRAINT [PK_spAllowedReportsRolesMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spAllowedRoleMenus'
ALTER TABLE [dbo].[spAllowedRoleMenus]
ADD CONSTRAINT [PK_spAllowedRoleMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spAllowedRoleMenuswebs'
ALTER TABLE [dbo].[spAllowedRoleMenuswebs]
ADD CONSTRAINT [PK_spAllowedRoleMenuswebs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spMenuItems'
ALTER TABLE [dbo].[spMenuItems]
ADD CONSTRAINT [PK_spMenuItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spMenus'
ALTER TABLE [dbo].[spMenus]
ADD CONSTRAINT [PK_spMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spReportsMenuItems'
ALTER TABLE [dbo].[spReportsMenuItems]
ADD CONSTRAINT [PK_spReportsMenuItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spRoles'
ALTER TABLE [dbo].[spRoles]
ADD CONSTRAINT [PK_spRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spUsers'
ALTER TABLE [dbo].[spUsers]
ADD CONSTRAINT [PK_spUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'spUsersInRoles'
ALTER TABLE [dbo].[spUsersInRoles]
ADD CONSTRAINT [PK_spUsersInRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
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

-- Creating primary key on [Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentsExamResults'
ALTER TABLE [dbo].[StudentsExamResults]
ADD CONSTRAINT [PK_StudentsExamResults]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentsExamResults_Temp'
ALTER TABLE [dbo].[StudentsExamResults_Temp]
ADD CONSTRAINT [PK_StudentsExamResults_Temp]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentsExamResultsDetails'
ALTER TABLE [dbo].[StudentsExamResultsDetails]
ADD CONSTRAINT [PK_StudentsExamResultsDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentsExamResultsDetail_Temp'
ALTER TABLE [dbo].[StudentsExamResultsDetail_Temp]
ADD CONSTRAINT [PK_StudentsExamResultsDetail_Temp]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentSubjectTargets'
ALTER TABLE [dbo].[StudentSubjectTargets]
ADD CONSTRAINT [PK_StudentSubjectTargets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ShortCode] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [PK_Subjects]
    PRIMARY KEY CLUSTERED ([ShortCode] ASC);
GO

-- Creating primary key on [Id] in table 'SubSubjects'
ALTER TABLE [dbo].[SubSubjects]
ADD CONSTRAINT [PK_SubSubjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [PK_Teachers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TechParams'
ALTER TABLE [dbo].[TechParams]
ADD CONSTRAINT [PK_TechParams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Id] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionsAuthorizations'
ALTER TABLE [dbo].[TransactionsAuthorizations]
ADD CONSTRAINT [PK_TransactionsAuthorizations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionTypes'
ALTER TABLE [dbo].[TransactionTypes]
ADD CONSTRAINT [PK_TransactionTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transports'
ALTER TABLE [dbo].[Transports]
ADD CONSTRAINT [PK_Transports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'UserProfiles'
ALTER TABLE [dbo].[UserProfiles]
ADD CONSTRAINT [PK_UserProfiles]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Name] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- Creating primary key on [UserId] in table 'webpages_Membership'
ALTER TABLE [dbo].[webpages_Membership]
ADD CONSTRAINT [PK_webpages_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Provider], [ProviderUserId] in table 'webpages_OAuthMembership'
ALTER TABLE [dbo].[webpages_OAuthMembership]
ADD CONSTRAINT [PK_webpages_OAuthMembership]
    PRIMARY KEY CLUSTERED ([Provider], [ProviderUserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'webpages_Roles'
ALTER TABLE [dbo].[webpages_Roles]
ADD CONSTRAINT [PK_webpages_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [PK_webpages_UsersInRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
GO

-- Creating primary key on [BankBranchName], [BankSortCode], [BankName], [BankCode], [BranchCode], [BranchName] in table 'vwBankBranches'
ALTER TABLE [dbo].[vwBankBranches]
ADD CONSTRAINT [PK_vwBankBranches]
    PRIMARY KEY CLUSTERED ([BankBranchName], [BankSortCode], [BankName], [BankCode], [BranchCode], [BranchName] ASC);
GO

-- Creating primary key on [ExamPeriodId], [ClassId], [Id], [StudentId], [SubjectShortCode], [ContributionFlag] in table 'vwExamResults'
ALTER TABLE [dbo].[vwExamResults]
ADD CONSTRAINT [PK_vwExamResults]
    PRIMARY KEY CLUSTERED ([ExamPeriodId], [ClassId], [Id], [StudentId], [SubjectShortCode], [ContributionFlag] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_Accounts]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_Accounts'
CREATE INDEX [IX_FK_Transactions_Accounts]
ON [dbo].[Transactions]
    ([AccountId]);
GO

-- Creating foreign key on [BankCode] in table 'BankBranches'
ALTER TABLE [dbo].[BankBranches]
ADD CONSTRAINT [FK_BankBranches_Banks]
    FOREIGN KEY ([BankCode])
    REFERENCES [dbo].[Banks]
        ([BankCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBranches_Banks'
CREATE INDEX [IX_FK_BankBranches_Banks]
ON [dbo].[BankBranches]
    ([BankCode]);
GO

-- Creating foreign key on [ClassId] in table 'ClassStreams'
ALTER TABLE [dbo].[ClassStreams]
ADD CONSTRAINT [FK_ClassStreams_SchoolClasses]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[SchoolClasses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassStreams_SchoolClasses'
CREATE INDEX [IX_FK_ClassStreams_SchoolClasses]
ON [dbo].[ClassStreams]
    ([ClassId]);
GO

-- Creating foreign key on [ClassStreamId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_ClassStreams]
    FOREIGN KEY ([ClassStreamId])
    REFERENCES [dbo].[ClassStreams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Students_ClassStreams'
CREATE INDEX [IX_FK_Students_ClassStreams]
ON [dbo].[Students]
    ([ClassStreamId]);
GO

-- Creating foreign key on [ClassId] in table 'ClassSubjects'
ALTER TABLE [dbo].[ClassSubjects]
ADD CONSTRAINT [FK_ClassSubjects_SchoolClasses]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[SchoolClasses]
        ([Id])
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

-- Creating foreign key on [SubjectTeacherId] in table 'ClassSubjects'
ALTER TABLE [dbo].[ClassSubjects]
ADD CONSTRAINT [FK_ClassSubjects_Teachers]
    FOREIGN KEY ([SubjectTeacherId])
    REFERENCES [dbo].[Teachers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassSubjects_Teachers'
CREATE INDEX [IX_FK_ClassSubjects_Teachers]
ON [dbo].[ClassSubjects]
    ([SubjectTeacherId]);
GO

-- Creating foreign key on [ExamPeriodId] in table 'Exams'
ALTER TABLE [dbo].[Exams]
ADD CONSTRAINT [FK_Exam_ExamPeriod]
    FOREIGN KEY ([ExamPeriodId])
    REFERENCES [dbo].[ExamPeriods]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Exam_ExamPeriod'
CREATE INDEX [IX_FK_Exam_ExamPeriod]
ON [dbo].[Exams]
    ([ExamPeriodId]);
GO

-- Creating foreign key on [ClassId] in table 'Exams'
ALTER TABLE [dbo].[Exams]
ADD CONSTRAINT [FK_Exam_SchoolClasses]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[SchoolClasses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Exam_SchoolClasses'
CREATE INDEX [IX_FK_Exam_SchoolClasses]
ON [dbo].[Exams]
    ([ClassId]);
GO

-- Creating foreign key on [SubjectShortCode] in table 'Exams'
ALTER TABLE [dbo].[Exams]
ADD CONSTRAINT [FK_Exam_Subjects]
    FOREIGN KEY ([SubjectShortCode])
    REFERENCES [dbo].[Subjects]
        ([ShortCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Exam_Subjects'
CREATE INDEX [IX_FK_Exam_Subjects]
ON [dbo].[Exams]
    ([SubjectShortCode]);
GO

-- Creating foreign key on [ExamId] in table 'RegisteredExams'
ALTER TABLE [dbo].[RegisteredExams]
ADD CONSTRAINT [FK_RegisteredExams_Exam]
    FOREIGN KEY ([ExamId])
    REFERENCES [dbo].[Exams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RegisteredExams_Exam'
CREATE INDEX [IX_FK_RegisteredExams_Exam]
ON [dbo].[RegisteredExams]
    ([ExamId]);
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

-- Creating foreign key on [GradingSystemId] in table 'GradingSystemDets'
ALTER TABLE [dbo].[GradingSystemDets]
ADD CONSTRAINT [FK_GradingSystemDets_GradingSystems]
    FOREIGN KEY ([GradingSystemId])
    REFERENCES [dbo].[GradingSystems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GradingSystemDets_GradingSystems'
CREATE INDEX [IX_FK_GradingSystemDets_GradingSystems]
ON [dbo].[GradingSystemDets]
    ([GradingSystemId]);
GO

-- Creating foreign key on [GradingSystem] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [FK_Schools_GradingSystems]
    FOREIGN KEY ([GradingSystem])
    REFERENCES [dbo].[GradingSystems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Schools_GradingSystems'
CREATE INDEX [IX_FK_Schools_GradingSystems]
ON [dbo].[Schools]
    ([GradingSystem]);
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
ADD CONSTRAINT [FK_ProgrammeYearCourses_Programmes]
    FOREIGN KEY ([ProgrammeId])
    REFERENCES [dbo].[Programmes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgrammeYearCourses_Programmes'
CREATE INDEX [IX_FK_ProgrammeYearCourses_Programmes]
ON [dbo].[ProgrammeYearCourses]
    ([ProgrammeId]);
GO

-- Creating foreign key on [ProgrammeId] in table 'ProgrammeYears'
ALTER TABLE [dbo].[ProgrammeYears]
ADD CONSTRAINT [FK_ProgrammeYears_Programmes]
    FOREIGN KEY ([ProgrammeId])
    REFERENCES [dbo].[Programmes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgrammeYears_Programmes'
CREATE INDEX [IX_FK_ProgrammeYears_Programmes]
ON [dbo].[ProgrammeYears]
    ([ProgrammeId]);
GO

-- Creating foreign key on [ProgrammeYearId] in table 'ProgrammeYearCourses'
ALTER TABLE [dbo].[ProgrammeYearCourses]
ADD CONSTRAINT [FK_ProgrammeYearCourses_ProgrammeYears]
    FOREIGN KEY ([ProgrammeYearId])
    REFERENCES [dbo].[ProgrammeYears]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgrammeYearCourses_ProgrammeYears'
CREATE INDEX [IX_FK_ProgrammeYearCourses_ProgrammeYears]
ON [dbo].[ProgrammeYearCourses]
    ([ProgrammeYearId]);
GO

-- Creating foreign key on [ProgrammeYearId] in table 'SchoolClasses'
ALTER TABLE [dbo].[SchoolClasses]
ADD CONSTRAINT [FK_SchoolClasses_ProgrammeYears]
    FOREIGN KEY ([ProgrammeYearId])
    REFERENCES [dbo].[ProgrammeYears]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolClasses_ProgrammeYears'
CREATE INDEX [IX_FK_SchoolClasses_ProgrammeYears]
ON [dbo].[SchoolClasses]
    ([ProgrammeYearId]);
GO

-- Creating foreign key on [RoomId] in table 'RegisteredExams'
ALTER TABLE [dbo].[RegisteredExams]
ADD CONSTRAINT [FK_RegisteredExams_Rooms]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RegisteredExams_Rooms'
CREATE INDEX [IX_FK_RegisteredExams_Rooms]
ON [dbo].[RegisteredExams]
    ([RoomId]);
GO

-- Creating foreign key on [TeacherId] in table 'SchoolClasses'
ALTER TABLE [dbo].[SchoolClasses]
ADD CONSTRAINT [FK_SchoolClasses_Teachers]
    FOREIGN KEY ([TeacherId])
    REFERENCES [dbo].[Teachers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolClasses_Teachers'
CREATE INDEX [IX_FK_SchoolClasses_Teachers]
ON [dbo].[SchoolClasses]
    ([TeacherId]);
GO

-- Creating foreign key on [SchoolId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_Schools]
    FOREIGN KEY ([SchoolId])
    REFERENCES [dbo].[Schools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Students_Schools'
CREATE INDEX [IX_FK_Students_Schools]
ON [dbo].[Students]
    ([SchoolId]);
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

-- Creating foreign key on [MenuItemId] in table 'spAllowedReportsRolesMenus'
ALTER TABLE [dbo].[spAllowedReportsRolesMenus]
ADD CONSTRAINT [FK_spAllowedReportsRolesMenus_spReportsMenuItems]
    FOREIGN KEY ([MenuItemId])
    REFERENCES [dbo].[spReportsMenuItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_spAllowedReportsRolesMenus_spReportsMenuItems'
CREATE INDEX [IX_FK_spAllowedReportsRolesMenus_spReportsMenuItems]
ON [dbo].[spAllowedReportsRolesMenus]
    ([MenuItemId]);
GO

-- Creating foreign key on [MenuItemId] in table 'spAllowedRoleMenus'
ALTER TABLE [dbo].[spAllowedRoleMenus]
ADD CONSTRAINT [FK_spAllowedRoleMenus_spMenuItems]
    FOREIGN KEY ([MenuItemId])
    REFERENCES [dbo].[spMenuItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_spAllowedRoleMenus_spMenuItems'
CREATE INDEX [IX_FK_spAllowedRoleMenus_spMenuItems]
ON [dbo].[spAllowedRoleMenus]
    ([MenuItemId]);
GO

-- Creating foreign key on [StudentId] in table 'StudentProgresses'
ALTER TABLE [dbo].[StudentProgresses]
ADD CONSTRAINT [FK_StudentProgresses_Students]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Students]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentProgresses_Students'
CREATE INDEX [IX_FK_StudentProgresses_Students]
ON [dbo].[StudentProgresses]
    ([StudentId]);
GO

-- Creating foreign key on [TransactionTypeId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_TransactionTypes]
    FOREIGN KEY ([TransactionTypeId])
    REFERENCES [dbo].[TransactionTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_TransactionTypes'
CREATE INDEX [IX_FK_Transactions_TransactionTypes]
ON [dbo].[Transactions]
    ([TransactionTypeId]);
GO

-- Creating foreign key on [TransactionTypeId] in table 'TransactionsAuthorizations'
ALTER TABLE [dbo].[TransactionsAuthorizations]
ADD CONSTRAINT [FK_TransactionsAuthorizations_TransactionTypes]
    FOREIGN KEY ([TransactionTypeId])
    REFERENCES [dbo].[TransactionTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionsAuthorizations_TransactionTypes'
CREATE INDEX [IX_FK_TransactionsAuthorizations_TransactionTypes]
ON [dbo].[TransactionsAuthorizations]
    ([TransactionTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------