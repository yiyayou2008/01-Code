using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using CommClass;
using System.Collections;

namespace IVM
{
    public partial class FrmInvoiceInput : IVM.FrmTemplate
    {
        Input inp = new Input();
        public FrmInvoiceInput()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

       
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inp.OpenTXTfile();
            this.tbFileName.Text = inp.Filename;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(tbFileName .Text =="")
            {
                MessageBox.Show("请选择要导入的文件！");
                return;

            }
            ReadTxtFile(this.tbFileName.Text);
        }

        public void ReadTxtFile(string filename)
        {

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            //仅 对文本 进行 读写操作  
            StreamReader sr = new StreamReader(fs, Encoding.Default );
            //定位操作点,begin 是一个参考点  
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str;
            string symbol;
            int cancelCount = 0;
            int count = 0;
            string invNumber;
            string custName;
            string companyname;
            double amountNoTax;
            double tax;

            while ((str = sr.ReadLine()) != null)
            {

                //去掉首尾空格
                str = str.Trim();
                //取最前面2个字符
                symbol = str.Substring(0, 2);
                //判断是否类似于注释"//发票1"
                if (symbol.Equals("//"))
                {
                    //如是，则取下一行			
                    str = sr.ReadLine();
                    //如下一行已到文件尾则退出，否则处理
                    if (str == null)
                    {
                        break;
                    }
                    else
                    {
                        symbol = str.Substring(0, 1);
                        //判断是否为作废发票
                        if (symbol.Equals("1"))
                        {
                            cancelCount++;
                            continue;
                        }
                        //将字符串根据分隔符~~拆分成数组
                        string[] inv = Regex.Split(str, "~~", RegexOptions.IgnoreCase);
                        invNumber = inv[4];
                        amountNoTax = Double.Parse(inv[9]);
                        tax = Double.Parse(inv[11]);
                        custName = inv[12];
                        companyname = inv[16];


                        ListViewItem li = new ListViewItem();
                        li.Text = invNumber;
                        li.SubItems.Add(custName);
                        li.SubItems.Add(amountNoTax.ToString());
                        li.SubItems.Add(tax.ToString());
                        li.SubItems.Add(companyname);
                        livinvoice.Items.Add(li);
                        count++;
                    }

                }
            }

            label3.Text = count.ToString();
           
            //C#读取TXT文件之关闭文件，注意顺序，先对文件内部进行关闭，然后才是文件~  
            sr.Close();
            fs.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            listBox1.Items.Add("开始导入数据...");
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = livinvoice.Items.Count;
            Invoice inv = new Invoice();
            for(int i=0;i<livinvoice.Items.Count ;i++)
            {
                inv.InvNumber = livinvoice.Items[i].SubItems[0].Text;
                inv.Custname = livinvoice.Items[i].SubItems[1].Text;
                inv.AmountNoTax = Decimal .Parse(livinvoice.Items[i].SubItems[2].Text);
                inv.Tax = Decimal.Parse(livinvoice.Items[i].SubItems[3].Text);
                inv.CompanyId = App.GetCompanyid(livinvoice.Items[i].SubItems[4].Text);
                inv.Inputdate =DateTime .Parse (DateTime.Now.ToString("yyyy-MM-dd"));
                if (App.InvoiceIsExsit(inv.InvNumber)<1)
                {
                    
                   if(!App.InvoiceAdd(inv))
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
    }
}
           

        
    


