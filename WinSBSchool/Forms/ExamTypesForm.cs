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
    public partial class ExamTypesForm : Form
    {
        SBSchoolDBEntities db; 
        string connection;
        Repository rep;

        public ExamTypesForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

        }
        private void ExamTypesForm_Load(object sender, EventArgs e)
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
                colCboxStatus.DisplayIndex = 5;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true;
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewExamType.Columns.Contains("cbStatus"))
                {
                    dataGridViewExamType.Columns.Add(colCboxStatus);
                } 

                dataGridViewExamType.AutoGenerateColumns = false;
                this.dataGridViewExamType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceExamType.DataSource = rep.GetActiveExamTypes();
                dataGridViewExamType.DataSource = bindingSourceExamType;
                groupBox2.Text = bindingSourceExamType.Count.ToString();
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
                    bindingSourceExamType.DataSource = null;
                    bindingSourceExamType.DataSource = rep.GetAllExamTypes();
                    groupBox2.Text = bindingSourceExamType.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewExamType.Rows)
                    {
                        dataGridViewExamType.Rows[dataGridViewExamType.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewExamType.Rows.Count - 1;
                        bindingSourceExamType.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceExamType.DataSource = null;
                    bindingSourceExamType.DataSource = rep.GetActiveExamTypes();
                    groupBox2.Text = bindingSourceExamType.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewExamType.Rows)
                    {
                        dataGridViewExamType.Rows[dataGridViewExamType.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewExamType.Rows.Count - 1;
                        bindingSourceExamType.Position = nRowIndex;
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
            Forms.AddExamTypeForm ac = new Forms.AddExamTypeForm(connection) { Owner = this };
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
                if (dataGridViewExamType.SelectedRows.Count != 0)
                {
                    DAL.ExamType p = (DAL.ExamType)bindingSourceExamType.Current;

                    var _activeexamsquery = from ex in db.Exams
                                            join re in db.RegisteredExams on ex.Id equals re.ExamId
                                            join et in db.ExamTypes on re.ExamTypeId equals et.Id
                                            
                                            where ex.IsDeleted == false 
                                            select ex;
                    List<Exam> _activeexams = _activeexamsquery.ToList();

                    if (_activeexams.Count > 0)
                    {
                        MessageBox.Show("There is an Exam Associated with this Exam Type.\n Delete the Exam First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Exam Type\n" + p.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteExamType(p);

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
                if (dataGridViewExamType.SelectedRows.Count != 0)
                {
                    DAL.ExamType et = (DAL.ExamType)bindingSourceExamType.Current;
                    Forms.EditExamTypeForm eetf = new Forms.EditExamTypeForm(et, connection) { Owner = this };
                    eetf.Text = et.Description.ToString().ToUpper().Trim();
                    eetf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ExamTypeDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewExamType.SelectedRows.Count != 0)
                {
                    DAL.ExamType et = (DAL.ExamType)bindingSourceExamType.Current;
                    Forms.EditExamTypeForm eetf = new Forms.EditExamTypeForm(et, connection) { Owner = this };
                    eetf.Text = et.Description.ToString().ToUpper().Trim();
                    eetf.ShowDialog();
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
                    bindingSourceExamType.DataSource = null;
                    bindingSourceExamType.DataSource = rep.GetAllExamTypes();
                    groupBox2.Text = bindingSourceExamType.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewExamType.Rows)
                    {
                        dataGridViewExamType.Rows[dataGridViewExamType.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewExamType.Rows.Count - 1;
                        bindingSourceExamType.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceExamType.DataSource = null;
                    bindingSourceExamType.DataSource = rep.GetActiveExamTypes();
                    groupBox2.Text = bindingSourceExamType.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewExamType.Rows)
                    {
                        dataGridViewExamType.Rows[dataGridViewExamType.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewExamType.Rows.Count - 1;
                        bindingSourceExamType.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 


    }
}