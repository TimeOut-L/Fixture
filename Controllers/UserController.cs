using FixtureManagement.Service;
using FixtureManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureManagement.Controllers
{
    public class UserController : Controller
    {
        public UserService userService { get; set; }
        // GET: User
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
        public JsonResult GetCurrentUserName()
        {
            string code = (string)Session["CurrentUser"];
            string _userName = userService.GetCurrentUserName(code);
            var data = new
            {
                //result = true,
                userName = _userName
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult GetUser()
        {
            return null;
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult GetMenuTree()
        {
            string code = (string)Session["CurrentUser"];
            var menuList = userService.GetMenuNodesByCode(code);
            /***
             * menuTree 实际上是多棵树
             */
            List<MenuTreeViewModel> menuTrees = new List<MenuTreeViewModel>();
            //foreach (var menu in menuList)
            //{
            //    /***
            //     * ParentMenuID 为 -1 代表不是菜单节点 只是某个 controller 下的 action
            //     */
            //    if (menu.ParentMenuID != -1)
            //    {
            //        MenuTreeViewModel pNode = new MenuTreeViewModel();
            //        pNode.id = menu.MenuID;
            //        pNode.pId = menu.ParentMenuID;
            //        pNode.name = menu.Name;
            //        pNode.nodeIcon = menu.NodeIcon;
            //        pNode.expandIcon = menu.ExpandIcon;
            //        pNode.collapseIcon = menu.CollapseIcon;

            //        if (string.IsNullOrWhiteSpace(menu.ControllerName) || string.IsNullOrWhiteSpace(menu.ControllerName))
            //        {
            //            pNode.url = "#";
            //            pNode.open = true;
            //        }
            //        else
            //        {
            //            pNode.url = "/" + menu.ControllerName + "/" + menu.ActionName;
            //            pNode.open = false;
            //        }
            //        pNode.target = "_self";
            //        menuTrees.Add(pNode);
            //    }
            //}
            int index = 0;
            foreach (var menu in menuList)
            {

                //ParentMenuID=0 则为父亲节点 
                if (menu.ParentMenuID == 0)
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
                            lNode.id = menu.MenuID;
                            lNode.pId = menu.ParentMenuID;
                            lNode.name = temp.Name;
                            lNode.expandIcon = menu.ExpandIcon;
                            lNode.collapseIcon = menu.CollapseIcon;
                            lNode.nodeIcon = menu.NodeIcon;
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