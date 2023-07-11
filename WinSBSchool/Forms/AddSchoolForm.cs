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
    public partial class AddSchoolForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        #region "Constructor"
        public AddSchoolForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }
        #endregion "Constructor"

        public bool IsSchoolValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtIndex.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtIndex, "Index cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtSchoolName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSchoolName, "Name cannot be null!");
                return false;
            }
            if (cboSchoolType.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboSchoolType, "Select School Type!");
                return false;
            }
            if (cboGradingSystem.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboGradingSystem, "Select Grading System!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress1.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAddress1, "Address 1 cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtSlogan.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSlogan, "Slogan cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtLogo.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLogo, "Logo cannot be null!");
                return false;
            }
            return noerror;

        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsSchoolValid())
            {
                try
                {
                    School s = new School();
                    if (!string.IsNullOrEmpty(txtIndex.Text))
                    {
                        s.SchoolIndex = Utils.ConvertFirstLetterToUpper(txtIndex.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtSchoolName.Text))
                    {
                        s.SchoolName = Utils.ConvertFirstLetterToUpper(txtSchoolName.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtTelephone.Text))
                    {
                        s.Telephone = Utils.ConvertFirstLetterToUpper(txtTelephone.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtCellPhone.Text))
                    {
                        s.Cellphone = Utils.ConvertFirstLetterToUpper(txtCellPhone.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        s.Email = txtEmail.Text.ToString().ToLower().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtAddress1.Text))
                    {
                        s.Address1 = Utils.ConvertFirstLetterToUpper(txtAddress1.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtAddress2.Text))
                    {
                        s.Address2 = Utils.ConvertFirstLetterToUpper(txtAddress2.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtSlogan.Text))
                    {
                        s.Slogan = Utils.ConvertFirstLetterToUpper(txtSlogan.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtLogo.Text))
                    {
                        s.Logo = txtLogo.Text.ToString().Trim();
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        s.Status = cboStatus.SelectedValue.ToString();
                    }
                    if (cboSchoolType.SelectedIndex != -1)
                    {
                        s.SchoolType = cboSchoolType.SelectedValue.ToString();
                    }
                    if (cboGradingSystem.SelectedIndex != -1)
                    {
                        s.GradingSystem = int.Parse(cboGradingSystem.SelectedValue.ToString());
                    }
                    s.DefaultSchool = chkIsDefaultSchool.Checked;
                    if (!string.IsNullOrEmpty(txtSMSGateway.Text))
                    {
                        s.SMSGateway = Utils.ConvertFirstLetterToUpper(txtSMSGateway.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtSMTPServer.Text))
                    {
                        s.SMTPServer = Utils.ConvertFirstLetterToUpper(txtSMTPServer.Text.ToString().Trim());
                    }
                    s.IsDeleted = false;

                    if (db.Schools.Any(i => i.SchoolName == s.SchoolName))
                    {
                        MessageBox.Show("School Name Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Schools.Any(i => i.SchoolName == s.SchoolName))
                    {
                        db.Schools.AddObject(s);
                        db.SaveChanges();

                        SchoolsForm f = (SchoolsForm)this.Owner;
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
        private void buttonClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void AddSchoolForm_Load(object sender, EventArgs e)
        {
            try
            {

                var SchoolTypes = new BindingList<KeyValuePair<string, string>>();
                SchoolTypes.Add(new KeyValuePair<string, string>("1", "Pre-School"));
                SchoolTypes.Add(new KeyValuePair<string, string>("2", "Primary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("3", "Secondary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("4", "Tertiary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("5", "University"));
                SchoolTypes.Add(new KeyValuePair<string, string>("6", "Pre-School and Primary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("7", "Primary and Secondary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("8", "Primary, Secondary and Pre-School"));
                cboSchoolType.DataSource = SchoolTypes;
                cboSchoolType.ValueMember = "Key";
                cboSchoolType.DisplayMember = "Value";
                cboSchoolType.SelectedIndex = -1;

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                var grdsys = db.GradingSystems;
                List<GradingSystem> grdsystm = grdsys.ToList();
                cboGradingSystem.DataSource = grdsystm;
                cboGradingSystem.ValueMember = "Id";
                cboGradingSystem.DisplayMember = "Description";
                cboGradingSystem.SelectedIndex = -1;

                txtLogo.Enabled = false;

                var _Schoolsquery = (from pr in db.Schools
                                     where pr.DefaultSchool == true
                                     select pr).FirstOrDefault();
                School _School = _Schoolsquery;
                if (_School == null)
                {
                    chkIsDefaultSchool.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void DisableChechBox()
        {
            this.chkIsDefaultSchool.Enabled = false;
        }

        private void txtCellPhone_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCellPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                // Create OpenFileDialog 
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Title = "Select an Image File";
                ofd.Filter = "Image File (*.jpg)|*.jpg|Image File (*.gif)|*.gif|All files (*.*)|*.*";
                Nullable<bool> result = ofd.ShowDialog();
                // Process open file dialog box results
                if (result == true)
                {
                    txtLogo.Text = ofd.FileName.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

         





    }
}