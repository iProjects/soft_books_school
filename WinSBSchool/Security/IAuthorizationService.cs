using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool
{

    public interface IAuthorizationService
    {
         void GetAllowedModules(string role, Action<IList<string>> callback);
    }













}
