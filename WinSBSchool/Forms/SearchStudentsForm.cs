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
    public partial class SearchStudentsForm : Form
    {
        string connection;
        Repository rep;
        SBSchoolDBEntities db;
        static int index;
        List<Field> StudentFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<Student> _students;
        //delegate
        public delegate void StudentsSelectHandler(object sender, StudentsSelectEventArgs e);
        //event
        public event StudentsSelectHandler OnStudentsListSelected;


        public SearchStudentsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewStudents.SelectedRows.Count > 0)
                {
                    Student selectedStudent = (Student)bindingSourceStudents.Current;
                    OnStudentsListSelected(this,
                        new StudentsSelectEventArgs(selectedStudent));

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SearchStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                StudentFields.Add(new Field("surname", "string"));
                StudentFields.Add(new Field("othernames", "string"));
                StudentFields.Add(new Field("customerno", "string"));
                StudentFields.Add(new Field("phone", "string"));
                StudentFields.Add(new Field("classstream", "string"));

                cbField.DataSource = StudentFields;
                cbField.DisplayMember = "Name";
                cbField.ValueMember = "Name";

                cbOperator.DataSource = Op.GetList();
                cbOperator.DisplayMember = "Description";
                cbOperator.ValueMember = "Symbol";

                this.dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridViewStudents.AutoGenerateColumns = false;
                lstCriteria.DataSource = criteriaBuilder.CriterionItemList();


                var _ClassStreamsquery = from dc in db.ClassStreams
                                         select dc;
                List<ClassStream> _ClassStreams = _ClassStreamsquery.ToList();

                DataGridViewComboBoxColumn colClassStream = new DataGridViewComboBoxColumn();
                colClassStream.HeaderText = "Stream";
                colClassStream.Name = "cbClassStream";
                colClassStream.DataSource = _ClassStreams;
                colClassStream.DisplayMember = "Description";
                colClassStream.DataPropertyName = "CurrentClass";
                colClassStream.ValueMember = "Id";
                colClassStream.MaxDropDownItems = 10;
                colClassStream.DisplayIndex = 1;
                colClassStream.MinimumWidth = 5;
                colClassStream.Width = 80;
                colClassStream.FlatStyle = FlatStyle.Flat;
                colClassStream.DefaultCellStyle.NullValue = "--- Select ---";
                colClassStream.ReadOnly = true; 
                if (!this.dataGridViewStudents.Columns.Contains("cbClassStream"))
                {
                    dataGridViewStudents.Columns.Add(colClassStream);
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValue.Text))
            {
                CriterionItem cr = GetValidCriterionItem();
                if (cr != null)
                {
                    criteriaBuilder.AddCriterionItem(cr);
                    index++;
                }
                //refresh
                ListBoxRefresh();
            }
        }
        public void ListBoxRefresh()
        {
            lstCriteria.DataSource = null;
            lstCriteria.DataSource = criteriaBuilder.CriterionItemList();
        }
        private CriterionItem GetValidCriterionItem()
        {
            Field field = (Field)cbField.SelectedItem;
            Op Op = (Op)cbOperator.SelectedItem;
            string FValue = txtValue.Text;
            conjuction cj;
            string FieldType = field.Type;
            if (criteriaBuilder.IsFirstItem())
            {
                cj = conjuction.nil;
            }
            else
            {

                if (rbAnd.Checked)
                {
                    cj = conjuction.and;
                }
                else cj = conjuction.or;
            }
            switch (FieldType.ToLower())
            {
                case "string":
                    FValue = string.Format("{0}", FValue);
                    break;
                case "decimal":
                    decimal d;
                    if (!decimal.TryParse(FValue, out d))
                    {
                        lblMessage.Text = "Please enter a number in the field value";
                        return null;
                    }
                    break;
                case "date":
                    DateTime dd;
                    if (!DateTime.TryParse(FValue, out dd))
                    {
                        lblMessage.Text = "Please enter a date in the field value";
                        return null;
                    }
                    FValue = string.Format("{0}", FValue); //do a date format
                    break;
                case "like":
                    FValue = string.Format("{0}", FValue);
                    break;
            }
            //clean. no error
            Criterion cr = new Criterion(cj, field.Name, Op, FValue);
            return new CriterionItem("index" + index, cr);

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstCriteria.SelectedItem != null)
            {
                CriterionItem selCriterionItem = (CriterionItem)lstCriteria.SelectedValue;
                criteriaBuilder.Remove(selCriterionItem);

                //refresh
                ListBoxRefresh();
            }
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                _students = rep.GetStudentsFromCriteria(criteriaBuilder.CriterionItemList());
                bindingSourceStudents.DataSource = _students;
                dataGridViewStudents.AutoGenerateColumns = false;
                this.dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewStudents.DataSource = bindingSourceStudents;
                groupBoxResults.Text = _students.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewStudents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewStudents.SelectedRows.Count > 0)
                {
                    Student selectedStudent = (Student)bindingSourceStudents.Current;
                    OnStudentsListSelected(this,
                        new StudentsSelectEventArgs(selectedStudent));

                    this.Close();
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

    public class StudentsSelectEventArgs : System.EventArgs
    {
        // add local member variables to hold text 
        private Student _student;

        // class constructor
        public StudentsSelectEventArgs(Student student)
        {

            this._student = student;
        }

        // Properties - Viewable by each listener 
        public Student _Student
        {
            get
            {
                return _student;
            }
        }
    }
}
        