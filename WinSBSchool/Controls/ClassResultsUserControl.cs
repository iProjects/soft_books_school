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
using WinSBSchool.Forms;
using WinSBSchool.Reports.ViewModelBuilders;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Controls
{
    public partial class ClassResultsUserControl : UserControl
    {
        SBSchoolDBEntities db;
        string connection;
        ExamPeriodClass ExamPeriodClass;
        bool _contributes;
        bool _current;
        string _user;

        public ClassResultsUserControl(ExamPeriodClass excl, bool contributes, bool current, string user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);

            _user = user;

            if (excl == null)
                throw new ArgumentNullException("Exam Period /class is invalid");
            ExamPeriodClass = excl;

            _contributes = contributes;

            _current = current;
        }

        private void ClassResultsUserControl_Load(object sender, EventArgs e)
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
                               join ep in db.ExamPeriods on ExamPeriodClass.ExamPeriod equals ep.Id
                               join sb in db.Subjects on ex.SubjectShortCode equals sb.ShortCode
                               where ser.Examid == ex.Id
                               where ser.StudentId == se.StudentId
                               where ser.SchoolClassId == sc.Id
                               where ep.Id == ExamPeriodClass.ExamPeriod
                               where sc.Id == ExamPeriodClass.ClassId
                               where re.ContributionFlag == true
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
                                   SubjectDescription = sb.Description,
                                   _Teacher = sc.Teacher.Name,
                                   _ClassStream = cs.Description,
                                   _ClassName = sc.ClassName,
                                   _ClassShortCode = sc.ShortCode,
                                   _ExamId = ex.Id,
                                   _SchoolClassId = sc.Id,
                                   _TeacherId = sc.Teacher.Id,
                                   _Status = st.Status,
                                   _ExamperiodDesc = ep.Description,
                                   _Term = ep.Term,
                                   _Year = ep.Year
                               };
 
                    var lst = data.ToList();

                    /*get all possible _examTypesquery into a separate group*/
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

                    /*Here the pivot column is the subject and the static column is exam
                    group the data against the static column(st)*/
                    var groups = from d in data
                                 orderby d.AdminNo ascending
                                 group d by new
                                 {
                                     StudentId = d.StudentId,
                                     d.SubjectShortCode
                                 }
                                     into grp
                                     select new
                                     {
                                         StudentId = grp.Key.StudentId,
                                         Marks = grp.GroupBy(f => f.SubjectShortCode)
                                         .Select(m => new
                                         {
                                             Title = m.Key,
                                             Sum = m.Sum(c => c.Mark * c.Contribution),
                                             Contribution = m.Sum(d => d.Contribution)
                                         }),
                                     };

                    var _classResultsquery = from d in lst
                                               group d by new
                                               {
                                                   d.StudentId
                                               }
                                                   into grp
                                                   select new
                                                   {
                                                       StudentId = grp.Key.StudentId, 
                                                       Marks = grp.GroupBy(f => f._ExamTypeShortCode)
                                                       .Select(m => new
                                                       {
                                                           Title = m.Key,
                                                           Sum = m.Sum(c => c.Mark)
                                                       }),
                                                       _Marks = (from d in grp
                                                                 group d by d._ExamTypeShortCode into grp2
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
                    var _classResults = _classResultsquery.ToList();

                    var _studentResultsquery = from d in _classResults
                                               group d by new
                                               {
                                                   d.StudentId, 
                                                   d._ExamTypeShortCode, 
                                               }
                                                   into grp
                                                   select new ProcessExaminationDTO
                                                   {
                                                       StudentId = grp.Key.StudentId  
                                                   };
                    var _studentResults = _studentResultsquery.FirstOrDefault();


                    //Build the table
                    DataTable dt = new DataTable();

                    /*for static cols*/
                    dt.Columns.Add("Student");

                    /*for dynamic cols*/
                    foreach (var _result in _classResults.ToList())
                    {
                        foreach (var sub in _result._SubjectShortCode.ToList())
                        {
                            DataColumn col = new DataColumn();
                            col.ColumnName = sub._SubjectShortCode;
                            col.Caption = sub._SubjectShortCode;

                            if (!dt.Columns.Contains(col.ColumnName))
                            {
                                dt.Columns.Add(col);
                            }
                        }
                    }

                    foreach (var _result in _classResults.ToList())
                    {                        
                        foreach (var stid in _result._ProcessExaminations.ToList())
                        {
                            DataRow dr = dt.NewRow();

                            var _studentquery = (from st in db.Students
                                                 where st.Id == _result.StudentId
                                                 select st).FirstOrDefault();
                            Student student = _studentquery;
                            dr["Student"] = student.AdminNo + " - " + student.StudentSurName + "  " + student.StudentOtherNames;

                            if (!dt.Columns.Contains("Total Mark"))
                            {
                                dt.Columns.Add("Total Mark");
                            }
                            if (!dt.Columns.Contains("Mean Mark"))
                            {
                                dt.Columns.Add("Mean Mark");
                            }
                            if (!dt.Columns.Contains("Mean Grade"))
                            {
                                dt.Columns.Add("Mean Grade");
                            }
                            if (!dt.Columns.Contains("Points"))
                            {
                                dt.Columns.Add("Points");
                            }

                            double total = 0;
                            foreach (var g in groups.Where(i => i.StudentId == _result.StudentId).ToList())
                            {
                                foreach (var mark in g.Marks)
                                {
                                    dr[mark.Title] = mark.Sum;
                                    total += (mark.Sum.HasValue ? mark.Sum.Value : 0);
                                }
                            }
                            dr["Total Mark"] = total;

                            dt.Rows.Add(dr);
                        }
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
                               join ep in db.ExamPeriods on ExamPeriodClass.ExamPeriod equals ep.Id
                               where ser.Examid == ex.Id
                               where ser.StudentId == se.StudentId
                               where ser.SchoolClassId == sc.Id
                               where ep.Id == ExamPeriodClass.ExamPeriod
                               where sc.Id == ExamPeriodClass.ClassId
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

                    //         var queryGroupMax =
                    //from student in students
                    //group student by student.Year into studentGroup
                    //select new
                    //{
                    //    Level = studentGroup.Key,
                    //    HighestScore =
                    //    (from student2 in studentGroup
                    //     select student2.ExamScores.Average()).Max()
                    //};

                   

                    var lst = data.ToList();

                    /*get all possible _examTypesquery into a separate group*/
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

                    /*Here the pivot column is the subject and the static column is exam
                    group the data against the static column(st)*/
                    var groups = from d in data
                                 orderby d.AdminNo ascending
                                 group d by new
                                 {
                                     StudentId = d.StudentId,
                                     d.SubjectShortCode
                                 }
                                     into grp
                                     select new
                                     {
                                         StudentId = grp.Key.StudentId,
                                         Marks = grp.GroupBy(f => f.SubjectShortCode)
                                         .Select(m => new
                                         {
                                             Title = m.Key,
                                             Sum = m.Sum(c => c.Mark * c.Contribution),
                                             Contribution = m.Sum(d => d.Contribution)
                                         }),
                                     };

                    //Build the table
                    DataTable dt = new DataTable();

                    /*for static cols*/
                    dt.Columns.Add("Student");

                    /*for dynamic cols*/
                    foreach (var sub in subjects.ToList())
                    {
                        DataColumn col = new DataColumn();
                        col.ColumnName = sub;
                        col.Caption = sub;

                        if (!dt.Columns.Contains(col.ColumnName))
                        {
                            dt.Columns.Add(col);
                        }
                    }

                    foreach (var stid in studentsquery.ToList())
                    {
                        DataRow dr = dt.NewRow();

                        var _studentquery = (from st in db.Students
                                             where st.Id == stid
                                             select st).FirstOrDefault();
                        Student student = _studentquery;
                        dr["Student"] = student.AdminNo + " - " + student.StudentSurName + "  " + student.StudentOtherNames;

                        if (!dt.Columns.Contains("Total"))
                        {
                            dt.Columns.Add("Total");
                        }

                        double total = 0;
                        foreach (var g in groups.Where(i => i.StudentId == stid).ToList())
                        {
                            foreach (var mark in g.Marks)
                            {
                                dr[mark.Title] = mark.Sum;
                                total += (mark.Sum.HasValue ? mark.Sum.Value : 0);
                            }
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
                //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(ExamPeriodClass, _user, connection);
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