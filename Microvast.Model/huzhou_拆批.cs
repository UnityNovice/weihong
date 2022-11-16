using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_拆批
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 时间 { get; set; }
        public string 拆批源批次 { get; set; }
        public string 拆批后批次1 { get; set; }
        public string 拆批后批次1重量 { get; set; }
        public string 拆批后批次2 { get; set; }
        public string 拆批后批次2重量 { get; set; }
        public string 拆批操作者 { get; set; }
    }

}
