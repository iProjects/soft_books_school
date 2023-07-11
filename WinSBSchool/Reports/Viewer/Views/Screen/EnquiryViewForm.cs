using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using GL.DAL;
using WinSchool.Forms;
using WinSchool.Reports.ViewModelBuilders;
using WinSchool.Reports.ViewModels;


namespace WinSchool.Reports.Views.Screen
{
    public partial class EnquiryViewForm : Form
    {

        List<Account> _accountsList;

        public EnquiryViewForm()
        {
            InitializeComponent();
        }

        private void btnSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(cboAccountNumber.Text))
                    {
                        MessageBox.Show("Account number cannot be null");
                        return;
                    }

                    int accid = int.Parse(cboAccountNumber.Text);


                    StatementViewModelBuilder svmBuilder =
                        new StatementViewModelBuilder(accid, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value);

                    StatementViewModel svmodel = svmBuilder.BuildStatementViewModel();
                    bindingSourceTransactions.DataSource = svmodel.StatementTransactions;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnSearchAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SearchAccountForm saf = new SearchAccountForm() { Owner = this };
                saf.OnAccountListSelected += new SearchAccountForm.AccountSelectHandler(saf_OnAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }

        private void saf_OnAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetAccountNos(e.AccountsList);
        }
        private void SetAccountNos(List<Account> Accountnos)
        {
            if (Accountnos != null)
            {
                _accountsList = Accountnos;
                bindingSourceAccountnos.DataSource = _accountsList;
            }

        }
        private void EnquiryViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewTransactions.AutoGenerateColumns = false;
                dataGridViewTransactions.DataSource = bindingSourceTransactions;

                DateTime v = DateTime.Today;

                cboAccountNumber.DataSource = bindingSourceAccountnos;
                cboAccountNumber.ValueMember = "AccountID";
                cboAccountNumber.DisplayMember = "AccountID";

                this.dateTimePickerEndDate.Value = DateTime.Today;
                this.dateTimePickerStartDate.Value = DateTime.Today.AddMonths(-1);
 

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
 

    }
}