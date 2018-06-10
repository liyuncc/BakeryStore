using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakeryStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your local bakery since 1999.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We would love to hear from you!";

            return View();
        }
    }
}