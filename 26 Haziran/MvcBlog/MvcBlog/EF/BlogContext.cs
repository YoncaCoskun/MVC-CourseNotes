using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcBlog.Entities;
using MvcBlog.FluentMappings;

namespace MvcBlog.EF
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("BlogContext")
        {
      
        }

        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<MakaleEtiket> MakaleEtiketler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EtiketMap());
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new KullaniciMap());
            modelBuilder.Configurations.Add(new MakaleEtiketMap());
            modelBuilder.Configurations.Add(new MakaleMap());
            modelBuilder.Configurations.Add(new YorumMap());


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("EklenmeTarihi") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("EklenmeTarihi").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("EklenmeTarihi").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}