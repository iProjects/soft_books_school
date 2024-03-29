/****** Object:  Database [SBSchoolDB]    Script Date: 12/16/2014 10:49:01 ******/
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'SBSchoolVersion' , NULL,NULL, NULL,NULL, NULL,NULL))
EXEC dbo.sp_addextendedproperty @name=N'SBSchoolVersion', @value=N'1.0.0.0'
GO
/****** Object:  ForeignKey [FK_StudentProgresses_Students]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses] DROP CONSTRAINT [FK_StudentProgresses_Students]
GO
/****** Object:  StoredProcedure [dbo].[CopyExamResults]    Script Date: 12/16/2014 10:49:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CopyExamResults]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CopyExamResults]
GO
/****** Object:  StoredProcedure [dbo].[CopyExamResultsDet]    Script Date: 12/16/2014 10:49:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CopyExamResultsDet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CopyExamResultsDet]
GO
/****** Object:  Table [dbo].[StudentProgresses]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses]') AND type in (N'U'))
DROP TABLE [dbo].[StudentProgresses]
GO
/****** Object:  View [dbo].[vwBankBranches]    Script Date: 12/16/2014 10:49:01 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwBankBranches]'))
DROP VIEW [dbo].[vwBankBranches]
GO
/****** Object:  View [dbo].[vwExamResults]    Script Date: 12/16/2014 10:49:01 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwExamResults]'))
DROP VIEW [dbo].[vwExamResults]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_Membership]') AND type in (N'U'))
DROP TABLE [dbo].[webpages_Membership]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_OAuthMembership]') AND type in (N'U'))
DROP TABLE [dbo].[webpages_OAuthMembership]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_Roles]') AND type in (N'U'))
DROP TABLE [dbo].[webpages_Roles]
GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 12/16/2014 10:49:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_UsersInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[webpages_UsersInRoles]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/16/2014 10:48:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[Accounts]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 12/16/2014 10:48:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountTypes]') AND type in (N'U'))
DROP TABLE [dbo].[AccountTypes]
GO
/****** Object:  Table [dbo].[Attendances]    Script Date: 12/16/2014 10:48:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendances]') AND type in (N'U'))
DROP TABLE [dbo].[Attendances]
GO
/****** Object:  Table [dbo].[BankBranches]    Script Date: 12/16/2014 10:48:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankBranches]') AND type in (N'U'))
DROP TABLE [dbo].[BankBranches]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 12/16/2014 10:48:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banks]') AND type in (N'U'))
DROP TABLE [dbo].[Banks]
GO
/****** Object:  Table [dbo].[BS_Level1]    Script Date: 12/16/2014 10:48:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BS_Level1]') AND type in (N'U'))
DROP TABLE [dbo].[BS_Level1]
GO
/****** Object:  Table [dbo].[BS_Level2]    Script Date: 12/16/2014 10:48:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BS_Level2]') AND type in (N'U'))
DROP TABLE [dbo].[BS_Level2]
GO
/****** Object:  Table [dbo].[ClassStreams]    Script Date: 12/16/2014 10:48:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassStreams]') AND type in (N'U'))
DROP TABLE [dbo].[ClassStreams]
GO
/****** Object:  Table [dbo].[ClassSubjects]    Script Date: 12/16/2014 10:48:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND type in (N'U'))
DROP TABLE [dbo].[ClassSubjects]
GO
/****** Object:  Table [dbo].[COA]    Script Date: 12/16/2014 10:48:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COA]') AND type in (N'U'))
DROP TABLE [dbo].[COA]
GO
/****** Object:  Table [dbo].[StudentProgresses_Temp]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses_Temp]') AND type in (N'U'))
DROP TABLE [dbo].[StudentProgresses_Temp]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
DROP TABLE [dbo].[Students]
GO
/****** Object:  Table [dbo].[StudentsExamResults]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResults]') AND type in (N'U'))
DROP TABLE [dbo].[StudentsExamResults]
GO
/****** Object:  Table [dbo].[StudentsExamResults_Temp]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResults_Temp]') AND type in (N'U'))
DROP TABLE [dbo].[StudentsExamResults_Temp]
GO
/****** Object:  Table [dbo].[StudentsExamResultsDetail]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]') AND type in (N'U'))
DROP TABLE [dbo].[StudentsExamResultsDetail]
GO
/****** Object:  Table [dbo].[StudentsExamResultsDetail_Temp]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail_Temp]') AND type in (N'U'))
DROP TABLE [dbo].[StudentsExamResultsDetail_Temp]
GO
/****** Object:  Table [dbo].[StudentSubjectTargets]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentSubjectTargets]') AND type in (N'U'))
DROP TABLE [dbo].[StudentSubjectTargets]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
DROP TABLE [dbo].[Subjects]
GO
/****** Object:  Table [dbo].[SubSubjects]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubSubjects]') AND type in (N'U'))
DROP TABLE [dbo].[SubSubjects]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teachers]') AND type in (N'U'))
DROP TABLE [dbo].[Teachers]
GO
/****** Object:  Table [dbo].[TechParams]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TechParams]') AND type in (N'U'))
DROP TABLE [dbo].[TechParams]
GO
/****** Object:  Table [dbo].[TimeTableDets]    Script Date: 12/16/2014 10:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTableDets]') AND type in (N'U'))
DROP TABLE [dbo].[TimeTableDets]
GO
/****** Object:  Table [dbo].[TimeTables]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTables]') AND type in (N'U'))
DROP TABLE [dbo].[TimeTables]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND type in (N'U'))
DROP TABLE [dbo].[Transactions]
GO
/****** Object:  Table [dbo].[TransactionsAuthorizations]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionsAuthorizations]') AND type in (N'U'))
DROP TABLE [dbo].[TransactionsAuthorizations]
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionTypes]') AND type in (N'U'))
DROP TABLE [dbo].[TransactionTypes]
GO
/****** Object:  Table [dbo].[Transport]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transport]') AND type in (N'U'))
DROP TABLE [dbo].[Transport]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
DROP TABLE [dbo].[UserProfile]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/16/2014 10:49:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/16/2014 10:48:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[DisciplinaryCategories]    Script Date: 12/16/2014 10:48:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DisciplinaryCategories]') AND type in (N'U'))
DROP TABLE [dbo].[DisciplinaryCategories]
GO
/****** Object:  Table [dbo].[Discipline]    Script Date: 12/16/2014 10:48:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Discipline]') AND type in (N'U'))
DROP TABLE [dbo].[Discipline]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/16/2014 10:48:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
DROP TABLE [dbo].[Employees]
GO
/****** Object:  Table [dbo].[Employers]    Script Date: 12/16/2014 10:48:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employers]') AND type in (N'U'))
DROP TABLE [dbo].[Employers]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 12/16/2014 10:48:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exam]') AND type in (N'U'))
DROP TABLE [dbo].[Exam]
GO
/****** Object:  Table [dbo].[ExamPeriod]    Script Date: 12/16/2014 10:48:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamPeriod]') AND type in (N'U'))
DROP TABLE [dbo].[ExamPeriod]
GO
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamTypes]') AND type in (N'U'))
DROP TABLE [dbo].[ExamTypes]
GO
/****** Object:  Table [dbo].[FeesStructure]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeesStructure]') AND type in (N'U'))
DROP TABLE [dbo].[FeesStructure]
GO
/****** Object:  Table [dbo].[FeeStructureAcademic]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeStructureAcademic]') AND type in (N'U'))
DROP TABLE [dbo].[FeeStructureAcademic]
GO
/****** Object:  Table [dbo].[FeeStructureOthers]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeStructureOthers]') AND type in (N'U'))
DROP TABLE [dbo].[FeeStructureOthers]
GO
/****** Object:  Table [dbo].[GradingSystemDets]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystemDets]') AND type in (N'U'))
DROP TABLE [dbo].[GradingSystemDets]
GO
/****** Object:  Table [dbo].[GradingSystems]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystems]') AND type in (N'U'))
DROP TABLE [dbo].[GradingSystems]
GO
/****** Object:  Table [dbo].[LocationProperties]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocationProperties]') AND type in (N'U'))
DROP TABLE [dbo].[LocationProperties]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locations]') AND type in (N'U'))
DROP TABLE [dbo].[Locations]
GO
/****** Object:  Table [dbo].[MarksheetArchives]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarksheetArchives]') AND type in (N'U'))
DROP TABLE [dbo].[MarksheetArchives]
GO
/****** Object:  Table [dbo].[MarkSheetExams]    Script Date: 12/16/2014 10:48:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetExams]') AND type in (N'U'))
DROP TABLE [dbo].[MarkSheetExams]
GO
/****** Object:  Table [dbo].[MarkSheetStudents]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]') AND type in (N'U'))
DROP TABLE [dbo].[MarkSheetStudents]
GO
/****** Object:  Table [dbo].[Parents]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parents]') AND type in (N'U'))
DROP TABLE [dbo].[Parents]
GO
/****** Object:  Table [dbo].[PL_Level1]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PL_Level1]') AND type in (N'U'))
DROP TABLE [dbo].[PL_Level1]
GO
/****** Object:  Table [dbo].[PL_Level2]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PL_Level2]') AND type in (N'U'))
DROP TABLE [dbo].[PL_Level2]
GO
/****** Object:  Table [dbo].[Programmes]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programmes]') AND type in (N'U'))
DROP TABLE [dbo].[Programmes]
GO
/****** Object:  Table [dbo].[ProgrammeYearCourses]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYearCourses]') AND type in (N'U'))
DROP TABLE [dbo].[ProgrammeYearCourses]
GO
/****** Object:  Table [dbo].[ProgrammeYears]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYears]') AND type in (N'U'))
DROP TABLE [dbo].[ProgrammeYears]
GO
/****** Object:  Table [dbo].[RegisteredExams]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND type in (N'U'))
DROP TABLE [dbo].[RegisteredExams]
GO
/****** Object:  Table [dbo].[ReportGroups]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportGroups]') AND type in (N'U'))
DROP TABLE [dbo].[ReportGroups]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
DROP TABLE [dbo].[Reports]
GO
/****** Object:  Table [dbo].[ResidenceHallRooms]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResidenceHallRooms]') AND type in (N'U'))
DROP TABLE [dbo].[ResidenceHallRooms]
GO
/****** Object:  Table [dbo].[ResidenceHalls]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResidenceHalls]') AND type in (N'U'))
DROP TABLE [dbo].[ResidenceHalls]
GO
/****** Object:  Table [dbo].[Residences]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Residences]') AND type in (N'U'))
DROP TABLE [dbo].[Residences]
GO
/****** Object:  Table [dbo].[RoleRights]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleRights]') AND type in (N'U'))
DROP TABLE [dbo].[RoleRights]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rooms]') AND type in (N'U'))
DROP TABLE [dbo].[Rooms]
GO
/****** Object:  Table [dbo].[RuleSet]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RuleSet]') AND type in (N'U'))
DROP TABLE [dbo].[RuleSet]
GO
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND type in (N'U'))
DROP TABLE [dbo].[SchoolClasses]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schools]') AND type in (N'U'))
DROP TABLE [dbo].[Schools]
GO
/****** Object:  Table [dbo].[SecurityQuestions]    Script Date: 12/16/2014 10:48:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestions]') AND type in (N'U'))
DROP TABLE [dbo].[SecurityQuestions]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
DROP TABLE [dbo].[Settings]
GO
/****** Object:  Table [dbo].[SettingsGroups]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SettingsGroups]') AND type in (N'U'))
DROP TABLE [dbo].[SettingsGroups]
GO
/****** Object:  Table [dbo].[SmsMessageStore]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SmsMessageStore]') AND type in (N'U'))
DROP TABLE [dbo].[SmsMessageStore]
GO
/****** Object:  Table [dbo].[spAllowedReportsRolesMenus]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAllowedReportsRolesMenus]') AND type in (N'U'))
DROP TABLE [dbo].[spAllowedReportsRolesMenus]
GO
/****** Object:  Table [dbo].[spAllowedRoleMenus]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAllowedRoleMenus]') AND type in (N'U'))
DROP TABLE [dbo].[spAllowedRoleMenus]
GO
/****** Object:  Table [dbo].[spAllowedRoleMenusweb]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAllowedRoleMenusweb]') AND type in (N'U'))
DROP TABLE [dbo].[spAllowedRoleMenusweb]
GO
/****** Object:  Table [dbo].[spMenuItems]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spMenuItems]') AND type in (N'U'))
DROP TABLE [dbo].[spMenuItems]
GO
/****** Object:  Table [dbo].[spMenus]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spMenus]') AND type in (N'U'))
DROP TABLE [dbo].[spMenus]
GO
/****** Object:  Table [dbo].[spReportsMenuItems]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spReportsMenuItems]') AND type in (N'U'))
DROP TABLE [dbo].[spReportsMenuItems]
GO
/****** Object:  Table [dbo].[spRoles]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRoles]') AND type in (N'U'))
DROP TABLE [dbo].[spRoles]
GO
/****** Object:  Table [dbo].[spUsers]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUsers]') AND type in (N'U'))
DROP TABLE [dbo].[spUsers]
GO
/****** Object:  Table [dbo].[StudentExams]    Script Date: 12/16/2014 10:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND type in (N'U'))
DROP TABLE [dbo].[StudentExams]
GO
/****** Object:  Schema [mato]    Script Date: 12/16/2014 10:49:02 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'mato')
DROP SCHEMA [mato]
GO
/****** Object:  Role [kevin]    Script Date: 12/16/2014 10:49:02 ******/
DECLARE @RoleName sysname
set @RoleName = N'kevin'
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = @RoleName AND type = 'R')
Begin
	DECLARE @RoleMemberName sysname
	DECLARE Member_Cursor CURSOR FOR
	select [name]
	from sys.database_principals 
	where principal_id in ( 
		select member_principal_id 
		from sys.database_role_members 
		where role_principal_id in (
			select principal_id
			FROM sys.database_principals where [name] = @RoleName  AND type = 'R' ))

	OPEN Member_Cursor;

	FETCH NEXT FROM Member_Cursor
	into @RoleMemberName

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec sp_droprolemember @rolename=@RoleName, @membername= @RoleMemberName

		FETCH NEXT FROM Member_Cursor
		into @RoleMemberName
	END;

	CLOSE Member_Cursor;
	DEALLOCATE Member_Cursor;
End
GO
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'kevin' AND type = 'R')
DROP ROLE [kevin]
GO
/****** Object:  Role [mato]    Script Date: 12/16/2014 10:49:02 ******/
DECLARE @RoleName sysname
set @RoleName = N'mato'
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = @RoleName AND type = 'R')
Begin
	DECLARE @RoleMemberName sysname
	DECLARE Member_Cursor CURSOR FOR
	select [name]
	from sys.database_principals 
	where principal_id in ( 
		select member_principal_id 
		from sys.database_role_members 
		where role_principal_id in (
			select principal_id
			FROM sys.database_principals where [name] = @RoleName  AND type = 'R' ))

	OPEN Member_Cursor;

	FETCH NEXT FROM Member_Cursor
	into @RoleMemberName

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec sp_droprolemember @rolename=@RoleName, @membername= @RoleMemberName

		FETCH NEXT FROM Member_Cursor
		into @RoleMemberName
	END;

	CLOSE Member_Cursor;
	DEALLOCATE Member_Cursor;
End
GO
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'mato' AND type = 'R')
DROP ROLE [mato]
GO
/****** Object:  Role [test]    Script Date: 12/16/2014 10:49:02 ******/
DECLARE @RoleName sysname
set @RoleName = N'test'
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = @RoleName AND type = 'R')
Begin
	DECLARE @RoleMemberName sysname
	DECLARE Member_Cursor CURSOR FOR
	select [name]
	from sys.database_principals 
	where principal_id in ( 
		select member_principal_id 
		from sys.database_role_members 
		where role_principal_id in (
			select principal_id
			FROM sys.database_principals where [name] = @RoleName  AND type = 'R' ))

	OPEN Member_Cursor;

	FETCH NEXT FROM Member_Cursor
	into @RoleMemberName

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec sp_droprolemember @rolename=@RoleName, @membername= @RoleMemberName

		FETCH NEXT FROM Member_Cursor
		into @RoleMemberName
	END;

	CLOSE Member_Cursor;
	DEALLOCATE Member_Cursor;
End
GO
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'test' AND type = 'R')
DROP ROLE [test]
GO
/****** Object:  Role [kevin]    Script Date: 12/16/2014 10:49:02 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'kevin')
BEGIN
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'kevin' AND type = 'R')
CREATE ROLE [kevin] AUTHORIZATION [dbo]

END
GO
/****** Object:  Role [mato]    Script Date: 12/16/2014 10:49:02 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'mato')
BEGIN
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'mato' AND type = 'R')
CREATE ROLE [mato] AUTHORIZATION [dbo]

END
GO
/****** Object:  Role [test]    Script Date: 12/16/2014 10:49:02 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'test')
BEGIN
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'test' AND type = 'R')
CREATE ROLE [test] AUTHORIZATION [dbo]

END
GO
/****** Object:  Schema [mato]    Script Date: 12/16/2014 10:49:02 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'mato')
EXEC sys.sp_executesql N'CREATE SCHEMA [mato] AUTHORIZATION [mato]'
GO
/****** Object:  Table [dbo].[StudentExams]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentExams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[RegdExamId] [int] NOT NULL,
	[Mark] [float] NULL,
	[Status] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModified] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StudentExams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND name = N'IX_FK_StudentExams_RegisteredExams1')
CREATE NONCLUSTERED INDEX [IX_FK_StudentExams_RegisteredExams1] ON [dbo].[StudentExams] 
(
	[RegdExamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND name = N'IX_FK_StudentExams_Students')
CREATE NONCLUSTERED INDEX [IX_FK_StudentExams_Students] ON [dbo].[StudentExams] 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET IDENTITY_INSERT [dbo].[StudentExams] ON
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (281, 171, 153, NULL, NULL, N'sys', CAST(0x0000A35400AAAC5D AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (282, 172, 153, NULL, NULL, N'sys', CAST(0x0000A35400AAAC6C AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (283, 171, 157, NULL, NULL, N'sys', CAST(0x0000A35400AAAC7F AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (284, 172, 157, NULL, NULL, N'sys', CAST(0x0000A35400AAAC90 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (285, 171, 161, NULL, NULL, N'sys', CAST(0x0000A35400AAACA8 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (286, 172, 161, NULL, NULL, N'sys', CAST(0x0000A35400AAACB3 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (287, 171, 154, NULL, NULL, N'sys', CAST(0x0000A35400AAB096 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (288, 172, 154, NULL, NULL, N'sys', CAST(0x0000A35400AAB0A2 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (289, 171, 158, NULL, NULL, N'sys', CAST(0x0000A35400AAB0B4 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (290, 172, 158, NULL, NULL, N'sys', CAST(0x0000A35400AAB0C1 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (291, 171, 162, NULL, NULL, N'sys', CAST(0x0000A35400AAB0D4 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (292, 172, 162, NULL, NULL, N'sys', CAST(0x0000A35400AAB0E2 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (293, 171, 156, NULL, NULL, N'sys', CAST(0x0000A35400AAB4FD AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (294, 172, 156, NULL, NULL, N'sys', CAST(0x0000A35400AAB509 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (295, 171, 160, NULL, NULL, N'sys', CAST(0x0000A35400AAB518 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (296, 172, 160, NULL, NULL, N'sys', CAST(0x0000A35400AAB523 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (297, 171, 164, NULL, NULL, N'sys', CAST(0x0000A35400AAB533 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (298, 172, 164, NULL, NULL, N'sys', CAST(0x0000A35400AAB53E AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (299, 171, 155, NULL, NULL, N'sys', CAST(0x0000A35400AAB996 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (300, 172, 155, NULL, NULL, N'sys', CAST(0x0000A35400AAB9A2 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (301, 171, 159, NULL, NULL, N'sys', CAST(0x0000A35400AAB9B4 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (302, 172, 159, NULL, NULL, N'sys', CAST(0x0000A35400AAB9C0 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (303, 171, 163, NULL, NULL, N'sys', CAST(0x0000A35400AAB9D6 AS DateTime), NULL)
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified], [IsDeleted]) VALUES (304, 172, 163, NULL, NULL, N'sys', CAST(0x0000A35400AAB9E3 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[StudentExams] OFF
/****** Object:  Table [dbo].[spUsers]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[spUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
	[EmployeeId] [int] NULL,
	[UserName] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Password] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Locked] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[SystemId] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ISUserLogins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[spUsers] ON
INSERT [dbo].[spUsers] ([Id], [UserId], [RoleId], [EmployeeId], [UserName], [Password], [Status], [Locked], [IsDeleted], [SystemId]) VALUES (1, NULL, 1, NULL, N'sys', N'sys', NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[spUsers] OFF
/****** Object:  Table [dbo].[spRoles]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[spRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[spRoles] ON
INSERT [dbo].[spRoles] ([Id], [ShortCode], [Description], [IsDeleted]) VALUES (1, N'admin', N'Administrator', 0)
SET IDENTITY_INSERT [dbo].[spRoles] OFF
/****** Object:  Table [dbo].[spReportsMenuItems]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spReportsMenuItems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[spReportsMenuItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[mnuName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_spReportsMenuItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[spReportsMenuItems] ON
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (1, N'fileToolStripMenuItem', N'File Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (2, N'studentListsToolStripMenuItem', N'Students List Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (3, N'teachersListtoolStripMenuItem', N'Teachers List Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (4, N'subjectListsToolStripMenuItem', N'Subjects List Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (5, N'classListsToolStripMenuItem', N'Classes List Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (6, N'programmeCourseListToolStripMenuItem', N'Programme Courses List Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (8, N'examResultsToolStripMenuItem', N'Exam Results Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (9, N'examResultsbyClassToolStripMenuItem', N'Exam Results by Class Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (10, N'examResultsbySubjectToolStripMenuItem', N'Exam Results by Subject Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (11, N'examResultsbyExamTypeToolStripMenuItem', N'Exam Results By Exam Type Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (12, N'markSheetTableToolStripMenuItem', N'Mark Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (13, N'preSchoolToolStripMenuItem', N'Pre-School Mark Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (14, N'primaryToolStripMenuItem', N'Primary Mark Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (15, N'secondaryToolStripMenuItem', N'Secondary Mark Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (16, N'tertiaryToolStripMenuItem', N'Tertiary Mark Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (17, N'collegeToolStripMenuItem', N'College Mark Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (18, N'universityToolStripMenuItem', N'University Mark Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (19, N'academicReportsToolStripMenuItem', N'Academic Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (20, N'studentAcademicToolStripMenuItem', N'Student Academic Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (21, N'studentAcademicReportFormToolStripMenuItem', N'Student Academic Report Form Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (22, N'studentAcademicProgressFormToolStripMenuItem', N'Student Academic Progress Form Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (23, N'studentPerformanceByTargetToolStripMenuItem', N'Student Academic Performance by Target Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (24, N'teacherAcademicToolStripMenuItem', N'Teacher Academic Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (25, N'teacherAcademicRepotFormToolStripMenuItem', N'Teacher Academic Report Form Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (26, N'teachersProgressFormToolStripMenuItem', N'Teacher Academic Progress Form Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (27, N'teacherPerformanceByTargetToolStripMenuItem', N'Teacher Academic Performance by Target Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (28, N'classAcademicToolStripMenuItem', N'Class Academic Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (29, N'classesReportFormToolStripMenuItem', N'Class Academic Report Form Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (30, N'classesProgressFormToolStripMenuItem', N'Class Academic Progress Form Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (31, N'classesPerformanceByTargetToolStripMenuItem', N'Class Academic Performance by Target Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (32, N'classConsolidatedMarksheetToolStripMenuItem', N'Class Consolidated Mark Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (33, N'schoolAcademicToolStripMenuItem', N'School Academic Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (34, N'schoolsReportFormToolStripMenuItem', N'School Academic Report Form Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (36, N'schoolsProgressFormToolStripMenuItem', N'School Academic Progress Form Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (37, N'schoolPerformanceByTargetToolStripMenuItem', N'School Academic Performance by Target Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (38, N'schoolPerformanceInTheRegionToolStripMenuItem', N'School Academic Performance in the Region Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (39, N'financialReportsToolStripMenuItem', N'Financial Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (41, N'studentFinancialReportToolStripMenuItem', N'Student Financial Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (42, N'studentStatementToolStripMenuItem', N'Student Statement Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (43, N'studentAccountStatusToolStripMenuItem', N'Student Account Status Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (44, N'studentArrearsReceivablesToolStripMenuItem', N'Student Arrears and Receivables Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (45, N'parentStatementToolStripMenuItem', N'Parent Statement Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (46, N'parentAccountStatusToolStripMenuItem', N'Parent Account Status Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (47, N'paymentReceiptsToolStripMenuItem', N'Payment Receipt Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (48, N'studentFeesStructureToolStripMenuItem', N'Student Fee Structure Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (49, N'schoolFinancialReportToolStripMenuItem', N'School Financial Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (50, N'generalLToolStripMenuItem', N'General Ledger Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (52, N'pLToolStripMenuItem', N'Profit and Loss Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (53, N'balanceSheetToolStripMenuItem', N'Balance Sheet Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (54, N'bankStatementToolStripMenuItem', N'Bank Statement Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (55, N'cashBookToolStripMenuItem', N'Cash Book Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (56, N'schoolArrearsReceivablesToolStripMenuItem', N'School Arrears and Receivables Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (58, N'payablesToolStripMenuItem', N'Payables Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (59, N'feesStructureToolStripMenuItem', N'Fee Structure Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (60, N'feeStructurebyClassToolStripMenuItem', N'Fee Structure by Class Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (62, N'feeStructurebyProgrammeToolStripMenuItem', N'Fee Structure by Programme Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (63, N'feeStructurebyAccountTypesToolStripMenuItem', N'Fee Structure by Account Type Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (64, N'nonAcademicReportToolStripMenuItem', N'Non Academic Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (65, N'nonAcademicstudentToolStripMenuItem', N'Student Non Academic Reports Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (66, N'disciplineStatusToolStripMenuItem', N'Discipline Status Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (67, N'disciplinaryRecordToolStripMenuItem', N'Disciplinary Report Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (68, N'extraCurriculaToolStripMenuItem', N'Extra Curricula Activities Report Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (69, N'medicalRecordToolStripMenuItem', N'Medical Report Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (70, N'attendanceRecordToolStripMenuItem', N'Attendance Report Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (71, N'timetableReportToolStripMenuItem', N'Timetable Report Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (72, N'btnAccountStatement', N'Account Statement Button')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (73, N'listsToolStripMenuItem', N'Lists Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (74, N'studentsListtoolStripMenuItem', N'Students Lists Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (75, N'teacherListstoolStripMenuItem', N'Teachers Lists Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (76, N'subjectsListstoolStripMenuItem', N'Subjects Lists Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (77, N'classesListstoolStripMenuItem', N'Classes Lists Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (78, N'programmesListstoolStripMenuItem', N'Programmes Lists Buton Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (79, N'reportFormstoolStripButton', N'Report Forms Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (80, N'studentReportFormToolStripMenuItem', N'Student Report Form Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (81, N'teacherReportFormToolStripMenuItem', N'Teacher Report Form Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (82, N'classReportFormToolStripMenuItem', N'Class Report Form Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (83, N'schoolReportFormToolStripMenuItem', N'School Report Form Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (84, N'toolStripButtonProgressForms', N'Progress Forms Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (85, N'studentProgressFormToolStripMenuItem', N'Student Progress Form Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (86, N'teacherProgressFormToolStripMenuItem', N'Teacher Progress Form Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (87, N'classProgressFormToolStripMenuItem', N'Class Progress Form Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (88, N'schoolProgressFormToolStripMenuItem', N'School Progress Form Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (89, N'toolStripDropDownButtonPerformanceByTarget', N'Performance by Target Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (90, N'studentsPerformanceByTargetsToolStripMenuItem', N'Student Performance by Target Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (91, N'teachersPerformanceByTargetsToolStripMenuItem', N'Teacher Performance by Target Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (92, N'classPerformanceByTargetToolStripMenuItem', N'Class Performance by Target Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (93, N'schoolsPerformanceByTargetsToolStripMenuItem', N'School Performance by Target Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (94, N'toolStripButtonExamResults', N'Exam Results Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (95, N'examsResultsbyClassToolStripMenuItem', N'Exam Results by Class Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (98, N'examsResultsBySubjectsToolStripMenuItem', N'Exam Results by Subject Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (99, N'examsResultsByExamTypesToolStripMenuItem', N'Exam Results by Exam Type Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (100, N'toolStripDropDownButtonMarksTableForms', N'Mark Sheet Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (101, N'preSchoolsMarkSheetToolStripMenuItem', N'PreSchool Mark Sheet Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (102, N'primarySchoolsMarkSheetToolStripMenuItem', N'Primary School Mark Sheet Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (103, N'secondarySchoolsMarkSheetToolStripMenuItem', N'Secondary School Mark Sheet Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (104, N'tertiarySchoolsMarkSheetToolStripMenuItem', N'Tertiary School Mark Sheet Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (106, N'collegeSchoolsMarkSheetToolStripMenuItem', N'College School Mark Sheet Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (108, N'universitySchoolsMarkSheetToolStripMenuItem', N'University School Mark Sheet Button Menu')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (109, N'btnSearchbyAccount', N'Search Account by Account Button')
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (110, N'btnSearchbyStudent', N'Search Account by Student Button')
GO
print 'Processed 100 total records'
INSERT [dbo].[spReportsMenuItems] ([Id], [mnuName], [Description]) VALUES (111, N'btnSearchExamPeriods', N'Search Exam Period Button')
SET IDENTITY_INSERT [dbo].[spReportsMenuItems] OFF
/****** Object:  Table [dbo].[spMenus]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spMenus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[spMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[mnuName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_spMenus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[spMenus] ON
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (1, N'mnuDataEntry', N'Data Entry - Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (2, N'subMenuSubjects', N'Subjects - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (3, N'subMenuProgrammes', N'Programmes - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (4, N'subMenuTeachers', N'Teachers - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (5, N'subMenuSchoolClasses', N'School Classes - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (6, N'subMenuStudents', N'Students - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (7, N'subMenuCustomers', N'Customers - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (8, N'subMenuGradingSystems', N'Grading Systems - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (9, N'subMenuAttendance', N'Attendance - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (10, N'subMenuRooms', N'Rooms - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (11, N'subMenuLocations', N'Locations - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (12, N'subMenuDisciplineCategories', N'Discipline Categories - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (13, N'mnuExams', N'Exams - Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (14, N'subMenuExamPeriods', N'Exam Periods - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (15, N'subMenuExamTypes', N'Exam Types - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (16, N'subMenuExams', N'Exams - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (17, N'subMenuRegisteredStudents', N'Registered Students - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (18, N'subMenuMarkSheet', N'Mark Sheet - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (19, N'subMenuProcessedExams', N'Processed Exams - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (20, N'mnuFees', N'Fees - Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (21, N'subMenuFees', N'Fees - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (22, N'subMenuAdmission', N'Admission - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (23, N'mnuAccounting', N'Accounting - Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (24, N'subMenuChartOfAccounts', N'Chart of Accounts - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (25, N'subMenuAccounts', N'Accounts - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (26, N'subMenuAccountTypes', N'Account Types - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (27, N'subMenuTransactionTypes', N'Transaction Types - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (28, N'subMenuTransactionsAuthorizations', N'Transactions Authorizations - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (29, N'subMenuBanks', N'Banks - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (30, N'subMenuEnquiry', N'Enquiry - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (31, N'subMenuPayFees', N'Pay Fees - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (32, N'subMenuGeneralPosts', N'General Posts - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (33, N'mnuTechnical', N'Technical - Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (34, N'subMenuSMS', N'Sms - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (35, N'subMenuReports', N'Reports - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (36, N'subMenuSchools', N'Schools - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (37, N'subMenuSettings', N'Settings - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (38, N'subMenuTimeTables', N'Time Table - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (39, N'mnuAdministrator', N'Administrator - Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (40, N'subMenuEmployers', N'Employers - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (41, N'subMenuEmployees', N'Employees - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (42, N'subMenuRoles', N'Roles - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (43, N'subMenuUsers', N'Users - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (44, N'subMenuUsersRoles', N'Users Roles - Sub Menu')
INSERT [dbo].[spMenus] ([Id], [mnuName], [Description]) VALUES (45, N'subMenuRights', N'Rights - Sub Menu')
SET IDENTITY_INSERT [dbo].[spMenus] OFF
/****** Object:  Table [dbo].[spMenuItems]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spMenuItems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[spMenuItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[mnuName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_MenuItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[spMenuItems] ON
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (2, N'dataEntryToolStripMenuItem', N'Data Entry Menu')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (3, N'examsToolStripMenuItem', N'Exams Menu')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (4, N'feesToolStripMenuItem', N'Fees Menu')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (5, N'generalLedgerToolStripMenuItem', N'General Ledger Menu')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (6, N'reportsToolStripMenuItem', N'Reports Menu')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (7, N'administrationToolStripMenuItem', N'Administration Menu')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (8, N'changePasswordToolStripMenuItem', N'Change Password')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (9, N'subjectsToolStripMenuItem', N'Subjects')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (10, N'programmesToolStripMenuItem', N'Programmes')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (11, N'teachersToolStripMenuItem', N'Teachers')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (12, N'classesToolStripMenuItem', N'Classes')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (13, N'studentsToolStripMenuItem', N'Students')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (14, N'customersToolStripMenuItem', N'Customers')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (15, N'gradingToolStripMenuItem', N'Grading')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (16, N'attendanceToolStripMenuItem', N'Attendance')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (17, N'roomsToolStripMenuItem', N'Rooms')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (18, N'locationsToolStripMenuItem', N'Locations')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (19, N'disciplineCategoriesToolStripMenuItem', N'Discipline Categories')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (20, N'examPeriodsToolStripMenuItem', N'Exam Periods')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (21, N'examTypesToolStripMenuItem', N'Exam Types')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (22, N'examsToolStripMenuItem', N'Exams')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (23, N'registerStudentsToolStripItem', N'Register Students')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (24, N'markSheetToolStripMenuItem', N'Mark Sheet')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (25, N'processExamsToolStripMenuItem', N'Process Exams')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (26, N'examResultsToolStripMenuItem', N'Exam Results')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (27, N'feeStructureToolStripMenuItem', N'Fee Structure')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (28, N'admissionFormToolStripMenuItem', N'Admission')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (29, N'chartOfAccountsToolStripMenuItem', N'Chart of Accounts')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (30, N'accountsToolStripMenuItem', N'Accounts')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (31, N'accountTypesToolStripMenuItem', N'Account Types')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (32, N'transactionTypesToolStripMenuItem', N'Transaction Types')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (33, N'transactionsAuthorizationsToolStripMenuItem', N'Transactions Authorization')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (34, N'banksToolStripMenuItem', N'Banks')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (35, N'enquiryToolStripMenuItem', N'Enquiry')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (36, N'postingToolStripMenuItem', N'Post')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (37, N'payFeesToolStripMenuItem', N'Pay Fees')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (38, N'generalPostsToolStripMenuItem', N'General Post')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (39, N'reportToolStripMenuItem', N'Reports')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (40, N'schoolSetUpToolStripMenuItem', N'School Set-Up')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (41, N'timeTableToolStripMenuItem', N'Time Table')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (42, N'rightsToolStripMenuItem', N'Rights')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (43, N'rolesToolStripMenuItem', N'Roles')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (44, N'usersToolStripMenuItem', N'Users')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (45, N'settingsToolStripMenuItem', N'Settings')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (46, N'databaseControlPanelToolStripMenuItem', N'Database Control Panel')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (47, N'uploadDownloadWizardToolStripMenuItem', N'Upload and Download Wizard')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (50, N'toolStripButtonReports', N'Reports Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (51, N'toolStripButtonStudents', N'Students Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (52, N'toolStripButtonAdmission', N'Admission Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (53, N'toolStripButtonChartofAccounts', N'Chart of Accounts Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (54, N'toolStripButtonGeneralPostings', N'General Posts Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (55, N'toolStripButtonPayFees', N'Pay Fees Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (56, N'toolStripButtonEnquiry', N'Enquiry Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (57, N'toolStripButtonExams', N'Exams Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (58, N'toolStripButtonRegisterStudents', N'Register Students Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (59, N'toolStripButtonMarkSheet', N'Mark Sheet Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (60, N'toolStripButtonProcessExams', N'Process Exams Button')
INSERT [dbo].[spMenuItems] ([Id], [mnuName], [Description]) VALUES (61, N'toolStripButtonExamResults', N'Exam Results Button')
SET IDENTITY_INSERT [dbo].[spMenuItems] OFF
/****** Object:  Table [dbo].[spAllowedRoleMenusweb]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAllowedRoleMenusweb]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[spAllowedRoleMenusweb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[MenuItemId] [int] NULL,
	[Allowed] [bit] NULL,
 CONSTRAINT [PK_spAllowedRoleMenusweb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[spAllowedRoleMenusweb] ON
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (5, 1, 1, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (6, 1, 2, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (7, 1, 3, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (8, 1, 4, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (9, 1, 5, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (10, 1, 6, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (11, 1, 7, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (12, 1, 8, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (13, 1, 9, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (14, 1, 10, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (15, 1, 11, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (16, 1, 12, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (17, 1, 13, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (18, 1, 14, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (19, 1, 15, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (20, 1, 16, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (21, 1, 17, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (22, 1, 18, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (23, 1, 19, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (24, 1, 20, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (25, 1, 21, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (26, 1, 22, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (27, 1, 23, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (28, 1, 24, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (29, 1, 25, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (30, 1, 26, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (31, 1, 27, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (32, 1, 28, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (33, 1, 29, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (34, 1, 30, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (35, 1, 31, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (36, 1, 32, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (37, 1, 33, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (38, 1, 34, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (39, 1, 35, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (40, 1, 36, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (41, 1, 37, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (42, 1, 38, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (43, 1, 39, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (44, 1, 40, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (45, 1, 41, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (46, 1, 42, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (47, 1, 43, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (48, 1, 44, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (49, 1, 45, 1)
INSERT [dbo].[spAllowedRoleMenusweb] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (51, 2, 28, 1)
SET IDENTITY_INSERT [dbo].[spAllowedRoleMenusweb] OFF
/****** Object:  Table [dbo].[spAllowedRoleMenus]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAllowedRoleMenus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[spAllowedRoleMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
	[Allowed] [bit] NOT NULL,
 CONSTRAINT [PK_AllowedRoleMenus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[spAllowedRoleMenus] ON
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (1, 1, 7, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (2, 1, 42, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (3, 1, 2, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (4, 1, 38, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (5, 1, 43, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (6, 1, 22, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (9, 1, 44, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (11, 1, 31, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (12, 1, 30, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (13, 1, 28, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (14, 1, 52, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (15, 1, 16, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (16, 1, 34, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (17, 1, 8, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (18, 1, 29, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (19, 1, 53, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (20, 1, 3, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (21, 1, 4, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (22, 1, 5, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (23, 1, 25, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (24, 1, 47, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (25, 1, 39, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (26, 1, 50, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (27, 1, 6, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (28, 1, 51, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (29, 1, 13, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (30, 1, 9, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (31, 1, 37, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (32, 1, 55, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (33, 1, 36, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (34, 1, 35, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (35, 1, 56, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (36, 1, 20, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (37, 1, 26, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (38, 1, 61, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (39, 1, 21, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (40, 1, 57, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (41, 1, 27, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (42, 1, 54, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (43, 1, 15, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (44, 1, 18, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (45, 1, 24, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (46, 1, 59, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (47, 1, 41, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (48, 1, 32, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (49, 1, 33, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (50, 1, 10, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (51, 1, 11, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (52, 1, 12, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (53, 1, 14, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (54, 1, 17, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (55, 1, 19, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (56, 1, 23, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (57, 1, 58, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (58, 1, 45, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (59, 1, 46, 1)
INSERT [dbo].[spAllowedRoleMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (60, 1, 60, 1)
SET IDENTITY_INSERT [dbo].[spAllowedRoleMenus] OFF
/****** Object:  Table [dbo].[spAllowedReportsRolesMenus]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAllowedReportsRolesMenus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[spAllowedReportsRolesMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuItemId] [int] NOT NULL,
	[Allowed] [bit] NOT NULL,
 CONSTRAINT [PK_spAllowedReportsRolesMenus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[spAllowedReportsRolesMenus] ON
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (5, 1, 1, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (6, 1, 50, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (8, 1, 8, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (9, 1, 64, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (10, 1, 19, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (11, 1, 73, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (12, 1, 79, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (13, 1, 84, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (14, 1, 89, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (15, 1, 94, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (16, 1, 100, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (17, 1, 110, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (18, 1, 109, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (19, 1, 111, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (20, 1, 72, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (21, 1, 53, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (22, 1, 54, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (23, 1, 55, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (24, 1, 31, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (25, 1, 30, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (26, 1, 29, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (27, 1, 28, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (28, 2, 32, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (29, 1, 39, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (30, 1, 70, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (31, 1, 32, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (32, 1, 17, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (33, 1, 106, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (34, 1, 5, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (35, 1, 63, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (36, 1, 95, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (37, 1, 9, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (38, 1, 99, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (39, 1, 11, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (40, 1, 98, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (41, 1, 10, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (42, 1, 68, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (43, 1, 60, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (44, 1, 62, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (45, 1, 59, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (46, 1, 12, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (47, 1, 69, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (48, 1, 46, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (49, 1, 45, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (50, 1, 58, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (51, 1, 47, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (52, 1, 101, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (53, 1, 13, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (54, 1, 14, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (55, 1, 52, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (56, 1, 6, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (57, 1, 78, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (58, 1, 37, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (59, 1, 38, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (60, 1, 36, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (61, 1, 34, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (62, 1, 33, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (63, 1, 56, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (64, 1, 49, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (65, 1, 93, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (66, 1, 88, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (67, 1, 83, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (68, 1, 15, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (69, 1, 103, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (70, 1, 23, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (71, 1, 22, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (72, 1, 21, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (73, 1, 20, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (74, 1, 44, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (75, 1, 48, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (76, 1, 41, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (77, 1, 65, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (78, 1, 90, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (79, 1, 85, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (80, 1, 80, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (81, 1, 42, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (82, 1, 2, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (83, 1, 76, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (84, 1, 74, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (85, 1, 4, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (86, 1, 27, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (87, 1, 26, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (88, 1, 25, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (89, 1, 24, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (90, 1, 91, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (91, 1, 86, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (92, 1, 81, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (93, 1, 3, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (94, 1, 75, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (95, 1, 16, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (96, 1, 104, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (97, 1, 71, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (98, 2, 18, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (99, 1, 108, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (100, 1, 92, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (101, 1, 87, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (102, 1, 82, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (103, 1, 77, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (104, 1, 102, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (105, 1, 67, 1)
GO
print 'Processed 100 total records'
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (106, 1, 66, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (107, 1, 43, 1)
INSERT [dbo].[spAllowedReportsRolesMenus] ([Id], [RoleId], [MenuItemId], [Allowed]) VALUES (108, 1, 18, 1)
SET IDENTITY_INSERT [dbo].[spAllowedReportsRolesMenus] OFF
/****** Object:  Table [dbo].[SmsMessageStore]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SmsMessageStore]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SmsMessageStore](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserDataText] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OriginatingAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SCTimestamp] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MessageStatus] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Storage] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SmscAddressType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SmscAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OriginatingAddressType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MessageType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MessageIndex] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MessageBody] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Processed] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_SmsMessageStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[SettingsGroups]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SettingsGroups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SettingsGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Parent] [int] NOT NULL,
 CONSTRAINT [PK_SettingsGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[SettingsGroups] ON
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (1, N'Settings', 0)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (2, N'School', 1)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (3, N'General', 1)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (7, N'Security', 1)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (8, N'Mpesa', 1)
SET IDENTITY_INSERT [dbo].[SettingsGroups] OFF
/****** Object:  Table [dbo].[Settings]    Script Date: 12/16/2014 10:48:58 ******/
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
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND name = N'IX_FK_Settings_SettingsGroups')
CREATE NONCLUSTERED INDEX [IX_FK_Settings_SettingsGroups] ON [dbo].[Settings] 
(
	[SGroup] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'BANKACC', N'1', N'N', N'Bank Account', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'CASHACC', N'1', N'N', N'Cash Account', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'COMMBAUDRATE', N'460800', N'N', N'Baud Rate', 8, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'COMMPORT', N'5', N'N', N'Modem Port', 8, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'COMMTIMEOUT', N'5000', N'N', N'Time Out', 8, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'FEESPOSTINGTXN', N'1', N'N', N'Fees Posting Transaction Type', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'FIRSTNAME', N'7', N'N', N'First Name Index', 8, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'GRADINGSYS', N'1', N'N', N'Grading System', 2, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'HELPFILEPATH', N'C:\Program Files (x86)\Software Providers\Soft Books School\Help', N'S', N'Help Sytem File Path', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'LASTNAME', N'8', N'N', N'Last Name Index', 8, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MAXTRIES', N'3', N'N', N'Maximum password retries', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MINAGE', N'18', N'N', N'Minimum employement age', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MPESAACC', N'1', N'N', N'Mpesa Account', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MPESAAMOUNT', N'5', N'N', N'Mpesa Amount Index', 8, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MPESAREFERENCENUMBER', N'0', N'N', N'Mpesa Reference Number Index', 8, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PWDSIZE', N'5', N'N', N'Password size', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'REPFORMNAME', N'SCHOOL REPORT', N'S', N'Report Form Name', 2, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'REPORTPATH', N'C:\Program Files (x86)\Software Providers\Soft Books School\Reports', N'S', N'Report Output Path', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'RESOURCEPATH', N'C:\Program Files (x86)\Software Providers\Soft Books School\Resources', N'S', N'Resource Path', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SCHOOLID', N'1', N'N', N'School Id', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SCHOOLLOGO', N'C:\Program Files (x86)\Software Providers\Soft Books School\Resources\softwareproviderslogo.jpg', N'S', N'School Logo', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SCHOOLSLOGAN', N'Solutions for all', N'S', N'School Slogan', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SENDERPHONENUMBER', N'9', N'N', N'Sender Phone Number Index', 8, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'STUDFEESCOAID', N'27', N'N', N'Student Account COA', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SUSPCR', N'63', N'N', N'SUSPENSE CREDIT ACCOUNT', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SUSPDR', N'62', N'N', N'SUSPENSE DEBIT ACCOUNT', 7, 0)
/****** Object:  Table [dbo].[SecurityQuestions]    Script Date: 12/16/2014 10:48:57 ******/
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
/****** Object:  Table [dbo].[Schools]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schools]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Schools](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SchoolIndex] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SchoolName] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SchoolType] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GradingSystem] [int] NOT NULL,
	[DefaultSchool] [bit] NOT NULL,
	[GLCustomerId] [int] NOT NULL,
	[Cellphone] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address1] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address2] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SMTPServer] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SMSGateway] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Logo] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Slogan] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SchoolClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClassName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProgrammeYearId] [int] NOT NULL,
	[NoOfSubjects] [int] NOT NULL,
	[TeacherId] [int] NULL,
	[CurrentYrLevel] [int] NULL,
	[NextYrLevel] [int] NULL,
	[Remarks] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_SchoolClasses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND name = N'IX_FK_Class_FK00')
CREATE NONCLUSTERED INDEX [IX_FK_Class_FK00] ON [dbo].[SchoolClasses] 
(
	[TeacherId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND name = N'IX_FK_SchoolClasses_Programmes')
CREATE NONCLUSTERED INDEX [IX_FK_SchoolClasses_Programmes] ON [dbo].[SchoolClasses] 
(
	[ProgrammeYearId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[RuleSet]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RuleSet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RuleSet](
	[Name] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MajorVersion] [int] NOT NULL,
	[MinorVersion] [int] NOT NULL,
	[RuleSet] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Status] [smallint] NULL,
	[AssemblyPath] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ActivityName] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_RuleSet] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[MajorVersion] ASC,
	[MinorVersion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[RuleSet] ([Name], [MajorVersion], [MinorVersion], [RuleSet], [Status], [AssemblyPath], [ActivityName], [ModifiedDate], [IsDeleted]) VALUES (N'RegExamsRuleSet', 1, 0, N'<RuleSet Description="{p1:Null}" Name="RegExamsRuleSet" ChainingBehavior="Full" xmlns:p1="http://schemas.microsoft.com/winfx/2006/xaml" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/workflow">
	<RuleSet.Rules>
		<Rule ReevaluationBehavior="Always" Priority="0" Description="{p1:Null}" Active="True" Name="Fees Paid">
			<Rule.ElseActions>
				<RuleStatementAction>
					<RuleStatementAction.CodeDomStatement>
						<ns0:CodeAssignStatement LinePragma="{p1:Null}" xmlns:ns0="clr-namespace:System.CodeDom;Assembly=System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
							<ns0:CodeAssignStatement.Left>
								<ns0:CodePropertyReferenceExpression PropertyName="Message">
									<ns0:CodePropertyReferenceExpression.TargetObject>
										<ns0:CodeThisReferenceExpression />
									</ns0:CodePropertyReferenceExpression.TargetObject>
								</ns0:CodePropertyReferenceExpression>
							</ns0:CodeAssignStatement.Left>
							<ns0:CodeAssignStatement.Right>
								<ns0:CodePrimitiveExpression>
									<ns0:CodePrimitiveExpression.Value>
										<ns1:String xmlns:ns1="clr-namespace:System;Assembly=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">Has not met the minimum fees requirement</ns1:String>
									</ns0:CodePrimitiveExpression.Value>
								</ns0:CodePrimitiveExpression>
							</ns0:CodeAssignStatement.Right>
						</ns0:CodeAssignStatement>
					</RuleStatementAction.CodeDomStatement>
				</RuleStatementAction>
			</Rule.ElseActions>
			<Rule.ThenActions>
				<RuleStatementAction>
					<RuleStatementAction.CodeDomStatement>
						<ns0:CodeAssignStatement LinePragma="{p1:Null}" xmlns:ns0="clr-namespace:System.CodeDom;Assembly=System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
							<ns0:CodeAssignStatement.Left>
								<ns0:CodePropertyReferenceExpression PropertyName="IsSuccess">
									<ns0:CodePropertyReferenceExpression.TargetObject>
										<ns0:CodeThisReferenceExpression />
									</ns0:CodePropertyReferenceExpression.TargetObject>
								</ns0:CodePropertyReferenceExpression>
							</ns0:CodeAssignStatement.Left>
							<ns0:CodeAssignStatement.Right>
								<ns0:CodePrimitiveExpression>
									<ns0:CodePrimitiveExpression.Value>
										<ns1:Boolean xmlns:ns1="clr-namespace:System;Assembly=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">true</ns1:Boolean>
									</ns0:CodePrimitiveExpression.Value>
								</ns0:CodePrimitiveExpression>
							</ns0:CodeAssignStatement.Right>
						</ns0:CodeAssignStatement>
					</RuleStatementAction.CodeDomStatement>
				</RuleStatementAction>
			</Rule.ThenActions>
			<Rule.Condition>
				<RuleExpressionCondition Name="{p1:Null}">
					<RuleExpressionCondition.Expression>
						<ns0:CodeBinaryOperatorExpression Operator="LessThanOrEqual" xmlns:ns0="clr-namespace:System.CodeDom;Assembly=System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
							<ns0:CodeBinaryOperatorExpression.Right>
								<ns0:CodePrimitiveExpression>
									<ns0:CodePrimitiveExpression.Value>
										<ns1:Int32 xmlns:ns1="clr-namespace:System;Assembly=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">1000</ns1:Int32>
									</ns0:CodePrimitiveExpression.Value>
								</ns0:CodePrimitiveExpression>
							</ns0:CodeBinaryOperatorExpression.Right>
							<ns0:CodeBinaryOperatorExpression.Left>
								<ns0:CodeBinaryOperatorExpression Operator="Subtract">
									<ns0:CodeBinaryOperatorExpression.Right>
										<ns0:CodePropertyReferenceExpression PropertyName="FeesPaid">
											<ns0:CodePropertyReferenceExpression.TargetObject>
												<ns0:CodeThisReferenceExpression />
											</ns0:CodePropertyReferenceExpression.TargetObject>
										</ns0:CodePropertyReferenceExpression>
									</ns0:CodeBinaryOperatorExpression.Right>
									<ns0:CodeBinaryOperatorExpression.Left>
										<ns0:CodePropertyReferenceExpression PropertyName="FeesCharged">
											<ns0:CodePropertyReferenceExpression.TargetObject>
												<ns0:CodeThisReferenceExpression />
											</ns0:CodePropertyReferenceExpression.TargetObject>
										</ns0:CodePropertyReferenceExpression>
									</ns0:CodeBinaryOperatorExpression.Left>
								</ns0:CodeBinaryOperatorExpression>
							</ns0:CodeBinaryOperatorExpression.Left>
						</ns0:CodeBinaryOperatorExpression>
					</RuleExpressionCondition.Expression>
				</RuleExpressionCondition>
			</Rule.Condition>
		</Rule>
		<Rule ReevaluationBehavior="Always" Priority="0" Description="{p1:Null}" Active="True" Name="Eligibility">
			<Rule.ElseActions>
				<RuleStatementAction>
					<RuleStatementAction.CodeDomStatement>
						<ns0:CodeAssignStatement LinePragma="{p1:Null}" xmlns:ns0="clr-namespace:System.CodeDom;Assembly=System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
							<ns0:CodeAssignStatement.Left>
								<ns0:CodePropertyReferenceExpression PropertyName="Message">
									<ns0:CodePropertyReferenceExpression.TargetObject>
										<ns0:CodeThisReferenceExpression />
									</ns0:CodePropertyReferenceExpression.TargetObject>
								</ns0:CodePropertyReferenceExpression>
							</ns0:CodeAssignStatement.Left>
							<ns0:CodeAssignStatement.Right>
								<ns0:CodePrimitiveExpression>
									<ns0:CodePrimitiveExpression.Value>
										<ns1:String xmlns:ns1="clr-namespace:System;Assembly=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">Not Eligible.  Please contact the administator to find out why you are debarred from registering exams</ns1:String>
									</ns0:CodePrimitiveExpression.Value>
								</ns0:CodePrimitiveExpression>
							</ns0:CodeAssignStatement.Right>
						</ns0:CodeAssignStatement>
					</RuleStatementAction.CodeDomStatement>
				</RuleStatementAction>
			</Rule.ElseActions>
			<Rule.ThenActions>
				<RuleStatementAction>
					<RuleStatementAction.CodeDomStatement>
						<ns0:CodeAssignStatement LinePragma="{p1:Null}" xmlns:ns0="clr-namespace:System.CodeDom;Assembly=System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
							<ns0:CodeAssignStatement.Left>
								<ns0:CodePropertyReferenceExpression PropertyName="IsSuccess">
									<ns0:CodePropertyReferenceExpression.TargetObject>
										<ns0:CodeThisReferenceExpression />
									</ns0:CodePropertyReferenceExpression.TargetObject>
								</ns0:CodePropertyReferenceExpression>
							</ns0:CodeAssignStatement.Left>
							<ns0:CodeAssignStatement.Right>
								<ns0:CodePrimitiveExpression>
									<ns0:CodePrimitiveExpression.Value>
										<ns1:Boolean xmlns:ns1="clr-namespace:System;Assembly=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">true</ns1:Boolean>
									</ns0:CodePrimitiveExpression.Value>
								</ns0:CodePrimitiveExpression>
							</ns0:CodeAssignStatement.Right>
						</ns0:CodeAssignStatement>
					</RuleStatementAction.CodeDomStatement>
				</RuleStatementAction>
			</Rule.ThenActions>
			<Rule.Condition>
				<RuleExpressionCondition Name="{p1:Null}">
					<RuleExpressionCondition.Expression>
						<ns0:CodePropertyReferenceExpression PropertyName="IsEligible" xmlns:ns0="clr-namespace:System.CodeDom;Assembly=System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
							<ns0:CodePropertyReferenceExpression.TargetObject>
								<ns0:CodeThisReferenceExpression />
							</ns0:CodePropertyReferenceExpression.TargetObject>
						</ns0:CodePropertyReferenceExpression>
					</RuleExpressionCondition.Expression>
				</RuleExpressionCondition>
			</Rule.Condition>
		</Rule>
	</RuleSet.Rules>
</RuleSet>', 0, N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\Rules\bin\Debug\Rules.dll', N'Rules.RegisterExamRules', CAST(0x0000A17501095B40 AS DateTime), NULL)
/****** Object:  Table [dbo].[Rooms]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rooms]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Capacity] [int] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[RoleRights]    Script Date: 12/16/2014 10:48:57 ******/
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
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_RoleRights] PRIMARY KEY CLUSTERED 
(
	[RoleRightId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Residences]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Residences]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Residences](
	[ResidenceId] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Cost] [money] NULL,
	[GPSCordinates] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Title] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Residences] PRIMARY KEY CLUSTERED 
(
	[ResidenceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ResidenceHalls]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResidenceHalls]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ResidenceHalls](
	[HallId] [int] IDENTITY(1,1) NOT NULL,
	[HallName] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Location] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ResidenceHalls] PRIMARY KEY CLUSTERED 
(
	[HallId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ResidenceHallRooms]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResidenceHallRooms]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ResidenceHallRooms](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[HallId] [int] NOT NULL,
	[Room] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Cost] [money] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ResidenceHallRooms] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 12/16/2014 10:48:57 ******/
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
	[IsDeleted] [bit] NULL,
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
/****** Object:  Table [dbo].[ReportGroups]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportGroups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReportGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportGroup1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ReportGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[RegisteredExams]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RegisteredExams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamId] [int] NOT NULL,
	[ExamTypeId] [int] NOT NULL,
	[RoomId] [int] NULL,
	[ExamDate] [date] NULL,
	[Invilgilator] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContributionFlag] [bit] NOT NULL,
	[Contribution] [float] NULL,
	[OutOf] [int] NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModified] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_RegisteredExams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND name = N'IX_FK_RegisteredExams_ExamPeriods')
CREATE NONCLUSTERED INDEX [IX_FK_RegisteredExams_ExamPeriods] ON [dbo].[RegisteredExams] 
(
	[ExamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND name = N'IX_RegisteredExams')
CREATE UNIQUE NONCLUSTERED INDEX [IX_RegisteredExams] ON [dbo].[RegisteredExams] 
(
	[ExamId] ASC,
	[ExamTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[ProgrammeYears]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYears]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProgrammeYears](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProgrammeId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Year] [int] NOT NULL,
	[Description] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NextYr] [int] NULL,
	[Fees] [money] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ProgrammeYears] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ProgrammeYearCourses]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYearCourses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProgrammeYearCourses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProgrammeId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProgrammeYearId] [int] NOT NULL,
	[CourseId] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Semester] [int] NOT NULL,
	[NoOfHrs] [int] NULL,
	[TuitionFees] [money] NULL,
	[ExamFees] [money] NULL,
	[ResitFees] [money] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ProgrammeCourses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYearCourses]') AND name = N'IX_FK_ProgrammeCourses_Programmes')
CREATE NONCLUSTERED INDEX [IX_FK_ProgrammeCourses_Programmes] ON [dbo].[ProgrammeYearCourses] 
(
	[ProgrammeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Programmes]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programmes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Programmes](
	[Id] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Hours] [int] NULL,
	[Fees] [money] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDefault] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Programmes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[PL_Level2]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PL_Level2]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PL_Level2](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccField] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PLCriteria] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Yr1Amount] [money] NOT NULL,
	[Yr2Amount] [money] NOT NULL,
	[ROrder] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_PL_Level2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[PL_Level1]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PL_Level1]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PL_Level1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ROrder] [int] NOT NULL,
	[PLGroup] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_PL_Level1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Parents]    Script Date: 12/16/2014 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Parents](
	[ParentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Gender] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CellPhoneNo] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Occupation] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Maritalstatus] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Relationship] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Parents] PRIMARY KEY CLUSTERED 
(
	[ParentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[MarkSheetStudents]    Script Date: 12/16/2014 10:48:57 ******/
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
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_MarkSheetStudents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[MarkSheetExams]    Script Date: 12/16/2014 10:48:56 ******/
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
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_MarkSheetExams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[MarksheetArchives]    Script Date: 12/16/2014 10:48:56 ******/
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
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_MarksheetArchives] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 12/16/2014 10:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent] [int] NOT NULL,
	[Description] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TransportCost] [money] NULL,
	[BoardingCost] [money] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[LocationProperties]    Script Date: 12/16/2014 10:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocationProperties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LocationProperties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocKey] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LocValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LocValueType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LocationId] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_LocationProperties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[GradingSystems]    Script Date: 12/16/2014 10:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GradingSystems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_GradingSystems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[GradingSystems] ON
INSERT [dbo].[GradingSystems] ([Id], [Description], [IsDeleted]) VALUES (1, N'KCSE', 0)
INSERT [dbo].[GradingSystems] ([Id], [Description], [IsDeleted]) VALUES (70, N'KCPE', 0)
SET IDENTITY_INSERT [dbo].[GradingSystems] OFF
/****** Object:  Table [dbo].[GradingSystemDets]    Script Date: 12/16/2014 10:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystemDets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GradingSystemDets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GradingSystemId] [int] NOT NULL,
	[LMark] [float] NOT NULL,
	[UMark] [float] NOT NULL,
	[Grade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Point] [float] NULL,
	[Remarks] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_GradingSystemDets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystemDets]') AND name = N'IX_FK_GradingSystemDet_GradingSystems')
CREATE NONCLUSTERED INDEX [IX_FK_GradingSystemDet_GradingSystems] ON [dbo].[GradingSystemDets] 
(
	[GradingSystemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET IDENTITY_INSERT [dbo].[GradingSystemDets] ON
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (1, 1, 0, 29, N'E         ', 1, N'Fail', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (2, 1, 30, 34, N'D-        ', 2, N'Poor', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (3, 1, 35, 39, N'D         ', 3, N'Fair', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (4, 1, 40, 44, N'D+        ', 4, N'Below Average', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (6, 1, 45, 49, N'C-        ', 5, N'Below Average', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (7, 1, 50, 54, N'C         ', 6, N'Pass', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (8, 1, 55, 59, N'C+        ', 7, N'Average', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (9, 1, 60, 64, N'B-        ', 8, N'Above Averange', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (13, 1, 65, 69, N'B         ', 9, N'Satisfactory', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (14, 1, 70, 74, N'B+        ', 10, N'Good', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (15, 1, 75, 79, N'A-        ', 11, N'Very Good', 0)
INSERT [dbo].[GradingSystemDets] ([Id], [GradingSystemId], [LMark], [UMark], [Grade], [Point], [Remarks], [IsDeleted]) VALUES (16, 1, 80, 100, N'A         ', 12, N'Excellent', 0)
SET IDENTITY_INSERT [dbo].[GradingSystemDets] OFF
/****** Object:  Table [dbo].[FeeStructureOthers]    Script Date: 12/16/2014 10:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeStructureOthers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FeeStructureOthers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeStructureId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Amount] [money] NOT NULL,
	[AmountPeriod] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ApplicableTo] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_FeeStructureOthers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[FeeStructureAcademic]    Script Date: 12/16/2014 10:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeStructureAcademic]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FeeStructureAcademic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeStructureId] [int] NOT NULL,
	[SchoolClassId] [int] NOT NULL,
	[Term] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Amount] [money] NOT NULL,
	[AmountPeriod] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_FeeStructureDet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[FeesStructure]    Script Date: 12/16/2014 10:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeesStructure]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FeesStructure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Year] [int] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_FeesStructure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 12/16/2014 10:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExamTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ROrder] [int] NULL,
	[PercentageContribution] [int] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ExamTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ExamPeriod]    Script Date: 12/16/2014 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamPeriod]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExamPeriod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[Term] [int] NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 12/16/2014 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exam]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Exam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamPeriodId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[SubjectShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Enabled] [bit] NOT NULL,
	[Closed] [bit] NOT NULL,
	[Processed] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ExamPeriods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Employers]    Script Date: 12/16/2014 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address1] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address2] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Logo] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Slogan] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AuthorizedSignatory] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Employers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/16/2014 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Surname] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OtherNames] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmpNo] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MaritalStatus] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Gender] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Photo] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DoB] [date] NULL,
	[DoE] [date] NULL,
	[CreatedOn] [date] NULL,
	[DateLeft] [date] NULL,
	[TelephoneNo] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DepartmentId] [int] NULL,
	[EmployerId] [int] NULL,
	[BasicComputation] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BasicPay] [money] NULL,
	[LeaveBalance] [money] NULL,
	[PersonalRelief] [money] NULL,
	[MortgageRelief] [money] NULL,
	[InsuranceRelief] [money] NULL,
	[NSSFNo] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NHIFNo] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IDNo] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PINNo] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PayPoint] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmpGroup] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmpSchool] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PaymentMode] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ChequeNo] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BankCode] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BankAccount] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevEmployer] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[SystemId] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Discipline]    Script Date: 12/16/2014 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Discipline]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Discipline](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[DisciplineCategoryId] [int] NOT NULL,
	[DisciplinaryDate] [date] NOT NULL,
	[Incident] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisciplineRating] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Severity] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ActionRecommended] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ActionTaken] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Review] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Discipline] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[DisciplinaryCategories]    Script Date: 12/16/2014 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DisciplinaryCategories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DisciplinaryCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_DisciplinaryCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/16/2014 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CustomerNo] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Branch] [int] NULL,
	[BillToName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToAddress] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToTelephone] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToEmail] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentId] [int] NULL,
	[DateofCreation] [datetime] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND name = N'IX_Customers')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customers] ON [dbo].[Customers] 
(
	[CustomerNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/16/2014 10:49:00 ******/
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
	[UserType] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProfileReset] [tinyint] NOT NULL,
	[IsDeleted] [bit] NULL,
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
INSERT [dbo].[Users] ([Name], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [PasswordQuestion], [PasswordAnswerHash], [PasswordAnswerSalt], [UserType], [ProfileReset], [IsDeleted]) VALUES (N'admin1', N'Fred', N'Bloggs', NULL, N'LvnDL3Iy/h2nm1FO2/rD0yrch24sKSrCZpmTv4wQc4PmILDLhgpcfqCgXWi06WyM3Mx2AY93oJzNwVqVrER/rQ==', N'I1nIRw==', N'In what city is your vacation home? (Enter full name of city)', N'teIPQA==', N'X0najw==', N'A', 1, NULL)
INSERT [dbo].[Users] ([Name], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [PasswordQuestion], [PasswordAnswerHash], [PasswordAnswerSalt], [UserType], [ProfileReset], [IsDeleted]) VALUES (N'user1', N'John', N'Doe', NULL, N'p13yuVCMCIgTy6jOf0ypzUPKWdSkYqcqYJAUwC2WGAOdk9EQD5ciEBD8s8hVPd+i36icrnH4SK+1sWLUQ5ZTpg==', N'qUCPFQ==', N'In what city is your vacation home? (Enter full name of city)', N'kqTjVA==', N'iCQYWA==', N'U', 1, NULL)
/****** Object:  Table [dbo].[UserProfile]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (43, N'kevinmk30@gmail.com')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
/****** Object:  Table [dbo].[Transport]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transport]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Transport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResidenceId] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TransactionTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DebitCredit] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TxnTypeView] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CommissionType] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FlatRate] [money] NULL,
	[PercentageRate] [float] NULL,
	[DialogFlag] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UseDefaultAmount] [bit] NULL,
	[DefaultAmount] [money] NULL,
	[UseDefaultCreditAccount] [bit] NULL,
	[DefaultCreditAccount] [int] NULL,
	[UseDefaultDebitAccount] [bit] NULL,
	[DefaultDebitAccount] [int] NULL,
	[UseDefaultCreditNarrative] [bit] NULL,
	[DefaultCreditNarrative] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UseDefaultDebitNarrative] [bit] NULL,
	[DefaultDebitNarrative] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScreenViewCreditAccountField] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScreenViewCreditNarrativeField] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScreenViewDebitAccountField] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScreenViewDebitNarrativeField] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScreenViewAmountField] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScreenViewModeofPaymentField] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScreenViewValueDateField] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrintReceipt] [bit] NULL,
	[ReceiptLayout] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrintReceiptPrompt] [bit] NULL,
	[ForcePost] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NarrativeFlag] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StatementFlag] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ValueDays] [int] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] ON
INSERT [dbo].[TransactionTypes] ([Id], [ShortCode], [Description], [DebitCredit], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [UseDefaultAmount], [DefaultAmount], [UseDefaultCreditAccount], [DefaultCreditAccount], [UseDefaultDebitAccount], [DefaultDebitAccount], [UseDefaultCreditNarrative], [DefaultCreditNarrative], [UseDefaultDebitNarrative], [DefaultDebitNarrative], [ScreenViewCreditAccountField], [ScreenViewCreditNarrativeField], [ScreenViewDebitAccountField], [ScreenViewDebitNarrativeField], [ScreenViewAmountField], [ScreenViewModeofPaymentField], [ScreenViewValueDateField], [PrintReceipt], [ReceiptLayout], [PrintReceiptPrompt], [ForcePost], [NarrativeFlag], [StatementFlag], [ValueDays], [Status], [IsDeleted]) VALUES (1, N'FP', N'Fees Posting', N'C', N'D', N'T', 6.0000, 3, N'V', 0, 80500.0000, 0, 70, 0, 55, 0, N'Fee Posted', 0, N'Fee Posted', N'V', N'V', N'V', N'V', N'V', N'V', N'V', 1, N'Date: {0} 
School Name: {1} 
Receipt Number: {3} 
Debit Account: {4} 
Credit Account: {5} 
Debit Narrative: {6} 
Credit Narrative: {7} 
Amount: {8} ', 1, N'1', N'E', N'P', 0, N'A', 0)
INSERT [dbo].[TransactionTypes] ([Id], [ShortCode], [Description], [DebitCredit], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [UseDefaultAmount], [DefaultAmount], [UseDefaultCreditAccount], [DefaultCreditAccount], [UseDefaultDebitAccount], [DefaultDebitAccount], [UseDefaultCreditNarrative], [DefaultCreditNarrative], [UseDefaultDebitNarrative], [DefaultDebitNarrative], [ScreenViewCreditAccountField], [ScreenViewCreditNarrativeField], [ScreenViewDebitAccountField], [ScreenViewDebitNarrativeField], [ScreenViewAmountField], [ScreenViewModeofPaymentField], [ScreenViewValueDateField], [PrintReceipt], [ReceiptLayout], [PrintReceiptPrompt], [ForcePost], [NarrativeFlag], [StatementFlag], [ValueDays], [Status], [IsDeleted]) VALUES (2, N'DP', N'Deposit', N'C', N'D', N'T', 1.0000, 3, N'V', 1, 90500.0000, 1, 144, 1, 143, 1, N'Deposit Transaction', 1, N'Deposit Transaction', N'V', N'V', N'V', N'V', N'V', N'V', N'V', 1, N'Date: {0} 
School Name: {1} 
Receipt Number: {3} 
Debit Account: {4} 
Credit Account: {5} 
Debit Narrative: {6} 
Credit Narrative: {7} 
Amount: {8} ', 1, N'1', N'E', N'P', 0, N'A', 0)
INSERT [dbo].[TransactionTypes] ([Id], [ShortCode], [Description], [DebitCredit], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [UseDefaultAmount], [DefaultAmount], [UseDefaultCreditAccount], [DefaultCreditAccount], [UseDefaultDebitAccount], [DefaultDebitAccount], [UseDefaultCreditNarrative], [DefaultCreditNarrative], [UseDefaultDebitNarrative], [DefaultDebitNarrative], [ScreenViewCreditAccountField], [ScreenViewCreditNarrativeField], [ScreenViewDebitAccountField], [ScreenViewDebitNarrativeField], [ScreenViewAmountField], [ScreenViewModeofPaymentField], [ScreenViewValueDateField], [PrintReceipt], [ReceiptLayout], [PrintReceiptPrompt], [ForcePost], [NarrativeFlag], [StatementFlag], [ValueDays], [Status], [IsDeleted]) VALUES (3, N'WD', N'Withdrawal', N'C', N'M', N'T', 5.0000, 3, N'V', 1, 45600.0000, 1, 85, 1, 107, 1, N'Withdrawal Sucessful', 1, N'Withdrawal Sucessful', N'V', N'V', N'V', N'V', N'V', N'V', N'V', 1, N'Date: {0} 
School Name: {1} 
Receipt Number: {3} 
Debit Account: {4} 
Credit Account: {5} 
Debit Narrative: {6} 
Credit Narrative: {7} 
Amount: {8} ', 1, N'1', N'E', N'P', 0, N'A', 0)
INSERT [dbo].[TransactionTypes] ([Id], [ShortCode], [Description], [DebitCredit], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [UseDefaultAmount], [DefaultAmount], [UseDefaultCreditAccount], [DefaultCreditAccount], [UseDefaultDebitAccount], [DefaultDebitAccount], [UseDefaultCreditNarrative], [DefaultCreditNarrative], [UseDefaultDebitNarrative], [DefaultDebitNarrative], [ScreenViewCreditAccountField], [ScreenViewCreditNarrativeField], [ScreenViewDebitAccountField], [ScreenViewDebitNarrativeField], [ScreenViewAmountField], [ScreenViewModeofPaymentField], [ScreenViewValueDateField], [PrintReceipt], [ReceiptLayout], [PrintReceiptPrompt], [ForcePost], [NarrativeFlag], [StatementFlag], [ValueDays], [Status], [IsDeleted]) VALUES (4, N'RP', N'Rent Posting', N'C', N'S', N'T', 1.0000, 5, N'V', 0, 60500.0000, 0, 84, 0, 69, 0, N'Rent Posted', 0, N'Rent Posted', N'V', N'V', N'V', N'V', N'V', N'V', N'V', 1, N'Date: {0} 
School Name: {1} 
Receipt Number: {3} 
Debit Account: {4} 
Credit Account: {5} 
Debit Narrative: {6} 
Credit Narrative: {7} 
Amount: {8} ', 1, N'1', N'E', N'P', 0, N'A', 0)
INSERT [dbo].[TransactionTypes] ([Id], [ShortCode], [Description], [DebitCredit], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [UseDefaultAmount], [DefaultAmount], [UseDefaultCreditAccount], [DefaultCreditAccount], [UseDefaultDebitAccount], [DefaultDebitAccount], [UseDefaultCreditNarrative], [DefaultCreditNarrative], [UseDefaultDebitNarrative], [DefaultDebitNarrative], [ScreenViewCreditAccountField], [ScreenViewCreditNarrativeField], [ScreenViewDebitAccountField], [ScreenViewDebitNarrativeField], [ScreenViewAmountField], [ScreenViewModeofPaymentField], [ScreenViewValueDateField], [PrintReceipt], [ReceiptLayout], [PrintReceiptPrompt], [ForcePost], [NarrativeFlag], [StatementFlag], [ValueDays], [Status], [IsDeleted]) VALUES (5, N'CF', N'Charge Fees', N'D', N'D', N'T', 6.0000, 3, N'V', 1, 8900.0000, 1, 69, 1, 86, 1, N'Fees Charged', 1, N'Fees Charged', N'V', N'V', N'V', N'V', N'V', N'V', N'V', 1, N'Date: {0} 
School Name: {1} 
Receipt Number: {3} 
Debit Account: {4} 
Credit Account: {5} 
Debit Narrative: {6} 
Credit Narrative: {7} 
Amount: {8} ', 1, N'1', N'E', N'P', 0, N'A', 0)
INSERT [dbo].[TransactionTypes] ([Id], [ShortCode], [Description], [DebitCredit], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [UseDefaultAmount], [DefaultAmount], [UseDefaultCreditAccount], [DefaultCreditAccount], [UseDefaultDebitAccount], [DefaultDebitAccount], [UseDefaultCreditNarrative], [DefaultCreditNarrative], [UseDefaultDebitNarrative], [DefaultDebitNarrative], [ScreenViewCreditAccountField], [ScreenViewCreditNarrativeField], [ScreenViewDebitAccountField], [ScreenViewDebitNarrativeField], [ScreenViewAmountField], [ScreenViewModeofPaymentField], [ScreenViewValueDateField], [PrintReceipt], [ReceiptLayout], [PrintReceiptPrompt], [ForcePost], [NarrativeFlag], [StatementFlag], [ValueDays], [Status], [IsDeleted]) VALUES (7, N'Ep', N'Expenditure Posting', N'D', N'S', N'T', 0.0000, 0, N'V', 1, 70500.0000, 1, 143, 1, 83, 1, N'Expenditure Posting', 1, N'Expenditure Posting', N'V', N'V', N'V', N'V', N'V', N'V', N'V', 1, N'Date: {0} 
School Name: {1} 
Receipt Number: {3} 
Debit Account: {4} 
Credit Account: {5} 
Debit Narrative: {6} 
Credit Narrative: {7} 
Amount: {8} ', 1, N'1', N'S', N'P', 0, N'A', 0)
INSERT [dbo].[TransactionTypes] ([Id], [ShortCode], [Description], [DebitCredit], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [UseDefaultAmount], [DefaultAmount], [UseDefaultCreditAccount], [DefaultCreditAccount], [UseDefaultDebitAccount], [DefaultDebitAccount], [UseDefaultCreditNarrative], [DefaultCreditNarrative], [UseDefaultDebitNarrative], [DefaultDebitNarrative], [ScreenViewCreditAccountField], [ScreenViewCreditNarrativeField], [ScreenViewDebitAccountField], [ScreenViewDebitNarrativeField], [ScreenViewAmountField], [ScreenViewModeofPaymentField], [ScreenViewValueDateField], [PrintReceipt], [ReceiptLayout], [PrintReceiptPrompt], [ForcePost], [NarrativeFlag], [StatementFlag], [ValueDays], [Status], [IsDeleted]) VALUES (8, N'Ip', N'Income Posting', N'D', N'M', N'T', 0.0000, 0, N'V', 1, 45700.0000, 1, 70, 1, 109, 1, N'Income Posting', 1, N'Income Posting', N'V', N'V', N'V', N'V', N'V', N'V', N'V', 1, N'Date: {0} 
School Name: {1} 
Receipt Number: {3} 
Debit Account: {4} 
Credit Account: {5} 
Debit Narrative: {6} 
Credit Narrative: {7} 
Amount: {8} ', 1, N'1', N'S', N'P', 0, N'A', 0)
SET IDENTITY_INSERT [dbo].[TransactionTypes] OFF
/****** Object:  Table [dbo].[TransactionsAuthorizations]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionsAuthorizations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TransactionsAuthorizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleId] [int] NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TransactionsAuthorizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[PostDate] [datetime] NOT NULL,
	[RecordDate] [datetime] NOT NULL,
	[ValueDate] [datetime] NULL,
	[Narrative] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StatementFlag] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Authorizer] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserName] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TransRef] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND name = N'IX_FK_Transactions_Accounts')
CREATE NONCLUSTERED INDEX [IX_FK_Transactions_Accounts] ON [dbo].[Transactions] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND name = N'IX_FK_Transactions_FK01')
CREATE NONCLUSTERED INDEX [IX_FK_Transactions_FK01] ON [dbo].[Transactions] 
(
	[TransactionTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[TimeTables]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTables]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TimeTables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassStreamId] [int] NOT NULL,
	[ClassTimeTableXML] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TimeTables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TimeTables]') AND name = N'IX_FK_TimeTable_ClassStreams')
CREATE NONCLUSTERED INDEX [IX_FK_TimeTable_ClassStreams] ON [dbo].[TimeTables] 
(
	[ClassStreamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[TimeTableDets]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTableDets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TimeTableDets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeTableId] [int] NOT NULL,
	[SubjectShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RoomId] [int] NULL,
	[Recurrent] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Activity] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Venue] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Text] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[A] [int] NOT NULL,
	[R] [int] NOT NULL,
	[G] [int] NOT NULL,
	[B] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TimeTableDets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[TechParams]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TechParams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TechParams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[strtdt] [date] NULL,
	[edc] [int] NULL,
 CONSTRAINT [PK_TechParams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[TechParams] ON
INSERT [dbo].[TechParams] ([Id], [strtdt], [edc]) VALUES (4, CAST(0xF36B0B00 AS Date), 3000000)
SET IDENTITY_INSERT [dbo].[TechParams] OFF
/****** Object:  Table [dbo].[Teachers]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teachers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IDNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TSCNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Position] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateJoined] [datetime] NULL,
	[DateLeft] [datetime] NULL,
	[IsLeft] [bit] NULL,
	[HighestQualification] [nvarchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[SubSubjects]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubSubjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SubSubjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OutOf] [int] NULL,
	[PassMark] [int] NULL,
	[GroupingFactor] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_SubSubjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SubSubjects]') AND name = N'IX_FK_SubSubjects_Subjects')
CREATE NONCLUSTERED INDEX [IX_FK_SubSubjects_Subjects] ON [dbo].[SubSubjects] 
(
	[SubjectShortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Subjects](
	[ShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OutOf] [int] NULL,
	[PassMark] [int] NULL,
	[NoOfRequiredHours] [int] NULL,
	[Fees] [money] NULL,
	[ROrder] [int] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Remarks] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[ShortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[StudentSubjectTargets]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentSubjectTargets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentSubjectTargets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[SubjectShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Target] [float] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StudentSubjectTagets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[StudentsExamResultsDetail_Temp]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail_Temp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentsExamResultsDetail_Temp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentsExamResults_TempId] [int] NULL,
	[SubjectShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mark] [float] NULL,
	[Grade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mark_Target] [float] NULL,
	[Grade_Target] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StudentsExamResultsDetail_Temp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[StudentsExamResultsDetail]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentsExamResultsDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentsExamResultsId] [int] NULL,
	[SubjectShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mark] [float] NULL,
	[Grade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mark_Target] [float] NULL,
	[Grade_Target] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StudentExamResultDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[StudentsExamResults_Temp]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResults_Temp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentsExamResults_Temp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[Examid] [int] NOT NULL,
	[SchoolClassId] [int] NOT NULL,
	[TeacherId] [int] NULL,
	[TotalMarks_Target] [float] NULL,
	[TotalPoints_Target] [float] NULL,
	[Position_Target] [int] NULL,
	[MeanMarks_Target] [float] NULL,
	[MeanGrade_Target] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TotalMarks] [float] NULL,
	[TotalPoints] [float] NULL,
	[Position] [int] NULL,
	[MeanMarks] [float] NULL,
	[MeanGrade] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HeadTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StudentsExamResults_Temp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[StudentsExamResults]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResults]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentsExamResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[Examid] [int] NOT NULL,
	[SchoolClassId] [int] NOT NULL,
	[TeacherId] [int] NULL,
	[TotalMarks_Target] [float] NULL,
	[TotalPoints_Target] [float] NULL,
	[Position_Target] [int] NULL,
	[MeanMarks_Target] [float] NULL,
	[MeanGrade_Target] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TotalMarks] [float] NULL,
	[TotalPoints] [float] NULL,
	[Position] [int] NULL,
	[MeanMarks] [float] NULL,
	[MeanGrade] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HeadTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StudentExamProgresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResults]') AND name = N'IX_FK_StudentProgresses_Students')
CREATE NONCLUSTERED INDEX [IX_FK_StudentProgresses_Students] ON [dbo].[StudentsExamResults] 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/16/2014 10:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SchoolId] [int] NOT NULL,
	[ClassStreamId] [int] NOT NULL,
	[AdminNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StudentSurName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StudentOtherNames] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Gender] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Phone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Homepage] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AdmissionType] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KCPE] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KCSE] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AdmissionDate] [datetime] NULL,
	[AdmittedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Remarks] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Photo] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModifiedTime] [datetime] NULL,
	[GLAccountId] [int] NULL,
	[CustomerId] [int] NULL,
	[FatherName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherCellPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherOfficePhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherEmail] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherCellPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherOfficePhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherEmail] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GuardianName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GuardianCellPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GuardianOfficePhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GuardianEmail] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolAddress] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReasonForLeaving] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricular1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricular2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricular3] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term1MeanGrade] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term2MeanGrade] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term3MeanGrade] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Eligible] [bit] NULL,
	[RequireTransport] [bit] NULL,
	[TransportChargeType] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FeesPayPlan] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Boarder] [bit] NULL,
	[ResidenceHallRoomId] [int] NULL,
	[ResidenceId] [int] NULL,
	[DoctorName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Ailments] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Foods] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Allergies] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HostelName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BedNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[StudentProgresses_Temp]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses_Temp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentProgresses_Temp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[SchoolClassId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Term] [int] NOT NULL,
	[ClassShortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SubjectShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TeacherId] [int] NULL,
	[TotalMarks] [float] NULL,
	[TotalPoints] [float] NULL,
	[Position] [int] NULL,
	[MeanMarks] [float] NULL,
	[MeanGrade] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HeadTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StudentProgresses_Temp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[COA]    Script Date: 12/16/2014 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[COALevel] [int] NOT NULL,
	[Parent] [int] NOT NULL,
	[Rorder] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[COA] ON
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (3, N'ASSET     ', N'ASSET', 1, 0, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (4, N'LIAB      ', N'LIABILITIES', 1, 0, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (6, N'INCOME    ', N'INCOME', 1, 0, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (7, N'EXP       ', N'EXPENSES', 1, 0, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (8, N'CAPITAL   ', N'CAPITAL', 1, 0, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (9, N'FA        ', N'FIXED ASSET', 2, 3, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (10, N'CA        ', N'CURRET ASSET', 2, 3, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (13, N'LTL       ', N'Long Term Liabilities', 2, 4, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (15, N'STL       ', N'Short Term Liabilities', 2, 4, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (16, N'MV        ', N'Motor Vehicle', 3, 9, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (19, N'OE        ', N'Office Equipment', 3, 9, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (20, N'CASH      ', N'Petty Cash', 3, 10, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (21, N'Bank      ', N'Bank Accounts', 3, 10, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (22, N'EQ        ', N'Equity Accounts', 4, 21, 4, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (23, N'ST        ', N'Standard A/C 1', 4, 21, 4, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (24, N'CSH       ', N'Bursar 1', 4, 20, 4, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (25, N'LN        ', N'Equity Loan', 3, 13, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (26, N'AP        ', N'Account Payable', 3, 15, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (27, N'Stfe      ', N'Student Fees', 3, 10, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (28, N'EL        ', N'Electricity', 4, 26, 4, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (29, N'WT        ', N'Water', 4, 26, 4, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (30, N'INP       ', N'Interest Payable', 4, 26, 4, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (31, N'UN        ', N'Unga Supplier', 4, 26, 4, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (32, N'Fees      ', N'Fees Income', 1, 6, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (33, N'TU        ', N'Tuition Fees', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (34, N'LB        ', N'Library Fees', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (35, N'TR        ', N'Transport Fees', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (36, N'BF        ', N'Boarding Fees', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (37, N'OI        ', N'Other Income', 2, 6, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (39, N'AE        ', N'Administrative Expenses', 2, 7, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (40, N'FE        ', N'Financial Expenses', 2, 7, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (41, N'ME        ', N'Marketing Expenses', 2, 7, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (42, N'ACE       ', N'Academic Expenses', 2, 7, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (43, N'OE        ', N'Owners Equity', 2, 8, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (44, N'RE        ', N'Retained Earnings', 2, 8, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (46, N'OF        ', N'Other Fees', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (53, N'OD        ', N'Other Debtors', 3, 10, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (54, N'OL        ', N'Other Liabilities', 3, 15, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (55, N'Labfee    ', N'Laboratory Fees', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (56, N'Sempfund  ', N'School Employee Fund', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (57, N'Renov     ', N'Renovation', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (58, N'Schprojs  ', N'School Projects', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (59, N'Cocuractfu', N'Co- Curriculum Activity Fund', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (60, N'Maintfees ', N'Maintenance Fees', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (61, N'Adminfees ', N'Admission Fee', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (62, N'Extrtution', N'Extra Tuition', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (63, N'Smase     ', N'Smasse', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (64, N'Foreignstd', N'Foreign Student Equation Fees', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (65, N'Unireg    ', N'University Registration', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (66, N'Passport  ', N'Passport Size Photo/ School Id', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (67, N'Medical   ', N'Medical Fee', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (68, N'dinningute', N'Dinning Utensils', 3, 32, 1, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (69, N'Schlunifor', N'School Uniform', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (70, N'Pe        ', N'Personal Effects', 3, 32, 3, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (71, N'Kcb Acc   ', N'Kcb A/C 1', 4, 21, 4, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (72, N'Exam      ', N'Examination Fees', 2, 32, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (73, N'Caution   ', N'Caution Money', 2, 32, 2, NULL)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder], [IsDeleted]) VALUES (74, N'App       ', N'Application Fees', 2, 32, 2, NULL)
SET IDENTITY_INSERT [dbo].[COA] OFF
/****** Object:  Table [dbo].[ClassSubjects]    Script Date: 12/16/2014 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassSubjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[SubjectCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SubjectTeacherId] [int] NULL,
	[Room] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ClassSubjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND name = N'IX_FK_ClassSubjects_SchoolClasses')
CREATE NONCLUSTERED INDEX [IX_FK_ClassSubjects_SchoolClasses] ON [dbo].[ClassSubjects] 
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
/****** Object:  Table [dbo].[ClassStreams]    Script Date: 12/16/2014 10:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassStreams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassStreams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ClassStreams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[BS_Level2]    Script Date: 12/16/2014 10:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BS_Level2]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BS_Level2](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccField] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BSCriteria] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Yr1Amount] [money] NOT NULL,
	[Yr2Amount] [money] NOT NULL,
	[ROrder] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_BS_Level2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[BS_Level1]    Script Date: 12/16/2014 10:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BS_Level1]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BS_Level1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BSGroup] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ROrder] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_BS_Level1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 12/16/2014 10:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Banks](
	[BankCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BankName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED 
(
	[BankCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'01', N'Kenya Commercial Bank Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'02', N'Standard Chartered Bank', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'03', N'Barclays Bank of Kenya Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'05', N'Bank of India', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'06', N'Bank of Baroda (Kenya) Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'07', N'Commercial Bank of Africa Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'08', N'Habib Bank Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'09', N'Central Bank of Kenya', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'10', N'Prime Bank Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'11', N'Co-operative Bank Of Kenya', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'12', N'National Bank of Kenya', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'14', N'Oriental Commercial Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'16', N'Citi Bank', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'17', N'Habib Bank', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'18', N'Middle East Bank', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'19', N'Bank of Africa Kenya Ltd.', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'20', N' Dubai Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'23', N'Consolidated Bank of Kenya', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'25', N' Credit Bank Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'26', N'Trans-National Bank Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'30', N'Chase Bank', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'31', N'Cfc Stanbic Bank ', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'35', N' African BankingCorporation Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'39', N'Imperial Bank Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'41', N'NIC Bank Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'42', N' Giro Commercial', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'43', N'Ecobank Kenya Limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'49', N'Equatorial Commercial Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'50', N'Paramount Universal Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'51', N'Jamii Bora Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'53', N'Fina Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'54', N'Victoria Commercial Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'55', N'Guardian Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'57', N'I & M Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'59', N'Development Bank of Kenya Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'60', N'Fidelity Commercial Bank Ltd.', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'63', N'Diamond Trust Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'66', N'K-Rep Bank limited', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'68', N'Equity Bank ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'70', N'Family Bank ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'72', N'Gulf African Bank', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'74', N'First Community Bank Ltd', 0)
INSERT [dbo].[Banks] ([BankCode], [BankName], [IsDeleted]) VALUES (N'76', N'UBA Kenya Bank', 0)
/****** Object:  Table [dbo].[BankBranches]    Script Date: 12/16/2014 10:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankBranches]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BankBranches](
	[BankSortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BranchCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BankCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BranchName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_BankBranch] PRIMARY KEY CLUSTERED 
(
	[BankSortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01095', N'095', N'01', N'Wote', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01100', N'100', N'01', N'Moi Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01102', N'102', N'01', N'Treasury Square', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01103', N'103', N'01', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01104', N'104', N'01', N'KICC', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01105', N'105', N'01', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01106', N'106', N'01', N'Kericho', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01107', N'107', N'01', N'Tom Mboya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01108', N'108', N'01', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01109', N'109', N'01', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01110', N'110', N'01', N'Kakamega', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01111', N'111', N'01', N'Kilindini', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01113', N'113', N'01', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01114', N'114', N'01', N'River Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01115', N'115', N'01', N'Muranga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01116', N'116', N'01', N'Embu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01117', N'117', N'01', N'Kangema', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01119', N'119', N'01', N'Kiambu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01120', N'120', N'01', N'Karatina', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01121', N'121', N'01', N'Siaya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01122', N'122', N'01', N'Nyahururu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01123', N'123', N'01', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01124', N'124', N'01', N'Mumias', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01125', N'125', N'01', N'Nanyuki', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01127', N'127', N'01', N'Moyale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01129', N'129', N'01', N'Kikuyu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01130', N'130', N'01', N'Tala', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01131', N'131', N'01', N'Kajiado', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01133', N'133', N'01', N'Custody Services', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01134', N'134', N'01', N'Matuu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01135', N'135', N'01', N'Kitui', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01136', N'136', N'01', N'Mvita', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01137', N'137', N'01', N'Jogoo Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01140', N'140', N'01', N'Marsabit', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01141', N'141', N'01', N'Sarit Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01142', N'142', N'01', N'Loitokitok', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01143', N'143', N'01', N'Nandi Hills', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01144', N'144', N'01', N'Lodwar', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01145', N'145', N'01', N'UN Gigiri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01146', N'146', N'01', N'Hola', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01147', N'147', N'01', N'Ruiru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01148', N'148', N'01', N'Mwingi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01149', N'149', N'01', N'Kitale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01150', N'150', N'01', N'Mandera', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01151', N'151', N'01', N'Kapenguria', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01152', N'152', N'01', N'Kabarnet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01153', N'153', N'01', N'Wajir', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01154', N'154', N'01', N'Maralal', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01155', N'155', N'01', N'Limuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01157', N'157', N'01', N'Ukunda', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01161', N'161', N'01', N'Ongata Rongai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01162', N'162', N'01', N'Kitengela', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01163', N'163', N'01', N'Eldama Ravine', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01164', N'164', N'01', N'Kibwezi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01166', N'166', N'01', N'Kapsabet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01167', N'167', N'01', N'University Way', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01168', N'168', N'01', N'Eldoret West', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01169', N'169', N'01', N'Garissa ', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01173', N'173', N'01', N'Lamu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01174', N'174', N'01', N'Kilifi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01175', N'175', N'01', N'Milimani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01176', N'176', N'01', N'Nyamira', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01177', N'177', N'01', N'Mukurwe-ini', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01180', N'180', N'01', N'Village Market', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01181', N'181', N'01', N'Bomet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01183', N'183', N'01', N'Mbale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01184', N'184', N'01', N'Narok', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01185', N'158', N'01', N'Iten', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01186', N'186', N'01', N'Voi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01188', N'188', N'01', N'Webuye', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01189', N'159', N'01', N'Gilgil', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01190', N'190', N'01', N'Naivasha', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01191', N'191', N'01', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01192', N'192', N'01', N'Migori', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01193', N'193', N'01', N'Githunguri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01194', N'194', N'01', N'Machakos', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01195', N'195', N'01', N'Kerugoya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01196', N'196', N'01', N'Chuka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01197', N'197', N'01', N'Bungoma', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01198', N'198', N'01', N'Wundanyi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01199', N'199', N'01', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01201', N'201', N'01', N'Capital Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01202', N'202', N'01', N'Karen', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01203', N'203', N'01', N'Lokichogio', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01204', N'204', N'01', N'Gateway', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01205', N'205', N'01', N'Buruburu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01206', N'206', N'01', N'Chogoria', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01207', N'207', N'01', N'Kangari', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01208', N'208', N'01', N'Kianyaga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01209', N'209', N'01', N'Nkubu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01210', N'210', N'01', N'Ol Kalou', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01211', N'211', N'01', N'Makuyu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01212', N'212', N'01', N'Mwea', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01213', N'213', N'01', N'Njabini', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01214', N'214', N'01', N'Gatundu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01215', N'215', N'01', N'Emali', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01216', N'216', N'01', N'Isiolo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01217', N'217', N'01', N'Flamingo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01218', N'218', N'01', N'Njoro', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01219', N'219', N'01', N'Mutomo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01220', N'220', N'01', N'Mariakani', 0)
GO
print 'Processed 100 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01221', N'221', N'01', N'Mpeketoni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01222', N'222', N'01', N'Mtito Andei', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01223', N'223', N'01', N'Mtwapa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01224', N'224', N'01', N'Taveta', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01225', N'225', N'01', N'Kengeleni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01226', N'226', N'01', N'Garsen', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01227', N'227', N'01', N'Watamu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01228', N'228', N'01', N'Bondo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01229', N'229', N'01', N'Busia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01230', N'230', N'01', N'Homa Bay', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01231', N'231', N'01', N'Kapsowar', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01232', N'232', N'01', N'Kehancha', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01233', N'233', N'01', N'Keroka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01234', N'234', N'01', N'Kilgoris', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01235', N'235', N'01', N'Kimilili', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01236', N'236', N'01', N'Litein', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01237', N'237', N'01', N'Londiani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01238', N'238', N'01', N'Luanda', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01239', N'239', N'01', N'Malaba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01240', N'240', N'01', N'Muhoroni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01241', N'241', N'01', N'Oyugis', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01242', N'242', N'01', N'Ugunja', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01243', N'243', N'01', N'United Mall', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01244', N'244', N'01', N'Serem', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01245', N'245', N'01', N'Sondu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01246', N'246', N'01', N'Kisumu West', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01247', N'247', N'01', N'Marigat', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01248', N'248', N'01', N'Moi''s Bridge', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01249', N'249', N'01', N'Mashariki', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01250', N'250', N'01', N'Naro Moru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01251', N'251', N'01', N'Kiriaini', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01252', N'252', N'01', N'Egerton University', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01253', N'253', N'01', N'Maua', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01254', N'254', N'01', N'Kawangware', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01255', N'255', N'01', N'Kimathi Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01256', N'256', N'01', N'Namanga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01257', N'257', N'01', N'Gikomba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01258', N'258', N'01', N'Kwale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01259', N'259', N'01', N'Prestige Plaza', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01260', N'260', N'01', N'Kariobangi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01263', N'263', N'01', N'Biashara Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01266', N'266', N'01', N'Ngara', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01267', N'267', N'01', N'Kyuso', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01270', N'270', N'01', N'Masii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01271', N'271', N'01', N'Menengai Crater', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01272', N'272', N'01', N'Town Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01278', N'278', N'01', N'Makindu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01283', N'283', N'01', N'Rongo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01284', N'284', N'01', N'Isibania', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01285', N'285', N'01', N'Kiserian', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01286', N'286', N'01', N'Mwembe Tayari', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01287', N'287', N'01', N'Kisauni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01288', N'288', N'01', N'Haile Selassie', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01289', N'289', N'01', N'Mama Ngina', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01290', N'290', N'01', N'Garden Plaza', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01291', N'291', N'01', N'Sarit Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01292', N'292', N'01', N'CPC Bulk Corporate Chqs', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'01293', N'293', N'01', N'Trade Services', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02000', N'000', N'02', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02001', N'001', N'02', N'Kericho', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02002', N'002', N'02', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02003', N'003', N'02', N'Kitale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02004', N'004', N'02', N'Treasury Square', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02005', N'005', N'02', N'Maritime', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02006', N'006', N'02', N'Kenyatta', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02007', N'007', N'02', N'Kimathi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02008', N'008', N'02', N'Moi Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02009', N'009', N'02', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02010', N'010', N'02', N'Nanyuki', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02011', N'011', N'02', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02012', N'012', N'02', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02015', N'015', N'02', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02016', N'016', N'02', N'Machakos', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02017', N'017', N'02', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02019', N'019', N'02', N'Harambee', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02020', N'020', N'02', N'Kiambu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02053', N'053', N'02', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02054', N'054', N'02', N'Kakamega', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02060', N'060', N'02', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02063', N'063', N'02', N'Haile Selassie', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02064', N'064', N'02', N'Koinange Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02071', N'071', N'02', N'Yaya Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02072', N'072', N'02', N'Ruaraka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02074', N'074', N'02', N'Langata', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02075', N'075', N'02', N'Makupa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02076', N'076', N'02', N'Karen', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02077', N'077', N'02', N'Muthaiga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02078', N'078', N'02', N'Customer Service Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02079', N'079', N'02', N'Customer Service Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02080', N'080', N'02', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02081', N'081', N'02', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02082', N'082', N'02', N'Uper Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02083', N'083', N'02', N'Mombasa-Nyali', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'02084', N'084', N'02', N'Chiromo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03002', N'002', N'03', N'Kapsabet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03003', N'003', N'03', N'Eldoret Std & Prestige', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03004', N'004', N'03', N'Embu Std & Prestige', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03005', N'005', N'03', N'Murang''a', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03006', N'006', N'03', N'Kapenguria', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03007', N'007', N'03', N'Kericho', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03008', N'008', N'03', N'Kisii', 0)
GO
print 'Processed 200 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03009', N'009', N'03', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03010', N'010', N'03', N'South C', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03011', N'011', N'03', N'Limuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03012', N'012', N'03', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03013', N'013', N'03', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03014', N'014', N'03', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03015', N'015', N'03', N'Kitui', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03016', N'016', N'03', N'Nkrumah Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03017', N'017', N'03', N'Garissa ', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03018', N'018', N'03', N'Nyamira', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03019', N'019', N'03', N'Kilifi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03020', N'020', N'03', N'Waiyaki Way', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03023', N'023', N'03', N'Gilgil', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03024', N'024', N'03', N'Githurai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03027', N'027', N'03', N'Nakuru East', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03028', N'028', N'03', N'Buruburu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03029', N'029', N'03', N'Bomet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03030', N'030', N'03', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03031', N'031', N'03', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03032', N'032', N'03', N'Port Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03033', N'033', N'03', N'Gikomba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03034', N'034', N'03', N'Kawangware', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03035', N'035', N'03', N'Mbale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03036', N'036', N'03', N'Plaza Premier Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03037', N'037', N'03', N'River Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03038', N'038', N'03', N'Upper River Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03039', N'039', N'03', N'Mumias', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03040', N'040', N'03', N'Machakos', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03042', N'042', N'03', N'Isiolo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03043', N'043', N'03', N'Ngong', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03044', N'044', N'03', N'Maua', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03045', N'045', N'03', N'Hurlingham', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03046', N'046', N'03', N'Makupa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03047', N'047', N'03', N'Development Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03049', N'049', N'03', N'Lavington', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03050', N'050', N'03', N'Eastleigh II', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03051', N'051', N'03', N'Homa Bay', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03052', N'052', N'03', N'Rongai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03053', N'053', N'03', N'Othaya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03054', N'054', N'03', N'Voi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03055', N'055', N'03', N'Muthaiga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03057', N'057', N'03', N'Githunguri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03058', N'058', N'03', N'Webuye', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03060', N'060', N'03', N'Chuka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03061', N'061', N'03', N'Nakumatt Westgate', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03062', N'062', N'03', N'Kabarnet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03063', N'063', N'03', N'Kerugoya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03064', N'064', N'03', N'Taveta', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03065', N'065', N'03', N'Karen Std&Prestige', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03066', N'066', N'03', N'Wundanyi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03067', N'067', N'03', N'Ruaraka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03069', N'069', N'03', N'Wote', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03070', N'070', N'03', N'Enterprise prestige centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03071', N'071', N'03', N'Nakumatt Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03072', N'072', N'03', N'Juja', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03073', N'073', N'03', N'ABC Prestige', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03074', N'074', N'03', N'Kikuyu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03075', N'075', N'03', N'Moi Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03077', N'077', N'03', N'Plaza Business Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03078', N'078', N'03', N'Kiriaini', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03079', N'079', N'03', N'Avon Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03080', N'080', N'03', N'Migori', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03082', N'082', N'03', N'Haile Selassie', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03083', N'083', N'03', N'University of Nairobi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03086', N'086', N'03', N'Nairobi west', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03087', N'087', N'03', N'Parkland Highbridge', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03088', N'088', N'03', N'Busia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03089', N'089', N'03', N'Pangani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03093', N'093', N'03', N'Kariobangi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03094', N'094', N'03', N'QueensWay', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'03095', N'095', N'03', N'Nakumatt Ebakasi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'05000', N'000', N'05', N'Nairobi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'05001', N'001', N'05', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'05002', N'002', N'05', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'05003', N'003', N'05', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'06000', N'000', N'06', N'Nairobi Main', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'06002', N'002', N'06', N'Digo rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'06004', N'004', N'06', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'06005', N'005', N'06', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'06006', N'006', N'06', N'Sarit Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'06007', N'007', N'06', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'06008', N'008', N'06', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'06009', N'009', N'06', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07000', N'000', N'07', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07001', N'001', N'07', N'Upper Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07002', N'002', N'07', N'Wabera', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07003', N'003', N'07', N'Mama Ngina Br/Hilton Agency', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07004', N'004', N'07', N'Westlands Br/ILRI Agency', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07005', N'005', N'07', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07006', N'006', N'07', N'Mamlaka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07007', N'007', N'07', N'Village Mkt Br/US Emb/Icraf Ag', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07008', N'008', N'07', N'Cargo Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07009', N'009', N'07', N'Park Side', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07016', N'016', N'07', N'Galleria', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07017', N'017', N'07', N'Junction', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07020', N'020', N'07', N'Moi Avenue Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07021', N'021', N'07', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07022', N'022', N'07', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07023', N'023', N'07', N'Bamburi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07024', N'024', N'07', N'Diani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07025', N'025', N'07', N'Changamwe', 0)
GO
print 'Processed 300 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07026', N'026', N'07', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'07027', N'027', N'07', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'08046', N'046', N'08', N'Mobasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'08047', N'047', N'08', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'08048', N'048', N'08', N'Nairobi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'09000', N'000', N'09', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'09001', N'001', N'09', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'09002', N'002', N'09', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'09003', N'003', N'09', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'09004', N'004', N'09', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10000', N'000', N'10', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10001', N'001', N'10', N'Kenindia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10002', N'002', N'10', N'Biashara', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10003', N'003', N'10', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10004', N'004', N'10', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10005', N'005', N'10', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10006', N'006', N'10', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10007', N'007', N'10', N'Parklands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10008', N'008', N'10', N'Riverside Drive', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10009', N'009', N'10', N'Card centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10010', N'010', N'10', N'Hurlingham', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10011', N'011', N'10', N'Capital Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10012', N'012', N'10', N'Nyali', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10014', N'014', N'10', N'Kamukunji', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'10015', N'015', N'10', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11000', N'000', N'11', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11002', N'002', N'11', N'Co-op Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11003', N'003', N'11', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11004', N'004', N'11', N'Nkrumah Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11005', N'005', N'11', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11006', N'006', N'11', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11007', N'007', N'11', N'Industrial Are', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11008', N'008', N'11', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11009', N'009', N'11', N'Machakos', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11010', N'010', N'11', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11011', N'011', N'11', N'Ukulima', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11012', N'012', N'11', N'Chuka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11013', N'013', N'11', N'Wakulima Market', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11014', N'014', N'11', N'Moi Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11015', N'015', N'11', N'Naivasha', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11017', N'017', N'11', N'Nyahururu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11018', N'018', N'11', N'Chuka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11019', N'019', N'11', N'Wakulima Market', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11020', N'020', N'11', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11021', N'021', N'11', N'Kiambu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11022', N'022', N'11', N'Homabay', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11023', N'023', N'11', N'Embu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11024', N'024', N'11', N'Kericho', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11025', N'025', N'11', N'Bungoma', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11026', N'026', N'11', N'Muranga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11027', N'027', N'11', N'Kayole', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11028', N'028', N'11', N'Karatina', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11029', N'029', N'11', N'Ukunda', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11030', N'030', N'11', N'Mtwapa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11031', N'031', N'11', N'University way', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11032', N'032', N'11', N'BuruBuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11033', N'033', N'11', N'AthiRiver', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11034', N'034', N'11', N'Mumias', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11035', N'035', N'11', N'Stima Plaza', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11036', N'036', N'11', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11037', N'037', N'11', N'Upper Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11038', N'038', N'11', N'Ongata Rongai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11039', N'039', N'11', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11040', N'040', N'11', N'Nacico Plaza', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11041', N'041', N'11', N'Kariobangi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11042', N'042', N'11', N'Kawangware', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11043', N'043', N'11', N'Makutano', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11044', N'044', N'11', N'Parliament Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11045', N'045', N'11', N'Kimathi Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11046', N'046', N'11', N'Kitale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11047', N'047', N'11', N'Githurai Agency', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11048', N'048', N'11', N'Maua', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11049', N'049', N'11', N'City Hall', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11050', N'050', N'11', N'Digo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11051', N'051', N'11', N'Nairobi Business Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11052', N'052', N'11', N'Kakamega', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11053', N'053', N'11', N'Migori', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11055', N'055', N'11', N'Nkubu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11056', N'056', N'11', N'Enterprise Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11057', N'057', N'11', N'Busia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11058', N'058', N'11', N'Siaya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11059', N'059', N'11', N'Voi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11060', N'060', N'11', N'Mariakani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11061', N'061', N'11', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11062', N'062', N'11', N'Zimmerman', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11063', N'063', N'11', N'Nakuru East', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11064', N'064', N'11', N'Kitengela', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11065', N'065', N'11', N'Aga Khan Walk', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11066', N'066', N'11', N'Narok', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11067', N'067', N'11', N'Kitui', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11068', N'068', N'11', N'Nanyuki', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11069', N'069', N'11', N'Embakasi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11070', N'070', N'11', N'Kibera', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11071', N'071', N'11', N'Siakago', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11072', N'072', N'11', N'Kapsabet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11073', N'073', N'11', N'Mbita', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11074', N'074', N'11', N'Kangemi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11075', N'075', N'11', N'Dandora', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11077', N'077', N'11', N'Tala', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11078', N'078', N'11', N'Gikomba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11079', N'079', N'11', N'River Road', 0)
GO
print 'Processed 400 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11080', N'080', N'11', N'Nyamira', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11081', N'081', N'11', N'Garissa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11082', N'082', N'11', N'Bomet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11083', N'083', N'11', N'Keroka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11084', N'084', N'11', N'Gilgil', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11085', N'085', N'11', N'Tom Mboya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11086', N'086', N'11', N'Likoni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11088', N'088', N'11', N'Mwingi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11089', N'089', N'11', N'Mwingi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11090', N'090', N'11', N'Webuye', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11100', N'100', N'11', N'Ndhiwa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'11102', N'102', N'11', N'Isiolo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12002', N'002', N'12', N'Kenyatta Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12003', N'003', N'12', N'Harambee Avenue NBK  Building', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12004', N'004', N'12', N'Hill Plaza', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12005', N'005', N'12', N'Busia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12006', N'006', N'12', N'Kiambu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12007', N'007', N'12', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12008', N'008', N'12', N'Karatina', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12009', N'009', N'12', N'Narok', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12010', N'010', N'12', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12011', N'011', N'12', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12012', N'012', N'12', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12013', N'013', N'12', N'Kitale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12015', N'015', N'12', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12016', N'016', N'12', N'Limuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12017', N'017', N'12', N'Kitui', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12019', N'019', N'12', N'Bungoma', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12020', N'020', N'12', N'Nkurumah Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12021', N'021', N'12', N'Kapsabet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12022', N'022', N'12', N'Awendo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12023', N'023', N'12', N'Portway Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12025', N'025', N'12', N'Hospital', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12026', N'026', N'12', N'Ruiru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12027', N'027', N'12', N'Ongata Rongai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12028', N'028', N'12', N'Embu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12029', N'029', N'12', N'Kakamega', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12031', N'031', N'12', N'Ukunda', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12032', N'032', N'12', N'Upper Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12033', N'033', N'12', N'Nandi Hills', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12034', N'034', N'12', N'Migori', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12035', N'035', N'12', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12036', N'036', N'12', N'Times Tower', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12037', N'037', N'12', N'Maua', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12038', N'038', N'12', N'Wilson Airport', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12039', N'039', N'12', N'J.K.I.A.', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12040', N'040', N'12', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12042', N'042', N'12', N'Mutomo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12043', N'043', N'12', N'Kianjai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12044', N'044', N'12', N'Kenyatta University', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12045', N'045', N'12', N'St. Paul''s University', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12046', N'046', N'12', N'Moi University', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12047', N'047', N'12', N'Moi International Airport, Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12050', N'050', N'12', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'12099', N'099', N'12', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'14000', N'000', N'14', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'14004', N'004', N'14', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'14005', N'005', N'14', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'14006', N'006', N'14', N'Kitale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'14007', N'007', N'14', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'16000', N'000', N'16', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'16400', N'400', N'16', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'17000', N'000', N'17', N'Main Branch', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'17001', N'001', N'17', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'17002', N'002', N'17', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'18000', N'000', N'18', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'18002', N'002', N'18', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'18003', N'003', N'18', N'Milimani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'18004', N'004', N'18', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19000', N'000', N'19', N'Nairobi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19001', N'001', N'19', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19002', N'002', N'19', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19003', N'003', N'19', N'Uhuru Highway', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19004', N'004', N'19', N'River Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19006', N'006', N'19', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19007', N'007', N'19', N'Ruaraka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19008', N'008', N'19', N'Monrovia Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19009', N'009', N'19', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19010', N'010', N'19', N'Ngong Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19011', N'011', N'19', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19012', N'012', N'19', N'Embakasi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19013', N'013', N'19', N'Kericho', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19014', N'014', N'19', N'Changamwe', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19015', N'015', N'19', N'Bungoma', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19017', N'017', N'19', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'19018', N'018', N'19', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'20001', N'001', N'20', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'20002', N'002', N'20', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'20003', N'003', N'20', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'20004', N'004', N'20', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23000', N'000', N'23', N'Harambee Avenue Harambee Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23001', N'001', N'23', N'Murang''a', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23002', N'002', N'23', N'Embu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23003', N'003', N'23', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23004', N'004', N'23', N'Koinange Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23005', N'005', N'23', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23006', N'006', N'23', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23007', N'007', N'23', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23009', N'009', N'23', N'Maua', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23010', N'010', N'23', N'Isiolo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23011', N'011', N'23', N'Head Office', 0)
GO
print 'Processed 500 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23013', N'013', N'23', N'Umoja', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23014', N'014', N'23', N'River Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23015', N'015', N'23', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'23016', N'016', N'23', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'25000', N'000', N'25', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'25001', N'001', N'25', N'Koinange Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'25002', N'002', N'25', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'25003', N'003', N'25', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'25004', N'004', N'25', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'25005', N'005', N'25', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'25006', N'006', N'25', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26001', N'001', N'26', N'Nairobi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26002', N'002', N'26', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26003', N'003', N'26', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26005', N'005', N'26', N'MIA', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26006', N'006', N'26', N'JKIA', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26007', N'007', N'26', N'Kirinyaga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26008', N'008', N'26', N'Kabarak', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26009', N'009', N'26', N'Olenguruone', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26010', N'010', N'26', N'Kericho', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26011', N'011', N'26', N'Nandi Hills', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26012', N'012', N'26', N'EPZ', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26013', N'013', N'26', N'Sheikh Karume', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'26014', N'014', N'26', N'Kabarnet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30000', N'000', N'30', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30001', N'001', N'30', N'City Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30003', N'003', N'30', N'Village Market', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30004', N'004', N'30', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30005', N'005', N'30', N'Hurlingham', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30006', N'006', N'30', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30007', N'007', N'30', N'Parklands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30008', N'008', N'30', N'Riverside Mews', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30009', N'009', N'30', N'Iman Banking Centre Riverside Mews', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30010', N'010', N'30', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30011', N'011', N'30', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30012', N'012', N'30', N'Donholm', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30014', N'014', N'30', N'Ngara Mini Branch Peace Towers', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30015', N'015', N'30', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'30016', N'016', N'30', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31000', N'000', N'31', N'Clearing Centre,Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31002', N'002', N'31', N'Kenyatta Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31003', N'003', N'31', N'Digo Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31004', N'004', N'31', N'Waiyaki Way', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31005', N'005', N'31', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31006', N'006', N'31', N'Harambee Avenue Nairobi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31007', N'007', N'31', N'Chiromo Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31008', N'008', N'31', N'International House', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31009', N'009', N'31', N'Nkrumah', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31010', N'010', N'31', N'Upper Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31011', N'011', N'31', N'Naivasha', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31012', N'012', N'31', N'Westgate', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31013', N'013', N'31', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31014', N'014', N'31', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31015', N'015', N'31', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31016', N'016', N'31', N'Nyerere', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31017', N'017', N'31', N'Nanyuki', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31018', N'018', N'31', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31020', N'020', N'31', N'Gikomba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31021', N'021', N'31', N'Ruaraka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31022', N'022', N'31', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31023', N'023', N'31', N'Karen', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31024', N'024', N'31', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'31999', N'999', N'31', N'Central Processing CfC Centre,HeadOffice', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'35000', N'000', N'35', N'Koinange Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'35001', N'001', N'35', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'35002', N'002', N'35', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'35004', N'004', N'35', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'35005', N'005', N'35', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'35006', N'006', N'35', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'35007', N'007', N'35', N'Libra House', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'35008', N'008', N'35', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39001', N'001', N'39', N'IPS', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39002', N'002', N'39', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39003', N'003', N'39', N'Upper Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39004', N'004', N'39', N'Parklands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39006', N'006', N'39', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39007', N'007', N'39', N'Watamu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39008', N'008', N'39', N'Diani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39009', N'009', N'39', N'Kilifi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39010', N'010', N'39', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39011', N'011', N'39', N'Karen', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39012', N'012', N'39', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39014', N'014', N'39', N'Changamwe', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39015', N'015', N'39', N'Riverside', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39016', N'016', N'39', N'Likoni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'39018', N'018', N'39', N'Village Market', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41000', N'000', N'41', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41101', N'101', N'41', N'City Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41102', N'102', N'41', N'NIC Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41103', N'103', N'41', N'Harbor Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41105', N'105', N'41', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41106', N'106', N'41', N'Junction', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41107', N'107', N'41', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41108', N'108', N'41', N'Nyali', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41109', N'109', N'41', N'Nkurumah Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41111', N'111', N'41', N'Prestige', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41112', N'112', N'41', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41113', N'113', N'41', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41114', N'114', N'41', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41115', N'115', N'41', N'Galleria (Bomas)', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41116', N'116', N'41', N'Eldoret', 0)
GO
print 'Processed 600 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41117', N'117', N'41', N'Village Market', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'41118', N'118', N'41', N'Mombasa Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'42001', N'001', N'42', N'Banda Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'42004', N'004', N'42', N'Kimathi Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'42005', N'005', N'42', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'42006', N'006', N'42', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'42007', N'007', N'42', N'Parklands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43000', N'000', N'43', N'Ecobank Towers', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43002', N'002', N'43', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43003', N'003', N'43', N'Plaza 2000', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43004', N'004', N'43', N'Westminister', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43005', N'005', N'43', N'Chambers', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43007', N'007', N'43', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43008', N'008', N'43', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43009', N'009', N'43', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43010', N'010', N'43', N'Kitale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43011', N'011', N'43', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43012', N'012', N'43', N'Karatina', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43013', N'013', N'43', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43014', N'014', N'43', N'United Mall', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43015', N'015', N'43', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43016', N'016', N'43', N'Jomo Kenyatta Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43017', N'017', N'43', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43018', N'018', N'43', N'Busia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43019', N'019', N'43', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43020', N'020', N'43', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43021', N'021', N'43', N'Gikomba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43023', N'023', N'43', N'Valley Arcade', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'43100', N'100', N'43', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49000', N'000', N'49', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49001', N'001', N'49', N'Nairobi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49002', N'002', N'49', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49003', N'003', N'49', N'Westlands The Mall The Mall', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49005', N'005', N'49', N'Chester', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49007', N'007', N'49', N'Waiyaki Way', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49008', N'008', N'49', N'Kakamega', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49009', N'009', N'49', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49011', N'011', N'49', N'Nyali', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49012', N'012', N'49', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'49013', N'013', N'49', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'50000', N'000', N'50', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'50001', N'001', N'50', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'50002', N'002', N'50', N'Parklands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'50003', N'003', N'50', N'Koinange Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'5004', N'004', N'50', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'51000', N'000', N'51', N'Koinange Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53001', N'001', N'53', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53002', N'002', N'53', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53003', N'003', N'53', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53004', N'004', N'53', N'Lavington', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53005', N'005', N'53', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53006', N'006', N'53', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53007', N'007', N'53', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53008', N'008', N'53', N'Muthaiga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53010', N'010', N'53', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53011', N'011', N'53', N'Gikomba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53012', N'012', N'53', N'Ngong Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'53013', N'013', N'53', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'54001', N'001', N'54', N'Nairobi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'54002', N'002', N'54', N'Riverside Drive', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'55001', N'001', N'55', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'55002', N'002', N'55', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'55004', N'004', N'55', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'55005', N'005', N'55', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'55006', N'006', N'55', N'Main Branch', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'55007', N'007', N'55', N'Mombasa Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57000', N'000', N'57', N'Kenyatta Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57001', N'001', N'57', N'2nd Ngong Avenue I & M Bank House', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57002', N'002', N'57', N'Sarit Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57003', N'003', N'57', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57004', N'004', N'57', N'Biashara', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57005', N'005', N'57', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57007', N'007', N'57', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57008', N'008', N'57', N'Karen', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57009', N'009', N'57', N'Panari Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57010', N'010', N'57', N'Parklands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57011', N'011', N'57', N'Wilson Airport', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57012', N'012', N'57', N'Ongata Rongai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57013', N'013', N'57', N'South C Shopping South C', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57014', N'014', N'57', N'Nyali Cinemax', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57015', N'015', N'57', N'Langata Link', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57016', N'016', N'57', N'Lavington', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57018', N'018', N'57', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'57098', N'098', N'57', N'Card Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'59001', N'001', N'59', N'Loita Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'59002', N'002', N'59', N'Ngong Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'60000', N'000', N'60', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'60001', N'001', N'60', N'City Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'60002', N'002', N'60', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'60003', N'003', N'60', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'60004', N'004', N'60', N'Diani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'60006', N'006', N'60', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63000', N'000', N'63', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63001', N'001', N'63', N'Nation Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63002', N'002', N'63', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63003', N'003', N'63', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63005', N'005', N'63', N'Parklands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63006', N'006', N'63', N'Westgate', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63008', N'008', N'63', N'Mombasa Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63009', N'009', N'63', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63011', N'011', N'63', N'Malindi', 0)
GO
print 'Processed 700 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63012', N'012', N'63', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63013', N'013', N'63', N'OTC', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63014', N'014', N'63', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63015', N'015', N'63', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63016', N'016', N'63', N'Changamwe', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63017', N'017', N'63', N'T-Mall', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63018', N'018', N'63', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63019', N'019', N'63', N'Village Market', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63020', N'020', N'63', N'Diani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63021', N'021', N'63', N'Bungoma', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63023', N'023', N'63', N'Prestige', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63024', N'024', N'63', N'Buru Buru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63025', N'025', N'63', N'Kitengela', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63026', N'026', N'63', N'Jomo Kenyatta', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63027', N'027', N'63', N'Kakamega', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63028', N'028', N'63', N'Kericho', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63029', N'029', N'63', N'Upper Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63030', N'030', N'63', N'Wabera Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63031', N'031', N'63', N'Karen', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63032', N'032', N'63', N'Voi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63034', N'034', N'63', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63035', N'035', N'63', N'Diamond Plaza', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63036', N'036', N'63', N'Cross Roads', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'63050', N'050', N'63', N'Tom Mboya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66000', N'000', N'66', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66001', N'001', N'66', N'Naivasha Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66002', N'002', N'66', N'Moi Avenue -Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66003', N'003', N'66', N'Kenyatta Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66004', N'004', N'66', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66005', N'005', N'66', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66007', N'007', N'66', N'Embu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66008', N'008', N'66', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66009', N'009', N'66', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66010', N'010', N'66', N'Kericho', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66011', N'011', N'66', N'Kangemi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66012', N'012', N'66', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66013', N'013', N'66', N'Kerugoya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66014', N'014', N'66', N'Kenyatta Mkt', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66015', N'015', N'66', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66016', N'016', N'66', N'Chuka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66017', N'017', N'66', N'Kitui', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66018', N'018', N'66', N'Machakos', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66019', N'019', N'66', N'Nanyuki', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66021', N'021', N'66', N'Emali', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66022', N'022', N'66', N'Naivasha', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66023', N'023', N'66', N'Nyahururu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66024', N'024', N'66', N'Isiolo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66025', N'025', N'66', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66026', N'026', N'66', N'Kitale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66027', N'027', N'66', N'Kibwezi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66028', N'028', N'66', N'Bungoma', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66031', N'031', N'66', N'Mtwapa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66033', N'033', N'66', N'Moi Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66034', N'034', N'66', N'Mwea', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66035', N'035', N'66', N'Kengeleni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'66036', N'036', N'66', N'Kilimani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68000', N'000', N'68', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68001', N'001', N'68', N'Corporate', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68002', N'002', N'68', N'Fourways', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68003', N'003', N'68', N'Kangema', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68004', N'004', N'68', N'Karatina', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68006', N'006', N'68', N'Muraradia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68007', N'007', N'68', N'Kangari', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68008', N'008', N'68', N'Othaya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68009', N'009', N'68', N'Thika Plaza', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68010', N'010', N'68', N'Kerugoya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68011', N'011', N'68', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68012', N'012', N'68', N'Tom Mboya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68013', N'013', N'68', N'Nakuru Gatehouse Gate Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68014', N'014', N'68', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68015', N'015', N'68', N'Mama Ngina', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68017', N'017', N'68', N'Community', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68018', N'018', N'68', N'Community Corporate', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68019', N'019', N'68', N'Embu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68020', N'020', N'68', N'Naivasha', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68021', N'021', N'68', N'Chuka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68022', N'022', N'68', N'Murang''a', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68023', N'023', N'68', N'Molo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68024', N'024', N'68', N'Harambee', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68025', N'025', N'68', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68026', N'026', N'68', N'Kimathi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68027', N'027', N'68', N'Nanyuki', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68029', N'029', N'68', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68030', N'030', N'68', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68031', N'031', N'68', N'Nakuru Kenyatta Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68032', N'032', N'68', N'Kariobangi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68033', N'033', N'68', N'Kitale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68034', N'034', N'68', N'Thika Kenyatta Highway', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68035', N'035', N'68', N'Knut Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68036', N'036', N'68', N'Narok', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68037', N'037', N'68', N'Nkubu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68038', N'038', N'68', N'Mwea', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68040', N'040', N'68', N'Maua', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68041', N'041', N'68', N'Isiolo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68042', N'042', N'68', N'Kagio', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68043', N'043', N'68', N'Gikomba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68044', N'044', N'68', N'Ukunda', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68045', N'045', N'68', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68046', N'046', N'68', N'Mombasa Digo Rd Digo Rd', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68047', N'047', N'68', N'Moi Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68048', N'048', N'68', N'Bungoma', 0)
GO
print 'Processed 800 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68049', N'049', N'68', N'Kapsabet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68050', N'050', N'68', N'Kakamega', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68052', N'052', N'68', N'Nyamira', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68053', N'053', N'68', N'Litein', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68055', N'055', N'68', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68056', N'056', N'68', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68057', N'057', N'68', N'Kikuyu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68058', N'058', N'68', N'Garissa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68059', N'059', N'68', N'Mwingi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68060', N'060', N'68', N'Machakos', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68061', N'061', N'68', N'Ongata Rongai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68062', N'062', N'68', N'Ol-Kalou', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68064', N'064', N'68', N'Kiambu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68065', N'065', N'68', N'Kayole', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68066', N'066', N'68', N'Gatundu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68067', N'067', N'68', N'Wote', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68068', N'068', N'68', N'Mumias', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68069', N'069', N'68', N'Limuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68070', N'070', N'68', N'Kitengela', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68071', N'071', N'68', N'Githurai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68072', N'072', N'68', N'Kitui', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68073', N'073', N'68', N'Ngong', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68074', N'074', N'68', N'Loitoktok', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68076', N'076', N'68', N'Mbita', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68077', N'077', N'68', N'Gilgil', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68078', N'078', N'68', N'Busia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68079', N'079', N'68', N'Voi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68080', N'080', N'68', N'Enterprise Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68081', N'081', N'68', N'Equity Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68082', N'082', N'68', N'Donholm', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68083', N'083', N'68', N'Mukurwe-ini', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68084', N'084', N'68', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68085', N'085', N'68', N'Namanga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68088', N'088', N'68', N'OTC', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68089', N'089', N'68', N'Kenol', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68090', N'090', N'68', N'Tala', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68091', N'091', N'68', N'Ngara', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68092', N'092', N'68', N'Nandi Hills', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68093', N'093', N'68', N'Githunguri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68094', N'094', N'68', N'Tea Room', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68095', N'095', N'68', N'Buru Buru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68096', N'096', N'68', N'Mbale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68097', N'097', N'68', N'Siaya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68098', N'098', N'68', N'Homa Bay', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68099', N'099', N'68', N'Lodwar', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68100', N'100', N'68', N'Mandera', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68101', N'101', N'68', N'Marsabit', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68102', N'102', N'68', N'Moyale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68103', N'103', N'68', N'Wajir', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68104', N'104', N'68', N'Meru Makutano', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68105', N'105', N'68', N'Malaba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68106', N'106', N'68', N'Kilifi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68107', N'107', N'68', N'Kapenguria', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68108', N'108', N'68', N'Mombasa Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68110', N'110', N'68', N'Maralal', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68111', N'111', N'68', N'Kimende', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68112', N'112', N'68', N'Luanda', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68113', N'113', N'68', N'KU', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68114', N'114', N'68', N'Kengeleni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68115', N'115', N'68', N'Nyeri Kimathi Way EK Wachira Bldg', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68116', N'116', N'68', N'Migori', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68117', N'117', N'68', N'Kibera', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68118', N'118', N'68', N'Kasarani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68119', N'119', N'68', N'Mtwapa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68120', N'120', N'68', N'Changamwe', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68122', N'122', N'68', N'Bomet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68123', N'123', N'68', N'Kilgoris', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68124', N'124', N'68', N'Keroka', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68125', N'125', N'68', N'Karen', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68126', N'126', N'68', N'Kisumu Angawa Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68127', N'127', N'68', N'Mpeketoni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68128', N'128', N'68', N'Nairobi West', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68129', N'129', N'68', N'Kenyatta Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68130', N'130', N'68', N'City Hall', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'68131', N'131', N'68', N'Eldama Ravine', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70000', N'000', N'70', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70001', N'001', N'70', N'Kiambu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70002', N'002', N'70', N'Githunguri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70003', N'003', N'70', N'Sonalux', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70004', N'004', N'70', N'Gatundu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70005', N'005', N'70', N'Thika', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70006', N'006', N'70', N'Murang''a', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70007', N'007', N'70', N'kangari', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70008', N'008', N'70', N'Kiria-ini', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70009', N'009', N'70', N'Kangema', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70011', N'011', N'70', N'Othaya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70014', N'014', N'70', N'Cargen Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70018', N'018', N'70', N'Nakuru Finance', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70019', N'019', N'70', N'Nakuru Njoro Hse', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70021', N'021', N'70', N'Dagoreti', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70023', N'023', N'70', N'Nyahururu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70024', N'024', N'70', N'Ruiru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70025', N'025', N'70', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70026', N'026', N'70', N'Nyamira', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70027', N'027', N'70', N'Kisii', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70031', N'031', N'70', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70033', N'033', N'70', N'Donholm', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70035', N'035', N'70', N'Fourways Retail', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70038', N'038', N'70', N'KTDA Plaza', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70041', N'041', N'70', N'Kariobangi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70042', N'042', N'70', N'Gikomba Area 42', 0)
GO
print 'Processed 900 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70043', N'043', N'70', N'Gikomba', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70045', N'045', N'70', N'Githurai', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70046', N'046', N'70', N'Kilimani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70047', N'047', N'70', N'Limuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70049', N'049', N'70', N'Kagwe', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70051', N'051', N'70', N'Banana', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70053', N'053', N'70', N'Naivasha', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70055', N'055', N'70', N'Nyeri', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70057', N'057', N'70', N'Kerugoya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70058', N'058', N'70', N'Tom Mboya', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70059', N'059', N'70', N'River Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70061', N'061', N'70', N'Kayole', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70062', N'062', N'70', N'Nkubu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70063', N'063', N'70', N'Meru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70065', N'065', N'70', N'KTDA Corporate', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70069', N'069', N'70', N'Kitui', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70071', N'071', N'70', N'Kitengela', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70072', N'072', N'70', N'Kitui', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70073', N'073', N'70', N'Machakos', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70075', N'075', N'70', N'Embu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70077', N'077', N'70', N'Bungoma', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70078', N'078', N'70', N'Kakamega', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70079', N'079', N'70', N'Busia', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70083', N'083', N'70', N'Molo', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70085', N'085', N'70', N'Eldoret', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70095', N'095', N'70', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70096', N'096', N'70', N'Kenyatta Avenue,Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'70097', N'097', N'70', N'Kapsabet', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72000', N'000', N'72', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72001', N'001', N'72', N'Central Clearing Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72002', N'002', N'72', N'Upperhill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72003', N'003', N'72', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72004', N'004', N'72', N'Kenyatta Avenue', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72005', N'005', N'72', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72007', N'007', N'72', N'Lamu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72008', N'008', N'72', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72009', N'009', N'72', N'Muthaiga', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'72010', N'010', N'72', N'Bondeni', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74001', N'001', N'74', N'Wabera Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74002', N'002', N'74', N'Eastleigh', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74003', N'003', N'74', N'Mombasa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74004', N'004', N'74', N'Garissa', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74005', N'005', N'74', N'Eastleigh II', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74006', N'006', N'74', N'Malindi', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74007', N'007', N'74', N'Kisumu', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74008', N'008', N'74', N'Kimathi Street', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74009', N'009', N'74', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74010', N'010', N'74', N'South C', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74011', N'011', N'74', N'Industrial Area', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74012', N'012', N'74', N'Masalani', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74013', N'013', N'74', N'Habaswein', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74014', N'014', N'74', N'Wajir', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74015', N'015', N'74', N'Moyale', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74016', N'016', N'74', N'Nakuru', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74017', N'017', N'74', N'Mombasa 11', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'74999', N'999', N'74', N'Head Office/Clearing Centre', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'76001', N'001', N'76', N'Westlands', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'76002', N'002', N'76', N'Enterprise Road', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'76003', N'003', N'76', N'Upper Hill', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'76099', N'099', N'76', N'Head Office', 0)
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName], [IsDeleted]) VALUES (N'95000', N'000', N'59', N'Head Office', 0)
/****** Object:  Table [dbo].[Attendances]    Script Date: 12/16/2014 10:48:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendances]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Attendances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[Attended] [bit] NOT NULL,
	[ReasonForNotAttending] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
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
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 12/16/2014 10:48:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AccountTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ChartofAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[AccountTypes] ON
INSERT [dbo].[AccountTypes] ([Id], [ShortCode], [Description], [Status], [IsDeleted]) VALUES (1, N'INT       ', N'Internal Account', N'A', 0)
INSERT [dbo].[AccountTypes] ([Id], [ShortCode], [Description], [Status], [IsDeleted]) VALUES (2, N'TUITION   ', N'Tuition', N'A', 0)
INSERT [dbo].[AccountTypes] ([Id], [ShortCode], [Description], [Status], [IsDeleted]) VALUES (3, N'BANK      ', N'Bank', N'A', 0)
INSERT [dbo].[AccountTypes] ([Id], [ShortCode], [Description], [Status], [IsDeleted]) VALUES (4, N'EXT       ', N'External Account', N'A', 0)
SET IDENTITY_INSERT [dbo].[AccountTypes] OFF
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/16/2014 10:48:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AccountName] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccountNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccountTypeId] [int] NULL,
	[COAId] [int] NOT NULL,
	[BankBranch] [int] NULL,
	[SchoolBranch] [int] NULL,
	[BookBalance] [money] NOT NULL,
	[ClearedBalance] [money] NOT NULL,
	[InterestRate] [float] NOT NULL,
	[AccruedInt] [money] NOT NULL,
	[Limit] [money] NOT NULL,
	[PassFlag] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Bal30] [money] NULL,
	[Bal60] [money] NULL,
	[Bal90] [money] NULL,
	[BalOver90] [money] NULL,
	[IntRate30] [float] NULL,
	[IntRate60] [float] NULL,
	[IntRate90] [float] NULL,
	[IntRateOver90] [float] NULL,
	[Closed] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND name = N'IX_FK_Accounts_Customers')
CREATE NONCLUSTERED INDEX [IX_FK_Accounts_Customers] ON [dbo].[Accounts] 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (55, 91, N'Tuition Fees Account', N'6', 2, 33, NULL, 8, 500001.0000, 35854961.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (56, 91, N'Library Fees Account', N'7', 1, 34, NULL, 8, 43381310.0000, 224334810.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (62, 91, N'SUSPENSE - DEBIT', N'9', 1, 53, NULL, 8, -169338183.0000, -237944873.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (63, 91, N'SUSPENSE - CREDIT', N'10', 1, 54, NULL, 8, -133303640.0000, -245181003.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (64, 91, N'PROFIT & LOSS', N'11', 1, 44, NULL, 8, 0.0000, 45600.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (65, 91, N'Medical Fees Account', N'12', 1, 32, NULL, 8, 1510680.0000, 6961230.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (66, 91, N'School Furnitures Account', N'13', 1, 19, NULL, 8, 476280.0000, 2235600.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (69, 91, N'Loan', N'14', 1, 15, NULL, 8, 78768676.0000, 78777576.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (70, 91, N'CAPITAL', N'15', 1, 43, NULL, 8, 0.0000, 45700.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (71, 91, N'SHARES', N'16', 1, 43, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (72, 91, N'Transport Account', N'17', 1, 35, NULL, 8, 0.0000, -177960000.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (73, 91, N'Boarding Fees Account', N'18', 1, 36, NULL, 8, 9300140.0000, 54747100.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (74, 91, N'Laboratory Fees Account', N'19', 1, 55, NULL, 8, 1427230.0000, 8505770.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (75, 91, N'Co-Curriculum Activities Fund Account', N'20', 1, 59, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (76, 91, N'Renovation Account', N'21', 1, 57, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (77, 91, N'School Maintenance Account', N'22', 1, 60, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (78, 91, N'School Employees Fund Account', N'23', 1, 56, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (82, 91, N'Admission Fees Account', N'24', 1, 61, NULL, 8, 4167867.0000, 21903867.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (83, 91, N'School Other Fees Account', N'25', 3, 46, NULL, 8, 0.0000, -70500.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (84, 91, N'Dinning Utensils', N'26', 1, 68, NULL, 8, 520000.0000, 2738000.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (85, 91, N'Medical Account', N'27', 1, 67, NULL, 8, 456000.0000, 456000.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (86, 91, N'Extra Tuition Fees', N'28', 1, 62, NULL, 8, 639450.0000, 2992600.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (87, 91, N'Foreign Student Equation Fees Account', N'29', 1, 64, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (88, 91, N'Smasse Account', N'30', 1, 63, NULL, 8, 17800.0000, 17800.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (89, 91, N'University Registration Account', N'31', 1, 65, NULL, 8, 5636800.0000, 10709920.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (90, 91, N'School Projects Account', N'32', 1, 58, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (91, 91, N'School Id Card Account', N'33', 1, 66, NULL, 8, 312000.0000, 1642800.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (92, 91, N'School Uniform Account', N'34', 1, 69, NULL, 8, 1560000.0000, 8212500.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (107, 91, N'Equity Current Account', N'45', 1, 22, NULL, 8, -456000.0000, -501600.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (109, 91, N'Long Term Liabilities Account', N'46', 1, 13, 1095, 8, 0.0000, -45700.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (110, 91, N'Account Payable Account', N'47', 1, 26, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (121, 91, N'Personal Effects', N'54', 1, 70, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (132, 91, N'Kcb Bank Account - (Fixed)', N'65', 1, 71, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (133, 91, N'Academic Expenses', N'66', 1, 42, NULL, 8, 0.0000, 0.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (143, 91, N'Marketing Expenses', N'76', 1, 41, NULL, 8, -182000.0000, -292500.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [BankBranch], [SchoolBranch], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [PassFlag], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed], [IsDeleted]) VALUES (144, 91, N'Financial Expenses', N'77', 1, 40, NULL, 8, 182000.0000, 363000.0000, 0, 0.0000, 0.0000, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 12/16/2014 10:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_UsersInRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_webpages_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3, 1)
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_webpages_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'Administrator')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_OAuthMembership]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProviderUserId] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_webpages_OAuthMembership] PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 12/16/2014 10:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_Membership]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [smalldatetime] NULL,
	[ConfirmationToken] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [smalldatetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordChangedDate] [smalldatetime] NULL,
	[PasswordSalt] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PasswordVerificationTokenExpirationDate] [smalldatetime] NULL,
 CONSTRAINT [PK_webpages_Membership] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (43, CAST(0xA3A80182 AS SmallDateTime), NULL, 1, NULL, 0, N'AMDS/xX3zlIIPX/FgcgY1AdLAkEiK77hft15AfUqfVsO4IKxNd27ampjSNRT/i6uwg==', CAST(0xA3A80182 AS SmallDateTime), N'', NULL, NULL)
/****** Object:  View [dbo].[vwExamResults]    Script Date: 12/16/2014 10:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwExamResults]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwExamResults]
AS
SELECT     dbo.Exam.ExamPeriodId, dbo.Exam.ClassId, dbo.Exam.Id, dbo.StudentExams.StudentId, dbo.Exam.SubjectShortCode, dbo.Subjects.Description, 
                      dbo.RegisteredExams.ContributionFlag, SUM(dbo.StudentExams.Mark / dbo.RegisteredExams.OutOf * 100 * dbo.RegisteredExams.Contribution) AS ExamMark, 
                      SUM(dbo.RegisteredExams.Contribution) * 100 AS CombinedOutOf
FROM         dbo.StudentExams INNER JOIN
                      dbo.RegisteredExams ON dbo.StudentExams.RegdExamId = dbo.RegisteredExams.Id INNER JOIN
                      dbo.Exam ON dbo.RegisteredExams.ExamId = dbo.Exam.Id INNER JOIN
                      dbo.Subjects ON dbo.Exam.SubjectShortCode = dbo.Subjects.ShortCode INNER JOIN
                      dbo.ExamTypes ON dbo.RegisteredExams.ExamTypeId = dbo.ExamTypes.Id
GROUP BY dbo.StudentExams.StudentId, dbo.Exam.SubjectShortCode, dbo.Subjects.Description, dbo.RegisteredExams.ContributionFlag, dbo.Exam.ExamPeriodId, 
                      dbo.Exam.ClassId, dbo.Exam.Id
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vwExamResults', NULL,NULL))
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
         Begin Table = "StudentExams"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RegisteredExams"
            Begin Extent = 
               Top = 6
               Left = 243
               Bottom = 114
               Right = 418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Exam"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 222
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Subjects"
            Begin Extent = 
               Top = 114
               Left = 259
               Bottom = 222
               Right = 451
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ExamTypes"
            Begin Extent = 
               Top = 222
               Left = 38
               Bottom = 330
               Right = 248
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
      Begin ColumnWidths = 12
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
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwExamResults'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'vwExamResults', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwExamResults'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vwExamResults', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwExamResults'
GO
/****** Object:  View [dbo].[vwBankBranches]    Script Date: 12/16/2014 10:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwBankBranches]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwBankBranches]
AS
SELECT     dbo.Banks.BankName + '' - '' + dbo.BankBranches.BranchName AS BankBranchName, dbo.BankBranches.BankSortCode, dbo.Banks.BankName, 
                      dbo.BankBranches.BankCode, dbo.BankBranches.BranchCode, dbo.BankBranches.BranchName
FROM         dbo.BankBranches INNER JOIN
                      dbo.Banks ON dbo.BankBranches.BankCode = dbo.Banks.BankCode
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vwBankBranches', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[38] 4[4] 2[19] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
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
      ActivePaneConfig = 2
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BankBranches"
            Begin Extent = 
               Top = 24
               Left = 343
               Bottom = 132
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Banks"
            Begin Extent = 
               Top = 31
               Left = 16
               Bottom = 109
               Right = 167
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
      PaneHidden = 
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
/****** Object:  Table [dbo].[StudentProgresses]    Script Date: 12/16/2014 10:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentProgresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[ExamId] [int] NOT NULL,
	[SchoolClassId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Term] [int] NOT NULL,
	[ClassShortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SubjectShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TeacherId] [int] NULL,
	[TotalMarks] [float] NULL,
	[TotalPoints] [float] NULL,
	[Position] [int] NULL,
	[MeanMarks] [float] NULL,
	[MeanGrade] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HeadTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsDeleted] [bit] NULL,
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
/****** Object:  StoredProcedure [dbo].[CopyExamResultsDet]    Script Date: 12/16/2014 10:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CopyExamResultsDet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [dbo].[CopyExamResultsDet]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	/* SET NOCOUNT ON */
INSERT INTO StudentsExamResultsDetail
                         (StudentsExamResultsId, SubjectShortCode, Mark, Grade, Mark_Target, Grade_Target, IsDeleted)
SELECT        StudentsExamResults_TempId, SubjectShortCode, Mark, Grade, Mark_Target, Grade_Target, IsDeleted
FROM            StudentsExamResultsDetail_Temp
SELECT        StudentsExamResults_TempId, SubjectShortCode, Mark, Grade, Mark_Target, Grade_Target, IsDeleted
FROM            StudentsExamResultsDetail_Temp
	RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[CopyExamResults]    Script Date: 12/16/2014 10:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CopyExamResults]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [dbo].[CopyExamResults]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	/* SET NOCOUNT ON */
INSERT INTO StudentsExamResults
                         (StudentId, Examid, SchoolClassId, TeacherId, TotalMarks_Target, TotalPoints_Target, Position_Target, MeanMarks_Target, MeanGrade_Target, TotalMarks, TotalPoints, Position, MeanMarks, MeanGrade, ClassTeacherRemark, HeadTeacherRemark, 
                         Status, IsDeleted)
SELECT        StudentId, Examid, SchoolClassId, TeacherId, TotalMarks_Target, TotalPoints_Target, Position_Target, MeanMarks_Target, MeanGrade_Target, TotalMarks, TotalPoints, Position, MeanMarks, MeanGrade, ClassTeacherRemark, HeadTeacherRemark, 
                         Status, IsDeleted
FROM            StudentsExamResults_Temp
SELECT        StudentId, Examid, SchoolClassId, TeacherId, TotalMarks_Target, TotalPoints_Target, Position_Target, MeanMarks_Target, MeanGrade_Target, TotalMarks, TotalPoints, Position, MeanMarks, MeanGrade, ClassTeacherRemark, HeadTeacherRemark, 
                         Status, IsDeleted
FROM            StudentsExamResults_Temp
	RETURN
' 
END
GO
/****** Object:  ForeignKey [FK_StudentProgresses_Students]    Script Date: 12/16/2014 10:48:58 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses]  WITH CHECK ADD  CONSTRAINT [FK_StudentProgresses_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses] CHECK CONSTRAINT [FK_StudentProgresses_Students]
GO
