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
    public class FixturePurchaseController : Controller
    {
        FixtureManagerContext context = new FixtureManagerContext();
        public UserService userService { get; set; }
        PurchaseService purchaseService = new PurchaseServiceImpl();

        // GET: FixturePurchase/Apply
        public ActionResult Apply()
        {
            return View();
        }

        // GET: FixturePurchase/FirstPass
        public ActionResult FirstPass()
        {
            return View();
        }

        // GET: FixturePurchase/LastPass 
        public ActionResult LastPass()
        {
            return View();
        }


        //添加采购申请
        [HttpPost]
        public ActionResult AddPurChaseRecord()
        {

            FixturePurchase fp = new FixturePurchase();
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            fp.AppBy = user.code;//获取当前申请人的工号
            fp.AppByName = userService.GetUserByCode(user.code).Name;//获取当前申请人姓名
            fp.FamilyID = Convert.ToInt32(Request["familycode"]);
            fp.Code = Request["code"];
            fp.SeqID = Convert.ToInt32(Request["seqID"]);
            fp.BillNo = Request["billNo"];
            fp.RegDate = Convert.ToDateTime(Request["regDate"]);
            fp.Pic = Request["pic"];
            fp.State = "初审";

            context.Purchases.Add(fp);
            context.SaveChanges();


            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //查询本用户提交的所有采购申请
        [HttpPost]
        public ActionResult ReadPurchaseWithUser()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string currentcode = user.code;
            List<FixturePurchase> fixturePurchases = context.Purchases.SqlQuery("select * from FixturePurchase where AppBy=" + currentcode).ToList();
            return Json(fixturePurchases, JsonRequestBehavior.AllowGet);
        }

        //查询本车间正在初审的采购申请
        [HttpPost]
        public ActionResult ReadPurchaseFirstPass()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string State = "初审";
            string currentWorkCell = user.workCell;
            List<FixturePurchase> fixturePurchases = context.Purchases.SqlQuery("select * from FixturePurchase fp join UserRole ur on fp.AppBy=ur.UserCode where State='" + State + "' and WorkCell='" + currentWorkCell + "'").ToList();
            return Json(fixturePurchases, JsonRequestBehavior.AllowGet);
        }

        //查询本车间正在State的采购申请
        [HttpPost]
        public ActionResult ReadPurchaseLastPass()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string State = "终审";
            string PassAll = "审核全过";
            string currentWorkCell = user.workCell;
            List<FixturePurchase> fixturePurchases = context.Purchases.SqlQuery("select * from FixturePurchase fp join UserRole ur on fp.AppBy=ur.UserCode where ( State='" + State + "' or State='"+PassAll+"')and WorkCell='" + currentWorkCell + "'").ToList();
            return Json(fixturePurchases, JsonRequestBehavior.AllowGet);
        }

        //申请人撤销申请
        [HttpPost]
        public ActionResult DeleteApply()
        {
            string JSONData = Request["record"];
            string[] arr = JSONData.Split(';');
            var _record = purchaseService.FindByBillno(arr[0]);
            if (_record == null)
            {
                var error = new
                {
                    succes = false,
                    msg = "该条记录不存在请刷新表格"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            _record.AppBy = _record.AppBy;
            _record.AppByName = _record.AppByName;
            _record.FamilyID = _record.FamilyID;
            _record.Code = _record.Code;
            _record.SeqID = _record.SeqID;
            _record.BillNo = _record.BillNo;
            _record.RegDate = _record.RegDate;
            _record.Pic = _record.Pic;
            _record.State = arr[1];
            if (!purchaseService.Update(_record))
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

        //通过初审
        [HttpPost]
        public ActionResult PassFirstApply()
        {

            string JSONData = Request["record"];
            string[] arr = JSONData.Split(';');
            var _record = purchaseService.FindByBillno(arr[0]);
            if (_record == null)
            {
                var error = new
                {
                    succes = false,
                    msg = "该条记录不存在请刷新表格"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            _record.AppBy = _record.AppBy;
            _record.AppByName = _record.AppByName;
            _record.FamilyID = _record.FamilyID;
            _record.Code = _record.Code;
            _record.SeqID = _record.SeqID;
            _record.BillNo = _record.BillNo;
            _record.RegDate = _record.RegDate;
            _record.Pic = _record.Pic;
            _record.State = arr[1];
            if (!purchaseService.Update(_record))
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

        //终审通过
        [HttpPost]
        public ActionResult PassLastApply()
        {

            string JSONData = Request["record"];
            string[] arr = JSONData.Split(';');
            var _record = purchaseService.FindByBillno(arr[0]);
            if (_record == null)
            {
                var error = new
                {
                    succes = false,
                    msg = "该条记录不存在请刷新表格"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            _record.AppBy = _record.AppBy;
            _record.AppByName = _record.AppByName;
            _record.FamilyID = _record.FamilyID;
            _record.Code = _record.Code;
            _record.SeqID = _record.SeqID;
            _record.BillNo = _record.BillNo;
            _record.RegDate = _record.RegDate;
            _record.Pic = _record.Pic;
            _record.State = arr[1];
            if (!purchaseService.Update(_record))
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

        //审查者驳回申请
        [HttpPost]
        public ActionResult RebutApply()
        {

            string JSONData = Request["record"];
            string[] arr = JSONData.Split(';');
            var _record = purchaseService.FindByBillno(arr[0]);
            if (_record == null)
            {
                var error = new
                {
                    succes = false,
                    msg = "该条记录不存在请刷新表格"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            _record.AppBy = _record.AppBy;
            _record.AppByName = _record.AppByName;
            _record.FamilyID = _record.FamilyID;
            _record.Code = _record.Code;
            _record.SeqID = _record.SeqID;
            _record.BillNo = _record.BillNo;
            _record.RegDate = _record.RegDate;
            _record.Pic = _record.Pic;
            _record.State = arr[1];
            if (!purchaseService.Update(_record))
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