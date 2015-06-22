using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Devam.Models
{
    [Table("Urunler")]
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Stok { get; set; }
        public decimal Fiyat { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }

    }
}