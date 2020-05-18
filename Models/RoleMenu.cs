using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class RoleMenu
    {
        public int ID { get; set; }
        [Key]
        [Column(Order = 1)]

        public int RoleID { get; set; }
        [Key]
        [Column(Order =2)]
        public string MenuID { get; set; }
    }
}