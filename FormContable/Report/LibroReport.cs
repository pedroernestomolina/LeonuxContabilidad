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

        public void Libro_Diario(OOB.Reportes.Libro.Diario.Ficha data,
            OOB.Empresa.DatosNegocio.Ficha negocio)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Report\LibroDiario.rdlc";
            var ds = new Contable();
            var saldoInicial = data.Saldo;
            var saldoFinal = data.Saldo;

            var saldo = saldoInicial;
            foreach (var it in data.Data.OrderBy(o=>o.FechaDoc).ToList())
            {
                DataRow r = ds.Tables["LibroDiario"].NewRow();
                r["TipoDocumento"] = it.TipoDocumento;
                r["DocumentoRef"] = it.DocumentoRef;
                r["DescripcionDoc"] = it.DescripcionDoc;
                r["FechaDoc"] = it.FechaDoc;
                r["MontoDebe"] = it.MontoDebe;
                r["MontoHaber"] = it.MontoHaber;
                r["Saldo"] = saldo+ (it.MontoDebe-it.MontoHaber);
                ds.Tables["LibroDiario"].Rows.Add(r);
                saldoFinal += (it.MontoDebe - it.MontoHaber);
                saldo = (saldo + (it.MontoDebe - it.MontoHaber));
            }

            var desdeHasta = "Desde: " + data.Desde.ToShortDateString() + Environment.NewLine + "Hasta: " + data.Hasta.ToShortDateString();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("RifNegocio", negocio.Rif));
            pmt.Add(new ReportParameter("NombreNegocio", negocio.NombreRazonSocial));
            pmt.Add(new ReportParameter("CtaCodigo", data.Cuenta.Cuenta));
            pmt.Add(new ReportParameter("DesdeHasta", desdeHasta));
            pmt.Add(new ReportParameter("SaldoInicial", saldoInicial.ToString()));
            pmt.Add(new ReportParameter("SaldoFinal", saldoFinal.ToString()));
            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("LibroDiario", ds.Tables["LibroDiario"]));
            var frp = new FReporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public void Libro_Mayor(OOB.Reportes.Libro.Mayor.Ficha data,
             OOB.Empresa.DatosNegocio.Ficha negocio)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Report\LibroMayor.rdlc";
            var ds = new Contable();
            var saldo = data.Saldo;
            foreach (var it in data.Data.OrderBy(o=>o.Comprobante))
            {
                DataRow r = ds.Tables["LibroMayor"].NewRow();
                r["TipoAsiento"] = it.TipoAsiento;
                r["Comprobante"] = it.Comprobante;
                r["Fecha"] = it.Fecha;
                r["TipoDocumento"] = it.TipoDocumento;
                r["MontoDebe"] = it.MontoDebe;
                r["MontoHaber"] = it.MontoHaber;
                r["Saldo"] = saldo+(it.MontoDebe-it.MontoHaber);
                saldo += (it.MontoDebe - it.MontoHaber);
                ds.Tables["LibroMayor"].Rows.Add(r);
            }

            var desdeHasta = "Desde: " + data.Desde.ToShortDateString() + Environment.NewLine + "Hasta: " + data.Hasta.ToShortDateString();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("RifNegocio", negocio.Rif));
            pmt.Add(new ReportParameter("NombreNegocio", negocio.NombreRazonSocial));
            pmt.Add(new ReportParameter("CtaCodigo", data.Cuenta.Cuenta));
            pmt.Add(new ReportParameter("DesdeHasta", desdeHasta));
            pmt.Add(new ReportParameter("SaldoInicial", data.Saldo.ToString()));
            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("LibroMayor", ds.Tables["LibroMayor"]));
            var frp = new FReporte();
            frp.rds = Rds;
            frp.Path = pt;
            frp.prmts = pmt;
            frp.ShowDialog();
        }

    }

}