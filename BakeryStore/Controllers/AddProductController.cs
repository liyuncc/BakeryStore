using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryStore.Models;
namespace BakeryStore.Controllers
{
    public class AddProductController : Controller
    {
        BakeryEntities db = new BakeryEntities();

        // GET: AddProduct
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message m = new Message();
                m.MessageText = "Dear employees, you must log in first to add a product.";
                return RedirectToAction("Result", m);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ProductKey, ProductName, ProductPrice")] Product p)
          
        {
            db.Products.Add(p);
            db.SaveChanges();
            Message m = new Message();
            m.MessageText = "The product was successfully added.";
            return View("Result", m);
           
        }
        public ActionResult Result(Message m)
        {
            return View(m);
        }

    }
}