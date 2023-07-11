using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VVX;
using WinSBSchool.Reports.Viewer;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.Views.PDF
{
    public class ClassReportFormPDFBuilder
  {
        string sFilePDF;
        ClassReportFormViewModel _ViewModel;
        string Message;
        Document document; 
        List<string> Subjects;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER 

        public ClassReportFormPDFBuilder(ClassReportFormViewModel _ClassAcademicReportFormViewModel, List<string> _Subjects,   string FileName)
        {
            if (_ClassAcademicReportFormViewModel == null)
                throw new ArgumentNullException("ClassReportFormViewModel is invalid");
            _ViewModel = _ClassAcademicReportFormViewModel;

            if (_Subjects == null)
                throw new ArgumentNullException("Subjects List is invalid");
            Subjects = _Subjects;

            
            sFilePDF = FileName;
        } 
         
        public string GetPDF()
        {
            BuildPDF();
            return sFilePDF;
        }

        /*Build the document **/
        private void BuildPDF()
        {
            try
            {
                if (System.IO.File.Exists(sFilePDF))
                {
                    System.IO.File.Delete(sFilePDF);
                }

                //step 1 creation of the document
                document = new Document(PageSize.A4.Rotate());

                // step 2:create a writer that listens to the document
                PdfWriter.GetInstance(document, new FileStream(sFilePDF, FileMode.Create));

                //open document
                document.Open();

                //document header
                AddDocHeader();

                //document body
                AddDocBody();

                //document footer
                AddDocFooter();

                //close document
                document.Close();
            }
            catch (DocumentException de)
            {
                this.Message = de.Message;
            }
            catch (IOException ioe)
            {
                this.Message = ioe.Message;
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
            } 
        }
        //document header
        private void AddDocHeader()
        {

            try
            {
                Table classReportFormTable = new Table(5);
                classReportFormTable.WidthPercentage = 100;
                classReportFormTable.Padding = 1;
                classReportFormTable.Spacing = 1;
                classReportFormTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                classReportFormTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                classReportFormTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                classReportFormTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                classReportFormTable.AddCell(nullCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell Logcell = new Cell(img0);
                Logcell.HorizontalAlignment = Cell.ALIGN_LEFT;
                Logcell.Border = Cell.NO_BORDER;
                Logcell.Add(new Phrase(_ViewModel.SchoolSlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                classReportFormTable.AddCell(Logcell);

                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), hFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Colspan = 5;
                reportdateCell.Border = Cell.NO_BORDER;
                classReportFormTable.AddCell(reportdateCell);

                Cell TermCell = new Cell(new Phrase("Term:     " + _ViewModel.Term.ToString(), hFont));
                TermCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                TermCell.Border = Cell.NO_BORDER;
                classReportFormTable.AddCell(TermCell);

                Cell YearCell = new Cell(new Phrase("Year:     " + _ViewModel.Year.ToString(), hFont));
                YearCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                YearCell.Border = Cell.NO_BORDER;
                classReportFormTable.AddCell(YearCell);

                Cell ExamTypeShortcodeCell = new Cell(new Phrase("Exam Type:     " + _ViewModel.ExamTypeShortcode.ToString(), hFont));
                ExamTypeShortcodeCell.Colspan = 2;
                ExamTypeShortcodeCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                ExamTypeShortcodeCell.Border = Cell.NO_BORDER;
                classReportFormTable.AddCell(ExamTypeShortcodeCell);


                document.Add(classReportFormTable);

            } 
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
      

        //document body
        private void AddDocBody()
        {
            document.Add(new Phrase("\n"));
            int Cols = 4 + Subjects.Count() + 6;
            Table classReportFormTable = new Table(Cols);
            classReportFormTable.WidthPercentage = 100;

            int[] colWidthPercentages = new int[Cols];
            //initialize the first 4
            int initialcols = 4;
            colWidthPercentages[0] = 5;
            colWidthPercentages[1] = 20;
            colWidthPercentages[2] = 5;
            colWidthPercentages[3] = 5;

            int others = colWidthPercentages.Sum();
            int dif = 100 - others;
            int othercols = Cols - initialcols;
            int colsize = dif /othercols;
            for (int i = initialcols; i < Cols; i++)
            {
                colWidthPercentages[i] = colsize;
            }

            classReportFormTable.SetWidths(colWidthPercentages);  
            classReportFormTable.Spacing = 1;
            classReportFormTable.Padding = 1;


            AddExamTableHeaders(classReportFormTable);

            //add table details for each _Exam 
            foreach (var item in _ViewModel.ClsExamResults)
            {
                AddExamTableDetails(classReportFormTable,item);
            }

            document.Add(classReportFormTable);

        }
        private void AddExamTableHeaders(Table classReportFormTable)
        {
            Cell adminnoCell = new Cell(new Phrase("ADMIN\n NO", thFont));
            adminnoCell.Border = Cell.RECTANGLE;
            adminnoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(adminnoCell);

            Cell nameCell = new Cell(new Phrase("NAME", thFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(nameCell);


            Cell clsCell = new Cell(new Phrase("CLASS", thFont));
            clsCell.Border = Cell.RECTANGLE;
            clsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(clsCell);

            Cell kcpeCell = new Cell(new Phrase("KCPE \nMARKS", thFont));
            kcpeCell.Border = Cell.RECTANGLE;
            kcpeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(kcpeCell);

            //add subject _Exam details
            foreach (var sub in this.Subjects)
            {
                Cell markCell = new Cell(new Phrase(sub, thFont));
                markCell.Border = Cell.RECTANGLE;
                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                classReportFormTable.AddCell(markCell);

            }

            //add summaries
            Cell tmks = new Cell(new Phrase("T.MKS", thFont));
            tmks.Border = Cell.RECTANGLE;
            tmks.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(tmks);

            Cell mmks = new Cell(new Phrase("M.MKS", thFont));
            mmks.Border = Cell.RECTANGLE;
            mmks.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(mmks);

            Cell totalpoints = new Cell(new Phrase("T.PTS", thFont));
            totalpoints.Border = Cell.RECTANGLE;
            totalpoints.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(totalpoints);

            Cell meantotalpoints = new Cell(new Phrase("M.PTS", thFont));
            meantotalpoints.Border = Cell.RECTANGLE;
            meantotalpoints.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(meantotalpoints);

            Cell meangradeCell = new Cell(new Phrase("M.G", thFont));
            meangradeCell.Border = Cell.RECTANGLE;
            meangradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(meangradeCell);

            Cell fpCell = new Cell(new Phrase("FP", thFont));
            fpCell.Border = Cell.RECTANGLE;
            fpCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(fpCell);

        }
        private void AddExamTableDetails(Table classReportFormTable, ClsStudentMarkSheetRecord stRec)
        {
            
            //add _Student info
            Cell adminnoCell = new Cell(new Phrase(stRec.Student.AdminNo, tdFont));
            adminnoCell.Border = Cell.RECTANGLE;
            adminnoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            classReportFormTable.AddCell(adminnoCell);

            Cell nameCell = new Cell(new Phrase(stRec.Student.StudentSurName , tdFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            classReportFormTable.AddCell(nameCell);

            ///TODO Lookup the class
            Cell clsCell = new Cell(new Phrase(stRec.Student.ClassStreamId.ToString(), tdFont));
            clsCell.Border = Cell.RECTANGLE;
            clsCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            classReportFormTable.AddCell(clsCell);

            Cell kcpeCell = new Cell(new Phrase(stRec.Student.KCPE.ToString(), tdFont));
            kcpeCell.Border = Cell.RECTANGLE;
            kcpeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(kcpeCell);


            //add subject _Exam details
            foreach (var sub in this.Subjects)
            {
                var rec = stRec.ClsSubjectsExamResult.Where(s => s.SubjectCode == sub).SingleOrDefault();
                if (rec != null)
                {
                    string item = rec.Mark.ToString() + " " + rec.Grade;

                    Cell markCell = new Cell(new Phrase(item, tdFont));
                    markCell.Border = Cell.RECTANGLE;
                    markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    classReportFormTable.AddCell(markCell);
                }
                else
                {
                    Cell markCell = new Cell(new Phrase("    ", tdFont));
                    markCell.Border = Cell.RECTANGLE;
                    markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    classReportFormTable.AddCell(markCell);
                }
            }

            //add summaries
            Cell tmks = new Cell(new Phrase(stRec.TotalMarks.ToString(), tdFont));
            tmks.Border = Cell.RECTANGLE;
            tmks.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(tmks);

            Cell mmks = new Cell(new Phrase(string.Format("{0:.##}", stRec.MeanMarks), tdFont));
            mmks.Border = Cell.RECTANGLE;
            mmks.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(mmks);

            string tp = stRec.TotalPoints.HasValue ? stRec.TotalPoints.Value.ToString() : " ";
            Cell totalpoints = new Cell(new Phrase(tp, tdFont));
            totalpoints.Border = Cell.RECTANGLE;
            totalpoints.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(totalpoints);

            string mp = stRec.TotalPoints.HasValue ? stRec.TotalPoints.Value.ToString() : " ";
            Cell meantotalpoints = new Cell(new Phrase(mp, tdFont));
            meantotalpoints.Border = Cell.RECTANGLE;
            meantotalpoints.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(meantotalpoints);

            Cell meangradeCell = new Cell(new Phrase(stRec.MeanGrade, tdFont));
            meangradeCell.Border = Cell.RECTANGLE;
            meangradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(meangradeCell);

            Cell fpCell = new Cell(new Phrase(stRec.Rank.ToString(), tdFont));
            fpCell.Border = Cell.RECTANGLE;
            fpCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classReportFormTable.AddCell(fpCell);
        } 
       
        //document footer
        private void AddDocFooter()
        {
            Table classReportFormTable = new Table(1);
            classReportFormTable.WidthPercentage = 100;
            classReportFormTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            classReportFormTable.AddCell(sgCell);

            document.Add(classReportFormTable); 


        }

    }
}

