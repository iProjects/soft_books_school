using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VVX;
using WinSBSchool.Reports.Viewer;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.PDFBuilders
{
    public class TeachersListPDFBuilder
    {
        string sFilePDF;
        TeachersListViewModel _ViewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER


        public TeachersListPDFBuilder(TeachersListViewModel _teacherviewmodel, string FileName)
        {
            if (_teacherviewmodel == null)
                throw new ArgumentNullException("TeachersListViewModel is null");
            _ViewModel = _teacherviewmodel;
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

            Table teachersListTable = new Table(5);
            teachersListTable.WidthPercentage = 100;
            teachersListTable.Padding = 1;
            teachersListTable.Spacing = 1;
            teachersListTable.Border = Table.NO_BORDER;

            Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
            SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            SchoolNameCell.Colspan = 5;
            SchoolNameCell.Border = Cell.NO_BORDER;
            teachersListTable.AddCell(SchoolNameCell);

            Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
            SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            SchoolAddressCell.Colspan = 5;
            SchoolAddressCell.Border = Cell.NO_BORDER;
            teachersListTable.AddCell(SchoolAddressCell);

            Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
            reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportNameCell.Colspan = 5;
            reportNameCell.Border = Cell.NO_BORDER;
            teachersListTable.AddCell(reportNameCell);

            Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
            nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            nullCell.Colspan = 4;
            nullCell.Border = Cell.NO_BORDER;
            teachersListTable.AddCell(nullCell);

            PDFGen pdfgen = new PDFGen();
            Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
            imgCell.Alignment = Image.ALIGN_MIDDLE;
            Cell logoCell = new Cell(imgCell);
            logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            logoCell.Border = Cell.NO_BORDER;
            logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
            teachersListTable.AddCell(logoCell);


            Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
            reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            reportdateCell.Border = Cell.NO_BORDER;
            reportdateCell.Colspan = 5;
            teachersListTable.AddCell(reportdateCell);

            document.Add(teachersListTable);

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
            Table teachersListTable = new Table(6);
            teachersListTable.WidthPercentage = 100;
            teachersListTable.Spacing = 1;
            teachersListTable.Padding = 1;


            Cell teacherNameCell = new Cell(new Phrase("Name", thFont));
            teacherNameCell.Border = Cell.RECTANGLE;
            teacherNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            teachersListTable.AddCell(teacherNameCell);

            Cell idNoCell = new Cell(new Phrase("Id No", thFont));
            idNoCell.Border = Cell.RECTANGLE;
            idNoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            teachersListTable.AddCell(idNoCell);

            Cell tscNoCell = new Cell(new Phrase("Tsc No", thFont));
            tscNoCell.Border = Cell.RECTANGLE;
            tscNoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            teachersListTable.AddCell(tscNoCell);

            Cell positionCell = new Cell(new Phrase("Position", thFont));
            positionCell.Border = Cell.RECTANGLE;
            positionCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            teachersListTable.AddCell(positionCell);

            Cell dateJoinedCell = new Cell(new Phrase("Date Joined", thFont));
            dateJoinedCell.Border = Cell.RECTANGLE;
            dateJoinedCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            teachersListTable.AddCell(dateJoinedCell);

            Cell qualificationCell = new Cell(new Phrase("Qualification", thFont));
            qualificationCell.Border = Cell.RECTANGLE;
            qualificationCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            teachersListTable.AddCell(qualificationCell);

            document.Add(teachersListTable);
        }


        //table details 
        private void AddTableDetails()
        {
            foreach (var ti in _ViewModel._TeachersList)
            {
                AddTeacherInfoDetails(ti);
            }
        }

        //table details 
        private void AddTeacherInfoDetails(TeachersListDTO t)
        {
            Table teachersListTable = new Table(6);
            teachersListTable.WidthPercentage = 100;
            teachersListTable.Spacing = 1;
            teachersListTable.Padding = 1;

            Cell teacherNameCell = new Cell(new Phrase(t.TeacherName, tdFont));
            teacherNameCell.Border = Cell.RECTANGLE;
            teacherNameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            teachersListTable.AddCell(teacherNameCell);

            Cell idNoCell = new Cell(new Phrase(t.IDNo, tdFont));
            idNoCell.Border = Cell.RECTANGLE;
            idNoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            teachersListTable.AddCell(idNoCell);

            Cell tscNoCell = new Cell(new Phrase(t.TSCNo, tdFont));
            tscNoCell.Border = Cell.RECTANGLE;
            tscNoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            teachersListTable.AddCell(tscNoCell);

            Cell positionCell = new Cell(new Phrase(t.Position, tdFont));
            positionCell.Border = Cell.RECTANGLE;
            positionCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            teachersListTable.AddCell(positionCell);

            Cell dateJoinedCell = new Cell(new Phrase(t.DateJoined.ToShortDateString(), tdFont));
            dateJoinedCell.Border = Cell.RECTANGLE;
            dateJoinedCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            teachersListTable.AddCell(dateJoinedCell);

            var qualifications = new BindingList<KeyValuePair<string, string>>();
            qualifications.Add(new KeyValuePair<string, string>("DI", "Diploma"));
            qualifications.Add(new KeyValuePair<string, string>("DE", "Degree"));
            qualifications.Add(new KeyValuePair<string, string>("MA", "Masters"));
            qualifications.Add(new KeyValuePair<string, string>("PH", "Doctor of Philosophy(Phd)"));
            string _qualification = (from ap in qualifications
                                     where ap.Key == t.Qualification
                                     select ap.Value).FirstOrDefault();

            Cell qualificationCell = new Cell(new Phrase(_qualification, tdFont));
            qualificationCell.Border = Cell.RECTANGLE;
            qualificationCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            teachersListTable.AddCell(qualificationCell);

            document.Add(teachersListTable);
        }

        //table totals
        private void AddTableTotals()
        {

        }

        //document footer
        private void AddDocFooter()
        {
            Table teachersListTable = new Table(1);
            teachersListTable.WidthPercentage = 100;
            teachersListTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            teachersListTable.AddCell(sgCell);

            document.Add(teachersListTable);

        }


    }
}