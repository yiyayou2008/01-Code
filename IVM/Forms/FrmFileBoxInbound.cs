using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommClass;

namespace IVM
{
    public partial class FrmFileBoxInbound : IVM.FrmTemplate
    {
        public string FileBoxNumber;
        FileBox fb = new FileBox();
        public FrmFileBoxInbound()
        {
            InitializeComponent();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //关闭
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //检索
            FoundOut();
        }
        private void FoundOut()
        {
            int companyid = App.AppUser.CompanyID;
            int userid = App.AppUser.UserID;
            string sqlcode = "";
            
            //若用户级别为普通用户，根据用户所属公司显示档案盒内容
            if (App.AppUser.UserLevel == 1)
            {
                sqlcode = sqlcode + " and t_Company.companyid=" + companyid + " and t_User.userid= " + userid;
            }

            int ItemCount = 0;
            liFileBoxInbound.Items.Clear();
            DataTable dt = App.GetNoLocationFB(sqlcode);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["FileBoxNumber"].ToString();
                li.SubItems.Add(row["CompanyCode"].ToString());
                li.SubItems.Add(row["CompanyName"].ToString());
                li.SubItems.Add(row["VoucherNumber"].ToString());
                li.SubItems.Add(row["VoucherType"].ToString());
                li.SubItems.Add(((DateTime)row["BeginDate"]).ToString("yyyy-MM-dd"));
                li.SubItems.Add(((DateTime)row["EndDate"]).ToString("yyyy-MM-dd"));
                li.SubItems.Add(row["UserName"].ToString());
                liFileBoxInbound.Items.Add(li);
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //判断是否选中了一条数据
            if (liFileBoxInbound.SelectedItems.Count < 1)
            {
                MessageBox.Show("入库失败，请至少选择一条凭证信息！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断库位是否为空
            if (txtLocationID.Text == "")
            {
                MessageBox.Show("入库失败，请输入库位信息！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //更新库位信息
            App.UpdateInbound(FileBoxNumber, int.Parse(txtLocationID.Text));
            MessageBox.Show("恭喜，入库成功！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLocationID.Text = "";           
            FoundOut();
        }

        private void liFileBoxInbound_SelectedIndexChanged(object sender, EventArgs e)
        {
            //取得用户选中行的FileBoxNumber
            if (liFileBoxInbound.SelectedIndices != null && liFileBoxInbound.SelectedIndices.Count > 0)
            {
                FileBoxNumber = liFileBoxInbound.SelectedItems[0].Text;                
            }
        }
    }
}
