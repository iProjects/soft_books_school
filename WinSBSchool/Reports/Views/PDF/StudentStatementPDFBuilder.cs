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
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.Views.PDF
{
    public class StudentStatementPDFBuilder
    {
        string sFilePDF;
        StudentStatementViewModel _ViewModel;
        string Message;
        Document document;


        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER



        public StudentStatementPDFBuilder(StudentStatementViewModel _studentStatementViewModel, string FileName)
        {
            if (_studentStatementViewModel == null)
                throw new ArgumentNullException("_studentStatementViewModel is null");
            _ViewModel = _studentStatementViewModel;

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
                Table statementTable = new Table(5);
                statementTable.WidthPercentage = 100;
                statementTable.Padding = 1;
                statementTable.Spacing = 1;
                statementTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                statementTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                statementTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                statementTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                statementTable.AddCell(nullCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo.Trim());
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(img0);
                logoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan.Trim(), new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                statementTable.AddCell(logoCell);

                Cell reportDateCell = new Cell(new Phrase("Print Date :  " + _ViewModel.ReportDate.ToShortDateString(), hFont));
                reportDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                //reportDateCell.Colspan = 5;
                reportDateCell.Border = Cell.NO_BORDER;
                statementTable.AddCell(reportDateCell);

                Cell startDateCell = new Cell(new Phrase("Start Date :  " + _ViewModel.StartDate.ToShortDateString(), hFont));
                startDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                //startDateCell.Colspan = 5;
                startDateCell.Border = Cell.NO_BORDER;
                statementTable.AddCell(startDateCell);

                Cell endDateCell = new Cell(new Phrase("End Date :  " + _ViewModel.EndDate.ToShortDateString(), hFont));
                endDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                endDateCell.Colspan = 3;
                endDateCell.Border = Cell.NO_BORDER;
                statementTable.AddCell(endDateCell);

                Cell customerCell = new Cell(new Phrase("CUSTOMER", new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
                customerCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                customerCell.Border = Cell.NO_BORDER;
                customerCell.Colspan = 2;
                statementTable.AddCell(customerCell);

                Cell billtoCell = new Cell(new Phrase("BILL TO", new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLACK)));
                billtoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtoCell.Border = Cell.NO_BORDER;
                billtoCell.Colspan = 3;
                statementTable.AddCell(billtoCell);

                Cell customerNameCell = new Cell(new Phrase(_ViewModel.CustomerName, hFont));
                customerNameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                customerNameCell.Colspan = 2;
                customerNameCell.Border = Cell.NO_BORDER;
                statementTable.AddCell(customerNameCell);

                Cell billtoNameCell = new Cell(new Phrase(_ViewModel.BillToName, hFont));
                billtoNameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtoNameCell.Border = Cell.NO_BORDER;
                billtoNameCell.Colspan = 3;
                statementTable.AddCell(billtoNameCell);


                Cell customerAddressCell = new Cell(new Phrase(_ViewModel.CustomerAddress, hFont));
                customerAddressCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                customerAddressCell.Border = Cell.NO_BORDER;
                customerAddressCell.Colspan = 2;
                statementTable.AddCell(customerAddressCell);

                Cell billToAddressCell = new Cell(new Phrase(_ViewModel.BillToAddress, hFont));
                billToAddressCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billToAddressCell.Border = Cell.NO_BORDER;
                billToAddressCell.Colspan = 3;
                statementTable.AddCell(billToAddressCell);

                Cell customerTelephoneCell = new Cell(new Phrase(_ViewModel.CustomerTelephone, hFont));
                customerTelephoneCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                customerTelephoneCell.Border = Cell.NO_BORDER;
                customerTelephoneCell.Colspan = 2;
                statementTable.AddCell(customerTelephoneCell);

                Cell billToTelephoneCell = new Cell(new Phrase(_ViewModel.BillToTelephone, hFont));
                billToTelephoneCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billToTelephoneCell.Border = Cell.NO_BORDER;
                billToTelephoneCell.Colspan = 3;
                statementTable.AddCell(billToTelephoneCell);

                Cell customerEmailCell = new Cell(new Phrase(_ViewModel.CustomerEmail, hFont));
                customerEmailCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                customerEmailCell.Border = Cell.NO_BORDER;
                customerEmailCell.Colspan = 2;
                statementTable.AddCell(customerEmailCell);

                Cell billToEmailCell = new Cell(new Phrase(_ViewModel.BillToEmail, hFont));
                billToEmailCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billToEmailCell.Border = Cell.NO_BORDER;
                billToEmailCell.Colspan = 3;
                statementTable.AddCell(billToEmailCell);

                document.Add(statementTable);

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
            Table transactionstable = new Table(5);
            transactionstable.WidthPercentage = 100;
            transactionstable.Spacing = 1;
            transactionstable.Padding = 1;

            AddTableHeaders(transactionstable);

            //Add table details  
            foreach (var d in _ViewModel.StatementTransactions)
            {
                AddStatementDetails(transactionstable, d);
            }

            document.Add(transactionstable);

            //Add table totals
            AddTableTotals();

        }

        //table headers
        private void AddTableHeaders(Table transactionstable)
        {
            Cell dateCell = new Cell(new Phrase("Date", thFont));
            dateCell.Border = Cell.RECTANGLE;
            dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            dateCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(dateCell);

            Cell desCell = new Cell(new Phrase("Description", thFont));
            desCell.Border = Cell.RECTANGLE;
            desCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            desCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(desCell);

            Cell amtCell = new Cell(new Phrase("Amount", thFont));
            amtCell.Border = Cell.RECTANGLE;
            amtCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            amtCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(amtCell);

            Cell balCell = new Cell(new Phrase("Balance", thFont));
            balCell.Border = Cell.RECTANGLE;
            balCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            balCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(balCell);

            Cell TransRefCell = new Cell(new Phrase("Transaction Reference", thFont));
            TransRefCell.Border = Cell.RECTANGLE;
            TransRefCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            TransRefCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(TransRefCell);

        }


        //table details 
        private void AddStatementDetails(Table transactionstable, StatementTransaction txn)
        {

            Cell dateCell = new Cell(new Phrase(txn.PostDate.ToString("dd-MM-yyyy"), tdFont));
            dateCell.Border = Cell.RECTANGLE;
            dateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            transactionstable.AddCell(dateCell);

            Cell desCell = new Cell(new Phrase(txn.Narrative, tdFont));
            desCell.Border = Cell.RECTANGLE;
            desCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            transactionstable.AddCell(desCell);

            Cell amtCell = new Cell(new Phrase(txn.Amount.ToString("#,##0"), tdFont));
            amtCell.Border = Cell.RECTANGLE;
            amtCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            transactionstable.AddCell(amtCell);

            Cell balCell = new Cell(new Phrase(txn.Balance.ToString("#,##0"), tdFont));
            balCell.Border = Cell.RECTANGLE;
            balCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            transactionstable.AddCell(balCell);

            Cell TransRefCell = new Cell(new Phrase(txn.TransRef, tdFont));
            TransRefCell.Border = Cell.RECTANGLE;
            TransRefCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            transactionstable.AddCell(TransRefCell);

        }

        //table totals
        private void AddTableTotals()
        {
            Table totalsTable = new Table(6);
            totalsTable.WidthPercentage = 100;
            totalsTable.Spacing = 1;
            totalsTable.Padding = 1;

            // Put table headers
            Cell currCell = new Cell(new Phrase("Current", thFont));
            currCell.Border = Cell.RECTANGLE;
            currCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            currCell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(currCell);

            Cell p130Cell = new Cell(new Phrase("1-30 Days Past Due", thFont));
            p130Cell.Border = Cell.RECTANGLE;
            p130Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p130Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(p130Cell);

            Cell p3060Cell = new Cell(new Phrase("31-60 Days Past Due", thFont));
            p3060Cell.Border = Cell.RECTANGLE;
            p3060Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p3060Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(p3060Cell);

            Cell p6090Cell = new Cell(new Phrase("61-90 Days Past Due", thFont));
            p6090Cell.Border = Cell.RECTANGLE;
            p6090Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p6090Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(p6090Cell);

            Cell over90Cell = new Cell(new Phrase("Over 90 Days Past Due", thFont));
            over90Cell.Border = Cell.RECTANGLE;
            over90Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            over90Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(over90Cell);

            Cell dueCell = new Cell(new Phrase("Amount Due", thFont));
            dueCell.Border = Cell.RECTANGLE;
            dueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            dueCell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(dueCell);

            //Put data

            Cell curramtCell = new Cell(new Phrase(_ViewModel.CurrentBalance.ToString("#,##0"), tdFont));
            curramtCell.Border = Cell.RECTANGLE;
            curramtCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(curramtCell);

            Cell amt130Cell = new Cell(new Phrase(_ViewModel.Bal30.ToString("#,##0"), tdFont));
            amt130Cell.Border = Cell.RECTANGLE;
            amt130Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amt130Cell);

            Cell amt3060Cell = new Cell(new Phrase(_ViewModel.Bal60.ToString("#,##0"), tdFont));
            amt3060Cell.Border = Cell.RECTANGLE;
            amt3060Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amt3060Cell);

            Cell amt6090Cell = new Cell(new Phrase(_ViewModel.Bal90.ToString("#,##0"), tdFont));
            amt6090Cell.Border = Cell.RECTANGLE;
            amt6090Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amt6090Cell);

            Cell amtover90Cell = new Cell(new Phrase(_ViewModel.BalOver90.ToString("#,##0"), tdFont));
            amtover90Cell.Border = Cell.RECTANGLE;
            amtover90Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amtover90Cell);

            Cell amtdueCell = new Cell(new Phrase(_ViewModel.CurrentBalance.ToString("#,##0"), tdFont));
            amtdueCell.Border = Cell.RECTANGLE;
            amtdueCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amtdueCell);

            //Add remittance area

            Cell nilCell = new Cell(new Phrase("", thFont));
            nilCell.Border = Cell.RECTANGLE;
            nilCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            nilCell.Colspan = 3;
            totalsTable.AddCell(nilCell);

            Cell remitCell = new Cell(new Phrase("Remittance", thFont));
            remitCell.Border = Cell.RECTANGLE;
            remitCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            remitCell.Colspan = 3;
            remitCell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(remitCell);

            //Debits
            Cell nil2Cell = new Cell(new Phrase("", thFont));
            nil2Cell.Border = Cell.RECTANGLE;
            nil2Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            nil2Cell.Colspan = 3;
            totalsTable.AddCell(nil2Cell);

            Cell drCell = new Cell(new Phrase("Total Debit", tdFont));
            drCell.Border = Cell.RECTANGLE;
            drCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            drCell.Colspan = 2;
            totalsTable.AddCell(drCell);

            Cell totaldrCell = new Cell(new Phrase(_ViewModel.TotalDebits.ToString("#,##0"), tdFont));
            totaldrCell.Border = Cell.RECTANGLE;
            totaldrCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(totaldrCell);

            //Credits
            Cell nil3Cell = new Cell(new Phrase("", thFont));
            nil3Cell.Border = Cell.RECTANGLE;
            nil3Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            nil3Cell.Colspan = 3;
            totalsTable.AddCell(nil3Cell);

            Cell crCell = new Cell(new Phrase("Total Credit", tdFont));
            crCell.Border = Cell.RECTANGLE;
            crCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            crCell.Colspan = 2;
            totalsTable.AddCell(crCell);

            Cell totalcrCell = new Cell(new Phrase(_ViewModel.TotalCredits.ToString("#,##0"), tdFont));
            totalcrCell.Border = Cell.RECTANGLE;
            totalcrCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(totalcrCell);


            document.Add(totalsTable);
        }

        //document footer
        private void AddDocFooter()
        {

            Table statementTable = new Table(1);
            statementTable.WidthPercentage = 100;
            statementTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            statementTable.AddCell(sgCell);

            document.Add(statementTable);

        }

    }
}


