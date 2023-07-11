using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class FeeStructureOthersForm : Form
    {
         SBSchoolDBEntities db;
        string connection;

        public FeeStructureOthersForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
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
                    Forms.EditFeeStructureOthersForm es = new Forms.EditFeeStructureOthersForm(_FeeStructureOther, connection) { Owner = this };
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
                    Forms.EditFeeStructureOthersForm es = new Forms.EditFeeStructureOthersForm(_FeeStructureOther, connection) { Owner = this };
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