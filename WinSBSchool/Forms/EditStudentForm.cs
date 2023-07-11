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
    public partial class EditStudentForm : Form
    {
        Repository rep;
        DAL.Student s;
        string connection;
        SBSchoolDBEntities db;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        string user;

        public EditStudentForm(DAL.Student student, string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            s = student;
            user = _user;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void ComputeBookBalanceTotal()
        {
            try
            {
                decimal BookBalanceAmount = 0;
                foreach (DataGridViewRow row in dataGridViewStudentAccounts.Rows)
                {
                    decimal rate = 0;
                    if (row.Cells["ColumnAccountBookBalance"].Value != null)
                    {
                        rate = (decimal)row.Cells["ColumnAccountBookBalance"].Value;
                    }
                    BookBalanceAmount += rate;
                }
                lblBookBalance.Text = BookBalanceAmount.ToString("C2");
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            errorProvider1.Clear();
            if (IsStudentValid())
            {
                try
                {

                    #region "Personal Info"
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
                        s.StudentSurName = Utils.ConvertFirstLetterToUpper(txtSurname.Text.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtOtherNames.Text))
                    {
                        s.StudentOtherNames = Utils.ConvertFirstLetterToUpper(txtOtherNames.Text.ToString());
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
                        s.AdmittedBy = Utils.ConvertFirstLetterToUpper(txtAdmittedBy.Text.ToString());
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
                    #endregion "Personal Info"

                    #region "Parents Info"
                    if (!string.IsNullOrEmpty(txtFatherName.Text))
                    {
                        s.FatherName = Utils.ConvertFirstLetterToUpper(txtFatherName.Text.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtFatherCellPhone.Text))
                    {
                        s.FatherCellPhone = txtFatherCellPhone.Text.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtFatherOfficePhone.Text))
                    {
                        s.FatherOfficePhone = txtFatherOfficePhone.Text.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtFatherEmail.Text))
                    {
                        s.FatherEmail = txtFatherEmail.Text.ToString().ToLower().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtMotherName.Text))
                    {
                        s.MotherName = Utils.ConvertFirstLetterToUpper(txtMotherName.Text.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtMotherCellPhone.Text))
                    {
                        s.MotherCellPhone = txtMotherCellPhone.Text.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtMotherOfficePhone.Text))
                    {
                        s.MotherOfficePhone = txtMotherOfficePhone.Text.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtMotherEmail.Text))
                    {
                        s.MotherEmail = txtMotherEmail.Text.Trim().ToLower();
                    }
                    if (!string.IsNullOrEmpty(txtGuardianName.Text))
                    {
                        s.GuardianName = Utils.ConvertFirstLetterToUpper(txtGuardianName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtGuardianCellphone.Text))
                    {
                        s.GuardianCellPhone = txtGuardianCellphone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtGuardianOfficePhone.Text))
                    {
                        s.GuardianOfficePhone = txtGuardianOfficePhone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtGuardianEmail.Text))
                    {
                        s.GuardianEmail = txtGuardianEmail.Text.Trim().ToLower();
                    }
                    #endregion "Parents Info"

                    #region "Fees Payment Plan"  
                    if (cboFeesPaymentPlan.SelectedIndex != -1)
                    {
                        s.FeesPayPlan = cboFeesPaymentPlan.SelectedValue.ToString();
                    } 
                    #endregion "Fees Payment Plan"

                    #region "Previous School Info"
                    if (!string.IsNullOrEmpty(txtPreviousSchoolID.Text))
                    {
                        s.PrevSchoolId = txtPreviousSchoolID.Text.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtPreviousSchoolName.Text))
                    {
                        s.PrevSchoolName = Utils.ConvertFirstLetterToUpper(txtPreviousSchoolName.Text.ToString().Trim());
                    }
                    if (!string.IsNullOrEmpty(txtPreviousSchoolPhone.Text))
                    {
                        s.PrevSchoolPhone = txtPreviousSchoolPhone.Text.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtPreviousSchoolAddress.Text))
                    {
                        s.PrevSchoolAddress = txtPreviousSchoolAddress.Text.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtReasonforLeaving.Text))
                    {
                        s.ReasonForLeaving = txtReasonforLeaving.Text.ToString().Trim();
                    }
                    #endregion "Previous School Info"

                    #region "ExtraCurricular"
                    if (!string.IsNullOrEmpty(txtExtraCurricular1.Text))
                    {
                        s.ExtraCurricular1 = Utils.ConvertFirstLetterToUpper(txtExtraCurricular1.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtExtraCurricular2.Text))
                    {
                        s.ExtraCurricular2 = Utils.ConvertFirstLetterToUpper(txtExtraCurricular2.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtExtraCurricular3.Text))
                    {
                        s.ExtraCurricular3 = Utils.ConvertFirstLetterToUpper(txtExtraCurricular3.Text.Trim());
                    }
                    #endregion "ExtraCurricular"

                    #region "Residence"
                    s.Boarder = chkBoarder.Checked;
                    s.RequireTransport = chkRequireTransport.Checked;
                    if (cboTransportLocations.SelectedIndex != -1)
                    {
                        s.ResidenceId = int.Parse(cboTransportLocations.SelectedValue.ToString());
                    }
                    if (cboBoardingLocations.SelectedIndex != -1)
                    {
                        s.ResidenceHallRoomId = int.Parse(cboBoardingLocations.SelectedValue.ToString());
                    }
                    if (chkRequireTransport.Checked)
                    {
                        s.TransportChargeType = "B"; 
                    }
                    if (chkBoarder.Checked)
                    {
                        s.TransportChargeType = "T";
                    }
                    if (!chkBoarder.Checked && !chkRequireTransport.Checked)
                    {
                        s.TransportChargeType = "N";
                    }
                    #endregion "Residence"

                    #region "Special Needs"
                    if (!string.IsNullOrEmpty(txtDoctorName.Text))
                    {
                        s.DoctorName = Utils.ConvertFirstLetterToUpper(txtDoctorName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtAilment.Text))
                    {
                        s.Ailments = Utils.ConvertFirstLetterToUpper(txtAilment.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtFoods.Text))
                    {
                        s.Foods = Utils.ConvertFirstLetterToUpper(txtFoods.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtAllergy.Text))
                    {
                        s.Allergies = Utils.ConvertFirstLetterToUpper(txtAllergy.Text.Trim());
                    }
                    #endregion "Special Needs"

                    #region "Disciplinary"

                    #endregion "Disciplinary"

                    rep.UpdateStudent(s);

                    if (this.Owner is StudentsForm && this.Owner != null)
                    {
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
        private void InitializeControls()
        {
            try
            {
                #region "Personal Info"
                if (s.SchoolId != null)
                {
                    cboSchool.SelectedValue = s.SchoolId;
                }
                if (s.ClassStreamId != null)
                {
                    cboCurrentClass.SelectedValue = s.ClassStreamId;
                }
                if (s.AdminNo != null)
                {
                    txtAdminNo.Text = s.AdminNo.Trim();
                }
                if (s.AdminNo == null)
                {
                    string _AdminNo = Utils.NextSeries(NextAdminNo());
                    txtAdminNo.Text = _AdminNo;
                }
                if (s.StudentSurName != null)
                {
                    txtSurname.Text = s.StudentSurName.Trim();
                }
                if (s.StudentSurName != null)
                {
                    txtOtherNames.Text = s.StudentOtherNames.Trim();
                }
                if (s.Gender != null)
                {
                    cboGender.SelectedValue = s.Gender;
                }
                if (s.DateOfBirth != null)
                {
                    dpDOB.Value = DateTime.Parse(s.DateOfBirth.ToString());
                }
                if (s.Phone != null)
                {
                    txtPhone.Text = s.Phone.Trim();
                }
                if (s.Email != null)
                {
                    txtEmail.Text = s.Email.Trim();
                }
                if (s.Homepage != null)
                {
                    txtHomePage.Text = s.Homepage.Trim();
                }
                if (s.StudentAddress != null)
                {
                    txtAddress.Text = s.StudentAddress.Trim();
                }
                if (s.AdmissionType != null)
                {
                    cboStudentAdmissionType.SelectedValue = s.AdmissionType.Trim();
                }
                if (s.Status != null)
                {
                    cboStatus.SelectedValue = s.Status.Trim();
                }
                if (s.KCPE != null)
                {
                    txtKCPE.Text = s.KCPE.ToString().Trim();
                }
                if (s.AdmissionDate != null)
                {
                    dpAdmissionDate.Value = DateTime.Parse(s.AdmissionDate.ToString());
                }
                if (s.AdmittedBy != null)
                {
                    txtAdmittedBy.Text = s.AdmittedBy.Trim();
                }
                if (s.Remarks != null)
                {
                    txtRemarks.Text = s.Remarks.Trim();
                }
                if (s.Photo != null)
                {
                    imgStudentPhoto.ImageLocation = s.Photo.ToString().Trim();
                }
                #endregion "Personal Info"

                #region "Parents Info"
                if (s.FatherName != null)
                {
                    txtFatherName.Text = s.FatherName.Trim();
                }
                if (s.FatherCellPhone != null)
                {
                    txtFatherCellPhone.Text = s.FatherCellPhone.Trim();
                }
                if (s.FatherOfficePhone != null)
                {
                    txtFatherOfficePhone.Text = s.FatherOfficePhone.Trim();
                }
                if (s.FatherEmail != null)
                {
                    txtFatherEmail.Text = s.FatherEmail.Trim();
                }
                if (s.MotherName != null)
                {
                    txtMotherName.Text = s.MotherName.Trim();
                }
                if (s.MotherCellPhone != null)
                {
                    txtMotherCellPhone.Text = s.MotherCellPhone.Trim();
                }
                if (s.MotherOfficePhone != null)
                {
                    txtMotherOfficePhone.Text = s.MotherOfficePhone.Trim();
                }
                if (s.MotherEmail != null)
                {
                    txtMotherEmail.Text = s.MotherEmail.Trim();
                }
                if (s.GuardianName != null)
                {
                    txtGuardianName.Text = s.GuardianName.Trim();
                }
                if (s.GuardianCellPhone != null)
                {
                    txtGuardianCellphone.Text = s.GuardianCellPhone.Trim();
                }
                if (s.GuardianOfficePhone != null)
                {
                    txtGuardianOfficePhone.Text = s.GuardianOfficePhone.Trim();
                }
                if (s.GuardianEmail != null)
                {
                    txtGuardianEmail.Text = s.GuardianEmail.Trim();
                }
                #endregion "Parents Info"

                #region "Fees Payment Plan"
                if (s.FeesPayPlan != null)
                {
                    cboFeesPaymentPlan.SelectedValue = s.FeesPayPlan.Trim();
                }
                #endregion "Fees Payment Plan"

                #region "Previous School Info"
                if (s.PrevSchoolId != null)
                {
                    txtPreviousSchoolID.Text = s.PrevSchoolId.Trim();
                }
                if (s.PrevSchoolName != null)
                {
                    txtPreviousSchoolName.Text = s.PrevSchoolName.Trim();
                }
                if (s.PrevSchoolPhone != null)
                {
                    txtPreviousSchoolPhone.Text = s.PrevSchoolPhone.Trim();
                }
                if (s.PrevSchoolAddress != null)
                {
                    txtPreviousSchoolAddress.Text = s.PrevSchoolAddress.Trim();
                }
                if (s.ReasonForLeaving != null)
                {
                    txtReasonforLeaving.Text = s.ReasonForLeaving.Trim();
                }
                #endregion "Previous School Info"

                #region "Extra Curricular"
                if (s.ExtraCurricular1 != null)
                {
                    txtExtraCurricular1.Text = s.ExtraCurricular1.Trim();
                }
                if (s.ExtraCurricular2 != null)
                {
                    txtExtraCurricular2.Text = s.ExtraCurricular2.Trim();
                }
                if (s.ExtraCurricular3 != null)
                {
                    txtExtraCurricular3.Text = s.ExtraCurricular3.Trim();
                }
                #endregion "Extra Curricular"

                #region "Residence"
                if (s.Boarder != null)
                {
                    chkBoarder.Checked = s.Boarder ?? false;
                }
                if (s.RequireTransport != null)
                {
                    chkRequireTransport.Checked = s.RequireTransport ?? false;
                }
                if (s.ResidenceId != null)
                {
                    cboTransportLocations.SelectedValue = s.ResidenceId;
                }
                if (s.ResidenceHallRoomId != null)
                {
                    cboBoardingLocations.SelectedValue = s.ResidenceHallRoomId;
                }
                #endregion "Residence"

                #region "Accounts"
                if (s.CustomerId != null)
                {
                    lbCustomerId.Text = s.CustomerId.ToString();
                }
                if (s.GLAccountId != null)
                {
                    lblAccountId.Text = s.GLAccountId.ToString();
                }
                #endregion "Accounts"

                #region "Special Needs"
                if (s.DoctorName != null)
                {
                    txtDoctorName.Text = s.DoctorName.Trim();
                }
                if (s.Ailments != null)
                {
                    txtAilment.Text = s.Ailments.Trim();
                }
                if (s.Foods != null)
                {
                    txtFoods.Text = s.Foods.Trim();
                }
                if (s.Allergies != null)
                {
                    txtAllergy.Text = s.Allergies.Trim();
                }
                #endregion "Special Needs"
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                btnFatherSendEmail.Enabled = false;
                btnFatherSendSms.Enabled = false;
                btnGuardianSendEmail.Enabled = false;
                btnGuardianSendSms.Enabled = false;
                btnMotherSendEmail.Enabled = false;
                btnMotherSendSms.Enabled = false;

                btnFatherSendEmail.Visible = false;
                btnFatherSendSms.Visible = false;
                btnGuardianSendEmail.Visible = false;
                btnGuardianSendSms.Visible = false;
                btnMotherSendEmail.Visible = false;
                btnMotherSendSms.Visible = false;

                imgStudentPhoto.MouseHover += new EventHandler(pBStudentPhoto_MouseHover);
                imgStudentPhoto.MouseLeave += new EventHandler(pBStudentPhoto_MouseLeave);
                imgStudentPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                dataGridViewStudentAccounts.Columns[1].Name = "ColumnAccountBookBalance";

                lblBoardingCost.Text = string.Empty;
                lblTransportCost.Text = string.Empty;
                lblNoofYears.Text = string.Empty;

                var _Schlsquery = from sl in db.Schools
                                  where sl.Status == "A"
                                  where sl.IsDeleted == false
                                  select sl;
                List<School> schools = _Schlsquery.ToList();
                cboSchool.DataSource = schools;
                cboSchool.ValueMember = "Id";
                cboSchool.DisplayMember = "SchoolName";
                cboSchool.SelectedIndex = -1;

                var _Locationquery = from rhr in db.Locations
                                     where rhr.IsDeleted == false
                                     select rhr;
                List<Location> _Locations = _Locationquery.ToList();
                cboBoardingLocations.DataSource = _Locations;
                cboBoardingLocations.ValueMember = "Id";
                cboBoardingLocations.DisplayMember = "Description";
                cboBoardingLocations.SelectedIndex = -1;

                var _Locationsquery = from rd in db.Locations
                                      where rd.IsDeleted == false
                                      select rd;
                List<Location> _locations = _Locationsquery.ToList();
                cboTransportLocations.DataSource = _locations;
                cboTransportLocations.ValueMember = "Id";
                cboTransportLocations.DisplayMember = "Description";
                cboTransportLocations.SelectedIndex = -1;

                var _ClssStrmquery = from cs in db.ClassStreams
                                     where cs.IsDeleted == false
                                     orderby cs.Description ascending
                                     select cs;
                List<ClassStream> _ClassStreams = _ClssStrmquery.ToList();
                cboCurrentClass.DataSource = _ClassStreams;
                cboCurrentClass.ValueMember = "Id";
                cboCurrentClass.DisplayMember = "Description";
                cboCurrentClass.SelectedIndex = -1;

                //Gender Combox
                var gender = new BindingList<KeyValuePair<string, string>>();
                gender.Add(new KeyValuePair<string, string>("M", "Male"));
                gender.Add(new KeyValuePair<string, string>("F", "Female"));
                cboGender.DataSource = gender;
                cboGender.ValueMember = "Key";
                cboGender.DisplayMember = "Value";
                cboGender.SelectedIndex = -1;

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";
                cboStatus.SelectedIndex = -1;

                var _feesPaymentPlan = new BindingList<KeyValuePair<string, string>>();
                _feesPaymentPlan.Add(new KeyValuePair<string, string>("C", "Cash"));
                _feesPaymentPlan.Add(new KeyValuePair<string, string>("M", "Mpesa"));
                _feesPaymentPlan.Add(new KeyValuePair<string, string>("Q", "Cheque"));
                _feesPaymentPlan.Add(new KeyValuePair<string, string>("B", "Bank Slip"));
                cboFeesPaymentPlan.DataSource = _feesPaymentPlan;
                cboFeesPaymentPlan.ValueMember = "Key";
                cboFeesPaymentPlan.DisplayMember = "Value";
                cboFeesPaymentPlan.SelectedIndex = -1;

                var AdmissionType = new BindingList<KeyValuePair<string, string>>();
                AdmissionType.Add(new KeyValuePair<string, string>("N", "New Admission"));
                AdmissionType.Add(new KeyValuePair<string, string>("T", "Transfer"));
                cboStudentAdmissionType.DataSource = AdmissionType;
                cboStudentAdmissionType.ValueMember = "Key";
                cboStudentAdmissionType.DisplayMember = "Value";
                cboStudentAdmissionType.SelectedIndex = -1;

                dataGridViewStudentAccounts.AutoGenerateColumns = false;
                dataGridViewStudentAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewStudentAccounts.DataSource = bindingSourceStudentAccounts;

                var _dscplnryctgrs = from dc in db.DisciplinaryCategories
                                     where dc.Status == "A"
                                     where dc.IsDeleted == false
                                     select dc;
                List<DisciplinaryCategory> _disciplinarycategories = _dscplnryctgrs.ToList();
                bindingSourceDisciplinaryCategories.DataSource = _disciplinarycategories;
                DataGridViewComboBoxColumn colDisciplinaryCategory = new DataGridViewComboBoxColumn();
                colDisciplinaryCategory.HeaderText = "Disciplinary Category";
                colDisciplinaryCategory.Name = "cbDisciplinaryCategory";
                colDisciplinaryCategory.DataSource = bindingSourceDisciplinaryCategories;
                colDisciplinaryCategory.DisplayMember = "Description";
                colDisciplinaryCategory.DataPropertyName = "DisciplineCategoryId";
                colDisciplinaryCategory.ValueMember = "Id";
                colDisciplinaryCategory.MaxDropDownItems = 10;
                colDisciplinaryCategory.DisplayIndex = 1;
                colDisciplinaryCategory.MinimumWidth = 5;
                colDisciplinaryCategory.Width = 150;
                colDisciplinaryCategory.FlatStyle = FlatStyle.Flat;
                colDisciplinaryCategory.DefaultCellStyle.NullValue = "--- Select ---";
                colDisciplinaryCategory.ReadOnly = true;
                if (!this.dataGridViewDispline.Columns.Contains("cbDisciplinaryCategory"))
                {
                    dataGridViewDispline.Columns.Add(colDisciplinaryCategory);
                }

                var _AccountTypesquery = from dc in db.AccountTypes
                                         where dc.Status == "A"
                                         where dc.IsDeleted == false
                                         select dc;
                List<AccountType> _AccountTypes = _AccountTypesquery.ToList();
                DataGridViewComboBoxColumn colAccountType = new DataGridViewComboBoxColumn();
                colAccountType.HeaderText = "Account Type";
                colAccountType.Name = "cbAccountType";
                colAccountType.DataSource = _AccountTypes;
                colAccountType.DisplayMember = "Description";
                colAccountType.DataPropertyName = "AccountTypeId";
                colAccountType.ValueMember = "Id";
                colAccountType.MaxDropDownItems = 10;
                colAccountType.DisplayIndex = 2;
                colAccountType.MinimumWidth = 5;
                colAccountType.Width = 150;
                colAccountType.FlatStyle = FlatStyle.Flat;
                colAccountType.DefaultCellStyle.NullValue = "--- Select ---";
                colAccountType.ReadOnly = true;
                if (!this.dataGridViewStudentAccounts.Columns.Contains("cbAccountType"))
                {
                    dataGridViewStudentAccounts.Columns.Add(colAccountType);
                }

                var _Dsplns = from dp in db.Disciplines
                              where dp.StudentId == s.Id
                              where dp.IsDeleted == false
                              select dp;
                List<Discipline> _Disciplines = _Dsplns.ToList();
                bindingSourceDisplines.DataSource = _Disciplines;

                dataGridViewDispline.AutoGenerateColumns = false;
                dataGridViewDispline.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewDispline.DataSource = bindingSourceDisplines;

                InitializeControls();

                int glacc;
                if (s.GLAccountId != null)
                {
                    glacc = s.GLAccountId ?? 0;
                    var _studentAccountquery = (from ac in db.Accounts
                                                where ac.Id == glacc
                                                where ac.Closed == false
                                                where ac.IsDeleted == false
                                                select ac).FirstOrDefault();
                    Account stdAccount = _studentAccountquery;
                    bindingSourceStudentAccounts.DataSource = stdAccount;
                    lblBookBalance.Text = stdAccount.BookBalance.ToString("C2");
                }

                chkRequireTransport.CheckedChanged += new EventHandler(chkRequireTransport_CheckedChanged);
                chkBoarder.CheckedChanged += new EventHandler(chkBoarder_CheckedChanged);

                if (s.RequireTransport ?? false)
                {
                    groupBoxResidenceTransport.Enabled = true;
                }
                else
                {
                    groupBoxResidenceTransport.Enabled = false;
                }

                if (s.Boarder ?? false)
                {
                    groupBoxResidenceBorder.Enabled = true;
                }
                else
                {
                    groupBoxResidenceBorder.Enabled = false;
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void pBStudentPhoto_MouseHover(object sender, EventArgs e)
        {
            //setting a border when it is moused over
            ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
        }
        private void pBStudentPhoto_MouseLeave(object sender, EventArgs e)
        {
            //removing the border when the mouse leaves it
            ((PictureBox)sender).BorderStyle = BorderStyle.None;
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
                errorProvider1.SetError(cboCurrentClass, "Select Class!");
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
                errorProvider1.SetError(txtSurname, "Student Surname cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtOtherNames.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtOtherNames, "Student Other Names cannot be null!");
                return false;
            }
            if (cboGender.SelectedIndex == -1)
            {
                errorProvider1.Clear(); //Clear all Error Messages
                errorProvider1.SetError(cboGender, "Select Gender!");
                return false;
            }
            DateTime _dob = dpDOB.Value;
            DateTime _today = DateTime.Today;
            if (_today <= _dob)
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
        private void btnCreateCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int customerId;
                if (int.TryParse(lbCustomerId.Text, out customerId))
                {
                    MessageBox.Show("Customer Exists!", "SB School");
                }
                else
                {
                    AddNewCustomerForm ancf = new AddNewCustomerForm(s, connection) { Owner = this };
                    ancf.Show();
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
                if (this.Owner is StudentsForm)
                {
                    StudentsForm f = (StudentsForm)this.Owner;
                    f.CloseForm();
                    this.Close();
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
                //set the datasource to null
                bindingSourceStudentAccounts.DataSource = null;
                //set the datasource to a method
                int glacc;
                if (s.GLAccountId != null)
                {
                    glacc = s.GLAccountId ?? 0;
                    var _studentAccountquery = (from ac in db.Accounts
                                                where ac.Id == glacc
                                                where ac.Closed == false
                                                where ac.IsDeleted == false
                                                select ac).FirstOrDefault();
                    Account stdAccount = _studentAccountquery;
                    bindingSourceStudentAccounts.DataSource = stdAccount;
                    lblBookBalance.Text = stdAccount.BookBalance.ToString("C2");
                    lblAccountId.Text = stdAccount.Id.ToString();
                }
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);

            }
        }
        /*public method to diable all controls when form is called by parent from 'View Details' button*/
        public void DisableControls()
        {
            #region "Personal Info"
            cboSchool.Enabled = false;
            cboCurrentClass.Enabled = false;
            txtAdminNo.Enabled = false;
            txtSurname.Enabled = false;
            txtOtherNames.Enabled = false;
            cboGender.Enabled = false;
            dpDOB.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtHomePage.Enabled = false;
            txtAddress.Enabled = false;
            cboStudentAdmissionType.Enabled = false;
            cboStatus.Enabled = false;
            btnUploadPhoto.Enabled = false;
            imgStudentPhoto.Enabled = false;
            txtKCPE.Enabled = false;
            dpAdmissionDate.Enabled = false;
            txtAdmittedBy.Enabled = false;
            txtRemarks.Enabled = false;
            #endregion "Personal Info"

            #region "Accounts"
            dataGridViewStudentAccounts.Enabled = false;
            btnCreateAccount.Enabled = false;
            btnCreateCustomer.Enabled = false;
            #endregion "Accounts"

            #region "Parents Info"
            txtFatherName.Enabled = false;
            txtFatherCellPhone.Enabled = false;
            txtFatherOfficePhone.Enabled = false;
            txtFatherEmail.Enabled = false;
            txtMotherName.Enabled = false;
            txtMotherCellPhone.Enabled = false;
            txtMotherOfficePhone.Enabled = false;
            txtMotherEmail.Enabled = false;
            txtGuardianName.Enabled = false;
            txtGuardianCellphone.Enabled = false;
            txtGuardianOfficePhone.Enabled = false;
            txtGuardianEmail.Enabled = false;
            #endregion "Parents Info"

            #region "Previous School Info"
            txtPreviousSchoolID.Enabled = false;
            txtPreviousSchoolName.Enabled = false;
            txtPreviousSchoolPhone.Enabled = false;
            txtPreviousSchoolAddress.Enabled = false;
            txtReasonforLeaving.Enabled = false;
            #endregion "Previous School Info"

            #region "Extra Curricular"
            txtExtraCurricular1.Enabled = false;
            txtExtraCurricular2.Enabled = false;
            txtExtraCurricular3.Enabled = false;
            #endregion "Extra Curricular"

            #region "Residence"
            chkBoarder.Enabled = false;
            chkRequireTransport.Enabled = false;
            cboTransportLocations.Enabled = false;
            cboBoardingLocations.Enabled = false;
            #endregion "Residence"

            #region "Special Needs"
            txtDoctorName.Enabled = false;
            txtAilment.Enabled = false;
            txtFoods.Enabled = false;
            txtAllergy.Enabled = false;
            #endregion "Special Needs"

            #region "Discipline"
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnViewDetails.Enabled = false;
            btnDelete.Enabled = false;
            dataGridViewDispline.Enabled = false;
            #endregion "Discipline"

            btnCreateSAccounts.Enabled = false;
            btnCreateSCustomer.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;
        }
        private void btnCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int customerId;
                int _AccountId;
                if (int.TryParse(lblAccountId.Text, out _AccountId))
                {
                    MessageBox.Show("Account Exists!", "SB School");
                }
                else if (int.TryParse(lbCustomerId.Text, out customerId))
                {
                    AddAccountForm aaf = new AddAccountForm(customerId, s, connection) { Owner = this };
                    aaf.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Create a Customer first before Creating an Account", "SB School");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkBoarder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoarder.Checked)
            {
                groupBoxResidenceBorder.Enabled = true;
            }
            else
            {
                groupBoxResidenceBorder.Enabled = false;
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewDispline.SelectedRows.Count != 0)
            {
                try
                {
                    Discipline displine = (Discipline)bindingSourceDisplines.Current;

                    rep.DeleteDiscipline(displine);

                    this.RefreshDisplinesGrid();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddStudentDisplineForm f = new AddStudentDisplineForm(s, connection) { Owner = this };
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshDisplinesGrid()
        {
            try
            {
                bindingSourceDisplines.DataSource = null;
                var _Dsplns = from dp in db.Disciplines
                              where dp.IsDeleted == false
                              where dp.StudentId == s.Id
                              select dp;
                List<Discipline> _Disciplines = _Dsplns.ToList();
                bindingSourceDisplines.DataSource = _Disciplines;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkRequireTransport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRequireTransport.Checked)
            {
                groupBoxResidenceTransport.Enabled = true;
            }
            else
            {
                groupBoxResidenceTransport.Enabled = false;
            }
        }
        private void cboBoardingLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblBoardingCost.Text = string.Empty;
            if (cboBoardingLocations.SelectedIndex != -1)
            {
                DAL.Location loc = (DAL.Location)cboBoardingLocations.SelectedItem;
                if (loc.BoardingCost != null)
                {
                    lblBoardingCost.Text = "Boarding Cost: " + loc.BoardingCost.ToString();
                }
            }
        }
        private void cboLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTransportCost.Text = string.Empty;
            if (cboTransportLocations.SelectedIndex != -1)
            {
                DAL.Location loc = (DAL.Location)cboTransportLocations.SelectedItem;
                if (loc.TransportCost != null)
                {
                    lblTransportCost.Text = "Transport Cost: " + loc.TransportCost.ToString();
                }
            }
        }
        private void dataGridViewStudentAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudentAccounts.SelectedRows.Count != 0)
            {
                try
                {
                    Account _Account = (Account)bindingSourceStudentAccounts.Current;
                    WinSBSchool.Reports.Views.Screen.EnquiryViewForm f = new WinSBSchool.Reports.Views.Screen.EnquiryViewForm(_Account, user, connection);
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
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
                MessageBox.Show("Upload completed successfully");
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
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewDispline.SelectedRows.Count != 0)
            {
                try
                {
                    Discipline _Discipline = (Discipline)bindingSourceDisplines.Current;
                    EditStudentDisciplineForm f = new EditStudentDisciplineForm(s, _Discipline, connection) { Owner = this };
                    f.Text = _Discipline.Incident.Trim().ToUpper();
                    f.DisableControls();
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewStudentAccounts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewDispline.SelectedRows.Count != 0)
            {
                try
                {
                    Discipline _Discipline = (Discipline)bindingSourceDisplines.Current;
                    EditStudentDisciplineForm f = new EditStudentDisciplineForm(s, _Discipline, connection) { Owner = this };
                    f.Text = _Discipline.Incident.Trim().ToUpper();
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewDispline_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDispline.SelectedRows.Count != 0)
            {
                try
                {
                    Discipline _Discipline = (Discipline)bindingSourceDisplines.Current;
                    EditStudentDisciplineForm f = new EditStudentDisciplineForm(s, _Discipline, connection) { Owner = this };
                    f.Text = _Discipline.Incident.Trim().ToUpper();
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void cboStudentAdmissionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStudentAdmissionType.SelectedIndex != -1)
            {
                switch (cboStudentAdmissionType.SelectedValue.ToString())
                {
                    case "N":
                        tabControl2.TabPages.Remove(tabPagePreviousSchoolDets);
                        break;
                    case "T":
                        tabControl2.TabPages.Add(tabPagePreviousSchoolDets);
                        break;
                    default:
                        tabControl2.TabPages.Remove(tabPagePreviousSchoolDets);
                        break;
                }
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
        private void txtGuardianCellphone_KeyDown(object sender, KeyEventArgs e)
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
        private void txtGuardianCellphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtPreviousSchoolPhone_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPreviousSchoolPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtFatherCellPhone_KeyDown(object sender, KeyEventArgs e)
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

        private void txtFatherCellPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtMotherCellPhone_KeyDown(object sender, KeyEventArgs e)
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
        private void txtMotherCellPhone_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btnFatherSendSms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFatherCellPhone.Text))
                {
                    SendSmsForm sms = new SendSmsForm(txtFatherCellPhone.Text.Trim()) { Owner = this };
                    sms.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnFatherSendEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFatherEmail.Text))
                {
                    SendEmailForm email = new SendEmailForm(txtFatherEmail.Text.Trim()) { Owner = this };
                    email.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnMotherSendSms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMotherCellPhone.Text))
                {
                    SendSmsForm sms = new SendSmsForm(txtMotherCellPhone.Text.Trim()) { Owner = this };
                    sms.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnMotherSendEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMotherEmail.Text))
                {
                    SendEmailForm email = new SendEmailForm(txtMotherEmail.Text.Trim()) { Owner = this };
                    email.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnGuardianSendSms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtGuardianCellphone.Text))
                {
                    SendSmsForm sms = new SendSmsForm(txtGuardianCellphone.Text.Trim()) { Owner = this };
                    sms.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnGuardianSendEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtGuardianEmail.Text))
                {
                    SendEmailForm email = new SendEmailForm(txtGuardianEmail.Text.Trim()) { Owner = this };
                    email.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtFatherEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFatherEmail.Text))
                {
                    btnFatherSendEmail.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtFatherEmail.Text))
                {
                    btnFatherSendEmail.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtFatherCellPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFatherCellPhone.Text))
                {
                    btnFatherSendSms.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtFatherCellPhone.Text))
                {
                    btnFatherSendSms.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtMotherCellPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMotherCellPhone.Text))
                {
                    btnMotherSendSms.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtMotherCellPhone.Text))
                {
                    btnMotherSendSms.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtMotherEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMotherEmail.Text))
                {
                    btnMotherSendEmail.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtMotherEmail.Text))
                {
                    btnMotherSendEmail.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtGuardianCellphone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtGuardianCellphone.Text))
                {
                    btnGuardianSendSms.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtGuardianCellphone.Text))
                {
                    btnGuardianSendSms.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtGuardianEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtGuardianEmail.Text))
                {
                    btnGuardianSendEmail.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtGuardianEmail.Text))
                {
                    btnGuardianSendEmail.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



















    }
}