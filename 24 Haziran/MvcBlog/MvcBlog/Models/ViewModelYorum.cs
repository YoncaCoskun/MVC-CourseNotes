using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcBlog.Entities;

namespace MvcBlog.Models
{
    public class ViewModelYorum
    {
        public int Id { get; set; }
        public string Yazan { get; set; }
        public string Icerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Onay { get; set; }
        public int MakaleId { get; set; }
       
    }
   
}