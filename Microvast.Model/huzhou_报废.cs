using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_报废
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 时间 { get; set; }
        public string 报废批次号 { get; set; }
        public string 报废前数量 { get; set; }
        public string 报废后数量 { get; set; }
        public string 报废数量 { get; set; }

    }
}
