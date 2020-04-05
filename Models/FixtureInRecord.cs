using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    [Serializable]
    public class FixtureInRecord
    {

        [Key]
        public int ID { get; set; }
        public string Code { get; set; }

        public int SeqID { get; set; }

        public DateTime RetDate { get; set; }
        public string RetByName { get; set; }
        public string OperationByName { get; set; }
        public int ProdLineID { get; set; }
    }
}