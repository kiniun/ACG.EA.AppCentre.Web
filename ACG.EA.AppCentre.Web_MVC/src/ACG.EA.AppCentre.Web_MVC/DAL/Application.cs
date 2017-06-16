using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACG.EA.AppCentre.Web_MVC.DAL
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public int CatalogID { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationDesc { get; set; }

        public Catalog Catalog { get; set; }
    }
}
