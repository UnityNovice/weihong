using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_产线基础数据
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 产线编号 { get; set; }
        public string 产线描述 { get; set; }
        public string 用户编号 { get; set; }
        public string 系统时间 { get; set; }
        public string 备注说明 { get; set; }
    }
}
