using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixtureManagement.Service
{
    interface PurchaseService
    {

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="outRecord"> 记录 </param>
        /// <returns></returns>
        bool Add(FixturePurchase fp);

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="outRecord"></param>
        /// <returns></returns>
        bool Update(FixturePurchase fp);


        FixturePurchase FindByBillno(string Billno);
    }
}
