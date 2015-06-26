using System;

namespace MvcBlog.EF
{
    public class Yorum
    {
        public int Id { get; set; }
        public string Yazan { get; set; }
        public DateTime YorumTarihi { get; set; }
        public bool Onay { get; set; }
        public string Icerik { get; set; }
        public int MakaleId { get; set; }
        
        //navigation properties
        public virtual Makale Makale { get; set; }
    }
}