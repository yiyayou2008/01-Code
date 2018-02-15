namespace IVM
{
    partial class FrmExpAddressUpdate
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
            this.txbaddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbtel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbsee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbcustsend = new System.Windows.Forms.TextBox();
            this.txbcustomername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbaddress
            // 
            this.txbaddress.Location = new System.Drawing.Point(96, 142);
            this.txbaddress.Name = "txbaddress";
            this.txbaddress.Size = new System.Drawing.Size(203, 22);
            this.txbaddress.TabIndex = 116;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 115;
            this.label5.Text = "邮寄地址：";
            // 
            // txbtel
            // 
            this.txbtel.Location = new System.Drawing.Point(96, 219);
            this.txbtel.Name = "txbtel";
            this.txbtel.Size = new System.Drawing.Size(203, 22);
            this.txbtel.TabIndex = 114;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 113;
            this.label4.Text = "收件人：";
            // 
            // txbsee
            // 
            this.txbsee.Location = new System.Drawing.Point(96, 181);
            this.txbsee.Name = "txbsee";
            this.txbsee.Size = new System.Drawing.Size(203, 22);
            this.txbsee.TabIndex = 112;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 111;
            this.label3.Text = "联系电话：";
            // 
            // txbcustsend
            // 
            this.txbcustsend.Location = new System.Drawing.Point(96, 104);
            this.txbcustsend.Name = "txbcustsend";
            this.txbcustsend.Size = new System.Drawing.Size(203, 22);
            this.txbcustsend.TabIndex = 110;
            // 
            // txbcustomername
            // 
            this.txbcustomername.Location = new System.Drawing.Point(96, 69);
            this.txbcustomername.Name = "txbcustomername";
            this.txbcustomername.Size = new System.Drawing.Size(203, 22);
            this.txbcustomername.TabIndex = 109;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 108;
            this.label2.Text = "邮寄名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 107;
            this.label1.Text = "客户名称：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(336, 56);
            this.toolStrip1.TabIndex = 106;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::IVM.Properties.Resources.disk;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 53);
            this.toolStripButton1.Text = "保存";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::IVM.Properties.Resources.remove;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(36, 53);
            this.toolStripButton5.Text = "退出";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // FrmExpAddressUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(336, 283);
            this.Controls.Add(this.txbaddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbtel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbsee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbcustsend);
            this.Controls.Add(this.txbcustomername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmExpAddressUpdate";
            this.Text = "客户邮寄地址修改";
            this.Load += new System.EventHandler(this.FrmExpAddressUpdate_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbaddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbtel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbsee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbcustsend;
        private System.Windows.Forms.TextBox txbcustomername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}
