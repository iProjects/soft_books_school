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
    public class GeneralLedgerPDFBuilder
    {
        string sFilePDF;
        GeneralLegderViewModel _ViewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER  

        public GeneralLedgerPDFBuilder(GeneralLegderViewModel _GLViewModel, string FileName)
        {
          
            if (_GLViewModel == null)
                throw new ArgumentNullException("GeneralLegderViewModel is null");
            _ViewModel = _GLViewModel;

            sFilePDF = FileName;
        }
        public string GetPDF()
        {
            BuildPDF();
            return sFilePDF;
        }
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
        private void AddDocHeader()
        {

            try
            {
                Table ProgrammeCoursesTable = new Table(5);
                ProgrammeCoursesTable.WidthPercentage = 100;
                ProgrammeCoursesTable.Padding = 1;
                ProgrammeCoursesTable.Spacing = 1;
                ProgrammeCoursesTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                ProgrammeCoursesTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                ProgrammeCoursesTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                ProgrammeCoursesTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                ProgrammeCoursesTable.AddCell(nullCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(_ViewModel.Logo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.Logo, thFont));
                ProgrammeCoursesTable.AddCell(logoCell);


                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                ProgrammeCoursesTable.AddCell(reportdateCell);

                document.Add(ProgrammeCoursesTable);

              }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void AddDocBody()
        {


            //Add table headers
            Table Accountstable = new Table(4);
            Accountstable.WidthPercentage = 100;
            Accountstable.Spacing = 1;
            Accountstable.Padding = 1;

            AddTableHeaders(Accountstable);

            //Add table details  
            foreach (var d in _ViewModel.AccountGroups)
            {
                AddAccountDetails(Accountstable, d);
            }

            document.Add(Accountstable);

            

        }
        private void AddTableHeaders(Table Accountstable)
        {
            Cell dateCell = new Cell(new Phrase("DATE", thFont));
            dateCell.Border = Cell.RECTANGLE;
            dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            dateCell.BackgroundColor = Color.CYAN;
            Accountstable.AddCell(dateCell);

            Cell desCell = new Cell(new Phrase("DESCRIPTION", thFont));
            desCell.Border = Cell.RECTANGLE;
            desCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            desCell.BackgroundColor = Color.CYAN;
            Accountstable.AddCell(desCell);

            Cell amtCell = new Cell(new Phrase("DEBIT", thFont));
            amtCell.Border = Cell.RECTANGLE;
            amtCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            amtCell.BackgroundColor = Color.CYAN;
            Accountstable.AddCell(amtCell);

            Cell balCell = new Cell(new Phrase("CREDIT", thFont));
            balCell.Border = Cell.RECTANGLE;
            balCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            balCell.BackgroundColor = Color.CYAN;
            Accountstable.AddCell(balCell);

        }
        private void AddAccountDetails(Table Accountstable, AccountGroup act)
        {

            //Cell dateCell = new Cell(new Phrase(act.PostDate.ToString("dd-MM-yyyy"), tdFont));
            //dateCell.Border = Cell.RECTANGLE;
            //dateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            //Accountstable.AddCell(dateCell);

            Cell desCell = new Cell(new Phrase(act.Description, tdFont));
            desCell.Border = Cell.RECTANGLE;
            desCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            Accountstable.AddCell(desCell);

            Cell amtCell = new Cell(new Phrase(act.Debits.ToString("#,##0"), tdFont));
            amtCell.Border = Cell.RECTANGLE;
            amtCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            Accountstable.AddCell(amtCell);

            Cell balCell = new Cell(new Phrase(act.Credits.ToString("#,##0"), tdFont));
            balCell.Border = Cell.RECTANGLE;
            balCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            Accountstable.AddCell(balCell);

        }
        private void AddTableTotals()
        {
            Table totalsTable = new Table(2);
            totalsTable.WidthPercentage = 100;
            totalsTable.Spacing = 1;
            totalsTable.Padding = 1;

            // Put table headers
            Cell currCell = new Cell(new Phrase("TOTAL DEBIT", thFont));
            currCell.Border = Cell.RECTANGLE;
            currCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            currCell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(currCell);

            Cell p130Cell = new Cell(new Phrase("TOTAL CREDIT", thFont));
            p130Cell.Border = Cell.RECTANGLE;
            p130Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            p130Cell.BackgroundColor = Color.CYAN;
            totalsTable.AddCell(p130Cell);

           

            //Put data

            Cell curramtCell = new Cell(new Phrase(_ViewModel.TotalDebits.ToString("#,##0"), tdFont));
            curramtCell.Border = Cell.RECTANGLE;
            curramtCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(curramtCell);

            Cell amt130Cell = new Cell(new Phrase(_ViewModel.TotalCredits.ToString("#,##0"), tdFont));
            amt130Cell.Border = Cell.RECTANGLE;
            amt130Cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(amt130Cell);

            document.Add(totalsTable);
        }

        //document footer
        private void AddDocFooter()
        {



        }
    }
}

