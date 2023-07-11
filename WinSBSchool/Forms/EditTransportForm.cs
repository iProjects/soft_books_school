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
    public partial class EditTransportForm : Form
    {
        string connection;
        SBSchoolDBEntities db;
        DAL.Transport t;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditTransportForm(DAL.Transport transport, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
            t = transport;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();

            if (IsTransportValid())
            {
                try
                {
                     
                    if (cboResidence.SelectedIndex != -1)
                    {
                        t.ResidenceId = int.Parse(cboResidence.SelectedValue.ToString());
                    }
                    int cost;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && int.TryParse(txtAmount.Text, out cost))
                    {
                        t.Amount = int.Parse(txtAmount.Text.ToString());
                    } 

                    db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                    TransportForm f = (TransportForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsTransportValid()
        {
            bool noerror = true;
            if (cboResidence.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboResidence, "Select Residence!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmount, "Amount cannot be null!");
                return false;
            }
            return noerror;
        }
        private void EditResidenceForm_Load(object sender, EventArgs e)
        {try
            {
            var rsdncsquery = from rd in db.Residences
                             select rd;
            List<Residence> Residences = rsdncsquery.ToList();
            cboResidence.DataSource = Residences;
            cboResidence.ValueMember = "ResidenceId";
            cboResidence.DisplayMember = "Name";
            cboResidence.SelectedIndex = -1;

            InitializeControls();
            }
        catch (Exception ex)
        {
            Utils.ShowError(ex);
        }
        }
        private void InitializeControls()
        {
            if (t.ResidenceId != null)
            {
                cboResidence.SelectedValue = t.ResidenceId;
            }
            if (t.Amount != null)
            {
                txtAmount.Text = t.Amount.ToString();
            } 
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
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
