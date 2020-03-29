using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Common
{
    [Serializable]
    /**
     * 物品代码
     */
    public class ItemCode
    {
       
        public string Code { set; get; }       
       
        public int SeqID { set; get; }
        
    } 
}