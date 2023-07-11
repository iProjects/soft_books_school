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
using WinSchool.Reports.Viewer;
namespace WinSchool.Reports.Views.PDF
{
    public class GeneralLedgerPDFBuilder
    {
        string sFilePDF;
        GeneralLegderViewModel _ViewModel;
        string Message;
        Document document;
        List<SelectedFontsDTO> _SelectedFontsList;
        List<string> Subjects;

        public GeneralLedgerPDFBuilder(GeneralLegderViewModel _GeneralLegderViewModel, List<string> _Subjects, List<SelectedFontsDTO> _SelectedFonts, string FileName)
        {
            if (_GeneralLegderViewModel == null)
                throw new ArgumentNullException("GeneralLegderViewModel is invalid");
            _ViewModel = _GeneralLegderViewModel;

            if (_Subjects == null)
                throw new ArgumentNullException("Subjects List is invalid");
            Subjects = _Subjects;

            if (_SelectedFonts == null)
                throw new ArgumentNullException("Fonts are  invalid");
            _SelectedFontsList = _SelectedFonts;
            SetDocFonts(_SelectedFontsList);
            sFilePDF = FileName;
        }


        //DEFINED fONTS
        private void SetDocFonts(List<SelectedFontsDTO> SelectedFonts)
        {
            foreach (var f in SelectedFonts)
            {
                //                int j;
                //bool result = Int32.TryParse(f.FontSizeInPoints, out j);
                //if (true == result)     
                //    int j;
                //bool result = Int32.TryParse(f.FontSizeInPoints, out j);
                //if (true == result)     
                //                 Font htFont = new Font(j,
            }
        }
        Font htFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.DARK_GRAY);
        Font hFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.DARK_GRAY);
        Font thFont = new Font(Font.HELVETICA, 6, Font.BOLD, Color.BLUE);//TABLE HEADER
        Font tdFont = new Font(Font.HELVETICA, 6, Font.NORMAL, Color.BLACK);//TABLE HEADER

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

        }


        //document body
        private void AddDocBody()
        {
            

        }
        private void AddCollExamTableDetails(Table collrsTable, CollStudentMarkSheetRecord colltRec)
        {

        }

        private void AddExamTableHeaders(Table collrsTable)
        {
            
        }

        //document footer
        private void AddDocFooter()
        {


        }

    }
}


