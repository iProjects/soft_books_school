using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class RegisterExamsForm : Form
    {

        Repository rep;
        SBSchoolDBEntities db;
        string user;
        ExamPeriod _ExamPeriod;
        string connection;
       List<ExamType> _ExamTypes;

        public RegisterExamsForm(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            user = _user;
            _ExamTypes = new List<ExamType>();
        } 
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        } 
        private void RegisterExamsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _schlclss = from sc in db.SchoolClasses
                                select sc;
                List<SchoolClass> _SchoolClasses = _schlclss.ToList();
                bindingSourceSchoolClasses.DataSource = _SchoolClasses;
                cboSchoolClass.DataSource = bindingSourceSchoolClasses;
                cboSchoolClass.ValueMember = "ClassId";
                cboSchoolClass.DisplayMember = "ClassName";  
                 
                var _rms = from rm in db.Rooms
                           select rm;
                List<Room> _Rooms = _rms.ToList();
                bindingSourceRooms.DataSource = _Rooms;
                DataGridViewComboBoxColumn colCboxRooms = new DataGridViewComboBoxColumn();
                colCboxRooms.HeaderText = "Rooms";
                colCboxRooms.Name = "cbRooms";
                colCboxRooms.DataSource = bindingSourceRooms;
                // The display member is the name column in the column datasource  
                colCboxRooms.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxRooms.DataPropertyName = "RoomId";
                // The value member is the primary key of the parent table  
                colCboxRooms.ValueMember = "RoomId";
                colCboxRooms.MaxDropDownItems = 10;
                colCboxRooms.Width = 200;
                colCboxRooms.DisplayIndex = 1;
                colCboxRooms.MinimumWidth = 5;
                colCboxRooms.FlatStyle = FlatStyle.Flat;
                colCboxRooms.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxRooms.ReadOnly = true; 
                if (!this.dataGridViewRegdExams.Columns.Contains("cbRooms"))
                {
                    dataGridViewRegdExams.Columns.Add(colCboxRooms);
                }


                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("O", "Open"));
                status.Add(new KeyValuePair<string, string>("C", "Close"));
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
                colCboxStatus.Width = 100;
                colCboxStatus.DisplayIndex = 2;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true; 
                if (!this.dataGridViewRegdExams.Columns.Contains("cbStatus"))
                {
                    dataGridViewRegdExams.Columns.Add(colCboxStatus);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void cboSchoolClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshGrid()
        {
            if (cboSchoolClass.SelectedIndex != -1 && _ExamPeriod != null)
            {
                try
                {
                    SchoolClass cls = (SchoolClass)cboSchoolClass.SelectedItem;

                    //var _RegisteredExamquery = from rgtd in db.RegisteredExams
                    //                           join exms in db.Exams on cls.ClassId equals exms.ClassId
                    //                           where exms.ExamPeriodId == _AllowedRoleMenus.ExamPeriodId

                    //                           where rgtd.ExamDetId == exms._ExamId
                    //                           select rgtd;


                    //List<RegisteredExam> _RegisteredExams = _RegisteredExamquery.ToList();
                    //var _exms = from exm in db.Exams
                    //            where exm.ClassId == cls.ClassId
                    //            where exm.ExamPeriodId == _AllowedRoleMenus.ExamPeriodId
                    //            select exm;
                    //List<ExamType> _Exams = _exms.ToList();

                    //bindingSourceExams.DataSource = _Exams;

                    DataGridViewComboBoxColumn colCboxExams = new DataGridViewComboBoxColumn();
                    colCboxExams.HeaderText = "Exam";
                    colCboxExams.Name = "cbExams";
                    colCboxExams.DataSource = bindingSourceExams;
                    // The display member is the name column in the column datasource  
                    colCboxExams.DisplayMember = "SubjectShortCode";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxExams.DataPropertyName = "ExamId";
                    // The value member is the primary key of the parent table  
                    colCboxExams.ValueMember = "ExamId";
                    colCboxExams.MaxDropDownItems = 10;
                    colCboxExams.Width = 100;
                    colCboxExams.DisplayIndex = 0;
                    colCboxExams.MinimumWidth = 5;
                    colCboxExams.FlatStyle = FlatStyle.Flat;
                    colCboxExams.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxExams.ReadOnly = true; 
                    if (!this.dataGridViewRegdExams.Columns.Contains("cbExams"))
                    {
                        dataGridViewRegdExams.Columns.Add(colCboxExams);
                    }

                    //var _ExamTypesquery = from et in db.ExamTypes
                    //                      join exm in db.Exams on cls.ClassId equals exm.ClassId
                    //                      where exm.ExamPeriodId == _AllowedRoleMenus.ExamPeriodId
                    //                      join ed in db.ExamDets on exm._ExamId equals ed._ExamId
                    //                      where et.Id == ed.ExamTypeId
                    //                      select et;
                    //List<ExamType> _Students = _ExamTypesquery.ToList();
                    //bindingSourceExamType.DataSource = _Students;
                    DataGridViewComboBoxColumn colCboxExamTypes = new DataGridViewComboBoxColumn();
                    colCboxExamTypes.HeaderText = "Exam Type";
                    colCboxExamTypes.Name = "cbExamTypes";
                    colCboxExamTypes.DataSource = bindingSourceExamType;
                    // The display member is the name column in the column datasource  
                    colCboxExamTypes.DisplayMember = "Description";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxExamTypes.DataPropertyName = "ExamTypeId";
                    // The value member is the primary key of the parent table  
                    colCboxExamTypes.ValueMember = "Id";
                    colCboxExamTypes.MaxDropDownItems = 10;
                    colCboxExamTypes.Width = 200;
                    colCboxExamTypes.DisplayIndex = 1;
                    colCboxExamTypes.MinimumWidth = 5;
                    colCboxExamTypes.FlatStyle = FlatStyle.Flat;
                    colCboxExamTypes.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxExamTypes.ReadOnly = true; 
                    if (!this.dataGridViewRegdExams.Columns.Contains("cbExamTypes"))
                    {
                        dataGridViewRegdExams.Columns.Add(colCboxExamTypes);
                    }

                    //bindingSourceRegdExams.DataSource = _RegisteredExams;
                    dataGridViewRegdExams.AutoGenerateColumns = false;
                    dataGridViewRegdExams.DataSource = bindingSourceRegdExams;
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }       
        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                MessageBox.Show("Succesfully saved");
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewRegdExams_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSelectExamPeriod_Click(object sender, EventArgs e)
        {
            SearchExamPeriodForm f = new SearchExamPeriodForm(connection) { Owner = this };
            f.OnExamPeriodListSelected += new SearchExamPeriodForm.ExamPeriodSelectHandler(f_OnExamPeriodListSelected);
            f.ShowDialog();
        }
        private void f_OnExamPeriodListSelected(object sender, ExamPeriodSelectEventArgs e)
        {
            SetExamPeriod(e._ExamPeriod);
            RefreshGrid();
        }
        private void SetExamPeriod(ExamPeriod _examPeriod)
        {
            if (_examPeriod != null && cboSchoolClass.SelectedIndex != -1)
            {
                try
                {
                    SchoolClass cls = (SchoolClass)cboSchoolClass.SelectedItem;

                    _ExamPeriod = _examPeriod;

                    txtExamPeriod.Text = _ExamPeriod.Id.ToString(); 
                    lblMessage.Text = string.Empty;
                    lblMessage.Text = "Year = " + _ExamPeriod.Year + ", Term= " + _ExamPeriod.Term;

                    var _Examquery =( from exm in db.Exams
                                      where exm.ExamPeriodId == _ExamPeriod.Id
                                      where exm.ClassId == cls.Id
                                select exm).FirstOrDefault();
                    Exam _Exam = _Examquery;
                    //var _ExamDetsquery = from exmdt in db.ExamDets
                    //                     where exmdt._ExamId == _Exam._ExamId
                    //                      select exmdt;
                    //List<ExamDet> _ExamDets = _ExamDetsquery.ToList();
                    //foreach (ExamDet _ExamDet in _ExamDets)
                    //{
                    //    if (_ExamDets != null)
                    //    {
                    //        //txtPercentContr.Text = _ExamDet.Contribution.ToString();

                    //        var _ExamTypesquery = from et in db.ExamTypes
                    //                              join exm in db.Exams on _AllowedRoleMenus.ExamPeriodId equals exm.ExamPeriodId
                    //                              join emdt in db.ExamDets on _ExamDet.ExamTypeId equals emdt.ExamTypeId
                    //                              where exm._ExamId == _ExamDet._ExamId
                    //                              select et;
                    //        List<ExamType> examtypes = _ExamTypesquery.ToList();
                    //        foreach (ExamType _ExamType in examtypes)
                    //        {
                    //            if(!_Students.Contains(_ExamType))
                    //            {
                    //            _Students.Add(_ExamType);
                    //            }
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }

        }
        private void btnPopulate_Click(object sender, EventArgs e)
        {
            try
            {
                SchoolClass cls;
                if (cboSchoolClass.SelectedIndex != -1)
                {
                    cls = (SchoolClass)cboSchoolClass.SelectedItem;
                }
                else
                {
                    MessageBox.Show("please select a valid ClassName");
                    return;
                }
                if (_ExamPeriod == null)
                {
                    MessageBox.Show("please Select a valid Exam Period");
                    return;
                }

                List<Subject> subjects = rep.GetClassSubjects(cls.Id);
                foreach (ExamType _ExamType in _ExamTypes)
                        {
                foreach (Subject sub in subjects)
                {
                    var _examquery = (from exms in db.Exams
                                      where exms.ClassId == cls.Id

                                      where exms.ExamPeriodId == _ExamPeriod.Id
                                      where exms.SubjectShortCode == sub.ShortCode
                                      select exms).FirstOrDefault();
                    Exam _exam = _examquery;
                    
                        
                            if (_exam != null && _ExamType != null)
                    {
                            //if (!db.RegisteredExams.Any(o => o.ExamDetId == _AllowedRoleMenus.ExamPeriodId
                            // ))
                            //{
                            //    //No Match!
                            //    RegisteredExam re = new RegisteredExam();
                            //    re.ExamDetId = _exam._ExamId;
                            //    re.LastModified = DateTime.Now;
                            //    re.ModifiedBy = _User;

                            //    db.RegisteredExams.AddObject(re);
                            //    db.SaveChanges();
                            //}
                        }
                    }
                }
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void createExamTimeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void createAllExamTimeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void contributionByExamTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}