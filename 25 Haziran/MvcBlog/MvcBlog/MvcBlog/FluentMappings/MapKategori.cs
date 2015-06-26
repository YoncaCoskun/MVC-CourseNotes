using System.Data.Entity.ModelConfiguration;
using MvcBlog.EF;

namespace MvcBlog.FluentMappings
{
    public class MapKategori : EntityTypeConfiguration<Kategori>
    {
        public MapKategori()
        {
            ToTable("Kategoriler");
            Property(x => x.Ad).IsRequired();
        }
    }
}