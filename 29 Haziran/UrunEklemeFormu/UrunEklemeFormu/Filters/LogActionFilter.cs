using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using UrunEklemeFormu.Models;
using UrunEklemeFormu.Description;

namespace UrunEklemeFormu.Filters
{
        public class LogActionFilter : ActionFilterAttribute, IActionFilter
        {

            DateTime BeginTime;
            DateTime EndTime;
            void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
            {
                EndTime = DateTime.Now;
                var timeElapsed = EndTime.Ticks - BeginTime.Ticks;
                TimeSpan timeSpan = new TimeSpan(timeElapsed);

                ActionLogModel log = new ActionLogModel()
                {
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Action = filterContext.ActionDescriptor.ActionName + "(Logged By: Log Action Filter)",
                    IP = filterContext.HttpContext.Request.UserHostAddress,
                    DateTime = filterContext.HttpContext.Timestamp,
                    TimeElapsed = timeSpan.TotalMilliseconds
                };
                BeginTime = log.DateTime;

                if (Description.Context.ActionLogTable == null)
                {
                    Description.Context.ActionLogTable = new List<ActionLogModel>();
                }
               Description.Context.ActionLogTable.Add(log);
            }

            void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
            {

                BeginTime = DateTime.Now;


                this.OnActionExecuting(filterContext);
            }
        }
    
}