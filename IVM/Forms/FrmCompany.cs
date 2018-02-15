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
    public partial class FrmCompany : IVM.FrmTemplate
    {
        public FrmCompany()
        {
            InitializeComponent();
        }

      
        private void FrmCompany_Load(object sender, EventArgs e)
        {
            int ItemCount = 0;
            livcompany.Items.Clear();
            DataTable dt = App.GetCompany();
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["companyid"].ToString();
                li.SubItems.Add(row["companycode"].ToString());
                li.SubItems.Add(row["companyname"].ToString());
                li.SubItems.Add(row["companyaddress"].ToString());
                livcompany.Items.Add(li);
            }
        }
    
              
             

        private void livcompany_DoubleClick(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Add()
        {
            FrmCompanyAdd frm = new FrmCompanyAdd();
            frm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.FrmCompany_Load(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            string companyid;
            if (livcompany.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选取一条公司信息！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            companyid = livcompany.SelectedItems[0].Text;
            FrmCompanyUpdate fmo = new FrmCompanyUpdate();
            fmo.companyid = companyid;
            fmo.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
