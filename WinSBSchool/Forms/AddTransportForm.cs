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
    public partial class AddTransportForm : Form
    {
        string connection;
        SBSchoolDBEntities db;

        public AddTransportForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsTransportValid())
            {

                try
                {
                    Transport t = new Transport();
                    if (cboResidence.SelectedIndex != -1)
                    {
                        t.ResidenceId = int.Parse(cboResidence.SelectedValue.ToString());
                    }
                    int cost;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && int.TryParse(txtAmount.Text, out cost))
                    {
                        t.Amount = int.Parse(txtAmount.Text.ToString());
                    }

                    if (!db.Transports.Any(o => o.ResidenceId == t.ResidenceId && o.Amount == t.Amount))
                    {
                        db.Transports.AddObject(t);
                        db.SaveChanges();
                    }

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

        private void AddTransportForm_Load(object sender, EventArgs e)
        {
            var rsdncsquery = from rd in db.Residences
                              select rd;
            List<Residence> Residences = rsdncsquery.ToList();
            cboResidence.DataSource = Residences;
            cboResidence.ValueMember = "ResidenceId";
            cboResidence.DisplayMember = "Name";
            cboResidence.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
