using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_权限管理
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 角色ID { get; set; }
        public string 菜单项ID { get; set; }
        public string 备注说明 { get; set; }
        public string 创建时间 { get; set; }
        public string 更新时间 { get; set; }
        public string 创建者Id { get; set; }
        public string 创建者名称 { get; set; }
        public string 修改者Id { get; set; }
        public string 修改者名称 { get; set; }
    }
}
