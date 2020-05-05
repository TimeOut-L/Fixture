using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class RoleMenu
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int MenuID { get; set; }
    }
}