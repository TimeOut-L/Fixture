using FixtureManagement.Common;
using FixtureManagement.filter;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using FixtureManagement.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    [UserFilter]
    //归还
    public class InRecordController : Controller
    {
        public UserService userService { get; set; }
        public InRecordService inRecordService { get; set; }

        //测试用 
        FixtureManagerContext context = new FixtureManagerContext();
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
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string code = user.code;
            //var _user = userService.GetUserByCode(code);
            var list = inRecordService.GetAllInRecordWithWorkCell(user.workCell);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加归还记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult AddInRecord()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string Code = Request["code"];
            int SeqID = Convert.ToInt32(Request["seqID"]);
            string RetByName = Request["retByName"];
            string OperationByName = Request["operationByName"];
            int ProdLineID = Convert.ToInt32(Request["prodLineID"]);
            DateTime RetDate = Convert.ToDateTime(Request["retDate"]);

            FixtureInRecord inRecord = new FixtureInRecord();
            inRecord.Code = Code;
            inRecord.SeqID = SeqID;
            inRecord.RetByName = RetByName;
            inRecord.OperationByName = OperationByName;
            inRecord.ProdLineID = ProdLineID;
            inRecord.RetDate = RetDate;

            if (!inRecordService.Add(inRecord))
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
                  
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///  删除归还记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult DeleteInRecords()
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

            if (!inRecordService.Delete(ids))
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
        public ActionResult QeuryOutRecords()
        {
            return null;
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
                var _record = inRecordService.FindByID(obj.ID);
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
                _record.RetDate = obj.Date;
                _record.RetByName = obj.ByName;
                _record.OperationByName = obj.OperationByName;
                _record.ProdLineID = obj.ProdLineId;
                if (!inRecordService.Update(_record))
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