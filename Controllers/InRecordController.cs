using FixtureManagement.filter;
using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    //归还
    public class InRecordController : Controller
    {
        FixtureInRecordContext context = new FixtureInRecordContext();
        // GET: InRecord
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 读取归还记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ReadInRecords()
        {
            List<FixtureInRecord> fixtureInRecords = context.InRecords.SqlQuery("select * from FixtureInRecord  ORDER BY ID ASC").ToList();

            return Json(fixtureInRecords, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加归还记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddInRecord()
        {
            string Code = Request["code"];
            int SeqID = Convert.ToInt32(Request["seqID"]);
            string RetByName = Request["retByName"];
            string OperationByName = Request["operationByName"];
            int ProLineID = Convert.ToInt32(Request["proLineID"]);
            DateTime RetDate = Convert.ToDateTime(Request["retDate"]);
            FixtureInRecord inRecord = new FixtureInRecord();
            inRecord.Code = Code;
            inRecord.SeqID = SeqID;
            inRecord.RetByName = RetByName;
            inRecord.OperationByName = OperationByName;
            inRecord.ProdLineID = ProLineID;
            inRecord.RetDate = RetDate;
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
            try
            {
                context.InRecords.Add(inRecord);
            }
            catch (Exception e)
            {
                var exception = new
                {
                    success = false,
                    msg = "数据类型错误或不必配",
                };
                return Json(exception, JsonRequestBehavior.AllowGet);
            }
            var data = new
            {
                success = true,
            };
            context.SaveChanges();
           
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}