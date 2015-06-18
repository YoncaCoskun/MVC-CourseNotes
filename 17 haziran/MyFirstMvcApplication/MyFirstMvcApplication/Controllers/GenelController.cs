using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMvcApplication.Controllers
{
    public class GenelController : Controller
    {
        //
        // GET: /Genel/
        public ActionResult AnaSayfa()
        {
            return View();
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Kontak()
        {
            return View(); 
        }
        public ActionResult BasindaBiz()
        {
            return View();
        }
	}
}