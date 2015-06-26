using System.Data.Entity.ModelConfiguration;
using MvcBlog.EF;

namespace MvcBlog.FluentMappings
{
    public class MapYorum : EntityTypeConfiguration<Yorum>
    {
        public MapYorum()
        {
            ToTable("Yorumlar");

            Property(x => x.Icerik)
                .IsRequired()
                .HasMaxLength(800);

            Property(x => x.Yazan)
                .IsRequired();

        }
    }
}