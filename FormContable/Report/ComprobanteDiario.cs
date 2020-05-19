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

        public void Balance_ComprobanteDiario(OOB.Reportes.Balances.ComprobanteDiario.Ficha data,
            OOB.Empresa.DatosNegocio.Ficha negocio)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Report\ComprobanteDiario.rdlc";
            var ds = new Contable();
            foreach (var it in data.Detalles)
            {
                DataRow r = ds.Tables["ComprobanteDiarioDet"].NewRow();
                r["renglon"] = it.Renglon;
                r["codigoCta"] = it.CodigoCta ;
                r["descripcionCta"] = it.DescripcionCta ;
                r["tipoDocumento"] = it.TipoDocumento ;
                r["documento"] = it.Documento ;
                r["descripcion"] = it.Descripcion ;
                r["debe"] = it.MontoDebe ;
                r["haber"] = it.MontoHaber ;
                ds.Tables["ComprobanteDiarioDet"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("ComprobanteDiarioDet", ds.Tables["ComprobanteDiarioDet"]));

            pmt.Add(new ReportParameter("Comprobante", data.ComprobanteNro));
            pmt.Add(new ReportParameter("DeFecha", data.DeFecha.ToShortDateString()));
            pmt.Add(new ReportParameter("Descripcion", data.Descripcion));
            pmt.Add(new ReportParameter("RifNegocio", negocio.Rif));
            pmt.Add(new ReportParameter("NombreNegocio", negocio.NombreRazonSocial));
            var frp = new FReporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}