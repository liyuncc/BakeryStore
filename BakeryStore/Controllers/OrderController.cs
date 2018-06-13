using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryStore.Models;

namespace BakeryStore.Controllers
{
    public class OrderController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        // GET: Order
        public ActionResult Index()
        {
             if (Session["PersonKey"] == null)
              {
                   Message m = new Message();
                   m.MessageText = "You must log in first to place your order.";

                  return RedirectToAction("Result", m);
               }
            ViewBag.products = new SelectList(db.Products, "ProductKey", "ProductName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ProductKey, ProductName, Price, Quantity")] BakeryItem i)
        {

            // Receipt: Dark Chocolate Bar ($4.50) qty 2. Subtotal: $9.00. Tax: $0.90. Total: $9.90
            

            Message m = new Message();
                  var prod = from p in db.Products
                             where p.ProductKey == i.ProductKey
                             select new { p.ProductName, p.ProductPrice };

                  foreach (var pr in prod)
                  {
                      i.ProductName = pr.ProductName.ToString();
                       i.Price = (decimal)pr.ProductPrice;
                  }
            decimal subtotal = i.Price * i.Quantity;
            decimal taxrate = 0.1m;
            decimal tax = subtotal * taxrate;
            decimal total = subtotal + tax;
            m.MessageText = "Receipt: " +
                i.ProductName + " ($" + 
                i.Price + ") qty " + i.Quantity + ". Subtotal: $" + subtotal + ". Tax: $" + tax + ". Total: $" + total;
            return View("Result", m);
        }


        public ActionResult Result(Message m)
        {
            return View(m);
        }

    }
}

