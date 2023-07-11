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
    public partial class ResidenceForm : Form
    {
        string connection;
        SBSchoolDBEntities db;

        public ResidenceForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddResidenceForm arf = new AddResidenceForm(connection) { Owner = this };
            arf.ShowDialog();
        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewResidence.SelectedRows.Count != 0)
            {
                try
                {
                    Residence _Residence = (Residence)bindingSourceResidence.Current;
                    EditResidenceForm erf = new EditResidenceForm(_Residence, connection) { Owner = this };
                    erf.Text = _Residence.Name.Trim().ToUpper();
                    erf.ShowDialog();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException != null)
                        msg += "\n" + ex.InnerException.Message;
                    MessageBox.Show(msg);
                }
            }
        }
        public void RefreshGrid()
        {
            //set the datasource to null
            bindingSourceResidence.DataSource = null;
            //set the datasource to a method 
            var _Rsdncs = from rh in db.Residences
                          select rh;
            List<Residence> Residences = _Rsdncs.ToList();
            bindingSourceResidence.DataSource = Residences;
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewResidence.SelectedRows.Count != 0)
            {
                try
                {
                    Residence _Residence = (Residence)bindingSourceResidence.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete  Residence \n" + _Residence.Name.Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.Residences.DeleteObject(_Residence);
                        db.SaveChanges();
                    }


                    this.RefreshGrid();
                }
                catch (Exception ex)
                {

                    string msg = ex.Message;
                    if (ex.InnerException != null)
                        msg += "\n" + ex.InnerException.Message;
                    MessageBox.Show(msg);

                }
            }
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void ResidenceForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _Rsdncs = from rh in db.Residences
                              select rh;
                List<Residence> Residences = _Rsdncs.ToList();
                bindingSourceResidence.DataSource = Residences;
                dataGridViewResidence.AutoGenerateColumns = false;
                dataGridViewResidence.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewResidence.DataSource = bindingSourceResidence;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }

        private void dataGridViewResidence_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewResidence.SelectedRows.Count != 0)
            {
                try
                {
                    Residence _Residence = (Residence)bindingSourceResidence.Current;
                    EditResidenceForm erf = new EditResidenceForm(_Residence, connection) { Owner = this };
                    erf.Text = _Residence.Name.Trim().ToUpper();
                    erf.ShowDialog();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException != null)
                        msg += "\n" + ex.InnerException.Message;
                    MessageBox.Show(msg);
                }
            }
        }

        
    }
}