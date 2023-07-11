using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace WinSBSchool.Forms
{
    public partial class ParentsForm : Form
     {

        Repository rep;
        string connection;
        public ParentsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.AddParentForm asf = new Forms.AddParentForm(connection) { Owner = this };
            asf.ShowDialog();
        }

        private void ParentsForm_Load(object sender, EventArgs e)
        {
            dataGridViewParents.AutoGenerateColumns = false;
            this.dataGridViewParents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bindingSourceParents.DataSource = rep.GetAllParents();
            dataGridViewParents.DataSource = bindingSourceParents;
        }

        public void RefreshGrid()
        {
            //set the datasource to null
            bindingSourceParents.DataSource = null;
            //set the datasource to a method
            bindingSourceParents.DataSource = rep.GetAllParents();

        }

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewParents.SelectedRows.Count != 0)
                {
                    DAL.Parent p = (DAL.Parent)bindingSourceParents.Current;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Parent\n" + p.Name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteParent(p);
                        RefreshGrid();

                    }

                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewParents.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.Parent parent = (DAL.Parent)bindingSourceParents.Current;
                    Forms.EditParentForm es = new Forms.EditParentForm(parent, connection) { Owner = this };
                    es.Text = parent.Name.ToUpper().Trim();
                    es.ShowDialog();
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

        private void dataGridViewParents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewParents.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.Parent parent = (DAL.Parent)bindingSourceParents.Current;
                    Forms.EditParentForm es = new Forms.EditParentForm(parent, connection) { Owner = this };
                    es.Text = parent.Name.ToUpper().Trim();
                    es.ShowDialog();
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