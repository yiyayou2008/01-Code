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
    public partial class FrmDepartment : IVM.FrmTemplate
    {
        public FrmDepartment()
        {
            InitializeComponent();
        }

       
        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            int ItemCount = 0;
            livdepartment.Items.Clear();
            DataTable dt = App.GetDepartment();
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["departmentid"].ToString();
                li.SubItems.Add(row["departmentcode"].ToString());
                li.SubItems.Add(row["departmentname"].ToString());
                livdepartment.Items.Add(li);
            }
        }

       

       

        private void Add()
        {
            FrmDepartmentAdd frm = new FrmDepartmentAdd();
            frm.ShowDialog();
        }

     
      

        private void UpdateInfo()
        {
            string departmentid;
            if (livdepartment.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选取一条部门信息！");
                return;
            }
            departmentid = livdepartment.SelectedItems[0].Text;
            FrmDepartmentUpdate fmo = new FrmDepartmentUpdate();
            fmo.departmentid = departmentid;
            fmo.ShowDialog();
        }

       
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.FrmDepartment_Load(sender, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
