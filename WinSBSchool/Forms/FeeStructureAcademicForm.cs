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
	public partial class FeeStructureAcademicForm: Form
	{
		 SBSchoolDBEntities db;
        string connection;

        public FeeStructureAcademicForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
        }
        private void FeeStructureAcademicForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                              select fs;
                List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();
                bindingSourceFeeStructureAcademic.DataSource = _FeeStructureAcademics;
                dataGridViewFeeStructureAcademic.AutoGenerateColumns = false;
                this.dataGridViewFeeStructureAcademic.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewFeeStructureAcademic.DataSource = bindingSourceFeeStructureAcademic;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Forms.AddFeeStructureAcademicForm asf = new Forms.AddFeeStructureAcademicForm(connection) { Owner = this };
            //asf.ShowDialog();
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFeeStructureAcademic.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeeStructureAcademic _FeeStructureAcademic = (DAL.FeeStructureAcademic)bindingSourceFeeStructureAcademic.Current;
                    Forms.EditFeeStructureAcademicForm es = new Forms.EditFeeStructureAcademicForm(_FeeStructureAcademic, connection) { Owner = this };
                    es.Text = _FeeStructureAcademic.Description.ToUpper().Trim();
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
            if (dataGridViewFeeStructureAcademic.SelectedRows.Count != 0)
            {
                try
                { 
                    DAL.FeeStructureAcademic _FeeStructureAcademic = (DAL.FeeStructureAcademic)bindingSourceFeeStructureAcademic.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Fees Structure Academic\n" + _FeeStructureAcademic.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            db.FeeStructureAcademics.DeleteObject(_FeeStructureAcademic);
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        public void RefreshGrid()
        {
            //set the datasource to null
            bindingSourceFeeStructureAcademic.DataSource = null;
            //set the datasource to a method
            var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                              select fs;
            List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();
            bindingSourceFeeStructureAcademic.DataSource = _FeeStructureAcademics;
        }
        private void dataGridViewFeeStructureAcademic_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFeeStructureAcademic.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FeeStructureAcademic _FeeStructureAcademic = (DAL.FeeStructureAcademic)bindingSourceFeeStructureAcademic.Current;
                    Forms.EditFeeStructureAcademicForm es = new Forms.EditFeeStructureAcademicForm(_FeeStructureAcademic, connection) { Owner = this };
                    es.Text = _FeeStructureAcademic.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }


    }
}