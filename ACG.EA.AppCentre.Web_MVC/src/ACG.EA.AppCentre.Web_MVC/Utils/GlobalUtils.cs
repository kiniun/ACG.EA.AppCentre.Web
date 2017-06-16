using System;
using Lib = SessionExtensionsLib;
using ACG.EA.AppCentre.Web.Utils;

namespace ACG.EA.AppCentre.Web
{
    public class GlobalUtils: IGlobalUtils
    {
        public IAppCentreAdminLib _userProfile { get; }

        public GlobalUtils(IAppCentreAdminLib userProfile)
        {
            _userProfile = userProfile;
        }

        public string ScriptPath { get; set; }
        public string ContentPath { get; set; }
        public string StylesPath { get; set; }
        public string appCentrePath { get; set; }

        public void GetSessionVariables(string identity)
        {
            var name = identity;
            var i = name.IndexOf("\\") + 1;
            Lib.SessionExtensions.Set("UserName", name.Substring(i, name.Length - i));

            Lib.SessionExtensions.Set("InRole", false);
            Lib.SessionExtensions.Set("IsAppCentreAdmin", false);
            Lib.SessionExtensions.Set("IsAppAdmin", false);
            Lib.SessionExtensions.Set("User", string.Empty);

            //Web.Utils.AppCentreAdminLib userProfile = new Web.Utils.AppCentreAdminLib();

            Lib.SessionExtensions.Set("InRole", _userProfile.IsUserInRole(Lib.SessionExtensions.Get<string>("Username")));

            if (Lib.SessionExtensions.Get<bool>("InRole"))
            {
                Lib.SessionExtensions.Set("User", _userProfile.GetUserProfile(Lib.SessionExtensions.Get<string>("UserName")));
                Lib.SessionExtensions.Set("IsAppCentreAdmin", _userProfile.IsAppCentreAdmin(Lib.SessionExtensions.Get<string>("UserName")));
                Lib.SessionExtensions.Set("IsAppAdmin", _userProfile.IsAppAdmin(Lib.SessionExtensions.Get<string>("UserName")));
            }
            else
            {
                Lib.SessionExtensions.Set("InRole", false);
            }

            //ScriptPath = "http://" + HttpContext.Request.Host + Request.Path + "/Support/Scripts";
            //ContentPath = "http://" + Request.Host + Request.Path + "/Support/Content";
            //StylesPath = "http://" + Request.Host + Request.Path + "/Support/Styles";
            //appCentrePath = "http://" + Request.Host + Request.Path + "/Webpages";
            //throw new NotImplementedException();
        }

        //protected string UserName = ;



    }
}
