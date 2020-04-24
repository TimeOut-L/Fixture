using FixtureManagement.Models;
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
        UserContext context = new UserContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DoLogin()
        {
            string code = Request["code"];
            string password = Request["password"];           
            //User user = context.users.Where(u => u.Code == code && u.Password == password).Single();
            var _user = context.users.Find(code);
            if (_user == null)           
            {
                //var data = new List<object>();
                //data.Add(new
                //{
                //    state = false,
                //    msg="用户名或密码错误"
                //}) ;
                return Content("<script>alert('用户不存在');history.go(-1);</script>");
            }
            else if(_user.Password!=password){
                return Content("<script>alert('密码错误');history.go(-1);</script>");
            }
            else{
                //TODO 
                Session["CurrentUser"] =_user;
                return RedirectToAction("Index", "Home");
            }          
        }
    }
}