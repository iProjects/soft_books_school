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
    public partial class TeachersForm : Form
    {
        Repository rep;
        string connection;
        SBSchoolDBEntities db;

        public TeachersForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
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

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



    }
}
