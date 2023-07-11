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
    public partial class DisciplinaryCategoriesForm : Form
    {
        SBSchoolDBEntities db;
        string connection;
        Repository rep;

        public DisciplinaryCategoriesForm(string Conn)
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
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewDisciplinaryCategories.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.DisciplinaryCategory disciplinarycategory = (DAL.DisciplinaryCategory)bindingSourceDisplinaryCategories.Current;

                    var _Dsplns = from dp in db.Disciplines
                                  where dp.DisciplineCategoryId == disciplinarycategory.Id
                                  where dp.IsDeleted == false
                                  select dp;
                    List<Discipline> _Disciplines = _Dsplns.ToList();

                    if (_Disciplines.Count > 0)
                    {
                        MessageBox.Show("There is a Student with a Discipline Associated with this Disciplinary Category.\n Delete the Discipline First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Disciplinary Category\n" + disciplinarycategory.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteDisciplinaryCategory(disciplinarycategory);

                            RefreshGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewDisciplinaryCategories.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.DisciplinaryCategory disciplinarycategory = (DAL.DisciplinaryCategory)bindingSourceDisplinaryCategories.Current;
                    EditDisciplinaryCategoriesForm edcf = new EditDisciplinaryCategoriesForm(disciplinarycategory, connection) { Owner = this };
                    edcf.Text = disciplinarycategory.Description.ToString().ToUpper();
                    edcf.ShowDialog();
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
                if (chkInActive.Checked)
                {
                    bindingSourceDisplinaryCategories.DataSource = null;
                    var _dscplnryCtgryquery = from dcs in db.DisciplinaryCategories
                                              where dcs.IsDeleted == false
                                              select dcs;
                    List<DisciplinaryCategory> _disciplinaryCategories = _dscplnryCtgryquery.ToList();
                    bindingSourceDisplinaryCategories.DataSource = _disciplinaryCategories;
                    groupBox2.Text = bindingSourceDisplinaryCategories.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewDisciplinaryCategories.Rows)
                    {
                        dataGridViewDisciplinaryCategories.Rows[dataGridViewDisciplinaryCategories.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewDisciplinaryCategories.Rows.Count - 1;
                        bindingSourceDisplinaryCategories.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceDisplinaryCategories.DataSource = null;
                    var _dscplnryCtgryquery = from dcs in db.DisciplinaryCategories
                                              where dcs.IsDeleted == false
                                              where dcs.Status == "A"
                                              select dcs;
                    List<DisciplinaryCategory> _disciplinaryCategories = _dscplnryCtgryquery.ToList();
                    bindingSourceDisplinaryCategories.DataSource = _disciplinaryCategories;
                    groupBox2.Text = bindingSourceDisplinaryCategories.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewDisciplinaryCategories.Rows)
                    {
                        dataGridViewDisciplinaryCategories.Rows[dataGridViewDisciplinaryCategories.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewDisciplinaryCategories.Rows.Count - 1;
                        bindingSourceDisplinaryCategories.Position = nRowIndex;
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
            try
            {
                AddDisciplinaryCategoriesForm aaf = new AddDisciplinaryCategoriesForm(connection) { Owner = this };
                aaf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DisciplinaryCategoriesForm_Load(object sender, EventArgs e)
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
                colCboxStatus.DisplayIndex = 3;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true;
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewDisciplinaryCategories.Columns.Contains("cbStatus"))
                {
                    dataGridViewDisciplinaryCategories.Columns.Add(colCboxStatus);
                }

                var _dscplnryCtgryquery = from dcs in db.DisciplinaryCategories
                                          where dcs.IsDeleted == false
                                          where dcs.Status == "A"
                                          select dcs;
                List<DisciplinaryCategory> _disciplinaryCategories = _dscplnryCtgryquery.ToList();
                bindingSourceDisplinaryCategories.DataSource = _disciplinaryCategories;
                dataGridViewDisciplinaryCategories.AutoGenerateColumns = false;
                dataGridViewDisciplinaryCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewDisciplinaryCategories.DataSource = bindingSourceDisplinaryCategories;
                groupBox2.Text = bindingSourceDisplinaryCategories.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewDisciplinaryCategories_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDisciplinaryCategories.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.DisciplinaryCategory disciplinarycategory = (DAL.DisciplinaryCategory)bindingSourceDisplinaryCategories.Current;
                    EditDisciplinaryCategoriesForm edcf = new EditDisciplinaryCategoriesForm(disciplinarycategory, connection) { Owner = this };
                    edcf.Text = disciplinarycategory.Description.ToString().ToUpper();
                    edcf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceDisplinaryCategories.DataSource = null;
                    var _dscplnryCtgryquery = from dcs in db.DisciplinaryCategories
                                              where dcs.IsDeleted == false
                                              select dcs;
                    List<DisciplinaryCategory> _disciplinaryCategories = _dscplnryCtgryquery.ToList();
                    bindingSourceDisplinaryCategories.DataSource = _disciplinaryCategories;
                    groupBox2.Text = bindingSourceDisplinaryCategories.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewDisciplinaryCategories.Rows)
                    {
                        dataGridViewDisciplinaryCategories.Rows[dataGridViewDisciplinaryCategories.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewDisciplinaryCategories.Rows.Count - 1;
                        bindingSourceDisplinaryCategories.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceDisplinaryCategories.DataSource = null;
                    var _dscplnryCtgryquery = from dcs in db.DisciplinaryCategories
                                              where dcs.IsDeleted == false
                                              where dcs.Status == "A"
                                              select dcs;
                    List<DisciplinaryCategory> _disciplinaryCategories = _dscplnryCtgryquery.ToList();
                    bindingSourceDisplinaryCategories.DataSource = _disciplinaryCategories;
                    groupBox2.Text = bindingSourceDisplinaryCategories.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewDisciplinaryCategories.Rows)
                    {
                        dataGridViewDisciplinaryCategories.Rows[dataGridViewDisciplinaryCategories.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewDisciplinaryCategories.Rows.Count - 1;
                        bindingSourceDisplinaryCategories.Position = nRowIndex;
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