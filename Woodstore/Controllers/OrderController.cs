using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Woodstore.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult CreateOrder()
        {
            return View();
        }
    }
}