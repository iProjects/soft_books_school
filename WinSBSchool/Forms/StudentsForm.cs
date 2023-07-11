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
    public partial class StudentsForm : Form
    {

        SBSchoolDBEntities db;
        Repository rep;
        string connection;
        IQueryable<Student> _students;
        string user;

        public StudentsForm(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            user = _user;
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var _defaultSchoolquery = (from sub in db.Schools
                                           where sub.DefaultSchool == true
                                           where sub.IsDeleted == false
                                           where sub.Status == "A"
                                           select sub).FirstOrDefault();
                School _defaultSchool = _defaultSchoolquery;
                if (_defaultSchool == null)
                {
                    MessageBox.Show("No Default School is Set!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (_defaultSchool != null)
                {
                    Forms.AddStudentForm asf = new Forms.AddStudentForm(connection) { Owner = this };
                    asf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void StudentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                bindingSourceClassStreams.DataSource = db.ClassStreams.Where(i => i.IsDeleted == false);
                DataGridViewComboBoxColumn colCboxCurrentClass = new DataGridViewComboBoxColumn();
                colCboxCurrentClass.HeaderText = "Stream";
                colCboxCurrentClass.Name = "cbCurrentClass";
                colCboxCurrentClass.DataSource = bindingSourceClassStreams;
                // The display member is the name column in the column datasource  
                colCboxCurrentClass.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxCurrentClass.DataPropertyName = "ClassStreamId";
                // The value member is the primary key of the parent table  
                colCboxCurrentClass.ValueMember = "Id";
                colCboxCurrentClass.MaxDropDownItems = 10;
                colCboxCurrentClass.Width = 80;
                colCboxCurrentClass.DisplayIndex = 4;
                colCboxCurrentClass.MinimumWidth = 5;
                colCboxCurrentClass.FlatStyle = FlatStyle.Flat;
                colCboxCurrentClass.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxCurrentClass.ReadOnly = true;
                if (!this.dataGridViewStudents.Columns.Contains("cbCurrentClass"))
                {
                    dataGridViewStudents.Columns.Add(colCboxCurrentClass);
                }

                var gender = new BindingList<KeyValuePair<string, string>>();
                gender.Add(new KeyValuePair<string, string>("M", "Male"));
                gender.Add(new KeyValuePair<string, string>("F", "Female"));
                DataGridViewComboBoxColumn colCboxGender = new DataGridViewComboBoxColumn();
                colCboxGender.HeaderText = "Gender";
                colCboxGender.Name = "cbGender";
                colCboxGender.DataSource = gender;
                // The display member is the name column in the column datasource  
                colCboxGender.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxGender.DataPropertyName = "Gender";
                // The value member is the primary key of the parent table  
                colCboxGender.ValueMember = "Key";
                colCboxGender.MaxDropDownItems = 10;
                colCboxGender.Width = 80;
                colCboxGender.DisplayIndex = 7;
                colCboxGender.MinimumWidth = 5;
                colCboxGender.FlatStyle = FlatStyle.Flat;
                colCboxGender.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxGender.ReadOnly = true;
                if (!this.dataGridViewStudents.Columns.Contains("cbGender"))
                {
                    dataGridViewStudents.Columns.Add(colCboxGender);
                }

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                DataGridViewComboBoxColumn colCboxStatus = new DataGridViewComboBoxColumn();
                colCboxStatus.HeaderText = "Status";
                colCboxStatus.Name = "cbStatus";
                colCboxStatus.DataSource = status;
                // The display member is the name column in the column datasource  
                colCboxStatus.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxStatus.DataPropertyName = "Status";
                // The value member is the primary key of the parent table  
                colCboxStatus.ValueMember = "Key";
                colCboxStatus.MaxDropDownItems = 10;
                colCboxStatus.Width = 80;
                colCboxStatus.DisplayIndex = 8;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true;
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewStudents.Columns.Contains("cbStatus"))
                {
                    dataGridViewStudents.Columns.Add(colCboxStatus);
                }

                _students = from s in db.Students
                            where s.Status == "A"
                            where s.IsDeleted == false
                            select s;
                bindingSourceStudents.DataSource = _students;
                dataGridViewStudents.AutoGenerateColumns = false;
                this.dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewStudents.DataSource = bindingSourceStudents;
                groupBox2.Text = bindingSourceStudents.Count.ToString();

                AutoCompleteStringCollection acscadm = new AutoCompleteStringCollection();
                acscadm.AddRange(this.AutoComplete_AdminNos());
                txtAdminNo.AutoCompleteCustomSource = acscadm;
                txtAdminNo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAdminNo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscsrnm = new AutoCompleteStringCollection();
                acscsrnm.AddRange(this.AutoComplete_Surnames());
                txtSurname.AutoCompleteCustomSource = acscsrnm;
                txtSurname.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtSurname.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscsrtm = new AutoCompleteStringCollection();
                acscsrtm.AddRange(this.AutoComplete_Streams());
                txtStream.AutoCompleteCustomSource = acscsrtm;
                txtStream.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtStream.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsccls = new AutoCompleteStringCollection();
                acsccls.AddRange(this.AutoComplete_Classes());
                txtClass.AutoCompleteCustomSource = acsccls;
                txtClass.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtClass.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscothrnms = new AutoCompleteStringCollection();
                acscothrnms.AddRange(this.AutoComplete_OtherNames());
                txtOtherNames.AutoCompleteCustomSource = acscothrnms;
                txtOtherNames.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtOtherNames.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_AdminNos()
        {
            try
            {
                var adminnosquery = from st in db.Students
                                    where st.Status == "A"
                                    where st.IsDeleted == false
                                    select st.AdminNo;
                return adminnosquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Surnames()
        {
            try
            {
                var surnamesquery = from st in db.Students
                                    where st.Status == "A"
                                    where st.IsDeleted == false
                                    select st.StudentSurName;
                return surnamesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_OtherNames()
        {
            try
            {
                var surnamesquery = from st in db.Students
                                    where st.Status == "A"
                                    where st.IsDeleted == false
                                    select st.StudentOtherNames;
                return surnamesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Streams()
        {
            try
            {
                var classstreamsquery = from cs in db.ClassStreams
                                        where cs.IsDeleted == false
                                        select cs.Description;
                return classstreamsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Classes()
        {
            try
            {
                var classesquery = from sc in db.SchoolClasses
                                   where sc.IsDeleted == false
                                   select sc.ClassName;
                return classesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public void RefreshGrid()
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceStudents.DataSource = null;
                    var _studentsquery = from st in db.Students
                                         where st.IsDeleted == false
                                         select st;
                    bindingSourceStudents.DataSource = _studentsquery.ToList();
                    groupBox2.Text = bindingSourceStudents.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                    {
                        dataGridViewStudents.Rows[dataGridViewStudents.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudents.Rows.Count - 1;
                        bindingSourceStudents.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceStudents.DataSource = null;
                    var _studentsquery = from st in db.Students
                                         where st.Status == "A"
                                         where st.IsDeleted == false
                                         select st;
                    bindingSourceStudents.DataSource = _studentsquery.ToList();
                    groupBox2.Text = _studentsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                    {
                        dataGridViewStudents.Rows[dataGridViewStudents.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudents.Rows.Count - 1;
                        bindingSourceStudents.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.Student student = (DAL.Student)bindingSourceStudents.Current;
                    Forms.EditStudentForm es = new Forms.EditStudentForm(student, user, connection) { Owner = this };
                    es.Text = student.StudentOtherNames.ToUpper().Trim() + " " + student.StudentSurName.ToUpper().Trim();
                    es.ShowDialog();
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

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.Student student = (DAL.Student)bindingSourceStudents.Current;

                    var rgdclssbjt = from sub in db.Accounts
                                     where sub.IsDeleted == false
                                     where sub.Closed == false
                                     where sub.CustomerId == student.Id
                                     select sub.CustomerId;

                    List<int> clsSubjects = rgdclssbjt.ToList();

                    var _StudentCustomerquery = from cs in db.Customers
                                                where cs.Status == "A"
                                                where cs.IsDeleted == false
                                                where cs.StudentId == student.Id
                                                select cs;
                    List<Customer> _StudentCustomer = _StudentCustomerquery.ToList();

                    if (clsSubjects.Count > 0)
                    {
                        MessageBox.Show("There is an  Account Associated with this Student.\n Close the Account First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_StudentCustomer.Count > 0)
                    {
                        MessageBox.Show("There is a Customer  Associated with this Student.\n Delete the Customer First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Student\n" + student.StudentSurName.ToString().Trim().ToUpper() + student.StudentOtherNames.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteStudent(student);
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
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.Student student = (DAL.Student)bindingSourceStudents.Current;
                    Forms.EditStudentForm es = new Forms.EditStudentForm(student, user, connection) { Owner = this };
                    es.DisableControls();
                    es.Text = student.StudentOtherNames.ToUpper().Trim() + " " + student.StudentSurName.ToUpper().Trim();
                    es.ShowDialog();
                }

                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewStudents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.Student student = (DAL.Student)bindingSourceStudents.Current;
                    Forms.EditStudentForm es = new Forms.EditStudentForm(student, user, connection) { Owner = this };
                    es.Text = student.StudentOtherNames.ToUpper().Trim() + " " + student.StudentSurName.ToUpper().Trim();
                    es.ShowDialog();
                }

                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        // apply the filter
        private void ApplyFilter()
        {
            try
            {
                var filter = CreateFilter(_students);
                // set the filter
                this.bindingSourceStudents.DataSource = filter;
                groupBox2.Text = filter.Count().ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<Student> CreateFilter(IQueryable<Student> _students)
        {
            //none
            if (string.IsNullOrEmpty(txtAdminNo.Text)
                && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                return _students;
            }
            //all
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
               && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Stream = txtStream.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
               && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            select st;
                return _students;
            }
            //surname  
            if (string.IsNullOrEmpty(txtAdminNo.Text)
               && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            select st;
                return _students;
            }
            //othernames  
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _OtherNames = txtOtherNames.Text;
                _students = from st in db.Students
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            select st;
                return _students;
            }
            //stream
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and surname
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and othernames
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
               && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _OtherNames = txtOtherNames.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and stream
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //surname and othernames
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                string _OtherNames = txtOtherNames.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            select st;
                return _students;
            }
            //surname and stream
            if (string.IsNullOrEmpty(txtAdminNo.Text)
               && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //surname and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
               && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //othernames and stream
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _OtherNames = txtOtherNames.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //othernames and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _OtherNames = txtOtherNames.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //stream and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Stream = txtStream.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and surname and othernames
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                string _OtherNames = txtOtherNames.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and surname and stream
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and surname and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
               && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and othernames and stream
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
               && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and othernames and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
               && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //adminno and stream and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
               && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Stream = txtStream.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //surname and othernames and stream
            if (string.IsNullOrEmpty(txtAdminNo.Text)
               && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //surname and othernames and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //surname and stream and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                string _Stream = txtStream.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //othernames and stream and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _OtherNames = txtOtherNames.Text;
                string _Stream = txtStream.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //admino and surname and othernames and stream
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //admino and surname and othernames and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //surname and othernames and stream and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Stream = txtStream.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //admino and surname and stream and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                string _Stream = txtStream.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            //admino and othernames and stream and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
              && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtOtherNames.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _OtherNames = txtOtherNames.Text;
                string _Stream = txtStream.Text;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentOtherNames.StartsWith(_OtherNames)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
                            where st.IsDeleted == false
                            where sc.IsDeleted == false
                            where cs.IsDeleted == false
                            select st;
                return _students;
            }
            return _students;
        }
        private void txtAdminNo_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtAdminNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtSurname_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtClass_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtStream_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtStream_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceStudents.DataSource = null;
                    var _studentsquery = from st in db.Students
                                         where st.IsDeleted == false
                                         select st;
                    bindingSourceStudents.DataSource = _studentsquery.ToList();
                    groupBox2.Text = _studentsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                    {
                        dataGridViewStudents.Rows[dataGridViewStudents.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudents.Rows.Count - 1;
                        bindingSourceStudents.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceStudents.DataSource = null;
                    var _studentsquery = from st in db.Students
                                         where st.Status == "A"
                                         where st.IsDeleted == false
                                         select st;
                    bindingSourceStudents.DataSource = _studentsquery.ToList();
                    groupBox2.Text = _studentsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                    {
                        dataGridViewStudents.Rows[dataGridViewStudents.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudents.Rows.Count - 1;
                        bindingSourceStudents.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchStudentsForm saf = new Forms.SearchStudentsForm(connection) { Owner = this };
                saf.OnStudentsListSelected += new SearchStudentsForm.StudentsSelectHandler(saf_OnStudentsListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnStudentsListSelected(object sender, StudentsSelectEventArgs e)
        {
            SetStudent(e._Student);
        }
        private void SetStudent(Student _Student)
        {
            if (_Student != null)
            {
                bindingSourceStudents.DataSource = _Student;
                groupBox2.Text = bindingSourceStudents.Count.ToString();
            } 
        }
        public void CloseForm()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            { 
                Utils.ShowError(ex); 
            }
        }
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceStudents.DataSource = null;
                    var _studentsquery = from st in db.Students
                                         where st.IsDeleted == false
                                         select st;
                    bindingSourceStudents.DataSource = _studentsquery.ToList();
                    groupBox2.Text = _studentsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                    {
                        dataGridViewStudents.Rows[dataGridViewStudents.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudents.Rows.Count - 1;
                        bindingSourceStudents.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceStudents.DataSource = null;
                    var _studentsquery = from st in db.Students
                                         where st.Status == "A"
                                         where st.IsDeleted == false
                                         select st;
                    bindingSourceStudents.DataSource = _studentsquery.ToList();
                    groupBox2.Text = _studentsquery.Count().ToString();
                    foreach (DataGridViewRow row in dataGridViewStudents.Rows)
                    {
                        dataGridViewStudents.Rows[dataGridViewStudents.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewStudents.Rows.Count - 1;
                        bindingSourceStudents.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewStudents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }















    }
}