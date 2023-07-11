using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class ExamPeriodsForm : Form
    {
        string user;
        SBSchoolDBEntities db;
        Repository rep;
        string connection;
        IQueryable<ExamPeriod> _ExamPeriods;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public ExamPeriodsForm(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            user = _user;
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (cboYear.SelectedIndex != -1)
                {

                    int year = (int)cboYear.SelectedItem;
                    AddExamPeriodForm aepf = new AddExamPeriodForm(year, user, connection) { Owner = this };
                    aepf.ShowDialog();
                }
                if (cboYear.SelectedIndex == -1)
                {
                    AddExamPeriodForm aepf = new AddExamPeriodForm(user, connection) { Owner = this };
                    aepf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        public void RefreshYearCombo()
        {
            try
            {
                if (chkInActive.Checked)
                {
                    var _exmprds = (from exmprd in db.ExamPeriods
                                    where exmprd.IsDeleted == false
                                    orderby exmprd.Year ascending
                                    select exmprd.Year).Distinct();
                    cboYear.DataSource = _exmprds.ToList();
                }
                else
                {
                    var _exmprds = (from exmprd in db.ExamPeriods
                                    where exmprd.Status == "A"
                                    where exmprd.IsDeleted == false
                                    orderby exmprd.Year ascending
                                    select exmprd.Year).Distinct();
                    cboYear.DataSource = _exmprds.ToList();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }

        public void RefreshGrid()
        {
            try
            {
                ApplyFilter();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshAllGrids()
        {
            try
            {
                RefreshYearCombo();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ExamPeriodsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                DataGridViewComboBoxColumn colCboxStatus = new DataGridViewComboBoxColumn();
                colCboxStatus.HeaderText = "Status";
                colCboxStatus.Name = "cbStatus";
                colCboxStatus.DataSource = status;
                // The display member is the name column in the column datasource  
                colCboxStatus.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxStatus.DataPropertyName = "Status";
                // The value member is the primary key of the parent table  
                colCboxStatus.ValueMember = "Key";
                colCboxStatus.MaxDropDownItems = 10;
                colCboxStatus.Width = 80;
                colCboxStatus.DisplayIndex = 5;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true;
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewExamPeriods.Columns.Contains("cbStatus"))
                {
                    dataGridViewExamPeriods.Columns.Add(colCboxStatus);
                } 

                dataGridViewExamPeriods.AutoGenerateColumns = false;
                dataGridViewExamPeriods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExamPeriods.DataSource = bindingSourceExamPeriods;

                AutoCompleteStringCollection acscyr = new AutoCompleteStringCollection();
                acscyr.AddRange(this.AutoComplete_Years());
                cboYear.AutoCompleteCustomSource = acscyr;
                cboYear.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                cboYear.AutoCompleteSource =
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

                RefreshYearCombo();

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
                var trmquery = (from sb in db.ExamPeriods
                                where sb.Status == "A"
                                where sb.IsDeleted == false
                                select sb.Term).Distinct();
                int[] intarray = trmquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < trmquery.Count(); i++)
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
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            RefreshYearCombo();

            if (cboYear.SelectedIndex != -1)
            {
                int _year = (int)cboYear.SelectedItem;
                try
                {
                    if (chkInActive.Checked)
                    {
                        bindingSourceExamPeriods.DataSource = null;
                        var _examperiodsquery = from st in db.ExamPeriods
                                                where st.Year == _year
                                                where st.IsDeleted == false
                                                select st;
                        bindingSourceExamPeriods.DataSource = _examperiodsquery.ToList();
                        groupBox2.Text = _examperiodsquery.Count().ToString();
                    }
                    else
                    {
                        bindingSourceExamPeriods.DataSource = null;
                        var _examperiodsquery = from st in db.ExamPeriods
                                                where st.Status == "A"
                                                where st.IsDeleted == false
                                                where st.Year == _year
                                                select st;
                        bindingSourceExamPeriods.DataSource = _examperiodsquery.ToList();
                        groupBox2.Text = _examperiodsquery.Count().ToString();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchExamPeriodForm saf = new Forms.SearchExamPeriodForm(connection) { Owner = this };
                saf.OnExamPeriodListSelected += new SearchExamPeriodForm.ExamPeriodSelectHandler(saf_OnExamPeriodListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnExamPeriodListSelected(object sender, ExamPeriodSelectEventArgs e)
        {
            SetExamPeriod(e._ExamPeriod);
        }
        private void SetExamPeriod(ExamPeriod _ExamPeriod)
        {
            if (_ExamPeriod != null)
            {
                bindingSourceExamPeriods.DataSource = _ExamPeriod;
                groupBox2.Text = bindingSourceExamPeriods.Count.ToString();
            }
        }
        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            if (cboYear.SelectedIndex != -1)
            {
                int _year = (int)cboYear.SelectedItem;
                try
                {
                    if (chkInActive.Checked)
                    {
                        bindingSourceExamPeriods.DataSource = null;
                        var _examperiodsquery = from st in db.ExamPeriods
                                                where st.IsDeleted == false
                                                where st.Year == _year
                                                select st;
                        bindingSourceExamPeriods.DataSource = _examperiodsquery.ToList();
                        groupBox2.Text = _examperiodsquery.Count().ToString();
                    }
                    else
                    {
                        bindingSourceExamPeriods.DataSource = null;
                        var _examperiodsquery = from st in db.ExamPeriods
                                                where st.Status == "A"
                                                where st.IsDeleted == false
                                                where st.Year == _year
                                                select st;
                        bindingSourceExamPeriods.DataSource = _examperiodsquery.ToList();
                        groupBox2.Text = _examperiodsquery.Count().ToString();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyFilter();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (dataGridViewExamPeriods.SelectedRows.Count != 0)
            {
                try
                {
                    ExamPeriod exmpd = (ExamPeriod)bindingSourceExamPeriods.Current;

                    var _examquery = from ed in db.Exams
                                     where ed.Enabled == true
                                     where ed.IsDeleted == false
                                     where ed.Closed == false
                                     where ed.ExamPeriodId == exmpd.Id
                                     where ed.IsDeleted == false
                                     select ed;
                    List<Exam> _Exams = _examquery.ToList();

                    if (_Exams.Count > 0)
                    {
                        MessageBox.Show("There is an Exam Associated with this Exam Period.\n Delete the Exam First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Exam Period\n" + exmpd.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteExamPeriod(exmpd);

                            RefreshGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewExamPeriods.SelectedRows.Count != 0)
            {
                try
                {
                    if (cboYear.SelectedIndex != -1)
                    {

                        int year = (int)cboYear.SelectedItem;
                        ExamPeriod exmpd = (ExamPeriod)bindingSourceExamPeriods.Current;
                        EditExamPeriodForm epf = new EditExamPeriodForm(exmpd, year, user, connection) { Owner = this };
                        epf.Text = exmpd.Description.ToUpper();
                        epf.ShowDialog();
                    }
                    if (cboYear.SelectedIndex == -1)
                    {
                        ExamPeriod exmpd = (ExamPeriod)bindingSourceExamPeriods.Current;
                        EditExamPeriodForm epf = new EditExamPeriodForm(exmpd, user, connection) { Owner = this };
                        epf.Text = exmpd.Description.ToUpper();
                        epf.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void cboYear_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cboYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {
                    ApplyFilter();
                }
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void cboYear_KeyDown(object sender, KeyEventArgs e)
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
        // apply the filter
        private void ApplyFilter()
        {
            try
            {
                _ExamPeriods = db.ExamPeriods;
                var filter = CreateFilter(_ExamPeriods);
                // set the filter
                this.bindingSourceExamPeriods.DataSource = filter;
                groupBox2.Text = filter.Count().ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<ExamPeriod> CreateFilter(IQueryable<ExamPeriod> _examPeriod)
        {
            if (chkInActive.Checked)
            {
                //none
                if (string.IsNullOrEmpty(cboYear.Text)
                    && string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
                {
                    return _examPeriod;
                }
                //all
                if (!string.IsNullOrEmpty(cboYear.Text)
                    && !string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Year = int.Parse(cboYear.Text);
                    int _Term = int.Parse(txtTerm.Text);
                    string _Description = txtDescription.Text;
                    _examPeriod = from ep in db.ExamPeriods
                                  where ep.Year == _Year
                                  where ep.IsDeleted == false
                                  where ep.Term == _Term
                                  where ep.Description.StartsWith(_Description)
                                  select ep;
                    return _examPeriod;
                }
                //Year
                if (!string.IsNullOrEmpty(cboYear.Text)
                      && string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Year = int.Parse(cboYear.Text);
                    _examPeriod = _examPeriod.Where(a => a.Year == _Year);
                    return _examPeriod;
                }
                //Year and term
                if (!string.IsNullOrEmpty(cboYear.Text)
                     && !string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Year = int.Parse(cboYear.Text);
                    int _Term = int.Parse(txtTerm.Text);
                    _examPeriod = _examPeriod.Where(a => a.Year == _Year && a.Term == _Term);
                    return _examPeriod;
                }
                //year and description
                if (!string.IsNullOrEmpty(cboYear.Text)
                     && string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Year = int.Parse(cboYear.Text);
                    string _Description = txtDescription.Text;
                    _examPeriod = _examPeriod.Where(a => a.Year == _Year && a.Description.StartsWith(_Description));
                    return _examPeriod;
                }
                //term
                if (string.IsNullOrEmpty(cboYear.Text)
                      && !string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Term = int.Parse(txtTerm.Text);
                    _examPeriod = _examPeriod.Where(a => a.Term == _Term);
                    return _examPeriod;
                }
                //term and description
                if (string.IsNullOrEmpty(cboYear.Text)
                     && !string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Term = int.Parse(txtTerm.Text);
                    string _Description = txtDescription.Text;
                    _examPeriod = _examPeriod.Where(a => a.Term == _Term && a.Description.StartsWith(_Description));
                    return _examPeriod;
                }
                //description
                if (string.IsNullOrEmpty(cboYear.Text)
                     && string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    string _Description = txtDescription.Text;
                    _examPeriod = _examPeriod.Where(a => a.Description.StartsWith(_Description));
                    return _examPeriod;
                }
            }
            else
            {
                //none
                if (string.IsNullOrEmpty(cboYear.Text)
                    && string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
                {
                    return _examPeriod.Where(i => i.Status == "A");
                }
                //all
                if (!string.IsNullOrEmpty(cboYear.Text)
                    && !string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Year = int.Parse(cboYear.Text);
                    int _Term = int.Parse(txtTerm.Text);
                    string _Description = txtDescription.Text;
                    _examPeriod = from ep in db.ExamPeriods
                                  where ep.Year == _Year
                                  where ep.Term == _Term
                                  where ep.IsDeleted == false
                                  where ep.Status == "A"
                                  where ep.Description.StartsWith(_Description)
                                  select ep;
                    return _examPeriod;
                }
                //Year
                if (!string.IsNullOrEmpty(cboYear.Text)
                      && string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Year = int.Parse(cboYear.Text);
                    _examPeriod = _examPeriod.Where(a => a.Year == _Year && a.Status == "A");
                    return _examPeriod;
                }
                //Year and term
                if (!string.IsNullOrEmpty(cboYear.Text)
                     && !string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Year = int.Parse(cboYear.Text);
                    int _Term = int.Parse(txtTerm.Text);
                    _examPeriod = _examPeriod.Where(a => a.Year == _Year && a.Term == _Term && a.Status == "A");
                    return _examPeriod;
                }
                //year and description
                if (!string.IsNullOrEmpty(cboYear.Text)
                     && string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Year = int.Parse(cboYear.Text);
                    string _Description = txtDescription.Text;
                    _examPeriod = _examPeriod.Where(a => a.Year == _Year && a.Description.StartsWith(_Description) && a.Status == "A");
                    return _examPeriod;
                }
                //term
                if (string.IsNullOrEmpty(cboYear.Text)
                      && !string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Term = int.Parse(txtTerm.Text);
                    _examPeriod = _examPeriod.Where(a => a.Term == _Term && a.Status == "A");
                    return _examPeriod;
                }
                //term and description
                if (string.IsNullOrEmpty(cboYear.Text)
                     && !string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    int _Term = int.Parse(txtTerm.Text);
                    string _Description = txtDescription.Text;
                    _examPeriod = _examPeriod.Where(a => a.Term == _Term && a.Description.StartsWith(_Description) && a.Status == "A");
                    return _examPeriod;
                }
                //description
                if (string.IsNullOrEmpty(cboYear.Text)
                     && string.IsNullOrEmpty(txtTerm.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    string _Description = txtDescription.Text;
                    _examPeriod = _examPeriod.Where(a => a.Description.StartsWith(_Description) && a.Status == "A");
                    return _examPeriod;
                }
            }
            return _examPeriod;
        }

        private void txtTerm_Validated(object sender, EventArgs e)
        {
            if (nonNumberEntered == true)
            {
                ApplyFilter();
            }
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
                    if (cboYear.SelectedIndex != -1)
                    {

                        int year = (int)cboYear.SelectedItem;
                        ExamPeriod exmpd = (ExamPeriod)bindingSourceExamPeriods.Current;
                        EditExamPeriodForm epf = new EditExamPeriodForm(exmpd, year, user, connection) { Owner = this };
                        epf.Text = exmpd.Description.ToUpper();
                        epf.ShowDialog();
                    }
                    if (cboYear.SelectedIndex == -1)
                    {
                        ExamPeriod exmpd = (ExamPeriod)bindingSourceExamPeriods.Current;
                        EditExamPeriodForm epf = new EditExamPeriodForm(exmpd, user, connection) { Owner = this };
                        epf.Text = exmpd.Description.ToUpper();
                        epf.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }



    }
}