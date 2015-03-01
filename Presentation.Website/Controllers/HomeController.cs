using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Presentation.Website.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
