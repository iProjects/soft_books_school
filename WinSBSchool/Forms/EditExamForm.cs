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
    public partial class EditExamForm : Form
    {

        string user;
        SBSchoolDBEntities db;
        string connection;
        Exam _Exam;
        Repository rep;

        public EditExamForm(Exam exam, string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (exam == null)
                throw new ArgumentNullException("Exam");
            _Exam = exam;    
           
            user = _user;
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsExamValid())
            {
                try
                {
                    if (cboExamPeriods.SelectedIndex != -1)
                    {
                        _Exam.ExamPeriodId = int.Parse(cboExamPeriods.SelectedValue.ToString());
                    }
                    if (cboClass.SelectedIndex != -1)
                    {
                        _Exam.ClassId = int.Parse(cboClass.SelectedValue.ToString());
                    }
                    if (cboSubject.SelectedIndex != -1)
                    {
                        _Exam.SubjectShortCode = cboSubject.SelectedValue.ToString();
                    }
                    if (dtpLastModified.Value != null)
                    {
                        _Exam.LastModified = dtpLastModified.Value;
                    }
                    if (!string.IsNullOrEmpty(txtModifiedby.Text))
                    {
                        _Exam.ModifiedBy = Utils.ConvertFirstLetterToUpper(txtModifiedby.Text);
                    }
                    _Exam.Enabled = chkEnabled.Checked;
                    
                    rep.UpdateExam(_Exam);

                    ExamsForm f = (ExamsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void DisableControls()
        {
            cboExamPeriods.Enabled = false;
            cboClass.Enabled = false;
            cboSubject.Enabled = false;
            dtpLastModified.Enabled = false;
            txtModifiedby.Enabled = false;
            chkEnabled.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;
        }
        private bool IsExamValid()
        {
            bool noerror = true;
            if (cboExamPeriods.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboExamPeriods, "Select Exam Period!");
                return false;
            }
            if (cboClass.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboClass, "Select Class!");
                return false;
            }
            if (cboSubject.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboSubject, "Select Subject!");
                return false;
            }
            return noerror;
        }
        private void EditExamForm_Load(object sender, EventArgs e)
        {
            try
            {

                var _exmprdsquery = from eps in db.ExamPeriods
                                    orderby eps.Year, eps.Term ascending
                                    where eps.Status == "A"
                                    where eps.IsDeleted==false
                                    select eps;
                List<ExamPeriod> _ExamPeriods = _exmprdsquery.ToList();
                cboExamPeriods.DataSource = _ExamPeriods;
                cboExamPeriods.ValueMember = "Id";
                cboExamPeriods.DisplayMember = "Description";
                cboExamPeriods.SelectedIndex = -1;

                var _sclcls = from sc in db.SchoolClasses
                              where sc.IsDeleted==false
                              where sc.Status=="A"
                              select sc;
                List<SchoolClass> _SchoolClasses = _sclcls.ToList();
                cboClass.DataSource = _SchoolClasses;
                cboClass.ValueMember = "Id";
                cboClass.DisplayMember = "ClassName";
                cboClass.SelectedIndex = -1;

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

                var _exmtyps = from et in db.ExamTypes
                               where et.Status=="A"
                               where et.IsDeleted==false
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

                var RegisteredExamquery = from rg in db.RegisteredExams 
                                          where rg.ExamId == _Exam.Id
                                          where rg.IsDeleted==false
                                          select rg;
                List<RegisteredExam> _RegisteredExams = RegisteredExamquery.ToList();
                bindingSourceExamDetails.DataSource = _RegisteredExams;
                dataGridViewRegisteredExams.AutoGenerateColumns = false;
                this.dataGridViewRegisteredExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewRegisteredExams.DataSource = bindingSourceExamDetails;
                groupBox4.Text = bindingSourceExamDetails.Count.ToString();

                InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {
            if (_Exam.ExamPeriodId != null)
            {
                cboExamPeriods.SelectedValue = _Exam.ExamPeriodId;
                cboExamPeriods.Enabled = false;
            }
            if (_Exam.ClassId != null)
            {
                cboClass.SelectedValue = _Exam.ClassId;
                cboClass.Enabled = false;
            }
            if (_Exam.SubjectShortCode != null)
            {
                cboSubject.SelectedValue = _Exam.SubjectShortCode;
                cboSubject.Enabled = false;
            }
            if (_Exam.LastModified != null)
            {
                dtpLastModified.Value = _Exam.LastModified ?? DateTime.Today;
            }
            if (_Exam.ModifiedBy != null)
            {
                txtModifiedby.Text = _Exam.ModifiedBy;
            }
            if (_Exam.Enabled != null)
            {
                chkEnabled.Checked = _Exam.Enabled;
            } 
        }
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboClass.SelectedIndex != -1)
                {
                    SchoolClass sclass = (SchoolClass)cboClass.SelectedItem;
                    var clssubjects = (from cs in db.Subjects
                                       join clssbjct in db.ClassSubjects on cs.ShortCode equals clssbjct.SubjectCode
                                       where clssbjct.ClassId == sclass.Id
                                       where cs.Status == "A"
                                       where clssbjct.Status == "A"
                                       where cs.IsDeleted==false
                                       where clssbjct.IsDeleted==false
                                       orderby cs.Description
                                       select cs).Distinct().OrderBy(i=>i.ShortCode);
                    List<Subject> _subjects = clssubjects.ToList();
                    cboSubject.DataSource = _subjects;
                    cboSubject.ValueMember = "ShortCode";
                    cboSubject.DisplayMember = "Description";
                    cboSubject.SelectedIndex = -1; 
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
        private bool ValidExamDets()
        {
            bool valid = false;
            //TotalAssets should add up to 100
            //var TotalAssets = 0.00;

            //var totalq = db.ExamDets.Where(exm => exm._ExamId == _Exam._ExamId).Select(exm => exm.Contribution);
            //if (totalq.Count() > 0)
            //    TotalAssets = totalq.Sum();

            //valid = (TotalAssets == 100.00); 

            return valid;
        }
        private void groupBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (!ValidExamDets())
            //{
            //    MessageBox.Show("Not adding up to 100%");
            //    e.Cancel = true;
            //}
        }



    }
}