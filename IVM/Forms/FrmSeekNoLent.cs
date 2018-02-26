using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommClass;

namespace IVM
{
    public partial class FrmSeekNoLent : IVM.FrmTemplate
    {
        public FrmSeekNoLent()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //如果未给定查询条件，默认情况下显示所有未借出的凭证信息
        }
    }
}
