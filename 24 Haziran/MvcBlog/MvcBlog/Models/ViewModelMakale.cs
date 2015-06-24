using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MvcBlog.Models
{
    //AutoMapper arastır.
    public class ViewModelMakale
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }

        public DateTime Tarih { get; set; }
        public int OkunmaSayisi { get; set; }
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }

    }
}