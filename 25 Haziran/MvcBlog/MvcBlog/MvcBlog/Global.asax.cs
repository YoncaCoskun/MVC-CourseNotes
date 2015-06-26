using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcBlog.EF;

namespace MvcBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //update-database yapar. (migrations)
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MvcBlogContext, MvcBlogConfiguration>());

        }
    }
}
