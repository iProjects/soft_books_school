using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class EditResidenceForm : Form
    {
        string connection;
        SBSchoolDBEntities db;
        DAL.Residence _residence;
        Repository rep;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditResidenceForm(DAL.Residence residence, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
            _residence = residence;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsResidenceValid())
            {
                try
                {
                    if (cboParent.SelectedIndex != -1)
                    {
                        _residence.ParentId = int.Parse(cboParent.SelectedValue.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        _residence.Name = Utils.ConvertFirstLetterToUpper(txtName.Text.Trim());
                    }
                    decimal cost;
                    if (!string.IsNullOrEmpty(txtTitle.Text) && decimal.TryParse(txtCost.Text, out cost))
                    {
                        _residence.Cost = decimal.Parse(txtCost.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtGPSCordinates.Text))
                    {
                        _residence.GPSCordinates = txtGPSCordinates.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtTitle.Text))
                    {
                        _residence.Title = txtTitle.Text.Trim();
                    }

                    rep.UpdateResidence(_residence);

                    ResidenceForm f = (ResidenceForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsResidenceValid()
        {
            bool noerror = true;
            if (cboParent.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboParent, "Select Parent!");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCost, "Cost cannot be null!");
                return false;
            }
            decimal cost;
            if (!decimal.TryParse(txtCost.Text, out cost))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCost, "Cost must be decimal!");
                return false;
            }
            return noerror;
        }
        private void EditResidenceForm_Load(object sender, EventArgs e)
        {
            try
            {
            var prntsquery = from pt in db.Parents
                             select pt;
            List<Parent> Parents = prntsquery.ToList();
            cboParent.DataSource = Parents;
            cboParent.ValueMember = "ParentId";
            cboParent.DisplayMember = "Name";
            cboParent.SelectedIndex = -1;

            InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void InitializeControls()
        {
            if (_residence.ParentId != null)
            {
                cboParent.SelectedValue = _residence.ParentId;
            }
            if (_residence.Name != null)
            {
                txtName.Text = _residence.Name.Trim();
            }
            if (_residence.GPSCordinates != null)
            {
              txtGPSCordinates.Text  =  _residence.GPSCordinates.Trim();
            }
            if (_residence.Title != null)
            {
              txtTitle.Text  =  _residence.Title.Trim();
            }
            if (_residence.Cost != null)
            {
                txtCost.Text = _residence.Cost.ToString();
            }
        }
        private void txtCost_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }




    }
}
