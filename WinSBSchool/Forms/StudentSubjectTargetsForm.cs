using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace WinSBSchool.Forms
{
    public partial class StudentSubjectTargetsForm : Form
    {

        Repository rep;
        string connection;
        SBSchoolDBEntities db;

        public StudentSubjectTargetsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            Forms.AddSubjectForm asf = new Forms.AddSubjectForm(connection) { Owner = this };
            asf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void StudentSubjectTargetsForm_Load(object sender, EventArgs e)
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
                colCboxStatus.DisplayIndex = 8;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true; 
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewStudentSubjectTargets.Columns.Contains("cbStatus"))
                {
                    dataGridViewStudentSubjectTargets.Columns.Add(colCboxStatus);
                }

                var _subjectsquery = from sb in db.Subjects
                                     where sb.Status == "A"
                                     select sb;
                bindingSourceStudentSubjectTargets.DataSource = _subjectsquery.ToList();
                groupBox2.Text = _subjectsquery.Count().ToString();

                dataGridViewStudentSubjectTargets.AutoGenerateColumns = false;
                this.dataGridViewStudentSubjectTargets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewStudentSubjectTargets.DataSource = bindingSourceStudentSubjectTargets;
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
                if (chkIsDeleted.Checked)
                {
                    bindingSourceStudentSubjectTargets.DataSource = null;
                    var _subjectsquery = from sb in db.Subjects
                                         select sb;
                    bindingSourceStudentSubjectTargets.DataSource = _subjectsquery.ToList();
                    groupBox2.Text = _subjectsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudentSubjectTargets.Rows)
                    {
                        dataGridViewStudentSubjectTargets.Rows[dataGridViewStudentSubjectTargets.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudentSubjectTargets.Rows.Count - 1;
                        bindingSourceStudentSubjectTargets.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceStudentSubjectTargets.DataSource = null;
                    var _subjectsquery = from sb in db.Subjects
                                         where sb.Status == "A"
                                         select sb;
                    bindingSourceStudentSubjectTargets.DataSource = _subjectsquery.ToList();
                    groupBox2.Text = _subjectsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudentSubjectTargets.Rows)
                    {
                        dataGridViewStudentSubjectTargets.Rows[dataGridViewStudentSubjectTargets.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudentSubjectTargets.Rows.Count - 1;
                        bindingSourceStudentSubjectTargets.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void chkIsDeleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsDeleted.Checked)
                {
                    bindingSourceStudentSubjectTargets.DataSource = null;
                    var _subjectsquery = from sb in db.Subjects
                                         select sb;
                    bindingSourceStudentSubjectTargets.DataSource = _subjectsquery.ToList();
                    groupBox2.Text = _subjectsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudentSubjectTargets.Rows)
                    {
                        dataGridViewStudentSubjectTargets.Rows[dataGridViewStudentSubjectTargets.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudentSubjectTargets.Rows.Count - 1;
                        bindingSourceStudentSubjectTargets.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceStudentSubjectTargets.DataSource = null;
                    var _subjectsquery = from sb in db.Subjects
                                         where sb.Status == "A"
                                         select sb;
                    bindingSourceStudentSubjectTargets.DataSource = _subjectsquery.ToList();
                    groupBox2.Text = _subjectsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudentSubjectTargets.Rows)
                    {
                        dataGridViewStudentSubjectTargets.Rows[dataGridViewStudentSubjectTargets.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudentSubjectTargets.Rows.Count - 1;
                        bindingSourceStudentSubjectTargets.Position = nRowIndex;
                    }
                }
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
                if (dataGridViewStudentSubjectTargets.SelectedRows.Count != 0)
                {

                    DAL.Subject s = (DAL.Subject)bindingSourceStudentSubjectTargets.Current;

                    var clsssbjctsquery = from cjs in db.ClassSubjects
                                          where cjs.SubjectCode == s.ShortCode
                                          select cjs;


                    List<ClassSubject> _ClassSubjects = clsssbjctsquery.ToList();

                    var ProgrammeYearCoursesquery = from pyc in db.ProgrammeYearCourses
                                                    where pyc.CourseId == s.ShortCode
                                                    select pyc;


                    List<ProgrammeYearCours> _ProgrammeYearCourses = ProgrammeYearCoursesquery.ToList();

                    if (_ClassSubjects.Count > 0)
                    {
                        MessageBox.Show("There is a Class Subject  Associated with this Subject.\n Delete the Class Subject First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (_ProgrammeYearCourses.Count > 0)
                    {
                        MessageBox.Show("There is a Programme Year Course Associated with this Subject.\n Delete the Programme Year Course First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Subject\n" + s.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteSubject(s);
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
                if (dataGridViewStudentSubjectTargets.SelectedRows.Count != 0)
                {
                    DAL.Subject subject = (DAL.Subject)bindingSourceStudentSubjectTargets.Current;
                    Forms.EditSubjectForm es = new Forms.EditSubjectForm(subject, connection) { Owner = this };
                    es.Text = subject.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void dataGridViewStudentSubjectTargets_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewStudentSubjectTargets.SelectedRows.Count != 0)
                {
                    DAL.Subject subject = (DAL.Subject)bindingSourceStudentSubjectTargets.Current;
                    Forms.EditSubjectForm es = new Forms.EditSubjectForm(subject, connection) { Owner = this };
                    es.Text = subject.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewStudentSubjectTargets_DataError(object sender, DataGridViewDataErrorEventArgs e)
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