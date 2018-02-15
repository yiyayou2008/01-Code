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
    public partial class FrmDepartmentUpdate : IVM.FrmTemplate
    {
        public string departmentid;
        public FrmDepartmentUpdate()
        {
            InitializeComponent();
        }

        private void FrmDepartmentUpdate_Load(object sender, EventArgs e)
        {
            DataTable dt = App.GetDepartmentByid(departmentid);
            DataRow dr = dt.Rows[0];
            txbdepartmentcode.Text = dr["departmentcode"].ToString();
            txbdepartmentname.Text = dr["departmentname"].ToString();
        }

       
        private void Save()
        {
            string departmentcode = txbdepartmentcode.Text.Trim();
            string departmentname = txbdepartmentname.Text.Trim();
            if (App.DepartmentUpdate(departmentid, departmentcode, departmentname))
            {
                MessageBox.Show("部门信息更新成功！");
                this.Close();

            }
            else
            {
                MessageBox.Show("部门信息更新失败！");
                return;
            }
        }

      
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
