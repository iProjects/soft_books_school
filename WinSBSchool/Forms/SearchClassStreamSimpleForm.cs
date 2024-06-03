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
    public partial class SearchClassStreamSimpleForm : Form
    {

        SBSchoolDBEntities db;
        string connection;
        IQueryable<ClassStream> _ClassStreams;
        //delegate
        public delegate void ClassStreamSelectHandler(object sender, ClassStreamSelectEventArgs e);
        //event
        public event ClassStreamSelectHandler OnClassStreamListSelected;

        public SearchClassStreamSimpleForm(string Conn)
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
            if (dataGridViewClassStreams.SelectedRows.Count != 0)
            {
                try
                {
                    ClassStream selectedStudent = (ClassStream)bindingSourceClassStreams.Current;
                    OnClassStreamListSelected(this,
                        new ClassStreamSelectEventArgs(selectedStudent));

                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void SearchClassStreamSimpleForm_Load(object sender, EventArgs e)
        {
            try
            {

                var _SchlClsss = (from sc in db.SchoolClasses
                                  select sc);
                List<SchoolClass> _SchoolClasses = _SchlClsss.ToList();

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
                colCboxSchoolClass.Width = 200;
                colCboxSchoolClass.DisplayIndex = 2;
                colCboxSchoolClass.MinimumWidth = 200;
                colCboxSchoolClass.FlatStyle = FlatStyle.Flat;
                colCboxSchoolClass.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxSchoolClass.ReadOnly = true; 
                colCboxSchoolClass.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
                if (!this.dataGridViewClassStreams.Columns.Contains("cbSchoolClass"))
                {
                    dataGridViewClassStreams.Columns.Add(colCboxSchoolClass);
                }

                dataGridViewClassStreams.AutoGenerateColumns = false;
                this.dataGridViewClassStreams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewClassStreams.DataSource = bindingSourceClassStreams;

                _ClassStreams = db.ClassStreams;

                AutoCompleteStringCollection acscsrtm = new AutoCompleteStringCollection();
                acscsrtm.AddRange(this.AutoComplete_Description());
                txtStreamDescription.AutoCompleteCustomSource = acscsrtm;
                txtStreamDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtStreamDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsccls = new AutoCompleteStringCollection();
                acsccls.AddRange(this.AutoComplete_Classes());
                txtClass.AutoCompleteCustomSource = acsccls;
                txtClass.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtClass.AutoCompleteSource =
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
                var streamdescriptionquery = from cs in db.ClassStreams
                                        select cs.Description;
                return streamdescriptionquery.ToArray();
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
                var filter = CreateFilter(_ClassStreams);
                // set the filter
                this.bindingSourceClassStreams.DataSource = filter;
                groupBox1.Text = bindingSourceClassStreams.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<ClassStream> CreateFilter(IQueryable<ClassStream> _classStreams)
        {
            //none
            if (string.IsNullOrEmpty(txtClass.Text)
                && string.IsNullOrEmpty(txtStreamDescription.Text))
            {
                return _classStreams;
            }
            //all
            if (!string.IsNullOrEmpty(txtClass.Text)
                 && !string.IsNullOrEmpty(txtStreamDescription.Text))
            {
                _classStreams = null;
                string _Description = txtStreamDescription.Text;
                string _Class = txtClass.Text;
                _classStreams = from cs in db.ClassStreams
                                where cs.Description.StartsWith(_Description)
                                join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                                where sc.ClassName.StartsWith(_Class)
                                select cs;
                return _classStreams;
            }
            //description
            if (string.IsNullOrEmpty(txtClass.Text)
                 && !string.IsNullOrEmpty(txtStreamDescription.Text))
            {
                _classStreams = null;
                string _Description = txtStreamDescription.Text; 
                _classStreams = from cs in db.ClassStreams
                                where cs.Description.StartsWith(_Description) 
                                select cs;
                return _classStreams;
            }
            //class
            if (!string.IsNullOrEmpty(txtClass.Text)
                 && string.IsNullOrEmpty(txtStreamDescription.Text))
            {
                _classStreams = null;
                string _Class = txtClass.Text;
                _classStreams = from cs in db.ClassStreams 
                                join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                                where sc.ClassName.StartsWith(_Class)
                                select cs;
                return _classStreams;
            }    
            return _classStreams;
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
        private void txtStreamDescription_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtStreamDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void dataGridViewClassStreams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewClassStreams.SelectedRows.Count != 0)
            {

                try
                {
                    ClassStream selectedStudent = (ClassStream)bindingSourceClassStreams.Current;
                    OnClassStreamListSelected(this,
                        new ClassStreamSelectEventArgs(selectedStudent));

                    this.Close();
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
                Utils.LogEventViewer(e.Exception);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

    }


    public class ClassStreamSelectEventArgs : System.EventArgs
    {
        // add local member variables to hold text        
        private ClassStream classstream;

        // class constructor
        public ClassStreamSelectEventArgs(ClassStream _classstream)
        {

            this.classstream = _classstream;
        }

        // public Property Viewable by each listener        
        public ClassStream _ClassStream
        {
            get
            {
                return classstream;
            }
        }
    }

}