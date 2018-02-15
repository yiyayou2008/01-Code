using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommClass;

namespace IVM
{
    public partial class FrmExpressUpdate : IVM.FrmTemplate
    {
        Express exp = new Express();
        public FrmExpressUpdate()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            exp.MegerNumber = txbmernumber.Text;
            exp.ExpNumber = txbexpnumber.Text;
            if (App.ExpressUpdate(exp))
            {
                MessageBox.Show("信息更新成功！");
            }
            else
            {
                MessageBox.Show("信息更新失败！");
                return;
            }

        }
        private void GetExpnumber(string mernumber)
        {

        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbmernumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string megnumber = txbmernumber.Text;
            string expnumber = App.GetExpnumberByMernumber(megnumber);
            if (expnumber == "")
            {
                MessageBox.Show("没有找到信息！");
                return;
            }
            else
                txbexpnumber.Text = expnumber;
        }
    }
}
