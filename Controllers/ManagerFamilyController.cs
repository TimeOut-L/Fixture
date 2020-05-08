using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;

namespace FixtureManagement.Controllers
{
    public class ManagerFamilyController : Controller
    {

        //测试用 
        FixtureManagerContext context = new FixtureManagerContext();

        public ActionResult Index()
        {
            return View();
        }


        //查询所有的类别
        [HttpPost]
        public ActionResult ReadFamilyRecord()
        {
            List<FixtureFamily> fixtureFamily = context.Familys.SqlQuery("select * from FixtureFamily").ToList();

            return Json(fixtureFamily, JsonRequestBehavior.AllowGet);
        }



        //修改工夹具的类别
        public ActionResult EditFamilyRecord()
        {
            int FamilyID = Convert.ToInt32(Request["FamilyID"]);
            string FamilyName = Request["FamilyName"];
            FixtureFamily family = new FixtureFamily();
            family.FamilyID = FamilyID;
            family.FamilyName = FamilyName;
            context.Entry(family).State = EntityState.Modified;
            context.SaveChanges();

            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //创建工夹具的类别
        public ActionResult AddFamilyRecord()
        {
            int FamilyID = Convert.ToInt32(Request["FamilyID"]);
            string FamilyName = Request["FamilyName"];
            FixtureFamily family = new FixtureFamily();
            family.FamilyID = FamilyID;
            family.FamilyName = FamilyName;
            context.Familys.Add(family);
            context.SaveChanges();

            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DeleteFamilyRecord() {
            return null;
        }
    }
}
