using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GL.DAL;
using WinSchool.Reports.ViewModels;
using CommonLib;
using WinSchool.Infrastructure;

namespace WinSchool.Reports.ViewModelBuilders
{
    public class ClassViewModelBuilder
    {
        Repository rep;
        bool error = false;
        ClassViewModel classviewmodel;

        public ClassViewModelBuilder()
        {
            rep = new Repository();


        }

        private void BuildClassReportModel()
        {
            classviewmodel = new ClassViewModel();
            classviewmodel.printedon = DateTime.Today;
            classviewmodel.ListofClasses = this.GetSchoolClasslist();
        }
        public ClassViewModel GetClassModel()
        {
            try
            {
                if (!error)
                    BuildClassReportModel();
                return classviewmodel;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }

        private List<SchoolClasslist> GetSchoolClasslist()
        {
            List<SchoolClasslist> populatedclasslistmodel = new List<SchoolClasslist>();
            List<SchoolClass> classlist = rep.GetAllSchoolClasses();


            SchoolClasslist bsc = new SchoolClasslist();
            var Items = from p in classlist
                        select new SClass
                        {
                            Name = p.ClassName,
                            ClassTeacher = p.ClassTeacher ?? 0,
                            Remarks = p.Remarks,
                        };
            bsc.ClassList = Items.ToList();

            if (Items.Count() > 0)
                populatedclasslistmodel.Add(bsc);

            return populatedclasslistmodel;

        }

    }
}
