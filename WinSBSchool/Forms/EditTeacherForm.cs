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
    public partial class EditTeacherForm : Form
    {
        Repository rep;
        DAL.Teacher t;
        string connection;
        SBSchoolDBEntities db;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditTeacherForm(DAL.Teacher teacher, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            t = teacher;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsTeacherValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        t.Name = Utils.ConvertFirstLetterToUpper(txtName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtIDNo.Text))
                    {
                        t.IDNo = Utils.ConvertFirstLetterToUpper(txtIDNo.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtTSCNo.Text))
                    {
                        t.TSCNo = Utils.ConvertFirstLetterToUpper(txtTSCNo.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtPosition.Text))
                    {
                        t.Position = Utils.ConvertFirstLetterToUpper(txtPosition.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        t.Email = txtEmail.Text.ToLower().Trim();
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        t.Status = cboStatus.SelectedValue.ToString();
                    }
                    if (dtpDateJoined.Value != null)
                    {
                        t.DateJoined = dtpDateJoined.Value;
                    }
                    if (cboQualification.SelectedIndex != -1)
                    {
                        t.HighestQualification = cboQualification.SelectedValue.ToString();
                    }

                    rep.UpdateTeacher(t);

                    TeachersForm f = (TeachersForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsTeacherValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtIDNo.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtIDNo, "ID No cannot be null!");
                return false;
            }
            return noerror;
        }

        private void EditTeacherForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value"; 

                var qualifications = new BindingList<KeyValuePair<string, string>>();
                qualifications.Add(new KeyValuePair<string, string>("DI", "Diploma"));
                qualifications.Add(new KeyValuePair<string, string>("DE", "Degree"));
                qualifications.Add(new KeyValuePair<string, string>("MA", "Masters"));
                qualifications.Add(new KeyValuePair<string, string>("PH", "Doctor of Philosophy(Phd)"));
                cboQualification.DataSource = qualifications;
                cboQualification.ValueMember = "Key";
                cboQualification.DisplayMember = "Value";
                cboQualification.SelectedIndex = -1;

                groupBoxLeft.Visible = false;

                InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }


        private void InitializeControls()
        {

            try
            {
                if (t.Name != null)
                {
                    txtName.Text = t.Name.Trim();
                }
                if (t.IDNo != null)
                {
                    txtIDNo.Text = t.IDNo.Trim();
                }
                if (t.TSCNo != null)
                {
                    txtTSCNo.Text = t.TSCNo.Trim();
                }
                if (t.Position != null)
                {
                    txtPosition.Text = t.Position.Trim();
                }
                if (t.Email != null)
                {
                    txtEmail.Text = t.Email.Trim();
                }
                if (t.Status != null)
                {
                    cboStatus.SelectedValue = t.Status.Trim();
                }
                if (t.DateJoined != null)
                {
                    dtpDateJoined.Value = t.DateJoined ?? DateTime.Now;
                }
                if (t.IsLeft != null)
                {
                    chkLeft.Checked = t.IsLeft ?? false;
                }
                if (t.DateLeft != null)
                {
                    dtpDateLeft.Value = t.DateLeft ?? DateTime.Now;
                }
                if (t.HighestQualification != null)
                {
                    cboQualification.SelectedValue = t.HighestQualification;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        /*public method to diable all controls when form is called by parent from 'View Details' button*/
        public void DisableControls()
        {
            txtName.Enabled = false;
            txtIDNo.Enabled = false;
            txtTSCNo.Enabled = false;
            txtPosition.Enabled = false;
            txtEmail.Enabled = false;
            cboStatus.Enabled = false;
            dtpDateJoined.Enabled = false;
            dtpDateLeft.Enabled = false;
            chkLeft.Enabled = false;
            cboQualification.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;
        }

        private void chkLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLeft.Checked == true)
            {
                groupBoxLeft.Visible = true;
            }
            else
            {
                groupBoxLeft.Visible = false;
            }

        }
        private void txtIDNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtIDNo_KeyDown(object sender, KeyEventArgs e)
        {

            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }


    }
}
