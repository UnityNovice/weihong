using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Model
{
    public class huzhou_异常日志
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string 用户账号 { get; set; }
        public string 用户名称 { get; set; }
        public string 类名 { get; set; }
        public string 方法名 { get; set; }
        public string 异常名称 { get; set; }
        public string 异常信息 { get; set; }
        public string 异常源 { get; set; }
        public string 堆栈信息 { get; set; }
        public string 参数对象 { get; set; }
        public string 异常时间 { get; set; }
    }
}
