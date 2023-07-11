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
    public partial class EditRoomForm : Form
    {

        Room _Room;
        SBSchoolDBEntities db;
        Repository rep;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditRoomForm(Room rm, string Conn)
        {
            InitializeComponent();
            _Room = rm;

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsRoomValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtShortCode.Text))
                    {
                        _Room.ShortCode = Utils.ConvertFirstLetterToUpper(txtShortCode.Text);
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _Room.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    }
                    int capacity;
                    if (!string.IsNullOrEmpty(txtDescription.Text) && int.TryParse(txtCapacity.Text,out capacity))
                    {
                        _Room.Capacity = int.Parse(txtCapacity.Text);
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        _Room.Status = cboStatus.SelectedValue.ToString();
                    }

                    rep.UpdateRoom(_Room);

                    RoomsForm f = (RoomsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsRoomValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtShortCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtShortCode, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCapacity.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCapacity, "Capacity cannot be null!");
                return false;
            }
            int capacity;
            if (!int.TryParse(txtCapacity.Text, out capacity))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCapacity, "Capacity must be integer!");
                return false;
            }
            if (cboStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboStatus, "Select Status!");
                return false;
            }
            return noerror;
        }

        private void EditRoomForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

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
                if (_Room.ShortCode != null)
                {
                    txtShortCode.Text = _Room.ShortCode;
                }
                if (_Room.Description != null)
                {
                    txtDescription.Text = _Room.Description ;
                }
                if (_Room.Capacity != null)
                {
                    txtCapacity.Text = _Room.Capacity.ToString();
                }
                if (_Room.Status != null)
                {
                    cboStatus.SelectedValue = _Room.Status.Trim();
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtCapacity_KeyDown(object sender, KeyEventArgs e)
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
