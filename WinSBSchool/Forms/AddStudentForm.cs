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
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class AddStudentForm : Form
    {
        Repository rep;
        string connection;
        SBSchoolDBEntities db;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public AddStudentForm(string _user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            user = _user;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AddStudentForm initialization", TAG));

        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.WriteToErrorLogFile_and_EventViewer(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }

        private void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            Log.WriteToErrorLogFile_and_EventViewer(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }
        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                imgStudentPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                //Gender Combox
                var gender = new BindingList<KeyValuePair<string, string>>();
                gender.Add(new KeyValuePair<string, string>("M", "Male"));
                gender.Add(new KeyValuePair<string, string>("F", "Female"));
                cboGender.DataSource = gender;
                cboGender.ValueMember = "Key";
                cboGender.DisplayMember = "Value";
                cboGender.SelectedIndex = -1;

                var _ClassStreamsquery = from csms in db.ClassStreams
                                         where csms.IsDeleted == false
                                         orderby csms.Description ascending
                                         select csms;
                List<ClassStream> ClassStreams = _ClassStreamsquery.ToList();
                cboCurrentClass.DataSource = ClassStreams;
                cboCurrentClass.ValueMember = "Id";
                cboCurrentClass.DisplayMember = "Description";
                cboCurrentClass.SelectedIndex = -1;

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                var AdmissionType = new BindingList<KeyValuePair<string, string>>();
                AdmissionType.Add(new KeyValuePair<string, string>("N", "New Admission"));
                AdmissionType.Add(new KeyValuePair<string, string>("T", "Transfer"));
                cboStudentAdmissionType.DataSource = AdmissionType;
                cboStudentAdmissionType.ValueMember = "Key";
                cboStudentAdmissionType.DisplayMember = "Value";

                var _Schoolsquery = from scs in db.Schools
                                    where scs.Status=="A"
                                    where scs.IsDeleted == false
                                    select scs;
                List<School> _Schools = _Schoolsquery.ToList();
                cboSchool.DataSource = _Schools;
                cboSchool.ValueMember = "Id";
                cboSchool.DisplayMember = "SchoolName";
                cboSchool.SelectedIndex = -1;

                var _defaultSchoolquery = (from sub in db.Schools
                                           where sub.DefaultSchool == true
                                           where sub.IsDeleted == false
                                           where sub.Status=="A"
                                           select sub).FirstOrDefault();
                School _defaultSchool = _defaultSchoolquery; 
                if (_defaultSchool != null)
                {
                    cboSchool.SelectedValue = _defaultSchool.Id;
                }

                this.dpDOB.Value = DateTime.Today.AddYears(-18);

                string _AdminNo = Utils.NextSeries(NextAdminNo());
                txtAdminNo.Text = _AdminNo;
                txtAdmittedBy.Text = user;
                txtRemarks.Text = "New Student";

                AutoCompleteStringCollection acscsrnm = new AutoCompleteStringCollection();
                acscsrnm.AddRange(this.AutoComplete_StudentSurName());
                txtSurname.AutoCompleteCustomSource = acscsrnm;
                txtSurname.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtSurname.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscsotnm = new AutoCompleteStringCollection();
                acscsotnm.AddRange(this.AutoComplete_StudentOtherNames());
                txtOtherNames.AutoCompleteCustomSource = acscsotnm;
                txtOtherNames.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtOtherNames.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscdmn = new AutoCompleteStringCollection();
                acscdmn.AddRange(this.AutoComplete_AdminNo());
                txtAdminNo.AutoCompleteCustomSource = acscdmn;
                txtAdminNo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAdminNo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
                
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AddStudentForm load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_StudentSurName()
        {
            try
            {
                var studentsquery = from bk in db.Students
                                    where bk.Status == "A"
                                    where bk.IsDeleted == false
                                    select bk.StudentSurName;
                return studentsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_StudentOtherNames()
        {
            try
            {
                var studentsquery = from bk in db.Students
                                    where bk.Status == "A"
                                    where bk.IsDeleted == false
                                    select bk.StudentOtherNames;
                return studentsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_AdminNo()
        {
            try
            {
                var studentsquery = from bk in db.Students
                                    where bk.Status == "A"
                                    where bk.IsDeleted == false
                                    select bk.AdminNo;
                return studentsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string NextAdminNo()
        {
            try
            {
                var cn = (from c in db.Students
                          orderby c.Id descending
                          select c).FirstOrDefault();
                if (cn == null)
                    return "0";
                return cn.AdminNo.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "0";
            }
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsStudentValid())
            {
                try
                {
                    Student s = new Student();
                    if (cboSchool.SelectedIndex != -1)
                    {
                        s.SchoolId = int.Parse(cboSchool.SelectedValue.ToString());
                    }
                    if (cboCurrentClass.SelectedIndex != -1)
                    {
                        s.ClassStreamId = int.Parse(cboCurrentClass.SelectedValue.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtAdminNo.Text))
                    {
                        s.AdminNo = Utils.ConvertFirstLetterToUpper(txtAdminNo.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtSurname.Text))
                    {
                        s.StudentSurName = Utils.ConvertFirstLetterToUpper(txtSurname.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtOtherNames.Text))
                    {
                        s.StudentOtherNames = Utils.ConvertFirstLetterToUpper(txtOtherNames.Text.ToString().Trim());
                    }
                    if (cboGender.SelectedIndex != -1)
                    {
                        s.Gender = cboGender.SelectedValue.ToString();
                    }
                    if (dpDOB.Value != null)
                    {
                        s.DateOfBirth = dpDOB.Value;
                    }
                    if (!string.IsNullOrEmpty(txtPhone.Text))
                    {
                        s.Phone = txtPhone.Text.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        s.Email = txtEmail.Text.ToString().ToLower().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtHomePage.Text))
                    {
                        s.Homepage = txtHomePage.Text.ToString().ToLower().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtAddress.Text))
                    {
                        s.StudentAddress = Utils.ConvertFirstLetterToUpper(txtAddress.Text.ToString().Trim());
                    }
                    if (cboStudentAdmissionType.SelectedIndex != -1)
                    {
                        s.AdmissionType = cboStudentAdmissionType.SelectedValue.ToString();
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        s.Status = cboStatus.SelectedValue.ToString();
                    }
                    int kcpe;
                    if (!string.IsNullOrEmpty(txtKCPE.Text) && int.TryParse(txtKCPE.Text, out kcpe))
                    {
                        s.KCPE = txtKCPE.Text;
                    }
                    if (!string.IsNullOrEmpty(txtAdmittedBy.Text))
                    {
                        s.AdmittedBy = Utils.ConvertFirstLetterToUpper(txtAdmittedBy.Text.ToString().Trim());
                    }
                    if (dpAdmissionDate.Value != null)
                    {
                        s.AdmissionDate = dpAdmissionDate.Value;
                    }
                    if (!string.IsNullOrEmpty(txtRemarks.Text))
                    {
                        s.Remarks = Utils.ConvertFirstLetterToUpper(txtRemarks.Text.Trim());
                    }
                    if (imgStudentPhoto.ImageLocation != null)
                    {
                        s.Photo = imgStudentPhoto.ImageLocation.ToString().Trim();
                    }
                    s.LastModifiedTime = DateTime.Now;
                    s.IsDeleted = false;
                    s.TransportChargeType = "N";
                    s.FeesPayPlan = "C";

                    if (db.Students.Any(i => i.AdminNo == s.AdminNo && i.StudentSurName == s.StudentSurName && s.StudentOtherNames == s.StudentOtherNames))
                    {
                        MessageBox.Show("Student with AdmiNo " + s.AdminNo + " and Name " + s.StudentSurName + " " + s.StudentOtherNames + " Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Students.Any(i => i.AdminNo == s.AdminNo && i.StudentSurName == s.StudentSurName && s.StudentOtherNames == s.StudentOtherNames))
                    {
                        db.Students.AddObject(s);
                        db.SaveChanges();

                        StudentsForm f = (StudentsForm)this.Owner;
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
        public bool IsStudentValid()
        {
            bool noerror = true;

            if (cboSchool.SelectedIndex == -1)
            {
                errorProvider1.Clear(); //Clear all Error Messages
                errorProvider1.SetError(cboSchool, "Select School!");
                return false;
            }
            if (cboCurrentClass.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCurrentClass, "Select Class Stream!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAdminNo.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAdminNo, "Admission Number cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSurname, "Surname cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtOtherNames.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtOtherNames, "Other Names cannot be null!");
                return false;
            }
            if (cboGender.SelectedIndex == -1)
            {
                errorProvider1.Clear(); //Clear all Error Messages
                errorProvider1.SetError(cboGender, "Select Gender!");
                return false;
            }
            DateTime _dob = dpDOB.Value;
            DateTime _today = DateTime.Now;
            if (_dob >= _today)
            {
                errorProvider1.Clear(); //Clear all Error Messages
                errorProvider1.SetError(dpDOB, "Date of Birth must be Less than Today!");
                return false;
            }

            DateTime _AdmissionDate = dpAdmissionDate.Value;
            DateTime _DOB = dpDOB.Value;
            if (_AdmissionDate <= _DOB)
            {
                errorProvider1.Clear(); //Clear all Error Messages
                errorProvider1.SetError(dpAdmissionDate, "Admission Date must be greater than Date of Birth!");
                return false;
            }
            return noerror;
        }
        
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUploadPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Title = "select an Image File";

            openFileDialog1.Filter = "Image File (*.jpg)|*.jpg|Image File (*.gif)|*.gif|Image File (*.png)|*.png|All files (*.*)|*.*";

            openFileDialog1.ShowDialog();

            string strFileName = openFileDialog1.FileName;

            try
            {
                UploadStudentPhoto(strFileName);
                MessageBox.Show("Upload completed successfully", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during upload." + Environment.NewLine + "Error details are:  " + ex.Message, "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("Upload incomplete", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void UploadStudentPhoto(string strFileName)
        {

            string strFileType = System.IO.Path.GetExtension(strFileName).ToString().ToLower();

            //check file exists
            if (!System.IO.File.Exists(strFileName))
            {
                MessageBox.Show("Error Loading Photo." + Environment.NewLine + " File Does not Exist!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Check file type
            if (strFileType != ".jpg" && strFileType != ".gif" && strFileType != ".png")
            {
                throw new Exception("File Type not Image");
            }

            //display  image
            if (strFileType.Trim() == ".jpg")
            {
                imgStudentPhoto.ImageLocation = strFileName;
            }
            else if (strFileType.Trim() == ".gif")
            {
                imgStudentPhoto.ImageLocation = strFileName;
            }
            else if (strFileType.Trim() == ".png")
            {
                imgStudentPhoto.ImageLocation = strFileName;
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtKCPE_KeyDown(object sender, KeyEventArgs e)
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

        private void txtKCPE_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void dpDOB_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int datetoday = DateTime.Today.Year;
                int selecteddate = dpDOB.Value.Year;
                int noofyrs = datetoday - selecteddate;
                lblNoofYears.Text = noofyrs.ToString() + "  Years";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



    }
}