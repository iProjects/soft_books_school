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
    public partial class TransactionsForm : Form
    {
        Repository rep;
        string user;
        string connection;
        public TransactionsForm(string s, string  Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            user = s;
        }

        private void TransactionsForm_Load(object sender, EventArgs e)
        {
            try
            {
            dataGridViewTransactions.AutoGenerateColumns = false;
            dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bindingSourceTransactions.DataSource = rep.GetAllTransactions();
            dataGridViewTransactions.DataSource = bindingSourceTransactions;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnSingleEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingSingleEntryForm asf = new Forms.PostingSingleEntryForm(user, connection) { Owner = this };
            asf.ShowDialog();
        }

        private void btnDoubleEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingDoubleEntryForm asf = new Forms.PostingDoubleEntryForm(user, connection) { Owner = this };
            asf.ShowDialog();
        }

        private void btnMuiltiEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingMuiltiEntryForm asf = new Forms.PostingMuiltiEntryForm(user, connection) { Owner = this };
            asf.ShowDialog();
        }


        public void RefreshGrid()
        {
            try
            {
            //set the datasource to null
            bindingSourceTransactions.DataSource = null;
            //set the datasource to a method
            bindingSourceTransactions.DataSource = rep.GetAllTransactions();
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
    }
}
