using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class MenuNode
    {
        [Key]
        public int MenuID { get; set; }
        public string Name { get; set; }
      
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
       
        public int ParentMenuID { get; set; }
        public string NodeIcon { get; set; }
        
        public string ExpandIcon { get; set; }
        public string CollapseIcon { get; set; }
        //public string Icon { get; set; }

    }
}