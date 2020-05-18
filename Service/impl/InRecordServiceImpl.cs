using FixtureManagement.Models;
using FixtureManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureManagement.Service.impl
{
    public class InRecordServiceImpl:InRecordService
    {
        private FixtureManagerContext context = FixtureDbContextHelper.GetCurrentContext();

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="inRecord"> 记录 </param>
        /// <returns></returns>
        public bool Add(FixtureInRecord inRecord)
        {
            //是否有相同记录
            var _record = context.InRecords.FirstOrDefault(o => o.Code == inRecord.Code && o.SeqID == inRecord.SeqID && o.RetDate == inRecord.RetDate);
            if (_record == null)
            {
                context.InRecords.Add(inRecord);
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
            var _record = context.InRecords.Find(ID);
            if (_record != null)
            {
                context.InRecords.Remove(_record);
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
        /// <param name="inRecord">记录</param>
        /// <returns></returns>
        public bool Update(FixtureInRecord inRecord)
        {
            var _record = context.InRecords.AsNoTracking().FirstOrDefault(o => o.ID == inRecord.ID);
            if (_record == null)
            {
                return false;
            }
            else
            {
                context.InRecords.Attach(inRecord);
                context.Entry<FixtureInRecord>(inRecord).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <param name="_workCellID"> 部门ID</param>
        /// <returns></returns>
        public List<FixtureInRecord> GetAllInRecordWithWorkCell(string _workCell)
        {

            var list = from ir in context.InRecords
                       where (from fd in context.FixtureDefinitions
                              where (from w in context.WorkCells
                                     where w.WorkCellName == _workCell
                                     select w.WorkCellID).Contains(fd.WorkCellID)
                              select fd.Code).Contains(ir.Code)
                       select ir;
            return list.ToList();
        }

        public FixtureInRecord FindByID(int ID)
        {
            var _record = context.InRecords.Find(ID);
            if (_record == null)
            {
                return null;
            }
            return _record;
        }
        public List<FixtureInRecord> QueryOutRecord()
        {
            throw new NotImplementedException();
        }
    }
}