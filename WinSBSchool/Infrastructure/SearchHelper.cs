using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace WinSBSchool.Infrastructure
{
    class SearchHelper
    {
        public static void Search(string labletext, string col, BindingSource bd)
        {
            // get a parameter.
            //ParamInputForm f = new ParamInputForm();
            //f.LableValue(labletext);
            //f.SetFocus();
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    //Find
            //    bd.Position  = bd.Find( col, f.GetParam());

            //    f.Dispose();
            //}
        } 
        public static void Filter(string fld, string col, string param, string type, BindingSource bd, List<DataGridViewColumn> cols)
        {
            string filter = "";
            switch (type.ToLower())
            {
                case "s":
                    //filter = col + "='" + param + "'";
                    filter = col + "LIKE '*" + param + "*'";
                    break;
            }
            //FilterForm f = new FilterForm(bd);
            //f.SetBinding(bd, filter, cols);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    //Find
            //    string val = f.GetSelectedItem(fld);
            //    bd.RemoveFilter();
            //    bd.Position = bd.Find(fld, val);
            //    f.Dispose();
            //}
            //else
            //{
            //    bd.RemoveFilter();
            //}
        } 
        public static void Filter(string ReturnField, BindingSource bd)
        {
            //FilterForm f = new FilterForm(bd);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    //Find
            //    string val = f.GetSelectedItem(ReturnField);
            //    bd.RemoveFilter();
            //    bd.Position = bd.Find(ReturnField, val);
            //    f.Dispose();
            //}
            //else
            //{
            //    bd.RemoveFilter();
            //}
        }
        public static void Filter(string ReturnField, string col, string param, string type, BindingSource bd)
        {
            string filter = "";
            switch (type.ToLower())
            {
                case "s":
                    filter = col + "='" + param + "'";
                    break;
            }
            //FilterForm f = new FilterForm(bd);
            //f.SetBinding(bd, filter);
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    //Find
            //    string val = f.GetSelectedItem(ReturnField);
            //    bd.RemoveFilter();
            //    bd.Position = bd.Find(ReturnField, val);
            //    f.Dispose();
            //}
            //else
            //{
            //    bd.RemoveFilter();
            //}
        }









    }
}