using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using GL.DAL;

namespace WinSBSchool.Forms
{
    public partial class SimpleSearchExamsForm : Form
    {
         SBSchoolDBEntities db;
        string connection;
        IQueryable<Exam> _Exams;
        //delegate
        public delegate void ExamSelectHandler(object sender, ExamSelectEventArgs e);
        //event
        public event ExamSelectHandler OnExamListSelected;

        public SimpleSearchExamsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            _Exams = from ex in db.Exams
                       select ex;
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {

                try
                {
                    Exam selectedExamPeriod = (Exam)bindingSourceExams.Current;
                    OnExamListSelected(this, new ExamSelectEventArgs(selectedExamPeriod));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void SearchExamForm_Load(object sender, EventArgs e)
        {
            try
            { 
                dataGridViewExams.AutoGenerateColumns = false;
                this.dataGridViewExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExams.DataSource = bindingSourceExams;
                 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        // apply the filter
        private void ApplyFilter()
        {

            _Exams = db.Exams;
            var filter = CreateFilter(_Exams);
            // set the filter
            this.bindingSourceExams.DataSource = filter;
        }
        private IQueryable<Exam> CreateFilter(IQueryable<Exam> student)
        {
            if (string.IsNullOrEmpty(txtSubjectCode.Text)
                && string.IsNullOrEmpty(txtExamPeriodId.Text) && string.IsNullOrEmpty(txtClassId.Text))
            {
                return _Exams;
            } 
            //Year
            if (!string.IsNullOrEmpty(txtSubjectCode.Text))
            {
                string yr = txtSubjectCode.Text;
                _Exams = _Exams.Where(a => a.SubjectShortCode == yr);
            } 
            //Term
            if (!string.IsNullOrEmpty(txtExamPeriodId.Text))
            {
                int trm = int.Parse(txtExamPeriodId.Text);
                _Exams = _Exams.Where(a => a.ExamPeriodId == trm); 
            } 
            //Description
            if (!string.IsNullOrEmpty(txtClassId.Text))
            {
                int trm = int.Parse(txtClassId.Text);
                _Exams = _Exams.Where(a => a.ClassId == trm); 
            }
            return _Exams;
        }
        private void txtYear_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtTerm_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtDescription_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }

        private void dataGridViewExams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count != 0)
            {

                try
                {
                    Exam selectedExamPeriod = (Exam)bindingSourceExams.Current;
                    OnExamListSelected(this, new ExamSelectEventArgs(selectedExamPeriod));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void dataGridViewExamPeriods_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
