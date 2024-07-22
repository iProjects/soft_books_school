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
    public partial class ClassesForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        IQueryable<ClassStream> csQuery;

        public ClassesForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished ClassesForm initialization", TAG));

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
        private void ClassForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _programmes_query = from pys in db.ProgrammeYears
                                        where pys.IsDeleted == false
                                        select pys;
                List<ProgrammeYear> _ProgrammeYears = _programmes_query.ToList();
                bindingSourceProgrammeYears.DataSource = _ProgrammeYears;
                DataGridViewComboBoxColumn colCboxProgrammeYears = new DataGridViewComboBoxColumn();
                colCboxProgrammeYears.HeaderText = "Programme Years";
                colCboxProgrammeYears.Name = "cbProgrammeYears";
                colCboxProgrammeYears.DataSource = bindingSourceProgrammeYears;
                colCboxProgrammeYears.DisplayMember = "Description";
                colCboxProgrammeYears.DataPropertyName = "ProgrammeYearId";
                colCboxProgrammeYears.ValueMember = "Id";
                colCboxProgrammeYears.MaxDropDownItems = 10;
                colCboxProgrammeYears.DisplayIndex = 3;
                colCboxProgrammeYears.MinimumWidth = 5;
                colCboxProgrammeYears.Width = 100;
                colCboxProgrammeYears.FlatStyle = FlatStyle.Flat;
                colCboxProgrammeYears.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxProgrammeYears.ReadOnly = true;
                if (!this.dataGridViewSchoolClasses.Columns.Contains("cbProgrammeYears"))
                {
                    dataGridViewSchoolClasses.Columns.Add(colCboxProgrammeYears);
                }

                var teachers_query = from tc in db.Teachers
                                     where tc.Status == "A"
                                     where tc.IsDeleted == false
                                     select tc;
                List<Teacher> _Teachers = teachers_query.ToList();
                bindingSourceTeachers.DataSource = _Teachers;
                DataGridViewComboBoxColumn colCboxClassTeacher = new DataGridViewComboBoxColumn();
                colCboxClassTeacher.HeaderText = "Teacher";
                colCboxClassTeacher.Name = "cbClassTeacher";
                colCboxClassTeacher.DataSource = bindingSourceTeachers;
                colCboxClassTeacher.DisplayMember = "Name";
                colCboxClassTeacher.DataPropertyName = "TeacherId";
                colCboxClassTeacher.ValueMember = "Id";
                colCboxClassTeacher.MaxDropDownItems = 10;
                colCboxClassTeacher.DisplayIndex = 4;
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
                colCboxStatus.DisplayIndex = 5;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true;
                //colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewSchoolClasses.Columns.Contains("cbStatus"))
                {
                    dataGridViewSchoolClasses.Columns.Add(colCboxStatus);
                }

                var school_query = from sc in db.SchoolClasses
                                   where sc.IsDeleted == false
                                   where sc.Status == "A"
                                   select sc;
                List<SchoolClass> _SchoolClasss = school_query.ToList();
                bindingSourceSchoolClasses.DataSource = _SchoolClasss;

                dataGridViewSchoolClasses.AutoGenerateColumns = false;
                this.dataGridViewSchoolClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewSchoolClasses.DataSource = bindingSourceSchoolClasses;
                groupBox2.Text = bindingSourceSchoolClasses.Count.ToString();

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished ClassesForm load", TAG));

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
                if (chkInActive.Checked)
                {
                    bindingSourceSchoolClasses.DataSource = null;
                    var SchlClsssquery = from sc in db.SchoolClasses
                                         where sc.IsDeleted == false
                                         select sc;
                    List<SchoolClass> _SchoolClasss = SchlClsssquery.ToList();
                    bindingSourceSchoolClasses.DataSource = _SchoolClasss;
                    groupBox2.Text = bindingSourceSchoolClasses.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSchoolClasses.Rows)
                    {
                        dataGridViewSchoolClasses.Rows[dataGridViewSchoolClasses.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSchoolClasses.Rows.Count - 1;
                        bindingSourceSchoolClasses.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceSchoolClasses.DataSource = null;
                    var SchlClsssquery = from sc in db.SchoolClasses
                                         where sc.IsDeleted == false
                                         where sc.Status == "A"
                                         select sc;
                    List<SchoolClass> _SchoolClasss = SchlClsssquery.ToList();
                    bindingSourceSchoolClasses.DataSource = _SchoolClasss;
                    groupBox2.Text = bindingSourceSchoolClasses.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSchoolClasses.Rows)
                    {
                        dataGridViewSchoolClasses.Rows[dataGridViewSchoolClasses.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSchoolClasses.Rows.Count - 1;
                        bindingSourceSchoolClasses.Position = nRowIndex;
                    }
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Forms.AddClassForm ac = new Forms.AddClassForm(connection) { Owner = this };
                ac.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewSchoolClasses.SelectedRows.Count != 0)
                {
                    DAL.SchoolClass sc = (DAL.SchoolClass)bindingSourceSchoolClasses.Current;

                    var _ClassStreamsquery = from cs in db.ClassStreams
                                             where cs.IsDeleted == false
                                             where cs.ClassId == sc.Id
                                             select cs;
                    List<ClassStream> _ClassStreams = _ClassStreamsquery.ToList();

                    var _ClassSubjectsquery = from cs in db.ClassSubjects
                                              where cs.Status == "A"
                                              where cs.IsDeleted == false
                                              where cs.ClassId == sc.Id
                                              select cs;
                    List<ClassSubject> _ClassSubjects = _ClassSubjectsquery.ToList();

                    if (_ClassStreams.Count > 0)
                    {
                        MessageBox.Show("There is a Stream Associated with this Class.\n Delete the Stream First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_ClassSubjects.Count > 0)
                    {
                        MessageBox.Show("There is a Subject Associated with this Class.\n Delete the Subject First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete  Class\n" + sc.ClassName.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteSchoolClass(sc);
                            RefreshGrid();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewSchoolClasses.SelectedRows.Count != 0)
                {
                    DAL.SchoolClass clas = (DAL.SchoolClass)bindingSourceSchoolClasses.Current;
                    Forms.EditClassForm ec = new Forms.EditClassForm(clas, connection) { Owner = this };
                    ec.Text = clas.ClassName.ToString().ToUpper().Trim();
                    ec.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSchoolClasses_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewSchoolClasses.SelectedRows.Count != 0)
                {
                    DAL.SchoolClass clas = (DAL.SchoolClass)bindingSourceSchoolClasses.Current;
                    Forms.EditClassForm ec = new Forms.EditClassForm(clas, connection) { Owner = this };
                    ec.Text = clas.ClassName.ToString().ToUpper().Trim();
                    ec.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewSchoolClasses.SelectedRows.Count != 0)
                {
                    DAL.SchoolClass clas = (DAL.SchoolClass)bindingSourceSchoolClasses.Current;
                    Forms.EditClassForm ec = new Forms.EditClassForm(clas, connection) { Owner = this };
                    ec.Text = clas.ClassName.ToString().ToUpper().Trim();
                    ec.DisableControls();
                    ec.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceSchoolClasses.DataSource = null;
                    var SchlClsssquery = from sc in db.SchoolClasses
                                         where sc.IsDeleted == false
                                         select sc;
                    List<SchoolClass> _SchoolClasss = SchlClsssquery.ToList();
                    bindingSourceSchoolClasses.DataSource = _SchoolClasss;
                    groupBox2.Text = bindingSourceSchoolClasses.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSchoolClasses.Rows)
                    {
                        dataGridViewSchoolClasses.Rows[dataGridViewSchoolClasses.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSchoolClasses.Rows.Count - 1;
                        bindingSourceSchoolClasses.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceSchoolClasses.DataSource = null;
                    var SchlClsssquery = from sc in db.SchoolClasses
                                         where sc.IsDeleted == false
                                         where sc.Status == "A"
                                         select sc;
                    List<SchoolClass> _SchoolClasss = SchlClsssquery.ToList();
                    bindingSourceSchoolClasses.DataSource = _SchoolClasss;
                    groupBox2.Text = bindingSourceSchoolClasses.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSchoolClasses.Rows)
                    {
                        dataGridViewSchoolClasses.Rows[dataGridViewSchoolClasses.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSchoolClasses.Rows.Count - 1;
                        bindingSourceSchoolClasses.Position = nRowIndex;
                    }
                }
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










    }
}