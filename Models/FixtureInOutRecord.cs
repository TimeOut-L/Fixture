using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureInOutRecord
    {
        public string UsedBy { get; set; }
        public string UsedByName { get; set; }
        public string OperationBy { get; set; }
        public string OperationByName { get; set; }
        public int ProLineID { get; set; }
        public DateTime UsedDate { get; set; }
        public string Code { get; set; }
        public int SeqID { get; set; }
        public string State { get; set; }
    }
}