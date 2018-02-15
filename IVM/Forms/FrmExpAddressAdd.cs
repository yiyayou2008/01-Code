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
    public partial class FrmExpAddressAdd : IVM.FrmTemplate
    {
        ExpAddress eadd = new ExpAddress();
        public FrmExpAddressAdd()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if(txbcustomername .Text=="")
            {
                MessageBox .Show ("请输入客户名称！");
                return ;
            }
            if(txbcustsend .Text =="")
            {
                MessageBox .Show ("请输入客户邮寄名称！");
                return ;
            }
            if(txbaddress .Text =="")
            {
                MessageBox .Show ("请输入邮寄地址！");
                return ;

            }
            if(txbsee .Text =="")
            {
                MessageBox .Show("请输入收件人！");
                return ;
            }
            if (txbtel .Text =="")
            {
                MessageBox .Show ("请输入联系电话！");
                return ;
            }
            
            eadd.CustomerName = txbcustomername.Text;
            eadd.CustomerSend = txbcustsend.Text;
            eadd.CustAddress = txbaddress.Text;
            eadd.Addressee = txbsee.Text;
            eadd.CustTel = txbtel.Text;
            if (!App.CheckAddress(eadd))
            {
                if (App.CustAddressAdd(eadd))
                {
                    MessageBox.Show("信息保存成功！");
                    Close();
                }
                else
                {
                    MessageBox.Show("信息保存失败！");
                    return;


                }
            }
            else
            {
                MessageBox.Show("信息与系统重复，请核实！");
                return;
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbcustomername_TextChanged(object sender, EventArgs e)
        {
            eadd.CustomerName = txbcustomername.Text;
            if (App.CheckCustomName(eadd))
            {
                FrmCustAddPoP frm = new FrmCustAddPoP();
                frm.custname = eadd.CustomerName;
                frm.ShowDialog();
            }
        }
    }
}
