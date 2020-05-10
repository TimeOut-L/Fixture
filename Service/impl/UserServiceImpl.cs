using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Service.impl
{
    public class UserServiceImpl : UserService
    {
        private FixtureManagerContext context = FixtureDbContextHelper.GetCurrentContext();

        public bool LoginValidate(string code, string password, string workCell, out string msg)
        {
            var _user = context.Users.Find(code);
            var _workList = from w in context.WorkCells
                            where (from uw in context.UserWorkCells where uw.Code == code select uw.WorkCellID)
                            .Contains(w.WorkCellID)
                            select w.WorkCellName;
            if (_user == null)
            {
                msg = "用户不存在!";
                return false;
            }
            else if (!_user.Password.Equals(password))
            {
                msg = "密码错误";
                return false;
            }
            else if (!_workList.Contains(workCell))
            {
                msg = "部门没有该用户或者部门不存在";
                return false;
            }
            else
            {
                //可设置登录成功提示
                msg = "";
                return true;
            }
        }

        public User GetUserByCode(string code)
        {
            var _user = context.Users.Find(code);
            if (_user == null)
            {
                return null;
            }
            return _user;
        }


        public List<MenuNode> GetMenuNodesByCode(string code, string workCell)
        {
            var menuList = from mn in context.MenuNodes
                           where(from rm in context.RoleMenus
                                 where(from ur in context.UserRoles
                                       where ur.UserCode == code && ur.WorkCell==workCell select ur.RoleID)
                                        .Contains(rm.RoleID)select rm.MenuID)
                                        .Contains(mn.MenuID)
                           select mn;
            return menuList.ToList();
        }
    }
}