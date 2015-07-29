using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunEklemeFormu.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        
    }
}