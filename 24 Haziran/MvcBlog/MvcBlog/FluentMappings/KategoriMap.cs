using System.Data.Entity.ModelConfiguration;
using MvcBlog.Entities;

namespace MvcBlog.FluentMappings
{
    public class KategoriMap : EntityTypeConfiguration<Kategori>
    {
        public KategoriMap()
        {
            ToTable("Kategoriler");

            Property(x => x.Ad)
                .IsRequired();
        }
    }
}