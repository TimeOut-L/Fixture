using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureRepair
    {
        public string RepBy { get; set; }
        public string RepByName { get; set; }

        public string Code { get; set; }

        public int SeqID { get; set; }

        public string faultDes { get; set; }
        public string faultPic { get; set; }
        public string DealBy { get; set; }
        public string DealByName { get; set; }
        public string DealRes { get; set; }
        public string State { get; set; }
    }
}