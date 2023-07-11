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
    public class ExamResultByExamPeriodByClassBySubjectByExamTypePDFBuilder
    {
        string sFilePDF;
        ExamResultByExamPeriodByClassBySubjectByExamTypeViewModel examResultByExamPeriodByClassBySubjectByExamTypeViewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE HEADER


        public ExamResultByExamPeriodByClassBySubjectByExamTypePDFBuilder(ExamResultByExamPeriodByClassBySubjectByExamTypeViewModel _examResultByExamPeriodByClassBySubjectByExamTypeViewModel, string FileName)
        {
            examResultByExamPeriodByClassBySubjectByExamTypeViewModel = _examResultByExamPeriodByClassBySubjectByExamTypeViewModel;
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

                Cell RCell = new Cell(new Phrase(examResultByExamPeriodByClassBySubjectByExamTypeViewModel.ReportName, new Font(Font.HELVETICA, 15, Font.BOLD, Color.BLUE)));
                RCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                RCell.Colspan = 4;
                RCell.Border = Cell.NO_BORDER;
                examResultByExamPeriodByClassTable.AddCell(RCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(examResultByExamPeriodByClassBySubjectByExamTypeViewModel.SchoolLogo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell Logcell = new Cell(img0);
                Logcell.HorizontalAlignment = Cell.ALIGN_LEFT;

                Logcell.Border = Cell.NO_BORDER;
                Logcell.Add(new Phrase(examResultByExamPeriodByClassBySubjectByExamTypeViewModel.SchoolSlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                examResultByExamPeriodByClassTable.AddCell(Logcell);

                Cell reportdateCell = new Cell(new Phrase("Report Date:     " + examResultByExamPeriodByClassBySubjectByExamTypeViewModel.ReportDate.ToString("MMMM  dd, yyyy"), hFont));
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
            foreach (var item in examResultByExamPeriodByClassBySubjectByExamTypeViewModel.ExamResults)
            {
                AddExamPeriodTableDetails(item);
            }

        }
        private void AddExamPeriodTableDetails(ExamResultsByClassBySubjectByExamTypeDTO ercdto)
        {
            document.Add(new Phrase("\n"));

            Table examResultByExamPeriodByClassTable = new Table(3);
            examResultByExamPeriodByClassTable.WidthPercentage = 100;
            examResultByExamPeriodByClassTable.Spacing = 1;
            examResultByExamPeriodByClassTable.Padding = 1;

            Cell yearCell = new Cell(new Phrase("YEAR", thFont));
            yearCell.Border = Cell.RECTANGLE;
            yearCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(yearCell);

            Cell termCell = new Cell(new Phrase("TERM", thFont));
            termCell.Border = Cell.RECTANGLE;
            termCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(termCell);

            Cell examdateCell = new Cell(new Phrase("EXAMINATION DATE", thFont));
            examdateCell.Border = Cell.RECTANGLE;
            examdateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(examdateCell);

            document.Add(examResultByExamPeriodByClassTable);

            BuildExamResultsTable(ercdto.StudentExamResult);
        }
        //table headers
        private void BuildExamResultsTable(List<StudentExamResult> studentexamresult)
        {
            //Create table
            Table examResultByExamPeriodByClassTable = new Table(4);
            examResultByExamPeriodByClassTable.WidthPercentage = 100;
            examResultByExamPeriodByClassTable.Alignment = Table.ALIGN_LEFT;
            examResultByExamPeriodByClassTable.Spacing = 1;
            examResultByExamPeriodByClassTable.Padding = 1;

            //Build headers
            BuildExamResultsTableHeaders(examResultByExamPeriodByClassTable);

            //Build details
            BuildExamResultsTableDetails(examResultByExamPeriodByClassTable, studentexamresult);

            //add the table to the document
            document.Add(examResultByExamPeriodByClassTable);
        }
        private void AddTableHeaders()
        {
            Table examResultByExamPeriodByClassTable = new Table(2);
            examResultByExamPeriodByClassTable.WidthPercentage = 100;
            examResultByExamPeriodByClassTable.Spacing = 1;
            examResultByExamPeriodByClassTable.Padding = 1;

            Cell subjectCell = new Cell(new Phrase("SUBJECT", thFont));
            subjectCell.Border = Cell.RECTANGLE;
            subjectCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(subjectCell);

            Cell subjectvalueCell = new Cell(new Phrase("", thFont));
            subjectvalueCell.Border = Cell.RECTANGLE;
            subjectvalueCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(subjectvalueCell);

            document.Add(examResultByExamPeriodByClassTable);

        }
        private void BuildExamResultsTableHeaders(Table examResultByExamPeriodByClassTable)
        {
            //Table examResultByExamPeriodByClassTable = new Table(4);
            examResultByExamPeriodByClassTable.WidthPercentage = 100;
            examResultByExamPeriodByClassTable.Spacing = 1;
            examResultByExamPeriodByClassTable.Padding = 1;

            Cell adminnoCell = new Cell(new Phrase("ADMINNO", thFont));
            adminnoCell.Border = Cell.RECTANGLE;
            adminnoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(adminnoCell);

            Cell nameCell = new Cell(new Phrase("NAME", thFont));
            nameCell.Border = Cell.RECTANGLE;
            nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(nameCell);

            Cell markCell = new Cell(new Phrase("MARK", thFont));
            markCell.Border = Cell.RECTANGLE;
            markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(markCell);

            Cell gradeCell = new Cell(new Phrase("GRADE", thFont));
            gradeCell.Border = Cell.RECTANGLE;
            gradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            examResultByExamPeriodByClassTable.AddCell(gradeCell);

            //document.Add(examResultByExamPeriodByClassTable);


        }
        //table totals
        private void BuildExamResultsTableDetails(Table examResultByExamPeriodByClassTable, List<StudentExamResult> subjectresults)
        {
            foreach (var se in subjectresults)
            {

                //Table examResultByExamPeriodByClassTable = new Table(4);
                examResultByExamPeriodByClassTable.WidthPercentage = 100;
                examResultByExamPeriodByClassTable.Spacing = 1;
                examResultByExamPeriodByClassTable.Padding = 1;

                Cell adminnoCell = new Cell(new Phrase(se.StudentAdminNo, thFont));
                adminnoCell.Border = Cell.RECTANGLE;
                adminnoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                examResultByExamPeriodByClassTable.AddCell(adminnoCell);

                Cell nameCell = new Cell(new Phrase(se.StudentName, thFont));
                nameCell.Border = Cell.RECTANGLE;
                nameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                examResultByExamPeriodByClassTable.AddCell(nameCell);

                Cell markCell = new Cell(new Phrase(se.Mark.ToString(), thFont));
                markCell.Border = Cell.RECTANGLE;
                markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                examResultByExamPeriodByClassTable.AddCell(markCell);

                Cell gradeCell = new Cell(new Phrase(se.Grade, thFont));
                gradeCell.Border = Cell.RECTANGLE;
                gradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                examResultByExamPeriodByClassTable.AddCell(gradeCell);

                //document.Add(examResultByExamPeriodByClassTable);
            }


        }

        //document footer
        private void AddDocFooter()
        {



        }

    }
}
