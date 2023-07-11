using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class PrimaryMarksheetPDFBuilder
    {
        string sFilePDF;
        PrimaryMarksheetViewModel _ViewModel;
        string Message;
        string connection;
        SBSchoolDBEntities db;
        Document document;
        List<string> Subjects;


        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER


        public PrimaryMarksheetPDFBuilder(PrimaryMarksheetViewModel _PriMarkSheetViewModel, List<string> _Subjects, string FileName, string Conn)
        {

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);

            if (_PriMarkSheetViewModel == null)
                throw new ArgumentNullException("PrimaryMarksheetViewModel is invalid");
            _ViewModel = _PriMarkSheetViewModel;

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
                Table markSheetTable = new Table(5);
                markSheetTable.WidthPercentage = 100;
                markSheetTable.Padding = 1;
                markSheetTable.Spacing = 1;
                markSheetTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                markSheetTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                markSheetTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                markSheetTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                markSheetTable.AddCell(nullCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell Logcell = new Cell(img0);
                Logcell.HorizontalAlignment = Cell.ALIGN_LEFT;
                Logcell.Border = Cell.NO_BORDER;
                Logcell.Add(new Phrase(_ViewModel.SchoolSlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                markSheetTable.AddCell(Logcell);

                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), hFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Colspan = 5;
                reportdateCell.Border = Cell.NO_BORDER;
                markSheetTable.AddCell(reportdateCell);

                document.Add(markSheetTable);

                AddYearTerm();

             }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void AddYearTerm()
        {
            document.Add(new Phrase("\n"));

            Table resultsTable = new Table(5);
            resultsTable.WidthPercentage = 100;
            resultsTable.Alignment = Table.ALIGN_LEFT;
            resultsTable.Spacing = 1;
            resultsTable.Padding = 1;
            resultsTable.Border = Table.NO_BORDER;

            Cell formCell = new Cell(new Phrase("Class:    " + _ViewModel.ClassName, tdFont));
            formCell.Border = Cell.RECTANGLE;
            formCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            formCell.Border = Cell.NO_BORDER;
            resultsTable.AddCell(formCell);

            Cell nameCell = new Cell(new Phrase("Exam Type:   " + _ViewModel.ExamTypeShortcode, tdFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            nameCell.Border = Cell.NO_BORDER;
            resultsTable.AddCell(nameCell);

            Cell YearCell = new Cell(new Phrase("Year:     " + _ViewModel.Year.ToString(), tdFont));
            YearCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            YearCell.Border = Cell.NO_BORDER;
            resultsTable.AddCell(YearCell);

            Cell TermCell = new Cell(new Phrase("Term:     " + _ViewModel.Term.ToString(), tdFont));
            TermCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            TermCell.Border = Cell.NO_BORDER;
            TermCell.Colspan = 2;
            resultsTable.AddCell(TermCell);

            document.Add(resultsTable);

            document.Add(new Phrase("\n"));

        }


        //document body
        private void AddDocBody()
        {
            document.Add(new Phrase("\n"));
            int Cols = 4 + Subjects.Count() + 6;
            Table rsTable = new Table(Cols);
            rsTable.WidthPercentage = 100;

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
            int colsize = dif / othercols;
            for (int i = initialcols; i < Cols; i++)
            {
                colWidthPercentages[i] = colsize;
            }

            rsTable.SetWidths(colWidthPercentages);
            rsTable.Spacing = 1;
            rsTable.Padding = 1;


            AddExamTableHeaders(rsTable);

            //add table details for each _Exam 
            foreach (var item in _ViewModel.ExamResults)
            {
                AddExamTableDetails(rsTable, item);
            }

            document.Add(rsTable);

        }
        private void AddExamTableHeaders(Table rsTable)
        {
            Cell adminnoCell = new Cell(new Phrase("Admin\nNo", thFont));
            adminnoCell.Border = Cell.RECTANGLE;
            adminnoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(adminnoCell);

            Cell nameCell = new Cell(new Phrase("Name", thFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(nameCell);

            Cell clsCell = new Cell(new Phrase("Stream", thFont));
            clsCell.Border = Cell.RECTANGLE;
            clsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(clsCell);

            Cell kcpeCell = new Cell(new Phrase("KCPE\nMarks", thFont));
            kcpeCell.Border = Cell.RECTANGLE;
            kcpeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(kcpeCell);

            //add subject _Exam details
            foreach (var sub in this.Subjects)
            {
                Cell markCell = new Cell(new Phrase(sub, thFont));
                markCell.Border = Cell.RECTANGLE;
                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                rsTable.AddCell(markCell);

            }

            //add summaries
            Cell tmks = new Cell(new Phrase("T.MKS", thFont));
            tmks.Border = Cell.RECTANGLE;
            tmks.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(tmks);

            Cell mmks = new Cell(new Phrase("M.MKS", thFont));
            mmks.Border = Cell.RECTANGLE;
            mmks.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(mmks);

            Cell totalpoints = new Cell(new Phrase("T.PTS", thFont));
            totalpoints.Border = Cell.RECTANGLE;
            totalpoints.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(totalpoints);

            Cell meantotalpoints = new Cell(new Phrase("M.PTS", thFont));
            meantotalpoints.Border = Cell.RECTANGLE;
            meantotalpoints.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(meantotalpoints);

            Cell meangradeCell = new Cell(new Phrase("M.G", thFont));
            meangradeCell.Border = Cell.RECTANGLE;
            meangradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(meangradeCell);

            Cell fpCell = new Cell(new Phrase("FP", thFont));
            fpCell.Border = Cell.RECTANGLE;
            fpCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(fpCell);

        }

        private void AddExamTableDetails(Table rsTable, SecStudentMarkSheetRecord stRec)
        {

            //add _Student info
            Cell adminnoCell = new Cell(new Phrase(stRec.Student.AdminNo, tdFont));
            adminnoCell.Border = Cell.RECTANGLE;
            adminnoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            rsTable.AddCell(adminnoCell);

            Cell nameCell = new Cell(new Phrase(stRec.Student.StudentOtherNames.Trim() + "   " + stRec.Student.StudentSurName.Trim(), tdFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            rsTable.AddCell(nameCell);

            ///TODO Lookup the class
            var classStreamquery = (from cs in db.ClassStreams
                                    join st in db.Students on cs.Id equals st.ClassStreamId
                                    where st.ClassStreamId == stRec.Student.ClassStreamId
                                    select cs).FirstOrDefault();
            ClassStream _ClassStream = classStreamquery;

            Cell clsCell = new Cell(new Phrase(_ClassStream.Description.Trim(), tdFont));
            clsCell.Border = Cell.RECTANGLE;
            clsCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            rsTable.AddCell(clsCell);

            Cell kcpeCell = new Cell(new Phrase(stRec.Student.KCPE, tdFont));
            kcpeCell.Border = Cell.RECTANGLE;
            kcpeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(kcpeCell);


            //add subject _Exam details
            foreach (var sub in this.Subjects)
            {
                var rec = stRec.SubjectsExamResult.Where(s => s.SubjectCode == sub).SingleOrDefault();
                if (rec != null)
                {
                    string item = rec.Mark.ToString() + " " + rec.Grade;

                    Cell markCell = new Cell(new Phrase(item, tdFont));
                    markCell.Border = Cell.RECTANGLE;
                    markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    rsTable.AddCell(markCell);
                }
                else
                {
                    Cell markCell = new Cell(new Phrase("    ", tdFont));
                    markCell.Border = Cell.RECTANGLE;
                    markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    rsTable.AddCell(markCell);
                }
            }

            //add summaries
            Cell tmks = new Cell(new Phrase(stRec.TotalMarks.ToString(), tdFont));
            tmks.Border = Cell.RECTANGLE;
            tmks.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(tmks);

            Cell mmks = new Cell(new Phrase(string.Format("{0:.##}", stRec.MeanMarks), tdFont));
            mmks.Border = Cell.RECTANGLE;
            mmks.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(mmks);

            string tp = stRec.TotalPoints.HasValue ? stRec.TotalPoints.Value.ToString() : " ";
            Cell totalpoints = new Cell(new Phrase(tp, tdFont));
            totalpoints.Border = Cell.RECTANGLE;
            totalpoints.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(totalpoints);

            string mp = stRec.TotalPoints.HasValue ? stRec.TotalPoints.Value.ToString() : " ";
            Cell meantotalpoints = new Cell(new Phrase(mp, tdFont));
            meantotalpoints.Border = Cell.RECTANGLE;
            meantotalpoints.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(meantotalpoints);

            Cell meangradeCell = new Cell(new Phrase(stRec.MeanGrade, tdFont));
            meangradeCell.Border = Cell.RECTANGLE;
            meangradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(meangradeCell);

            Cell fpCell = new Cell(new Phrase(stRec.Rank.ToString(), tdFont));
            fpCell.Border = Cell.RECTANGLE;
            fpCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            rsTable.AddCell(fpCell);
        }

        //document footer
        private void AddDocFooter()
        {
            Table studentListTable = new Table(1);
            studentListTable.WidthPercentage = 100;
            studentListTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            studentListTable.AddCell(sgCell);

            document.Add(studentListTable);

        }


    }
}