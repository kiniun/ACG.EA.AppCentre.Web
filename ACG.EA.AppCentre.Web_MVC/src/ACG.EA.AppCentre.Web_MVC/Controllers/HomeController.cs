using System;
using Microsoft.AspNetCore.Mvc;
using ACG.EA.AppCentre.Web;
//using Microsoft.AspNetCore.Http;

namespace ACG.EA.AppCentre.Web.Controllers
{
    public class HomeController : Controller
    {

        public string ScriptPath { get; set; }
        public string ContentPath { get; set; }
        public string StylesPath { get; set; }
        public string appCentrePath { get; set; }
        IGlobalUtils _sessionVariables { get; }

        public HomeController(IGlobalUtils sessionVariables)
        {
            _sessionVariables = sessionVariables;
        }

        public IActionResult Index()
        {
            _sessionVariables.GetSessionVariables(HttpContext.User.Identity.Name);
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
