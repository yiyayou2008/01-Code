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
    public partial class FrmSerchInfo : IVM.FrmTemplate
    {
        public FrmSerchInfo()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string invnumber = txbinvnumber.Text.Trim();
            string expnumber = txbexpnumber.Text.Trim();
            string custname = txbcustname.Text.Trim();
            string datefr = txbtimefr.Text;
            string dateto = txbtimet.Text;
            string sqlcode = "";
            if(invnumber !="")
            {
                if(!App.CheckInvIsSend (invnumber ))
                {
                    MessageBox.Show("系统中未发现该发票信息！");
                    return;
                }
                else
                sqlcode = sqlcode + " and ti.invnumber='" + invnumber + "'";
            }
            if(expnumber !="")
            {
                if(!App.CheckExpNumber (expnumber ))
                {
                    MessageBox.Show("系统中没有该快递单信息！");
                    return;
                }
                else
                sqlcode = sqlcode + " and te.ExpNumber='" + expnumber + "'";
                    
            }
            if(custname !="")
            {
                sqlcode = sqlcode + " and ti.custName like '%" + custname + "%'";
            }
            if (datefr != "")
            {
                if (dateto != "")
                {
                    sqlcode = sqlcode + " and CONVERT(varchar(100), te.ExpDate, 23)>='" + datefr + "' and CONVERT(varchar(100),te.ExpDate, 23)<='" + dateto + "'";
                }
                else
                {
                    sqlcode = sqlcode + " and CONVERT(varchar(100), te.ExpDate, 23)='" + datefr + "'";
                }
            }

            DataTable dt = App.GetSerchInfo(sqlcode);
            int ItemCount = 0;
            livserchinfo.Items.Clear();
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["InvNumber"].ToString();
                li.SubItems.Add(row["ExpNumber"].ToString());
                li.SubItems.Add(row["ExpDate"].ToString());
                li.SubItems.Add(row["CustomerSend"].ToString());
                li.SubItems.Add(row["CustAddress"].ToString());
                li.SubItems.Add(row["Addressee"].ToString());
                li.SubItems.Add(row["CustTel"].ToString());
                livserchinfo.Items.Add(li);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSerchInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txbtimefr.Text = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            txbtimet.Text = dateTimePicker3.Value.ToString("yyyy-MM-dd");
        }
    }
}
