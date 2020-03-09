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
        [Column(Order =1)]
        public string Code { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SeqID { get; set; }
        public string UsedByName { get; set; }
        public string OperationByName { get; set; }
        public int ProLineID { get; set; }
        public DateTime UsedDate { get; set; }
      
       
    }
}