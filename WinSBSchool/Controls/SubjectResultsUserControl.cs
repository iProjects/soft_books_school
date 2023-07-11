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
    public partial class SubjectResultsUserControl : UserControl
    {

        SBSchoolDBEntities db;
        Repository rep;
        string connection;
        Exam _Exam;
        bool _contributes;
        bool _current;
        string _user; 
        School school;
        int gradingsys;

        public SubjectResultsUserControl(Exam _exam, bool contributes, bool current, string user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            _user = user;

            if (_exam == null)
                throw new ArgumentNullException("Exam  is invalid");
            _Exam = _exam;

            _contributes = contributes;

            _current = current;

            var _Schoolquery = (from sc in db.Schools
                                where sc.DefaultSchool == true
                                select sc).FirstOrDefault();
            School _School = _Schoolquery;
            school = _School;
            gradingsys = school.GradingSystem;
        }

        private void SubjectResultsUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (_current)
                {
                    var data = from ser in db.StudentsExamResults_Temp
                               join serd in db.StudentsExamResultsDetail_Temp on ser.Id equals serd.StudentsExamResults_TempId
                               join st in db.Students on ser.StudentId equals st.Id
                               join se in db.StudentExams on st.Id equals se.StudentId
                               join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                               join sc in db.SchoolClasses on cs.SchoolClass.Id equals sc.Id     
                               join re in db.RegisteredExams on se.RegdExamId equals re.Id
                               join et in db.ExamTypes on re.ExamTypeId equals et.Id
                               join ex in db.Exams on ser.Examid equals ex.Id
                               join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                               where ser.Examid == ex.Id
                               where ser.StudentId == se.StudentId
                               where ser.SchoolClassId == sc.Id
                               where ep.Id == _Exam.ExamPeriodId
                               where ex.Id == _Exam.Id 
                               where re.ExamId == _Exam.Id
                               where re.ContributionFlag==true
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
                                   _ExamTypeDescription = et.Description
                               };

                    var lst = data.ToList();

                    /*get all possible _examTypesquery into a separate group*/
                    var _examTypesquery = (from d in data
                                           orderby d._ExamTypeShortCode ascending
                                           select new
                                           {
                                               ExamType = d._ExamTypeShortCode,
                                               ContributionFlag = d.ContributionFlag,
                                               Contribution = d.Contribution
                                           })
                                 .Distinct()
                                 .ToList(); 
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
                    var _examTypequery = (from d in lst
                                          orderby d._ExamTypeShortCode ascending
                                          select new
                                          {
                                              _ExamTypeShortCode = d._ExamTypeShortCode,
                                              ContributionFlag = d.ContributionFlag,
                                              Contribution = d.Contribution
                                          })
                               .Distinct()
                               .ToList();

                    /*Here the pivot column is the subject and the static column is _exam
                    group the data against the static column(st)*/
                    var groups = from d in data
                                 orderby d.AdminNo ascending
                                 group d by new
                                 {
                                     StudentId = d.StudentId,
                                     StudentSurname = d.StudentSurName,
                                     d.ContributionFlag
                                 }
                                     into grp
                                     select new
                                     {
                                         StudentId = grp.Key.StudentId,
                                         StudentSurname = grp.Key.StudentSurname,
                                         ContributionFlag = grp.Key.ContributionFlag,
                                         Marks = grp.GroupBy(f => f._ExamTypeShortCode)
                                         .Select(m => new
                                         {
                                             Title = m.Key,
                                             Sum = m.Sum(c => c.Mark * c.Contribution)
                                         }),
                                     };

                    var _SubjectResultsquery = from d in lst 
                                 group d by new
                                 {
                                     d.StudentId ,
                                     d.SubjectShortCode
                                 }
                                     into grp
                                     select new
                                     {
                                         StudentId = grp.Key.StudentId,
                                         SubjectShortCode = grp.Key.SubjectShortCode, 
                                         Marks = grp.GroupBy(f => f._ExamTypeShortCode)
                                         .Select(m => new
                                         {
                                             Title = m.Key,
                                             Sum = m.Sum(c => c.Mark)
                                         }),
                                         _Marks = (from d in grp
                                                   group d by d.SubjectShortCode into grp2
                                                   select new ProcessMarksDTO
                                                   {
                                                       TotalMarks = grp2.Sum(c => c.Mark * c.Contribution),
                                                       Contribution = grp2.Sum(d => d.Contribution)
                                                   }).ToList(),
                                         _SubjectShortCode = (from d in grp
                                                              group d by d.SubjectShortCode into grp2
                                                              select new ProcessSubjectDTO
                                                              {
                                                                  _SubjectShortCode = grp2.Key
                                                              }).ToList(),
                                         _ExamTypeShortCode = (from d in grp
                                                               group d by d._ExamTypeShortCode into grp2
                                                               select new ProcessExamTypeDTO
                                                               {
                                                                   _ExamTypeShortCode = grp2.Key
                                                               }).ToList(),
                                         _ProcessExaminations = (from g in grp
                                                                 select new ProcessExaminationDTO
                                                                 {
                                                                     _ExamTypeDescription = g._ExamTypeDescription,
                                                                     _ExamTypeShortCode = g._ExamTypeShortCode,
                                                                     AdminNo = g.AdminNo,
                                                                     Contribution = g.Contribution,
                                                                     ContributionFlag = g.ContributionFlag,
                                                                     Mark = g.Mark,
                                                                     StudentId = g.StudentId,
                                                                     StudentOtherNames = g.StudentOtherNames,
                                                                     StudentSurName = g.StudentSurName,
                                                                     
                                                                     SubjectShortCode = g.SubjectShortCode
                                                                 }).ToList()
                                     };
                    var _SubjectResults = _SubjectResultsquery.ToList();

                    //Build the table
                    DataTable dt = new DataTable();

                    /*for static cols*/
                    dt.Columns.Add("Student");

                    /*for dynamic cols*/
                    foreach (var exam in _SubjectResults.ToList())
                    {
                        foreach (var examtype in exam._ExamTypeShortCode.ToList())
                        {
                            DataColumn col = new DataColumn();
                            col.ColumnName = examtype._ExamTypeShortCode;
                            col.Caption = examtype._ExamTypeShortCode ;

                            if (!dt.Columns.Contains(col.ColumnName))
                            {
                                dt.Columns.Add(col);
                            }
                        }
                    }

                    dt.Columns.Add("Total Mark");
                    dt.Columns.Add("Mean Mark");
                    dt.Columns.Add("Mean Grade");
                    dt.Columns.Add("Points");

                    /*pivot the data into a new data table*/
                    foreach (var g in _SubjectResults.ToList())
                    {
                        DataRow dr = dt.NewRow();

                        var _studentquery = (from st in db.Students
                                             where st.Id == g.StudentId
                                             select st).FirstOrDefault();
                        Student student = _studentquery;
                        dr["Student"] = student.AdminNo + " - " + student.StudentSurName + "  " + student.StudentOtherNames;

                        double total = 0;
                        double? points = 0;
                        double meanmark = 0;
                        string meangrade = string.Empty;

                        foreach (var mark in g.Marks)
                        {
                            dr[mark.Title] = mark.Sum;
                            total += (mark.Sum.HasValue ? mark.Sum.Value : 0);
                        }
                        foreach (var mark in g._Marks)
                        { 
                            meanmark = (mark.MeanMarks.HasValue ? mark.MeanMarks.Value : 0);
                            meangrade = rep.GradeLookUp(meanmark, gradingsys);
                            points = (rep.PointLookUp(meanmark, gradingsys).HasValue ? rep.PointLookUp(meanmark, gradingsys).Value : 0);
                        }

                        dr["Total Mark"] = total;
                        dr["Mean Mark"] = meanmark;
                        dr["Mean Grade"] = meangrade;
                        dr["Points"] = points;

                        dt.Rows.Add(dr);
                    }

                    dataGridViewStudentResults.AutoGenerateColumns = true;
                    dataGridViewStudentResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewStudentResults.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    bindingSourceStudentResults.DataSource = dt;
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
                               where ep.Id == _Exam.ExamPeriodId
                               where ex.Id == _Exam.Id
                               //where re.ContributionFlag == _contributes
                               //where ex.Closed == current
                               //where ex.Processed == true
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
                                   _ExamTypeDescription = et.Description
                               };


                    var lst = data.ToList();

                    /*get all possible _examTypesquery into a separate group*/
                    var _examTypesquery = (from d in data
                                           orderby d._ExamTypeShortCode ascending
                                           select new
                                           {
                                               ExamType = d._ExamTypeShortCode,
                                               ContributionFlag = d.ContributionFlag,
                                               Contribution = d.Contribution
                                           })
                                 .Distinct()
                                 .ToList();

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

                    var _examTypequery = (from d in lst
                                          orderby d._ExamTypeShortCode ascending
                                          select new
                                          {
                                              _ExamTypeShortCode = d._ExamTypeShortCode,
                                              ContributionFlag = d.ContributionFlag,
                                              Contribution = d.Contribution
                                          })
                               .Distinct()
                               .ToList();

                    /*Here the pivot column is the subject and the static column is _exam
                    group the data against the static column(st)*/
                    var groups = from d in data
                                 orderby d.AdminNo ascending
                                 group d by new
                                 {
                                     StudentId = d.StudentId,
                                     StudentSurname = d.StudentSurName,
                                     d.ContributionFlag
                                 }
                                     into grp
                                     select new
                                     {
                                         StudentId = grp.Key.StudentId,
                                         StudentSurname = grp.Key.StudentSurname,
                                         ContributionFlag = grp.Key.ContributionFlag,
                                         Marks = grp.GroupBy(f => f._ExamTypeShortCode)
                                         .Select(m => new
                                         {
                                             Title = m.Key,
                                             Sum = m.Sum(c => c.Mark * c.Contribution)
                                         }),
                                     };


                    //Build the table
                    DataTable dt = new DataTable();

                    /*for static cols*/
                    dt.Columns.Add("Student");

                    /*for dynamic cols*/
                    foreach (var exam in _examTypesquery.ToList())
                    {
                        DataColumn col = new DataColumn();
                        col.ColumnName = exam.ExamType;
                        col.Caption = exam.ExamType + "/" + exam.Contribution * 100;

                        if (!dt.Columns.Contains(col.ColumnName))
                        {
                            dt.Columns.Add(col);
                        }
                    }

                    dt.Columns.Add("Total");

                    /*pivot the data into a new data table*/
                    foreach (var g in groups.ToList())
                    {
                        DataRow dr = dt.NewRow();

                        var _studentquery = (from st in db.Students
                                             where st.Id == g.StudentId
                                             select st).FirstOrDefault();
                        Student student = _studentquery;
                        dr["Student"] = student.AdminNo + " - " + student.StudentSurName + "  " + student.StudentOtherNames;

                        double total = 0;

                        foreach (var mark in g.Marks)
                        {
                            dr[mark.Title] = mark.Sum;
                            total += (mark.Sum.HasValue ? mark.Sum.Value : 0);
                        }

                        dr["Total"] = total;

                        dt.Rows.Add(dr);
                    }

                    dataGridViewStudentResults.AutoGenerateColumns = true;
                    dataGridViewStudentResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewStudentResults.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    bindingSourceStudentResults.DataSource = dt;
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
                //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(_Exam, _user, connection);
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