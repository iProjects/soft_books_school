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

namespace WinSchool.Reports.Views.PDF
{
    public class ReportFormPDFBuilder
    {
        string sFilePDF;
        ReportFormViewModel reportFormviewModel;
        string Message;
        Document document;

        //DEFINED fONTS
        Font hFont2 = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.DARK_GRAY);

        Font tHfont1 = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLUE);//TABLE HEADER


        public ReportFormPDFBuilder(ReportFormViewModel _reportFormviewModel, string FileName)
        {
            reportFormviewModel = _reportFormviewModel;
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

                Cell RCell = new Cell(new Phrase(reportFormviewModel.ReportFormName, new Font(Font.HELVETICA, 32, Font.BOLD, Color.BLUE)));
                RCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                RCell.Colspan = 4;
                RCell.Border = Cell.NO_BORDER;
                hTable.AddCell(RCell);

                //create the logo
                PDFGen pdfgen = new PDFGen();
                Image img0 = pdfgen.DoGetImageFile(reportFormviewModel.Logo);
                img0.Alignment = Image.ALIGN_MIDDLE;
                Cell Logcell = new Cell(img0);
                Logcell.HorizontalAlignment = Cell.ALIGN_LEFT;
                //Logcell.Rowspan = 2;
                Logcell.Border = Cell.NO_BORDER;
                Logcell.Add(new Phrase(reportFormviewModel.CompanySlogan, new Font(Font.HELVETICA, 8, Font.ITALIC, Color.BLACK)));
                hTable.AddCell(Logcell);
                //

                Cell repDateCell = new Cell(new Phrase("REPORT DATE:" + reportFormviewModel.ReportDate.ToShortDateString(), hFont2));
                repDateCell.HorizontalAlignment = Cell.ALIGN_LEFT;
                repDateCell.Colspan = 5;
                repDateCell.Border = Cell.NO_BORDER;
                hTable.AddCell(repDateCell);

                Cell stdCell = new Cell(new Phrase("STUDENT CODE:" + reportFormviewModel.StudentAdminNo, hFont2));
                stdCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                stdCell.Colspan = 5;
                stdCell.Border = Cell.NO_BORDER;
                hTable.AddCell(stdCell);

                Cell stdnmCell = new Cell(new Phrase("STUDENT NAME:" + reportFormviewModel.StudentName, hFont2));
                stdnmCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                stdnmCell.Colspan = 5;
                stdnmCell.Border = Cell.NO_BORDER;
                hTable.AddCell(stdnmCell);


                Cell ClassCell = new Cell(new Phrase("CLASS:" + reportFormviewModel.Class, hFont2));
                ClassCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                ClassCell.Colspan = 5;
                ClassCell.Border = Cell.NO_BORDER;
                hTable.AddCell(ClassCell);


                Cell YearCell = new Cell(new Phrase("YEAR:" + reportFormviewModel.Year.ToString(), hFont2));
                YearCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                YearCell.Colspan = 5;
                YearCell.Border = Cell.NO_BORDER;
                hTable.AddCell(YearCell);

                Cell TermCell = new Cell(new Phrase("TERM:" + reportFormviewModel.Class.ToString(), hFont2));
                TermCell.HorizontalAlignment = Cell.ALIGN_CENTER;
                TermCell.Colspan = 5;
                TermCell.Border = Cell.NO_BORDER;
                hTable.AddCell(TermCell);


                document.Add(hTable);


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
            Table studenttable = new Table(4);
            studenttable.WidthPercentage = 100;
            studenttable.Spacing = 1;
            studenttable.Padding = 1;

            AddTableHeaders(studenttable);


            //Add table headers
            Table resultstable = new Table(5);
            resultstable.WidthPercentage = 100;
            resultstable.Spacing = 1;
            resultstable.Padding = 1;

            AddTableHeaders(resultstable);

            //Add table details  
            foreach (var r in reportFormviewModel.StudentExamResults)
            {
                AddReportFormDetails(resultstable, r);
            }

            document.Add(resultstable);

            //Add table totals
            AddTableTotals();

        }

        //table headers
        private void AddTableHeaders(Table resultstable)
        {
            Cell dateCell = new Cell(new Phrase("SUBJECT CODE", tHfont1));
            dateCell.Border = Cell.RECTANGLE;
            dateCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            dateCell.BackgroundColor = Color.CYAN;
            resultstable.AddCell(dateCell);

            Cell desCell = new Cell(new Phrase("DESCRIPTION", tHfont1));
            desCell.Border = Cell.RECTANGLE;
            desCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            desCell.BackgroundColor = Color.CYAN;
            resultstable.AddCell(desCell);

            Cell markCell = new Cell(new Phrase("MARK", tHfont1));
            markCell.Border = Cell.RECTANGLE;
            markCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            markCell.BackgroundColor = Color.CYAN;
            resultstable.AddCell(markCell);

            Cell outofCell = new Cell(new Phrase("OUT OF", tHfont1));
            outofCell.Border = Cell.RECTANGLE;
            outofCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            outofCell.BackgroundColor = Color.CYAN;
            resultstable.AddCell(outofCell);

            Cell gradeCell = new Cell(new Phrase("GRADE", tHfont1));
            gradeCell.Border = Cell.RECTANGLE;
            gradeCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            gradeCell.BackgroundColor = Color.CYAN;
            resultstable.AddCell(gradeCell);

        }


        //table details 
        private void AddReportFormDetails(Table resultstable, SubjectExamResult n)
        {

             Cell subCell = new Cell(new Phrase(n.SubjectCode, tdFont));
            subCell.Border = Cell.RECTANGLE;
            subCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            resultstable.AddCell(subCell);

            Cell descCell = new Cell(new Phrase(n.Description, tdFont));
            descCell.Border = Cell.RECTANGLE;
            descCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            resultstable.AddCell(descCell);

            Cell mkCell = new Cell(new Phrase(n.Mark.ToString(), tdFont));
            mkCell.Border = Cell.RECTANGLE;
            mkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            resultstable.AddCell(mkCell);

            Cell otfCell = new Cell(new Phrase(n.OutOf.ToString(), tdFont));
            otfCell.Border = Cell.RECTANGLE;
            otfCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            resultstable.AddCell(otfCell);

            Cell grdCell = new Cell(new Phrase(n.Grade, tdFont));
            grdCell.Border = Cell.RECTANGLE;
            grdCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            resultstable.AddCell(grdCell);

        }

        //table totals
        private void AddTableTotals()
        {
            Table totalsTable = new Table(6,3);
            totalsTable.WidthPercentage = 100;
            totalsTable.Spacing = 1;
            totalsTable.Padding = 1;

            // Put table headers -> Row 1

            Cell totlmarkCell = new Cell(new Phrase("Total Marks", tdFont));
            totlmarkCell.Border = Cell.RECTANGLE;
            totlmarkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            //totlmarkCell.Rowspan = 2;
            totalsTable.AddCell(totlmarkCell);

            Cell avergemrkCell = new Cell(new Phrase("Average Marks", tdFont));
            avergemrkCell.Border = Cell.RECTANGLE;
            avergemrkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            //avergemrkCell.Rowspan = 2;
            totalsTable.AddCell(avergemrkCell);

            Cell currntgrdCell = new Cell(new Phrase("Previous Periods Mean Grade", tHfont1));
            currntgrdCell.Border = Cell.RECTANGLE;
            currntgrdCell.Colspan = 4;
            currntgrdCell.BackgroundColor = Color.CYAN;
            currntgrdCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            totalsTable.AddCell(currntgrdCell);


            //Put data - > Row 2

            Cell nilcell = new Cell(new Phrase("", tdFont));
            nilcell.Border = Cell.RECTANGLE;
            nilcell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(nilcell);

            Cell nil2cell = new Cell(new Phrase("", tdFont));
            nil2cell.Border = Cell.RECTANGLE;
            nil2cell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(nil2cell);

            Cell currentCell = new Cell(new Phrase("Current", tdFont));
            currentCell.Border = Cell.RECTANGLE;
            currentCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(currentCell);

            Cell term1textCell = new Cell(new Phrase("Term1", tdFont));
            term1textCell.Border = Cell.RECTANGLE;
            term1textCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(term1textCell);

            Cell term2textCell = new Cell(new Phrase("Term2", tdFont));
            term2textCell.Border = Cell.RECTANGLE;
            term2textCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(term2textCell);

            Cell term3textCell = new Cell(new Phrase("Term3", tdFont));
            term3textCell.Border = Cell.RECTANGLE;
            term3textCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(term3textCell);

            Cell totalmrkCell = new Cell(new Phrase(reportFormviewModel.TotalMarks.ToString(), tdFont));
            totalmrkCell.Border = Cell.RECTANGLE;
            totalmrkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(totalmrkCell);

            Cell avergmrkCell = new Cell(new Phrase(reportFormviewModel.AvgMarks.ToString(), tdFont));
            avergmrkCell.Border = Cell.RECTANGLE;
            avergmrkCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(avergmrkCell);

            Cell meangradeCell = new Cell(new Phrase(reportFormviewModel.CurrentMeanGrade, tdFont));
            meangradeCell.Border = Cell.RECTANGLE;
            meangradeCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(meangradeCell);

            Cell term1valCell = new Cell(new Phrase(reportFormviewModel.Term1MeanGrade, tdFont));
            term1valCell.Border = Cell.RECTANGLE;
            term1valCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(term1valCell);

            Cell term2valCell = new Cell(new Phrase(reportFormviewModel.Term2MeanGrade, tdFont));
            term2valCell.Border = Cell.RECTANGLE;
            term2valCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(term2valCell);

            Cell term3valCell = new Cell(new Phrase(reportFormviewModel.Term3MeanGrade, tdFont));
            term3valCell.Border = Cell.RECTANGLE;
            term3valCell.HorizontalAlignment = Cell.ALIGN_RIGHT;
            totalsTable.AddCell(term3valCell);



            ////Add Remarks area
            Cell nil4Cell = new Cell(new Phrase("\n\n\n", tHfont1));
            nil4Cell.Border = Cell.RECTANGLE;
            nil4Cell.HorizontalAlignment = Cell.ALIGN_LEFT;
            nil4Cell.Colspan = 6;
            totalsTable.AddCell(nil4Cell);

            Cell remitCell = new Cell(new Phrase("REMARKS:", tHfont1));
            remitCell.Border = Cell.RECTANGLE;
            remitCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            remitCell.Colspan = 6;
            totalsTable.AddCell(remitCell);

            Cell drCell = new Cell(new Phrase("SIGNED:", tdFont));
            drCell.Border = Cell.RECTANGLE;
            drCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            drCell.Colspan = 6;
            totalsTable.AddCell(drCell);

            

            document.Add(totalsTable);
        }

        //document footer
        private void AddDocFooter()
        {



        }

    }
}



