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
    public partial class FrmCustAddInput : IVM.FrmTemplate
    {
        Input inp = new Input();
        DBSource dsExcelFile;
        DBConnection dc = new DBConnection();
        ExpAddress exd = new ExpAddress();
        public FrmCustAddInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileOpen();
            //inp.OpenEXCELfile();
            //this.tbFileName.Text = inp.Filename;
            //cbbSheets.DataSource = inp.Tablename;
            //cbbSheets.SelectedIndex = 0;
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //显示excel数据
            dvgstaff.DataSource = dsExcelFile.GetRecord("select * from [" + cbbSheets.Text + "] ").Tables[0];
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
            
            //获取excel数据
            DataTable dtt = (DataTable)dvgstaff.DataSource;
            progressBar1.Maximum = dtt.Rows.Count;
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                exd.CustomerName = dtt.Rows[i][0].ToString();
                exd.CustomerSend = dtt.Rows[i][1].ToString();
                exd.CustAddress = dtt.Rows[i][2].ToString();
                exd.Addressee = dtt.Rows[i][3].ToString();
                exd.CustTel = dtt.Rows[i][4].ToString();
                if (!App.CheckAddress (exd))
                {
                    if(!App.CustAddressAdd(exd))
                    {
                        listBox1.Items.Add("客户名称：" + dtt.Rows[i][0] + ",客户邮寄名称：" + dtt.Rows[i][1] + ",客户邮寄地址：" + dtt.Rows[i][2] + ",导入失败，请核实。");
                    }
                    
                }
                else
                {
                    listBox1.Items.Add("客户名称：" + dtt.Rows[i][0] + "，系统中已存在相关信息，请核实。");
                }
                progressBar1.Value = i;

            }
            progressBar1.Visible = false;
            listBox1.Items.Add("数据导入完成！");
        }
        
    }
}
