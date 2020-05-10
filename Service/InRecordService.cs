using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Service
{
    public interface InRecordService
    {
        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="inRecord"> 记录 </param>
        /// <returns></returns>
        bool Add(FixtureInRecord inRecord);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ID">记录 ID </param>
        /// <returns></returns>
        bool Delete(int ID);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        bool Delete(List<int> IDs);
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="inRecord"></param>
        /// <returns></returns>
        bool Update(FixtureInRecord inRecord);

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        List<FixtureInRecord> GetAllInRecordWithWorkCell(string _workCell);

        FixtureInRecord FindByID(int ID);
        List<FixtureInRecord> QueryOutRecord();
    }
}