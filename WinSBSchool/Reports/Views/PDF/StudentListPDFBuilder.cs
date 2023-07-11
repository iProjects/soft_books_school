using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;
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
    public class StudentListPDFBuilder
    {

        string sFilePDF;
        StudentListViewModel _ViewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER

        public StudentListPDFBuilder(StudentListViewModel studentListViewModel, string FileName)
        {

            if (studentListViewModel == null)
                throw new ArgumentNullException("StudentListViewModel is null");
            _ViewModel = studentListViewModel;

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
                Table studentListTable = new Table(5);
                studentListTable.WidthPercentage = 100;
                studentListTable.Padding = 1;
                studentListTable.Spacing = 1;
                studentListTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                studentListTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                studentListTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                studentListTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                studentListTable.AddCell(nullCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
                studentListTable.AddCell(logoCell);


                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                studentListTable.AddCell(reportdateCell);

                Cell ClassCell = new Cell(new Phrase("Class:     " + _ViewModel.ClassName, hFont));
                ClassCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                ClassCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                studentListTable.AddCell(ClassCell);

                document.Add(studentListTable);

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
            Table studentListTable = new Table(9);
            studentListTable.WidthPercentage = 100;
            studentListTable.Spacing = 1;
            studentListTable.Padding = 1;

            Cell studentNameCell = new Cell(new Phrase("Name", thFont));
            studentNameCell.Border = Cell.RECTANGLE;
            studentNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(studentNameCell);

            Cell adminNoCell = new Cell(new Phrase("Admin No", thFont));
            adminNoCell.Border = Cell.RECTANGLE;
            adminNoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(adminNoCell);

            Cell genderCell = new Cell(new Phrase("Gender", thFont));
            genderCell.Border = Cell.RECTANGLE;
            genderCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(genderCell);

            Cell dobCell = new Cell(new Phrase("Dob", thFont));
            dobCell.Border = Cell.RECTANGLE;
            dobCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(dobCell);

            Cell classStreamCell = new Cell(new Phrase("Stream", thFont));
            classStreamCell.Border = Cell.RECTANGLE;
            classStreamCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(classStreamCell);

            Cell admissionDateCell = new Cell(new Phrase("Admission Date", thFont));
            admissionDateCell.Border = Cell.RECTANGLE;
            admissionDateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(admissionDateCell);

            Cell kcpeCell = new Cell(new Phrase("KCPE", thFont));
            kcpeCell.Border = Cell.RECTANGLE;
            kcpeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(kcpeCell);

            Cell parentNameCell = new Cell(new Phrase("Parent Name", thFont));
            parentNameCell.Border = Cell.RECTANGLE;
            parentNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(parentNameCell);

            Cell parentPhoneCell = new Cell(new Phrase("Parent Phone", thFont));
            parentPhoneCell.Border = Cell.RECTANGLE;
            parentPhoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(parentPhoneCell);

            document.Add(studentListTable);

        }


        //table details 
        private void AddTableDetails()
        {
            foreach (var st in _ViewModel._StudentsDTO)
            {
                AddStudentInfoDetails(st);
            }
        }

        //table details 
        private void AddStudentInfoDetails(StudentsListDTO st)
        {
            Table studentListTable = new Table(9);
            studentListTable.WidthPercentage = 100;
            studentListTable.Spacing = 1;
            studentListTable.Padding = 1;

            Cell studentNameCell = new Cell(new Phrase(st.StudentName, tdFont));
            studentNameCell.Border = Cell.RECTANGLE;
            studentNameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            studentListTable.AddCell(studentNameCell);

            Cell adminNoCell = new Cell(new Phrase(st.AdmissionNo, tdFont));
            adminNoCell.Border = Cell.RECTANGLE;
            adminNoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            studentListTable.AddCell(adminNoCell);

            var gender = new BindingList<KeyValuePair<string, string>>();
            gender.Add(new KeyValuePair<string, string>("M", "Male"));
            gender.Add(new KeyValuePair<string, string>("F", "Female"));

            string _applicableto = (from ap in gender
                                    where ap.Key == st.Gender
                                    select ap.Value).FirstOrDefault();

            Cell genderCell = new Cell(new Phrase(_applicableto, tdFont));
            genderCell.Border = Cell.RECTANGLE;
            genderCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            studentListTable.AddCell(genderCell);

            Cell dobCell = new Cell(new Phrase(st.DOB.ToString("dd/MM/yyyy"), tdFont));
            dobCell.Border = Cell.RECTANGLE;
            dobCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            studentListTable.AddCell(dobCell);

            Cell classStreamCell = new Cell(new Phrase(st.Stream, tdFont));
            classStreamCell.Border = Cell.RECTANGLE;
            classStreamCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            studentListTable.AddCell(classStreamCell);

            Cell admissionDateCell = new Cell(new Phrase(st.AdmissionDate.ToString("dd/MM/yyyy"), tdFont));
            admissionDateCell.Border = Cell.RECTANGLE;
            admissionDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            studentListTable.AddCell(admissionDateCell);

            Cell kcpeCell = new Cell(new Phrase(st.KCPEMark, tdFont));
            kcpeCell.Border = Cell.RECTANGLE;
            kcpeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(kcpeCell);

            Cell parentNameCell = new Cell(new Phrase(st.ParentName, tdFont));
            parentNameCell.Border = Cell.RECTANGLE;
            parentNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(parentNameCell);

            Cell parentPhoneCell = new Cell(new Phrase(st.ParentPhoneno, tdFont));
            parentPhoneCell.Border = Cell.RECTANGLE;
            parentPhoneCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            studentListTable.AddCell(parentPhoneCell);

            document.Add(studentListTable);
        }

        //table totals
        private void AddTableTotals()
        {

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
