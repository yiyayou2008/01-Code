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
    public partial class FrmMulAddress : IVM.FrmTemplate
    {
        public string custname;
        public List<string> invnumber;
        public FrmMulAddress()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMulAddress_Load(object sender, EventArgs e)
        {
            int ItemCount = 0;
            livcustaddress.Items.Clear();
            DataTable dt = App.GetAddressCustName(custname);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["expaddressid"].ToString();
                li.SubItems.Add(row["customername"].ToString());
                li.SubItems.Add(row["customersend"].ToString());
                li.SubItems.Add(row["custaddress"].ToString());
                li.SubItems.Add(row["addressee"].ToString());
                li.SubItems.Add(row["custtel"].ToString());
                livcustaddress.Items.Add(li);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (livcustaddress.Items.Count >0)
            {
                int expaddressid = int.Parse(livcustaddress.SelectedItems[0].Text);
                for(int i=0;i<invnumber .Count;i++)
                {
                    string invno = invnumber[i].ToString();
                    if (!App.UpdateInvAddressId(invno, expaddressid))
                    {
                        MessageBox.Show("地址匹配失败！");
                        return;
                    }
                   
                }
                MessageBox.Show("地址匹配结束！");

                Close();
                
            }
        }
    }
}
