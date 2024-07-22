using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;
using System.Threading;

namespace WinSBSchool.Controls
{
    public partial class StudentDetailsControl : UserControl
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public StudentDetailsControl(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished StudentDetailsControl initialization", TAG));

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

        private void StudentDetailsControl_Load(object sender, EventArgs e)
        {
            try
            {
                var classesStreams_query = from cs in db.ClassStreams
                                           where cs.IsDeleted == false
                                           select cs;
                List<ClassStream> _ClasssStreams = classesStreams_query.ToList();

                bindingSourceClassStreams.DataSource = _ClasssStreams;
                cboclassStreams.DataSource = bindingSourceClassStreams;
                cboclassStreams.ValueMember = "Id";
                cboclassStreams.DisplayMember = "Description";
                cboclassStreams.SelectedIndex = -1;

                bindingSourceClassStreams.DataSource = db.ClassStreams.Where(i => i.IsDeleted == false);
                DataGridViewComboBoxColumn colCboxCurrentClass = new DataGridViewComboBoxColumn();
                colCboxCurrentClass.HeaderText = "Stream";
                colCboxCurrentClass.Name = "cbCurrentClass";
                colCboxCurrentClass.DataSource = bindingSourceClassStreams;
                // The display member is the name column in the column datasource  
                colCboxCurrentClass.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxCurrentClass.DataPropertyName = "ClassStreamId";
                // The value member is the primary key of the parent table  
                colCboxCurrentClass.ValueMember = "Id";
                colCboxCurrentClass.MaxDropDownItems = 10;
                colCboxCurrentClass.Width = 80;
                colCboxCurrentClass.DisplayIndex = 4;
                colCboxCurrentClass.MinimumWidth = 5;
                colCboxCurrentClass.FlatStyle = FlatStyle.Flat;
                colCboxCurrentClass.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxCurrentClass.ReadOnly = true;
                if (!this.dataGridViewStudents.Columns.Contains("cbCurrentClass"))
                {
                    dataGridViewStudents.Columns.Add(colCboxCurrentClass);
                }

                var gender = new BindingList<KeyValuePair<string, string>>();
                gender.Add(new KeyValuePair<string, string>("M", "Male"));
                gender.Add(new KeyValuePair<string, string>("F", "Female"));
                DataGridViewComboBoxColumn colCboxGender = new DataGridViewComboBoxColumn();
                colCboxGender.HeaderText = "Gender";
                colCboxGender.Name = "cbGender";
                colCboxGender.DataSource = gender;
                // The display member is the name column in the column datasource  
                colCboxGender.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxGender.DataPropertyName = "Gender";
                // The value member is the primary key of the parent table  
                colCboxGender.ValueMember = "Key";
                colCboxGender.MaxDropDownItems = 10;
                colCboxGender.Width = 80;
                colCboxGender.DisplayIndex = 7;
                colCboxGender.MinimumWidth = 5;
                colCboxGender.FlatStyle = FlatStyle.Flat;
                colCboxGender.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxGender.ReadOnly = true;
                if (!this.dataGridViewStudents.Columns.Contains("cbGender"))
                {
                    dataGridViewStudents.Columns.Add(colCboxGender);
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
                colCboxStatus.DisplayIndex = 8;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true;
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewStudents.Columns.Contains("cbStatus"))
                {
                    dataGridViewStudents.Columns.Add(colCboxStatus);
                }

                var statementflags = new BindingList<KeyValuePair<string, string>>();
                statementflags.Add(new KeyValuePair<string, string>("C", "Credit"));
                statementflags.Add(new KeyValuePair<string, string>("D", "Debit"));

                DataGridViewComboBoxColumn colCboxStatementFlag = new DataGridViewComboBoxColumn();
                colCboxStatementFlag.HeaderText = "Statement Flag";
                colCboxStatementFlag.Name = "cbStatementFlag";
                colCboxStatementFlag.DataSource = statementflags;
                // The display member is the name column in the column datasource  
                colCboxStatementFlag.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxStatementFlag.DataPropertyName = "StatementFlag";
                // The value member is the primary key of the parent table  
                colCboxStatementFlag.ValueMember = "Key";
                colCboxStatementFlag.MaxDropDownItems = 10;
                colCboxStatementFlag.Width = 70;
                colCboxStatementFlag.DisplayIndex = 2;
                colCboxStatementFlag.MinimumWidth = 5;
                colCboxStatementFlag.FlatStyle = FlatStyle.Flat;
                colCboxStatementFlag.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatementFlag.ReadOnly = true;
                if (!this.dataGridViewstudentfees.Columns.Contains("cbStatementFlag"))
                {
                    dataGridViewstudentfees.Columns.Add(colCboxStatementFlag);
                }

                var _students_query = from s in db.Students
                                      where s.Status == "A"
                                      where s.IsDeleted == false
                                      select s;

                bindingSourceStudents.DataSource = _students_query.ToList();
                dataGridViewStudents.AutoGenerateColumns = false;
                this.dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewStudents.DataSource = bindingSourceStudents;
                groupBox2.Text = bindingSourceStudents.Count.ToString();

                dataGridViewStudents.DataSource = bindingSourcestudentfees;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished StudentDetailsControl load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnadvancedfilter_Click(object sender, EventArgs e)
        {

        }

        private void btnclearfilter_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewStudents.SelectedRows.Count != 0)
                {
                    DAL.Student student = (DAL.Student)bindingSourceStudents.Current;

                    load_fee_records(student);
                    load_student_details(student);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void load_fee_records(Student student)
        {
            try
            {
                bindingSourcestudentfees.DataSource = null;
                var students_query = from stds in db.Students
                                     join csm in db.ClassStreams on stds.ClassStreamId equals csm.Id
                                     join scs in db.SchoolClasses on csm.ClassId equals scs.Id
                                     join cst in db.Customers on stds.CustomerId equals cst.Id
                                     join acc in db.Accounts on stds.GLAccountId equals acc.Id
                                     join txn in db.Transactions on acc.Id equals txn.AccountId
                                     where stds.Id == student.Id
                                     where stds.IsDeleted == false
                                     where stds.Status == "A"
                                     select new StudentDTO
                                     {
                                         Amount = txn.Amount,
                                         GLAccountId = txn.AccountId,
                                         Narrative = txn.Narrative,
                                         PostDate = txn.PostDate,
                                         StatementFlag = txn.StatementFlag
                                     };
                List<StudentDTO> _lststudents = students_query.ToList();

                bindingSourcestudentfees.DataSource = _lststudents;
                groupBoxstudentfees.Text = bindingSourcestudentfees.Count.ToString();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void load_student_details(Student student)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewStudents_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dataGridViewstudentfees_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
