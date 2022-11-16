using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_合批
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 时间 { get; set; }
        public string 合批前批次1 { get; set; }
        public string 合批前批次1重量 { get; set; }
        public string 合批前批次2 { get; set; }
        public string 合批前批次2重量 { get; set; }
        public string 合批后批次 { get; set; }
        public string 合批后批次重量 { get; set; }
        public string 合批操作者 { get; set; }
    }

}
