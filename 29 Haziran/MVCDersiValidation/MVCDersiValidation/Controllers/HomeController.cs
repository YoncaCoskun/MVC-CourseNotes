using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDersiValidation.Models;

namespace MVCDersiValidation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Contact(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ContactThankYou");
            }
            //mail gonderilecek
            //işlem bıttıkten soonra tesekkur sayfasına yonlendırmelıyız.
            return View();
        }

        public ActionResult ContactThankYou()
        {
            return View();
        }
    }
}