using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.EF;

namespace MvcBlog.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GirisYap(string kullaniciAdi, string parola)
        {
            using (BlogContext context = new BlogContext())
            {
                var kullanici = context.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi.Trim() && x.Parola == parola.Trim());

                if (kullanici == null)
                {
                    ViewBag.LoginHatasi = "Kullanıcı adı/parola hatalı.";
                    return View("Index");
                }
                else
                {
                    //........
                    Session["loginDurum"] = true;
                    return RedirectToAction("Index", "Admin");
                }
            }
        }
    }
}