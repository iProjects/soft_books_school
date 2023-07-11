using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class AddExamPeriodForm : Form
    {
        Repository rep;
        string connection;
        string user;
        SBSchoolDBEntities db;
        int _defaultYear;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public AddExamPeriodForm(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            user = _user;
            db = new SBSchoolDBEntities(connection);
        }
        public AddExamPeriodForm(int year, string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            user = _user;
            db = new SBSchoolDBEntities(connection);

            if (year == null)
                throw new ArgumentNullException("Year");
            _defaultYear = year;

            txtYear.Text = _defaultYear.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (IsExamPeriodValid())
            {
                try
                {
                    int _Year;
                    if (!int.TryParse(txtYear.Text, out _Year))
                    {
                        MessageBox.Show("Year must be a number", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    int _Term;
                    if (!int.TryParse(txtTerm.Text, out _Term))
                    {
                        MessageBox.Show("Term must be a number", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string _Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text);

                    ExamPeriod ep = new ExamPeriod();
                    ep.Year = _Year;
                    ep.Term = _Term;
                    ep.Description = _Description;
                    ep.Status = cboStatus.SelectedValue.ToString();
                    ep.StartDate = dtpStartDate.Value;
                    ep.EndDate = dtpEndDate.Value;
                    ep.IsDeleted = false;

                    if (db.ExamPeriods.Any(o => o.Year == _Year && o.Term == _Term))
                    {
                        MessageBox.Show("Term for Year " + _Year + " Exist!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.ExamPeriods.Any(o => o.Year == _Year && o.Term == _Term))
                    {
                        db.ExamPeriods.AddObject(ep);
                        db.SaveChanges();


                        ExamPeriodsForm f = (ExamPeriodsForm)this.Owner;
                        if (_defaultYear != null)
                        {
                            if (ep.Year == _defaultYear)
                            {
                                f.RefreshGrid();
                                this.Close();
                            }
                            if (ep.Year != _defaultYear)
                            {
                                f.RefreshAllGrids();
                                this.Close();
                            }
                        }
                        if (_defaultYear == null)
                        {
                            f.RefreshAllGrids();
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsExamPeriodValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtYear, "Year cannot be null!");
                return false;
            }
            int year;
            if (!int.TryParse(txtYear.Text, out year))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtYear, "Year must be integer!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTerm.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTerm, "Term cannot be null!");
                return false;
            }
            int term;
            if (!int.TryParse(txtTerm.Text, out term))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTerm, "Term must be integer!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (cboStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboStatus, "Select Status!");
                return false;
            }
            return noerror;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddExamPeriodForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                string _Term = Utils.NextSeries(NextTerm());
                txtTerm.Text = _Term;


                this.dtpEndDate.Value = DateTime.Today;
                this.dtpStartDate.Value = DateTime.Today.AddMonths(-3);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private string NextTerm()
        {
            try
            {
                var cn = (from c in db.ExamPeriods
                          where c.Year == _defaultYear
                          orderby c.Id descending
                          select c).FirstOrDefault();
                if (cn == null)
                    return "0";
                return cn.Term.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "0";
            }
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtYear.Text) && !string.IsNullOrEmpty(txtTerm.Text))
                {
                    txtDescription.Text = string.Empty;
                    string year = txtYear.Text;
                    string term = " - " + txtTerm.Text;
                    if (year.Length >= 4)
                    {
                        string yearterm = year.Insert(4, term);
                        txtDescription.Text = yearterm;
                    }
                    if (year.Length < 4)
                    {
                        txtDescription.Text = year;
                    }
                }
                if (!string.IsNullOrEmpty(txtYear.Text) && string.IsNullOrEmpty(txtTerm.Text))
                {
                    txtDescription.Text = string.Empty;
                    txtDescription.Text = txtYear.Text;
                }
                if (string.IsNullOrEmpty(txtYear.Text))
                {
                    txtDescription.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void txtTerm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtYear.Text) && !string.IsNullOrEmpty(txtTerm.Text))
                {
                    txtDescription.Text = string.Empty;
                    string year = txtYear.Text;
                    string term = " - " + txtTerm.Text;
                    if (year.Length >= 4)
                    {
                        string yearterm = year.Insert(4, term);
                        txtDescription.Text = yearterm;
                    }
                    if (year.Length < 4)
                    {
                        txtDescription.Text = year;
                    }
                }
                if (string.IsNullOrEmpty(txtYear.Text) && string.IsNullOrEmpty(txtTerm.Text))
                {
                    txtDescription.Text = string.Empty;
                }
                if (!string.IsNullOrEmpty(txtYear.Text) && string.IsNullOrEmpty(txtTerm.Text))
                {
                    txtDescription.Text = string.Empty;
                    txtDescription.Text = txtYear.Text;

                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
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

        private void txtTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }





    }
}