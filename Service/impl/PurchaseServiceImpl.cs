using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;

namespace FixtureManagement.Service.impl
{
    public class PurchaseServiceImpl : PurchaseService
    {
        private FixtureManagerContext context = FixtureDbContextHelper.GetCurrentContext();

        public bool Add(FixturePurchase fp)
        {
            throw new NotImplementedException();
        }


        public FixturePurchase FindByBillno(string Billno)
        {
            var _record = context.Purchases.Find(Billno);
            if (_record == null)
            {
                return null;
            }
            return _record;
        }

        public bool Update(FixturePurchase fp)
        {
            var _record = context.Purchases.AsNoTracking().FirstOrDefault(o => o.BillNo == fp.BillNo);
            if (_record == null)
            {
                return false;
            }
            else
            {
                context.Purchases.Attach(fp);
                context.Entry<FixturePurchase>(fp).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}