using FixtureManagement.Common;
using FixtureManagement.Models;
using FixtureManagement.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    //登录控制器
    
    public class LoginController :Controller
    {
        public UserService userService {  get;  set; }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult DoLogin()
        {
            string code = Request["code"];
            string password = Request["password"];
            string workCell = Request["workCell"].Trim();
            string tipMsg = "";
            
            if (!userService.LoginValidate(code,password,workCell,out tipMsg))
            {
                var retData = new
                {
                    success = false,
                    tips = tipMsg
                };
                return Json(retData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var retData = new
                {
                    success = true,
                    tips = tipMsg
                };
                CurrentUserWorkCell _user = new CurrentUserWorkCell();
                _user.code = code;
                _user.workCell = workCell;
                Session["CurrentUser"] = _user;
                return Json(retData, JsonRequestBehavior.AllowGet);
            }                           
        }

        public ActionResult DoLogout()
        {
            Session["CurrentUser"] = null;
            var data = new
            {
                success = true,
                tips = "您已退出本系统"
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}