using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Devam.Models
{
    public class KirazBilisimContext:DbContext
    {
        public KirazBilisimContext()
            : base("KirazBilisimContext")
        {
            Database.SetInitializer<KirazBilisimContext>(new CreateDatabaseIfNotExists<KirazBilisimContext>()); //database ı olusturacak ,package manage console gıtmeye girek kalmıyor.
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet <Kategori> Kategoriler { get; set; }
       
    }
}