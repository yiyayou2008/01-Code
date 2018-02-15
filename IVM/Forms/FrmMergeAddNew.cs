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
    public partial class FrmMergeAddNew : IVM.FrmTemplate
    {
        public string mergenumber;
        Express exp = new Express();
        public FrmMergeAddNew()
        {
            InitializeComponent();
        }

        private void FrmMergeAddNew_Load(object sender, EventArgs e)
        {
            FoundOut();
        }
        private void FoundOut()
        {
            int companyid = App.AppUser.CompanyID;
            
            string sqlcode = "";
            if (App.AppUser.UserLevel == 1)
            {
                sqlcode = " and iv.companyid=" + companyid ;
            }
            int ItemCount = 0;
            livinvmeger.Items.Clear();
            DataTable dt = App.GetNoMegerInv(sqlcode);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["invnumber"].ToString();
                li.SubItems.Add(row["custname"].ToString());
                
                livinvmeger.Items.Add(li);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int expaddressid = 0;
            int oldaddressid;
            
            if (livinvmeger.CheckedItems.Count < 1)
            {
                MessageBox.Show("请至少选择一个发票号！");
                return;
            }
            oldaddressid = App.GetExpressIdByMer(mergenumber);
            foreach (ListViewItem item in livinvmeger.Items)
            {
                if (item.Checked)
                {
                    expaddressid = App.GetExpressIdByIvn(item.SubItems[0].Text);
                    if(expaddressid !=oldaddressid )
                    {
                        MessageBox.Show("与原合并的邮寄不一致，请重新选择！");
                        return;
                    }
                }

            }
            exp.MegerNumber = mergenumber;
            foreach (ListViewItem item in livinvmeger.Items)
            {
                if (item.Checked)
                {
                    exp.InvNumber = item.SubItems[0].Text;
                    if (!App.MegerExpDescAdd(exp))
                    {
                       
                        MessageBox.Show("发票邮寄合并失败！");
                        return;
                    }

                    App.UpdateMegerInv(exp);
                }

            }
            MessageBox.Show("发票增加完成！");
            Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
