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

namespace WinSBSchool.Reports.Views.PDF
{
    public class StudentFeeStructurePDFBuilder
      {

        string sFilePDF;
        StudentFeeStructureViewModel _ViewModel;
        string Message;
        Document document;


        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font thFont1 = new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLACK);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER


        public StudentFeeStructurePDFBuilder(StudentFeeStructureViewModel _studentFeeStructureViewModel, string FileName)
        {
         
            if (_studentFeeStructureViewModel == null)
                throw new ArgumentNullException("StudentFeeStructureViewModel is null");
            _ViewModel = _studentFeeStructureViewModel;

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

                AddDocTotals();

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
                Table feeStructureTable = new Table(5);
                feeStructureTable.WidthPercentage = 100;
                feeStructureTable.Padding = 1;
                feeStructureTable.Spacing = 1;
                feeStructureTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                feeStructureTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                feeStructureTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                feeStructureTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                feeStructureTable.AddCell(nullCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
                feeStructureTable.AddCell(logoCell);

                Cell classCell = new Cell(new Phrase("Class:     " + _ViewModel.ClassName, tdFont));
                classCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                classCell.Border = Cell.NO_BORDER;
                classCell.Colspan = 5;
                feeStructureTable.AddCell(classCell);

                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                feeStructureTable.AddCell(reportdateCell);

                document.Add(feeStructureTable);

             }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        //document body
        private void AddDocBody()
        {
            try
            {
                AddFeeStructureAcademicsTable();

                AddFeeStructureOthersTable();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void AddFeeStructureAcademicsTable()
        {
            AddFeeStructureAcademicsTableHeaders();

            foreach (var fs in _ViewModel.FeeStructureAcademics)
            {
                AddFeeStructureAcademicsTableBody(fs);
            }
            AddFeeStructureAcademicsTableTotals();
        }
        private void AddFeeStructureOthersTable()
        {
            AddFeeStructureOthersTableHeaders();

            foreach (var fs in _ViewModel.FeeStructureOthers)
            {
                AddFeeStructureOthersTableBody(fs);
            }
            AddFeeStructureOthersTableTotals();
        }
        private void AddFeeStructureAcademicsTableHeaders()
        {

            Table feeStructureTable = new Table(3);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Padding = 1;
            feeStructureTable.Spacing = 1;

            Cell AcademicCell = new Cell(new Phrase("Academic", thFont));
            AcademicCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            AcademicCell.Colspan = 3;
            feeStructureTable.AddCell(AcademicCell);

            Cell itemDescriptionCell = new Cell(new Phrase("", thFont));
            itemDescriptionCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            feeStructureTable.AddCell(itemDescriptionCell);

            Cell amountCell = new Cell(new Phrase("Amount", thFont));
            amountCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            amountCell.Border = Cell.NO_BORDER;
            feeStructureTable.AddCell(amountCell);

            Cell amountperiodCell = new Cell(new Phrase("Period", thFont));
            amountperiodCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            feeStructureTable.AddCell(amountperiodCell);

            document.Add(feeStructureTable);
        }

        private void AddFeeStructureOthersTableHeaders()
        {

            Table feeStructureTable = new Table(4);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Padding = 1;
            feeStructureTable.Spacing = 1;

            Cell OtherRequirementsCell = new Cell(new Phrase("Other Requirements", thFont));
            OtherRequirementsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            OtherRequirementsCell.Colspan = 4;
            feeStructureTable.AddCell(OtherRequirementsCell);

            Cell itemDescriptionCell = new Cell(new Phrase("", thFont));
            itemDescriptionCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            feeStructureTable.AddCell(itemDescriptionCell);

            Cell amountCell = new Cell(new Phrase("Amount", thFont));
            amountCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            amountCell.Border = Cell.NO_BORDER;
            feeStructureTable.AddCell(amountCell);

            Cell amountperiodCell = new Cell(new Phrase("Period", thFont));
            amountperiodCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            feeStructureTable.AddCell(amountperiodCell);

            Cell applicabletoCell = new Cell(new Phrase("Applicable To", thFont));
            applicabletoCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            feeStructureTable.AddCell(applicabletoCell);

            document.Add(feeStructureTable);
        }

        private void AddFeeStructureAcademicsTableBody(FeeStructureAcademicDTO fs)
        {
            Table feeStructureTable = new Table(3);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Padding = 1;
            feeStructureTable.Spacing = 1;

            Cell itemDescriptionCell = new Cell(new Phrase(fs.Description, tdFont));
            itemDescriptionCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feeStructureTable.AddCell(itemDescriptionCell);

            Cell amountCell = new Cell(new Phrase(fs.Amount.ToString("#,##0"), tdFont));
            amountCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            feeStructureTable.AddCell(amountCell);

            var _amountPeriods = new BindingList<KeyValuePair<string, string>>();
            _amountPeriods.Add(new KeyValuePair<string, string>("S", "Per Semester"));
            _amountPeriods.Add(new KeyValuePair<string, string>("Y", "Per Academic Year"));
            _amountPeriods.Add(new KeyValuePair<string, string>("D", "Once on Admission"));
            _amountPeriods.Add(new KeyValuePair<string, string>("P", "Once on Application"));
            _amountPeriods.Add(new KeyValuePair<string, string>("R", "Once on Admission(Refundable)"));

            string _amountPeriod = (from ap in _amountPeriods
                                    where ap.Key == fs.AmountPeriod
                                    select ap.Value).FirstOrDefault();

            Cell amountperiodCell = new Cell(new Phrase(_amountPeriod, tdFont));
            amountperiodCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feeStructureTable.AddCell(amountperiodCell);

            document.Add(feeStructureTable);
        }
        private void AddFeeStructureOthersTableBody(FeeStructureOthersDTO fs)
        {
            Table feeStructureTable = new Table(4);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Padding = 1;
            feeStructureTable.Spacing = 1;

            Cell itemDescriptionCell = new Cell(new Phrase(fs.Description, tdFont));
            itemDescriptionCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feeStructureTable.AddCell(itemDescriptionCell);

            Cell amountCell = new Cell(new Phrase(fs.Amount.ToString("#,##0"), tdFont));
            amountCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            feeStructureTable.AddCell(amountCell);

            var _amountPeriods = new BindingList<KeyValuePair<string, string>>();
            _amountPeriods.Add(new KeyValuePair<string, string>("S", "Per Semester"));
            _amountPeriods.Add(new KeyValuePair<string, string>("Y", "Per Academic Year"));
            _amountPeriods.Add(new KeyValuePair<string, string>("D", "Once on Admission"));
            _amountPeriods.Add(new KeyValuePair<string, string>("P", "Once on Application"));
            _amountPeriods.Add(new KeyValuePair<string, string>("R", "Once on Admission(Refundable)"));

            string _amountPeriod = (from ap in _amountPeriods
                                    where ap.Key == fs.AmountPeriod
                                    select ap.Value).FirstOrDefault();

            Cell amountperiodCell = new Cell(new Phrase(_amountPeriod, tdFont));
            amountperiodCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feeStructureTable.AddCell(amountperiodCell);

            var _ApplicableTo = new BindingList<KeyValuePair<string, string>>();
            _ApplicableTo.Add(new KeyValuePair<string, string>("A", "All"));
            _ApplicableTo.Add(new KeyValuePair<string, string>("B", "Boarder"));
            _ApplicableTo.Add(new KeyValuePair<string, string>("N", "Non-Boarder"));

            string _applicableto = (from ap in _ApplicableTo
                                    where ap.Key == fs.ApplicableTo
                                    select ap.Value).FirstOrDefault();

            Cell applicabletoCell = new Cell(new Phrase(_applicableto, tdFont));
            applicabletoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feeStructureTable.AddCell(applicabletoCell);

            document.Add(feeStructureTable);
        }
        private void AddFeeStructureAcademicsTableTotals()
        {

            Table feeStructureTable = new Table(3);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Padding = 1;
            feeStructureTable.Spacing = 1;

            Cell totalsCell = new Cell(new Phrase("Total", tdFont));
            totalsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            feeStructureTable.AddCell(totalsCell);

            Cell totalsValueCell = new Cell(new Phrase(_ViewModel.TotalAcademicFees.ToString("#,##0"), tdFont));
            totalsValueCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            feeStructureTable.AddCell(totalsValueCell);

            Cell totalsnullCell = new Cell(new Phrase("", tdFont));
            totalsnullCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsnullCell.Colspan = 1;
            feeStructureTable.AddCell(totalsnullCell);

            document.Add(feeStructureTable);

        }
        private void AddFeeStructureOthersTableTotals()
        {

            Table feeStructureTable = new Table(4);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Padding = 1;
            feeStructureTable.Spacing = 1;

            Cell totalsCell = new Cell(new Phrase("Total", tdFont));
            totalsCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            feeStructureTable.AddCell(totalsCell);

            Cell totalsValueCell = new Cell(new Phrase(_ViewModel.TotalOtherFees.ToString("#,##0"), tdFont));
            totalsValueCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            feeStructureTable.AddCell(totalsValueCell);

            Cell totalsnullCell = new Cell(new Phrase("", tdFont));
            totalsnullCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsnullCell.Colspan = 2;
            feeStructureTable.AddCell(totalsnullCell);

            document.Add(feeStructureTable);

        }

        //document Total
        private void AddDocTotals()
        {

            Table feeStructureTable = new Table(2);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Padding = 1;
            feeStructureTable.Spacing = 1;

            Cell totalsCell = new Cell(new Phrase("Total Fees", thFont1));
            totalsCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feeStructureTable.AddCell(totalsCell);

            Cell totalsValueCell = new Cell(new Phrase(_ViewModel.TotalFees.ToString("C2"), thFont1));
            totalsValueCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            feeStructureTable.AddCell(totalsValueCell);

            document.Add(feeStructureTable);
        }

        private void AddDocRemarks()
        {

            Table feeStructureTable = new Table(1);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Padding = 1;
            feeStructureTable.Spacing = 1;

            Cell totalsCell = new Cell(new Phrase("No Cash Payments or Personal Cheques will be accepted.", thFont1));
            totalsCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feeStructureTable.AddCell(totalsCell);

            Cell totalsValueCell = new Cell(new Phrase("All Payments should be made either by Banker's cheques or paid Directly into the School's Bank Accounts below:", thFont1));
            totalsValueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            feeStructureTable.AddCell(totalsValueCell);

            document.Add(feeStructureTable);
        }

        //document footer
        private void AddDocFooter()
        {

            Table feeStructureTable = new Table(1);
            feeStructureTable.WidthPercentage = 100;
            feeStructureTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            feeStructureTable.AddCell(sgCell);

            document.Add(feeStructureTable);

        }


      }
}
