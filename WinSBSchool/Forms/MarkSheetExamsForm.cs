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
    public partial class MarkSheetExamsForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string user;
        Exam _Exam;
        string connection;

        public MarkSheetExamsForm(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            user = _user;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnSearchExams_Click(object sender, EventArgs e)
        {
            try
            {
                SearchExamsSimpleForm f = new SearchExamsSimpleForm(connection) { Owner = this };
                f.OnExamListSelected += new SearchExamsSimpleForm.ExamSelectHandler(f_OnExamListSelected);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdvancedSearchExams_Click(object sender, EventArgs e)
        {
            try
            {
                SearchExamsForm f = new SearchExamsForm(connection) { Owner = this };
                f.OnExamListSelected += new SearchExamsForm.ExamSelectHandler(f_OnExamListSelected);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void f_OnExamListSelected(object sender, ExamSelectEventArgs e)
        {
            try
            {
                SetExam(e._Exam);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetExam(Exam exam)
        {
            try
            {
                if (exam != null)
                {
                    _Exam = exam;
                    lblMessage.Text = string.Empty;
                    var subjectquery = (from sj in db.Subjects
                                        where sj.Status == "A"
                                        where sj.IsDeleted == false
                                        where sj.ShortCode == _Exam.SubjectShortCode
                                        select sj).FirstOrDefault();
                    Subject sub = subjectquery;
                    lblMessage.Text = sub.ShortCode;
                    lblSubjectDescription.Text = sub.Description;
                    txtExam.Text = _Exam.Id.ToString();

                    var _SchoolClassquery = (from sc in db.SchoolClasses
                                             where sc.Id == _Exam.ClassId
                                             where sc.Status == "A"
                                             where sc.IsDeleted == false
                                             select sc).FirstOrDefault();
                    SchoolClass cls = _SchoolClassquery;

                    cboSchoolClass.SelectedValue = cls.Id;

                    var _examtypequery = from et in db.ExamTypes
                                         join rg in db.RegisteredExams on et.Id equals rg.ExamTypeId
                                         join exm in db.Exams on rg.ExamId equals exm.Id
                                         join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                                         where exm.ClassId == cls.Id
                                         where exm.Id == _Exam.Id
                                         where exm.Enabled == true 
                                         where exm.Closed == false
                                         where ep.Status=="A"
                                         where et.Status == "A"
                                         where ep.IsDeleted == false
                                         orderby et.Description ascending
                                         where et.IsDeleted == false
                                         select et;
                    List<ExamType> _ExamTypes = _examtypequery.ToList();
                    cbRegisteredExamTypes.ValueMember = "Id";
                    cbRegisteredExamTypes.DisplayMember = "Description";
                    cbRegisteredExamTypes.DataSource = _ExamTypes;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshGrid()
        {

            bindingSourceRegdStudents.DataSource = null;
            groupBox4.Text = bindingSourceRegdStudents.Count.ToString();  

            if (cbRegisteredExamTypes.SelectedIndex != -1 && cboSchoolClass.SelectedIndex != -1 && _Exam != null)
            {
                try
                {
                    SchoolClass cls = (SchoolClass)cboSchoolClass.SelectedItem;

                    ExamType _ExamType = (ExamType)cbRegisteredExamTypes.SelectedItem;

                    string _subjectshortcode = lblMessage.Text;

                    if (_ExamType != null)
                    {
                        var _RegisteredExamquery = (from re in db.RegisteredExams
                                                    join exm in db.Exams on re.ExamId equals exm.Id
                                                    join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                                                    where ep.Status == "A"
                                                    where ep.IsDeleted == false
                                                    where exm.ClassId == cls.Id
                                                    where exm.IsDeleted==false
                                                    where exm.Closed == false
                                                    where re.ExamTypeId == _ExamType.Id
                                                    where exm.SubjectShortCode == _subjectshortcode
                                                    select re).FirstOrDefault();
                        RegisteredExam _RegisteredExam = _RegisteredExamquery;

                        if (_RegisteredExam != null)
                        {

                            var _StudentExamsquery = from se in db.StudentExams
                                                     where se.RegdExamId == _RegisteredExam.Id
                                                     select se;
                            List<StudentExam> _StudentExams = _StudentExamsquery.ToList();

                            bindingSourceRegdStudents.DataSource = _StudentExams;
                            groupBox4.Text = bindingSourceRegdStudents.Count.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void MarkSheetExamsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _SchoolClassesquery = from sc in db.SchoolClasses
                                          where sc.IsDeleted==false
                                          where sc.Status=="A"
                                          select sc;
                List<SchoolClass> _SchoolClasses = _SchoolClassesquery.ToList();
                cboSchoolClass.DisplayMember = "ClassName";
                cboSchoolClass.ValueMember = "Id";
                cboSchoolClass.DataSource = _SchoolClasses;


                var _StudentsAdminNoquery = from st in db.Students
                                            where st.Status=="A"
                                            where st.IsDeleted==false
                                            select st;
                List<Student> _StudentsAdminNo = _StudentsAdminNoquery.ToList();
                DataGridViewComboBoxColumn colCboxClassStudentAdmino = new DataGridViewComboBoxColumn();
                colCboxClassStudentAdmino.HeaderText = "AdminNo";
                colCboxClassStudentAdmino.Name = "cbClassStudents";
                colCboxClassStudentAdmino.DataSource = _StudentsAdminNo;
                // The display member is the name column in the column datasource  
                colCboxClassStudentAdmino.DisplayMember = "AdminNo";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassStudentAdmino.DataPropertyName = "StudentId";
                // The value member is the primary key of the parent table  
                colCboxClassStudentAdmino.ValueMember = "Id";
                colCboxClassStudentAdmino.MaxDropDownItems = 10;
                colCboxClassStudentAdmino.Width = 150;
                colCboxClassStudentAdmino.DisplayIndex = 1;
                colCboxClassStudentAdmino.MinimumWidth = 5;
                colCboxClassStudentAdmino.FlatStyle = FlatStyle.Flat;
                colCboxClassStudentAdmino.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassStudentAdmino.ReadOnly = true; 
                if (!this.dataGridViewRegdStudents.Columns.Contains("cbClassStudents"))
                {
                    dataGridViewRegdStudents.Columns.Add(colCboxClassStudentAdmino);
                }

                var _StudentsSurNamequery = from st in db.Students
                                            where st.Status == "A"
                                            where st.IsDeleted == false
                                            select st;
                List<Student> _StudentsSurName = _StudentsSurNamequery.ToList();
                DataGridViewComboBoxColumn colCboxClassStudentsurName = new DataGridViewComboBoxColumn();
                colCboxClassStudentsurName.HeaderText = "SurName";
                colCboxClassStudentsurName.Name = "cbClassStudentSurName";
                colCboxClassStudentsurName.DataSource = _StudentsSurName;
                // The display member is the name column in the column datasource  
                colCboxClassStudentsurName.DisplayMember = "StudentSurName";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassStudentsurName.DataPropertyName = "StudentId";
                // The value member is the primary key of the parent table  
                colCboxClassStudentsurName.ValueMember = "Id";
                colCboxClassStudentsurName.MaxDropDownItems = 10;
                colCboxClassStudentsurName.Width = 150;
                colCboxClassStudentsurName.DisplayIndex = 2;
                colCboxClassStudentsurName.MinimumWidth = 5;
                colCboxClassStudentsurName.FlatStyle = FlatStyle.Flat;
                colCboxClassStudentsurName.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassStudentsurName.ReadOnly = true; 
                if (!this.dataGridViewRegdStudents.Columns.Contains("cbClassStudentSurName"))
                {
                    dataGridViewRegdStudents.Columns.Add(colCboxClassStudentsurName);
                }

                var _StudentsOtherNamesquery = from st in db.Students
                                               where st.Status == "A"
                                               where st.IsDeleted == false
                                               select st;
                List<Student> _StudentsOtherNames = _StudentsOtherNamesquery.ToList();
                DataGridViewComboBoxColumn colCboxClassStudentOtherNames = new DataGridViewComboBoxColumn();
                colCboxClassStudentOtherNames.HeaderText = "OtherNames";
                colCboxClassStudentOtherNames.Name = "cbClassStudentOtherNames";
                colCboxClassStudentOtherNames.DataSource = _StudentsOtherNames;
                // The display member is the name column in the column datasource  
                colCboxClassStudentOtherNames.DisplayMember = "StudentOtherNames";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassStudentOtherNames.DataPropertyName = "StudentId";
                // The value member is the primary key of the parent table  
                colCboxClassStudentOtherNames.ValueMember = "Id";
                colCboxClassStudentOtherNames.MaxDropDownItems = 10;
                colCboxClassStudentOtherNames.Width = 150;
                colCboxClassStudentOtherNames.DisplayIndex = 3;
                colCboxClassStudentOtherNames.MinimumWidth = 5;
                colCboxClassStudentOtherNames.FlatStyle = FlatStyle.Flat;
                colCboxClassStudentOtherNames.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassStudentOtherNames.ReadOnly = true; 
                if (!this.dataGridViewRegdStudents.Columns.Contains("cbClassStudentOtherNames"))
                {
                    dataGridViewRegdStudents.Columns.Add(colCboxClassStudentOtherNames);
                }

                var _ClassStreamsquery = from st in db.ClassStreams
                                         where st.IsDeleted==false
                                         select st;
                List<ClassStream> _ClassStreams = _ClassStreamsquery.ToList();
                DataGridViewComboBoxColumn colCboxCurrentClass = new DataGridViewComboBoxColumn();
                colCboxCurrentClass.HeaderText = "Stream";
                colCboxCurrentClass.Name = "cbCurrentClass";
                colCboxCurrentClass.DataSource = _ClassStreams;
                // The display member is the name column in the column datasource  
                colCboxCurrentClass.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxCurrentClass.DataPropertyName = "ClassStreamId";
                // The value member is the primary key of the parent table  
                colCboxCurrentClass.ValueMember = "Id";
                colCboxCurrentClass.MaxDropDownItems = 10;
                colCboxCurrentClass.Width = 100;
                colCboxCurrentClass.DisplayIndex = 4;
                colCboxCurrentClass.MinimumWidth = 5;
                colCboxCurrentClass.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colCboxCurrentClass.FlatStyle = FlatStyle.Flat;
                colCboxCurrentClass.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxCurrentClass.ReadOnly = true;
                if (!this.dataGridViewRegdStudents.Columns.Contains("cbCurrentClass"))
                {
                    //dataGridViewRegdStudents.Columns.Add(colCboxCurrentClass);
                }

                dataGridViewRegdStudents.Columns[3].Name = "ColumnMark";
                dataGridViewRegdStudents.Columns[4].Name = "ColumnGrade";
                dataGridViewRegdStudents.AutoGenerateColumns = false;
                dataGridViewRegdStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewRegdStudents.DataSource = bindingSourceRegdStudents;

                lblMessage.Text = string.Empty;
                lblMessage.Visible = false;
                lblSubjectDescription.Text = string.Empty;
                txtExam.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboSchoolClass_SelectedIndexChanged(object sender, EventArgs e)
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
        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Succesfully saved", "SB School");
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cbRegisteredExamTypes_SelectedIndexChanged(object sender, EventArgs e)
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

        private void CalculateMarkGrade()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridViewRegdStudents.Rows)
                {
                    int gradingsys = int.Parse(rep.SettingLookup("GRADINGSYS"));
                    double _Mark = 0;
                    double mark;
                    if (row.Cells["ColumnMark"].Value != null && double.TryParse(row.Cells["ColumnMark"].Value.ToString(), out mark))
                    {
                        _Mark = double.Parse(row.Cells["ColumnMark"].Value.ToString());
                    }
                    if (_Mark != 0)
                    {
                        string Grade = GradeLookUp(_Mark, gradingsys);
                        if (Grade != null)
                        {
                            row.Cells["ColumnGrade"].Value = Grade.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string GradeLookUp(double? Mark, int gradingsys)
        {
            if (!Mark.HasValue) return "No Mark";
            if (!(Mark is double)) return "No Mark";
            try
            {
                var rt = (from r in db.GradingSystemDets
                          orderby r.LMark ascending
                          where r.GradingSystemId == gradingsys
                          where r.LMark <= Mark.Value
                          where r.UMark >= Mark.Value
                          select r).SingleOrDefault();
                string ret = "Unknown";
                if (rt == null) { return ret; }
                return rt.Grade.Trim();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "Unknown";
            }
        }

        private void dataGridViewRegdStudents_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CalculateMarkGrade();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewRegdStudents_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CalculateMarkGrade();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewRegdStudents_DataError(object sender, DataGridViewDataErrorEventArgs e)
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