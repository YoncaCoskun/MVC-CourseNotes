using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UrunModel
    {
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public decimal? Fiyat { get; set; }
        public short Stok { get; set; }

        //soru ısaretı olumca bos bırakılabılır anlamında oluyordu.
    }
}