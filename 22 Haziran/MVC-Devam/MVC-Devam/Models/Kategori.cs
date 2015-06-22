using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Devam.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAd { get; set; }
    }
}