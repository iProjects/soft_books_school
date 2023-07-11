﻿using System;
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
    public partial class UsersForm : Form
    {
        Repository rep;
        string connection;
        SBSchoolDBEntities db;

        public UsersForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void Users_Load(object sender, EventArgs e)
        {
            try
            {

                var _rolesquery = from rls in db.spRoles
                                  select rls;
                List<spRole> _UserRoles = _rolesquery.ToList();
                DataGridViewComboBoxColumn colUserRole = new DataGridViewComboBoxColumn();
                colUserRole.HeaderText = "Role";
                colUserRole.Name = "cbUserRole";
                colUserRole.DataSource = _UserRoles;
                colUserRole.DisplayMember = "Description";
                colUserRole.DataPropertyName = "RoleId";
                colUserRole.ValueMember = "Id";
                colUserRole.MaxDropDownItems = 10;
                colUserRole.DisplayIndex = 2;
                colUserRole.MinimumWidth = 6;
                colUserRole.Width = 200;
                colUserRole.FlatStyle = FlatStyle.Flat;
                colUserRole.DefaultCellStyle.NullValue = "--- Select ---";
                colUserRole.ReadOnly = true; 
                if (!this.dataGridViewUsers.Columns.Contains("cbUserRole"))
                {
                    dataGridViewUsers.Columns.Add(colUserRole);
                }

                dataGridViewUsers.AutoGenerateColumns = false;
                this.dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                var _usersquery = from us in db.spUsers
                                  select us;
                bindingSourceUsers.DataSource = _usersquery.ToList();
                dataGridViewUsers.DataSource = bindingSourceUsers;
                groupBox2.Text = bindingSourceUsers.Count.ToString();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourceUsers.DataSource = null;
                //set the datasource to a method
                var _usersquery = from us in db.spUsers
                                  select us;
                bindingSourceUsers.DataSource = _usersquery.ToList();
                groupBox2.Text = bindingSourceUsers.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewUsers.Rows)
                {
                    dataGridViewUsers.Rows[dataGridViewUsers.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewUsers.Rows.Count - 1;
                    bindingSourceUsers.Position = nRowIndex;
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
                Forms.AddUserForm au = new Forms.AddUserForm(connection) { Owner = this };
                au.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count != 0)
            {
                try
                {
                    spUser user = (spUser)bindingSourceUsers.Current;
                    Forms.EditUserForm f = new Forms.EditUserForm(user, connection) { Owner = this };
                    f.Text = user.UserName.ToString().Trim().ToUpper();
                    f.ShowDialog();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void dataGridviewUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count != 0)
            {
                try
                {
                    spUser user = (spUser)bindingSourceUsers.Current;
                    Forms.EditUserForm f = new Forms.EditUserForm(user, connection) { Owner = this };
                    f.Text = user.UserName.ToString().Trim().ToUpper();
                    f.ShowDialog();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void dataGridviewUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count != 0)
            {
                try
                {
                    spUser user = (spUser)bindingSourceUsers.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete User\n" + user.UserName.ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        db.spUsers.DeleteObject(user);
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


    }
}
