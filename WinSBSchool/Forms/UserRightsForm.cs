﻿using System; 
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq; 
using System.Text; 
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class UserRightsForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        IQueryable<spAllowedRoleMenu> _AllowedRoleMenus;
        #endregion "Private Fields"

        #region "Constructor"
        public UserRightsForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewRights.SelectedRows.Count != 0)
            {
                try
                {
                    spAllowedRoleMenu _right = (spAllowedRoleMenu)bindingSourceRights.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Right", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.spAllowedRoleMenus.DeleteObject(_right);
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
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewRights.SelectedRows.Count != 0)
            {
                try
                {
                    spAllowedRoleMenu _right = (spAllowedRoleMenu)bindingSourceRights.Current;
                    EditUserRightsForm eus = new EditUserRightsForm(_right, connection) { Owner = this };
                    eus.Text = "Edit Right";
                    eus.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }

        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddUserRightsForm usf = new AddUserRightsForm(connection) { Owner = this };
                usf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void dataGridViewRights_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRights.SelectedRows.Count != 0)
            {
                try
                {
                    spAllowedRoleMenu _right = (spAllowedRoleMenu)bindingSourceRights.Current;
                    EditUserRightsForm eus = new EditUserRightsForm(_right, connection) { Owner = this };
                    eus.Text = "Edit Right";
                    eus.ShowDialog();
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
                bindingSourceRights.DataSource = null;
                var rightsquery = from rts in db.spAllowedRoleMenus
                                  select rts;
                bindingSourceRights.DataSource = rightsquery.ToList();
                groupBox1.Text = bindingSourceRights.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewRights.Rows)
                {
                    dataGridViewRights.Rows[dataGridViewRights.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewRights.Rows.Count - 1;
                    bindingSourceRights.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }


        private void UserRightsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _Rolesquery = from rl in db.spRoles
                                  select rl;
                List<spRole> _Roles = _Rolesquery.ToList();
                DataGridViewComboBoxColumn colCboxRole = new DataGridViewComboBoxColumn();
                colCboxRole.HeaderText = "Role";
                colCboxRole.Name = "cbRole";
                colCboxRole.DataSource = _Roles;
                // The display member is the name column in the column datasource  
                colCboxRole.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxRole.DataPropertyName = "RoleId";
                // The value member is the primary key of the parent table  
                colCboxRole.ValueMember = "Id";
                colCboxRole.MaxDropDownItems = 10;
                colCboxRole.Width = 100;
                colCboxRole.DisplayIndex = 1;
                colCboxRole.MinimumWidth = 5;
                colCboxRole.FlatStyle = FlatStyle.Flat;
                colCboxRole.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxRole.ReadOnly = true; 
                //colCboxRole.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewRights.Columns.Contains("cbRole"))
                {
                    dataGridViewRights.Columns.Add(colCboxRole);
                }

                var _menuItemsquery = from rl in db.spMenuItems
                                      select rl;
                List<spMenuItem> _MenuItems = _menuItemsquery.ToList();
                DataGridViewComboBoxColumn colCboxMenu = new DataGridViewComboBoxColumn();
                colCboxMenu.HeaderText = "Menu";
                colCboxMenu.Name = "cbMenu";
                colCboxMenu.DataSource = _MenuItems;
                // The display member is the name column in the column datasource  
                colCboxMenu.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxMenu.DataPropertyName = "MenuItemId";
                // The value member is the primary key of the parent table  
                colCboxMenu.ValueMember = "Id";
                colCboxMenu.MaxDropDownItems = 10;
                colCboxMenu.Width = 150;
                colCboxMenu.DisplayIndex = 2;
                colCboxMenu.MinimumWidth = 5;
                colCboxMenu.FlatStyle = FlatStyle.Flat;
                colCboxMenu.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxMenu.ReadOnly = true; 
                //colCboxRole.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewRights.Columns.Contains("cbMenu"))
                {
                    dataGridViewRights.Columns.Add(colCboxMenu);
                }

                var rightsquery = from rts in db.spAllowedRoleMenus
                                  select rts;
                bindingSourceRights.DataSource = rightsquery.ToList();
                dataGridViewRights.AutoGenerateColumns = false;
                dataGridViewRights.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewRights.DataSource = bindingSourceRights;
                groupBox1.Text = bindingSourceRights.Count.ToString();

                _AllowedRoleMenus = db.spAllowedRoleMenus;

                AutoCompleteStringCollection acsctrm = new AutoCompleteStringCollection();
                acsctrm.AddRange(this.AutoComplete_Roles());
                txtRole.AutoCompleteCustomSource = acsctrm;
                txtRole.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtRole.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscdsc = new AutoCompleteStringCollection();
                acscdsc.AddRange(this.AutoComplete_Menu());
                txtMenu.AutoCompleteCustomSource = acscdsc;
                txtMenu.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtMenu.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_Roles()
        {
            try
            {
                var rolesquery = from rl in db.spRoles
                                 where rl.IsDeleted == false
                                 select rl.Description;
                return rolesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Menu()
        {
            try
            {
                var menuquery = from mn in db.spMenuItems
                                select mn.Description;
                return menuquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }

        private void dataGridViewRights_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtRole_Validated(object sender, EventArgs e)
        {
            try
            {
                ApplyFilter();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtMenu_Validated(object sender, EventArgs e)
        {
            try
            {
                ApplyFilter();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        // apply the filter
        private void ApplyFilter()
        {
            try
            {
                var filter = CreateFilter(_AllowedRoleMenus);
                // set the filter
                this.bindingSourceRights.DataSource = filter;
                groupBox1.Text = bindingSourceRights.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<spAllowedRoleMenu> CreateFilter(IQueryable<spAllowedRoleMenu> _allowedMenu)
        {
            //none
            if (string.IsNullOrEmpty(txtRole.Text) && string.IsNullOrEmpty(txtMenu.Text))
            {
                return _allowedMenu;
            }
            //all
            if (!string.IsNullOrEmpty(txtRole.Text) && !string.IsNullOrEmpty(txtMenu.Text))
            {
                string _Role = txtRole.Text;
                string _Menu = txtMenu.Text;
                _allowedMenu = from st in db.spAllowedRoleMenus
                               join rl in db.spRoles on st.RoleId equals rl.Id
                               where rl.Description.StartsWith(_Role)
                               join mn in db.spMenuItems on st.MenuItemId equals mn.Id
                               where mn.Description.StartsWith(_Menu)
                               select st;
                return _allowedMenu;
            }
            //role
            if (!string.IsNullOrEmpty(txtRole.Text) && string.IsNullOrEmpty(txtMenu.Text))
            {
                _allowedMenu = null;
                string _Role = txtRole.Text;
                _allowedMenu = from st in db.spAllowedRoleMenus
                               join rl in db.spRoles on st.RoleId equals rl.Id
                               where rl.Description.StartsWith(_Role)
                               select st;
                return _allowedMenu;
            }
            //menu
            if (string.IsNullOrEmpty(txtRole.Text) && !string.IsNullOrEmpty(txtMenu.Text))
            {
                _allowedMenu = null;
                string _Menu = txtMenu.Text;
                _allowedMenu = from st in db.spAllowedRoleMenus
                               join mn in db.spMenuItems on st.MenuItemId equals mn.Id
                               where mn.Description.StartsWith(_Menu)
                               select st;
                return _allowedMenu;
            }
            return _allowedMenu;
        }
        private void btnReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ReportsRightsForm rrf = new ReportsRightsForm(connection);
                rrf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"



    }
}