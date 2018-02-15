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
    public partial class FrmAddUser : IVM.FrmTemplate
    {
       
        public FrmAddUser()
        {
            InitializeComponent();
        }

        private void FrmAddUser_Load(object sender, EventArgs e)
        {

            DataTable dtc = App.GetCompany();
            DataRow drc = dtc.NewRow();
            drc["companyid"] = "0";
            drc["companyname"] = "请选择";
            dtc.Rows.InsertAt(drc, 0);
            cmbcompanyid.DataSource = dtc;
            cmbcompanyid.DisplayMember = "companyname";
            cmbcompanyid.ValueMember = "companyid";
            cmbcompanyid.SelectedIndex = 0;

            DataTable dtd = App.GetDepartment();
            DataRow drd = dtd.NewRow();
            drd["departmentid"] = "0";
            drd["departmentname"] = "请选择";
            dtd.Rows.InsertAt(drd, 0);
            cmbdepartmentid.DataSource = dtd;
            cmbdepartmentid.DisplayMember = "departmentname";
            cmbdepartmentid.ValueMember = "departmentid";
            cmbdepartmentid.SelectedIndex = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Save()
        {
            string ErrorMsg;
            if (txbusercode.Text.Trim() == "")
            {
                ErrorMsg = "用户代码不能为空，请输入用户名！";
                MessageBox.Show(ErrorMsg);
                txbusercode.Focus();
                return;
            }

            if (App.UserIsExist(txbusercode.Text))
            {
                ErrorMsg = "用户代码<" + txbusercode.Text + ">已存在！请重新输入用户名。";
                MessageBox.Show(ErrorMsg);
                txbusercode.Focus();
                return;
            }

            if (txbusername.Text.Trim() == "")
            {
                ErrorMsg = "用户名称不能为空，请输入用户名！";
                MessageBox.Show(ErrorMsg);
                txbusername.Focus();
                return;
            }

            if (txbpassword .Text.Trim() !=txbrepassword .Text.Trim())
            {
                ErrorMsg = "两次输入的密码不一样，请重新输入密码！";
                MessageBox.Show(ErrorMsg);
                txbpassword.Focus();
                return;
            }
            //user赋值
            User user = new User();
            user.UserCode =txbusercode.Text;
            user.UserName = txbusername.Text;
            if (checkBox1.Checked)
                user.UserLevel = 2;
            else
                user.UserLevel = 1; 
            
            user.UserPassword = txbpassword.Text;
            user.UserDescription = txbuserdesc.Text;
            user.UserTel = txbtel.Text;
            user.CompanyID =Int32.Parse( cmbcompanyid.SelectedValue.ToString ());
            user.DepartmentID = Int32.Parse(cmbdepartmentid.SelectedValue.ToString());

            //提交数据库
            if (App.UserAdd(user))
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("保存失败");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
