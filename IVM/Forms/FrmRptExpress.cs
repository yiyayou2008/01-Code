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
    public partial class FrmRptExpress : IVM.FrmTemplate
    {
        Report Rpt = new Report();
        public FrmRptExpress()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string sqlcase = "";
            string datefr = txbtimefr.Text;
            string dateto = txbtimet.Text;
            if (int.Parse(cmbcompanyid.SelectedValue.ToString()) > 0)
            {
                sqlcase = sqlcase + " and tp.companyid=" + int.Parse(cmbcompanyid.SelectedValue.ToString());
            }
            if(int.Parse(cmbexpcompany.SelectedValue.ToString())>0)
            {
                sqlcase = sqlcase + " and tec.ExpCompanyId=" + int.Parse(cmbexpcompany.SelectedValue.ToString());
            }
            if (datefr != "")
            {
                if (dateto != "")
                {
                    sqlcase = sqlcase + " and convert(varchar(10),te.ExpDate,120)>='" + datefr + "' and convert(varchar(10),te.ExpDate,120)<='" + dateto + "'";
                }
                else
                {
                    sqlcase = sqlcase + " and convert(varchar(10),te.ExpDate,120)='" + datefr + "'";
                }
            }
            DataTable dt = App.GetRptExpressInfo(sqlcase);
            Rpt.SourceData = dt.DefaultView;
            Rpt.ReportName = @"Report\RptExpress.rdlc";
            Rpt.Preview();
        }

        private void FrmRptExpress_Load(object sender, EventArgs e)
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

            DataTable dte = App.GetExpCompany();
            DataRow drp = dte.NewRow();
            drp["expcompanyid"] = "0";
            drp["expcompanyname"] = "请选择";
            dte.Rows.InsertAt(drp, 0);
            cmbexpcompany.DataSource = dte;
            cmbexpcompany.DisplayMember = "expcompanyname";
            cmbexpcompany.ValueMember = "expcompanyid";
            cmbexpcompany.SelectedIndex = 0;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txbtimefr.Text = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            txbtimet.Text = dateTimePicker3.Value.ToString("yyyy-MM-dd");
        }
    }
}
