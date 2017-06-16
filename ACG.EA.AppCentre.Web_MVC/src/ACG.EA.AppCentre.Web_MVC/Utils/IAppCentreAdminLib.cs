using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACG.EA.AppCentre.Web.Utils
{
    public interface IAppCentreAdminLib
    {
        bool IsUserInRole(string username);
        string GetUserProfile(string username);
        bool IsAppCentreAdmin(string uName);
        bool IsAppAdmin(string uName);
        void UpdateUserActivity(string appId, string user, string target);
    }
}
