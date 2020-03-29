using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.filter
{
    public class LoginCheckFilter:AuthorizeAttribute
    {
      
        public override void OnAuthorization(AuthorizationContext filterContext)

        {
            var user = filterContext.HttpContext.Session["CurrentUser"];
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            //判断是否Action判断是否跳过授权过滤器
            {
                return;
            }
            else if (user == null || string.IsNullOrWhiteSpace(user.ToString()))
            //判断用户是否登录
            {
                filterContext.Result = new RedirectResult("../Login/Index");
            }
            else
            {
                return;
            }
        }
    }
}