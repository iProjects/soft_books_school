using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WinSchool.Reports.Viewer;
using WinSchool.Reports.ViewModels;

namespace WinSchool.Reports.Views.Excel
{
    public class SecMarkSheetExcelBuilder
    {

        MarkSheetViewModel _ViewModel;
        string Message;
        List<SelectedFontsDTO> _SelectedFontsList;
        List<string> Subjects;
        CreateExcelDoc document; 
        string sFileExcel;
        

        //constructor
        public SecMarkSheetExcelBuilder(MarkSheetViewModel _MarkSheetViewModel, List<string> _Subjects, List<SelectedFontsDTO> _SelectedFonts, string FileName)
        {
            if (_MarkSheetViewModel == null)
                throw new ArgumentNullException("MarkSheetViewModel is invalid");
            _ViewModel = _MarkSheetViewModel;

            if (_Subjects == null)
                throw new ArgumentNullException("Subjects List is invalid");
            Subjects = _Subjects;

            if (_SelectedFonts == null)
                throw new ArgumentNullException("Fonts are  invalid");
            _SelectedFontsList = _SelectedFonts;
            //SetDocFonts(_SelectedFontsList);
            sFileExcel = FileName;
        }

        public string GetExcel()
        {
            BuildadvancesheduleExcel();
            document.Save(sFileExcel);
            return sFileExcel;
        }

        /*Build the document **/
        private void BuildadvancesheduleExcel()
        {
            // step 1: creation of a document-object
            document = new CreateExcelDoc();
            try
            {
                //Add  Header 
                int row = 1; int col = 1;
                AddDocHeader(ref row, ref col);

                //Add  Body
                AddDocBody(ref row, ref col);

                //Add Footer
                AddDocFooter(ref row, ref col);

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

        /*Build the document**/
        private void AddDocHeader(ref int row, ref int col)
        {
            //createHeaders(int row, int col, string htext, string cell1, string cell2, int mergeColumns, string b, bool font, int size, string fcolor)

            //col = 2; row = 1;
            //string cellrangeaddr1 = document.IntAlpha(col) + row;
            //document.createHeaders(row, col, _advancereport.employername, cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            //row++;
            //cellrangeaddr1 = document.IntAlpha(col) + row;
            //document.createHeaders(row, col, _advancereport.employeraddress, cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            //row++;
            //cellrangeaddr1 = document.IntAlpha(col) + row;
            //document.createHeaders(row, col, "ADVANCE", cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");        

            //row++;
            //cellrangeaddr1 = document.IntAlpha(col) + row;
            //document.createHeaders(row, col, _advancereport.ReportName, cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            //row++;
            //cellrangeaddr1 = document.IntAlpha(col) + row;
            //document.createHeaders(row, col, "Printed on: " + _advancereport.printedon.ToString("dd-dddd-MMMM-yyyy"), cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            
        }

        private void AddDocBody(ref int row, ref int col)
        {
            //Add table headers
            AddBodytableHeaders(ref  row, ref  col);

            //Add table detail
            //foreach (var d in _advancereport.EmployeAadvanceList)
            //{
            //    AddBodyTableDetail(d, ref  row, ref  col);

            //}

            //Add table footer
            AddDocBodyTableTotals(ref  row, ref  col);

        }

        //table headers
        private void AddBodytableHeaders(ref int row, ref int col)
        {
            //row 1
            row = row + 2; col = 1;
            string cellrangeaddr1 = document.IntAlpha(col) + row;
            document.createHeaders(row, col, "EMPLOYEE NO", cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            col++;
            cellrangeaddr1 = document.IntAlpha(col) + row;
            document.createHeaders(row, col, "EMPLOYEE NAME", cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            col++;
            cellrangeaddr1 = document.IntAlpha(col) + row;
            document.createHeaders(row, col, "AMOUNT", cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            //col++;
            //cellrangeaddr1 = document.IntAlpha(col) + row;
            //document.createHeaders(row, col, "DATE", cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");
            
            
        }

        //table details
        //private void AddBodyTableDetail(advance   adv, ref int row, ref int col)
        //{

        //    row++; col = 1;
        //    string cellrangeaddr1 = document.IntAlpha(col) + row;
        //    document.createHeaders(row, col, adv.employeeno.ToString().Trim() , cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

        //    col++;
        //    cellrangeaddr1 = document.IntAlpha(col) + row;
        //    document.createHeaders(row, col, adv.employeename.ToString().Trim().ToUpper() , cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

        //    col++;
        //    cellrangeaddr1 = document.IntAlpha(col) + row;
        //    document.createHeaders(row, col, adv.advanceamount.ToString("C2"), cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

        //    //col++;
        //    //cellrangeaddr1 = document.IntAlpha(col) + row;
        //    //document.createHeaders(row, col,  adv.dateposted.ToString("dd-MMM-yyyy"), cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");
           

        //}

        //table footer
        private void AddDocBodyTableTotals(ref int row, ref int col)
        {
            row++; col = 1;
            string cellrangeaddr1 = document.IntAlpha(col) + row;
            document.createHeaders(row, col, "TOTALS", cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            col++;
            cellrangeaddr1 = document.IntAlpha(col) + row;
            document.createHeaders(row, col,"", cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

            //col++;
            //cellrangeaddr1 = document.IntAlpha(col) + row;
            //document.createHeaders(row, col, _advancereport.totaladvance.ToString("C2"), cellrangeaddr1, cellrangeaddr1, 0, "YELLOW", true, 10, "n");

        }

        //document footer
        private void AddDocFooter(ref int row, ref int col)
        {
           
           
        }


    }
}

