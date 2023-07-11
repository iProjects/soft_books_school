using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using DAL;
using WinSBSchool.Infrastructure;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class ExamResultsByClassViewModelBuilder
    {

        ExamResultsByClassViewModel _ViewModel;
        SchoolClass _SchoolClass;
        School school;
        string connection;
        SBSchoolDBEntities db;
        Repository rep;
        bool error = false;
        int gradingsys;
        ExamType _ExamType;
        ExamPeriod _ExamPeriod;
        RegisteredExam _RegisteredExam;
        string fileLogo;
        string slogan;


        public ExamResultsByClassViewModelBuilder(School _school, ExamPeriod examPeriod, SchoolClass schoolClass, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (examPeriod == null)
                throw new ArgumentNullException("ExamPeriod is invalid");
            _ExamPeriod = examPeriod;

            if (schoolClass == null)
                throw new ArgumentNullException("SchoolClass is invalid");
            _SchoolClass = schoolClass;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;

        }
        public ExamResultsByClassViewModel GetModelBuilder()
        {
            try
            {
                if (!error) Build();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void Build()
        {
            try
            {
                _ViewModel = new ExamResultsByClassViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.ClassName = _SchoolClass.ClassName;
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel.Year = _ExamPeriod.Year;
                _ViewModel.Term = _ExamPeriod.Term;
                _ViewModel.ExamResults = this.GetExamResults();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<ExamResultsByClassDTO> GetExamResults()
        {
            try
            {
                List<ExamResultsByClassDTO> lstdto = new List<ExamResultsByClassDTO>();

                var data = from se in db.StudentExams
                           join rg in db.RegisteredExams on se.RegdExamId equals rg.Id
                           join exm in db.Exams on rg.ExamId equals exm.Id
                           join et in db.ExamTypes on rg.ExamTypeId equals et.Id
                           join sj in db.Subjects on exm.SubjectShortCode equals sj.ShortCode
                           join st in db.Students on se.StudentId equals st.Id
                           where exm.ExamPeriodId == _ExamPeriod.Id
                           where exm.ClassId == _SchoolClass.Id
                           select new ClassExamResult
                           {
                               StudentId = st.Id,
                               StudentAdminNo = st.AdminNo,
                               StudentName = st.StudentSurName + ", " + st.StudentOtherNames,
                               SubjectCode = sj.ShortCode,
                               ExamType = et.ShortCode, 
                               Mark = se.Mark
                           };

                var lst = data.ToList();

                foreach (var item in lst)
                {
                    item.Point = rep.PointLookUp(item.Mark, gradingsys);
                    item.Grade = rep.GradeLookUp(item.Mark, gradingsys);
                }

                /*get all possible _examTypesquery into a separate group*/
                var examtypesquery = (from d in lst
                                      select d.ExamType)
                               .Distinct()
                               .ToList();
                _ViewModel._ExamTypes = examtypesquery;

                var subjectsquery = (from d in lst
                                     orderby d.SubjectCode ascending
                                     select d.SubjectCode)
                               .Distinct()
                               .ToList();
                var clssbjectsquery = (from cs in db.ClassSubjects
                                      join sb in db.Subjects on cs.SubjectCode equals sb.ShortCode
                                      where cs.ClassId == _SchoolClass .Id
                                       where cs.Status == "A"
                                      select cs.SubjectCode).Distinct().ToList();
                _ViewModel._Subjects = clssbjectsquery;

                var studentsquery = (from d in lst
                                     select d.StudentId)
                               .Distinct()
                               .ToList();
                _ViewModel._Students = studentsquery;

                var groups = from d in lst
                             group d by new { d.StudentId, d.SubjectCode, d.StudentAdminNo, d.StudentName, d.ExamType, d.Mark } into grp
                             select new ClassExamResult
                            {
                                StudentId = grp.Key.StudentId,
                                StudentAdminNo = grp.Key.StudentAdminNo,
                                StudentName = grp.Key.StudentName,
                                SubjectCode = grp.Key.SubjectCode,
                                ExamType = grp.Key.ExamType,
                                Mark = grp.Key.Mark
                            };

                var _groupeddto = from d in data
                             group d by new
                             {
                                 StudentId = d.StudentId, StudentName = d.StudentName, d.SubjectCode ,d.Mark
                             }
                                 into grp
                                 select new ClassSubjectsExamTypes
                                 {
                                     StudentId = grp.Key.StudentId,
                                     SubjectCode =grp.Key.SubjectCode, 
                                      NoOfExamTypes =_ViewModel._ExamTypes.Count(),
                                     Marks = grp.GroupBy(f => f.SubjectCode)
                                     .Select(m => new MarksDTO
                                     {
                                         Mark = m.Sum(c => c.Mark)
                                     }),
                                     Rank = (from o in grp
                                             where o.Mark > grp.Key.Mark
                                             select o).Count() + 1
                                 };

                foreach (var item in _groupeddto.ToList())
                {
                    //item.Mark = groups.Sum(i => i.Mark);
                }
                foreach (var sub in subjectsquery)
                {
                    double? _sum = 0;
                    var sum = groups.Where(s => s.SubjectCode == sub).Sum(s => s.Mark);
                    _sum = sum;
                }
                foreach (var stid in _ViewModel._Students)
                {
                    ExamResultsByClassDTO strec = new ExamResultsByClassDTO();
                    strec.StudentId = stid;
                    strec.StudentExamResults = _groupeddto.Where(s => s.StudentId == stid).ToList();
                    strec.NoOfSubjects = _ViewModel._Subjects.Count();
                    string _mark = strec.MeanMarks.ToString("N0");
                    double _Mrk = double.Parse(_mark);
                    strec.MeanGrade = rep.GradeLookUp(_Mrk, gradingsys);
                    strec.Remarks = rep.RemarkLookUp(_Mrk, gradingsys);
                     
                    lstdto.Add(strec);
                }

                //var q = from _school in lst
                //        orderby _school.Mark ascending
                //        orderby _school.Rank ascending
                //        select new
                //        {
                //            Mark = _school.Mark,
                //            Rank = (from o in lst
                //                    where o.Mark > _school.Mark
                //                    select o).Count() + 1
                //        };
                //foreach (var rec in q)
                //{
                //    //var rank = q.Where(_school => _school.AdminNo == rec.StudentAdminNo).SingleOrDefault();

                //    //if (rank != null)
                //    //    rec.Rank = rank.Rank;
                //}

                return lstdto.OrderByDescending(i => i.Rank).ToList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private List<SecStudentMarkSheetRecord> RankstudentsMarksheet(List<SubjectExamResult> SubjectsExamResult)
        {
            List<SecStudentMarkSheetRecord> lst = new List<SecStudentMarkSheetRecord>();

            //Pass 1
            List<Student> classStudents = rep.GetClassStudents(_SchoolClass);
            foreach (Student student in classStudents)
            {
                SecStudentMarkSheetRecord strec = new SecStudentMarkSheetRecord();
                strec.NoOfSubjects = _SchoolClass.NoOfSubjects;
                strec.Student = student;
                strec.SubjectsExamResult = SubjectsExamResult.Where(s => s.StudentId == student.Id).ToList();
                strec.MeanGrade = rep.GradeLookUp(strec.MeanMarks, gradingsys);
                lst.Add(strec);
            }

            //do the actual ranking and regrouping according to subject order
            var q = from s in lst
                    orderby s.MeanMarks ascending
                    orderby s.Rank ascending
                    select new
                    {
                        AdminNo = s.Student.AdminNo,
                        Rank = (from o in lst
                                where o.MeanMarks > s.MeanMarks
                                select o).Count() + 1
                    };

            //Pass 2
            foreach (var rec in lst)
            {
                var rank = q.Where(s => s.AdminNo == rec.Student.AdminNo).SingleOrDefault();

                if (rank != null)
                    rec.Rank = rank.Rank;
            }

            return lst;
        }


    }
}
