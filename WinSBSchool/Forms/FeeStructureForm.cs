using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class FeeStructureForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        BindingList<Transaction> observableTransactions;
        private int updateStatusCounter = 60;

        public FeeStructureForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            observableTransactions = new BindingList<Transaction>();

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished FeeStructureForm initialization", TAG)); 

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
        private void FeeStructureForm_Load(object sender, EventArgs e)
        {
            try
            {

                ListViewFeeStructureSummary.View = View.Details;
                ListViewFeeStructureSummary.GridLines = true;
                ListViewFeeStructureSummary.FullRowSelect = true;
                ListViewFeeStructureSummary.MultiSelect = false;
                ListViewFeeStructureSummary.HideSelection = false;
                ListViewFeeStructureSummary.Columns.Add("Description", 100, HorizontalAlignment.Left);
                // Width of -2 indicates auto-size.
                ListViewFeeStructureSummary.Columns.Add("Amount", -2, HorizontalAlignment.Center);
                ListViewFeeStructureSummary.Items.Clear();

                ImageList photoList = new ImageList();
                photoList.TransparentColor = Color.Blue;
                photoList.ColorDepth = ColorDepth.Depth32Bit;
                photoList.ImageSize = new Size(10, 10);
                photoList.Images.Add(Image.FromFile("Resources/greenmage.jpg"));
                ListViewFeeStructureSummary.SmallImageList = photoList;

                var _amountPeriods = new BindingList<KeyValuePair<string, string>>();
                _amountPeriods.Add(new KeyValuePair<string, string>("S", "Per Semester"));
                _amountPeriods.Add(new KeyValuePair<string, string>("Y", "Per Academic Year"));
                _amountPeriods.Add(new KeyValuePair<string, string>("D", "Once on Admission"));
                _amountPeriods.Add(new KeyValuePair<string, string>("P", "Once on Application"));
                _amountPeriods.Add(new KeyValuePair<string, string>("R", "Once on Admission(Refundable)"));

                DataGridViewComboBoxColumn colAcademicAmountPeriod = new DataGridViewComboBoxColumn();
                colAcademicAmountPeriod.HeaderText = "Amount Period";
                colAcademicAmountPeriod.Name = "cbAcademicAmountPeriod";
                colAcademicAmountPeriod.DataSource = _amountPeriods;
                colAcademicAmountPeriod.DisplayMember = "Value";
                colAcademicAmountPeriod.DataPropertyName = "AmountPeriod";
                colAcademicAmountPeriod.ValueMember = "Key";
                colAcademicAmountPeriod.MaxDropDownItems = 10;
                colAcademicAmountPeriod.DisplayIndex = 3;
                colAcademicAmountPeriod.MinimumWidth = 5;
                colAcademicAmountPeriod.Width = 100;
                colAcademicAmountPeriod.FlatStyle = FlatStyle.Flat;
                colAcademicAmountPeriod.DefaultCellStyle.NullValue = "--- Select ---";
                colAcademicAmountPeriod.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAcademicAmountPeriod.ReadOnly = true;
                if (!this.dataGridViewFeeStructureAcademic.Columns.Contains("cbAcademicAmountPeriod"))
                {
                    dataGridViewFeeStructureAcademic.Columns.Add(colAcademicAmountPeriod);
                }

                var _Accountsquery = from ac in db.Accounts
                                     where ac.Closed == false
                                     select ac;
                List<Account> _Accounts = _Accountsquery.ToList();
                DataGridViewComboBoxColumn colAccount = new DataGridViewComboBoxColumn();
                colAccount.HeaderText = "Account";
                colAccount.Name = "cbAccount";
                colAccount.DataSource = _Accounts;
                colAccount.DisplayMember = "AccountName";
                colAccount.DataPropertyName = "AccountId";
                colAccount.ValueMember = "Id";
                colAccount.MaxDropDownItems = 10;
                colAccount.DisplayIndex = 2;
                colAccount.MinimumWidth = 5;
                colAccount.Width = 150;
                colAccount.FlatStyle = FlatStyle.Flat;
                colAccount.DefaultCellStyle.NullValue = "--- Select ---";
                colAccount.ReadOnly = true;
                if (!this.dataGridViewFeeStructureAcademic.Columns.Contains("cbAccount"))
                {
                    dataGridViewFeeStructureAcademic.Columns.Add(colAccount);
                }

                var __fsoAccountsquery = from ac in db.Accounts
                                         where ac.Closed == false
                                         select ac;
                List<Account> _fsoAccounts = __fsoAccountsquery.ToList();
                DataGridViewComboBoxColumn colfsoAccount = new DataGridViewComboBoxColumn();
                colfsoAccount.HeaderText = "Account";
                colfsoAccount.Name = "cbfsoAccount";
                colfsoAccount.DataSource = _fsoAccounts;
                colfsoAccount.DisplayMember = "AccountName";
                colfsoAccount.DataPropertyName = "AccountId";
                colfsoAccount.ValueMember = "Id";
                colfsoAccount.MaxDropDownItems = 10;
                colfsoAccount.DisplayIndex = 2;
                colfsoAccount.MinimumWidth = 5;
                colfsoAccount.Width = 150;
                colfsoAccount.FlatStyle = FlatStyle.Flat;
                colfsoAccount.DefaultCellStyle.NullValue = "--- Select ---";
                colfsoAccount.ReadOnly = true;
                if (!this.dataGridViewFeeStructureOthers.Columns.Contains("cbfsoAccount"))
                {
                    dataGridViewFeeStructureOthers.Columns.Add(colfsoAccount);
                }

                var _AmountPeriods = new BindingList<KeyValuePair<string, string>>();
                _AmountPeriods.Add(new KeyValuePair<string, string>("S", "Per Semester"));
                _AmountPeriods.Add(new KeyValuePair<string, string>("Y", "Per Academic Year"));
                _AmountPeriods.Add(new KeyValuePair<string, string>("D", "Once on Admission"));
                _AmountPeriods.Add(new KeyValuePair<string, string>("P", "Once on Application"));
                _AmountPeriods.Add(new KeyValuePair<string, string>("R", "Once on Admission(Refundable)"));
                DataGridViewComboBoxColumn colOthersAmountPeriod = new DataGridViewComboBoxColumn();
                colOthersAmountPeriod.HeaderText = "Amount Period";
                colOthersAmountPeriod.Name = "cbOthersAmountPeriod";
                colOthersAmountPeriod.DataSource = _amountPeriods;
                colOthersAmountPeriod.DisplayMember = "Value";
                colOthersAmountPeriod.DataPropertyName = "AmountPeriod";
                colOthersAmountPeriod.ValueMember = "Key";
                colOthersAmountPeriod.MaxDropDownItems = 10;
                colOthersAmountPeriod.DisplayIndex = 4;
                colOthersAmountPeriod.MinimumWidth = 5;
                colOthersAmountPeriod.Width = 150;
                colOthersAmountPeriod.FlatStyle = FlatStyle.Flat;
                colOthersAmountPeriod.DefaultCellStyle.NullValue = "--- Select ---";
                colOthersAmountPeriod.ReadOnly = true;
                if (!this.dataGridViewFeeStructureOthers.Columns.Contains("cbOthersAmountPeriod"))
                {
                    dataGridViewFeeStructureOthers.Columns.Add(colOthersAmountPeriod);
                }

                var _ApplicableTo = new BindingList<KeyValuePair<string, string>>();
                _ApplicableTo.Add(new KeyValuePair<string, string>("A", "All"));
                _ApplicableTo.Add(new KeyValuePair<string, string>("B", "Boarder"));
                _ApplicableTo.Add(new KeyValuePair<string, string>("N", "Non-Boarder"));
                DataGridViewComboBoxColumn colApplicableTo = new DataGridViewComboBoxColumn();
                colApplicableTo.HeaderText = "Applicable To";
                colApplicableTo.Name = "cbApplicableTo";
                colApplicableTo.DataSource = _ApplicableTo;
                colApplicableTo.DisplayMember = "Value";
                colApplicableTo.DataPropertyName = "ApplicableTo";
                colApplicableTo.ValueMember = "Key";
                colApplicableTo.MaxDropDownItems = 10;
                colApplicableTo.DisplayIndex = 5;
                colApplicableTo.MinimumWidth = 5;
                colApplicableTo.Width = 200;
                colApplicableTo.FlatStyle = FlatStyle.Flat;
                colApplicableTo.DefaultCellStyle.NullValue = "--- Select ---";
                colApplicableTo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colApplicableTo.ReadOnly = true;
                if (!this.dataGridViewFeeStructureOthers.Columns.Contains("cbApplicableTo"))
                {
                    dataGridViewFeeStructureOthers.Columns.Add(colApplicableTo);
                }

                var _SchoolClassesquery = from sc in db.SchoolClasses
                                          where sc.IsDeleted == false
                                          select sc;
                List<SchoolClass> _SchoolClasses = _SchoolClassesquery.ToList();
                cboClass.DataSource = _SchoolClasses;
                cboClass.ValueMember = "Id";
                cboClass.DisplayMember = "ClassName";

                var _termsquery = (from tm in db.ExamPeriods
                                   where tm.Status == "A"
                                   where tm.IsDeleted == false
                                   select tm.Term).Distinct().ToList();
                cboTerm.DataSource = _termsquery;


                var fstrctr = from fs in db.FeesStructures
                              where fs.IsDeleted == false
                              select fs;
                List<FeesStructure> _FeeStructure = fstrctr.ToList();
                bindingSourceFeeStructure.DataSource = _FeeStructure;
                dataGridViewFeeStructure.AutoGenerateColumns = false;
                this.dataGridViewFeeStructure.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewFeeStructure.DataSource = bindingSourceFeeStructure;
                groupBox2.Text = bindingSourceFeeStructure.Count.ToString();

                dataGridViewFeeStructureAcademic.AutoGenerateColumns = false;
                this.dataGridViewFeeStructureAcademic.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewFeeStructureAcademic.DataSource = bindingSourceFeeStructureAcademic;
                groupBox10.Text = bindingSourceFeeStructureAcademic.Count.ToString();

                dataGridViewFeeStructureOthers.AutoGenerateColumns = false;
                this.dataGridViewFeeStructureOthers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewFeeStructureOthers.DataSource = bindingSourceFeeStructureOthers;
                groupBox7.Text = bindingSourceFeeStructureOthers.Count.ToString();

                PopulateFeeStructures();

                progressBarProcess.Visible = false;

                lblTimeElasped.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateFeeStructures()
        {
            try
            {
                if (dataGridViewFeeStructure.SelectedRows.Count != 0)
                {

                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    if (cboClass.SelectedIndex != -1 && cboTerm.SelectedIndex != -1)
                    {
                        bindingSourceFeeStructureAcademic.DataSource = null;
                        bindingSourceFeeStructureOthers.DataSource = null;

                        SchoolClass _SchoolClass = (SchoolClass)cboClass.SelectedItem;
                        int _Term = (int)cboTerm.SelectedItem;
                        var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                          where fs.FeeStructureId == _FeesStructure.Id
                                                          where fs.SchoolClassId == _SchoolClass.Id
                                                          where fs.Term == _Term
                                                          where fs.IsDeleted == false
                                                          select fs;
                        List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();
                        bindingSourceFeeStructureAcademic.DataSource = _FeeStructureAcademics;
                        groupBox10.Text = bindingSourceFeeStructureAcademic.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewFeeStructureAcademic.Rows)
                        {
                            dataGridViewFeeStructureAcademic.Rows[dataGridViewFeeStructureAcademic.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewFeeStructureAcademic.Rows.Count - 1;
                            bindingSourceFeeStructureAcademic.Position = nRowIndex;
                        }
                    }
                    var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                                   where fs.FeeStructureId == _FeesStructure.Id
                                                   where fs.IsDeleted == false
                                                   select fs;
                    List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();
                    bindingSourceFeeStructureOthers.DataSource = _FeeStructureOthers;
                    groupBox7.Text = bindingSourceFeeStructureOthers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewFeeStructureOthers.Rows)
                    {
                        dataGridViewFeeStructureOthers.Rows[dataGridViewFeeStructureOthers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewFeeStructureOthers.Rows.Count - 1;
                        bindingSourceFeeStructureOthers.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var dfscl = (from sub in db.FeesStructures
                             where sub.IsDefault == true
                             where sub.IsDeleted == false
                             select sub);
                if (dfscl.Count() > 0)
                {
                    Forms.AddFeeStructureForm asf = new Forms.AddFeeStructureForm(connection) { Owner = this };
                    asf.DisableChechBox();
                    asf.ShowDialog();
                }
                else
                {
                    Forms.AddFeeStructureForm asf = new Forms.AddFeeStructureForm(connection) { Owner = this };
                    asf.SetCheckBox();
                    asf.ShowDialog();
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    var dfltSchl = (from sub in db.FeesStructures
                                    where sub.IsDefault == true
                                    where sub.IsDeleted == false
                                    select sub);

                    if (dfltSchl.Count() != 0 && _FeesStructure.IsDefault == true)
                    {
                        Forms.EditFeeStructureForm efsf = new Forms.EditFeeStructureForm(_FeesStructure, connection) { Owner = this };
                        efsf.Text = _FeesStructure.Description.ToUpper().Trim();
                        efsf.ShowDialog();
                    }
                    if (dfltSchl.Count() != 0 && _FeesStructure.IsDefault != true)
                    {
                        Forms.EditFeeStructureForm efs = new Forms.EditFeeStructureForm(_FeesStructure, connection) { Owner = this };
                        efs.Text = _FeesStructure.Description.ToUpper().Trim();
                        efs.DisableCheckBox();
                        efs.ShowDialog();
                    }
                    if (dfltSchl.Count() == 0)
                    {
                        Forms.EditFeeStructureForm efs = new Forms.EditFeeStructureForm(_FeesStructure, connection) { Owner = this };
                        efs.Text = _FeesStructure.Description.ToUpper().Trim();
                        efs.SetCheckBox();
                        efs.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewFeeStructureAcademic_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFeeStructureAcademic.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeeStructureAcademic _FeeStructureAcademic = (DAL.FeeStructureAcademic)bindingSourceFeeStructureAcademic.Current;
                    Forms.EditFeeStructureAcademicForm es = new Forms.EditFeeStructureAcademicForm(_FeeStructureAcademic, user, connection, _notificationmessageEventname) { Owner = this };
                    es.Text = _FeeStructureAcademic.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewFeeStructureOthers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFeeStructureOthers.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeeStructureOther _FeeStructureOther = (DAL.FeeStructureOther)bindingSourceFeeStructureOthers.Current;
                    Forms.EditFeeStructureOthersForm es = new Forms.EditFeeStructureOthersForm(_FeeStructureOther, user, connection, _notificationmessageEventname) { Owner = this };
                    es.Text = _FeeStructureOther.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    var _FeeStructureAcademicsquery = from fsa in db.FeeStructureAcademics
                                                      where fsa.FeeStructureId == _FeesStructure.Id
                                                      where fsa.IsDeleted == false
                                                      select fsa;

                    List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();

                    var _FeeStructureOthersquery = from fso in db.FeeStructureOthers
                                                   where fso.FeeStructureId == _FeesStructure.Id
                                                   where fso.IsDeleted == false
                                                   select fso;

                    List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();

                    if (_FeeStructureAcademics.Count > 0)
                    {
                        MessageBox.Show("There is Fee Structure Academic Associated with this Fee Structure.\n Delete the Fee Structure Academic First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (_FeeStructureOthers.Count > 0)
                    {
                        MessageBox.Show("There is a Fee Structure Others Associated with this Fee Structure.\n Delete the Fee Structure Others First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Fee Structure\n" + _FeesStructure.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            db.FeesStructures.DeleteObject(_FeesStructure);
                            db.SaveChanges();
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        public void RefreshGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourceFeeStructure.DataSource = null;
                //set the datasource to a method
                var fstrctr = from fs in db.FeesStructures
                              where fs.IsDeleted == false
                              select fs;
                List<FeesStructure> _FeeStructure = fstrctr.ToList();
                bindingSourceFeeStructure.DataSource = _FeeStructure;
                groupBox2.Text = bindingSourceFeeStructure.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewFeeStructure.Rows)
                {
                    dataGridViewFeeStructure.Rows[dataGridViewFeeStructure.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewFeeStructure.Rows.Count - 1;
                    bindingSourceFeeStructure.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGridOthers()
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;
                    //set the datasource to null
                    bindingSourceFeeStructureOthers.DataSource = null;
                    //set the datasource to a method
                    var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                                   where fs.FeeStructureId == _FeesStructure.Id
                                                   where fs.IsDeleted == false
                                                   select fs;
                    List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();
                    bindingSourceFeeStructureOthers.DataSource = _FeeStructureOthers;
                    groupBox7.Text = bindingSourceFeeStructureOthers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewFeeStructureOthers.Rows)
                    {
                        dataGridViewFeeStructureOthers.Rows[dataGridViewFeeStructureOthers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewFeeStructureOthers.Rows.Count - 1;
                        bindingSourceFeeStructureOthers.Position = nRowIndex;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void RefreshTermGrid()
        {
            try
            {
                var _termsquery = (from tm in db.ExamPeriods
                                   where tm.IsDeleted == false
                                   select tm.Term).Distinct().ToList();
                cboTerm.DataSource = _termsquery;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGridAcademics()
        {

            if (dataGridViewFeeStructure.SelectedRows.Count != 0 && cboClass.SelectedIndex != -1 && cboTerm.SelectedIndex != -1)
            {
                try
                {
                    bindingSourceFeeStructureAcademic.DataSource = null;

                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    int term = (int)cboTerm.SelectedItem;

                    SchoolClass _SchoolClass = (SchoolClass)cboClass.SelectedItem;

                    var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                      where fs.FeeStructureId == _FeesStructure.Id
                                                      where fs.SchoolClassId == _SchoolClass.Id
                                                      where fs.Term == term
                                                      where fs.IsDeleted == false
                                                      select fs;
                    List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();

                    bindingSourceFeeStructureAcademic.DataSource = _FeeStructureAcademics;
                    groupBox10.Text = bindingSourceFeeStructureAcademic.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewFeeStructureAcademic.Rows)
                    {
                        dataGridViewFeeStructureAcademic.Rows[dataGridViewFeeStructureAcademic.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewFeeStructureAcademic.Rows.Count - 1;
                        bindingSourceFeeStructureAcademic.Position = nRowIndex;
                    }
                }

                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewFeeStructure_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    var dfltSchl = (from sub in db.FeesStructures
                                    where sub.IsDefault == true
                                    where sub.IsDeleted == false
                                    select sub);

                    if (dfltSchl.Count() != 0 && _FeesStructure.IsDefault == true)
                    {
                        Forms.EditFeeStructureForm efsf = new Forms.EditFeeStructureForm(_FeesStructure, connection) { Owner = this };
                        efsf.Text = _FeesStructure.Description.ToUpper().Trim();
                        efsf.ShowDialog();
                    }
                    if (dfltSchl.Count() != 0 && _FeesStructure.IsDefault != true)
                    {
                        Forms.EditFeeStructureForm efs = new Forms.EditFeeStructureForm(_FeesStructure, connection) { Owner = this };
                        efs.Text = _FeesStructure.Description.ToUpper().Trim();
                        efs.DisableCheckBox();
                        efs.ShowDialog();
                    }
                    if (dfltSchl.Count() == 0)
                    {
                        Forms.EditFeeStructureForm efs = new Forms.EditFeeStructureForm(_FeesStructure, connection) { Owner = this };
                        efs.Text = _FeesStructure.Description.ToUpper().Trim();
                        efs.SetCheckBox();
                        efs.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void btnPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                if (dataGridViewFeeStructure.SelectedRows.Count != 0 && cboClass.SelectedIndex != -1 && cboTerm.SelectedIndex != -1)
                {
                    FeesStructure _feeStructure = (FeesStructure)bindingSourceFeeStructure.Current;
                    SchoolClass _schoolclass = (SchoolClass)cboClass.SelectedItem;
                    int _Term = (int)cboTerm.SelectedItem;

                    //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(_Term, _feeStructure, _schoolclass, user, connection);
                    //_viewer.WindowState = FormWindowState.Normal;
                    //_viewer.StartPosition = FormStartPosition.CenterScreen;
                    //_viewer.Show();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            } 
        } 
        private void btnAddAcademicFeeStructure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0 && cboClass.SelectedIndex != -1)
            {
                try
                {
                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;
                    SchoolClass sc = (SchoolClass)cboClass.SelectedItem;

                    if (cboTerm.SelectedIndex != -1)
                    {

                        int term = (int)cboTerm.SelectedItem;
                        AddFeeStructureAcademicForm aepf = new AddFeeStructureAcademicForm(term, _FeesStructure, sc, connection) { Owner = this };
                        aepf.ShowDialog();
                    }
                    if (cboTerm.SelectedIndex == -1)
                    {
                        Forms.AddFeeStructureAcademicForm asf = new Forms.AddFeeStructureAcademicForm(_FeesStructure, sc, connection) { Owner = this };
                        asf.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void btnEditAcademicFeeStructure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructureAcademic.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeeStructureAcademic _FeeStructureAcademic = (DAL.FeeStructureAcademic)bindingSourceFeeStructureAcademic.Current;
                    Forms.EditFeeStructureAcademicForm es = new Forms.EditFeeStructureAcademicForm(_FeeStructureAcademic, user, connection, _notificationmessageEventname) { Owner = this };
                    es.Text = _FeeStructureAcademic.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void btDeleteAcademicFeeStructure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructureAcademic.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeeStructureAcademic _FeeStructureAcademic = (DAL.FeeStructureAcademic)bindingSourceFeeStructureAcademic.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Fees Structure Academic\n" + _FeeStructureAcademic.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.FeeStructureAcademics.DeleteObject(_FeeStructureAcademic);
                        db.SaveChanges();
                        RefreshGridAcademics();
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnAddOtherFeeStructure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;
                    Forms.AddFeeStructureOthersForm asf = new Forms.AddFeeStructureOthersForm(_FeesStructure, user, connection, _notificationmessageEventname) { Owner = this };
                    asf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void btnEditOtherFeeStructure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructureOthers.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeeStructureOther _FeeStructureOther = (DAL.FeeStructureOther)bindingSourceFeeStructureOthers.Current;
                    Forms.EditFeeStructureOthersForm es = new Forms.EditFeeStructureOthersForm(_FeeStructureOther, user, connection, _notificationmessageEventname) { Owner = this };
                    es.Text = _FeeStructureOther.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void btnDeleteOtherFeeStructure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructureOthers.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeeStructureOther _FeeStructureOther = (DAL.FeeStructureOther)bindingSourceFeeStructureOthers.Current;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Fees Structure Other\n" + _FeeStructureOther.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.FeeStructureOthers.DeleteObject(_FeeStructureOther);
                        db.SaveChanges();
                        RefreshGridOthers();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void btnCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void dataGridViewFeeStructure_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0)
            {
                try
                {
                    bindingSourceFeeStructureAcademic.DataSource = null;
                    bindingSourceFeeStructureOthers.DataSource = null;

                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    if (cboClass.SelectedIndex != -1 && cboTerm.SelectedIndex != -1)
                    {
                        SchoolClass _SchoolClass = (SchoolClass)cboClass.SelectedItem;

                        int term = (int)cboTerm.SelectedItem;

                        var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                          where fs.FeeStructureId == _FeesStructure.Id
                                                          where fs.SchoolClassId == _SchoolClass.Id
                                                          where fs.Term == term
                                                          where fs.IsDeleted == false
                                                          select fs;
                        List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();
                        bindingSourceFeeStructureAcademic.DataSource = _FeeStructureAcademics;
                        groupBox10.Text = bindingSourceFeeStructureAcademic.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewFeeStructureAcademic.Rows)
                        {
                            dataGridViewFeeStructureAcademic.Rows[dataGridViewFeeStructureAcademic.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewFeeStructureAcademic.Rows.Count - 1;
                            bindingSourceFeeStructureAcademic.Position = nRowIndex;
                        }
                    }
                    var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                                   where fs.FeeStructureId == _FeesStructure.Id
                                                   where fs.IsDeleted == false
                                                   select fs;
                    List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();
                    bindingSourceFeeStructureOthers.DataSource = _FeeStructureOthers;
                    groupBox7.Text = bindingSourceFeeStructureOthers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewFeeStructureOthers.Rows)
                    {
                        dataGridViewFeeStructureOthers.Rows[dataGridViewFeeStructureOthers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewFeeStructureOthers.Rows.Count - 1;
                        bindingSourceFeeStructureOthers.Position = nRowIndex;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool ValidFeesStructure()
        {
            bool valid = false;
            var totalq = (from fs in db.FeesStructures
                          where fs.IsDefault == true
                          select fs).FirstOrDefault();

            if (totalq != null)
            {
                valid = true;
            }
            if (totalq == null)
            {
                valid = false;
            }
            return valid;
        }
        private void groupBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count > 0)
            {
                if (!ValidFeesStructure())
                {
                    MessageBox.Show("No default Fee Structure is set!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }
        private string BuildNarrative(Student _student, ClassStream _ClsStrm, SchoolClass _SchoolClass, int accountid, decimal amount, string description, string TType)
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
                            narr += description + ",  Account =  " + " Name: [ " + _account.AccountName + " ] " + " No:  [ " + _account.AccountNo + " ] " + " Amount: [ " + amount.ToString("#,##0") + " ] " + ", Student =  Name: [ " + _student.StudentSurName + "  " + _student.StudentOtherNames + " ] " + " Admin No: [ " + _student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + ",  Account = " + " Name: [ " + _account.AccountName + ", No: " + _account.AccountNo + "] " + " Amount [ " + amount.ToString("#,##0") + " ]";
                            break;
                    } 
                }
                if (_account == null)
                {

                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + ",  Amount: [ " + amount.ToString("#,##0") + " ] " + ", Student =  Name: [ " + _student.StudentSurName + "  " + _student.StudentOtherNames + " ] " + " Admin No: [ " + _student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
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
        public bool NotifyMessage(string _Title, string _Text)
        {
            try
            {
                appNotifyIcon.Text = Utils.APP_NAME;
                appNotifyIcon.Icon = new Icon("Resources/Icons/SchoolStudents.ico");
                appNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                appNotifyIcon.BalloonTipTitle = _Title;
                appNotifyIcon.BalloonTipText = _Text;
                appNotifyIcon.Visible = true;
                appNotifyIcon.ShowBalloonTip(900000);

                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                return false;
            }
        }
        private void btnChargeFees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0 && cboTerm.SelectedIndex != -1)
            {
                try
                {
                    progressBarProcess.Visible = true;
                    int _counter = 0;
                    DateTime startTime = DateTime.Now;
                    lblTimeElasped.Text = string.Empty;

                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    int _Term = (int)cboTerm.SelectedItem;

                    var _Studentsquery = from st in db.Students
                                         where st.Status == "A"
                                         select st;
                    List<Student> _Students = _Studentsquery.ToList();

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

                    progressBarProcess.Minimum = 0;
                    progressBarProcess.Maximum = _Students.Count();

                    ChargeFeesService cfs = new ChargeFeesService(db, rep);

                    cfs.OnCompleteChargeFees += new ChargeFeesService.ChargeFeesCompleteEventHandler(cfs_OnCompleteChargeFees);
                    cfs.ChargeStudentsFees(_Students, _FeesStructure.Id, _Term, _transRef, user, _counter);

                    DateTime endTime = DateTime.Now;

                    TimeSpan tt = endTime - startTime;

                    lblTimeElasped.Text = string.Format("{0} ms", tt.TotalMilliseconds);

                    updateStatusTimer.Tick += new EventHandler(updateStatusTimer_Tick);
                    updateStatusTimer.Interval = 1000; // 1 second
                    updateStatusTimer.Start();

                    MessageBox.Show("Fee Charges Successfull!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void updateStatusTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                updateStatusCounter--;
                if (updateStatusCounter == 0)
                {
                    lblTimeElasped.Text = string.Empty;
                    updateStatusTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cfs_OnCompleteChargeFees(object sender, ChargeFeesCompleteEventArg e)
        {
            try
            {
                progressBarProcess.Value = e.StatusValue;
                NotifyMessage("ACCOUNTING ENGINE RUNNING...", e._Template);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0)
            {
                if (tabControl1.SelectedTab == tabPageSummary)
                {
                    try
                    {
                        DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                        var _SchoolClassesquery = (from sc in db.SchoolClasses
                                                   select sc).Distinct().ToList();
                        ListViewFeeStructureSummary.Items.Clear();
                        ListViewFeeStructureSummary.ShowGroups = true;
                        foreach (var sc in _SchoolClassesquery)
                        {
                            decimal _FeestoCharge = 0;

                            ListViewGroup _group =
         new ListViewGroup(sc.ClassName.Trim(), sc.ClassName.Trim());
                            ListViewFeeStructureSummary.Groups.Add(_group);

                            var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                              where fs.FeeStructureId == _FeesStructure.Id
                                                              where fs.SchoolClassId == sc.Id
                                                              select fs;
                            List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();

                            foreach (FeeStructureAcademic feeStructureAcademic in _FeeStructureAcademics)
                            {
                                ListViewFeeStructureSummary.Items.Add(new ListViewItem(new string[]
                {
                    feeStructureAcademic.Description.ToString(),feeStructureAcademic.Amount.ToString() 
                }, _group));
                            }
                            var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                                           where fs.FeeStructureId == _FeesStructure.Id
                                                           select fs;
                            List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();
                            foreach (FeeStructureOther feeStructureOther in _FeeStructureOthers)
                            {
                                ListViewFeeStructureSummary.Items.Add(new ListViewItem(new string[]
                {
                    feeStructureOther.Description.ToString(),feeStructureOther.Amount.ToString() 
                }, _group));
                            }

                            foreach (ListViewItem item in ListViewFeeStructureSummary.Groups[_group.Name].Items)
                            {
                                ListViewItem.ListViewSubItem _tuitionfees = item.SubItems[1];
                                _FeestoCharge += decimal.Parse(_tuitionfees.Text.ToString());

                            }
                            ListViewFeeStructureSummary.Items.Add(new ListViewItem(new string[]
                {
                    "Total Fees",_FeestoCharge.ToString() 
                }, _group));
                        }
                        foreach (ListViewItem item in ListViewFeeStructureSummary.Items)
                        {
                            item.ImageIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
        }

        private void dataGridViewFeeStructure_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewFeeStructureAcademic_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewFeeStructureOthers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0 && cboClass.SelectedIndex != -1 && cboTerm.SelectedIndex != -1)
            {
                try
                {
                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cboClass.SelectedItem;

                    int term = (int)cboTerm.SelectedItem;

                    var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                      where fs.FeeStructureId == _FeesStructure.Id
                                                      where fs.SchoolClassId == _SchoolClass.Id
                                                      where fs.Term == term
                                                      where fs.IsDeleted == false
                                                      select fs;
                    List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();
                    bindingSourceFeeStructureAcademic.DataSource = _FeeStructureAcademics;
                    groupBox10.Text = bindingSourceFeeStructureAcademic.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewFeeStructureAcademic.Rows)
                    {
                        dataGridViewFeeStructureAcademic.Rows[dataGridViewFeeStructureAcademic.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewFeeStructureAcademic.Rows.Count - 1;
                        bindingSourceFeeStructureAcademic.Position = nRowIndex;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void cboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridViewFeeStructure.SelectedRows.Count != 0 && cboClass.SelectedIndex != -1 && cboTerm.SelectedIndex != -1)
            {
                try
                {
                    DAL.FeesStructure _FeesStructure = (DAL.FeesStructure)bindingSourceFeeStructure.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cboClass.SelectedItem;

                    int term = (int)cboTerm.SelectedItem;

                    var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                      where fs.FeeStructureId == _FeesStructure.Id
                                                      where fs.SchoolClassId == _SchoolClass.Id
                                                      where fs.Term == term
                                                      where fs.IsDeleted == false
                                                      select fs;
                    List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();
                    bindingSourceFeeStructureAcademic.DataSource = _FeeStructureAcademics;
                    groupBox10.Text = bindingSourceFeeStructureAcademic.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewFeeStructureAcademic.Rows)
                    {
                        dataGridViewFeeStructureAcademic.Rows[dataGridViewFeeStructureAcademic.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewFeeStructureAcademic.Rows.Count - 1;
                        bindingSourceFeeStructureAcademic.Position = nRowIndex;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
    }



    public class ChargeFeesService
    {
        //delegate
        public delegate void ChargeFeesCompleteEventHandler(object sender, ChargeFeesCompleteEventArg e);
        //event
        public event ChargeFeesCompleteEventHandler OnCompleteChargeFees;

        SBSchoolDBEntities db;
        Repository rep;

        public ChargeFeesService(SBSchoolDBEntities _db, Repository _rep)
        {
            if (_db == null)
                throw new ArgumentNullException("SBSchoolDBEntities");
            db = _db;

            if (_rep == null)
                throw new ArgumentNullException("Repository");
            rep = _rep;

        }
        public void ChargeStudentsFees(List<Student> _Students, int _FeesStructureId, int _Term, string _transRef, string user, int _counter)
        {
            try
            {
                decimal _bookbalance = 0;
                decimal _clearedbalance = 0;

                foreach (Student s in _Students)
                {
                    if (s.GLAccountId != null)
                    {
                        _bookbalance = rep.GetStudentGLAccountBookBalance(s.GLAccountId ?? 1);
                        _clearedbalance = rep.GetStudentGLAccountClearedBalance(s.GLAccountId ?? 1);
                    }
                    if (s.GLAccountId == null)
                    {
                        _bookbalance = 0;
                        _clearedbalance = 0;
                    }
                    List<Transaction> _Transactions = this.ComputeFees(s, _FeesStructureId, _Term, _transRef, user, _counter);

                    rep.PostTransactions(_Transactions);
                    _counter++;
                    OnCompleteChargeFees(this, new ChargeFeesCompleteEventArg(_counter, "Admin  No: " + s.AdminNo + Environment.NewLine + "Name: " + s.StudentSurName + " " + s.StudentOtherNames + Environment.NewLine + "Book Balance: " + _bookbalance.ToString() + Environment.NewLine + "Cleared Balance: " + _clearedbalance.ToString() + Environment.NewLine + "Stream: " + s.ClassStream.Description + Environment.NewLine + "Class: " + s.ClassStream.SchoolClass.ClassName));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public List<Transaction> ComputeFees(Student _student, int feestructureId, int _term, string _transRef, string user, int _counter)
        {
            try
            {
                List<Transaction> lst = new List<Transaction>();

                var cls = (from cs in db.ClassStreams
                           join st in db.Students on cs.Id equals st.ClassStreamId
                           where st.Id == _student.Id
                           select cs).FirstOrDefault();

                ClassStream _ClsStrm = cls;
                var _SchoolClassesquery = (from sc in db.SchoolClasses
                                           join cs in db.ClassStreams on _student.ClassStreamId equals cs.Id
                                           where cs.ClassId == sc.Id
                                           select sc).FirstOrDefault();

                SchoolClass _SchoolClass = _SchoolClassesquery;

                var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                  where fs.FeeStructureId == feestructureId
                                                  where fs.Term == _term
                                                  where fs.SchoolClassId == _SchoolClass.Id
                                                  select fs;

                List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();

                var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                               where fs.FeeStructureId == feestructureId
                                               select fs;

                List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();

                foreach (FeeStructureAcademic feeStructureAcademic in _FeeStructureAcademics)
                {

                    //Debit transaction
                    Transaction drtxn = new Transaction();
                    drtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                    int dracc = rep.GetStudentGLAccount(_student.GLAccountId ?? -1);
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
                    crtxn.Narrative = this.BuildNarrative(_student, _ClsStrm, _SchoolClass, drtxn.AccountId, crtxn.Amount, feeStructureAcademic.Description, "C");
                    crtxn.UserName = user;
                    crtxn.Authorizer = "SYSTEM";
                    crtxn.StatementFlag = "Credit";
                    crtxn.PostDate = DateTime.Today;
                    crtxn.ValueDate = DateTime.Today;
                    crtxn.RecordDate = DateTime.Today;
                    crtxn.TransRef = _transRef;
                    crtxn.IsDeleted = false;

                    lst.Add(crtxn);

                    drtxn.Narrative = this.BuildNarrative(_student, _ClsStrm, _SchoolClass, crtxn.AccountId, drtxn.Amount, feeStructureAcademic.Description, "D");

                    lst.Add(drtxn); 
                }
                foreach (FeeStructureOther _feeStructureOther in _FeeStructureOthers)
                {

                    //Debit transaction
                    Transaction drtxn = new Transaction();
                    drtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                    int dracc = rep.GetStudentGLAccount(_student.GLAccountId ?? -1);
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
                    crtxn.Narrative = this.BuildNarrative(_student, _ClsStrm, _SchoolClass, drtxn.Id, drtxn.Amount, _feeStructureOther.Description, "C");
                    crtxn.UserName = user;
                    crtxn.Authorizer = "SYSTEM";
                    crtxn.StatementFlag = "Credit";
                    crtxn.PostDate = DateTime.Today;
                    crtxn.ValueDate = DateTime.Today;
                    crtxn.RecordDate = DateTime.Today;
                    crtxn.TransRef = _transRef;
                    crtxn.IsDeleted = false;

                    lst.Add(crtxn);

                    drtxn.Narrative = this.BuildNarrative(_student, _ClsStrm, _SchoolClass, crtxn.AccountId, crtxn.Amount, _feeStructureOther.Description, "D");

                    lst.Add(drtxn); 
                } 
                return lst;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string BuildNarrative(Student _student, ClassStream _ClsStrm, SchoolClass _SchoolClass, int accountid, decimal amount, string description, string TType)
        {
            try
            {
                string narr = string.Empty;
                var accntquery = (from acc in db.Accounts
                                  where acc.Id == accountid
                                  select acc).FirstOrDefault();
                Account _account = accntquery;
                if (_account != null)
                {

                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + ",   Account = [ " + " Name: " + _account.AccountName + " No: " + _account.AccountNo + " ] " + "Amount: [ " + amount.ToString("#,##0") + " ] " + " Student = [ Name: " + _student.StudentSurName + "  " + _student.StudentOtherNames + " ]  [ " + " Admin No: [ " + _student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + ",  Account  [" + " Name: " + _account.AccountName + " No: " + _account.AccountNo + "] " + " Amount: [ " + amount.ToString("#,##0") + " ]";
                            break;
                    } 
                }
                if (_account == null)
                {

                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + ",   Amount [ " + amount.ToString("#,##0") + " ] " + ", Student = [ Name: " + _student.StudentSurName + "  " + _student.StudentOtherNames + " ]  [ " + " Admin No: [ " + _student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + ", Amount [ " + amount.ToString("#,##0") + " ]";
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

    }

    public class ChargeFeesCompleteEventArg : System.EventArgs
    {
        private int svalue;
        private string _template;

        public ChargeFeesCompleteEventArg(int value, string template)
        {
            svalue = value;
            _template = template;
        }

        public int StatusValue
        {
            get { return svalue; }
        }

        public string _Template
        {
            get { return _template; }
        }
    }











}