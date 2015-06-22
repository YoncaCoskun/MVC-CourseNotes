using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_BLOCK.EF
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("BlogContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext,BlogConfiguration>()); //update mıgratıon u saglıyor.
        }
    }
}