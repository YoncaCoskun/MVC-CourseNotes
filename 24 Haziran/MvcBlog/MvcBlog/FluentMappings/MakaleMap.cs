using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MvcBlog.Entities;

namespace MvcBlog.FluentMappings
{
    public class MakaleMap: EntityTypeConfiguration<Makale>
    {
        public MakaleMap()
        {
            //Sql' deki tablo adı
            ToTable("Makaleler");

            Property(x => x.Ozet)
                .IsRequired()
                .HasMaxLength(500);

            Property(x => x.Baslik)
                .IsRequired()
                .HasMaxLength(140);

            Property(x => x.Icerik)
                .IsRequired();

            Property(x => x.KategoriId)
                .IsRequired();

        }
    }
}