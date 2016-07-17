using System.Web.Mvc;

namespace Woodstore.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult Parquet()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Laminate()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Vinyl()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Plinth()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Isolation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Glue()
        {
            return View();
        }
    }
}