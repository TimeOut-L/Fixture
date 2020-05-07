using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    [Serializable]
    public class FixtureFamily
    {
        [Key]
        [Column(Order = 1)]
        public int FamilyID { get; set; }
        public string FamilyName { get; set; }
      
    }
}