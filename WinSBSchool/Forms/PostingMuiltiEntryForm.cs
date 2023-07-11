using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class PostingMuiltiEntryForm : Form
    {
        //create an observable collection
        BindingList<Transaction> observableTransactions;
        Repository rep;
        SBSchoolDBEntities db;
        string user;
        string connection;


        public PostingMuiltiEntryForm(string s, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
            user = s;
            observableTransactions = new BindingList<Transaction>();

        }

        private void PostingMuiltiEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                List<TransactionType> transactiontypes = rep.GetAllTransactionTypes();
                cboTransactionType.DataSource = transactiontypes;
                cboTransactionType.ValueMember = "TransactionTypeID";
                cboTransactionType.DisplayMember = "Description";

                bindingSourceTransactions.DataSource = observableTransactions;
                dataGridViewTransactions.AutoGenerateColumns = false;
                dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewTransactions.DataSource = bindingSourceTransactions;

                var _TransactionTypesquery = from dc in db.TransactionTypes
                                         select dc;
                List<TransactionType> _TransactionTypes = _TransactionTypesquery.ToList();

                DataGridViewComboBoxColumn colTransactionType = new DataGridViewComboBoxColumn();
                colTransactionType.HeaderText = "Transaction Type";
                colTransactionType.Name = "cbTransactionType";
                colTransactionType.DataSource = _TransactionTypes;
                colTransactionType.DisplayMember = "Description";
                colTransactionType.DataPropertyName = "TransactionTypeId";
                colTransactionType.ValueMember = "TransactionTypeID";
                colTransactionType.MaxDropDownItems = 10;
                colTransactionType.DisplayIndex = 0;
                colTransactionType.MinimumWidth = 5;
                colTransactionType.Width = 100;
                colTransactionType.FlatStyle = FlatStyle.Flat;
                colTransactionType.DefaultCellStyle.NullValue = "--- Select ---";
                colTransactionType.ReadOnly = true;

                if (!this.dataGridViewTransactions.Columns.Contains("cbTransactionType"))
                {
                    dataGridViewTransactions.Columns.Add(colTransactionType);
                }

                var _Accountsquery = from dc in db.Accounts
                                             select dc;
                List<Account> _Accounts = _Accountsquery.ToList();

                DataGridViewComboBoxColumn colAccount = new DataGridViewComboBoxColumn();
                colAccount.HeaderText = "Account";
                colAccount.Name = "cbAccount";
                colAccount.DataSource = _Accounts;
                colAccount.DisplayMember = "AccountName";
                colAccount.DataPropertyName = "AccountID";
                colAccount.ValueMember = "AccountID";
                colAccount.MaxDropDownItems = 10;
                colAccount.DisplayIndex = 1;
                colAccount.MinimumWidth = 5;
                colAccount.Width = 100;
                colAccount.ReadOnly = true;
                colAccount.FlatStyle = FlatStyle.Flat;
                colAccount.DefaultCellStyle.NullValue = "--- Select ---";
                if (!this.dataGridViewTransactions.Columns.Contains("cbAccount"))
                {
                    dataGridViewTransactions.Columns.Add(colAccount);
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool IsTransactionValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtAccountID.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAccountID, "Account id cannot be null!");
                return false;
            }
            int accountid;
            if (!int.TryParse(txtAccountID.Text,out accountid))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAccountID, "Account id must be integer!");
                return false;
            }
            if (cboTransactionType.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboTransactionType, "Select Transaction Type!");
                return false;
            } 
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmount, "Amount cannot be null!");
                return false;
            }
            decimal amt;
            if (!decimal.TryParse(txtAmount.Text, out amt))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmount, "Amount must be decimal!");
                return false;
            }
            if (string.IsNullOrEmpty(txtNarrative.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNarrative, "Narrative cannot be null!");
                return false;
            }
            return noerror;

        }

        private void btnPostTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rep.PostTransactions(observableTransactions.ToList());
                MessageBox.Show("Post Successful!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
        private void btnAddTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsTransactionValid())
            {
                try
                {
                    string RawSalt = DateTime.Now.ToString("yMdHms");
                    string HashSalt = HashHelper.CreateRandomSalt();
                    int foundS1 = HashSalt.IndexOf("==");
                    int foundS2 = HashSalt.IndexOf("+");
                    int foundS3 = HashSalt.IndexOf("/");
                    if (foundS1 > 0)
                    {
                        HashSalt = HashSalt.Remove(foundS1);
                    }
                    if (foundS2 > 0)
                    {
                        HashSalt = HashSalt.Remove(foundS2);
                    }
                    if (foundS3 > 0)
                    {
                        HashSalt = HashSalt.Remove(foundS3);
                    }
                    string SaltedHash = RawSalt.Insert(5, HashSalt);
                    string _transRef = SaltedHash; 

                    Transaction t = new Transaction();
                    int accountid;
                    if (!string.IsNullOrEmpty(txtAccountID.Text) && int.TryParse(txtAccountID.Text, out accountid))
                    {
                        t.AccountId = int.Parse(txtAccountID.Text);
                    }
                    if (cboTransactionType.SelectedIndex != -1)
                    {
                        t.TransactionTypeId = int.Parse(cboTransactionType.SelectedValue.ToString());
                    } 
                    decimal amount;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && decimal.TryParse(txtAmount.Text, out amount))
                    {
                        t.Amount = decimal.Parse(txtAmount.Text);
                    }
                    t.PostDate = dpPostDate.Value;
                    t.RecordDate = dpPostDate.Value;
                    t.ValueDate = dpValueDate.Value;
                    if (!string.IsNullOrEmpty(txtNarrative.Text))
                    {
                        t.Narrative = txtNarrative.Text;
                    }
                    if (!string.IsNullOrEmpty(user))
                    {
                        t.UserName = user;
                    }
                    t.Authorizer = "SYSTEM";
                    t.StatementFlag = "VALID";
                    t.TransRef = _transRef;

                    observableTransactions.Add(t);

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count != 0)
            {
                try
                {
                    Transaction t = (Transaction)bindingSourceTransactions.Current;

                    observableTransactions.Remove(t);
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void RefreshGrid()
        {
            //set the datasource to null
            bindingSourceTransactions.DataSource = null;
            //set the datasource to a method
            bindingSourceTransactions.DataSource = observableTransactions;

        }

        private void btnSearchbyAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountForm saf = new Forms.SearchAccountForm(connection) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountForm.AccountSelectHandler(saf_OnAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetAccountNos(e._Account);
        }
        private void SetAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                txtAccountID.Text = _Account.Id.ToString();
            }

        }


    }
}
