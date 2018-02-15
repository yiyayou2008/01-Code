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
    public partial class FrmExpCompany : IVM.FrmTemplate
    {
        public FrmExpCompany()
        {
            InitializeComponent();
        }

        private void FrmExpCompany_Load(object sender, EventArgs e)
        {
            int ItemCount = 0;
            livexpcompany.Items.Clear();
            DataTable dt = App.GetExpCompany();
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["expcompanyid"].ToString();
                li.SubItems.Add(row["expcompanyname"].ToString());
                li.SubItems.Add(row["exptel"].ToString());
                livexpcompany.Items.Add(li);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void Add()
        {
            FrmExpCompanyAdd frm = new FrmExpCompanyAdd();
            frm.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.FrmExpCompany_Load(sender, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }
        private void UpdateInfo()
        {
            string expcompanyid;
            if (livexpcompany.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选取一条快递公司信息！");
                return;
            }
            expcompanyid = livexpcompany.SelectedItems[0].Text;
            FrmExpCompanyUpdate fmo = new FrmExpCompanyUpdate();
            fmo.expcompanyid = expcompanyid;
            fmo.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
