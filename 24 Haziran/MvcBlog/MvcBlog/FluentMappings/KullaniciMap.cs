using System.Data.Entity.ModelConfiguration;
using MvcBlog.Entities;

namespace MvcBlog.FluentMappings
{
    public class KullaniciMap : EntityTypeConfiguration<Kullanici>
    {
        public KullaniciMap()
        {
            ToTable("Kullanicilar");
        }
    }
}