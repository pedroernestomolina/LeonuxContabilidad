using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Report
{

    public partial class Report : IReport
    {

        public void PlanCta_MaestroCta(IEnumerable<OOB.Reportes.PlanCta.Maestro.Ficha> data)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory+@"Report\MaestroCta.rdlc";
            var ds = new Contable();
            foreach (var it in data.OrderBy(d=>d.Codigo).ToList())
            {
                DataRow r = ds.Tables["MaestroCta"].NewRow();
                r["codigo"] = it.Codigo;
                r["descripcion"] = it.Nombre;
                r["nivel"] = it.Nivel;
                ds.Tables["MaestroCta"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("MaestroCta", ds.Tables["MaestroCta"]));
            var frp = new FReporte();
            frp.rds=Rds;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}