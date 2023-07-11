using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using CommonLib;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Configuration;

namespace DAL
{

    public class Repository
    {
        #region "Private Fields"
        SBSchoolDBEntities db;
        #endregion "Private Fields"
        #region "Constructor"

        public Repository()
        {

            //Should be called by login service only
        }

        public Repository(string connection)
        {
            db = new SBSchoolDBEntities(connection);
        }
        #endregion "Constructor"
        #region "Public Methods"
        #region "Database and Connection"
        public bool Connect(
         string providerName,
         string serverName,
         string databaseName,
         string attacheddb,
         string userName,
         string password,
     string metaData,
          bool IntegratedSecurity)
        {
            try
            {
                EntityConnection conn = new EntityConnection(GetConnectionString(
                    providerName,
                    serverName,
                    databaseName,
                    attacheddb,
                    userName,
                    password,
                    metaData,
                    IntegratedSecurity));

                //overwrite the default context with this one
                db = new SBSchoolDBEntities(conn);

                return true;
            }
            catch (Exception ex)
            {
                ///TODO Log error
                Log.WriteToErrorLogFile(ex);
                db = null;
                return false;
            }
        }
        public bool Connect(string connectiostr)
        {
            try
            {
                //overwrite the default context with this one
                //string encConnection = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

                db = new SBSchoolDBEntities(connectiostr);

                return true;
            }
            catch (Exception ex)
            {
                ///TODO Log error
                Log.WriteToErrorLogFile(ex);
                db = null;
                return false;
            }
        }
        public string GetConnectionString(
           string providerName,
           string serverName,
           string databaseName,
           string attacheddb,
           string userName,
           string password,
            string metaData,
            bool IntegratedSecurity)
        {
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            if (!string.IsNullOrEmpty(attacheddb)) sqlBuilder.AttachDBFilename = attacheddb;
            sqlBuilder.IntegratedSecurity = IntegratedSecurity;
            sqlBuilder.UserID = userName;
            sqlBuilder.Password = password;


            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            //entityBuilder.Metadata = string.Format(@"metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl",
            //    metaData);
            entityBuilder.Metadata = string.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl",
                metaData);
            return entityBuilder.ToString();
        }
        #endregion "Database and Connection"
        #region "Login"
        public bool Register(string username, string Pwd, int roleid)
        {
            try
            {
                spUser user = new spUser();

                user.UserName = username;
                user.Password = Pwd;
                user.RoleId = roleid;
                db.AddTospUsers(user);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }

        }
        public bool CheckUserExists(string username, string Pwd)
        {
            try
            {
                var us = from users in db.spUsers
                         where users.UserName == username
                         where users.Password == Pwd
                         select users;
                return (us.Count() > 0);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        public bool IsUserLocked(string username)
        {
            try
            {
                var us = from users in db.spUsers
                         where users.UserName == username
                         where users.Locked == true
                         select users;
                return (us.Count() > 0);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        public void LockUser(string username)
        {
            spUser user;
            try
            {
                var us = from users in db.spUsers
                         where users.UserName == username
                         select users;
                user = us.Single();
                user.Locked = true;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public spUser GetUserbyUserName(string username)
        {
            try
            {
                var us = from users in db.spUsers
                         where users.UserName == username
                         select users;
                return us.Single();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public bool ChangePassword(string username, string Pwd)
        {
            try
            {
                var us = (from users in db.spUsers
                          where users.UserName == username
                          select users).Single();
                us.Password = Pwd;
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        #endregion "Login"
        #region "Users"
        public void GetUsers(Action<IList<UserModel>> callback)
        {
            callback(GetUserList());
        }
        public IList<UserModel> GetUserList()
        {

            var usermodels = from usr in db.spUsers
                             select new UserModel
                             {
                                 UserName = usr.UserName,
                                 Password = usr.Password,
                                 RoleId = usr.RoleId,
                                 Locked = usr.Locked
                             };

            return usermodels.ToList();
        }
        public UserModel GetUser(string _user)
        {

            var usermodel = (from usr in db.spUsers
                             where usr.UserName == _user
                             select new UserModel
                             {
                                 UserName = usr.UserName,
                                 Password = usr.Password,
                                 RoleId = usr.RoleId,
                                 Locked = usr.Locked
                             }).FirstOrDefault();

            return usermodel;
        }
        public void GetUserRoles()
        {

        }
        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<spUser> GetUsers()
        {
            try
            {

                return db.spUsers.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }

        }
        public void AddUser(string username, string password, int roleid, bool locked)
        {
            try
            {

                spUser user = new spUser();
                user.UserName = username;
                user.Password = password;
                user.RoleId = roleid;
                user.Locked = locked;

                db.AddTospUsers(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public void AddUser(spUser user)
        {
            try
            {
                spUser _user = new spUser();
                _user.UserName = user.UserName;
                _user.Password = user.Password;
                _user.RoleId = user.RoleId;
                _user.Surname = user.Surname;
                _user.OtherNames = user.OtherNames;
                _user.NationalID = user.NationalID;
                _user.DateOfBirth = user.DateOfBirth;
                _user.Gender = user.Gender;
                _user.InformBy = user.InformBy;
                _user.Email = user.Email;
                _user.Telephone = user.Telephone;
                _user.Photo = user.Photo;
                _user.Locked = user.Locked;
                _user.IsDeleted = user.IsDeleted;
                _user.SystemId = user.SystemId;
                _user.Status = user.Status;
                _user.DateJoined = user.DateJoined;
                _user.password_hash = user.password_hash;
                _user.password_salt = user.password_salt;

                db.AddTospUsers(_user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateUser(DAL.spUser user)
        {
            try
            {
                spUser _user = db.spUsers.First(u => u.Id == user.Id);
                _user.UserName = user.UserName;
                _user.Password = user.Password;
                _user.RoleId = user.RoleId;
                _user.Surname = user.Surname;
                _user.OtherNames = user.OtherNames;
                _user.NationalID = user.NationalID;
                _user.DateOfBirth = user.DateOfBirth;
                _user.Gender = user.Gender;
                _user.InformBy = user.InformBy;
                _user.Email = user.Email;
                _user.Telephone = user.Telephone;
                _user.Photo = user.Photo;
                _user.Locked = user.Locked;
                _user.IsDeleted = user.IsDeleted;
                _user.SystemId = user.SystemId;
                _user.Status = user.Status;
                _user.DateJoined = user.DateJoined;
                _user.password_hash = user.password_hash;
                _user.password_salt = user.password_salt;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public void UpdateUser(DAL.spUser user, string password, int roleid, bool locked)
        {
            try
            {

                spUser _user = db.spUsers.First(u => u.Id == user.Id);

                _user.Password = password;
                _user.RoleId = roleid;
                _user.Locked = locked;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public bool ChangePassword(UserModel user)
        {
            try
            {
                var _user = (from us in db.spUsers
                             where us.Id == user.UserId
                             select us).Single();

                _user.Password = user.Password;
                _user.password_hash = user.password_hash;
                _user.password_salt = user.password_salt;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                return true;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        public bool Authenticate(string userId, string pwd, int Maxtries, int tries, ref string message, ref string errCode)
        {
            if (tries > Maxtries)
            {
                message = "Maximum tries exceeded; User locked ";
                errCode = "100";
                LockUser(userId);
                return false;
            }
            if (!CheckUserExists(userId, pwd))
            {
                message = "Username or password not correct";
                errCode = "101";
                return false;
            }
            if (IsUserLocked(userId))
            {
                message = "User locked, please contact the administrator";
                errCode = "102";
                return false;
            }
            ///TODO continue checking all authentication conditions

            return true;
        }
        #endregion "Users"
        #region "Roles"
        public void AddRole(spRole role)
        {
            try
            {
                spRole c = new spRole();
                c = role;

                db.spRoles.AddObject(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateRole(spRole role)
        {
            try
            {
                spRole c = db.spRoles.First(r => r.Id == role.Id);
                c.Description = role.Description;
                c.ShortCode = role.ShortCode;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteRole(spRole role)
        {
            try
            {
                spRole c = db.spRoles.Where(r => r.Id == role.Id).Single();
                db.spRoles.DeleteObject(c);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<spRole> GetRolesList()
        {
            try
            {
                return db.spRoles.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Roles"
        #region "Rights"
        public void UpdateRight(spAllowedRoleMenu right)
        {
            try
            {
                spAllowedRoleMenu _right = db.spAllowedRoleMenus.First(r => r.Id == right.Id);
                _right.RoleId = right.RoleId;
                _right.MenuItemId = right.MenuItemId;
                _right.Allowed = right.Allowed;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateReportsRight(spAllowedReportsRolesMenu right)
        {
            try
            {
                spAllowedReportsRolesMenu _right = db.spAllowedReportsRolesMenus.First(r => r.Id == right.Id);
                _right.RoleId = right.RoleId;
                _right.MenuItemId = right.MenuItemId;
                _right.Allowed = right.Allowed;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "Rights"
        #region "Setting"
        public string SettingLookup(string Key)
        {
            try
            {
                var setting = db.Settings.FirstOrDefault(s => s.SSKey == Key);
                if (setting != null)
                    return setting.SSValue;
                else
                    return null;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<DAL.Setting> GetSettings()
        {
            try
            {

                return db.Settings.ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public void EditSetting(DAL.Setting setting, string ssvalue)
        {
            try
            {


                Setting _setting = db.Settings.First(s => s.SSKey == setting.SSKey);

                _setting.SSValue = ssvalue;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<SettingsGroup> GetSettingsGroup()
        {
            try
            {

                return db.SettingsGroups.Include("Settings").ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Setting"
        #region "Student"
        public void AddNewStudent(Student s)
        {
            try
            {

                Student student = new Student();
                student = s;

                db.AddToStudents(student);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public void UpdateStudent(Student student)
        {
            try
            {

                Student s = db.Students.First(i => i.Id == student.Id);

                s.SchoolId = student.SchoolId;
                s.ClassStreamId = student.ClassStreamId;
                s.AdminNo = student.AdminNo;
                s.StudentSurName = student.StudentSurName;
                s.StudentOtherNames = student.StudentOtherNames;
                s.Gender = student.Gender;
                s.DateOfBirth = student.DateOfBirth;
                s.Phone = student.Phone;
                s.Email = student.Email;
                s.Homepage = student.Homepage;
                s.StudentAddress = student.StudentAddress;
                s.AdmissionType = student.AdmissionType;
                s.Status = student.Status;
                s.KCPE = student.KCPE;
                s.KCSE = student.KCSE;
                s.AdmissionDate = student.AdmissionDate;
                s.AdmittedBy = student.AdmittedBy;
                s.Remarks = student.Remarks;
                s.Photo = student.Photo;
                s.LastModifiedTime = student.LastModifiedTime;
                s.FatherName = student.FatherName;
                s.FatherCellPhone = student.FatherCellPhone;
                s.FatherOfficePhone = student.FatherOfficePhone;
                s.FatherEmail = student.FatherEmail;
                s.MotherName = student.MotherName;
                s.MotherCellPhone = student.MotherCellPhone;
                s.MotherOfficePhone = student.MotherOfficePhone;
                s.MotherEmail = student.MotherEmail;
                s.GuardianName = student.GuardianName;
                s.GuardianCellPhone = student.GuardianCellPhone;
                s.GuardianOfficePhone = student.GuardianOfficePhone;
                s.GuardianEmail = student.GuardianEmail;
                s.PrevSchoolId = student.PrevSchoolId;
                s.PrevSchoolName = student.PrevSchoolName;
                s.PrevSchoolPhone = student.PrevSchoolPhone;
                s.PrevSchoolAddress = student.PrevSchoolAddress;
                s.ReasonForLeaving = student.ReasonForLeaving;
                s.ExtraCurricular1 = student.ExtraCurricular1;
                s.ExtraCurricular2 = student.ExtraCurricular2;
                s.ExtraCurricular3 = student.ExtraCurricular3;
                s.Term1MeanGrade = student.Term1MeanGrade;
                s.Term2MeanGrade = student.Term2MeanGrade;
                s.Term3MeanGrade = student.Term3MeanGrade;
                s.Eligible = student.Eligible;
                s.RequireTransport = student.RequireTransport;
                s.TransportChargeType = student.TransportChargeType;
                s.Boarder = student.Boarder;
                s.FeesPayPlan = student.FeesPayPlan;
                s.ResidenceHallRoomId = student.ResidenceHallRoomId;
                s.RequireTransport = student.RequireTransport;
                s.ResidenceId = student.ResidenceId;
                s.DoctorName = student.DoctorName;
                s.Ailments = student.Ailments;
                s.Foods = student.Foods;
                s.Allergies = student.Allergies;
                s.HostelName = student.HostelName;
                s.BedNo = student.BedNo;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public void UpdateStudentCustomer(Student student)
        {
            try
            {
                Student s = db.Students.First(i => i.Id == student.Id);
                s.CustomerId = student.CustomerId;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateStudentGLAccount(Student student)
        {
            try
            {
                Student s = db.Students.First(i => i.Id == student.Id);
                s.GLAccountId = student.GLAccountId;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                return db.Students.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Student> GetNonDeletedStudents()
        {
            try
            {
                return db.Students.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public void DeleteStudent(Student s)
        {
            try
            {
                Student student = db.Students.Where(i => i.Id == s.Id).Single();
                student.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Student> GetAllStudentsInClass(int currentClass)
        {
            try
            {
                return db.Students.Where(i => i.ClassStreamId == currentClass && i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public Student GetStudent(int id)
        {
            try
            {
                var tsd = db.Students.Where(p => p.Id == id);
                return tsd.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Student> GetClassStudent(int classid)
        {
            try
            {
                var tsd = db.Students.Where(p => p.ClassStreamId == classid && p.IsDeleted == false && p.Status == "A");
                return tsd.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public ClassStream GetStudentClassStream(int studentid)
        {
            try
            {

                var cls = (from cs in db.ClassStreams
                           where cs.IsDeleted == false
                           join st in db.Students on cs.Id equals st.ClassStreamId
                           where st.IsDeleted == false
                           where st.Id == studentid
                           select cs).FirstOrDefault();
                return cls;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<string> GetStudentAccountIdsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {
                var emp = from e in GetStudentAccountsFromCriteria(Criteria)
                          select e.Id.ToString();
                return emp.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Account> GetStudentAccountsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {

                IQueryable<Account> query = db.Accounts;

                foreach (CriterionItem ci in Criteria)
                {
                    switch (ci.Criterion.FieldName.ToLower())
                    {
                        case "surname":
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = from pc in db.Accounts
                                                      join sub in db.Students on pc.Id equals sub.CustomerId
                                                      where sub.StudentSurName == ci.Criterion.FValue
                                                      select pc;
                                    break;
                                case "notequal": query = from pc in db.Accounts
                                                         join sub in db.Students on pc.Id equals sub.CustomerId
                                                         where sub.StudentSurName != ci.Criterion.FValue
                                                         select pc;
                                    break;
                                case "startswith": query = from pc in db.Accounts
                                                           join sub in db.Students on pc.Id equals sub.CustomerId
                                                           where sub.StudentSurName.StartsWith(ci.Criterion.FValue)
                                                           select pc;
                                    break;
                                case "endswith": query = from pc in db.Accounts
                                                         join sub in db.Students on pc.Id equals sub.CustomerId
                                                         where sub.StudentSurName.EndsWith(ci.Criterion.FValue)
                                                         select pc;
                                    break;
                                case "has": query = from pc in db.Accounts
                                                    join sub in db.Students on pc.Id equals sub.CustomerId
                                                    where sub.StudentSurName.Contains(ci.Criterion.FValue)
                                                    select pc;
                                    break;
                            }
                            break;
                        case "othernames":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = from pc in db.Accounts
                                                      join sub in db.Students on pc.Id equals sub.CustomerId
                                                      where sub.StudentOtherNames == ci.Criterion.FValue
                                                      select pc;
                                    break;
                                case "notequal": query = from pc in db.Accounts
                                                         join sub in db.Students on pc.Id equals sub.CustomerId
                                                         where sub.StudentOtherNames != ci.Criterion.FValue
                                                         select pc;
                                    break;
                                case "startswith": query = from pc in db.Accounts
                                                           join sub in db.Students on pc.Id equals sub.CustomerId
                                                           where sub.StudentOtherNames.StartsWith(ci.Criterion.FValue)
                                                           select pc;
                                    break;
                                case "endswith": query = from pc in db.Accounts
                                                         join sub in db.Students on pc.Id equals sub.CustomerId
                                                         where sub.StudentOtherNames.EndsWith(ci.Criterion.FValue)
                                                         select pc;
                                    break;
                                case "has": query = from pc in db.Accounts
                                                    join sub in db.Students on pc.Id equals sub.CustomerId
                                                    where sub.StudentOtherNames.Contains(ci.Criterion.FValue)
                                                    select pc;
                                    break;
                            }
                            break;
                        case "customerno":
                            int intval = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = from pc in db.Accounts
                                                      join sub in db.Students on pc.Id equals sub.CustomerId
                                                      where sub.CustomerId == intval
                                                      select pc;
                                    break;
                                case "notequal": query = from pc in db.Accounts
                                                         join sub in db.Students on pc.Id equals sub.CustomerId
                                                         where sub.CustomerId == intval
                                                         select pc;
                                    break;
                                case "greatorthan": query = from pc in db.Accounts
                                                            join sub in db.Students on pc.Id equals sub.CustomerId
                                                            where sub.CustomerId > intval
                                                            select pc;
                                    break;
                                case "lessthan": query = query = from pc in db.Accounts
                                                                 join sub in db.Students on pc.Id equals sub.CustomerId
                                                                 where sub.CustomerId < intval
                                                                 select pc;
                                    break;
                                case "greatorthanorequal": query = from pc in db.Accounts
                                                                   join sub in db.Students on pc.Id equals sub.CustomerId
                                                                   where sub.CustomerId >= intval
                                                                   select pc;
                                    break;
                                case "lessthanorequal": query = from pc in db.Accounts
                                                                join sub in db.Students on pc.Id equals sub.CustomerId
                                                                where sub.CustomerId <= intval
                                                                select pc;
                                    break;
                            }
                            break;
                    }
                }
                List<Account> empl = query.ToList();
                return empl;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }

        }
        public List<string> GetStudentIdsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {
                var emp = from e in GetStudentsFromCriteria(Criteria)
                          select e.Id.ToString();
                return emp.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Student> GetStudentsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {

                IQueryable<Student> query = db.Students;

                foreach (CriterionItem ci in Criteria)
                {
                    switch (ci.Criterion.FieldName.ToLower())
                    {
                        case "surname":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.StudentSurName == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.StudentSurName != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.StudentSurName.StartsWith(ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.StudentSurName.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.StudentSurName.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "othernames":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.StudentOtherNames == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.StudentOtherNames != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.StudentOtherNames.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.StudentOtherNames.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.StudentOtherNames.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "customerno":
                            int intval = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = query.Where(e => e.CustomerId == intval);
                                    break;
                                case "notequal": query = query.Where(e => e.CustomerId != intval);
                                    break;
                                case "greatorthan": query = query.Where(e => e.CustomerId > intval);
                                    break;
                                case "lessthan": query = query.Where(e => e.CustomerId < intval);
                                    break;
                                case "greatorthanorequal": query = query.Where(e => e.CustomerId >= intval);
                                    break;
                                case "lessthanorequal": query = query.Where(e => e.CustomerId <= intval);
                                    break;
                            }
                            break;
                        case "phone":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.Phone == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.Phone != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.Phone.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.Phone.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.Phone.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "classstream":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = from st in db.Students
                                                      join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                                                      where cs.Description == ci.Criterion.FValue
                                                      select st;
                                    break;
                                case "notequal": query = from st in db.Students
                                                         join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                                                         where cs.Description != ci.Criterion.FValue
                                                         select st;
                                    break;
                                case "startswith": query = from st in db.Students
                                                           join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                                                           where cs.Description.StartsWith
                                                            (ci.Criterion.FValue)
                                                           select st;
                                    break;
                                case "endswith": query = from st in db.Students
                                                         join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                                                         where cs.Description.EndsWith(ci.Criterion.FValue)
                                                         select st;

                                    break;
                                case "has": query = from st in db.Students
                                                    join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                                                    where cs.Description.Contains(ci.Criterion.FValue)
                                                    select st;
                                    break;
                            }
                            break;
                    }
                }
                List<Student> empl = query.ToList();
                return empl;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }

        }
        public decimal GetStudentGLAccountBookBalance(int Accountid)
        {
            var acc = GetStudentGLAccount(Accountid);
            if (acc != null)
            {
                var accnt = (from a in db.Accounts
                             where a.Id == acc
                             select a).FirstOrDefault();
                return accnt.BookBalance * 1;
            }
            else return 0;
        }
        public decimal GetStudentGLAccountClearedBalance(int Accountid)
        {
            var acc = GetStudentGLAccount(Accountid);
            if (acc != null)
            {
                var accnt = (from a in db.Accounts
                             where a.Id == acc
                             select a).FirstOrDefault();
                return accnt.ClearedBalance * 1;
            }
            else return 0;
        }
        public int GetStudentGLAccount(int Accountid)
        {
            var acc = (from a in db.Accounts
                       where a.Id == Accountid
                       select a).FirstOrDefault();

            if (acc != null)
                return acc.Id;
            else return -1;
        }
        public int GetSchoolGLAccount(int Id)
        {
            var acc = (from a in db.Accounts
                       where a.Id == Id
                       select a).FirstOrDefault();

            if (acc != null)
                return acc.Id;
            else return -1;
        }
        public int GetStudentAccountByAccountType(string AccountTypeShortCode, int studentid)
        {
            //get the customer id given a student id
            int customer = GetCustomerIDByStudent(studentid);
            return GetCustomerAccountByAccountType(AccountTypeShortCode, customer);
        }
        public int GetSchoolAccountByAccountType(string AccountTypeShortCode, int schoolid)
        {
            //get the customer id given a school id
            int customer = GetCustomerIDBySchool(schoolid);
            return GetCustomerAccountByAccountType(AccountTypeShortCode, customer);
        }
        public int GetCustomerAccountByAccountType(string AccountTypeShortCode, int Id)
        {
            var acc = (from a in db.Accounts
                       join at in db.AccountTypes on a.AccountTypeId equals at.Id
                       where at.ShortCode.ToLower().Equals(AccountTypeShortCode.ToLower()) //replace with shortcode
                       where a.Id == Id
                       select a).FirstOrDefault();

            if (acc != null)
                return acc.Id;
            else return -1;

        }

        public int GetCustomerIDByStudent(int studentid)
        {
            var customer = (from c in db.Customers
                            where c.StudentId == studentid
                            select c).FirstOrDefault();
            if (customer != null)
                return customer.Id;
            else return -1;
        }
        public int GetCustomerIDBySchool(int schoolid)
        {
            var customer = (from c in db.Customers
                            join sc in db.Schools on c.Id equals sc.GLCustomerId
                            where sc.Id == schoolid
                            select c).FirstOrDefault();
            if (customer != null)
                return customer.Id;
            else return -1;
        }
        #endregion "Student"
        #region "Teacher"
        public void AddNewTeacher(Teacher teacher)
        {
            try
            {
                Teacher t = new Teacher();
                t = teacher;

                db.AddToTeachers(t);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateTeacher(Teacher teacher)
        {
            try
            {
                Teacher t = db.Teachers.First(i => i.Id == teacher.Id);
                t.Name = teacher.Name;
                t.IDNo = teacher.IDNo;
                t.TSCNo = teacher.TSCNo;
                t.Position = teacher.Position;
                t.Email = teacher.Email;
                t.Status = teacher.Status;
                t.DateJoined = teacher.DateJoined;
                t.DateLeft = teacher.DateLeft;
                t.IsLeft = teacher.IsLeft;
                t.HighestQualification = teacher.HighestQualification;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Teacher> GetActiveTeachers()
        {
            try
            {
                return db.Teachers.Where(i => i.Status == "A" && i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public List<Teacher> GetAllTeachers()
        {
            try
            {
                return db.Teachers.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public List<Teacher> GetNonDeletedTeachers()
        {
            try
            {
                return db.Teachers.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public void DeleteTeacher(Teacher t)
        {
            try
            {
                Teacher teacher = db.Teachers.Where(i => i.Id == t.Id).Single();
                teacher.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "Teacher"
        #region "School"
        public void AddNewSchool(School school)
        {
            try
            {
                School s = new School(); 
                s.SchoolIndex = school.SchoolIndex;
                s.SchoolName = school.SchoolName;
                s.SchoolType = school.SchoolType;
                s.GradingSystem = school.GradingSystem;
                s.DefaultSchool = school.DefaultSchool;
                s.GLCustomerId = school.GLCustomerId;
                s.Cellphone = school.Cellphone;
                s.Telephone = school.Telephone;
                s.Email = school.Email;
                s.Address1 = school.Address1;
                s.Address2 = school.Address2;
                s.SMTPServer = school.SMTPServer;
                s.SMSGateway = school.SMSGateway;
                s.Status = school.Status;
                s.Slogan = school.Slogan;
                s.Logo = school.Logo;

                db.AddToSchools(school);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateSchool(School school)
        {
            try
            {
                School s = db.Schools.First(i => i.Id == school.Id);
                s.SchoolIndex = school.SchoolIndex;
                s.SchoolName = school.SchoolName;
                s.SchoolType = school.SchoolType;
                s.GradingSystem = school.GradingSystem;
                s.DefaultSchool = school.DefaultSchool;
                s.GLCustomerId = school.GLCustomerId;
                s.Cellphone = school.Cellphone;
                s.Telephone = school.Telephone;
                s.Email = school.Email;
                s.Address1 = school.Address1;
                s.Address2 = school.Address2;
                s.SMTPServer = school.SMTPServer;
                s.SMSGateway = school.SMSGateway;
                s.Status = school.Status;
                s.Slogan = school.Slogan;
                s.Logo = school.Logo;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<School> GetAllSchools()
        {
            try
            {
                return db.Schools.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public void DeleteSchool(School s)
        {
            try
            {
                School school = db.Schools.Where(i => i.Id == s.Id).Single();
                school.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public School GetSchool(int id)
        {
            try
            {
                var sd = db.Schools.Where(p => p.Id == id && p.IsDeleted == false);
                return sd.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public School GetDefaultSchool()
        {
            try
            {
                var sd = db.Schools.Where(p => p.DefaultSchool == true && p.IsDeleted == false);
                return sd.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public void UpdateSchoolCustomer(School school)
        {
            try
            {
                School s = db.Schools.First(i => i.Id == school.Id);
                s.GLCustomerId = school.GLCustomerId;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "School"
        #region "Subject"
        public void AddNewSubject(Subject s)
        {
            try
            {
                Subject subject = new Subject();
                subject = s;

                db.AddToSubjects(subject);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateSubject(Subject subject)
        {
            try
            {
                Subject s = db.Subjects.First(i => i.ShortCode == subject.ShortCode);
                s.ShortCode = subject.ShortCode;
                s.Description = subject.Description;
                s.OutOf = subject.OutOf;
                s.PassMark = subject.PassMark;
                s.Status = subject.Status;
                s.ROrder = subject.ROrder;
                s.Remarks = subject.Remarks;
                s.NoOfRequiredHours = subject.NoOfRequiredHours;
                s.Fees = subject.Fees;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteSubject(Subject s)
        {
            try
            {
                Subject subject = db.Subjects.Where(i => i.ShortCode == s.ShortCode).Single();
                subject.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Subject> GetAllSubjects()
        {
            try
            {
                return db.Subjects.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Subject> GetNonDeletedSubjects()
        {
            try
            {
                return db.Subjects.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Subject> GetActiveSubjects()
        {
            try
            {
                return db.Subjects.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public Subject GetSubject(string shortcode)
        {
            try
            {
                return db.Subjects.Where(s => s.ShortCode == shortcode && s.IsDeleted == false).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<string> GetAllSubjectCodes()
        {
            try
            {
                return db.Subjects.Where(i => i.IsDeleted == false).Select(i => i.ShortCode).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Subject"
        #region "Classes"
        public void AddNewSchoolClass(SchoolClass sc)
        {
            try
            {
                SchoolClass schoolclass = new SchoolClass();
                schoolclass = sc;

                db.SchoolClasses.AddObject(schoolclass);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateSchoolClass(SchoolClass sc)
        {
            try
            {
                SchoolClass schoolclass = db.SchoolClasses.First(i => i.Id == sc.Id);
                schoolclass.ShortCode = sc.ShortCode;
                schoolclass.ClassName = sc.ClassName;
                schoolclass.ProgrammeYearId = sc.ProgrammeYearId;
                schoolclass.NoOfSubjects = sc.NoOfSubjects;
                schoolclass.TeacherId = sc.TeacherId;
                schoolclass.CurrentYrLevel = sc.CurrentYrLevel;
                schoolclass.NextYrLevel = sc.NextYrLevel;
                schoolclass.Remarks = sc.Remarks;
                schoolclass.Status = sc.Status;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteSchoolClass(SchoolClass sc)
        {
            try
            {
                SchoolClass schoolclass = db.SchoolClasses.Where(i => i.Id == sc.Id).Single();
                schoolclass.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<SchoolClass> GetAllSchoolClasses()
        {
            try
            {
                return db.SchoolClasses.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<SchoolClass> GetActiveSchoolClasses()
        {
            try
            {
                return db.SchoolClasses.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public SchoolClass GetSchoolClass(int classid)
        {
            try
            {
                return db.SchoolClasses.Where(sc => sc.Id == classid && sc.IsDeleted == false).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Classes"
        #region "Transactions"
        public List<Transaction> GetAllTransactions()
        {
            try
            {

                return db.Transactions.OrderBy(a => a.Id).ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Transaction> GetTransactionsLists(int account, DateTime startdate, DateTime enddate)
        {
            try
            {

                return db.Transactions
                    .Where(i => i.AccountId == account)
                    .Where(d => d.PostDate >= startdate && d.PostDate <= enddate)
                    .OrderByDescending(a => a.PostDate).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Transaction> GetTransactions(int account, DateTime startdate, DateTime enddate)
        {
            try
            {
                return db.Transactions
                    .Where(i => i.AccountId == account)
                    .Where(d => d.PostDate >= startdate && d.PostDate <= enddate)
                    .OrderBy(a => a.PostDate).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public decimal GetBalanceBF(int accid, DateTime startdate)
        {

            var total = db.Transactions
                .Where(q => q.AccountId == accid)
                .Where(d => d.PostDate < startdate)
                .Select(e => e.Amount);
            if (total.Count() == 0) return 0;

            return total.Sum();

        }
        public void SaveTransaction(Transaction t)
        {

            try
            {
                Transaction ts = new Transaction()
                {
                    TransactionTypeId = t.TransactionTypeId,
                    AccountId = t.AccountId,
                    Amount = t.Amount,
                    Narrative = t.Narrative,
                    UserName = t.UserName,
                    Authorizer = t.Authorizer,
                    StatementFlag = t.StatementFlag,
                    PostDate = t.PostDate,
                    ValueDate = t.ValueDate,
                    TransRef = t.TransRef,
                    RecordDate = t.RecordDate
                };

                db.Transactions.AddObject(ts);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        #endregion "Transaction"
        #region "TransactionType"
        public void AddNewTransactionType(TransactionType t)
        {
            try
            {

                TransactionType txntype = new TransactionType();
                txntype = t;

                db.TransactionTypes.AddObject(txntype);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateTransactionType(TransactionType t)
        {
            try
            {

                TransactionType txntype = db.TransactionTypes.First(i => i.Id == t.Id);
                txntype.ShortCode = t.ShortCode;
                txntype.Description = t.Description;
                txntype.DebitCredit = t.DebitCredit;
                txntype.DefaultAmount = t.DefaultAmount;
                txntype.DefaultCreditAccount = t.DefaultCreditAccount;
                txntype.DefaultDebitAccount = t.DefaultDebitAccount;
                txntype.DefaultCreditNarrative = t.DefaultCreditNarrative;
                txntype.DefaultDebitNarrative = t.DefaultDebitNarrative;
                txntype.TxnTypeView = t.TxnTypeView;
                txntype.CommissionType = t.CommissionType;
                txntype.FlatRate = t.FlatRate;
                txntype.PercentageRate = t.PercentageRate;
                txntype.DialogFlag = t.DialogFlag;
                txntype.NarrativeFlag = t.NarrativeFlag;
                txntype.ForcePost = t.ForcePost;
                txntype.UseDefaultAmount = t.UseDefaultAmount;
                txntype.UseDefaultCreditAccount = t.UseDefaultCreditAccount;
                txntype.UseDefaultDebitAccount = t.UseDefaultDebitAccount;
                txntype.UseDefaultCreditNarrative = t.UseDefaultCreditNarrative;
                txntype.UseDefaultDebitNarrative = t.UseDefaultDebitNarrative;
                txntype.ScreenViewCreditAccountField = t.ScreenViewCreditAccountField;
                txntype.ScreenViewCreditNarrativeField = t.ScreenViewCreditNarrativeField;
                txntype.ScreenViewDebitAccountField = t.ScreenViewDebitAccountField;
                txntype.ScreenViewDebitNarrativeField = t.ScreenViewDebitNarrativeField;
                txntype.ScreenViewAmountField = t.ScreenViewAmountField;
                txntype.ScreenViewModeofPaymentField = t.ScreenViewModeofPaymentField;
                txntype.ScreenViewValueDateField = t.ScreenViewValueDateField;
                txntype.PrintReceipt = t.PrintReceipt;
                txntype.ReceiptLayout = t.ReceiptLayout;
                txntype.PrintReceiptPrompt = t.PrintReceiptPrompt;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteTransactionType(TransactionType t)
        {
            try
            {

                TransactionType transactiontype = db.TransactionTypes.Where(i => i.Id == t.Id).Single();

                db.TransactionTypes.DeleteObject(transactiontype);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<TransactionType> GetAllTransactionTypes()
        {
            try
            {

                return db.TransactionTypes.OrderBy(a => a.Id).ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "TransactionType"
        #region "Posting"
        public void PostTransactions(List<Transaction> ts)
        {
            try
            {
                foreach (Transaction t in ts)
                {
                    Post(t);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void Post(Transaction t)
        {
            try
            {
                if (t == null) throw new ArgumentNullException("Transaction");

                Transaction ts = new Transaction();
                ts.TransactionTypeId = t.TransactionTypeId;
                ts.AccountId = t.AccountId;
                ts.Amount = t.Amount;
                ts.PostDate = t.PostDate;
                ts.ValueDate = t.ValueDate;
                ts.RecordDate = t.RecordDate;
                ts.Narrative = t.Narrative;
                ts.StatementFlag = t.StatementFlag;
                ts.Authorizer = t.Authorizer;
                ts.UserName = t.UserName;
                ts.TransRef = t.TransRef;
                ts.IsDeleted = t.IsDeleted;

                //Account ChangeBalance(t);
                string status;
                Account act = GetAccountPostStatus(t.AccountId, t, out status);
                if (act == null) throw new ArgumentNullException("Account Posting Error :", status);

                //On Before Book Balance Changed
                act.BookBalance += t.Amount;

                //Change cleared only if postdate == valuedate
                if (t.ValueDate == t.PostDate)
                {
                    //On Before Cleared Balance Changed
                    act.ClearedBalance += t.Amount;
                }

                db.Transactions.AddObject(ts);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public Account GetAccount(int AccountId)
        {
            try
            {
                Account act = (Account)db.Accounts.Where(ac => ac.Id == AccountId).FirstOrDefault();
                return act;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public int GetAccountIfExists(int Accountid)
        {
            try
            {
                var acc = (from a in db.Accounts
                           where a.Id == Accountid
                           select a).FirstOrDefault();

                if (acc != null)
                    return acc.Id;
                else return -1;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return -1;
            }
        }
        public Account GetAccountPostStatus(int AccountId, Transaction txn, out string Status)
        {
            Status = "Account Ok";

            //Check if account exists
            Account act = GetAccount(AccountId);
            if (act == null)
            {
                Status = "Account does not exist";
                return null;
            }

            //Is it a force post transacion 
            var TrnsctnTyp = (from tt in db.TransactionTypes
                              where tt.Id == txn.TransactionTypeId
                              select tt).FirstOrDefault();
            TransactionType _TransactionType = TrnsctnTyp;
            if (_TransactionType != null && _TransactionType.ForcePost != null && _TransactionType.ForcePost.Equals("1"))
            {
                Status = "Force post";
                return act;
            }

            //Check Available amount
            /*
             * 0 = Ok
             * 1 = Debit posting prohibited
             * 2 = Credit Posting prohibited
             * 3 = All postings prohibited
             * 4 = Cannot Overdraw
             */
            decimal AmountAvailable = act.ClearedBalance - act.Limit;
            decimal accBal = act.ClearedBalance + txn.Amount;

            if (act.PassFlag != null)
            {
                if (act.PassFlag.Equals("1") && txn.TransactionType.DebitCredit.Equals("D"))
                {
                    Status = "Account does not accept Debit posting";
                    return null;
                }
                if (act.PassFlag.Equals("2") && txn.TransactionType.DebitCredit.Equals("C"))
                {
                    Status = "Account does not accept Credit posting";
                    return null;
                }
                if (act.PassFlag.Equals("3"))
                {
                    Status = "Account does not accept any posting";
                    return null;
                }
                if (act.PassFlag.Equals("4") && txn.TransactionType.DebitCredit.Equals("D") && accBal < 0)
                {
                    Status = "Cannot overdraw";
                    return null;
                }
            }
            return act;
        }
        #endregion "Posting"
        #region "Account"
        public void AddNewAccount(Account a)
        {
            try
            {
                Account account = new Account();
                account = a;

                db.Accounts.AddObject(account);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAccount(Account a)
        {
            try
            {
                Account acc = db.Accounts.First(r => r.Id == a.Id);
                acc.AccountTypeId = a.AccountTypeId;
                acc.COAId = a.COAId;
                acc.Closed = a.Closed;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAccount(Account a)
        {
            try
            {
                Account account = db.Accounts.Where(i => i.Id == a.Id).Single();

                db.Accounts.DeleteObject(account);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Account> GetAllAccounts()
        {
            try
            {

                return db.Accounts.OrderBy(a => a.Id).ThenBy(a => a.AccountName).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Account> GetStudentAccounts(int Id)
        {
            try
            {

                return db.Accounts.Where(i => i.Id == Id).ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public bool AccountExist(int AccountId)
        {
            try
            {
                ///TODO Check how to determine item exists in EF
                //if (db.Accounts.Any(ac => ac.Id == AccountId))
                //{}
                //return true;
                Account act = (Account)db.Accounts.Where(ac => ac.Id == AccountId).FirstOrDefault();
                return (act == null);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        public Dictionary<string, Account> GetSchoolAccounts(int customerid)
        {
            try
            {
                Dictionary<string, Account> dict = new Dictionary<string, Account>();
                var acc = from ac in db.Accounts.Include("AccountType")
                          join at in db.AccountTypes on ac.AccountTypeId equals at.Id
                          where ac.Id == customerid
                          select new { Key = at.Description, Account = ac };

                foreach (var ac in acc)
                {
                    if (!dict.ContainsKey(ac.Key))
                    {
                        dict.Add(ac.Key, ac.Account);

                    }
                }

                return dict;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public Account GetAccounts(int id)
        {
            try
            {

                var acc = db.Accounts.Where(a => a.Id == id);
                return acc.SingleOrDefault();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<int> GetAccountIdsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {
                var emp = from e in GetAccountsFromCriteria(Criteria)
                          select e.Id;
                return emp.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Account> GetAccountsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {

                IQueryable<Account> query = db.Accounts;

                foreach (CriterionItem ci in Criteria)
                {
                    switch (ci.Criterion.FieldName.ToLower())
                    {
                        case "customerid":
                            int intvalcustomerid = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = query.Where(e => e.Id == intvalcustomerid);
                                    break;
                                case "notequal": query = query.Where(e => e.Id != intvalcustomerid);
                                    break;
                                case "greatorthan": query = query.Where(e => e.Id > intvalcustomerid);
                                    break;
                                case "lessthan": query = query.Where(e => e.Id < intvalcustomerid);
                                    break;
                                case "greatorthanorequal": query = query.Where(e => e.Id >= intvalcustomerid);
                                    break;
                                case "lessthanorequal": query = query.Where(e => e.Id <= intvalcustomerid);
                                    break;
                            }
                            break;
                        case "accountid":
                            int intvalaccountid = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.Id == intvalaccountid);
                                    break;
                                case "notequal": query = query.Where(e => e.Id != intvalaccountid);
                                    break;
                                case "greatorthan": query = query.Where(e => e.Id > intvalaccountid);
                                    break;
                                case "lessthan": query = query.Where(e => e.Id < intvalaccountid);
                                    break;
                                case "greatorthanorequal": query = query.Where(e => e.Id >= intvalaccountid);
                                    break;
                                case "lessthanorequal": query = query.Where(e => e.Id <= intvalaccountid);
                                    break;
                            }
                            break;
                        case "accountname":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.AccountName == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.AccountName != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.AccountName.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.AccountName.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.AccountName.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "accountno":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.AccountNo == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.AccountNo != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.AccountNo.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.AccountNo.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.AccountNo.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                    }
                }

                List<Account> empl = query.ToList();
                return empl;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Account"
        #region "AccountType"
        public void AddNewAccountType(AccountType at)
        {
            try
            {
                AccountType atp = new AccountType();
                atp = at;

                db.AccountTypes.AddObject(atp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAccountType(AccountType at)
        {
            try
            {
                AccountType atp = db.AccountTypes.First(r => r.Id == at.Id);
                atp.ShortCode = at.ShortCode;
                atp.Description = at.Description;
                atp.Status = at.Status;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAccountType(AccountType at)
        {
            try
            {
                AccountType atp = db.AccountTypes.Where(r => r.Id == at.Id).Single();
                atp.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AccountType> GetAllAccountTypes()
        {
            try
            {
                return db.AccountTypes.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AccountType> GetActiveAccountTypes()
        {
            try
            {
                return db.AccountTypes.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AccountType"
        #region "Parents"
        public void AddNewParent(Parent p)
        {
            try
            {

                Parent parent = new Parent();
                parent = p;

                db.Parents.AddObject(parent);
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateParent(Parent p)
        {
            try
            {
                Parent parent = db.Parents.First(r => r.ParentId == p.ParentId);
                parent.Name = p.Name;
                parent.Gender = p.Gender;
                parent.CellPhoneNo = p.CellPhoneNo;
                parent.Email = p.Email;
                parent.Occupation = p.Occupation;
                parent.Maritalstatus = p.Maritalstatus;
                parent.Relationship = p.Relationship;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteParent(Parent p)
        {
            try
            {

                Parent parent = db.Parents.Where(i => i.ParentId == p.ParentId).Single();

                db.Parents.DeleteObject(parent);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Parent> GetAllParents()
        {
            try
            {

                return db.Parents.OrderBy(a => a.ParentId).ThenBy(a => a.Name).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Parents"
        #region "Registered Exams"
        public void AddNewRegisteredExam(RegisteredExam r)
        {
            try
            {
                RegisteredExam registeredexam = new RegisteredExam();
                registeredexam.ExamId = r.ExamId;
                registeredexam.ExamTypeId = r.ExamTypeId;
                registeredexam.RoomId = r.RoomId;
                registeredexam.ExamDate = r.ExamDate;
                registeredexam.Invilgilator = r.Invilgilator;
                registeredexam.Status = r.Status;
                registeredexam.ContributionFlag = r.ContributionFlag;
                registeredexam.Contribution = r.Contribution;
                registeredexam.OutOf = r.OutOf;
                registeredexam.ModifiedBy = r.ModifiedBy;
                registeredexam.LastModified = r.LastModified;
                registeredexam.IsDeleted = r.IsDeleted;

                db.RegisteredExams.AddObject(registeredexam);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateRegisteredExam(RegisteredExam r)
        {
            try
            {
                RegisteredExam registeredexam = db.RegisteredExams.First(i => i.Id == r.Id);
                registeredexam.RoomId = r.RoomId;
                registeredexam.ExamDate = r.ExamDate;
                registeredexam.Invilgilator = r.Invilgilator;
                registeredexam.Status = r.Status;
                registeredexam.ContributionFlag = r.ContributionFlag;
                registeredexam.Contribution = r.Contribution;
                registeredexam.OutOf = r.OutOf;
                registeredexam.ModifiedBy = r.ModifiedBy;
                registeredexam.LastModified = r.LastModified;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteRegisteredExam(RegisteredExam r)
        {
            try
            {
                RegisteredExam registeredexam = db.RegisteredExams.Where(i => i.Id == r.Id).Single();
                db.RegisteredExams.DeleteObject(registeredexam);

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<RegisteredExam> GetAllRegisteredExam()
        {
            try
            {
                return db.RegisteredExams.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<RegisteredExam> GeAlltRegisteredExams(int examid)
        {
            try
            {
                return db.RegisteredExams.Where(i => i.IsDeleted == false && i.Status == "A" && i.ExamId == examid).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public RegisteredExam GetRegisteredExam(int examid, int examtypeid)
        {
            try
            {
                var _RegisteredExamquery = (from re in db.RegisteredExams
                                            where re.ExamId == examid
                                            where re.ExamTypeId == examtypeid
                                            select re).FirstOrDefault();
                RegisteredExam _RegisteredExam = _RegisteredExamquery;
                return _RegisteredExam;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Registered Exams"
        #region "ExamType"
        public void AddNewExamType(ExamType et)
        {
            try
            {
                ExamType examtype = new ExamType();
                examtype = et;

                db.ExamTypes.AddObject(examtype);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateExamType(ExamType examtype)
        {
            try
            {
                ExamType et = db.ExamTypes.First(i => i.Id == examtype.Id);
                et.ShortCode = examtype.ShortCode;
                et.Description = examtype.Description;
                et.ROrder = examtype.ROrder;
                et.PercentageContribution = examtype.PercentageContribution;
                et.Status = examtype.Status;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteExamType(ExamType et)
        {
            try
            {
                ExamType examtype = db.ExamTypes.Where(i => i.Id == et.Id).Single();
                examtype.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ExamType> GetAllExamTypes()
        {
            try
            {
                return db.ExamTypes.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ExamType> GetActiveExamTypes()
        {
            try
            {
                return db.ExamTypes.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public ExamType GetExamType(int ExamtypeId)
        {
            try
            {
                return db.ExamTypes.Where(et => et.Id == ExamtypeId && et.IsDeleted == false).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "ExamType"
        #region "Exam"
        public void UpdateExam(Exam exam)
        {
            try
            {
                Exam exm = db.Exams.First(i => i.Id == exam.Id);
                exm.ExamPeriodId = exam.ExamPeriodId;
                exm.ClassId = exam.ClassId;
                exm.SubjectShortCode = exam.SubjectShortCode;
                exm.LastModified = exam.LastModified;
                exm.ModifiedBy = exam.ModifiedBy;
                exm.Enabled = exam.Enabled;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<Exam> GetNonClosedExams(ExamPeriod _examperiod, SchoolClass _cls)
        {
            try
            {
                var examsquery = from ex in db.Exams
                                 join sc in db.SchoolClasses on ex.ClassId equals sc.Id
                                 join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                                 where ep.Id == _examperiod.Id
                                 where sc.Id == _cls.Id
                                 where ex.Closed == false
                                 select ex;
                return examsquery.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Exam> GetExamsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {

                IQueryable<Exam> query = db.Exams.Where(i => i.Closed == false && i.Enabled == true);

                foreach (CriterionItem ci in Criteria)
                {

                    switch (ci.Criterion.FieldName.ToLower())
                    {

                        case "examperiod":
                            int intvalexamperiodid = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = from pc in db.Exams
                                                      join sc in db.ExamPeriods on pc.ClassId equals sc.Id
                                                      where sc.Description == ci.Criterion.FValue
                                                      select pc;
                                    break;
                                case "notequal": query = from pc in db.Exams
                                                         join sc in db.ExamPeriods on pc.ClassId equals sc.Id
                                                         where sc.Description != ci.Criterion.FValue
                                                         select pc;
                                    break;
                                case "startswith": query = from pc in db.Exams
                                                           join sc in db.ExamPeriods on pc.ClassId equals sc.Id
                                                           where sc.Description.StartsWith(ci.Criterion.FValue)
                                                           select pc;
                                    break;
                                case "endswith": query = from pc in db.Exams
                                                         join sc in db.ExamPeriods on pc.ClassId equals sc.Id
                                                         where sc.Description.EndsWith(ci.Criterion.FValue)
                                                         select pc;
                                    break;
                                case "has": query = from pc in db.Exams
                                                    join sc in db.ExamPeriods on pc.ClassId equals sc.Id
                                                    where sc.Description.Contains(ci.Criterion.FValue)
                                                    select pc;
                                    break;
                            }
                            break;
                        case "class":
                            int intvalclassid = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = from pc in db.Exams
                                                      join sc in db.SchoolClasses on pc.ClassId equals sc.Id
                                                      where sc.ClassName == ci.Criterion.FValue
                                                      select pc;
                                    break;
                                case "notequal": query = from pc in db.Exams
                                                         join sc in db.SchoolClasses on pc.ClassId equals sc.Id
                                                         where sc.ClassName != ci.Criterion.FValue
                                                         select pc;
                                    break;
                                case "startswith": query = from pc in db.Exams
                                                           join sc in db.SchoolClasses on pc.ClassId equals sc.Id
                                                           where sc.ClassName.StartsWith(ci.Criterion.FValue)
                                                           select pc;
                                    break;
                                case "endswith": query = from pc in db.Exams
                                                         join sc in db.SchoolClasses on pc.ClassId equals sc.Id
                                                         where sc.ClassName.EndsWith(ci.Criterion.FValue)
                                                         select pc;
                                    break;
                                case "has": query = from pc in db.Exams
                                                    join sc in db.SchoolClasses on pc.ClassId equals sc.Id
                                                    where sc.ClassName.Contains(ci.Criterion.FValue)
                                                    select pc;
                                    break;
                            }
                            break;
                        case "subjectshortcode":
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = from pc in db.Exams
                                                      where pc.SubjectShortCode == ci.Criterion.FValue
                                                      select pc;
                                    break;
                                case "notequal": query = from pc in db.Exams
                                                         where pc.SubjectShortCode != ci.Criterion.FValue
                                                         select pc;
                                    break;
                                case "startswith": query = from pc in db.Exams
                                                           where pc.SubjectShortCode.StartsWith(ci.Criterion.FValue)
                                                           select pc;
                                    break;
                                case "endswith": query = from pc in db.Exams
                                                         where pc.SubjectShortCode.EndsWith(ci.Criterion.FValue)
                                                         select pc;
                                    break;
                                case "has": query = from pc in db.Exams
                                                    where pc.SubjectShortCode.Contains(ci.Criterion.FValue)
                                                    select pc;
                                    break;
                            }
                            break;
                    }


                }

                List<Exam> empl = query.ToList();
                return empl;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }        
        public void CopyExamResultsFromTemps()
        {
            try
            {
                //copy StudentsExamResults_Temp --> StudentsExamResults
                db.CopyExamResults();

                //copy StudentsExamResultsDetail_Temp --> StudentsExamResultsDetail
                db.CopyExamResultsDet();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void MarkExamAsClosed(int Examid)
        {
            try
            {
                var exam = (from e in db.Exams
                            where e.Id == Examid
                            select e).SingleOrDefault();
                if (exam != null)
                    exam.Closed = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public void MarkExamAsProcessed(Exam _exam)
        {
            try
            {
                var examquery = (from e in db.Exams
                                 where e.Id == _exam.Id
                                 select e).SingleOrDefault();
                if (examquery != null)
                {
                    Exam _Exam = examquery;
                    _Exam.Processed = true;

                    db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public void DeleteExam(Exam exam)
        {
            try
            {
                Exam _exam = db.Exams.Where(i => i.Id == exam.Id).Single();
                _exam.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public List<Exam> GetRegisteredExamsforProcessing(ExamPeriod _examperiod, Exam _exam, SchoolClass _schoolclass)
        {
            try
            {
                var examsquery = from ex in db.Exams
                                 join re in db.RegisteredExams on ex.Id equals re.ExamId
                                 join se in db.StudentExams on re.Id equals se.RegdExamId
                                 select ex;
                return examsquery.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Exam> GetProcessedOpenExams(ExamPeriod _examperiod, Exam _exam, SchoolClass _schoolclass)
        {
            try
            {
                var examsquery = from ex in db.Exams
                                 join re in db.RegisteredExams on ex.Id equals re.ExamId
                                 join se in db.StudentExams on re.Id equals se.RegdExamId
                                 join ser in db.StudentsExamResults_Temp on ex.Id equals ser.Examid
                                 join serd in db.StudentsExamResultsDetail_Temp on ser.Id equals serd.StudentsExamResults_TempId
                                 where ex.Processed == true
                                 where ex.Closed == false
                                 select ex;
                return examsquery.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Exam> GetProcessedClosedExams(ExamPeriod _examperiod, Exam _exam, SchoolClass _schoolclass)
        {
            try
            {
                var examsquery = from ex in db.Exams
                                 join re in db.RegisteredExams on ex.Id equals re.ExamId
                                 join se in db.StudentExams on re.Id equals se.RegdExamId
                                 join ser in db.StudentsExamResults on ex.Id equals ser.Examid
                                 join serd in db.StudentsExamResultsDetails on ser.Id equals serd.StudentsExamResultsId
                                 where ex.Processed == true
                                 where ex.Closed == true
                                 select ex;
                return examsquery.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public bool WorkingCopyNotClosed(ref int _schoolclassid, ref int _examid, ref string examtypeshortcodewc)
        {
            try
            {
                var cnt = db.StudentsExamResults_Temp.Count();
                if (cnt > 0)
                {
                    var rec = (from ser in db.StudentsExamResults_Temp
                               join serd in db.StudentsExamResultsDetails on ser.Id equals serd.StudentsExamResultsId
                               select new { 
                               ser.ClassTeacherRemark,
                               ser.Examid,
                               ser.HeadTeacherRemark,
                               ser.Id,
                               ser.IsDeleted,
                               ser.MeanGrade,
                               ser.MeanGrade_Target,
                               ser.MeanMarks,
                               ser.MeanMarks_Target,
                               ser.Position,
                               ser.Position_Target,
                               ser.SchoolClassId,
                               ser.Status,
                               ser.StudentId,
                               ser.TeacherId,
                               ser.TotalMarks,
                               ser.TotalMarks_Target,
                               ser.TotalPoints,
                               ser.TotalPoints_Target,
                               serd.SubjectShortCode 
                               }).First();

                    _schoolclassid = rec.SchoolClassId;
                    _examid = rec.Examid;
                    examtypeshortcodewc=rec.SubjectShortCode;
                }
                else
                {
                    _schoolclassid = -1;
                    _examid = -1;
                    examtypeshortcodewc="";
                }
                return cnt > 0;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        public void MarkExamPeriodAsProcessed(int term, int year, int ExamTypeId)
        {
            try
            {
                var examtype = (from p in db.ExamPeriods
                                where p.IsDeleted == false
                                where p.Status == "A"
                                where p.Term == term
                                where p.Year == year
                                select p).SingleOrDefault();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void MarkExamPeriodAsClosed(int term, int year)
        {
            try
            {
                var school = (from p in db.ExamPeriods
                               where p.IsDeleted == false
                               where p.Status == "A"
                               where p.Term == term
                               where p.Year == year
                               select p).SingleOrDefault();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void SaveExamination(bool Simulate, Examination exam)
        {
            try
            {
                try
                {
                    StudentProgresses_Temp sp = new StudentProgresses_Temp();

                    sp.StudentId = exam.StudentId;
                    sp.Year = exam.Year;
                    sp.Term = exam.Term;
                    sp.ClassShortCode = exam.ClassShortCode;
                    sp.SubjectShortCode = exam.ExamTypeShortCode;
                    sp.TeacherId = exam.TeacherId;
                    sp.TotalMarks = exam.TotalMarks;
                    sp.TotalPoints = exam.TotalPoints;
                    sp.Position = exam.Position;
                    sp.MeanMarks = exam.MeanMarks;
                    sp.MeanGrade = exam.MeanGrade;
                    sp.ClassTeacherRemark = exam.ClassTeacherRemark;
                    sp.HeadTeacherRemark = exam.HeadTeacherRemark;

                    db.StudentProgresses_Temp.AddObject(sp);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    string msg = "Error in Examination [" + exam.StudentId.ToString() + "]";
                    Exception ex = new Exception(msg, e);
                    Log.WriteToErrorLogFile(ex);
                    return;
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }        
        public void TruncateWorkingTables()
        {
            try
            {
                //TruncateStudentProgresses_Temp();
                TruncateStudentsExamResults_Temp();
                TruncateStudentsExamResultsDetail_Temp();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void TruncateStudentProgresses_Temp()
        {
            try
            {
                db.ExecuteStoreCommand("TRUNCATE TABLE StudentProgresses_Temp");
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearPayslipDet(int payPeriod, int Year)
        {
            try
            {


                db.ExecuteStoreCommand("DELETE FROM PayslipDet WHERE Period = {0} AND Year = {1}", payPeriod, Year);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void TruncateStudentsExamResults_Temp()
        {
            try
            {
                db.ExecuteStoreCommand("TRUNCATE TABLE StudentsExamResults_Temp");
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void TruncateStudentsExamResultsDetail_Temp()
        {
            try
            {
                db.ExecuteStoreCommand("TRUNCATE TABLE StudentsExamResultsDetail_Temp");
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentProgresses_Temp(ExamPeriod examperiod, SchoolClass cls)
        {
            try
            {
                db.ExecuteStoreCommand("DELETE FROM StudentProgresses_Temp WHERE Year = {0} AND Term = {1} AND ClassShortCode = {2}", examperiod.Year, examperiod.Term, cls.ShortCode);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentProgresses_Temp(int _examid)
        {
            try
            {
                db.ExecuteStoreCommand("DELETE FROM StudentProgresses_Temp WHERE ExamId = {0}", _examid);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentProgresses_Temp(int schoolclassid, int examid)
        {
            try
            {
                db.ExecuteStoreCommand("DELETE FROM StudentProgresses_Temp WHERE ExamId = {0} AND ClassShortCode = {1}", schoolclassid, examid);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentsExamResults_Temp(int schoolclassid, int examid)
        {
            try
            {
                var _studentexamresulttempquery = from sert in db.StudentsExamResults_Temp
                                                  where sert.SchoolClassId == schoolclassid
                                                  where sert.Examid == examid
                                                  select sert;
                List<StudentsExamResults_Temp> _sert = _studentexamresulttempquery.ToList();

                foreach (var er in _sert)
                {
                    ClearStudentsExamResultsDetail_Temp(er.Id);

                    db.ExecuteStoreCommand("DELETE FROM StudentsExamResults_Temp WHERE Id = {0}", er.Id);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentsExamResults_Temp( int examid)
        {
            try
            {
                var _studentexamresulttempquery = from sert in db.StudentsExamResults_Temp 
                                                  where sert.Examid == examid
                                                  select sert;
                List<StudentsExamResults_Temp> _sert = _studentexamresulttempquery.ToList();

                foreach (var er in _sert)
                {
                    ClearStudentsExamResultsDetail_Temp(er.Id);

                    db.ExecuteStoreCommand("DELETE FROM StudentsExamResults_Temp WHERE Id = {0}", er.Id);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentsExamResultsDetail_Temp(int _StudentsExamResultid)
        {
            try
            {
                db.ExecuteStoreCommand("DELETE FROM StudentsExamResultsDetail_Temp WHERE StudentsExamResults_TempId = {0}", _StudentsExamResultid);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentsExamResults(int Examid, int SchoolClassId)
        {
            try
            {
                db.ExecuteStoreCommand("DELETE FROM StudentsExamResults WHERE Examid = {0} AND SchoolClassId = {1}", Examid, SchoolClassId);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentsExamResults_Temp()
        {
            try
            {
                db.ExecuteStoreCommand("TRUNCATE TABLE StudentsExamResults_Temp");
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentsExamResultsDetail_Temp()
        {
            try
            {
                db.ExecuteStoreCommand("TRUNCATE TABLE StudentsExamResultsDetail_Temp");
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearStudentsExamResultsDetail(int StudentsExamResultsId, string SubjectShortCode)
        {
            try
            {
                db.ExecuteStoreCommand("DELETE FROM StudentsExamResultsDetail WHERE StudentsExamResultsId = {0} AND SubjectShortCode = {1}", StudentsExamResultsId, SubjectShortCode);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "Exam"
        #region "ClassSubjects"
        public void AddNewClassSubject(ClassSubject c)
        {
            try
            {
                ClassSubject cs = new ClassSubject();
                cs = c;

                List<string> classsubjects = db.ClassSubjects.Where(i => i.ClassId == c.ClassId).Select(i => i.SubjectCode).ToList();

                if (!classsubjects.Contains(c.SubjectCode))
                {
                    db.ClassSubjects.AddObject(cs);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ClassSubject> GetAllClassSubjects(int classId)
        {
            try
            {
                return db.ClassSubjects.Where(i => i.ClassId == classId && i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Subject> GetClassSubjects(int classid)
        {
            try
            {
                var subs = from sub in db.Subjects
                           join cs in db.ClassSubjects on sub.ShortCode equals cs.SubjectCode
                           where cs.ClassId == classid
                           where sub.IsDeleted == false
                           where cs.IsDeleted == false
                           where sub.Status == "A"
                           where cs.Status == "A"
                           select sub;
                return subs.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<string> GetClassSubjectCodes(int classid)
        {
            try
            {
                var subs = from sub in db.Subjects
                           join cs in db.ClassSubjects on sub.ShortCode equals cs.SubjectCode
                           where cs.ClassId == classid
                           orderby sub.ROrder ascending
                           where sub.IsDeleted == false
                           where cs.IsDeleted == false
                           where sub.Status == "A"
                           where cs.Status == "A"
                           select sub.ShortCode;
                return subs.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public ClassSubject GetClassSubject(int classsubjectid)
        {
            try
            {
                return db.ClassSubjects
                    .Include("SchoolClass")
                    .Include("Subject")
                    .Where(i => i.Id == classsubjectid && i.Status == "A" && i.IsDeleted == false && i.SchoolClass.IsDeleted == false && i.Subject.Status == "A" && i.Subject.IsDeleted == false).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClassSubject> GetSchoolClassSubjects()
        {
            try
            {
                return db.ClassSubjects
                       .Include("SchoolClass")
                       .Include("Subject")
                       .Where(i => i.Status == "A" && i.IsDeleted == false && i.SchoolClass.IsDeleted == false && i.Subject.Status == "A" && i.Subject.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public void UpdateClassSubject(ClassSubject c)
        {
            try
            {
                ClassSubject cs = db.ClassSubjects.First(i => i.Id == c.Id);
                cs.ClassId = c.ClassId;
                cs.SubjectCode = c.SubjectCode;
                cs.SubjectTeacherId = c.SubjectTeacherId;
                cs.Status = c.Status;
                cs.Room = c.Room;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteClassSubject(ClassSubject c)
        {
            try
            {
                ClassSubject cs = db.ClassSubjects.Where(i => i.Id == c.Id).Single();
                cs.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "ClassSubjects"
        #region "ClassStream"
        public void AddNewClassStream(ClassStream c)
        {
            try
            {
                ClassStream cs = new ClassStream();
                cs = c;
                List<string> classsubjects = db.ClassStreams.Where(i => i.ClassId == c.ClassId)

                    .Select(i => i.Description).ToList();
                if (!classsubjects.Contains(c.Description))
                {
                    db.ClassStreams.AddObject(cs);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateClassStream(ClassStream c)
        {
            try
            {
                ClassStream cs = db.ClassStreams.First(i => i.Id == c.Id);
                cs.ClassId = c.ClassId;
                cs.Description = c.Description;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteClassStream(ClassStream c)
        {
            try
            {
                ClassStream cs = db.ClassStreams.Where(i => i.Id == c.Id).Single();
                cs.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ClassStream> GetAllClassStreams()
        {
            try
            {
                return db.ClassStreams.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClassStream> GetAllClassStreams(int classId)
        {
            try
            {
                return db.ClassStreams.Where(i => i.ClassId == classId && i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<string> GetClassStreamIdsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {
                var emp = from e in GetClassStreamsFromCriteria(Criteria)
                          select e.Id.ToString();
                return emp.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClassStream> GetClassStreamsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {
                IQueryable<ClassStream> query = db.ClassStreams.Where(i => i.IsDeleted == false);

                foreach (CriterionItem ci in Criteria)
                {
                    switch (ci.Criterion.FieldName.ToLower())
                    {
                        case "schoolclass":
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = query.Where(e => e.ClassId.ToString() == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.ClassId.ToString() != ci.Criterion.FValue);
                                    break;

                                case "startswith": query = query.Where(e => e.ClassId.ToString().StartsWith(ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.ClassId.ToString().EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.ClassId.ToString().Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;

                    }
                }

                List<ClassStream> empl = query.ToList();
                return empl;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "ClassStream"
        #region "TimeTable"
        public void AddNewTimeTable(TimeTable t)
        {
            try
            {
                TimeTable tt = new TimeTable();
                tt = t;

                db.TimeTables.AddObject(tt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateTimeTable(TimeTable t)
        {
            try
            {
                TimeTable tt = db.TimeTables.First(i => i.Id == t.Id);
                tt.ClassTimeTableXML = t.ClassTimeTableXML;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public void DeleteTimeTable(TimeTable t)
        {
            try
            {

                TimeTable tt = db.TimeTables.Where(i => i.Id == t.Id).Single();

                db.TimeTables.DeleteObject(tt);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<TimeTable> GetAllTimeTableActivities()
        {
            try
            {

                return db.TimeTables.ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "TimeTable"
        #region "pseudoviews"
        public List<pseudovwStatement> GetStudentStatement(int accountId)
        {
            try
            {

                //Account act = GetAccount(accountId);
                //var pm = db.vwStatements.Where(v => v.Id == accountId)
                //    .Select(v => new pseudovwStatement
                //    {
                //        date = v.PostDate,
                //        description = v.Narrative,
                //        amount = v.Amount,
                //        balance = v.BookBalance

                //    }).OrderBy(i => i.date).ToList();
                //return pm.ToList();
                return null;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }

        }
        public List<pseudovwProgrammeCourses> GetpseudovwProgrammeCourses(int classid)
        {
            try
            {



                var pm = db.ClassSubjects.Where(v => v.ClassId == classid)
                    .Select(v => new pseudovwProgrammeCourses
                    {


                    }).OrderBy(i => i.CourseCode).ToList();
                return pm.ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }

        }
        #endregion "pseudoviews"
        #region "StudentsExam"
        public void AddNewRegisteredStudent(RegisteredStudentDTO r)
        {
            try
            {

                StudentExam studentexam = new StudentExam();
                studentexam.StudentId = r.StudentID;
                studentexam.RegdExamId = r.ExamID;

                db.StudentExams.AddObject(studentexam);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Student> GetClassStudents(SchoolClass sc)
        {
            try
            {


                var _ClassStudentsquery = from st in db.Students
                                          join cs in db.ClassStreams
                                          on st.ClassStreamId equals cs.Id
                                          where cs.ClassId == sc.Id
                                          where st.Status == "A"
                                          orderby cs.Id ascending
                                          select st;

                List<Student> students = _ClassStudentsquery.ToList();

                return students;


            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Student> GetRegisteredClassStudents()
        {
            try
            {



                var regClsStudents = from r in db.StudentExams
                                     //select r.StudentId.Id;
                                     select r.StudentId;


                var students = from s in db.Students
                               //where regClsStudents.Contains(s.Id)
                               select s;

                return students.ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Student> GetUnRegisteredClassStudents()
        {
            //cross join


            var rgd = from r in GetRegisteredClassStudents()
                      select r.Id;


            var unRgd = from p in db.Students
                        where !rgd.Contains(p.Id)
                        select p;

            return unRgd.ToList();

        }
        public List<SubjectExamResult> GetStudentExam(int studentid, RegisteredExam _RegisteredExam, int gradingsys)
        {
            try
            {
                //var _examresultsquery = from se in db.StudentExams
                //         join rg in db.RegisteredExams on se.RegdExamId equals rg.RegdExamId
                //         join st in db.Students on se.StudentId equals st.StudentId
                //         join cs in db.ClassStreams on st.CurrentClass equals cs.ClassStreamId
                //         join sc in db.SchoolClasses on cs.SchoolClass equals sc.ClassId
                //         where cs.ClassStreamId == st.CurrentClass
                //         join exm in db.Exams on sc.ClassId equals exm.ClassId
                //         join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.ExamPeriodId
                //                        join exmtyp in db.ExamTypes on rg.ExamTypeId equals exmtyp.Id
                //                        where rg.ExamTypeId == examtypeid 
                //                        where se.StudentId == studentid
                //         join sj in db.Subjects on exm.SubjectShortCode equals sj.ShortCode 

                //         select new SubjectExamResult
                //         {
                //             SubjectCode = sj.ShortCode,
                //             Description = sj.Description,
                //             Mark = se.Mark,
                //             OutOf = sj.OutOf
                //         };

                //var lst = _examresultsquery.ToList();

                var yt = from se in db.StudentExams
                         join rgexam in db.RegisteredExams on se.RegdExamId equals rgexam.Id
                         where rgexam.Id == _RegisteredExam.Id
                         //where rgexam.ContributionFlag == contr
                         join exm in db.Exams on rgexam.ExamId equals exm.Id
                         join sub in db.Subjects on exm.SubjectShortCode equals sub.ShortCode
                         select new SubjectExamResult
                         {
                             StudentId = se.StudentId,
                             Mark = se.Mark ?? 0,
                             SubjectCode = sub.ShortCode,
                             Description = sub.Description,
                             OutOf = sub.OutOf
                         };
                var lst = yt.ToList();

                foreach (var item in lst)
                {
                    item.Point = this.PointLookUp(item.Mark, gradingsys);
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<StudentExamResult> GetStudentExamResult(int RegdExamId, int gradingsys)
        {
            try
            {

                var td = from se in db.StudentExams
                         join st in db.Students on se.StudentId equals st.Id
                         where se.RegdExamId == RegdExamId
                         select new StudentExamResult
                         {
                             StudentId = se.StudentId,
                             StudentAdminNo = st.AdminNo,
                             StudentName = st.StudentSurName,
                             Mark = se.Mark,
                             Grade = GradeLookUp(se.Mark, gradingsys)
                         };
                return td.ToList();
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "StudentExams"
        #region "Banks"
        public void AddNewBank(Bank _bank)
        {
            try
            {

                Bank bank = new Bank();
                bank.BankCode = _bank.BankCode;
                bank.BankName = _bank.BankName;

                db.Banks.AddObject(bank);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateBank(Bank _bank)
        {
            try
            {

                Bank bank = db.Banks.First(b => b.BankCode == _bank.BankCode);
                bank.BankName = _bank.BankName;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteBank(string bankcode)
        {
            try
            {

                Bank bank = db.Banks.Where(b => b.BankCode == bankcode).Single();

                db.Banks.DeleteObject(bank);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Bank> GetBanks()
        {
            try
            {
                return db.Banks.OrderBy(i => i.BankCode).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public IQueryable<Bank> GetBankQuery()
        {
            try
            {

                var banks = db.Banks.Include("BankBranches");
                return banks;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Banks"
        #region "Branches"
        public void AddNewBranch(BankBranch branch)
        {
            try
            {

                BankBranch bankbranch = new BankBranch();
                bankbranch = branch;

                db.BankBranches.AddObject(bankbranch);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public void UpdateBranch(BankBranch branch)
        {

            try
            {
                BankBranch bankbranch = db.BankBranches.First(b => b.BankCode == branch.BankCode && b.BankSortCode == branch.BankSortCode);
                bankbranch.BranchCode = branch.BranchCode;
                bankbranch.BranchName = branch.BranchName;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteBranch(string banksortcode, string bankcode)
        {
            try
            {
                BankBranch bankbranch = db.BankBranches.Where(b => b.BankCode == bankcode && b.BankSortCode == banksortcode).Single();

                db.BankBranches.DeleteObject(bankbranch);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAllBankBranches(string bankcode)
        {
            try
            {
                BankBranch bankbranch = db.BankBranches.Where(bb => bb.BankCode == bankcode).Single();

                db.BankBranches.DeleteObject(bankbranch);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<BankBranch> GetBankBranchList()
        {
            try
            {

                return db.BankBranches.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Branches"
        #region "vwBankBranch"
        public List<vwBankBranch> GetBankBranches()
        {
            try
            {
                return db.vwBankBranches.OrderBy(i => i.BankName).ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<vwBankBranch> GetBankBranchesFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {

                IQueryable<vwBankBranch> query = db.vwBankBranches;

                foreach (CriterionItem ci in Criteria)
                {
                    switch (ci.Criterion.FieldName.ToLower())
                    {

                        case "bankcode":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.BankCode == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.BankCode != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.BankCode.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.BankCode.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.BankCode.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "bankname":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.BankName == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.BankName != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.BankName.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.BankName.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.BankName.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "branchcode":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.BranchCode == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.BranchCode != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.BranchCode.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.BranchCode.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.BranchCode.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "branchname":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.BranchName == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.BranchName != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.BranchName.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.BranchName.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.BranchName.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "banksortcode":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.BankSortCode == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.BankSortCode != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.BankSortCode.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.BankSortCode.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.BankSortCode.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                    }
                }

                List<vwBankBranch> empl = query.ToList();
                return empl;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "vwBankBranch"
        #region "Customer"
        public int AddNewCustomer(Customer c)
        {
            int id = -1;
            try
            {
                Customer customer = new Customer();
                customer = c;

                db.Customers.AddObject(customer);
                db.SaveChanges();

                return customer.Id;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return id;
            }
        }
        public void UpdateCustomer(Customer c)
        {
            try
            {
                Customer customer = db.Customers.First(r => r.Id == c.Id);
                customer.CustomerNo = c.CustomerNo;
                customer.CustomerName = c.CustomerName;
                customer.Address = c.Address;
                customer.Telephone = c.Telephone;
                customer.Email = c.Email;
                customer.Branch = c.Branch;
                customer.BillToName = c.BillToName;
                customer.BillToAddress = c.BillToAddress;
                customer.BillToTelephone = c.BillToTelephone;
                customer.BillToEmail = c.BillToEmail;
                customer.Status = c.Status;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCustomer(Customer c)
        {
            try
            {
                Customer customer = db.Customers.Where(i => i.Id == c.Id).Single();
                customer.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Customer> GetAllCustomers()
        {
            try
            {
                return db.Customers.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Customer> GetActiveCustomers()
        {
            try
            {
                return db.Customers.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public Customer GetCustomer(int customerid)
        {
            try
            {
                return db.Customers.Where(v => v.Id == customerid && v.IsDeleted == false && v.Status == "A").SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public List<string> GetCustomerIdsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {
                var emp = from e in GetCustomersFromCriteria(Criteria)
                          select e.Id.ToString();
                return emp.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Customer> GetCustomersFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {

                IQueryable<Customer> query = db.Customers.Where(i => i.IsDeleted == false && i.Status == "A");

                foreach (CriterionItem ci in Criteria)
                {
                    switch (ci.Criterion.FieldName.ToLower())
                    {
                        case "id":
                            int intval = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = query.Where(e => e.Id == intval);
                                    break;
                                case "notequal": query = query.Where(e => e.Id != intval);
                                    break;
                                case "greatorthan": query = query.Where(e => e.Id > intval);
                                    break;
                                case "lessthan": query = query.Where(e => e.Id < intval);
                                    break;
                                case "greatorthanorequal": query = query.Where(e => e.Id >= intval);
                                    break;
                                case "lessthanorequal": query = query.Where(e => e.Id <= intval);
                                    break;
                            }
                            break;
                        case "name":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.CustomerName == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.CustomerName != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.CustomerName.StartsWith(ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.CustomerName.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.CustomerName.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "no":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.CustomerNo == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.CustomerNo != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.CustomerNo.StartsWith(ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.CustomerNo.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.CustomerNo.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "phone":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.Telephone == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.Telephone != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.Telephone.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.Telephone.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.Telephone.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "email":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.Email == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.Email != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.Email.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.Email.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.Email.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;

                    }
                }

                List<Customer> empl = query.ToList();
                return empl;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Customer"
        #region "Exam Period"
        public void AddNewExamPeriod(ExamPeriod ep)
        {
            try
            {
                ExamPeriod examperiod = new ExamPeriod();
                examperiod = ep;

                db.ExamPeriods.AddObject(examperiod);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateExamPeriod(ExamPeriod ep)
        {
            try
            {
                ExamPeriod examperiod = db.ExamPeriods.First(i => i.Id == ep.Id);
                examperiod.Year = ep.Year;
                examperiod.Term = ep.Term;
                examperiod.Description = ep.Description;
                examperiod.Status = ep.Status;
                examperiod.StartDate = ep.StartDate;
                examperiod.EndDate = ep.EndDate;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteExamPeriod(ExamPeriod ep)
        {
            try
            {
                ExamPeriod examperiod = db.ExamPeriods.Where(i => i.Id == ep.Id).Single();
                examperiod.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public ExamPeriod GetExamPeriod(int id)
        {
            try
            {
                var ed = db.ExamPeriods.Include("ExamType")
                    .Where(p => p.Id == id);

                return ed.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ExamPeriod> GetOpenExamPeriods(bool openFlag)
        {
            try
            {
                return db.ExamPeriods.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ExamPeriod> GetProcessedExamPeriods(bool processedFlag)
        {
            try
            {
                return db.ExamPeriods.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ExamPeriod> GetExamPeriods(bool openFlag, bool processedFlag)
        {
            try
            {
                return db.ExamPeriods.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        } 
        public List<string> GetExamPeriodIdsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {
                var emp = from e in GetExamPeriodsFromCriteria(Criteria)
                          select e.Id.ToString();
                return emp.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ExamPeriod> GetExamPeriodsFromCriteria(List<CriterionItem> Criteria)
        {
            try
            {
                IQueryable<ExamPeriod> query = db.ExamPeriods.Where(i => i.IsDeleted == false && i.Status == "A");

                foreach (CriterionItem ci in Criteria)
                {
                    switch (ci.Criterion.FieldName.ToLower())
                    {

                        case "year":
                            int intvalYear = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = from pc in db.ExamPeriods
                                                      where pc.Year == intvalYear
                                                      select pc;
                                    break;
                                case "notequal": query = from pc in db.ExamPeriods
                                                         where pc.Year != intvalYear
                                                         select pc;
                                    break;
                                case "greatorthan": query = from pc in db.ExamPeriods
                                                            where pc.Year > intvalYear
                                                            select pc;
                                    break;
                                case "lessthan": query = query = from pc in db.ExamPeriods
                                                                 where pc.Year < intvalYear
                                                                 select pc;
                                    break;
                                case "greatorthanorequal": query = from pc in db.ExamPeriods
                                                                   where pc.Year >= intvalYear
                                                                   select pc;
                                    break;
                                case "lessthanorequal": query = from pc in db.ExamPeriods
                                                                where pc.Year <= intvalYear
                                                                select pc;
                                    break;
                            }
                            break;
                        case "term":
                            int intvalTerm = int.Parse(ci.Criterion.FValue);
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = from pc in db.ExamPeriods
                                                      where pc.Term == intvalTerm
                                                      select pc;
                                    break;
                                case "notequal": query = from pc in db.ExamPeriods
                                                         where pc.Term != intvalTerm
                                                         select pc;
                                    break;
                                case "greatorthan": query = from pc in db.ExamPeriods
                                                            where pc.Term > intvalTerm
                                                            select pc;
                                    break;
                                case "lessthan": query = query = from pc in db.ExamPeriods
                                                                 where pc.Term < intvalTerm
                                                                 select pc;
                                    break;
                                case "greatorthanorequal": query = from pc in db.ExamPeriods
                                                                   where pc.Term >= intvalTerm
                                                                   select pc;
                                    break;
                                case "lessthanorequal": query = from pc in db.ExamPeriods
                                                                where pc.Term <= intvalTerm
                                                                select pc;
                                    break;
                            }
                            break;
                        case "description":
                            switch (ci.Criterion.Opr.Name)
                            {

                                case "equal": query = query.Where(e => e.Description == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.Description != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.Description.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.Description.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.Description.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                        case "status":
                            switch (ci.Criterion.Opr.Name)
                            {
                                case "equal": query = query.Where(e => e.Status == ci.Criterion.FValue);
                                    break;
                                case "notequal": query = query.Where(e => e.Status != ci.Criterion.FValue);
                                    break;
                                case "startswith": query = query.Where(e => e.Status.StartsWith
                                    (ci.Criterion.FValue));
                                    break;
                                case "endswith": query = query.Where(e => e.Status.EndsWith(ci.Criterion.FValue));
                                    break;
                                case "has": query = query.Where(e => e.Status.Contains(ci.Criterion.FValue));
                                    break;
                            }
                            break;
                    }

                }

                List<ExamPeriod> empl = query.ToList();
                return empl;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Exam Period"
        #region "MarkSheet"
        public void SaveMarkSheetExams(MarkSheetExam markSheetExam)
        {
            try
            {

                MarkSheetExam m = new MarkSheetExam();
                m = markSheetExam;

                db.AddToMarkSheetExams(m);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<MarkSheetExam> GetAllMarkSheetExams()
        {
            try
            {

                return db.MarkSheetExams.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public List<MarksheetArchive> GetAllMarksheetArchives()
        {
            try
            {

                return db.MarksheetArchives.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public List<MarkSheetStudent> GetAllMarkSheetStudents()
        {
            try
            {

                return db.MarkSheetStudents.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public List<TimeTable> GetAllTimeTables()
        {
            try
            {

                return db.TimeTables.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); return null;
            }
        }
        public List<ClassExamResult> GetExamResultsByClass(int classid, int examperiod, int gradingsys)
        {
            try
            {
                var yt = from se in db.StudentExams
                         join rg in db.RegisteredExams on se.RegdExamId equals rg.Id
                         join exm in db.Exams on rg.ExamId equals exm.Id
                         join et in db.ExamTypes on rg.ExamTypeId equals et.Id
                         join st in db.Students on se.StudentId equals st.Id
                         join sub in db.Subjects on exm.SubjectShortCode equals sub.ShortCode
                         where exm.ClassId == classid
                         where exm.ExamPeriodId == examperiod
                         select new StudentExamResult
                         {
                             Mark = se.Mark,
                             StudentAdminNo = st.AdminNo,
                             StudentId = se.StudentId,
                             StudentName = st.StudentOtherNames + " " + st.StudentSurName
                         };
                var lst1 = yt.ToList();

                var data = from ex in db.Exams
                           join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                           join r in db.RegisteredExams on ex.Id equals r.ExamId
                           join m in db.StudentExams on r.Id equals m.RegdExamId
                           join s in db.Students on m.StudentId equals s.Id
                           where ex.ClassId == classid
                           where ep.Id == examperiod
                           //where r.ContributionFlag == true                          
                           select new ClassExamResult
                                    {
                                        StudentId = s.Id,
                                        StudentName = s.StudentSurName + "  " + s.StudentOtherNames,
                                        StudentAdminNo = s.AdminNo,
                                        SubjectCode = ex.SubjectShortCode,
                                        ContributionFlag = r.ContributionFlag,
                                        Contribution = r.Contribution,
                                        Mark = m.Mark
                                    };
                var lst = data.ToList();

                foreach (var item in lst)
                {
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<SubjectResult> GetExamResultsBySubject(int classid, int examperiod, int gradingsys)
        {
            try
            {
                var data = from ex in db.Exams
                           join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                           where ex.ClassId == classid
                           where ep.Id == examperiod
                           join r in db.RegisteredExams on ex.Id equals r.ExamId
                           where r.ContributionFlag == true
                           join m in db.StudentExams on r.Id equals m.RegdExamId
                           join s in db.Students on m.StudentId equals s.Id
                           select new SubjectResult
                           {
                               StudentId = s.Id,
                               StudentName = s.StudentSurName + "  " + s.StudentOtherNames,
                               StudentAdminNo = s.AdminNo,
                               SubjectCode = ex.SubjectShortCode,
                               ContributionFlag = r.ContributionFlag,
                               Contribution = r.Contribution,
                               Mark = m.Mark
                           };
                var lst = data.ToList();

                foreach (var item in lst)
                {
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ExamTypeResult> GetExamResultsByExamType(int classid, int examperiod, int gradingsys)
        {
            try
            {
                var data = from ex in db.Exams
                           join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                           where ex.ClassId == classid
                           where ep.Id == examperiod
                           join r in db.RegisteredExams on ex.Id equals r.ExamId
                           where r.ContributionFlag == true
                           join m in db.StudentExams on r.Id equals m.RegdExamId
                           join s in db.Students on m.StudentId equals s.Id
                           select new ExamTypeResult
                           {
                               StudentId = s.Id,
                               StudentName = s.StudentSurName + "  " + s.StudentOtherNames,
                               StudentAdminNo = s.AdminNo,
                               SubjectCode = ex.SubjectShortCode,
                               ContributionFlag = r.ContributionFlag,
                               Contribution = r.Contribution,
                               Mark = m.Mark ?? 0
                           };
                var lst = data.ToList();

                foreach (var item in lst)
                {
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<SubjectExamResult> GetSecExamResultsByRegdExam(RegisteredExam rgdexam, int gradingsys, bool contr)
        {
            try
            {

                var yt = from se in db.StudentExams
                         join rgexam in db.RegisteredExams on se.RegdExamId equals rgexam.Id
                         where rgexam.Id == rgdexam.Id
                         where rgexam.ContributionFlag == contr
                         join exm in db.Exams on rgexam.ExamId equals exm.Id
                         join sub in db.Subjects on exm.SubjectShortCode equals sub.ShortCode
                         select new SubjectExamResult
                         {
                             StudentId = se.StudentId,
                             Mark = se.Mark ?? 0,
                             SubjectCode = sub.ShortCode,
                             Description = sub.Description,
                             OutOf = sub.OutOf
                         };
                var lst = yt.ToList();

                foreach (var item in lst)
                {
                    item.Point = this.PointLookUp(item.Mark, gradingsys);
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }

        public List<SubjectExamResult> GetSecExamResultsByExamPeriod(int ExamPeriodId, int gradingsys)
        {
            try
            {

                var yt = from se in db.vwExamResults
                         where se.ExamPeriodId == ExamPeriodId
                         select new SubjectExamResult
                         {
                             StudentId = se.StudentId,
                             Mark = se.ExamMark ?? 0,
                             SubjectCode = se.SubjectShortCode,
                             Description = se.Description,
                             OutOf = se.CombinedOutOf
                         };
                var lst = yt.ToList();

                foreach (var item in lst)
                {
                    item.Point = this.PointLookUp(item.Mark, gradingsys);
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }


        public List<StudentExamResult> GetSecExamResultsByExam(Exam exam, int gradingsys)
        {
            try
            {

                var yt = from se in db.vwExamResults
                         join st in db.Students on se.StudentId equals st.Id
                         where se.Id == exam.Id
                         select new StudentExamResult
                         {
                             StudentId = se.StudentId,
                             Mark = se.ExamMark,
                             StudentAdminNo = st.AdminNo,
                             StudentName = st.StudentSurName + " " + st.StudentOtherNames,
                             OutOf = se.CombinedOutOf
                         };
                var lst = yt.ToList();

                foreach (var item in lst)
                {
                    item.Point = this.PointLookUp(item.Mark, gradingsys);
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }


        public List<SubjectExamResult> GetSecExamResultsBySubject(int ExamPeriodId, int ExamTypeid, int ClassId, int gradingsys)
        {
            try
            {

                var yt = from se in db.StudentExams
                         join rgexam in db.RegisteredExams on se.RegdExamId equals rgexam.Id
                         join exm in db.Exams on rgexam.ExamId equals exm.Id
                         where exm.ClassId == ClassId
                         where exm.ExamPeriodId == ExamPeriodId
                         where rgexam.ExamTypeId == ExamTypeid
                         join sub in db.Subjects on exm.SubjectShortCode equals sub.ShortCode
                         select new SubjectExamResult
                         {
                             StudentId = se.StudentId,
                             Mark = se.Mark ?? 0,
                             SubjectCode = sub.ShortCode,
                             Description = sub.Description,
                             OutOf = sub.OutOf
                         };
                var lst = yt.ToList();

                foreach (var item in lst)
                {
                    item.Point = this.PointLookUp(item.Mark, gradingsys);
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }

        public List<SubjectExamResult> GetPriExamResultsBySubject(int ExamPeriodId, int ClassId, int gradingsys)
        {
            try
            {

                var yt = from se in db.StudentExams
                         join rgexam in db.RegisteredExams on se.RegdExamId equals rgexam.Id
                         join exm in db.Exams on rgexam.ExamId equals exm.Id
                         where exm.ClassId == ClassId
                         where exm.ExamPeriodId == ExamPeriodId
                         join sub in db.Subjects on exm.SubjectShortCode equals sub.ShortCode

                         select new SubjectExamResult
                         {
                             StudentId = se.StudentId,
                             Mark = se.Mark ?? 0,
                             SubjectCode = sub.ShortCode,
                             Description = sub.Description,
                             OutOf = sub.OutOf
                         };
                var lst = yt.ToList();

                foreach (var item in lst)
                {
                    item.Point = this.PointLookUp(item.Mark, gradingsys);
                    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }

        public List<SubjectResult> GetCollExamResultsBySubject(int ExamPeriodId, int ClassId, int gradingsys)
        {
            try
            {

                //var yt = from se in db.StudentExams
                //         join rgexam in db.RegisteredExams on se.RegdExamId equals rgexam.RegdExamId
                //         join sub in db.Subjects on rgexam.ExamDetId.ToString() equals sub.ShortCode
                //         where rgexam.ExamDetId == ExamPeriodId
                //         select new CollSubjectExamResult
                //         {
                //             StudentId = se.StudentId,
                //             Mark = se.Mark,
                //             SubjectCode = rgexam.ExamDetId.ToString(),
                //             Description = sub.Description,
                //             OutOf = sub.OutOf
                //         };
                //var lst = yt.ToList();

                //foreach (var item in lst)
                //{
                //    item.Point = this.PointLookUp(item.Mark, gradingsys);
                //    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                //}

                return null;


            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }

        public List<SubjectResult> GetPSExamResultsBySubject(int ExamPeriodId, int ClassId, int gradingsys)
        {
            try
            {

                //var yt = from se in db.StudentExams
                //         join rgexam in db.RegisteredExams on se.RegdExamId equals rgexam.RegdExamId
                //         join sub in db.Subjects on rgexam.ExamDetId.ToString() equals sub.ShortCode
                //         where rgexam.ExamDetId == ExamPeriodId
                //         select new PSSubjectExamResult
                //         {
                //             StudentId = se.StudentId,
                //             Mark = se.Mark,
                //             SubjectCode = rgexam.ExamDetId.ToString(),
                //             Description = sub.Description,
                //             OutOf = sub.OutOf
                //         };
                //var lst = yt.ToList();

                //foreach (var item in lst)
                //{
                //    item.Point = this.PointLookUp(item.Mark, gradingsys);
                //    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                //}

                return null;

            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }


        public List<UniSubjectExamResult> GetUniExamResultsBySubject(int ExamPeriodId, int ClassId, int gradingsys)
        {
            try
            {
                //var yt = from se in db.StudentExams
                //         join rgexam in db.RegisteredExams on se.RegdExamId equals rgexam.RegdExamId
                //         join sub in db.Subjects on rgexam.ExamDetId.ToString() equals sub.ShortCode
                //         where rgexam.ExamDetId == ExamPeriodId
                //         select new UniSubjectExamResult
                //         {
                //             StudentId = se.StudentId,
                //             Mark = se.Mark,
                //             SubjectCode = rgexam.ExamDetId.ToString(),
                //             Description = sub.Description,
                //             OutOf = sub.OutOf
                //         };
                //var lst = yt.ToList();

                //foreach (var item in lst)
                //{
                //    item.Point = this.PointLookUp(item.Mark, gradingsys);
                //    item.Grade = this.GradeLookUp(item.Mark, gradingsys);
                //}

                return null;

            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<StudentExamResult> GetExamResultsByClassBySubject(int examperiodid, int examtypeid, Subject _Subject, int RegdExamId, int gradingsys)
        {
            try
            {
                //var yt = from se in db.StudentExams  
                //         join rg in db.RegisteredExams on se.RegdExamId equals rg.RegdExamId
                //         join st in db.Students on se.StudentId equals st.StudentId
                //         join cs in db.ClassStreams on st.CurrentClass equals cs.ClassStreamId
                //         join sc in db.SchoolClasses on cs.SchoolClass equals sc.ClassId
                //         join exm in db.Exams on sc.ClassId equals exm.ClassId
                //         join exmdet in db.ExamDets on rg.ExamDetId equals exmdet.ExamDetId
                //         where exmdet.ExamTypeId == examtypeid
                //         where exm.ExamId == exmdet.ExamId
                //         join sj in db.Subjects on exm.SubjectShortCode equals sj.ShortCode
                //         where exm.ExamPeriodId == examperiodid
                //         where sj.ShortCode == _Subject.ShortCode
                //         where se.RegdExamId == RegdExamId
                //         select new StudentExamResult
                //         {
                //             Mark = se.Mark,
                //             StudentAdminNo = st.AdminNo,
                //             StudentId = se.StudentId,
                //             StudentName = st.StudentOtherNames + " " + st.StudentSurName,
                //             //Grade = GradeLookUp(se.Mark, gradingsys)
                //         };
                return null;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<StudentExamResult> GetExamResultsByClassBySubjectByExamType(string programmeid)
        {
            try
            {

                var yt = from pc in db.StudentExams
                         //where pc.StudentId == programmeid
                         group pc by new { pc.StudentId } into g
                         //orderby g.Key.ClassSubject ascending
                         //orderby g.Key.Semester ascending
                         select new StudentExamResult
                         {
                             //StudentAdminNo =g.Key.ClassSubject
                         }
                         ;
                return yt.ToList();

            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClsSubjectExamResult> GetClsExamResultsBySubject(int ExamPeriodId, int ClassId, int gradingsys)
        {
            try
            {

                var yt = from pc in db.StudentExams
                         //where pc.StudentId == programmeid
                         group pc by new { pc.StudentId } into g
                         //orderby g.Key.ClassSubject ascending
                         //orderby g.Key.Semester ascending
                         select new ClsSubjectExamResult
                         {
                             //StudentAdminNo =g.Key.ClassSubject
                         }
                         ;
                return yt.ToList();

            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "MarkSheet"
        #region "General Ledger"


        #endregion "General Ledger"
        #region "Programmes"
        public void AddNewProgramme(Programme p)
        {
            try
            {
                Programme programme = new Programme();
                programme.Id = p.Id;
                programme.Description = p.Description;
                programme.Hours = p.Hours;
                programme.Fees = p.Fees;
                programme.Status = p.Status;
                programme.IsDefault = p.IsDefault;
                programme.IsDeleted = p.IsDeleted;

                db.Programmes.AddObject(programme);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateProgramme(Programme p)
        {
            try
            {
                Programme programme = db.Programmes.First(r => r.Id == p.Id);
                programme.Description = p.Description;
                programme.Hours = p.Hours;
                programme.Fees = p.Fees;
                programme.Status = p.Status;
                programme.IsDefault = p.IsDefault;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteProgramme(Programme p)
        {
            try
            {
                Programme programme = db.Programmes.Where(r => r.Id == p.Id).Single();
                programme.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Programme> GetAllProgrammes()
        {
            try
            {
                return db.Programmes.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public Programme GetProgramme(string ProgrammeID)
        {
            try
            {
                return db.Programmes.Where(p => p.Id == ProgrammeID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Programmes"
        #region "ProgrammeYearCourses"
        public void AddNewProgrammeCourse(ProgrammeYearCours pc)
        {
            try
            {
                ProgrammeYearCours programmecourse = new ProgrammeYearCours();
                programmecourse = pc;

                if (!db.ProgrammeYearCourses.Any(o => o.ProgrammeId == programmecourse.ProgrammeId && o.CourseId == programmecourse.CourseId))
                {
                    db.ProgrammeYearCourses.AddObject(programmecourse);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateProgrammeCourse(ProgrammeYearCours pc)
        {
            try
            {
                ProgrammeYearCours programmecourse = db.ProgrammeYearCourses.First(r => r.Id == pc.Id);

                programmecourse.ProgrammeId = pc.ProgrammeId;
                programmecourse.CourseId = pc.CourseId;
                programmecourse.ProgrammeYearId = pc.ProgrammeYearId;
                programmecourse.Semester = pc.Semester;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteProgrammeCourse(ProgrammeYearCours p)
        {
            try
            {
                ProgrammeYearCours programmecourse = db.ProgrammeYearCourses.Where(r => r.Id == p.Id).Single();
                programmecourse.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ProgrammeYearCours> GetAllProgrammeCourses(string programmeid)
        {
            try
            {
                var subjects = db.ProgrammeYearCourses.Where(i => i.ProgrammeId == programmeid && i.IsDeleted == false);
                if (subjects == null) return null;
                return subjects.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ProgrammeYearCours> GetProgrammeCourses(string programmeid)
        {
            try
            {
                var progcourse = from sub in db.ProgrammeYearCourses
                                 where sub.IsDeleted == false
                                 join pc in db.Subjects on sub.CourseId equals pc.ShortCode
                                 where sub.ProgrammeId == programmeid
                                 where pc.IsDeleted == false
                                 where pc.Status == "A"
                                 select sub;
                if (progcourse == null) return null;
                return progcourse.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ProgrammeYearCours> ProgrammeYearCourses(string programmeid, int year, int term)
        {
            try
            {
                var _programmequery = (from pr in db.Programmes
                                       where pr.Id == programmeid
                                       where pr.IsDeleted == false
                                       select pr).FirstOrDefault();
                Programme _Programme = _programmequery;

                var _Programyearquery = (from py in db.ProgrammeYears
                                         where py.ProgrammeId == _Programme.Id
                                         where py.Year == year
                                         where py.IsDeleted == false
                                         select py).FirstOrDefault();
                ProgrammeYear _ProgrammeYear = _Programyearquery;

                var ProgrammeYearCoursesquery = from pc in db.ProgrammeYearCourses
                                                where pc.ProgrammeId == _Programme.Id
                                                where pc.IsDeleted == false
                                                where pc.ProgrammeYearId == _ProgrammeYear.Id
                                                where pc.Semester == term
                                                select pc;
                List<ProgrammeYearCours> _ProgrammeYearCourses = ProgrammeYearCoursesquery.ToList();

                if (_ProgrammeYearCourses == null) return null;
                return _ProgrammeYearCourses;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<YearTerm> GetProgrammeYearTerms(string programmeid)
        {
            try
            {

                var yt = from pc in db.ProgrammeYears
                         join py in db.ProgrammeYears on pc.Id equals py.Id
                         where pc.ProgrammeId == programmeid
                         where pc.IsDeleted == false
                         where py.IsDeleted == false
                         group pc by new { py.Year } into g
                         orderby g.Key.Year ascending
                         select new YearTerm
                         {
                             Year = g.Key.Year
                         }
                         ;
                var lst = yt.ToList();

                foreach (var item in lst)
                {
                    var _progYrquery = (from pry in db.ProgrammeYears
                                        where pry.IsDeleted == false
                                        where pry.ProgrammeId == programmeid
                                        where pry.Year == item.Year
                                        select pry).FirstOrDefault();
                    ProgrammeYear _ProgrammeYear = _progYrquery;
                    var Semestersquery = (from sm in db.ProgrammeYearCourses
                                          where sm.IsDeleted == false
                                          where sm.ProgrammeId == programmeid
                                          where sm.ProgrammeYearId == _ProgrammeYear.Id
                                          select sm.Semester).Distinct().ToList();

                    item.Term = Semestersquery;
                }
                return lst;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<StudentExamResult> SubjectExamResults(int registeredexamid, int gradingsys)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "ProgrammeYearCourses"
        #region "GradingSystem"
        public void AddNewGradingSystem(GradingSystem g)
        {
            try
            {
                if (!db.GradingSystems.Any(o => o.Description == g.Description))
                {
                    GradingSystem gradingsystem = new GradingSystem();
                    gradingsystem = g;

                    db.GradingSystems.AddObject(gradingsystem);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateGradingSystem(GradingSystem g)
        {
            try
            {
                GradingSystem gradingsystem = db.GradingSystems.First(r => r.Id == g.Id);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteGradingSystem(GradingSystem g)
        {
            try
            {
                GradingSystem gradingsystem = db.GradingSystems.Where(r => r.Id == g.Id).Single();

                db.GradingSystems.DeleteObject(gradingsystem);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<GradingSystem> GetAllGradingSystem()
        {
            try
            {
                return db.GradingSystems.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public string RemarkLookUp(double? Mark, int gradingsys)
        {
            if (!Mark.HasValue) return "No Mark";
            if (!(Mark is double)) return "No Mark";
            try
            {
                var rt = (from r in db.GradingSystemDets
                          orderby r.LMark ascending
                          where r.GradingSystemId == gradingsys
                          where r.LMark <= Mark.Value
                          where r.UMark >= Mark.Value
                          select r).SingleOrDefault();
                string ret = "Unknown";
                if (rt == null) { return ret; }
                return rt.Remarks.Trim();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return "Unknown";
            }
        }
        public string GradeLookUp(double? Mark, int gradingsys)
        {
            if (!Mark.HasValue) return "No Mark";
            if (!(Mark is double)) return "No Mark";
            try
            {
                var rt = (from r in db.GradingSystemDets
                          orderby r.LMark ascending
                          where r.GradingSystemId == gradingsys
                          where r.LMark <= Mark.Value
                          where r.UMark >= Mark.Value
                          select r).SingleOrDefault();
                string ret = "Unknown";
                if (rt == null) { return ret; }
                return rt.Grade.Trim();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return "Unknown";
            }
        }
        public double? PointLookUp(double? Mark, int gradingsys)
        {
            if (!Mark.HasValue) return null;
            var rt = (from r in db.GradingSystemDets
                      orderby r.LMark ascending
                      where r.GradingSystemId == gradingsys
                      where r.LMark <= Mark.Value
                      where r.UMark >= Mark.Value
                      select r).SingleOrDefault();
            if (rt == null) { return null; }
            return rt.Point;
        }
        public string GradeLookUpGivenPoint(int? Point, int gradingsys)
        {
            if (!Point.HasValue) return "No Mark";
            if (!(Point is int)) return "No Mark";
            try
            {
                var rt = (from r in db.GradingSystemDets
                          orderby r.LMark ascending
                          where r.GradingSystemId == gradingsys
                          where r.Point == Point.Value
                          select r).SingleOrDefault();
                string ret = "Unknown";
                if (rt == null) { return ret; }
                return rt.Grade.Trim();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return "Unknown";
            }
        }
        #endregion "GradingSystem"
        #region "GradingSystemDet"
        public void AddNewGradingSystemDet(GradingSystemDet gs)
        {
            try
            {

                GradingSystemDet gradingsystemdet = new GradingSystemDet();
                gradingsystemdet = gs;

                db.GradingSystemDets.AddObject(gradingsystemdet);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateGradingSystemDet(GradingSystemDet gs)
        {
            try
            {

                GradingSystemDet gradingsystemdet = db.GradingSystemDets.First(r => r.Id == gs.Id);


                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);


            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteGradingSystemDet(GradingSystemDet gs)
        {
            try
            {

                GradingSystemDet gradingsystemdet = db.GradingSystemDets.Where(r => r.Id == gs.Id).Single();

                db.GradingSystemDets.DeleteObject(gradingsystemdet);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<GradingSystemDet> GetAllGradingSystemDets()
        {
            try
            {

                return db.GradingSystemDets.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "GradingSystemDet"
        #region "Rooms"
        public void AddNewRoom(Room r)
        {
            try
            {
                Room room = new Room();
                room.ShortCode = r.ShortCode;
                room.Description = r.Description;
                room.Capacity = r.Capacity;
                room.Status = r.Status;

                db.Rooms.AddObject(room);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateRoom(Room r)
        {
            try
            {
                Room room = db.Rooms.First(i => i.Id == r.Id);
                room.ShortCode = r.ShortCode;
                room.Description = r.Description;
                room.Capacity = r.Capacity;
                room.Status = r.Status;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteRoom(Room r)
        {
            try
            {
                Room room = db.Rooms.Where(i => i.Id == r.Id).Single();
                room.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Room> GetAllRooms()
        {
            try
            {
                return db.Rooms.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Room> GetActiveRooms()
        {
            try
            {
                return db.Rooms.Where(i => i.Status == "A" && i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Rooms"
        #region "Residence"
        public void UpdateResidence(Residence r)
        {
            try
            {
                Residence _Residence = db.Residences.First(i => i.ResidenceId == r.ResidenceId);
                _Residence.ParentId = r.ParentId;
                _Residence.Name = r.Name;
                _Residence.Cost = r.Cost;
                _Residence.GPSCordinates = r.GPSCordinates;
                _Residence.Title = r.Title;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "Residence"
        #region "FeesStructure"
        public void UpdateFeesStructure(FeesStructure fs)
        {
            try
            {
                FeesStructure _FeesStructure = db.FeesStructures.First(i => i.Id == fs.Id);
                _FeesStructure.Description = fs.Description;
                _FeesStructure.Year = fs.Year;
                _FeesStructure.IsDefault = fs.IsDefault;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "FeesStructure"
        #region "FeeStructureOther"
        public void UpdateFeeStructureOther(FeeStructureOther fso)
        {
            try
            {
                FeeStructureOther _FeeStructureOther = db.FeeStructureOthers.First(i => i.Id == fso.Id);
                _FeeStructureOther.FeeStructureId = fso.FeeStructureId;
                _FeeStructureOther.AccountId = fso.AccountId;
                _FeeStructureOther.Description = fso.Description;
                _FeeStructureOther.Amount = fso.Amount;
                _FeeStructureOther.AmountPeriod = fso.AmountPeriod;
                _FeeStructureOther.ApplicableTo = fso.ApplicableTo;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "FeeStructureOther"
        #region "FeeStructureAcademic"
        public void UpdateFeeStructureAcademic(FeeStructureAcademic fsa)
        {
            try
            {
                FeeStructureAcademic _FeeStructureAcademic = db.FeeStructureAcademics.First(i => i.Id == fsa.Id);
                _FeeStructureAcademic.FeeStructureId = fsa.FeeStructureId;
                _FeeStructureAcademic.SchoolClassId = fsa.SchoolClassId;
                _FeeStructureAcademic.AccountId = fsa.AccountId;
                _FeeStructureAcademic.Term = fsa.Term;
                _FeeStructureAcademic.Description = fsa.Description;
                _FeeStructureAcademic.Amount = fsa.Amount;
                _FeeStructureAcademic.AmountPeriod = fsa.AmountPeriod;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "FeeStructureAcademic"
        #region "Attendance"
        public void AddNewAttendance(AttendanceModel _attendance)
        {
            try
            {
                Attendance _Attendance = new Attendance();
                _Attendance.StudentId = _attendance.StudentId;
                _Attendance.SubjectShortCode = _attendance.SubjectShortCode;
                _Attendance.StartDateTime = _attendance.StartDateTime;
                _Attendance.EndDateTime = _attendance.EndDateTime;
                _Attendance.Attended = _attendance.Attended;
                _Attendance.ReasonForNotAttending = _attendance.ReasonForNotAttending;
                _Attendance.IsDeleted = _attendance.IsDeleted;

                db.Attendances.AddObject(_Attendance);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAttendance(AttendanceModel _attendance)
        {
            try
            {
                Attendance _Attendance = db.Attendances.First(i => i.Id == _attendance.Id);
                _Attendance.StudentId = _attendance.StudentId;
                _Attendance.SubjectShortCode = _attendance.SubjectShortCode;
                _Attendance.StartDateTime = _attendance.StartDateTime;
                _Attendance.EndDateTime = _attendance.EndDateTime;
                _Attendance.Attended = _attendance.Attended;
                _Attendance.ReasonForNotAttending = _attendance.ReasonForNotAttending;

                if (!db.Attendances.Any(o => o.StudentId == _Attendance.StudentId && o.SubjectShortCode == _Attendance.SubjectShortCode && o.StartDateTime == _Attendance.StartDateTime && o.EndDateTime == _Attendance.EndDateTime))
                {
                    db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAttendance(AttendanceModel _attendance)
        {
            try
            {
                Attendance _Attendance = db.Attendances.Where(i => i.Id == _attendance.Id).Single();
                _Attendance.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AttendanceModel> GetAllAttendances()
        {
            try
            {
                var _attendancequery = from at in db.Attendances
                                       join st in db.Students on at.StudentId equals st.Id
                                       join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                                       join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                                       join sb in db.Subjects on at.SubjectShortCode equals sb.ShortCode
                                       where st.IsDeleted == false
                                       where cs.IsDeleted == false
                                       where sc.IsDeleted == false
                                       where sb.IsDeleted == false
                                       select new AttendanceModel
                                       {
                                           AdminNo = st.AdminNo,
                                           Attended = at.Attended,
                                           ClassStreamId = cs.Id,
                                           EndDateTime = at.EndDateTime,
                                           Id = at.Id,
                                           IsDeleted = at.IsDeleted,
                                           ReasonForNotAttending = at.ReasonForNotAttending,
                                           SchoolClassId = sc.Id,
                                           StartDateTime = at.StartDateTime,
                                           StudentId = at.StudentId,
                                           SubjectShortCode = at.SubjectShortCode,
                                           ClassName = sc.ClassName,
                                           ClassStreamName = cs.Description,
                                           StudentName = st.StudentSurName + " " + st.StudentOtherNames,
                                           SubjectDescription = sb.Description
                                       };
                List<AttendanceModel> _attendances = _attendancequery.ToList();
                return _attendances;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Attendance> GetAllStudentAttendances(int studentid)
        {
            try
            {
                return db.Attendances.Where(i => i.IsDeleted == false && i.StudentId == studentid).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Attendance> GetAllSubjectAttendances(string subjectshortcode)
        {
            try
            {
                return db.Attendances.Where(i => i.IsDeleted == false && i.SubjectShortCode == subjectshortcode).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Attendance> GetAttendancesinPeriod(DateTime starttime, DateTime endtime)
        {
            try
            {
                return db.Attendances.Where(i => i.IsDeleted == false && i.StartDateTime == starttime && i.EndDateTime == endtime).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Attendance"
        #region "Location"
        public void UpdateLocation(Location _loc)
        {
            try
            {
                Location _Location = db.Locations.First(i => i.Id == _loc.Id);
                _Location.Description = _loc.Description;
                _Location.TransportCost = _loc.TransportCost;
                _Location.BoardingCost = _loc.BoardingCost;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "Location"
        #region "LocationProperties"
        public void UpdateLocationProperty(LocationProperty _locprop)
        {
            try
            {

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "LocationProperties"
        #region "COA"
        public void UpdateCOA(COA _coa)
        {
            try
            {
                COA _COA = db.COAs.First(i => i.Id == _coa.Id);
                _COA.Description = _coa.Description;
                _COA.ShortCode = _coa.ShortCode;
                _COA.COALevel = _coa.COALevel;
                _COA.Rorder = _coa.Rorder;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "COA"
        #region "Discipline"
        public void UpdateDiscipline(Discipline _displine)
        {
            try
            {
                Discipline _Displine = db.Disciplines.First(i => i.Id == _displine.Id);
                _Displine.StudentId = _displine.StudentId;
                _Displine.DisciplineCategoryId = _displine.DisciplineCategoryId;
                _Displine.DisciplinaryDate = _displine.DisciplinaryDate;
                _Displine.Incident = _displine.Incident;
                _Displine.Severity = _displine.Severity;
                _Displine.ActionRecommended = _displine.ActionRecommended;
                _Displine.ActionTaken = _displine.ActionTaken;
                _Displine.DisciplineRating = _displine.DisciplineRating;
                _Displine.Review = _displine.Review;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteDiscipline(Discipline _displine)
        {
            try
            {
                Discipline _Displine = db.Disciplines.Where(i => i.Id == _displine.Id).Single();
                _Displine.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<Discipline> GetAllDisciplines()
        {
            try
            {
                return db.Disciplines.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Discipline"
        #region "DisciplinaryCategory"
        public void UpdateDisciplineCategory(DisciplinaryCategory _displinecategory)
        {
            try
            {
                DisciplinaryCategory _DisciplinaryCategory = db.DisciplinaryCategories.First(i => i.Id == _displinecategory.Id);
                _DisciplinaryCategory.ShortCode = _displinecategory.ShortCode;
                _DisciplinaryCategory.Description = _displinecategory.Description;
                _DisciplinaryCategory.Status = _displinecategory.Status;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteDisciplinaryCategory(DisciplinaryCategory _displinecategory)
        {
            try
            {
                DisciplinaryCategory _DisciplinaryCategory = db.DisciplinaryCategories.Where(i => i.Id == _displinecategory.Id).Single();
                _DisciplinaryCategory.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<DisciplinaryCategory> GetAllDisciplinaryCategories()
        {
            try
            {
                return db.DisciplinaryCategories.Where(i => i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<DisciplinaryCategory> GetActiveDisciplinaryCategories()
        {
            try
            {
                return db.DisciplinaryCategories.Where(i => i.Status == "A" && i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "DisciplinaryCategory"
        #region "PL_Level2"
        public void AddProfitandLoss(List<PL_Level2> pl2lst)
        {
            try
            {
                foreach (PL_Level2 pl2 in pl2lst)
                {
                    AddProfitandLoss(pl2);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void AddProfitandLoss(PL_Level2 PL2)
        {
            try
            {
                PL_Level2 _PL2 = new PL_Level2();
                _PL2.ParentId = PL2.ParentId;
                _PL2.Description = PL2.Description;
                _PL2.AccField = PL2.AccField;
                _PL2.PLCriteria = PL2.PLCriteria;
                _PL2.Yr1Amount = PL2.Yr1Amount;
                _PL2.Yr2Amount = PL2.Yr2Amount;
                _PL2.ROrder = PL2.ROrder;

                if (!db.PL_Level2.Any(i => i.Description == _PL2.Description && i.ParentId == _PL2.ParentId))
                {
                    db.PL_Level2.AddObject(_PL2);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearPL_Level2()
        {
            try
            {
                db.ExecuteStoreCommand("TRUNCATE TABLE PL_Level2");

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "PL_Level2"
        #region "BS_Level2"
        public void AddBalanceSheet(BS_Level2 BS2)
        {
            try
            {
                BS_Level2 _BS2 = new BS_Level2();
                _BS2.ParentId = BS2.ParentId;
                _BS2.Description = BS2.Description;
                _BS2.AccField = BS2.AccField;
                _BS2.BSCriteria = BS2.BSCriteria;
                _BS2.Yr1Amount = BS2.Yr1Amount;
                _BS2.Yr2Amount = BS2.Yr2Amount;
                _BS2.ROrder = BS2.ROrder;

                if (!db.BS_Level2.Any(i => i.Description == _BS2.Description && i.ParentId == _BS2.ParentId))
                {
                    db.BS_Level2.AddObject(_BS2);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ClearBS_Level2()
        {
            try
            {
                db.ExecuteStoreCommand("TRUNCATE TABLE BS_Level2");
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "BS_Level2"
        #region "SmsMessageStores"
        public void AddNewSmsMessageStore(GSMMessage _sms)
        {
            try
            {
                SmsMessageStore sms = new SmsMessageStore();
                sms.MessageBody = _sms.MessageBody;
                sms.Storage = _sms.Storage;
                sms.Status = _sms.Status;
                sms.UserDataText = _sms.UserDataText;
                sms.SmscAddressType = _sms.SmscAddressType;
                sms.SmscAddress = _sms.SmscAddress;
                sms.SCTimestamp = _sms.SCTimestamp;
                sms.OriginatingAddressType = _sms.OriginatingAddressType;
                sms.OriginatingAddress = _sms.OriginatingAddress;
                sms.MessageType = _sms.MessageType;
                sms.MessageIndex = _sms.MessageIndex;
                sms.MessageStatus = _sms.MessageIndex;
                sms.IsDeleted = _sms.IsDeleted;
                sms.Processed = _sms.Processed;

                db.SmsMessageStores.AddObject(sms);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateSmsMessageStore(GSMMessage _sms)
        {
            try
            {
                SmsMessageStore sms = db.SmsMessageStores.First(i => i.Id == _sms.Id);
                sms.MessageBody = _sms.MessageBody;
                sms.Storage = _sms.Storage;
                sms.Status = _sms.Status;
                sms.UserDataText = _sms.UserDataText;
                sms.SmscAddressType = _sms.SmscAddressType;
                sms.SmscAddress = _sms.SmscAddress;
                sms.SCTimestamp = _sms.SCTimestamp;
                sms.OriginatingAddressType = _sms.OriginatingAddressType;
                sms.OriginatingAddress = _sms.OriginatingAddress;
                sms.MessageType = _sms.MessageType;
                sms.MessageIndex = _sms.MessageIndex;
                sms.MessageStatus = _sms.MessageStatus;
                sms.Processed = _sms.Processed;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteSmsMessageStore(GSMMessage _sms)
        {
            try
            {
                SmsMessageStore sms = db.SmsMessageStores.Where(i => i.Id == _sms.Id).Single();
                sms.IsDeleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<GSMMessage> GetAllSmsMessageStores()
        {
            try
            {
                var smsquery = from _sms in db.SmsMessageStores
                               where _sms.OriginatingAddress == "MPESA"
                               select new GSMMessage
                               {
                                   Id = _sms.Id,
                                   MessageBody = _sms.MessageBody,
                                   Storage = _sms.Storage,
                                   Status = _sms.Status,
                                   UserDataText = _sms.UserDataText,
                                   SmscAddressType = _sms.SmscAddressType,
                                   SmscAddress = _sms.SmscAddress,
                                   SCTimestamp = _sms.SCTimestamp,
                                   OriginatingAddressType = _sms.OriginatingAddressType,
                                   OriginatingAddress = _sms.OriginatingAddress,
                                   MessageType = _sms.MessageType,
                                   MessageIndex = _sms.MessageIndex,
                                   IsDeleted = _sms.IsDeleted,
                                   MessageStatus = _sms.MessageStatus,
                                   Processed = _sms.Processed
                               };
                return smsquery.OrderByDescending(i => i.SCTimestamp).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "SmsMessageStores"
        #endregion "Public Methods"











    }
}