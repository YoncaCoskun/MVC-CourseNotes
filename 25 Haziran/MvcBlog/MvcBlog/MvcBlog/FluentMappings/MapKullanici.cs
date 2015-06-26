using System.Data.Entity.ModelConfiguration;
using MvcBlog.EF;

namespace MvcBlog.FluentMappings
{
    public class MapKullanici : EntityTypeConfiguration<Kullanici>
    {
        public MapKullanici()
        {
            ToTable("Kullanicilar");
            Property(x => x.KullaniciAdi).IsRequired();
            Property(x => x.Parola).IsRequired();
        }
    }
}