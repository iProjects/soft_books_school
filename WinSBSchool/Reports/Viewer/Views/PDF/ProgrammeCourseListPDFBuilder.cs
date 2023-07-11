
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GL.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WinSchool.Reports.ViewModels;


namespace WinSchool.Reports.PDFBuilders
{
    public class ProgrammeCourseListPDFBuilder
    {
        string sFilePDF;
        ProgrammeCourseListViewModel programmecourselistviewmodel;
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


        public ProgrammeCourseListPDFBuilder(ProgrammeCourseListViewModel _programmecourselistviewmodel, string FileName)
        {
            programmecourselistviewmodel = _programmecourselistviewmodel;
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

            Cell RCell = new Cell(new Phrase("Course List For:", hFont1));
            RCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            RCell.Colspan = 2;
            RCell.Border = Cell.NO_BORDER;
            hTable.AddCell(RCell);


            Cell PDCell = new Cell(new Phrase("Printed on: " + programmecourselistviewmodel.printedon.ToString("dd-dddd-MMMM-yyyy"), hFont2));
            PDCell.HorizontalAlignment = Cell.ALIGN_CENTER;
            PDCell.Colspan = 2;
            PDCell.Border = Cell.NO_BORDER;
            hTable.AddCell(PDCell);


            document.Add(hTable);

        }

        //document body
        private void AddDocBody()
        {
            //Add document table headers 
            AddDocTableHeaders();

            //Add document table details  
            foreach (var d in programmecourselistviewmodel.ListofProgrammeCourses)
            {
                AddDocTableDetails(d);
            }

             
        }

        //document table headers 
        private void AddDocTableHeaders()
        {
            Table programmecoursestable = new Table(2);
            programmecoursestable.WidthPercentage = 100;
            programmecoursestable.Spacing = 1;
            programmecoursestable.Padding = 1;

            Cell CellYear = new Cell(new Phrase("Year:", tHfont1));
            CellYear.Border = Cell.RECTANGLE;
            CellYear.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellYear);

            Cell CellTerm = new Cell(new Phrase("Term:", tHfont1));
            CellTerm.Border = Cell.RECTANGLE;
            CellTerm.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellTerm);

            document.Add(programmecoursestable);

        } 

        //document table details 
        private void AddDocTableDetails(ProgrammeCourseList pc)
        {

            //Add table headers
            AddTableHeaders();

            foreach (var programcourse in pc.ListofSubjectCourses)
            {
                AddTableDetails(programcourse);
            }

        }

        //table headers
        private void AddTableHeaders()
        {
            Table programmecoursestable = new Table(4);
            programmecoursestable.WidthPercentage = 100;
            programmecoursestable.Spacing = 1;
            programmecoursestable.Padding = 1;
             
            Cell CellCourseCode = new Cell(new Phrase("Course Code", tHfont1));
            CellCourseCode.Border = Cell.RECTANGLE;
            CellCourseCode.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellCourseCode);

            Cell CellDescription = new Cell(new Phrase("Description", tHfont1));
            CellDescription.Border = Cell.RECTANGLE;
            CellDescription.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellDescription);

            Cell CellOutOf = new Cell(new Phrase("Out Of", tHfont1));
            CellOutOf.Border = Cell.RECTANGLE;
            CellOutOf.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellOutOf);

            Cell CellPassMark = new Cell(new Phrase("Pass Mark", tHfont1));
            CellPassMark.Border = Cell.RECTANGLE;
            CellPassMark.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellPassMark);
             
            document.Add(programmecoursestable);

        }

        //table details 
        private void AddTableDetails(SubjectCourses sc)
        {
            Table programmecoursestable = new Table(4);
            programmecoursestable.WidthPercentage = 100;
            programmecoursestable.Spacing = 1;
            programmecoursestable.Padding = 1;

            Cell CellCourseCode = new Cell(new Phrase(sc.CourseCode, tHfont1));
            CellCourseCode.Border = Cell.RECTANGLE;
            CellCourseCode.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellCourseCode);

            Cell CellDescription = new Cell(new Phrase(sc.Description, tHfont1));
            CellDescription.Border = Cell.RECTANGLE;
            CellDescription.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellDescription);

            Cell CellOutOf = new Cell(new Phrase(sc.OutOf.ToString(), tHfont1));
            CellOutOf.Border = Cell.RECTANGLE;
            CellOutOf.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellOutOf);

            Cell CellPassMark = new Cell(new Phrase(sc.PassMark.ToString(), tHfont1));
            CellPassMark.Border = Cell.RECTANGLE;
            CellPassMark.HorizontalAlignment = Cell.ALIGN_CENTER;
            programmecoursestable.AddCell(CellPassMark);

            document.Add(programmecoursestable);

        }
 

        //document footer
        private void AddDocFooter()
        {

            Table programmecoursestable = new Table(1);
            programmecoursestable.WidthPercentage = 100;
            programmecoursestable.Border = Table.NO_BORDER;


            Cell sgCell = new Cell(new Phrase("Signature.....................................................................................................", rms10Normal));
            sgCell.HorizontalAlignment = Cell.ALIGN_LEFT;
            sgCell.Border = Cell.NO_BORDER;
            programmecoursestable.AddCell(sgCell);


            document.Add(programmecoursestable);

        }



    }
}