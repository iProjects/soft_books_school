using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using System.Threading;
using DAL;

namespace WinSBSchool.Controls
{
    public partial class ClassControl : UserControl
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public ClassControl(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished ClassControl initialization", TAG));

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

        private void ClassControl_Load(object sender, EventArgs e)
        {
            try
            {
                var teacher_query = from tc in db.Teachers
                                 where tc.Status == "A"
                                 where tc.IsDeleted == false
                                 orderby tc.Name ascending
                                 select tc;
                List<Teacher> _lstTeachers = teacher_query.ToList();

                cboclassteacher.DataSource = _lstTeachers;
                cboclassteacher.ValueMember = "Id";
                cboclassteacher.DisplayMember = "Name";
                cboclassteacher.SelectedIndex = -1;

                var programmes_query = from pys in db.ProgrammeYears
                                 where pys.IsDeleted == false
                                 select pys;
                List<ProgrammeYear> _lstProgrammeYears = programmes_query.ToList();

                DataGridViewComboBoxColumn colCboxProgrammeYears = new DataGridViewComboBoxColumn();
                colCboxProgrammeYears.HeaderText = "Programme Years";
                colCboxProgrammeYears.Name = "cbProgrammeYears";
                colCboxProgrammeYears.DataSource = _lstProgrammeYears;
                colCboxProgrammeYears.DisplayMember = "Description";
                colCboxProgrammeYears.DataPropertyName = "ProgrammeYearId";
                colCboxProgrammeYears.ValueMember = "Id";
                colCboxProgrammeYears.MaxDropDownItems = 10;
                colCboxProgrammeYears.DisplayIndex = 2;
                colCboxProgrammeYears.MinimumWidth = 5;
                colCboxProgrammeYears.Width = 100;
                colCboxProgrammeYears.FlatStyle = FlatStyle.Flat;
                colCboxProgrammeYears.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxProgrammeYears.ReadOnly = true;
                if (!this.dataGridViewSchoolClasses.Columns.Contains("cbProgrammeYears"))
                {
                    dataGridViewSchoolClasses.Columns.Add(colCboxProgrammeYears);
                }
                 
                DataGridViewComboBoxColumn colCboxClassTeacher = new DataGridViewComboBoxColumn();
                colCboxClassTeacher.HeaderText = "Teacher";
                colCboxClassTeacher.Name = "cbClassTeacher";
                colCboxClassTeacher.DataSource = _lstTeachers;
                colCboxClassTeacher.DisplayMember = "Name";
                colCboxClassTeacher.DataPropertyName = "TeacherId";
                colCboxClassTeacher.ValueMember = "Id";
                colCboxClassTeacher.MaxDropDownItems = 10;
                colCboxClassTeacher.DisplayIndex = 3;
                colCboxClassTeacher.MinimumWidth = 5;
                colCboxClassTeacher.Width = 100;
                colCboxClassTeacher.FlatStyle = FlatStyle.Flat;
                colCboxClassTeacher.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassTeacher.ReadOnly = true;
                if (!this.dataGridViewSchoolClasses.Columns.Contains("cbClassTeacher"))
                {
                    dataGridViewSchoolClasses.Columns.Add(colCboxClassTeacher);
                }

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
                colCboxStatus.DisplayIndex = 4;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true;
                //colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewSchoolClasses.Columns.Contains("cbStatus"))
                {
                    dataGridViewSchoolClasses.Columns.Add(colCboxStatus);
                }

                DataGridViewComboBoxColumn colCboxClassSubjectTeacher = new DataGridViewComboBoxColumn();
                colCboxClassSubjectTeacher.HeaderText = "Teacher";
                colCboxClassSubjectTeacher.Name = "cbClassSubjectTeacher";
                colCboxClassSubjectTeacher.DataSource = _lstTeachers;
                colCboxClassSubjectTeacher.DisplayMember = "Name";
                colCboxClassSubjectTeacher.DataPropertyName = "SubjectTeacherId";
                colCboxClassSubjectTeacher.ValueMember = "Id";
                colCboxClassSubjectTeacher.MaxDropDownItems = 10;
                colCboxClassSubjectTeacher.DisplayIndex = 2;
                colCboxClassSubjectTeacher.MinimumWidth = 5;
                colCboxClassSubjectTeacher.Width = 100;
                colCboxClassSubjectTeacher.FlatStyle = FlatStyle.Flat;
                colCboxClassSubjectTeacher.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassSubjectTeacher.ReadOnly = true;
                if (!this.DataGridViewclassSubjects.Columns.Contains("cbClassSubjectTeacher"))
                {
                    DataGridViewclassSubjects.Columns.Add(colCboxClassSubjectTeacher);
                }

                DataGridViewComboBoxColumn colCboxSubjectStatus = new DataGridViewComboBoxColumn();
                colCboxSubjectStatus.HeaderText = "Status";
                colCboxSubjectStatus.Name = "cbSubjectStatus";
                colCboxSubjectStatus.DataSource = status;
                // The display member is the name column in the column datasource  
                colCboxSubjectStatus.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxSubjectStatus.DataPropertyName = "Status";
                // The value member is the primary key of the parent table  
                colCboxSubjectStatus.ValueMember = "Key";
                colCboxSubjectStatus.MaxDropDownItems = 10;
                colCboxSubjectStatus.Width = 80;
                colCboxSubjectStatus.DisplayIndex = 4;
                colCboxSubjectStatus.MinimumWidth = 5;
                colCboxSubjectStatus.FlatStyle = FlatStyle.Flat;
                colCboxSubjectStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxSubjectStatus.ReadOnly = true;
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.DataGridViewclassSubjects.Columns.Contains("cbSubjectStatus"))
                {
                    DataGridViewclassSubjects.Columns.Add(colCboxSubjectStatus);
                }

                var schoolclass_query = from sc in db.SchoolClasses
                                     where sc.IsDeleted == false
                                     where sc.Status == "A"
                                     select sc;
                List<SchoolClass> _SchoolClasss = schoolclass_query.ToList();

                bindingSourceSchoolClasses.DataSource = _SchoolClasss;
                dataGridViewSchoolClasses.AutoGenerateColumns = false;
                this.dataGridViewSchoolClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewSchoolClasses.DataSource = bindingSourceSchoolClasses;
                 
                DataGridViewclassSubjects.AutoGenerateColumns = false;
                this.DataGridViewclassSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewclassSubjects.DataSource = bindingSourceclassSubjects;

                DataGridViewstudents.AutoGenerateColumns = false;
                this.DataGridViewstudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewstudents.DataSource = bindingSourceStudents;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished ClassControl load", TAG));
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewSchoolClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewSchoolClasses.SelectedRows.Count != 0)
                {
                    DAL.SchoolClass sclass = (DAL.SchoolClass)bindingSourceSchoolClasses.Current;

                    txtclassid.Text = sclass.Id.ToString();
                    txtclassname.Text = sclass.ClassName;
                    cboclassteacher.SelectedValue = sclass.TeacherId;
                    txtclassremarks.Text = sclass.Remarks;

                    load_class_subjects(sclass);
                    load_class_students(sclass);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void load_class_subjects(SchoolClass sclass)
        {
            try
            {
                bindingSourceclassSubjects.DataSource = null;
                var classsubjects_query = from cs in db.ClassSubjects
                                          where cs.ClassId == sclass.Id
                                          where cs.IsDeleted == false
                                          where cs.Status == "A"
                                          select cs;
                List<ClassSubject> _lstclasssubjects = classsubjects_query.ToList();

                bindingSourceclassSubjects.DataSource = _lstclasssubjects;
                groupboxclasssubjects.Text = bindingSourceclassSubjects.Count.ToString();
               
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void load_class_students(SchoolClass sclass)
        {
            try
            {
                bindingSourceStudents.DataSource = null;
                var students_query = from stds in db.Students
                                     join csm in db.ClassStreams on stds.ClassStreamId equals csm.Id
                                     join scs in db.SchoolClasses on csm.ClassId equals scs.Id
                                     where scs.Id == sclass.Id
                                     where stds.IsDeleted == false
                                     where stds.Status == "A"
                                     select stds;
                List<Student> _lststudents = students_query.ToList();

                bindingSourceStudents.DataSource = _lststudents;
                groupboxclasssubjects.Text = bindingSourceStudents.Count.ToString();
               
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewSchoolClasses_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
            }
            catch (Exception ex)
            {
                Log.Write_To_Log_File_temp_dir(ex);
            }
        }

        private void btnclearfilter_Click(object sender, EventArgs e)
        {
            txtSearchByName.Text = string.Empty;
            txtSearchByRegNo.Text = string.Empty;
        }

        private void dataGridViewSchoolClasses_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewSchoolClasses.SelectedRows.Count != 0)
                {
                    DAL.SchoolClass sclass = (DAL.SchoolClass)bindingSourceSchoolClasses.Current;

                    txtclassid.Text = sclass.Id.ToString();
                    txtclassname.Text = sclass.ClassName;
                    cboclassteacher.SelectedValue = sclass.TeacherId;
                    txtclassremarks.Text = sclass.Remarks;

                    load_class_subjects(sclass);
                    load_class_students(sclass);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void DataGridViewclassSubjects_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
            }
            catch (Exception ex)
            {
                Log.Write_To_Log_File_temp_dir(ex);
            }
        }

        private void DataGridViewclassSubjects_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewstudents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewstudents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
            }
            catch (Exception ex)
            {
                Log.Write_To_Log_File_temp_dir(ex);
            }
        }

        private void dataGridViewSchoolClasses_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewSchoolClasses_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSchoolClasses.SelectedRows.Count != 0)
                {
                    DAL.SchoolClass sclass = (DAL.SchoolClass)bindingSourceSchoolClasses.Current;

                    txtclassid.Text = sclass.Id.ToString();
                    txtclassname.Text = sclass.ClassName;
                    cboclassteacher.SelectedValue = sclass.TeacherId;
                    txtclassremarks.Text = sclass.Remarks;

                    load_class_subjects(sclass);
                    load_class_students(sclass);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }


    }
}
