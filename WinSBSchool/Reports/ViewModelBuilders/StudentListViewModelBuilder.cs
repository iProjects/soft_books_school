using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonLib;
using DAL;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class StudentListViewModelBuilder
    {

        Repository rep;
        bool error = false;
        StudentListViewModel _ViewModel;
        DAL.SchoolClass _SchoolClass;
        DAL.School school;
        string fileLogo;
        string slogan;
        string connection;
        SBSchoolDBEntities db;
        int gradingsys;

        public StudentListViewModelBuilder(School _school, DAL.SchoolClass schoolClass, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

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
        public StudentListViewModel GetStudentListViewModelBuilder()
        {
            try
            {
                if (!error)
                    Build();
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
                _ViewModel = new StudentListViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.ClassName = _SchoolClass.ClassName ;
                _ViewModel.SchoolName = school.SchoolName ;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel._StudentsDTO = this.GetStudentsList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<StudentsListDTO> GetStudentsList()
        {
            try
            {
                List<StudentsListDTO> lstStudents = new List<StudentsListDTO>();

                var _ClassStudentsquery = from st in db.Students
                                          join cs in db.ClassStreams
                                          on st.ClassStreamId equals cs.Id
                                          where cs.ClassId == _SchoolClass.Id
                                          orderby cs.Id ascending
                                          select st;

                List<Student> students = _ClassStudentsquery.ToList();

                foreach (var st in students)
                {
                    var _ClassStreamquery = (from cs in db.ClassStreams
                                             where cs.Id == st.ClassStreamId
                                             select cs).FirstOrDefault();
                    ClassStream _ClassStream = _ClassStreamquery;

                    StudentsListDTO sld = new StudentsListDTO();
                    sld.StudentName = st.StudentOtherNames + "  " + st.StudentSurName;
                    sld.AdmissionNo = st.AdminNo;
                    sld.Gender = st.Gender;
                    sld.DOB = st.DateOfBirth ?? DateTime.Now;
                    sld.Phone = st.Phone;
                    sld.Stream = _ClassStream.Description;
                    sld.AdmissionDate = st.AdmissionDate ?? DateTime.Now;
                    sld.KCPEMark = st.KCPE;
                    if (st.FatherName != null)
                    {
                        sld.ParentName = st.FatherName;
                    }
                    if (st.MotherName != null)
                    {
                        sld.ParentName = st.MotherName;
                    }
                    if (st.GuardianName != null)
                    {
                        sld.ParentName = st.GuardianName;
                    }
                    if (st.FatherCellPhone != null)
                    {
                        sld.ParentPhoneno = st.FatherCellPhone;
                    }
                    if (st.MotherCellPhone != null)
                    {
                        sld.ParentPhoneno = st.MotherCellPhone;
                    }
                    if (st.GuardianCellPhone != null)
                    {
                        sld.ParentPhoneno = st.GuardianCellPhone;
                    }

                    lstStudents.Add(sld);
                }

                return lstStudents;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }



    }
}
