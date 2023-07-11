using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using CommonLib;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VVX;
using WinSBSchool.Reports.ViewModels;
using DAL;

namespace WinSBSchool.Reports.PDFBuilders
{
    public class ProgrammeCourseListPDFBuilder
       {
           string sFilePDF;
           ProgrammeCourseListViewModel _ViewModel;
           string Message;
           Document document;
           string connection;
           SBSchoolDBEntities db;

           //DEFINED fONTS
           Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
           Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
           Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
           Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER   
           public ProgrammeCourseListPDFBuilder(ProgrammeCourseListViewModel ProgrammeCourseListViewModel, string FileName, string Conn)
           {
               if (string.IsNullOrEmpty(Conn))
                   throw new ArgumentNullException("Conn");
               connection = Conn;

               db = new SBSchoolDBEntities(connection);

               if (ProgrammeCourseListViewModel == null)
                   throw new ArgumentNullException("ProgrammeCourseListViewModel is null");
               _ViewModel = ProgrammeCourseListViewModel;

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

               Table programmeCourseListTable = new Table(5);
               programmeCourseListTable.WidthPercentage = 100;
               programmeCourseListTable.Padding = 1;
               programmeCourseListTable.Spacing = 1;
               programmeCourseListTable.Border = Table.NO_BORDER;

               Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
               SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               SchoolNameCell.Colspan = 5;
               SchoolNameCell.Border = Cell.NO_BORDER;
               programmeCourseListTable.AddCell(SchoolNameCell);

               Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
               SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               SchoolAddressCell.Colspan = 5;
               SchoolAddressCell.Border = Cell.NO_BORDER;
               programmeCourseListTable.AddCell(SchoolAddressCell);

               Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
               reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               reportNameCell.Colspan = 5;
               reportNameCell.Border = Cell.NO_BORDER;
               programmeCourseListTable.AddCell(reportNameCell);
               
               Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
               nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               nullCell.Colspan = 4;
               nullCell.Border = Cell.NO_BORDER;
               programmeCourseListTable.AddCell(nullCell);

               PDFGen pdfgen = new PDFGen();
               Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
               imgCell.Alignment = Image.ALIGN_MIDDLE;
               Cell logoCell = new Cell(imgCell);
               logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
               logoCell.Border = Cell.NO_BORDER;
               logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
               programmeCourseListTable.AddCell(logoCell);

               Cell ProgrammeDescriptionCell = new Cell(new Phrase(_ViewModel.ProgrammeDescription, new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLACK)));
               ProgrammeDescriptionCell.HorizontalAlignment = Cell.ALIGN_LEFT;
               ProgrammeDescriptionCell.Colspan = 5;
               ProgrammeDescriptionCell.Border = Cell.NO_BORDER;
               programmeCourseListTable.AddCell(ProgrammeDescriptionCell);

               Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
               reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
               reportdateCell.Border = Cell.NO_BORDER;
               reportdateCell.Colspan = 5;
               programmeCourseListTable.AddCell(reportdateCell);


               document.Add(programmeCourseListTable);

           }

           //document body
           private void AddDocBody()
           {             

               //Add table details 
               foreach (var py in _ViewModel.Courses)
               {

                   AddDocTableBody(py);
               }

               //Add table totals
               AddTableTotals();

           }



           private void AddDocTableBody(ProgramCoursesDTO pc)
           {

               AddYearTermDetails(pc.YearTerm, pc.ProgrammeYrCrs); 
           }
           private void AddYearTermDetails(YearTerm yt, List<ProgrammeYearCours> ProgyrCrs)
           {

               foreach (var tr in yt.Term)
               {
                   AddYearTermTableDetails(yt.Year, tr);

                   //Add table headers
                   AddTableHeaders();

                   foreach (var pyc in ProgyrCrs)
                   {
                       //Add table details 
                       AddTableDetails(pyc);
                   }
               }
           }
           private void AddYearTermTableDetails(int year, int term)
           {
               Table programmeCourseListTable = new Table(4);
               programmeCourseListTable.WidthPercentage = 100;
               programmeCourseListTable.Spacing = 1;
               programmeCourseListTable.Padding = 1;

               Cell YearCell = new Cell(new Phrase("Year", thFont));
               YearCell.Border = Cell.RECTANGLE;
               YearCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(YearCell);

               Cell YearDetsCell = new Cell(new Phrase(year.ToString(), tdFont));
               YearDetsCell.Border = Cell.RECTANGLE;
               YearDetsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(YearDetsCell);

               Cell TermCell = new Cell(new Phrase("Term", thFont));
               TermCell.Border = Cell.RECTANGLE;
               TermCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(TermCell);

               Cell TermDetsCell = new Cell(new Phrase(term.ToString(), tdFont));
               TermDetsCell.Border = Cell.RECTANGLE;
               TermDetsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(TermDetsCell);                

               document.Add(programmeCourseListTable);

           }

           //table headers
           private void AddTableHeaders()
           {
               Table programmeCourseListTable = new Table(6);
               programmeCourseListTable.WidthPercentage = 100;
               programmeCourseListTable.Spacing = 1;
               programmeCourseListTable.Padding = 1;


               Cell CourseCell = new Cell(new Phrase("Course", thFont));
               CourseCell.Border = Cell.RECTANGLE;
               CourseCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(CourseCell);

               Cell NoOfHrsCell = new Cell(new Phrase("No Of Hours", thFont));
               NoOfHrsCell.Border = Cell.RECTANGLE;
               NoOfHrsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(NoOfHrsCell);

               Cell tuitionFeesCell = new Cell(new Phrase("Tuition Fees", thFont));
               tuitionFeesCell.Border = Cell.RECTANGLE;
               tuitionFeesCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(tuitionFeesCell);

               Cell examFeesCell = new Cell(new Phrase("Exam Fees", thFont));
               examFeesCell.Border = Cell.RECTANGLE;
               examFeesCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(examFeesCell);

               Cell resitFeesCell = new Cell(new Phrase("Resit Fees", thFont));
               resitFeesCell.Border = Cell.RECTANGLE;
               resitFeesCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               programmeCourseListTable.AddCell(resitFeesCell);

               document.Add(programmeCourseListTable);

           }

           //table details 
           private void AddTableDetails(ProgrammeYearCours pyc)
           {

               Table programmeCourseListTable = new Table(6);
               programmeCourseListTable.WidthPercentage = 100;
               programmeCourseListTable.Spacing = 1;
               programmeCourseListTable.Padding = 1;

               var Subjectquery = (from sub in db.Subjects 
                        where sub.ShortCode == pyc.CourseId
                        select sub).FirstOrDefault();
               Subject Subject=Subjectquery;
               Cell CourseCell = new Cell(new Phrase(Subject.Description, tdFont));
               CourseCell.Border = Cell.RECTANGLE;
               CourseCell.HorizontalAlignment = Cell.ALIGN_LEFT;
               programmeCourseListTable.AddCell(CourseCell);

               Cell NoOfHrsCell = new Cell(new Phrase(pyc.NoOfHrs.ToString(), tdFont));
               NoOfHrsCell.Border = Cell.RECTANGLE;
               NoOfHrsCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
               programmeCourseListTable.AddCell(NoOfHrsCell);

               Cell tuitionFeesCell = new Cell(new Phrase((pyc.TuitionFees ?? 0).ToString("#,##0"), tdFont));
               tuitionFeesCell.Border = Cell.RECTANGLE;
               tuitionFeesCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
               programmeCourseListTable.AddCell(tuitionFeesCell);

               Cell examFeesCell = new Cell(new Phrase((pyc.ExamFees ?? 0).ToString("#,##0"), tdFont));
               examFeesCell.Border = Cell.RECTANGLE;
               examFeesCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
               programmeCourseListTable.AddCell(examFeesCell);

               Cell resitFeesCell = new Cell(new Phrase((pyc.ResitFees ?? 0).ToString("#,##0"), tdFont));
               resitFeesCell.Border = Cell.RECTANGLE;
               resitFeesCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
               programmeCourseListTable.AddCell(resitFeesCell);

               document.Add(programmeCourseListTable);
           }

           //table totals
           private void AddTableTotals()
           {
               

               
           }

           //document footer
           private void AddDocFooter()
           {

               Table programmeCourseListTable = new Table(1);
               programmeCourseListTable.WidthPercentage = 100;
               programmeCourseListTable.Border = Table.NO_BORDER;


               Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
               sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
               sgCell.Border = Cell.NO_BORDER;
               programmeCourseListTable.AddCell(sgCell);


               document.Add(programmeCourseListTable);

           }

       }
    }

