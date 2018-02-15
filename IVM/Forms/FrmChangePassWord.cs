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
    public partial class FrmChangePassWord : IVM.FrmTemplate
    {
        public string userCode;
        private User tmpUser = new User();
        
        public FrmChangePassWord()
        {
            InitializeComponent();
        }

        private void FrmChangePassWord_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userCode))
            {
                tmpUser = App.AppUser;
            }
            else
            {
                tmpUser = App.UserGetByCode(userCode);
            }
            txtUserCode.Text = tmpUser.UserCode;
            txtUserName.Text = tmpUser.UserName;
        }

       

        private void Save()
        {
            if (!App.UserCheck(txtUserCode.Text, txtOldPassword.Text))
            {
                MessageBox.Show("旧密码不正确，您不能修改密码！");
                txtOldPassword.SelectAll();
                txtOldPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("两次输入密码不一样，请重新输入！");
                txtPassword.SelectAll();
                txtPassword.Focus();
                return;
            }
            if (App.ChangePasswordByCode(txtUserCode.Text, txtPassword.Text))
            {
                MessageBox.Show("密码修改成功！");
                Close();
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
