using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Report
{

    public partial class FReporte : Form
    {

        public string Path { get; set; }
        public IEnumerable <ReportDataSource> rds {get;set;}
        public IEnumerable <ReportParameter> prmts  {get;set;}

        public FReporte()
        {
            InitializeComponent();
        }

        private void FReporte_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.Visible = true;
            this.reportViewer1.SetDisplayMode(DisplayMode.Normal);
            this.reportViewer1.LocalReport.ReportPath = Path;
            this.reportViewer1.LocalReport.DataSources.Clear();
            foreach (var it in rds) 
            {
                this.reportViewer1.LocalReport.DataSources.Add(it);
            }
            this.reportViewer1.ShowParameterPrompts = true;

            if (prmts != null)
            {
                foreach (var p in prmts)
                {
                    this.reportViewer1.LocalReport.SetParameters(p);
                }
            }
            this.reportViewer1.RefreshReport();
        }

    }

}