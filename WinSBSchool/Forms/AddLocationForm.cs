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
    public partial class AddLocationForm : Form
    {
        string connection;
        SBSchoolDBEntities db;
        int _ParentId = -1;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public AddLocationForm(int _parentId, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
             
            _ParentId = _parentId; 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (IsLocationValid())
            {
                try
                {
                    Location loc = new Location();
                    loc.Parent = _ParentId;
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        loc.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }
                    decimal _transportcost;
                    if (!string.IsNullOrEmpty(txtTransportCost.Text) && decimal.TryParse(txtTransportCost.Text, out _transportcost))
                    {
                        loc.TransportCost = decimal.Parse(txtTransportCost.Text);
                    }
                    decimal _boardingcost;
                    if (!string.IsNullOrEmpty(txtBoardingCost.Text) && decimal.TryParse(txtBoardingCost.Text, out _boardingcost))
                    {
                        loc.BoardingCost = decimal.Parse(txtBoardingCost.Text);
                    }
                    loc.IsDeleted = false;

                    if (db.Locations.Any(i => i.Description == loc.Description && i.Parent == loc.Parent))
                    {
                        MessageBox.Show("Location with Description " + loc.Description + " Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Locations.Any(i => i.Description == loc.Description && i.Parent == loc.Parent))
                    {
                        db.Locations.AddObject(loc);
                        db.SaveChanges();

                        LocationsForm f = (LocationsForm)this.Owner;
                        f.BuildTree();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsLocationValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
             
            return noerror;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTransportCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtTransportCost_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBoardingCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtBoardingCost_KeyDown(object sender, KeyEventArgs e)
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
