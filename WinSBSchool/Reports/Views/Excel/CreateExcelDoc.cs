using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace WinSBSchool.Reports.Views.Excel
{
   public  class CreateExcelDoc
    {
        private Microsoft.Office.Interop.Excel.Application appExcel = null;
        private Workbook workbook = null;
        private Worksheet worksheet = null;
        private Range workSheet_range = null;
        private Dictionary<int, string> alpha = new Dictionary<int, string>();

        private void Initialize()
        {
            alpha.Add(1, "A");
            alpha.Add(2, "B");
            alpha.Add(3, "C");
            alpha.Add(4, "D");
            alpha.Add(5, "E");
            alpha.Add(6, "F");
            alpha.Add(7, "G");
            alpha.Add(8, "H");
            alpha.Add(9, "I");
            alpha.Add(10, "J");
            alpha.Add(11, "K");
            alpha.Add(12, "L");
            alpha.Add(13, "M");
            alpha.Add(14, "N");
            alpha.Add(15, "O");
            alpha.Add(16, "P");
            alpha.Add(17, "Q");
            alpha.Add(18, "R");
            alpha.Add(19, "S");
            alpha.Add(20, "T");
            alpha.Add(21, "U");
            alpha.Add(22, "V");
            alpha.Add(23, "W");
            alpha.Add(24, "X");
            alpha.Add(25, "Y");
            alpha.Add(26, "Z");
        }

        public void Save(string filename)
        {
            //if (appExcel != null) appExcel.SaveWorkspace(filename);
            if (workbook != null) workbook.SaveAs(filename);
        }

        public CreateExcelDoc()
        {
            Initialize();
            createDoc();

        }
        public void createDoc()
        {
            try
            {


                appExcel = new Microsoft.Office.Interop.Excel.Application();
                appExcel.Visible = true;
                workbook = appExcel.Workbooks.Add(1);
                worksheet = (Worksheet)workbook.Sheets[1];

            }
            catch (Exception e)
            {
                MessageBox.Show("Error : "+ e.Message);
            }
            finally
            {

            }
        }

        public void createHeaders(int row, int col, string htext, string cell1, string cell2, int mergeColumns, string color, bool font, int size, string fcolor)
        {
            worksheet.Cells[row, col] = htext;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Merge(mergeColumns);
            switch (color)
            {
                case "YELLOW":
                    workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
                    break;
                case "GRAY":
                    workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                    break;
                case "GAINSBORO":
                    workSheet_range.Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();
                    break;
                case "Turquoise":
                    workSheet_range.Interior.Color = System.Drawing.Color.Turquoise.ToArgb();
                    break;
                case "PeachPuff":
                    workSheet_range.Interior.Color = System.Drawing.Color.PeachPuff.ToArgb();
                    break;
                default:
                    //  workSheet_range.Interior.Color = System.Drawing.Color..ToArgb();
                    break;

            }

            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.Font.Bold = font;
            workSheet_range.ColumnWidth = size;
            if (fcolor.Equals(""))
            {
                workSheet_range.Font.Color = System.Drawing.Color.White.ToArgb();
            }
            else
            {
                workSheet_range.Font.Color = System.Drawing.Color.Black.ToArgb();
            }

        }

        public void addData(int row, int col, string data, string cell1, string cell2, string format)
        {
            worksheet.Cells[row, col] = data;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            workSheet_range.NumberFormat = format;
        }


        public string IntAlpha(int i)
        {
            return alpha[i];
        }
    }



}
