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
  public   class ProgrammeCourseListViewPDFBuilder
    {

        string sFilePDF;
        ProgrammeCourseListViewModel programmecourselistviewmodel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE HEADER

        public ProgrammeCourseListViewPDFBuilder(ProgrammeCourseListViewModel _programmecourselistviewmodel, string FileName)
        {
            programmecourselistviewmodel = _programmecourselistviewmodel;
            if (_programmecourselistviewmodel == null)
                throw new ArgumentNullException("_programmecourselistviewmodel is null");

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
            finally
            {
                if (document.IsOpen()) document.Close();
            }

        }

        //document header
        private void AddDocHeader()
        {

            try
            { 
                Table ProgrammeCoursesTable = new Table(5);
                ProgrammeCoursesTable.WidthPercentage = 100;
                ProgrammeCoursesTable.Padding = 1;
                ProgrammeCoursesTable.Spacing = 1;
                ProgrammeCoursesTable.Border = Table.NO_BORDER;


                Cell reportnameCell = new Cell(new Phrase(programmecourselistviewmodel.ReportName, new Font(Font.HELVETICA, 15, Font.BOLD, Color.BLUE)));
                reportnameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportnameCell.Colspan = 4;
                reportnameCell.Border = Cell.NO_BORDER;
                ProgrammeCoursesTable.AddCell(reportnameCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(programmecourselistviewmodel.SchoolLogo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;

                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT; 
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(programmecourselistviewmodel.SchoolSlogan, thFont));
                ProgrammeCoursesTable.AddCell(logoCell);


                Cell reportdateCell = new Cell(new Phrase("Report Date:     " + programmecourselistviewmodel.ReportDate.ToString("MMMM  dd, yyyy"), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                ProgrammeCoursesTable.AddCell(reportdateCell); 

                document.Add(ProgrammeCoursesTable);

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
            foreach (var item in programmecourselistviewmodel.Courses)
            {
                AddYearTermCourses(item);
            }
        }

        private void AddYearTermCourses(ProgramCoursesDTO item)
        {
            document.Add(new Phrase("\n"));

            Table yrTable = new Table(2);
            yrTable.WidthPercentage = 50;
            yrTable.Alignment = Table.ALIGN_LEFT;
            yrTable.Spacing = 1;
            yrTable.Padding = 1;

            Cell yearCell = new Cell(new Phrase("YEAR: " + item.YearTerm.Year.ToString(), thFont));
            yearCell.Border = Cell.RECTANGLE;
            yearCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            yrTable.AddCell(yearCell); 

            Cell termCell = new Cell(new Phrase("TERM: " + item.YearTerm.Term.ToString(), thFont));
            termCell.Border = Cell.RECTANGLE;
            termCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            yrTable.AddCell(termCell);

            document.Add(yrTable);

            BuildSubjectsTable(item.Subjects);

        }
        private void BuildSubjectsTable(List<Subject> subjects)
        {
            //Create table
            Table subjectsTable = new Table(4);
            subjectsTable.WidthPercentage = 100;
            subjectsTable.Alignment = Table.ALIGN_LEFT;
            subjectsTable.Spacing = 1;
            subjectsTable.Padding = 1;

            //Build headers
            BuildSubjectsTableHeaders(subjectsTable);

            //Build details
            BuildSubjectsTableDetails(subjectsTable, subjects);

            //add the table to the document
            document.Add(subjectsTable);
        } 
      private void BuildSubjectsTableHeaders(Table subjectsTable)
      {
          
            Cell coursecodeCell = new Cell(new Phrase("COURSE CODE", thFont));
            coursecodeCell.Border = Cell.RECTANGLE;
            coursecodeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            coursecodeCell.BackgroundColor = Color.CYAN;
            subjectsTable.AddCell(coursecodeCell);

            Cell descriptionCell = new Cell(new Phrase("DESCRIPTION", thFont));
            descriptionCell.Border = Cell.RECTANGLE;
            descriptionCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            descriptionCell.BackgroundColor = Color.CYAN;
            subjectsTable.AddCell(descriptionCell);

            Cell outofCell = new Cell(new Phrase("OUT OF", thFont));
            outofCell.Border = Cell.RECTANGLE;
            outofCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            outofCell.BackgroundColor = Color.CYAN;
            subjectsTable.AddCell(outofCell);

            Cell passmarkCell = new Cell(new Phrase("PASS MARK", thFont));
            passmarkCell.Border = Cell.RECTANGLE;
            passmarkCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            passmarkCell.BackgroundColor = Color.CYAN;
            subjectsTable.AddCell(passmarkCell); 
        } 

      private void BuildSubjectsTableDetails(Table subjectsTable, List<Subject> subjects)
      {
          foreach (Subject subject in subjects)
          {

              Cell coursecodeCell = new Cell(new Phrase(subject.ShortCode, thFont));
              coursecodeCell.Border = Cell.RECTANGLE;
              coursecodeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
              subjectsTable.AddCell(coursecodeCell);

              Cell descriptionCell = new Cell(new Phrase(subject.Description, thFont));
              descriptionCell.Border = Cell.RECTANGLE;
              descriptionCell.HorizontalAlignment = Cell.ALIGN_CENTER;
              subjectsTable.AddCell(descriptionCell);

              Cell outofCell = new Cell(new Phrase(subject.OutOf.ToString(), thFont));
              outofCell.Border = Cell.RECTANGLE;
              outofCell.HorizontalAlignment = Cell.ALIGN_CENTER;
              subjectsTable.AddCell(outofCell);

              Cell passmarkCell = new Cell(new Phrase(subject.PassMark.ToString(), thFont));
              passmarkCell.Border = Cell.RECTANGLE;
              passmarkCell.HorizontalAlignment = Cell.ALIGN_CENTER;
              subjectsTable.AddCell(passmarkCell);
          }

      } 
        //document footer
        private void AddDocFooter()
        {



        }


    }
}
