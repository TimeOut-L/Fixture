using FixtureManagement.Models;
using FixtureManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Service
{
    public interface UserService
    {
        /// <summary>
        /// 登录验证接口
        /// </summary>
        /// <param name="code"> 登录账号</param>
        /// <param name="password">密码</param>
        /// <param name="msg"> 返回的提示信息</param>
        /// <returns> true :通过 false 不通过</returns>
        bool LoginValidate(string code,string password,string workCell,out string msg);

        

        /// <summary>
        /// 获取 账户信息
        /// </summary>
        /// <param name="code">账户</param>
        /// <returns></returns>
        User GetUserByCode(string code);

        
        //拆分到另一个服务
        List<MenuNode> GetMenuNodesByCode(string code,string workCell);
        //List<string> GetRoleByCode(string code);

        
        /// <summary>
        ///  读取用户相关信息
        /// </summary>
        /// <param name="workCell">admin 所在部门</param>
        /// <returns></returns>
        List<UserViewModel> GetAllUserWithWorkCell(string workCell);
    }
}