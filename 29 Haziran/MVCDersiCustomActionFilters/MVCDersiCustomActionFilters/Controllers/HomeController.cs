using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDersiCustomActionFilters.Filters;
using MVCDersiCustomActionFilters.Models;

namespace MVCDersiCustomActionFilters.Controllers
{
         [LogActionFilter]
    public class HomeController : Controller
    {
        // GET: Home

      
   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayLog()
        {
            var logs = ActionLogDb.ActionLogTable;

            if (logs==null)
            {
                
                logs=new List<ActionLog>();
            }
            return View(logs);
        }


      

    }
}