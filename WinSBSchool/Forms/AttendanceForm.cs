using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class AttendanceForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;

        public AttendanceForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            try
            {  
                var Attendancequery = from sc in rep.GetAllAttendances()
                                      where sc.IsDeleted == false
                                      select sc;
                List<AttendanceModel> _Attendances = Attendancequery.ToList();
                bindingSourceAttendance.DataSource = _Attendances;
                dataGridViewAttendance.AutoGenerateColumns = false;
                this.dataGridViewAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewAttendance.DataSource = bindingSourceAttendance;
                groupBox2.Text = bindingSourceAttendance.Count.ToString();
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
                bindingSourceAttendance.DataSource = null;
                var Attendancequery = from sc in rep.GetAllAttendances()
                                      where sc.IsDeleted==false
                                      select sc;
                List<AttendanceModel> _Attendances = Attendancequery.ToList();
                bindingSourceAttendance.DataSource = _Attendances;
                groupBox2.Text = bindingSourceAttendance.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewAttendance.Rows)
                {
                    dataGridViewAttendance.Rows[dataGridViewAttendance.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewAttendance.Rows.Count - 1;
                    bindingSourceAttendance.Position = nRowIndex;
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
                Forms.AddAttendanceForm ac = new Forms.AddAttendanceForm(connection) { Owner = this };
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
                if (dataGridViewAttendance.SelectedRows.Count != 0)
                {
                    DAL.AttendanceModel _Attendance = (DAL.AttendanceModel)bindingSourceAttendance.Current;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete  Attendance", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteAttendance(_Attendance);

                        RefreshGrid();
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
                if (dataGridViewAttendance.SelectedRows.Count != 0)
                {
                    DAL.AttendanceModel _Attendance = (DAL.AttendanceModel)bindingSourceAttendance.Current;
                    Forms.EditAttendanceForm ec = new Forms.EditAttendanceForm(_Attendance, connection) { Owner = this };
                    ec.Text = "Edit Attendance";
                    ec.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewAttendance_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewAttendance.SelectedRows.Count != 0)
                {
                    DAL.AttendanceModel _Attendance = (DAL.AttendanceModel)bindingSourceAttendance.Current;
                    Forms.EditAttendanceForm ec = new Forms.EditAttendanceForm(_Attendance, connection) { Owner = this };
                    ec.Text = "Edit Attendance";
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
                if (dataGridViewAttendance.SelectedRows.Count != 0)
                {
                    DAL.AttendanceModel _Attendance = (DAL.AttendanceModel)bindingSourceAttendance.Current;
                    Forms.EditAttendanceForm ec = new Forms.EditAttendanceForm(_Attendance, connection) { Owner = this };
                    ec.Text = "Attendance Details";
                    ec.DisableControls();
                    ec.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void dataGridViewAttendance_DataError(object sender, DataGridViewDataErrorEventArgs e)
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