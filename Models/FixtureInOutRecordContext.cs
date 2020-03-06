using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureInOutRecordContext:DbContext
    {
       public FixtureInOutRecordContext() : base("name=FixtureManagement")
        {
            Database.SetInitializer<FixtureInOutRecordContext>(null);//表示实体对象不初始化数据库

        }
        public DbSet<FixtureInOutRecord> inOutRecords { get; set; }
    }
}