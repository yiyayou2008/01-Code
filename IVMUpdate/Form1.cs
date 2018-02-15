using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IVMUpgrade;

namespace IvmUpdate
{
    public partial class FrmUpgrade : Form
    {
        public string UpdateFileName;
        public string CurrentExeFileName;

        SoftwareUpgrade IVMUpgrade;

        private void DownloadBeginHandler(object sender, IVMUpgrade.DownloadEventArgs e)
        {
            pgbCurrent.Maximum = (int)IVMUpgrade.UpgradeFileList[e.FileIndex].FileSize;
        }

        private void DownloadEndHandler(object sender, IVMUpgrade.DownloadEventArgs e)
        {
            pgbWhole.Value = e.FileIndex+1;
        }

        private void ProgressHandler(object sender, IVMUpgrade.DownloadingEventArgs e)
        {
            pgbCurrent.Value = (int)e.DownloadSize;
        }

        public FrmUpgrade()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            pgbWhole.Maximum = IVMUpgrade.UpgradeFileList.Count;
            btnUpgrade.Enabled = false;
            IVMUpgrade.Upgrade();
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(CurrentExeFileName);
            this.Close();
        }

        private void FrmUpgrade_Load(object sender, EventArgs e)
        {
        }

        private void FrmUpgrade_Shown(object sender, EventArgs e)
        {
            //CurrentExeFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\LMS.exe";
            //UpdateFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Upgrade\\Upgrade.XML";

            IVMUpgrade = new SoftwareUpgrade(CurrentExeFileName, UpdateFileName);
            IVMUpgrade.DownloadBeginEvent += new SoftwareUpgrade.DownloadBeginEventHandler(this.DownloadBeginHandler);
            IVMUpgrade.DownloadEndEvent += new SoftwareUpgrade.DownloadEndEventHandler(this.DownloadEndHandler);
            IVMUpgrade.ProgressEvent += new SoftwareUpgrade.ProgressEventHandler(this.ProgressHandler);

            if (IVMUpgrade.CurrentVersion == null)
            {
                lblUpgrade.Text = "找不到执行文件，无法升级！";
                btnUpgrade.Enabled = false;
                return;
            }
            if (IVMUpgrade.LastedVersion == null)
            {
                lblUpgrade.Text = "无法连接升级服务器，或服务器上没有升级文件！";
                btnUpgrade.Enabled = false;
                return;
            }
            if (IVMUpgrade.IsOldVersion())
            {
                lblUpgrade.Text = "检测到新版本，从旧版本(" + IVMUpgrade.CurrentVersion.ToString() + ")升级到新版本(" + IVMUpgrade.LastedVersion.ToString() + ")";
                //显示升级文件列表
                IVMUpgrade.FillFileSizeList();
                foreach (SoftwareUpgrade.SUFileInfo _fileInfo in IVMUpgrade.UpgradeFileList)
                {
                    lstUpgradeFileList.Items.Add(_fileInfo.FileName + "(" + Math.Round((float)(_fileInfo.FileSize / 1024)).ToString() + "KB)");
                }
                btnUpgrade.Enabled = true;
            }
            else
            {
                lblUpgrade.Text = "当前已经是最新版本，不需要升级！";
                btnUpgrade.Enabled = false;
            }

            //关闭原有应用程序的所有进程 
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("IVM");
            foreach (System.Diagnostics.Process pro in proc)
            {
                pro.Kill();
            }

            this.Activate();

        }
    }
}
