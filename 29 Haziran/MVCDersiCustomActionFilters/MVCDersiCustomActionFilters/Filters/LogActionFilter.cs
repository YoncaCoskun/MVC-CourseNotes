using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDersiCustomActionFilters.Models;


namespace MVCDersiCustomActionFilters.Filters
{
    //baslangıc ve bıtıs arasındakı gecen sureyı bulduk 
    public class LogActionFilter:ActionFilterAttribute,IActionFilter
    {
       
        DateTime BeginTime;
        DateTime EndTime;
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            EndTime = DateTime.Now;
            var timeElapsed = EndTime.Ticks - BeginTime.Ticks;
            TimeSpan timeSpan=new TimeSpan(timeElapsed);

            ActionLog log = new ActionLog()
            {
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = filterContext.ActionDescriptor.ActionName + "(Logged By: Log Action Filter)",
                IP = filterContext.HttpContext.Request.UserHostAddress,
                DateTime = filterContext.HttpContext.Timestamp,
                TimeElapsed = timeSpan.TotalMilliseconds
            };
            BeginTime = log.DateTime;

            if (ActionLogDb.ActionLogTable == null)
            {
                ActionLogDb.ActionLogTable = new List<ActionLog>();
            }
            ActionLogDb.ActionLogTable.Add(log);
        }

    void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
    {
       
        BeginTime=DateTime.Now;


        this.OnActionExecuting(filterContext);
    }
}
}