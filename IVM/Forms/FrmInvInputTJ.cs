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
    public partial class FrmInvInputTJ : IVM.FrmTemplate
    {
        DBSource dsExcelFile;
        DBConnection dc = new DBConnection();
        Invoice inv = new Invoice();
        public FrmInvInputTJ()
        {
            InitializeComponent();
        }
        private bool IsNumberic(string oText)
        {
            try
            {
                int var1 = Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //显示excel数据
            int count=0;            
            livinvoice.Items.Clear();
            DataTable dt = dsExcelFile.GetRecord("select * from [" + cbbSheets.Text + "] ").Tables[0];
            for ( int i = 5; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString().Trim () != "" && IsNumberic(dt.Rows[i][1].ToString()))
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = dt.Rows[i][1].ToString();
                    li.SubItems.Add(dt.Rows[i][2].ToString());
                    li.SubItems.Add(dt.Rows[i][14].ToString());
                    li.SubItems.Add(dt.Rows[i][16].ToString());
                    livinvoice.Items.Add(li);
                    count++;
                }
            }
            label3.Text = count.ToString();      
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            UpLoad();

        }
        private void UpLoad()
        {
            tabControl1.SelectedIndex = 1;
            listBox1.Items.Add("开始导入数据...");
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = livinvoice.Items.Count;

            for (int i = 0; i < livinvoice.Items.Count; i++)
            {
                inv.InvNumber = livinvoice.Items[i].SubItems[0].Text;
                inv.Custname = livinvoice.Items[i].SubItems[1].Text;
                inv.AmountNoTax = Decimal.Parse(livinvoice.Items[i].SubItems[2].Text);
                inv.Tax = Decimal.Parse(livinvoice.Items[i].SubItems[3].Text);
                inv.CompanyId = App.AppUser.CompanyID;
                if (App.InvoiceIsExsit(inv.InvNumber) < 1)
                {

                    if (!App.InvoiceAdd(inv))
                    {
                        listBox1.Items.Add("发票号：" + inv.InvNumber + "导入失败！");
                    }
                }
                else
                {
                    listBox1.Items.Add("发票号：" + inv.InvNumber + "重复，无法再次导入！");
                }
                progressBar1.Value = i;
            }
            progressBar1.Visible = false;
            listBox1.Items.Add("数据导入完成！");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
