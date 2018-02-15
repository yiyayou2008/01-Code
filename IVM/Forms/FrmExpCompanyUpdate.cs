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
    public partial class FrmExpCompanyUpdate : IVM.FrmTemplate
    {
        public string expcompanyid;
        public FrmExpCompanyUpdate()
        {
            InitializeComponent();
        }

        private void FrmExpCompanyUpdate_Load(object sender, EventArgs e)
        {
            DataTable dt = App.GetExpCompanyByid(expcompanyid);
            DataRow dr = dt.Rows[0];
            txbexpcompanyname.Text = dr["expcompanyname"].ToString();
            txbexpcompanytel.Text = dr["exptel"].ToString();
            txbprintmodel.Text = dr["printmodel"].ToString();
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

            if (App.ExpCompanyUpdate(expcompanyid,expcompanyname, expcompanytel,printmodel))
            {
                MessageBox.Show("信息更新成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("信息更新失败！");
                return;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
