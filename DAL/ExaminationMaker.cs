using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Diagnostics;
using CommonLib;

namespace DAL
{
    public class ExaminationMaker
    {

        #region "Private Properties"
        string _User;
        SBSchoolDBEntities db;
        DateTime _PaymentDate = DateTime.Now;
        public int _Term;
        public int _Year;
        public int _ExamTypeId;
        public int _StudentId;
        public bool _erorr = false;
        public string _errMsg;
        Repository rep;
        string connection;
        SchoolClass _SchoolClass;
        Teacher _Teacher;
        ExamType _ExamType;
        Student _Student;
        StudentsExamResult _StudentsExamsResult;       
        #endregion "Private Properties"

        #region "Constructors"
        //used to make _exam for a student
        public ExaminationMaker(int Term, int Year, int ExamTypeId, int StudentId, string User, string Conn)
        {
            try
            {
                if (string.IsNullOrEmpty(Conn))
                    throw new ArgumentNullException("Conn");
                connection = Conn;

                rep = new Repository(connection);
                db = new SBSchoolDBEntities(connection);
                _Term = Term;
                _Year = Year;
                _StudentId = StudentId;
                _User = User;
                _ExamTypeId = ExamTypeId;

                //load settings
                if (!Load())
                {
                    _erorr = true;
                    _errMsg = "Unable to load configs. please check the settings table";
                    Log.WriteToErrorLogFile(new Exception(_errMsg)); //log

                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }


        #endregion "Constructors"

        #region Public Members
        public Examination CreateExamResultsFromStudentExams()
        {
            //create Examination from loaded info. 
            Examination _exam = new Examination();

            if (!AddEmployeeEmployer(_exam))
            {
                return null;
            }

            if (!AddDeductions(_exam))
            {
                return null;
            }

            if (!AddPensionInfo(_exam))
            {
                return null;
            }

            if (!AddTaxInfo(_exam))
            {
                return null;
            }

            return _exam;
        }


        public Examination CreateAnonymousPayslip()
        {
            Examination _exam = new Examination();
            _exam.PrintedBy = "System";
            _exam.PrintedOn = DateTime.Today; 
            _exam.Year = DateTime.Today.Year;
            _exam.PrintedBy = _User;
            _exam.PrintedOn = DateTime.Today;
            return _exam;
        }

        #endregion

        #region private build members 
        private bool AddEmployeeEmployer(Examination _exam)
        {
            try
            {  
                _exam.StudentId = _Student.Id;
                _exam.Year = _Year;
                _exam.Term = _Term;
                _exam.ClassShortCode = _SchoolClass.ShortCode; 
                _exam.ExamTypeShortCode = _ExamType.ShortCode;
                _exam.TeacherId = _Teacher.Id;
                _exam.TotalMarks = (float) _StudentsExamsResult.TotalMarks;
                _exam.TotalPoints =(float) _StudentsExamsResult.TotalPoints;
                _exam.Position = (int)_StudentsExamsResult.Position;
                _exam.MeanMarks =(float) _StudentsExamsResult.MeanMarks;
                _exam.MeanGrade = _StudentsExamsResult.MeanGrade;
                _exam.ClassTeacherRemark = _StudentsExamsResult.ClassTeacherRemark;
                _exam.HeadTeacherRemark = _StudentsExamsResult.HeadTeacherRemark; 

                return true;
            }
            catch (Exception e)
            {
                Log.WriteToErrorLogFile(e);
                return false;
            }
        }

        private bool AddPensionInfo(Examination _exam)
        {
            try
            {
                
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        } 

        private bool AddTaxInfo(Examination _exam)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }

        private bool AddDeductions(Examination _exam)
        {

            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        //load general settings
        private bool Load()
        {
            try
            {
                var cls = (from sc in db.SchoolClasses
                          join cs in db.ClassStreams on sc.Id equals cs.ClassId
                          join st in db.Students on cs.Id equals st.ClassStreamId
                           where st.Id == _StudentId
                          select sc).FirstOrDefault();
                _SchoolClass = cls;
                if (_SchoolClass == null)
                    throw new ArgumentNullException("_SchoolClass");  


                var stdnt = (from sd in db.Students
                             where sd.Id == _StudentId
                              select sd).FirstOrDefault();
                _Student = stdnt;
                if (_Student == null)
                    throw new ArgumentNullException("_Student");

                var tchr = (from tc in db.Teachers
                            join sc in db.SchoolClasses on tc.Id equals _SchoolClass.TeacherId
                            select tc).FirstOrDefault();
                _Teacher = tchr;
                if (_Teacher == null)
                    throw new ArgumentNullException("_Teacher");

                var examtype = (from et in db.ExamTypes
                                where et.Id == _ExamTypeId
                                select et).FirstOrDefault();
                _ExamType = examtype;
                if (_ExamType == null)
                    throw new ArgumentNullException("_ExamType");

                var stdntexmrslts = (from ser in db.StudentsExamResults
                                    where ser.StudentId == _StudentId
                                    select ser).FirstOrDefault();
                _StudentsExamsResult = stdntexmrslts;
                if (_ExamType == null)
                    throw new ArgumentNullException("_StudentExamResult");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                _erorr = true;
                _errMsg = "Error processing Load() \n" + ex.Message;
                return false;
            }

        }
        #endregion

    }
}