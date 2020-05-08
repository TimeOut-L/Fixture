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
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    [UserFilter]
    //领用
    public class OutRecordController : Controller
    {
        public UserService userService { get; set; }
        public OutRecordService outRecordService { get; set; }

        //测试用 
        FixtureManagerContext context = new FixtureManagerContext();

        //index 页面
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
            string code = (string)Session["CurrentUser"];
            var _user = userService.GetUserByCode(code);
            var list = outRecordService.GetAllOutRecordWithWorkCell(_user.WorkCellID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加领用记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
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
            FixtureEntity fixtureEntity = context.FixtureEntities.Find(code, seqID);
            fixtureEntity.UsedCount += 1;
            // entityContext.fixtureEntities.SqlQuery("update FixtureEntity set UsedCount = UsedCount + 1 where Code=N@code and SeqID=@seqID");
            context.SaveChanges();
        }

        /// <summary>
        ///  删除领用记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult DeleteOutRecords()
        {
            //TODO
            string jsonData = Request["ItemIDs"];
            JArray jArray = JArray.Parse(jsonData);
            List<int> ids = new List<int>();
            foreach (var item in jArray)
            {
                JsonSerializer js = new JsonSerializer();
                ItemID obj = (ItemID)js.Deserialize(item.CreateReader(), typeof(ItemID));
                ids.Add(obj.ID);
            }

            if (!outRecordService.Delete(ids))
            {
                var exception = new
                {
                    success = false,
                    msg = "可能有些记录不存在"
                };
                return Json(exception, JsonRequestBehavior.AllowGet);
            }          
            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
 
        public ActionResult QeuryOutRecords()
        {
            return null;
        }

        public ActionResult UpdateOutRecord()
        {
            return null;
        }

        //重构到对应服务 FixtureDefinitions 定义
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetFixtureCode()
        {
            string code = (string)Session["CurrentUser"];
            var _user = userService.GetUserByCode(code);
            var codes = from fd in context.FixtureDefinitions
                        where fd.WorkCellID == _user.WorkCellID
                        select new
                        {
                            id = fd.ID,
                            value = fd.Code,
                        };
            return Json(codes,JsonRequestBehavior.AllowGet);
        }
        //重构到对应服务 FixtureEnitities 定义
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetFixtureSeqIDByCode()
        {
            string _code = Request["temp"];
           
            var seqIDs = from fe in context.FixtureEntities
                        where fe.Code ==_code
                        select new
                        {                           
                            value =fe.SeqID,
                        };
            var list = seqIDs.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }

}
