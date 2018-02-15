using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using CommClass;

namespace IVM
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

       



        private DataTable GenerateMenuTable(User MenuUser)
        {
            string strCmd;
            if (MenuUser.IsAdmin)
                strCmd = "select * from t_menu where typeID=0";
            else
                strCmd = "WITH pp (MenuID,Title,MenuName,MenuLevel,IsDetail,ParentID,FormName,TypeID,OrderNumber) as " +
                        "(SELECT m.MenuID,m.Title,m.MenuName,m.MenuLevel,m.IsDetail,m.ParentID,m.FormName,m.TypeID,m.OrderNumber " +
                           "FROM t_menu m,t_UserRight r,t_user u " +
                            "WHERE m.MenuID=r.MenuID " +
                            "AND r.UserID=u.UserID " +
                            "AND u.UserCode='" + MenuUser.UserCode + "'" +
                            " UNION ALL " +
                            "SELECT m.MenuID,m.Title,m.MenuName,m.MenuLevel,m.IsDetail,m.ParentID,m.FormName,m.TypeID,m.OrderNumber " +
                            "FROM t_menu m " +
                            "join PP " +
                            "on m.MenuID=pp.ParentID " +
                            ") " +
                            " select distinct * from pp where TypeID=0";
            DataSet ds = App.Ds.GetRecord(strCmd);
            return ds.Tables[0];
        }

        private void CreateMenu(DataTable dt)
        {
            MenuStrip mainMenu = new MenuStrip();
            mainMenu.Name = "APPMainMenu";

            DataView dv = dt.DefaultView;

            dv.RowFilter = "MenuLevel=0";
            dv.Sort = "OrderNumber asc";
            for (int i = 0; i < dv.Count; i++)
            {
                ToolStripMenuItem topMenu = new ToolStripMenuItem();
                topMenu.Text = dv[i]["Title"].ToString();
                topMenu.Name = dv[i]["MenuName"].ToString();
                if (Convert.ToInt16(dv[i]["IsDetail"]) == 0)
                {
                    CreateSubMenu(ref topMenu, Convert.ToInt32(dv[i]["MenuID"]), dt);
                }
                mainMenu.MdiWindowListItem = topMenu;
                mainMenu.Items.Add(topMenu);
            }

            //在文件菜单显示MDI子窗体
            mainMenu.MdiWindowListItem = (ToolStripMenuItem)mainMenu.Items[1];

            mainMenu.Dock = DockStyle.Top;
            mainMenu.AllowMerge = true;
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;
        }

        private void CreateSubMenu(ref ToolStripMenuItem topMenu, int ItemID, DataTable dt)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "ParentID=" + ItemID.ToString();
            dv.Sort = "OrderNumber asc";

            for (int i = 0; i < dv.Count; i++)
            {
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = dv[i]["Title"].ToString();
                subMenu.Name = dv[i]["MenuName"].ToString();
                if (Convert.ToInt16(dv[i]["IsDetail"]) == 0)
                {
                    CreateSubMenu(ref subMenu, Convert.ToInt32(dv[i]["MenuID"]), dt);
                }
                else
                {
                    subMenu.Tag = dv[i]["FormName"].ToString();
                    subMenu.Click += new System.EventHandler(this.menuItem_Click);
                }
                topMenu.DropDownItems.Add(subMenu);
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            string formName = ((ToolStripMenuItem)sender).Tag.ToString();
            switch (formName.Trim())
            {
                case "":
                    break;
                case "[EXIT]":
                    Close();
                    break;
                //case "FrmAbout":
                //    Form formAbout = new FrmAbout();
                //    formAbout.ShowDialog();
                //    break;
                default:
                    if (this.checkchildfrm(formName) == true)
                        return;
                    string strForm = "IVM." + formName;
                    // 获得Assembly
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    // 实例化窗体
                    Form form = assembly.CreateInstance(strForm) as Form;
                    if (form == null)
                    {
                        MessageBox.Show(strForm + "不存在！");
                    }
                    else
                    {
                        form.Name = formName;
                       
                        form.ShowDialog();
                    }
                    break;
            }
            return;
        }

        public bool checkchildfrm(string childfrmname)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.Name == childfrmname)
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)
                        childFrm.WindowState = FormWindowState.Normal;
                    childFrm.Activate();
                    return true;
                }
            }
            return false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //张大维
            //原代码：tslTitle.Text = App.AppUser.UserName;
            tslTitle.Text = "当前登录用户：" + App.AppUser.UserName;

            //此处为新增代码：
            tslUserName.Text = "技术支持：财务部IT组 联系电话：022-66271662";


            CreateMenu(GenerateMenuTable(App.AppUser));

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            
           
            
        }

        private void tslUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
