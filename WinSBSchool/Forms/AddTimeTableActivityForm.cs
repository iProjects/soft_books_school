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
    public partial class AddTimeTableActivityForm : Form
    {
        string connection;
        SBSchoolDBEntities db;
        IQueryable<ClassStream> csQuery;

        public AddTimeTableActivityForm(string Conn)
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
            if (IsTimeTableActivityValid())
            {
                //try
                //{
                //    TimeTableForm tt = new TimeTableForm()
                //    {
                //        ClassStreamId = int.Parse(cboClassStream.SelectedValue.ToString()),
                //        startdate = dtpStartTime.Value,
                //        enddate = dtpEndTime.Value,
                //        Activity = txtActivity.Text.Trim(),
                //        Place = int.Parse(cboPlace.SelectedValue.ToString()),
                //        ByWho = int.Parse(cboByWho.SelectedValue.ToString())
                       
                //    };
                //    db.TimeTables.AddObject(tt);
                //    db.SaveChanges();

                //    TimeTableActivityListForm f = (TimeTableActivityListForm)this.Owner;
                //    f.RefreshSubjectsGrid();
                //    this.Close();
                //}
                //catch (Exception exm)
                ////{
                ////    string msg = exm.Message;
                //if (exm.InnerException != null)
                //    msg += "\n" + exm.InnerException.Message;
                //MessageBox.Show(msg, "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }
        public bool IsTimeTableActivityValid()
        {
            bool noerror = true;

            if (cboClassStream.SelectedValue == null)
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
        private void AddTimeTableActivityForm_Load(object sender, EventArgs e)
        {
            try
            {
                csQuery = db.ClassStreams;
                List<ClassStream> classstreams = csQuery.ToList();
                cboClassStream.DataSource = classstreams;
                cboClassStream.ValueMember = "ClassStreamId";
                cboClassStream.DisplayMember = "Description";

                IQueryable<ClassStream> sclassesstreams = db.ClassStreams;
                List<ClassStream> schoolclassstreams = sclassesstreams.ToList();
                cboPlace.DataSource = schoolclassstreams;
                cboPlace.ValueMember = "ClassStreamId";
                cboPlace.DisplayMember = "Description";

                IQueryable<Teacher> teachers = db.Teachers;
                List<Teacher> subjectteachers = teachers.ToList();
                cboByWho.DataSource = subjectteachers;
                cboByWho.ValueMember = "TeacherId";
                cboByWho.DisplayMember = "Name";
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

         
    }
}
