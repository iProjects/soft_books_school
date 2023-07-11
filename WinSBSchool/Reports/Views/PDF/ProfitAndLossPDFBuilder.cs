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
   public class ProfitAndLossPDFBuilder
     { 
        ProfitAndLossViewModel _ViewModel;
        string Message;
        Document document;
        string sFilePDF;
        string connection;
        SBSchoolDBEntities db;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font tdFont1 = new Font(Font.HELVETICA, 8, Font.BOLD, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER


        public ProfitAndLossPDFBuilder(ProfitAndLossViewModel _ProfitAndLossViewModel, string FileName, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn is null");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);

            if (_ProfitAndLossViewModel == null)
                throw new ArgumentNullException("ProfitAndLossViewModel is null");
            _ViewModel = _ProfitAndLossViewModel;

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
                Table profitAndLossTable = new Table(5);
                profitAndLossTable.WidthPercentage = 100;
                profitAndLossTable.Padding = 1;
                profitAndLossTable.Spacing = 1;
                profitAndLossTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                profitAndLossTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                profitAndLossTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                profitAndLossTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                profitAndLossTable.AddCell(nullCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(img0);
                logoCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                profitAndLossTable.AddCell(logoCell);

                Cell reportDateCell = new Cell(new Phrase("Print Date :  " + _ViewModel.ReportDate.ToShortDateString(), hFont));
                reportDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportDateCell.Colspan = 5;
                reportDateCell.Border = Cell.NO_BORDER;
                profitAndLossTable.AddCell(reportDateCell);

                document.Add(profitAndLossTable);

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
                foreach (var r in _ViewModel._ProfitAndLoss)
                {
                    AddDocTableBody(r);
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void AddDocTableBody(ProfitAndLossDTO blcsht)
        {
            try
            {
                Table profitAndLossTable = new Table(3);
                profitAndLossTable.WidthPercentage = 100;
                profitAndLossTable.Padding = 1;
                profitAndLossTable.Spacing = 1;

                var plquery = (from pl1 in db.PL_Level1
                                   where pl1.Id == blcsht.GroupId
                                   select pl1).FirstOrDefault();
                PL_Level1 plv1 = plquery;

                Cell DescriptionCell = new Cell(new Phrase(plv1.Description, thFont));
                DescriptionCell.Border = Cell.RECTANGLE;
                DescriptionCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                DescriptionCell.Colspan = 3;
                profitAndLossTable.AddCell(DescriptionCell);

                AddTableHeaders(profitAndLossTable);

                //Add table details  
                foreach (var r in blcsht.Level2ProfitAndLoss)
                {
                    AddTableDetails(profitAndLossTable, r);
                }  

                //Add table totals
                AddTableTotals(profitAndLossTable, blcsht);

                document.Add(profitAndLossTable);
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        //table headers
        private void AddTableHeaders(Table profitAndLossTable)
        {
            Cell DescriptionCell = new Cell(new Phrase("", thFont));
            DescriptionCell.Border = Cell.RECTANGLE;
            DescriptionCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            profitAndLossTable.AddCell(DescriptionCell);

            Cell Yr1AmountCell = new Cell(new Phrase("Year 1", thFont));
            Yr1AmountCell.Border = Cell.RECTANGLE;
            Yr1AmountCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            profitAndLossTable.AddCell(Yr1AmountCell);

            Cell Yr2AmountCell = new Cell(new Phrase("Year 2", thFont));
            Yr2AmountCell.Border = Cell.RECTANGLE;
            Yr2AmountCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            profitAndLossTable.AddCell(Yr2AmountCell);
        }

        //table details 
        private void AddTableDetails(Table profitAndLossTable, ProfitAndLossLevel2 blcsht)
        {
            try
            {
                Cell DescriptionCell = new Cell(new Phrase(blcsht.Description, tdFont));
                DescriptionCell.Border = Cell.RECTANGLE;
                DescriptionCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                profitAndLossTable.AddCell(DescriptionCell);

                Cell Yr1AmountCell = new Cell(new Phrase(blcsht.Yr1Amount.ToString(), tdFont));
                Yr1AmountCell.Border = Cell.RECTANGLE;
                Yr1AmountCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                profitAndLossTable.AddCell(Yr1AmountCell);

                Cell Yr2AmountCell = new Cell(new Phrase(blcsht.Yr2Amount.ToString(), tdFont));
                Yr2AmountCell.Border = Cell.RECTANGLE;
                Yr2AmountCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                profitAndLossTable.AddCell(Yr2AmountCell);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void AddTableTotals(Table profitAndLossTable, ProfitAndLossDTO pldto)
        { 

            Cell DescriptionCell = new Cell(new Phrase("Total", tdFont1));
            DescriptionCell.Border = Cell.RECTANGLE;
            DescriptionCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            profitAndLossTable.AddCell(DescriptionCell);

            Cell Yr1AmountCell = new Cell(new Phrase(pldto.TotalY1.ToString(), tdFont));
            Yr1AmountCell.Border = Cell.RECTANGLE;
            Yr1AmountCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            profitAndLossTable.AddCell(Yr1AmountCell);

            Cell Yr2AmountCell = new Cell(new Phrase(pldto.TotalY2.ToString(), tdFont));
            Yr2AmountCell.Border = Cell.RECTANGLE;
            Yr2AmountCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            profitAndLossTable.AddCell(Yr2AmountCell); 
             
        }

        //document footer
        private void AddDocFooter()
        {

            Table profitAndLossTable = new Table(1);
            profitAndLossTable.WidthPercentage = 100;
            profitAndLossTable.Border = Table.NO_BORDER;

            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            profitAndLossTable.AddCell(sgCell);

            document.Add(profitAndLossTable);

        }

     }
}