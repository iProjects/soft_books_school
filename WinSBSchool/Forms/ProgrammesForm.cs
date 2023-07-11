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
    public partial class ProgrammesForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;

        public ProgrammesForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void ProgrammesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var prgrmmsquery = from pg in db.Programmes
                                   where pg.IsDeleted == false
                                   select pg;
                List<Programme> _programmes = prgrmmsquery.ToList();

                decimal _TotalProgrammeFees = 0;

                foreach (var _Programme in _programmes)
                {
                    var _programmeyearsquery = from pc in db.ProgrammeYears
                                               where pc.ProgrammeId.Trim() == _Programme.Id.Trim()
                                               select pc;
                    List<ProgrammeYear> _ProgramYears = _programmeyearsquery.ToList();

                    foreach (var _ProgrammeYear in _ProgramYears)
                    {
                        var _ProgramYearCoursesquery = from pyc in db.ProgrammeYearCourses
                                                       where pyc.ProgrammeId == _Programme.Id
                                                       where pyc.IsDeleted == false
                                                       where pyc.ProgrammeYearId == _ProgrammeYear.Id
                                                       select pyc;
                        List<ProgrammeYearCours> _ProgrammeYearCourses = _ProgramYearCoursesquery.ToList();

                        _TotalProgrammeFees += _ProgrammeYearCourses.Sum(i => i.ExamFees) + _ProgrammeYearCourses.Sum(i => i.ResitFees) + _ProgrammeYearCourses.Sum(i => i.TuitionFees) ?? 0;
                    }

                    _Programme.Fees = _TotalProgrammeFees;
                }     

                bindingSourceProgrammes.DataSource = _programmes; 
                dataGridViewProgrammes.AutoGenerateColumns = false;
                this.dataGridViewProgrammes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewProgrammes.DataSource = bindingSourceProgrammes;
                groupBox1.Text = bindingSourceProgrammes.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var dfscl = (from sub in db.Programmes
                             where sub.IsDefault == true
                             where sub.IsDeleted == false
                             select sub);
                if (dfscl.Count() > 0)
                {
                    Forms.AddProgrammeForm asf = new Forms.AddProgrammeForm(connection) { Owner = this };
                    asf.DisableChechBox();
                    asf.ShowDialog();
                }
                else
                {
                    AddProgrammeForm anpf = new AddProgrammeForm(connection) { Owner = this };
                    anpf.ShowDialog();
                }
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
                if (dataGridViewProgrammes.SelectedRows.Count != 0)
                {
                    Programme p = (Programme)bindingSourceProgrammes.Current;

                    var dfscl = (from sub in db.Programmes
                                 where sub.IsDefault == true
                                 where sub.IsDeleted == false
                                 select sub);

                    if (dfscl.Count() > 0 && p.IsDefault == true)
                    {
                        Forms.EditProgrammeForm esf = new Forms.EditProgrammeForm(p, connection) { Owner = this };
                        esf.Text = p.Description.ToUpper().Trim();
                        esf.ShowDialog();
                    }
                    if (dfscl.Count() > 0 && p.IsDefault != true)
                    {
                        Forms.EditProgrammeForm esf = new Forms.EditProgrammeForm(p, connection) { Owner = this };
                        esf.Text = p.Description.ToUpper().Trim();
                        esf.DisableCheckBox();
                        esf.ShowDialog();
                    }
                    if (dfscl.Count() == 0)
                    {
                        Forms.EditProgrammeForm esf = new Forms.EditProgrammeForm(p, connection) { Owner = this };
                        esf.Text = p.Description.ToUpper().Trim();
                        esf.SetCheckBox();
                        esf.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGrid()
        {
            try
            {
                bindingSourceProgrammes.DataSource = null;
                var _programmesquery = from pg in db.Programmes
                                   where pg.IsDeleted == false
                                   select pg;
                List<Programme> _programmes = _programmesquery.ToList();

                decimal _TotalProgrammeFees = 0;

                foreach (var _Programme in _programmes)
                {
                    var _programmeyearsquery = from pc in db.ProgrammeYears
                                             where pc.ProgrammeId.Trim() == _Programme.Id.Trim()
                                             select pc;
                    List<ProgrammeYear> _ProgramYears = _programmeyearsquery.ToList();

                    foreach (var _ProgrammeYear in _ProgramYears)
                    {
                        var _ProgramYearCoursesquery = from pyc in db.ProgrammeYearCourses
                                                     where pyc.ProgrammeId == _Programme.Id
                                                     where pyc.IsDeleted == false
                                                     where pyc.ProgrammeYearId == _ProgrammeYear.Id 
                                                     select pyc;
                        List<ProgrammeYearCours> _ProgrammeYearCourses = _ProgramYearCoursesquery.ToList();

                        _TotalProgrammeFees += _ProgrammeYearCourses.Sum(i => i.ExamFees) + _ProgrammeYearCourses.Sum(i => i.ResitFees) + _ProgrammeYearCourses.Sum(i => i.TuitionFees) ?? 0;
                    }

                    _Programme.Fees = _TotalProgrammeFees;
                }                

                bindingSourceProgrammes.DataSource = _programmes;
                groupBox1.Text = bindingSourceProgrammes.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewProgrammes.Rows)
                {
                    dataGridViewProgrammes.Rows[dataGridViewProgrammes.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewProgrammes.Rows.Count - 1;
                    bindingSourceProgrammes.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewProgrammes.SelectedRows.Count != 0)
                {
                    Programme p = (Programme)bindingSourceProgrammes.Current;


                    var prgyrsquery = from py in db.ProgrammeYears
                                      where py.IsDeleted == false
                                      where py.ProgrammeId == p.Id
                                      select py;
                    List<ProgrammeYear> programmeyears = prgyrsquery.ToList();

                    if (programmeyears.Count > 0)
                    {
                        MessageBox.Show("There is a Year Associated with this Programme.\n Delete the Year First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Programme\n" + p.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteProgramme(p);
                            RefreshGrid();
                        }
                    }
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

        private void dataGridViewProgrammes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewProgrammes.SelectedRows.Count != 0)
                {
                    Programme p = (Programme)bindingSourceProgrammes.Current;
                    EditProgrammeForm epf = new EditProgrammeForm(p, connection) { Owner = this };
                    epf.Text = p.Description.Trim().ToUpper();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewProgrammes.SelectedRows.Count != 0)
                {
                    Programme p = (Programme)bindingSourceProgrammes.Current;
                    EditProgrammeForm epf = new EditProgrammeForm(p, connection) { Owner = this };
                    epf.Text = p.Description.Trim().ToUpper();
                    epf.DisableControls();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private bool ValidDefaultProgramme()
        {
            bool valid = false;
            var totalq = (from fs in db.Programmes
                          where fs.IsDefault == true
                          select fs).FirstOrDefault();

            if (totalq != null)
            {
                valid = true;
            }
            if (totalq == null)
            {
                valid = false;
            }
            return valid;
        }
        private void groupBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count > 0)
            {
                if (!ValidDefaultProgramme())
                {
                    MessageBox.Show("Not default Programme is set!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }

        private void dataGridViewProgrammes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }









    }
}