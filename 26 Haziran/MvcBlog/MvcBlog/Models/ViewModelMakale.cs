using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Models
{
    //AutoMapper
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
        public List<ViewModelMakaleEtiket> Etiketler { get; set; }

        public List<SelectListItem> KategorilerTum { get; set; }
        public bool Pasif { get; set; }
    }
}