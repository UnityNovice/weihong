using Microvast.Common.Utils;
using Microvast.Common.Vuex;
using Microvast.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microvast.Service
{
    public class 通用Service
    {
        #region 方法 
        public static void 记录生产报工(string txt)
        {
            SqlSugarServerHelper sqlSugarServerHelper = new SqlSugarServerHelper();
            huzhou_生产报工 生产报工 = new huzhou_生产报工();
            生产报工.工号 = Store.工号;
            生产报工.角色 = Store.角色;
            生产报工.名称 = Store.名称;
            生产报工.日期 = DateTime.Now.ToString("F");
            生产报工.详情 = txt;
            sqlSugarServerHelper.db.Insertable(生产报工).ExecuteCommand();
        }
        #endregion
    }
}
