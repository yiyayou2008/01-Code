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
    public partial class FrmInvInputQHD : IVM.FrmTemplate
    {
        DBSource dsExcelFile;
        DBConnection dc = new DBConnection();
        Invoice inv = new Invoice();
        public FrmInvInputQHD()
        {
            InitializeComponent();
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //显示excel数据
            
            livinvoice.Items.Clear();
            DataTable dta = dsExcelFile.GetRecord("select * from [" + cbbSheets.Text + "] ").Tables[0];
            dta.Columns[0].ColumnName = "invo";
            dta.Columns[16].ColumnName = "custname";
            dta.Columns[32].ColumnName = "count";
            dta.Columns[34].ColumnName = "tax";
            DataView dv = dta.DefaultView;
            DataTable dt = dv.ToTable(true, new string[] { "invo", "custname", "count","tax" });
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().Trim() != "")
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = dt.Rows[i][0].ToString();
                    li.SubItems.Add(dt.Rows[i][1].ToString());
                    li.SubItems.Add(dt.Rows[i][2].ToString());
                    li.SubItems.Add(dt.Rows[i][3].ToString());
                    livinvoice.Items.Add(li);
                    
                }
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            UpLoad();
        }
        private void UpLoad()
        {
            if (int.Parse(cmbcompanyid.SelectedValue.ToString()) < 1)
            {
                MessageBox.Show("请选择所属公司，谢谢！");
                return;
            }
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
                inv.CompanyId = int.Parse(cmbcompanyid.SelectedValue.ToString());
                inv.Inputdate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
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

        private void FrmInvInputQHD_Load(object sender, EventArgs e)
        {
            //公司
            DataTable dtc = App.GetCompany();
            DataRow drc = dtc.NewRow();
            drc["companyid"] = "0";
            drc["companyname"] = "请选择";
            dtc.Rows.InsertAt(drc, 0);
            cmbcompanyid.DataSource = dtc;
            cmbcompanyid.DisplayMember = "companyname";
            cmbcompanyid.ValueMember = "companyid";
            cmbcompanyid.SelectedIndex = 0;
        }
    }
}
