using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace WinSBSchool.Forms
{
    public partial class TransactionsAuthorizationForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;

        public TransactionsAuthorizationForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsTransactionAuthorizationValid())
            {
                if (dgvUserRoles.SelectedRows.Count != 0)
                {
                    try
                    {
                        spRole ur = (spRole)bindingSourceRoles.Current;

                        TransactionsAuthorization ta = new TransactionsAuthorization();
                        ta.UserRoleId = ur.Id;
                        ta.TransactionTypeId = int.Parse(cboTransactionTypes.SelectedValue.ToString());
                        ta.IsDeleted = false;

                        if (!db.TransactionsAuthorizations.Any(i => i.UserRoleId == ta.UserRoleId && i.TransactionTypeId == ta.TransactionTypeId))
                        {
                            db.TransactionsAuthorizations.AddObject(ta);
                            db.SaveChanges();
                        }
                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
        }
        private bool IsTransactionAuthorizationValid()
        {
            bool noerror = true;
            if (cboTransactionTypes.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboTransactionTypes, "Select Transaction Type");
                return false;
            }
            return noerror;
        }
        private void RefreshGrid()
        {
            if (dgvUserRoles.SelectedRows.Count != 0)
            {
                try
                {
                    bindingSourceTransactionTypes.DataSource = null;
                    spRole ur = (spRole)bindingSourceRoles.Current;
                    var transactionAuthorizationsquery = from ta in db.TransactionsAuthorizations
                                                         where ta.UserRoleId == ur.Id
                                                         select ta;
                    List<TransactionsAuthorization> TransactionsAuthorizations = transactionAuthorizationsquery.ToList();
                    bindingSourceTransactionTypes.DataSource = TransactionsAuthorizations.ToList();
                    groupBox3.Text = bindingSourceTransactionTypes.Count.ToString();

                    List<TransactionType> _TransactionTypes = db.TransactionTypes.ToList();
                    DataGridViewComboBoxColumn colCboxTransactionType = new DataGridViewComboBoxColumn();
                    colCboxTransactionType.HeaderText = "Transaction Type";
                    colCboxTransactionType.Name = "cbTransactionType";
                    colCboxTransactionType.DataSource = _TransactionTypes;
                    // The display member is the name column in the column datasource  
                    colCboxTransactionType.DisplayMember = "Description";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxTransactionType.DataPropertyName = "TransactionTypeId";
                    // The value member is the primary key of the parent table  
                    colCboxTransactionType.ValueMember = "Id";
                    colCboxTransactionType.MaxDropDownItems = 10;
                    colCboxTransactionType.Width = 100;
                    colCboxTransactionType.DisplayIndex = 1;
                    colCboxTransactionType.MinimumWidth = 5;
                    colCboxTransactionType.FlatStyle = FlatStyle.Flat;
                    colCboxTransactionType.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxTransactionType.ReadOnly = true; 
                    colCboxTransactionType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
                    if (!this.dataGridViewTransactionTypes.Columns.Contains("cbTransactionType"))
                    {
                        dataGridViewTransactionTypes.Columns.Add(colCboxTransactionType);
                    }

                    dataGridViewTransactionTypes.AutoGenerateColumns = false;
                    this.dataGridViewTransactionTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                     
                    dataGridViewTransactionTypes.DataSource = bindingSourceTransactionTypes;
                    foreach (DataGridViewRow row in dataGridViewTransactionTypes.Rows)
                    {
                        dataGridViewTransactionTypes.Rows[dataGridViewTransactionTypes.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewTransactionTypes.Rows.Count - 1;
                        bindingSourceTransactionTypes.Position = nRowIndex;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTransactionTypes.SelectedRows.Count != 0)
            {
                try
                {
                    TransactionsAuthorization ta = (TransactionsAuthorization)bindingSourceTransactionTypes.Current;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Transaction Authorization\n" + ta.TransactionType.Description, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.TransactionsAuthorizations.DeleteObject(ta);
                        db.SaveChanges();
                        RefreshGrid();
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void TransactionsAuthorizationForm_Load(object sender, EventArgs e)
        {
            try
            {

                var TransactionTypesquery = from tt in db.TransactionTypes
                                    select tt;
                List<TransactionType> _TransactionTypes = TransactionTypesquery.ToList();
                cboTransactionTypes.DataSource = _TransactionTypes;
                cboTransactionTypes.ValueMember = "Id";
                cboTransactionTypes.DisplayMember = "Description";
                cboTransactionTypes.SelectedIndex = -1; 

                dgvUserRoles.AutoGenerateColumns = false;
                this.dgvUserRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                var roles = from rls in db.spRoles
                            select rls;
                bindingSourceRoles.DataSource = roles;
                dgvUserRoles.DataSource = bindingSourceRoles;
                groupBox5.Text = bindingSourceRoles.Count.ToString();

                RefreshGrid();
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

        private void dataGridViewRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dgvUserRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        






    }
}
