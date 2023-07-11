using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL;
using CommonLib;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VVX;
using WinSBSchool.Reports.ViewModels;
using WinSBSchool.Reports.Viewer;
using System.Windows.Forms;

namespace WinSBSchool.Reports.Views.PDF
{
   public class ClassListPDFBuilder
    {
        string sFilePDF;
        ClassListViewModel _ViewModel;
        string Message;
        Document document;
        string connection;
        SBSchoolDBEntities db;

       //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER 

        public ClassListPDFBuilder(ClassListViewModel _classListReportViewModel, string FileName, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);

            if (_classListReportViewModel == null)
                throw new ArgumentNullException("ClassListViewModel is invalid");
            _ViewModel = _classListReportViewModel;
             
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
                Table classListTable = new Table(5);
                classListTable.WidthPercentage = 100;
                classListTable.Padding = 1;
                classListTable.Spacing = 1;
                classListTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                classListTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                classListTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                classListTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                classListTable.AddCell(nullCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
                classListTable.AddCell(logoCell);

                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                classListTable.AddCell(reportdateCell); 

                document.Add(classListTable);

             
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        //document body
        private void AddDocBody()
        {

            //Add table headers
            AddTableHeaders();

            //Add table details  
            AddTableDetails();

            //Add table totals
            AddTableTotals();

        }

        //table headers
        private void AddTableHeaders()
        {
            Table classListTable = new Table(6);
            classListTable.WidthPercentage = 100;
            classListTable.Spacing = 1;
            classListTable.Padding = 1;

            Cell shortCodeCell = new Cell(new Phrase("Short Code", thFont));
            shortCodeCell.Border = Cell.RECTANGLE;
            shortCodeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classListTable.AddCell(shortCodeCell);

            Cell classNameCell = new Cell(new Phrase("Name", thFont));
            classNameCell.Border = Cell.RECTANGLE;
            classNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classListTable.AddCell(classNameCell);

            Cell programmeYearCell = new Cell(new Phrase("Programme Year", thFont));
            programmeYearCell.Border = Cell.RECTANGLE;
            programmeYearCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classListTable.AddCell(programmeYearCell); 

            Cell classTeacherCell = new Cell(new Phrase("Class Teacher", thFont));
            classTeacherCell.Border = Cell.RECTANGLE;
            classTeacherCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classListTable.AddCell(classTeacherCell);
            
            Cell noofSubjectsCell = new Cell(new Phrase("No Of Subjects", thFont));
            noofSubjectsCell.Border = Cell.RECTANGLE;
            noofSubjectsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classListTable.AddCell(noofSubjectsCell);

            Cell classStudentsCell = new Cell(new Phrase("No of Students", thFont));
            classStudentsCell.Border = Cell.RECTANGLE;
            classStudentsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            classListTable.AddCell(classStudentsCell);
 
            document.Add(classListTable);

        }


        //table details 
        private void AddTableDetails()
        {
            foreach (var st in _ViewModel._ClassesList)
            {
                AddStudentInfoDetails(st);
            }
        }

        //table details 
        private void AddStudentInfoDetails(SchoolClassesDTO cl)
        {
            Table classListTable = new Table(6);
            classListTable.WidthPercentage = 100;
            classListTable.Spacing = 1;
            classListTable.Padding = 1;

            Cell shortCodeCell = new Cell(new Phrase(cl.ShortCode, tdFont));
            shortCodeCell.Border = Cell.RECTANGLE;
            shortCodeCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            classListTable.AddCell(shortCodeCell);

            Cell classNameCell = new Cell(new Phrase(cl.ClassName, tdFont));
            classNameCell.Border = Cell.RECTANGLE;
            classNameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            classListTable.AddCell(classNameCell);

            var _programmeYearquery = (from py in db.ProgrammeYears
                                       where py.Id == cl.ProgrammeYearId
                                      select py).FirstOrDefault();
            ProgrammeYear _ProgrammeYear = _programmeYearquery;

            Cell programmeYearCell = new Cell(new Phrase(_ProgrammeYear.Description, tdFont));
            programmeYearCell.Border = Cell.RECTANGLE;
            programmeYearCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            classListTable.AddCell(programmeYearCell);

           
            var _ClassTeacherquery = (from tc in db.Teachers
                                       where tc.Id == cl.ClassTeacher
                                       select tc).FirstOrDefault();
            Teacher _Teacher = _ClassTeacherquery;

            Cell classTeacherCell = new Cell(new Phrase(_Teacher.Name, tdFont));
            classTeacherCell.Border = Cell.RECTANGLE;
            classTeacherCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            classListTable.AddCell(classTeacherCell);

            Cell noofSubjectsCell = new Cell(new Phrase(cl.NoOfSubjects.ToString(), tdFont));
            noofSubjectsCell.Border = Cell.RECTANGLE;
            noofSubjectsCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            classListTable.AddCell(noofSubjectsCell);

            Cell classStudentsCell = new Cell(new Phrase(cl.NoofStudents.ToString(), tdFont));
            classStudentsCell.Border = Cell.RECTANGLE;
            classStudentsCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            classListTable.AddCell(classStudentsCell);

            document.Add(classListTable);
        }

        //table totals
        private void AddTableTotals()
        {

        }

        //document footer
        private void AddDocFooter()
        {
            Table classListTable = new Table(1);
            classListTable.WidthPercentage = 100;
            classListTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            classListTable.AddCell(sgCell);

            document.Add(classListTable);

        }

    }
}


