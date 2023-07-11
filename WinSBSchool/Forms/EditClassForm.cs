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
    public partial class EditClassForm : Form
    {
      Repository rep;
        SBSchoolDBEntities db;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;   
        DAL.SchoolClass _SchoolClass;
        List<ClassSubject> classsubjects;
        List<ClassStream> classstreams;
       

        public EditClassForm(DAL.SchoolClass classes, string Conn)
        {
            InitializeComponent();
            _SchoolClass = classes;

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

            if (IsClassValid())
            {
                try
                {

                    if (!string.IsNullOrEmpty(txtShortCode.Text))
                    {
                        _SchoolClass.ShortCode = Utils.ConvertFirstLetterToUpper(txtShortCode.Text);
                    }
                    if (!string.IsNullOrEmpty(txtClassName.Text))
                    {
                        _SchoolClass.ClassName = Utils.ConvertFirstLetterToUpper(txtClassName.Text.Trim());
                    }
                    if (cboProgrammeYears.SelectedIndex != -1)
                    {
                        _SchoolClass.ProgrammeYearId = int.Parse(cboProgrammeYears.SelectedValue.ToString());
                    }
                    int noofsubjects;
                    if (!string.IsNullOrEmpty(txtNoOfSubjects.Text) && int.TryParse(txtNoOfSubjects.Text, out noofsubjects))
                    {
                        _SchoolClass.NoOfSubjects = int.Parse(txtNoOfSubjects.Text.ToString());
                    }
                    if (cboClassTeacher.SelectedIndex != -1)
                    {
                        _SchoolClass.TeacherId = int.Parse(cboClassTeacher.SelectedValue.ToString());
                    }
                    int crrntyr;
                    if (!string.IsNullOrEmpty(txtCurrentYearLevel.Text) && int.TryParse(txtCurrentYearLevel.Text, out crrntyr))
                    {
                        _SchoolClass.CurrentYrLevel = int.Parse(txtCurrentYearLevel.Text.ToString());
                    }
                    int nxtyr;
                    if (!string.IsNullOrEmpty(txtNextYearLevel.Text) && int.TryParse(txtNextYearLevel.Text.Trim(), out nxtyr))
                    {
                        _SchoolClass.NextYrLevel = int.Parse(txtNextYearLevel.Text.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtRemarks.Text))
                    {
                        _SchoolClass.Remarks = Utils.ConvertFirstLetterToUpper(txtRemarks.Text.Trim());
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        _SchoolClass.Status = cboStatus.SelectedValue.ToString();
                    }

                    rep.UpdateSchoolClass(_SchoolClass);

                    ClassesForm f = (ClassesForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsClassValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtShortCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtShortCode, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtClassName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtClassName, "Class Name cannot be null!");
                return false;
            }
            if (cboProgrammeYears.SelectedIndex ==-1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboProgrammeYears, "Select Programme!");
                return false;
            }
            if (string.IsNullOrEmpty(txtNoOfSubjects.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoOfSubjects, "No Of Subjects cannot be null!");
                return false;
            }
            int noofsubjects;
            if (!int.TryParse(txtNoOfSubjects.Text, out noofsubjects))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoOfSubjects, "No Of Subjects must be integer!");
                return false;
            }
            if (cboClassTeacher.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboClassTeacher, "Select Teacher!");
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
        private void EditClassForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                var clsstchrsquery = from tc in db.Teachers
                                     where tc.Status == "A"
                                     where tc.IsDeleted ==false
                                     orderby tc.Name ascending
                                 select tc; 
                List<Teacher> _ClassTeachers = clsstchrsquery.ToList();
                cboClassTeacher.DataSource = _ClassTeachers;
                cboClassTeacher.ValueMember = "Id";
                cboClassTeacher.DisplayMember = "Name";
                cboClassTeacher.SelectedIndex = -1;

                var prgrmmyrs = (from pc in db.ProgrammeYears 
                                 join pr in db.Programmes on pc.ProgrammeId equals pr.Id
                                 where pc.IsDeleted == false
                                 where pr.IsDeleted == false
                                 select pc).Distinct();
                List<ProgrammeYear> ProgrammeYears = prgrmmyrs.ToList();
                cboProgrammeYears.DataSource = ProgrammeYears;
                cboProgrammeYears.ValueMember = "Id";
                cboProgrammeYears.DisplayMember = "Description";
                cboProgrammeYears.SelectedIndex = -1;

                InitializeControls(); 
                
                var clsstreamsquery = from cs in db.ClassStreams
                                     where cs.ClassId == _SchoolClass.Id
                                      where cs.IsDeleted ==false
                                     select cs;
                bindingSourceClassStreams.DataSource = clsstreamsquery.ToList();
                lstClassStreams.DataSource = bindingSourceClassStreams;
                lstClassStreams.ValueMember = "Id";
                lstClassStreams.DisplayMember = "Description";
                groupBox4.Text = bindingSourceClassStreams.Count.ToString(); 

                var sbjcts = from pc in db.Subjects
                             where pc.Status =="A"
                             where pc.IsDeleted ==false
                             select pc;
                List<Subject> subjects = sbjcts.ToList();
                bindingSourceSubjects.DataSource = subjects;
                DataGridViewComboBoxColumn colCboxClassSubjects = new DataGridViewComboBoxColumn();
                colCboxClassSubjects.HeaderText = "Subjects";
                colCboxClassSubjects.Name = "cbClassSubjects";
                colCboxClassSubjects.DataSource = bindingSourceSubjects;
                // The display member is the name column in the column datasource  
                colCboxClassSubjects.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassSubjects.DataPropertyName = "SubjectCode";
                // The value member is the primary key of the parent table  
                colCboxClassSubjects.ValueMember = "ShortCode";
                colCboxClassSubjects.MaxDropDownItems = 10;
                colCboxClassSubjects.Width = 150;
                colCboxClassSubjects.DisplayIndex = 1;
                colCboxClassSubjects.MinimumWidth = 5;
                colCboxClassSubjects.FlatStyle = FlatStyle.Flat;
                colCboxClassSubjects.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassSubjects.ReadOnly = true;
                if (!this.dataGridViewClassSubject.Columns.Contains("cbClassSubjects"))
                {
                    dataGridViewClassSubject.Columns.Add(colCboxClassSubjects);
                } 

                var tchs = from pc in db.Teachers
                           where pc.Status=="A"
                           where pc.IsDeleted ==false
                           select pc;
                List<Teacher> teachers = tchs.ToList();
                bindingSourceTeachers.DataSource = teachers;
                DataGridViewComboBoxColumn colCboxClassTeacher = new DataGridViewComboBoxColumn();
                colCboxClassTeacher.HeaderText = "Teacher";
                colCboxClassTeacher.Name = "cbClassTeacher";
                colCboxClassTeacher.DataSource = bindingSourceTeachers;
                // The display member is the name column in the column datasource  
                colCboxClassTeacher.DisplayMember = "Name";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassTeacher.DataPropertyName = "SubjectTeacherId";
                // The value member is the primary key of the parent table  
                colCboxClassTeacher.ValueMember = "Id";
                colCboxClassTeacher.MaxDropDownItems = 10;
                colCboxClassTeacher.Width = 150;
                colCboxClassTeacher.DisplayIndex = 2;
                colCboxClassTeacher.MinimumWidth = 5;
                colCboxClassTeacher.FlatStyle = FlatStyle.Flat;
                colCboxClassTeacher.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassTeacher.ReadOnly = true;
                if (!this.dataGridViewClassSubject.Columns.Contains("cbClassTeacher"))
                {
                    dataGridViewClassSubject.Columns.Add(colCboxClassTeacher);
                }

                var csstatus = new BindingList<KeyValuePair<string, string>>();
                csstatus.Add(new KeyValuePair<string, string>("A", "Active"));
                csstatus.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                DataGridViewComboBoxColumn colCboxClassStatus = new DataGridViewComboBoxColumn();
                colCboxClassStatus.HeaderText = "Status";
                colCboxClassStatus.Name = "cbStatus";
                colCboxClassStatus.DataSource = csstatus;
                // The display member is the name column in the column datasource  
                colCboxClassStatus.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassStatus.DataPropertyName = "Status";
                // The value member is the primary key of the parent table  
                colCboxClassStatus.ValueMember = "Key";
                colCboxClassStatus.MaxDropDownItems = 10;
                colCboxClassStatus.Width = 100;
                colCboxClassStatus.DisplayIndex = 3;
                colCboxClassStatus.MinimumWidth = 5;
                colCboxClassStatus.FlatStyle = FlatStyle.Flat;
                colCboxClassStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassStatus.ReadOnly = true;
                if (!this.dataGridViewClassSubject.Columns.Contains("cbStatus"))
                {
                    dataGridViewClassSubject.Columns.Add(colCboxClassStatus);
                }
                
                var _clssbbjctsquery = from cs in db.ClassSubjects 
                                  where cs.ClassId == _SchoolClass.Id
                                       where cs.Status == "A"
                                       where cs.IsDeleted ==false
                                       orderby cs.Subject.ShortCode ascending
                                  select cs;
                List<ClassSubject> _classsubjects = _clssbbjctsquery.ToList();
                bindingSourceClassSubjects.DataSource = _clssbbjctsquery;  

                dataGridViewClassSubject.AutoGenerateColumns = false;
                this.dataGridViewClassSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewClassSubject.DataSource = bindingSourceClassSubjects;
                groupBox6.Text = bindingSourceClassSubjects.Count.ToString();
                txtNoOfSubjects.Text = bindingSourceClassSubjects.Count.ToString();

                AutoCompleteStringCollection scccls = new AutoCompleteStringCollection();
                scccls.AddRange(this.AutoComplete_Description());
                txtStreamDescription.AutoCompleteCustomSource = scccls;
                txtStreamDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtStreamDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_Description()
        {
            try
            {
                var descriptionquery = from cs in db.ClassStreams
                                       where cs.IsDeleted == false
                                       select cs.Description;
                return descriptionquery.ToArray();
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
                if (_SchoolClass.ShortCode != null)
                {
                    txtShortCode.Text = _SchoolClass.ShortCode.Trim();
                }
                if (_SchoolClass.ClassName != null)
                {
                    txtClassName.Text = _SchoolClass.ClassName.Trim();
                }
                if (_SchoolClass.ProgrammeYearId != null)
                {
                    cboProgrammeYears.SelectedValue = _SchoolClass.ProgrammeYearId;
                }
                if (_SchoolClass.NoOfSubjects != null)
                {
                    txtNoOfSubjects.Text = _SchoolClass.NoOfSubjects.ToString();
                }
                if (_SchoolClass.TeacherId != null)
                {
                    cboClassTeacher.SelectedValue = _SchoolClass.TeacherId;
                }
                if (_SchoolClass.CurrentYrLevel != null)
                {
                    txtCurrentYearLevel.Text = _SchoolClass.CurrentYrLevel.ToString();
                }
                if (_SchoolClass.NextYrLevel != null)
                {
                    txtNextYearLevel.Text = _SchoolClass.NextYrLevel.ToString();
                }
                if (_SchoolClass.Remarks != null)
                {
                    txtRemarks.Text = _SchoolClass.Remarks.Trim();
                }
                if (_SchoolClass.Status != null)
                {
                    cboStatus.SelectedValue = _SchoolClass.Status.Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        public void DisableControls()
        {

            txtShortCode.Enabled = false;
            txtClassName.Enabled = false;
            cboProgrammeYears.Enabled = false;
            txtNoOfSubjects.Enabled = false;
            cboClassTeacher.Enabled = false;
            txtCurrentYearLevel.Enabled = false;
            txtNextYearLevel.Enabled = false;
            txtRemarks.Enabled = false;
            dataGridViewClassSubject.Enabled = false; 
            btnAddClassSubject.Enabled = false;
            btnDeleteClassSubject.Enabled = false; 
            btnAddClassSubject.Enabled = false;
            lstClassStreams.Enabled = false;
            txtStreamDescription.Enabled = false;
            btnAddClassStreams.Enabled = false;
            btnEdit.Enabled = false;
            chkInActive.Enabled = false;
            btnDeleteClassStream.Enabled = false;
            cboStatus.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;
            
        }
        private void btnAddClassSubject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddClassSubjectForm acsf = new AddClassSubjectForm(_SchoolClass, connection) { Owner = this };
                acsf.ShowDialog();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private bool IsClassSubjectValid()
        {
            bool noerror = true;
             
            return noerror;
        }
        public void RefreshSubjectsGrid()
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceClassSubjects.DataSource = null;
                    var _ClssSbjcts = from cs in db.ClassSubjects
                                      where cs.ClassId == _SchoolClass.Id
                                      where cs.IsDeleted ==false 
                                      select cs;
                    List<ClassSubject> _ClassSubjects = _ClssSbjcts.ToList();
                    bindingSourceClassSubjects.DataSource = _ClassSubjects;
                    groupBox6.Text = bindingSourceClassSubjects.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewClassSubject.Rows)
                    {
                        dataGridViewClassSubject.Rows[dataGridViewClassSubject.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewClassSubject.Rows.Count - 1;
                        bindingSourceClassSubjects.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceClassSubjects.DataSource = null;
                    var _ClssSbjcts = from cs in db.ClassSubjects
                                      where cs.ClassId == _SchoolClass.Id
                                      where cs.Status == "A"
                                      where cs.IsDeleted == false 
                                      select cs;
                    List<ClassSubject> _ClassSubjects = _ClssSbjcts.ToList();
                    bindingSourceClassSubjects.DataSource = _ClassSubjects;
                    groupBox6.Text = bindingSourceClassSubjects.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewClassSubject.Rows)
                    {
                        dataGridViewClassSubject.Rows[dataGridViewClassSubject.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewClassSubject.Rows.Count - 1;
                        bindingSourceClassSubjects.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private bool IsClassStreamValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtStreamDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtStreamDescription, "Description cannot be null!");
                return false;
            }
            return noerror;
        }
        private void btnAddClassStream_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsClassStreamValid())
            {
                try
                {
                    ClassStream scs = new ClassStream();
                    scs.ClassId = _SchoolClass.Id;
                    scs. Description = Utils.ConvertFirstLetterToUpper(txtStreamDescription.Text.Trim());
                    scs.IsDeleted =false;

                    if (db.ClassStreams.Any(i => i.Description == scs.Description && i.ClassId == scs.ClassId && i.IsDeleted == false))
                    {
                        MessageBox.Show("Stream " + scs.Description + " Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.ClassStreams.Any(i => i.Description == scs.Description && i.ClassId == scs.ClassId && i.IsDeleted == false))
                    {
                        db.ClassStreams.AddObject(scs);
                        db.SaveChanges();

                        RefreshStreamsGrid();

                        txtStreamDescription.Text = string.Empty;
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void RefreshStreamsGrid()
        {
            try
            { 
                bindingSourceClassStreams.DataSource = null;
                var classstreamsquey = from cls in db.ClassStreams
                                       where cls.ClassId == _SchoolClass.Id
                                       where cls.IsDeleted ==false
                                       select cls;
                bindingSourceClassStreams.DataSource = classstreamsquey;
                groupBox4.Text = bindingSourceClassStreams.Count.ToString();
                groupBox6.Text = bindingSourceClassSubjects.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewClassSubject.Rows)
                {
                    dataGridViewClassSubject.Rows[dataGridViewClassSubject.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewClassSubject.Rows.Count - 1;
                    bindingSourceClassSubjects.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeleteClassSubject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewClassSubject.SelectedRows.Count != 0)
            {

                try
                {
                    ClassSubject _ClassSubject = (ClassSubject)bindingSourceClassSubjects.Current;

                    var _subjectquery = (from sb in db.Subjects
                                         join cs in db.ClassSubjects on sb.ShortCode equals cs.SubjectCode
                                         where cs.Id == _ClassSubject.Id
                                         where sb.IsDeleted == false
                                         where sb.Status == "A"
                                         where cs.IsDeleted == false 
                                         select sb).FirstOrDefault();

                     var _examsquery = from cs in db.Exams 
                                              where cs.IsDeleted == false 
                                              select cs;
                     List<Exam> _exams = _examsquery.ToList();

                     if (_exams.Count > 0)
                    {
                        MessageBox.Show("There is an Exam Associated with this Class Subject.\n Delete the Exam First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Class Subject\n" + _subjectquery.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteClassSubject(_ClassSubject);
                            RefreshSubjectsGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDeleteClassStream_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lstClassStreams.SelectedIndex != -1)
            {
                try
                {
                    ClassStream classstream = (ClassStream)lstClassStreams.SelectedItem;

                    var _Studentsquery = from sc in db.Students
                                         where sc.IsDeleted==false
                                         where sc.Status=="A"
                                         where sc.ClassStreamId == classstream.Id 
                                         select sc;
                    List<Student> _Students = _Studentsquery.ToList();

                    if (_Students.Count > 0)
                    {
                        MessageBox.Show("There is a Student Associated with this Stream.\n Delete the Student First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Stream \n" + classstream.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteClassStream(classstream);
                            RefreshStreamsGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void txtCurrentYearLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtCurrentYearLevel_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNextYearLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtNextYearLevel_KeyDown(object sender, KeyEventArgs e)
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
        private void txtNoOfSubjects_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtNoOfSubjects_KeyDown(object sender, KeyEventArgs e)
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
        private void dataGridViewClassSubject_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
            if (dataGridViewClassSubject.SelectedRows.Count != 0)
            {

                try
                {
                    ClassSubject _ClassSubject = (ClassSubject)bindingSourceClassSubjects.Current;

                    EditClassSubjectForm acsf = new EditClassSubjectForm(_ClassSubject, _SchoolClass, connection) { Owner = this };
                    acsf.Text = _ClassSubject.Subject.Description.ToUpper();
                    acsf.ShowDialog(); 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void dataGridViewClassSubject_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewClassSubject.SelectedRows.Count != 0)
            {

                try
                {
                    ClassSubject _ClassSubject = (ClassSubject)bindingSourceClassSubjects.Current;
                  
                    EditClassSubjectForm acsf = new EditClassSubjectForm(_ClassSubject, _SchoolClass, connection) { Owner = this };
                    acsf.Text = _ClassSubject.Subject.Description.ToUpper();
                    acsf.ShowDialog(); 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceClassSubjects.DataSource = null;
                    var _ClssSbjcts = from cs in db.ClassSubjects
                                      where cs.ClassId == _SchoolClass.Id 
                                      where cs.IsDeleted==false
                                      select cs;
                    List<ClassSubject> _ClassSubjects = _ClssSbjcts.ToList();
                    bindingSourceClassSubjects.DataSource = _ClassSubjects;
                    groupBox6.Text = bindingSourceClassSubjects.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewClassSubject.Rows)
                    {
                        dataGridViewClassSubject.Rows[dataGridViewClassSubject.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewClassSubject.Rows.Count - 1;
                        bindingSourceClassSubjects.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceClassSubjects.DataSource = null;
                    var _ClssSbjcts = from cs in db.ClassSubjects
                                      where cs.ClassId == _SchoolClass.Id
                                      where cs.Status =="A"
                                      where cs.IsDeleted == false
                                      select cs;
                    List<ClassSubject> _ClassSubjects = _ClssSbjcts.ToList();
                    bindingSourceClassSubjects.DataSource = _ClassSubjects;
                    groupBox6.Text = bindingSourceClassSubjects.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewClassSubject.Rows)
                    {
                        dataGridViewClassSubject.Rows[dataGridViewClassSubject.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewClassSubject.Rows.Count - 1;
                        bindingSourceClassSubjects.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        
         
    }
}