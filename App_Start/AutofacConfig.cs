using Autofac;
using Autofac.Integration.Mvc;
using FixtureManagement.Service;
using FixtureManagement.Service.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FixtureManagement.App_Start
{
    public class AutoFacConfig
    {
        public static IContainer container;
        public static void Reigster()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserServiceImpl>().As<UserService>();
            builder.RegisterType<OutRecordServiceImpl>().As<OutRecordService>();
            builder.RegisterType<InRecordServiceImpl>().As<InRecordService>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly())//注册mvc的Controller
                .PropertiesAutowired();//属性注入
            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
