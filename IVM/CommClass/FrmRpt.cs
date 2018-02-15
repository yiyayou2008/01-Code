using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Collections;

namespace CommClass
{
    public partial class FrmRpt : Form
    {
        public DataView SourceData;
        public string ReportName;
        public Hashtable _Parameters;

        public FrmRpt()
        {
            InitializeComponent();
        }

        private void FrmRpt_Shown(object sender, EventArgs e)
        {
            reportViewer1.Reset();
            ReportDataSource rds = new ReportDataSource("DataSet1", SourceData);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportPath = ReportName;
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            if (_Parameters.Count > 0)
            {
                foreach (DictionaryEntry de in _Parameters)
                {
                    ReportParameter rptPara = new ReportParameter(de.Key.ToString(), de.Value.ToString());
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptPara });
                }
            }

            reportViewer1.RefreshReport();
            //this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            ////缩放模式为百分比,以100%方式显示
            //this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            //this.reportViewer1.ZoomPercent = 100;


        }

        private void FrmRpt_Load(object sender, EventArgs e)
        {

        }

    }
}
