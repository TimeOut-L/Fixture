using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureDefinition
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int FamilyID { get; set; }
        public string Model { get; set; }
        public string PartNo { get; set; }
        public int UPL { get; set; }
        public string UsedFor { get; set; }
        public int PMPeriod { get; set; }
        public string Owner { get; set; }
        public DateTime RecOn { get; set; }
        public string RecBy { get; set; }
        public DateTime EditOn { get; set; }
        public string EditBy { get; set; }
        public int WorkCellID { get; set; }

    }
}