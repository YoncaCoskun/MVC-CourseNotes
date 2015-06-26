using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcBlog.EF;

namespace MvcBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Update-Database yerine alttakini yazdık
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, BlogConfiguration>());
        }
    }
}