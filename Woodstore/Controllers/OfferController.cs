using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Woodstore.Controllers
{
    public class OfferController : Controller
    {
        [HttpGet]
        public ActionResult Offer()
        {
            return View();
        }
    }
}