using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;

namespace FixtureManagement.Service.impl
{
    public class RepairServiceImpl : RepairService
    {
        private FixtureManagerContext context = FixtureDbContextHelper.GetCurrentContext();

        public bool Delete(string Code, int SeqId)
        {
            var _record = context.repairs.Find(Code, SeqId);
            if (_record != null)
            {
                context.repairs.Remove(_record);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public FixtureRepair FindByCode_SeqId(string Code, int SeqId)
        {
            var _record = context.repairs.Find(Code, SeqId);
            if (_record == null)
            {
                return null;
            }
            return _record;
        }

        public bool Update(FixtureRepair fr)
        {
            var _record = context.repairs.AsNoTracking().FirstOrDefault(o => (o.Code == fr.Code && o.SeqID == fr.SeqID));
            if (_record == null)
            {
                return false;
            }
            else
            {
                context.repairs.Attach(fr);
                context.Entry<FixtureRepair>(fr).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}