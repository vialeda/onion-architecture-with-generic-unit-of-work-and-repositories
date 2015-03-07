using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Viainternet.OnionArchitecture.Presentation.Website.Controllers
{
    
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
