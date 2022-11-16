using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_操作日志
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 操作事项 { get; set; }
        public string 模块名称 { get; set; }
        public string 写入时间 { get; set; }
        public string 用户账号 { get; set; }
        public string 用户名称 { get; set; }
        public string IP地址 { get; set; }
        public string 返回内容 { get; set; }
        public string URL { get; set; }
        public string 新内容 { get; set; }
        public string 旧内容 { get; set; }
    }
}
