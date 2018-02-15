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
    public partial class FrmExpAddress : IVM.FrmTemplate
    {
        public FrmExpAddress()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmExpAddressAdd frm = new FrmExpAddressAdd();
            frm.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmExpAddress_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FrmExpAddress_Load(sender, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            string custname = txbcustname.Text;
            string sqlcode = " and CustomerName like '%" + txbcustname.Text.Trim() + "%'";
            int ItemCount = 0;
            livcustaddress.Items.Clear();
            DataTable dt = App.GetCustAddress(sqlcode);
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["expaddressid"].ToString();
                li.SubItems.Add(row["customername"].ToString());
                li.SubItems.Add(row["customersend"].ToString());
                li.SubItems.Add(row["custaddress"].ToString());
                li.SubItems.Add(row["addressee"].ToString());
                li.SubItems.Add(row["custtel"].ToString());
                livcustaddress.Items.Add(li);
            }
        }
        private void UpdateInfo()
        {
            int custaddressid;
            if (livcustaddress.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选取一条地址信息！");
                return;
            }
            custaddressid =int.Parse (livcustaddress.SelectedItems[0].Text);
            FrmExpAddressUpdate fmo = new FrmExpAddressUpdate();
            fmo.custaddressid = custaddressid;
            fmo.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmCustAddInput frm = new FrmCustAddInput();
            frm.ShowDialog();
        }

        private void livcustaddress_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UpdateInfo();
        }

        
         
    }
}
