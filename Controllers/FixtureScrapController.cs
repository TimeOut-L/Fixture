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
    public class FixtureScrapController : Controller
    {
        FixtureManagerContext context = new FixtureManagerContext();
        public UserService userService { get; set; }
        ScrapService scrapService = new ScrapServiceImpl();
        // GET: FixtureScrap/Apply
        public ActionResult Apply()
        {
            return View();
        }

        // GET: FixtureScrap/FirstPass
        public ActionResult FirstPass()
        {
            return View();
        }

        // GET: FixtureScrap/LastPass 
        public ActionResult LastPass()
        {
            return View();
        }

        //添加报废申请
        [HttpPost]
        public ActionResult AddScrapRecord()
        {
            FixtureScrap fs = new FixtureScrap();
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            fs.ScrapBy = user.code;//获取当前申请人的工号
            fs.ScrapByName = userService.GetUserByCode(user.code).Name;//获取当前申请人姓名
            fs.Code = Request["code"];
            fs.SeqId = Convert.ToInt32(Request["seqID"]);
            FixtureEntity fixtureEntity = context.FixtureEntities.Find(fs.Code,fs.SeqId);
            fs.UsedCount = fixtureEntity.UsedCount;
            fs.ScrapReason = Request["reason"];
            fs.State = "初审";
            context.Scraps.Add(fs);
            context.SaveChanges();

            var data = new
            {
                success = true,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
            
        }

        //查询本用户能查看的报废申请
        [HttpPost]
        public ActionResult ReadScrapWithUser()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string currentcode = user.code;
            List<FixtureScrap> fixtureScraps = context.Scraps.SqlQuery("select * from FixtureScrap where ScrapBy=" + currentcode).ToList();
            return Json(fixtureScraps, JsonRequestBehavior.AllowGet);
            
        }
        //查询本车间正在初审的报废申请
        [HttpPost]
        public ActionResult ReadScrapFirstPass()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string State = "初审";
            string currentWorkCell = user.workCell;
            List<FixtureScrap> fixturePurchases = context.Scraps.SqlQuery("select * from FixtureScrap fs join UserRole ur on fs.ScrapBy=ur.UserCode where State='" + State + "' and WorkCell='" + currentWorkCell + "'").ToList();
            return Json(fixturePurchases, JsonRequestBehavior.AllowGet);
        }

        //查询本车间正在终审的报废申请
        [HttpPost]
        public ActionResult ReadScrapLastPass()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string State = "终审";
            string PassAll = "审核全过";
            string currentWorkCell = user.workCell;
            List<FixtureScrap> fixturePurchases = context.Scraps.SqlQuery("select * from FixtureScrap fs join UserRole ur on fs.ScrapBy=ur.UserCode where ( State='" + State + "' or State='" + PassAll + "')and WorkCell='" + currentWorkCell + "'").ToList();
            return Json(fixturePurchases, JsonRequestBehavior.AllowGet);
        }

        //修改报废申请状态
        [HttpPost]
        public ActionResult UpdateScrap()
        {
            string JSONData = Request["record"];
            string[] arr = JSONData.Split(';');
            var _record = scrapService.FindByCode_SeqId(arr[0],Convert.ToInt32(arr[1]));
            if (_record == null)
            {
                var error = new
                {
                    succes = false,
                    msg = "该条记录不存在请刷新表格"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            _record.ScrapBy = _record.ScrapBy;
            _record.ScrapByName = _record.ScrapByName;
            _record.Code = _record.Code;
            _record.SeqId = _record.SeqId;
            _record.ScrapReason = _record.ScrapReason;
            _record.State = arr[2];
            if (!scrapService.Update(_record))
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