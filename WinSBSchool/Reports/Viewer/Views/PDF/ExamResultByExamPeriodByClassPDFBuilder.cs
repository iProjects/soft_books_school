using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GL.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VVX;
using WinSchool.Reports.ViewModels;

namespace WinSchool.Reports.Views.PDF
{
    public class ExamResultByExamPeriodByClassPDFBuilder
    {
        string sFilePDF;
        ExamResultByExamPeriodByClassViewModel examResultByExamPeriodByClassViewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE HEADER


        public ExamResultByExamPeriodByClassPDFBuilder(ExamResultByExamPeriodByClassViewModel _examResultByExamPeriodByClassViewModel, string FileName)
        {
            examResultByExamPeriodByClassViewModel = _examResultByExamPeriodByClassViewModel;
            if (_examResultByExamPeriodByClassViewModel == null)
                throw new ArgumentNullException("_examResultByExamPeriodByClassViewModel is null");
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
                Table examResultByExamPeriodByClassTable = new Table(5);
                examResultByExamPeriodByClassTable.WidthPercentage = 100;
                examResultByExamPeriodByClassTable.Padding = 1;
                examResultByExamPeriodByClassTable.Spacing = 1;
                examResultByExamPeriodByClassTable.Border = Table.NO_BORDER;

                Cell RCell = new Cell(new Phrase(examResultByExamPeriodByClassViewModel.ReportName, new Font(Font.HELVETICA, 15, Font.BOLD, Color.BLUE)));
                RCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                RCell.Colspan = 4;
                RCell.Border = Cell.NO_BORDER;
                examResultByExamPeriodByClassTable.AddCell(RCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(examResultByExamPeriodByClassViewModel.SchoolLogo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell Logcell = new Cell(img0);
                Logcell.HorizontalAlignment = Cell.ALIGN_LEFT;

                Logcell.Border = Cell.NO_BORDER;
                Logcell.Add(new Phrase(examResultByExamPeriodByClassViewModel.SchoolSlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                examResultByExamPeriodByClassTable.AddCell(Logcell);

                Cell reportdateCell = new Cell(new Phrase("Report Date:     " + examResultByExamPeriodByClassViewModel.ReportDate.ToString("MMMM  dd, yyyy"), hFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Colspan = 5;
                reportdateCell.Border = Cell.NO_BORDER;
                examResultByExamPeriodByClassTable.AddCell(reportdateCell);
                
                Cell classnameCell = new Cell(new Phrase("CLASS:     " + examResultByExamPeriodByClassViewModel.ClassName, hFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Colspan = 5;
                reportdateCell.Border = Cell.NO_BORDER;
                examResultByExamPeriodByClassTable.AddCell(reportdateCell); 
                document.Add(examResultByExamPeriodByClassTable);

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

        //document body
        private void AddDocBody()
        {
            foreach (var item in examResultByExamPeriodByClassViewModel.ExamResults)
            {
                AddSubjectExamResults(item);
            }
        }
        private void AddSubjectExamResults(ExamResultsBySubjectDTO item)
        {
            document.Add(new Phrase("\n"));

            Table sbTable = new Table(1);
            sbTable.WidthPercentage = 50;
            sbTable.Alignment = Table.ALIGN_LEFT;
            sbTable.Spacing = 1;
            sbTable.Padding = 1;

            Cell subjectCell = new Cell(new Phrase("SUBJECT: " + item.Subject, thFont));
            subjectCell.Border = Cell.RECTANGLE;
            subjectCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            sbTable.AddCell(subjectCell);



            document.Add(sbTable);

            BuildSubjectResultsTable(item.StudentExamResults);

        }

        private void BuildSubjectResultsTable(List<StudentExamResult> studentExamResults)
        {
            //Create table
            Table studentExamresultsTable = new Table(4);
            studentExamresultsTable.WidthPercentage = 100;
            studentExamresultsTable.Alignment = Table.ALIGN_LEFT;
            studentExamresultsTable.Spacing = 1;
            studentExamresultsTable.Padding = 1;

            //Build headers
            BuildStudentExamresultsTableHeaders(studentExamresultsTable);

            //Build details
            BuildStudentExamresultsTableDetails(studentExamresultsTable, studentExamResults);

            //add the table to the document
            document.Add(studentExamresultsTable);
        }
        private void BuildStudentExamresultsTableHeaders(Table studentExamresultsTable)
        {

            Cell adminnoCell = new Cell(new Phrase("ADMINNO", thFont));
            adminnoCell.Border = Cell.RECTANGLE;
            adminnoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentExamresultsTable.AddCell(adminnoCell);

            Cell nameCell = new Cell(new Phrase("NAME", thFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentExamresultsTable.AddCell(nameCell);

            Cell markCell = new Cell(new Phrase("MARK", thFont));
            markCell.Border = Cell.RECTANGLE;
            markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentExamresultsTable.AddCell(markCell);

            Cell gradeCell = new Cell(new Phrase("GRADE", thFont));
            gradeCell.Border = Cell.RECTANGLE;
            gradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentExamresultsTable.AddCell(gradeCell);
        }

        private void BuildStudentExamresultsTableDetails(Table studentExamresultsTable, List<StudentExamResult> studentExamResults)
        {
            foreach (StudentExamResult studentExamResult in studentExamResults)
            {

                Cell adminnoCell = new Cell(new Phrase(studentExamResult.StudentAdminNo, thFont));
                adminnoCell.Border = Cell.RECTANGLE;
                adminnoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                studentExamresultsTable.AddCell(adminnoCell);

                Cell nameCell = new Cell(new Phrase(studentExamResult.StudentName, thFont));
                nameCell.Border = Cell.RECTANGLE;
                nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                studentExamresultsTable.AddCell(nameCell);

                Cell markCell = new Cell(new Phrase(studentExamResult.Mark.ToString(), thFont));
                markCell.Border = Cell.RECTANGLE;
                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                studentExamresultsTable.AddCell(markCell);

                Cell gradeCell = new Cell(new Phrase(studentExamResult.Grade.ToString(), thFont));
                gradeCell.Border = Cell.RECTANGLE;
                gradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                studentExamresultsTable.AddCell(gradeCell);
            }

        } 

        private void AddDocFooter()
        {



        }

    }
}