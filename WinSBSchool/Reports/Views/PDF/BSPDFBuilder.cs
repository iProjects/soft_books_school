using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GL.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VVX;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms;

namespace WinSBSchool.Reports.Views.PDF
{
    public class BSPDFBuilder
    {
        string sFilePDF;
        BalanceSheetViewModel _ViewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE HEADER

        public BSPDFBuilder(BalanceSheetViewModel _BalanceSheetViewModel, string FileName)
        {
            _ViewModel = _BalanceSheetViewModel;
            if (_BalanceSheetViewModel == null)
                throw new ArgumentNullException("_BalanceSheetViewModel is null");

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
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
            finally
            {
                if (document.IsOpen()) document.Close();
            }

        }

        //document header
        private void AddDocHeader()
        {

            try
            {
                Table disciplinaryTable = new Table(5);
                disciplinaryTable.WidthPercentage = 100;
                disciplinaryTable.Padding = 1;
                disciplinaryTable.Spacing = 1;
                disciplinaryTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, hFont));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                disciplinaryTable.AddCell(SchoolNameCell);

                Cell reportnameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 15, Font.BOLD, Color.BLUE)));
                reportnameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportnameCell.Colspan = 4;
                reportnameCell.Border = Cell.NO_BORDER;
                disciplinaryTable.AddCell(reportnameCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;

                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
                disciplinaryTable.AddCell(logoCell);


                Cell reportdateCell = new Cell(new Phrase("Report Date:     " + _ViewModel.ReportDate.ToString("MMMM  dd, yyyy"), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                disciplinaryTable.AddCell(reportdateCell);

                document.Add(disciplinaryTable);

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
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }

        //document body
        private void AddDocBody()
        {

        }


        //document footer
        private void AddDocFooter()
        {



        }


    }
}