using System;

namespace MvcBlog.Entities
{
    public class Yorum
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public string Yazan { get; set; }
        public bool Onay { get; set; }
        public DateTime EklenmeTarihi { get; set; } 
        public int MakaleId { get; set; }

        //navigation properties
        public virtual Makale Makale { get; set; }
    }
}