using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_载具基础数据
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 载具编码 { get; set; }
        public string 载具类型 { get; set; }
        public string 载具规格 { get; set; }
        public string 载具状态 { get; set; }
        public string 维护人员 { get; set; }
        public string 更新时间 { get; set; }
        public string 使用位置 { get; set; }
        public string 备注说明 { get; set; }
    }

}
