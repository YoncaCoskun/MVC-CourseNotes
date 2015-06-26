using System;
using System.Collections.Generic;

namespace MvcBlog.EF
{
    public class Makale
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public DateTime YazilmaTarihi { get; set; }
        public int OkunmaSayisi { get; set; }
        public bool Silindi { get; set; }
        public int KategoriId { get; set; }

        //navigation properties
        public virtual Kategori Kategori { get; set; }

        //makale üzerinden Yorumlara erişebilmek için ekledik.
        public virtual ICollection<Yorum> Yorumlar { get; set; } 

    }
}