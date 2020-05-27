using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;

namespace FixtureManagement.Service.impl
{
    public class ScrapServiceImpl : ScrapService
    {
        private FixtureManagerContext context = FixtureDbContextHelper.GetCurrentContext();

        public FixtureScrap FindByCode_SeqId(string Code, int SeqId)
        {
            var _record = context.Scraps.Find(Code, SeqId);
            if (_record == null)
            {
                return null;
            }
            return _record;

        }

        public bool Update(FixtureScrap fs)
        {
            var _record = context.Scraps.AsNoTracking().FirstOrDefault(o =>( o.Code == fs.Code && o.SeqId == fs.SeqId) );
            if (_record == null)
            {
                return false;
            }
            else
            {
                context.Scraps.Attach(fs);
                context.Entry<FixtureScrap>(fs).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}