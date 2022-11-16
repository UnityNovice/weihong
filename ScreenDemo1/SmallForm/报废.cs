using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Sunny.UI.Win32;
using Test;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ScreenDemo1.SmallForm
{
    public partial class 报废 : UIForm
    {
        public 报废()
        {
            InitializeComponent();
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

        private void 保存_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
