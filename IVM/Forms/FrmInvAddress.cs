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
    public partial class FrmInvAddress : IVM.FrmTemplate
    {
        public FrmInvAddress()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmInvAddress_Load(object sender, EventArgs e)
        {
           
        }

        private void RefreshFrm()
        {
            string sqlcode = "";
            if(txbcustname .Text !="")
            {
                sqlcode = sqlcode + " and custname like '%" + txbcustname .Text.Trim ()+ "%'";
            }
            if(App.AppUser.UserLevel ==1)
            {
                sqlcode = sqlcode + " and companyid=" + App.AppUser.CompanyID;
            }
            int ItemCount = 0;
            livinvlist.Items.Clear();
            DataTable dt = App.GetInvoice(sqlcode);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["invnumber"].ToString();
                li.SubItems.Add(row["custname"].ToString());

                livinvlist.Items.Add(li);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = livinvlist.Items.Count;
            for(int i=0;i<livinvlist.Items.Count ;i++)
            {
                string custname = livinvlist.Items[i].SubItems[1].Text;
                if(App.CountAddress(custname)==1)
                {
                    string invnumber=livinvlist.Items[i].Text ;
                    int expaddressid=App.GetAddressId (custname);
                    App.UpdateInvAddressId(invnumber, expaddressid);
                }
                progressBar1.Value = i;
                
            }
            progressBar1.Visible = false;
            MessageBox.Show("地址匹配结束！");
            RefreshFrm();
        }

        //private void livinvlist_DoubleClick(object sender, EventArgs e)
        //{
        //    string custname = livinvlist.SelectedItems[0].SubItems[1].Text;
        //    string invnumber = livinvlist.SelectedItems[0].Text;
        //    FrmMulAddress fmo = new FrmMulAddress();
        //    fmo.custname = custname;
        //    fmo.invnumber = invnumber;
        //    fmo.ShowDialog();
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RefreshFrm();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(livinvlist.CheckedItems.Count <1)
            {
                MessageBox.Show("请至少选择一条数据，谢谢！");
                return;
            }
            string custname = livinvlist.CheckedItems[0].SubItems [1].Text;
            List <string> invnumber = new List<string>();
            for (int i = 0; i < livinvlist.CheckedItems.Count; i++)
            {
                if (livinvlist.CheckedItems[i].Checked)
                    invnumber.Add (livinvlist.CheckedItems[i].Text);
            }

            FrmMulAddress fmo = new FrmMulAddress();
            fmo.custname = custname;
            fmo.invnumber = invnumber;
            fmo.ShowDialog();
            RefreshFrm();
        }
    }
}
