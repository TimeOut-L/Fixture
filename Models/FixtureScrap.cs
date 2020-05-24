using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureScrap
    {
        public string ScrapBy { get; set; }
        public string ScrapByName { get; set; }
        public string Code { get; set; }
        public int SeqId { get; set; }
        public int UsedCount { get; set; }
        public string ScrapReason { get; set; }
    }
}