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
    public partial class SearchExamPeriodForm : Form
    {
        string connection;
        Repository rep;
        static int index;
        List<Field> ExamPeriodFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<ExamPeriod> _ExamPeriods;
        SBSchoolDBEntities db;
        //delegate
        public delegate void ExamPeriodSelectHandler(object sender, ExamPeriodSelectEventArgs e);
        //event
        public event ExamPeriodSelectHandler OnExamPeriodListSelected; 

        public SearchExamPeriodForm(string Conn)
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
            if (dataGridViewExamPeriods.SelectedRows.Count > 0)
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
        private void SearchExamPeriodForm_Load(object sender, EventArgs e)
        {
            try
            {
                ExamPeriodFields.Add(new Field("year", "string"));
                ExamPeriodFields.Add(new Field("term", "string"));
                ExamPeriodFields.Add(new Field("description", "string"));
                ExamPeriodFields.Add(new Field("status", "string"));

                cbField.DataSource = ExamPeriodFields;
                cbField.DisplayMember = "Name";
                cbField.ValueMember = "Name";

                cbOperator.DataSource = Op.GetList();
                cbOperator.DisplayMember = "Description";
                cbOperator.ValueMember = "Symbol";

                lstCriteria.DataSource = criteriaBuilder.CriterionItemList();
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
            _ExamPeriods = rep.GetExamPeriodsFromCriteria(criteriaBuilder.CriterionItemList());
            bindingSourceExamPeriods.DataSource = _ExamPeriods;
            this.dataGridViewExamPeriods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewExamPeriods.AutoGenerateColumns = false;
            dataGridViewExamPeriods.DataSource = bindingSourceExamPeriods;
            groupBoxResults.Text = _ExamPeriods.Count.ToString();
        }

        private void dataGridViewExamPeriods_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExamPeriods.SelectedRows.Count > 0)
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


    public class ExamPeriodSelectEventArgs : System.EventArgs
    {

        // add local member variables to hold text        
        private ExamPeriod _examPeriod;

        // class constructor
        public ExamPeriodSelectEventArgs(ExamPeriod _examPeriods)
        {
            this._examPeriod = _examPeriods;
        }

        // Properties - Viewable by each listener        
        public ExamPeriod _ExamPeriod
        {
            get
            {
                return _examPeriod;
            }
        }
    }


}
