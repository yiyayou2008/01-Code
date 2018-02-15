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
    public partial class FrmUser : IVM.FrmTemplate
    {
        public string userCode;
        public User _User = new User();
        

        private AppMenuLogic LMenu = new AppMenuLogic(App.Ds);

        public FrmUser()
        {
            InitializeComponent();
            RefreshUserList();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {

        }
        private void RefreshUserList()
        {
            lvUserList.Items.Clear();
            List<User> UserList = new List<User>();
            UserList = App.UserGetList();

            foreach (User tmpUser in UserList)
            {
                ListViewItem LI = new ListViewItem();
                LI.Text = tmpUser.UserCode;
                LI.SubItems.Add(tmpUser.UserName);
                LI.SubItems.Add(tmpUser.Companyname);
                LI.SubItems.Add(tmpUser.Departmentname);
                LI.SubItems.Add(tmpUser.UserDescription);
                if (tmpUser.IsDisable)
                {
                    LI.StateImageIndex = 1;
                    LI.ForeColor = System.Drawing.Color.Gray;
                }
                else
                    LI.StateImageIndex = 0;
                lvUserList.Items.Add(LI);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new FrmAddUser();
            form.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshUserList();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 递归算法显示子树
        /// </summary>
        /// <param name="dvMenu">数据表视图</param>
        /// <param name="ParentID">要显示树的父节点ID</param>
        /// <param name="pNode">在要哪个节点上显示树，根节点为Null</param>
        private void DisplayTree(DataView dvMenu, string ParentID, TreeNode pNode)
        {
            dvMenu.RowFilter = "ParentID=" + ParentID;
            foreach (DataRowView Row in dvMenu)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    Node.Text = Row["Title"].ToString();
                    Node.Tag = Row["MenuID"].ToString();
                    tvItem.Nodes.Add(Node);
                    DisplayTree(dvMenu, Row["MenuID"].ToString(), Node);
                }
                else
                {
                    Node.Text = Row["Title"].ToString();
                    Node.Tag = Row["MenuID"].ToString();
                    pNode.Nodes.Add(Node);
                    DisplayTree(dvMenu, Row["MenuID"].ToString(), Node);
                }
            }
        }

        private void tvItem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.lvItem.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.lvItem_ItemChecked);
            lvItem.Items.Clear();
            DataView dvLeaf = new DataView();
            dvLeaf = LMenu.GetUserMenu(tvItem.SelectedNode.Tag.ToString(), App.AppUser.UserCode);
            for (int i = 0; i <= dvLeaf.Count - 1; i++)
            {
                ListViewItem lviLeaf = new ListViewItem();
                lviLeaf.Text = dvLeaf[i]["Title"].ToString();
                lviLeaf.Tag = dvLeaf[i]["MenuID"].ToString();
                lviLeaf.Checked = _User.HasRight(lviLeaf.Tag.ToString());
                lvItem.Items.Add(lviLeaf);
            }
            this.lvItem.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvItem_ItemChecked);
        }

        private void lvItem_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //            MessageBox.Show(e.Item.Tag.ToString());
            if (e.Item.Checked)
                _User.AddRight(e.Item.Tag.ToString());
            else
                _User.RemoveRight(e.Item.Tag.ToString());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            App.SetUserRight(_User);
            MessageBox.Show("权限设置成功！");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (!App.AppUser.IsAdmin)
            {
                MessageBox.Show("您没有权限设置用户权限！");
                return;
            }
            if (lvUserList.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改权限的用户！");
                return;
            }
            userCode= lvUserList.SelectedItems[0].Text;
            //加载用户权限
            _User.UserCode = userCode;
            App.GetUserRight(_User);

            lblUserID.Text = userCode;
            TreeNode RootNode = new TreeNode();
            RootNode.Text = "菜单";
            RootNode.Tag = "0";
            tvItem.Nodes.Add(RootNode);

            DataView dv = new DataView();
            dv = LMenu.GetMenuList("0");
            DisplayTree(dv, "0", RootNode);

            tvItem.ExpandAll();
            tvItem.SelectedNode = RootNode;
            tvItem.Focus();
        }

        private void lvUserList_DoubleClick(object sender, EventArgs e)
        {
            string usercode;
            usercode = lvUserList.SelectedItems[0].Text;
            FrmUserUpdate frm = new FrmUserUpdate();
            frm.usercode = usercode;
            frm.ShowDialog();
        }

       
    }
}
