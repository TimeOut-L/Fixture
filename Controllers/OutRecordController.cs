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
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string code = user.code;
            //var _user = userService.GetUserByCode(code);
            var list = outRecordService.GetAllOutRecordWithWorkCell(user.workCell);


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
            string jsonData = Request["record"];
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

        /// <summary>
        ///  查询记录 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        [AllowAnonymous]
        public ActionResult QeuryOutRecords()
        {
            string Code = Request["queryCode"];
            string Name = Request["queryName"];
            
            DateTime StartDate = Convert.ToDateTime(Request["StartDate"]);
            DateTime StopDate = Convert.ToDateTime(Request["StopDate"]);
            var result = new
            {
                success = true,
                msg = "成功"

            };
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult UpdateOutRecord()
        {
            string jsonData = Request["record"];
            JArray jArray = JArray.Parse(jsonData);

            //实际只有一条记录 传的是对象数组
            foreach (var item in jArray)
            {
                JsonSerializer js = new JsonSerializer();
                InOutEditRecord obj = (InOutEditRecord)js.Deserialize(item.CreateReader(), typeof(InOutEditRecord));
                var _record = outRecordService.FindByID(obj.ID);
                if (_record == null)
                {
                    var error = new
                    {
                        succes = false,
                        msg = "该条记录不存在请刷新表格"
                    };
                    return Json(error, JsonRequestBehavior.AllowGet);
                }
                _record.Code = obj.Code;
                _record.SeqID = obj.SeqID;
                _record.UsedDate = obj.Date;
                _record.UsedByName = obj.ByName;
                _record.OperationByName = obj.OperationByName;
                _record.ProdLineID = obj.ProdLineId;
                if (!outRecordService.Update(_record))
                {
                    var error = new
                    {
                        succes = false,
                        msg = "编辑保存失败"
                    };
                    return Json(error, JsonRequestBehavior.AllowGet);
                }
            }
            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //重构到对应服务 FixtureDefinitions 定义
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetFixtureCode()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string code = user.code;
            var _user = userService.GetUserByCode(code);
            var codes = from fd in context.FixtureDefinitions
                        where (from w in context.WorkCells where w.WorkCellName == user.workCell select w.WorkCellID).Contains(fd.WorkCellID)
                        select new
                        {
                            id = fd.ID,
                            value = fd.Code,
                        };
            return Json(codes, JsonRequestBehavior.AllowGet);

        }


        //重构到对应服务 FixtureEnitities 定义
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetFixtureSeqIDByCode()
        {
            string _code = Request["_Code"];

            var seqIDs = from fe in context.FixtureEntities
                         where fe.Code == _code
                         select new
                         {
                             value = fe.SeqID,
                         };
            var list = seqIDs.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }

}
