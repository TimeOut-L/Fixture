using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class UserContext:DbContext
    {
        public  UserContext():base("name= FixtureManagement")
        {
            Database.SetInitializer<UserContext>(null);//表示实体对象不初始化数据库
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<User> users { get; set; }
    }
}