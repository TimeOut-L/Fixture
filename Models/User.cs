using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    [Serializable]
    public class User
    {
        
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
       
    }
}