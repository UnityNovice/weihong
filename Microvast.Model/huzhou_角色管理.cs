using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_角色管理
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 角色编码 { get; set; }
        public string 角色名称 { get; set; }
        public string 排序 { get; set; }
        public string 备注说明 { get; set; }
        public string 状态 { get; set; }
        public string 创建时间 { get; set; }
        public string 更新时间 { get; set; }
        public string 创建者Id { get; set; }
        public string 创建者名称 { get; set; }
        public string 修改者Id { get; set; }
        public string 修改者名称 { get; set; }
    }
}
