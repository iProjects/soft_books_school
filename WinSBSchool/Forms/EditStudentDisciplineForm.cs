﻿using System;
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
    public partial class EditStudentDisciplineForm : Form
    {
        Repository rep;
        DAL.Student s;
        string connection;
        SBSchoolDBEntities db;
        Discipline displine;

        public EditStudentDisciplineForm(DAL.Student student, Discipline _discipline, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (student == null)
                throw new ArgumentNullException("Student");
            s = student;

            if (_discipline == null)
                throw new ArgumentNullException("Discipline");
            displine = _discipline;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (IsDisplineValid())
            {
                try
                {

                    displine.StudentId = s.Id;
                    displine.DisciplinaryDate = dateTimePickeDisplinaryDate.Value;
                    if (!string.IsNullOrEmpty(txtIncident.Text))
                    {
                        displine.Incident =Utils.ConvertFirstLetterToUpper( txtIncident.Text.Trim());
                    }
                    if (cboDisplineCategory.SelectedIndex != -1)
                    {
                        displine.DisciplineCategoryId = int.Parse(cboDisplineCategory.SelectedValue.ToString());
                    }
                    if (cboSeverity.SelectedIndex != -1)
                    {
                        displine.Severity = cboSeverity.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtActionRecommendend.Text))
                    {
                        displine.ActionRecommended = Utils.ConvertFirstLetterToUpper(txtActionRecommendend.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtActionTaken.Text))
                    {
                        displine.ActionTaken = Utils.ConvertFirstLetterToUpper(txtActionTaken.Text.Trim());
                    }
                    if (cboDisciplineRating.SelectedIndex != -1)
                    {
                        displine.DisciplineRating = cboDisciplineRating.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtReview.Text))
                    {
                        displine.Review = Utils.ConvertFirstLetterToUpper(txtReview.Text.Trim());
                    } 

                    rep.UpdateDiscipline(displine);

                    EditStudentForm f = (EditStudentForm)this.Owner;
                    f.RefreshDisplinesGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsDisplineValid()
        {
            bool noerror = true;
            if (cboDisplineCategory.SelectedIndex == -1)
            {
                errorProvider1.Clear(); //Clear all Error Messages
                errorProvider1.SetError(cboDisplineCategory, "Select Displine Category!");
                return false;
            }
            if (string.IsNullOrEmpty(txtIncident.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtIncident, "Incident cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtActionTaken.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtActionTaken, "Action Taken cannot be null!");
                return false;
            }
            return noerror;
        }
        public void DisableControls()
        {
            txtIncident.Enabled = false;
            cboDisplineCategory.Enabled = false;
            cboSeverity.Enabled = false;
            txtActionRecommendend.Enabled = false;
            txtActionTaken.Enabled = false;
            dateTimePickeDisplinaryDate.Enabled = false;
            cboDisciplineRating.Enabled = false;
            txtReview.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditStudentDisciplineForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _DscplnryCtgrs = from dc in db.DisciplinaryCategories
                                     select dc;
                List<DisciplinaryCategory> _DisciplinaryCategories = _DscplnryCtgrs.ToList();
                cboDisplineCategory.DataSource = _DisciplinaryCategories;
                cboDisplineCategory.ValueMember = "Id";
                cboDisplineCategory.DisplayMember = "Description";
                cboDisplineCategory.SelectedIndex = -1;

                var Severity = new BindingList<KeyValuePair<string, string>>();
                Severity.Add(new KeyValuePair<string, string>("M", "Mild"));
                Severity.Add(new KeyValuePair<string, string>("S", "Serious"));
                cboSeverity.DataSource = Severity;
                cboSeverity.ValueMember = "Key";
                cboSeverity.DisplayMember = "Value"; 

                var DisciplineRating = new BindingList<KeyValuePair<string, string>>();
                DisciplineRating.Add(new KeyValuePair<string, string>("I", "Improving"));
                DisciplineRating.Add(new KeyValuePair<string, string>("T", "Deteriorating"));
                //DisciplineRating.Add(new KeyValuePair<string, string>("G", "Degrading"));
                cboDisciplineRating.DataSource = DisciplineRating;
                cboDisciplineRating.ValueMember = "Key";
                cboDisciplineRating.DisplayMember = "Value"; 

                InitializeControls();
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);

            }
        }
        public void InitializeControls()
        {

            if (displine.DisciplineCategoryId != null)
            {
                cboDisplineCategory.SelectedValue = displine.DisciplineCategoryId;
            }
            if (displine.DisciplinaryDate != null)
            {
                dateTimePickeDisplinaryDate.Value = displine.DisciplinaryDate;
            }
            if (displine.Incident != null)
            {
                txtIncident.Text = displine.Incident.Trim();
            }
            if (displine.Severity != null)
            {
                cboSeverity.SelectedValue = displine.Severity.ToString();
            }
            if (displine.ActionRecommended != null)
            {
                txtActionRecommendend.Text = displine.ActionRecommended.Trim();
            }
            if (displine.ActionTaken != null)
            {
                txtActionTaken.Text = displine.ActionTaken.Trim();
            }
            if (displine.DisciplineRating != null)
            {
                cboDisciplineRating.SelectedValue = displine.DisciplineRating.Trim();
            }
            if (displine.Review != null)
            {
                txtReview.Text = displine.Review.Trim();
            }

        }
    }
}
