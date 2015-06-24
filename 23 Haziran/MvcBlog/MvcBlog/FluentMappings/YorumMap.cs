using System.Data.Entity.ModelConfiguration;
using MvcBlog.Entities;

namespace MvcBlog.FluentMappings
{
    public class YorumMap : EntityTypeConfiguration<Yorum>
    {
        public YorumMap()
        {
            ToTable("Yorumlar");

            Property(x => x.Icerik)
                .IsRequired();

            Property(x => x.MakaleId)
                .IsRequired();
        }
    }
}