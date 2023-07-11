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
    public partial class ExamsForm : Form
    {
        string user;
        SBSchoolDBEntities db;
        string connection;
        Repository rep;

        public ExamsForm(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            user = _user;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void ExamsForm_Load(object sender, EventArgs e)
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
                if (!this.dataGridViewRegisteredExams.Columns.Contains("cbStatus"))
                {
                    dataGridViewRegisteredExams.Columns.Add(colCboxStatus);
                }

                int _year = DateTime.Now.Year;
                var _defaultExamPeriodquery = (from ep in db.ExamPeriods
                                               where ep.Year == _year
                                               where ep.Status == "A"
                                               where ep.IsDeleted == false
                                               orderby ep.Term ascending
                                               select ep).FirstOrDefault();
                ExamPeriod _ExamPeriod = _defaultExamPeriodquery;

                var _ExamPeriodsquery = from eps in db.ExamPeriods
                                        orderby eps.Year, eps.Term ascending
                                        where eps.Status == "A"
                                        where eps.IsDeleted == false
                                        select eps;
                List<ExamPeriod> _ExamPeriods = _ExamPeriodsquery.ToList();
                bindingSourceExamPeriods.DataSource = _ExamPeriods;
                cboExamPeriods.DataSource = bindingSourceExamPeriods;
                cboExamPeriods.ValueMember = "Id";
                cboExamPeriods.DisplayMember = "Description";
                if (_ExamPeriod != null)
                {
                    cboExamPeriods.SelectedValue = _ExamPeriod.Id;
                }

                var _SchoolClassesquery = from sc in db.SchoolClasses
                                          where sc.IsDeleted == false
                                          where sc.Status == "A"
                                          select sc;
                List<SchoolClass> _SchoolClasses = _SchoolClassesquery.ToList();
                bindingSourceClasses.DataSource = _SchoolClasses;
                cboClasses.DataSource = bindingSourceClasses;
                cboClasses.ValueMember = "Id";
                cboClasses.DisplayMember = "ClassName";

                var _subjectsquery = from et in db.Subjects
                                     where et.Status == "A"
                                     where et.IsDeleted == false
                                     select et;
                List<Subject> _Subjects = _subjectsquery.ToList();
                DataGridViewComboBoxColumn colCboxSubjects = new DataGridViewComboBoxColumn();
                colCboxSubjects.HeaderText = "Subject";
                colCboxSubjects.Name = "cbSubjects";
                colCboxSubjects.DataSource = _Subjects;
                // The display member is the name column in the column datasource  
                colCboxSubjects.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxSubjects.DataPropertyName = "SubjectShortCode";
                // The value member is the primary key of the parent table  
                colCboxSubjects.ValueMember = "ShortCode";
                colCboxSubjects.MaxDropDownItems = 10;
                colCboxSubjects.Width = 200;
                colCboxSubjects.DisplayIndex = 1;
                colCboxSubjects.MinimumWidth = 5;
                colCboxSubjects.FlatStyle = FlatStyle.Flat;
                colCboxSubjects.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxSubjects.ReadOnly = true;
                if (!this.dataGridViewExams.Columns.Contains("cbSubjects"))
                {
                    dataGridViewExams.Columns.Add(colCboxSubjects);
                }

                var _exmtyps = from et in db.ExamTypes
                               where et.Status == "A"
                               where et.IsDeleted == false
                               select et;
                List<ExamType> _examtypes = _exmtyps.ToList();
                bindingSourceExamTypes.DataSource = _examtypes;
                DataGridViewComboBoxColumn colCboxExamTypes = new DataGridViewComboBoxColumn();
                colCboxExamTypes.HeaderText = "Exam Type";
                colCboxExamTypes.Name = "cbExamTypes";
                colCboxExamTypes.DataSource = bindingSourceExamTypes;
                // The display member is the name column in the column datasource  
                colCboxExamTypes.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxExamTypes.DataPropertyName = "ExamTypeId";
                // The value member is the primary key of the parent table  
                colCboxExamTypes.ValueMember = "Id";
                colCboxExamTypes.MaxDropDownItems = 10;
                colCboxExamTypes.Width = 200;
                colCboxExamTypes.DisplayIndex = 1;
                colCboxExamTypes.MinimumWidth = 5;
                colCboxExamTypes.FlatStyle = FlatStyle.Flat;
                colCboxExamTypes.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxExamTypes.ReadOnly = true;
                if (!this.dataGridViewRegisteredExams.Columns.Contains("cbExamTypes"))
                {
                    dataGridViewRegisteredExams.Columns.Add(colCboxExamTypes);
                }

                dataGridViewExams.AutoGenerateColumns = false;
                this.dataGridViewExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExams.DataSource = bindingSourceExams;

                dataGridViewRegisteredExams.AutoGenerateColumns = false;
                this.dataGridViewRegisteredExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewRegisteredExams.DataSource = bindingSourceRegisteredExams;

                RefreshGrid();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {

                try
                {
                    Exam exm = (Exam)bindingSourceExams.Current;
                    if (exm.Closed)
                    {
                        MessageBox.Show("Cannot edit a Closed Exam!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        EditExamForm epf = new EditExamForm(exm, user, connection) { Owner = this };
                        epf.Text = "Edit Exam";
                        epf.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboClasses.SelectedIndex != -1 && cboExamPeriods.SelectedIndex != -1)
            {
                try
                {
                    ExamPeriod _ExamPeriod = (ExamPeriod)cboExamPeriods.SelectedItem;
                    SchoolClass _SchoolClasses = (SchoolClass)cboClasses.SelectedItem;

                    AddExamForm aef = new AddExamForm(_ExamPeriod, _SchoolClasses, user, connection) { Owner = this };
                    aef.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewExams_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGrid()
        {
            bindingSourceExams.DataSource = null;
            groupBox5.Text = bindingSourceExams.Count.ToString();

            if (cboExamPeriods.SelectedIndex != -1 && cboClasses.SelectedIndex != -1)
            {
                try
                {

                    ExamPeriod _ExamPeriod = (ExamPeriod)cboExamPeriods.SelectedItem;
                    SchoolClass _SchoolClass = (SchoolClass)cboClasses.SelectedItem;

                    if (chkClosed.Checked && chkDisabled.Checked)
                    {
                        bindingSourceExams.DataSource = null;
                        var _Exams = from exm in db.Exams
                                     where exm.ExamPeriodId == _ExamPeriod.Id
                                     where exm.ClassId == _SchoolClass.Id
                                     where exm.IsDeleted == false
                                     select exm;
                        List<Exam> Exams = _Exams.ToList();

                        bindingSourceExams.DataSource = Exams;
                        groupBox5.Text = bindingSourceExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewExams.Rows)
                        {
                            dataGridViewExams.Rows[dataGridViewExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewExams.Rows.Count - 1;
                            bindingSourceExams.Position = nRowIndex;
                        }

                        RefreshRegisteredExamsGrid();
                    }
                    else if (chkClosed.Checked && !chkDisabled.Checked)
                    {
                        bindingSourceExams.DataSource = null;
                        var _Exams = from exm in db.Exams
                                     where exm.ExamPeriodId == _ExamPeriod.Id
                                     where exm.ClassId == _SchoolClass.Id
                                     where exm.IsDeleted == false
                                     where exm.Enabled == true
                                     select exm;
                        List<Exam> Exams = _Exams.ToList();

                        bindingSourceExams.DataSource = Exams;
                        groupBox5.Text = bindingSourceExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewExams.Rows)
                        {
                            dataGridViewExams.Rows[dataGridViewExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewExams.Rows.Count - 1;
                            bindingSourceExams.Position = nRowIndex;
                        }

                        RefreshRegisteredExamsGrid();
                    }
                    else if (!chkClosed.Checked && !chkDisabled.Checked)
                    {
                        bindingSourceExams.DataSource = null;
                        var _Exams = from exm in db.Exams
                                     where exm.ExamPeriodId == _ExamPeriod.Id
                                     where exm.ClassId == _SchoolClass.Id
                                     where exm.IsDeleted == false
                                     where exm.Enabled == true
                                     where exm.Closed == false
                                     select exm;
                        List<Exam> Exams = _Exams.ToList();

                        bindingSourceExams.DataSource = Exams;
                        groupBox5.Text = bindingSourceExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewExams.Rows)
                        {
                            dataGridViewExams.Rows[dataGridViewExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewExams.Rows.Count - 1;
                            bindingSourceExams.Position = nRowIndex;
                        }

                        RefreshRegisteredExamsGrid();
                    }
                    else if (!chkClosed.Checked && chkDisabled.Checked)
                    {
                        bindingSourceExams.DataSource = null;
                        var _Exams = from exm in db.Exams
                                     where exm.ExamPeriodId == _ExamPeriod.Id
                                     where exm.ClassId == _SchoolClass.Id
                                     where exm.IsDeleted == false
                                     where exm.Closed == false
                                     select exm;
                        List<Exam> Exams = _Exams.ToList();

                        bindingSourceExams.DataSource = Exams;
                        groupBox5.Text = bindingSourceExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewExams.Rows)
                        {
                            dataGridViewExams.Rows[dataGridViewExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewExams.Rows.Count - 1;
                            bindingSourceExams.Position = nRowIndex;
                        } 
                        RefreshRegisteredExamsGrid();
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void RefreshRegisteredExamsGrid()
        {
            bindingSourceRegisteredExams.DataSource = null;
            groupBox3.Text = bindingSourceRegisteredExams.Count.ToString();

            if (dataGridViewExams.SelectedRows.Count != 0)
            {
                try
                {
                    Exam _Exam = (Exam)bindingSourceExams.Current;

                    if (chkInActive.Checked)
                    {
                        bindingSourceRegisteredExams.DataSource = null;
                        var _RegisteredExamquery = from rg in db.RegisteredExams
                                                   where rg.IsDeleted == false
                                                   where rg.ExamId == _Exam.Id
                                                   select rg;
                        List<RegisteredExam> _RegisteredExams = _RegisteredExamquery.ToList();

                        bindingSourceRegisteredExams.DataSource = _RegisteredExams;
                        groupBox3.Text = bindingSourceRegisteredExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewRegisteredExams.Rows)
                        {
                            dataGridViewRegisteredExams.Rows[dataGridViewRegisteredExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewRegisteredExams.Rows.Count - 1;
                            bindingSourceRegisteredExams.Position = nRowIndex;
                        }
                    }
                    else
                    {
                        bindingSourceRegisteredExams.DataSource = null;
                        var _RegisteredExamquery = from rg in db.RegisteredExams
                                                   where rg.IsDeleted == false
                                                   where rg.Status == "A"
                                                   where rg.ExamId == _Exam.Id
                                                   select rg;
                        List<RegisteredExam> _RegisteredExams = _RegisteredExamquery.ToList();

                        bindingSourceRegisteredExams.DataSource = _RegisteredExams;
                        groupBox3.Text = bindingSourceRegisteredExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewRegisteredExams.Rows)
                        {
                            dataGridViewRegisteredExams.Rows[dataGridViewRegisteredExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewRegisteredExams.Rows.Count - 1;
                            bindingSourceRegisteredExams.Position = nRowIndex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void cboExamPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {
                try
                {
                    Exam _Exam = (Exam)bindingSourceExams.Current;

                    if (chkInActive.Checked)
                    {
                        bindingSourceRegisteredExams.DataSource = null;
                        var _RegisteredExamquery = from rg in db.RegisteredExams
                                                   where rg.IsDeleted == false
                                                   where rg.ExamId == _Exam.Id
                                                   select rg;
                        List<RegisteredExam> _RegisteredExams = _RegisteredExamquery.ToList();
                        bindingSourceRegisteredExams.DataSource = _RegisteredExams;
                        groupBox3.Text = bindingSourceRegisteredExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewRegisteredExams.Rows)
                        {
                            dataGridViewRegisteredExams.Rows[dataGridViewRegisteredExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewRegisteredExams.Rows.Count - 1;
                            bindingSourceRegisteredExams.Position = nRowIndex;
                        }
                    }
                    else
                    {
                        bindingSourceRegisteredExams.DataSource = null;
                        var _RegisteredExamquery = from rg in db.RegisteredExams
                                                   where rg.IsDeleted == false
                                                   where rg.Status == "A"
                                                   where rg.ExamId == _Exam.Id
                                                   select rg;
                        List<RegisteredExam> _RegisteredExams = _RegisteredExamquery.ToList();
                        bindingSourceRegisteredExams.DataSource = _RegisteredExams;
                        groupBox3.Text = bindingSourceRegisteredExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewRegisteredExams.Rows)
                        {
                            dataGridViewRegisteredExams.Rows[dataGridViewRegisteredExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewRegisteredExams.Rows.Count - 1;
                            bindingSourceRegisteredExams.Position = nRowIndex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewExams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {
                try
                {
                    Exam exm = (Exam)bindingSourceExams.Current;

                    EditExamForm epf = new EditExamForm(exm, user, connection) { Owner = this };
                    epf.Text = "Edit Exam";
                    epf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void cboClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {
                try
                {
                    Exam exm = (Exam)bindingSourceExams.Current;
                    if (exm.Closed)
                    {
                        MessageBox.Show("Cannot Register a Closed Exam!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int examdetid = ((Exam)bindingSourceExams.Current).Id;
                        RegisterSingleExamForm f = new RegisterSingleExamForm("Add", examdetid, user, connection) { Owner = this };
                        f.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void chkDisabled_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkClosed_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewExams_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshRegisteredExamsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEditRegisteredExam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewRegisteredExams.SelectedRows.Count != 0)
            {
                try
                {
                    RegisteredExam _regexam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    RegisterSingleExamForm f = new RegisterSingleExamForm("Edit", _regexam, user, connection) { Owner = this };
                    f.DisableControls();
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDeleteRegisteredExam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewRegisteredExams.SelectedRows.Count != 0)
            {
                try
                {
                    RegisteredExam _regexam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    var _processedexamsquery = from se in db.StudentExams
                                               join st in db.Students on se.StudentId equals st.Id
                                               where st.Status == "A"
                                               where st.IsDeleted == false

                                               join re in db.RegisteredExams on se.RegdExamId equals re.Id
                                               where re.Id == se.RegdExamId
                                               where re.Status == "A"
                                               where se.StudentId == st.Id
                                               join exm in db.Exams on re.ExamId equals exm.Id
                                               where exm.Enabled == true
                                               where exm.IsDeleted == false
                                               where _regexam.Id == re.Id
                                               select se;
                    List<StudentExam> _StudentsExamResults = _processedexamsquery.ToList();

                    if (_StudentsExamResults.Count > 0)
                    {
                        MessageBox.Show("There is a Student Registered for this Exam!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Registered Exam\n", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteRegisteredExam(_regexam);

                            RefreshRegisteredExamsGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {
                try
                {
                    Exam _Exam = (Exam)bindingSourceExams.Current;

                    if (chkInActive.Checked)
                    {
                        bindingSourceRegisteredExams.DataSource = null;
                        var _RegisteredExamquery = from rg in db.RegisteredExams
                                                   where rg.IsDeleted == false
                                                   where rg.ExamId == _Exam.Id
                                                   select rg;
                        List<RegisteredExam> _RegisteredExams = _RegisteredExamquery.ToList();
                        bindingSourceRegisteredExams.DataSource = _RegisteredExams;
                        groupBox3.Text = bindingSourceRegisteredExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewRegisteredExams.Rows)
                        {
                            dataGridViewRegisteredExams.Rows[dataGridViewRegisteredExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewRegisteredExams.Rows.Count - 1;
                            bindingSourceRegisteredExams.Position = nRowIndex;
                        }
                    }
                    else
                    {
                        bindingSourceRegisteredExams.DataSource = null;
                        var _RegisteredExamquery = from rg in db.RegisteredExams
                                                   where rg.IsDeleted == false
                                                   where rg.Status == "A"
                                                   where rg.ExamId == _Exam.Id
                                                   select rg;
                        List<RegisteredExam> _RegisteredExams = _RegisteredExamquery.ToList();
                        bindingSourceRegisteredExams.DataSource = _RegisteredExams;
                        groupBox3.Text = bindingSourceRegisteredExams.Count.ToString();
                        foreach (DataGridViewRow row in dataGridViewRegisteredExams.Rows)
                        {
                            dataGridViewRegisteredExams.Rows[dataGridViewRegisteredExams.Rows.Count - 1].Selected = true;
                            int nRowIndex = dataGridViewRegisteredExams.Rows.Count - 1;
                            bindingSourceRegisteredExams.Position = nRowIndex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewRegisteredExams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRegisteredExams.SelectedRows.Count != 0)
            {
                try
                {
                    RegisteredExam _regexam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    RegisterSingleExamForm f = new RegisterSingleExamForm("Edit", _regexam, user, connection) { Owner = this };
                    f.DisableControls();
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {
                try
                {
                    Exam _Exam = (Exam)bindingSourceExams.Current;

                    var _processedexamsquery = from re in db.RegisteredExams
                                               where re.ExamId == _Exam.Id
                                               where re.Status == "A"
                                               join exm in db.Exams on re.ExamId equals exm.Id
                                               where exm.Enabled == true
                                               where exm.IsDeleted == false
                                               where exm.Id == _Exam.Id
                                               select re;
                    List<RegisteredExam> _StudentsExamResults = _processedexamsquery.ToList();

                    if (_StudentsExamResults.Count > 0)
                    {
                        MessageBox.Show("There is a Registered Exam Associated with this Exam\n Delete the Registered Exam first!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete  Exam\n", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteExam(_Exam);

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
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            { 
                try
                {
                    Exam exm = (Exam)bindingSourceExams.Current;
                    EditExamForm epf = new EditExamForm(exm, user, connection) { Owner = this };
                    epf.Text = "Edit Exam";
                    epf.DisableControls();
                    epf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void dataGridViewRegisteredExams_DataError(object sender, DataGridViewDataErrorEventArgs e)
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