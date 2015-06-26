using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Attributes
{
    public class LoginGerektirirAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["loginDurum"] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Login/Index");
            }
        }
    }
}