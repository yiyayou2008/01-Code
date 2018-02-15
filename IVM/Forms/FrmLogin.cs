using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Threading;
using System.IO;
using CommClass;

namespace IVM
{
    public partial class FrmLogin : Form
    {
        public DBSource LoginDS;
        public User LoginUser;
        

        public string _userName;
        public string _password;

        private DBConnection AppDC = new DBConnection();

        private Encryption encrypt = new Encryption();
        private string iniFileName = "";
        private const int encryptKey = 1234;
        private IniSetting MySettings;
        Thread thrd;
        
        private delegate void ThreadEnd();

        public FrmLogin()
        {
            InitializeComponent();
            tbcLogin.TabPages.Remove(tbpConnection);
            this.Height -= 130;
            tbcLogin.Height -= 130;
            tbcLogin.ItemSize = new Size(0, 1);

            iniFileName = Application.StartupPath + "\\IVM.ini";
            MySettings = new IniSetting(iniFileName);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConnectDBServer()
        {
            //连接数据库
            lblStatus.Text = "正在连接数据库服务器...";
            AppDC.DBServer = txtServer.Text.Trim();
            AppDC.DBName = txtDB.Text.Trim();
            AppDC.UserName = txtUserName.Text.Trim();
            AppDC.Password = txtPassword.Text.Trim();
            LoginDS = new SqlsvrDBSource(AppDC);

            if (!LoginDS.Connect())
            {
                string errMsg = LoginDS.ErrorMessage;
                errMsg = "数据库服务器连接不正确，请重新设置！错误信息：" + errMsg;
                lblStatus.Text = errMsg;
                //MessageBox.Show(errMsg);
                return;
            }
            else
            {
                lblStatus.Text = "";
                
            }
                        
            if (!string.IsNullOrEmpty(_userName))
            {
                txtLoginUser.Text = _userName;
                txtLoginPassword.Text = _password;
                btnLogin_Click(this, null);
            }

            ThreadEnd te = new ThreadEnd(OnThreadEnd);
            this.BeginInvoke(te);      
        }

        private void OnThreadEnd()
        {
           
            btnLogin.Enabled = true;
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (thrd.IsAlive)
            {
                MessageBox.Show("正在数据库服务器连接，请稍候再试...");
                return;
            }
            
            App.Ds = LoginDS;

            if (!App.UserCheck(txtLoginUser.Text.Trim(), txtLoginPassword.Text.Trim()))
            {
                MessageBox.Show("用户名密码不正确！");
                txtUserName.Focus();
                return;
            }

            LoginUser = new User();
            LoginUser = App.UserGetByCode (txtLoginUser.Text.Trim());
           
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            if (tbcLogin.TabPages.Count == 1)
            {
                btnOption.Text = "选项(&O)<<";
                tbcLogin.TabPages.Add(tbpConnection);
                tbcLogin.SelectTab(1);
                this.Height += 130;
                tbcLogin.Height += 130;
                tbcLogin.ItemSize = new Size(96, 22);
            }
            else
            {
                btnOption.Text = "选项(&O)>>";
                tbcLogin.TabPages.Remove(tbpConnection);
                this.Height -= 130;
                tbcLogin.Height -= 130;
                tbcLogin.ItemSize = new Size(0, 1);
                txtServer.Focus();
            }
            tbpConnection.Focus();
        }

        private void btnConnectTest_Click(object sender, EventArgs e)
        {
            AppDC.DBServer = txtServer.Text.Trim();
            AppDC.DBName = txtDB.Text.Trim();
            AppDC.UserName = txtUserName.Text.Trim();
            AppDC.Password = txtPassword.Text.Trim();
            LoginDS = new SqlsvrDBSource(AppDC);

            if (LoginDS.Connect())
            {
                MessageBox.Show("连接成功！");
            }
            else
            {
                string errMsg = LoginDS.ErrorMessage;
                MessageBox.Show(errMsg);
                return;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            MySettings.SetValue("DBConnection", "DBServer", txtServer.Text.Trim());
            MySettings.SetValue("DBConnection", "DBName", txtDB.Text.Trim());
            MySettings.SetValue("DBConnection", "UserName", txtUserName.Text.Trim());
            MySettings.SetValue("DBConnection", "Password", encrypt.Encrypt(txtPassword.Text.Trim(), encryptKey));
            MessageBox.Show("保存成功！");
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = txtLoginUser;
            txtLoginUser.Focus();

            //致敬Banner
            this.lblSaluteBanner.Text = "衷心感谢给予帮助和支持的各位朋友！";

            //读取INI文件中数据库连接信息，在连接标签显示
            txtServer.Text = MySettings.GetValue("DBConnection", "DBServer");
            txtDB.Text = MySettings.GetValue("DBConnection", "DBName");
            txtUserName.Text = MySettings.GetValue("DBConnection", "UserName");
            txtPassword.Text = encrypt.Decrypt(MySettings.GetValue("DBConnection", "Password"), encryptKey);

            thrd = new Thread(new ThreadStart(ConnectDBServer));
            thrd.Start();
           
        }
        
    }
}
