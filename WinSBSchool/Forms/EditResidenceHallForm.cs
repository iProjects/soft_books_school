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
    public partial class EditResidenceHallForm : Form
    {
        string connection;
        SBSchoolDBEntities db;
        DAL.ResidenceHall _residenceHall;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditResidenceHallForm(DAL.ResidenceHall residencehall, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
            _residenceHall = residencehall;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsResidenceHallValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtHallName.Text))
                    {
                        _residenceHall.HallName = txtHallName.Text.ToUpper();
                    }
                    if (!string.IsNullOrEmpty(txtLocation.Text))
                    {
                        _residenceHall.Location = txtLocation.Text.Trim();
                    }

                    db.SaveChanges();

                    ResidenceHallsForm f = (ResidenceHallsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsResidenceHallValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtHallName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtHallName, "Hall Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtLocation.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLocation, "Location cannot be null!");
                return false;
            }
            return noerror;
        }
        private void EditResidenceHallForm_Load(object sender, EventArgs e)
        {
            try
            { 
            var _RsdncHllrms = from rh in db.ResidenceHallRooms
                               where rh.HallId == _residenceHall.HallId
                               select rh;
            List<ResidenceHallRoom> ResidenceHallRooms = _RsdncHllrms.ToList();
            bindingSourceResidenceHallRoom.DataSource = ResidenceHallRooms;            
            dataGridViewResidenceHallRoom.AutoGenerateColumns = false;
            this.dataGridViewResidenceHallRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResidenceHallRoom.DataSource = bindingSourceResidenceHallRoom;

            InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void InitializeControls()
        {
            if (_residenceHall.HallName != null)
            {
                txtHallName.Text = _residenceHall.HallName.Trim();
            }
            if (_residenceHall.Location != null)
            {
                txtLocation.Text = _residenceHall.Location.Trim();
            }
        }

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewResidenceHallRoom.SelectedRows.Count != 0)
            {
                try
                {
                    ResidenceHallRoom _ResidenceHallRoom = (ResidenceHallRoom)bindingSourceResidenceHallRoom.Current;


                    var _stdntssquery = from st in db.Students
                                         where st.ResidenceHallRoomId == _ResidenceHallRoom.RoomId 
                                            select st;
                    List<Student> _Students = _stdntssquery.ToList();

                    if (_Students.Count > 0)
                    {
                        MessageBox.Show("There is a Student Associated with this Room.\n Delete the Student First!", "Confirm Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete  Room\n" + _ResidenceHallRoom.Room.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            db.ResidenceHallRooms.DeleteObject(_ResidenceHallRoom);
                            db.SaveChanges();
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
        private bool IsResidenceHallRoomValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtRoom.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtRoom, "Room cannot be null!");
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsResidenceHallRoomValid())
            {
                try
                {
                    ResidenceHallRoom _residenceHallRoom = new ResidenceHallRoom();
                    _residenceHallRoom.HallId = _residenceHall.HallId;
                    if (!string.IsNullOrEmpty(txtRoom.Text))
                    {
                        _residenceHallRoom.Room = txtRoom.Text.ToUpper();
                    }
                    decimal cost;
                    if (!string.IsNullOrEmpty(txtCost.Text) && decimal.TryParse(txtCost.Text,out cost))
                    {
                        _residenceHallRoom.Cost = decimal.Parse(txtCost.Text.ToString());
                    }
                    if (!db.ResidenceHallRooms.Any(o => o.Room.Trim() == txtRoom.Text.Trim()))
                    {
                        db.ResidenceHallRooms.AddObject(_residenceHallRoom);
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
        public void RefreshGrid()
        {
            try
            {
            //set the datasource to null
            bindingSourceResidenceHallRoom.DataSource = null;
            //set the datasource to a method 
            var _RsdncHllrms = from rh in db.ResidenceHallRooms
                               where rh.HallId == _residenceHall.HallId
                             select rh;
            List<ResidenceHallRoom> ResidenceHallRooms = _RsdncHllrms.ToList();
            bindingSourceResidenceHallRoom.DataSource = ResidenceHallRooms;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtRoom_KeyDown(object sender, KeyEventArgs e)
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

        private void txtRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
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
