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
   public class TeacherPDFBuilder
    {
       string sFilePDF;
       TeacherViewModel teacherviewmodel;
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


        public TeacherPDFBuilder(TeacherViewModel _teacherviewmodel, string FileName)
        {
            teacherviewmodel = _teacherviewmodel;
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

            Cell RCell = new Cell(new Phrase("TEACHERS", hFont1));
            RCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            RCell.Colspan = 2;
            RCell.Border = Cell.NO_BORDER;
            hTable.AddCell(RCell);


            Cell PDCell = new Cell(new Phrase("Printed on: " + teacherviewmodel.printedon.ToString("dd-dddd-MMMM-yyyy"), hFont2));
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
            foreach (var d in teacherviewmodel.ListofTeachers)
            {
                AddTeacherDetails(d);
            }

            //Add table totals
            AddTableTotals();

        }

        //table headers
        private void AddTableHeaders()
        {
            Table advancetable = new Table(7);
            advancetable.WidthPercentage = 100;
            advancetable.Spacing = 1;
            advancetable.Padding = 1;


            Cell Cellproductname = new Cell(new Phrase("TEACHER NAME", tHfont1));
            Cellproductname.Border = Cell.RECTANGLE;
            Cellproductname.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(Cellproductname);

            Cell CellQuantity = new Cell(new Phrase("TSC NO", tHfont1));
            CellQuantity.Border = Cell.RECTANGLE;
            CellQuantity.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellQuantity);

            Cell CellSuppliername = new Cell(new Phrase("ID NO", tHfont1));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);

            Cell CellReceivedby = new Cell(new Phrase("POSITION", tHfont1));
            CellReceivedby.Border = Cell.RECTANGLE;
            CellReceivedby.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellReceivedby);

            Cell CellIssueNo = new Cell(new Phrase("STATUS", tHfont1));
            CellIssueNo.Border = Cell.RECTANGLE;
            CellIssueNo.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellIssueNo);

            Cell CellDateReceived = new Cell(new Phrase("DATE JOINED", tHfont1));
            CellDateReceived.Border = Cell.RECTANGLE;
            CellDateReceived.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellDateReceived);

            Cell CellManufacturedate = new Cell(new Phrase("DATE LEFT", tHfont1));
            CellManufacturedate.Border = Cell.RECTANGLE;
            CellManufacturedate.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellManufacturedate);

            document.Add(advancetable);

        }


        //table details 
        private void AddTeacherDetails(SchoolTeacherList p)
        {

            foreach (var ti in p.TeachersList)
            {
                AddTableDetails(ti);
            }

        }

        //table details 
        private void AddTableDetails(SchoolTeacher t)
        {
            Table advancetable = new Table(7);
            advancetable.WidthPercentage = 100;
            advancetable.Spacing = 1;
            advancetable.Padding = 1;


            Cell Cellproductname = new Cell(new Phrase(t.TeacherName, tHfont1));
            Cellproductname.Border = Cell.RECTANGLE;
            Cellproductname.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(Cellproductname);

            Cell CellQuantity = new Cell(new Phrase(t.TSCNo, tHfont1));
            CellQuantity.Border = Cell.RECTANGLE;
            CellQuantity.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellQuantity);

            Cell CellSuppliername = new Cell(new Phrase(t.IDNo, tHfont1));
            CellSuppliername.Border = Cell.RECTANGLE;
            CellSuppliername.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellSuppliername);

            Cell CellReceivedby = new Cell(new Phrase(t.Position, tHfont1));
            CellReceivedby.Border = Cell.RECTANGLE;
            CellReceivedby.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellReceivedby);

            Cell CellIssueNo = new Cell(new Phrase(t.Status.ToString(), tHfont1));
            CellIssueNo.Border = Cell.RECTANGLE;
            CellIssueNo.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellIssueNo);

            Cell CellDateReceived = new Cell(new Phrase(t.DateJoined.ToString("dd-dddd-MMMM-yyyy"), tHfont1));
            CellDateReceived.Border = Cell.RECTANGLE;
            CellDateReceived.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellDateReceived);

            Cell CellManufacturedate = new Cell(new Phrase(t.DateLeft.ToString("dd-dddd-MMMM-yyyy"), tHfont1));
            CellManufacturedate.Border = Cell.RECTANGLE;
            CellManufacturedate.HorizontalAlignment = Cell.ALIGN_CENTER;
            advancetable.AddCell(CellManufacturedate);

            document.Add(advancetable);

        }

        //table totals
        private void AddTableTotals()
        {
            Table advancetable = new Table(7);
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
