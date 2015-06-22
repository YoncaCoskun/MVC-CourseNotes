using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MVC_BLOCK.EF
{
    public class BlogConfiguration:DbMigrationsConfiguration<BlogContext>
    {
        public BlogConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed=true;
            
        }
    }
}