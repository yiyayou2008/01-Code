using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;

namespace CommClass
{
    class Report
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private Hashtable parameters = new Hashtable();
        public Hashtable Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        private string reportName;
        public string ReportName
        {
            get { return reportName; }
            set { reportName = value; }
        }

        private string printerName;
        public string PrinterName
        {
            get { return printerName; }
            set { printerName = value; }
        }

        private DataView sourceData;
        public DataView SourceData
        {
            get { return sourceData; }
            set { sourceData = value; }
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,
                                  string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        //private void Export(LocalReport report)
        //{
        //    double PageWidth, PageHeight;
        //    if (report.GetDefaultPageSettings().IsLandscape) //判断是否横向打印
        //    {
        //        PageWidth = report.GetDefaultPageSettings().PaperSize.Height / 100.0;
        //        PageHeight = report.GetDefaultPageSettings().PaperSize.Width / 100.0;
        //    }
        //    else
        //    {
        //        PageWidth = report.GetDefaultPageSettings().PaperSize.Width / 100.0;
        //        PageHeight = report.GetDefaultPageSettings().PaperSize.Height / 100.0;
        //    }
        //    string deviceInfo =
        //      "<DeviceInfo>" +
        //      "  <OutputFormat>EMF</OutputFormat>" +
        //      "  <PageWidth>8.27in</PageWidth>" +
        //      "  <PageHeight>5in</PageHeight>" +
        //        "  <MarginTop>0.1in</MarginTop>" +
        //        "  <MarginLeft>0.1in</MarginLeft>" +
        //        "  <MarginRight>0.1in</MarginRight>" +
        //        "  <MarginBottom>0.1in</MarginBottom>" +
        //      "</DeviceInfo>";
        //    Warning[] warnings;
        //    m_streams = new List<Stream>();
        //    report.Render("Image", deviceInfo, CreateStream, out warnings);

        //    foreach (Stream stream in m_streams)
        //        stream.Position = 0;
        //}

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            m_streams[m_currentPageIndex].Position = 0;

            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            //指定是否横向打印   
            ev.PageSettings.Landscape = false;

            //这里的Graphics对象实际指向了打印机  
            ev.Graphics.DrawImage(pageImage, 0, 0, pageImage.Width/3, pageImage.Height/3);
            //ev.Graphics.DrawImage(pageImage, 0, 0,850,300);
            m_streams[m_currentPageIndex].Close();
            m_currentPageIndex++;
            //设置是否需要继续打印  
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public void Print()
        {
            LocalReport report = new LocalReport();
            report.ReportPath = reportName;
            report.DataSources.Add(new ReportDataSource("DataSet1", sourceData));
            if (Parameters.Count > 0)
            {
                foreach (DictionaryEntry de in Parameters)
                {
                    ReportParameter rptPara = new ReportParameter(de.Key.ToString(), de.Value.ToString());
                    report.SetParameters(new ReportParameter[] { rptPara });
                }
            }
            report.Refresh();
            string deviceInfo =
             "<DeviceInfo>" +
             "  <OutputFormat>EMF</OutputFormat>" +
             //"  <PageWidth>8.27in</PageWidth>" +
             //"  <PageHeight>5in</PageHeight>" +
             //  "  <MarginTop>0.1in</MarginTop>" +
             //  "  <MarginLeft>0.1in</MarginLeft>" +
             //  "  <MarginRight>0.1in</MarginRight>" +
             //  "  <MarginBottom>0.1in</MarginBottom>" +
             "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            //Export(report);
            string printname = new PrintDocument().PrinterSettings.PrinterName;
            m_currentPageIndex = 0;
           

            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName =printerName ;
            if (!printDoc.PrinterSettings.IsValid)
            {
                MessageBox.Show("Can't find printer");
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            //指定是否横向打印
            printDoc.DefaultPageSettings.Landscape = false;
            //将RDLC报表上的参数传递过来
            //printDoc.DefaultPageSettings.Landscape = report.GetDefaultPageSettings().IsLandscape;
            printDoc.DefaultPageSettings.PaperSize = report.GetDefaultPageSettings().PaperSize;
            printDoc.DefaultPageSettings.Margins = report.GetDefaultPageSettings().Margins;

            printDoc.Print();
        }

        public void Preview()
        {
            FrmRpt Frm = new FrmRpt();
            Frm.SourceData = sourceData;
            Frm.ReportName = reportName;
            Frm._Parameters = parameters;
            Frm.ShowDialog();
        }
    }
}