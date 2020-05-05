using FixtureManagement.filter;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FixtureManagement.Controllers
{
    //夹具实体信息的查询测试和 bootstrap table 
    [UserFilter]
    public class TestController:Controller
    {
        FixtureManagerContext context = new FixtureManagerContext();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoTest()
        {
            List<FixtureEntity> entities = context.FixtureEntities.SqlQuery("select * from FixtureEntity").ToList();
          
            return Json(entities, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Purchase()
        {
            return View();
        }
    }
}