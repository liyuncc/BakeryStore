using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryStore.Models;

namespace BakeryStore.Controllers
{
    public class LoginController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email, Password")] Login l)
        {
            int results = db.usp_Login(l.Email, l.Password);
            int PKey = 0;
            Message msg = new Message();

            if (results != -1)
            {
                var pkey = (from np in db.People
                            where np.PersonEmail.Equals(l.Email)
                            select np.PersonKey).FirstOrDefault();
                PKey = (int)pkey;
                Session["PersonKey"] = PKey;
                msg.MessageText = "Welcome, " + l.Email;
            }
            else
            {
                msg.MessageText = "Invalid Login. Please try again. If it's your first time visiting our website, please register first.";
            }

            return View("Result", msg);
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }

    }
}