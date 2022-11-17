using Microvast.Common.Utils;
using Microvast.Common.Vuex;
using Microvast.Model;
using Microvast.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Microvast.Service
{
    public class 通用Service
    {
        #region 方法:记录生产报工
        public static void 记录生产报工(string txt, string 工序)
        {
            SqlSugarServerHelper sqlSugarServerHelper = new SqlSugarServerHelper();
            huzhou_生产报工报表 生产报工 = new huzhou_生产报工报表();
            生产报工.工号 = Store.工号;
            生产报工.角色 = Store.角色;
            生产报工.名称 = Store.名称;
            生产报工.日期 = DateTime.Now;
            生产报工.工序 = 工序;
            生产报工.详情 = txt;
            sqlSugarServerHelper.db.Insertable(生产报工).ExecuteCommand();
        }
        #endregion
        public static List<WorkOrder> 加载工单(string aa)
        {
            SqlSugarServerHelper sqlSugarServerHelper = new SqlSugarServerHelper();
            var 生产工单s = sqlSugarServerHelper.db.Queryable<huzhou_生产工单>().Where(a => a.工序.Contains(aa)).Where(a=> a.状态=="未生产"|| a.状态 == "暂停中"|| a.状态 == "生产中").ToList();
            List<WorkOrder> workOrders = new List<WorkOrder>();
            for (int i = 0; i < 生产工单s.Count; i++)
            {
                WorkOrder workOrder = new WorkOrder();
                workOrder.workordernum = 生产工单s[i].工单编号;//"MV32022092900" + i.ToString();
                workOrder.Status = 生产工单s[i].状态;//"未生产";
                workOrder.Priority = 生产工单s[i].优先级;//"一般";
                workOrders.Add(workOrder);
            }
            return workOrders;
        }
    }
}
