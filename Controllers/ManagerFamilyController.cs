using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using FixtureManagement.Common;
using FixtureManagement.filter;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    [UserFilter]
    public class ManagerFamilyController : Controller
    {   
        FixtureManagerContext context = new FixtureManagerContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        //查询所有的类别
        [HttpPost]
        public ActionResult ReadFamilyRecord()
        {
            List<FixtureFamily> fixtureFamily = context.Familys.SqlQuery("select * from FixtureFamily").ToList();

            return Json(fixtureFamily, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [AllowAnonymous]
        //修改工夹具的类别
        public ActionResult EditFamilyRecord()
        {
            string jsonData = Request["record"];
            string[] arr = jsonData.Split(';');
            FixtureFamily family = new FixtureFamily();
            family.FamilyID = Convert.ToInt32(arr[0]);
            family.FamilyName = arr[1];
            context.Entry(family).State = EntityState.Modified;
            context.SaveChanges();

            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        //创建工夹具的类别
        [AllowAnonymous]
        public ActionResult AddFamilyRecord()
        {
            int FamilyID = 0;
            string FamilyName = Request["name"];
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
        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteFamilyRecord() {
            string jsonData = Request["record"];
            string[]  arr = jsonData.Split(';');
            FixtureFamily family = context.Familys.Find(Convert.ToInt32(arr[0]));
            int id = family.FamilyID;
            string name = family.FamilyName;
            context.Familys.Remove(family);
            context.SaveChanges();
            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteFamilyRecords()
        {
            string datastring = Request["record"];
            string[] ids = datastring.Split(';');
            foreach (string id in ids)
            {
              
                var _record = context.Familys.Find(Convert.ToInt32(id));
                if (_record != null)
                {
                    context.Familys.Remove(_record);
                }
                context.SaveChanges();

            }
            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
