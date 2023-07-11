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
    public partial class TransportForm : Form
    {
        string connection;
        SBSchoolDBEntities db;

        public TransportForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddTransportForm arf = new AddTransportForm(connection) { Owner = this };
            arf.ShowDialog();
        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTransport.SelectedRows.Count != 0)
            {
                try
                {
                    Transport _Transport = (Transport)bindingSourceTransport.Current;
                    EditTransportForm erf = new EditTransportForm(_Transport, connection) { Owner = this };
                    erf.Text = "Edit Transport";
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
            bindingSourceTransport.DataSource = null;
            //set the datasource to a method 
            var _Trnsprts = from tp in db.Transports
                            select tp;
            List<Transport> Transports = _Trnsprts.ToList();
            bindingSourceTransport.DataSource = Transports;
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTransport.SelectedRows.Count != 0)
            {
                try
                {
                    Transport _Transport = (Transport)bindingSourceTransport.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Transport ", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.Transports.DeleteObject(_Transport);
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

        private void TransportForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _Trnsprts = from rh in db.Transports
                              select rh;
                List<Transport> Transports = _Trnsprts.ToList();
                bindingSourceTransport.DataSource = Transports;
                dataGridViewTransport.AutoGenerateColumns = false;
                dataGridViewTransport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewTransport.DataSource = bindingSourceTransport;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }

        private void dataGridViewTransport_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTransport.SelectedRows.Count != 0)
            {
                try
                {
                    Transport _Transport = (Transport)bindingSourceTransport.Current;
                    EditTransportForm erf = new EditTransportForm(_Transport, connection) { Owner = this };
                    erf.Text = "Edit Transport";
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
