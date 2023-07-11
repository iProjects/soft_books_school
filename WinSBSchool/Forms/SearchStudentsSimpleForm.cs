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
    public partial class SearchStudentsSimpleForm : Form
    {
        SBSchoolDBEntities db;
        string connection;
        IQueryable<Student> _students;
        //delegate
        public delegate void StudentsSelectHandler(object sender, StudentsSelectEventArgs e);
        //event
        public event StudentsSelectHandler OnStudentsListSelected;

        public SearchStudentsSimpleForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                try
                {
                    Student selectedStudent = (Student)bindingSourceStudents.Current;
                    OnStudentsListSelected(this,
                        new StudentsSelectEventArgs(selectedStudent));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        private void SearchStudentsSimpleForm_Load(object sender, EventArgs e)
        {
            try
            {

                bindingSourceClassStreams.DataSource = db.ClassStreams.Where(i=>i.IsDeleted==false);
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
                           where s.IsDeleted==false
                           select s;

                dataGridViewStudents.AutoGenerateColumns = false;
                this.dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewStudents.DataSource = bindingSourceStudents;

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

                txtAdminNo_Leave(sender, e);
                txtSurname_Leave(sender, e);
                txtStream_Leave(sender, e);
                txtClass_Leave(sender, e);

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
                                    where st.Status =="A"
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
                                   where sc.Status=="A"
                                   select sc.ClassName;
                return classesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
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
                groupBox1.Text = bindingSourceStudents.Count.ToString();
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
                && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                return _students;
            }
            //all
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
               && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
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
                            select st;
                return _students;
            }
            //adminno
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
                && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.Status == "A"
                            select st;
                return _students;
            }
            //adminno and surname
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
                && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Surname = txtSurname.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.Status == "A"
                            select st;
                return _students;
            }
            //adminno and surname and stream
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
                 && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
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
                            select st;
                return _students;
            }
            //adminno and stream
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
                 && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _AdminNo = txtAdminNo.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.AdminNo.StartsWith(_AdminNo)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            select st;
                return _students;
            }
            //adminno and stream and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
                 && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
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
                            select st;
                return _students;
            }
            //adminno and class
            if (!string.IsNullOrEmpty(txtAdminNo.Text)
                 && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
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
                            select st;
                return _students;
            }
            //surname  
            if (string.IsNullOrEmpty(txtAdminNo.Text)
                && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            where st.Status == "A"
                            select st;
                return _students;
            }
            //surname and stream
            if (string.IsNullOrEmpty(txtAdminNo.Text)
                && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Surname = txtSurname.Text;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            where st.StudentSurName.StartsWith(_Surname)
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            select st;
                return _students;
            }
            //surname and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
                && !string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
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
                            select st;
                return _students;
            }
            //surname and stream and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
                && !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
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
                            select st;
                return _students;
            }
            //stream
            if (string.IsNullOrEmpty(txtAdminNo.Text)
                && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtStream.Text) && string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Stream = txtStream.Text;
                _students = from st in db.Students
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            where cs.Description.StartsWith(_Stream)
                            where st.Status == "A"
                            select st;
                return _students;
            }
            //stream and class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
                && string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
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
                            select st;
                return _students;
            }
            //class
            if (string.IsNullOrEmpty(txtAdminNo.Text)
                 && string.IsNullOrEmpty(txtSurname.Text) && string.IsNullOrEmpty(txtStream.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                _students = null;
                string _Class = txtClass.Text;
                _students = from st in db.Students
                            join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                            join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                            where sc.ClassName.StartsWith(_Class)
                            where st.Status == "A"
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
        private void dataGridViewStudents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count != 0)
            {

                try
                {
                    Student selectedStudent = (Student)bindingSourceStudents.Current;
                    OnStudentsListSelected(this,
                        new StudentsSelectEventArgs(selectedStudent));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void dataGridViewCustomers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void txtAdminNo_Leave(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtSurname_Leave(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtStream_Leave(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtClass_Leave(object sender, EventArgs e)
        {
            ApplyFilter();
        }






    }
}