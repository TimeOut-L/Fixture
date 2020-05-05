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
    
        public bool LoginValidate(string code, string password, out string msg)
        {
            var _user = context.Users.Find(code);
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
            else
            {
                //可设置登录成功提示
                msg = "";
                return true;
            }
        }
        public string GetCurrentUserName(string code)
        {
            var _user= context.Users.Find(code);
            return _user.Name;
        }

        
        public User GetUserByCode(string code)
        {
            var _user = context.Users.Find(code);
            return _user;
        }

        //public List<string> GetRoleByCode(string code)
        //{
        //    var _role = from r in context.Roles
        //                where (from ur in context.UserRoles
        //                       where ur.UserCode == code
        //                       select ur.RoleID)
        //                       .Contains(r.RoleID)
        //                select r.RoleName;
        //    return _role.ToList();
        //}
        public List<MenuNode> GetMenuNodesByCode(string code)
        {
            var menuList = from m in context.MenuNodes
                       where (from ur in context.UserRoles 
                              join rm in context.RoleMenus 
                              on ur.RoleID equals rm.RoleID where ur.UserCode==code
                              select rm.MenuID
                                )
                              .Contains(m.MenuID)
                       select m;
            return menuList.ToList();
        }
    }
}