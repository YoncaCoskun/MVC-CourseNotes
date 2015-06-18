using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMvcApplication.Controllers
{
    public class HesapController : Controller
    {
        //
        // GET: /Hesap/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GirisYap(string kullaniciAdi, string parola)
        {
            if (kullaniciAdi == "mehmet" && parola == "123")
            {
                return RedirectToAction("AnaSayfa", "Genel");
            }

            //TempData["LoginHatasi"] = "Kullanıcı Adı Parola Yanlış";
            ViewBag.LoginUyarisi = "Kullanıcı Adı Parola Yanlış";
            
            return View("Index");
        }
    }
}