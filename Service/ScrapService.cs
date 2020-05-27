using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Service
{
    interface ScrapService
    {



        /// <summary>
        /// 修改报废信息
        /// </summary>
        /// <param name="outRecord"></param>
        /// <returns></returns>
        bool Update(FixtureScrap fp);

        //根据code和seqid找夹具报废表，返回夹具报废表
        FixtureScrap FindByCode_SeqId(string Code,int SeqId);



    }
}