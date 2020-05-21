using FixtureManagement.Common;
using FixtureManagement.filter;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using FixtureManagement.Service;
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
            List<FixturePurchase> fixturePurchases = context.Purchases.SqlQuery("select * from FixturePurchase fp join UserRole ur on fp.AppBy=ur.UserCode where State='"+State+"' and WorkCell='"+currentWorkCell+"'").ToList();
            return Json(fixturePurchases, JsonRequestBehavior.AllowGet);
        }

        //查询本车间正在State的采购申请
        [HttpPost]
        public ActionResult ReadPurchaseLastPass()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string State = "终审";
            string currentWorkCell = user.workCell;
            List<FixturePurchase> fixturePurchases = context.Purchases.SqlQuery("select * from FixturePurchase fp join UserRole ur on fp.AppBy=ur.UserCode where State='" + State + "' and WorkCell='" + currentWorkCell + "'").ToList(); return Json(fixturePurchases, JsonRequestBehavior.AllowGet);
        }

        ////修改State
        //[HttpPost]
        //public ActionResult 
    }
}