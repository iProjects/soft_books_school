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
    public partial class EnquiryForm : Form
    {
        Repository rep;
        Account _Account;
        BindingList<Transaction> observableTransactions;
        string connection;

        public EnquiryForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);

            observableTransactions = new BindingList<Transaction>();

            bindingSourceTransactions.DataSource = observableTransactions;
            dataGridViewTransactions.AutoGenerateColumns = false;
            dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTransactions.DataSource = bindingSourceTransactions;
        }
        public EnquiryForm(string Conn, Account acc)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);

            if (acc == null)
                throw new ArgumentNullException("Account");
            _Account = acc;


            observableTransactions = new BindingList<Transaction>();

            bindingSourceTransactions.DataSource = observableTransactions;
            dataGridViewTransactions.AutoGenerateColumns = false;
            dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTransactions.DataSource = bindingSourceTransactions;
        }

        private void btnSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //bindingSourceTransactions.DataSource = null;
                DateTime startdate = dateTimePickerStartDate.Value;
                DateTime enddate = dateTimePickerEndDate.Value;
                int account;
                //= Convert.ToInt32(txtAccountNo.Text)
                if (int.TryParse(Convert.ToString(cboAccountNumber.SelectedValue), out account))
                {
                    //dataGridView1.DataSource = rep.GetTransactions(account, startdate, enddate);  
                    List<Transaction> transactions = rep.GetTransactions(account, startdate, enddate);
                    bindingSourceTransactions.DataSource = transactions;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnSearchAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SearchAccountForm saf = new SearchAccountForm(connection);
                saf.ShowDialog();
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
        private void EnquiryForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Student> students = rep.GetAllStudents();
                this.cboAdmissionNumber.DataSource = students;
                this.cboAdmissionNumber.DisplayMember = "AdminNo";
                this.cboAdmissionNumber.ValueMember = "Id";
                this.cboAdmissionNumber.SelectedIndex = -1;
                //Autocomplete for cboAdmissionNumber
                string[] strstudents = students.Select(san => san.AdminNo).ToArray();
                AutoCompleteStringCollection sanacsc = new AutoCompleteStringCollection();
                sanacsc.AddRange(strstudents);
                this.cboAdmissionNumber.AutoCompleteCustomSource = sanacsc;

                List<Account> accounts = rep.GetAllAccounts();
                this.cboAccountNumber.DataSource = accounts;
                this.cboAccountNumber.DisplayMember = "AccountNo";
                this.cboAccountNumber.ValueMember = "AccountID";
                this.cboAccountNumber.SelectedIndex = -1;
                //Autocomplete for cboAccountNumber
                string[] straccounts = accounts.Select(acn => acn.AccountNo.ToString()).ToArray();
                AutoCompleteStringCollection anacsc = new AutoCompleteStringCollection();
                anacsc.AddRange(straccounts);
                this.cboAccountNumber.AutoCompleteCustomSource = anacsc;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }






    }
}