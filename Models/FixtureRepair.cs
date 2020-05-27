using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureRepair
    {
        public string RepBy { get; set; }
        public string RepByName { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Code { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SeqID { get; set; }

        public string faultDes { get; set; }
        public string faultPic { get; set; }
        public string DealBy { get; set; }
        public string DealByName { get; set; }
        public string DealRes { get; set; }
        public string State { get; set; }
    }
}