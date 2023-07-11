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
    public class ClassStreamTimeTableViewModelBuilder
    {
        Repository rep;
        string connection;
        bool error = false;
        ClassStreamTimeTableViewModel _ViewModel;
        DAL.School school;
        string fileLogo;
        string slogan;
        int gradingsys;
        SBSchoolDBEntities db;
        ClassStream _ClassStream;
        TimeTable _TimeTable;

        public ClassStreamTimeTableViewModelBuilder(School _school, ClassStream clssstrm, TimeTable timetable, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;

            if (clssstrm == null)
                throw new ArgumentNullException("ClassStream");
            _ClassStream = clssstrm;

            if (timetable == null)
                throw new ArgumentNullException("TimeTable");
            _TimeTable = timetable;
        }

        public ClassStreamTimeTableViewModel GetViewModelBuilder()
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
            _ViewModel = new ClassStreamTimeTableViewModel();
            _ViewModel.printedon = DateTime.Today;
            _ViewModel.ReportDate = DateTime.Today;
            _ViewModel.SchoolName = school.SchoolName;
            _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
            _ViewModel.SchoolLogo = fileLogo;
            _ViewModel.SchoolSlogan = slogan;
            _ViewModel._TimeTableList = this.GetTimeTableList();
        }

        private List<ClassStreamTimeTableListDTO> GetTimeTableList()
        {
            List<ClassStreamTimeTableListDTO> lstTimeTable = new List<ClassStreamTimeTableListDTO>();
            var _timetablequery = from tt in db.TimeTables
                                 join ttd in db.TimeTableDets on tt.Id equals ttd.TimeTableId
                                 where tt.ClassStreamId == _ClassStream.Id
                                 where tt.Id == _TimeTable.Id
                                 select new
                                  {
                                      SubjectShortCode = ttd.SubjectShortCode,
                                      StartTime = ttd.StartTime,
                                      EndTime = ttd.EndTime,
                                      Activity = ttd.Activity,
                                      Venue = ttd.Venue,
                                      Recurrent = ttd.Recurrent,
                                      Text = ttd.Text,
                                      RoomId = ttd.RoomId
                                  };

            var groups = from ttd in _timetablequery
                         orderby ttd.SubjectShortCode ascending
                         group ttd by new
                         {
                             SubjectShortCode = ttd.SubjectShortCode,
                             StartTime = ttd.StartTime,
                             EndTime = ttd.EndTime,
                             Activity = ttd.Activity,
                             Venue = ttd.Venue,
                             Recurrent = ttd.Recurrent,
                             Text = ttd.Text,
                             RoomId = ttd.RoomId
                         }
                             into grp
                             select new
                             {
                                 SubjectShortCode = grp.Key.SubjectShortCode,
                                 StartTime = grp.Key.StartTime,
                                 EndTime = grp.Key.EndTime,
                                 Activity = grp.Key.Activity,
                                 Venue = grp.Key.Venue,
                                 Recurrent = grp.Key.Recurrent,
                                 Text = grp.Key.Text,
                                 RoomId = grp.Key.RoomId
                             };

            foreach (var ttd in groups.ToList())
            {
                ClassStreamTimeTableListDTO tld = new ClassStreamTimeTableListDTO();
                tld.SubjectShortCode = ttd.SubjectShortCode;
                tld.StartTime = ttd.StartTime;
                tld.EndTime = ttd.EndTime;
                tld.Activity = ttd.Activity;
                tld.Venue = ttd.Venue;
                tld.Recurrent = ttd.Recurrent;
                tld.Text = ttd.Text;
                tld.RoomId = ttd.RoomId;

                lstTimeTable.Add(tld);
            }
            return lstTimeTable;
        }





    }
}