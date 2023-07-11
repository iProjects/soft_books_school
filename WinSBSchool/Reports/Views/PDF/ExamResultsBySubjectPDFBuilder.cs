using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VVX;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms; 
using CommonLib;

namespace WinSBSchool.Reports.Views.PDF
{
    public class ExamResultsBySubjectPDFBuilder
    {
        string sFilePDF;
        ExamResultsBySubjectViewModel _ViewModel;
        string Message;
        Document document;
        string connection;
        SBSchoolDBEntities db;
        Repository rep;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font tdFont1 = new Font(Font.HELVETICA, 8, Font.BOLD, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER


        public ExamResultsBySubjectPDFBuilder(ExamResultsBySubjectViewModel _examResultsByClassBySubjectViewModel, string FileName, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn is null");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);


            if (_examResultsByClassBySubjectViewModel == null)
                throw new ArgumentNullException("ExamResultsBySubjectViewModel is invalid"); 
            _ViewModel = _examResultsByClassBySubjectViewModel;

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
                Table resultsTable = new Table(5);
                resultsTable.WidthPercentage = 100;
                resultsTable.Padding = 1;
                resultsTable.Spacing = 1;
                resultsTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                resultsTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                resultsTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                resultsTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase(" ", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                resultsTable.AddCell(nullCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(img0);
                logoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                resultsTable.AddCell(logoCell);

                Cell reportdateCell = new Cell(new Phrase("Print Date:  " + _ViewModel.ReportDate.ToShortDateString(), hFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Colspan = 5;
                reportdateCell.Border = Cell.NO_BORDER;
                resultsTable.AddCell(reportdateCell); 

                document.Add(resultsTable);

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

            var _Subjectquery = (from sj in db.Subjects
                                 where sj.ShortCode == _ViewModel.ExamShortcode
                                 select sj).FirstOrDefault();

            DAL.Subject _Subject = (DAL.Subject)_Subjectquery;
            Cell nameCell = new Cell(new Phrase("Subject:   " + _Subject.Description, tdFont));
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
            try
            {
                if (_ViewModel._ExamTypes.Count() > 0)
                {
                    int Cols = 3 + _ViewModel._ExamTypes.Count() + 3;
                    Table resultsTable = new Table(Cols, 2);
                    resultsTable.WidthPercentage = 100;

                    int[] colWidthPercentages = new int[Cols];
                    //initialize the first 1
                    int initialcols = 3;
                    colWidthPercentages[0] = 15;
                    colWidthPercentages[1] = 5;
                    colWidthPercentages[2] = 5;
                    int others = colWidthPercentages.Sum();
                    int dif = 100 - others;
                    int othercols = Cols - initialcols;
                    int colsize = dif / othercols;

                    for (int i = initialcols; i < Cols; i++)
                    {
                        colWidthPercentages[i] = colsize;
                    }

                    resultsTable.SetWidths(colWidthPercentages);
                    resultsTable.Spacing = 1;
                    resultsTable.Padding = 1;

                    AddTableHeaders(resultsTable);


                    //Add table details  
                    foreach (var r in _ViewModel.ExamResults)
                    {
                        AddTableDetails(resultsTable, r);
                    }

                    document.Add(resultsTable);

                    //Add table totals
                    //AddTableTotals();
                }
                else
                {
                    int Cols = 3 + 1 + 3;
                    Table resultsTable = new Table(Cols, 2);
                    resultsTable.WidthPercentage = 100;

                    int[] colWidthPercentages = new int[Cols];
                    //initialize the first 1
                    int initialcols = 3;
                    colWidthPercentages[0] = 15;
                    colWidthPercentages[1] = 5;
                    colWidthPercentages[2] = 5;
                    int others = colWidthPercentages.Sum();
                    int dif = 100 - others;
                    int othercols = Cols - initialcols;
                    int colsize = dif / othercols;

                    for (int i = initialcols; i < Cols; i++)
                    {
                        colWidthPercentages[i] = colsize;
                    }

                    resultsTable.SetWidths(colWidthPercentages);
                    resultsTable.Spacing = 1;
                    resultsTable.Padding = 1;

                    AddTableHeaders(resultsTable);


                    //Add table details  
                    foreach (var r in _ViewModel.ExamResults)
                    {
                        AddTableDetails(resultsTable, r);
                    }

                    document.Add(resultsTable);

                    //Add table totals
                    //AddTableTotals();
                } 
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        //table headers
        private void AddTableHeaders(Table resultsTable)
        {
            //row 1
            Cell nameCell = new Cell(new Phrase("Name", thFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(nameCell);

            Cell adminoCell = new Cell(new Phrase("Admin No", thFont));
            adminoCell.Border = Cell.RECTANGLE;
            adminoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(adminoCell);

            Cell streamCell = new Cell(new Phrase("Stream", thFont));
            streamCell.Border = Cell.RECTANGLE;
            streamCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(streamCell);

            if (_ViewModel._ExamTypes.Count() > 0)
            {
                Cell subjectCell = new Cell(new Phrase("Marks", thFont));
                subjectCell.Border = Cell.RECTANGLE;
                subjectCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                subjectCell.Colspan = _ViewModel._ExamTypes.Count();
                resultsTable.AddCell(subjectCell);
            }
            else
            {
                Cell subjectCell = new Cell(new Phrase("Marks", thFont));
                subjectCell.Border = Cell.RECTANGLE;
                subjectCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                resultsTable.AddCell(subjectCell);
            }
            

            Cell totalCell = new Cell(new Phrase("Total\nMarks", thFont));
            totalCell.Border = Cell.RECTANGLE;
            totalCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(totalCell);

            Cell meanmarkCell = new Cell(new Phrase("Mean\nMark", thFont));
            meanmarkCell.Border = Cell.RECTANGLE;
            meanmarkCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(meanmarkCell);

            Cell gradeCell = new Cell(new Phrase("Mean\nGrade", thFont));
            gradeCell.Border = Cell.RECTANGLE;
            gradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(gradeCell);

            //row 2
            Cell namenullCell = new Cell(new Phrase("", thFont));
            namenullCell.Border = Cell.RECTANGLE;
            namenullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(namenullCell);

            Cell adminonullCell = new Cell(new Phrase("", thFont));
            adminonullCell.Border = Cell.RECTANGLE;
            adminonullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(adminonullCell);

            Cell streamnullCell = new Cell(new Phrase("", thFont));
            streamnullCell.Border = Cell.RECTANGLE;
            streamnullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(streamnullCell);

            if (_ViewModel._ExamTypes.Count() > 0)
            {
                foreach (var r in _ViewModel._ExamTypes)
                {
                    Cell examypeCell = new Cell(new Phrase(r.ToUpper(), tdFont1));
                    examypeCell.Border = Cell.RECTANGLE;
                    examypeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    resultsTable.AddCell(examypeCell);
                }
            }
            else
            {
                Cell subjectsCell = new Cell(new Phrase("", thFont));
                subjectsCell.Border = Cell.RECTANGLE;
                subjectsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                resultsTable.AddCell(subjectsCell);
            } 
            

            Cell totalnullCell = new Cell(new Phrase("", thFont));
            totalnullCell.Border = Cell.RECTANGLE;
            totalnullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(totalnullCell);

            Cell meanmarknullCell = new Cell(new Phrase("", thFont));
            meanmarknullCell.Border = Cell.RECTANGLE;
            meanmarknullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(meanmarknullCell);

            Cell gradenullCell = new Cell(new Phrase("", thFont));
            gradenullCell.Border = Cell.RECTANGLE;
            gradenullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            resultsTable.AddCell(gradenullCell);
        }

        //table details 
        private void AddTableDetails(Table resultsTable, ExamResultsBySubjectDTO stRec)
        {
            try
            {
                var studentquery = (from st in db.Students
                                    where st.Id == stRec.StudentId
                                    select st).FirstOrDefault();
                Student _Student = studentquery;

                Cell nameCell = new Cell(new Phrase(_Student.StudentSurName + ", " + _Student.StudentOtherNames, tdFont));
                nameCell.Border = Cell.RECTANGLE;
                nameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                resultsTable.AddCell(nameCell);

                Cell adminoCell = new Cell(new Phrase(_Student.AdminNo, tdFont));
                adminoCell.Border = Cell.RECTANGLE;
                adminoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                resultsTable.AddCell(adminoCell);

                var classStreamquery = (from cs in db.ClassStreams
                                        join st in db.Students on cs.Id equals st.ClassStreamId
                                        where st.ClassStreamId == _Student.ClassStreamId
                                        select cs).FirstOrDefault();
                ClassStream _ClassStream = classStreamquery;

                Cell streamCell = new Cell(new Phrase(_ClassStream.Description, tdFont));
                streamCell.Border = Cell.RECTANGLE;
                streamCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                resultsTable.AddCell(streamCell);


                if (_ViewModel._ExamTypes.Count() > 0)
                {
                    foreach (var et in _ViewModel._ExamTypes)
                    {
                        var rec = stRec.StudentExamResults.Where(s => s.ExamTypeShortCode == et).SingleOrDefault();
                        if (rec != null)
                        {
                            var _Schoolquery = (from sc in db.Schools
                                                where sc.DefaultSchool == true
                                                select sc).FirstOrDefault();
                            School _School = _Schoolquery;
                            int gradingsys = _School.GradingSystem;
                           
                            //string _mark = rec.Mark.ToString("N0");
                            string _mark = string.Format("{0:0.00}", rec.Mark);
                            double _Mrk = double.Parse(_mark);
                            string _Grade = rep.GradeLookUp(_Mrk, gradingsys);
                            string item = string.Format("{0:0.00}", rec.Mark) + " " + _Grade;

                            Cell markCell = new Cell(new Phrase(item.ToString(), tdFont));
                            markCell.Border = Cell.RECTANGLE;
                            markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                            resultsTable.AddCell(markCell);
                        }
                        else
                        {
                            Cell markCell = new Cell(new Phrase(" ", tdFont));
                            markCell.Border = Cell.RECTANGLE;
                            markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                            resultsTable.AddCell(markCell);
                        }
                    }

                }
                else
                {
                    Cell subjectCell = new Cell(new Phrase("", thFont));
                    subjectCell.Border = Cell.RECTANGLE;
                    subjectCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                    resultsTable.AddCell(subjectCell);
                }

                Cell totalCell = new Cell(new Phrase(stRec.TotalMarks.ToString("N0"), tdFont));
                totalCell.Border = Cell.RECTANGLE;
                totalCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                resultsTable.AddCell(totalCell);

                Cell meanMarkCell = new Cell(new Phrase(stRec.MeanMarks.ToString("N0"), tdFont));
                meanMarkCell.Border = Cell.RECTANGLE;
                meanMarkCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                resultsTable.AddCell(meanMarkCell);

                Cell gradeCell = new Cell(new Phrase(stRec.MeanGrade, tdFont));
                gradeCell.Border = Cell.RECTANGLE;
                gradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                resultsTable.AddCell(gradeCell);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }


        //document footer
        private void AddDocFooter()
        {
            Table resultsTable = new Table(1);
            resultsTable.WidthPercentage = 100;
            resultsTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            resultsTable.AddCell(sgCell);

            document.Add(resultsTable);

        }

    }
}
