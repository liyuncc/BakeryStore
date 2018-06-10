using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryStore.Models;
namespace BakeryStore.Controllers
{
    public class RegisterController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "LastName, FirstName, Email, Phone, Password")] NewPerson np)
        {
            Message m = new Message();
            int result = db.usp_newPerson(np.LastName, np.FirstName, np.Email, np.Phone, np.Password);
            if (result != -1)
            {
                m.MessageText = "Welcome, " + np.FirstName;
            }
            else
            {
                m.MessageText = "Oops, something went wrong with the registration. Please try again!";
            }

            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}