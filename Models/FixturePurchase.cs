using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    [Serializable]
    public class FixturePurchase
    {
        public string AppBy { get; set; }
        public string AppByName { get; set; }
        public int FamilyID { get; set; }
      
        public string Code { get; set; }
       
        public int SeqID { get; set; }
        [Key]
        public string BillNo { get; set; }
        public DateTime RegDate { get; set;}
        public string Pic { get; set; }
        public string State { get; set; }
    }
}