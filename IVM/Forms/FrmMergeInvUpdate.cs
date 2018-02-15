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
    public partial class FrmMergeInvUpdate : IVM.FrmTemplate
    {
        public string mergenumber="";
        public FrmMergeInvUpdate()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int ItemCount = 0;
            livmergeid.Items.Clear();
            string sqlcode = "";
            if(App.AppUser .UserLevel ==1)
            {
                sqlcode = " and ti.companyid=" + App.AppUser.CompanyID;
            }
            DataTable dt = App.GetUnprintMergeid(sqlcode);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["megernumber"].ToString();
                livmergeid.Items.Add(li);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (livinvnumber.CheckedItems.Count < 1)
            {
                MessageBox.Show("请至少选择一个发票号！");
                return;
            }
            foreach (ListViewItem item in livinvnumber.Items)
            {
                if (item.Checked)
                {
                    string invnumber = item.SubItems[0].Text;
                    if(!App.CancleMegerInv (invnumber))
                    {
                        MessageBox.Show("发票号：" + invnumber + "移除失败！");
                    }
                }
            }
            ReNewlivnumber();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(mergenumber =="")
            {
                MessageBox.Show("请选择需要添加发票的合并号！");
                return;
            }
            FrmMergeAddNew frm = new FrmMergeAddNew();
            frm.mergenumber = mergenumber;
            frm.ShowDialog();
        }

        private void livmergeid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (livmergeid.SelectedIndices != null && livmergeid.SelectedIndices.Count > 0)
            {
                mergenumber = livmergeid.SelectedItems[0].Text;
                ReNewlivnumber();
                
            }
        }
        private void ReNewlivnumber()
        {
            int ItemCount = 0;
            livinvnumber.Items.Clear();
            DataTable dt = App.GetUnprintInv(mergenumber);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["invnumber"].ToString();
                livinvnumber.Items.Add(li);
            }
        }

        private void FrmMergeInvUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
