using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Common
{
    [Serializable]
    public class InOutQueryRecord
    {
        public string queryCode { get; set; }
        public string queryName { get; set; }
        public string StartDate { get; set; }
        public string StopDate { get; set; }
    }
}