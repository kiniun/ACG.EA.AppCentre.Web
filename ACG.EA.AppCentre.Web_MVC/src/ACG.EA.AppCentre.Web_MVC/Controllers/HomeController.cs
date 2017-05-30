using System;
using Microsoft.AspNetCore.Mvc;
using SessionExtensionsLib;
using ACG.EA.AppCentre.Web.Utils;
//using Microsoft.AspNetCore.Http;

namespace ACG.EA.AppCentre.Web_MVC.Controllers
{
    public class HomeController : Controller
    {

        public string ScriptPath { get; set; }
        public string ContentPath { get; set; }
        public string StylesPath { get; set; }
        public string appCentrePath { get; set; }

        public IActionResult Index()
        {
            var name = User.Identity.Name;
            var i = name.IndexOf("\\") + 1;
            HttpContext.Session.Set("UserName", name.Substring(i, name.Length - i));
           
            HttpContext.Session.Set("InRole", false);
            HttpContext.Session.Set("IsAppCentreAdmin", false);
            HttpContext.Session.Set("IsAppAdmin", false);
            HttpContext.Session.Set("User", string.Empty);

            Utils.AppCentreAdminLib userProfile = new Utils.AppCentreAdminLib();

            HttpContext.Session.Set("InRole", userProfile.IsUserInRole(HttpContext.Session.Get<string>("Username")));

            if (HttpContext.Session.Get<bool>("InRole"))
            {
                HttpContext.Session.Set("User", Utils.AppCentreAdminLib.GetUserProfile(HttpContext.Session.Get<string>("UserName")));
                HttpContext.Session.Set("IsAppCentreAdmin", userProfile.IsAppCentreAdmin(HttpContext.Session.Get<string>("UserName")));
                HttpContext.Session.Set("IsAppAdmin", userProfile.IsAppAdmin(HttpContext.Session.Get<string>("UserName")));
            }
            else
            {
                HttpContext.Session.Set("InRole", false);
            }

            ScriptPath = "http://" + HttpContext.Request.Host + Request.Path + "/Support/Scripts";
            ContentPath = "http://" + Request.Host + Request.Path + "/Support/Content";
            StylesPath = "http://" + Request.Host + Request.Path + "/Support/Styles";
            appCentrePath = "http://" + Request.Host + Request.Path + "/Webpages";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
