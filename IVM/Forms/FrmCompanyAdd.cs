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
    public partial class FrmCompanyAdd : IVM.FrmTemplate
    {
        public FrmCompanyAdd()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
        private void Save()
        {
            string companycode = txbcompanycode.Text.Trim();
            string companyname = txbcompanyname.Text.Trim();
            string companyaddress = txbcompanyadd.Text.Trim();
            if (companycode == "")
            {
                MessageBox.Show("请输入公司代码！");
                return;
            }
            if (companyname == "")
            {
                MessageBox.Show("请输入公司名称！");
                return;
            }
            if (App.CompanyAdd(companycode, companyname,companyaddress))
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
