using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Service
{
    interface RepairService
    {
       
        bool Update(FixtureRepair fp);
      
        bool Delete(string Code, int SeqId);

        //根据code和seqid找夹具报修表，返回夹具报修表
        FixtureRepair FindByCode_SeqId(string Code, int SeqId);
    }
}