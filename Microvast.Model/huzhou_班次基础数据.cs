using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_班次基础数据
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 班次编号 { get; set; }
        public string 班次名称 { get; set; }
        public string 开始时间 { get; set; }
        public string 结束时间 { get; set; }
        public string 系统时间 { get; set; }
        public string 状态 { get; set; }
        public string 用户编号 { get; set; }
        public string 备注说明 { get; set; }
    }

}
