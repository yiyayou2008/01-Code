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
    public partial class FrmExpAddressUpdate : IVM.FrmTemplate
    {
        public int custaddressid;
        public FrmExpAddressUpdate()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ExpAddress ead = new ExpAddress();
            ead.ExpAddressId = custaddressid;
            ead.CustomerName = txbcustomername.Text;
            ead.CustomerSend = txbcustsend.Text;
            ead.CustAddress = txbaddress.Text;
            ead.Addressee = txbsee.Text;
            ead.CustTel = txbtel.Text;
            if(App.ExpAddressUpdate (ead))
            {
                MessageBox.Show("信息更新成功！");
                Close();
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

        private void FrmExpAddressUpdate_Load(object sender, EventArgs e)
        {
            DataTable dt = App.GetAddressByid(custaddressid);
            DataRow dr = dt.Rows[0];
            txbcustomername .Text  = dr["customername"].ToString();
            txbcustsend .Text  = dr["customersend"].ToString();
            txbaddress.Text = dr["custaddress"].ToString();
            txbsee.Text = dr["addressee"].ToString();
            txbtel.Text = dr["custtel"].ToString();
        }
    }
}
