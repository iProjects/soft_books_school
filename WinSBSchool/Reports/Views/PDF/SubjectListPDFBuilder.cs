 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    public class SubjectListPDFBuilder
     {

        string sFilePDF;
        SubjectListViewModel _ViewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER

        public SubjectListPDFBuilder(SubjectListViewModel _subjectListViewModel, string FileName)
        {
            if (_subjectListViewModel == null)
                throw new ArgumentNullException("SubjectListViewModel is null");
            _ViewModel = _subjectListViewModel;

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
                Table subjectsListTable = new Table(5);
                subjectsListTable.WidthPercentage = 100;
                subjectsListTable.Padding = 1;
                subjectsListTable.Spacing = 1;
                subjectsListTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                subjectsListTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                subjectsListTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                subjectsListTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                subjectsListTable.AddCell(nullCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
                subjectsListTable.AddCell(logoCell);


                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                subjectsListTable.AddCell(reportdateCell);

                Cell classCell = new Cell(new Phrase("Class:     " + _ViewModel.ClassName, tdFont));
                classCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                classCell.Border = Cell.NO_BORDER;
                classCell.Colspan = 5;
                subjectsListTable.AddCell(classCell);

                document.Add(subjectsListTable);

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
            Table subjectsListTable = new Table(6);
            subjectsListTable.WidthPercentage = 100;
            subjectsListTable.Spacing = 1;
            subjectsListTable.Padding = 1;

            Cell shortCodeCell = new Cell(new Phrase("Short Code", thFont));
            shortCodeCell.Border = Cell.RECTANGLE;
            shortCodeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            subjectsListTable.AddCell(shortCodeCell);

            Cell descriptionCell = new Cell(new Phrase("Description", thFont));
            descriptionCell.Border = Cell.RECTANGLE;
            descriptionCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            subjectsListTable.AddCell(descriptionCell);

            Cell outOfCell = new Cell(new Phrase("Out Of", thFont));
            outOfCell.Border = Cell.RECTANGLE;
            outOfCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            subjectsListTable.AddCell(outOfCell);

            Cell passMarkCell = new Cell(new Phrase("Pass Mark", thFont));
            passMarkCell.Border = Cell.RECTANGLE;
            passMarkCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            subjectsListTable.AddCell(passMarkCell);

            Cell noOfRequiredHrsCell = new Cell(new Phrase("No of \nRequired Hours", thFont));
            noOfRequiredHrsCell.Border = Cell.RECTANGLE;
            noOfRequiredHrsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            subjectsListTable.AddCell(noOfRequiredHrsCell);

            Cell feesCell = new Cell(new Phrase("Fees", thFont));
            feesCell.Border = Cell.RECTANGLE;
            feesCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            subjectsListTable.AddCell(feesCell);

            document.Add(subjectsListTable);

        }


        //table details 
        private void AddTableDetails()
        {
            foreach (var st in _ViewModel._ClassSubjectsList)
            {
                AddSubjectInfoDetails(st);
            }
        }

        //table details 
        private void AddSubjectInfoDetails(SubjectsListDTO st)
        {
            Table subjectsListTable = new Table(6);
            subjectsListTable.WidthPercentage = 100;
            subjectsListTable.Spacing = 1;
            subjectsListTable.Padding = 1;

            Cell shortCodeCell = new Cell(new Phrase(st.ShortCode, tdFont));
            shortCodeCell.Border = Cell.RECTANGLE;
            shortCodeCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            subjectsListTable.AddCell(shortCodeCell);

            Cell descriptionCell = new Cell(new Phrase(st.Description, tdFont));
            descriptionCell.Border = Cell.RECTANGLE;
            descriptionCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            subjectsListTable.AddCell(descriptionCell);

            Cell outOfCell = new Cell(new Phrase(st.OutOf.ToString(), tdFont));
            outOfCell.Border = Cell.RECTANGLE;
            outOfCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            subjectsListTable.AddCell(outOfCell);

            Cell passMarkCell = new Cell(new Phrase(st.PassMark.ToString(), tdFont));
            passMarkCell.Border = Cell.RECTANGLE;
            passMarkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            subjectsListTable.AddCell(passMarkCell);

            Cell noOfRequiredHrsCell = new Cell(new Phrase(st.NoOfRequiredHours.ToString(), tdFont));
            noOfRequiredHrsCell.Border = Cell.RECTANGLE;
            noOfRequiredHrsCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            subjectsListTable.AddCell(noOfRequiredHrsCell);

            Cell feesCell = new Cell(new Phrase(st.Fees.ToString(), tdFont));
            feesCell.Border = Cell.RECTANGLE;
            feesCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            subjectsListTable.AddCell(feesCell);

            document.Add(subjectsListTable);
        }

        //table totals
        private void AddTableTotals()
        {

        }

        //document footer
        private void AddDocFooter()
        {
            Table subjectsListTable = new Table(1);
            subjectsListTable.WidthPercentage = 100;
            subjectsListTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            subjectsListTable.AddCell(sgCell);

            document.Add(subjectsListTable);
        }


    }
}
