using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
using System.Data; 
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq; 
using System.Runtime.InteropServices;
using System.Text; 
using System.Windows.Forms; 
using CommonLib; 
using DAL; 
using WinSBSchool.Forms;

namespace WinSBSchool.Forms
{
    public partial class AdmissionForm : Form
    {
        BindingList<Transaction> observableTransactions;
        Repository rep;
        SBSchoolDBEntities db;
        Student _Student = null;
        School school;
        string user;
        double CourseTuitionFee = 0.0;
        string connection;
        private StreamReader streamToPrint;
        private Font printFont;
        TransactionType TType;
        List<Transaction> transactions;
        string receiptNo;
        Account DrAccountBeforePosting;
        Account CreditAccountBeforePosting;
        Account DrAccountAfterPosting;
        Account CrAccountAfterPosting;
        Transaction DebitTransaction;
        Transaction CreditTransaction;
        decimal Amount;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public AdmissionForm(School sch, string _user, string Conn)
        {
            try
            {
                InitializeComponent();

                if (Conn == null)
                    throw new ArgumentNullException("Conn");
                connection = Conn;

                if (sch == null)
                    throw new ArgumentNullException("_school");
                school = sch;

                if (_user == null)
                    throw new ArgumentNullException("user");
                user = _user;

                db = new SBSchoolDBEntities(connection);
                rep = new Repository(connection);

                observableTransactions = new BindingList<Transaction>();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void AdmissionForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblBankChequeDetails.Text = string.Empty;
                lblBankSlipDetails.Text = string.Empty;
                lblBoardingCost.Text = string.Empty;
                lblTransportCost.Text = string.Empty;

                groupBoxCash.Visible = false;
                groupBoxCheque.Visible = false;
                groupBoxMpesa.Visible = false;
                groupBoxBankSlip.Visible = false;

                pBStudentPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                ListViewProgrammeYearCourses.View = View.Details;
                ListViewProgrammeYearCourses.GridLines = true;
                ListViewProgrammeYearCourses.FullRowSelect = true;
                ListViewProgrammeYearCourses.MultiSelect = false;
                ListViewProgrammeYearCourses.CheckBoxes = true;
                ListViewProgrammeYearCourses.HideSelection = false;
                ListViewProgrammeYearCourses.Columns.Add("", "Course", 100);
                ListViewProgrammeYearCourses.Columns.Add("", "NoOfHrs", 100);
                ListViewProgrammeYearCourses.Columns.Add("", "Tuituion Fees", 100);
                ListViewProgrammeYearCourses.Columns.Add("", "Exam Fees", 100);
                ListViewProgrammeYearCourses.Columns.Add("", "Resit Fees", -2);

                ImageList photoList = new ImageList();
                photoList.TransparentColor = Color.Blue;
                photoList.ColorDepth = ColorDepth.Depth32Bit;
                photoList.ImageSize = new Size(10, 10);
                photoList.Images.Add(Image.FromFile("Resources/Signin.jpg"));
                ListViewProgrammeYearCourses.SmallImageList = photoList;

                listViewFeePayments.View = View.Details;
                listViewFeePayments.GridLines = true;
                listViewFeePayments.FullRowSelect = true;
                listViewFeePayments.MultiSelect = false;
                listViewFeePayments.CheckBoxes = false;
                listViewFeePayments.HideSelection = false;
                listViewFeePayments.Columns.Add("", "Description", 100);
                listViewFeePayments.Columns.Add("", "Amount", -2);

                ImageList FeePaymentsphotoList = new ImageList();
                FeePaymentsphotoList.TransparentColor = Color.Blue;
                FeePaymentsphotoList.ColorDepth = ColorDepth.Depth32Bit;
                FeePaymentsphotoList.ImageSize = new Size(10, 10);
                FeePaymentsphotoList.Images.Add(Image.FromFile("Resources/greenmage.jpg"));
                listViewFeePayments.SmallImageList = FeePaymentsphotoList;

                dataGridViewStudentAccounts.Columns[1].Name = "ColumnAccountBookBalance";

                var _Schlsquery = from sl in db.Schools
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

                dataGridViewStudentAccounts.AutoGenerateColumns = false;
                dataGridViewStudentAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewStudentAccounts.DataSource = bindingSourceStudentAccounts;

                var _dscplnryctgrs = from dc in db.DisciplinaryCategories
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

                AutoCompleteStringCollection acsadminno = new AutoCompleteStringCollection();
                acsadminno.AddRange(this.AutoComplete_AdminNos());
                txtAdminNo.AutoCompleteCustomSource = acsadminno;
                txtAdminNo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAdminNo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                chkRequireTransport.CheckedChanged += new EventHandler(chkRequireTransport_CheckedChanged);
                chkBoarder.CheckedChanged += new EventHandler(chkBoarder_CheckedChanged);

                var AdmissionType = new BindingList<KeyValuePair<string, string>>();
                AdmissionType.Add(new KeyValuePair<string, string>("N", "New Admission"));
                AdmissionType.Add(new KeyValuePair<string, string>("T", "Transfer"));
                cboStudentAdmissionType.DataSource = AdmissionType;
                cboStudentAdmissionType.ValueMember = "Key";
                cboStudentAdmissionType.DisplayMember = "Value";
                cboStudentAdmissionType.SelectedIndex = -1;

                tabControlStudentAdmission.TabPages.Remove(tabPageFeesPayment);

                tabControlStudentAdmission.TabPages.Remove(tabPageFeesPaymentPlan);

                btnChargeFees.Enabled = false;
                btnPrintReceipt.Enabled = false;

                var _feesPaymentPlan = new BindingList<KeyValuePair<string, string>>();
                _feesPaymentPlan.Add(new KeyValuePair<string, string>("C", "Cash"));
                _feesPaymentPlan.Add(new KeyValuePair<string, string>("M", "Mpesa"));
                _feesPaymentPlan.Add(new KeyValuePair<string, string>("Q", "Cheque"));
                _feesPaymentPlan.Add(new KeyValuePair<string, string>("B", "Bank Slip"));
                cboFeesPaymentPlan.DataSource = _feesPaymentPlan;
                cboFeesPaymentPlan.ValueMember = "Key";
                cboFeesPaymentPlan.DisplayMember = "Value";
                cboFeesPaymentPlan.SelectedIndex = -1;

                groupBoxResidenceTransport.Enabled = false;
                groupBoxResidenceBorder.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_AdminNos()
        {
            try
            {
                var adminnosquery = from st in db.Students
                                    where st.Status == "A"
                                    where st.IsDeleted == false
                                    select st.AdminNo;
                return adminnosquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void btnChargeTuitionFees_Click(object sender, EventArgs e)
        {
            if (_Student != null)
            {
                try
                { 
                    if (!string.IsNullOrEmpty(txtTutionFees.Text) && _Student != null)
                    {
                        string RawSalt = DateTime.Now.ToString("yMdHms");
                        string HashSalt = HashHelper.CreateRandomSalt();
                        int foundS1 = HashSalt.IndexOf("==");
                        int foundS2 = HashSalt.IndexOf("+");
                        int foundS3 = HashSalt.IndexOf("/");
                        if (foundS1 > 0)
                        {
                            HashSalt = HashSalt.Remove(foundS1);
                        }
                        if (foundS2 > 0)
                        {
                            HashSalt = HashSalt.Remove(foundS2);
                        }
                        if (foundS3 > 0)
                        {
                            HashSalt = HashSalt.Remove(foundS3);
                        }
                        string SaltedHash = RawSalt.Insert(5, HashSalt);
                        string _transRef = SaltedHash;

                        var cls = (from cs in db.ClassStreams
                                   join st in db.Students on cs.Id equals st.ClassStreamId
                                   where st.Id == _Student.Id
                                   where cs.IsDeleted == false
                                   where st.IsDeleted == false
                                   where st.Status == "A"
                                   select cs).FirstOrDefault();
                        ClassStream _ClsStrm = cls;

                        var _SchoolClassesquery = (from sc in db.SchoolClasses
                                                   where sc.IsDeleted == false
                                                   join cs in db.ClassStreams on _Student.ClassStreamId equals cs.Id
                                                   where cs.IsDeleted == false
                                                   where cs.ClassId == sc.Id
                                                   select sc).FirstOrDefault();
                        SchoolClass _SchoolClass = _SchoolClassesquery;

                        var feeStructurequery = (from fs in db.FeesStructures
                                                 where fs.IsDeleted == false
                                                 where fs.IsDefault == true
                                                 select fs).FirstOrDefault();
                        FeesStructure _FeesStructure = feeStructurequery;

                        var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                          where fs.FeeStructureId == _FeesStructure.Id
                                                          where fs.SchoolClassId == _SchoolClass.Id
                                                          where fs.IsDeleted == false
                                                          select fs;
                        List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();

                        var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                                       where fs.FeeStructureId == _FeesStructure.Id
                                                       where fs.IsDeleted == false
                                                       select fs;
                        List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();

                        foreach (FeeStructureAcademic feeStructureAcademic in _FeeStructureAcademics)
                        {
                            //Debit transaction
                            Transaction drtxn = new Transaction();
                            drtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int dracc = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);
                            if (dracc == -1) dracc = int.Parse(rep.SettingLookup("SUSPDR"));
                            drtxn.AccountId = dracc;
                            drtxn.Amount = feeStructureAcademic.Amount * -1;
                            drtxn.UserName = user;
                            drtxn.Authorizer = "SYSTEM";
                            drtxn.StatementFlag = "Debit";
                            drtxn.PostDate = DateTime.Today;
                            drtxn.ValueDate = DateTime.Today;
                            drtxn.RecordDate = DateTime.Today;
                            drtxn.TransRef = _transRef;
                            drtxn.IsDeleted = false;

                            //Credit transaction
                            Transaction crtxn = new Transaction();
                            crtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int cracc = rep.GetAccountIfExists(feeStructureAcademic.AccountId);
                            if (cracc == -1) cracc = int.Parse(rep.SettingLookup("SUSPCR"));
                            crtxn.AccountId = cracc;
                            crtxn.Amount = feeStructureAcademic.Amount;
                            crtxn.Narrative = this.BuildNarrative(_Student, _ClsStrm, _SchoolClass, drtxn.AccountId, drtxn.Amount, feeStructureAcademic.Description, "C");
                            crtxn.UserName = user;
                            crtxn.Authorizer = "SYSTEM";
                            crtxn.StatementFlag = "Credit";
                            crtxn.PostDate = DateTime.Today;
                            crtxn.ValueDate = DateTime.Today;
                            crtxn.RecordDate = DateTime.Today;
                            crtxn.TransRef = _transRef;
                            crtxn.IsDeleted = false;

                            observableTransactions.Add(crtxn);

                            drtxn.Narrative = this.BuildNarrative(_Student, _ClsStrm, _SchoolClass, crtxn.AccountId, crtxn.Amount, feeStructureAcademic.Description, "D");

                            observableTransactions.Add(drtxn);
                        }
                        foreach (FeeStructureOther _feeStructureOther in _FeeStructureOthers)
                        {

                            //Debit transaction
                            Transaction drtxn = new Transaction();
                            drtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int dracc = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);
                            if (dracc == -1) dracc = int.Parse(rep.SettingLookup("SUSPDR"));
                            drtxn.AccountId = dracc;
                            drtxn.Amount = _feeStructureOther.Amount * -1;
                            drtxn.UserName = user;
                            drtxn.Authorizer = "SYSTEM";
                            drtxn.StatementFlag = "Debit";
                            drtxn.PostDate = DateTime.Today;
                            drtxn.ValueDate = DateTime.Today;
                            drtxn.RecordDate = DateTime.Today;
                            drtxn.TransRef = _transRef;
                            drtxn.IsDeleted = false;

                            //Credit transaction
                            Transaction crtxn = new Transaction();
                            crtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int cracc = rep.GetAccountIfExists(_feeStructureOther.AccountId);
                            if (cracc == -1) cracc = int.Parse(rep.SettingLookup("SUSPCR"));
                            crtxn.AccountId = cracc;
                            crtxn.Amount = _feeStructureOther.Amount;
                            crtxn.Narrative = this.BuildNarrative(_Student, _ClsStrm, _SchoolClass, drtxn.Id, drtxn.Amount, _feeStructureOther.Description, "C");
                            crtxn.UserName = user;
                            crtxn.Authorizer = "SYSTEM";
                            crtxn.StatementFlag = "Credit";
                            crtxn.PostDate = DateTime.Today;
                            crtxn.ValueDate = DateTime.Today;
                            crtxn.RecordDate = DateTime.Today;
                            crtxn.TransRef = _transRef;
                            crtxn.IsDeleted = false;

                            observableTransactions.Add(crtxn);

                            drtxn.Narrative = this.BuildNarrative(_Student, _ClsStrm, _SchoolClass, crtxn.AccountId, crtxn.Amount, _feeStructureOther.Description, "D");

                            observableTransactions.Add(drtxn);
                        } 
                    }
                    if (!tabControlStudentAdmission.Contains(tabPageFeesPayment))
                    {
                        tabControlStudentAdmission.TabPages.Add(tabPageFeesPayment);
                    }
                    tabControlStudentAdmission.SelectedTab = tabControlStudentAdmission.TabPages[tabControlStudentAdmission.TabPages.IndexOf(tabPageFeesPayment)];
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnPostCharges_Click(object sender, EventArgs e)
        {
            try
            {
                if (observableTransactions.Count != 0)
                {
                    rep.PostTransactions(observableTransactions.ToList());
                    MessageBox.Show("Fees Charges Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Transactions to Post!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            try
            {
                SearchStudentsSimpleForm ssf = new SearchStudentsSimpleForm(connection);
                ssf.OnStudentsListSelected += new SearchStudentsSimpleForm.StudentsSelectHandler(ssf_OnStudentsListSelected);
                ssf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ssf_OnStudentsListSelected(object sender, StudentsSelectEventArgs e)
        {
            try
            {
                SetStudents(e._Student);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetStudents(Student _Student)
        {
            try
            {
                if (_Student != null)
                {
                    txtAdminNo.Text = _Student.AdminNo.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnRetrieveStudentDetails_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(txtAdminNo.Text))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtAdminNo, "Admission No cannot be null!");
                    return;
                }
                if (!string.IsNullOrEmpty(txtAdminNo.Text))
                {
                    string adminno = txtAdminNo.Text.ToString().Trim();
                    var stdquery = (from st in db.Students
                                    where st.AdminNo == adminno
                                    where st.IsDeleted == false
                                    select st).FirstOrDefault();
                    _Student = stdquery;
                    if (_Student != null)
                    {
                        lblAccountId.Text = string.Empty;
                        lblBookBalance.Text = string.Empty;
                        lbCustomerId.Text = string.Empty;

                        InitializeControls(_Student);

                        if (_Student.RequireTransport ?? false)
                        {
                            groupBoxResidenceTransport.Enabled = true;
                        }
                        else
                        {
                            groupBoxResidenceTransport.Enabled = false;
                        }

                        if (_Student.Boarder ?? false)
                        {
                            groupBoxResidenceBorder.Enabled = true;
                        }
                        else
                        {
                            groupBoxResidenceBorder.Enabled = false;
                        }

                        txtTutionFees.Text = string.Empty;
                        listViewFeePayments.Items.Clear();
                        ListViewProgrammeYearCourses.Items.Clear();

                        if (!tabControlStudentAdmission.Contains(tabPageFeesPaymentPlan))
                        {
                            tabControlStudentAdmission.TabPages.Add(tabPageFeesPaymentPlan);
                        }
                        tabControlStudentAdmission.SelectedTab = tabControlStudentAdmission.TabPages[tabControlStudentAdmission.TabPages.IndexOf(tabPageFeesPaymentPlan)];
                        tabControlStudentAdmission.TabPages.Remove(tabPageFeesPayment);

                        ClearFeesPaymentControls();

                        ClearFeesPaymentPlanControls();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls(Student s)
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
                    txtAdmissionNo.Text = s.AdminNo.Trim();
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
                    pBStudentPhoto.ImageLocation = s.Photo.ToString().Trim();
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

                var _Dsplns = from dp in db.Disciplines
                              where dp.StudentId == s.Id
                              where dp.IsDeleted == false
                              select dp;
                List<Discipline> _Disciplines = _Dsplns.ToList();
                bindingSourceDisplines.DataSource = _Disciplines;

                dataGridViewDispline.AutoGenerateColumns = false;
                dataGridViewDispline.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewDispline.DataSource = bindingSourceDisplines;

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
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
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
        private string BuildNarrative(Student _Student, ClassStream _ClsStrm, SchoolClass _SchoolClass, int accountid, decimal amount, string description, string TType)
        {
            try
            {
                string narr = string.Empty;
                var accntquery = (from acc in db.Accounts
                                  where acc.IsDeleted == false
                                  where acc.Closed == false
                                  where acc.Id == accountid
                                  select acc).FirstOrDefault();
                Account _account = accntquery;
                if (_account != null)
                {
                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + ",  Account = " + " Name: [ " + _account.AccountName + " ]  No: [ " + _account.AccountNo + " ] " + " Amount: [ " + amount.ToString("#,##0") + " ] " + ", Student =  Name: [ " + _Student.StudentSurName + "  " + _Student.StudentOtherNames + " ] " + " Admin No: [ " + _Student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + ",  Account = " + " Name: [ " + _account.AccountName + " ] No: [ " + _account.AccountNo + "] " + " Amount: [ " + amount.ToString("#,##0") + " ]";
                            break;
                    } 
                }
                if (_account == null)
                {
                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + ",  Amount [ " + amount.ToString("#,##0") + " ] " + ", Student =  Name: [ " + _Student.StudentSurName + "  " + _Student.StudentOtherNames + " ]   " + " Admin No: [ " + _Student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + ",  Amount [ " + amount.ToString("#,##0") + " ]";
                            break;
                    }
                }
                return narr;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string BuildPaymentsNarrative(Student _Student, ClassStream _ClsStrm, SchoolClass _SchoolClass, int accountid, decimal amount, string description, string TType)
        {
            try
            {
                string narr = string.Empty;
                var accntquery = (from acc in db.Accounts
                                  where acc.Closed == false
                                  where acc.IsDeleted == false
                                  where acc.Id == accountid
                                  select acc).FirstOrDefault();
                Account _account = accntquery;
                if (_account != null)
                {
                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + ",   Account = " + " Name: [ " + _account.AccountName + " ]  " + "  No: [ " + _account.AccountNo + " ] " + " Amount: [ " + amount.ToString("#,##0") + " ] " + ",  Student =   Name: [ " + _Student.StudentSurName + "  " + _Student.StudentOtherNames + " ]  " + "  Admin No: [ " + _Student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + ",   Account = " + " Name: [ " + _account.AccountName + " ]  " + "  No: [ " + _account.AccountNo + " ] " + " Amount: [ " + amount.ToString("#,##0") + " ] ";
                            break;
                    } 
                }
                if (_account == null)
                {
                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + ",  Amount: [ " + amount.ToString("#,##0") + " ] " + ", Student =   Name: [ " + _Student.StudentSurName + "  " + _Student.StudentOtherNames + " ]  " + "  Admin No: [ " + _Student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + ",  Amount: [ " + amount.ToString("#,##0") + " ] ";
                            break;
                    }
                }
                return narr;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void txtCashAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtCashAmountPaid_KeyDown(object sender, KeyEventArgs e)
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
        private void txtMpesaAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtMpesaAmountPaid_KeyDown(object sender, KeyEventArgs e)
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
        private void txtBankSlipAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtBankSlipAmountPaid_KeyDown(object sender, KeyEventArgs e)
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
        private void txtChequeAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtChequeAmountPaid_KeyDown(object sender, KeyEventArgs e)
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
        private void txtBankSortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtBankSortCode_KeyDown(object sender, KeyEventArgs e)
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
        private void txtChqBankBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtChqBankBranch_KeyDown(object sender, KeyEventArgs e)
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
        private bool isPaymentsValid()
        {
            bool noerror = true;
            foreach (Control ctrl in groupBoxModeofPayment.Controls)
            {
                if (ctrl.GetType() == typeof(RadioButton))
                {
                    if (((RadioButton)ctrl).Checked)
                    {
                        switch (((RadioButton)ctrl).Name)
                        {
                            case "radioButtonCash":
                                if (string.IsNullOrEmpty(txtCashAmountPaid.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtCashAmountPaid, "Amount cannot be null!");
                                    return false;
                                }
                                break;
                            case "radioButtonMpesa":
                                if (string.IsNullOrEmpty(txtMpesaReceiptNo.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtMpesaReceiptNo, "Mpesa Receipt No cannot be null!");
                                    return false;
                                }
                                if (string.IsNullOrEmpty(txtMpesaAmountPaid.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtMpesaAmountPaid, "Amount cannot be null!");
                                    return false;
                                }
                                if (string.IsNullOrEmpty(txtMpesaSenderName.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtMpesaSenderName, "Mpesa Sender Name cannot be null!");
                                    return false;
                                }
                                if (string.IsNullOrEmpty(txtMpesaPhoneNumber.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtMpesaPhoneNumber, "Mpesa Phone Number cannot be null!");
                                    return false;
                                }
                                break;
                            case "radioButtonBankSlip":
                                if (string.IsNullOrEmpty(txtBankSlipNo.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtBankSlipNo, "Bank Slip Number cannot be null!");
                                    return false;
                                }
                                if (string.IsNullOrEmpty(txtBankSlipAmountPaid.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtBankSlipAmountPaid, "Amount cannot be null!");
                                    return false;
                                }
                                if (string.IsNullOrEmpty(txtSlipBankSortCode.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtSlipBankSortCode, "Bank Sort Code cannot be null!");
                                    return false;
                                }
                                if (!string.IsNullOrEmpty(txtSlipBankSortCode.Text))
                                {
                                    string _banksortcode = txtSlipBankSortCode.Text.Trim();
                                    var _branchquery = (from bb in rep.GetBankBranchList()
                                                        where bb.BankSortCode == _banksortcode
                                                        select bb).FirstOrDefault();
                                    BankBranch _branch = _branchquery;
                                    if (_branch == null)
                                    {
                                        errorProvider1.Clear();
                                        errorProvider1.SetError(txtSlipBankSortCode, "Bank Sort Code does not exist!");
                                        return false;
                                    }
                                }
                                break;
                            case "radioButtonCheque":
                                if (string.IsNullOrEmpty(txtChequeNo.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtChequeNo, "Cheque Number cannot be null!");
                                    return false;
                                }
                                if (string.IsNullOrEmpty(txtChequeAmountPaid.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtChequeAmountPaid, "Amount cannot be null!");
                                    return false;
                                }
                                if (string.IsNullOrEmpty(txtChqBankSortCode.Text))
                                {
                                    errorProvider1.Clear();
                                    errorProvider1.SetError(txtChqBankSortCode, "Bank Sort Code cannot be null!");
                                    return false;
                                }
                                if (!string.IsNullOrEmpty(txtChqBankSortCode.Text))
                                {
                                    string _banksortcode = txtChqBankSortCode.Text.Trim();
                                    var _branchquery = (from bb in rep.GetBankBranchList()
                                                        where bb.BankSortCode == _banksortcode
                                                        select bb).FirstOrDefault();
                                    BankBranch _branch = _branchquery;
                                    if (_branch == null)
                                    {
                                        errorProvider1.Clear();
                                        errorProvider1.SetError(txtChqBankSortCode, "Bank Sort Code does not exist!");
                                        return false;
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            return noerror;
        } 
        private void btnPostPayments_Click(object sender, EventArgs e)
        {
            if (isPaymentsValid())
            {
                transactions = new List<Transaction>();
                if (_Student != null)
                {
                    try
                    {
                        string _Narrative = null;
                        string RawSalt = DateTime.Now.ToString("yMdHms");
                        string HashSalt = HashHelper.CreateRandomSalt();
                        int foundS1 = HashSalt.IndexOf("==");
                        int foundS2 = HashSalt.IndexOf("+");
                        int foundS3 = HashSalt.IndexOf("/");
                        if (foundS1 > 0)
                        {
                            HashSalt = HashSalt.Remove(foundS1);
                        }
                        if (foundS2 > 0)
                        {
                            HashSalt = HashSalt.Remove(foundS2);
                        }
                        if (foundS3 > 0)
                        {
                            HashSalt = HashSalt.Remove(foundS3);
                        }
                        string SaltedHash = RawSalt.Insert(5, HashSalt);
                        string _transRef = SaltedHash;
                        receiptNo = _transRef;

                        var cls = (from cs in db.ClassStreams
                                   join st in db.Students on cs.Id equals st.ClassStreamId
                                   where st.Id == _Student.Id
                                   where cs.IsDeleted == false
                                   where st.IsDeleted == false
                                   where st.Status == "A"
                                   select cs).FirstOrDefault();
                        ClassStream _ClsStrm = cls;

                        var _Schoolquery = (from sc in db.Schools
                                            where sc.Id == _Student.SchoolId
                                            where sc.IsDeleted == false
                                            select sc).FirstOrDefault();
                        School _School = _Schoolquery;

                        var _SchoolClassesquery = (from sc in db.SchoolClasses
                                                   where sc.IsDeleted == false
                                                   join cs in db.ClassStreams on _Student.ClassStreamId equals cs.Id
                                                   where cs.IsDeleted == false
                                                   where cs.ClassId == sc.Id
                                                   select sc).FirstOrDefault();
                        SchoolClass _SchoolClass = _SchoolClassesquery;

                        var feeStructurequery = (from fs in db.FeesStructures
                                                 where fs.IsDefault == true
                                                 where fs.IsDeleted == false
                                                 select fs).FirstOrDefault();
                        FeesStructure _FeesStructure = feeStructurequery;

                        var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                          where fs.FeeStructureId == _FeesStructure.Id
                                                          where fs.IsDeleted == false
                                                          where fs.SchoolClassId == _SchoolClass.Id
                                                          select fs;
                        List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();


                        var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                                       where fs.FeeStructureId == _FeesStructure.Id
                                                       where fs.IsDeleted == false
                                                       select fs;
                        List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();


                        foreach (Control ctrl in groupBoxModeofPayment.Controls)
                        {
                            if (ctrl.GetType() == typeof(RadioButton))
                            {
                                if (((RadioButton)ctrl).Checked)
                                {
                                    switch (((RadioButton)ctrl).Name)
                                    {
                                        case "radioButtonCash":
                                            if (!string.IsNullOrEmpty(txtCashAmountPaid.Text))
                                            {
                                                _Narrative = "Cash Payment ";

                                                //Credit transaction
                                                CreditTransaction = new Transaction();
                                                CreditTransaction.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                                                int crCashacc = rep.GetCustomerAccountByAccountType("TUITION", _School.GLCustomerId);  //_School Account
                                                if (crCashacc == -1) crCashacc = int.Parse(rep.SettingLookup("SUSPCR"));
                                                CreditTransaction.AccountId = crCashacc;
                                                CreditTransaction.Amount = decimal.Parse(txtCashAmountPaid.Text);
                                                CreditTransaction.UserName = user;
                                                CreditTransaction.Authorizer = "SYSTEM";
                                                CreditTransaction.StatementFlag = "Credit";
                                                CreditTransaction.PostDate = DateTime.Today;
                                                CreditTransaction.ValueDate = DateTime.Today;
                                                CreditTransaction.RecordDate = DateTime.Today;
                                                CreditTransaction.TransRef = _transRef;
                                                CreditTransaction.IsDeleted = false;


                                                //Debit transaction
                                                DebitTransaction = new Transaction();
                                                DebitTransaction.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                                                int drCashacc = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);//_Student account
                                                if (drCashacc == -1) drCashacc = int.Parse(rep.SettingLookup("SUSPDR"));
                                                DebitTransaction.AccountId = drCashacc;
                                                DebitTransaction.Amount = decimal.Parse(txtCashAmountPaid.Text) * -1;
                                                DebitTransaction.Narrative = BuildPaymentsNarrative(_Student, _ClsStrm, _SchoolClass, CreditTransaction.AccountId, CreditTransaction.Amount, _Narrative, "D");
                                                DebitTransaction.UserName = user;
                                                DebitTransaction.Authorizer = "SYSTEM";
                                                DebitTransaction.StatementFlag = "Debit";
                                                DebitTransaction.PostDate = DateTime.Today;
                                                DebitTransaction.ValueDate = DateTime.Today;
                                                DebitTransaction.RecordDate = DateTime.Today;
                                                DebitTransaction.TransRef = _transRef;
                                                DebitTransaction.IsDeleted = false;

                                                transactions.Add(DebitTransaction);

                                                CreditTransaction.Narrative = BuildPaymentsNarrative(_Student, _ClsStrm, _SchoolClass, DebitTransaction.AccountId, DebitTransaction.Amount, _Narrative, "C");

                                                transactions.Add(CreditTransaction);

                                                var _drcashAccountquery = (from da in db.Accounts
                                                                           where da.Id == DebitTransaction.AccountId
                                                                           select da).FirstOrDefault();
                                                DrAccountAfterPosting = _drcashAccountquery;

                                                var _crcashAccountquery = (from da in db.Accounts
                                                                           where da.Id == CreditTransaction.AccountId
                                                                           select da).FirstOrDefault();
                                                CrAccountAfterPosting = _crcashAccountquery;

                                                rep.PostTransactions(transactions);

                                                MessageBox.Show("Payments Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                if (IsPrintTransactionValid())
                                                {
                                                    btnPrintReceipt.Enabled = true;
                                                    btnPrintReceipt_Click(sender, e);
                                                }
                                            }
                                            break;
                                        case "radioButtonMpesa":
                                            if (!string.IsNullOrEmpty(txtMpesaAmountPaid.Text))
                                            {
                                                _Narrative = "Mpesa Payment =  Receipt No: " + " [ " + txtMpesaReceiptNo.Text + " ] " + " Name: " + " [ " + txtMpesaSenderName.Text + " ] " + " Phone Number: " + " [ " + txtMpesaPhoneNumber.Text + " ]";
                                                
                                                //Credit transaction
                                                CreditTransaction = new Transaction();
                                                CreditTransaction.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                                                int accschMpesa = rep.GetCustomerAccountByAccountType("TUITION", _School.GLCustomerId);  //_School Account
                                                if (accschMpesa == -1) accschMpesa = int.Parse(rep.SettingLookup("SUSPCR"));

                                                CreditTransaction.AccountId = accschMpesa;
                                                CreditTransaction.Amount = decimal.Parse(txtMpesaAmountPaid.Text);
                                                CreditTransaction.UserName = user;
                                                CreditTransaction.Authorizer = "SYSTEM";
                                                CreditTransaction.StatementFlag = "Credit";
                                                CreditTransaction.PostDate = DateTime.Today;
                                                CreditTransaction.ValueDate = DateTime.Today;
                                                CreditTransaction.RecordDate = DateTime.Today;
                                                CreditTransaction.TransRef = _transRef;
                                                CreditTransaction.IsDeleted = false;


                                                //Debit transaction
                                                DebitTransaction = new Transaction();
                                                DebitTransaction.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                                                int accMpesa = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);//_Student account
                                                if (accMpesa == -1) accMpesa = int.Parse(rep.SettingLookup("SUSPDR"));
                                                DebitTransaction.AccountId = accMpesa;
                                                DebitTransaction.Amount = decimal.Parse(txtMpesaAmountPaid.Text) * -1;
                                                DebitTransaction.Narrative = BuildPaymentsNarrative(_Student, _ClsStrm, _SchoolClass, CreditTransaction.AccountId, CreditTransaction.Amount, _Narrative, "D");
                                                DebitTransaction.UserName = user;
                                                DebitTransaction.Authorizer = "UserName";
                                                DebitTransaction.StatementFlag = "Debit";
                                                DebitTransaction.PostDate = DateTime.Today;
                                                DebitTransaction.ValueDate = DateTime.Today;
                                                DebitTransaction.RecordDate = DateTime.Today;
                                                DebitTransaction.TransRef = _transRef;
                                                DebitTransaction.IsDeleted = false;

                                                transactions.Add(DebitTransaction);

                                                CreditTransaction.Narrative = BuildPaymentsNarrative(_Student, _ClsStrm, _SchoolClass, DebitTransaction.AccountId, DebitTransaction.Amount, _Narrative, "C");
                                                transactions.Add(CreditTransaction);

                                                var _drMpesaAccountquery = (from da in db.Accounts
                                                                            where da.Id == DebitTransaction.AccountId
                                                                            select da).FirstOrDefault();
                                                DrAccountAfterPosting = _drMpesaAccountquery;

                                                var _crMpesaAccountquery = (from da in db.Accounts
                                                                            where da.Id == CreditTransaction.AccountId
                                                                            select da).FirstOrDefault();
                                                CrAccountAfterPosting = _crMpesaAccountquery;

                                                rep.PostTransactions(transactions);

                                                MessageBox.Show("Payments Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                if (IsPrintTransactionValid())
                                                {
                                                    btnPrintReceipt.Enabled = true;
                                                    btnPrintReceipt_Click(sender, e);
                                                }
                                            }
                                            break;
                                        case "radioButtonBankSlip":
                                            if (!string.IsNullOrEmpty(txtBankSlipAmountPaid.Text))
                                            {
                                                _Narrative = "Bank Slip Payment =  Slip No: [ " + txtBankSlipNo.Text + " ]  Bank Sort Code: [ " + txtSlipBankSortCode.Text + "  ] ";


                                                //Credit transaction
                                                CreditTransaction = new Transaction();
                                                CreditTransaction.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                                                int accschBankSlip = rep.GetCustomerAccountByAccountType("TUITION", _School.GLCustomerId);  //_School Account
                                                if (accschBankSlip == -1) accschBankSlip = int.Parse(rep.SettingLookup("SUSPCR"));
                                                CreditTransaction.AccountId = accschBankSlip;
                                                CreditTransaction.Amount = decimal.Parse(txtBankSlipAmountPaid.Text);
                                                CreditTransaction.UserName = user;
                                                CreditTransaction.Authorizer = "SYSTEM";
                                                CreditTransaction.StatementFlag = "Credit";
                                                CreditTransaction.PostDate = DateTime.Today;
                                                CreditTransaction.ValueDate = DateTime.Today;
                                                CreditTransaction.RecordDate = DateTime.Today;
                                                CreditTransaction.TransRef = _transRef;
                                                CreditTransaction.IsDeleted = false;

                                                //Debit transaction
                                                DebitTransaction = new Transaction();
                                                DebitTransaction.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                                                int accBankSlip = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);//_Student account
                                                if (accBankSlip == -1) accBankSlip = int.Parse(rep.SettingLookup("SUSPDR"));
                                                DebitTransaction.AccountId = accBankSlip;
                                                DebitTransaction.Amount = decimal.Parse(txtBankSlipAmountPaid.Text) * -1;
                                                DebitTransaction.Narrative = BuildPaymentsNarrative(_Student, _ClsStrm, _SchoolClass, CreditTransaction.AccountId, CreditTransaction.Amount, _Narrative, "D");
                                                DebitTransaction.UserName = user;
                                                DebitTransaction.Authorizer = "SYSTEM";
                                                DebitTransaction.StatementFlag = "Debit";
                                                DebitTransaction.PostDate = DateTime.Today;
                                                DebitTransaction.ValueDate = DateTime.Today;
                                                DebitTransaction.RecordDate = DateTime.Today;
                                                DebitTransaction.TransRef = _transRef;
                                                DebitTransaction.IsDeleted = false;

                                                transactions.Add(DebitTransaction);

                                                CreditTransaction.Narrative = BuildPaymentsNarrative(_Student, _ClsStrm, _SchoolClass, DebitTransaction.AccountId, DebitTransaction.Amount, _Narrative, "C");

                                                transactions.Add(CreditTransaction);

                                                var _drBankSlipAccountquery = (from da in db.Accounts
                                                                               where da.Id == DebitTransaction.AccountId
                                                                               select da).FirstOrDefault();
                                                DrAccountAfterPosting = _drBankSlipAccountquery;

                                                var _crBankSlipAccountquery = (from da in db.Accounts
                                                                               where da.Id == CreditTransaction.AccountId
                                                                               select da).FirstOrDefault();
                                                CrAccountAfterPosting = _crBankSlipAccountquery;

                                                rep.PostTransactions(transactions);

                                                MessageBox.Show("Payments Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                if (IsPrintTransactionValid())
                                                {
                                                    btnPrintReceipt.Enabled = true;
                                                    btnPrintReceipt_Click(sender, e);
                                                }
                                            }
                                            break;
                                        case "radioButtonCheque":
                                            if (!string.IsNullOrEmpty(txtChequeAmountPaid.Text))
                                            {
                                                _Narrative = "Cheque Payment =  Cheque No: [ " + txtChequeNo.Text + " ]  Bank Sort Code:  [ " + txtChqBankSortCode.Text + " ] ";

                                                //Credit transaction
                                                CreditTransaction = new Transaction();
                                                CreditTransaction.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                                                int accschCheque = rep.GetCustomerAccountByAccountType("TUITION", _School.GLCustomerId);  //_School Account
                                                if (accschCheque == -1) accschCheque = int.Parse(rep.SettingLookup("SUSPCR"));
                                                CreditTransaction.AccountId = accschCheque;
                                                CreditTransaction.Amount = decimal.Parse(txtChequeAmountPaid.Text);
                                                CreditTransaction.UserName = user;
                                                CreditTransaction.Authorizer = "SYSTEM";
                                                CreditTransaction.StatementFlag = "Credit";
                                                CreditTransaction.PostDate = DateTime.Today;
                                                CreditTransaction.ValueDate = DateTime.Today;
                                                CreditTransaction.RecordDate = DateTime.Today;
                                                CreditTransaction.TransRef = _transRef;
                                                CreditTransaction.IsDeleted = false;

                                                //Debit transaction
                                                DebitTransaction = new Transaction();
                                                DebitTransaction.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                                                int accCheque = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);//_Student account
                                                if (accCheque == -1) accCheque = int.Parse(rep.SettingLookup("SUSPDR"));
                                                DebitTransaction.AccountId = accCheque;
                                                DebitTransaction.Amount = decimal.Parse(txtChequeAmountPaid.Text) * -1;
                                                DebitTransaction.Narrative = BuildPaymentsNarrative(_Student, _ClsStrm, _SchoolClass, CreditTransaction.AccountId, CreditTransaction.Amount, _Narrative, "D");
                                                DebitTransaction.UserName = user;
                                                DebitTransaction.Authorizer = "SYSTEM";
                                                DebitTransaction.StatementFlag = "Debit";
                                                DebitTransaction.PostDate = DateTime.Today;
                                                DebitTransaction.ValueDate = DateTime.Today;
                                                DebitTransaction.RecordDate = DateTime.Today;
                                                DebitTransaction.TransRef = _transRef;
                                                DebitTransaction.IsDeleted = false;

                                                transactions.Add(DebitTransaction);

                                                CreditTransaction.Narrative = BuildPaymentsNarrative(_Student, _ClsStrm, _SchoolClass, DebitTransaction.AccountId, DebitTransaction.Amount, _Narrative, "C");
                                                transactions.Add(CreditTransaction);

                                                var _drChequeAccountquery = (from da in db.Accounts
                                                                             where da.Id == DebitTransaction.AccountId
                                                                             select da).FirstOrDefault();
                                                DrAccountAfterPosting = _drChequeAccountquery;

                                                var _crChequeAccountquery = (from da in db.Accounts
                                                                             where da.Id == CreditTransaction.AccountId
                                                                             select da).FirstOrDefault();
                                                CrAccountAfterPosting = _crChequeAccountquery;

                                                rep.PostTransactions(transactions);

                                                MessageBox.Show("Payments Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                if (IsPrintTransactionValid())
                                                {
                                                    btnPrintReceipt.Enabled = true;
                                                    btnPrintReceipt_Click(sender, e);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
        }
        private bool IsPrintTransactionValid()
        {
            bool noerror = true;
            if (school == null)
            {
                MessageBox.Show("School cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (_Student == null)
            {
                MessageBox.Show("Student cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (DrAccountAfterPosting == null)
            {
                MessageBox.Show("Debit Account cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (CrAccountAfterPosting == null)
            {
                MessageBox.Show("Credit Account cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (DebitTransaction == null)
            {
                MessageBox.Show("Debit Transaction cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (CreditTransaction == null)
            {
                MessageBox.Show("Credit Transaction cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (school == null)
            {
                MessageBox.Show("School cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            } 
            return noerror;
        }
        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPrintTransactionValid())
                { 

                    int txntypeid = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                    var txnquery = (from tx in db.TransactionTypes
                                    where tx.Id == txntypeid
                                    select tx).FirstOrDefault();
                    TransactionType TType = txnquery;

                    string Template = TType.ReceiptLayout;

                    if (TType.PrintReceipt == true)
                    {
                        if (TType.PrintReceiptPrompt == true)
                        {
                            if (DialogResult.Yes == MessageBox.Show("Do you want to print", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {

                                PrintReciept(Template, GetPrintObject());
                            }
                        }
                        else
                        {
                            PrintReciept(Template, GetPrintObject());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private object[] GetPrintObject()
        {
            try
            {
                PrintFields pf = new PrintFields();
                List<PrintField> lpf = pf.GetFieldList();
                List<object> po = new List<object>();
                foreach (var item in lpf)
                {
                    object io = GetItemObject(item);
                    po.Add(io);
                }
                return po.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private object GetItemObject(PrintField item)
        {
            try
            { 
                var _classquery = from sc in db.SchoolClasses
                                  join cs in db.ClassStreams on sc.Id equals cs.ClassId
                                  join st in db.Students on cs.Id equals st.ClassStreamId
                                  where st.Id == _Student.Id
                                  select sc;
                SchoolClass _class = _classquery.FirstOrDefault();

                switch (item.Id)
                {
                    case 0:
                        return DateTime.Now.ToString("d/M/yyyy");
                    case 1:
                        return school.SchoolName;
                    case 2:
                        return school.Address1 + school.Address2;
                    case 3:
                        return receiptNo;
                    case 4:
                        return DrAccountAfterPosting.AccountName;
                    case 5:
                        return CrAccountAfterPosting.AccountName;
                    case 6:
                        return DebitTransaction.Narrative;
                    case 7:
                        return CreditTransaction.Narrative;
                    case 8:
                        return CreditTransaction.Amount;
                    case 9:
                        return _Student.StudentSurName + "  " + _Student.StudentOtherNames;
                    case 10:
                        return _Student.AdminNo;
                    case 11:
                        return _class.ClassName;
                    default:
                        return "Unknown Field";
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void PrintReciept(string ReceiptLayout, object[] PostObject)
        {
            try
            {
                string output = string.Format(ReceiptLayout, PostObject);
                PrintDocument p = new PrintDocument();
                p.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
                {
                    e1.Graphics.DrawString(output,
                        new Font("Arial", 12),
                        new SolidBrush(Color.Black),
                        new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

                };

                try
                {
                    p.Print();
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured While Printing", ex);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        // The PrintPage event is raised for each page to be printed. 
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                string line = null;

                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height /
                   printFont.GetHeight(ev.Graphics);

                // Print each line of the file. 
                while (count < linesPerPage &&
                   ((line = streamToPrint.ReadLine()) != null))
                {
                    yPos = topMargin + (count *
                       printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black,
                       leftMargin, yPos, new StringFormat());
                    count++;
                }

                // If more lines exist, print another page. 
                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void radioButtonFeesPaymentPerUnit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Student != null)
                { 
                    var schlquery = (from sc in db.Schools
                                     where sc.Id == _Student.SchoolId
                                     select sc).FirstOrDefault();

                    switch (schlquery.SchoolType)
                    {
                        case "1":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "2":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "3":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "4":
                            PopulateFeesPaymentPlanHigherLevel();
                            ComputeHigherFeesPaymentPlan();
                            break;
                        case "5":
                            PopulateFeesPaymentPlanHigherLevel();
                            ComputeHigherFeesPaymentPlan();
                            break;
                        case "6":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "7":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "8":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonFeeesPaymentPerSemester_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Student != null)
                {
                    var schlquery = (from sc in db.Schools
                                     where sc.Id == _Student.SchoolId
                                     select sc).FirstOrDefault();

                    switch (schlquery.SchoolType)
                    {
                        case "1":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "2":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "3":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "4":
                            PopulateFeesPaymentPlanHigherLevel();
                            ComputeHigherFeesPaymentPlan();
                            break;
                        case "5":
                            PopulateFeesPaymentPlanHigherLevel();
                            ComputeHigherFeesPaymentPlan();
                            break;
                        case "6":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "7":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "8":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonFeesPaymentPerYear_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Student != null)
                {
                    var schlquery = (from sc in db.Schools
                                     where sc.Id == _Student.SchoolId
                                     select sc).FirstOrDefault();

                    switch (schlquery.SchoolType)
                    {
                        case "1":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "2":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "3":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "4":
                            PopulateFeesPaymentPlanHigherLevel();
                            ComputeHigherFeesPaymentPlan();
                            break;
                        case "5":
                            PopulateFeesPaymentPlanHigherLevel();
                            ComputeHigherFeesPaymentPlan();
                            break;
                        case "6":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "7":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        case "8":
                            PopulateFeesPaymentPlanLowerLevel();
                            ComputeLowerFeesPaymentPlan();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void PopulateFeesPaymentPlanHigherLevel()
        {
            try
            {
                if (_Student != null)
                {
                    ListViewProgrammeYearCourses.Items.Clear();
                    listViewFeePayments.Items.Clear();
                    CourseTuitionFee = 0.0;
                    txtTutionFees.Text = string.Empty;
                    foreach (Control ctrl in groupBoxFeesPaymentPlan.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton))
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                switch (((RadioButton)ctrl).Name)
                                {
                                    case "radioButtonFeesPaymentPerUnit":
                                        var _StudentClass = (from sc in db.SchoolClasses
                                                             join cs in db.ClassStreams on _Student.ClassStreamId equals cs.Id
                                                             where cs.ClassId == sc.Id
                                                             select sc).FirstOrDefault();
                                        SchoolClass _schoolclass = _StudentClass;
                                        var _PrgrmmYr = (from pg in db.ProgrammeYears
                                                         where
                                                         pg.Id == _schoolclass.ProgrammeYearId
                                                         select pg).FirstOrDefault();
                                        ProgrammeYear _programmeyear = _PrgrmmYr;

                                        var _semesters = (from sm in db.ProgrammeYearCourses
                                                          where sm.ProgrammeYearId == _programmeyear.Id
                                                          where sm.ProgrammeId == _programmeyear.ProgrammeId
                                                          select sm.Semester).Distinct().ToList();
                                        ListViewProgrammeYearCourses.Items.Clear(); ListViewProgrammeYearCourses.ShowGroups = true;

                                        foreach (var sm in _semesters)
                                        {
                                            ListViewGroup _group =
                         new ListViewGroup("Semester  " + sm.ToString(), HorizontalAlignment.Left);
                                            var _ProgrammeYearCoursesquery = from py in db.ProgrammeYearCourses
                                                                             where py.ProgrammeYearId == _programmeyear.Id
                                                                             where py.ProgrammeId == _programmeyear.ProgrammeId
                                                                             where py.Semester == sm
                                                                             select py;
                                            List<ProgrammeYearCours> _programmeyearcours = _ProgrammeYearCoursesquery.ToList();


                                            foreach (var smt in _programmeyearcours)
                                            {

                                                ListViewProgrammeYearCourses.Groups.Add(_group);
                                                ListViewProgrammeYearCourses.Items.Add(new ListViewItem(new string[]
                {
                    smt.CourseId.ToString(),smt.NoOfHrs.ToString(),smt.TuitionFees.ToString(),smt.ExamFees.ToString(),smt.ResitFees.ToString()
                }, _group));
                                            }
                                        }
                                        foreach (ListViewItem item in ListViewProgrammeYearCourses.Items)
                                        {
                                            item.ImageIndex = 0;
                                        }
                                        break;
                                    case "radioButtonFeeesPaymentPerSemester":
                                        var _StudentClassquery = (from sc in db.SchoolClasses join cs in db.ClassStreams on _Student.ClassStreamId equals cs.Id where cs.ClassId == sc.Id select sc).FirstOrDefault();
                                        SchoolClass _SchoolClass = _StudentClassquery;
                                        var _ProgrammeYearquery = (from pg in db.ProgrammeYears
                                                                   where
                                                                   pg.Id == _SchoolClass.ProgrammeYearId
                                                                   select pg).FirstOrDefault();
                                        ProgrammeYear _ProgrammeYear = _ProgrammeYearquery;

                                        var _Semesters = (from sm in db.ProgrammeYearCourses
                                                          where sm.ProgrammeYearId == _ProgrammeYear.Id
                                                          where sm.ProgrammeId == _ProgrammeYear.ProgrammeId
                                                          select sm.Semester).Distinct().ToList();
                                        ListViewProgrammeYearCourses.Items.Clear(); ListViewProgrammeYearCourses.ShowGroups = true;

                                        foreach (var sm in _Semesters)
                                        {
                                            ListViewGroup _group =
                         new ListViewGroup("Semester  " + sm.ToString(), HorizontalAlignment.Left);
                                            var _ProgrammeYearCoursesquery = from py in db.ProgrammeYearCourses
                                                                             where py.ProgrammeYearId == _ProgrammeYear.Id
                                                                             where py.ProgrammeId == _ProgrammeYear.ProgrammeId
                                                                             where py.Semester == sm
                                                                             select py;
                                            List<ProgrammeYearCours> _programmeyearcours = _ProgrammeYearCoursesquery.ToList();


                                            foreach (var smt in _programmeyearcours)
                                            {

                                                ListViewProgrammeYearCourses.Groups.Add(_group);
                                                ListViewProgrammeYearCourses.Items.Add(new ListViewItem(new string[]
                {
                    smt.CourseId.ToString(),smt.NoOfHrs.ToString(),smt.TuitionFees.ToString(),smt.ExamFees.ToString(),smt.ResitFees.ToString()
                }, _group));
                                            }
                                        }
                                        foreach (ListViewItem item in ListViewProgrammeYearCourses.Items)
                                        {
                                            item.ImageIndex = 0;
                                        }
                                        break;
                                    case "radioButtonFeesPaymentPerYear":

                                        var _Studentclassquery = (from sc in db.SchoolClasses
                                                                  join cs in db.ClassStreams on _Student.ClassStreamId equals cs.Id
                                                                  where cs.ClassId == sc.Id
                                                                  select sc).FirstOrDefault();
                                        SchoolClass _Schoolclass = _Studentclassquery;
                                        var _programmeYearquery = (from pg in db.ProgrammeYears
                                                                   where
                                                                   pg.Id == _Schoolclass.ProgrammeYearId
                                                                   select pg).FirstOrDefault();
                                        ProgrammeYear _programmeYear = _programmeYearquery;

                                        var Semesters = (from sm in db.ProgrammeYearCourses
                                                         where sm.ProgrammeYearId == _programmeYear.Id
                                                         where sm.ProgrammeId == _programmeYear.ProgrammeId
                                                         select sm.Semester).Distinct().ToList();
                                        ListViewProgrammeYearCourses.Items.Clear(); ListViewProgrammeYearCourses.ShowGroups = true;

                                        foreach (var sm in Semesters)
                                        {
                                            ListViewGroup _group =
                         new ListViewGroup("Semester  " + sm.ToString(), HorizontalAlignment.Left);
                                            var _ProgrammeYearCoursesquery = from py in db.ProgrammeYearCourses
                                                                             where py.ProgrammeYearId == _programmeYear.Id
                                                                             where py.ProgrammeId == _programmeYear.ProgrammeId
                                                                             where py.Semester == sm
                                                                             select py;
                                            List<ProgrammeYearCours> _programmeyearcours = _ProgrammeYearCoursesquery.ToList();


                                            foreach (var smt in _programmeyearcours)
                                            {

                                                ListViewProgrammeYearCourses.Groups.Add(_group);
                                                ListViewProgrammeYearCourses.Items.Add(new ListViewItem(new string[]
                {
                    smt.CourseId.ToString(),smt.NoOfHrs.ToString(),smt.TuitionFees.ToString(),smt.ExamFees.ToString(),smt.ResitFees.ToString()
                }, _group));
                                            }
                                        }
                                        //This loops through all the items in the ListView and  checks each item.
                                        foreach (ListViewItem lvi in ListViewProgrammeYearCourses.Items)
                                        {
                                            lvi.Checked = true;
                                        }
                                        foreach (ListViewItem item in ListViewProgrammeYearCourses.Items)
                                        {
                                            item.ImageIndex = 0;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateFeesPaymentPlanLowerLevel()
        {
            try
            {
                if (_Student != null)
                {
                    var _defaultfeestructurequery = (from fs in db.FeesStructures
                                                     where fs.IsDefault == true
                                                     select fs).FirstOrDefault();
                    FeesStructure _defaultFeesStructure = _defaultfeestructurequery;

                    var _SchoolClassquery = (from sc in db.SchoolClasses
                                             join cs in db.ClassStreams on _Student.ClassStreamId equals cs.Id
                                             where cs.ClassId == sc.Id
                                             select sc).FirstOrDefault();
                    SchoolClass _schoolclass = _SchoolClassquery;

                    listViewFeePayments.Items.Clear();

                    var FeeStructureAcademicquery = from fsaq in db.FeeStructureAcademics
                                                    where fsaq.FeeStructureId == _defaultFeesStructure.Id
                                                    where fsaq.SchoolClassId == _schoolclass.Id
                                                    select fsaq;
                    List<FeeStructureAcademic> _FeeStructureAcademics = FeeStructureAcademicquery.ToList();

                    foreach (var fsa in _FeeStructureAcademics)
                    {

                        listViewFeePayments.Items.Add(new ListViewItem(new string[]
                {
                   fsa.Description.Trim(),fsa.Amount.ToString()
                }));

                    }
                    var FeeStructureOthersquery = (from fsoq in db.FeeStructureOthers
                                                   join fsa in db.FeeStructureAcademics on _schoolclass.Id equals fsa.SchoolClassId
                                                   where fsoq.FeeStructureId == fsa.FeeStructureId
                                                   select fsoq).ToList();
                    List<FeeStructureOther> _FeeStructureOthers = new List<FeeStructureOther>();
                    foreach (var fs in FeeStructureOthersquery)
                    {
                        FeeStructureOther feestructureothers = fs;
                        if (!_FeeStructureOthers.Contains(feestructureothers))
                        {
                            _FeeStructureOthers.Add(feestructureothers);
                        }
                    }
                    foreach (var fo in _FeeStructureOthers)
                    {
                        listViewFeePayments.Items.Add(new ListViewItem(new string[]
                {
                   fo.Description.Trim(),fo.Amount.ToString()
                }));
                    }
                    foreach (ListViewItem item in listViewFeePayments.Items)
                    {
                        item.ImageIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ComputeHigherFeesPaymentPlan()
        {
            try
            {
                if (_Student != null)
                {
                    txtTutionFees.Text = string.Empty;
                    if (ListViewProgrammeYearCourses.CheckedItems.Count != 0)
                    {
                        foreach (Control ctrl in groupBoxFeesPaymentPlan.Controls)
                        {
                            if (ctrl.GetType() == typeof(RadioButton))
                            {
                                if (((RadioButton)ctrl).Checked)
                                {
                                    switch (((RadioButton)ctrl).Name)
                                    {
                                        case "radioButtonFeesPaymentPerUnit":
                                            txtTutionFees.Text = string.Empty;
                                            decimal _tuitionFeestoCharge = 0;
                                            ListViewItem.ListViewSubItem _tuitionFees = listViewFeePayments.Items[0].SubItems[1];
                                            _tuitionFeestoCharge += decimal.Parse(_tuitionFees.Text.ToString());
                                            txtTutionFees.Text = _tuitionFeestoCharge.ToString();
                                            break;
                                        case "radioButtonFeeesPaymentPerSemester":
                                            txtTutionFees.Text = string.Empty;
                                            decimal _TuitionFeestoCharge = 0;
                                            ListViewItem.ListViewSubItem _TuitionFees = listViewFeePayments.Items[0].SubItems[1];
                                            _TuitionFeestoCharge += decimal.Parse(_TuitionFees.Text.ToString());
                                            txtTutionFees.Text = _TuitionFeestoCharge.ToString();
                                            break;
                                        case "radioButtonFeesPaymentPerYear":
                                            txtTutionFees.Text = string.Empty;
                                            decimal _Tuitionfeestocharge = 0;
                                            foreach (ListViewItem item in listViewFeePayments.Items)
                                            {
                                                ListViewItem.ListViewSubItem _tuitionfees = item.SubItems[1];
                                                _Tuitionfeestocharge += decimal.Parse(_tuitionfees.Text.ToString());


                                            }
                                            txtTutionFees.Text = _Tuitionfeestocharge.ToString();
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ComputeLowerFeesPaymentPlan()
        {
            try
            {
                if (_Student != null)
                {
                    txtTutionFees.Text = string.Empty;

                    foreach (Control ctrl in groupBoxFeesPaymentPlan.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton))
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                switch (((RadioButton)ctrl).Name)
                                {
                                    case "radioButtonFeesPaymentPerUnit":
                                        txtTutionFees.Text = string.Empty;
                                        decimal _Tuitionfeestocharge = 0;
                                        foreach (ListViewItem item in listViewFeePayments.Items)
                                        {
                                            ListViewItem.ListViewSubItem _tuitionfees = item.SubItems[1];
                                            _Tuitionfeestocharge += decimal.Parse(_tuitionfees.Text.ToString());
                                        }
                                        txtTutionFees.Text = _Tuitionfeestocharge.ToString();
                                        break;
                                    case "radioButtonFeeesPaymentPerSemester":
                                        txtTutionFees.Text = string.Empty;
                                        decimal _tuitionfeestocharge = 0;
                                        foreach (ListViewItem item in listViewFeePayments.Items)
                                        {
                                            ListViewItem.ListViewSubItem _tuitionfees = item.SubItems[1];
                                            _tuitionfeestocharge += decimal.Parse(_tuitionfees.Text.ToString());
                                        }
                                        txtTutionFees.Text = _tuitionfeestocharge.ToString();
                                        break;
                                    case "radioButtonFeesPaymentPerYear":
                                        txtTutionFees.Text = string.Empty;
                                        decimal _TuitionFeestoCharge = 0;
                                        foreach (ListViewItem item in listViewFeePayments.Items)
                                        {
                                            ListViewItem.ListViewSubItem _tuitionfees = item.SubItems[1];
                                            _TuitionFeestoCharge += decimal.Parse(_tuitionfees.Text.ToString());
                                        }
                                        txtTutionFees.Text = _TuitionFeestoCharge.ToString();
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonCash_CheckedChanged(object sender, EventArgs e)
        {
            if (_Student != null)
            {
                PopulateModeofFeesPayment();
            }
        }
        private void radioButtonMpesa_CheckedChanged(object sender, EventArgs e)
        {
            if (_Student != null)
            {
                PopulateModeofFeesPayment();
            }
        }
        private void radioButtonBankSlip_CheckedChanged(object sender, EventArgs e)
        {
            if (_Student != null)
            {
                PopulateModeofFeesPayment();
            }
        }
        private void radioButtonCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (_Student != null)
            {
                PopulateModeofFeesPayment();
            }
        }
        private void PopulateModeofFeesPayment()
        {
            try
            {
                if (_Student != null)
                { 
                    foreach (Control ctrl in groupBoxModeofPayment.Controls)
                    {
                        if (ctrl.GetType() == typeof(RadioButton))
                        {
                            if (((RadioButton)ctrl).Checked)
                            {
                                switch (((RadioButton)ctrl).Name)
                                {
                                    case "radioButtonCash":
                                        groupBoxCash.Visible = true;
                                        groupBoxCash.Location = groupBoxCheque.Location;
                                        groupBoxCheque.Visible = false;
                                        groupBoxMpesa.Visible = false;
                                        groupBoxBankSlip.Visible = false;

                                        break;
                                    case "radioButtonMpesa":
                                        groupBoxMpesa.Visible = true;
                                        groupBoxMpesa.Location = groupBoxCheque.Location;
                                        groupBoxCheque.Visible = false;
                                        groupBoxCash.Visible = false;
                                        groupBoxBankSlip.Visible = false;
                                        break;
                                    case "radioButtonBankSlip":
                                        groupBoxBankSlip.Visible = true;
                                        groupBoxBankSlip.Location = groupBoxCheque.Location;
                                        groupBoxCheque.Visible = false;
                                        groupBoxMpesa.Visible = false;
                                        groupBoxCash.Visible = false;
                                        break;
                                    case "radioButtonCheque":
                                        groupBoxCheque.Visible = true;
                                        groupBoxCheque.Location = groupBoxCheque.Location;
                                        groupBoxBankSlip.Visible = false; 
                                        groupBoxMpesa.Visible = false;
                                        groupBoxCash.Visible = false;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void tabControlStudentAdmission_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (_Student != null)
                {
                    if (tabControlStudentAdmission.SelectedTab == this.tabPageFeesPaymentPlan)
                    {

                        var schlquery = (from sc in db.Schools
                                         where sc.Id == _Student.SchoolId
                                         select sc).FirstOrDefault();
                        switch (schlquery.SchoolType)
                        {
                            case "1":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "2":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "3":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "4":
                                groupBoxTertiallyMode.Visible = true;
                                break;
                            case "5":
                                groupBoxTertiallyMode.Visible = true;
                                break;
                            case "6":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "7":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "8":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            default:
                                break;
                        }
                    }

                    if (tabControlStudentAdmission.SelectedTab == this.tabPageFeesPayment)
                    {
                        decimal _AmounttoPay =
                        this.observableTransactions
                                .Select(t => t.Amount).Sum();
                        txtAmounttoPay.Text = _AmounttoPay.ToString();
                        int acc = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);//_Student GL Account
                        if (acc != -1)
                        {
                            var _accountquery = (from a in db.Accounts
                                                 where a.Id == acc
                                                 select a).FirstOrDefault();
                            Account _account = _accountquery;
                            if (_account != null)
                            {
                                txtBalanceBF.Text = _account.BookBalance.ToString();
                            }
                            if (_account == null)
                            {
                                txtBalanceBF.Text = "0";
                            }
                        }
                        if (acc == -1)
                        {
                            txtBalanceBF.Text = "0";
                        }
                        txtAmountCharged.Text = txtTutionFees.Text;
                        txtAmounttoPay.Text = txtTutionFees.Text + txtBalanceBF.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        // Handles the ItemCheck event. The method uses the CurrentValue
        // property of the ItemCheckEventArgs to retrieve and tally the  
        // Total of the items Checked.  
        private void ListViewProgrammeYearCourses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (_Student != null)
                {

                    var _SchoolClassquery = (from sc in db.SchoolClasses
                                             join cs in db.ClassStreams on _Student.ClassStreamId equals cs.Id
                                             where cs.ClassId == sc.Id
                                             select sc).FirstOrDefault();
                    SchoolClass _schoolclass = _SchoolClassquery;

                    if (e.NewValue == CheckState.Unchecked)
                    {
                        double TuitionFee = Double.Parse(
                            this.ListViewProgrammeYearCourses.Items[e.Index].SubItems[2].Text);

                        CourseTuitionFee -= TuitionFee;

                        listViewFeePayments.Items.Clear();

                        listViewFeePayments.Items.Add(new ListViewItem(new string[]
                {
                   "Tuition",string.Format("{0:.##}", CourseTuitionFee)
                }));

                        var FeeStructureAcademicquery = from fsaq in db.FeeStructureAcademics
                                                        where fsaq.SchoolClassId == _schoolclass.Id
                                                        select fsaq;
                        List<FeeStructureAcademic> _FeeStructureAcademics = FeeStructureAcademicquery.ToList();

                        foreach (var fsa in _FeeStructureAcademics)
                        {

                            if (!fsa.Description.Equals("Tuition"))
                            {
                                listViewFeePayments.Items.Add(new ListViewItem(new string[]
                {
                   fsa.Description.Trim(),fsa.Amount.ToString()
                }));
                            }
                        }
                        var FeeStructureOthersquery = (from fsoq in db.FeeStructureOthers
                                                       join fsa in db.FeeStructureAcademics on _schoolclass.Id equals fsa.SchoolClassId
                                                       where fsoq.FeeStructureId == fsa.FeeStructureId
                                                       select fsoq).ToList();
                        List<FeeStructureOther> _FeeStructureOthers = new List<FeeStructureOther>();
                        foreach (var fs in FeeStructureOthersquery)
                        {
                            FeeStructureOther feestructureothers = fs;
                            if (!_FeeStructureOthers.Contains(feestructureothers))
                            {
                                _FeeStructureOthers.Add(feestructureothers);
                            }
                        }
                        foreach (var fo in _FeeStructureOthers)
                        {
                            listViewFeePayments.Items.Add(new ListViewItem(new string[]
                {
                   fo.Description.Trim(),fo.Amount.ToString()
                }));
                        }
                        foreach (ListViewItem item in listViewFeePayments.Items)
                        {
                            item.ImageIndex = 0;
                        }
                    }
                    else if ((e.NewValue == CheckState.Checked))
                    {
                        double TuitionFee = Double.Parse(
                            this.ListViewProgrammeYearCourses.Items[e.Index].SubItems[2].Text);

                        CourseTuitionFee += TuitionFee;

                        listViewFeePayments.Items.Clear();

                        listViewFeePayments.Items.Add(new ListViewItem(new string[]
                {
                   "Tuition",string.Format("{0:.##}", CourseTuitionFee)
                }));

                        var FeeStructureAcademicquery = from fsaq in db.FeeStructureAcademics
                                                        where fsaq.SchoolClassId == _schoolclass.Id
                                                        select fsaq;
                        List<FeeStructureAcademic> _FeeStructureAcademics = FeeStructureAcademicquery.ToList();

                        foreach (var fsa in _FeeStructureAcademics)
                        {
                            if (!fsa.Description.Equals("Tuition"))
                            {
                                listViewFeePayments.Items.Add(new ListViewItem(new string[]
                {
                   fsa.Description.Trim(),fsa.Amount.ToString()
                }));
                            }
                        }

                        var FeeStructureOthersquery = (from fso in db.FeeStructureOthers
                                                       join fsa in db.FeeStructureAcademics on fso.FeeStructureId equals fsa.FeeStructureId

                                                       where fsa.SchoolClassId == _schoolclass.Id
                                                       select fso).ToList();
                        List<FeeStructureOther> _FeeStructureOthers = new List<FeeStructureOther>();
                        foreach (var fs in FeeStructureOthersquery)
                        {
                            FeeStructureOther feestructureothers = fs;
                            if (!_FeeStructureOthers.Contains(feestructureothers))
                            {
                                _FeeStructureOthers.Add(feestructureothers);
                            }

                        }
                        foreach (var fo in _FeeStructureOthers)
                        {
                            listViewFeePayments.Items.Add(new ListViewItem(new string[]
                {
                   fo.Description.Trim(),fo.Amount.ToString()
                }));
                        }
                        foreach (ListViewItem item in listViewFeePayments.Items)
                        {
                            item.ImageIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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

        private void cboTransportLocations_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnSearchBankSortCode_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBanksSimpleForm saf = new Forms.SearchBanksSimpleForm(connection) { Owner = this };
                saf.OnBankListSelected += new SearchBanksSimpleForm.BankSelectHandler(saf_OnSetBankSortCodeListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnSetBankSortCodeListSelected(object sender, BankSelectEventArgs e)
        {
            SetBankSortCode(e._BankSortCode);
        }
        private void SetBankSortCode(vwBankBranch _vwBankBranch)
        {
            if (_vwBankBranch != null)
            {
                txtSlipBankSortCode.Text = _vwBankBranch.BankSortCode.Trim();
            }
        }
        private void btnSearchChqBankSortCode_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBanksSimpleForm saf = new Forms.SearchBanksSimpleForm(connection) { Owner = this };
                saf.OnBankListSelected += new SearchBanksSimpleForm.BankSelectHandler(saf_OnSetChqBankSortCodeListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnSetChqBankSortCodeListSelected(object sender, BankSelectEventArgs e)
        {
            SetChqBankSortCode(e._BankSortCode);
        }
        private void SetChqBankSortCode(vwBankBranch _vwBankBranch)
        {
            if (_vwBankBranch != null)
            {
                txtChqBankSortCode.Text = _vwBankBranch.BankSortCode.Trim();
            }
        }
        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchStudentsForm ssf = new SearchStudentsForm(connection);
                ssf.OnStudentsListSelected += new SearchStudentsForm.StudentsSelectHandler(ssf_OnStudentsListSelected);
                ssf.ShowDialog();
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
        private void txtBalanceBF_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = true;
                if (Char.IsLetter(e.KeyChar)) e.Handled = true;
                if (Char.IsNumber(e.KeyChar)) e.Handled = true;
                if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
                if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
                if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
                if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
                if (e.KeyChar == (char)Keys.Back) e.Handled = true;
                if (e.KeyChar == (char)Keys.Space) e.Handled = true;
                if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
                if (e.KeyChar == (char)Keys.Clear) e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAmountCharged_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = true;
                if (Char.IsLetter(e.KeyChar)) e.Handled = true;
                if (Char.IsNumber(e.KeyChar)) e.Handled = true;
                if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
                if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
                if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
                if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
                if (e.KeyChar == (char)Keys.Back) e.Handled = true;
                if (e.KeyChar == (char)Keys.Space) e.Handled = true;
                if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
                if (e.KeyChar == (char)Keys.Clear) e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAmounttoPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = true;
                if (Char.IsLetter(e.KeyChar)) e.Handled = true;
                if (Char.IsNumber(e.KeyChar)) e.Handled = true;
                if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
                if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
                if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
                if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
                if (e.KeyChar == (char)Keys.Back) e.Handled = true;
                if (e.KeyChar == (char)Keys.Space) e.Handled = true;
                if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
                if (e.KeyChar == (char)Keys.Clear) e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtTutionFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = true;
                if (Char.IsLetter(e.KeyChar)) e.Handled = true;
                if (Char.IsNumber(e.KeyChar)) e.Handled = true;
                if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
                if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
                if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
                if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
                if (e.KeyChar == (char)Keys.Back) e.Handled = true;
                if (e.KeyChar == (char)Keys.Space) e.Handled = true;
                if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
                if (e.KeyChar == (char)Keys.Clear) e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelectAll.Checked == true)
                {
                    foreach (ListViewItem lvi in ListViewProgrammeYearCourses.Items)
                    {
                        lvi.Checked = true;
                    }
                }
                if (chkSelectAll.Checked == false)
                {
                    foreach (ListViewItem lvi in ListViewProgrammeYearCourses.Items)
                    {
                        lvi.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtBankSortCode_Leave(object sender, EventArgs e)
        {
            try
            {
                lblBankSlipDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtSlipBankSortCode.Text))
                {
                    string _banksortcode = txtSlipBankSortCode.Text.Trim();
                    var bankbranchnamequery = (from vw in db.vwBankBranches
                                               where vw.BankSortCode == _banksortcode
                                               select vw).FirstOrDefault();
                    if (bankbranchnamequery != null)
                    {
                        lblBankSlipDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtBankSortCode_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblBankSlipDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtSlipBankSortCode.Text))
                {
                    string _banksortcode = txtSlipBankSortCode.Text.Trim();
                    var bankbranchnamequery = (from vw in db.vwBankBranches
                                               where vw.BankSortCode == _banksortcode
                                               select vw).FirstOrDefault();
                    if (bankbranchnamequery != null)
                    {
                        lblBankSlipDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtBankSortCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblBankSlipDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtSlipBankSortCode.Text))
                {
                    string _banksortcode = txtSlipBankSortCode.Text.Trim();
                    var bankbranchnamequery = (from vw in db.vwBankBranches
                                               where vw.BankSortCode == _banksortcode
                                               select vw).FirstOrDefault();
                    if (bankbranchnamequery != null)
                    {
                        lblBankSlipDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void txtBankSortCode_Validated(object sender, EventArgs e)
        {
            try
            {
                lblBankSlipDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtSlipBankSortCode.Text))
                {
                    string _banksortcode = txtSlipBankSortCode.Text.Trim();
                    var bankbranchnamequery = (from vw in db.vwBankBranches
                                               where vw.BankSortCode == _banksortcode
                                               select vw).FirstOrDefault();
                    if (bankbranchnamequery != null)
                    {
                        lblBankSlipDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtChqBankSortCode_Leave(object sender, EventArgs e)
        {
            try
            {
                lblBankChequeDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtChqBankSortCode.Text))
                {
                    string _banksortcode = txtChqBankSortCode.Text.Trim();
                    var bankbranchnamequery = (from vw in db.vwBankBranches
                                               where vw.BankSortCode == _banksortcode
                                               select vw).FirstOrDefault();
                    if (bankbranchnamequery != null)
                    {
                        lblBankChequeDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtChqBankSortCode_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblBankChequeDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtChqBankSortCode.Text))
                {
                    string _banksortcode = txtChqBankSortCode.Text.Trim();
                    var bankbranchnamequery = (from vw in db.vwBankBranches
                                               where vw.BankSortCode == _banksortcode
                                               select vw).FirstOrDefault();
                    if (bankbranchnamequery != null)
                    {
                        lblBankChequeDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtChqBankSortCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblBankChequeDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtChqBankSortCode.Text))
                {
                    string _banksortcode = txtChqBankSortCode.Text.Trim();
                    var bankbranchnamequery = (from vw in db.vwBankBranches
                                               where vw.BankSortCode == _banksortcode
                                               select vw).FirstOrDefault();
                    if (bankbranchnamequery != null)
                    {
                        lblBankChequeDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtChqBankSortCode_Validated(object sender, EventArgs e)
        {
            try
            {
                lblBankChequeDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtChqBankSortCode.Text))
                {
                    string _banksortcode = txtChqBankSortCode.Text.Trim();
                    var bankbranchnamequery = (from vw in db.vwBankBranches
                                               where vw.BankSortCode == _banksortcode
                                               select vw).FirstOrDefault();
                    if (bankbranchnamequery != null)
                    {
                        lblBankChequeDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnSMSGateWay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ReceivedSmsMessagesForm rsmf = new ReceivedSmsMessagesForm(user, connection) { Owner = this };
                rsmf.OnReceivedSmsMessagesSelected += new ReceivedSmsMessagesForm.ReceivedSmsMessagesSelectHandler(rsmf_OnReceivedSmsMessagesSelected);
                rsmf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void rsmf_OnReceivedSmsMessagesSelected(object sender, ReceivedSmsMessagesSelectEventArgs e)
        {
            try
            {
                SetMpesaPaymentDetails(e.Amount, e.Name, e.PhoneNumber, e.ReferenceNumber);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetMpesaPaymentDetails(decimal Amount,string Name,string PhoneNumber,string ReferenceNumber)
        {
            errorProvider1.Clear();
            try
            {
                decimal _amount;
                string _amt = Amount.ToString();
                if (decimal.TryParse(_amt, out _amount))
                {
                    txtMpesaAmountPaid.Text = _amount.ToString();
                }
                if (ReferenceNumber != null)
                {
                    txtMpesaReceiptNo.Text = ReferenceNumber;
                }
                if (Name != null)
                {
                    txtMpesaSenderName.Text = Name;
                }
                if (PhoneNumber != null)
                {
                    txtMpesaPhoneNumber.Text = PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void txtTutionFees_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTutionFees.Text))
                {
                    btnChargeFees.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtTutionFees.Text))
                {
                    btnChargeFees.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void tabControlStudentAdmission_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Student != null)
                {
                    if (tabControlStudentAdmission.SelectedTab == this.tabPageFeesPaymentPlan)
                    {

                        var schlquery = (from sc in db.Schools
                                         where sc.Id == _Student.SchoolId
                                         select sc).FirstOrDefault();
                        switch (schlquery.SchoolType)
                        {
                            case "1":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "2":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "3":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "4":
                                groupBoxTertiallyMode.Visible = true;
                                break;
                            case "5":
                                groupBoxTertiallyMode.Visible = true;
                                break;
                            case "6":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "7":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            case "8":
                                groupBoxTertiallyMode.Visible = false;
                                break;
                            default:
                                break;
                        }
                        switch (_Student.FeesPayPlan)
                        {
                            case "C":
                                radioButtonCash.Checked = true;
                                break;
                            case "M":
                                radioButtonMpesa.Checked = true;
                                break;
                            case "Q":
                                radioButtonCheque.Checked = true;
                                break;
                            case "B":
                                radioButtonBankSlip.Checked = true;
                                break;
                            default:
                                break;
                        }
                    }

                    if (tabControlStudentAdmission.SelectedTab == this.tabPageFeesPayment)
                    {
                        decimal _AmounttoPay =
                        this.observableTransactions
                                .Select(t => t.Amount).Sum();
                        txtAmounttoPay.Text = _AmounttoPay.ToString();
                        int acc = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);//_Student GL Account
                        if (acc != -1)
                        {
                            var _accountquery = (from a in db.Accounts
                                                 where a.Id == acc
                                                 select a).FirstOrDefault();
                            Account _account = _accountquery;
                            if (_account != null)
                            {
                                txtBalanceBF.Text = (_account.BookBalance * -1).ToString();
                            }
                            if (_account == null)
                            {
                                txtBalanceBF.Text = "0";
                            }
                        }
                        if (acc == -1)
                        {
                            txtBalanceBF.Text = "0";
                        }
                        txtAmountCharged.Text = decimal.Parse(txtTutionFees.Text).ToString();
                        txtAmounttoPay.Text = (decimal.Parse(txtTutionFees.Text) + decimal.Parse(txtBalanceBF.Text)).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void txtTutionFees_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTutionFees.Text))
                {
                    btnChargeFees.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtTutionFees.Text))
                {
                    btnChargeFees.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void txtAmounttoPay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAmounttoPay.Text))
                {
                    btnPostCharges.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtAmounttoPay.Text))
                {
                    btnPostCharges.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void txtAmounttoPay_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAmounttoPay.Text))
                {
                    btnPostCharges.Enabled = false;
                }
                if (!string.IsNullOrEmpty(txtAmounttoPay.Text))
                {
                    btnPostCharges.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ClearFeesPaymentControls()
        {
            try
            {
                txtBalanceBF.Text = string.Empty;
                txtAmountCharged.Text = string.Empty;
                txtAmounttoPay.Text = string.Empty;
                txtCashAmountPaid.Text = string.Empty;
                txtChequeAmountPaid.Text = string.Empty;
                txtChequeNo.Text = string.Empty;
                txtChqBankSortCode.Text = string.Empty;
                txtMpesaAmountPaid.Text = string.Empty;
                txtMpesaPhoneNumber.Text = string.Empty;
                txtMpesaReceiptNo.Text = string.Empty;
                txtMpesaSenderName.Text = string.Empty;
                txtSlipBankSortCode.Text = string.Empty;
                txtBankSlipAmountPaid.Text = string.Empty;
                txtBankSlipNo.Text = string.Empty;  
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ClearFeesPaymentPlanControls()
        {
            try
            {
                listViewFeePayments.Items.Clear();
                ListViewProgrammeYearCourses.Items.Clear();
                txtTutionFees.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }













    }
}