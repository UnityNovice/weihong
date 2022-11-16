using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_生产报工
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 批次号 { get; set; }
        public string 日期 { get; set; }
        public string 工号 { get; set; }
        public string 角色 { get; set; }
        public string 名称 { get; set; }
        public string 详情 { get; set; }
    }

}
