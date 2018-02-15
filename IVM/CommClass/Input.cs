using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CommClass
{
    class Input
    {
        private string filename;
        public string Filename
        {
            get { return filename ; }
            set { filename = value; }
        }
        private string[] tablename;
        public string[] Tablename
        {
            get { return tablename; }
            set { tablename = value; }
        }
        DBConnection dc = new DBConnection();
        DBSource dsExcelFile;
        public void OpenTXTfile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
            dlg.Filter = "TXT文件|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename= dlg.FileName;
                dlg.Dispose();

            }
            
        }
        public void OpenEXCELfile()
        {
            OpenFileDialog dlg = new OpenFileDialog();

           
            dlg.Filter = "Excel文件|*.xls;*.xlsx|所有文件|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                dlg.Dispose();
                dc.DBName = filename;
                dsExcelFile = new ExcelDBSource(dc);
                tablename = dsExcelFile.GetTableNames();
                
            }

        }
    }
}
