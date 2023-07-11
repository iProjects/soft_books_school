using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class SchoolsForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;

        public SchoolsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var dfscl = (from sub in db.Schools
                             where sub.DefaultSchool == true
                             where sub.IsDeleted == false
                             select sub);
                if (dfscl.Count() > 0)
                {
                    Forms.AddSchoolForm asf = new Forms.AddSchoolForm(connection) { Owner = this };
                    asf.DisableChechBox();
                    asf.ShowDialog();
                }
                else
                {
                    Forms.AddSchoolForm asf = new Forms.AddSchoolForm(connection) { Owner = this };
                    asf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void SchoolsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var SchoolTypes = new BindingList<KeyValuePair<string, string>>();
                SchoolTypes.Add(new KeyValuePair<string, string>("1", "Pre-School"));
                SchoolTypes.Add(new KeyValuePair<string, string>("2", "Primary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("3", "Secondary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("4", "Tertiary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("5", "University"));
                SchoolTypes.Add(new KeyValuePair<string, string>("6", "Pre-School and Primary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("7", "Primary and Secondary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("8", "Primary, Secondary and Pre-School"));
                DataGridViewComboBoxColumn colSchoolType = new DataGridViewComboBoxColumn();
                colSchoolType.HeaderText = "School Type";
                colSchoolType.Name = "cbSchoolType";
                colSchoolType.DataSource = SchoolTypes;
                colSchoolType.DisplayMember = "Value";
                colSchoolType.DataPropertyName = "SchoolType";
                colSchoolType.ValueMember = "Key";
                colSchoolType.MaxDropDownItems = 10;
                colSchoolType.DisplayIndex = 3;
                colSchoolType.MinimumWidth = 5;
                colSchoolType.Width = 100;
                colSchoolType.FlatStyle = FlatStyle.Flat;
                colSchoolType.DefaultCellStyle.NullValue = "--- Select ---";
                colSchoolType.ReadOnly = true;
                //colSchoolType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewSchool.Columns.Contains("cbSchoolType"))
                {
                    dataGridViewSchool.Columns.Add(colSchoolType);
                }

                var _GradingSystemsquery = from dc in db.GradingSystems
                                           select dc;
                List<GradingSystem> _GradingSystems = _GradingSystemsquery.ToList();

                DataGridViewComboBoxColumn colGradingSystem = new DataGridViewComboBoxColumn();
                colGradingSystem.HeaderText = "Grading System";
                colGradingSystem.Name = "cbGradingSystem";
                colGradingSystem.DataSource = _GradingSystems;
                colGradingSystem.DisplayMember = "Description";
                colGradingSystem.DataPropertyName = "GradingSystem";
                colGradingSystem.ValueMember = "Id";
                colGradingSystem.MaxDropDownItems = 10;
                colGradingSystem.DisplayIndex = 4;
                colGradingSystem.MinimumWidth = 5;
                colGradingSystem.Width = 100;
                colGradingSystem.FlatStyle = FlatStyle.Flat;
                colGradingSystem.DefaultCellStyle.NullValue = "--- Select ---";
                colGradingSystem.ReadOnly = true;
                //colGradingSystem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewSchool.Columns.Contains("cbGradingSystem"))
                {
                    dataGridViewSchool.Columns.Add(colGradingSystem);
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
                if (!this.dataGridViewSchool.Columns.Contains("cbStatus"))
                {
                    dataGridViewSchool.Columns.Add(colCboxStatus);
                }

                var Schoolsquery = from sc in db.Schools
                                   where sc.Status == "A"
                                   where sc.IsDeleted == false
                                   select sc;
                bindingSourceSchools.DataSource = Schoolsquery.ToList();
                dataGridViewSchool.AutoGenerateColumns = false;
                this.dataGridViewSchool.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewSchool.DataSource = bindingSourceSchools;
                groupBox2.Text = bindingSourceSchools.Count.ToString();
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
                    //set the datasource to null
                    bindingSourceSchools.DataSource = null;
                    //set the datasource to a method
                    var Schoolsquery = from sc in db.Schools
                                       where sc.IsDeleted == false
                                       select sc;
                    bindingSourceSchools.DataSource = Schoolsquery.ToList();
                    groupBox2.Text = bindingSourceSchools.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSchool.Rows)
                    {
                        dataGridViewSchool.Rows[dataGridViewSchool.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSchool.Rows.Count - 1;
                        bindingSourceSchools.Position = nRowIndex;
                    }
                }
                else
                {
                    //set the datasource to null
                    bindingSourceSchools.DataSource = null;
                    //set the datasource to a method
                    var Schoolsquery = from sc in db.Schools
                                       where sc.Status == "A"
                                       where sc.IsDeleted == false
                                       select sc;
                    bindingSourceSchools.DataSource = Schoolsquery.ToList();
                    groupBox2.Text = bindingSourceSchools.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSchool.Rows)
                    {
                        dataGridViewSchool.Rows[dataGridViewSchool.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSchool.Rows.Count - 1;
                        bindingSourceSchools.Position = nRowIndex;
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
            if (dataGridViewSchool.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.School school = (DAL.School)bindingSourceSchools.Current;

                    var dfscl = (from sub in db.Schools
                                 where sub.DefaultSchool == true 
                                 where sub.IsDeleted == false
                                 select sub);

                    if (dfscl.Count() > 0 && school.DefaultSchool == true)
                    {
                        Forms.EditSchoolForm esf = new Forms.EditSchoolForm(school, connection) { Owner = this };
                        esf.Text = school.SchoolName.ToUpper().Trim();
                        esf.ShowDialog();
                    }
                    if (dfscl.Count() > 0 && school.DefaultSchool != true)
                    {
                        Forms.EditSchoolForm esf = new Forms.EditSchoolForm(school, connection) { Owner = this };
                        esf.Text = school.SchoolName.ToUpper().Trim();
                        esf.DisableCheckBox();
                        esf.ShowDialog();
                    }
                    if (dfscl.Count() == 0)
                    {
                        Forms.EditSchoolForm esf = new Forms.EditSchoolForm(school, connection) { Owner = this };
                        esf.Text = school.SchoolName.ToUpper().Trim();
                        esf.SetCheckBox();
                        esf.ShowDialog();
                    }
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
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewSchool.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.School school = (DAL.School)bindingSourceSchools.Current;

                    var stdsinschool = from pc in db.Students
                                       where pc.IsDeleted == false 
                                       where pc.SchoolId == school.Id
                                       select pc;
                    List<Student> stds = stdsinschool.ToList();

                    if (stds.Count > 0)
                    {
                        MessageBox.Show("There is a Student Associated with this School.\n Delete the Student First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete School\n" + school.SchoolName.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteSchool(school);
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
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewSchool.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.School school = (DAL.School)bindingSourceSchools.Current;
                    Forms.EditSchoolForm esf = new Forms.EditSchoolForm(school, connection) { Owner = this };
                    esf.DisableControls();
                    esf.Text = school.SchoolName.ToUpper().Trim();
                    esf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void dataGridViewSchool_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSchool.SelectedRows.Count != 0)
            {
                try
                {
                    var dfscl = from sub in db.Schools
                                where sub.DefaultSchool == true
                                where sub.IsDeleted == false 
                                select sub;

                    if (dfscl.Count() > 0)
                    {
                        DAL.School school = (DAL.School)bindingSourceSchools.Current;
                        if (school.DefaultSchool == true)
                        {
                            Forms.EditSchoolForm esf1 = new Forms.EditSchoolForm(school, connection) { Owner = this };
                            esf1.Text = school.SchoolName.ToUpper().Trim();
                            esf1.ShowDialog();
                        }
                        else
                        {
                            Forms.EditSchoolForm esf = new Forms.EditSchoolForm(school, connection) { Owner = this };
                            esf.Text = school.SchoolName.ToUpper().Trim();
                            esf.DisableCheckBox();
                            esf.ShowDialog();
                        }
                    }
                    else
                    {
                        DAL.School school = (DAL.School)bindingSourceSchools.Current;
                        Forms.EditSchoolForm esf = new Forms.EditSchoolForm(school, connection) { Owner = this };
                        esf.Text = school.SchoolName.ToUpper().Trim();
                        esf.ShowDialog();
                    }

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void CloseForm()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSchool_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private bool ValidDefaultSchool()
        {
            bool valid = false;
            var totalq = (from fs in db.Schools
                          where fs.DefaultSchool == true
                          select fs).FirstOrDefault();

            if (totalq != null)
            {
                valid = true;
            }
            if (totalq == null)
            {
                valid = false;
            }
            return valid;
        }
        private void groupBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataGridViewSchool.SelectedRows.Count > 0)
            {
                if (!ValidDefaultSchool())
                {
                    MessageBox.Show("Not default School is set!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    //set the datasource to null
                    bindingSourceSchools.DataSource = null;
                    //set the datasource to a method
                    var Schoolsquery = from sc in db.Schools 
                                       where sc.IsDeleted == false
                                       select sc;
                    bindingSourceSchools.DataSource = Schoolsquery.ToList();
                    groupBox2.Text = bindingSourceSchools.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSchool.Rows)
                    {
                        dataGridViewSchool.Rows[dataGridViewSchool.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSchool.Rows.Count - 1;
                        bindingSourceSchools.Position = nRowIndex;
                    }
                }
                else
                {
                    //set the datasource to null
                    bindingSourceSchools.DataSource = null;
                    //set the datasource to a method
                    var Schoolsquery = from sc in db.Schools
                                       where sc.Status == "A"
                                       where sc.IsDeleted == false
                                       select sc;
                    bindingSourceSchools.DataSource = Schoolsquery.ToList();
                    groupBox2.Text = bindingSourceSchools.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSchool.Rows)
                    {
                        dataGridViewSchool.Rows[dataGridViewSchool.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSchool.Rows.Count - 1;
                        bindingSourceSchools.Position = nRowIndex;
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