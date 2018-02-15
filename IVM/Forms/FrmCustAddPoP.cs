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
    public partial class FrmCustAddPoP : IVM.FrmTemplate
    {
        public string custname;
        public FrmCustAddPoP()
        {
            InitializeComponent();
        }

        private void FrmCustAddPoP_Load(object sender, EventArgs e)
        {
            int ItemCount = 0;
            livcustaddress.Items.Clear();
            DataTable dt = App.GetAddressCustName(custname);
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

        private void livcustaddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
