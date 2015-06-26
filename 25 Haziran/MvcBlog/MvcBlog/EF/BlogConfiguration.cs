using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using MvcBlog.Entities;

namespace MvcBlog.EF
{
    public class BlogConfiguration : DbMigrationsConfiguration<BlogContext>
    {
        public BlogConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogContext context)
        {
            context.Kullanicilar.AddOrUpdate(new Kullanici
            {
                Id = 4,
                KullaniciAdi = "mehmet",
                Parola = "1"
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}