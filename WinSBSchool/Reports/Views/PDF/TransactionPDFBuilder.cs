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
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.PDFBuilders
{
    public class TransactionPDFBuilder
    {
        string sFilePDF;
        TransactionViewModel _ViewModel;
        string Message;
        Document document;


        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER 

        public TransactionPDFBuilder(TransactionViewModel _transactionviewmodel, string FileName)
        {
            if (_transactionviewmodel == null)
                throw new ArgumentNullException("TransactionViewModel is invalid");
            _ViewModel = _transactionviewmodel;

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

            Table transactionsTable = new Table(2);
            transactionsTable.WidthPercentage = 100;
            transactionsTable.Padding = 1;
            transactionsTable.Spacing = 1;
            transactionsTable.Border = Table.NO_BORDER;

            Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
            SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            SchoolNameCell.Colspan = 5;
            SchoolNameCell.Border = Cell.NO_BORDER;
            transactionsTable.AddCell(SchoolNameCell);

            Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
            SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            SchoolAddressCell.Colspan = 5;
            SchoolAddressCell.Border = Cell.NO_BORDER;
            transactionsTable.AddCell(SchoolAddressCell);

            Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
            reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            reportNameCell.Colspan = 5;
            reportNameCell.Border = Cell.NO_BORDER;
            transactionsTable.AddCell(reportNameCell);

            Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
            nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            nullCell.Colspan = 4;
            nullCell.Border = Cell.NO_BORDER;
            transactionsTable.AddCell(nullCell);


            Cell PDCell = new Cell(new Phrase("Printed on: " + _ViewModel.printedon.ToShortDateString(), hFont));
            PDCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            PDCell.Colspan = 2;
            PDCell.Border = Cell.NO_BORDER;
            transactionsTable.AddCell(PDCell);


            document.Add(transactionsTable);

        }

        //document body
        private void AddDocBody()
        {

            //Add table headers
            AddTableHeaders();

            //Add table details  
            foreach (var d in _ViewModel.ListofTransactions)
            {
                AddTransactionDetails(d);
            }

            //Add table totals
            AddTableTotals();

        }

        //table headers
        private void AddTableHeaders()
        {
            Table advancetable = new Table(10);
            advancetable.WidthPercentage = 100;
            advancetable.Spacing = 1;
            advancetable.Padding = 1;


            Cell CellTransactionTypeID = new Cell(new Phrase("TransactionType ID", thFont));
            CellTransactionTypeID.Border = Cell.RECTANGLE;
            CellTransactionTypeID.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellTransactionTypeID);

            Cell CellAccountIDname = new Cell(new Phrase("Account ID", thFont));
            CellAccountIDname.Border = Cell.RECTANGLE;
            CellAccountIDname.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellAccountIDname);

            Cell CellAmount = new Cell(new Phrase("Amount", thFont));
            CellAmount.Border = Cell.RECTANGLE;
            CellAmount.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellAmount);
            Cell CellNarrative = new Cell(new Phrase("Narrative", thFont));
            CellNarrative.Border = Cell.RECTANGLE;
            CellNarrative.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellNarrative);

            Cell CellUserID = new Cell(new Phrase("User ID", thFont));
            CellUserID.Border = Cell.RECTANGLE;
            CellUserID.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellUserID);

            Cell CellAuthorizer = new Cell(new Phrase("Authorizer", thFont));
            CellAuthorizer.Border = Cell.RECTANGLE;
            CellAuthorizer.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellAuthorizer);

            Cell CellStatementFlag = new Cell(new Phrase("Statement Flag", thFont));
            CellStatementFlag.Border = Cell.RECTANGLE;
            CellStatementFlag.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellStatementFlag);

            Cell CellPostReceived = new Cell(new Phrase("Post Date", thFont));
            CellPostReceived.Border = Cell.RECTANGLE;
            CellPostReceived.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellPostReceived);

            Cell CellValuedate = new Cell(new Phrase("Value Date", thFont));
            CellValuedate.Border = Cell.RECTANGLE;
            CellValuedate.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellValuedate);
            Cell CellRecorddate = new Cell(new Phrase("Record Date", thFont));
            CellRecorddate.Border = Cell.RECTANGLE;
            CellRecorddate.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellRecorddate);



            document.Add(advancetable);

        }


        //table details 
        private void AddTransactionDetails(SchoolTransactionlist p)
        {

            foreach (var ti in p.TransactionList)
            {
                AddTableDetails(ti);
            }

        }

        //table details 
        private void AddTableDetails(STransaction t)
        {
            Table advancetable = new Table(10);
            advancetable.WidthPercentage = 100;
            advancetable.Spacing = 1;
            advancetable.Padding = 1;


            Cell Cellproductname = new Cell(new Phrase(t.TransactionTypeID, thFont));
            Cellproductname.Border = Cell.RECTANGLE;
            Cellproductname.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(Cellproductname);

            Cell CellQuantity = new Cell(new Phrase(t.AccountID, thFont));
            CellQuantity.Border = Cell.RECTANGLE;
            CellQuantity.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellQuantity);

            Cell CellSuppliername = new Cell(new Phrase(t.Amount.ToString(), thFont));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);

            Cell CellNarrativename = new Cell(new Phrase(t.Narrative, thFont));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);

            Cell CellUsername = new Cell(new Phrase(t.UserID, thFont));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);
            Cell CellAuthorizername = new Cell(new Phrase(t.Authorizer, thFont));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);
            Cell CellStatementFlagname = new Cell(new Phrase(t.StatementFlag, thFont));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);

            Cell CellPostDatename = new Cell(new Phrase("PostDate", thFont));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);
            Cell CellValueDatename = new Cell(new Phrase("ValueDate", thFont));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);
            Cell CellRecordDatename = new Cell(new Phrase("RecordDate", thFont));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);

            document.Add(advancetable);

        }

        //table totals
        private void AddTableTotals()
        {
            Table advancetable = new Table(10);
            advancetable.WidthPercentage = 100;
            advancetable.Spacing = 1;
            advancetable.Padding = 1;


            //Cell TotalAssets = new Cell(new Phrase("TOTAL", rms8Normal));
            //TotalAssets.HorizontalAlignment = Cell.ALIGN_RIGHT;
            //TotalAssets.Colspan = 2;
            //advancetable.AddCell(TotalAssets);

            //Cell totalamount = new Cell(new Phrase("TOTAL", rms8Normal));
            //totalamount.HorizontalAlignment = Cell.ALIGN_RIGHT;
            //advancetable.AddCell(totalamount);


            document.Add(advancetable);
        }

        //document footer
        private void AddDocFooter()
        {

            Table netsalaryinfotable = new Table(1);
            netsalaryinfotable.WidthPercentage = 100;
            netsalaryinfotable.Border = Table.NO_BORDER;


            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            netsalaryinfotable.AddCell(sgCell);


            document.Add(netsalaryinfotable);

        }

    }
}