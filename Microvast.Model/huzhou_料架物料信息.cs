using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_料架物料信息
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 料架编号 { get; set; }
        public string 料架位置 { get; set; }
        public string 物料编号 { get; set; }
        public string 物料名称 { get; set; }
        public string 物料批次 { get; set; }
        public string 物料数量 { get; set; }
        public string 计量单位 { get; set; }
        public string 状态 { get; set; }
        public string 上架时间 { get; set; }
        public string 备注说明 { get; set; }
    }
}
