using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcBlog.Models
{
    public class ViewModelMakaleAdmin
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public int OkunmaSayisi { get; set; }
        public bool Silindi { get; set; }

        public string SilindiText
        {
            get
            {
                //if (Silindi == true)
                //    return "Evet";

                //else
                //    return "Hayır";
                if (Silindi)
                    return "Evet";
                return "Hayır";
            }
        }
    }

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
        public bool Silindi { get; set; }

        public List<SelectListItem> KategoriListesi { get; set; }
    }

}