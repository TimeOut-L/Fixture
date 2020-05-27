using FixtureManagement.Common;
using FixtureManagement.filter;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using FixtureManagement.Service;
using FixtureManagement.Service.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    [UserFilter]
    public class FixtureRepairController : Controller
    {
        FixtureManagerContext context = new FixtureManagerContext();
        public UserService userService { get; set; }
        RepairService repairService = new RepairServiceImpl();
        // GET: FixtureRepair/Apply
        public ActionResult Apply()
        {
            return View();
        }

        // GET: FixtureRepair/Dealwith
        public ActionResult DealWith()
        {
            return View();

        }


        //添加报修申请
        [HttpPost]
        public ActionResult AddRepairRecord()
        {
            FixtureRepair fr = new FixtureRepair();
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            fr.RepBy = user.code;//获取当前申请人的工号
            fr.RepByName = userService.GetUserByCode(user.code).Name;//获取当前申请人姓名
            fr.Code = Request["code"];
            fr.SeqID = Convert.ToInt32(Request["seqID"]);
            fr.faultDes = Request["faultDes"];
            fr.faultPic = Request["faultPic"];
            fr.DealBy = "";
            fr.DealByName = "";
            fr.DealRes = "";
            fr.State = "受理中";
            context.repairs.Add(fr);
            context.SaveChanges();
            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //查询本用户能查看的报废申请
        [HttpPost]
        public ActionResult ReadRepairWithUser()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string currentcode = user.code;
            List<FixtureRepair> fixtureRepairs = context.repairs.SqlQuery("select * from FixtureRepair where RepBy=" + currentcode).ToList();
            return Json(fixtureRepairs, JsonRequestBehavior.AllowGet);

        }
        //查询本车间正在初审的报废申请
        [HttpPost]
        public ActionResult ReadRepairState()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string State = "受理中";
            string currentWorkCell = user.workCell;
            List<FixtureRepair> fixturePurchases = context.repairs.SqlQuery("select * from FixtureRepair fr join UserRole ur on fr.RepBy=ur.UserCode where (State='" + State + "' or State='通过') and WorkCell='" + currentWorkCell + "'").ToList();
            return Json(fixturePurchases, JsonRequestBehavior.AllowGet);
        }

        //删除报修信息
        [HttpPost]
        public ActionResult DeleteRepairRecord()
        {
            string JSONData = Request["record"];
            string[] arr = JSONData.Split(';');
            if (!repairService.Delete(arr[0],Convert.ToInt32(arr[1])))
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

        //修改报废申请状态
        [HttpPost]
        public ActionResult UpdateRepair()
        {
            string JSONData = Request["record"];
            string[] arr = JSONData.Split(';');
            var _record = repairService.FindByCode_SeqId(arr[0], Convert.ToInt32(arr[1]));
            if (_record == null)
            {
                var error = new
                {
                    succes = false,
                    msg = "该条记录不存在请刷新表格"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }         
            _record.RepBy = _record.RepBy;
            _record.RepByName = _record.RepByName;
            _record.Code = _record.Code;
            _record.SeqID = _record.SeqID;
            _record.faultDes = _record.faultDes;
            _record.faultPic = _record.faultPic;
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            _record.DealBy = user.code;
            _record.DealByName = userService.GetUserByCode(user.code).Name;//获取当前申请人姓名
            _record.DealRes = "";
            _record.State = arr[2];
            if (!repairService.Update(_record))
            {
                var error = new
                {
                    succes = false,
                    msg = "编辑保存失败"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }

            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }



    }
}