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
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class EditSchoolForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        DAL.School _school;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditSchoolForm(DAL.School school, string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            TAG = this.GetType().Name;

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname = notificationmessageEventname;

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
            user = UserName;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished EditSchoolForm initialization", TAG));

        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.Write_To_Log_File_temp_dir(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }

        private void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            Log.Write_To_Log_File_temp_dir(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }
        private void buttonClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void EditSchoolForm_Load(object sender, EventArgs e)
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

                var grdsys = db.GradingSystems;
                List<GradingSystem> grdsystm = grdsys.ToList();
                cboGradingSystem.DataSource = grdsystm;
                cboGradingSystem.ValueMember = "Id";
                cboGradingSystem.DisplayMember = "Description";
                cboGradingSystem.SelectedIndex = -1;

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                txtLogo.Enabled = false;

                InitializeControls();

                AutoCompleteStringCollection acsaccid = new AutoCompleteStringCollection();
                acsaccid.AddRange(this.AutoComplete_CustomerIds());
                txtAccountId.AutoCompleteCustomSource = acsaccid;
                txtAccountId.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountId.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_CustomerIds()
        {
            try
            {
                var custidsquery = (from ac in db.Customers
                                    select ac.Id).Distinct();
                int[] intarray = custidsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < custidsquery.Count(); i++)
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
        private void InitializeControls()
        {

            try
            {
                if (_school.SchoolIndex != null)
                {
                    txtIndex.Text = _school.SchoolIndex.ToString().Trim();
                }
                if (_school.SchoolName != null)
                {
                    txtSchoolName.Text = _school.SchoolName.ToString().Trim();
                }
                if (_school.Telephone != null)
                {
                    txtTelephone.Text = _school.Telephone.ToString().Trim();
                }
                if (_school.Cellphone != null)
                {
                    txtCellPhone.Text = _school.Cellphone.ToString().Trim();
                }
                if (_school.Email != null)
                {
                    txtEmail.Text = _school.Email.ToString().Trim();
                }
                if (_school.Address1 != null)
                {
                    txtAddress1.Text = _school.Address1.ToString().Trim();
                }
                if (_school.Address2 != null)
                {
                    txtAddress2.Text = _school.Address2.ToString().Trim();
                }
                if (_school.Slogan != null)
                {
                    txtSlogan.Text = _school.Slogan.ToString().Trim();
                }
                if (_school.Logo != null)
                {
                    txtLogo.Text = _school.Logo.ToString().Trim();
                }
                if (_school.SchoolType != null)
                {
                    cboSchoolType.SelectedValue = _school.SchoolType;
                }
                if (_school.GradingSystem != null)
                {
                    cboGradingSystem.SelectedValue = _school.GradingSystem;
                }
                if (_school.DefaultSchool != null)
                {
                    chkIsDefaultSchool.Checked = _school.DefaultSchool;
                }
                if (_school.SMSGateway != null)
                {
                    txtSMSGateway.Text = _school.SMSGateway.ToString().Trim();
                }
                if (_school.SMTPServer != null)
                {
                    txtSMTPServer.Text = _school.SMTPServer.ToString().Trim();
                }
                if (_school.GLCustomerId != null)
                {
                    txtAccountId.Text = _school.GLCustomerId.ToString();
                }
                if (_school.Status != null)
                {
                    cboStatus.SelectedValue = _school.Status.Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        public bool IsSchoolValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtIndex.Text))
            { 
                errorProvider.SetError(txtIndex, "School Index cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtSchoolName.Text))
            { 
                errorProvider.SetError(txtSchoolName, "School Name cannot be null!");
                noerror = false;
            }
            if (cboSchoolType.SelectedIndex == -1)
            { 
                errorProvider.SetError(cboSchoolType, "Select School Type!");
                noerror = false;
            }
            if (cboGradingSystem.SelectedIndex == -1)
            { 
                errorProvider.SetError(cboGradingSystem, "Select Grading System!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAccountId.Text))
            { 
                errorProvider.SetError(txtAccountId, "Customer Id cannot be null!");
                noerror = false;
            }
            int _customerid;
            if (!int.TryParse(txtAccountId.Text, out _customerid))
            { 
                errorProvider.SetError(txtAccountId, "Customer Id must be integer!");
                noerror = false;
            }
            Customer customer = rep.GetCustomer(_customerid);
            if (customer == null)
            { 
                errorProvider.SetError(txtAccountId, "Error Retrieving Customer!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAddress1.Text))
            { 
                errorProvider.SetError(txtAddress1, "Address 1 cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtSlogan.Text))
            { 
                errorProvider.SetError(txtSlogan, "Slogan cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtLogo.Text))
            { 
                errorProvider.SetError(txtLogo, "Logo cannot be null!");
                noerror = false;
            }
            return noerror;
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            if (IsSchoolValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtIndex.Text))
                    {
                        _school.SchoolIndex = Utils.ConvertFirstLetterToUpper(txtIndex.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtSchoolName.Text))
                    {
                        _school.SchoolName = Utils.ConvertFirstLetterToUpper(txtSchoolName.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtTelephone.Text))
                    {
                        _school.Telephone = Utils.ConvertFirstLetterToUpper(txtTelephone.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtCellPhone.Text))
                    {
                        _school.Cellphone = Utils.ConvertFirstLetterToUpper(txtCellPhone.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        _school.Email = txtEmail.Text.ToString().ToLower().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtAddress1.Text))
                    {
                        _school.Address1 = Utils.ConvertFirstLetterToUpper(txtAddress1.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtAddress2.Text))
                    {
                        _school.Address2 = Utils.ConvertFirstLetterToUpper(txtAddress2.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtSlogan.Text))
                    {
                        _school.Slogan = Utils.ConvertFirstLetterToUpper(txtSlogan.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtLogo.Text))
                    {
                        _school.Logo = txtLogo.Text.ToString().Trim();
                    }
                    if (cboSchoolType.SelectedIndex != -1)
                    {
                        _school.SchoolType = cboSchoolType.SelectedValue.ToString();
                    }
                    if (cboGradingSystem.SelectedIndex != -1)
                    {
                        _school.GradingSystem = int.Parse(cboGradingSystem.SelectedValue.ToString());
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        _school.Status = cboStatus.SelectedValue.ToString();
                    }
                    _school.DefaultSchool = chkIsDefaultSchool.Checked;
                    if (!string.IsNullOrEmpty(txtSMSGateway.Text))
                    {
                        _school.SMSGateway = Utils.ConvertFirstLetterToUpper(txtSMSGateway.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtSMTPServer.Text))
                    {
                        _school.SMTPServer = Utils.ConvertFirstLetterToUpper(txtSMTPServer.Text.ToString().Trim());
                    }
                    int _customerid;
                    if (!string.IsNullOrEmpty(txtAccountId.Text) && int.TryParse(txtAccountId.Text, out _customerid))
                    {
                        _school.GLCustomerId = int.Parse(txtAccountId.Text);
                    }

                    rep.UpdateSchool(_school);

                    if (this.Owner is SchoolsForm)
                    {
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
        
        /*public method to diable all controls when form is called by parent from 'View Details' button*/
        public void DisableControls()
        {
            txtAddress1.Enabled = false;
            txtAddress2.Enabled = false;
            txtCellPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtIndex.Enabled = false;
            txtSchoolName.Enabled = false;
            txtTelephone.Enabled = false;
            txtSMTPServer.Enabled = false;
            txtSMSGateway.Enabled = false;
            chkIsDefaultSchool.Enabled = false;
            txtLogo.Enabled = false;
            btnBrowse.Enabled = false;
            txtSlogan.Enabled = false;
            cboGradingSystem.Enabled = false;
            btnSearchCustomerId.Enabled = false;
            cboSchoolType.Enabled = false;
            txtAccountId.Enabled = false;
            btnCreateSCustomer.Enabled = false;
            cboStatus.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;
        }
        public void DisableCheckBox()
        {
            this.chkIsDefaultSchool.Enabled = false;
        }
        public void SetCheckBox()
        {
            this.chkIsDefaultSchool.Checked = true;
        }
        private void btnSearchCustomerId_Click(object sender, EventArgs e)
        {
            try
            {
                SearchCustomersSimpleForm scf = new SearchCustomersSimpleForm(user, connection, _notificationmessageEventname) { Owner = this };
                scf.OnCustomerListSelected += new SearchCustomersSimpleForm.CustomerSelectHandler(scf_OnCustomerListSelected);
                scf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void scf_OnCustomerListSelected(object sender, CustomerSelectEventArgs e)
        {
            SetAccountNos(e._Customer);
        }
        private void SetAccountNos(Customer _customer)
        {
            if (_customer != null)
            {
                txtAccountId.Text = _customer.Id.ToString();
            }
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
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
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
        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void btnCreateCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAccountId.Text))
                {
                    AddNewCustomerForm ancf = new AddNewCustomerForm(_school, connection) { Owner = this };
                    ancf.Show();
                }
                if (!string.IsNullOrEmpty(txtAccountId.Text))
                {
                    int customerId = int.Parse(txtAccountId.Text);
                    Customer _Customer = rep.GetCustomer(customerId);
                    if (_Customer != null)
                    {
                        MessageBox.Show("Customer Exists!", "SB School");
                    }
                    else
                    {
                        AddNewCustomerForm ancf = new AddNewCustomerForm(_school, connection) { Owner = this };
                        ancf.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void CloseForm(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.Owner is SchoolsForm)
                {
                    SchoolsForm f = (SchoolsForm)this.Owner;
                    f.CloseForm();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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