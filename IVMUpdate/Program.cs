using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IVMUpdate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String[] arguments = Environment.GetCommandLineArgs();
            FrmUpgrade frm = new FrmUpgrade();

            if (arguments.Length == 3)
            {
                frm.UpdateFileName = arguments[1];
                frm.CurrentExeFileName = arguments[2];
                Application.Run(frm);
            }
            else
            {
                MessageBox.Show("缺少文件！");
            }
        }
    }
}
