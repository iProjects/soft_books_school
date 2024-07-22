using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class FeeStructureOthersForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public FeeStructureOthersForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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
             
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished FeeStructureOthersForm initialization", TAG)); 

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
        private void FeeStructureOthersForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                              select fs;
                List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();

                bindingSourceFeeStructureOthers.DataSource = _FeeStructureOthers;
                dataGridViewFeeStructureOthers.AutoGenerateColumns = false;
                this.dataGridViewFeeStructureOthers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewFeeStructureOthers.DataSource = bindingSourceFeeStructureOthers;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Forms.AddFeeStructureOthersForm asf = new Forms.AddFeeStructureOthersForm(connection) { Owner = this };
            //asf.ShowDialog();
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            if (dataGridViewFeeStructureOthers.SelectedRows.Count != 0)
            {
                try
                { 
                    DAL.FeeStructureOther _FeeStructureOther = (DAL.FeeStructureOther)bindingSourceFeeStructureOthers.Current;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Fees Structure Other\n" + _FeeStructureOther.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.FeeStructureOthers.DeleteObject(_FeeStructureOther);
                        db.SaveChanges();
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void RefreshGrid()
        {
            try
            {
            //set the datasource to null
            bindingSourceFeeStructureOthers.DataSource = null;
            //set the datasource to a method
            var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                           select fs;
            List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();
            bindingSourceFeeStructureOthers.DataSource = _FeeStructureOthers;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

    }
}