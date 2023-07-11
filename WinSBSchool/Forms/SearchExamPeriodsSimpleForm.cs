using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace WinSBSchool.Forms
{
    public partial class SearchExamPeriodsSimpleForm : Form
    {

        SBSchoolDBEntities db;
        string connection;
        IQueryable<ExamPeriod> _ExamPeriods;
        //delegate
        public delegate void ExamPeriodSelectHandler(object sender, ExamPeriodSelectEventArgs e);
        //event
        public event ExamPeriodSelectHandler OnExamPeriodListSelected;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;


        public SearchExamPeriodsSimpleForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewExamPeriods.SelectedRows.Count != 0)
            {
                try
                {
                    ExamPeriod selectedExamPeriod = (ExamPeriod)bindingSourceExamPeriods.Current;
                    OnExamPeriodListSelected(this, new ExamPeriodSelectEventArgs(selectedExamPeriod));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void SearchExamForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewExamPeriods.AutoGenerateColumns = false;
                this.dataGridViewExamPeriods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExamPeriods.DataSource = bindingSourceExamPeriods;

                _ExamPeriods = db.ExamPeriods.Where(i => i.Status == "A" && i.IsDeleted == false);

                AutoCompleteStringCollection acscyr = new AutoCompleteStringCollection();
                acscyr.AddRange(this.AutoComplete_Years());
                txtYear.AutoCompleteCustomSource = acscyr;
                txtYear.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtYear.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsctrm = new AutoCompleteStringCollection();
                acsctrm.AddRange(this.AutoComplete_Terms());
                txtTerm.AutoCompleteCustomSource = acsctrm;
                txtTerm.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtTerm.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscdsc = new AutoCompleteStringCollection();
                acscdsc.AddRange(this.AutoComplete_Description());
                txtDescription.AutoCompleteCustomSource = acscdsc;
                txtDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_Years()
        {
            try
            {
                var yrsquery = (from sb in db.ExamPeriods
                                where sb.Status == "A"
                                where sb.IsDeleted == false
                                select sb.Year).Distinct();
                int[] intarray = yrsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < yrsquery.Count(); i++)
                {
                    string strName = intarray[i].ToString();
                    items.Add(strName);
                }
                return items.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Terms()
        {
            try
            {
                var trmsquery = (from sb in db.ExamPeriods
                                 where sb.Status == "A"
                                 where sb.IsDeleted == false
                                 select sb.Term).Distinct();
                int[] intarray = trmsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < trmsquery.Count(); i++)
                {
                    string strName = intarray[i].ToString();
                    items.Add(strName);
                }
                return items.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Description()
        {
            try
            {
                var dscquery = from sb in db.ExamPeriods
                               where sb.Status == "A"
                               where sb.IsDeleted == false
                               select sb.Description;
                return dscquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        // apply the filter
        private void ApplyFilter()
        {
            try
            {
                var filter = CreateFilter(_ExamPeriods);
                // set the filter
                this.bindingSourceExamPeriods.DataSource = filter;
                groupBox1.Text = bindingSourceExamPeriods.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<ExamPeriod> CreateFilter(IQueryable<ExamPeriod> _examPeriod)
        {
            //none
            if (string.IsNullOrEmpty(txtYear.Text)
                && string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
            {
                return _examPeriod;
            }
            //all
            if (!string.IsNullOrEmpty(txtYear.Text)
                && !string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
            {
                int _Year = int.Parse(txtYear.Text);
                int _Term = int.Parse(txtTerm.Text);
                string _Description = txtDescription.Text;
                _examPeriod = from ep in db.ExamPeriods
                              where ep.Status == "A"
                              where ep.Year == _Year
                              where ep.IsDeleted == false
                              where ep.Term == _Term
                              where ep.Description.StartsWith(_Description)
                              select ep;
                return _examPeriod;
            }
            //Year
            if (!string.IsNullOrEmpty(txtYear.Text)
                  && string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
            {
                int _Year = int.Parse(txtYear.Text);
                _examPeriod = _examPeriod.Where(a => a.Year == _Year);
                return _examPeriod;
            }
            //Year and term
            if (!string.IsNullOrEmpty(txtYear.Text)
                 && !string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
            {
                int _Year = int.Parse(txtYear.Text);
                int _Term = int.Parse(txtTerm.Text);
                _examPeriod = _examPeriod.Where(a => a.Year == _Year && a.Term == _Term);
                return _examPeriod;
            }
            //year and description
            if (!string.IsNullOrEmpty(txtYear.Text)
                 && string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
            {
                int _Year = int.Parse(txtYear.Text);
                string _Description = txtDescription.Text;
                _examPeriod = _examPeriod.Where(a => a.Year == _Year && a.Description.StartsWith(_Description));
                return _examPeriod;
            }
            //term
            if (string.IsNullOrEmpty(txtYear.Text)
                  && !string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
            {
                int _Term = int.Parse(txtTerm.Text);
                _examPeriod = _examPeriod.Where(a => a.Term == _Term);
                return _examPeriod;
            }
            //term and description
            if (string.IsNullOrEmpty(txtYear.Text)
                 && !string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
            {
                int _Term = int.Parse(txtTerm.Text);
                string _Description = txtDescription.Text;
                _examPeriod = _examPeriod.Where(a => a.Term == _Term && a.Description.StartsWith(_Description));
                return _examPeriod;
            }
            //description
            if (string.IsNullOrEmpty(txtYear.Text)
                 && string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
            {
                string _Description = txtDescription.Text;
                _examPeriod = _examPeriod.Where(a => a.Description.StartsWith(_Description));
                return _examPeriod;
            }
            return _examPeriod; 
        }
        private void txtYear_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        } 
        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {
                    ApplyFilter();
                }
                e.Handled = true;
            }
        }
        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }
        private void txtTerm_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {
                    ApplyFilter();
                }
                e.Handled = true;
            }
        }
        private void txtTerm_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }
        private void txtDescription_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        } 
        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        } 
        private void dataGridViewExamPeriods_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExamPeriods.SelectedRows.Count != 0)
            {

                try
                {
                    ExamPeriod selectedExamPeriod = (ExamPeriod)bindingSourceExamPeriods.Current;
                    OnExamPeriodListSelected(this, new ExamPeriodSelectEventArgs(selectedExamPeriod));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewExamPeriods_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }









    }
}