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
    public partial class SearchExamsPeriodsForm : Form
    {

        SBSchoolDBEntities db;
        string connection;
        IQueryable<ExamPeriod> _ExamPeriod;
        //delegate
        public delegate void ExamPeriodSelectHandler(object sender, ExamPeriodSelectEventArgs e);
        //event
        public event ExamPeriodSelectHandler OnExamPeriodListSelected; 

        public SearchExamsPeriodsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            _ExamPeriod = from ex in db.ExamPeriods
                       select ex;
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewExamPeriods.SelectedRows.Count != 0)
            {

                try
                {
                    ExamPeriod selectedExamPeriod = (ExamPeriod)bindingSourceExamPeriods.Current;
                    OnExamPeriodListSelected(this, new ExamPeriodSelectEventArgs(selectedExamPeriod));

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
                dataGridViewExamPeriods.AutoGenerateColumns = false;
                this.dataGridViewExamPeriods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExamPeriods.DataSource = bindingSourceExamPeriods;
                 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        // apply the filter
        private void ApplyFilter()
        {
            
            _ExamPeriod = db.ExamPeriods;
            var filter = CreateFilter(_ExamPeriod);
            // set the filter
            this.bindingSourceExamPeriods.DataSource = filter;
        }
        private IQueryable<ExamPeriod> CreateFilter(IQueryable<ExamPeriod> student)
        {
            if (string.IsNullOrEmpty(txtYear.Text)
                && string.IsNullOrEmpty(txtTerm.Text) && string.IsNullOrEmpty(txtDescription.Text))
            {
                return _ExamPeriod;
            } 
            //Year
            if (!string.IsNullOrEmpty(txtYear.Text))
            {
                int yr = int.Parse(txtYear.Text);
                _ExamPeriod = _ExamPeriod.Where(a => a.Year== yr);
            } 
            //Term
            if (!string.IsNullOrEmpty(txtTerm.Text))
            {
                int trm = int.Parse(txtTerm.Text);
                _ExamPeriod = _ExamPeriod.Where(a => a.Term == trm); 
            } 
            //Description
            if (!string.IsNullOrEmpty(txtDescription.Text))
            {
                _ExamPeriod = _ExamPeriod.Where(a => a.Description.StartsWith(txtDescription.Text));
            }

            return _ExamPeriod;
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

        private void dataGridViewExamPeriods_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExamPeriods.SelectedRows.Count != 0)
            {

                try
                {
                    ExamPeriod selectedExamPeriod = (ExamPeriod)bindingSourceExamPeriods.Current;
                    OnExamPeriodListSelected(this, new ExamPeriodSelectEventArgs(selectedExamPeriod));

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
