using System;
using System.Collections.Generic;
using System.Diagnostics;
using CommonLib;
using DAL;
//--- Add the following to make itext work
using iTextSharp.text;
using WinSBSchool.Reports.PDFBuilders;
using WinSBSchool.Reports.ViewModels;
using WinSBSchool.Reports.Views.PDF;

namespace VVX
{
    public class PDFGen
    {
        #region "Properties"
        private bool bRet = false;
        private string resourcePath;
        private string sMsg = "";
        string connection;
        Repository rep;
        SBSchoolDBEntities db;
        public string Message
        {
            get { return sMsg; }
            set { sMsg = value; }
        }
        public bool Success
        {
            get { return bRet; }
            set { bRet = value; }
        }
        #endregion "Properties"

        #region "Constructor"
        public PDFGen()
        {

        }
        public PDFGen(string ResourcePath, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            resourcePath = ResourcePath;

        }
        #endregion "Constructor"

        #region "Helper methods"
        /// <summary>
        /// Safely attempts to insert an image file into the document
        /// </summary>
        /// <param name="document">iTextSharp Document in which it needs to be inserted</param>
        /// <param name="sFilename">the name of the file to be inserted</param>
        /// <returns>false if failed to do so</returns>
        private bool DoInsertImageFile(Document document, string sFilename, bool bInsertMsg)
        {
            bool bRet = false;

            try
            {
                if (File.Exists(sFilename) == false)
                {
                    string sMsg = "Unable to find '" + sFilename + "' in the current folder.\n\n"
                                + "Would you like to locate it?";
                    if (MsgBox.Confirm(sMsg))
                        sFilename = FileDialog.GetFilenameToOpen(FileDialog.FileType.Image);
                }

                Image img = null;
                if (File.Exists(sFilename))
                {
                    this.DoGetImageFile(sFilename, out img);
                }

                if (img != null)
                {
                    document.Add(img);
                    bRet = true;
                }
                else
                {
                    if (bInsertMsg)
                        document.Add(new Paragraph(sFilename + " not found"));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

            return bRet;
        }
        public Image DoGetImageFile(string sFilename)
        {
            bool bRet = false;
            Image img = null;

            try
            {
                if (File.Exists(sFilename) == false)
                {
                    string sMsg = "Unable to find '" + sFilename + "' in the current folder.\n\n"
                                + "Would you like to locate it?";
                    if (MsgBox.Confirm(sMsg))
                        sFilename = FileDialog.GetFilenameToOpen(FileDialog.FileType.Image);
                }

                if (File.Exists(sFilename))
                {
                    img = Image.GetInstance(sFilename);
                }

                bRet = (img != null);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

            return img;
        }
        private bool DoGetImageFile(string sFilename, out Image img)
        {
            bool bRet = false;
            img = null;

            try
            {
                if (File.Exists(sFilename) == false)
                {
                    string sMsg = "Unable to find '" + sFilename + "' in the current folder.\n\n"
                                + "Would you like to locate it?";
                    if (MsgBox.Confirm(sMsg))
                        sFilename = FileDialog.GetFilenameToOpen(FileDialog.FileType.Image);
                }

                if (File.Exists(sFilename))
                {
                    img = Image.GetInstance(sFilename);
                }

                bRet = (img != null);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

            return bRet;
        }
        private bool DoLocateImageFile(ref string sFilename)
        {
            bool bRet = false;

            try
            {
                if (File.Exists(sFilename) == false)
                {
                    string sMsg = "Unable to find '" + sFilename + "' in the current folder.\n\n"
                                + "Would you like to locate it?";

                    if (MsgBox.Confirm(sMsg))
                        sFilename = FileDialog.GetFilenameToOpen(FileDialog.FileType.Image);
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

            return bRet = File.Exists(sFilename);
        }
        #endregion "Helper methods"

        #region "public methods"
        public bool ShowProgrammeCourseList(ProgrammeCourseListViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ProgrammeCourseListPDFBuilder _PdfBuilder = new ProgrammeCourseListPDFBuilder(_ViewModel, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowSecondaryMarkSheet(SecondaryMarkSheetViewModel _ViewModel, List<string> subjectcodes, string msFilePDF)
        {
            bRet = false;
            try
            {
                SecondaryMarkSheetPDFBuilder _PdfBuilder = new SecondaryMarkSheetPDFBuilder(_ViewModel, subjectcodes, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStatement(StatementViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StatementPDFBuilder _PdfBuilder = new StatementPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentAcademicReport(StudentReportFormViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentReportFormPDFBuilder _PdfBuilder = new StudentReportFormPDFBuilder(_ViewModel, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowExamResultByExamPeriodByClass(ExamResultsByClassViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ExamResultsByClassPDFBuilder _PDFBuilder = new ExamResultsByClassPDFBuilder(_ViewModel, msFilePDF, connection);
                _PDFBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowExamResultBySubject(ExamResultsBySubjectViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ExamResultsBySubjectPDFBuilder _PdfBuilder = new ExamResultsBySubjectPDFBuilder(_ViewModel, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowExamResultByExamType(ExamResultsByExamTypeViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ExamResultsByExamTypePDFBuilder _PdfBuilder = new ExamResultsByExamTypePDFBuilder(_ViewModel, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentProgressForm(StudentProgressFormViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentProgressFormPDFBuilder _PdfBuilder = new StudentProgressFormPDFBuilder(_ViewModel, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentList(StudentListViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentListPDFBuilder _PdfBuilder = new StudentListPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowTeachersList(TeachersListViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                TeachersListPDFBuilder _PdfBuilder = new TeachersListPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClassStreamTimeTable(ClassStreamTimeTableViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClassStreamTimeTablePDFBuilder _PdfBuilder = new ClassStreamTimeTablePDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowSubjectList(SubjectListViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                SubjectListPDFBuilder subjectsListPDFBuilder = new SubjectListPDFBuilder(_ViewModel, msFilePDF);
                subjectsListPDFBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClassList(ClassListViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClassListPDFBuilder classListPDFBuilder = new ClassListPDFBuilder(_ViewModel, msFilePDF, connection);
                classListPDFBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowPreSchoolMarksheeet(PreSchoolMarksheetViewModel _ViewModel, List<string> subjectcodes, string msFilePDF)
        {
            bRet = false;
            try
            {
                PreSchoolMarksheeetPDFBuilder PreSchoolMarkSheetPDFBuilder = new PreSchoolMarksheeetPDFBuilder(_ViewModel, subjectcodes, msFilePDF, connection);
                PreSchoolMarkSheetPDFBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowPrimaryMarksheet(PrimaryMarksheetViewModel _ViewModel, List<string> subjectcodes, string msFilePDF)
        {
            bRet = false;
            try
            {
                PrimaryMarksheetPDFBuilder _PdfBuilder = new PrimaryMarksheetPDFBuilder(_ViewModel, subjectcodes, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowTertiaryMarksheet(TertiaryMarksheetViewModel _ViewModel, List<string> subjectcodes, string msFilePDF)
        {
            bRet = false;
            try
            {
                TertiaryMarksheeetPDFBuilder _PdfBuilder = new TertiaryMarksheeetPDFBuilder(_ViewModel, subjectcodes, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowCollegeMarksheeet(CollegeMarksheetViewModel _ViewModel, List<string> subjectcodes, string msFilePDF)
        {
            bRet = false;
            try
            {
                CollegeMarksheetPDFBuilder _PdfBuilder = new CollegeMarksheetPDFBuilder(_ViewModel, subjectcodes, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowUniversityMarksheeet(UniversityMarksheeetViewModel _ViewModel, List<string> subjectcodes, string msFilePDF)
        {
            bRet = false;
            try
            {
                UniversityMarksheeetPDFBuilder _PdfBuilder = new UniversityMarksheeetPDFBuilder(_ViewModel, subjectcodes, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentPerformanceByTarget(StudentPerformanceByTargetViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentPerformanceByTargetPDFBuilder _PdfBuilder = new StudentPerformanceByTargetPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowTeacherReportForm(TeacherReportFormViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                TeacherReportFormPDFBuilder _PdfBuilder = new TeacherReportFormPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowTeacherProgressForm(TeacherProgressFormViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                TeacherProgressFormPDFBuilder _PdfBuilder = new TeacherProgressFormPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowTeacherPerformanceByTarget(TeacherPerformanceByTargetViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                TeacherPerformanceByTargetPDFBuilder _PdfBuilder = new TeacherPerformanceByTargetPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClassReportForm(ClassReportFormViewModel _ViewModel, List<string> subjectcodes, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClassReportFormPDFBuilder _PdfBuilder = new ClassReportFormPDFBuilder(_ViewModel, subjectcodes, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClassProgressForm(ClassProgressFormViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClassProgressFormPDFBuilder _PdfBuilder = new ClassProgressFormPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClassPerformanceByTarget(ClassPerformanceByTargetViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClassPerformanceByTargetPDFBuilder _PdfBuilder = new ClassPerformanceByTargetPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClassConsolidatedMarksheet(ClassConsolidatedMarksheetViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClassConsolidatedMarksheetPDFBuilder _PdfBuilder = new ClassConsolidatedMarksheetPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowSchoolReportForm(SchoolReportFormViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                SchoolReportFormPDFBuilder _PdfBuilder = new SchoolReportFormPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowSchoolProgressForm(SchoolProgressFormViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                SchoolProgressFormPDFBuilder _PdfBuilder = new SchoolProgressFormPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowSchoolPerformanceByTarget(SchoolPerformanceByTargetViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                SchoolPerformanceByTargetPDFBuilder _PdfBuilder = new SchoolPerformanceByTargetPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowSchoolPerformanceInTheRegion(SchoolPerformanceInTheRegionViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                SchoolPerformanceInTheRegionPDFBuilder _PfBuilder = new SchoolPerformanceInTheRegionPDFBuilder(_ViewModel, msFilePDF);
                _PfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentStatement(StudentStatementViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                WinSBSchool.Reports.Views.PDF.StudentStatementPDFBuilder _PfBuilder = new WinSBSchool.Reports.Views.PDF.StudentStatementPDFBuilder(_ViewModel, msFilePDF);
                _PfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentAccountStatus(StudentAccountStatusViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentAccountStatusPDFBuilder _PdfBuilder = new StudentAccountStatusPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentArrearsAndReceivables(StudentArrearsAndReceivablesViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentArrearsAndReceivablesPDFBuilder _PdfBuilder = new StudentArrearsAndReceivablesPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowParentStatement(ParentStatementViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                WinSBSchool.Reports.Views.PDF.ParentStatementPDFBuilder statementPdf = new WinSBSchool.Reports.Views.PDF.ParentStatementPDFBuilder(_ViewModel, msFilePDF);
                statementPdf.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowParentAccountStatus(ParentAccountStatusViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ParentAccountStatusPDFBuilder _PdfBuilder = new ParentAccountStatusPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentPaymentReceipts(PaymentReceiptsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentPaymentReceiptsPDFBuilder _PdfBuilder = new StudentPaymentReceiptsPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentFeeStructure(StudentFeeStructureViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentFeeStructurePDFBuilder _PdfBuilder = new StudentFeeStructurePDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowFeeStructureByClass(FeeStructureByClassViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                FeeStructureByClassPDFBuilder _PdfBuilder = new FeeStructureByClassPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowGeneralLegder(GeneralLegderViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                GeneralLedgerPDFBuilder _PdfBuilder = new GeneralLedgerPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowProfitAndLoss(ProfitAndLossViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ProfitAndLossPDFBuilder _PdfBuilder = new ProfitAndLossPDFBuilder(_ViewModel, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowBalanceSheet(BalanceSheetViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                BalanceSheetPDFBuilder _PdfBuilder = new BalanceSheetPDFBuilder(_ViewModel, msFilePDF, connection);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowBankStatement(BankStatementViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                WinSBSchool.Reports.Views.PDF.BankStatementPDFBuilder _PdfBuilder = new WinSBSchool.Reports.Views.PDF.BankStatementPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentDisciplineStatus(StudentDisciplineStatusViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentDisciplineStatusPDFBuilder _PdfBuilder = new StudentDisciplineStatusPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentDisciplinaryRecord(StudentDisciplinaryRecordViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentDisciplinaryRecordPDFBuilder _PdfBuilder = new StudentDisciplinaryRecordPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentExtraCurricula(StudentExtraCurriculaViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentExtraCurriculaPDFBuilder _PdfBuilder = new StudentExtraCurriculaPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentMedicalRecord(StudentMedicalRecordViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentMedicalRecordPDFBuilder _PdfBuilder = new StudentMedicalRecordPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStudentAttendanceRecord(StudentAttendanceRecordViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StudentAttendanceRecordPDFBuilder _PdfBuilder = new StudentAttendanceRecordPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        #endregion "public methods"



    }
}