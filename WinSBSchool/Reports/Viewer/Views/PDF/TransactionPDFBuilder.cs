using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using WinSchool.Reports.ViewModels;
using GL.DAL;

namespace WinSchool.Reports.PDFBuilders
{
   public class TransactionPDFBuilder
    {
           string sFilePDF;
           TransactionViewModel transactionviewmodel;
           string Message;
           Document document;

           //DEFINED fONTS
           Font hFont1 = new Font(Font.TIMES_ROMAN, 12, Font.BOLD);
           Font hFont2 = new Font(Font.TIMES_ROMAN, 10, Font.BOLD);
           Font bfont1 = new Font(Font.TIMES_ROMAN, 8, Font.NORMAL);//BODY
           Font tHfont1 = new Font(Font.TIMES_ROMAN, 9, Font.BOLD);//TABLE HEADER
           Font tcFont = new Font(Font.HELVETICA, 10, Font.NORMAL);//table cell
           Font helv8font = new Font(Font.HELVETICA, 12, Font.NORMAL);//table cell
           Font rms6Normal = new Font(Font.TIMES_ROMAN, 8, Font.NORMAL);
           Font rms8Normal = new Font(Font.TIMES_ROMAN, 9, Font.BOLD);
           Font rms6Bold = new Font(Font.TIMES_ROMAN, 6, Font.BOLD);
           Font rms8Bold = new Font(Font.TIMES_ROMAN, 8, Font.BOLD);
           Font rms10Normal = new Font(Font.HELVETICA, 10, Font.NORMAL);


           public TransactionPDFBuilder(TransactionViewModel _transactionviewmodel, string FileName)
           {
               transactionviewmodel = _transactionviewmodel;
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
                   if (File.Exists(sFilePDF))
                   {
                       File.Delete(sFilePDF);
                   }

                   //step 1 creation of the document
                   document = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

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

               Table hTable = new Table(2);
               hTable.WidthPercentage = 100;
               hTable.Padding = 1;
               hTable.Spacing = 1;
               hTable.Border = Table.NO_BORDER;

               Cell RCell = new Cell(new Phrase("TRANSACTIONS", hFont1));
               RCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               RCell.Colspan = 2;
               RCell.Border = Cell.NO_BORDER;
               hTable.AddCell(RCell);


               Cell PDCell = new Cell(new Phrase("Printed on: " + transactionviewmodel.printedon.ToString("dd-dddd-MMMM-yyyy"), hFont2));
               PDCell.HorizontalAlignment = Cell.ALIGN_CENTER;
               PDCell.Colspan = 2;
               PDCell.Border = Cell.NO_BORDER;
               hTable.AddCell(PDCell);


               document.Add(hTable);

           }

           //document body
           private void AddDocBody()
           {

               //Add table headers
               AddTableHeaders();

               //Add table details  
               foreach (var d in transactionviewmodel.ListofTransactions)
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


               Cell CellTransactionTypeID = new Cell(new Phrase("TransactionType ID", tHfont1));
               CellTransactionTypeID.Border = Cell.RECTANGLE;
               CellTransactionTypeID.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellTransactionTypeID);

               Cell CellAccountIDname = new Cell(new Phrase("Account ID", tHfont1));
               CellAccountIDname.Border = Cell.RECTANGLE;
               CellAccountIDname.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellAccountIDname);

               Cell CellAmount = new Cell(new Phrase("Amount", tHfont1));
               CellAmount.Border = Cell.RECTANGLE;
               CellAmount.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellAmount);
               Cell CellNarrative = new Cell(new Phrase("Narrative", tHfont1));
               CellNarrative.Border = Cell.RECTANGLE;
               CellNarrative.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellNarrative);

               Cell CellUserID = new Cell(new Phrase("User ID", tHfont1));
               CellUserID.Border = Cell.RECTANGLE;
               CellUserID.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellUserID);

               Cell CellAuthorizer = new Cell(new Phrase("Authorizer", tHfont1));
               CellAuthorizer.Border = Cell.RECTANGLE;
               CellAuthorizer.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellAuthorizer);

               Cell CellStatementFlag = new Cell(new Phrase("Statement Flag", tHfont1));
               CellStatementFlag.Border = Cell.RECTANGLE;
               CellStatementFlag.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellStatementFlag);

               Cell CellPostReceived = new Cell(new Phrase("Post Date", tHfont1));
               CellPostReceived.Border = Cell.RECTANGLE;
               CellPostReceived.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellPostReceived);

               Cell CellValuedate = new Cell(new Phrase("Value Date", tHfont1));
               CellValuedate.Border = Cell.RECTANGLE;
               CellValuedate.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellValuedate);
               Cell CellRecorddate = new Cell(new Phrase("Record Date", tHfont1));
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


               Cell Cellproductname = new Cell(new Phrase(t.TransactionTypeID, tHfont1));
               Cellproductname.Border = Cell.RECTANGLE;
               Cellproductname.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(Cellproductname);

               Cell CellQuantity = new Cell(new Phrase(t.AccountID, tHfont1));
               CellQuantity.Border = Cell.RECTANGLE;
               CellQuantity.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellQuantity);

               Cell CellSuppliername = new Cell(new Phrase(t.Amount.ToString(), tHfont1));
               CellSuppliername.Border = Cell.RECTANGLE;
               CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellSuppliername);

               Cell CellNarrativename = new Cell(new Phrase(t.Narrative, tHfont1));
               CellSuppliername.Border = Cell.RECTANGLE;
               CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellSuppliername);

               Cell CellUsername = new Cell(new Phrase(t.UserID, tHfont1));
               CellSuppliername.Border = Cell.RECTANGLE;
               CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellSuppliername);
               Cell CellAuthorizername = new Cell(new Phrase(t.Authorizer, tHfont1));
               CellSuppliername.Border = Cell.RECTANGLE;
               CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellSuppliername);
               Cell CellStatementFlagname = new Cell(new Phrase(t.StatementFlag, tHfont1));
               CellSuppliername.Border = Cell.RECTANGLE;
               CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellSuppliername);

               Cell CellPostDatename = new Cell(new Phrase("PostDate", tHfont1));
               CellSuppliername.Border = Cell.RECTANGLE;
               CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellSuppliername);
               Cell CellValueDatename = new Cell(new Phrase("ValueDate", tHfont1));
               CellSuppliername.Border = Cell.RECTANGLE;
               CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
               advancetable.AddCell(CellSuppliername);
               Cell CellRecordDatename = new Cell(new Phrase("RecordDate", tHfont1));
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


               //Cell total = new Cell(new Phrase("TOTAL", rms8Normal));
               //total.HorizontalAlignment = Cell.ALIGN_RIGHT;
               //total.Colspan = 2;
               //advancetable.AddCell(total);

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
