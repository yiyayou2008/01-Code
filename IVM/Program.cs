using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommClass;

namespace IVM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            App.Ds = App.ConnectDB(App.GetDBConnection());
            //App.AppUser = App.UserGetByCode("admin");
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmLogin LoginForm = new FrmLogin();
            string[] Arguments = Environment.GetCommandLineArgs();
            if (Arguments.Length == 3)
            {
                LoginForm._userName = Arguments[1];
                LoginForm._password = Arguments[2];
            }
            DialogResult result = LoginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                App.Ds = LoginForm.LoginDS;
                App.AppUser = LoginForm.LoginUser;


                Application.Run(new FormMain());
            }
        }
    }
}
