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
    public partial class EditTimeTableActivityForm : Form
    {
        Repository rep;
        DAL.TimeTable tt; 
        SBSchoolDBEntities db;
        IQueryable<ClassStream> csQuery;
        IQueryable<ClassStream> sclassesstreams;
        string connection;
        public EditTimeTableActivityForm(DAL.TimeTable t, string Conn)
        {
            InitializeComponent();
            tt = t;

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void EditTimeTableActivityForm_Load(object sender, EventArgs e)
        {
            try
            {
                csQuery = db.ClassStreams;
                List<ClassStream> classstreams = csQuery.ToList();
                cboClassStream.DataSource = classstreams;
                cboClassStream.ValueMember = "ClassStreamId";
                cboClassStream.DisplayMember = "Description";

                sclassesstreams = db.ClassStreams;
                List<ClassStream> schoolclassstreams = sclassesstreams.ToList();
                cboPlace.DataSource = schoolclassstreams;
                cboPlace.ValueMember = "ClassStreamId";
                cboPlace.DisplayMember = "Description";

                IQueryable<Teacher> teachers = db.Teachers;
                List<Teacher> subjectteachers = teachers.ToList();
                cboByWho.DataSource = subjectteachers;
                cboByWho.ValueMember = "TeacherId";
                cboByWho.DisplayMember = "Name";

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
                 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider1.Clear();

                if (IsTimeTableActivityValid())
                { 
                     

                    rep.UpdateTimeTable(tt);

                    SystemDetailsForm f = (SystemDetailsForm)this.Owner;
                    
                    this.Close();
                }
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

        public bool IsTimeTableActivityValid()
        {
            bool noerror = true;

            if  (cboClassStream.SelectedValue == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboClassStream, "Select ClassName Stream!");
                return false;
            }
            if (string.IsNullOrEmpty(txtActivity.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtActivity, "Activity  cannot be null!");
                return false;
            }
            if (cboPlace.SelectedValue == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboPlace, "Select Place!");
                return false;
            }
            if (cboByWho.SelectedValue == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboByWho, "Select By Who!");
                return false;
            } 
            return noerror;

        }

        /*public method to diable all controls when form is called by parent from 'View Details' button*/
        public void DisableControls()
        {

            cboClassStream.Enabled = false;
            dtpStartTime.Enabled = false;
            dtpEndTime.Enabled = false;
            txtActivity.Enabled = false;
            cboByWho.Enabled = false;
            cboPlace.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;

        }

         


    }
}
