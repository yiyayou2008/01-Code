namespace IVM
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbcLogin = new System.Windows.Forms.TabControl();
            this.tbpLogin = new System.Windows.Forms.TabPage();
            this.lblSaluteBanner = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtLoginUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpConnection = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.btnConnectTest = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOption = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbcLogin.SuspendLayout();
            this.tbpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tbpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 90);
            this.panel2.TabIndex = 14;
            // 
            // tbcLogin
            // 
            this.tbcLogin.Controls.Add(this.tbpLogin);
            this.tbcLogin.Controls.Add(this.tbpConnection);
            this.tbcLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbcLogin.ItemSize = new System.Drawing.Size(96, 22);
            this.tbcLogin.Location = new System.Drawing.Point(0, 90);
            this.tbcLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbcLogin.Multiline = true;
            this.tbcLogin.Name = "tbcLogin";
            this.tbcLogin.SelectedIndex = 0;
            this.tbcLogin.Size = new System.Drawing.Size(395, 277);
            this.tbcLogin.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcLogin.TabIndex = 0;
            // 
            // tbpLogin
            // 
            this.tbpLogin.BackColor = System.Drawing.SystemColors.Control;
            this.tbpLogin.Controls.Add(this.lblSaluteBanner);
            this.tbpLogin.Controls.Add(this.pictureBox2);
            this.tbpLogin.Controls.Add(this.txtLoginPassword);
            this.tbpLogin.Controls.Add(this.txtLoginUser);
            this.tbpLogin.Controls.Add(this.label2);
            this.tbpLogin.Controls.Add(this.label1);
            this.tbpLogin.Location = new System.Drawing.Point(4, 26);
            this.tbpLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpLogin.Name = "tbpLogin";
            this.tbpLogin.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpLogin.Size = new System.Drawing.Size(387, 247);
            this.tbpLogin.TabIndex = 0;
            this.tbpLogin.Text = "登录";
            // 
            // lblSaluteBanner
            // 
            this.lblSaluteBanner.AutoSize = true;
            this.lblSaluteBanner.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSaluteBanner.ForeColor = System.Drawing.Color.Blue;
            this.lblSaluteBanner.Location = new System.Drawing.Point(88, 106);
            this.lblSaluteBanner.Name = "lblSaluteBanner";
            this.lblSaluteBanner.Size = new System.Drawing.Size(98, 17);
            this.lblSaluteBanner.TabIndex = 0;
            this.lblSaluteBanner.Text = "lblSaluteBanner";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(33, 40);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(154, 67);
            this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(175, 23);
            this.txtLoginPassword.TabIndex = 3;
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.Location = new System.Drawing.Point(154, 30);
            this.txtLoginUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.Size = new System.Drawing.Size(175, 23);
            this.txtLoginUser.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // tbpConnection
            // 
            this.tbpConnection.BackColor = System.Drawing.SystemColors.Control;
            this.tbpConnection.Controls.Add(this.groupBox1);
            this.tbpConnection.Controls.Add(this.pictureBox3);
            this.tbpConnection.Controls.Add(this.label10);
            this.tbpConnection.Controls.Add(this.btnSaveSetting);
            this.tbpConnection.Controls.Add(this.btnConnectTest);
            this.tbpConnection.Controls.Add(this.txtPassword);
            this.tbpConnection.Controls.Add(this.label9);
            this.tbpConnection.Controls.Add(this.comboBox1);
            this.tbpConnection.Controls.Add(this.label8);
            this.tbpConnection.Controls.Add(this.txtUserName);
            this.tbpConnection.Controls.Add(this.label7);
            this.tbpConnection.Controls.Add(this.txtDB);
            this.tbpConnection.Controls.Add(this.label6);
            this.tbpConnection.Controls.Add(this.txtServer);
            this.tbpConnection.Controls.Add(this.label5);
            this.tbpConnection.Location = new System.Drawing.Point(4, 26);
            this.tbpConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpConnection.Name = "tbpConnection";
            this.tbpConnection.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpConnection.Size = new System.Drawing.Size(387, 247);
            this.tbpConnection.TabIndex = 1;
            this.tbpConnection.Text = "连接属性";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(155, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 11);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(25, 95);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "数据库服务器连接设置";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(284, 206);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(89, 28);
            this.btnSaveSetting.TabIndex = 13;
            this.btnSaveSetting.Text = "保存设置(&S)";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // btnConnectTest
            // 
            this.btnConnectTest.Location = new System.Drawing.Point(147, 206);
            this.btnConnectTest.Name = "btnConnectTest";
            this.btnConnectTest.Size = new System.Drawing.Size(89, 28);
            this.btnConnectTest.TabIndex = 8;
            this.btnConnectTest.Text = "连接测试(&C)";
            this.btnConnectTest.UseVisualStyleBackColor = true;
            this.btnConnectTest.Click += new System.EventHandler(this.btnConnectTest_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(172, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(191, 23);
            this.txtPassword.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "密码：";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "SQL Server"});
            this.comboBox1.Location = new System.Drawing.Point(109, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(248, 25);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "MS SQL Server";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "数据库类型：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(172, 134);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(191, 23);
            this.txtUserName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "用户名：";
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(172, 102);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(191, 23);
            this.txtDB.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "数据库名：";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(172, 71);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(191, 23);
            this.txtServer.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "服务器：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOption);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 367);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 58);
            this.panel1.TabIndex = 22;
            //this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnOption
            // 
            this.btnOption.Location = new System.Drawing.Point(264, 11);
            this.btnOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(87, 30);
            this.btnOption.TabIndex = 2;
            this.btnOption.Text = "选项(&O)>>";
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(141, 11);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 30);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(28, 11);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 30);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "登录(&L)";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(395, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            //this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(395, 447);
            this.Controls.Add(this.tbcLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "财务凭证管理系统";
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.tbcLogin.ResumeLayout(false);
            this.tbpLogin.ResumeLayout(false);
            this.tbpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tbpConnection.ResumeLayout(false);
            this.tbpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tbcLogin;
        private System.Windows.Forms.TabPage tbpLogin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.TextBox txtLoginUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbpConnection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Button btnConnectTest;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label lblSaluteBanner;
    }
}