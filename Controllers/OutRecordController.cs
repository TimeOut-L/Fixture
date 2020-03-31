using FixtureManagement.Common;
using FixtureManagement.filter;
using FixtureManagement.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    //领用
    public class OutRecordController : Controller
    {
        FixtureOutRecordContext context = new FixtureOutRecordContext();
        // GET: OutRecord
        public ActionResult Index()
        {
            return View();
        }
        // 返回领用记录（出库记录）
        [HttpPost]
        public ActionResult ReadOutRecords()
        {
            List<FixtureOutRecord> fixtureOutRecords = context.OutRecords.SqlQuery("select * from FixtureOutRecord").ToList();

            return Json(fixtureOutRecords, JsonRequestBehavior.AllowGet);
        }

        //添加领用记录
        [HttpPost]
        public ActionResult AddOutRecord()
        {
            string Code = Request["code"];
            int SeqID = Convert.ToInt32(Request["seqID"]);
            string UsedByName = Request["usedByName"];
            string OperationByName = Request["operationByName"];
            int ProLineID = Convert.ToInt32(Request["proLineID"]);
            DateTime UsedDate = Convert.ToDateTime(Request["usedDate"]);
            FixtureOutRecord outRecord = new FixtureOutRecord();
            outRecord.Code = Code;
            outRecord.SeqID = SeqID;
            outRecord.UsedByName = UsedByName;
            outRecord.OperationByName = OperationByName;
            outRecord.ProLineID = ProLineID;
            outRecord.UsedDate = UsedDate;
            //SqlParameter[] parms = new SqlParameter[]
            //{
            //    new SqlParameter ("@code",Code),
            //    new SqlParameter("@seqID",SeqID),
            //    new SqlParameter("@usedByName",UsedByName),
            //    new SqlParameter("@operationByName",OperationByName),
            //    new SqlParameter("@proLineID",ProLineID),
            //    new SqlParameter("@usedDate",UsedDate),
            //};
            //TODO try catch
            context.OutRecords.Add(outRecord);
            context.SaveChanges();
            //return Redirect("/OutRecord/Index");
            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteOutRecords()
        {
            
            //TODO
            string jsonData = Request["ItemCodes"];
            JArray jArray = JArray.Parse(jsonData);
            foreach (var item in jArray)
            {
                JsonSerializer js = new JsonSerializer();
                ItemCode obj = (ItemCode)js.Deserialize(item.CreateReader(), typeof(ItemCode));
                SqlParameter[] parms = new SqlParameter[]
                {
                     new SqlParameter ("@code",obj.Code),
                     new SqlParameter("@seqID",obj.SeqID)
                };
                //TODO try catch
                FixtureOutRecord record= context.OutRecords.SqlQuery("select * from FixtureOutRecord where Code=@code and SeqID=@seqID",parms).Single();
                context.OutRecords.Remove(record);
                context.SaveChanges();
            }
            //return RedirectToAction("Index", "OutRecord");
            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
