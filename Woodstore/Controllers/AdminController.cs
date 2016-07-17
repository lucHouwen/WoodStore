using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Woodstore.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ControlPanel()
        {
            return View();
        }
    }
}