using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Common
{
    [Serializable]
    public class InOutEditRecord
    {
        public int ID { set; get; }
        public string Code { get; set; }
        public int SeqID { get; set; }

        public string ByName { get; set; }
        public string OperationByName { get; set; }

        public int ProdLineId { get; set; }
        public DateTime Date { get; set; }
    }
}