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
        FixtureEntityContext entityContext = new FixtureEntityContext();
        // GET: OutRecord
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 读取领用记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ReadOutRecords()
        {
            User currentUser = (User)Session["CurrentUser"];
            SqlParameter param = new SqlParameter("@workCellID", currentUser.WorkCellID);
           
            List<FixtureOutRecord> fixtureOutRecords = context.OutRecords.SqlQuery("select * from FixtureOutRecord as fr" +
                " where ProdLineID in ( select ProdLineID from FixtureDefinition where WorkCellID=@workCellID and Code= fr.Code)" +
                " ORDER BY ID ASC",param).ToList();
             
            return Json(fixtureOutRecords, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加领用记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddOutRecord()
        {
            string Code = Request["code"];
            int SeqID = Convert.ToInt32(Request["seqID"]);
            string UsedByName = Request["usedByName"];
            string OperationByName = Request["operationByName"];
            int ProdLineID = Convert.ToInt32(Request["prodLineID"]);
            DateTime UsedDate = Convert.ToDateTime(Request["usedDate"]);

            // TODO 判断是否是本部门的夹具 不是则无法添加
            FixtureOutRecord outRecord = new FixtureOutRecord();
            outRecord.Code = Code;
            outRecord.SeqID = SeqID;
            outRecord.UsedByName = UsedByName;
            outRecord.OperationByName = OperationByName;
            outRecord.ProdLineID = ProdLineID;
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
            try
            {
                context.OutRecords.Add(outRecord);
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
            //领用记录添加成功
            AddUsedCount(Code, SeqID);
                   
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 夹具使用次数加一
        /// </summary>
        /// <param name="code"></param>
        /// <param name="seqID"></param>
        public void AddUsedCount(string code, int seqID)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@code",code),
                new SqlParameter("@seqID",seqID),
            };
            FixtureEntity fixtureEntity = entityContext.fixtureEntities.Find(code,seqID);
            fixtureEntity.UsedCount += 1;
           // entityContext.fixtureEntities.SqlQuery("update FixtureEntity set UsedCount = UsedCount + 1 where Code=N@code and SeqID=@seqID");
            entityContext.SaveChanges();
        }
        /// <summary>
        ///  删除领用记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteOutRecords()
        {

            //TODO
            string jsonData = Request["ItemIDs"];
            JArray jArray = JArray.Parse(jsonData);
            foreach (var item in jArray)
            {
                JsonSerializer js = new JsonSerializer();
                ItemID obj = (ItemID)js.Deserialize(item.CreateReader(), typeof(ItemID));
                SqlParameter[] parms = new SqlParameter[]
                {
                     new SqlParameter ("@id",obj.ID),
                };
                //TODO try catch
                FixtureOutRecord record = context.OutRecords.SqlQuery("select * from FixtureOutRecord where ID=@id", parms).Single();
                try
                {
                    context.OutRecords.Remove(record);
                }
                catch (Exception e)
                {
                    var exception = new
                    {
                        success = false,
                        msg = "没有该记录",
                    };
                    return Json(exception, JsonRequestBehavior.AllowGet);
                }
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
