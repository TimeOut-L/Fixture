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
                       where ur.WorkCell == workCell
                       select new
                       {
                           ID = ur.ID,
                           Code = ur.UserCode,
                           Password = u.Password,
                           Name = u.Name,
                           RoleName = r.RoleName,
                           WorkCell = ur.WorkCell,
                       };
            list = list.Distinct();
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

        public bool Add(string code, string password, string name, string roleName, string workCell)
        {
            User user = new User();
            var _user = context.Users.Find(code);
            // 如果 user 表里存在该用户 则在userRole 添加 相应权限记录
            if (_user != null)
            {
                user = _user;
            }
            // 不存在 则新增该用户 然后再userRole 添加 相应权限记录
            else
            {
                var _workCell = context.WorkCells.Where(w => w.WorkCellName == workCell);
                user.Code = code;
                user.Password = password;
                user.Name = name;
                user.WorkCellID = _workCell.FirstOrDefault().WorkCellID;
                context.Users.Add(user);
            }
            var list = from r in context.Roles where r.RoleName == roleName select r.RoleID;
            if (list.Count() == 0)
            {
                return false;
            }
            var RoleID = list.FirstOrDefault();
            // 无法添加相同的userRole 且 一个用户在一个部门只能拥有一个角色
            UserRole userRole = new UserRole();
            var _userRole = context.UserRoles.Where(ur => ur.UserCode == code && ur.WorkCell == workCell);

            if (_userRole.Count() != 0)
            {
                return false;
            }
            userRole.RoleID = RoleID;
            userRole.UserCode = code;
            userRole.WorkCell = workCell;

            context.UserRoles.Add(userRole);
            context.SaveChanges();
            return true;
        }

        /// <summary>
        ///  删除当前部门用户 ,用户可能在其他部门拥有角色
        /// </summary>
        /// <param name="userView"></param>
        /// <returns></returns>
        public bool Delete(UserViewModel userView)
        {
            var _user = context.Users.Find(userView.Code);
            if (_user == null)
            {
                return false;
            }
            var list = from r in context.Roles where r.RoleName == userView.RoleName select r.RoleID;
            if (list.Count() == 0)
            {
                return false;
            }
            int RoleID = list.FirstOrDefault();
            //获取 code 的 所有userRole 记录
            var _userRoles = context.UserRoles.Where(ur => ur.UserCode == userView.Code);
            // 筛选当前部门记录
            var _userRole = _userRoles.FirstOrDefault(ur => ur.WorkCell == userView.WorkCell);
            //删除记录
            _userRoles.ToList().Remove(_userRole);
            context.UserRoles.Remove(_userRole);
            //如果 删除后 没有记录了 删除该用户
            if (_userRoles.Count() == 0)
                context.Users.Remove(_user);
            return true;
        }

        public bool Delete(List<UserViewModel> userViews)
        {
            bool pass = false;
            foreach (var item in userViews)
            {
                pass = Delete(item);
            }
            //所有的都删除了 才保存
            if (pass)
                context.SaveChanges();
            return pass;
        }
    }
}