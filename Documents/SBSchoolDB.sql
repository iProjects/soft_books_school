/****** Object:  Database [SBSchoolDB]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'SBSchoolVersion' , NULL,NULL, NULL,NULL, NULL,NULL))
EXEC dbo.sp_addextendedproperty @name=N'SBSchoolVersion', @value=N'1.0.0.0'
GO
/****** Object:  ForeignKey [FK_Accounts_AccountTypes]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_AccountTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_AccountTypes]
GO
/****** Object:  ForeignKey [FK_Accounts_COA]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_COA]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_COA]
GO
/****** Object:  ForeignKey [FK_Accounts_Customers]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_Customers]
GO
/****** Object:  ForeignKey [FK_Attendances_Students]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendances_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances] DROP CONSTRAINT [FK_Attendances_Students]
GO
/****** Object:  ForeignKey [FK_BankBranch_Banks]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[BankBranches]'))
ALTER TABLE [dbo].[BankBranches] DROP CONSTRAINT [FK_BankBranch_Banks]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_SchoolClasses]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_SchoolClasses]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_SchoolClasses]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Subjects]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] DROP CONSTRAINT [FK_ClassSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_Discipline_DisciplinaryCategories]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Discipline_DisciplinaryCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Discipline]'))
ALTER TABLE [dbo].[Discipline] DROP CONSTRAINT [FK_Discipline_DisciplinaryCategories]
GO
/****** Object:  ForeignKey [FK_Discipline_Students]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Discipline_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Discipline]'))
ALTER TABLE [dbo].[Discipline] DROP CONSTRAINT [FK_Discipline_Students]
GO
/****** Object:  ForeignKey [FK_Exam_ExamPeriod]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Exam_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[Exam]'))
ALTER TABLE [dbo].[Exam] DROP CONSTRAINT [FK_Exam_ExamPeriod]
GO
/****** Object:  ForeignKey [FK_FeeStructureAcademic_FeesStructure]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FeeStructureAcademic_FeesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[FeeStructureAcademic]'))
ALTER TABLE [dbo].[FeeStructureAcademic] DROP CONSTRAINT [FK_FeeStructureAcademic_FeesStructure]
GO
/****** Object:  ForeignKey [FK_FeeStructureOthers_FeesStructure]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FeeStructureOthers_FeesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[FeeStructureOthers]'))
ALTER TABLE [dbo].[FeeStructureOthers] DROP CONSTRAINT [FK_FeeStructureOthers_FeesStructure]
GO
/****** Object:  ForeignKey [FK_GradingSystemDet_GradingSystems]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDets]'))
ALTER TABLE [dbo].[GradingSystemDets] DROP CONSTRAINT [FK_GradingSystemDet_GradingSystems]
GO
/****** Object:  ForeignKey [FK_LocationProperties_Locations]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LocationProperties_Locations]') AND parent_object_id = OBJECT_ID(N'[dbo].[LocationProperties]'))
ALTER TABLE [dbo].[LocationProperties] DROP CONSTRAINT [FK_LocationProperties_Locations]
GO
/****** Object:  ForeignKey [FK_ProgrammeCourses_Programmes]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeCourses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeYearCourses]'))
ALTER TABLE [dbo].[ProgrammeYearCourses] DROP CONSTRAINT [FK_ProgrammeCourses_Programmes]
GO
/****** Object:  ForeignKey [FK_ProgrammeYears_Programmes]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeYears_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeYears]'))
ALTER TABLE [dbo].[ProgrammeYears] DROP CONSTRAINT [FK_ProgrammeYears_Programmes]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_Exam]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_Exam]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_Exam]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ExamTypes]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] DROP CONSTRAINT [FK_RegisteredExams_ExamTypes]
GO
/****** Object:  ForeignKey [FK_Reports_FK00]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_Reports_FK00]
GO
/****** Object:  ForeignKey [FK_ResidenceHallRooms_ResidenceHalls]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ResidenceHallRooms_ResidenceHalls]') AND parent_object_id = OBJECT_ID(N'[dbo].[ResidenceHallRooms]'))
ALTER TABLE [dbo].[ResidenceHallRooms] DROP CONSTRAINT [FK_ResidenceHallRooms_ResidenceHalls]
GO
/****** Object:  ForeignKey [FK_Class_FK00]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Class_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses] DROP CONSTRAINT [FK_Class_FK00]
GO
/****** Object:  ForeignKey [FK_SchoolClasses_ProgrammeYears]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SchoolClasses_ProgrammeYears]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses] DROP CONSTRAINT [FK_SchoolClasses_ProgrammeYears]
GO
/****** Object:  ForeignKey [FK_Settings_SettingsGroups]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[Settings]'))
ALTER TABLE [dbo].[Settings] DROP CONSTRAINT [FK_Settings_SettingsGroups]
GO
/****** Object:  ForeignKey [FK_StudentExams_RegisteredExams1]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams1]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] DROP CONSTRAINT [FK_StudentExams_RegisteredExams1]
GO
/****** Object:  ForeignKey [FK_StudentExams_Students]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] DROP CONSTRAINT [FK_StudentExams_Students]
GO
/****** Object:  ForeignKey [FK_StudentProgresses_Students]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses] DROP CONSTRAINT [FK_StudentProgresses_Students]
GO
/****** Object:  ForeignKey [FK_StudentsExamResults_Exam]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentsExamResults_Exam]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentsExamResults]'))
ALTER TABLE [dbo].[StudentsExamResults] DROP CONSTRAINT [FK_StudentsExamResults_Exam]
GO
/****** Object:  ForeignKey [FK_StudentsExamResultsDetail_StudentsExamResults]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentsExamResultsDetail_StudentsExamResults]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]'))
ALTER TABLE [dbo].[StudentsExamResultsDetail] DROP CONSTRAINT [FK_StudentsExamResultsDetail_StudentsExamResults]
GO
/****** Object:  ForeignKey [FK_SubSubjects_Subjects]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects] DROP CONSTRAINT [FK_SubSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_TimeTable_ClassStreams]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TimeTable_ClassStreams]') AND parent_object_id = OBJECT_ID(N'[dbo].[TimeTables]'))
ALTER TABLE [dbo].[TimeTables] DROP CONSTRAINT [FK_TimeTable_ClassStreams]
GO
/****** Object:  ForeignKey [FK_Transactions_Accounts]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_Accounts]
GO
/****** Object:  ForeignKey [FK_Transactions_FK01]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_FK01]
GO
/****** Object:  ForeignKey [FK_Users_PasswordQuestion]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_PasswordQuestion]
GO
/****** Object:  Table [dbo].[ClassSubjects]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassSubjects]') AND type in (N'U'))
DROP TABLE [dbo].[ClassSubjects]
GO
/****** Object:  Table [dbo].[StudentExams]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentExams]') AND type in (N'U'))
DROP TABLE [dbo].[StudentExams]
GO
/****** Object:  Table [dbo].[StudentsExamResultsDetail]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]') AND type in (N'U'))
DROP TABLE [dbo].[StudentsExamResultsDetail]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND type in (N'U'))
DROP TABLE [dbo].[Transactions]
GO
/****** Object:  Table [dbo].[StudentsExamResults]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResults]') AND type in (N'U'))
DROP TABLE [dbo].[StudentsExamResults]
GO
/****** Object:  View [dbo].[vwBankBranches]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwBankBranches]'))
DROP VIEW [dbo].[vwBankBranches]
GO
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND type in (N'U'))
DROP TABLE [dbo].[SchoolClasses]
GO
/****** Object:  Table [dbo].[RegisteredExams]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND type in (N'U'))
DROP TABLE [dbo].[RegisteredExams]
GO
/****** Object:  Table [dbo].[FeeStructureAcademic]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeStructureAcademic]') AND type in (N'U'))
DROP TABLE [dbo].[FeeStructureAcademic]
GO
/****** Object:  Table [dbo].[FeeStructureOthers]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeStructureOthers]') AND type in (N'U'))
DROP TABLE [dbo].[FeeStructureOthers]
GO
/****** Object:  Table [dbo].[GradingSystemDets]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystemDets]') AND type in (N'U'))
DROP TABLE [dbo].[GradingSystemDets]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
DROP TABLE [dbo].[Reports]
GO
/****** Object:  Table [dbo].[ResidenceHallRooms]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResidenceHallRooms]') AND type in (N'U'))
DROP TABLE [dbo].[ResidenceHallRooms]
GO
/****** Object:  Table [dbo].[ProgrammeYearCourses]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYearCourses]') AND type in (N'U'))
DROP TABLE [dbo].[ProgrammeYearCourses]
GO
/****** Object:  Table [dbo].[ProgrammeYears]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYears]') AND type in (N'U'))
DROP TABLE [dbo].[ProgrammeYears]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
DROP TABLE [dbo].[Settings]
GO
/****** Object:  Table [dbo].[StudentProgresses]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses]') AND type in (N'U'))
DROP TABLE [dbo].[StudentProgresses]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[Accounts]
GO
/****** Object:  Table [dbo].[Attendances]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendances]') AND type in (N'U'))
DROP TABLE [dbo].[Attendances]
GO
/****** Object:  Table [dbo].[BankBranches]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankBranches]') AND type in (N'U'))
DROP TABLE [dbo].[BankBranches]
GO
/****** Object:  Table [dbo].[Discipline]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Discipline]') AND type in (N'U'))
DROP TABLE [dbo].[Discipline]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exam]') AND type in (N'U'))
DROP TABLE [dbo].[Exam]
GO
/****** Object:  Table [dbo].[LocationProperties]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocationProperties]') AND type in (N'U'))
DROP TABLE [dbo].[LocationProperties]
GO
/****** Object:  Table [dbo].[TimeTables]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTables]') AND type in (N'U'))
DROP TABLE [dbo].[TimeTables]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[SubSubjects]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubSubjects]') AND type in (N'U'))
DROP TABLE [dbo].[SubSubjects]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teachers]') AND type in (N'U'))
DROP TABLE [dbo].[Teachers]
GO
/****** Object:  Table [dbo].[TimeTableDets]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTableDets]') AND type in (N'U'))
DROP TABLE [dbo].[TimeTableDets]
GO
/****** Object:  Table [dbo].[StudentSubjectTagets]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentSubjectTagets]') AND type in (N'U'))
DROP TABLE [dbo].[StudentSubjectTagets]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
DROP TABLE [dbo].[Subjects]
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionTypes]') AND type in (N'U'))
DROP TABLE [dbo].[TransactionTypes]
GO
/****** Object:  Table [dbo].[Transport]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transport]') AND type in (N'U'))
DROP TABLE [dbo].[Transport]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locations]') AND type in (N'U'))
DROP TABLE [dbo].[Locations]
GO
/****** Object:  Table [dbo].[MarksheetArchives]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarksheetArchives]') AND type in (N'U'))
DROP TABLE [dbo].[MarksheetArchives]
GO
/****** Object:  Table [dbo].[MarkSheetExams]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetExams]') AND type in (N'U'))
DROP TABLE [dbo].[MarkSheetExams]
GO
/****** Object:  Table [dbo].[MarkSheetStudents]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MarkSheetStudents]') AND type in (N'U'))
DROP TABLE [dbo].[MarkSheetStudents]
GO
/****** Object:  Table [dbo].[Parents]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parents]') AND type in (N'U'))
DROP TABLE [dbo].[Parents]
GO
/****** Object:  Table [dbo].[Programmes]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programmes]') AND type in (N'U'))
DROP TABLE [dbo].[Programmes]
GO
/****** Object:  Table [dbo].[ExamPeriod]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamPeriod]') AND type in (N'U'))
DROP TABLE [dbo].[ExamPeriod]
GO
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamTypes]') AND type in (N'U'))
DROP TABLE [dbo].[ExamTypes]
GO
/****** Object:  Table [dbo].[FeesStructure]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeesStructure]') AND type in (N'U'))
DROP TABLE [dbo].[FeesStructure]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banks]') AND type in (N'U'))
DROP TABLE [dbo].[Banks]
GO
/****** Object:  Table [dbo].[ClassStreams]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassStreams]') AND type in (N'U'))
DROP TABLE [dbo].[ClassStreams]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountTypes]') AND type in (N'U'))
DROP TABLE [dbo].[AccountTypes]
GO
/****** Object:  Table [dbo].[COA]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COA]') AND type in (N'U'))
DROP TABLE [dbo].[COA]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[DisciplinaryCategories]    Script Date: 04/23/2013 17:16:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DisciplinaryCategories]') AND type in (N'U'))
DROP TABLE [dbo].[DisciplinaryCategories]
GO
/****** Object:  Table [dbo].[StudentProgresses_Temp]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses_Temp]') AND type in (N'U'))
DROP TABLE [dbo].[StudentProgresses_Temp]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 04/23/2013 17:16:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
DROP TABLE [dbo].[Students]
GO
/****** Object:  Table [dbo].[SettingsGroups]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SettingsGroups]') AND type in (N'U'))
DROP TABLE [dbo].[SettingsGroups]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schools]') AND type in (N'U'))
DROP TABLE [dbo].[Schools]
GO
/****** Object:  Table [dbo].[SecurityQuestions]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecurityQuestions]') AND type in (N'U'))
DROP TABLE [dbo].[SecurityQuestions]
GO
/****** Object:  Table [dbo].[ResidenceHalls]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResidenceHalls]') AND type in (N'U'))
DROP TABLE [dbo].[ResidenceHalls]
GO
/****** Object:  Table [dbo].[Residences]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Residences]') AND type in (N'U'))
DROP TABLE [dbo].[Residences]
GO
/****** Object:  Table [dbo].[RoleRights]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleRights]') AND type in (N'U'))
DROP TABLE [dbo].[RoleRights]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rooms]') AND type in (N'U'))
DROP TABLE [dbo].[Rooms]
GO
/****** Object:  Table [dbo].[RuleSet]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RuleSet]') AND type in (N'U'))
DROP TABLE [dbo].[RuleSet]
GO
/****** Object:  Table [dbo].[GradingSystems]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystems]') AND type in (N'U'))
DROP TABLE [dbo].[GradingSystems]
GO
/****** Object:  Table [dbo].[ISUserLogins]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ISUserLogins]') AND type in (N'U'))
DROP TABLE [dbo].[ISUserLogins]
GO
/****** Object:  Table [dbo].[ReportGroups]    Script Date: 04/23/2013 17:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportGroups]') AND type in (N'U'))
DROP TABLE [dbo].[ReportGroups]
GO
/****** Object:  Table [dbo].[ReportGroups]    Script Date: 04/23/2013 17:16:32 ******/
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
/****** Object:  Table [dbo].[ISUserLogins]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ISUserLogins]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ISUserLogins](
	[UserId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Role] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Locked] [bit] NULL,
 CONSTRAINT [PK_ISUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[ISUserLogins] ([UserId], [Password], [Role], [Locked]) VALUES (N'mutio', N'6543', N'BS', 0)
INSERT [dbo].[ISUserLogins] ([UserId], [Password], [Role], [Locked]) VALUES (N'sys', N'sys', N'AD', 0)
/****** Object:  Table [dbo].[GradingSystems]    Script Date: 04/23/2013 17:16:32 ******/
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
INSERT [dbo].[GradingSystems] ([Id], [Description]) VALUES (1, N'KCSE')
INSERT [dbo].[GradingSystems] ([Id], [Description]) VALUES (70, N'KCPE')
SET IDENTITY_INSERT [dbo].[GradingSystems] OFF
/****** Object:  Table [dbo].[RuleSet]    Script Date: 04/23/2013 17:16:32 ******/
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
 CONSTRAINT [PK_RuleSet] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[MajorVersion] ASC,
	[MinorVersion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[RuleSet] ([Name], [MajorVersion], [MinorVersion], [RuleSet], [Status], [AssemblyPath], [ActivityName], [ModifiedDate]) VALUES (N'RegExamsRuleSet', 1, 0, N'<RuleSet Description="{p1:Null}" Name="RegExamsRuleSet" ChainingBehavior="Full" xmlns:p1="http://schemas.microsoft.com/winfx/2006/xaml" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/workflow">
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
</RuleSet>', 0, N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\Rules\bin\Debug\Rules.dll', N'Rules.RegisterExamRules', CAST(0x0000A17501095B40 AS DateTime))
/****** Object:  Table [dbo].[Rooms]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rooms]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rooms](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Capacity] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON
INSERT [dbo].[Rooms] ([RoomId], [ShortCode], [Description], [Capacity]) VALUES (1, N'DH', N'DINNING HALL', N'1000      ')
INSERT [dbo].[Rooms] ([RoomId], [ShortCode], [Description], [Capacity]) VALUES (2, N'LH', N'LIBRARY HALL', N'500       ')
INSERT [dbo].[Rooms] ([RoomId], [ShortCode], [Description], [Capacity]) VALUES (3, N'CH', N'CONFERENCE HALL', N'89022     ')
INSERT [dbo].[Rooms] ([RoomId], [ShortCode], [Description], [Capacity]) VALUES (7, N'CHSE 5 1A', N'CHURCH HOUSE 5TH FLOOR ROOM 1A', N'50        ')
INSERT [dbo].[Rooms] ([RoomId], [ShortCode], [Description], [Capacity]) VALUES (8, N'CHSE 6 1B', N'CHURCH HOUSE 6TH FLOOR ROOM 1B', N'50        ')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
/****** Object:  Table [dbo].[RoleRights]    Script Date: 04/23/2013 17:16:32 ******/
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
/****** Object:  Table [dbo].[Residences]    Script Date: 04/23/2013 17:16:32 ******/
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
 CONSTRAINT [PK_Residences] PRIMARY KEY CLUSTERED 
(
	[ResidenceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Residences] ON
INSERT [dbo].[Residences] ([ResidenceId], [ParentId], [Name], [Cost], [GPSCordinates], [Title]) VALUES (1, 1, N'Kenya', 65474.0000, N'23232', N'Country')
INSERT [dbo].[Residences] ([ResidenceId], [ParentId], [Name], [Cost], [GPSCordinates], [Title]) VALUES (3, 1, N'Rift Valley', 18858.0000, N'33333333333333', N'Province')
INSERT [dbo].[Residences] ([ResidenceId], [ParentId], [Name], [Cost], [GPSCordinates], [Title]) VALUES (4, 3, N'Kajiado', 58552.0000, N'111111111111111', N'County')
INSERT [dbo].[Residences] ([ResidenceId], [ParentId], [Name], [Cost], [GPSCordinates], [Title]) VALUES (5, 1, N'Kiserian', 25285.0000, N'99999999999', N'Location')
INSERT [dbo].[Residences] ([ResidenceId], [ParentId], [Name], [Cost], [GPSCordinates], [Title]) VALUES (6, 1, N'Kwa Maji', 52859.0000, N'254666', N'Area')
INSERT [dbo].[Residences] ([ResidenceId], [ParentId], [Name], [Cost], [GPSCordinates], [Title]) VALUES (7, 3, N'Matasia', 52954.0000, N'1223333', N'Area')
SET IDENTITY_INSERT [dbo].[Residences] OFF
/****** Object:  Table [dbo].[ResidenceHalls]    Script Date: 04/23/2013 17:16:32 ******/
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
 CONSTRAINT [PK_ResidenceHalls] PRIMARY KEY CLUSTERED 
(
	[HallId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[ResidenceHalls] ON
INSERT [dbo].[ResidenceHalls] ([HallId], [HallName], [Location]) VALUES (6, N'326326', N'775226')
INSERT [dbo].[ResidenceHalls] ([HallId], [HallName], [Location]) VALUES (7, N'8', N'77')
INSERT [dbo].[ResidenceHalls] ([HallId], [HallName], [Location]) VALUES (9, N'QQQQ', N'qqqq')
INSERT [dbo].[ResidenceHalls] ([HallId], [HallName], [Location]) VALUES (10, N'8888', N'22222')
SET IDENTITY_INSERT [dbo].[ResidenceHalls] OFF
/****** Object:  Table [dbo].[SecurityQuestions]    Script Date: 04/23/2013 17:16:32 ******/
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
/****** Object:  Table [dbo].[Schools]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schools]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Schools](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SchoolIndex] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SchoolName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SchoolType] [int] NOT NULL,
	[GradingSystem] [int] NOT NULL,
	[Cellphone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SMTPServer] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SMSGateway] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultSchool] [bit] NOT NULL,
	[GLCustomerId] [int] NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Schools] ON
INSERT [dbo].[Schools] ([Id], [SchoolIndex], [SchoolName], [SchoolType], [GradingSystem], [Cellphone], [Telephone], [Email], [Address1], [Address2], [SMTPServer], [SMSGateway], [DefaultSchool], [GLCustomerId]) VALUES (8, N'23', N'BARAKA HIGH SCHOOL', 3, 1, N'524152', N'124574', NULL, NULL, NULL, NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Schools] OFF
/****** Object:  Table [dbo].[SettingsGroups]    Script Date: 04/23/2013 17:16:32 ******/
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
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (2, N'School', 1)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (3, N'General', 1)
INSERT [dbo].[SettingsGroups] ([Id], [GroupName], [Parent]) VALUES (7, N'Security', 1)
/****** Object:  Table [dbo].[Students]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[SchoolId] [int] NOT NULL,
	[CurrentClass] [int] NOT NULL,
	[AdminNo] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StudentSurName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StudentOtherNames] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Gender] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Phone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Homepage] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KCPE] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KCSE] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AdmissionDate] [datetime] NULL,
	[AdmittedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Remarks] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Photo] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModifiedTime] [datetime] NULL,
	[GLAccount] [int] NULL,
	[CustomerID] [int] NULL,
	[FatherName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherCellPhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherOfficePhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherEmail] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherCellPhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherOfficePhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MotherEmail] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GuardianName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GuardianCellPhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GuardianOfficePhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GuardianEmail] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolPhone] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrevSchoolAddress] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReasonForLeaving] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricular1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricular2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExtraCurricular3] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term1MeanGrade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term2MeanGrade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Term3MeanGrade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Students] ON
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (13, 8, 56, N'12345', N'MUIGAI', N'REHAB NYAMBURA', N'F', CAST(0x0000A19F0135996C AS DateTime), N'0705896325', N'rehab@gmail.com', N'www.facebook.com/rehab', N'35325, oloosurutia', N'A    ', N'455       ', N'644       ', CAST(0x0000A1A60135996C AS DateTime), N'OBRA', N'hard working', N'C:\Program Files\Software Providers\Soft Books School\Splash.JPG', CAST(0x0000A1A800AA7018 AS DateTime), 30, 1, N'JAMES KAHUHIA', N'0712356256', N'345678', N'james@gmail.com', N'JESICCA KAHUHIA', N'0745214365', N'486466', N'jessica@gmail.com', N'IAN PEARSON', N'0735698412', N'456848', N'ianpearson@gmail.com', N'1', N'BARAKA GIRLS SECONDARY SCHOOL', N'0754689521', N'54856, kiserian', N'expelled for influencing other students to go on strike.', N'swimming', N'hockey', N'handball', NULL, NULL, NULL, 1, 1, N'M', NULL, 1, 16, 8, N'dr. kivutha karanja', N'diabities', N'ugali, red meat, porridge', N'cold water, sugar,', N'rtgrsgretgr', N'sregssregsrgrt')
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (14, 8, 57, N'80241', N'GITHAIGA', N'NOREEN NDUTA', N'F', CAST(0x00008C95013637A0 AS DateTime), N'fdgdfgfdgdf', N'ngdfgdfgdf', N'fdgdfgdfg', N'ggggggggggggggd', N'A    ', N'0         ', N'0         ', CAST(0x00009FF3013637A0 AS DateTime), N'GHJGHJGHJ', N'dgffdhghgfj', NULL, CAST(0x0000A19F01008768 AS DateTime), 33, 2, N'FDGDFG', N'dfgdfg', N'fgdfg', N'dfgd', N'DFGDFG', N'dfgdf', N'gdfg', N'dfgdfgfd', N'GDFGFDGFDGFDG', N'gdfg', N'gdfgdf', N'dfgdfg', N'DFGDF', N'FDGDF', N'dfgdf', N'gdfgdf', N'dfgdfg', N'ghjghjgh', N'ghjghjgh', N'ghjgjghj', NULL, NULL, NULL, 1, 0, N'T', NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (16, 8, 58, N'11119', N'MARETE', N'DICKSON KIBUJA', N'M', CAST(0x0000A155012CFBF4 AS DateTime), N'SDFSDF', N'testing', N'', N'ASDFSD', N'A    ', N'0         ', N'0         ', CAST(0x0000A164012CFBF4 AS DateTime), N'SDFSDFSDF', N'testd', N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\WinSchool\Resources\kra2.jpg', CAST(0x0000A1A00138D29F AS DateTime), 34, 3, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (17, 8, 59, N'23222', N'KAMAU', N'JOHNSON JAMES', N'M', CAST(0x0000A1640026EECC AS DateTime), N'', N'', N'', N'', N'A    ', N'0         ', N'0         ', CAST(0x0000A1650026EECC AS DateTime), N'', N'', NULL, CAST(0x0000A1A00139CB13 AS DateTime), 39, 4, N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (18, 8, 65, N'34824', N'MWAURA', N'WANGESHI EVELYN', N'F', CAST(0x0000A165007B9774 AS DateTime), N'', N'', N'', N'', N'A    ', N'0         ', N'0         ', CAST(0x0000A165007B9774 AS DateTime), N'', N'', NULL, CAST(0x0000A19F0100995E AS DateTime), NULL, 5, N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (20, 8, 61, N'45638', N'WARURU', N'QUINCE BABRA', N'F', CAST(0x0000A165008020C8 AS DateTime), N'0714452255', N'babra@yahoo.com', N'', N'14552, NAIROBI', N'A    ', N'0         ', N'0         ', CAST(0x0000A165008020C8 AS DateTime), N'MR JAMES NG''ANG''A', N'good', NULL, CAST(0x0000A19F01009F7B AS DateTime), NULL, 6, N'RRRRRRRRRRR', N'EEEEEEEEEEEE', N'YYYYYYYYYYYYY', N'uuuuuuuuuuuuuu', N'IIIIIIIIIIIII', N'NBBBBBBBBBBBB', N'VVVVVVVVVVVVVV', NULL, NULL, NULL, NULL, NULL, N'', N'', N'', N'', N'', N'drama', N'swimming', N'music', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (21, 8, 62, N'24563', N'FABIAN', N'MOHAMED ABDUL', N'M', CAST(0x0000A1650082F2A8 AS DateTime), N'', N'', N'', N'', N'A    ', N'0         ', N'0         ', CAST(0x0000A1650082F2A8 AS DateTime), N'', N'', NULL, CAST(0x0000A19F0100A5A6 AS DateTime), NULL, 7, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (22, 8, 64, N'42423', N'KIMEMIA', N'SAMSON KIMATHI', N'F', CAST(0x0000A1650083A270 AS DateTime), N'', N'', N'', N'', N'A    ', N'0         ', N'0         ', CAST(0x0000A1650083A270 AS DateTime), N'', N'', NULL, CAST(0x0000A19F0100AB8E AS DateTime), NULL, 8, N'JBHKBHJU', N'JBNHJKBHJU', N'', N'', N'JBHJ', N'BNJHJ', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (23, 8, 70, N'34523', N'NDUTU', N'WAMBUI MONIQ', N'F', CAST(0x0000A16500841D7C AS DateTime), N'', N'', N'', N'', N'A    ', N'0         ', N'0         ', CAST(0x0000A16500841D7C AS DateTime), N'', N'jbgb', NULL, CAST(0x0000A19F0100B179 AS DateTime), NULL, 9, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (24, 8, 71, N'56455', N'MBUGUA', N'NJOKI AIMEY', N'F', CAST(0x0000A1650086C400 AS DateTime), N'', N'', N'', N'', N'A    ', N'0         ', N'0         ', CAST(0x0000A1650086C400 AS DateTime), N'', N'', NULL, CAST(0x0000A19F0100B801 AS DateTime), NULL, 10, N'JYFGVYFV', N'HBGVYHVY', N'', N'', N'BGKYHJBG', N'HJBGHY', N'', NULL, NULL, NULL, NULL, NULL, N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (25, 8, 72, N'T6757', N'ARIMI', N'MATO OBRA', N'F', CAST(0x0000A16500888BDC AS DateTime), N'JKHBUGYI', N'nmbhgy', N'bhby', N'HBGY', N'A    ', N'0         ', N'0         ', CAST(0x0000A16600888BDC AS DateTime), N'HBVGHYJ', N'bhbb', NULL, CAST(0x0000A19F0100BD48 AS DateTime), NULL, 11, N'TFT', N'THFHCDFVTCTH', N'HHUHHJUH', N'uhuhh', N'JGHYVFY', N'HVGFYJ', N'UHU', N'', N'', N'', N'', N'', N'IJJUH', N'BVVV', N'BVBYY', N'BUIVG', N'bhyvdcsdcw', N'234234', N'3rfef', N'hbhy', NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (26, 8, 73, N'3201', N'OJWANG', N'EVELYN AKINYI', N'F', CAST(0x0000A18700B14D10 AS DateTime), N'0721258369', N'eakinyi1@gmail.com', N'www.facebook/evelyneakinyi', N'27872, homabay', N'A    ', N'354       ', N'500       ', CAST(0x0000A18700B14D10 AS DateTime), N'DAVID', N'', NULL, CAST(0x0000A19F0100C594 AS DateTime), NULL, 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (28, 8, 66, N'232313', N'KIRUJA', N'GRACE KARAMBU', N'F', CAST(0x0000A19B00B8D5F8 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A19B00B8D5F8 AS DateTime), NULL, NULL, NULL, CAST(0x0000A19F0100CB72 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (29, 8, 67, N'23432', N'KAMAU', N'JOAN', N'F', CAST(0x0000A19C00C2DD8C AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A1AD00C2DD8C AS DateTime), NULL, NULL, NULL, CAST(0x0000A1A001433610 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (30, 8, 69, N'12546', N'HADJI', N'MOHAMMED', N'M', CAST(0x00008806008D7098 AS DateTime), N'0722556565', N'hadji@gmail.com', N'me', N'305 kiserian', N'A    ', N'351       ', N'2016      ', CAST(0x0000A1B5008D7098 AS DateTime), N'KALONZI', N'good', NULL, CAST(0x0000A19F0100E3D4 AS DateTime), NULL, NULL, N'MOHAMUD ABDULIA', N'0717779961', N'0255469874', N'moha@ymail.com', N'SABRINA MWITA MUTIO', N'0722589658', N'0256478965', N'sab@ymail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'baseball', N'drama', N'tabletenniss', NULL, NULL, NULL, NULL, 1, NULL, NULL, 1, 10, 4, N'gracia', N'ulcers', N'white meat pizza soup', N'feeding on sukumawiki dust cold water', NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (31, 8, 56, N'4587', N'MUTIO', N'PETER MAINA', N'M', CAST(0x0000964B009495E4 AS DateTime), N'0722445566', N'pet@gmail', N'www.twitter.com', N'olepoles 654', NULL, N'405       ', NULL, CAST(0x0000964B009495E4 AS DateTime), NULL, N'very good', NULL, CAST(0x0000A19F010F32CE AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (32, 8, 56, N'12564', N'KAMAU', N'SHEILA PERRY', N'M', CAST(0x0000964A00955AC4 AS DateTime), N'0123455', N'm@ymail', N'www.facebook.com', N'pepetu', N'A    ', N'401       ', NULL, CAST(0x0000964B00955AC4 AS DateTime), N'KALONZI', N'good', N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\WinSchool\Resources\SoftwareProvidersLogoImg.jpg', CAST(0x0000A1A001386DBE AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (33, 8, 58, N'12879', N'KATTY', N'RIRI MINAJ', N'F', CAST(0x0000964B00961E78 AS DateTime), N'0245698', N'rm@ymail', N'www.facebook.com', N'ferini', N'A    ', N'398       ', NULL, CAST(0x0000964B00961E78 AS DateTime), N'MWETU', N'capable of doing better than this.', NULL, CAST(0x0000A19F010F4733 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([StudentId], [SchoolId], [CurrentClass], [AdminNo], [StudentSurName], [StudentOtherNames], [Gender], [DateOfBirth], [Phone], [Email], [Homepage], [StudentAddress], [Status], [KCPE], [KCSE], [AdmissionDate], [AdmittedBy], [Remarks], [Photo], [LastModifiedTime], [GLAccount], [CustomerID], [FatherName], [FatherCellPhone], [FatherOfficePhone], [FatherEmail], [MotherName], [MotherCellPhone], [MotherOfficePhone], [MotherEmail], [GuardianName], [GuardianCellPhone], [GuardianOfficePhone], [GuardianEmail], [PrevSchoolId], [PrevSchoolName], [PrevSchoolPhone], [PrevSchoolAddress], [ReasonForLeaving], [ExtraCurricular1], [ExtraCurricular2], [ExtraCurricular3], [Term1MeanGrade], [Term2MeanGrade], [Term3MeanGrade], [Eligible], [RequireTransport], [TransportChargeType], [FeesPayPlan], [Boarder], [ResidenceHallRoomId], [ResidenceId], [DoctorName], [Ailments], [Foods], [Allergies], [HostelName], [BedNo]) VALUES (34, 8, 70, N'12546', N'MWIKALI', N'BILHA WAMBOI', N'F', CAST(0x0000964B00C4C05C AS DateTime), N'07895642123', N'tre', N'www.cu.ke', N'123 peponi', NULL, N'0         ', N'0         ', CAST(0x0000964B00C4C05C AS DateTime), N'MRS.MUTUA', N'a responsible student', NULL, CAST(0x0000A19F010109FC AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
/****** Object:  Table [dbo].[StudentProgresses_Temp]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses_Temp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentProgresses_Temp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Term] [int] NOT NULL,
	[ClassShortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ExamTypeShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TeacherId] [int] NULL,
	[TotalMarks] [float] NULL,
	[TotalPoints] [float] NULL,
	[Position] [int] NULL,
	[MeanMarks] [float] NULL,
	[MeanGrade] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HeadTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_StudentProgresses_Temp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[StudentProgresses_Temp] ON
INSERT [dbo].[StudentProgresses_Temp] ([Id], [StudentId], [Year], [Term], [ClassShortCode], [ExamTypeShortCode], [TeacherId], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark]) VALUES (1, 13, 2012, 1, N'F1 2012', N'MAIN      ', 5, 850, 10, 8, 55, N'B', N'poor', N'poor')
SET IDENTITY_INSERT [dbo].[StudentProgresses_Temp] OFF
/****** Object:  Table [dbo].[DisciplinaryCategories]    Script Date: 04/23/2013 17:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DisciplinaryCategories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DisciplinaryCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_DisciplinaryCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[DisciplinaryCategories] ON
INSERT [dbo].[DisciplinaryCategories] ([Id], [ShortCode], [Description]) VALUES (2, N'LATE      ', N'LATE COMER')
INSERT [dbo].[DisciplinaryCategories] ([Id], [ShortCode], [Description]) VALUES (3, N'SCIVING   ', N'SCIVING OUT OF SCHOOL')
INSERT [dbo].[DisciplinaryCategories] ([Id], [ShortCode], [Description]) VALUES (13, N'TRUANCY   ', N'NOT ATTENDING SCHOOL FOR NO REASON')
SET IDENTITY_INSERT [dbo].[DisciplinaryCategories] OFF
/****** Object:  Table [dbo].[Customers]    Script Date: 04/23/2013 17:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telephone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Branch] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToName] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToAddress] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToTelephone] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BillToEmail] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudentId] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
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
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (1, N'125', N'BARAKA SCHOOL', N'27872, homabay', N'0712345678', N'miriamishimwe@gmail.com', N'19001', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 1)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (2, N'325', N'MATIN  KIPTACH', N'27872, homabay', N'0736876546', N'matotach34@gmail.com', N'35007', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 2)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (3, N'366', N'MATIN  ONYANGO', N'27872, homabay', N'0736876546', N'dfsaj@gmail.com', N'19002', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 4)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (4, N'258', N'KAMAU  TITUS', N'27872, homabay', N'0736876546', N'sadas@yahoo.com', N'20001', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 8)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (5, N'452', N'NDUTA  LUCY', N'27872, homabay', N'0736876546', N'fdsh@gmail.com', N'25002', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 9)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (6, N'145', N'MARANGA  EMILY', N'27872, homabay', N'0736876546', N'masra@yahoo.com', N'35006', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 10)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (7, N'987', N'MOHAMED  ABDUL', N'27872, homabay', N'0736876546', N'dudli@yahoo.com', N'25003', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 11)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (8, N'657', N'WANJIKU  JOAN', N'27872, homabay', N'0736876546', N'jodk@yahoo.com', N'68089', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 12)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (9, N'245', N'MATO OBRA', N'27872, homabay', N'0736876546', N'miriamishimwe@gmail.com', N'42006', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 16)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (10, N'369', N'KEVIN  MATO OBRA', N'27872, homabay', N'0736876546', N'miriamishimwe@gmail.com', N'19006', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 14)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (11, N'587', N'EVELYN AKINYI', N'27872, homabay', N'0736876546', N'miriamishimwe@gmail.com', N'20004', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 13)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (16, N'235', N'KABARE GIRLS', N'27872, homabay', N'0736876546', N'miriamishimwe@gmail.com', N'35000', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 15)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (18, N'149', N'EVELYN AKINYI  OJWANG', N'27872, homabay', N'0736876546', N'eakinyi1@gmail.com', N'19002', N'WANJIKU  JOAN', N'27872, homabay', N'0715269856', N'541fu@gmail.com', 26)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (20, N'26', N'MOHAMMED  HADJI', N'305 kiserian', N'0722556565', N'hadji@gmail.com', N'20003', N'moha', N'kajiado', N'02564123', N'moha@ymail.com', 30)
INSERT [dbo].[Customers] ([CustomerId], [CustomerNo], [Name], [Address], [Telephone], [Email], [Branch], [BillToName], [BillToAddress], [BillToTelephone], [BillToEmail], [StudentId]) VALUES (21, N'15', N'MOHAMMED  HADJI', N'305 kiserian', N'0722556565', N'hadji@gmail.com', N'20003', N'mohamud', N'kajiado', N'0214563652', N'moha@ymail.com', 30)
SET IDENTITY_INSERT [dbo].[Customers] OFF
/****** Object:  Table [dbo].[COA]    Script Date: 04/23/2013 17:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[COALevel] [int] NOT NULL,
	[Parent] [int] NOT NULL,
	[Rorder] [int] NOT NULL,
 CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[COA] ON
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (3, N'ASSET     ', N'ASSET', 1, 0, 1)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (4, N'LIAB      ', N'LIABILITIES', 1, 0, 2)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (6, N'INCOME    ', N'INCOME', 1, 0, 3)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (7, N'EXP       ', N'EXPENSES', 1, 0, 4)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (8, N'CAPITAL   ', N'CAPITAL', 1, 0, 5)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (9, N'FA        ', N'FIXED ASSET', 2, 3, 1)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (10, N'CA        ', N'CURRET ASSET', 2, 3, 2)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (13, N'LTL       ', N'Long Term Liabilities', 2, 4, 1)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (15, N'STL       ', N'Short Term Liabilities', 2, 4, 2)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (16, N'MV        ', N'Motor Vehicle', 3, 9, 1)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (17, N'LND       ', N'Land', 0, 9, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (19, N'OE        ', N'Office Equipment', 0, 9, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (20, N'CASH      ', N'Petty Cash', 0, 10, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (21, N'Bank      ', N'Bank Accounts', 0, 10, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (22, N'EQ        ', N'Equity Account 1', 0, 21, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (23, N'ST        ', N'Standard A/c 1', 0, 21, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (24, N'CSH       ', N'Bursar 1', 0, 20, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (25, N'LN        ', N'Equity Loan', 0, 13, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (26, N'AP        ', N'Account Payable', 0, 15, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (27, N'FO        ', N'Fees Oustanding', 0, 10, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (28, N'EL        ', N'Electricity', 0, 26, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (29, N'WT        ', N'Water', 0, 26, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (30, N'INP       ', N'Interest Payable', 0, 26, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (31, N'UN        ', N'Unga Supplier', 0, 26, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (32, N'Fees      ', N'Fees Income', 0, 6, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (33, N'TU        ', N'Tuition Fees', 0, 32, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (34, N'LB        ', N'Library Fees', 0, 32, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (35, N'TR        ', N'Transport Fees', 0, 32, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (36, N'BF        ', N'Boarding Fees', 0, 32, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (37, N'OI        ', N'Other Income', 0, 6, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (38, N'GH        ', N'Green House Sales', 0, 37, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (39, N'AE        ', N'Administrative Expenses', 0, 7, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (40, N'FE        ', N'Financial Expenses', 0, 7, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (41, N'ME        ', N'Marketing Expenses', 0, 7, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (42, N'ACE       ', N'Academic Expenses', 0, 7, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (43, N'OE        ', N'Owners Equity', 0, 8, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (44, N'RE        ', N'Retained Earnings', 0, 8, 0)
INSERT [dbo].[COA] ([Id], [ShortCode], [Description], [COALevel], [Parent], [Rorder]) VALUES (46, N'OF        ', N'Other Fees', 0, 32, 0)
SET IDENTITY_INSERT [dbo].[COA] OFF
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 04/23/2013 17:16:31 ******/
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
 CONSTRAINT [PK_ChartofAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[AccountTypes] ON
INSERT [dbo].[AccountTypes] ([Id], [ShortCode], [Description]) VALUES (1, N'INT       ', N'Internal Account')
SET IDENTITY_INSERT [dbo].[AccountTypes] OFF
/****** Object:  Table [dbo].[ClassStreams]    Script Date: 04/23/2013 17:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassStreams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassStreams](
	[ClassStreamId] [int] IDENTITY(1,1) NOT NULL,
	[SchoolClass] [int] NOT NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ClassStreams] PRIMARY KEY CLUSTERED 
(
	[ClassStreamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[ClassStreams] ON
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (56, 1, N'1A')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (57, 1, N'1B')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (58, 1, N'1C')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (59, 1, N'1D')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (61, 2, N'2B')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (62, 2, N'2C')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (64, 2, N'2D')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (65, 2, N'2A')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (66, 4, N'4A')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (67, 4, N'4B')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (68, 4, N'4C')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (69, 4, N'4D')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (70, 3, N'3A')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (71, 3, N'3B')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (72, 3, N'3C')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (73, 3, N'3D')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (74, 3, N'3E')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (75, 3, N'3F')
INSERT [dbo].[ClassStreams] ([ClassStreamId], [SchoolClass], [Description]) VALUES (80, 1, N'1E')
SET IDENTITY_INSERT [dbo].[ClassStreams] OFF
/****** Object:  Table [dbo].[Banks]    Script Date: 04/23/2013 17:16:31 ******/
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
INSERT [dbo].[Banks] ([BankCode], [BankName]) VALUES (N'232', N'wdwwd')
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
/****** Object:  Table [dbo].[FeesStructure]    Script Date: 04/23/2013 17:16:31 ******/
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
 CONSTRAINT [PK_FeesStructure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[FeesStructure] ON
INSERT [dbo].[FeesStructure] ([Id], [Description], [Year]) VALUES (1, N'Fees Year 2013', 2013)
INSERT [dbo].[FeesStructure] ([Id], [Description], [Year]) VALUES (2, N'Fees Year 2012', 2012)
SET IDENTITY_INSERT [dbo].[FeesStructure] OFF
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 04/23/2013 17:16:31 ******/
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
	[PercentageContribution] [int] NULL,
 CONSTRAINT [PK_ExamTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[ExamTypes] ON
INSERT [dbo].[ExamTypes] ([Id], [ShortCode], [Description], [ROrder], [PercentageContribution]) VALUES (1, N'MAIN ', N'MAIN EXAM', 1, 10)
INSERT [dbo].[ExamTypes] ([Id], [ShortCode], [Description], [ROrder], [PercentageContribution]) VALUES (2, N'MID  ', N'MID TERM EXAM', 1, 20)
INSERT [dbo].[ExamTypes] ([Id], [ShortCode], [Description], [ROrder], [PercentageContribution]) VALUES (3, N'CAT1 ', N'CONTINOUS ASSESSMENT TEST 1', 1, 30)
INSERT [dbo].[ExamTypes] ([Id], [ShortCode], [Description], [ROrder], [PercentageContribution]) VALUES (4, N'CAT2 ', N'CONTINOUS ASSESSMENT TEST 2', 3, 30)
INSERT [dbo].[ExamTypes] ([Id], [ShortCode], [Description], [ROrder], [PercentageContribution]) VALUES (8, N'CAT3 ', N'CONTINOUS ASSESSMENT TEST 3', 1, 60)
INSERT [dbo].[ExamTypes] ([Id], [ShortCode], [Description], [ROrder], [PercentageContribution]) VALUES (9, N'OPEN ', N'OPENING TERM EXAM', 4, 60)
INSERT [dbo].[ExamTypes] ([Id], [ShortCode], [Description], [ROrder], [PercentageContribution]) VALUES (10, N'CLOSE', N'CLOSING TERM EXAM', 3, 30)
INSERT [dbo].[ExamTypes] ([Id], [ShortCode], [Description], [ROrder], [PercentageContribution]) VALUES (11, N'CAT4 ', N'CONTINOUS ASSESSMENT TEST 4', 1, 40)
SET IDENTITY_INSERT [dbo].[ExamTypes] OFF
/****** Object:  Table [dbo].[ExamPeriod]    Script Date: 04/23/2013 17:16:31 ******/
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
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[ExamPeriodId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[ExamPeriod] ON
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (3, 2012, 1, N'2012-1', N'A         ', CAST(0x0000A19200D5309F AS DateTime), CAST(0x0000A19200D5309F AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (4, 2011, 1, N'2011-1', N'A         ', CAST(0x0000A1810148BD39 AS DateTime), CAST(0x0000A1810148BD39 AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (7, 2011, 2, N'2011-2', N'A         ', CAST(0x0000A18101499731 AS DateTime), CAST(0x0000A18101499731 AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (8, 2011, 3, N'2011-3', N'A         ', CAST(0x0000A181014A3194 AS DateTime), CAST(0x0000A181014A3193 AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (9, 2012, 2, N'2012-2', N'A         ', CAST(0x0000A181014A4AEB AS DateTime), CAST(0x0000A181014A4AEB AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (10, 2012, 3, N'2012-3', N'A         ', CAST(0x0000A181014A5E1F AS DateTime), CAST(0x0000A181014A5E1F AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (11, 2013, 1, N'2013-1', N'A         ', CAST(0x0000A19200AE7BE0 AS DateTime), CAST(0x0000A19200AE7BDF AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (12, 2013, 2, N'2013-2', N'A         ', CAST(0x0000A19200D1F0F4 AS DateTime), CAST(0x0000A19200D1F0F4 AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (13, 2013, 3, N'2013-3', N'A         ', CAST(0x0000964C00502024 AS DateTime), CAST(0x0000964C00502023 AS DateTime))
INSERT [dbo].[ExamPeriod] ([ExamPeriodId], [Year], [Term], [Description], [Status], [StartDate], [EndDate]) VALUES (14, 2013, 4, N'2013-4', N'A         ', CAST(0x0000A1B10080163C AS DateTime), CAST(0x0000A20D0080163C AS DateTime))
SET IDENTITY_INSERT [dbo].[ExamPeriod] OFF
/****** Object:  Table [dbo].[Programmes]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programmes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Programmes](
	[ProgrammeId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Hours] [int] NULL,
	[Fees] [money] NULL,
 CONSTRAINT [PK_Programmes] PRIMARY KEY CLUSTERED 
(
	[ProgrammeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[Programmes] ([ProgrammeId], [Description], [Hours], [Fees]) VALUES (N'KSCE      ', N'KENYA CERTIFICATE OF SECONDARY EDUCATION', 1500, 27000.0000)
/****** Object:  Table [dbo].[Parents]    Script Date: 04/23/2013 17:16:32 ******/
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
 CONSTRAINT [PK_Parents] PRIMARY KEY CLUSTERED 
(
	[ParentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Parents] ON
INSERT [dbo].[Parents] ([ParentId], [Name], [Gender], [CellPhoneNo], [Email], [Occupation], [Maritalstatus], [Relationship]) VALUES (1, N'nicholas kiogora', N'M', N'0717856985', N'nikko@gmail.com', N'hustler', N'D', N'brother')
INSERT [dbo].[Parents] ([ParentId], [Name], [Gender], [CellPhoneNo], [Email], [Occupation], [Maritalstatus], [Relationship]) VALUES (3, N'miriam kyende', N'F', N'0713586958', N'mkyende@yahoo.com', N'mboch', N'S', N'sister')
SET IDENTITY_INSERT [dbo].[Parents] OFF
/****** Object:  Table [dbo].[MarkSheetStudents]    Script Date: 04/23/2013 17:16:32 ******/
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
/****** Object:  Table [dbo].[MarkSheetExams]    Script Date: 04/23/2013 17:16:32 ******/
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
/****** Object:  Table [dbo].[MarksheetArchives]    Script Date: 04/23/2013 17:16:32 ******/
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
/****** Object:  Table [dbo].[Locations]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent] [int] NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TransportCost] [money] NULL,
	[BoardingCost] [money] NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Locations] ON
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (1, 0, N'Kenya', 1000.0000, 77777.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (2, 1, N'Rift Valley', 77777.0000, 54645.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (4, 2, N'Kajiado', 77777.0000, 54645.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (5, 4, N'Birika', 54645.0000, 54645.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (6, 5, N'Baraka School', 54645.0000, 77777.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (7, 6, N'St Lucy Dorm', 54645.0000, 54645.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (8, 6, N'St Agnes Dorm', 54645.0000, 54645.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (9, 6, N'St Maria Dorm', 54645.0000, 77777.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (28, 6, N'St Jude Dorm', 7800.0000, 5200.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (29, 1, N'Nairobi', 8500.0000, 14000.0000)
INSERT [dbo].[Locations] ([Id], [Parent], [Description], [TransportCost], [BoardingCost]) VALUES (30, 29, N'Kiserian', 800.0000, 4500.0000)
SET IDENTITY_INSERT [dbo].[Locations] OFF
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserRoles](
	[RoleId] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleName] [nchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[UserRoles] ([RoleId], [RoleName]) VALUES (N'AD', N'ADMINISTRATOR  ')
INSERT [dbo].[UserRoles] ([RoleId], [RoleName]) VALUES (N'BS', N'BURSAR         ')
INSERT [dbo].[UserRoles] ([RoleId], [RoleName]) VALUES (N'PR', N'PRINCIPAL      ')
INSERT [dbo].[UserRoles] ([RoleId], [RoleName]) VALUES (N'TC', N'TEACHER        ')
/****** Object:  Table [dbo].[Transport]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transport]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Transport](
	[TransportId] [int] IDENTITY(1,1) NOT NULL,
	[ResidenceId] [int] NOT NULL,
	[Amount] [money] NOT NULL,
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[TransportId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Transport] ON
INSERT [dbo].[Transport] ([TransportId], [ResidenceId], [Amount]) VALUES (1, 1, 55454.0000)
INSERT [dbo].[Transport] ([TransportId], [ResidenceId], [Amount]) VALUES (4, 1, 65465.0000)
INSERT [dbo].[Transport] ([TransportId], [ResidenceId], [Amount]) VALUES (5, 3, 25166.0000)
INSERT [dbo].[Transport] ([TransportId], [ResidenceId], [Amount]) VALUES (6, 4, 40000.0000)
SET IDENTITY_INSERT [dbo].[Transport] OFF
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 04/23/2013 17:16:33 ******/
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
	[DefaultCreditNarrative] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultDebitNarrative] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TxnTypeView] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CommissionType] [char](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FlatRate] [decimal](18, 0) NULL,
	[PercentageRate] [float] NULL,
	[DialogFlag] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ForcePost] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] ON
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [DebitCredit], [ShortCode], [Description], [DefaultAmount], [DefaultCreditAccount], [DefaultDebitAccount], [DefaultCreditNarrative], [DefaultDebitNarrative], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [ForcePost]) VALUES (1, N'D', N'WD', N'WithDrawal', CAST(12000.0000 AS Decimal(19, 4)), 1, 2, N'credit this account', N'debit this account', N'1', N'TU', CAST(1 AS Decimal(18, 0)), 1, N'1', N'1')
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [DebitCredit], [ShortCode], [Description], [DefaultAmount], [DefaultCreditAccount], [DefaultDebitAccount], [DefaultCreditNarrative], [DefaultDebitNarrative], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [ForcePost]) VALUES (2, N'C', N'DP', N'Deposit', CAST(10000.0000 AS Decimal(19, 4)), 2, 3, N'credit this account', N'debit this account', N'1', N'EX', CAST(1 AS Decimal(18, 0)), 1, N'1', N'1')
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [DebitCredit], [ShortCode], [Description], [DefaultAmount], [DefaultCreditAccount], [DefaultDebitAccount], [DefaultCreditNarrative], [DefaultDebitNarrative], [TxnTypeView], [CommissionType], [FlatRate], [PercentageRate], [DialogFlag], [ForcePost]) VALUES (3, N'D', N'CF', N'Charge Fees', CAST(36000.0000 AS Decimal(19, 4)), 1, 3, N'credit this account', N'debit this account', N'1', N'TU', CAST(1 AS Decimal(18, 0)), 1, N'1', N'1')
SET IDENTITY_INSERT [dbo].[TransactionTypes] OFF
/****** Object:  Table [dbo].[Subjects]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Subjects](
	[ShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OutOf] [int] NULL,
	[PassMark] [int] NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ROrder] [int] NULL,
	[Remarks] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NoOfRequiredHours] [int] NULL,
	[Fees] [money] NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[ShortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'AGR', N'AGRICULTURE', 100, 50, N'A         ', 10, N'1', 7, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'BIO', N'BIOLOGY', 100, 50, N'A         ', 4, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'BS', N'BUSINESS STUDIES', 100, 50, N'A         ', 12, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'CALC', N'CALCULUS', 100, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'CHEM', N'CHEMISTRY', 100, 50, N'A         ', 6, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'COM SKILL', N'HRD 2101 COMMUNICATION SKILLS', 95, 70, N'A         ', 1, N'1', 200, 6900.0000)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'COMM', N'COMMUNICATION', 100, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'COMP', N'COMPUTER STUDIES', 100, 50, N'A         ', 11, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'COMSYSORG', N'BIT 2102 COMPUTER SYSTEMS AND ORGANIZATION', 85, 60, N'A         ', 1, N'1', 160, 6500.0000)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'CRE', N'CHRISTIAN RELIGIOUS EDUCATION', 100, 50, N'A         ', 9, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'ENG', N'ENGLISH', 100, 50, N'A         ', 1, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'FM', N'FINANCE MANAGEMENT', 100, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'GEO', N'GEOGRAPHY', 100, 50, N'A         ', 8, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'HIST', N'HISTORY', 100, 50, N'A         ', 7, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'HIV/AID', N'SZL 2111 HIV/AIDS', 60, 45, N'A         ', 1, N'1', 150, 5050.0000)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'HSC', N'HOME SCIENCE', 100, 50, N'A         ', 14, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'KISW', N'KISWAHILI', 100, 50, N'A         ', 2, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'MATH', N'MATHEMATICS', 100, 50, N'A         ', 3, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'MUSIC', N'MUSIC', 100, 50, N'A         ', 13, N'', NULL, NULL)
INSERT [dbo].[Subjects] ([ShortCode], [Description], [OutOf], [PassMark], [Status], [ROrder], [Remarks], [NoOfRequiredHours], [Fees]) VALUES (N'PHYS', N'PHYSICS', 100, 50, N'A         ', 5, N'', NULL, NULL)
/****** Object:  Table [dbo].[StudentSubjectTagets]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentSubjectTagets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentSubjectTagets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[SubjectShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Target] [float] NULL,
 CONSTRAINT [PK_StudentSubjectTagets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[TimeTableDets]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeTableDets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TimeTableDets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeTableId] [int] NOT NULL,
	[SubjectId] [int] NULL,
	[RoomId] [int] NULL,
	[Recurrent] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Activity] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Venue] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Text] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[A] [int] NOT NULL,
	[R] [int] NOT NULL,
	[G] [int] NOT NULL,
	[B] [int] NOT NULL,
 CONSTRAINT [PK_TimeTableDets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teachers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IDNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TSCNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Position] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
INSERT [dbo].[Teachers] ([TeacherId], [Name], [IDNo], [TSCNo], [Position], [Email], [Status], [DateJoined], [DateLeft]) VALUES (1, N'NICK SUBATA', N'28282933', N'101', N'HEAD OF DEPARTMENT', N'nicksubata@gmail.com', N'A         ', CAST(0x0000A15B00F87778 AS DateTime), CAST(0x0000A15B00F87778 AS DateTime))
INSERT [dbo].[Teachers] ([TeacherId], [Name], [IDNo], [TSCNo], [Position], [Email], [Status], [DateJoined], [DateLeft]) VALUES (2, N'RUTH KYENDE', N'46476345', N'102', N'HEAD OF DEPARTMENT', N'ruthkyende@gmail.com', N'A         ', CAST(0x0000A15B00F8BBD2 AS DateTime), CAST(0x0000A15B00F8BBD2 AS DateTime))
INSERT [dbo].[Teachers] ([TeacherId], [Name], [IDNo], [TSCNo], [Position], [Email], [Status], [DateJoined], [DateLeft]) VALUES (4, N'MATIN BARAZA', N'78889374', N'103', N'HEAD TEACHER', N'mato39@gmail.com', N'A         ', CAST(0x0000A165001FD365 AS DateTime), CAST(0x0000A16700A0C221 AS DateTime))
INSERT [dbo].[Teachers] ([TeacherId], [Name], [IDNo], [TSCNo], [Position], [Email], [Status], [DateJoined], [DateLeft]) VALUES (5, N'SUSAN SHIKU', N'324234423', N'104', N'DEPUTY HEADTEACHER', N'susan21@yahoo.com', N'A         ', CAST(0x0000A1620020862C AS DateTime), CAST(0x0000A16700A11B0A AS DateTime))
INSERT [dbo].[Teachers] ([TeacherId], [Name], [IDNo], [TSCNo], [Position], [Email], [Status], [DateJoined], [DateLeft]) VALUES (10, N'KEVIN OBRA', N'434898347', N'105', N'HEAD OF DEPARTMENT', NULL, NULL, CAST(0x0000A16A00AF46AB AS DateTime), NULL)
INSERT [dbo].[Teachers] ([TeacherId], [Name], [IDNo], [TSCNo], [Position], [Email], [Status], [DateJoined], [DateLeft]) VALUES (14, N'MARY ANNE NUTHU', N'408876543', N'232', N'class teacher', N'maryanne@gmail.com', N'A         ', CAST(0x0000A17201250576 AS DateTime), CAST(0x0000A18400DC0257 AS DateTime))
SET IDENTITY_INSERT [dbo].[Teachers] OFF
/****** Object:  Table [dbo].[SubSubjects]    Script Date: 04/23/2013 17:16:33 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 04/23/2013 17:16:33 ******/
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
/****** Object:  Table [dbo].[TimeTables]    Script Date: 04/23/2013 17:16:33 ******/
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
/****** Object:  Table [dbo].[LocationProperties]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocationProperties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LocationProperties](
	[LocKey] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LocValue] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LocValueType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_LocationProperties] PRIMARY KEY CLUSTERED 
(
	[LocKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[LocationProperties] ([LocKey], [LocValue], [LocValueType], [Description], [LocationId]) VALUES (N'BEDS', N'63', N'N', N'Number of Beds', 7)
INSERT [dbo].[LocationProperties] ([LocKey], [LocValue], [LocValueType], [Description], [LocationId]) VALUES (N'PREFECT', N'Joan Mutio', N'S', N'Prefect', 7)
/****** Object:  Table [dbo].[Exam]    Script Date: 04/23/2013 17:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exam]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Exam](
	[ExamId] [int] IDENTITY(1,1) NOT NULL,
	[ExamPeriodId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[SubjectShortCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Enabled] [bit] NOT NULL,
	[Closed] [bit] NOT NULL,
 CONSTRAINT [PK_ExamPeriods] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Exam] ON
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (32, 3, 1, N'AGR', CAST(0x0000A19200DD125D AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (33, 3, 1, N'BIO', CAST(0x0000A19200DD19C8 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (34, 3, 1, N'BS', CAST(0x0000A19200DD2189 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (35, 3, 1, N'CALC', CAST(0x0000A19200DD2A9F AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (36, 3, 1, N'CRE', CAST(0x0000A19200DD3335 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (37, 3, 2, N'AGR', CAST(0x0000A19200DD458B AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (38, 3, 2, N'BIO', CAST(0x0000A19200DD4EAA AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (39, 3, 2, N'CHEM', CAST(0x0000A19200DD57C4 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (40, 3, 2, N'CRE', CAST(0x0000A19200DD5F01 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (41, 3, 3, N'AGR', CAST(0x0000A19200DD6DA5 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (42, 3, 3, N'BIO', CAST(0x0000A19200DD756D AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (43, 3, 3, N'BS', CAST(0x0000A19200DD8772 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (44, 3, 4, N'COMM', CAST(0x0000964C00600B0A AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (45, 3, 4, N'CRE', CAST(0x0000964C00603730 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (46, 3, 2, N'GEO', CAST(0x0000A19C00FABA1B AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (47, 3, 2, N'COM SKILL', CAST(0x0000A19C00FAC4DD AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (48, 3, 2, N'KISW', CAST(0x0000A19C00FADB1A AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (49, 3, 4, N'FM', CAST(0x0000A19C00FBFACD AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (50, 3, 4, N'COM SKILL', CAST(0x0000A19C00FC0B89 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (51, 3, 4, N'AGR', CAST(0x0000A19C00FC199B AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (52, 3, 3, N'COMSYSORG', CAST(0x0000A19C00FD4592 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (53, 3, 3, N'HIST', CAST(0x0000A19C00FD6563 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (54, 3, 3, N'MATH', CAST(0x0000A19C00FD7189 AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (55, 9, 1, N'CALC', CAST(0x0000A19C01095BD5 AS DateTime), N'sys', 0, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (56, 13, 1, N'BIO', CAST(0x0000A19C01098C7E AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (57, 13, 4, N'CRE', CAST(0x0000A19C0109AADA AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (62, 4, 1, N'AGR', CAST(0x0000A1A200F146DD AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (63, 4, 1, N'BIO', CAST(0x0000A1A200F1536F AS DateTime), N'sys', 1, 0)
INSERT [dbo].[Exam] ([ExamId], [ExamPeriodId], [ClassId], [SubjectShortCode], [LastModified], [ModifiedBy], [Enabled], [Closed]) VALUES (64, 4, 1, N'BS', CAST(0x0000A1A200F15D8B AS DateTime), N'sys', 1, 0)
SET IDENTITY_INSERT [dbo].[Exam] OFF
/****** Object:  Table [dbo].[Discipline]    Script Date: 04/23/2013 17:16:31 ******/
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
	[Severity] [int] NOT NULL,
	[ActionRecommended] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ActionTaken] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DisciplineRating] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Review] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Discipline] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Discipline] ON
INSERT [dbo].[Discipline] ([Id], [StudentId], [DisciplineCategoryId], [DisciplinaryDate], [Incident], [Severity], [ActionRecommended], [ActionTaken], [DisciplineRating], [Review]) VALUES (19, 25, 2, CAST(0xF6360B00 AS Date), N'late for cat 1 biology paper', 0, N'does not sit for cat 1 biology', N'does not sit forcat 1 biology', N'1', N'1')
INSERT [dbo].[Discipline] ([Id], [StudentId], [DisciplineCategoryId], [DisciplinaryDate], [Incident], [Severity], [ActionRecommended], [ActionTaken], [DisciplineRating], [Review]) VALUES (20, 25, 3, CAST(0xF6360B00 AS Date), N'caught sneaking out of school at night', 0, N'suspension for 2 weeks', N'suspended for 2 weeks', N'0.5', N'1')
INSERT [dbo].[Discipline] ([Id], [StudentId], [DisciplineCategoryId], [DisciplinaryDate], [Incident], [Severity], [ActionRecommended], [ActionTaken], [DisciplineRating], [Review]) VALUES (22, 26, 13, CAST(0xFB360B00 AS Date), N'3333333333333333333333333333333333333333', 0, N'11111111111111', N'33333333333333333333', N'111111111111111111', N'1111111111111111111')
INSERT [dbo].[Discipline] ([Id], [StudentId], [DisciplineCategoryId], [DisciplinaryDate], [Incident], [Severity], [ActionRecommended], [ActionTaken], [DisciplineRating], [Review]) VALUES (24, 13, 2, CAST(0xFB360B00 AS Date), N'came late for cre lesson', 0, N'clean the whole dinning hall', N'clean the whole dinning hall', N'1', N'1')
INSERT [dbo].[Discipline] ([Id], [StudentId], [DisciplineCategoryId], [DisciplinaryDate], [Incident], [Severity], [ActionRecommended], [ActionTaken], [DisciplineRating], [Review]) VALUES (25, 13, 3, CAST(0xFB360B00 AS Date), N'caught sneaking out of the school at night', 0, N'suspension for two weeks', N'suspended for two weeks and on reporting back to report with guardin', N'2', N'3')
INSERT [dbo].[Discipline] ([Id], [StudentId], [DisciplineCategoryId], [DisciplinaryDate], [Incident], [Severity], [ActionRecommended], [ActionTaken], [DisciplineRating], [Review]) VALUES (26, 14, 2, CAST(0xFB360B00 AS Date), N'late for music lesson', 0, N'clean dormitory for 1 week', N'cleaned the batian dormitory for one wewek', N'3', N'4')
SET IDENTITY_INSERT [dbo].[Discipline] OFF
/****** Object:  Table [dbo].[BankBranches]    Script Date: 04/23/2013 17:16:31 ******/
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
 CONSTRAINT [PK_BankBranch] PRIMARY KEY CLUSTERED 
(
	[BankSortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01095', N'095', N'01', N'Wote')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01100', N'100', N'01', N'Moi Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01102', N'102', N'01', N'Treasury Square')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01103', N'103', N'01', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01104', N'104', N'01', N'KICC')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01105', N'105', N'01', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01106', N'106', N'01', N'Kericho')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01107', N'107', N'01', N'Tom Mboya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01108', N'108', N'01', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01109', N'109', N'01', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01110', N'110', N'01', N'Kakamega')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01111', N'111', N'01', N'Kilindini')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01113', N'113', N'01', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01114', N'114', N'01', N'River Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01115', N'115', N'01', N'Muranga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01116', N'116', N'01', N'Embu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01117', N'117', N'01', N'Kangema')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01119', N'119', N'01', N'Kiambu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01120', N'120', N'01', N'Karatina')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01121', N'121', N'01', N'Siaya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01122', N'122', N'01', N'Nyahururu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01123', N'123', N'01', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01124', N'124', N'01', N'Mumias')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01125', N'125', N'01', N'Nanyuki')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01127', N'127', N'01', N'Moyale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01129', N'129', N'01', N'Kikuyu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01130', N'130', N'01', N'Tala')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01131', N'131', N'01', N'Kajiado')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01133', N'133', N'01', N'Custody Services')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01134', N'134', N'01', N'Matuu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01135', N'135', N'01', N'Kitui')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01136', N'136', N'01', N'Mvita')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01137', N'137', N'01', N'Jogoo Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01140', N'140', N'01', N'Marsabit')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01141', N'141', N'01', N'Sarit Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01142', N'142', N'01', N'Loitokitok')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01143', N'143', N'01', N'Nandi Hills')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01144', N'144', N'01', N'Lodwar')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01145', N'145', N'01', N'UN Gigiri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01146', N'146', N'01', N'Hola')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01147', N'147', N'01', N'Ruiru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01148', N'148', N'01', N'Mwingi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01149', N'149', N'01', N'Kitale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01150', N'150', N'01', N'Mandera')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01151', N'151', N'01', N'Kapenguria')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01152', N'152', N'01', N'Kabarnet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01153', N'153', N'01', N'Wajir')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01154', N'154', N'01', N'Maralal')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01155', N'155', N'01', N'Limuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01157', N'157', N'01', N'Ukunda')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01161', N'161', N'01', N'Ongata Rongai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01162', N'162', N'01', N'Kitengela')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01163', N'163', N'01', N'Eldama Ravine')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01164', N'164', N'01', N'Kibwezi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01166', N'166', N'01', N'Kapsabet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01167', N'167', N'01', N'University Way')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01168', N'168', N'01', N'Eldoret West')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01169', N'169', N'01', N'Garissa ')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01173', N'173', N'01', N'Lamu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01174', N'174', N'01', N'Kilifi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01175', N'175', N'01', N'Milimani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01176', N'176', N'01', N'Nyamira')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01177', N'177', N'01', N'Mukurwe-ini')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01180', N'180', N'01', N'Village Market')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01181', N'181', N'01', N'Bomet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01183', N'183', N'01', N'Mbale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01184', N'184', N'01', N'Narok')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01185', N'158', N'01', N'Iten')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01186', N'186', N'01', N'Voi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01188', N'188', N'01', N'Webuye')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01189', N'159', N'01', N'Gilgil')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01190', N'190', N'01', N'Naivasha')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01191', N'191', N'01', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01192', N'192', N'01', N'Migori')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01193', N'193', N'01', N'Githunguri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01194', N'194', N'01', N'Machakos')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01195', N'195', N'01', N'Kerugoya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01196', N'196', N'01', N'Chuka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01197', N'197', N'01', N'Bungoma')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01198', N'198', N'01', N'Wundanyi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01199', N'199', N'01', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01201', N'201', N'01', N'Capital Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01202', N'202', N'01', N'Karen')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01203', N'203', N'01', N'Lokichogio')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01204', N'204', N'01', N'Gateway')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01205', N'205', N'01', N'Buruburu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01206', N'206', N'01', N'Chogoria')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01207', N'207', N'01', N'Kangari')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01208', N'208', N'01', N'Kianyaga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01209', N'209', N'01', N'Nkubu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01210', N'210', N'01', N'Ol Kalou')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01211', N'211', N'01', N'Makuyu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01212', N'212', N'01', N'Mwea')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01213', N'213', N'01', N'Njabini')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01214', N'214', N'01', N'Gatundu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01215', N'215', N'01', N'Emali')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01216', N'216', N'01', N'Isiolo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01217', N'217', N'01', N'Flamingo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01218', N'218', N'01', N'Njoro')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01219', N'219', N'01', N'Mutomo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01220', N'220', N'01', N'Mariakani')
GO
print 'Processed 100 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01221', N'221', N'01', N'Mpeketoni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01222', N'222', N'01', N'Mtito Andei')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01223', N'223', N'01', N'Mtwapa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01224', N'224', N'01', N'Taveta')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01225', N'225', N'01', N'Kengeleni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01226', N'226', N'01', N'Garsen')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01227', N'227', N'01', N'Watamu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01228', N'228', N'01', N'Bondo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01229', N'229', N'01', N'Busia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01230', N'230', N'01', N'Homa Bay')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01231', N'231', N'01', N'Kapsowar')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01232', N'232', N'01', N'Kehancha')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01233', N'233', N'01', N'Keroka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01234', N'234', N'01', N'Kilgoris')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01235', N'235', N'01', N'Kimilili')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01236', N'236', N'01', N'Litein')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01237', N'237', N'01', N'Londiani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01238', N'238', N'01', N'Luanda')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01239', N'239', N'01', N'Malaba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01240', N'240', N'01', N'Muhoroni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01241', N'241', N'01', N'Oyugis')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01242', N'242', N'01', N'Ugunja')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01243', N'243', N'01', N'United Mall')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01244', N'244', N'01', N'Serem')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01245', N'245', N'01', N'Sondu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01246', N'246', N'01', N'Kisumu West')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01247', N'247', N'01', N'Marigat')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01248', N'248', N'01', N'Moi''s Bridge')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01249', N'249', N'01', N'Mashariki')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01250', N'250', N'01', N'Naro Moru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01251', N'251', N'01', N'Kiriaini')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01252', N'252', N'01', N'Egerton University')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01253', N'253', N'01', N'Maua')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01254', N'254', N'01', N'Kawangware')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01255', N'255', N'01', N'Kimathi Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01256', N'256', N'01', N'Namanga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01257', N'257', N'01', N'Gikomba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01258', N'258', N'01', N'Kwale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01259', N'259', N'01', N'Prestige Plaza')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01260', N'260', N'01', N'Kariobangi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01263', N'263', N'01', N'Biashara Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01266', N'266', N'01', N'Ngara')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01267', N'267', N'01', N'Kyuso')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01270', N'270', N'01', N'Masii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01271', N'271', N'01', N'Menengai Crater')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01272', N'272', N'01', N'Town Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01278', N'278', N'01', N'Makindu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01283', N'283', N'01', N'Rongo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01284', N'284', N'01', N'Isibania')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01285', N'285', N'01', N'Kiserian')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01286', N'286', N'01', N'Mwembe Tayari')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01287', N'287', N'01', N'Kisauni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01288', N'288', N'01', N'Haile Selassie')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01289', N'289', N'01', N'Mama Ngina')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01290', N'290', N'01', N'Garden Plaza')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01291', N'291', N'01', N'Sarit Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01292', N'292', N'01', N'CPC Bulk Corporate Chqs')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'01293', N'293', N'01', N'Trade Services')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02000', N'000', N'02', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02001', N'001', N'02', N'Kericho')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02002', N'002', N'02', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02003', N'003', N'02', N'Kitale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02004', N'004', N'02', N'Treasury Square')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02005', N'005', N'02', N'Maritime')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02006', N'006', N'02', N'Kenyatta')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02007', N'007', N'02', N'Kimathi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02008', N'008', N'02', N'Moi Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02009', N'009', N'02', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02010', N'010', N'02', N'Nanyuki')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02011', N'011', N'02', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02012', N'012', N'02', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02015', N'015', N'02', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02016', N'016', N'02', N'Machakos')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02017', N'017', N'02', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02019', N'019', N'02', N'Harambee')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02020', N'020', N'02', N'Kiambu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02053', N'053', N'02', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02054', N'054', N'02', N'Kakamega')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02060', N'060', N'02', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02063', N'063', N'02', N'Haile Selassie')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02064', N'064', N'02', N'Koinange Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02071', N'071', N'02', N'Yaya Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02072', N'072', N'02', N'Ruaraka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02074', N'074', N'02', N'Langata')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02075', N'075', N'02', N'Makupa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02076', N'076', N'02', N'Karen')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02077', N'077', N'02', N'Muthaiga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02078', N'078', N'02', N'Customer Service Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02079', N'079', N'02', N'Customer Service Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02080', N'080', N'02', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02081', N'081', N'02', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02082', N'082', N'02', N'Uper Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02083', N'083', N'02', N'Mombasa-Nyali')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'02084', N'084', N'02', N'Chiromo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03002', N'002', N'03', N'Kapsabet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03003', N'003', N'03', N'Eldoret Std & Prestige')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03004', N'004', N'03', N'Embu Std & Prestige')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03005', N'005', N'03', N'Murang''a')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03006', N'006', N'03', N'Kapenguria')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03007', N'007', N'03', N'Kericho')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03008', N'008', N'03', N'Kisii')
GO
print 'Processed 200 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03009', N'009', N'03', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03010', N'010', N'03', N'South C')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03011', N'011', N'03', N'Limuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03012', N'012', N'03', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03013', N'013', N'03', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03014', N'014', N'03', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03015', N'015', N'03', N'Kitui')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03016', N'016', N'03', N'Nkrumah Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03017', N'017', N'03', N'Garissa ')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03018', N'018', N'03', N'Nyamira')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03019', N'019', N'03', N'Kilifi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03020', N'020', N'03', N'Waiyaki Way')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03023', N'023', N'03', N'Gilgil')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03024', N'024', N'03', N'Githurai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03027', N'027', N'03', N'Nakuru East')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03028', N'028', N'03', N'Buruburu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03029', N'029', N'03', N'Bomet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03030', N'030', N'03', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03031', N'031', N'03', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03032', N'032', N'03', N'Port Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03033', N'033', N'03', N'Gikomba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03034', N'034', N'03', N'Kawangware')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03035', N'035', N'03', N'Mbale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03036', N'036', N'03', N'Plaza Premier Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03037', N'037', N'03', N'River Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03038', N'038', N'03', N'Upper River Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03039', N'039', N'03', N'Mumias')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03040', N'040', N'03', N'Machakos')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03042', N'042', N'03', N'Isiolo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03043', N'043', N'03', N'Ngong')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03044', N'044', N'03', N'Maua')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03045', N'045', N'03', N'Hurlingham')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03046', N'046', N'03', N'Makupa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03047', N'047', N'03', N'Development Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03049', N'049', N'03', N'Lavington')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03050', N'050', N'03', N'Eastleigh II')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03051', N'051', N'03', N'Homa Bay')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03052', N'052', N'03', N'Rongai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03053', N'053', N'03', N'Othaya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03054', N'054', N'03', N'Voi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03055', N'055', N'03', N'Muthaiga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03057', N'057', N'03', N'Githunguri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03058', N'058', N'03', N'Webuye')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03060', N'060', N'03', N'Chuka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03061', N'061', N'03', N'Nakumatt Westgate')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03062', N'062', N'03', N'Kabarnet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03063', N'063', N'03', N'Kerugoya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03064', N'064', N'03', N'Taveta')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03065', N'065', N'03', N'Karen Std&Prestige')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03066', N'066', N'03', N'Wundanyi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03067', N'067', N'03', N'Ruaraka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03069', N'069', N'03', N'Wote')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03070', N'070', N'03', N'Enterprise prestige centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03071', N'071', N'03', N'Nakumatt Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03072', N'072', N'03', N'Juja')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03073', N'073', N'03', N'ABC Prestige')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03074', N'074', N'03', N'Kikuyu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03075', N'075', N'03', N'Moi Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03077', N'077', N'03', N'Plaza Business Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03078', N'078', N'03', N'Kiriaini')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03079', N'079', N'03', N'Avon Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03080', N'080', N'03', N'Migori')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03082', N'082', N'03', N'Haile Selassie')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03083', N'083', N'03', N'University of Nairobi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03086', N'086', N'03', N'Nairobi west')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03087', N'087', N'03', N'Parkland Highbridge')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03088', N'088', N'03', N'Busia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03089', N'089', N'03', N'Pangani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03093', N'093', N'03', N'Kariobangi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03094', N'094', N'03', N'QueensWay')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'03095', N'095', N'03', N'Nakumatt Ebakasi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'05000', N'000', N'05', N'Nairobi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'05001', N'001', N'05', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'05002', N'002', N'05', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'05003', N'003', N'05', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'06000', N'000', N'06', N'Nairobi Main')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'06002', N'002', N'06', N'Digo rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'06004', N'004', N'06', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'06005', N'005', N'06', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'06006', N'006', N'06', N'Sarit Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'06007', N'007', N'06', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'06008', N'008', N'06', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'06009', N'009', N'06', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07000', N'000', N'07', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07001', N'001', N'07', N'Upper Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07002', N'002', N'07', N'Wabera')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07003', N'003', N'07', N'Mama Ngina Br/Hilton Agency')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07004', N'004', N'07', N'Westlands Br/ILRI Agency')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07005', N'005', N'07', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07006', N'006', N'07', N'Mamlaka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07007', N'007', N'07', N'Village Mkt Br/US Emb/Icraf Ag')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07008', N'008', N'07', N'Cargo Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07009', N'009', N'07', N'Park Side')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07016', N'016', N'07', N'Galleria')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07017', N'017', N'07', N'Junction')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07020', N'020', N'07', N'Moi Avenue Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07021', N'021', N'07', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07022', N'022', N'07', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07023', N'023', N'07', N'Bamburi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07024', N'024', N'07', N'Diani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07025', N'025', N'07', N'Changamwe')
GO
print 'Processed 300 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07026', N'026', N'07', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'07027', N'027', N'07', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'08046', N'046', N'08', N'Mobasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'08047', N'047', N'08', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'08048', N'048', N'08', N'Nairobi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'09000', N'000', N'09', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'09001', N'001', N'09', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'09002', N'002', N'09', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'09003', N'003', N'09', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'09004', N'004', N'09', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10000', N'000', N'10', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10001', N'001', N'10', N'Kenindia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10002', N'002', N'10', N'Biashara')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10003', N'003', N'10', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10004', N'004', N'10', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10005', N'005', N'10', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10006', N'006', N'10', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10007', N'007', N'10', N'Parklands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10008', N'008', N'10', N'Riverside Drive')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10009', N'009', N'10', N'Card centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10010', N'010', N'10', N'Hurlingham')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10011', N'011', N'10', N'Capital Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10012', N'012', N'10', N'Nyali')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10014', N'014', N'10', N'Kamukunji')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'10015', N'015', N'10', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11000', N'000', N'11', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11002', N'002', N'11', N'Co-op Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11003', N'003', N'11', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11004', N'004', N'11', N'Nkrumah Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11005', N'005', N'11', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11006', N'006', N'11', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11007', N'007', N'11', N'Industrial Are')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11008', N'008', N'11', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11009', N'009', N'11', N'Machakos')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11010', N'010', N'11', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11011', N'011', N'11', N'Ukulima')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11012', N'012', N'11', N'Chuka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11013', N'013', N'11', N'Wakulima Market')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11014', N'014', N'11', N'Moi Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11015', N'015', N'11', N'Naivasha')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11017', N'017', N'11', N'Nyahururu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11018', N'018', N'11', N'Chuka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11019', N'019', N'11', N'Wakulima Market')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11020', N'020', N'11', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11021', N'021', N'11', N'Kiambu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11022', N'022', N'11', N'Homabay')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11023', N'023', N'11', N'Embu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11024', N'024', N'11', N'Kericho')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11025', N'025', N'11', N'Bungoma')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11026', N'026', N'11', N'Muranga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11027', N'027', N'11', N'Kayole')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11028', N'028', N'11', N'Karatina')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11029', N'029', N'11', N'Ukunda')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11030', N'030', N'11', N'Mtwapa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11031', N'031', N'11', N'University way')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11032', N'032', N'11', N'BuruBuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11033', N'033', N'11', N'AthiRiver')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11034', N'034', N'11', N'Mumias')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11035', N'035', N'11', N'Stima Plaza')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11036', N'036', N'11', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11037', N'037', N'11', N'Upper Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11038', N'038', N'11', N'Ongata Rongai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11039', N'039', N'11', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11040', N'040', N'11', N'Nacico Plaza')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11041', N'041', N'11', N'Kariobangi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11042', N'042', N'11', N'Kawangware')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11043', N'043', N'11', N'Makutano')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11044', N'044', N'11', N'Parliament Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11045', N'045', N'11', N'Kimathi Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11046', N'046', N'11', N'Kitale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11047', N'047', N'11', N'Githurai Agency')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11048', N'048', N'11', N'Maua')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11049', N'049', N'11', N'City Hall')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11050', N'050', N'11', N'Digo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11051', N'051', N'11', N'Nairobi Business Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11052', N'052', N'11', N'Kakamega')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11053', N'053', N'11', N'Migori')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11055', N'055', N'11', N'Nkubu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11056', N'056', N'11', N'Enterprise Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11057', N'057', N'11', N'Busia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11058', N'058', N'11', N'Siaya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11059', N'059', N'11', N'Voi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11060', N'060', N'11', N'Mariakani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11061', N'061', N'11', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11062', N'062', N'11', N'Zimmerman')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11063', N'063', N'11', N'Nakuru East')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11064', N'064', N'11', N'Kitengela')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11065', N'065', N'11', N'Aga Khan Walk')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11066', N'066', N'11', N'Narok')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11067', N'067', N'11', N'Kitui')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11068', N'068', N'11', N'Nanyuki')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11069', N'069', N'11', N'Embakasi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11070', N'070', N'11', N'Kibera')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11071', N'071', N'11', N'Siakago')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11072', N'072', N'11', N'Kapsabet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11073', N'073', N'11', N'Mbita')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11074', N'074', N'11', N'Kangemi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11075', N'075', N'11', N'Dandora')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11077', N'077', N'11', N'Tala')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11078', N'078', N'11', N'Gikomba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11079', N'079', N'11', N'River Road')
GO
print 'Processed 400 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11080', N'080', N'11', N'Nyamira')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11081', N'081', N'11', N'Garissa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11082', N'082', N'11', N'Bomet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11083', N'083', N'11', N'Keroka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11084', N'084', N'11', N'Gilgil')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11085', N'085', N'11', N'Tom Mboya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11086', N'086', N'11', N'Likoni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11088', N'088', N'11', N'Mwingi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11089', N'089', N'11', N'Mwingi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11090', N'090', N'11', N'Webuye')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11100', N'100', N'11', N'Ndhiwa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'11102', N'102', N'11', N'Isiolo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12002', N'002', N'12', N'Kenyatta Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12003', N'003', N'12', N'Harambee Avenue NBK  Building')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12004', N'004', N'12', N'Hill Plaza')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12005', N'005', N'12', N'Busia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12006', N'006', N'12', N'Kiambu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12007', N'007', N'12', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12008', N'008', N'12', N'Karatina')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12009', N'009', N'12', N'Narok')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12010', N'010', N'12', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12011', N'011', N'12', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12012', N'012', N'12', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12013', N'013', N'12', N'Kitale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12015', N'015', N'12', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12016', N'016', N'12', N'Limuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12017', N'017', N'12', N'Kitui')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12019', N'019', N'12', N'Bungoma')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12020', N'020', N'12', N'Nkurumah Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12021', N'021', N'12', N'Kapsabet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12022', N'022', N'12', N'Awendo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12023', N'023', N'12', N'Portway Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12025', N'025', N'12', N'Hospital')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12026', N'026', N'12', N'Ruiru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12027', N'027', N'12', N'Ongata Rongai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12028', N'028', N'12', N'Embu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12029', N'029', N'12', N'Kakamega')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12031', N'031', N'12', N'Ukunda')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12032', N'032', N'12', N'Upper Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12033', N'033', N'12', N'Nandi Hills')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12034', N'034', N'12', N'Migori')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12035', N'035', N'12', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12036', N'036', N'12', N'Times Tower')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12037', N'037', N'12', N'Maua')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12038', N'038', N'12', N'Wilson Airport')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12039', N'039', N'12', N'J.K.I.A.')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12040', N'040', N'12', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12042', N'042', N'12', N'Mutomo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12043', N'043', N'12', N'Kianjai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12044', N'044', N'12', N'Kenyatta University')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12045', N'045', N'12', N'St. Paul''s University')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12046', N'046', N'12', N'Moi University')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12047', N'047', N'12', N'Moi International Airport, Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12050', N'050', N'12', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'12099', N'099', N'12', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'14000', N'000', N'14', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'14004', N'004', N'14', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'14005', N'005', N'14', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'14006', N'006', N'14', N'Kitale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'14007', N'007', N'14', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'16000', N'000', N'16', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'16400', N'400', N'16', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'17000', N'000', N'17', N'Main Branch')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'17001', N'001', N'17', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'17002', N'002', N'17', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'18000', N'000', N'18', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'18002', N'002', N'18', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'18003', N'003', N'18', N'Milimani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'18004', N'004', N'18', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19000', N'000', N'19', N'Nairobi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19001', N'001', N'19', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19002', N'002', N'19', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19003', N'003', N'19', N'Uhuru Highway')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19004', N'004', N'19', N'River Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19006', N'006', N'19', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19007', N'007', N'19', N'Ruaraka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19008', N'008', N'19', N'Monrovia Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19009', N'009', N'19', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19010', N'010', N'19', N'Ngong Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19011', N'011', N'19', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19012', N'012', N'19', N'Embakasi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19013', N'013', N'19', N'Kericho')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19014', N'014', N'19', N'Changamwe')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19015', N'015', N'19', N'Bungoma')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19017', N'017', N'19', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'19018', N'018', N'19', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'20001', N'001', N'20', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'20002', N'002', N'20', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'20003', N'003', N'20', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'20004', N'004', N'20', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23000', N'000', N'23', N'Harambee Avenue Harambee Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23001', N'001', N'23', N'Murang''a')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23002', N'002', N'23', N'Embu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23003', N'003', N'23', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23004', N'004', N'23', N'Koinange Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23005', N'005', N'23', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23006', N'006', N'23', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23007', N'007', N'23', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23009', N'009', N'23', N'Maua')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23010', N'010', N'23', N'Isiolo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23011', N'011', N'23', N'Head Office')
GO
print 'Processed 500 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23013', N'013', N'23', N'Umoja')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23014', N'014', N'23', N'River Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23015', N'015', N'23', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'23016', N'016', N'23', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'25000', N'000', N'25', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'25001', N'001', N'25', N'Koinange Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'25002', N'002', N'25', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'25003', N'003', N'25', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'25004', N'004', N'25', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'25005', N'005', N'25', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'25006', N'006', N'25', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26001', N'001', N'26', N'Nairobi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26002', N'002', N'26', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26003', N'003', N'26', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26005', N'005', N'26', N'MIA')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26006', N'006', N'26', N'JKIA')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26007', N'007', N'26', N'Kirinyaga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26008', N'008', N'26', N'Kabarak')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26009', N'009', N'26', N'Olenguruone')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26010', N'010', N'26', N'Kericho')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26011', N'011', N'26', N'Nandi Hills')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26012', N'012', N'26', N'EPZ')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26013', N'013', N'26', N'Sheikh Karume')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'26014', N'014', N'26', N'Kabarnet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30000', N'000', N'30', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30001', N'001', N'30', N'City Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30003', N'003', N'30', N'Village Market')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30004', N'004', N'30', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30005', N'005', N'30', N'Hurlingham')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30006', N'006', N'30', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30007', N'007', N'30', N'Parklands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30008', N'008', N'30', N'Riverside Mews')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30009', N'009', N'30', N'Iman Banking Centre Riverside Mews')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30010', N'010', N'30', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30011', N'011', N'30', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30012', N'012', N'30', N'Donholm')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30014', N'014', N'30', N'Ngara Mini Branch Peace Towers')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30015', N'015', N'30', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'30016', N'016', N'30', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31000', N'000', N'31', N'Clearing Centre,Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31002', N'002', N'31', N'Kenyatta Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31003', N'003', N'31', N'Digo Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31004', N'004', N'31', N'Waiyaki Way')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31005', N'005', N'31', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31006', N'006', N'31', N'Harambee Avenue Nairobi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31007', N'007', N'31', N'Chiromo Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31008', N'008', N'31', N'International House')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31009', N'009', N'31', N'Nkrumah')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31010', N'010', N'31', N'Upper Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31011', N'011', N'31', N'Naivasha')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31012', N'012', N'31', N'Westgate')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31013', N'013', N'31', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31014', N'014', N'31', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31015', N'015', N'31', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31016', N'016', N'31', N'Nyerere')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31017', N'017', N'31', N'Nanyuki')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31018', N'018', N'31', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31020', N'020', N'31', N'Gikomba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31021', N'021', N'31', N'Ruaraka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31022', N'022', N'31', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31023', N'023', N'31', N'Karen')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31024', N'024', N'31', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'31999', N'999', N'31', N'Central Processing CfC Centre,HeadOffice')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'35000', N'000', N'35', N'Koinange Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'35001', N'001', N'35', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'35002', N'002', N'35', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'35004', N'004', N'35', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'35005', N'005', N'35', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'35006', N'006', N'35', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'35007', N'007', N'35', N'Libra House')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'35008', N'008', N'35', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39001', N'001', N'39', N'IPS')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39002', N'002', N'39', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39003', N'003', N'39', N'Upper Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39004', N'004', N'39', N'Parklands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39006', N'006', N'39', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39007', N'007', N'39', N'Watamu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39008', N'008', N'39', N'Diani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39009', N'009', N'39', N'Kilifi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39010', N'010', N'39', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39011', N'011', N'39', N'Karen')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39012', N'012', N'39', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39014', N'014', N'39', N'Changamwe')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39015', N'015', N'39', N'Riverside')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39016', N'016', N'39', N'Likoni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'39018', N'018', N'39', N'Village Market')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41000', N'000', N'41', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41101', N'101', N'41', N'City Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41102', N'102', N'41', N'NIC Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41103', N'103', N'41', N'Harbor Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41105', N'105', N'41', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41106', N'106', N'41', N'Junction')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41107', N'107', N'41', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41108', N'108', N'41', N'Nyali')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41109', N'109', N'41', N'Nkurumah Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41111', N'111', N'41', N'Prestige')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41112', N'112', N'41', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41113', N'113', N'41', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41114', N'114', N'41', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41115', N'115', N'41', N'Galleria (Bomas)')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41116', N'116', N'41', N'Eldoret')
GO
print 'Processed 600 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41117', N'117', N'41', N'Village Market')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'41118', N'118', N'41', N'Mombasa Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'42001', N'001', N'42', N'Banda Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'42004', N'004', N'42', N'Kimathi Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'42005', N'005', N'42', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'42006', N'006', N'42', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'42007', N'007', N'42', N'Parklands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43000', N'000', N'43', N'Ecobank Towers')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43002', N'002', N'43', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43003', N'003', N'43', N'Plaza 2000')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43004', N'004', N'43', N'Westminister')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43005', N'005', N'43', N'Chambers')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43007', N'007', N'43', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43008', N'008', N'43', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43009', N'009', N'43', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43010', N'010', N'43', N'Kitale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43011', N'011', N'43', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43012', N'012', N'43', N'Karatina')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43013', N'013', N'43', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43014', N'014', N'43', N'United Mall')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43015', N'015', N'43', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43016', N'016', N'43', N'Jomo Kenyatta Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43017', N'017', N'43', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43018', N'018', N'43', N'Busia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43019', N'019', N'43', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43020', N'020', N'43', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43021', N'021', N'43', N'Gikomba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43023', N'023', N'43', N'Valley Arcade')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'43100', N'100', N'43', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49000', N'000', N'49', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49001', N'001', N'49', N'Nairobi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49002', N'002', N'49', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49003', N'003', N'49', N'Westlands The Mall The Mall')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49005', N'005', N'49', N'Chester')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49007', N'007', N'49', N'Waiyaki Way')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49008', N'008', N'49', N'Kakamega')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49009', N'009', N'49', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49011', N'011', N'49', N'Nyali')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49012', N'012', N'49', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'49013', N'013', N'49', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'50000', N'000', N'50', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'50001', N'001', N'50', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'50002', N'002', N'50', N'Parklands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'50003', N'003', N'50', N'Koinange Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'5004', N'004', N'50', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'51000', N'000', N'51', N'Koinange Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53001', N'001', N'53', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53002', N'002', N'53', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53003', N'003', N'53', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53004', N'004', N'53', N'Lavington')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53005', N'005', N'53', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53006', N'006', N'53', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53007', N'007', N'53', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53008', N'008', N'53', N'Muthaiga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53010', N'010', N'53', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53011', N'011', N'53', N'Gikomba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53012', N'012', N'53', N'Ngong Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'53013', N'013', N'53', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'54001', N'001', N'54', N'Nairobi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'54002', N'002', N'54', N'Riverside Drive')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'55001', N'001', N'55', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'55002', N'002', N'55', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'55004', N'004', N'55', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'55005', N'005', N'55', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'55006', N'006', N'55', N'Main Branch')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'55007', N'007', N'55', N'Mombasa Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57000', N'000', N'57', N'Kenyatta Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57001', N'001', N'57', N'2nd Ngong Avenue I & M Bank House')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57002', N'002', N'57', N'Sarit Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57003', N'003', N'57', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57004', N'004', N'57', N'Biashara')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57005', N'005', N'57', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57007', N'007', N'57', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57008', N'008', N'57', N'Karen')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57009', N'009', N'57', N'Panari Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57010', N'010', N'57', N'Parklands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57011', N'011', N'57', N'Wilson Airport')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57012', N'012', N'57', N'Ongata Rongai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57013', N'013', N'57', N'South C Shopping South C')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57014', N'014', N'57', N'Nyali Cinemax')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57015', N'015', N'57', N'Langata Link')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57016', N'016', N'57', N'Lavington')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57018', N'018', N'57', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'57098', N'098', N'57', N'Card Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'59001', N'001', N'59', N'Loita Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'59002', N'002', N'59', N'Ngong Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'60000', N'000', N'60', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'60001', N'001', N'60', N'City Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'60002', N'002', N'60', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'60003', N'003', N'60', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'60004', N'004', N'60', N'Diani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'60006', N'006', N'60', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63000', N'000', N'63', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63001', N'001', N'63', N'Nation Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63002', N'002', N'63', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63003', N'003', N'63', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63005', N'005', N'63', N'Parklands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63006', N'006', N'63', N'Westgate')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63008', N'008', N'63', N'Mombasa Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63009', N'009', N'63', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63011', N'011', N'63', N'Malindi')
GO
print 'Processed 700 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63012', N'012', N'63', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63013', N'013', N'63', N'OTC')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63014', N'014', N'63', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63015', N'015', N'63', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63016', N'016', N'63', N'Changamwe')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63017', N'017', N'63', N'T-Mall')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63018', N'018', N'63', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63019', N'019', N'63', N'Village Market')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63020', N'020', N'63', N'Diani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63021', N'021', N'63', N'Bungoma')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63023', N'023', N'63', N'Prestige')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63024', N'024', N'63', N'Buru Buru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63025', N'025', N'63', N'Kitengela')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63026', N'026', N'63', N'Jomo Kenyatta')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63027', N'027', N'63', N'Kakamega')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63028', N'028', N'63', N'Kericho')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63029', N'029', N'63', N'Upper Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63030', N'030', N'63', N'Wabera Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63031', N'031', N'63', N'Karen')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63032', N'032', N'63', N'Voi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63034', N'034', N'63', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63035', N'035', N'63', N'Diamond Plaza')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63036', N'036', N'63', N'Cross Roads')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'63050', N'050', N'63', N'Tom Mboya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66000', N'000', N'66', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66001', N'001', N'66', N'Naivasha Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66002', N'002', N'66', N'Moi Avenue -Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66003', N'003', N'66', N'Kenyatta Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66004', N'004', N'66', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66005', N'005', N'66', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66007', N'007', N'66', N'Embu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66008', N'008', N'66', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66009', N'009', N'66', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66010', N'010', N'66', N'Kericho')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66011', N'011', N'66', N'Kangemi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66012', N'012', N'66', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66013', N'013', N'66', N'Kerugoya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66014', N'014', N'66', N'Kenyatta Mkt')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66015', N'015', N'66', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66016', N'016', N'66', N'Chuka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66017', N'017', N'66', N'Kitui')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66018', N'018', N'66', N'Machakos')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66019', N'019', N'66', N'Nanyuki')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66021', N'021', N'66', N'Emali')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66022', N'022', N'66', N'Naivasha')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66023', N'023', N'66', N'Nyahururu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66024', N'024', N'66', N'Isiolo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66025', N'025', N'66', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66026', N'026', N'66', N'Kitale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66027', N'027', N'66', N'Kibwezi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66028', N'028', N'66', N'Bungoma')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66031', N'031', N'66', N'Mtwapa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66033', N'033', N'66', N'Moi Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66034', N'034', N'66', N'Mwea')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66035', N'035', N'66', N'Kengeleni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'66036', N'036', N'66', N'Kilimani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68000', N'000', N'68', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68001', N'001', N'68', N'Corporate')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68002', N'002', N'68', N'Fourways')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68003', N'003', N'68', N'Kangema')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68004', N'004', N'68', N'Karatina')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68006', N'006', N'68', N'Muraradia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68007', N'007', N'68', N'Kangari')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68008', N'008', N'68', N'Othaya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68009', N'009', N'68', N'Thika Plaza')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68010', N'010', N'68', N'Kerugoya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68011', N'011', N'68', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68012', N'012', N'68', N'Tom Mboya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68013', N'013', N'68', N'Nakuru Gatehouse Gate Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68014', N'014', N'68', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68015', N'015', N'68', N'Mama Ngina')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68017', N'017', N'68', N'Community')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68018', N'018', N'68', N'Community Corporate')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68019', N'019', N'68', N'Embu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68020', N'020', N'68', N'Naivasha')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68021', N'021', N'68', N'Chuka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68022', N'022', N'68', N'Murang''a')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68023', N'023', N'68', N'Molo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68024', N'024', N'68', N'Harambee')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68025', N'025', N'68', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68026', N'026', N'68', N'Kimathi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68027', N'027', N'68', N'Nanyuki')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68029', N'029', N'68', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68030', N'030', N'68', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68031', N'031', N'68', N'Nakuru Kenyatta Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68032', N'032', N'68', N'Kariobangi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68033', N'033', N'68', N'Kitale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68034', N'034', N'68', N'Thika Kenyatta Highway')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68035', N'035', N'68', N'Knut Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68036', N'036', N'68', N'Narok')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68037', N'037', N'68', N'Nkubu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68038', N'038', N'68', N'Mwea')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68040', N'040', N'68', N'Maua')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68041', N'041', N'68', N'Isiolo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68042', N'042', N'68', N'Kagio')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68043', N'043', N'68', N'Gikomba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68044', N'044', N'68', N'Ukunda')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68045', N'045', N'68', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68046', N'046', N'68', N'Mombasa Digo Rd Digo Rd')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68047', N'047', N'68', N'Moi Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68048', N'048', N'68', N'Bungoma')
GO
print 'Processed 800 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68049', N'049', N'68', N'Kapsabet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68050', N'050', N'68', N'Kakamega')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68052', N'052', N'68', N'Nyamira')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68053', N'053', N'68', N'Litein')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68055', N'055', N'68', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68056', N'056', N'68', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68057', N'057', N'68', N'Kikuyu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68058', N'058', N'68', N'Garissa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68059', N'059', N'68', N'Mwingi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68060', N'060', N'68', N'Machakos')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68061', N'061', N'68', N'Ongata Rongai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68062', N'062', N'68', N'Ol-Kalou')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68064', N'064', N'68', N'Kiambu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68065', N'065', N'68', N'Kayole')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68066', N'066', N'68', N'Gatundu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68067', N'067', N'68', N'Wote')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68068', N'068', N'68', N'Mumias')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68069', N'069', N'68', N'Limuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68070', N'070', N'68', N'Kitengela')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68071', N'071', N'68', N'Githurai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68072', N'072', N'68', N'Kitui')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68073', N'073', N'68', N'Ngong')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68074', N'074', N'68', N'Loitoktok')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68076', N'076', N'68', N'Mbita')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68077', N'077', N'68', N'Gilgil')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68078', N'078', N'68', N'Busia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68079', N'079', N'68', N'Voi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68080', N'080', N'68', N'Enterprise Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68081', N'081', N'68', N'Equity Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68082', N'082', N'68', N'Donholm')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68083', N'083', N'68', N'Mukurwe-ini')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68084', N'084', N'68', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68085', N'085', N'68', N'Namanga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68088', N'088', N'68', N'OTC')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68089', N'089', N'68', N'Kenol')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68090', N'090', N'68', N'Tala')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68091', N'091', N'68', N'Ngara')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68092', N'092', N'68', N'Nandi Hills')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68093', N'093', N'68', N'Githunguri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68094', N'094', N'68', N'Tea Room')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68095', N'095', N'68', N'Buru Buru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68096', N'096', N'68', N'Mbale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68097', N'097', N'68', N'Siaya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68098', N'098', N'68', N'Homa Bay')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68099', N'099', N'68', N'Lodwar')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68100', N'100', N'68', N'Mandera')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68101', N'101', N'68', N'Marsabit')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68102', N'102', N'68', N'Moyale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68103', N'103', N'68', N'Wajir')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68104', N'104', N'68', N'Meru Makutano')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68105', N'105', N'68', N'Malaba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68106', N'106', N'68', N'Kilifi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68107', N'107', N'68', N'Kapenguria')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68108', N'108', N'68', N'Mombasa Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68110', N'110', N'68', N'Maralal')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68111', N'111', N'68', N'Kimende')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68112', N'112', N'68', N'Luanda')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68113', N'113', N'68', N'KU')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68114', N'114', N'68', N'Kengeleni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68115', N'115', N'68', N'Nyeri Kimathi Way EK Wachira Bldg')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68116', N'116', N'68', N'Migori')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68117', N'117', N'68', N'Kibera')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68118', N'118', N'68', N'Kasarani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68119', N'119', N'68', N'Mtwapa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68120', N'120', N'68', N'Changamwe')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68122', N'122', N'68', N'Bomet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68123', N'123', N'68', N'Kilgoris')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68124', N'124', N'68', N'Keroka')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68125', N'125', N'68', N'Karen')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68126', N'126', N'68', N'Kisumu Angawa Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68127', N'127', N'68', N'Mpeketoni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68128', N'128', N'68', N'Nairobi West')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68129', N'129', N'68', N'Kenyatta Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68130', N'130', N'68', N'City Hall')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'68131', N'131', N'68', N'Eldama Ravine')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70000', N'000', N'70', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70001', N'001', N'70', N'Kiambu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70002', N'002', N'70', N'Githunguri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70003', N'003', N'70', N'Sonalux')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70004', N'004', N'70', N'Gatundu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70005', N'005', N'70', N'Thika')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70006', N'006', N'70', N'Murang''a')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70007', N'007', N'70', N'kangari')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70008', N'008', N'70', N'Kiria-ini')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70009', N'009', N'70', N'Kangema')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70011', N'011', N'70', N'Othaya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70014', N'014', N'70', N'Cargen Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70018', N'018', N'70', N'Nakuru Finance')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70019', N'019', N'70', N'Nakuru Njoro Hse')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70021', N'021', N'70', N'Dagoreti')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70023', N'023', N'70', N'Nyahururu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70024', N'024', N'70', N'Ruiru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70025', N'025', N'70', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70026', N'026', N'70', N'Nyamira')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70027', N'027', N'70', N'Kisii')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70031', N'031', N'70', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70033', N'033', N'70', N'Donholm')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70035', N'035', N'70', N'Fourways Retail')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70038', N'038', N'70', N'KTDA Plaza')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70041', N'041', N'70', N'Kariobangi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70042', N'042', N'70', N'Gikomba Area 42')
GO
print 'Processed 900 total records'
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70043', N'043', N'70', N'Gikomba')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70045', N'045', N'70', N'Githurai')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70046', N'046', N'70', N'Kilimani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70047', N'047', N'70', N'Limuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70049', N'049', N'70', N'Kagwe')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70051', N'051', N'70', N'Banana')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70053', N'053', N'70', N'Naivasha')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70055', N'055', N'70', N'Nyeri')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70057', N'057', N'70', N'Kerugoya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70058', N'058', N'70', N'Tom Mboya')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70059', N'059', N'70', N'River Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70061', N'061', N'70', N'Kayole')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70062', N'062', N'70', N'Nkubu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70063', N'063', N'70', N'Meru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70065', N'065', N'70', N'KTDA Corporate')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70069', N'069', N'70', N'Kitui')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70071', N'071', N'70', N'Kitengela')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70072', N'072', N'70', N'Kitui')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70073', N'073', N'70', N'Machakos')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70075', N'075', N'70', N'Embu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70077', N'077', N'70', N'Bungoma')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70078', N'078', N'70', N'Kakamega')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70079', N'079', N'70', N'Busia')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70083', N'083', N'70', N'Molo')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70085', N'085', N'70', N'Eldoret')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70095', N'095', N'70', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70096', N'096', N'70', N'Kenyatta Avenue,Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'70097', N'097', N'70', N'Kapsabet')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72000', N'000', N'72', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72001', N'001', N'72', N'Central Clearing Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72002', N'002', N'72', N'Upperhill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72003', N'003', N'72', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72004', N'004', N'72', N'Kenyatta Avenue')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72005', N'005', N'72', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72007', N'007', N'72', N'Lamu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72008', N'008', N'72', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72009', N'009', N'72', N'Muthaiga')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'72010', N'010', N'72', N'Bondeni')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74001', N'001', N'74', N'Wabera Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74002', N'002', N'74', N'Eastleigh')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74003', N'003', N'74', N'Mombasa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74004', N'004', N'74', N'Garissa')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74005', N'005', N'74', N'Eastleigh II')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74006', N'006', N'74', N'Malindi')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74007', N'007', N'74', N'Kisumu')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74008', N'008', N'74', N'Kimathi Street')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74009', N'009', N'74', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74010', N'010', N'74', N'South C')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74011', N'011', N'74', N'Industrial Area')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74012', N'012', N'74', N'Masalani')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74013', N'013', N'74', N'Habaswein')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74014', N'014', N'74', N'Wajir')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74015', N'015', N'74', N'Moyale')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74016', N'016', N'74', N'Nakuru')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74017', N'017', N'74', N'Mombasa 11')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'74999', N'999', N'74', N'Head Office/Clearing Centre')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'76001', N'001', N'76', N'Westlands')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'76002', N'002', N'76', N'Enterprise Road')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'76003', N'003', N'76', N'Upper Hill')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'76099', N'099', N'76', N'Head Office')
INSERT [dbo].[BankBranches] ([BankSortCode], [BranchCode], [BankCode], [BranchName]) VALUES (N'95000', N'000', N'59', N'Head Office')
/****** Object:  Table [dbo].[Attendances]    Script Date: 04/23/2013 17:16:31 ******/
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
SET IDENTITY_INSERT [dbo].[Attendances] ON
INSERT [dbo].[Attendances] ([Id], [StudentId], [SubjectShortCode], [StartDateTime], [EndDateTime], [Attended], [ReasonForNotAttending]) VALUES (7, 13, N'AGR', CAST(0x0000A19900BA1150 AS DateTime), CAST(0x0000A19900BA1150 AS DateTime), 1, NULL)
INSERT [dbo].[Attendances] ([Id], [StudentId], [SubjectShortCode], [StartDateTime], [EndDateTime], [Attended], [ReasonForNotAttending]) VALUES (8, 13, N'BIO', CAST(0x0000A19900BA29FD AS DateTime), CAST(0x0000A19900BA29FC AS DateTime), 1, NULL)
INSERT [dbo].[Attendances] ([Id], [StudentId], [SubjectShortCode], [StartDateTime], [EndDateTime], [Attended], [ReasonForNotAttending]) VALUES (9, 13, N'BS', CAST(0x0000A19900BA3A13 AS DateTime), CAST(0x0000A19900BA3A13 AS DateTime), 1, NULL)
INSERT [dbo].[Attendances] ([Id], [StudentId], [SubjectShortCode], [StartDateTime], [EndDateTime], [Attended], [ReasonForNotAttending]) VALUES (10, 17, N'COMM', CAST(0x0000A19C00E39BD6 AS DateTime), CAST(0x0000A19C00E39BD6 AS DateTime), 0, NULL)
INSERT [dbo].[Attendances] ([Id], [StudentId], [SubjectShortCode], [StartDateTime], [EndDateTime], [Attended], [ReasonForNotAttending]) VALUES (11, 28, N'BIO', CAST(0x0000A1A70149B7D0 AS DateTime), CAST(0x0000A1A70154FBBB AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[Attendances] OFF
/****** Object:  Table [dbo].[Accounts]    Script Date: 04/23/2013 17:16:31 ******/
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
	[AccountNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccountTypeId] [int] NULL,
	[COAId] [int] NOT NULL,
	[Branch] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SchoolBranch] [int] NULL,
	[PassFlag] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BookBalance] [money] NOT NULL,
	[ClearedBalance] [money] NOT NULL,
	[InterestRate] [float] NOT NULL,
	[AccruedInt] [money] NOT NULL,
	[Limit] [money] NOT NULL,
	[Bal30] [money] NULL,
	[Bal60] [money] NULL,
	[Bal90] [money] NULL,
	[BalOver90] [money] NULL,
	[IntRate30] [float] NULL,
	[IntRate60] [float] NULL,
	[IntRate90] [float] NULL,
	[IntRateOver90] [float] NULL,
	[Closed] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
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
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (1, 1, N'TUITION FEES', N'10011111', 1, 33, N'19017', 1, N'1', -2638500.0000, -2638500.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (2, 2, N'STUDENTS SAVINGS ACCOUNT', N'10011112', 1, 3, N'35008', 1, N'1', 0.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (3, 3, N'NOREEN NDUTA EXAMINATION  FEES', N'10011113', 1, 3, N'1091', 1, N'1', -15950.0000, -2500.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (4, 3, N'MOMBASA TOUR CONTRIBUTIONS', N'10011114', 1, 3, N'14000', 1, N'1', 0.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (5, 1, N'LIBRARY FEES', N'10011115', 1, 34, N'19004', 1, N'1', 0.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (6, 3, N'REHAB NYAMBURA  EXAMINATION  FEES', N'10011116', 1, 3, N'19004', 1, N'1', 105963.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (7, 7, N'QUINCE BABRA TUITION FEES', N'10011117', 1, 4, N'35001', 3, N'1', -31200.0000, -34600.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (8, 8, N'KEVIN SAMSON MEDICAL FEES', N'10011118', 1, 4, N'35000', 3, N'1', 101000.0000, 100000.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (9, 9, N'SAMSON KIMATHI TUITION FEES', N'10011119', 1, 3, N'01092', 2, N'1', -44800.0000, 5200.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (10, 10, N'QUINCE BABRA TUITION FEES', N'10011121', 1, 3, N'35001', 2, N'1', 0.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (12, 11, N'FOOTBALL CLUB CONTRIBUTIONS', N'10011122', 1, 3, N'12002', 2, N'1', 0.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (18, 1, N'ADMISSION FEES', N'10011123', 1, 46, N'19017', 1, N'1', 2793200.0000, 2742000.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (19, 1, N'EXAMINATION FEES', N'10011123', 1, 42, N'19017', 1, N'1', 20050.0000, 6000.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (20, 3, N'REHAB NYAMBURA MOMBASA TOUR CONTRIBUTIONS', N'10011124', 1, 3, N'19002', 2, N'1', 32321.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (21, 5, N'NOREEN NDUTA MEDICAL FEES', N'10011125', 1, 3, N'19002', 1, N'1', 1000.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (22, 18, N'EVELYN AKINYI EXAMINATION  FEES', N'10011126', 1, 3, N'19007', 2, N'1', 133821.0000, 96500.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (23, 18, N'EVELYN AKINYI MEDICAL FEES', N'10011127', 1, 4, N'19000', 2, N'1', 15400.0000, 10400.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (24, 16, N'DICKSON KIBUJA MEDICAL FEES', N'10011128', 1, 3, N'19004', 1, N'1', 1000.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (25, 16, N'JOHNSON JAMES  TUITION FEES', N'10011129', 1, 4, N'35005', 1, N'1', -44600.0000, -46800.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (26, 18, N'EVELYN AKINYI TUITION FEES', N'10011131', 1, 3, N'19017', 1, N'1', 45356353.0000, 10400.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (27, 3, N'NJOKI AIMEY MEDICAL FEES', N'10011132', 1, 3, N'19004', 1, N'1', 0.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (28, 3, N'MOHAMED ABDUL MEDICAL FEES', N'10011133', 1, 4, N'19002', 1, N'1', 1000.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (29, 3, N'JOHNSON JAMES MEDICAL FEES', N'10011134', 1, 4, N'42001', 1, N'1', 5000.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (30, 3, N'REHAB NYAMBURA TUITION FEES ', N'10011135', 1, 3, N'19004', 1, N'1', 53400.0000, 50000.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (31, 3, N'REHAB NYAMBURA MEDICAL FEES', N'10011136', 1, 4, N'42004', 1, N'1', 6000.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (32, 3, N'WAMBUI MONIQ TUITION FEES', N'10011137', 1, 7, N'42005', 2, N'1', 0.0000, 0.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (33, 2, N'NOREEN NDUTA  GITHAIGA  TUITION FEES', N'10011138', 1, 3, N'35001', 1, N'1', 8600.0000, 5200.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (34, 3, N'DICKSON KIBUJA  MARETE  TUITION FEES', N'10011139', 1, 3, N'19004', 1, N'1', 8600.0000, 5200.0000, 5, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (36, 8, N'SAMSON KIMATHI  KIMEMIA', N'32534542', 1, 3, N'19004', 1, N'1', 0.0000, 0.0000, 0, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (38, 3, N'REHAB NYAMBURA  MUIGAI', N'1001236985', 1, 3, N'20003', 1, N'1', 0.0000, 0.0000, 0, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (39, 4, N'JOHNSON JAMES  KAMAU FEES ACCOUNT', N'123', 1, 3, N'19004', 8, N'1', 0.0000, 0.0000, 0, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (40, 4, N'JOHNSON JAMES  KAMAU EXAMINATION ACCOUNT', N'124', 1, 3, N'42005', 8, N'1', 5000.0000, 0.0000, 0, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (41, 4, N'JOHNSON JAMES  KAMAU LIBRARY FEES ACCOUNT', N'125', 1, 3, N'35006', 8, N'1', 0.0000, 0.0000, 0, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (42, 10, N'UNGA FEES', N'4645655', 1, 19, N'19006', 8, N'1', 0.0000, 0.0000, 0, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (43, 7, N'GGGGGGGGGGGGGGGGGGGGG', N'55555555555555', 1, 25, N'19004', 8, N'1', 0.0000, 0.0000, 0, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([AccountID], [CustomerId], [AccountName], [AccountNo], [AccountTypeId], [COAId], [Branch], [SchoolBranch], [PassFlag], [BookBalance], [ClearedBalance], [InterestRate], [AccruedInt], [Limit], [Bal30], [Bal60], [Bal90], [BalOver90], [IntRate30], [IntRate60], [IntRate90], [IntRateOver90], [Closed]) VALUES (44, 5, N'32122244', N'42343242343', 1, 25, N'25002', 8, N'1', 0.0000, 0.0000, 0, 0.0000, 0.0000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
/****** Object:  Table [dbo].[StudentProgresses]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentProgresses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentProgresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Term] [int] NOT NULL,
	[ClassShortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ExamTypeShortCode] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TeacherId] [int] NULL,
	[TotalMarks] [float] NULL,
	[TotalPoints] [float] NULL,
	[Position] [int] NULL,
	[MeanMarks] [float] NULL,
	[MeanGrade] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClassTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HeadTeacherRemark] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
/****** Object:  Table [dbo].[Settings]    Script Date: 04/23/2013 17:16:32 ******/
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
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'GRADINGSYS', N'1', N'N', N'Grading System', 2, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MAXTRIES', N'3', N'N', N'Maximum password retries', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MINAGE', N'18', N'N', N'Minimum employement age', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PWDSIZE', N'5', N'N', N'Password size', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'REPFORMNAME', N'SCHOOL REPORT', N'S', N'Report Form Name', 2, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'REPORTPATH', N'C:\Program Files\Software Providers\Soft Books School\Reports', N'S', N'Report Output Path', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'RESOURCEPATH', N'C:\Program Files\Software Providers\Soft Books School\Resources', N'S', N'Resource Path', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SCHOOLID', N'1', N'N', N'School Id', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SCHOOLLOGO', N'C:\Program Files\Software Providers\Soft Books School\Resources\softwareproviderslogo.jpg', N'S', N'Company Logo', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SCHOOLSLOGAN', N'Solutions for all', N'S', N'Company Slogan', 3, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SUSPCR', N'1', N'N', N'SUSPENSE CREDIT', 7, 0)
INSERT [dbo].[Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SUSPDR', N'1', N'N', N'SUSPENSE DEBIT', 7, 0)
/****** Object:  Table [dbo].[ProgrammeYears]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYears]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProgrammeYears](
	[ProgrammeYearId] [int] IDENTITY(1,1) NOT NULL,
	[ProgrammeId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Year] [int] NOT NULL,
	[Description] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NextYr] [int] NULL,
	[Fees] [money] NULL,
 CONSTRAINT [PK_ProgrammeYears] PRIMARY KEY CLUSTERED 
(
	[ProgrammeYearId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[ProgrammeYears] ON
INSERT [dbo].[ProgrammeYears] ([ProgrammeYearId], [ProgrammeId], [Year], [Description], [NextYr], [Fees]) VALUES (6, N'KSCE      ', 1, N'KCSE year 1', 2, 20000.0000)
INSERT [dbo].[ProgrammeYears] ([ProgrammeYearId], [ProgrammeId], [Year], [Description], [NextYr], [Fees]) VALUES (7, N'KSCE      ', 2, N'KCSE year 2', 3, 20000.0000)
INSERT [dbo].[ProgrammeYears] ([ProgrammeYearId], [ProgrammeId], [Year], [Description], [NextYr], [Fees]) VALUES (8, N'KSCE      ', 3, N'KCSE year 3', 4, 20000.0000)
INSERT [dbo].[ProgrammeYears] ([ProgrammeYearId], [ProgrammeId], [Year], [Description], [NextYr], [Fees]) VALUES (14, N'KSCE      ', 4, N'KCSE year 4', NULL, 30000.0000)
INSERT [dbo].[ProgrammeYears] ([ProgrammeYearId], [ProgrammeId], [Year], [Description], [NextYr], [Fees]) VALUES (19, N'KSCE      ', 5, N'kcse year 5', 5, 5000.0000)
INSERT [dbo].[ProgrammeYears] ([ProgrammeYearId], [ProgrammeId], [Year], [Description], [NextYr], [Fees]) VALUES (20, N'KSCE      ', 6, N'kcse year 6', NULL, 3000.0000)
SET IDENTITY_INSERT [dbo].[ProgrammeYears] OFF
/****** Object:  Table [dbo].[ProgrammeYearCourses]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgrammeYearCourses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProgrammeYearCourses](
	[ProgrammeCourseId] [int] IDENTITY(1,1) NOT NULL,
	[ProgrammeId] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProgrammeYearId] [int] NOT NULL,
	[CourseId] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Semester] [int] NOT NULL,
	[NoOfHrs] [int] NULL,
	[TuitionFees] [money] NULL,
	[ExamFees] [money] NULL,
	[ResitFees] [money] NULL,
 CONSTRAINT [PK_ProgrammeCourses] PRIMARY KEY CLUSTERED 
(
	[ProgrammeCourseId] ASC
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
SET IDENTITY_INSERT [dbo].[ProgrammeYearCourses] ON
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (8, N'KSCE      ', 6, N'KISW', 1, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (9, N'KSCE      ', 6, N'MATH', 1, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (10, N'KSCE      ', 6, N'PHYS', 1, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (13, N'KSCE      ', 6, N'CHEM', 2, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (14, N'KSCE      ', 6, N'CRE', 2, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (15, N'KSCE      ', 6, N'ENG', 2, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (16, N'KSCE      ', 6, N'GEO', 2, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (17, N'KSCE      ', 6, N'HIST', 2, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (18, N'KSCE      ', 6, N'KISW', 2, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (19, N'KSCE      ', 6, N'MATH', 2, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (20, N'KSCE      ', 6, N'PHYS', 2, 150, 35000.0000, 5000.0000, 500.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (21, N'KSCE      ', 6, N'BIO', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (22, N'KSCE      ', 6, N'AGR', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (23, N'KSCE      ', 6, N'BS', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (24, N'KSCE      ', 6, N'CALC', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (25, N'KSCE      ', 6, N'CHEM', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (26, N'KSCE      ', 6, N'COM SKILL', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (27, N'KSCE      ', 6, N'COMSYSORG', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (28, N'KSCE      ', 6, N'HIV/AID', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (29, N'KSCE      ', 6, N'ENG', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (30, N'KSCE      ', 6, N'CRE', 3, 600, 63200.0000, 5000.0000, 250.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (31, N'KSCE      ', 6, N'COMSYSORG', 1, 500, 52000.0000, 45800.0000, 100.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (32, N'KSCE      ', 6, N'COM SKILL', 1, 500, 52000.0000, 45800.0000, 100.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (33, N'KSCE      ', 6, N'FM', 1, 500, 52000.0000, 45800.0000, 100.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (34, N'KSCE      ', 6, N'MUSIC', 1, 1000, 5000.0000, 500.0000, 200.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (35, N'KSCE      ', 6, N'COMP', 2, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (36, N'KSCE      ', 6, N'CALC', 2, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (37, N'KSCE      ', 6, N'COMP', 3, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (38, N'KSCE      ', 7, N'COMP', 3, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (39, N'KSCE      ', 7, N'COMP', 1, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (40, N'KSCE      ', 7, N'COMP', 2, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (41, N'KSCE      ', 14, N'COMP', 2, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (42, N'KSCE      ', 14, N'COMP', 1, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (43, N'KSCE      ', 14, N'COMP', 3, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (44, N'KSCE      ', 14, N'COMP', 4, 40, 47500.0000, 100.0000, 50.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (71, N'KSCE      ', 6, N'CHEM', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (72, N'KSCE      ', 19, N'CHEM', 1, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (73, N'KSCE      ', 19, N'BIO', 1, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (74, N'KSCE      ', 19, N'COMP', 1, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (75, N'KSCE      ', 19, N'GEO', 1, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (76, N'KSCE      ', 19, N'PHYS', 1, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (77, N'KSCE      ', 19, N'PHYS', 2, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (78, N'KSCE      ', 19, N'HIST', 2, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (79, N'KSCE      ', 19, N'KISW', 2, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (80, N'KSCE      ', 19, N'CRE', 2, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (81, N'KSCE      ', 19, N'FM', 2, 2000, 5000.0000, 200.0000, 150.0000)
INSERT [dbo].[ProgrammeYearCourses] ([ProgrammeCourseId], [ProgrammeId], [ProgrammeYearId], [CourseId], [Semester], [NoOfHrs], [TuitionFees], [ExamFees], [ResitFees]) VALUES (82, N'KSCE      ', 19, N'FM', 3, 2000, 5000.0000, 200.0000, 150.0000)
SET IDENTITY_INSERT [dbo].[ProgrammeYearCourses] OFF
/****** Object:  Table [dbo].[ResidenceHallRooms]    Script Date: 04/23/2013 17:16:32 ******/
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
 CONSTRAINT [PK_ResidenceHallRooms] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[ResidenceHallRooms] ON
INSERT [dbo].[ResidenceHallRooms] ([RoomId], [HallId], [Room], [Cost]) VALUES (5, 6, N'B1', 250.0000)
INSERT [dbo].[ResidenceHallRooms] ([RoomId], [HallId], [Room], [Cost]) VALUES (6, 6, N'B2', 250.0000)
INSERT [dbo].[ResidenceHallRooms] ([RoomId], [HallId], [Room], [Cost]) VALUES (7, 6, N'B3', 250.0000)
INSERT [dbo].[ResidenceHallRooms] ([RoomId], [HallId], [Room], [Cost]) VALUES (9, 10, N'P01', 2100.0000)
INSERT [dbo].[ResidenceHallRooms] ([RoomId], [HallId], [Room], [Cost]) VALUES (10, 10, N'P02', 2150.0000)
INSERT [dbo].[ResidenceHallRooms] ([RoomId], [HallId], [Room], [Cost]) VALUES (11, 10, N'P03', 2200.0000)
SET IDENTITY_INSERT [dbo].[ResidenceHallRooms] OFF
/****** Object:  Table [dbo].[Reports]    Script Date: 04/23/2013 17:16:32 ******/
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
/****** Object:  Table [dbo].[GradingSystemDets]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GradingSystemDets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GradingSystemDets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GradingSystemId] [int] NOT NULL,
	[LMark] [float] NOT NULL,
	[UMark] [float] NOT NULL,
	[Grade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Point] [float] NULL,
 CONSTRAINT [PK_GradingSystemDets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
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
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (1, 1, 0, 29, N'E         ', 1)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (2, 1, 30, 34, N'D-        ', 2)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (3, 1, 35, 39, N'D         ', 3)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (4, 1, 40, 44, N'D+        ', 4)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (6, 1, 45, 49, N'C-        ', 5)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (7, 1, 50, 54, N'C         ', 6)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (8, 1, 55, 59, N'C+        ', 7)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (9, 1, 60, 64, N'B-        ', 8)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (13, 1, 65, 69, N'B         ', 9)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (14, 1, 70, 74, N'B+        ', 10)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (15, 1, 75, 79, N'A-        ', 11)
INSERT [dbo].[GradingSystemDets] ([ID], [GradingSystemId], [LMark], [UMark], [Grade], [Point]) VALUES (16, 1, 80, 100, N'A         ', 12)
SET IDENTITY_INSERT [dbo].[GradingSystemDets] OFF
/****** Object:  Table [dbo].[FeeStructureOthers]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeStructureOthers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FeeStructureOthers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeStructureId] [int] NULL,
	[AccountId] [int] NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Amount] [money] NOT NULL,
	[AmountPeriod] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ApplicableTo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_FeeStructureOthers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[FeeStructureOthers] ON
INSERT [dbo].[FeeStructureOthers] ([Id], [FeeStructureId], [AccountId], [Description], [Amount], [AmountPeriod], [ApplicableTo]) VALUES (1, 1, 9, N'Medical', 2500.0000, N'D', N'samson')
INSERT [dbo].[FeeStructureOthers] ([Id], [FeeStructureId], [AccountId], [Description], [Amount], [AmountPeriod], [ApplicableTo]) VALUES (2, 1, 2, N'Caution Money', 2500.0000, N'S', N'Limuru')
INSERT [dbo].[FeeStructureOthers] ([Id], [FeeStructureId], [AccountId], [Description], [Amount], [AmountPeriod], [ApplicableTo]) VALUES (3, 2, 18, N'University ID', 500.0000, N'Y', N'limuru')
SET IDENTITY_INSERT [dbo].[FeeStructureOthers] OFF
/****** Object:  Table [dbo].[FeeStructureAcademic]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FeeStructureAcademic]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FeeStructureAcademic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeeStructureId] [int] NULL,
	[SchoolClassId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Amount] [money] NOT NULL,
	[AmountPeriod] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_FeeStructureDet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[FeeStructureAcademic] ON
INSERT [dbo].[FeeStructureAcademic] ([Id], [FeeStructureId], [SchoolClassId], [AccountId], [Description], [Amount], [AmountPeriod]) VALUES (2, 1, 1, 18, N'Tuition', 30000.0000, N'S')
INSERT [dbo].[FeeStructureAcademic] ([Id], [FeeStructureId], [SchoolClassId], [AccountId], [Description], [Amount], [AmountPeriod]) VALUES (3, 1, 1, 19, N'Exam', 2500.0000, N'S')
INSERT [dbo].[FeeStructureAcademic] ([Id], [FeeStructureId], [SchoolClassId], [AccountId], [Description], [Amount], [AmountPeriod]) VALUES (4, 1, 1, 33, N'Library', 1000.0000, N'R')
INSERT [dbo].[FeeStructureAcademic] ([Id], [FeeStructureId], [SchoolClassId], [AccountId], [Description], [Amount], [AmountPeriod]) VALUES (5, 1, 1, 1, N'Activity Fees', 1000.0000, N'S')
INSERT [dbo].[FeeStructureAcademic] ([Id], [FeeStructureId], [SchoolClassId], [AccountId], [Description], [Amount], [AmountPeriod]) VALUES (6, 2, 2, 1, N'Tuition', 50000.0000, N'D')
SET IDENTITY_INSERT [dbo].[FeeStructureAcademic] OFF
/****** Object:  Table [dbo].[RegisteredExams]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegisteredExams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RegisteredExams](
	[RegdExamId] [int] IDENTITY(1,1) NOT NULL,
	[ExamId] [int] NOT NULL,
	[ExamTypeId] [int] NOT NULL,
	[RoomId] [int] NULL,
	[ExamDate] [date] NULL,
	[LastModified] [datetime] NULL,
	[Invilgilator] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Contribution] [float] NULL,
	[ContributionFlag] [bit] NOT NULL,
 CONSTRAINT [PK_RegisteredExams] PRIMARY KEY CLUSTERED 
(
	[RegdExamId] ASC
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
SET IDENTITY_INSERT [dbo].[RegisteredExams] ON
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (2, 32, 2, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A700DD7480 AS DateTime), N'ds', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (3, 32, 3, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A700E23D63 AS DateTime), N'gg', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (4, 33, 3, 3, CAST(0x02370B00 AS Date), CAST(0x0000A1A7013BC221 AS DateTime), N'3256', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (5, 34, 3, 3, CAST(0x02370B00 AS Date), CAST(0x0000A1A7013BD717 AS DateTime), N'6256', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (6, 37, 1, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A7013BF87C AS DateTime), N'52', N'sys', NULL, 0, 1)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (7, 38, 3, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A7013CA30F AS DateTime), N'22', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (8, 39, 4, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A7013CE9C2 AS DateTime), N'564', N'sys', NULL, 0, 1)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (9, 37, 3, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A7013CFA06 AS DateTime), N'645', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (10, 39, 3, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A7013D0800 AS DateTime), N'56749', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (11, 36, 3, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A70156D319 AS DateTime), N'4', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (12, 35, 3, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A70156DCE3 AS DateTime), N'448', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (13, 35, 4, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A70156ECB7 AS DateTime), N'4', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (14, 34, 4, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A70156F64B AS DateTime), N'4764', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (15, 33, 4, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A701570197 AS DateTime), N'7474', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (16, 32, 4, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A701570FB0 AS DateTime), N'8784', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (17, 38, 4, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A701571B33 AS DateTime), N'4774', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (18, 40, 3, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A7015724D1 AS DateTime), N'747489', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (19, 40, 4, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A701572D57 AS DateTime), N'789', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (20, 46, 3, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A70157345F AS DateTime), N'7489', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (21, 46, 4, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A701573B2D AS DateTime), N'789', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (22, 47, 3, 1, CAST(0x02370B00 AS Date), CAST(0x0000A1A70157442C AS DateTime), N'7896', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (23, 47, 4, 2, CAST(0x02370B00 AS Date), CAST(0x0000A1A701574C39 AS DateTime), N'798674', N'sys', NULL, 0, 0)
INSERT [dbo].[RegisteredExams] ([RegdExamId], [ExamId], [ExamTypeId], [RoomId], [ExamDate], [LastModified], [Invilgilator], [ModifiedBy], [Status], [Contribution], [ContributionFlag]) VALUES (24, 36, 1, 2, CAST(0x03370B00 AS Date), CAST(0x0000A1A800B2B3BF AS DateTime), N'78', N'sys', NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[RegisteredExams] OFF
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 04/23/2013 17:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SchoolClasses](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ShortCode] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClassName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProgrammeYearId] [int] NOT NULL,
	[NoOfSubjects] [int] NOT NULL,
	[ClassTeacher] [int] NULL,
	[CurrentYrLevel] [int] NULL,
	[NextYrLevel] [int] NULL,
	[Remarks] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_SchoolClasses] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND name = N'IX_FK_Class_FK00')
CREATE NONCLUSTERED INDEX [IX_FK_Class_FK00] ON [dbo].[SchoolClasses] 
(
	[ClassTeacher] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SchoolClasses]') AND name = N'IX_FK_SchoolClasses_Programmes')
CREATE NONCLUSTERED INDEX [IX_FK_SchoolClasses_Programmes] ON [dbo].[SchoolClasses] 
(
	[ProgrammeYearId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET IDENTITY_INSERT [dbo].[SchoolClasses] ON
INSERT [dbo].[SchoolClasses] ([ClassId], [ShortCode], [ClassName], [ProgrammeYearId], [NoOfSubjects], [ClassTeacher], [CurrentYrLevel], [NextYrLevel], [Remarks]) VALUES (1, N'FORM1', N'FORM 1  2013', 6, 7, 1, 1, 2, N'1')
INSERT [dbo].[SchoolClasses] ([ClassId], [ShortCode], [ClassName], [ProgrammeYearId], [NoOfSubjects], [ClassTeacher], [CurrentYrLevel], [NextYrLevel], [Remarks]) VALUES (2, N'FORM2', N'FORM 2 2013', 7, 7, 2, 2, 3, N'1')
INSERT [dbo].[SchoolClasses] ([ClassId], [ShortCode], [ClassName], [ProgrammeYearId], [NoOfSubjects], [ClassTeacher], [CurrentYrLevel], [NextYrLevel], [Remarks]) VALUES (3, N'FORM3', N'FORM 3 2013', 8, 7, 4, 3, 4, N'1')
INSERT [dbo].[SchoolClasses] ([ClassId], [ShortCode], [ClassName], [ProgrammeYearId], [NoOfSubjects], [ClassTeacher], [CurrentYrLevel], [NextYrLevel], [Remarks]) VALUES (4, N'FORM4', N'FORM 4 2013', 14, 5, 5, 4, NULL, N'1')
SET IDENTITY_INSERT [dbo].[SchoolClasses] OFF
/****** Object:  View [dbo].[vwBankBranches]    Script Date: 04/23/2013 17:16:33 ******/
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
/****** Object:  Table [dbo].[StudentsExamResults]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResults]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentsExamResults](
	[StudentExamResultId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[Examid] [int] NOT NULL,
	[SchoolClass] [int] NOT NULL,
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
 CONSTRAINT [PK_StudentExamProgresses] PRIMARY KEY CLUSTERED 
(
	[StudentExamResultId] ASC
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
SET IDENTITY_INSERT [dbo].[StudentsExamResults] ON
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6155, 14, 32, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6156, 17, 32, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6157, 33, 32, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6158, 32, 32, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6159, 31, 32, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6160, 16, 32, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6161, 13, 32, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6162, 14, 33, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6163, 17, 33, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6164, 33, 33, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6165, 32, 33, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6166, 31, 33, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6167, 16, 33, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6168, 13, 33, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6169, 20, 37, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6170, 18, 37, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6171, 21, 37, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6172, 22, 37, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6173, 20, 38, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6174, 21, 38, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6175, 18, 38, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6176, 22, 38, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6177, 20, 39, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6178, 21, 39, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6179, 18, 39, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6180, 22, 39, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6181, 20, 40, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6182, 21, 40, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6183, 18, 40, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6184, 22, 40, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6185, 20, 46, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6186, 21, 46, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6187, 18, 46, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6188, 22, 46, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6189, 20, 47, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6190, 21, 47, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6191, 18, 47, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6192, 22, 47, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6193, 20, 48, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6194, 21, 48, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6195, 18, 48, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6196, 22, 48, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6197, 17, 34, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6198, 14, 34, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6199, 33, 34, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6200, 32, 34, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6201, 13, 34, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6202, 31, 34, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6203, 16, 34, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6204, 17, 35, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6205, 14, 35, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6206, 33, 35, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6207, 32, 35, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6208, 13, 35, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6209, 31, 35, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6210, 16, 35, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6211, 17, 36, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6212, 14, 36, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6213, 33, 36, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6214, 32, 36, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6215, 13, 36, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6216, 31, 36, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentsExamResults] ([StudentExamResultId], [StudentId], [Examid], [SchoolClass], [TeacherId], [TotalMarks_Target], [TotalPoints_Target], [Position_Target], [MeanMarks_Target], [MeanGrade_Target], [TotalMarks], [TotalPoints], [Position], [MeanMarks], [MeanGrade], [ClassTeacherRemark], [HeadTeacherRemark], [Status]) VALUES (6217, 16, 36, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StudentsExamResults] OFF
/****** Object:  Table [dbo].[Transactions]    Script Date: 04/23/2013 17:16:33 ******/
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
	[PostDate] [datetime] NOT NULL,
	[RecordDate] [datetime] NOT NULL,
	[ValueDate] [datetime] NULL,
	[Narrative] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StatementFlag] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Authorizer] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserID] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Transactions]') AND name = N'IX_FK_Transactions_Accounts')
CREATE NONCLUSTERED INDEX [IX_FK_Transactions_Accounts] ON [dbo].[Transactions] 
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
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (209, 2, 20, 4000.0000, CAST(0x0000A19900B3E81A AS DateTime), CAST(0x0000A19900B3E81A AS DateTime), CAST(0x0000A19900B3E818 AS DateTime), N'tour contribution', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (210, 2, 3, -5000.0000, CAST(0x0000A19900B40C72 AS DateTime), CAST(0x0000A19900B40C72 AS DateTime), CAST(0x0000A19900B40C72 AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (211, 2, 19, 5000.0000, CAST(0x0000A19900B40C72 AS DateTime), CAST(0x0000A19900B40C72 AS DateTime), CAST(0x0000A19900B40C72 AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (212, 3, 26, 600.0000, CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (213, 3, 6, 600.0000, CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (214, 3, 3, 600.0000, CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (215, 2, 8, 1000.0000, CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), N'medical fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (216, 2, 21, 1000.0000, CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), N'medical fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (217, 2, 24, 1000.0000, CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), N'medical fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (218, 2, 28, 1000.0000, CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), N'medical fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (219, 2, 31, 1000.0000, CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), CAST(0x0000A19900B48A8F AS DateTime), N'medical fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (220, 1, 3, -9050.0000, CAST(0x0000A199010F0B60 AS DateTime), CAST(0x0000A199010F0B60 AS DateTime), CAST(0x0000A199010F0B61 AS DateTime), N'examination fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (221, 1, 19, 9050.0000, CAST(0x0000A199010F0B60 AS DateTime), CAST(0x0000A199010F0B60 AS DateTime), CAST(0x0000A199010F0B61 AS DateTime), N'examination fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (222, 3, 18, 300500.0000, CAST(0x0000A19900000000 AS DateTime), CAST(0x0000A19900000000 AS DateTime), CAST(0x0000A19900000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (223, 3, 1, -300500.0000, CAST(0x0000A19900000000 AS DateTime), CAST(0x0000A19900000000 AS DateTime), CAST(0x0000A19900000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (224, 3, 18, 143000.0000, CAST(0x0000A19C00000000 AS DateTime), CAST(0x0000A19C00000000 AS DateTime), CAST(0x0000A19C00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (225, 3, 1, -143000.0000, CAST(0x0000A19C00000000 AS DateTime), CAST(0x0000A19C00000000 AS DateTime), CAST(0x0000A19C00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (226, 3, 22, -3500.0000, CAST(0x0000A19C01374F32 AS DateTime), CAST(0x0000A19C01374F32 AS DateTime), CAST(0x0000A19C01374F32 AS DateTime), N'charge fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (227, 3, 19, 3500.0000, CAST(0x0000A19C01374F32 AS DateTime), CAST(0x0000A19C01374F32 AS DateTime), CAST(0x0000A19C01374F32 AS DateTime), N'deposit fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (228, 3, 18, 218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (229, 3, 1, -218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (230, 3, 18, 218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (231, 3, 1, -218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (232, 3, 18, 218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (233, 3, 1, -218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (234, 3, 18, 218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (235, 3, 1, -218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (236, 3, 18, 218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (237, 3, 1, -218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (238, 3, 18, 218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (239, 3, 1, -218500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (240, 3, 18, 236500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (241, 3, 1, -236500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (242, 3, 18, 44500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (243, 3, 1, -44500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (244, 3, 18, 79500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (245, 3, 1, -79500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (246, 3, 18, 254500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (247, 3, 1, -254500.0000, CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), CAST(0x0000A19D00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (248, 1, 1, 100000.0000, CAST(0x0000A19D00C8DFEC AS DateTime), CAST(0x0000A19D00C8DFEC AS DateTime), CAST(0x0000A19D00C8DFEB AS DateTime), N'40000', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (249, 1, 1, 30000.0000, CAST(0x0000A19D00C96901 AS DateTime), CAST(0x0000A19D00C96901 AS DateTime), CAST(0x0000A19D00C96900 AS DateTime), N'1122322', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (250, 3, 18, 275500.0000, CAST(0x0000964B00000000 AS DateTime), CAST(0x0000964B00000000 AS DateTime), CAST(0x0000964B00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (251, 3, 1, -275500.0000, CAST(0x0000964B00000000 AS DateTime), CAST(0x0000964B00000000 AS DateTime), CAST(0x0000964B00000000 AS DateTime), N'Tuition Fees', N'Y', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (252, 3, 6, 2500.0000, CAST(0x0000964B00CEE761 AS DateTime), CAST(0x0000964B00CEE761 AS DateTime), CAST(0x0000964B00CEE75C AS DateTime), N'examination fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (253, 2, 3, -2500.0000, CAST(0x0000964B00CF5D14 AS DateTime), CAST(0x0000964B00CF5D14 AS DateTime), CAST(0x0000964B00CF5D14 AS DateTime), N'examination fee', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (254, 2, 19, 2500.0000, CAST(0x0000964B00CF5D14 AS DateTime), CAST(0x0000964B00CF5D14 AS DateTime), CAST(0x0000964B00CF5D14 AS DateTime), N'examination fee', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (255, 1, 1, 6500.0000, CAST(0x0000964B00D0A3A6 AS DateTime), CAST(0x0000964B00D0A3A6 AS DateTime), CAST(0x0000964B00D0A3A6 AS DateTime), N'school fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (256, 3, 8, 100000.0000, CAST(0x0000964B00D0A3A6 AS DateTime), CAST(0x0000964B00D0A3A6 AS DateTime), CAST(0x0000964B00D0A3A6 AS DateTime), N'medical fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (257, 3, 22, 100000.0000, CAST(0x0000964B00D0A3A6 AS DateTime), CAST(0x0000964B00D0A3A6 AS DateTime), CAST(0x0000964B00D0A3A6 AS DateTime), N'examination fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (258, 3, 30, 50000.0000, CAST(0x0000964B00D0A3A6 AS DateTime), CAST(0x0000964B00D0A3A6 AS DateTime), CAST(0x0000964B00D0A3A6 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (259, 3, 7, -45000.0000, CAST(0x0000964B00D25259 AS DateTime), CAST(0x0000964B00D25259 AS DateTime), CAST(0x0000964B00D25259 AS DateTime), N'tuition fee', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (260, 3, 18, 45000.0000, CAST(0x0000964B00D25259 AS DateTime), CAST(0x0000964B00D25259 AS DateTime), CAST(0x0000964B00D25259 AS DateTime), N'tuition fee', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (261, 3, 9, -50000.0000, CAST(0x0000964B00D2E88D AS DateTime), CAST(0x0000964B00D2E88D AS DateTime), CAST(0x0000964B00D2E891 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (262, 3, 18, 50000.0000, CAST(0x0000964B00D2E88D AS DateTime), CAST(0x0000964B00D2E88D AS DateTime), CAST(0x0000964B00D2E891 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (263, 1, 1, -32000.0000, CAST(0x0000964B00D31AFA AS DateTime), CAST(0x0000964B00D31AFA AS DateTime), CAST(0x0000964B00D31AFA AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (264, 1, 1, 32000.0000, CAST(0x0000964B00D31AFA AS DateTime), CAST(0x0000964B00D31AFA AS DateTime), CAST(0x0000964B00D31AFA AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (265, 3, 25, -52000.0000, CAST(0x0000964B00D39737 AS DateTime), CAST(0x0000964B00D39737 AS DateTime), CAST(0x0000964B00D39737 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (266, 3, 18, 52000.0000, CAST(0x0000964B00D39737 AS DateTime), CAST(0x0000964B00D39737 AS DateTime), CAST(0x0000964B00D39737 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (267, 1, 25, -1200.0000, CAST(0x0000A1A0013AC1C0 AS DateTime), CAST(0x0000A1A0013AC1C0 AS DateTime), CAST(0x0000A1AD013AC0F4 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (268, 1, 18, 1200.0000, CAST(0x0000A1A0013AC1C0 AS DateTime), CAST(0x0000A1A0013AC1C0 AS DateTime), CAST(0x0000A1AD013AC0F4 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (269, 3, 6, 3400.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1AC013AEEA8 AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (270, 3, 30, 3400.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (271, 3, 25, 3400.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (272, 3, 7, 3400.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (273, 3, 33, 3400.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (274, 3, 34, 3400.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (275, 3, 22, 5000.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (276, 3, 6, 5000.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (277, 3, 40, 5000.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'exam fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (278, 3, 23, 5000.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'medical  fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (279, 3, 29, 5000.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'medical  fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (280, 3, 31, 5000.0000, CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEF89 AS DateTime), CAST(0x0000A1A0013AEEA8 AS DateTime), N'medical  fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (281, 3, 23, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'medical fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (282, 3, 23, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'medical fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (283, 3, 26, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (284, 3, 9, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (285, 3, 7, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (286, 3, 7, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (287, 3, 34, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (288, 3, 33, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (289, 3, 26, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (290, 3, 25, 5200.0000, CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), CAST(0x0000A19E013F84E0 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (291, 3, 22, 32321.0000, CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), N'carge fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (292, 3, 6, 32321.0000, CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), N'carge fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (293, 3, 20, 32321.0000, CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), N'carge fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (294, 3, 6, 32321.0000, CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), N'carge fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (295, 3, 6, 32321.0000, CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), CAST(0x0000A1A2008EDDA4 AS DateTime), N'carge fees', N'VALID', N'SYSTEM', N'sys')
INSERT [dbo].[Transactions] ([TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID]) VALUES (296, 3, 26, 45345353.0000, CAST(0x0000A1A8013E8AD9 AS DateTime), CAST(0x0000A1A8013E8AD9 AS DateTime), CAST(0x0000A1A8013E8AD9 AS DateTime), N'tuition fees', N'VALID', N'SYSTEM', N'sys')
SET IDENTITY_INSERT [dbo].[Transactions] OFF
/****** Object:  Table [dbo].[StudentsExamResultsDetail]    Script Date: 04/23/2013 17:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StudentsExamResultsDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentExamResultId] [int] NULL,
	[Subject] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mark_Target] [float] NULL,
	[Grade_Target] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mark] [float] NULL,
	[Grade] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_StudentExamResultDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[StudentsExamResultsDetail] ON
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4826, 6155, N'AGR', NULL, NULL, 68, N'B         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4827, 6156, N'AGR', NULL, NULL, 69, N'B         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4828, 6157, N'AGR', NULL, NULL, 95, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4829, 6158, N'AGR', NULL, NULL, 54, N'C         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4830, 6159, N'AGR', NULL, NULL, 54, N'C         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4831, 6160, N'AGR', NULL, NULL, 68, N'B         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4832, 6161, N'AGR', NULL, NULL, 45, N'C-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4833, 6162, N'BIO', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4834, 6163, N'BIO', NULL, NULL, 64, N'B-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4835, 6164, N'BIO', NULL, NULL, 35, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4836, 6165, N'BIO', NULL, NULL, 75, N'A-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4837, 6166, N'BIO', NULL, NULL, 62, N'B-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4838, 6167, N'BIO', NULL, NULL, 24, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4839, 6168, N'BIO', NULL, NULL, 45, N'C-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4840, 6169, N'AGR', NULL, NULL, 85, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4841, 6170, N'AGR', NULL, NULL, 85, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4842, 6171, N'AGR', NULL, NULL, 41, N'D+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4843, 6172, N'AGR', NULL, NULL, 32, N'D-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4844, 6173, N'BIO', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4845, 6174, N'BIO', NULL, NULL, 85, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4846, 6175, N'BIO', NULL, NULL, 36, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4847, 6176, N'BIO', NULL, NULL, 12, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4848, 6177, N'CHEM', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4849, 6178, N'CHEM', NULL, NULL, 85, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4850, 6179, N'CHEM', NULL, NULL, 36, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4851, 6180, N'CHEM', NULL, NULL, 12, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4852, 6181, N'CRE', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4853, 6182, N'CRE', NULL, NULL, 85, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4854, 6183, N'CRE', NULL, NULL, 36, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4855, 6184, N'CRE', NULL, NULL, 12, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4856, 6185, N'GEO', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4857, 6186, N'GEO', NULL, NULL, 85, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4858, 6187, N'GEO', NULL, NULL, 36, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4859, 6188, N'GEO', NULL, NULL, 12, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4860, 6189, N'COM SKILL', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4861, 6190, N'COM SKILL', NULL, NULL, 85, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4862, 6191, N'COM SKILL', NULL, NULL, 36, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4863, 6192, N'COM SKILL', NULL, NULL, 12, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4864, 6193, N'KISW', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4865, 6194, N'KISW', NULL, NULL, 85, N'A         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4866, 6195, N'KISW', NULL, NULL, 36, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4867, 6196, N'KISW', NULL, NULL, 12, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4868, 6197, N'BS', NULL, NULL, 64, N'B-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4869, 6198, N'BS', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4870, 6199, N'BS', NULL, NULL, 35, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4871, 6200, N'BS', NULL, NULL, 75, N'A-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4872, 6201, N'BS', NULL, NULL, 45, N'C-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4873, 6202, N'BS', NULL, NULL, 62, N'B-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4874, 6203, N'BS', NULL, NULL, 24, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4875, 6204, N'CALC', NULL, NULL, 64, N'B-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4876, 6205, N'CALC', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4877, 6206, N'CALC', NULL, NULL, 35, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4878, 6207, N'CALC', NULL, NULL, 75, N'A-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4879, 6208, N'CALC', NULL, NULL, 45, N'C-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4880, 6209, N'CALC', NULL, NULL, 62, N'B-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4881, 6210, N'CALC', NULL, NULL, 24, N'E         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4882, 6211, N'CRE', NULL, NULL, 64, N'B-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4883, 6212, N'CRE', NULL, NULL, 74, N'B+        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4884, 6213, N'CRE', NULL, NULL, 35, N'D         ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4885, 6214, N'CRE', NULL, NULL, 75, N'A-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4886, 6215, N'CRE', NULL, NULL, 45, N'C-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4887, 6216, N'CRE', NULL, NULL, 62, N'B-        ')
INSERT [dbo].[StudentsExamResultsDetail] ([Id], [StudentExamResultId], [Subject], [Mark_Target], [Grade_Target], [Mark], [Grade]) VALUES (4888, 6217, N'CRE', NULL, NULL, 24, N'E         ')
SET IDENTITY_INSERT [dbo].[StudentsExamResultsDetail] OFF
/****** Object:  Table [dbo].[StudentExams]    Script Date: 04/23/2013 17:16:33 ******/
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
	[Status] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastModified] [datetime] NULL,
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
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (619, 13, 3, 45, NULL, N'sys', CAST(0x0000A1A701107958 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (620, 31, 3, 54, NULL, N'sys', CAST(0x0000A1A7011079D9 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (621, 32, 3, 54, NULL, N'sys', CAST(0x0000A1A7011079E7 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (622, 14, 3, 68, NULL, N'sys', CAST(0x0000A1A7011079F6 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (623, 16, 3, 68, NULL, N'sys', CAST(0x0000A1A701107A04 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (624, 33, 3, 95, NULL, N'sys', CAST(0x0000A1A701107A12 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (625, 17, 3, 69, NULL, N'sys', CAST(0x0000A1A701107A21 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (626, 13, 2, 45, NULL, N'sys', CAST(0x0000A1A7011082BF AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (627, 31, 2, 62, NULL, N'sys', CAST(0x0000A1A7011082CC AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (628, 32, 2, 75, NULL, N'sys', CAST(0x0000A1A7011082D9 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (629, 14, 2, 74, NULL, N'sys', CAST(0x0000A1A7011082F8 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (630, 16, 2, 24, NULL, N'sys', CAST(0x0000A1A70110830A AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (631, 33, 2, 35, NULL, N'sys', CAST(0x0000A1A701108317 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (632, 17, 2, 64, NULL, N'sys', CAST(0x0000A1A701108325 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (633, 20, 7, 85, NULL, N'sys', CAST(0x0000A1A7013D3A92 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (634, 21, 7, 41, NULL, N'sys', CAST(0x0000A1A7013D3AAF AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (635, 22, 7, 32, NULL, N'sys', CAST(0x0000A1A7013D3ABC AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (636, 18, 7, 85, NULL, N'sys', CAST(0x0000A1A7013D3AE3 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (637, 20, 6, 74, NULL, N'sys', CAST(0x0000A1A7015543E4 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (638, 21, 6, 85, NULL, N'sys', CAST(0x0000A1A7015543F8 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (639, 22, 6, 12, NULL, N'sys', CAST(0x0000A1A701554408 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (640, 18, 6, 36, NULL, N'sys', CAST(0x0000A1A701554416 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (641, 20, 8, 42, NULL, N'sys', CAST(0x0000A1A70156B776 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (642, 21, 8, 69, NULL, N'sys', CAST(0x0000A1A70156B7D1 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (643, 22, 8, 32, NULL, N'sys', CAST(0x0000A1A70156B7DC AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (644, 18, 8, 32, NULL, N'sys', CAST(0x0000A1A70156B7EA AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (645, 13, 13, 41, NULL, N'sys', CAST(0x0000A1A7015781CE AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (646, 31, 13, 15, NULL, N'sys', CAST(0x0000A1A7015781DC AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (647, 32, 13, 25, NULL, N'sys', CAST(0x0000A1A7015781EE AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (648, 14, 13, 54, NULL, N'sys', CAST(0x0000A1A7015781FB AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (649, 16, 13, 24, NULL, N'sys', CAST(0x0000A1A70157820E AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (650, 33, 13, 63, NULL, N'sys', CAST(0x0000A1A70157821B AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (651, 17, 13, 74, NULL, N'sys', CAST(0x0000A1A701578227 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (652, 13, 14, NULL, NULL, N'sys', CAST(0x0000A1A701578241 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (653, 31, 14, NULL, NULL, N'sys', CAST(0x0000A1A70157824B AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (654, 32, 14, NULL, NULL, N'sys', CAST(0x0000A1A70157825C AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (655, 14, 14, NULL, NULL, N'sys', CAST(0x0000A1A701578267 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (656, 16, 14, NULL, NULL, N'sys', CAST(0x0000A1A70157827B AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (657, 33, 14, NULL, NULL, N'sys', CAST(0x0000A1A701578286 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (658, 17, 14, NULL, NULL, N'sys', CAST(0x0000A1A701578292 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (659, 13, 15, NULL, NULL, N'sys', CAST(0x0000A1A7015782AC AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (660, 31, 15, NULL, NULL, N'sys', CAST(0x0000A1A7015782B6 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (661, 32, 15, NULL, NULL, N'sys', CAST(0x0000A1A7015782C5 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (662, 14, 15, NULL, NULL, N'sys', CAST(0x0000A1A7015782D1 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (663, 16, 15, NULL, NULL, N'sys', CAST(0x0000A1A7015782DD AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (664, 33, 15, NULL, NULL, N'sys', CAST(0x0000A1A7015782E7 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (665, 17, 15, NULL, NULL, N'sys', CAST(0x0000A1A7015782F2 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (666, 13, 16, NULL, NULL, N'sys', CAST(0x0000A1A701578306 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (667, 31, 16, NULL, NULL, N'sys', CAST(0x0000A1A701578310 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (668, 32, 16, NULL, NULL, N'sys', CAST(0x0000A1A70157831A AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (669, 14, 16, NULL, NULL, N'sys', CAST(0x0000A1A701578323 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (670, 16, 16, NULL, NULL, N'sys', CAST(0x0000A1A70157832D AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (671, 33, 16, NULL, NULL, N'sys', CAST(0x0000A1A701578337 AS DateTime))
INSERT [dbo].[StudentExams] ([Id], [StudentId], [RegdExamId], [Mark], [Status], [ModifiedBy], [LastModified]) VALUES (672, 17, 16, NULL, NULL, N'sys', CAST(0x0000A1A701578341 AS DateTime))
SET IDENTITY_INSERT [dbo].[StudentExams] OFF
/****** Object:  Table [dbo].[ClassSubjects]    Script Date: 04/23/2013 17:16:31 ******/
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
	[SubjectTeacher] [int] NULL,
	[Status] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Room] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ClassSubjects] PRIMARY KEY CLUSTERED 
(
	[ClassSubjectId] ASC
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
SET IDENTITY_INSERT [dbo].[ClassSubjects] ON
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (1, 1, N'AGR', 1, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (2, 1, N'BIO', 2, N'N', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (3, 1, N'CALC', 1, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (4, 3, N'BIO', 2, N'N', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (5, 3, N'AGR', 2, N'N', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (6, 3, N'BS', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (7, 1, N'BS', 5, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (8, 4, N'CRE', 1, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (9, 4, N'FM', 5, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (10, 4, N'COMM', 10, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (11, 1, N'CRE', 1, N'A', N'3')
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (12, 2, N'BIO', 1, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (13, 2, N'AGR', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (14, 2, N'CRE', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (15, 2, N'CHEM', 5, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (17, 1, N'HIST', 14, NULL, NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (19, 4, N'AGR', 14, N'A', N'1a')
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (20, 4, N'BIO', 10, N'A', N'1a')
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (21, 4, N'COM SKILL', 10, N'A', N'1a')
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (25, 2, N'KISW', 4, N'A', N'1l')
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (26, 2, N'COM SKILL', 4, N'A', N'1l')
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (27, 2, N'COMSYSORG', 4, N'A', N'1l')
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (28, 2, N'GEO', 4, N'A', N'1l')
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (29, 1, N'COMSYSORG', 4, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (30, 1, N'COM SKILL', 4, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (31, 1, N'FM', 4, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (33, 3, N'COM SKILL', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (34, 3, N'COMSYSORG', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (35, 3, N'FM', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (36, 3, N'HIST', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (37, 3, N'HSC', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (38, 3, N'MUSIC', 2, N'A', NULL)
INSERT [dbo].[ClassSubjects] ([ClassSubjectId], [ClassId], [SubjectCode], [SubjectTeacher], [Status], [Room]) VALUES (39, 3, N'MATH', 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ClassSubjects] OFF
/****** Object:  ForeignKey [FK_Accounts_AccountTypes]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_AccountTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_AccountTypes] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_AccountTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_AccountTypes]
GO
/****** Object:  ForeignKey [FK_Accounts_COA]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_COA]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_COA] FOREIGN KEY([COAId])
REFERENCES [dbo].[COA] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_COA]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_COA]
GO
/****** Object:  ForeignKey [FK_Accounts_Customers]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Customers]
GO
/****** Object:  ForeignKey [FK_Attendances_Students]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendances_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [FK_Attendances_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Attendances_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Attendances]'))
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [FK_Attendances_Students]
GO
/****** Object:  ForeignKey [FK_BankBranch_Banks]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[BankBranches]'))
ALTER TABLE [dbo].[BankBranches]  WITH CHECK ADD  CONSTRAINT [FK_BankBranch_Banks] FOREIGN KEY([BankCode])
REFERENCES [dbo].[Banks] ([BankCode])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[BankBranches]'))
ALTER TABLE [dbo].[BankBranches] CHECK CONSTRAINT [FK_BankBranch_Banks]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_SchoolClasses]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_SchoolClasses]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ClassSubjects_SchoolClasses] FOREIGN KEY([ClassId])
REFERENCES [dbo].[SchoolClasses] ([ClassId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_SchoolClasses]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] CHECK CONSTRAINT [FK_ClassSubjects_SchoolClasses]
GO
/****** Object:  ForeignKey [FK_ClassSubjects_Subjects]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ClassSubjects_Subjects] FOREIGN KEY([SubjectCode])
REFERENCES [dbo].[Subjects] ([ShortCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassSubjects]'))
ALTER TABLE [dbo].[ClassSubjects] CHECK CONSTRAINT [FK_ClassSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_Discipline_DisciplinaryCategories]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Discipline_DisciplinaryCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Discipline]'))
ALTER TABLE [dbo].[Discipline]  WITH CHECK ADD  CONSTRAINT [FK_Discipline_DisciplinaryCategories] FOREIGN KEY([DisciplineCategoryId])
REFERENCES [dbo].[DisciplinaryCategories] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Discipline_DisciplinaryCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[Discipline]'))
ALTER TABLE [dbo].[Discipline] CHECK CONSTRAINT [FK_Discipline_DisciplinaryCategories]
GO
/****** Object:  ForeignKey [FK_Discipline_Students]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Discipline_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Discipline]'))
ALTER TABLE [dbo].[Discipline]  WITH CHECK ADD  CONSTRAINT [FK_Discipline_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Discipline_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[Discipline]'))
ALTER TABLE [dbo].[Discipline] CHECK CONSTRAINT [FK_Discipline_Students]
GO
/****** Object:  ForeignKey [FK_Exam_ExamPeriod]    Script Date: 04/23/2013 17:16:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Exam_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[Exam]'))
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_ExamPeriod] FOREIGN KEY([ExamPeriodId])
REFERENCES [dbo].[ExamPeriod] ([ExamPeriodId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Exam_ExamPeriod]') AND parent_object_id = OBJECT_ID(N'[dbo].[Exam]'))
ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_ExamPeriod]
GO
/****** Object:  ForeignKey [FK_FeeStructureAcademic_FeesStructure]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FeeStructureAcademic_FeesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[FeeStructureAcademic]'))
ALTER TABLE [dbo].[FeeStructureAcademic]  WITH CHECK ADD  CONSTRAINT [FK_FeeStructureAcademic_FeesStructure] FOREIGN KEY([FeeStructureId])
REFERENCES [dbo].[FeesStructure] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FeeStructureAcademic_FeesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[FeeStructureAcademic]'))
ALTER TABLE [dbo].[FeeStructureAcademic] CHECK CONSTRAINT [FK_FeeStructureAcademic_FeesStructure]
GO
/****** Object:  ForeignKey [FK_FeeStructureOthers_FeesStructure]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FeeStructureOthers_FeesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[FeeStructureOthers]'))
ALTER TABLE [dbo].[FeeStructureOthers]  WITH CHECK ADD  CONSTRAINT [FK_FeeStructureOthers_FeesStructure] FOREIGN KEY([FeeStructureId])
REFERENCES [dbo].[FeesStructure] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FeeStructureOthers_FeesStructure]') AND parent_object_id = OBJECT_ID(N'[dbo].[FeeStructureOthers]'))
ALTER TABLE [dbo].[FeeStructureOthers] CHECK CONSTRAINT [FK_FeeStructureOthers_FeesStructure]
GO
/****** Object:  ForeignKey [FK_GradingSystemDet_GradingSystems]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDets]'))
ALTER TABLE [dbo].[GradingSystemDets]  WITH CHECK ADD  CONSTRAINT [FK_GradingSystemDet_GradingSystems] FOREIGN KEY([GradingSystemId])
REFERENCES [dbo].[GradingSystems] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GradingSystemDet_GradingSystems]') AND parent_object_id = OBJECT_ID(N'[dbo].[GradingSystemDets]'))
ALTER TABLE [dbo].[GradingSystemDets] CHECK CONSTRAINT [FK_GradingSystemDet_GradingSystems]
GO
/****** Object:  ForeignKey [FK_LocationProperties_Locations]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LocationProperties_Locations]') AND parent_object_id = OBJECT_ID(N'[dbo].[LocationProperties]'))
ALTER TABLE [dbo].[LocationProperties]  WITH CHECK ADD  CONSTRAINT [FK_LocationProperties_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LocationProperties_Locations]') AND parent_object_id = OBJECT_ID(N'[dbo].[LocationProperties]'))
ALTER TABLE [dbo].[LocationProperties] CHECK CONSTRAINT [FK_LocationProperties_Locations]
GO
/****** Object:  ForeignKey [FK_ProgrammeCourses_Programmes]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeCourses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeYearCourses]'))
ALTER TABLE [dbo].[ProgrammeYearCourses]  WITH CHECK ADD  CONSTRAINT [FK_ProgrammeCourses_Programmes] FOREIGN KEY([ProgrammeId])
REFERENCES [dbo].[Programmes] ([ProgrammeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeCourses_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeYearCourses]'))
ALTER TABLE [dbo].[ProgrammeYearCourses] CHECK CONSTRAINT [FK_ProgrammeCourses_Programmes]
GO
/****** Object:  ForeignKey [FK_ProgrammeYears_Programmes]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeYears_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeYears]'))
ALTER TABLE [dbo].[ProgrammeYears]  WITH CHECK ADD  CONSTRAINT [FK_ProgrammeYears_Programmes] FOREIGN KEY([ProgrammeId])
REFERENCES [dbo].[Programmes] ([ProgrammeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProgrammeYears_Programmes]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProgrammeYears]'))
ALTER TABLE [dbo].[ProgrammeYears] CHECK CONSTRAINT [FK_ProgrammeYears_Programmes]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_Exam]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_Exam]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredExams_Exam] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exam] ([ExamId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_Exam]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] CHECK CONSTRAINT [FK_RegisteredExams_Exam]
GO
/****** Object:  ForeignKey [FK_RegisteredExams_ExamTypes]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredExams_ExamTypes] FOREIGN KEY([ExamTypeId])
REFERENCES [dbo].[ExamTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RegisteredExams_ExamTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[RegisteredExams]'))
ALTER TABLE [dbo].[RegisteredExams] CHECK CONSTRAINT [FK_RegisteredExams_ExamTypes]
GO
/****** Object:  ForeignKey [FK_Reports_FK00]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_FK00] FOREIGN KEY([ReportGroup])
REFERENCES [dbo].[ReportGroups] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reports_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_FK00]
GO
/****** Object:  ForeignKey [FK_ResidenceHallRooms_ResidenceHalls]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ResidenceHallRooms_ResidenceHalls]') AND parent_object_id = OBJECT_ID(N'[dbo].[ResidenceHallRooms]'))
ALTER TABLE [dbo].[ResidenceHallRooms]  WITH CHECK ADD  CONSTRAINT [FK_ResidenceHallRooms_ResidenceHalls] FOREIGN KEY([HallId])
REFERENCES [dbo].[ResidenceHalls] ([HallId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ResidenceHallRooms_ResidenceHalls]') AND parent_object_id = OBJECT_ID(N'[dbo].[ResidenceHallRooms]'))
ALTER TABLE [dbo].[ResidenceHallRooms] CHECK CONSTRAINT [FK_ResidenceHallRooms_ResidenceHalls]
GO
/****** Object:  ForeignKey [FK_Class_FK00]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Class_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses]  WITH CHECK ADD  CONSTRAINT [FK_Class_FK00] FOREIGN KEY([ClassTeacher])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Class_FK00]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses] CHECK CONSTRAINT [FK_Class_FK00]
GO
/****** Object:  ForeignKey [FK_SchoolClasses_ProgrammeYears]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SchoolClasses_ProgrammeYears]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses]  WITH CHECK ADD  CONSTRAINT [FK_SchoolClasses_ProgrammeYears] FOREIGN KEY([ProgrammeYearId])
REFERENCES [dbo].[ProgrammeYears] ([ProgrammeYearId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SchoolClasses_ProgrammeYears]') AND parent_object_id = OBJECT_ID(N'[dbo].[SchoolClasses]'))
ALTER TABLE [dbo].[SchoolClasses] CHECK CONSTRAINT [FK_SchoolClasses_ProgrammeYears]
GO
/****** Object:  ForeignKey [FK_Settings_SettingsGroups]    Script Date: 04/23/2013 17:16:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[Settings]'))
ALTER TABLE [dbo].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_SettingsGroups] FOREIGN KEY([SGroup])
REFERENCES [dbo].[SettingsGroups] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[Settings]'))
ALTER TABLE [dbo].[Settings] CHECK CONSTRAINT [FK_Settings_SettingsGroups]
GO
/****** Object:  ForeignKey [FK_StudentExams_RegisteredExams1]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams1]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams]  WITH CHECK ADD  CONSTRAINT [FK_StudentExams_RegisteredExams1] FOREIGN KEY([RegdExamId])
REFERENCES [dbo].[RegisteredExams] ([RegdExamId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_RegisteredExams1]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] CHECK CONSTRAINT [FK_StudentExams_RegisteredExams1]
GO
/****** Object:  ForeignKey [FK_StudentExams_Students]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams]  WITH CHECK ADD  CONSTRAINT [FK_StudentExams_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentExams_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentExams]'))
ALTER TABLE [dbo].[StudentExams] CHECK CONSTRAINT [FK_StudentExams_Students]
GO
/****** Object:  ForeignKey [FK_StudentProgresses_Students]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses]  WITH CHECK ADD  CONSTRAINT [FK_StudentProgresses_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentProgresses_Students]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentProgresses]'))
ALTER TABLE [dbo].[StudentProgresses] CHECK CONSTRAINT [FK_StudentProgresses_Students]
GO
/****** Object:  ForeignKey [FK_StudentsExamResults_Exam]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentsExamResults_Exam]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentsExamResults]'))
ALTER TABLE [dbo].[StudentsExamResults]  WITH CHECK ADD  CONSTRAINT [FK_StudentsExamResults_Exam] FOREIGN KEY([Examid])
REFERENCES [dbo].[Exam] ([ExamId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentsExamResults_Exam]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentsExamResults]'))
ALTER TABLE [dbo].[StudentsExamResults] CHECK CONSTRAINT [FK_StudentsExamResults_Exam]
GO
/****** Object:  ForeignKey [FK_StudentsExamResultsDetail_StudentsExamResults]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentsExamResultsDetail_StudentsExamResults]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]'))
ALTER TABLE [dbo].[StudentsExamResultsDetail]  WITH CHECK ADD  CONSTRAINT [FK_StudentsExamResultsDetail_StudentsExamResults] FOREIGN KEY([StudentExamResultId])
REFERENCES [dbo].[StudentsExamResults] ([StudentExamResultId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_StudentsExamResultsDetail_StudentsExamResults]') AND parent_object_id = OBJECT_ID(N'[dbo].[StudentsExamResultsDetail]'))
ALTER TABLE [dbo].[StudentsExamResultsDetail] CHECK CONSTRAINT [FK_StudentsExamResultsDetail_StudentsExamResults]
GO
/****** Object:  ForeignKey [FK_SubSubjects_Subjects]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects]  WITH CHECK ADD  CONSTRAINT [FK_SubSubjects_Subjects] FOREIGN KEY([Subject])
REFERENCES [dbo].[Subjects] ([ShortCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubSubjects_Subjects]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubSubjects]'))
ALTER TABLE [dbo].[SubSubjects] CHECK CONSTRAINT [FK_SubSubjects_Subjects]
GO
/****** Object:  ForeignKey [FK_TimeTable_ClassStreams]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TimeTable_ClassStreams]') AND parent_object_id = OBJECT_ID(N'[dbo].[TimeTables]'))
ALTER TABLE [dbo].[TimeTables]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_ClassStreams] FOREIGN KEY([ClassStreamId])
REFERENCES [dbo].[ClassStreams] ([ClassStreamId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TimeTable_ClassStreams]') AND parent_object_id = OBJECT_ID(N'[dbo].[TimeTables]'))
ALTER TABLE [dbo].[TimeTables] CHECK CONSTRAINT [FK_TimeTable_ClassStreams]
GO
/****** Object:  ForeignKey [FK_Transactions_Accounts]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Accounts]
GO
/****** Object:  ForeignKey [FK_Transactions_FK01]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_FK01] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[TransactionTypes] ([TransactionTypeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transactions_FK01]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transactions]'))
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_FK01]
GO
/****** Object:  ForeignKey [FK_Users_PasswordQuestion]    Script Date: 04/23/2013 17:16:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PasswordQuestion] FOREIGN KEY([PasswordQuestion])
REFERENCES [dbo].[SecurityQuestions] ([PasswordQuestion])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_PasswordQuestion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PasswordQuestion]
GO
