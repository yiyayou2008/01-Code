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
    public partial class FrmExpressSend : IVM.FrmTemplate
    {
        public string mergenumber;
        Express ep = new Express();
        Report Rpt = new Report();
        public FrmExpressSend()
        {
            InitializeComponent();
        }

        private void livprint_DoubleClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            if(livprint .SelectedItems .Count <1)
            {
                MessageBox.Show("请选择需要发件的合并单！");
                return;
            }
            if(txbexpressnumber .Text =="")
            {
                MessageBox.Show("请输入快递单号！");
                return;
            }
            ep.Expcompanyid = int.Parse(cmbexpcompany.SelectedValue.ToString());
            ep.ExpNumber = txbexpressnumber.Text;
            ep.Expdate = DateTime.Now;
            
            ep.MegerNumber = mergenumber;
            if(App.ExpressSend(ep))
            {
                MessageBox.Show("快递单发件成功！");
                labmergernumber.Text = "";
                txbexpressnumber.Text = "";
                ReflashNew();
            }
            else
            {
                MessageBox.Show("快递单发件失败！");
                return;
            }


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (livprint.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选择需要重新打印的合并单！");
                return;
            }
            int expcomid = int.Parse(cmbexpcompany.SelectedValue.ToString());
            string printmodel = App.GetPrintModel(expcomid);
            mergenumber = labmergernumber .Text ;
            DataTable dt = App.GetPrintInfo(mergenumber);
            Rpt.SourceData = dt.DefaultView;
            Rpt.ReportName = @"Report\" + printmodel;
            Rpt.Parameters.Clear();
            Rpt.Parameters.Add("senduser", App.AppUser.UserName);
            Rpt.Parameters.Add("usertel", App.AppUser.UserTel);
            App.UpdatePrint(mergenumber, expcomid);
            Rpt.Print();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmExpressSend_Load(object sender, EventArgs e)
        {
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
            DataTable dt = App.GetPrintMerge(sqlcode);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["MegerNumber"].ToString();
                li.SubItems.Add(row["CustomerSend"].ToString());
                li.SubItems.Add(row["CustAddress"].ToString());
                li.SubItems.Add(row["Addressee"].ToString());
                li.SubItems.Add(row["CustTel"].ToString());
                livprint.Items.Add(li);
            }
        }

        private void livprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (livprint.SelectedIndices != null && livprint.SelectedIndices.Count > 0)
            {
                mergenumber = livprint.SelectedItems[0].Text;
            }
            labmergernumber.Text = mergenumber;
            string expcompanyid = App.GetExpIdByMer(mergenumber).ToString();
            DataTable dt = App.GetExpCompanyByid(expcompanyid);
            DataRow dr = dt.Rows[0];
            DataTable dtc = App.GetExpCompany();
            DataRow drc = dtc.NewRow();
            drc["expcompanyid"] =dr[0].ToString () ;
            drc["expcompanyname"] = dr[1].ToString() ;
            dtc.Rows.InsertAt(drc, 0);
            cmbexpcompany.DataSource = dtc;
            cmbexpcompany.DisplayMember = "expcompanyname";
            cmbexpcompany.ValueMember = "expcompanyid";
            cmbexpcompany.SelectedIndex = 0;
        }

       
    }
}
