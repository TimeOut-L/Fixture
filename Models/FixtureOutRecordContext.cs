using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureOutRecordContext:DbContext
    {
       public FixtureOutRecordContext() : base("name=FixtureManagement")
        {
            Database.SetInitializer<FixtureOutRecordContext>(null);//表示实体对象不初始化数据库
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除复数表名约定
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<FixtureOutRecord> OutRecords { get; set; }
    }
}