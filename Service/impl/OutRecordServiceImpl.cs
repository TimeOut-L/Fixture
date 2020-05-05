using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using StackExchange.Profiling;

namespace FixtureManagement.Service.impl
{
    public class OutRecordServiceImpl : OutRecordService
    {
        private FixtureManagerContext context = FixtureDbContextHelper.GetCurrentContext();

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="outRecord"> 记录 </param>
        /// <returns></returns>
        public bool Add(FixtureOutRecord outRecord)
        {
            bool _record = context.OutRecords.Any(o=>o.Code==outRecord.Code&&o.SeqID==outRecord.SeqID&&o.UsedDate==outRecord.UsedDate);
            if (!_record)
            {
                context.OutRecords.Add(outRecord);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public List<FixtureOutRecord> GetAllOutRecordWithWorkCell(int _workCellID)
        {
            
            var list = from o in context.OutRecords
                       where (from p in context.FixtureDefinitions
                              where p.WorkCellID == _workCellID
                              select p.Code).Contains(o.Code)
                              select o;
         
            return list.ToList();
        }

        public bool Update(FixtureOutRecord outRecord)
        {
            throw new NotImplementedException();
        }
    }
}