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
    public partial class SearchCustomerForm : Form
    {
        string connection;
        Repository rep;
        static int index;
        List<Field> CustomerFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<Customer> _Customers;
        //delegate
        public delegate void CustomerSelectHandler(object sender, CustomerSelectEventArgs e);
        //event
        public event CustomerSelectHandler OnCustomerListSelected;


        public SearchCustomerForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                try
                {

                    Customer selectedCustomer = (Customer)bindingSourceCustomers.Current;
                    OnCustomerListSelected(this, new CustomerSelectEventArgs(selectedCustomer));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void SearchCustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                CustomerFields.Add(new Field("id", "string"));
                CustomerFields.Add(new Field("name", "string"));
                CustomerFields.Add(new Field("no", "string"));
                CustomerFields.Add(new Field("phone", "string"));
                CustomerFields.Add(new Field("email", "string"));

                cbField.DataSource = CustomerFields;
                cbField.DisplayMember = "Name";
                cbField.ValueMember = "Name";

                cbOperator.DataSource = Op.GetList();
                cbOperator.DisplayMember = "Description";
                cbOperator.ValueMember = "Symbol";

                dataGridViewCustomers.AutoGenerateColumns = false;
                this.dataGridViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewCustomers.DataSource = bindingSourceCustomers;
                lstCriteria.DataSource = criteriaBuilder.CriterionItemList();
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
            try
            {
                _Customers = rep.GetCustomersFromCriteria(criteriaBuilder.CriterionItemList());
                bindingSourceCustomers.DataSource = _Customers;
                groupBoxResults.Text = _Customers.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                try
                {
                    Customer selectedCustomer = (Customer)bindingSourceCustomers.Current;
                    OnCustomerListSelected(this, new CustomerSelectEventArgs(selectedCustomer));

                    this.Close();                    
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void dataGridViewCustomers_DataError(object sender, DataGridViewDataErrorEventArgs e)
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



    public class CustomerSelectEventArgs : System.EventArgs
    {

        // add local member variables to hold text
        private Customer _customers;

        // class constructor
        public CustomerSelectEventArgs(Customer customer)
        {

            this._customers = customer;
        }

        // Properties - Viewable by each listener
        public Customer _Customer
        {
            get
            {
                return _customers;
            }
        }
    }


}