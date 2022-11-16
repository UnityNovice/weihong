using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_用户管理
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 工号 { get; set; }
        public string 账号 { get; set; }
        public string 密码 { get; set; }
        public string 姓名 { get; set; }
        public string 性别 { get; set; }
        public string 角色 { get; set; }
        public string 部门 { get; set; }
        public string 岗位 { get; set; }
        public string 工作中心 { get; set; }
        public string 工厂 { get; set; }
        public string 状态 { get; set; }
        public string 创建时间 { get; set; }
        public string 更新时间 { get; set; }
        public string 创建者Id { get; set; }
        public string 创建者名称 { get; set; }
        public string 修改者Id { get; set; }
        public string 修改者名称 { get; set; }
        public string 工序 { get; set; }
    }
}
