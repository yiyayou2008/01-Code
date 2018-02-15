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
    public partial class FrmVoucherInBox : IVM.FrmTemplate
    {
        FileBox fb = new FileBox();        
        public FrmVoucherInBox()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FoundOut();
        }

        private void FoundOut()
        {
            int companyid = App.AppUser.CompanyID;
            string sqlcode = "";

            //若凭证类型不为空，则按指定条件查询
            if (txbVoucherType.Text != "")
            {
                sqlcode = sqlcode + " and vc.VoucherType like '%" + txbVoucherType.Text + "%'";
            }
            //若用户级别为普通用户，根据用户所属公司显示凭证
            if (App.AppUser.UserLevel == 1)
            {
                sqlcode = sqlcode + " and vc.companyid=" + companyid;
            }

            int ItemCount = 0;
            livinvmeger.Items.Clear();
            DataTable dt = App.GetNoInBoxVoucher(sqlcode);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["CompanyCode"].ToString();
                li.SubItems.Add(row["CompanyName"].ToString());
                li.SubItems.Add(row["VoucherNumber"].ToString());
                li.SubItems.Add(row["VoucherType"].ToString());
                li.SubItems.Add(((DateTime)row["BeginDate"]).ToString("yyyy-MM-dd"));
                li.SubItems.Add(((DateTime)row["EndDate"]).ToString("yyyy-MM-dd"));
                livinvmeger.Items.Add(li);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //全选
            foreach (ListViewItem item in livinvmeger.Items)
            {
                item.Checked = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //反选
            foreach (ListViewItem item in livinvmeger.Items)
            {
                if (item.Checked)
                {
                    item.Checked = !item.Checked;
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string vc_tb_type = "";
            string vc_list_type;
            if (livinvmeger.CheckedItems.Count < 1)
            {
                MessageBox.Show("请至少选择一个凭证号！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断已选择的凭证类型是否一致，若不一致给出提示
            foreach (ListViewItem item in livinvmeger.Items)
            {
                vc_list_type = item.SubItems[3].Text;
                if (item.Checked)
                {
                    vc_list_type = item.SubItems[3].Text;
                    if (vc_tb_type == "")
                    {
                        vc_tb_type = vc_list_type;
                    }
                    if (vc_tb_type != vc_list_type)
                    {
                        MessageBox.Show("入册失败，凭证类型必须一致！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            //生成FileBoxID
            fb.FileBoxNumber = App.CreateFileBoxID();
            //取得UserID
            fb.UserID = App.AppUser.UserID;
            //取得用户所属公司ID
            fb.CompanyID = App.AppUser.CompanyID;

            if (App.FileBoxAdd(fb))
            {
                foreach (ListViewItem item in livinvmeger.Items)
                {
                    if (item.Checked)
                    {
                        fb.VoucherNumber = item.SubItems[2].Text;
                        if (!App.FileBoxDescAdd(fb))
                        {
                            //App.MegerExpDel(exp);
                            MessageBox.Show("凭证入盒操作失败！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        App.UpdateVoucher(fb);
                    }

                }
                MessageBox.Show("恭喜，完成凭证入盒！虚拟档案盒编号：" + fb.FileBoxNumber + "！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                FoundOut();
            }
            else
            {
                MessageBox.Show("凭证入盒失败！");
                return;
            }
        }
    }
}