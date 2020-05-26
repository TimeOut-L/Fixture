using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models.Context
{
    public class FixtureManagerContext:DbContext
    {
        public FixtureManagerContext() : base("name=FixtureManagement")
        {
            Database.SetInitializer<FixtureManagerContext>(null);//表示实体对象不初始化数据库
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除复数表名约定 否则会在数据库自动建立复数表
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<MenuNode> MenuNodes { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkCell> WorkCells { get; set; }  
        public DbSet<FixtureDefinition> FixtureDefinitions { get; set; }
        public DbSet<FixtureEntity> FixtureEntities { get; set; }
        public DbSet<FixtureInRecord> InRecords { get; set; }
        public DbSet<FixtureOutRecord> OutRecords { get; set; }
        public DbSet<FixtureFamily> Familys { get; set; }
        public DbSet<FixturePurchase> Purchases { get; set; }
        public DbSet<FixtureScrap> Scraps { get; set; }
    }
}