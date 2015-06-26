using System;

namespace MvcBlog.Models
{
    public class ViewModelYorum
    {
        public int Id { get; set; }
        public string Yazan { get; set; }
        public string Icerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string EklenmeTarihiStr { get; set; }
        public bool Onay { get; set; }
        public int MakaleId { get; set; }
    }
}