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
using WinSBSchool.Reports.Views.Excel;

namespace WinSBSchool.Forms
{
    public partial class TeachersForm : Form
    { 
        SBSchoolDBEntities db;
        Repository rep;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public TeachersForm(string _user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            user = _user;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished TeachersForm initialization", TAG));

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

        private void TeachersForm_Load(object sender, EventArgs e)
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
                colCboxStatus.DisplayIndex = 7;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true; 
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewteachers.Columns.Contains("cbStatus"))
                {
                    dataGridViewteachers.Columns.Add(colCboxStatus);
                }

                var qualifications = new BindingList<KeyValuePair<string, string>>();
                qualifications.Add(new KeyValuePair<string, string>("DI", "Diploma"));
                qualifications.Add(new KeyValuePair<string, string>("DE", "Degree"));
                qualifications.Add(new KeyValuePair<string, string>("MA", "Masters"));
                qualifications.Add(new KeyValuePair<string, string>("PH", "Doctor of Philosophy(Phd)")); 
                DataGridViewComboBoxColumn colCboxQualifications = new DataGridViewComboBoxColumn();
                colCboxQualifications.HeaderText = "Qualification";
                colCboxQualifications.Name = "cbQualifications";
                colCboxQualifications.DataSource = qualifications;
                // The display member is the name column in the column datasource  
                colCboxQualifications.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxQualifications.DataPropertyName = "HighestQualification";
                // The value member is the primary key of the parent table  
                colCboxQualifications.ValueMember = "Key";
                colCboxQualifications.MaxDropDownItems = 10;
                colCboxQualifications.Width = 80;
                colCboxQualifications.DisplayIndex = 6;
                colCboxQualifications.MinimumWidth = 5;
                colCboxQualifications.FlatStyle = FlatStyle.Flat;
                colCboxQualifications.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxQualifications.ReadOnly = true; 
                //colCboxQualifications.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewteachers.Columns.Contains("cbQualifications"))
                {
                    dataGridViewteachers.Columns.Add(colCboxQualifications);
                }

                var _teachersquery = from tc in db.Teachers
                                     where tc.Status == "A"
                                     where tc.IsDeleted == false
                                     select tc;

                bindingSourceTeachers.DataSource = _teachersquery.ToList();
                groupBox2.Text = _teachersquery.Count().ToString();
                dataGridViewteachers.AutoGenerateColumns = false;
                this.dataGridViewteachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewteachers.DataSource = bindingSourceTeachers;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished TeachersForm load", TAG));

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
                    bindingSourceTeachers.DataSource = null;
                    var _teachersquery = from tc in db.Teachers
                                         where tc.IsDeleted ==false
                                         select tc;
                    bindingSourceTeachers.DataSource = _teachersquery.ToList();
                    groupBox2.Text = _teachersquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewteachers.Rows)
                    {
                        dataGridViewteachers.Rows[dataGridViewteachers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewteachers.Rows.Count - 1;
                        bindingSourceTeachers.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceTeachers.DataSource = null;
                    var _teachersquery = from tc in db.Teachers
                                         where tc.Status == "A"
                                         where tc.IsDeleted == false
                                         select tc;
                    bindingSourceTeachers.DataSource = _teachersquery.ToList();
                    groupBox2.Text = _teachersquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewteachers.Rows)
                    {
                        dataGridViewteachers.Rows[dataGridViewteachers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewteachers.Rows.Count - 1;
                        bindingSourceTeachers.Position = nRowIndex;
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
            Forms.AddTeacherForm at = new Forms.AddTeacherForm(connection) { Owner = this };
            at.ShowDialog();
        }
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceTeachers.DataSource = null;
                    var _teachersquery = from tc in db.Teachers
                                         where tc.IsDeleted == false
                                         select tc;
                    bindingSourceTeachers.DataSource = _teachersquery.ToList();
                    groupBox2.Text = _teachersquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewteachers.Rows)
                    {
                        dataGridViewteachers.Rows[dataGridViewteachers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewteachers.Rows.Count - 1;
                        bindingSourceTeachers.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceTeachers.DataSource = null;
                    var _teachersquery = from tc in db.Teachers
                                         where tc.Status == "A"
                                         where tc.IsDeleted == false
                                         select tc;
                    bindingSourceTeachers.DataSource = _teachersquery.ToList();
                    groupBox2.Text = _teachersquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewteachers.Rows)
                    {
                        dataGridViewteachers.Rows[dataGridViewteachers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewteachers.Rows.Count - 1;
                        bindingSourceTeachers.Position = nRowIndex;
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
                if (dataGridViewteachers.SelectedRows.Count != 0)
                {
                    DAL.Teacher teacher = (DAL.Teacher)bindingSourceTeachers.Current;
                    Forms.EditTeacherForm et = new Forms.EditTeacherForm(teacher, connection) { Owner = this };
                    et.Text = teacher.Name.ToUpper().Trim();
                    et.ShowDialog();
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

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewteachers.SelectedRows.Count != 0)
                {
                    DAL.Teacher teacher = (DAL.Teacher)bindingSourceTeachers.Current;

                    var _ClssSbjctsquery = from sc in db.ClassSubjects
                                           where sc.SubjectTeacherId == teacher.Id
                                           where sc.IsDeleted ==false
                                           where sc.Status == "A"
                                           select sc;

                    List<ClassSubject> _ClassSubjects = _ClssSbjctsquery.ToList();

                    var _schoolClassesquery = from sc in db.SchoolClasses
                                              where sc.IsDeleted == false
                                              where sc.TeacherId == teacher.Id
                                              select sc;
                    List<SchoolClass> _schoolClasses = _schoolClassesquery.ToList();

                    if (_ClassSubjects.Count > 0)
                    {
                        MessageBox.Show("There is a Class Subject Associated with this Teacher.\n DeAssociate the Class Subject  First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_schoolClasses.Count > 0)
                    {
                        MessageBox.Show("There is a Class Associated with this Teacher.\n DeAssociate the Class First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Teacher\n" + teacher.Name.ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteTeacher(teacher);
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

        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewteachers.SelectedRows.Count != 0)
                {
                    DAL.Teacher teacher = (DAL.Teacher)bindingSourceTeachers.Current;
                    Forms.EditTeacherForm et = new Forms.EditTeacherForm(teacher, connection) { Owner = this };
                    et.DisableControls();
                    et.Text = teacher.Name.ToUpper().Trim();
                    et.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewteachers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewteachers.SelectedRows.Count != 0)
                {
                    DAL.Teacher teacher = (DAL.Teacher)bindingSourceTeachers.Current;
                    Forms.EditTeacherForm et = new Forms.EditTeacherForm(teacher, connection) { Owner = this };
                    et.Text = teacher.Name.ToUpper().Trim();
                    et.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewteachers_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void btnexport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            saveFileDialog.Title = "Select an excel file";
            //openFileDialog1.FileName = "";
            //"Text files (*.txt)|*.txt|All files (*.*)|*.*"
            saveFileDialog.Filter = "Excel Files|*.xls;*.xlsx";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = saveFileDialog.FileName;

                // use bulkcopy method of upload
                try
                {
                    //clear or backup the destination
                    Download(strFileName, user);

                    Utils.ShowInfo("Download completed successfully");
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
        }

        private void Download(string strFileName, string User)
        {
            CreateExcelDoc excell_app = new CreateExcelDoc();

            //creates the main header
            //createHeaders(int row, int col, string htext, string cell1, string cell2, int mergeColumns, string b, bool font, int size, string fcolor)
            excell_app.createHeaders(1, 1, "Id", "A1", "A1", 0, "WHITE", true, 10, "n");
            //creates subheaders
            excell_app.createHeaders(1, 2, "Name", "A2", "A2", 0, "WHITE", true, 10, "n");
            excell_app.createHeaders(1, 3, "IDNo", "A3", "A3", 0, "WHITE", true, 10, "n");
            excell_app.createHeaders(1, 4, "TSCNo", "A4", "A4", 0, "WHITE", true, 10, "n");

            int row = 2;
            foreach (var rec in db.Teachers)
            {
                //add Data to to cells
                int col = 1;
                string addr = excell_app.IntAlpha(col) + row;
                //excell_app.addData(row, col, rec.Id.ToString(), addr, addr, "#,##0");
                excell_app.createHeaders(row, col, rec.Id.ToString(), addr, addr, 0, "WHITE", true, 10, "n");

                col++;
                addr = excell_app.IntAlpha(col) + row;
                //excell_app.addData(row, col, rec.FromAmt.ToString(), addr, addr, "#,##0");
                excell_app.createHeaders(row, col, rec.Name.ToString(), addr, addr, 0, "WHITE", true, 10, "n");

                col++;
                addr = excell_app.IntAlpha(col) + row;
                //excell_app.addData(row, col, rec.ToAmt.ToString(), addr, addr, "#,##0");
                excell_app.createHeaders(row, col, rec.IDNo.ToString(), addr, addr, 0, "WHITE", true, 10, "n");

                col++;
                addr = excell_app.IntAlpha(col) + row;
                //excell_app.addData(row, col, rec.Rate.ToString(), addr, addr, "#,##0");
                excell_app.createHeaders(row, col, rec.TSCNo.ToString(), addr, addr, 0, "WHITE", true, 10, "n");

                row++;

            }
            excell_app.Save(strFileName);
        }
         
        //Add data to repository

        public string GetConnectionString(string str)
        {
            //variable to hold our return value
            string conn = string.Empty;
            //check if a value was provided
            if (!string.IsNullOrEmpty(str))
            {
                //name provided so search for that connection
                conn = ConfigurationManager.ConnectionStrings[str].ConnectionString;
            }
            else
            //name not provided, get the 'default' connection
            {
                conn = ConfigurationManager.ConnectionStrings["DestinationConnectionString"].ConnectionString;
            }
            //return the value
            return conn;
        }
         

        private void btnimport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog.Title = "select an excel file";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
            openFileDialog.ShowDialog();

            string strFileName = openFileDialog.FileName;

            // use bulkcopy method of upload
            try
            {
                bool overwrite = false;
                if (DialogResult.Yes == MessageBox.Show("Do you wish to overwrite?", "Confirm Overwrite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    overwrite = true;
                }

                //clear or backup the destination
                upload_to_database(overwrite, strFileName, user);

                Utils.ShowInfo("Upload completed successfully");
            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                Utils.ShowError(ex);
            }
        }

        private void upload_to_database(bool Overwrite, string strFileName, string User)
        {
            string query = null;
            string SourceConnectionString = "";
            string strFileType = System.IO.Path.GetExtension(strFileName).ToString().ToLower();

            //Check file type
            if (strFileType != ".xls" && strFileType != ".xlsx")
            {
                throw new Exception("File Type not Excel");

            }

            //Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                SourceConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName
                    + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                SourceConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                    + strFileName + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            string destinationConnectionString = this.GetConnectionString("DestinationConnectionString");

            query = "SELECT Id, Name, IDNo, TSCNo FROM [Sheet1$]";

            using (var myConnection = new OleDbConnection(SourceConnectionString))

            using (var destinationConnection = new SqlConnection(destinationConnectionString))

            using (var bulkCopy = new SqlBulkCopy(destinationConnection))
            {

                //Map first column in source to second column in sql table (skipping the ID column).

                //Excel schema[Vehicle] Table schema[ID, Vehicle, QueueDate, QueueStatus, QueuePriority]
                //bulkCopy.ColumnMappings.Add(Excel, Sql)
                bulkCopy.ColumnMappings.Add("Id", "Id"); //
                bulkCopy.ColumnMappings.Add("Name", "Name"); //
                bulkCopy.ColumnMappings.Add("IDNo", "IDNo");
                bulkCopy.ColumnMappings.Add("TSCNo", "TSCNo");

                bulkCopy.DestinationTableName = "Teachers";

                if (Overwrite)
                {
                    try
                    {
                        string deleteQuery = "Delete from Teachers";
                        var delcmd = new SqlCommand(deleteQuery, destinationConnection);
                        destinationConnection.Open();
                        delcmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                        Utils.ShowError(ex);
                    }
                    finally
                    {
                        destinationConnection.Close();
                    }
                }
               
                using (var myCommand = new OleDbCommand(query, myConnection))
                {
                    myConnection.Open();

                    destinationConnection.Open();

                    var myReader = myCommand.ExecuteReader();

                    bulkCopy.WriteToServer(myReader);
                }
            }
        }






    }
}
