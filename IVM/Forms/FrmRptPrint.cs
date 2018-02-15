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
    public partial class FrmRptPrint : IVM.FrmTemplate
    {
        Report Rpt = new Report();
        public FrmRptPrint()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRptPrint_Load(object sender, EventArgs e)
        {
            DataTable dtc = App.GetExpCompany();
            DataRow drc = dtc.NewRow();
            drc["expcompanyid"] = "0";
            drc["expcompanyname"] = "请选择";
            dtc.Rows.InsertAt(drc, 0);
            cmbexpcompany.DataSource = dtc;
            cmbexpcompany.DisplayMember = "expcompanyname";
            cmbexpcompany.ValueMember = "expcompanyid";
            cmbexpcompany.SelectedIndex = 0;
            ReflashNew();
           


        }

        private void ReflashNew()
        {
            int ItemCount = 0;
            livprint.Items.Clear();
            string sqlcode = "";
            if (App.AppUser.UserLevel == 1)
            {
                sqlcode = " and ti.companyid=" + App.AppUser.CompanyID;
            }
            DataTable dt = App.GetUnprintMergeid(sqlcode);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["MegerNumber"].ToString();
                li.SubItems.Add(row["CustAddress"].ToString());
                li.SubItems.Add(row["Addressee"].ToString());
                li.SubItems.Add(row["CustTel"].ToString());
                li.SubItems.Add(row["UserName"].ToString());
                livprint.Items.Add(li);
            }
        }

       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in livprint.Items)
            {
                item.Checked = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in livprint.Items)
            {
                if (item.Checked)
                {
                    item.Checked = !item.Checked;
                }

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string printmodel;
            string mergenumber;
            int expcompanyid;
            if(int.Parse (cmbexpcompany.SelectedValue.ToString ()) < 1 )
            {
                MessageBox.Show("请选择快递公司");
                return;
            }
            if(livprint.CheckedItems .Count <1)
            {
                MessageBox.Show("请至少选择一条需要打印的信息");
                return;
            }
            expcompanyid = int.Parse(cmbexpcompany.SelectedValue.ToString());
            printmodel = App.GetPrintModel(expcompanyid);  //获取打印模板
            foreach (ListViewItem item in livprint.Items)
            {
                if (item.Checked)
                {
                     mergenumber = item.SubItems[0].Text;
                     DataTable dt = App.GetPrintInfo(mergenumber);
                     Rpt.SourceData = dt.DefaultView;
                     Rpt.ReportName = @"Report\" + printmodel;
                     Rpt.Parameters.Clear();
                     Rpt.Parameters.Add("senduser", App.AppUser.UserName);
                     Rpt.Parameters.Add("usertel", App.AppUser.UserTel);
                     App.UpdatePrint(mergenumber, expcompanyid);
                     Rpt.Print();
                     //Rpt.Preview();
                     ReflashNew();
                }

            }
            
            
        }

        private void cmbexpcompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
