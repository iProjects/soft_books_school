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
            errorProvider.Clear();
            if (IsTimeTableActivityValid())
            {
                try
                {
                    //TimeTableDet tt = new TimeTableDet()
                    //{
                    //    ClassStreamId = int.Parse(cboClassStream.SelectedValue.ToString()),
                    //    startdate = dtpStartTime.Value,
                    //    enddate = dtpEndTime.Value,
                    //    Activity = txtActivity.Text.Trim(),
                    //    Place = int.Parse(cboPlace.SelectedValue.ToString()),
                          
                    //    ByWho = int.Parse(cboByWho.SelectedValue.ToString())
                         
                    //};
                    //db.TimeTables.AddObject(tt);
                    //db.SaveChanges();

                    //TimeTableActivityListForm f = (TimeTableActivityListForm)this.Owner;
                    //f.RefreshSubjectsGrid();
                    //this.Close();
                }
                catch (Exception exm)
                {
                    string msg = exm.Message;
                    if (exm.InnerException != null)
                        msg += "\n" + exm.InnerException.Message;
                    MessageBox.Show(msg, "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool IsTimeTableActivityValid()
        {
            bool noerror = true;

            if (cboClassStream.SelectedValue == null)
            {
                errorProvider.SetError(cboClassStream, "Select ClassName Stream!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtActivity.Text))
            {
                errorProvider.SetError(txtActivity, "Activity  cannot be null!");
                noerror = false;
            }
            if (cboPlace.SelectedValue == null)
            {
                errorProvider.SetError(cboPlace, "Select Place!");
                noerror = false;
            }
            if (cboByWho.SelectedValue == null)
            {
                errorProvider.SetError(cboByWho, "Select By Who!");
                noerror = false;
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
