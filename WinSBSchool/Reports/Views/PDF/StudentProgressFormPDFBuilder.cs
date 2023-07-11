using System; 
using System.Collections.Generic;
using System.Diagnostics; 
using System.IO; 
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CommonLib; 
using DAL; 
using iTextSharp.text;
using iTextSharp.text.pdf; 
using VVX;
using WinSBSchool.Forms;
using WinSBSchool.Reports.PDFBuilders;
using WinSBSchool.Reports.Viewer;
using WinSBSchool.Reports.ViewModelBuilders; 
using WinSBSchool.Reports.ViewModels;
using WinSBSchool.Reports.Views.PDF;

namespace WinSBSchool.Reports.Views.PDF
{
    public class StudentProgressFormPDFBuilder
     {
         
        StudentProgressFormViewModel _ViewModel;
        string Message;
        string sFilePDF;
        Document document;
        string connection;
        SBSchoolDBEntities db;
        Repository rep;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 6, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 5, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font thFont1 = new Font(Font.HELVETICA, 4, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 5, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font tdFont1 = new Font(Font.HELVETICA, 4, Font.BOLD, Color.BLACK);//TABLE BODY
        Font tdFont2 = new Font(Font.HELVETICA, 4, Font.BOLD, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 5, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER


        public StudentProgressFormPDFBuilder(StudentProgressFormViewModel _studentProgressFormViewModel, string FileName, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn is null");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (_studentProgressFormViewModel == null)
                throw new ArgumentNullException("StudentProgressFormViewModel is null");
            _ViewModel = _studentProgressFormViewModel;

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
                document = new Document(PageSize.A4);

                // step 2:create a writer that listens to the document
                PdfWriter.GetInstance(document, new FileStream(sFilePDF, FileMode.Create));

                //open document
                document.Open();

                //document header
                AddDocHeader();

                //document body
                AddDocBody();

                AddGradingDets();

                AddDocRemarks();

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
                Table reportFormTable = new Table(5);
                reportFormTable.WidthPercentage = 100;
                reportFormTable.Padding = 1;
                reportFormTable.Spacing = 1;
                reportFormTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 12, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 8, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 8, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 8, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(nullCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
                reportFormTable.AddCell(logoCell);

                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                reportFormTable.AddCell(reportdateCell);

                document.Add(reportFormTable);

                AddStudentDetails();
             }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void AddStudentDetails()
        {
            document.Add(new Phrase("\n"));

            Table reportFormTable = new Table(5);
            reportFormTable.WidthPercentage = 100;
            reportFormTable.Alignment = Table.ALIGN_LEFT;
            reportFormTable.Spacing = 1;
            reportFormTable.Padding = 1;
            reportFormTable.Border = Table.NO_BORDER;

            Cell nameCell = new Cell(new Phrase("Name: " + _ViewModel.StudentName, tdFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            nameCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(nameCell);

            Cell adminnoCell = new Cell(new Phrase("Admin No: " + _ViewModel.StudentAdminNo, tdFont));
            adminnoCell.Border = Cell.RECTANGLE;
            adminnoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            adminnoCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(adminnoCell);

            Cell formCell = new Cell(new Phrase("Form: " + _ViewModel.ClassName, tdFont));
            formCell.Border = Cell.RECTANGLE;
            formCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            formCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(formCell);

            Cell streamCell = new Cell(new Phrase("Stream: " + _ViewModel.ClassStream, tdFont));
            streamCell.Border = Cell.RECTANGLE;
            streamCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            streamCell.Border = Cell.NO_BORDER;
            streamCell.Colspan = 2;
            reportFormTable.AddCell(streamCell);

            Cell YearCell = new Cell(new Phrase("Year:     " + _ViewModel.Year.ToString(), tdFont));
            YearCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            YearCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(YearCell);

            Cell TermCell = new Cell(new Phrase("Term:     " + _ViewModel.Term.ToString(), tdFont));
            TermCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            TermCell.Border = Cell.NO_BORDER;
            TermCell.Colspan = 4;
            reportFormTable.AddCell(TermCell);

            document.Add(reportFormTable);

            //document.Add(new Phrase("\n"));

        }

        //document body
        private void AddDocBody()
        {
            try
            {
                if (_ViewModel._ExamTypes.Count() > 0)
                {
                    int Cols = 1 + _ViewModel._ExamTypes.Count() + 5;
                    Table reportFormTable = new Table(Cols, 2);
                    reportFormTable.WidthPercentage = 100;

                    int[] colWidthPercentages = new int[Cols];
                    //initialize the first 1
                    int initialcols = 1;
                    colWidthPercentages[0] = 15;
                    int others = colWidthPercentages.Sum();
                    int dif = 100 - others;
                    int othercols = Cols - initialcols;
                    int colsize = dif / othercols;

                    for (int i = initialcols; i < Cols; i++)
                    {
                        colWidthPercentages[i] = colsize;
                    }

                    reportFormTable.SetWidths(colWidthPercentages);
                    reportFormTable.Spacing = 1;
                    reportFormTable.Padding = 1;

                    AddTableHeaders(reportFormTable);


                    //Add table details  
                    foreach (var r in _ViewModel.StudentDTOExamResults)
                    {
                        AddTableDetails(reportFormTable, r);
                    }

                    document.Add(reportFormTable);

                    //Add table totals
                    AddTableTotals();
                }
                else
                {
                    int Cols = 1 + 1 + 5;
                    Table reportFormTable = new Table(Cols, 2);
                    reportFormTable.WidthPercentage = 100;

                    int[] colWidthPercentages = new int[Cols];
                    //initialize the first 1
                    int initialcols = 1;
                    colWidthPercentages[0] = 15;
                    int others = colWidthPercentages.Sum();
                    int dif = 100 - others;
                    int othercols = Cols - initialcols;
                    int colsize = dif / othercols;

                    for (int i = initialcols; i < Cols; i++)
                    {
                        colWidthPercentages[i] = colsize;
                    }

                    reportFormTable.SetWidths(colWidthPercentages);
                    reportFormTable.Spacing = 1;
                    reportFormTable.Padding = 1;

                    AddTableHeaders(reportFormTable);


                    //Add table details  
                    foreach (var r in _ViewModel.StudentDTOExamResults)
                    {
                        AddTableDetails(reportFormTable, r);
                    }

                    document.Add(reportFormTable);

                    //Add table totals
                    AddTableTotals();
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        //table headers
        private void AddTableHeaders(Table reportFormTable)
        {

            //row 1
            Cell SubjectCell = new Cell(new Phrase("Subjects", thFont));
            SubjectCell.Border = Cell.RECTANGLE;
            SubjectCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(SubjectCell);

            if (_ViewModel._ExamTypes.Count() > 0)
            {
                Cell markCell = new Cell(new Phrase("Marks", thFont));
                markCell.Border = Cell.RECTANGLE;
                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                markCell.Colspan = _ViewModel._ExamTypes.Count();
                reportFormTable.AddCell(markCell);
            }
            else
            {
                Cell markCell = new Cell(new Phrase("Marks", thFont));
                markCell.Border = Cell.RECTANGLE;
                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportFormTable.AddCell(markCell);
            }


            Cell totalmarksCell = new Cell(new Phrase("Total\nMarks", thFont));
            totalmarksCell.Border = Cell.RECTANGLE;
            totalmarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(totalmarksCell);

            Cell meanmarksCell = new Cell(new Phrase("Mean\nMarks", thFont));
            meanmarksCell.Border = Cell.RECTANGLE;
            meanmarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(meanmarksCell);

            Cell meangradeCell = new Cell(new Phrase("Mean\nGrade", thFont));
            meangradeCell.Border = Cell.RECTANGLE;
            meangradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(meangradeCell);

            Cell remarksCell = new Cell(new Phrase("Remarks", thFont));
            remarksCell.Border = Cell.RECTANGLE;
            remarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(remarksCell);

            Cell teacherinitialsCell = new Cell(new Phrase("Teacher Initials", thFont));
            teacherinitialsCell.Border = Cell.RECTANGLE;
            teacherinitialsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(teacherinitialsCell);

            //row 2
            Cell SubjectnullCell = new Cell(new Phrase("", thFont));
            SubjectnullCell.Border = Cell.RECTANGLE;
            SubjectnullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(SubjectnullCell);

            if (_ViewModel._ExamTypes.Count() > 0)
            {
                foreach (var r in _ViewModel._ExamTypes)
                {
                    Cell examypeCell = new Cell(new Phrase(r.ToUpper(), tdFont1));
                    examypeCell.Border = Cell.RECTANGLE;
                    examypeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(examypeCell);
                }
            }
            else
            {
                Cell examypeCell = new Cell(new Phrase("", tdFont1));
                examypeCell.Border = Cell.RECTANGLE;
                examypeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportFormTable.AddCell(examypeCell);
            }

            Cell totalmarksnullCell = new Cell(new Phrase("", thFont));
            totalmarksnullCell.Border = Cell.RECTANGLE;
            totalmarksnullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(totalmarksnullCell);

            Cell meanmarksnullCell = new Cell(new Phrase("", thFont));
            meanmarksnullCell.Border = Cell.RECTANGLE;
            meanmarksnullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(meanmarksnullCell);

            Cell meangradenullCell = new Cell(new Phrase("", thFont));
            meangradenullCell.Border = Cell.RECTANGLE;
            meangradenullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(meangradenullCell);

            Cell remarksnullCell = new Cell(new Phrase("", thFont));
            remarksnullCell.Border = Cell.RECTANGLE;
            remarksnullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(remarksnullCell);

            Cell teacherinitialsnullCell = new Cell(new Phrase("", thFont));
            teacherinitialsnullCell.Border = Cell.RECTANGLE;
            teacherinitialsnullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(teacherinitialsnullCell);
        }

        //table details 
        private void AddTableDetails(Table reportFormTable, StudentProgressFormDTO stRec)
        {
            try
            {
                if (stRec.SubjectsExamResult.Count != 0)
                {
                    var subjectsquery = (from sub in db.Subjects
                                         where sub.ShortCode == stRec.SubjectCode
                                         select sub).FirstOrDefault();
                    Subject _Subject = subjectsquery;

                    Cell SubjectCell = new Cell(new Phrase(_Subject.Description, tdFont));
                    SubjectCell.Border = Cell.RECTANGLE;
                    SubjectCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(SubjectCell);

                    if (_ViewModel._ExamTypes.Count() > 0)
                    {
                        foreach (var et in _ViewModel._ExamTypes)
                        {
                            var rec = stRec.SubjectsExamResult.Where(s => s.ExamTypeShortCode == et).FirstOrDefault();

                            if (rec != null)
                            {
                                var _Schoolquery = (from sc in db.Schools
                                                    where sc.DefaultSchool == true
                                                    select sc).FirstOrDefault();
                                School _School = _Schoolquery;
                                int gradingsys = _School.GradingSystem;
                                string _mark = rec.Mark.ToString("N0");
                                double _Mrk = double.Parse(_mark);
                                string _Grade = rep.GradeLookUp(_Mrk, gradingsys);
                                string item = rec.Mark.ToString("N0") + " " + _Grade;

                                Cell markCell = new Cell(new Phrase(item.ToString(), tdFont));
                                markCell.Border = Cell.RECTANGLE;
                                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                                reportFormTable.AddCell(markCell);
                            }
                            else
                            {
                                Cell markCell = new Cell(new Phrase(" ", tdFont));
                                markCell.Border = Cell.RECTANGLE;
                                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                                reportFormTable.AddCell(markCell);
                            }
                        }

                    }
                    else
                    {
                        Cell markCell = new Cell(new Phrase(" ", tdFont));
                        markCell.Border = Cell.RECTANGLE;
                        markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                        reportFormTable.AddCell(markCell);
                    }

                    Cell totalmarksCell = new Cell(new Phrase(stRec.TotalMarks.ToString("N0"), tdFont));
                    totalmarksCell.Border = Cell.RECTANGLE;
                    totalmarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(totalmarksCell);

                    Cell meanmarksCell = new Cell(new Phrase(stRec.MeanMarks.ToString("N0"), tdFont));
                    meanmarksCell.Border = Cell.RECTANGLE;
                    meanmarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(meanmarksCell);

                    Cell meangradeCell = new Cell(new Phrase(stRec.MeanGrade.ToString(), tdFont));
                    meangradeCell.Border = Cell.RECTANGLE;
                    meangradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(meangradeCell);

                    Cell remarksCell = new Cell(new Phrase(stRec.Remarks, tdFont));
                    remarksCell.Border = Cell.RECTANGLE;
                    remarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(remarksCell);

                    Cell teacherinitialsCell = new Cell(new Phrase("", tdFont));
                    teacherinitialsCell.Border = Cell.RECTANGLE;
                    teacherinitialsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(teacherinitialsCell);
                }
                else
                {
                    var subjectsquery = (from sub in db.Subjects
                                         where sub.ShortCode == stRec.SubjectCode
                                         select sub).FirstOrDefault();
                    Subject _Subject = subjectsquery;

                    Cell SubjectCell = new Cell(new Phrase(_Subject.Description, tdFont1));
                    SubjectCell.Border = Cell.RECTANGLE;
                    SubjectCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(SubjectCell);

                    if (_ViewModel._ExamTypes.Count() > 0)
                    {
                        foreach (var et in _ViewModel._ExamTypes)
                        {
                            var rec = stRec.SubjectsExamResult.Where(s => s.ExamTypeShortCode == et).SingleOrDefault();

                            if (rec != null)
                            {
                                var _Schoolquery = (from sc in db.Schools
                                                    where sc.DefaultSchool == true
                                                    select sc).FirstOrDefault();
                                School _School = _Schoolquery;
                                int gradingsys = _School.GradingSystem;
                                string _mark = rec.Mark.ToString("N0");
                                double _Mrk = double.Parse(_mark);
                                string _Grade = rep.GradeLookUp(_Mrk, gradingsys);
                                string item = rec.Mark.ToString("N0") + " " + _Grade;

                                Cell markCell = new Cell(new Phrase("", tdFont));
                                markCell.Border = Cell.RECTANGLE;
                                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                                reportFormTable.AddCell(markCell);
                            }
                            else
                            {
                                Cell markCell = new Cell(new Phrase(" ", tdFont));
                                markCell.Border = Cell.RECTANGLE;
                                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                                reportFormTable.AddCell(markCell);
                            }
                        }

                    }
                    else
                    {
                        Cell markCell = new Cell(new Phrase(" ", tdFont));
                        markCell.Border = Cell.RECTANGLE;
                        markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                        reportFormTable.AddCell(markCell);
                    }

                    Cell totalmarksCell = new Cell(new Phrase("", tdFont1));
                    totalmarksCell.Border = Cell.RECTANGLE;
                    totalmarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(totalmarksCell);

                    Cell meanmarksCell = new Cell(new Phrase("", tdFont1));
                    meanmarksCell.Border = Cell.RECTANGLE;
                    meanmarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(meanmarksCell);

                    Cell meangradeCell = new Cell(new Phrase("", tdFont1));
                    meangradeCell.Border = Cell.RECTANGLE;
                    meangradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(meangradeCell);

                    Cell remarksCell = new Cell(new Phrase("", tdFont1));
                    remarksCell.Border = Cell.RECTANGLE;
                    remarksCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(remarksCell);

                    Cell teacherinitialsCell = new Cell(new Phrase("", tdFont1));
                    teacherinitialsCell.Border = Cell.RECTANGLE;
                    teacherinitialsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    reportFormTable.AddCell(teacherinitialsCell);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        //table totals
        private void AddTableTotals()
        {
            Table reportFormTable = new Table(6, 3);
            reportFormTable.WidthPercentage = 100;
            reportFormTable.Spacing = 1;
            reportFormTable.Padding = 1;

            // Put table headers -> Row 1 
            Cell totlmarkCell = new Cell(new Phrase("Total Marks", tdFont1));
            totlmarkCell.Border = Cell.RECTANGLE;
            totlmarkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            //totlmarkCell.Rowspan = 2;
            reportFormTable.AddCell(totlmarkCell);

            Cell avergemrkCell = new Cell(new Phrase("Average Marks", tdFont1));
            avergemrkCell.Border = Cell.RECTANGLE;
            avergemrkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            //avergemrkCell.Rowspan = 2;
            reportFormTable.AddCell(avergemrkCell);

            Cell currntgrdCell = new Cell(new Phrase("Previous Periods Mean Grade", tdFont1));
            currntgrdCell.Border = Cell.RECTANGLE;
            currntgrdCell.Colspan = 4;
            currntgrdCell.BackgroundColor = Color.CYAN;
            currntgrdCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportFormTable.AddCell(currntgrdCell);

            //Put data - > Row 2 
            Cell nilcell = new Cell(new Phrase("", tdFont1));
            nilcell.Border = Cell.RECTANGLE;
            nilcell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(nilcell);

            Cell nil2cell = new Cell(new Phrase("", tdFont1));
            nil2cell.Border = Cell.RECTANGLE;
            nil2cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(nil2cell);

            Cell currentCell = new Cell(new Phrase("Current", tdFont1));
            currentCell.Border = Cell.RECTANGLE;
            currentCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(currentCell);

            Cell term1textCell = new Cell(new Phrase("Term1", tdFont1));
            term1textCell.Border = Cell.RECTANGLE;
            term1textCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(term1textCell);

            Cell term2textCell = new Cell(new Phrase("Term2", tdFont1));
            term2textCell.Border = Cell.RECTANGLE;
            term2textCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(term2textCell);

            Cell term3textCell = new Cell(new Phrase("Term3", tdFont1));
            term3textCell.Border = Cell.RECTANGLE;
            term3textCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(term3textCell);

            Cell totalmrkCell = new Cell(new Phrase(_ViewModel.TotalMarks.ToString(), tdFont));
            totalmrkCell.Border = Cell.RECTANGLE;
            totalmrkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(totalmrkCell);

            Cell avergmrkCell = new Cell(new Phrase(_ViewModel.AverageMarks.ToString("N0"), tdFont));
            avergmrkCell.Border = Cell.RECTANGLE;
            avergmrkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(avergmrkCell);

            Cell meangradeCell = new Cell(new Phrase(_ViewModel.CurrentMeanGrade, tdFont));
            meangradeCell.Border = Cell.RECTANGLE;
            meangradeCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(meangradeCell);

            Cell term1valCell = new Cell(new Phrase(_ViewModel.Term1MeanGrade, tdFont));
            term1valCell.Border = Cell.RECTANGLE;
            term1valCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(term1valCell);

            Cell term2valCell = new Cell(new Phrase(_ViewModel.Term2MeanGrade, tdFont));
            term2valCell.Border = Cell.RECTANGLE;
            term2valCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(term2valCell);

            Cell term3valCell = new Cell(new Phrase(_ViewModel.Term3MeanGrade, tdFont));
            term3valCell.Border = Cell.RECTANGLE;
            term3valCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            reportFormTable.AddCell(term3valCell);


            document.Add(reportFormTable);
        }


        private void AddGradingDets()
        {

            Table reportFormTable = new Table(2);
            reportFormTable.WidthPercentage = 50;
            reportFormTable.Spacing = 0;
            reportFormTable.Padding = 0;
            reportFormTable.Border = Table.NO_BORDER;
            reportFormTable.Alignment = Table.ALIGN_LEFT;

            AddMarksGradingDets(reportFormTable);

            Table chartTable = new Table(1);
            chartTable.WidthPercentage = 100;
            chartTable.Padding = 1;

            Cell keyCell = new Cell(new Phrase("", tdFont));
            keyCell.Border = Cell.RECTANGLE;
            keyCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            keyCell.Colspan = 1;
            keyCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(keyCell);

            var image = Image.GetInstance(Chart());
            image.ScalePercent(30f);
            image.Alignment = Image.ALIGN_MIDDLE;
            Cell chartCell = new Cell(image);
            chartCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            chartCell.Border = Cell.NO_BORDER;
            chartTable.AddCell(chartCell);

            reportFormTable.InsertTable(chartTable); 

            document.Add(reportFormTable); 
        }

        private void AddMarksGradingDets(Table _reportFormTable)
        {

            Table reportFormTable = new Table(5);
            reportFormTable.WidthPercentage = 50;
            reportFormTable.Spacing = 0;
            reportFormTable.Padding = 0;
            reportFormTable.Border = Table.NO_BORDER;
            reportFormTable.Alignment = Table.ALIGN_LEFT;

            Cell keyCell = new Cell(new Phrase("KEY:", tdFont));
            keyCell.Border = Cell.RECTANGLE;
            keyCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            keyCell.Colspan = 5;
            keyCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(keyCell);

            Cell GradeCell = new Cell(new Phrase("Grade", tdFont));
            GradeCell.Border = Cell.RECTANGLE;
            GradeCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            GradeCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(GradeCell);

            Cell LowerMarkCell = new Cell(new Phrase("LowerMark", tdFont));
            LowerMarkCell.Border = Cell.RECTANGLE;
            LowerMarkCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            LowerMarkCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(LowerMarkCell);

            Cell UpperMarkCell = new Cell(new Phrase("UpperMark", tdFont));
            UpperMarkCell.Border = Cell.RECTANGLE;
            UpperMarkCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            UpperMarkCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(UpperMarkCell);

            Cell PointCell = new Cell(new Phrase("Point", tdFont));
            PointCell.Border = Cell.RECTANGLE;
            PointCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            PointCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(PointCell);

            Cell RemarksCell = new Cell(new Phrase("Remarks", tdFont));
            RemarksCell.Border = Cell.RECTANGLE;
            RemarksCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            RemarksCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(RemarksCell); 

            foreach (var gs in _ViewModel._GradingDTO)
            {
                Cell GradeValueCell = new Cell(new Phrase(gs.Grade, tdFont2));
                GradeValueCell.Border = Cell.RECTANGLE;
                GradeValueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                GradeValueCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(GradeValueCell);

                Cell LowerMarkValueCell = new Cell(new Phrase(gs.LowerMark.ToString(), tdFont2));
                LowerMarkValueCell.Border = Cell.RECTANGLE;
                LowerMarkValueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                LowerMarkValueCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(LowerMarkValueCell);

                Cell UpperMarkValueCell = new Cell(new Phrase(gs.UpperMark.ToString(), tdFont2));
                UpperMarkValueCell.Border = Cell.RECTANGLE;
                UpperMarkValueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                UpperMarkValueCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(UpperMarkValueCell);

                Cell PointValueCell = new Cell(new Phrase(gs.Point.ToString(), tdFont2));
                PointValueCell.Border = Cell.RECTANGLE;
                PointValueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                PointValueCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(PointValueCell);

                Cell RemarksValueCell = new Cell(new Phrase(gs.Remarks, tdFont2));
                RemarksValueCell.Border = Cell.RECTANGLE;
                RemarksValueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                RemarksValueCell.Border = Cell.NO_BORDER;
                reportFormTable.AddCell(RemarksValueCell);
            }

            _reportFormTable.InsertTable(reportFormTable);

        }

        private void AddDocRemarks()
        {

            Table reportFormTable = new Table(2);
            reportFormTable.WidthPercentage = 100;
            reportFormTable.Spacing = 0;
            reportFormTable.Padding = 0;
            reportFormTable.Border = Table.NO_BORDER;
            reportFormTable.Alignment = Table.ALIGN_LEFT;

            Cell remarksCell = new Cell(new Phrase("Remarks", new Font(Font.TIMES_ROMAN, 7, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
            remarksCell.Border = Cell.RECTANGLE;
            remarksCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            remarksCell.Colspan = 2;
            remarksCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(remarksCell);

            Cell classTeacherCell = new Cell(new Phrase("Class Teacher:............................................................................................................................................................................................................................................................................", tdFont));
            classTeacherCell.Border = Cell.RECTANGLE;
            classTeacherCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            classTeacherCell.Colspan = 2;
            classTeacherCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(classTeacherCell);

            Cell ctDateCell = new Cell(new Phrase("Date:............................................................................................................................", tdFont));
            ctDateCell.Border = Cell.RECTANGLE;
            ctDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            ctDateCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(ctDateCell);

            Cell ctSignatureCell = new Cell(new Phrase("Signature:............................................................................................................................", tdFont));
            ctSignatureCell.Border = Cell.RECTANGLE;
            ctSignatureCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            ctSignatureCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(ctSignatureCell);

            Cell PrincipalCell = new Cell(new Phrase("Principal/Deputy-Principal:............................................................................................................................................................................................................................................................................", tdFont));
            PrincipalCell.Border = Cell.RECTANGLE;
            PrincipalCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            PrincipalCell.Colspan = 2;
            PrincipalCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(PrincipalCell);

            Cell closingDateCell = new Cell(new Phrase("Closing Date:............................................................................................................................", tdFont));
            closingDateCell.Border = Cell.RECTANGLE;
            closingDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            closingDateCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(closingDateCell);

            Cell openingDateCell = new Cell(new Phrase("Opening Date:............................................................................................................................", tdFont));
            openingDateCell.Border = Cell.RECTANGLE;
            openingDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            openingDateCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(openingDateCell);

            Cell pcDateCell = new Cell(new Phrase("Date:............................................................................................................................", tdFont));
            pcDateCell.Border = Cell.RECTANGLE;
            pcDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            pcDateCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(pcDateCell);

            Cell pcSignatureCell = new Cell(new Phrase("Signature:..............................................................................................................................", tdFont));
            pcSignatureCell.Border = Cell.RECTANGLE;
            pcSignatureCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            pcSignatureCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(pcSignatureCell);

            Cell parentCell = new Cell(new Phrase("Parent/Guardian:............................................................................................................................................................................................................................................................................", tdFont));
            parentCell.Border = Cell.RECTANGLE;
            parentCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            parentCell.Colspan = 2;
            parentCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(parentCell);

            Cell ptDateCell = new Cell(new Phrase("Date:............................................................................................................................", tdFont));
            ptDateCell.Border = Cell.RECTANGLE;
            ptDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            ptDateCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(ptDateCell);

            Cell ptSignatureCell = new Cell(new Phrase("Signature:............................................................................................................................", tdFont));
            ptSignatureCell.Border = Cell.RECTANGLE;
            ptSignatureCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            ptSignatureCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(ptSignatureCell);

            Cell feebalanceCell = new Cell(new Phrase("Fee Balance:............................................................................................................................" + _ViewModel.FeeBalance.ToString("C2"), tdFont));
            feebalanceCell.Border = Cell.RECTANGLE;
            feebalanceCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feebalanceCell.Border = Cell.NO_BORDER;
            feebalanceCell.Colspan = 2;
            reportFormTable.AddCell(feebalanceCell);

            Cell nextTermFeeCell = new Cell(new Phrase("Next Term Fee:............................................................................................................................" + _ViewModel.NextTermTotalFees.ToString("C2"), tdFont));
            nextTermFeeCell.Border = Cell.RECTANGLE;
            nextTermFeeCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            nextTermFeeCell.Border = Cell.NO_BORDER;
            nextTermFeeCell.Colspan = 2;
            reportFormTable.AddCell(nextTermFeeCell);

            document.Add(reportFormTable);

        }

        private Byte[] Chart()
        { 
            var query = from o in _ViewModel.StudentDTOExamResults
                        group o by o.StudentId
                            into g
                            select new
                            {
                                Employee = g.Key,
                                NoOfOrders = g.Count()
                            };

            var chart = new Chart
            {
                Width = 300,
                Height = 450,
                AntiAliasing = AntiAliasingStyles.All,
                TextAntiAliasingQuality = TextAntiAliasingQuality.High
            };

            chart.Titles.Add("Progress");
            chart.Titles[0].Font = new System.Drawing.Font("Arial", 16f);

            chart.ChartAreas.Add("");
            chart.ChartAreas[0].AxisX.Title = "Term";
            chart.ChartAreas[0].AxisY.Title = "Grade";
            chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial", 12f);
            chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial", 12f);
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 10f);
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart.ChartAreas[0].BackColor = System.Drawing.Color.White;

            chart.Series.Add("");
            chart.Series[0].ChartType = SeriesChartType.Column;

            foreach (var q in query)
            {
                var Name = q.Employee;
                chart.Series[0].Points.AddXY(Name, Convert.ToDouble(q.NoOfOrders));
            }
            using (var chartimage = new MemoryStream())
            {
                chart.SaveImage(chartimage, ChartImageFormat.Jpeg);
                return chartimage.GetBuffer();
            }
        }


        //document footer
        private void AddDocFooter()
        {

            Table reportFormTable = new Table(1);
            reportFormTable.WidthPercentage = 100;
            reportFormTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Student Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            reportFormTable.AddCell(sgCell);

            document.Add(reportFormTable);

        }


     }
}
