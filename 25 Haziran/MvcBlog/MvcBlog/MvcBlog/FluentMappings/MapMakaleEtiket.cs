using System.Data.Entity.ModelConfiguration;
using MvcBlog.EF;

namespace MvcBlog.FluentMappings
{
    public class MapMakaleEtiket : EntityTypeConfiguration<MakaleEtiket>
    {
        public MapMakaleEtiket()
        {
            ToTable("MakaleEtiketler");
        }
    }
}