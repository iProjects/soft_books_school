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
using WinSBSchool.Reports.ViewModelBuilders;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Controls
{
    public partial class ExamTypeResultsUserControl : UserControl
    {
        SBSchoolDBEntities db;
        string connection;
        RegisteredExam _RegisteredExam;
        Repository rep;
        bool _contributes;
        bool _current;
        DAL.School school;
        int gradingsys;
        string _user;

        public ExamTypeResultsUserControl(RegisteredExam registeredExam, bool contributes, bool current, string user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            _user = user;

            if (registeredExam == null)
                throw new ArgumentNullException("RegisteredExam is invalid");
            _RegisteredExam = registeredExam;
            

            _contributes = contributes;

            _current = current;

            var _Schoolquery = (from sc in db.Schools
                                where sc.DefaultSchool == true
                                select sc).FirstOrDefault();
            School _School = _Schoolquery;
            school = _School;
            gradingsys = school.GradingSystem;
        }

        private void RegisteredExamsUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (_current)
                {

                    var data = from ser in db.StudentsExamResults_Temp
                               join serd in db.StudentsExamResultsDetail_Temp on ser.Id equals serd.StudentsExamResults_TempId
                               join st in db.Students on ser.StudentId equals st.Id
                               join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                               join sc in db.SchoolClasses on cs.SchoolClass.Id equals sc.Id
                               join se in db.StudentExams on st.Id equals se.StudentId
                               join re in db.RegisteredExams on se.RegdExamId equals re.Id
                               join et in db.ExamTypes on re.ExamTypeId equals et.Id
                               join ex in db.Exams on ser.Examid equals ex.Id
                               join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                               where ser.Examid == ex.Id
                               where ser.StudentId == se.StudentId
                               where ser.SchoolClassId == sc.Id 
                               where se.RegdExamId == _RegisteredExam.Id
                               where et.Id == _RegisteredExam.ExamTypeId
                               where re.ContributionFlag == true
                               where re.Id == _RegisteredExam.Id
                               select new
                               {
                                   StudentId = st.Id,
                                   StudentSurName = st.StudentSurName,
                                   StudentOtherNames = st.StudentOtherNames,
                                   AdminNo = st.AdminNo,
                                   SubjectShortCode = ex.SubjectShortCode,
                                   ContributionFlag = re.ContributionFlag,
                                   Contribution = re.Contribution,
                                   Mark = se.Mark,
                                   MeanMark = ser.MeanMarks,
                                   TotalMark = ser.TotalMarks,
                                   TotalPoints = ser.TotalPoints,
                                   MeanGrade = ser.MeanGrade,
                                   Position = ser.Position,
                                   _ExamTypeShortCode = et.ShortCode,
                                   _ExamTypeDescription = et.Description,
                                   Point = ser.TotalPoints,
                                   Grade = ser.MeanGrade
                               }; 
               
                var lst = data.ToList(); 

                var subjects = (from d in lst
                                orderby d.SubjectShortCode ascending
                                select d.SubjectShortCode)
                                .Distinct()
                                .ToList(); 
                var studentsquery = (from d in lst
                                     orderby d.AdminNo ascending
                                     select d.StudentId)
                               .Distinct()
                               .ToList(); 
                var _examTypesquery = (from d in lst
                                       orderby d._ExamTypeShortCode ascending
                                       select new
                                       {
                                           _ExamTypeShortCode = d._ExamTypeShortCode,
                                           ContributionFlag = d.ContributionFlag,
                                           Contribution = d.Contribution
                                       })
                           .Distinct()
                           .ToList();

                //Build the table
                DataTable dt = new DataTable();

                /*for static cols*/
                dt.Columns.Add("Student");
                dt.Columns.Add("Mark");
                dt.Columns.Add("Grade"); 
                dt.Columns.Add("Points");

                /*for dynamic cols*/
                foreach (var exam in lst.ToList())
                {
                    DataRow dr = dt.NewRow();

                    var _studentquery = (from st in db.Students
                                         where st.Id == exam.StudentId
                                         select st).FirstOrDefault();
                    Student student = _studentquery;
                    var _Points = rep.PointLookUp(exam.Mark, gradingsys);

                    dr["Student"] = student.AdminNo + " - " + student.StudentSurName + "  " + student.StudentOtherNames;
                    dr["Mark"] = exam.Mark;
                    dr["Grade"] = exam.Grade;
                    dr["Points"] = _Points;

                    dt.Rows.Add(dr);
                }

                bindingSourceStudentResults.DataSource = dt;
                dataGridViewStudentResults.AutoGenerateColumns = true;
                dataGridViewStudentResults.CellBorderStyle = DataGridViewCellBorderStyle.None;
                dataGridViewStudentResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewStudentResults.DataSource = bindingSourceStudentResults;
                groupBox2.Text = bindingSourceStudentResults.Count.ToString();

                }
                else
                {
                    var data = from ser in db.StudentsExamResults
                               join serd in db.StudentsExamResultsDetails on ser.Id equals serd.StudentsExamResultsId
                               join st in db.Students on ser.StudentId equals st.Id
                               join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                               join sc in db.SchoolClasses on cs.SchoolClass.Id equals sc.Id
                               join se in db.StudentExams on st.Id equals se.StudentId
                               join re in db.RegisteredExams on se.RegdExamId equals re.Id
                               join et in db.ExamTypes on re.ExamTypeId equals et.Id
                               join ex in db.Exams on ser.Examid equals ex.Id
                               join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                               where ser.Examid == ex.Id
                               where ser.StudentId == se.StudentId
                               where ser.SchoolClassId == sc.Id
                               where re.Id == _RegisteredExam.Id
                               where se.RegdExamId == _RegisteredExam.Id
                               where et.Id == _RegisteredExam.ExamTypeId
                               //where re.ContributionFlag == _contributes
                               select new
                               {
                                   StudentId = st.Id,
                                   StudentSurName = st.StudentSurName,
                                   StudentOtherNames = st.StudentOtherNames,
                                   AdminNo = st.AdminNo,
                                   SubjectShortCode = ex.SubjectShortCode,
                                   ContributionFlag = re.ContributionFlag,
                                   Contribution = re.Contribution,
                                   Mark = se.Mark,
                                   MeanMark = ser.MeanMarks,
                                   TotalMark = ser.TotalMarks,
                                   TotalPoints = ser.TotalPoints,
                                   MeanGrade = ser.MeanGrade,
                                   Position = ser.Position,
                                   _ExamTypeShortCode = et.ShortCode,
                                   _ExamTypeDescription = et.Description,
                                   Point = ser.TotalPoints,
                                   Grade = ser.MeanGrade
                               };

                    var lst = data.ToList();

                    //foreach (var item in lst)
                    //{
                    //    item.Point = rep.PointLookUp(item.Mark, gradingsys);
                    //    item.Grade = rep.GradeLookUp(item.Mark, gradingsys);
                    //}

                    var subjects = (from d in lst
                                    orderby d.SubjectShortCode ascending
                                    select d.SubjectShortCode)
                                    .Distinct()
                                    .ToList();

                    var studentsquery = (from d in lst
                                         orderby d.AdminNo ascending
                                         select d.StudentId)
                                   .Distinct()
                                   .ToList();

                    var _examTypesquery = (from d in lst
                                           orderby d._ExamTypeShortCode ascending
                                           select new
                                           {
                                               _ExamTypeShortCode = d._ExamTypeShortCode,
                                               ContributionFlag = d.ContributionFlag,
                                               Contribution = d.Contribution
                                           })
                               .Distinct()
                               .ToList();

                    //Build the table
                    DataTable dt = new DataTable();

                    /*for static cols*/
                    dt.Columns.Add("Student");
                    dt.Columns.Add("Mark");
                    dt.Columns.Add("Grade");

                    /*for dynamic cols*/
                    foreach (var exam in lst.ToList())
                    {
                        DataRow dr = dt.NewRow();

                        var _studentquery = (from st in db.Students
                                             where st.Id == exam.StudentId
                                             select st).FirstOrDefault();
                        Student student = _studentquery;
                        dr["Student"] = student.AdminNo + " - " + student.StudentSurName + "  " + student.StudentOtherNames;
                        dr["Mark"] = exam.Mark;
                        dr["Grade"] = exam.Grade;

                        dt.Rows.Add(dr);
                    }

                    bindingSourceStudentResults.DataSource = dt;
                    dataGridViewStudentResults.AutoGenerateColumns = true;
                    dataGridViewStudentResults.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    dataGridViewStudentResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewStudentResults.DataSource = bindingSourceStudentResults;
                    groupBox2.Text = bindingSourceStudentResults.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(_RegisteredExam, _user, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

















    }
}