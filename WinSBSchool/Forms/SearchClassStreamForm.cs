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
    public partial class SearchClassStreamForm : Form
    {
        string connection;
        SBSchoolDBEntities db;
        Repository rep;
        static int index;
        List<Field> ClassStreamFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<ClassStream> _ClassStreams;
        //delegate
        public delegate void ClassStreamSelectHandler(object sender, ClassStreamSelectEventArgs e);
        //event
        public event ClassStreamSelectHandler OnClassStreamListSelected;



        public SearchClassStreamForm(string Conn)
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
            if (dataGridViewClassStreams.SelectedRows.Count > 0)
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
        private void SearchClassStreamForm_Load(object sender, EventArgs e)
        {
            try
            {
                ClassStreamFields.Add(new Field("classname", "string"));
                ClassStreamFields.Add(new Field("description", "string"));

                cbField.DataSource = ClassStreamFields;
                cbField.DisplayMember = "Name";
                cbField.ValueMember = "Name";

                cbOperator.DataSource = Op.GetList();
                cbOperator.DisplayMember = "Description";
                cbOperator.ValueMember = "Symbol";
                 
                lstCriteria.DataSource = criteriaBuilder.CriterionItemList(); 


                var _SchlClsss = (from sc in db.SchoolClasses
                                    select sc);
                List<SchoolClass> _SchoolClasses = _SchlClsss.ToList();
                bindingSourceSchoolClass.DataSource = _SchoolClasses;

                DataGridViewComboBoxColumn colCboxSchoolClass = new DataGridViewComboBoxColumn();
                colCboxSchoolClass.HeaderText = "ClassName";
                colCboxSchoolClass.Name = "cbSchoolClass";
                colCboxSchoolClass.DataSource = bindingSourceSchoolClass;
                // The display member is the name column in the column datasource  
                colCboxSchoolClass.DisplayMember = "ClassName";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxSchoolClass.DataPropertyName = "ClassId";
                // The value member is the primary key of the parent table  
                colCboxSchoolClass.ValueMember = "Id";
                colCboxSchoolClass.MaxDropDownItems = 10;
                colCboxSchoolClass.Width = 200;
                colCboxSchoolClass.DisplayIndex = 0;
                colCboxSchoolClass.MinimumWidth = 200;
                colCboxSchoolClass.FlatStyle = FlatStyle.Flat;
                colCboxSchoolClass.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxSchoolClass.ReadOnly = true; 
                if (!this.dataGridViewClassStreams.Columns.Contains("cbSchoolClass"))
                {
                    dataGridViewClassStreams.Columns.Add(colCboxSchoolClass);
                }

                dataGridViewClassStreams.AutoGenerateColumns = false;
                this.dataGridViewClassStreams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewClassStreams.DataSource = bindingSourceClassStreams;

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
            _ClassStreams = rep.GetClassStreamsFromCriteria(criteriaBuilder.CriterionItemList());
            bindingSourceClassStreams.DataSource = _ClassStreams;
            groupBoxResults.Text = _ClassStreams.Count.ToString();
            
        }

        private void dataGridViewClassStreams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewClassStreams.SelectedRows.Count != 0)
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

        private void dataGridViewClassStreams_DataError(object sender, DataGridViewDataErrorEventArgs e)
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