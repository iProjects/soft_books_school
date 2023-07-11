using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;
using System.Linq;

namespace WinSBSchool.Forms
{
    public partial class AddClassForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;


        public AddClassForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void AddClassForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                var tchrsquery = from tc in db.Teachers
                                 where tc.Status == "A"
                                 where tc.IsDeleted==false
                                 orderby tc.Name ascending
                                 select tc; 
                List<Teacher> _Teachers = tchrsquery.ToList();
                cboClassTeacher.DataSource = _Teachers;
                cboClassTeacher.ValueMember = "Id";
                cboClassTeacher.DisplayMember = "Name";
                cboClassTeacher.SelectedIndex = -1;

                var prgrmmyrs = (from pc in db.ProgrammeYears
                                 where pc.IsDeleted==false
                                 join pr in db.Programmes on pc.ProgrammeId equals pr.Id
                                 where pr.IsDeleted==false
                                 select pc).Distinct();
                List<ProgrammeYear> ProgrammeYears = prgrmmyrs.ToList();
                cboProgrammeYears.DataSource = ProgrammeYears;
                cboProgrammeYears.ValueMember = "Id";
                cboProgrammeYears.DisplayMember = "Description";
                cboProgrammeYears.SelectedIndex = -1;

                AutoCompleteStringCollection acsccls = new AutoCompleteStringCollection();
                acsccls.AddRange(this.AutoComplete_Description());
                txtClassName.AutoCompleteCustomSource = acsccls;
                txtClassName.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtClassName.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection scccls = new AutoCompleteStringCollection();
                scccls.AddRange(this.AutoComplete_ShortCode());
                txtShortCode.AutoCompleteCustomSource = scccls;
                txtShortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtShortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_Description()
        {
            try
            {
                var descriptionquery = from cs in db.SchoolClasses
                                       where cs.IsDeleted == false
                                       select cs.ClassName;
                return descriptionquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_ShortCode()
        {
            try
            {
                var descriptionquery = from cs in db.SchoolClasses
                                       where cs.IsDeleted == false
                                       select cs.ShortCode;
                return descriptionquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void buttonClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        public bool IsClassValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtShortCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtShortCode, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtClassName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtClassName, "Class Name cannot be null!");
                return false;
            }
            if (cboProgrammeYears.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboProgrammeYears, "Select Programme!");
                return false;
            }
            if (string.IsNullOrEmpty(txtNoOfSubjects.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoOfSubjects, "No Of Subjects cannot be null!");
                return false;
            }
            int noofsubjects;
            if (!int.TryParse(txtNoOfSubjects.Text, out noofsubjects))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoOfSubjects, "No Of Subjects must be integer!");
                return false;
            }
            if (cboClassTeacher.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboClassTeacher, "Select Teacher!");
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

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsClassValid())
            {
                try
                {
                    DAL.SchoolClass c = new DAL.SchoolClass();
                    if (!string.IsNullOrEmpty(txtShortCode.Text))
                    {
                        c.ShortCode = Utils.ConvertFirstLetterToUpper(txtShortCode.Text);
                    }
                    if (!string.IsNullOrEmpty(txtClassName.Text))
                    {
                        c.ClassName = Utils.ConvertFirstLetterToUpper(txtClassName.Text .Trim());
                    }
                    if (cboProgrammeYears.SelectedIndex != -1)
                    {
                        c.ProgrammeYearId = int.Parse(cboProgrammeYears.SelectedValue.ToString());
                    }
                    int noofsubjects;
                    if (!string.IsNullOrEmpty(txtNoOfSubjects.Text) && int.TryParse(txtNoOfSubjects.Text,out noofsubjects))
                    {
                        c.NoOfSubjects = int.Parse(txtNoOfSubjects.Text.ToString());
                    }
                    if (cboClassTeacher.SelectedIndex != -1)
                    {
                        c.TeacherId = int.Parse(cboClassTeacher.SelectedValue.ToString());
                    }
                    int crrntyr;
                    if (!string.IsNullOrEmpty(txtCurrentYearLevel.Text) && int.TryParse(txtCurrentYearLevel.Text,out crrntyr))
                    {
                        c.CurrentYrLevel = int.Parse(txtCurrentYearLevel.Text.ToString());
                    }
                    int nxtyr;
                    if (!string.IsNullOrEmpty(txtNextYearLevel.Text) && int.TryParse(txtNextYearLevel.Text.Trim(),out nxtyr))
                    {
                        c.NextYrLevel = int.Parse(txtNextYearLevel.Text.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtRemarks.Text))
                    {
                        c.Remarks = Utils.ConvertFirstLetterToUpper(txtRemarks.Text.Trim());
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        c.Status = cboStatus.SelectedValue.ToString();
                    }
                    c.IsDeleted = false;

                    if (db.SchoolClasses.Any(i => i.ShortCode == c.ShortCode))
                    {
                        MessageBox.Show("Short Code Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.SchoolClasses.Any(i => i.ShortCode == c.ShortCode))
                    {
                        db.SchoolClasses.AddObject(c);
                        db.SaveChanges();

                        ClassesForm f = (ClassesForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void txtCurrentYearLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtCurrentYearLevel_KeyDown(object sender, KeyEventArgs e)
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
        private void txtNoOfSubjects_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtNoOfSubjects_KeyDown(object sender, KeyEventArgs e)
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
        private void txtNextYearLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtNextYearLevel_KeyDown(object sender, KeyEventArgs e)
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



    }
}