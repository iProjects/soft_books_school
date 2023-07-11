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
    public partial class PostingDoubleEntryForm : Form
    {
        //create an observable collection
        List<Transaction> observableTransactions;
        Repository rep;
        SBSchoolDBEntities db;
        string connection; 
        string user; 

        public PostingDoubleEntryForm(string s, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
            user = s;
            observableTransactions = new List<Transaction>();
        } 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PostingDoubleEntryForm_Load(object sender, EventArgs e)
        {
            try
            {

                List<TransactionType> transactiontypes = rep.GetAllTransactionTypes();
                cboTransactionType.DataSource = transactiontypes;
                cboTransactionType.ValueMember = "TransactionTypeID";
                cboTransactionType.DisplayMember = "Description";
                 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        public bool IsTransactionValid()
        {
            bool noerror = true;

            if (cboTransactionType.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboTransactionType, "Select Transaction Type!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCAccountId.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCAccountId, "Credit Account id cannot be null!");
                return false;
            }
            int Caccountid;
            if (!int.TryParse(txtCAccountId.Text, out Caccountid))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCAccountId, "Credit Account id must be integer!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDAccountId.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDAccountId, "Debit Account id cannot be null!");
                return false;
            }
            int Daccountid;
            if (!int.TryParse(txtDAccountId.Text, out Daccountid))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDAccountId, "Debit Account id must be integer!");
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
            if (string.IsNullOrEmpty(txtDrNarrative.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDrNarrative, "Debit Narrative cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCrNarrative.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCrNarrative, "Credit Narrative cannot be null!");
                return false;
            }
            return noerror;

        }  
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        } 
        private void btnPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider1.Clear();

                if (IsTransactionValid())
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

                    //Credit transaction
                    Transaction ct = new Transaction();
                    if (cboTransactionType.SelectedIndex != -1)
                    {
                        ct.TransactionTypeId = int.Parse(cboTransactionType.SelectedValue.ToString());
                    }
                    int Caccountid;
                    if (!string.IsNullOrEmpty(txtCAccountId.Text) && int.TryParse(txtCAccountId.Text, out Caccountid))
                    {
                        ct.Id = int.Parse(txtCAccountId.Text);
                    } 
                    decimal _amount;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && decimal.TryParse(txtAmount.Text, out _amount))
                    {
                        ct.Amount = decimal.Parse(txtAmount.Text);
                    }
                    ct.PostDate = dpPostDate.Value;
                    ct.RecordDate = dpPostDate.Value;
                    ct.ValueDate = dpValueDate.Value;
                    if (!string.IsNullOrEmpty(txtCrNarrative.Text))
                    {
                        ct.Narrative = txtCrNarrative.Text;
                    }
                    if (!string.IsNullOrEmpty(user))
                    {
                        ct.UserName = user;
                    }
                    ct.Authorizer = "SYSTEM";
                    ct.StatementFlag = "VALID";
                    ct.TransRef = _transRef;

                    observableTransactions.Add(ct);

                    //Debit transaction
                    Transaction dt = new Transaction();
                    if (cboTransactionType.SelectedIndex != -1)
                    {
                        dt.TransactionTypeId = int.Parse(cboTransactionType.SelectedValue.ToString());
                    }
                    int Daccountid;
                    if (!string.IsNullOrEmpty(txtDAccountId.Text) && int.TryParse(txtCAccountId.Text, out Daccountid))
                    {
                        dt.AccountId= int.Parse(txtDAccountId.Text);
                    }
                    decimal amount;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && decimal.TryParse(txtAmount.Text, out amount))
                    {
                        dt.Amount = decimal.Parse(txtAmount.Text) * -1;
                    }
                    dt.PostDate = dpPostDate.Value;
                    dt.RecordDate = dpPostDate.Value;
                    dt.ValueDate = dpValueDate.Value;
                    if (!string.IsNullOrEmpty(txtDrNarrative.Text))
                    {
                        dt.Narrative = txtDrNarrative.Text;
                    }
                    if (!string.IsNullOrEmpty(user))
                    {
                        dt.UserName = user;
                    }
                    dt.Authorizer = "SYSTEM";
                    dt.StatementFlag = "VALID";
                    dt.TransRef = _transRef;

                    observableTransactions.Add(dt);

                    rep.PostTransactions(observableTransactions.ToList());

                    MessageBox.Show("Post Successfull!", "SB School");

                    if (this.Owner is TransactionsForm)
                    {
                        TransactionsForm f = (TransactionsForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    }
                     
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSearchCAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountForm saf = new Forms.SearchAccountForm(connection) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountForm.AccountSelectHandler(saf_OnCAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnCAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetCAccountNos(e._Account);
        }
        private void SetCAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                txtCAccountId.Text = _Account.Id.ToString();
            }

        }

        private void btnSearchbyDAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountForm saf = new Forms.SearchAccountForm(connection) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountForm.AccountSelectHandler(saf_OnDAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnDAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetDAccountNos(e._Account);
        }
        private void SetDAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                txtDAccountId.Text = _Account.Id.ToString();
            }

        }




    }
}
