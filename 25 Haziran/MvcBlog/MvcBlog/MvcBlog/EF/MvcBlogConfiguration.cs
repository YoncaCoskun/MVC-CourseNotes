using System.Data.Entity.Migrations;
using System.Linq;

namespace MvcBlog.EF
{
    public class MvcBlogConfiguration : DbMigrationsConfiguration<MvcBlogContext>
    {
        public MvcBlogConfiguration()
        {
            AutomaticMigrationsEnabled = true;

            //data loss hatası alınırsa, yorumdan kaldırıp projeyi çalıştırın. sonrasında alttaki satırı tekrar yorum yapın
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MvcBlogContext context)
        {
            Kullanici usr = context.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == "mehmet");
            if (usr == null)
            {
                context.Kullanicilar.AddOrUpdate(new Kullanici
                {
                    AdSoyad = "Mehmet YILDIZ",
                    KullaniciAdi = "mehmet",
                    Parola = "1"
                });
            }

            base.Seed(context);
        }
    }
}