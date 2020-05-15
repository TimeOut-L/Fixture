using FixtureManagement.Common;
using FixtureManagement.filter;
using FixtureManagement.Service;
using FixtureManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    [LoginCheckFilter]
    [UserFilter]
    public class UserController : Controller
    {
        public UserService userService { get; set; }
        // GET: 用户管理
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取当前登录用户的姓名方法
        /// </summary>
        /// <returns>当前登录用户名</returns>
        [HttpPost]
        [ValidateInput(true)]
        [AllowAnonymous]
        public JsonResult GetCurrentUserName()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            var _user= userService.GetUserByCode(user.code);
            if (_user == null)
            {
                var error = new
                {
                    success = false,
                    msg = "用户不存在"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }
            var data = new
            {
                success = true,
                userName = _user.Name
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        ///Admin 管理该部门用户
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        [AllowAnonymous]
        public ActionResult ReadUsers()
        {
            var _user = (CurrentUserWorkCell)Session["CurrentUser"];
            var list = userService.GetAllUserWithWorkCell(_user.workCell);
            return Json(list,JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 得到用户菜单树
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        [AllowAnonymous]
        public ActionResult GetMenuTree()
        {
            var user = (CurrentUserWorkCell)Session["CurrentUser"];
            string _code = user.code;
            string _workCell = user.workCell;
            var menuList = userService.GetMenuNodesByCode(_code,_workCell);
            /***
             * menuTree 实际上是多棵树
             */
            List<MenuTreeViewModel> menuTrees = new List<MenuTreeViewModel>();
                  
            int index = 0;
            foreach (var menu in menuList)
            {

                //ParentMenuID=0 则为父亲节点 
                if (menu.ParentMenuID.Equals("0"))
                {
                    index++;
                    MenuTreeViewModel pNode = new MenuTreeViewModel();
                    pNode.id = menu.MenuID;
                    pNode.pId = menu.ParentMenuID;
                    pNode.name = menu.Name;
                    pNode.expandIcon = menu.ExpandIcon;
                    pNode.collapseIcon = menu.CollapseIcon;
                    pNode.nodeIcon = menu.NodeIcon;
                    //bool isparent = false;    
                    pNode.url = "#Collapse_" + index;
                    foreach (var temp in menuList)
                    {
                        if (temp.ParentMenuID == menu.MenuID)
                        {
                            MenuTreeViewModel lNode = new MenuTreeViewModel();
                            lNode.id = temp.MenuID;
                            lNode.pId = temp.ParentMenuID;
                            lNode.name = temp.Name;
                            lNode.expandIcon = temp.ExpandIcon;
                            lNode.collapseIcon = temp.CollapseIcon;
                            lNode.nodeIcon = temp.NodeIcon;
                            if (string.IsNullOrWhiteSpace(temp.ControllerName) || string.IsNullOrWhiteSpace(temp.ControllerName))
                            {
                                index++;
                                lNode.url = "#Collapse_" + index;
                            }
                            else
                                lNode.url = "/" + temp.ControllerName + "/" + temp.ActionName;
                            pNode.children.Add(lNode);
                        }
                    }
                    menuTrees.Add(pNode);
                }
            }
            return Json(menuTrees, JsonRequestBehavior.AllowGet);          
        }
    }
}