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
    public partial class SearchAccountForm : Form
    {
        string connection;
        Repository rep;
        SBSchoolDBEntities db;
        static int index;
        List<Field> AccountFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<Account> _Accounts;
        //delegate
        public delegate void AccountSelectHandler(object sender, AccountSelectEventArgs e);
        //event
        public event AccountSelectHandler OnAccountListSelected;


        public SearchAccountForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count > 0)
            {
                try
                {
                    Account selectedAccount = (Account)bindingSourceAccounts.Current;
                    OnAccountListSelected(this, new AccountSelectEventArgs(selectedAccount));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void SearchAccountForm_Load(object sender, EventArgs e)
        {
            try
            {

                AccountFields.Add(new Field("accountid", "string"));
                AccountFields.Add(new Field("accountname", "string"));
                AccountFields.Add(new Field("accountno", "string"));
                AccountFields.Add(new Field("customerid", "string"));

                cbField.DataSource = AccountFields;
                cbField.DisplayMember = "Name";
                cbField.ValueMember = "Name";

                cbOperator.DataSource = Op.GetList();
                cbOperator.DisplayMember = "Description";
                cbOperator.ValueMember = "Symbol";

                lstCriteria.DataSource = criteriaBuilder.CriterionItemList();

                var _AccountTypesquery = from dc in db.AccountTypes
                                         select dc;
                List<AccountType> _AccountTypes = _AccountTypesquery.ToList();
                DataGridViewComboBoxColumn colAccountType = new DataGridViewComboBoxColumn();
                colAccountType.HeaderText = "Account Type";
                colAccountType.Name = "cbAccountType";
                colAccountType.DataSource = _AccountTypes;
                colAccountType.DisplayMember = "Description";
                colAccountType.DataPropertyName = "AccountTypeId";
                colAccountType.ValueMember = "Id";
                colAccountType.MaxDropDownItems = 10;
                colAccountType.DisplayIndex = 3;
                colAccountType.MinimumWidth = 5;
                colAccountType.Width = 100;
                colAccountType.FlatStyle = FlatStyle.Flat;
                colAccountType.DefaultCellStyle.NullValue = "--- Select ---";
                colAccountType.ReadOnly = true;
                if (!this.dataGridViewAccounts.Columns.Contains("cbAccountType"))
                {
                    dataGridViewAccounts.Columns.Add(colAccountType);
                }

                var _COAsquery = from coa in db.COAs
                                 select coa;
                List<COA> _COAs = _COAsquery.ToList();
                DataGridViewComboBoxColumn colCOA = new DataGridViewComboBoxColumn();
                colCOA.HeaderText = "Chart of Account";
                colCOA.Name = "cbCOA";
                colCOA.DataSource = _COAs;
                colCOA.DisplayMember = "Description";
                colCOA.DataPropertyName = "COAId";
                colCOA.ValueMember = "Id";
                colCOA.MaxDropDownItems = 10;
                colCOA.DisplayIndex = 4;
                colCOA.MinimumWidth = 5;
                colCOA.Width = 100;
                colCOA.FlatStyle = FlatStyle.Flat;
                colCOA.DefaultCellStyle.NullValue = "--- Select ---";
                colCOA.ReadOnly = true;
                if (!this.dataGridViewAccounts.Columns.Contains("cbCOA"))
                {
                    dataGridViewAccounts.Columns.Add(colCOA);
                }

                var _Customersquery = from dc in db.Customers
                                      select dc;
                List<Customer> _Customers = _Customersquery.ToList();
                DataGridViewComboBoxColumn colCustomer = new DataGridViewComboBoxColumn();
                colCustomer.HeaderText = "Customer";
                colCustomer.Name = "cbCustomer";
                colCustomer.DataSource = _Customers;
                colCustomer.DisplayMember = "CustomerName";
                colCustomer.DataPropertyName = "CustomerId";
                colCustomer.ValueMember = "Id";
                colCustomer.MaxDropDownItems = 10;
                colCustomer.DisplayIndex = 5;
                colCustomer.MinimumWidth = 5;
                colCustomer.Width = 150;
                colCustomer.FlatStyle = FlatStyle.Flat;
                colCustomer.DefaultCellStyle.NullValue = "--- Select ---";
                colCustomer.ReadOnly = true;
                if (!this.dataGridViewAccounts.Columns.Contains("cbCustomer"))
                {
                    dataGridViewAccounts.Columns.Add(colCustomer);
                }

                dataGridViewAccounts.AutoGenerateColumns = false;
                this.dataGridViewAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewAccounts.DataSource = bindingSourceAccounts;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValue.Text))
            {
                CriterionItem cr = GetValidCriterionItem();
                if (cr != null)
                {
                    criteriaBuilder.AddCriterionItem(cr);
                    index++;
                }

                //refresh
                ListBoxRefresh();
            }
        }
        public void ListBoxRefresh()
        {
            lstCriteria.DataSource = null;
            lstCriteria.DataSource = criteriaBuilder.CriterionItemList();
        }
        private CriterionItem GetValidCriterionItem()
        {

            Field field = (Field)cbField.SelectedItem;
            Op Op = (Op)cbOperator.SelectedItem;
            string FValue = txtValue.Text;
            conjuction cj;
            string FieldType = field.Type;
            if (criteriaBuilder.IsFirstItem())
            {
                cj = conjuction.nil;
            }
            else
            {
                if (rbAnd.Checked)
                {
                    cj = conjuction.and;
                }
                else cj = conjuction.or;
            }
            switch (FieldType.ToLower())
            {
                case "string":
                    FValue = string.Format("{0}", FValue);
                    break;
                case "decimal":
                    decimal d;
                    if (!decimal.TryParse(FValue, out d))
                    {
                        lblMessage.Text = "Please enter a number in the field value";
                        return null;
                    }
                    break;
                case "date":
                    DateTime dd;
                    if (!DateTime.TryParse(FValue, out dd))
                    {
                        lblMessage.Text = "Please enter a date in the field value";
                        return null;
                    }
                    FValue = string.Format("{0}", FValue); //do a date format
                    break;
                case "like":
                    FValue = string.Format("{0}", FValue);
                    break;
            }
            //clean. no error
            Criterion cr = new Criterion(cj, field.Name, Op, FValue);
            return new CriterionItem("index" + index, cr);

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstCriteria.SelectedItem != null)
            {
                CriterionItem selCriterionItem = (CriterionItem)lstCriteria.SelectedValue;
                criteriaBuilder.Remove(selCriterionItem);

                //refresh
                ListBoxRefresh();
            }
        }
        private void btnRetrieve_Click(object sender, EventArgs e)
        {

            try
            {
                //get search results
                _Accounts = rep.GetAccountsFromCriteria(criteriaBuilder.CriterionItemList());
                bindingSourceAccounts.DataSource = _Accounts;
                groupBoxResults.Text = bindingSourceAccounts.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count > 0)
            {
                try
                {
                    Account selectedAccount = (Account)bindingSourceAccounts.Current;
                    OnAccountListSelected(this, new AccountSelectEventArgs(selectedAccount));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void dataGridViewAccounts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
            }
            catch (Exception ex)
            {
                Log.Write_To_Log_File_temp_dir(ex);
            }
        }

    }



    public class AccountSelectEventArgs : System.EventArgs
    {

        // add local member variables to hold text        
        private Account _account;

        // class constructor
        public AccountSelectEventArgs(Account account)
        {

            this._account = account;
        }

        // Properties - Viewable by each listener         
        public Account _Account
        {
            get
            {
                return _account;
            }
        }
    }

}
