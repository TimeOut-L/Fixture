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
            //是否有相同记录
            var _record = context.OutRecords.FirstOrDefault(o => o.Code == outRecord.Code && o.SeqID == outRecord.SeqID && o.UsedDate == outRecord.UsedDate);
            if (_record == null)
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
            var _record = context.OutRecords.Find(ID);
            if (_record != null)
            {
                context.OutRecords.Remove(_record);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ids">list </param>
        /// <returns></returns>
        public bool Delete(List<int> ids)
        {
            bool pass = false;
            foreach (var i in ids)
            {
                pass = Delete(i);
            }
            //所有的都删除了 才保存
            if (pass)
                context.SaveChanges();
            return pass;
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="outRecord">记录</param>
        /// <returns></returns>
        public bool Update(FixtureOutRecord outRecord)
        {
            var _record = context.OutRecords.AsNoTracking().FirstOrDefault(o => o.ID == outRecord.ID);
            if (_record == null)
            {
                return false;
            }
            else
            {
                context.OutRecords.Attach(outRecord);
                context.Entry<FixtureOutRecord>(outRecord).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <param name="_workCellID"> 部门ID</param>
        /// <returns></returns>
        public List<FixtureOutRecord> GetAllOutRecordWithWorkCell(string _workCell)
        {

            var list = from or in context.OutRecords
                       where (from fd in context.FixtureDefinitions
                              where (from w in context.WorkCells where w.WorkCellName == _workCell 
                                     select w.WorkCellID).Contains(fd.WorkCellID)
                              select fd.Code).Contains(or.Code)
                       select or;
            return list.ToList();
        }

        public FixtureOutRecord FindByID(int ID)
        {
            var _record = context.OutRecords.Find(ID);
            if (_record == null)
            {
                return null;
            }
            return _record;
        }
        public List<FixtureOutRecord> QueryOutRecord()
        {
            throw new NotImplementedException();
        }
    }
}