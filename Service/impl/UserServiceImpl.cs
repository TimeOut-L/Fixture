using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using FixtureManagement.ViewModels;
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
            var _workList = from ur in context.UserRoles
                            where ur.UserCode == code
                            select ur.WorkCell;                                                     
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
                           where (from rm in context.RoleMenus
                                  where (from ur in context.UserRoles
                                         where ur.UserCode == code && ur.WorkCell == workCell
                                         select ur.RoleID)
                                         .Contains(rm.RoleID)
                                  select rm.MenuID)
                                        .Contains(mn.MenuID)
                           select mn;
            return menuList.ToList();
        }

        public List<UserViewModel> GetAllUserWithWorkCell(string workCell)
        {
            var list = from u in context.Users
                       join ur in context.UserRoles on u.Code equals (ur.UserCode)
                       join r in context.Roles on ur.RoleID equals (r.RoleID)
                       where ur.WorkCell==workCell
                       select new
                       {
                           ID = ur.ID,
                           Code = ur.UserCode,
                           Password = u.Password,
                           Name = u.Name,
                           RoleName = r.RoleName,
                           WorkCell = ur.WorkCell,
                       };
            List<UserViewModel> userViews = new List<UserViewModel>();
            foreach (var item in list)
            {
                UserViewModel user = new UserViewModel();
                user.ID = item.ID;
                user.Code = item.Code;
                user.Password = item.Password;
                user.Name = item.Name;
                user.RoleName = item.RoleName;
                user.WorkCell = item.WorkCell;
                userViews.Add(user);
            }
            return userViews;
        }
    }
}