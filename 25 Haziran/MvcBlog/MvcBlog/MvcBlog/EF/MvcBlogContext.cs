using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcBlog.FluentMappings;

namespace MvcBlog.EF
{
    public class MvcBlogContext : DbContext
    {
        public MvcBlogContext()
            : base("MvcBlogContext")
        {
            
        }

        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<MakaleEtiket> MakaleEtiketler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //FluentMapping' leri çalıştırdık
            modelBuilder.Configurations.Add(new MapEtiket());
            modelBuilder.Configurations.Add(new MapKategori());
            modelBuilder.Configurations.Add(new MapKullanici());
            modelBuilder.Configurations.Add(new MapMakale());
            modelBuilder.Configurations.Add(new MapMakaleEtiket());
            modelBuilder.Configurations.Add(new MapYorum());

            base.OnModelCreating(modelBuilder);
        }
    }
}