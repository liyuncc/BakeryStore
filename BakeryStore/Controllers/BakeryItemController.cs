using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryStore.Models;

namespace BakeryStore.Controllers
{
    public class BakeryItemController : Controller
    {
        // GET: BakeryItem
        public ActionResult Index()
        {
            BakeryEntities db = new BakeryEntities();
            return View(db.Products.ToList());
        }
    }
}