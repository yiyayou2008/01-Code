namespace IvmUpdate
{
    partial class FrmUpgrade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUpgrade = new System.Windows.Forms.Label();
            this.lstUpgradeFileList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pgbCurrent = new System.Windows.Forms.ProgressBar();
            this.pgbWhole = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Location = new System.Drawing.Point(228, 272);
            this.btnUpgrade.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(87, 28);
            this.btnUpgrade.TabIndex = 0;
            this.btnUpgrade.Text = "升级(&U)";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(358, 272);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUpgrade
            // 
            this.lblUpgrade.AutoSize = true;
            this.lblUpgrade.Location = new System.Drawing.Point(12, 9);
            this.lblUpgrade.Name = "lblUpgrade";
            this.lblUpgrade.Size = new System.Drawing.Size(211, 16);
            this.lblUpgrade.TabIndex = 2;
            this.lblUpgrade.Text = "检测到新版本，从旧版本()升级到新版本()";
            // 
            // lstUpgradeFileList
            // 
            this.lstUpgradeFileList.FormattingEnabled = true;
            this.lstUpgradeFileList.ItemHeight = 16;
            this.lstUpgradeFileList.Location = new System.Drawing.Point(15, 57);
            this.lstUpgradeFileList.Name = "lstUpgradeFileList";
            this.lstUpgradeFileList.Size = new System.Drawing.Size(433, 148);
            this.lstUpgradeFileList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "需要更新的文件：";
            // 
            // pgbCurrent
            // 
            this.pgbCurrent.Location = new System.Drawing.Point(80, 211);
            this.pgbCurrent.Name = "pgbCurrent";
            this.pgbCurrent.Size = new System.Drawing.Size(368, 23);
            this.pgbCurrent.TabIndex = 5;
            // 
            // pgbWhole
            // 
            this.pgbWhole.Location = new System.Drawing.Point(80, 240);
            this.pgbWhole.Name = "pgbWhole";
            this.pgbWhole.Size = new System.Drawing.Size(368, 23);
            this.pgbWhole.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "当前进度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "整体进度：";
            // 
            // FrmUpgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 313);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pgbWhole);
            this.Controls.Add(this.pgbCurrent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUpgradeFileList);
            this.Controls.Add(this.lblUpgrade);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpgrade);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmUpgrade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能升级";
            this.Load += new System.EventHandler(this.FrmUpgrade_Load);
            this.Shown += new System.EventHandler(this.FrmUpgrade_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUpgrade;
        private System.Windows.Forms.ListBox lstUpgradeFileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pgbCurrent;
        private System.Windows.Forms.ProgressBar pgbWhole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

