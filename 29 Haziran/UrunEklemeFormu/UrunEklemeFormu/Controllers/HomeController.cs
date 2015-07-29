using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunEklemeFormu.Description;
using UrunEklemeFormu.Filters;
using UrunEklemeFormu.Models;

namespace UrunEklemeFormu.Controllers
{
[LogActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
         

            return View(Context.Products);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel mdl)
        {
            Context.Products.Add(mdl);

            return View("Index",Context.Products);
        }

        public ActionResult DisplayLog()
        {
            var logs = Context.ActionLogTable;

            if (logs == null)
            {

                logs = new List<ActionLogModel>();
            }
            return View(logs);
        }

    }
}