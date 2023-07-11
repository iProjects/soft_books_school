using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using DAL;

namespace WinSBSchool
{
    public interface IAuthenticationService
    {
        void Authenticate(string userName, string password, Action<UserModel> successCallback, Action<string> failureCallback);

        string AuthenticatedUserName { get; }
    }
}
