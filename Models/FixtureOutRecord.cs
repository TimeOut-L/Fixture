using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    [Serializable]
    public class FixtureOutRecord
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
       
        public int SeqID { get; set; }
       
        public DateTime UsedDate { get; set; }
        public string UsedByName { get; set; }
        public string OperationByName { get; set; }
        public int ProdLineID { get; set; }           
    }
}