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
    public partial class FrmUserUpdate : IVM.FrmTemplate
    {
        public string usercode;
        User userlist = new User();
        public FrmUserUpdate()
        {
            InitializeComponent();
        }

        private void FrmUserUpdate_Load(object sender, EventArgs e)
        {
            userlist = App.UserInfoGetByCode(usercode);
            txbusercode.Text  = usercode;
            txbusername.Text = userlist.UserName;
            txbuserdesc.Text = userlist.UserDescription;
            txbtel.Text = userlist.UserTel;
            if (userlist.UserLevel == 2)
                checkBox2.Checked = true;
            else
                checkBox2.Checked = false;
            if (userlist.IsDisable)
                checkBox1.Checked = true;
            else
                checkBox1.Checked=false;
            //公司
            DataTable dtc = App.GetCompany();
            DataRow drc = dtc.NewRow();
            drc["companyid"] = userlist.CompanyID.ToString();
            drc["companyname"] = userlist.Companyname.ToString();
            dtc.Rows.InsertAt(drc, 0);
            cmbcompanyid.DataSource = dtc;
            cmbcompanyid.DisplayMember = "companyname";
            cmbcompanyid.ValueMember = "companyid";
            cmbcompanyid.SelectedIndex = 0;
            //部门
            DataTable dtd = App.GetDepartment();
            DataRow drd = dtd.NewRow();
            drd["departmentid"] = userlist.DepartmentID.ToString();
            drd["departmentname"] = userlist.Departmentname.ToString();
            dtd.Rows.InsertAt(drd, 0);
            cmbdepartmentid.DataSource = dtd;
            cmbdepartmentid.DisplayMember = "departmentname";
            cmbdepartmentid.ValueMember = "departmentid";
            cmbdepartmentid.SelectedIndex = 0;
        }

        private void Save()
        {
            userlist.UserCode = usercode;
            userlist.UserName = txbusername.Text;
            userlist.CompanyID = int.Parse(cmbcompanyid.SelectedValue.ToString());
            userlist.DepartmentID = int.Parse(cmbdepartmentid.SelectedValue.ToString());
            userlist.UserDescription = txbuserdesc.Text;
            userlist.UserTel = txbtel.Text;
            if (checkBox1.Checked)
                userlist.IsDisable = true;
            else
                userlist.IsDisable = false;
            if (checkBox2.Checked)
                userlist.UserLevel = 2;
            else
                userlist.UserLevel = 1; 
            if(App.UserUpdateByCode (userlist ))
            {
                MessageBox.Show("用户信息更新成功！", "财务凭证管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("用户信息更新失败！");
                return ;
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
