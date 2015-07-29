using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunEklemeFormu.Models;

namespace UrunEklemeFormu.Description
{
    public static class Context
    {
        public static List<ProductModel> Products=new List<ProductModel>();

        public static List<ActionLogModel> ActionLogTable = new List<ActionLogModel>();
    }
}