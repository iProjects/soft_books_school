using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class UserRolesForm : Form
    {
        Repository rep;
        string connection;
        SBSchoolDBEntities db;

        public UserRolesForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
        }
        public void RefreshGrid()
        {
            try
            {
                bindingSourceRoles.DataSource = null;
                var roles = from rls in db.spRoles
                            select rls;
                bindingSourceRoles.DataSource = roles.ToList();
                groupBox2.Text = bindingSourceRoles.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                {
                    dataGridViewRoles.Rows[dataGridViewRoles.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewRoles.Rows.Count - 1;
                    bindingSourceRoles.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Forms.AddUserRolesForm ur = new Forms.AddUserRolesForm(connection) { Owner = this };
                ur.ShowDialog();
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

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewRoles.SelectedRows.Count != 0)
                {
                    DAL.spRole userrole = (DAL.spRole)bindingSourceRoles.Current;
                    Forms.EditUserRolesForm es = new Forms.EditUserRolesForm(userrole, connection) { Owner = this };
                    es.Text = userrole.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void UserRolesForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                var roles = from rls in db.spRoles
                            select rls;
                bindingSourceRoles.DataSource = roles.ToList();
                dataGridViewRoles.AutoGenerateColumns = false;
                dataGridViewRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewRoles.DataSource = bindingSourceRoles;
                groupBox2.Text = bindingSourceRoles.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count != 0)
            {
                try
                {

                    spRole userrole = (spRole)bindingSourceRoles.Current;

                    var transactionAuthorizationsquery = from ta in db.TransactionsAuthorizations
                                                         where ta.UserRoleId == userrole.Id
                                                         select ta;
                    List<TransactionsAuthorization> TransactionsAuthorizations = transactionAuthorizationsquery.ToList();

                    var _userolesquery = from us in db.spUsers
                                         where us.RoleId == userrole.Id
                                         select us;
                    List<spUser> _Users = _userolesquery.ToList();

                    var _AllowedRoleMenusquery = from us in db.spAllowedRoleMenus
                                                 where us.RoleId == userrole.Id
                                                 select us;
                    List<spAllowedRoleMenu> _AllowedRoleMenus = _AllowedRoleMenusquery.ToList();

                    var _AllowedReportsRolesMenusquery = from us in db.spAllowedReportsRolesMenus
                                                         where us.RoleId == userrole.Id
                                                         select us;
                    List<spAllowedReportsRolesMenu> _AllowedReportsRolesMenus = _AllowedReportsRolesMenusquery.ToList();

                    if (TransactionsAuthorizations.Count > 0)
                    {
                        MessageBox.Show("There is a Transactions Authorizations Associated with this Role.\n Delete the Transactions Authorizations First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (_Users.Count > 0)
                    {
                        MessageBox.Show("There is a User Associated with this Role.\n Delete the User First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (_AllowedRoleMenus.Count > 0)
                    {
                        MessageBox.Show("There is a Menu Right Associated with this Role.\n Delete the Menu Right First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (_AllowedReportsRolesMenus.Count > 0)
                    {
                        MessageBox.Show("There is a Report Menu Right Associated with this Role.\n Delete the Report Menu Right First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Role\n" + userrole.Description.ToUpper().ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteRole(userrole);
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

        private void dgvUserRoles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewRoles.SelectedRows.Count != 0)
                {
                    DAL.spRole userrole = (DAL.spRole)bindingSourceRoles.Current;
                    Forms.EditUserRolesForm es = new Forms.EditUserRolesForm(userrole, connection) { Owner = this };
                    es.Text = userrole.Description.ToUpper().Trim();
                    es.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dgvUserRoles_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
