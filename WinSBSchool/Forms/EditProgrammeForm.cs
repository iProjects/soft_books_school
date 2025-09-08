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
    public partial class EditProgrammeForm : Form
    {
        Repository rep;
        Programme _Programme;
        SBSchoolDBEntities db;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditProgrammeForm(Programme programme, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            _Programme = programme;
            db = new SBSchoolDBEntities(connection);
        }
        private void EditProgrammeForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtPYCNoOfHours.Text = "45";
                txtTuitionFees.Text = "20000";
                txtExamFees.Text = "3000";
                txtRetakeFees.Text = "1000";

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                List<Subject> sbjcts = rep.GetActiveSubjects();
                cboprogrammecourses.DataSource = sbjcts;
                cboprogrammecourses.ValueMember = "ShortCode";
                cboprogrammecourses.DisplayMember = "Description";
                cboprogrammecourses.SelectedIndex = -1;

                listViewProgrammeYears.View = View.Details;
                listViewProgrammeYears.GridLines = true;
                listViewProgrammeYears.FullRowSelect = true;
                listViewProgrammeYears.MultiSelect = false;
                listViewProgrammeYears.HideSelection = false;
                listViewProgrammeYears.Columns.Add("", "Year", 100);
                listViewProgrammeYears.Columns.Add("", "Description", 100);
                listViewProgrammeYears.Columns.Add("", "Next Year", 100);
                listViewProgrammeYears.Columns.Add("", "Fees", -2);
                listViewProgrammeYears.Items.Clear();

                ImageList photoList = new ImageList();
                photoList.TransparentColor = Color.Blue;
                photoList.ColorDepth = ColorDepth.Depth32Bit;
                photoList.ImageSize = new Size(10, 10);
                photoList.Images.Add(Image.FromFile("Resources/Signin.jpg"));
                listViewProgrammeYears.SmallImageList = photoList;

                RefreshYearGrid();

                ListViewProgrammeYearCourses.View = View.Details;
                ListViewProgrammeYearCourses.GridLines = true;
                ListViewProgrammeYearCourses.FullRowSelect = true;
                ListViewProgrammeYearCourses.MultiSelect = false;
                ListViewProgrammeYearCourses.HideSelection = false;
                ListViewProgrammeYearCourses.Columns.Add("", "Course", 100);
                ListViewProgrammeYearCourses.Columns.Add("", "NoOfHrs", 100);
                ListViewProgrammeYearCourses.Columns.Add("", "Tuituion Fees", 100);
                ListViewProgrammeYearCourses.Columns.Add("", "Exam Fees", 100);
                ListViewProgrammeYearCourses.Columns.Add("", "Resit Fees", -2);
                ListViewProgrammeYearCourses.Items.Clear();

                ImageList pycphotoList = new ImageList();
                pycphotoList.TransparentColor = Color.Blue;
                pycphotoList.ColorDepth = ColorDepth.Depth32Bit;
                pycphotoList.ImageSize = new Size(10, 10);
                pycphotoList.Images.Add(Image.FromFile("Resources/Signin.jpg"));
                ListViewProgrammeYearCourses.SmallImageList = pycphotoList;

                RefreshYearCoursesGrid();

                InitializeControls();

                AutoCompleteStringCollection acscshtcd = new AutoCompleteStringCollection();
                acscshtcd.AddRange(this.AutoComplete_ShortCode());
                txtShortCode.AutoCompleteCustomSource = acscshtcd;
                txtShortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtShortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscdescrp = new AutoCompleteStringCollection();
                acscdescrp.AddRange(this.AutoComplete_Description());
                txtDescription.AutoCompleteCustomSource = acscdescrp;
                txtDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscyr = new AutoCompleteStringCollection();
                acscyr.AddRange(this.AutoComplete_Year());
                txtYear.AutoCompleteCustomSource = acscyr;
                txtYear.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtYear.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscpydscptn = new AutoCompleteStringCollection();
                acscpydscptn.AddRange(this.AutoComplete_PrYrDescription());
                txtPrYrDescription.AutoCompleteCustomSource = acscpydscptn;
                txtPrYrDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtPrYrDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscnxtyr = new AutoCompleteStringCollection();
                acscnxtyr.AddRange(this.AutoComplete_NextYear());
                txtNextYear.AutoCompleteCustomSource = acscnxtyr;
                txtNextYear.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtNextYear.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscsmstr = new AutoCompleteStringCollection();
                acscsmstr.AddRange(this.AutoComplete_Semester());
                txtSemester.AutoCompleteCustomSource = acscsmstr;
                txtSemester.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtSemester.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                CalculateProgrammeFees();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_ShortCode()
        {
            try
            {
                var accountsquery = from bk in db.Programmes
                                    where bk.IsDeleted == false
                                    select bk.Id;
                return accountsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Description()
        {
            try
            {
                var accountsquery = from bk in db.Programmes
                                    where bk.IsDeleted == false
                                    select bk.Description;
                return accountsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Year()
        {
            try
            {
                var custidsquery = (from ac in db.ProgrammeYears
                                    where ac.IsDeleted == false
                                    select ac.Year).Distinct();
                int[] intarray = custidsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < custidsquery.Count(); i++)
                {
                    string strName = intarray[i].ToString();
                    items.Add(strName);
                }
                return items.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_PrYrDescription()
        {
            try
            {
                var accountsquery = from bk in db.ProgrammeYears
                                    where bk.IsDeleted == false
                                    select bk.Description;
                return accountsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_NextYear()
        {
            try
            {
                var custidsquery = (from ac in db.ProgrammeYears
                                    where ac.IsDeleted == false
                                    select ac.NextYr).Distinct();
                int?[] intarray = custidsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < custidsquery.Count(); i++)
                {
                    string strName = intarray[i].ToString();
                    items.Add(strName);
                }
                return items.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Semester()
        {
            try
            {
                var custidsquery = (from ac in db.ProgrammeYearCourses
                                    where ac.IsDeleted == false
                                    select ac.Semester).Distinct();
                int[] intarray = custidsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < custidsquery.Count(); i++)
                {
                    string strName = intarray[i].ToString();
                    items.Add(strName);
                }
                return items.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void InitializeControls()
        {
            try
            {
                if (_Programme.Id != null)
                {
                    txtShortCode.Text = _Programme.Id;
                    txtShortCode.Enabled = false;
                }
                if (_Programme.Description != null)
                {
                    txtDescription.Text = _Programme.Description.Trim();
                }
                if (_Programme.Hours != null)
                {
                    txtHours.Text = _Programme.Hours.ToString();
                }
                if (_Programme.Fees != null)
                {
                    txtFees.Text = _Programme.Fees.ToString();
                }
                if (_Programme.IsDefault != null)
                {
                    chkIsDefaultProgramme.Checked = _Programme.IsDefault.Value;
                }
                cboprogrammecourses.Enabled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void DisableControls()
        {
            try
            {
                #region "Programme"
                txtShortCode.Enabled = false;
                txtDescription.Enabled = false;
                txtHours.Enabled = false;
                txtFees.Enabled = false;
                chkIsDefaultProgramme.Enabled = false;
                cboStatus.Enabled = false;
                #endregion "Programme"
                #region "Programme Years"
                txtYear.Enabled = false;
                txtDescription.Enabled = false;
                txtNextYear.Enabled = false;
                txtPYrFees.Enabled = false;
                txtPrYrDescription.Enabled = false;
                btnDeleteProgrammeYear.Enabled = false;
                btnAddProgrammeYear.Enabled = false;
                #endregion "Programme Years"
                #region "Programme Year Courses"
                cboprogrammecourses.Enabled = false;
                txtSemester.Enabled = false;
                txtPYCNoOfHours.Enabled = false;
                txtTuitionFees.Enabled = false;
                txtExamFees.Enabled = false;
                txtRetakeFees.Enabled = false;
                btnAddProgrammeYearCourse.Enabled = false;
                btnDeleteProgrammeYearCourse.Enabled = false;
                #endregion "Programme Year Courses"
                btnUpdate.Enabled = false;
                btnUpdate.Visible = false;
                btnClose.Location = btnUpdate.Location;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddProgrammeYearCourse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();

            if (listViewProgrammeYears.SelectedItems.Count != 0)
            {
                ProgrammeYear _ProgrammeYear = null;
                int year = 0;

                foreach (ListViewItem lvi in listViewProgrammeYears.SelectedItems)
                {

                    ListViewItem.ListViewSubItem _year = lvi.SubItems[0];
                    year = int.Parse(_year.Text.ToString());

                    _ProgrammeYear = this.GetProgrammeYear(_Programme.Id, year);
                }
                if (IsProgrammeCourseValid())
                {
                    try
                    {
                        ProgrammeYearCours prc = new ProgrammeYearCours();

                        if (_Programme.Id != null)
                        {
                            prc.ProgrammeId = _Programme.Id.Trim();
                        }
                        if (cboprogrammecourses.SelectedIndex != -1)
                        {
                            prc.CourseId = cboprogrammecourses.SelectedValue.ToString();
                        }
                        if (year != null)
                        {
                            prc.ProgrammeYearId = _ProgrammeYear.Id;
                        }
                        int semester;
                        if (!string.IsNullOrEmpty(txtSemester.Text) && int.TryParse(txtSemester.Text.Trim(), out semester))
                        {
                            prc.Semester = int.Parse(txtSemester.Text);
                        }
                        int noofhrs;
                        if (!string.IsNullOrEmpty(txtPYCNoOfHours.Text) && int.TryParse(txtPYCNoOfHours.Text, out noofhrs))
                        {
                            prc.NoOfHrs = int.Parse(txtPYCNoOfHours.Text);
                        }
                        decimal tuitionfees;
                        if (!string.IsNullOrEmpty(txtTuitionFees.Text) && decimal.TryParse(txtTuitionFees.Text, out tuitionfees))
                        {
                            prc.TuitionFees = decimal.Parse(txtTuitionFees.Text);
                        }
                        decimal examfees;
                        if (!string.IsNullOrEmpty(txtExamFees.Text) && decimal.TryParse(txtExamFees.Text, out examfees))
                        {
                            prc.ExamFees = decimal.Parse(txtExamFees.Text);
                        }
                        decimal resitfees;
                        if (!string.IsNullOrEmpty(txtRetakeFees.Text) && decimal.TryParse(txtRetakeFees.Text, out resitfees))
                        {
                            prc.ResitFees = decimal.Parse(txtRetakeFees.Text);
                        }
                        prc.Status = "A";
                        prc.IsDeleted = false;

                        if (db.ProgrammeYearCourses.Any(o => o.ProgrammeId == prc.ProgrammeId && o.CourseId == prc.CourseId && o.ProgrammeYearId == prc.ProgrammeYearId && o.Semester == prc.Semester))
                        {
                            MessageBox.Show("Course for Semester Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (!db.ProgrammeYearCourses.Any(o => o.ProgrammeId == prc.ProgrammeId && o.CourseId == prc.CourseId && o.ProgrammeYearId == prc.ProgrammeYearId && o.Semester == prc.Semester))
                        {
                            db.ProgrammeYearCourses.AddObject(prc);
                            db.SaveChanges();

                            RefreshYearCoursesGrid();

                            CalculateProgrammeFees();

                        }
                    }
                    catch (Exception ex)
                    {
                        Utils.ShowError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a Programme Year!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDeleteProgrammeYearCourse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewProgrammeYears.SelectedItems.Count != 0)
            {
                ProgrammeYear _ProgrammeYear = null;
                int year = 0;

                ListViewItem.ListViewSubItem _year = listViewProgrammeYears.SelectedItems[0].SubItems[0];

                year = int.Parse(_year.Text.ToString());

                _ProgrammeYear = this.GetProgrammeYear(_Programme.Id, year);

                var Semestersquery = (from sm in db.ProgrammeYearCourses
                                      where sm.ProgrammeId == _Programme.Id
                                      where sm.ProgrammeYearId == _ProgrammeYear.Id
                                      select sm.Semester).Distinct().ToList();

                foreach (var sm in Semestersquery)
                {

                    if (ListViewProgrammeYearCourses.SelectedItems.Count != 0)
                    {
                        try
                        {
                            ListViewItem.ListViewSubItem Course = ListViewProgrammeYearCourses.SelectedItems[0].SubItems[0];

                            ProgrammeYearCours progcs = this.GetProgrammeYearCourse(Course.Text, _ProgrammeYear.Id.ToString(), sm.ToString(), _Programme.Id.Trim());
                            if (progcs != null)
                            {
                                rep.DeleteProgrammeCourse(progcs);
                                RefreshYearCoursesGrid();
                            }
                        }
                        catch (Exception ex)
                        {
                            Utils.ShowError(ex);
                        }
                    }
                }
            }
        }
        private bool IsProgrammeYearValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtYear, "Year cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrYrDescription.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtPrYrDescription, "Description cannot be null!");
                return false;
            }
            return noerror;
        }
        private bool IsProgrammeCourseValid()
        {
            bool noerror = true;
            if (cboprogrammecourses.SelectedIndex == -1)
            {
                errorProvider.Clear();
                errorProvider.SetError(cboprogrammecourses, "Select a Subject!");
                return false;
            }
            if (string.IsNullOrEmpty(txtSemester.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtSemester, "Semester cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPYCNoOfHours.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtPYCNoOfHours, "No Of Hours cannot be null!");
                return false;
            }
            int _NoOfHours;
            if (!int.TryParse(txtPYCNoOfHours.Text, out _NoOfHours))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtPYCNoOfHours, "No Of Hours must be integer!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTuitionFees.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtTuitionFees, "Tuition Fees cannot be null!");
                return false;
            }
            decimal _TuitionFees;
            if (!decimal.TryParse(txtTuitionFees.Text, out _TuitionFees))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtTuitionFees, "Tuition Fees  must be decimal!");
                return false;
            }
            return noerror;
        }
        private void RefreshYearGrid()
        {

            try
            {
                listViewProgrammeYears.Items.Clear();

                var _programyearsquery = from pc in db.ProgrammeYears
                            where pc.ProgrammeId.Trim() == _Programme.Id.Trim()
                            select pc;
                List<ProgrammeYear> _ProgramYears = _programyearsquery.ToList();
                foreach (ProgrammeYear _ProgramYear in _ProgramYears)
                {
                    var _ProgramYearCoursesquery = from pyc in db.ProgrammeYearCourses
                                                   where pyc.ProgrammeId == _Programme.Id
                                                   where pyc.IsDeleted == false
                                                   where pyc.ProgrammeYearId == _ProgramYear.Id
                                                   select pyc;
                    List<ProgrammeYearCours> _ProgrammeYearCourses = _ProgramYearCoursesquery.ToList();

                    decimal totalyearcoursefees = _ProgrammeYearCourses.Sum(i => i.ExamFees) + _ProgrammeYearCourses.Sum(i => i.ResitFees) + _ProgrammeYearCourses.Sum(i => i.TuitionFees) ?? 0;

                    listViewProgrammeYears.Items.Add(new ListViewItem(new string[]
                {
                   _ProgramYear.Year.ToString(),_ProgramYear.Description.Trim(),_ProgramYear.NextYr.ToString(),totalyearcoursefees.ToString()
                
                }));
                }
                foreach (ListViewItem item in listViewProgrammeYears.Items)
                {
                    item.ImageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshYearCoursesGrid()
        {
            ListViewProgrammeYearCourses.Items.Clear();
            if (listViewProgrammeYears.SelectedItems.Count != 0)
            {
                try
                {
                    ProgrammeYear _ProgramYear = null;
                    int year = 0;

                    ListViewItem.ListViewSubItem _year = listViewProgrammeYears.SelectedItems[0].SubItems[0];

                    year = int.Parse(_year.Text.ToString());
                    _ProgramYear = this.GetProgrammeYear(_Programme.Id, year);

                    var _ProgramYearCoursesquery = from pyc in db.ProgrammeYearCourses
                                                   where pyc.ProgrammeId == _Programme.Id
                                                   where pyc.IsDeleted == false
                                                   where pyc.ProgrammeYearId == _ProgramYear.Id
                                                   select pyc;
                    List<ProgrammeYearCours> _ProgrammeYearCourses = _ProgramYearCoursesquery.ToList();

                    decimal totalyearcoursefees = _ProgrammeYearCourses.Sum(i => i.ExamFees) + _ProgrammeYearCourses.Sum(i => i.ResitFees) + _ProgrammeYearCourses.Sum(i => i.TuitionFees) ?? 0;

                    txtPYrFees.Text = totalyearcoursefees.ToString("N2");

                    var Semestersquery = (from sm in db.ProgrammeYearCourses
                                          where sm.ProgrammeId == _Programme.Id
                                          where sm.IsDeleted == false
                                          where sm.ProgrammeYearId == _ProgramYear.Id
                                          select sm.Semester).Distinct().ToList();
                    ListViewProgrammeYearCourses.Items.Clear();
                    ListViewProgrammeYearCourses.ShowGroups = true;

                    foreach (var sm in Semestersquery)
                    {
                        ListViewGroup _group =
     new ListViewGroup("Semester  " + sm.ToString(), HorizontalAlignment.Left);


                        var _ProgramYrCoursesquery = from pyc in db.ProgrammeYearCourses
                                                       where pyc.ProgrammeId == _Programme.Id
                                                       where pyc.IsDeleted == false
                                                       where pyc.ProgrammeYearId == _ProgramYear.Id
                                                       where pyc.Semester == sm
                                                       select pyc;
                        List<ProgrammeYearCours> _ProgrammeYrCourses = _ProgramYrCoursesquery.ToList();

                        foreach (ProgrammeYearCours _ProgramYrCourse in _ProgrammeYrCourses)
                        {
                            ListViewProgrammeYearCourses.Groups.Add(_group);
                            ListViewProgrammeYearCourses.Items.Add(new ListViewItem(new string[]
                {
                    _ProgramYrCourse.CourseId.ToString(),_ProgramYrCourse.NoOfHrs.ToString(),_ProgramYrCourse.TuitionFees.ToString(),_ProgramYrCourse.ExamFees.ToString(),_ProgramYrCourse.ResitFees.ToString()
                }, _group));
                        }
                    }
                    foreach (ListViewItem item in ListViewProgrammeYearCourses.Items)
                    {
                        item.ImageIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            if (IsProgrammeValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _Programme.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }
                    int hrs;
                    if (!string.IsNullOrEmpty(txtHours.Text) && int.TryParse(txtHours.Text, out hrs))
                    {
                        _Programme.Hours = int.Parse(txtHours.Text.Trim());
                    }
                    decimal fees;
                    if (!string.IsNullOrEmpty(txtFees.Text) && decimal.TryParse(txtFees.Text, out fees))
                    {
                        _Programme.Fees = decimal.Parse(txtFees.Text.Trim());
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        _Programme.Status = cboStatus.SelectedValue.ToString();
                    }
                    _Programme.IsDefault = chkIsDefaultProgramme.Checked;

                    rep.UpdateProgramme(_Programme);

                    ProgrammesForm epf = (ProgrammesForm)this.Owner;
                    epf.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsProgrammeValid()
        {
            bool noeeror = true;
            if (string.IsNullOrEmpty(txtShortCode.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtShortCode, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtDescription, "Description Cannot be null!");
                return false;
            }
            if (cboStatus.SelectedIndex == -1)
            {
                errorProvider.Clear();
                errorProvider.SetError(cboStatus, "Select Status!");
                return false;
            }
            return noeeror;
        }
        private ProgrammeYearCours GetProgrammeYearCourse(string Course, string year, string semester, string programmeId)
        {
            try
            {
                int yr = int.Parse(year);
                int sm = int.Parse(semester);

                return db.ProgrammeYearCourses.Where(i => i.CourseId.Trim().Equals(Course.Trim())).Where(i => i.ProgrammeId.Trim() == programmeId.Trim()).Where(i => i.ProgrammeYearId == yr).Where(i => i.Semester == sm).Where(i => i.IsDeleted == false).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void btnDeleteProgrammeYear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewProgrammeYears.SelectedItems.Count != 0)
            {
                try
                {

                    foreach (ListViewItem lvi in listViewProgrammeYears.SelectedItems)
                    {

                        ListViewItem.ListViewSubItem _year = lvi.SubItems[0];
                        int year = int.Parse(_year.Text.ToString());
                        ProgrammeYear programyear = this.GetProgrammeYear(_Programme.Id.Trim(), year);


                        var _prgyrcrsquery = from py in db.ProgrammeYearCourses
                                             where py.ProgrammeId == programyear.ProgrammeId
                                             where py.ProgrammeYearId == programyear.Id
                                             where py.IsDeleted == false
                                             select py;
                        List<ProgrammeYearCours> _programmeyearcourses = _prgyrcrsquery.ToList();

                        var _schlclssquery = from sc in db.SchoolClasses
                                             where sc.ProgrammeYearId == programyear.Id
                                             where sc.IsDeleted == false
                                             select sc;
                        List<SchoolClass> _SchoolClasses = _schlclssquery.ToList();

                        if (_programmeyearcourses.Count > 0)
                        {
                            MessageBox.Show("There is a Course  Associated with this Year.\n Delete the Course First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (_SchoolClasses.Count > 0)
                        {
                            MessageBox.Show("There is a Class Associated with this Year.\n Delete the Class First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Programme Year \n" + programyear.Year.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                            {
                                db.ProgrammeYears.DeleteObject(programyear);
                                db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                                RefreshYearGrid();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("No selected Programme Year! \n Select a Programme Year first.");
            }
        }
        private ProgrammeYear GetProgrammeYear(string programmeid, int year)
        {
            try
            {
                int yr = year;

                return db.ProgrammeYears.Where(i => i.ProgrammeId.Trim().Equals(programmeid.Trim())).Where(i => i.Year == yr).Where(i => i.IsDeleted == false).Single();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void btnAddProgrammeYear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            if (IsProgrammeYearValid())
            {
                try
                {
                    ProgrammeYear py = new ProgrammeYear();
                    if (_Programme.Id != null)
                    {
                        py.ProgrammeId = _Programme.Id.Trim();
                    }
                    int year;
                    if (!string.IsNullOrEmpty(txtYear.Text) && int.TryParse(txtYear.Text, out year))
                    {
                        py.Year = int.Parse(txtYear.Text);
                    }
                    if (!string.IsNullOrEmpty(txtPrYrDescription.Text))
                    {
                        py.Description = Utils.ConvertFirstLetterToUpper(txtPrYrDescription.Text.Trim());
                    }
                    int nextyear;
                    if (!string.IsNullOrEmpty(txtNextYear.Text) && int.TryParse(txtNextYear.Text, out nextyear))
                    {
                        py.NextYr = int.Parse(txtNextYear.Text);
                    }
                    decimal fees;
                    if (!string.IsNullOrEmpty(txtPYrFees.Text) && decimal.TryParse(txtPYrFees.Text, out fees))
                    {
                        py.Fees = decimal.Parse(txtPYrFees.Text);
                    }
                    int _yr = int.Parse(txtYear.Text.ToString().Trim());
                    py.Status = "A";
                    py.IsDeleted = false;

                    if (db.ProgrammeYears.Any(o => o.ProgrammeId == _Programme.Id && o.Year == _yr))
                    {
                        MessageBox.Show("Year for Programme Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.ProgrammeYears.Any(o => o.ProgrammeId == _Programme.Id && o.Year == _yr))
                    {
                        db.ProgrammeYears.AddObject(py);
                        db.SaveChanges();

                        RefreshYearGrid();

                        ClearProgrammeYearControls();

                        CalculateProgrammeFees();

                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void ClearProgrammeYearControls()
        {
            try
            {
                txtYear.Text = string.Empty;
                txtPrYrDescription.Text = string.Empty;
                txtNextYear.Text = string.Empty;
                txtPYrFees.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void listViewProgrammeYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshYearCoursesGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtHours_KeyDown(object sender, KeyEventArgs e)
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
        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtResitFees_KeyDown(object sender, KeyEventArgs e)
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
        private void txtResitFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtSemester_KeyDown(object sender, KeyEventArgs e)
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
        private void txtSemester_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtFees_KeyDown(object sender, KeyEventArgs e)
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
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) e.Handled = true;
            if (Char.IsLetter(e.KeyChar)) e.Handled = true;
            if (Char.IsNumber(e.KeyChar)) e.Handled = true;
            if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
            if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
            if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = true;
            if (e.KeyChar == (char)Keys.Space) e.Handled = true;
            if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
            if (e.KeyChar == (char)Keys.Clear) e.Handled = true;

            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtPYCNoOfHours_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPYCNoOfHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtExamFees_KeyDown(object sender, KeyEventArgs e)
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
        private void txtExamFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtPYrFees_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPYrFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) e.Handled = true;
            if (Char.IsLetter(e.KeyChar)) e.Handled = true;
            if (Char.IsNumber(e.KeyChar)) e.Handled = true;
            if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
            if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
            if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
            if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = true;
            if (e.KeyChar == (char)Keys.Space) e.Handled = true;
            if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
            if (e.KeyChar == (char)Keys.Clear) e.Handled = true;

            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtTuitionFees_KeyDown(object sender, KeyEventArgs e)
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
        private void txtTuitionFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtYear_KeyDown(object sender, KeyEventArgs e)
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
        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtNextYear_KeyDown(object sender, KeyEventArgs e)
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
        private void txtNextYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        public void DisableCheckBox()
        {
            this.chkIsDefaultProgramme.Enabled = false;
        }
        public void SetCheckBox()
        {
            this.chkIsDefaultProgramme.Checked = true;
        }
        private void CalculateProgrammeFees()
        {
            try
            {
                if (_Programme != null)
                {
                    if (tabControlProgrammes.SelectedTab == this.tabPageProgrammeDetails)
                    {
                        var _programmeyearsquery = from py in db.ProgrammeYears
                                                   where py.ProgrammeId == _Programme.Id
                                                   select py;
                        List<ProgrammeYear> _ProgrammeYears = _programmeyearsquery.ToList();

                        decimal totalyearfees = 0;

                        foreach (var _ProgramYear in _ProgrammeYears)
                        {
                            var _ProgramYearCoursesquery = from pyc in db.ProgrammeYearCourses
                                                           where pyc.ProgrammeId == _Programme.Id
                                                           where pyc.IsDeleted == false
                                                           where pyc.ProgrammeYearId == _ProgramYear.Id
                                                           select pyc;
                            List<ProgrammeYearCours> _ProgrammeYearCourses = _ProgramYearCoursesquery.ToList();

                            decimal totalyearcoursefees = _ProgrammeYearCourses.Sum(i => i.ExamFees) + _ProgrammeYearCourses.Sum(i => i.ResitFees) + _ProgrammeYearCourses.Sum(i => i.TuitionFees) ?? 0;

                            totalyearfees += totalyearcoursefees;
                        }

                        txtFees.Text = totalyearfees.ToString("N2");

                    }
                    if (tabControlProgrammes.SelectedTab == this.tabPageProgrammeYears)
                    {
                        if (listViewProgrammeYears.SelectedItems.Count != 0)
                        {
                            ProgrammeYear _ProgramYear = null;
                            int year = 0;

                            ListViewItem.ListViewSubItem _year = listViewProgrammeYears.SelectedItems[0].SubItems[0];

                            year = int.Parse(_year.Text.ToString());
                            _ProgramYear = this.GetProgrammeYear(_Programme.Id, year);

                            var _ProgramYearCoursesquery = from pyc in db.ProgrammeYearCourses
                                                           where pyc.ProgrammeId == _Programme.Id
                                                           where pyc.IsDeleted == false
                                                           where pyc.ProgrammeYearId == _ProgramYear.Id
                                                           select pyc;
                            List<ProgrammeYearCours> _ProgrammeYearCourses = _ProgramYearCoursesquery.ToList();

                            decimal totalyearcoursefees = _ProgrammeYearCourses.Sum(i => i.ExamFees) + _ProgrammeYearCourses.Sum(i => i.ResitFees) + _ProgrammeYearCourses.Sum(i => i.TuitionFees) ?? 0;

                            txtPYrFees.Text = totalyearcoursefees.ToString("N2");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void tabControlProgrammes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControlProgrammes.SelectedTab == this.tabPageProgrammeDetails)
                {
                    CalculateProgrammeFees();
                }
                if (tabControlProgrammes.SelectedTab == this.tabPageProgrammeYears)
                {
                    CalculateProgrammeFees();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 










    }
}