using System;
using System.Collections.Generic;

namespace MvcBlog.Entities
{
    public class Makale
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; } 
        public string Icerik { get; set; }
        public int OkunmaSayisi { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public int KategoriId { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }

        //navigation properties
        public virtual Kategori Kategori { get; set; }

        public virtual ICollection<Yorum> Yorumlar { get; set; }
    }
}