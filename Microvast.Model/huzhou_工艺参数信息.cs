using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_工艺参数信息
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 参数代码 { get; set; }
        public string 参数名称 { get; set; }
        public string 工序编号 { get; set; }
        public string 单位 { get; set; }
        public string 上限 { get; set; }
        public string 下限 { get; set; }
        public string 创建用户 { get; set; }
        public string 备注说明 { get; set; }
    }

}
