using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FixtureManagement.Models
{
    public class FixtureEntityContext:DbContext
    {
        public FixtureEntityContext() : base("name=FixtureManagement")
        {
            Database.SetInitializer<FixtureEntityContext>(null);//表示实体对象不初始化数据库
        }
        public DbSet<FixtureEntity> fixtureEntities { get; set; }
    }
}