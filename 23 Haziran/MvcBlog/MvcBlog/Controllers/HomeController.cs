using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.EF;

namespace MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BlogContext context = new BlogContext();
            var yorumlar = context.Yorumlar.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}