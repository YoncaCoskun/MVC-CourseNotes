using System.Data.Entity.ModelConfiguration;
using MvcBlog.Entities;

namespace MvcBlog.FluentMappings
{
    public class EtiketMap : EntityTypeConfiguration<Etiket>
    {
        public EtiketMap()
        {
            ToTable("Etiketler");

            Property(x => x.Ad)
                .IsRequired();
        }
    }
}