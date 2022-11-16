using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_投料口基础数据
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 投料口代码 { get; set; }
        public string 物料代码 { get; set; }
        public string 物料名称 { get; set; }
        public string 工序编号 { get; set; }
        public string 创建用户 { get; set; }
        public string 备注说明 { get; set; }
    }

}
