using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microvast.Common.Utils;
using Microvast.Model;
using Sunny.UI;
using Sunny.UI.Win32;
using Test;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ScreenDemo1.SmallForm
{
    public partial class 合批 : UIForm
    {
        public huzhou_合批报表 合批记录变量 = null;
        public 合批()
        {
            InitializeComponent();
        }
        public 合批(huzhou_合批报表 合批)
        {
            InitializeComponent();
            合批记录变量 = 合批;
        }
        public event Action<List<string>> ByValueEvent;
        #region 双缓冲
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;//用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }
        #endregion
        private void 确认_Click(object sender, EventArgs e)
        {
            SqlSugarServerHelper sqlSugarServerHelper = new SqlSugarServerHelper();
            合批记录变量.合批前批次1 = this.合批批次号1.Text;
            合批记录变量.合批前批次2 = this.合批批次号2.Text;
            合批记录变量.合批后批次重量 = this.合批后重量.Text;
            sqlSugarServerHelper.db.Insertable(合批记录变量).ExecuteCommand();
            this.Close();
        }
    }
}
