using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_工序管理
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 工序编号 { get; set; }
        public string 工序描述 { get; set; }
        public string 用户编号 { get; set; }
        public string 系统时间 { get; set; }
        public string 备注说明 { get; set; }
    }
}
