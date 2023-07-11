using System;
using System.Collections.Generic;
using CommonLib;
using DAL;

namespace WinSBSchool
{
    public interface IUserRepository
    {
        void GetUsers(Action<IList<UserModel>> callback);
    }



}
