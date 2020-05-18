using FixtureManagement.Common;
using FixtureManagement.Service;
using FixtureManagement.Service.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FixtureManagement.filter
{
    public class UserFilter : ActionFilterAttribute
    {
        public UserService userService = new UserServiceImpl();

        //action执行前
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user=(CurrentUserWorkCell)filterContext.HttpContext.Session["CurrentUser"];
            if (user == null)
            {
                filterContext.Result = new RedirectResult("../Login/Index");
            }
            string _userCode = user.code;
            var _userMenu = userService.GetMenuNodesByCode(_userCode,user.workCell);
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            var bAjax = filterContext.HttpContext.Request.IsAjaxRequest();
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            //判断是否Action判断是否跳过授权过滤器
            {
                return;
            }
            foreach (var _menu in _userMenu)
            {
                if (_menu.ControllerName == controllerName && _menu.ActionName == actionName)
                {
                    return;
                }
            }
            if (!bAjax)
                filterContext.Result = new RedirectResult("../Home/Index");
            else
            {
                var result = new
                {
                    success = false,
                    msg = "尊敬的用户,你没有该权限"
                };
                JsonResult jsonResult = new JsonResult();
                jsonResult.Data = result;
                filterContext.Result = jsonResult;
            }
            base.OnActionExecuting(filterContext);
        }
        //action 执行后
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}