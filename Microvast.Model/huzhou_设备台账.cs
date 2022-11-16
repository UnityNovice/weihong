using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_设备台账
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 设备编号 { get; set; }
        public string 设备描述 { get; set; }
        public string 产线ID { get; set; }
        public string 设备类型 { get; set; }
        public string 规格参数 { get; set; }
        public string 层次结构 { get; set; }
        public string 保修期 { get; set; }
        public string 购入安装日期 { get; set; }
        public string 供应商 { get; set; }
        public string 产地 { get; set; }
        public string 设备状态 { get; set; }
        public string 系统时间 { get; set; }
        public string 用户编号 { get; set; }
        public string 备注说明 { get; set; }
    }

}
