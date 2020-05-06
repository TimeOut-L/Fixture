using FixtureManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixtureManagement.Service
{
    public interface OutRecordService
    {
        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="outRecord"> 记录 </param>
        /// <returns></returns>
        bool Add(FixtureOutRecord outRecord);

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
        /// <param name="outRecord"></param>
        /// <returns></returns>
        bool Update(FixtureOutRecord outRecord);

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        List<FixtureOutRecord> GetAllOutRecordWithWorkCell(int _workCellID);
    }
}
