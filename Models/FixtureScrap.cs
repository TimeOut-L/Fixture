using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureScrap
    {
        public string ScrapBy { get; set; }
        public string ScrapByName { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Code { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SeqId { get; set; }

        public int UsedCount { get; set; }
        public string ScrapReason { get; set; }
        public string State { get; set; }
    }
}