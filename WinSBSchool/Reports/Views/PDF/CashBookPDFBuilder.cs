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
using System.Windows.Forms;

namespace WinSBSchool.Reports.Views.PDF
{
   public class CashBookPDFBuilder
    {
        string sFilePDF;
        CashBookViewModel _ViewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER


        public CashBookPDFBuilder(CashBookViewModel _cashBookViewModel, string FileName)
        {
            if (_cashBookViewModel == null)
                throw new ArgumentNullException("CashBookViewModel is null");
            _ViewModel = _cashBookViewModel;

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
                Table cashBookTable = new Table(5);
                cashBookTable.WidthPercentage = 100;
                cashBookTable.Padding = 1;
                cashBookTable.Spacing = 1;
                cashBookTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(nullCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell Logcell = new Cell(img0);
                Logcell.HorizontalAlignment = Cell.ALIGN_LEFT;
                Logcell.Border = Cell.NO_BORDER;
                Logcell.Add(new Phrase(_ViewModel.SchoolSlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                cashBookTable.AddCell(Logcell);

                Cell reportdateCell = new Cell(new Phrase("Report Date:     " + _ViewModel.ReportDate.ToShortDateString(), hFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Colspan = 5;
                reportdateCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(reportdateCell);

                Cell sDateCell = new Cell(new Phrase("START DATE:" + _ViewModel.StartDate.ToShortDateString(), hFont));
                sDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                sDateCell.Colspan = 5;
                sDateCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(sDateCell);

                Cell EDateCell = new Cell(new Phrase("END DATE:" + _ViewModel.EndDate.ToShortDateString(), hFont));
                EDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                EDateCell.Colspan = 5;
                EDateCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(EDateCell);

                Cell nameCell = new Cell(new Phrase(_ViewModel.CustomerName, hFont));
                nameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                nameCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(nameCell);

                Cell billtoCell = new Cell(new Phrase("BILL TO", hFont));
                billtoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtoCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(billtoCell);

                Cell billtoNameCell = new Cell(new Phrase(_ViewModel.BillToName, hFont));
                billtoNameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtoNameCell.Colspan = 3;
                billtoNameCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(billtoNameCell);


                Cell addrCell = new Cell(new Phrase(_ViewModel.CustomerAddress, hFont));
                addrCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                addrCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(addrCell);

                Cell nilCell = new Cell(new Phrase("", hFont));
                addrCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(nilCell);

                Cell billtoAddrCell = new Cell(new Phrase(_ViewModel.BillToAddress, hFont));
                billtoAddrCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtoAddrCell.Colspan = 3;
                billtoAddrCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(billtoAddrCell);

                Cell phoneCell = new Cell(new Phrase(_ViewModel.CustomerTelephone, hFont));
                phoneCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                phoneCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(phoneCell);

                Cell nil2Cell = new Cell(new Phrase("", hFont));
                addrCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(nil2Cell);

                Cell billtophoneCell = new Cell(new Phrase(_ViewModel.BillToTelephone, hFont));
                billtophoneCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtophoneCell.Colspan = 3;
                billtophoneCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(billtophoneCell);

                Cell emailCell = new Cell(new Phrase(_ViewModel.CustomerEmail, hFont));
                emailCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                emailCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(emailCell);

                Cell nil3Cell = new Cell(new Phrase("", hFont));
                addrCell.Border = Cell.NO_BORDER;
                cashBookTable.AddCell(nil3Cell);

                //Cell billtoemailCell = new Cell(new Phrase(_ViewModel.BillToEmail, hFont2));
                //billtoemailCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                //billtoemailCell.Colspan = 3;
                //billtoemailCell.Border = Cell.NO_BORDER;
                //cashBookTable.AddCell(billtoemailCell);

                document.Add(cashBookTable);

                //document.Add(new Phrase("Comments"));
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
                Utils.ShowError(ex);
            }
        }

        //document body
        private void AddDocBody()
        {


            //Add table headers
            Table cashBookTable = new Table(4);
            cashBookTable.WidthPercentage = 100;
            cashBookTable.Spacing = 1;
            cashBookTable.Padding = 1;

            AddTableHeaders(cashBookTable);

            //Add table details  
            foreach (var d in _ViewModel.CBStatementTransactions)
            {
                AddStatementDetails(cashBookTable, d);
            }

            document.Add(cashBookTable);

            //Add table totals
            AddTableTotals();

        }

        //table headers
        private void AddTableHeaders(Table cashBookTable)
        {
            Cell dateCell = new Cell(new Phrase("DATE", thFont));
            dateCell.Border = Cell.RECTANGLE;
            dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            dateCell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(dateCell);

            Cell desCell = new Cell(new Phrase("DESCRIPTION", thFont));
            desCell.Border = Cell.RECTANGLE;
            desCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            desCell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(desCell);

            Cell amtCell = new Cell(new Phrase("AMOUNT", thFont));
            amtCell.Border = Cell.RECTANGLE;
            amtCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            amtCell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(amtCell);

            Cell balCell = new Cell(new Phrase("BALANCE", thFont));
            balCell.Border = Cell.RECTANGLE;
            balCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            balCell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(balCell);

        }


        //table details 
        private void AddStatementDetails(Table cashBookTable, CBStatementTransaction txn)
        {

            Cell dateCell = new Cell(new Phrase(txn.PostDate.ToString("dd-MM-yyyy"), tdFont));
            dateCell.Border = Cell.RECTANGLE;
            dateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            cashBookTable.AddCell(dateCell);

            Cell desCell = new Cell(new Phrase(txn.Narrative, tdFont));
            desCell.Border = Cell.RECTANGLE;
            desCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            cashBookTable.AddCell(desCell);

            Cell amtCell = new Cell(new Phrase(txn.Amount.ToString("#,##0"), tdFont));
            amtCell.Border = Cell.RECTANGLE;
            amtCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(amtCell);

            Cell balCell = new Cell(new Phrase(txn.Balance.ToString("#,##0"), tdFont));
            balCell.Border = Cell.RECTANGLE;
            balCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(balCell);

        }

        //table totals
        private void AddTableTotals()
        {
            Table cashBookTable = new Table(6);
            cashBookTable.WidthPercentage = 100;
            cashBookTable.Spacing = 1;
            cashBookTable.Padding = 1;

            // Put table headers
            Cell currCell = new Cell(new Phrase("CURRENT", thFont));
            currCell.Border = Cell.RECTANGLE;
            currCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            currCell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(currCell);

            Cell p130Cell = new Cell(new Phrase("1-30 DAYS PAST DUE", thFont));
            p130Cell.Border = Cell.RECTANGLE;
            p130Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p130Cell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(p130Cell);

            Cell p3060Cell = new Cell(new Phrase("31-60 DAYS PAST DUE", thFont));
            p3060Cell.Border = Cell.RECTANGLE;
            p3060Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p3060Cell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(p3060Cell);

            Cell p6090Cell = new Cell(new Phrase("61-90 DAYS PAST DUE", thFont));
            p6090Cell.Border = Cell.RECTANGLE;
            p6090Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p6090Cell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(p6090Cell);

            Cell over90Cell = new Cell(new Phrase("Over 90 DAYS PAST DUE", thFont));
            over90Cell.Border = Cell.RECTANGLE;
            over90Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            over90Cell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(over90Cell);

            Cell dueCell = new Cell(new Phrase("AMOUNT DUE", thFont));
            dueCell.Border = Cell.RECTANGLE;
            dueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            dueCell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(dueCell);

            //Put data

            Cell curramtCell = new Cell(new Phrase(_ViewModel.CurrentBalance.ToString("#,##0"), tdFont));
            curramtCell.Border = Cell.RECTANGLE;
            curramtCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(curramtCell);

            Cell amt130Cell = new Cell(new Phrase(_ViewModel.Bal30.ToString("#,##0"), tdFont));
            amt130Cell.Border = Cell.RECTANGLE;
            amt130Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(amt130Cell);

            Cell amt3060Cell = new Cell(new Phrase(_ViewModel.Bal60.ToString("#,##0"), tdFont));
            amt3060Cell.Border = Cell.RECTANGLE;
            amt3060Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(amt3060Cell);

            Cell amt6090Cell = new Cell(new Phrase(_ViewModel.Bal90.ToString("#,##0"), tdFont));
            amt6090Cell.Border = Cell.RECTANGLE;
            amt6090Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(amt6090Cell);

            Cell amtover90Cell = new Cell(new Phrase(_ViewModel.BalOver90.ToString("#,##0"), tdFont));
            amtover90Cell.Border = Cell.RECTANGLE;
            amtover90Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(amtover90Cell);

            Cell amtdueCell = new Cell(new Phrase(_ViewModel.CurrentBalance.ToString("#,##0"), tdFont));
            amtdueCell.Border = Cell.RECTANGLE;
            amtdueCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(amtdueCell);

            //Add remittance area

            Cell nilCell = new Cell(new Phrase("", thFont));
            nilCell.Border = Cell.RECTANGLE;
            nilCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            nilCell.Colspan = 3;
            cashBookTable.AddCell(nilCell);

            Cell remitCell = new Cell(new Phrase("REMITTANCE", thFont));
            remitCell.Border = Cell.RECTANGLE;
            remitCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            remitCell.Colspan = 3;
            remitCell.BackgroundColor = Color.CYAN;
            cashBookTable.AddCell(remitCell);

            //Debits
            Cell nil2Cell = new Cell(new Phrase("", thFont));
            nil2Cell.Border = Cell.RECTANGLE;
            nil2Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            nil2Cell.Colspan = 3;
            cashBookTable.AddCell(nil2Cell);

            Cell drCell = new Cell(new Phrase("Total Debit", tdFont));
            drCell.Border = Cell.RECTANGLE;
            drCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            drCell.Colspan = 2;
            cashBookTable.AddCell(drCell);

            Cell totaldrCell = new Cell(new Phrase(_ViewModel.TotalDebits.ToString("#,##0"), tdFont));
            totaldrCell.Border = Cell.RECTANGLE;
            totaldrCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(totaldrCell);

            //Credits
            Cell nil3Cell = new Cell(new Phrase("", thFont));
            nil3Cell.Border = Cell.RECTANGLE;
            nil3Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            nil3Cell.Colspan = 3;
            cashBookTable.AddCell(nil3Cell);

            Cell crCell = new Cell(new Phrase("Total Credit", tdFont));
            crCell.Border = Cell.RECTANGLE;
            crCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            crCell.Colspan = 2;
            cashBookTable.AddCell(crCell);

            Cell totalcrCell = new Cell(new Phrase(_ViewModel.TotalCredits.ToString("#,##0"), tdFont));
            totalcrCell.Border = Cell.RECTANGLE;
            totalcrCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            cashBookTable.AddCell(totalcrCell);


            document.Add(cashBookTable);
        }

        //document footer
        private void AddDocFooter()
        {

            Table cashBookTable = new Table(1);
            cashBookTable.WidthPercentage = 100;
            cashBookTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            cashBookTable.AddCell(sgCell);

            document.Add(cashBookTable);

        }

    }
}

