using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class SearchExamsSimpleForm : Form
    {
        SBSchoolDBEntities db;
        string connection;
        IQueryable<Exam> _Exams;
        //delegate
        public delegate void ExamSelectHandler(object sender, ExamSelectEventArgs e);
        //event
        public event ExamSelectHandler OnExamListSelected;

        public SearchExamsSimpleForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {
                try
                {
                    Exam selectedExamPeriod = (Exam)bindingSourceExams.Current;
                    OnExamListSelected(this, new ExamSelectEventArgs(selectedExamPeriod));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void SearchExamForm_Load(object sender, EventArgs e)
        {
            try
            {
                var ExamPeriodquery = from ep in db.ExamPeriods
                                      where ep.IsDeleted == false
                                      where ep.Status == "A"
                                      select ep;
                List<ExamPeriod> _ExamPeriods = ExamPeriodquery.ToList();
                DataGridViewComboBoxColumn colCboxExamPeriod = new DataGridViewComboBoxColumn();
                colCboxExamPeriod.HeaderText = "Exam Period";
                colCboxExamPeriod.Name = "cbExamPeriod";
                colCboxExamPeriod.DataSource = _ExamPeriods;
                // The display member is the name column in the column datasource  
                colCboxExamPeriod.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxExamPeriod.DataPropertyName = "ExamPeriodId";
                // The value member is the primary key of the parent table  
                colCboxExamPeriod.ValueMember = "Id";
                colCboxExamPeriod.MaxDropDownItems = 10;
                colCboxExamPeriod.Width = 100;
                colCboxExamPeriod.DisplayIndex = 1;
                colCboxExamPeriod.MinimumWidth = 5;
                colCboxExamPeriod.FlatStyle = FlatStyle.Flat;
                colCboxExamPeriod.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxExamPeriod.ReadOnly = true; 
                if (!this.dataGridViewExams.Columns.Contains("cbExamPeriod"))
                {
                    dataGridViewExams.Columns.Add(colCboxExamPeriod);
                }

                var SchoolClassesquery = from sc in db.SchoolClasses
                                         where sc.Status == "A"
                                         where sc.IsDeleted == false
                                         select sc;
                List<SchoolClass> _SchoolClasses = SchoolClassesquery.ToList();
                DataGridViewComboBoxColumn colCboxSchoolClass = new DataGridViewComboBoxColumn();
                colCboxSchoolClass.HeaderText = "Class";
                colCboxSchoolClass.Name = "cbSchoolClass";
                colCboxSchoolClass.DataSource = _SchoolClasses;
                // The display member is the name column in the column datasource  
                colCboxSchoolClass.DisplayMember = "ClassName";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxSchoolClass.DataPropertyName = "ClassId";
                // The value member is the primary key of the parent table  
                colCboxSchoolClass.ValueMember = "Id";
                colCboxSchoolClass.MaxDropDownItems = 10;
                colCboxSchoolClass.Width = 180;
                colCboxSchoolClass.DisplayIndex = 2;
                colCboxSchoolClass.MinimumWidth = 5;
                colCboxSchoolClass.FlatStyle = FlatStyle.Flat;
                colCboxSchoolClass.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxSchoolClass.ReadOnly = true; 
                if (!this.dataGridViewExams.Columns.Contains("cbSchoolClass"))
                {
                    dataGridViewExams.Columns.Add(colCboxSchoolClass);
                }

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
                colCboxSubjects.Width = 250;
                colCboxSubjects.DisplayIndex = 1;
                colCboxSubjects.MinimumWidth = 5;
                colCboxSubjects.FlatStyle = FlatStyle.Flat;
                colCboxSubjects.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxSubjects.ReadOnly = true; 
                if (!this.dataGridViewExams.Columns.Contains("cbSubjects"))
                {
                    dataGridViewExams.Columns.Add(colCboxSubjects);
                }

                dataGridViewExams.AutoGenerateColumns = false;
                this.dataGridViewExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExams.DataSource = bindingSourceExams;

                _Exams = db.Exams.Where(i => i.Enabled == true && i.Closed == false && i.IsDeleted == false);

                AutoCompleteStringCollection acscsjb = new AutoCompleteStringCollection();
                acscsjb.AddRange(this.AutoComplete_Subjects());
                txtSubjectCode.AutoCompleteCustomSource = acscsjb;
                txtSubjectCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtSubjectCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscexmprd = new AutoCompleteStringCollection();
                acscexmprd.AddRange(this.AutoComplete_ExamPeriods());
                txtExamPeriod.AutoCompleteCustomSource = acscexmprd;
                txtExamPeriod.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtExamPeriod.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsccls = new AutoCompleteStringCollection();
                acsccls.AddRange(this.AutoComplete_Classes());
                txtClass.AutoCompleteCustomSource = acsccls;
                txtClass.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtClass.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_Subjects()
        {
            try
            {
                var subjectsquery = from sb in db.Subjects
                                    where sb.Status == "A"
                                    where sb.IsDeleted == false
                                    select sb.ShortCode;
                return subjectsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_ExamPeriods()
        {
            try
            {
                var examperiodsquery = from ep in db.ExamPeriods
                                       where ep.Status == "A"
                                       where ep.IsDeleted == false
                                       select ep.Description;
                return examperiodsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Classes()
        {
            try
            {
                var classesquery = from sc in db.SchoolClasses
                                   where sc.IsDeleted == false
                                   where sc.Status == "A"
                                   select sc.ClassName;
                return classesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        // apply the filter
        private void ApplyFilter()
        {
            try
            {
                // set the filter
                var filter = CreateFilter(_Exams);
                this.bindingSourceExams.DataSource = filter;
                groupBox1.Text = bindingSourceExams.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private IQueryable<Exam> CreateFilter(IQueryable<Exam> _exam)
        {
            //none
            if (string.IsNullOrEmpty(txtSubjectCode.Text)
                && string.IsNullOrEmpty(txtExamPeriod.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                return _exam;
            }
            //all
            if (!string.IsNullOrEmpty(txtSubjectCode.Text)
                && !string.IsNullOrEmpty(txtExamPeriod.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                string _SubjectCode = txtSubjectCode.Text;
                string _ExamPeriod = txtExamPeriod.Text;
                string _Class = txtClass.Text;
                _exam = from exm in db.Exams
                        where exm.IsDeleted == false
                        where exm.Enabled == true
                        where exm.Closed == false
                        where exm.SubjectShortCode.StartsWith(_SubjectCode)
                        join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                        where ep.Status == "A"
                        where ep.IsDeleted == false
                        where ep.Description.StartsWith(_ExamPeriod)
                        join sc in db.SchoolClasses on exm.ClassId equals sc.Id
                        where sc.IsDeleted == false
                        where sc.Status == "A"
                        where sc.ClassName.StartsWith(_Class)
                        where exm.Closed == false
                        where exm.Enabled == true
                        select exm;
                return _exam;
            }
            //subject
            if (!string.IsNullOrEmpty(txtSubjectCode.Text) && string.IsNullOrEmpty(txtExamPeriod.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                string _SubjectCode = txtSubjectCode.Text;
                _exam = _exam.Where(a => a.SubjectShortCode.StartsWith(_SubjectCode));
                return _exam;
            }
            //subject and examperiod
            if (!string.IsNullOrEmpty(txtSubjectCode.Text) && !string.IsNullOrEmpty(txtExamPeriod.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                string _SubjectCode = txtSubjectCode.Text;
                string _ExamPeriod = txtExamPeriod.Text;
                _exam = from exm in db.Exams
                        where exm.IsDeleted == false
                        where exm.SubjectShortCode.StartsWith(_SubjectCode)
                        join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                        where ep.Description.StartsWith(_ExamPeriod)
                        where ep.IsDeleted == false
                        where ep.Status == "A"
                        where exm.Closed == false
                        where exm.Enabled == true
                        select exm;
                return _exam;
            }
            //subject and class
            if (!string.IsNullOrEmpty(txtSubjectCode.Text) && !string.IsNullOrEmpty(txtClass.Text) && string.IsNullOrEmpty(txtExamPeriod.Text))
            {
                string _SubjectCode = txtSubjectCode.Text;
                string _Class = txtClass.Text;
                _exam = from exm in db.Exams
                        where exm.IsDeleted == false
                        where exm.SubjectShortCode.StartsWith(_SubjectCode)
                        join sc in db.SchoolClasses on exm.ClassId equals sc.Id
                        where sc.ClassName.StartsWith(_Class)
                        where sc.IsDeleted == false
                        where sc.Status == "A"
                        where exm.Closed == false
                        where exm.Enabled == true
                        select exm;
                return _exam;
            }
            //examperiod
            if (!string.IsNullOrEmpty(txtExamPeriod.Text) && string.IsNullOrEmpty(txtSubjectCode.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                string _ExamPeriod = txtExamPeriod.Text;
                _exam = from exm in db.Exams
                        join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                        where ep.Description.StartsWith(_ExamPeriod)
                        where exm.Closed == false
                        where exm.Enabled == true
                        where ep.Status == "A"
                        where ep.IsDeleted == false
                        select exm;
                return _exam;
            }
            //examperiod and class
            if (!string.IsNullOrEmpty(txtExamPeriod.Text) && !string.IsNullOrEmpty(txtClass.Text) && string.IsNullOrEmpty(txtSubjectCode.Text))
            {
                string _ExamPeriod = txtExamPeriod.Text;
                string _Class = txtClass.Text;
                _exam = from exm in db.Exams
                        join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                        where ep.Description.StartsWith(_ExamPeriod)
                        join sc in db.SchoolClasses on exm.ClassId equals sc.Id
                        where sc.ClassName.StartsWith(_Class)
                        where exm.Closed == false
                        where exm.IsDeleted == false
                        where exm.Enabled == true
                        where ep.IsDeleted == false
                        where ep.Status == "A"
                        where sc.IsDeleted == false
                        where sc.Status == "A"
                        select exm;
                return _exam;
            }
            //Class
            if (!string.IsNullOrEmpty(txtClass.Text) && string.IsNullOrEmpty(txtExamPeriod.Text) && string.IsNullOrEmpty(txtSubjectCode.Text))
            {
                string _Class = txtClass.Text;
                _exam = from exm in db.Exams
                        join sc in db.SchoolClasses on exm.ClassId equals sc.Id
                        where sc.ClassName.StartsWith(_Class)
                        where exm.Closed == false
                        where exm.Enabled == true
                        where sc.IsDeleted == false
                        where sc.Status == "A"
                        where exm.IsDeleted == false
                        select exm;
                return _exam;
            }
            return _exam;
        }
        private void txtSubjectCode_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtSubjectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtExamPeriod_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtExamPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtClass_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }

        private void dataGridViewExams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {
                try
                {
                    Exam selectedExamPeriod = (Exam)bindingSourceExams.Current;
                    OnExamListSelected(this, new ExamSelectEventArgs(selectedExamPeriod));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewExamPeriods_DataError(object sender, DataGridViewDataErrorEventArgs e)
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