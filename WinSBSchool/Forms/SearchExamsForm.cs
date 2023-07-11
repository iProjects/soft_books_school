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
    public partial class SearchExamsForm : Form
    {

        string connection;
        Repository rep;
        static int index;
        List<Field> ExamFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<Exam> _Exams;
        SBSchoolDBEntities db;
        //delegate
        public delegate void ExamSelectHandler(object sender, ExamSelectEventArgs e);
        //event
        public event ExamSelectHandler OnExamListSelected;

        public SearchExamsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count > 0)
            {

                try
                {
                    Exam selectedExam = (Exam)bindingSourceExams.Current;
                    OnExamListSelected(this, new ExamSelectEventArgs(selectedExam)); 
                    this.Close(); 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void SearchExamPeriodForm_Load(object sender, EventArgs e)
        {
            try
            {
                ExamFields.Add(new Field("subjectshortcode", "string"));
                ExamFields.Add(new Field("examperiod", "string"));
                ExamFields.Add(new Field("class", "string"));                 

                cbField.DataSource = ExamFields;
                cbField.DisplayMember = "Name";
                cbField.ValueMember = "Name";

                cbOperator.DataSource = Op.GetList();
                cbOperator.DisplayMember = "Description";
                cbOperator.ValueMember = "Symbol";

                lstCriteria.DataSource = criteriaBuilder.CriterionItemList();

                var ExamPeriodquery = from ep in db.ExamPeriods
                                      select ep;
                List<ExamPeriod> _ExamPeriods = ExamPeriodquery.ToList();
                DataGridViewComboBoxColumn colCboxExamPeriod = new DataGridViewComboBoxColumn();
                colCboxExamPeriod.HeaderText = "Exam Period";
                colCboxExamPeriod.Name = "cbExamPeriod";
                colCboxExamPeriod.DataSource = _ExamPeriods;
                // The display member is the name column in the column datasource  
                colCboxExamPeriod.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxExamPeriod.DataPropertyName = "ExamPeriodId";
                // The value member is the primary key of the parent table  
                colCboxExamPeriod.ValueMember = "Id";
                colCboxExamPeriod.MaxDropDownItems = 10;
                colCboxExamPeriod.Width = 100;
                colCboxExamPeriod.DisplayIndex = 1;
                colCboxExamPeriod.MinimumWidth = 5;
                colCboxExamPeriod.FlatStyle = FlatStyle.Flat;
                colCboxExamPeriod.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxExamPeriod.ReadOnly = true; 
                if (!this.dataGridViewExams.Columns.Contains("cbExamPeriod"))
                {
                    dataGridViewExams.Columns.Add(colCboxExamPeriod);
                }

                var SchoolClassesquery = from sc in db.SchoolClasses
                                      select sc;
                List<SchoolClass> _SchoolClasses = SchoolClassesquery.ToList();
                DataGridViewComboBoxColumn colCboxSchoolClass = new DataGridViewComboBoxColumn();
                colCboxSchoolClass.HeaderText = "Class";
                colCboxSchoolClass.Name = "cbSchoolClass";
                colCboxSchoolClass.DataSource = _SchoolClasses;
                // The display member is the name column in the column datasource  
                colCboxSchoolClass.DisplayMember = "ClassName";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxSchoolClass.DataPropertyName = "ClassId";
                // The value member is the primary key of the parent table  
                colCboxSchoolClass.ValueMember = "Id";
                colCboxSchoolClass.MaxDropDownItems = 10;
                colCboxSchoolClass.Width = 100;
                colCboxSchoolClass.DisplayIndex = 1;
                colCboxSchoolClass.MinimumWidth = 5;
                colCboxSchoolClass.FlatStyle = FlatStyle.Flat;
                colCboxSchoolClass.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxSchoolClass.ReadOnly = true; 
                if (!this.dataGridViewExams.Columns.Contains("cbSchoolClass"))
                {
                    dataGridViewExams.Columns.Add(colCboxSchoolClass);
                }

                var _subjectsquery = from et in db.Subjects
                                     select et;
                List<Subject> _Subjects = _subjectsquery.ToList();
                DataGridViewComboBoxColumn colCboxSubjects = new DataGridViewComboBoxColumn();
                colCboxSubjects.HeaderText = "Subject";
                colCboxSubjects.Name = "cbSubjects";
                colCboxSubjects.DataSource = _Subjects;
                // The display member is the name column in the column datasource  
                colCboxSubjects.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxSubjects.DataPropertyName = "SubjectShortCode";
                // The value member is the primary key of the parent table  
                colCboxSubjects.ValueMember = "ShortCode";
                colCboxSubjects.MaxDropDownItems = 10;
                colCboxSubjects.Width = 200;
                colCboxSubjects.DisplayIndex = 1;
                colCboxSubjects.MinimumWidth = 5;
                colCboxSubjects.FlatStyle = FlatStyle.Flat;
                colCboxSubjects.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxSubjects.ReadOnly = true; 
                if (!this.dataGridViewExams.Columns.Contains("cbSubjects"))
                {
                    dataGridViewExams.Columns.Add(colCboxSubjects);
                }

                this.dataGridViewExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExams.AutoGenerateColumns = false;
                dataGridViewExams.DataSource = bindingSourceExams;
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
            //get search results
            _Exams = rep.GetExamsFromCriteria(criteriaBuilder.CriterionItemList());
            bindingSourceExams.DataSource = _Exams;
            groupBoxResults.Text = _Exams.Count.ToString();
        }

        private void dataGridViewExams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count > 0)
            {

                try
                {
                    Exam selectedExam = (Exam)bindingSourceExams.Current;
                    OnExamListSelected(this, new ExamSelectEventArgs(selectedExam));
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void dataGridViewExams_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

    public class ExamSelectEventArgs : System.EventArgs
    { 
        // add local member variables to hold text        
        private Exam exam;

        // class constructor
        public ExamSelectEventArgs(Exam _exam)
        {
            this.exam = _exam;
        }

        // Properties - Viewable by each listener        
        public Exam _Exam
        {
            get
            {
                return exam;
            }
        }
    }
}
