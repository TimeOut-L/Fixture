using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FixtureManagement.Models;

namespace FixtureManagement.Controllers
{
    public class ManagerFamilyController : Controller
    {
        private FixtureFamilyContext context = new FixtureFamilyContext();

       
        public ActionResult Index()
        {
            return View();
        }


        //查询所有的类别
        [HttpPost]
        public ActionResult ReadFamily()
        {
            List<FixtureFamily> fixtureFamily = context.Family.SqlQuery("select * from FixtureFamily").ToList();

            return Json(fixtureFamily, JsonRequestBehavior.AllowGet);
        }



        //修改工夹具的类别
        public ActionResult Edit()
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
        public ActionResult Add()
        {
            int FamilyID = Convert.ToInt32(Request["FamilyID"]);
            string FamilyName = Request["FamilyName"];
            FixtureFamily family = new FixtureFamily();
            family.FamilyID = FamilyID;
            family.FamilyName = FamilyName;
            context.Family.Add(family);
            context.SaveChanges();

            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);

        }


    }
}
