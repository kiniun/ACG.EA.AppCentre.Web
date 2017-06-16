using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACG.EA.AppCentre.Web_MVC.DAL
{
    public class ApplicationGroup
    {
        public int GroupID { get; set; }
        public int ApplicationID { get; set; }
        public string GroupName { get; set; }

        public Application Application { get; set; }
    }
}
