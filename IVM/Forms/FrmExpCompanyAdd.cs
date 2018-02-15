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
    public partial class FrmExpCompanyAdd : IVM.FrmTemplate
    {
        public FrmExpCompanyAdd()
        {
            InitializeComponent();
        }

        private void FrmExpCompanyAdd_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            string expcompanyname = txbexpcompanyname.Text.Trim();
            string expcompanytel = txbexpcompanytel.Text.Trim();
            string printmodel = txbprintmodel.Text.Trim();
            if (expcompanyname == "")
            {
                MessageBox.Show("请输入快递公司名称！");
                return;
            }
            if(printmodel =="")
            {
                MessageBox.Show("请输入快递单打印模板名称！");
                return;
            }
          
            if (App.ExpCompanyAdd(expcompanyname, expcompanytel,printmodel))
            {
                MessageBox.Show("信息保存成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("信息保存失败！");
                return;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
