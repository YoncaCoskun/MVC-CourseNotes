using System.Data.Entity.ModelConfiguration;
using MvcBlog.EF;

namespace MvcBlog.FluentMappings
{
    //mapping ayarlarını bu dosyalarda tutacağız. entity class' ları üzerine attribute olarak yazmamaya çalışacağız.
    public class MapMakale : EntityTypeConfiguration<Makale>
    {
        public MapMakale()
        {
            ToTable("Makaleler");

            Property(x => x.Baslik)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Ozet)
                .IsRequired()
                .HasMaxLength(500);

            Property(x => x.Icerik)
                .IsRequired();
        }
    }
}