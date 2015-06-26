using System.Data.Entity.ModelConfiguration;
using MvcBlog.EF;

namespace MvcBlog.FluentMappings
{
    public class MapEtiket : EntityTypeConfiguration<Etiket>
    {
        public MapEtiket()
        {
            ToTable("Etiketler");
            Property(x => x.Ad).IsRequired();
        }
    }
}