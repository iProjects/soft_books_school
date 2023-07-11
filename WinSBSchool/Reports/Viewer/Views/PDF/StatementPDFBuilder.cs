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


namespace WinSchool.Reports.PDFBuilders
{
    public class StatementPDFBuilder
    {
        string sFilePDF;
        StatementViewModel statementviewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.DARK_GRAY);
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLUE);//TABLE HEADER


        public StatementPDFBuilder(StatementViewModel _statementviewModel, string FileName)
        {
            statementviewModel = _statementviewModel;
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
                Table hTable = new Table(5);
                hTable.WidthPercentage = 100;
                hTable.Padding = 1;
                hTable.Spacing = 1;
                hTable.Border = Table.NO_BORDER;

                Cell RCell = new Cell(new Phrase(statementviewModel.ReportName, new Font(Font.HELVETICA, 32, Font.BOLD, Color.BLUE)));
                RCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                RCell.Colspan = 4;
                RCell.Border = Cell.NO_BORDER;
                hTable.AddCell(RCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(statementviewModel.Logo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell Logcell = new Cell(img0);
                Logcell.HorizontalAlignment = Cell.ALIGN_LEFT;
                //Logcell.Rowspan = 2;
                Logcell.Border = Cell.NO_BORDER;
                Logcell.Add(new Phrase(statementviewModel.CompanySlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                hTable.AddCell(Logcell);
                 

                Cell repDateCell = new Cell(new Phrase("REPORT DATE:" + statementviewModel.ReportDate.ToShortDateString(), hFont));
                repDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                repDateCell.Colspan = 5;
                repDateCell.Border = Cell.NO_BORDER;
                hTable.AddCell(repDateCell);

                Cell sDateCell = new Cell(new Phrase("START DATE:" + statementviewModel.StartDate.ToShortDateString(), hFont));
                sDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                sDateCell.Colspan = 5;
                sDateCell.Border = Cell.NO_BORDER;
                hTable.AddCell(sDateCell);

                Cell EDateCell = new Cell(new Phrase("END DATE:" + statementviewModel.EndDate.ToShortDateString(), hFont));
                EDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                EDateCell.Colspan = 5;
                EDateCell.Border = Cell.NO_BORDER;
                hTable.AddCell(EDateCell);

                Cell nameCell = new Cell(new Phrase(statementviewModel.CustomerName, hFont));
                nameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                nameCell.Border = Cell.NO_BORDER;
                hTable.AddCell(nameCell);

                Cell billtoCell = new Cell(new Phrase("BILL TO", hFont));
                billtoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtoCell.Border = Cell.NO_BORDER;
                hTable.AddCell(billtoCell);

                Cell billtoNameCell = new Cell(new Phrase(statementviewModel.BillToName, hFont));
                billtoNameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtoNameCell.Colspan = 3;
                billtoNameCell.Border = Cell.NO_BORDER;
                hTable.AddCell(billtoNameCell);


                Cell addrCell = new Cell(new Phrase(statementviewModel.CustomerAddress, hFont));
                addrCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                addrCell.Border = Cell.NO_BORDER;
                hTable.AddCell(addrCell);

                Cell nilCell = new Cell(new Phrase("", hFont));
                addrCell.Border = Cell.NO_BORDER;
                hTable.AddCell(nilCell);

                Cell billtoAddrCell = new Cell(new Phrase(statementviewModel.BillToAddress, hFont));
                billtoAddrCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtoAddrCell.Colspan = 3;
                billtoAddrCell.Border = Cell.NO_BORDER;
                hTable.AddCell(billtoAddrCell);

                Cell phoneCell = new Cell(new Phrase(statementviewModel.CustomerTelephone, hFont));
                phoneCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                phoneCell.Border = Cell.NO_BORDER;
                hTable.AddCell(phoneCell);

                Cell nil2Cell = new Cell(new Phrase("", hFont));
                addrCell.Border = Cell.NO_BORDER;
                hTable.AddCell(nil2Cell);

                Cell billtophoneCell = new Cell(new Phrase(statementviewModel.BillToTelephone, hFont));
                billtophoneCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                billtophoneCell.Colspan = 3;
                billtophoneCell.Border = Cell.NO_BORDER;
                hTable.AddCell(billtophoneCell);

                Cell emailCell = new Cell(new Phrase(statementviewModel.CustomerEmail, hFont));
                emailCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                emailCell.Border = Cell.NO_BORDER;
                hTable.AddCell(emailCell);

                Cell nil3Cell = new Cell(new Phrase("", hFont));
                addrCell.Border = Cell.NO_BORDER;
                hTable.AddCell(nil3Cell);

                //Cell billtoemailCell = new Cell(new Phrase(statementviewModel.BillToEmail, hFont2));
                //billtoemailCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                //billtoemailCell.Colspan = 3;
                //billtoemailCell.Border = Cell.NO_BORDER;
                //hTable.AddCell(billtoemailCell);

                document.Add(hTable);

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
                this.Message = ex.Message;
            }
        }

        //document body
        private void AddDocBody()
        {


            //Add table headers
            Table transactionstable = new Table(4);
            transactionstable.WidthPercentage = 100;
            transactionstable.Spacing = 1;
            transactionstable.Padding = 1;

            AddTableHeaders(transactionstable);

            //Add table details  
            foreach (var d in statementviewModel.StatementTransactions)
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
            Cell dateCell = new Cell(new Phrase("DATE", thFont));
            dateCell.Border = Cell.RECTANGLE;
            dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            dateCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(dateCell);

            Cell desCell = new Cell(new Phrase("DESCRIPTION", thFont));
            desCell.Border = Cell.RECTANGLE;
            desCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            desCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(desCell);

            Cell amtCell = new Cell(new Phrase("AMOUNT", thFont));
            amtCell.Border = Cell.RECTANGLE;
            amtCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            amtCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(amtCell);

            Cell balCell = new Cell(new Phrase("BALANCE", thFont));
            balCell.Border = Cell.RECTANGLE;
            balCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            balCell.BackgroundColor = Color.CYAN;
            transactionstable.AddCell(balCell);

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

        }

        //table totals
        private void AddTableTotals()
        {
            Table totalsTable = new Table(6);
            totalsTable.WidthPercentage = 100;
            totalsTable.Spacing = 1;
            totalsTable.Padding = 1;

            // Put table headers
            Cell currCell = new Cell(new Phrase("CURRENT", thFont));
            currCell.Border = Cell.RECTANGLE;
            currCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            currCell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(currCell);

            Cell p130Cell = new Cell(new Phrase("1-30 DAYS PAST DUE", thFont));
            p130Cell.Border = Cell.RECTANGLE;
            p130Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p130Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(p130Cell);

            Cell p3060Cell = new Cell(new Phrase("31-60 DAYS PAST DUE", thFont));
            p3060Cell.Border = Cell.RECTANGLE;
            p3060Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p3060Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(p3060Cell);

            Cell p6090Cell = new Cell(new Phrase("61-90 DAYS PAST DUE", thFont));
            p6090Cell.Border = Cell.RECTANGLE;
            p6090Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p6090Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(p6090Cell);

            Cell over90Cell = new Cell(new Phrase("Over 90 DAYS PAST DUE", thFont));
            over90Cell.Border = Cell.RECTANGLE;
            over90Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            over90Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(over90Cell);

            Cell dueCell = new Cell(new Phrase("AMOUNT DUE", thFont));
            dueCell.Border = Cell.RECTANGLE;
            dueCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            dueCell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(dueCell);

            //Put data

            Cell curramtCell = new Cell(new Phrase(statementviewModel.CurrentBalance.ToString("#,##0"), tdFont));
            curramtCell.Border = Cell.RECTANGLE;
            curramtCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(curramtCell);

            Cell amt130Cell = new Cell(new Phrase(statementviewModel.Bal30.ToString("#,##0"), tdFont));
            amt130Cell.Border = Cell.RECTANGLE;
            amt130Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amt130Cell);

            Cell amt3060Cell = new Cell(new Phrase(statementviewModel.Bal60.ToString("#,##0"), tdFont));
            amt3060Cell.Border = Cell.RECTANGLE;
            amt3060Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amt3060Cell);

            Cell amt6090Cell = new Cell(new Phrase(statementviewModel.Bal90.ToString("#,##0"), tdFont));
            amt6090Cell.Border = Cell.RECTANGLE;
            amt6090Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amt6090Cell);

            Cell amtover90Cell = new Cell(new Phrase(statementviewModel.BalOver90.ToString("#,##0"), tdFont));
            amtover90Cell.Border = Cell.RECTANGLE;
            amtover90Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amtover90Cell);

            Cell amtdueCell = new Cell(new Phrase(statementviewModel.CurrentBalance.ToString("#,##0"), tdFont));
            amtdueCell.Border = Cell.RECTANGLE;
            amtdueCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amtdueCell);

            //Add remittance area

            Cell nilCell = new Cell(new Phrase("", thFont));
            nilCell.Border = Cell.RECTANGLE;
            nilCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            nilCell.Colspan = 3;
            totalsTable.AddCell(nilCell);

            Cell remitCell = new Cell(new Phrase("REMITTANCE", thFont));
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

            Cell totaldrCell = new Cell(new Phrase(statementviewModel.TotalDebits.ToString("#,##0"), tdFont));
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

            Cell totalcrCell = new Cell(new Phrase(statementviewModel.TotalCredits.ToString("#,##0"), tdFont));
            totalcrCell.Border = Cell.RECTANGLE;
            totalcrCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(totalcrCell);


            document.Add(totalsTable);
        }

        //document footer
        private void AddDocFooter()
        {



        }

    }
}

