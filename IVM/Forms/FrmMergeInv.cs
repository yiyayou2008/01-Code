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
    public partial class FrmMergeInv : IVM.FrmTemplate
    {
        Express exp = new Express();
        public FrmMergeInv()
        {
            InitializeComponent();
        }

        private void FrmMergeInv_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FoundOut();

        }
        private void FoundOut()
        {
            int companyid=App.AppUser.CompanyID ;
            
            string sqlcode = "";
            
            if (txbcustname .Text !="")
            {
                sqlcode = sqlcode + " and iv.custname like '%" + txbcustname.Text + "%'";
            }
            if(App.AppUser.UserLevel ==1)
            {
                sqlcode = sqlcode + " and iv.companyid=" + companyid;
            }
            
            int ItemCount = 0;
            livinvmeger.Items.Clear();
            DataTable dt = App.GetNoMegerInv(sqlcode );
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["invnumber"].ToString();
                li.SubItems.Add(row["custname"].ToString());
                li.SubItems.Add(row["custaddress"].ToString());
                livinvmeger.Items.Add(li);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string expaddress = "";
            string oldaddress;
            if (livinvmeger.CheckedItems.Count < 1)
            {
                MessageBox.Show("请至少选择一个发票号！");
                return;
            }
            foreach (ListViewItem item in livinvmeger.Items)
            {
                if (item.Checked)
                {
                    oldaddress = item.SubItems[2].Text;
                    if (expaddress == "")
                    {
                        expaddress = oldaddress;
                    }
                    if (expaddress != oldaddress)
                    {
                        MessageBox.Show("不同的邮寄地址不可以合并在一起，请重新选择！");
                        return;
                    }

                }

            }
            
            exp.MegerNumber = App.CreatMegerID();

            exp.UserId = App.AppUser.UserID;
            if (App.MegerExpAdd(exp))
            {
                foreach (ListViewItem item in livinvmeger.Items)
                {
                    if (item.Checked)
                    {
                        exp.InvNumber = item.SubItems[0].Text;
                        if (!App.MegerExpDescAdd(exp))
                        {
                            App.MegerExpDel(exp);
                            MessageBox.Show("发票邮寄合并失败！");
                            return;
                        }

                        App.UpdateMegerInv(exp);
                    }

                }
                MessageBox.Show("发票邮寄合并完成，合并号是：" + exp.MegerNumber + "！");
                FoundOut();
            }
            else
            {
                MessageBox.Show("发票邮寄合并失败！");
                return;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in livinvmeger.Items)
            {
                item.Checked = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in livinvmeger.Items)
            {
                if (item.Checked)
                {
                    item.Checked = !item.Checked;
                }

            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (livinvmeger.CheckedItems.Count < 1)
            {
                MessageBox.Show("请至少选择一个发票号！");
                return;
            }
            foreach (ListViewItem item in livinvmeger.Items)
            {
                if (item.Checked)
                {
                    exp.InvNumber = item.SubItems[0].Text;
                    if (!App.UpdateSelfInv (exp))
                    {
                        
                        MessageBox.Show("选中自提发票处理失败！");
                        return;
                    }
                    
                    
                }
             
            }
            MessageBox.Show("选中自提发票处理完成！");
            FoundOut();
        }

     

        
    }
}
