﻿using System;
using System.IO;
using System.Windows.Forms;
using CommonLib;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VVX;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.Views.PDF
{
    public class StudentArrearsAndReceivablesPDFBuilder
     {
        
        string sFilePDF;
        StudentArrearsAndReceivablesViewModel _ViewModel;
        string Message;
        Document document;


        //DEFINED fONTS
        Font hFont = new Font(Font.HELVETICA, 9, Font.NORMAL, Color.DARK_GRAY);//DOCUMENT HEADER 
        Font thFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);//TABLE BODY
        Font rms10Normal = new Font(Font.HELVETICA, 7, Font.NORMAL, Color.BLACK);//DOCUMENT FOOTER


        public StudentArrearsAndReceivablesPDFBuilder(StudentArrearsAndReceivablesViewModel _studentArrearsAndReceivablesViewModel, string FileName)
        { 
            if (_studentArrearsAndReceivablesViewModel == null)
                throw new ArgumentNullException("StudentArrearsAndReceivablesViewModel is null");
            _ViewModel = _studentArrearsAndReceivablesViewModel;

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
                Table studentarrearsTable = new Table(5);
                studentarrearsTable.WidthPercentage = 100;
                studentarrearsTable.Padding = 1;
                studentarrearsTable.Spacing = 1;
                studentarrearsTable.Border = Table.NO_BORDER;

                Cell SchoolNameCell = new Cell(new Phrase(_ViewModel.SchoolName, new Font(Font.TIMES_ROMAN, 15, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolNameCell.Colspan = 5;
                SchoolNameCell.Border = Cell.NO_BORDER;
                studentarrearsTable.AddCell(SchoolNameCell);

                Cell SchoolAddressCell = new Cell(new Phrase(_ViewModel.SchoolAddress, new Font(Font.TIMES_ROMAN, 9, Font.BOLD | Font.UNDERLINE, Color.BLUE)));
                SchoolAddressCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                SchoolAddressCell.Colspan = 5;
                SchoolAddressCell.Border = Cell.NO_BORDER;
                studentarrearsTable.AddCell(SchoolAddressCell);

                Cell reportNameCell = new Cell(new Phrase(_ViewModel.ReportName, new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                reportNameCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                reportNameCell.Colspan = 5;
                reportNameCell.Border = Cell.NO_BORDER;
                studentarrearsTable.AddCell(reportNameCell);

                Cell nullCell = new Cell(new Phrase("", new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLUE)));
                nullCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                nullCell.Colspan = 4;
                nullCell.Border = Cell.NO_BORDER;
                studentarrearsTable.AddCell(nullCell);

                PDFGen pdfgen = new PDFGen();
                Image imgCell = pdfgen.DoGetImageFile(_ViewModel.SchoolLogo);
                imgCell.Alignment = Image.ALIGN_MIDDLE;
                Cell logoCell = new Cell(imgCell);
                logoCell.HorizontalAlignment = Cell.ALIGN_RIGHT; 
                logoCell.Border = Cell.NO_BORDER;
                logoCell.Add(new Phrase(_ViewModel.SchoolSlogan, thFont));
                studentarrearsTable.AddCell(logoCell);

                Cell reportdateCell = new Cell(new Phrase("Print Date:     " + _ViewModel.ReportDate.ToShortDateString(), tdFont));
                reportdateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                reportdateCell.Border = Cell.NO_BORDER;
                reportdateCell.Colspan = 5;
                studentarrearsTable.AddCell(reportdateCell); 

                document.Add(studentarrearsTable);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
