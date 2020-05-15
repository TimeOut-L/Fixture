using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public string WorkCell { get; set; }
    }
}