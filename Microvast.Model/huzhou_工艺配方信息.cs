using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_工艺配方信息
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 产品编号 { get; set; }
        public string 产品名称 { get; set; }
        public string 版本号 { get; set; }
        public string 配方名称 { get; set; }
        public string 工步 { get; set; }
        public string 投料或搅拌标识 { get; set; }
        public string 物料或参数代码 { get; set; }
    }
}
