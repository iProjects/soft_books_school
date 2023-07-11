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
    public partial class ResidenceHallsForm : Form
    {
        string connection;
        SBSchoolDBEntities db;

        public ResidenceHallsForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddResidenceHallForm arf = new AddResidenceHallForm(connection) { Owner = this };
            arf.ShowDialog();
        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewResidenceHalls.SelectedRows.Count != 0)
            {
                try
                {
                    ResidenceHall _ResidenceHall = (ResidenceHall)bindingSourceResidenceHalls.Current;
                    EditResidenceHallForm erf = new EditResidenceHallForm(_ResidenceHall, connection) { Owner = this };
                    erf.Text = _ResidenceHall.HallName.Trim().ToUpper();
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
            bindingSourceResidenceHalls.DataSource = null;
            //set the datasource to a method 
            var _RsdncHlls = from rh in db.ResidenceHalls
                             select rh;
            List<ResidenceHall> ResidenceHalls = _RsdncHlls.ToList();
            bindingSourceResidenceHalls.DataSource = ResidenceHalls;
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewResidenceHalls.SelectedRows.Count != 0)
            {
                try
                {
                    ResidenceHall _ResidenceHall = (ResidenceHall)bindingSourceResidenceHalls.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete  Residence Hall\n" + _ResidenceHall.HallName.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.ResidenceHalls.DeleteObject(_ResidenceHall);
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

        private void ResidenceHallsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _RsdncHlls = from rh in db.ResidenceHalls
                                 select rh;
                List<ResidenceHall> ResidenceHalls = _RsdncHlls.ToList();
                bindingSourceResidenceHalls.DataSource = ResidenceHalls;
                dataGridViewResidenceHalls.AutoGenerateColumns = false;
                dataGridViewResidenceHalls.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewResidenceHalls.DataSource = bindingSourceResidenceHalls;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }

        private void dataGridViewResidenceHalls_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewResidenceHalls.SelectedRows.Count != 0)
            {
                try
                {
                    ResidenceHall _ResidenceHall = (ResidenceHall)bindingSourceResidenceHalls.Current;
                    EditResidenceHallForm erf = new EditResidenceHallForm(_ResidenceHall, connection) { Owner = this };
                    erf.Text = _ResidenceHall.HallName.Trim().ToUpper();
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
