using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_单位基础数据
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 数据项 { get; set; }
        public string 默认单位 { get; set; }
        public string 单位转换倍率 { get; set; }
        public string 转换后单位 { get; set; }
        public string 创建用户 { get; set; }
        public string 备注说明 { get; set; }
    }

}
