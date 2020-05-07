
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    [Serializable]
    public class FixtureEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Code { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SeqID { get; set; }
        public string BillNo { get; set; }
       
        public DateTime RegDate { 
            get; set; }
        public int UsedCount { get; set; }
        public string Location { get; set; }
    }
}