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
    public partial class GradingSystemForm : Form
    {
        SBSchoolDBEntities db;
        IQueryable<GradingSystem> gs;
        GradingSystem currentItem;
        bool dirty;
        string connection;

        public GradingSystemForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.IsContextDirty())
                {
                    if (MessageBox.Show("You have un saved changes. Do you want to save the changes",
                        "Save Changes",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                    {
                        db.SaveChanges();
                        MessageBox.Show("Save Successfull!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void GradingSystemForm_Load(object sender, EventArgs e)
        {
            try
            {
                gs = db.GradingSystems.Include("GradingSystemDets");
                bindingSourceGS.DataSource = gs;
                groupBox3.Text = bindingSourceGS.Count.ToString();

                listBoxGradingSystem.ValueMember = "Id";
                listBoxGradingSystem.DisplayMember = "Description";
                listBoxGradingSystem.DataSource = bindingSourceGS;
                listBoxGradingSystem.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
                MessageBox.Show("Save Successfull!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dirty = false;
                this.btnClose_Click(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddGradingSystem_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(txtGradingSys.Text))
                {
                    errorProvider1.SetError(txtGradingSys, "Grading System Description cannot be null!");
                    return;
                }

                string item = txtGradingSys.Text.Trim();

                //check if exists
                var exists = db.GradingSystems.Where(i => i.Description == item).FirstOrDefault();
                if (exists != null)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtGradingSys, "Grading System Description exists!");
                    return;
                }

                GradingSystem gs = new GradingSystem();
                //item.Description = "New Item";
                gs.Description = Utils.ConvertFirstLetterToUpper(txtGradingSys.Text.Trim());
                gs.Description = gs.Description.ToUpper();

                db.GradingSystems.AddObject(gs);
                db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

                RefreshGrid();
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
                //clear bindings
                gs = null;
                listBoxGradingSystem.DataSource = null;
                bindingSourceGSD.DataSource = null;
                dataGridViewGradingSystem.DataSource = null;
                groupBox1.Text = "0";

                //rebind
                gs = db.GradingSystems.Include("GradingSystemDets");
                bindingSourceGS.DataSource = gs;
                listBoxGradingSystem.DataSource = bindingSourceGS;
                groupBox3.Text = bindingSourceGS.Count.ToString();

                listBoxGradingSystem.ValueMember = "Id";
                listBoxGradingSystem.DisplayMember = "Description";
                listBoxGradingSystem.DataSource = bindingSourceGS;
                listBoxGradingSystem.SelectedIndex = -1;

                //listBoxGradingSystem.ValueMember = "Id";
                //listBoxGradingSystem.DisplayMember = "Description";
                //listBoxGradingSystem.DataSource = bindingSourceGS;                

                //this.txtGradingSys.DataBindings.Clear();
                //this.txtGradingSys.DataBindings.Add("Text", bindingSourceGS, "Description");
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnRemoveGradingSystem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxGradingSystem.SelectedIndex != -1)
                {
                    GradingSystem item = (GradingSystem)listBoxGradingSystem.SelectedItem;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Grading System\n" + item.Description.ToString().Trim().ToUpper() + " \n along with its Related Details", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        foreach (var gsdetail in item.GradingSystemDets)
                        {
                            db.GradingSystemDets.DeleteObject(gsdetail);
                        }

                        db.GradingSystems.DeleteObject(item);
                        db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

                        RefreshGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void listBoxGradingSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxGradingSystem.SelectedIndex != -1)
                {
                    currentItem = (GradingSystem)listBoxGradingSystem.SelectedItem;

                    var gsd = gs.Where(s => s.Id == currentItem.Id).SingleOrDefault();

                    if (gsd != null)
                    {
                        bindingSourceGSD.DataSource = gsd.GradingSystemDets;
                        dataGridViewGradingSystem.AutoGenerateColumns = false;
                        this.dataGridViewGradingSystem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridViewGradingSystem.DataSource = bindingSourceGSD;
                        groupBox1.Text = currentItem.GradingSystemDets.Count.ToString();

                        //this.txtGradingSys.DataBindings.Clear();
                        //this.txtGradingSys.DataBindings.Add("Text", bindingSourceGS, "Description");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtGradingSys_Validated(object sender, EventArgs e)
        {
            try
            {
                //if (currentItem != null)
                //{
                //    currentItem.Description = txtGradingSys.Text;
                //    dirty = true;
                //    ShowDirty();
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ShowDirty()
        {
            try
            {
                if (db.IsContextDirty())
                {
                    this.Text = "Grading System*";
                }
                else
                {
                    this.Text = "Grading System";
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewGradingSystem_Validated(object sender, EventArgs e)
        {
            try
            {
                dirty = true;
                ShowDirty();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewGradingSystem_DataError(object sender, DataGridViewDataErrorEventArgs e)
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