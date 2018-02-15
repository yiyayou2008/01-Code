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
    public partial class FrmDepartmentAdd : IVM.FrmTemplate
    {
        public FrmDepartmentAdd()
        {
            InitializeComponent();
        }

       
        private void Save()
        {
            string departmentcode = txbdepartmentcode.Text.Trim();
            string departmentname = txbdepartmentname.Text.Trim();
            if (departmentcode == "")
            {
                MessageBox.Show("请输入部门代码！");
                return;
            }
            if (departmentname == "")
            {
                MessageBox.Show("请输入部门名称！");
                return;
            }
            if (App.DepartmentAdd(departmentcode, departmentname))
            {
                MessageBox.Show("信息保存成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("信息保存失败！");
                return;
            }
        }

       
        private void FrmDepartmentAdd_Load(object sender, EventArgs e)
        {

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
