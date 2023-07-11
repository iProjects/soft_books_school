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
    public partial class SearchStudentAccountsForm : Form
    {
        string connection;
        Repository rep;
        SBSchoolDBEntities db;
        static int index;
        List<Field> StudentFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<Account> _studentAccounts;
        //delegate
        public delegate void StudentAccountsSelectHandler(object sender, StudentAccountsSelectEventArgs e);
        //event
        public event StudentAccountsSelectHandler OnStudentAccountsListSelected;


        public SearchStudentAccountsForm(string Conn)
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
            if (dataGridViewStudentAccounts.SelectedRows.Count > 0)
            {
                try
                {

                    Account selectedStudent = (Account)bindingSourceStudentAccounts.Current;
                    OnStudentAccountsListSelected(this, new StudentAccountsSelectEventArgs(selectedStudent));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void SearchStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                StudentFields.Add(new Field("surname", "string"));
                StudentFields.Add(new Field("othernames", "string"));
                StudentFields.Add(new Field("customerno", "string"));

                cbField.DataSource = StudentFields;
                cbField.DisplayMember = "Name";
                cbField.ValueMember = "Name";

                cbOperator.DataSource = Op.GetList();
                cbOperator.DisplayMember = "Description";
                cbOperator.ValueMember = "Symbol";

                this.dataGridViewStudentAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridViewStudentAccounts.AutoGenerateColumns = false;
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
                if (!this.dataGridViewStudentAccounts.Columns.Contains("cbAccountType"))
                {
                    dataGridViewStudentAccounts.Columns.Add(colAccountType);
                }

                var _COAsquery = from coa in db.COAs
                                 select coa;
                List<COA> _COAs = _COAsquery.ToList();

                DataGridViewComboBoxColumn colCOA = new DataGridViewComboBoxColumn();
                colCOA.HeaderText = "COA";
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
                if (!this.dataGridViewStudentAccounts.Columns.Contains("cbCOA"))
                {
                    dataGridViewStudentAccounts.Columns.Add(colCOA);
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
                colCustomer.DisplayIndex = 2;
                colCustomer.MinimumWidth = 5;
                colCustomer.Width = 100;
                colCustomer.FlatStyle = FlatStyle.Flat;
                colCustomer.DefaultCellStyle.NullValue = "--- Select ---";
                colCustomer.ReadOnly = true; 
                if (!this.dataGridViewStudentAccounts.Columns.Contains("cbCustomer"))
                {
                    dataGridViewStudentAccounts.Columns.Add(colCustomer);
                }
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
        private void btnPreview_Click(object sender, EventArgs e)
        {
            _studentAccounts = rep.GetStudentAccountsFromCriteria(criteriaBuilder.CriterionItemList());
            bindingSourceStudentAccounts.DataSource = _studentAccounts;
            dataGridViewStudentAccounts.AutoGenerateColumns = false;
            this.dataGridViewStudentAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudentAccounts.DataSource = bindingSourceStudentAccounts;
            groupBoxResults.Text = _studentAccounts.Count.ToString();
        }

        private void dataGridViewStudentAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudentAccounts.SelectedRows.Count > 0)
            {
                try
                {

                    Account selectedStudent = (Account)bindingSourceStudentAccounts.Current;
                    OnStudentAccountsListSelected(this, new StudentAccountsSelectEventArgs(selectedStudent));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void dataGridViewStudentAccounts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {



            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }


    }

    public class StudentAccountsSelectEventArgs : System.EventArgs
    {
        // add local member variables to hold text 
        private Account _studentaccount;

        // class constructor
        public StudentAccountsSelectEventArgs(Account studentAccount)
        {

            this._studentaccount = studentAccount;
        }

        // Properties - Viewable by each listener 
        public Account _StudentAccount
        {
            get
            {
                return _studentaccount;
            }
        }
    }
}
        