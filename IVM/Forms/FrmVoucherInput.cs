using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommClass;

namespace IVM
{
    public partial class FrmVoucherInput : IVM.FrmTemplate
    {
        DBSource dsExcelFile;
        DBConnection dc = new DBConnection();
        
        Voucher vou = new Voucher();

        public FrmVoucherInput()
        {
            InitializeComponent();
        }
               
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //张大维
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        private void FileOpen()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Excel文件|*.xls;*.xlsx|所有文件|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.tbFileName.Text = dlg.FileName;
                dlg.Dispose();
                dc.DBName = tbFileName.Text;
                dsExcelFile = new ExcelDBSource(dc);
                cbbSheets.DataSource = dsExcelFile.GetTableNames();
                cbbSheets.SelectedIndex = 0;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //显示excel数据
            int count = 0;
            livVoucher.Items.Clear();

            //张大维
            //若用户没有选择Excel表，提示用户并退出当前代码块
            if (cbbSheets.DataSource == null)
            {
                MessageBox.Show("请正确选择需要导入的会计凭证！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //张大维
            //读取Excel表内容到内存中并形成DataTable
            DataTable dt = dsExcelFile.GetRecord("select * from [" + cbbSheets.Text + "] ").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {                    
                ListViewItem li = new ListViewItem();
                li.Text = dt.Rows[i][0].ToString();                
                li.SubItems.Add(((DateTime)dt.Rows[i][1]).ToString("yyyy-MM-dd"));                
                li.SubItems.Add(((DateTime)dt.Rows[i][2]).ToString("yyyy-MM-dd"));
                li.SubItems.Add(dt.Rows[i][3].ToString());
                livVoucher.Items.Add(li);
                count++;
             }
                label3.Text = "共：" + count.ToString();            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UpLoad();
        }

        private void UpLoad()
        {
            int importStatus = 0;
            for (int i = 0; i < livVoucher.Items.Count; i++)
            {
                vou.VoucherNumber = livVoucher.Items[i].SubItems[0].Text;
                vou.CompanyId = App.AppUser.CompanyID;
                vou.BeginDate = Convert.ToDateTime(livVoucher.Items[i].SubItems[1].Text);
                vou.EndDate = Convert.ToDateTime(livVoucher.Items[i].SubItems[2].Text);
                vou.VoucherType = livVoucher.Items[i].SubItems[3].Text;

                App.ImportVoucher(vou);
                importStatus = 1;
            }
            if (importStatus == 1)
            {
                MessageBox.Show("恭喜，凭证导入成功！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                livVoucher.Items.Clear();
                label3.Text = "共：";
            }
            else
            {
                MessageBox.Show("请正确选择需要导入的会计凭证！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
