using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_生产工单
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 工单编号 { get; set; }
        public string 工单类型 { get; set; }
        public string 产品型号 { get; set; }
        public string 订单号 { get; set; }
        public string BOM编号 { get; set; }
        public string 工艺路线编号 { get; set; }
        public string 计划产量 { get; set; }
        public string 单位 { get; set; }
        public string 优先级 { get; set; }
        public string 计划开始时间 { get; set; }
        public string 计划结束时间 { get; set; }
        public string 产线编号 { get; set; }
        public string 超产上限 { get; set; }
        public string 状态 { get; set; }
        public string 用户编号 { get; set; }
        public string 系统时间 { get; set; }
        public string 备注说明 { get; set; }
    }

}
