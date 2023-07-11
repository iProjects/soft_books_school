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
    public partial class PostingSingleEntryForm : Form
    {
        Repository rep;
        string user;
        string connection;
        SBSchoolDBEntities db;

        public PostingSingleEntryForm(string s, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
            user = s;
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

                    Transaction t = new Transaction();
                    if (cboTransactionType.SelectedIndex != -1)
                    {
                        t.TransactionTypeId = int.Parse(cboTransactionType.SelectedValue.ToString());
                    }
                    int  accountid;
                    if (!string.IsNullOrEmpty(txtAccountId.Text) && int.TryParse(txtAccountId.Text, out  accountid))
                    {
                        t.AccountId = int.Parse(txtAccountId.Text);
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

                    rep.SaveTransaction(t);

                    MessageBox.Show("Post Successfull!");

                    this.Close();

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
            if (cboTransactionType.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboTransactionType, "Select Transaction Type!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAccountId.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAccountId, "Account Id cannot be null!");
                return false;
            }
            int accountid;
            if (!int.TryParse(txtAccountId.Text, out accountid))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAccountId, "Account id must be integer!");
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
        private void PostingSingleEntryForm_Load(object sender, EventArgs e)
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
                txtAccountId.Text = _Account.Id.ToString();
            }

        }


    } 
}
