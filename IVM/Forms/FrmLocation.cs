using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommClass;
using System.Data.SqlClient;//temp

namespace IVM
{
    public partial class FrmLocation : IVM.FrmTemplate
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //张大维
            //提示用户此功能由系统管理员完成
            MessageBox.Show("此项功能暂未开放，具体事宜请联系管理员！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //张大维
            //提示用户此功能由系统管理员完成
            MessageBox.Show("此项功能暂未开放，具体事宜请联系管理员！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            int ItemCount = 0;
            livLocation.Items.Clear();
            DataTable dt = App.GetLocation();
            foreach (DataRowView row in dt.DefaultView)
            {
                ItemCount++;
                ListViewItem li = new ListViewItem();
                li.Text = row["LocationID"].ToString();
                li.SubItems.Add(row["CompanyName"].ToString());
                li.SubItems.Add(row["FileRoomName"].ToString());
                li.SubItems.Add(row["FileShelfName"].ToString());
                li.SubItems.Add(row["FileLayerName"].ToString());
                livLocation.Items.Add(li);
            }

            //张大维
            ////以下代码可以实现将t_Location表中数据显示于ListView控件
            ////创建数据库连接类的对象
            //SqlConnection con = new SqlConnection("server=192.168.109.133;database=AMS_DEV_TJ;user=sa;pwd=cms2013");
            //con.Open();
            ////执行con对象的函数，返回一个SqlCommand类型的对象
            //SqlCommand cmd = con.CreateCommand();
            ////把输入的数据拼接成sql语句，并交给cmd对象
            //cmd.CommandText = "SELECT * from t_Location";

            ////用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
            //SqlDataReader dr = cmd.ExecuteReader();
            ////用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr
            //while (dr.Read())
            //{
            //    //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
            //    ListViewItem lt = new ListViewItem();
            //    //将数据库数据转变成ListView类型的一行数据
            //    lt.Text = dr["LocationID"].ToString();
            //    lt.SubItems.Add(dr["CompanyID"].ToString());
            //    lt.SubItems.Add(dr["FileRoomName"].ToString());
            //    lt.SubItems.Add(dr["FileShelfName"].ToString());
            //    lt.SubItems.Add(dr["FileLayerNum"].ToString());
            //    //将lt数据添加到listView1控件中
            //    livLocation.Items.Add(lt);
            //}

            //con.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //张大维
            this.FrmLocation_Load(sender, e);
        }
    }
}
