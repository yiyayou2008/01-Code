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
    public partial class FrmCompanyUpdate : IVM.FrmTemplate
    {
        public string companyid;
        public FrmCompanyUpdate()
        {
            InitializeComponent();
        }

        private void FrmCompanyUpdate_Load(object sender, EventArgs e)
        {
            DataTable dt = App.GetCompanyByid (companyid);
            DataRow dr = dt.Rows[0];
            txbcompanycode.Text = dr["companycode"].ToString();
            txbcompanyname.Text = dr["companyname"].ToString();
            txbcompanyadd.Text = dr["companyaddress"].ToString();
        }

       
        private void Save()
        {
            string companycode = txbcompanycode.Text.Trim();
            string companyname = txbcompanyname.Text.Trim();
            string companyaddress = txbcompanyadd.Text.Trim();
            if (App.CompanyUpdate(companyid, companycode, companyname,companyaddress))
            {
                MessageBox.Show("公司信息更新成功！");
                this.Close();

            }
            else
            {
                MessageBox.Show("公司信息更新失败！");
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
