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

        /// <summary>
        /// 通过给定条件，查询在库未借出的凭证
        /// 1.所有查询条件均为空，则查询所有在库未借出的凭证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //1.所有查询条件均为空，则查询所有在库未借出的凭证
            if ( 0 == 0)
            {

            }
        }
    }
}
