using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FixtureManagement.Controllers
{
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
            JavaScriptSerializer jsSer = new JavaScriptSerializer();
            return Json(fixtureOutRecords, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddOutRecord()
        {
            string Code = Request["code"];
            int SeqID = Convert.ToInt32(Request["seqID"]);
            string UsedByName = Request["usedByName"];
            string OperationByName = Request["operationByName"];
            int ProLineID = Convert.ToInt32(Request["proLineID"]);
            DateTime UsedDate = Convert.ToDateTime( Request["usedDate"]);
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
            context.OutRecords.Add(outRecord);
            context.SaveChanges();
            return RedirectToAction("Index", "OutRecord");
        }
    }
}
