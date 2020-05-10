using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.ViewModels
{
    public class MenuTreeViewModel
    {
       
        //public string text { get; set; }
        //public string href { get; set; }

        //public List<MenuTreeViewModel> nodes = new List<MenuTreeViewModel>();
       
        public string id { get; set; }
        public string pId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
       
        
        public string nodeIcon { get; set; }
        public string expandIcon { get; set; }
        public string collapseIcon { get; set; }

        public List<MenuTreeViewModel> children = new List<MenuTreeViewModel>();
        // public string target { get; set; }
       // public bool open { get; set; }

    }
}