using FixtureManagement.Common;
using FixtureManagement.filter;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using FixtureManagement.Service;
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
        public UserService userService { get; set; }
        public OutRecordService outRecordService { get; set; }

        FixtureManagerContext context = new FixtureManagerContext();


        // GET: OutRecord
        [UserFilter]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 读取领用记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
       
        [ValidateInput(true)]
        public ActionResult ReadOutRecords()
        {
            string code  = (string)Session["CurrentUser"];
            var _user = userService.GetUserByCode(code);
            var list = outRecordService.GetAllOutRecordWithWorkCell(_user.WorkCellID);        
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加领用记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [UserFilter]
        [ValidateInput(true)]
        public ActionResult AddOutRecord()
        {
            string Code = Request["code"];
            int SeqID = Convert.ToInt32(Request["seqID"]);
            string UsedByName = Request["usedByName"];
            string OperationByName = Request["operationByName"];
            int ProdLineID = Convert.ToInt32(Request["prodLineID"]);
            DateTime UsedDate = Convert.ToDateTime(Request["usedDate"]);

            // TODO 判断是否是本部门的夹具 不是则无法添加

            //数据处理
            FixtureOutRecord outRecord = new FixtureOutRecord();
            outRecord.Code = Code;
            outRecord.SeqID = SeqID;
            outRecord.UsedByName = UsedByName;
            outRecord.OperationByName = OperationByName;
            outRecord.ProdLineID = ProdLineID;
            outRecord.UsedDate = UsedDate;
            if (!outRecordService.Add(outRecord))
            {
                var exception = new
                {
                    success = false,
                    msg = "无法插入相同的数据",
                };
                return Json(exception, JsonRequestBehavior.AllowGet);
            }          
            var data = new
            {
                success = true,
            };
            //    领用记录添加成功 增加使用记录 
            //  ToDo 重构到 对应的服务中
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
            FixtureEntity fixtureEntity = context.FixtureEntities.Find(code,seqID);
            fixtureEntity.UsedCount += 1;
           // entityContext.fixtureEntities.SqlQuery("update FixtureEntity set UsedCount = UsedCount + 1 where Code=N@code and SeqID=@seqID");
            context.SaveChanges();
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
