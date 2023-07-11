using System; 
using System.Collections.Generic; 
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration; 
using System.Data;
using System.Data.OleDb; 
using System.Data.SqlClient; 
using System.Drawing;
using System.Linq; 
using System.Text; 
using System.Windows.Forms;
using CommonLib; 
using DAL;

namespace WinSBSchool.Forms
{
    public partial class CustomersForm : Form
    {
        SBSchoolDBEntities db;
        string _user;
        string connection;
        Repository rep;

        public CustomersForm(string user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            _user = user;
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddNewCustomerForm acf = new AddNewCustomerForm(connection) { Owner = this };
                acf.ShowDialog(); 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count != 0)
            {
                try
                {
                    Customer customer = (Customer)bindingSourceCustomers.Current;
                    Forms.EditCustomerForm esf = new Forms.EditCustomerForm(customer, connection) { Owner = this };
                    esf.Text = customer.CustomerNo + " - " + customer.CustomerName.ToUpper().Trim();
                    esf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count != 0)
            {
                try
                {

                    Customer customer = (Customer)bindingSourceCustomers.Current;

                    var _CstmrAccntsquery = from ac in db.Accounts
                                            where ac.IsDeleted == false
                                            where ac.Closed == false
                                            where ac.CustomerId == customer.Id
                                            select ac;
                    List<Account> _CustomerAccounts = _CstmrAccntsquery.ToList(); 

                    if (_CustomerAccounts.Count > 0)
                    {
                        MessageBox.Show("There is an Account  Associated with this Customer.\n Delete the Account First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Customer\n" + customer.CustomerName.ToUpper().ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteCustomer(customer);

                            RefreshGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void RefreshGrid()
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceCustomers.DataSource = null;
                    var cstmrs = from cs in db.Customers
                                 where cs.IsDeleted == false
                                 select cs;
                    List<Customer> customers = cstmrs.ToList();
                    bindingSourceCustomers.DataSource = customers;
                    groupBox1.Text = bindingSourceCustomers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewCustomers.Rows)
                    {
                        dataGridViewCustomers.Rows[dataGridViewCustomers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewCustomers.Rows.Count - 1;
                        bindingSourceCustomers.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceCustomers.DataSource = null;
                    var cstmrs = from cs in db.Customers
                                 where cs.IsDeleted == false
                                 where cs.Status == "A"
                                 select cs;
                    List<Customer> customers = cstmrs.ToList();
                    bindingSourceCustomers.DataSource = customers;
                    groupBox1.Text = bindingSourceCustomers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewCustomers.Rows)
                    {
                        dataGridViewCustomers.Rows[dataGridViewCustomers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewCustomers.Rows.Count - 1;
                        bindingSourceCustomers.Position = nRowIndex;
                    }
                }
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
        private void CustomersForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                DataGridViewComboBoxColumn colCboxStatus = new DataGridViewComboBoxColumn();
                colCboxStatus.HeaderText = "Status";
                colCboxStatus.Name = "cbStatus";
                colCboxStatus.DataSource = status;
                // The display member is the name column in the column datasource  
                colCboxStatus.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxStatus.DataPropertyName = "Status";
                // The value member is the primary key of the parent table  
                colCboxStatus.ValueMember = "Key";
                colCboxStatus.MaxDropDownItems = 10;
                colCboxStatus.Width = 80;
                colCboxStatus.DisplayIndex = 4;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true;
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewCustomers.Columns.Contains("cbStatus"))
                {
                    dataGridViewCustomers.Columns.Add(colCboxStatus);
                }
                
                var cstmrs = from cs in db.Customers
                             where cs.IsDeleted == false
                             where cs.Status == "A"
                             select cs;
                List<Customer> customers = cstmrs.ToList(); 
                bindingSourceCustomers.DataSource = customers;
                dataGridViewCustomers.AutoGenerateColumns = false;
                dataGridViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewCustomers.DataSource = bindingSourceCustomers;
                groupBox1.Text = bindingSourceCustomers.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count != 0)
            {
                try
                {
                    Customer customer = (Customer)bindingSourceCustomers.Current;
                    Forms.EditCustomerForm esf = new Forms.EditCustomerForm(customer, connection) { Owner = this };
                    esf.Text = customer.CustomerNo + " - " + customer.CustomerName.ToUpper().Trim();
                    esf.DisableControls();
                    esf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void dataGridViewCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count != 0)
            {
                try
                {
                    Customer customer = (Customer)bindingSourceCustomers.Current;
                    Forms.EditCustomerForm esf = new Forms.EditCustomerForm(customer, connection) { Owner = this };
                    esf.Text = customer.CustomerName.ToUpper().Trim();
                    esf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceCustomers.DataSource = null;
                    var cstmrs = from cs in db.Customers
                                 where cs.IsDeleted == false
                                 select cs;
                    List<Customer> customers = cstmrs.ToList();
                    bindingSourceCustomers.DataSource = customers;
                    groupBox1.Text = bindingSourceCustomers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewCustomers.Rows)
                    {
                        dataGridViewCustomers.Rows[dataGridViewCustomers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewCustomers.Rows.Count - 1;
                        bindingSourceCustomers.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceCustomers.DataSource = null;
                    var cstmrs = from cs in db.Customers
                                 where cs.IsDeleted == false
                                 where cs.Status=="A"
                                 select cs;
                    List<Customer> customers = cstmrs.ToList();
                    bindingSourceCustomers.DataSource = customers;
                    groupBox1.Text = bindingSourceCustomers.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewCustomers.Rows)
                    {
                        dataGridViewCustomers.Rows[dataGridViewCustomers.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewCustomers.Rows.Count - 1;
                        bindingSourceCustomers.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
}