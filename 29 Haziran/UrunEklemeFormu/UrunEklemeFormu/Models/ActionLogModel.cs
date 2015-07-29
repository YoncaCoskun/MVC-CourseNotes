using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunEklemeFormu.Models
{
    public class ActionLogModel
    {
       
            public string Controller { get; set; }
            public string Action { get; set; }
            public string IP { get; set; }
            public DateTime DateTime { get; set; }
            public double TimeElapsed { get; set; }
           
    }
   
}