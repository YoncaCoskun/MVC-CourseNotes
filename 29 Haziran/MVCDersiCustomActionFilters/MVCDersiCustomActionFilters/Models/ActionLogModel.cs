using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDersiCustomActionFilters.Models
{
    public class ActionLog
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IP { get; set; }
        public DateTime DateTime { get; set; }
        public double TimeElapsed { get; set; }
    }

    public class ActionLogDb
    {
        public static List<ActionLog> ActionLogTable;
    }

}