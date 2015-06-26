using System.Data.Entity.ModelConfiguration;
using MvcBlog.Entities;

namespace MvcBlog.FluentMappings
{
    public class MakaleEtiketMap : EntityTypeConfiguration<MakaleEtiket>
    {
        public MakaleEtiketMap()
        {
            ToTable("MakaleEtiketler");
        }
    }
}