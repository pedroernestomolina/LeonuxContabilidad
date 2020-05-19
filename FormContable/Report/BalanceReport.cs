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

        public void Balance_Comprobacion(
            IEnumerable<OOB.Reportes.Balances.Comprobacion.Ficha> data, 
            OOB.Contable.Periodo.Ficha periodo, 
            OOB.Empresa.DatosNegocio.Ficha negocio)
        {
            var listTot = new List<OOB.Reportes.Balances.Comprobacion.Ficha>();
            var list = new List<OOB.Reportes.Balances.Comprobacion.Ficha>();
            var TActivos = 0.0m;
            var TPasivos = 0.0m;
            var TPatrimonio = 0.0m;

            var cta = data.FirstOrDefault(t => t.Codigo == "1");
            if (cta != null) 
            {
                //TActivos = cta.SaldoFinal;
                TActivos = cta.SaldoMes;
            }
            cta = data.FirstOrDefault(t => t.Codigo == "2");
            if (cta != null)
            {
                //TPasivos = cta.SaldoFinal;
                TPasivos = cta.SaldoMes;
            }
            cta = data.FirstOrDefault(t => t.Codigo == "3");
            if (cta != null)
            {
                //TPatrimonio = cta.SaldoFinal;
                TPatrimonio = cta.SaldoMes;
            }

            var niv = 0;
            foreach (var it in data.OrderBy(o => o.Codigo).ToList())
            {
                if (it.Nivel < 6)
                {
                    if (it.Nivel > niv)
                    {
                        niv = it.Nivel;
                        var t = new OOB.Reportes.Balances.Comprobacion.Ficha();
                        t.Codigo = "";
                        t.Nombre = "TOTAL " + it.Codigo.Trim() + " " + it.Nombre.Trim();
                        t.Debe = it.Debe;
                        t.Haber = it.Haber;
                        t.SaldoApertura = it.SaldoApertura;
                        t.Naturaleza = it.Naturaleza;
                        t.Nivel = it.Nivel;
                        t.IsTotal = true;
                        listTot.Add(t);
                    }
                    else
                    {
                        for(int g=niv;g>=it.Nivel;g--)
                        {
                            if (listTot.Count > 0)
                            {
                                var t = listTot[listTot.Count - 1];
                                if (t.Nivel >= it.Nivel)
                                {
                                    niv = it.Nivel;
                                    list.Add(t);
                                    list.Add(new OOB.Reportes.Balances.Comprobacion.Ficha());
                                    listTot.Remove(t);
                                }
                            }
                            else 
                            {
                                niv = 0;
                            }
                        }

                        niv = it.Nivel;
                        var w = new OOB.Reportes.Balances.Comprobacion.Ficha();
                        w.Codigo = "";
                        w.Nombre = "TOTAL " + it.Codigo.Trim() + " " + it.Nombre.Trim();
                        w.Debe = it.Debe;
                        w.Haber = it.Haber;
                        w.SaldoApertura = it.SaldoApertura;
                        w.Naturaleza = it.Naturaleza;
                        w.Nivel = it.Nivel;
                        w.IsTotal = true;
                        listTot.Add(w);
                    }
                }
                list.Add(it);
            }

            if (listTot.Count > 0) 
            {
                for (int g = listTot.Count-1; g>=0; g--)
                {
                    var t = listTot[g];
                    list.Add(t);
                    list.Add(new OOB.Reportes.Balances.Comprobacion.Ficha());
                }
            }

            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Report\BalanceComprobacion.rdlc";
            var ds = new Contable();
            foreach (var it in list.Where(d=> (d.Debe!=0 || d.Haber!=0) || (d.SaldoApertura !=0) ).ToList())
                //d.SaldoFinal!=0
            {
                DataRow r = ds.Tables["BalanceComprobacion"].NewRow();
                r["codigo"] = it.Codigo;
                r["descripcion"] = it.Nombre;
                r["nivel"] = (int)it.Nivel;
                r["debe"] = Math.Abs(it.Debe);
                r["haber"] = Math.Abs(it.Haber);
                r["saldoMes"] = it.SaldoMes;
                r["saldoFinal"] = it.SaldoFinal;
                r["saldoInicial"] = it.SaldoApertura;
                r["esTotal"] = it.IsTotal;
                r["debeAcumulado"] = it.DebeAcum ;
                r["haberAcumulado"] = it.HaberAcum;
                ds.Tables["BalanceComprobacion"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("BalanceComprobacion", ds.Tables["BalanceComprobacion"]));
            pmt.Add(new ReportParameter("MesRelacion", periodo.Mes));
            pmt.Add(new ReportParameter("AnoRelacion", periodo.Ano));
            pmt.Add(new ReportParameter("RifNegocio", negocio.Rif ));
            pmt.Add(new ReportParameter("NombreNegocio", negocio.NombreRazonSocial));
            pmt.Add(new ReportParameter("TActivo", TActivos.ToString()));
            pmt.Add(new ReportParameter("TPasivoMasTPatrimonio", (TPasivos+TPatrimonio).ToString()));
            pmt.Add(new ReportParameter("Resultado", (TActivos+ (TPasivos+TPatrimonio)).ToString()));
            var frp = new FReporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public void Balance_GananciaPerdida(IEnumerable<OOB.Reportes.Balances.GananciaPerdida.Ficha> data,
            OOB.Contable.Periodo.Ficha periodo, OOB.Empresa.DatosNegocio.Ficha negocio)
        {

            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Report\BalanceGananciaPerdida.rdlc";
            var ds = new Contable();
            var grupo = "";
            var signo=1;
            var tUtilidad = 0.0m;
            var mult = 1;
            foreach (var it in data.OrderBy(d=>d.Codigo).ToList())
            {
                switch (it.Codigo.Substring(0, 1)) 
                {
                    case "4":
                        grupo = "INGRESOS";
                        signo = 1;
                        mult = -1;
                        break;
                    case "5":
                        grupo = "COSTOS";
                        signo = -1;
                        mult = 1;
                        break;
                    case "6":
                        grupo = "GASTOS";
                        signo = -1;
                        mult = 1;
                        break;
                    case "7":
                        grupo = "OTROS INGRESOS/EGRESOS";
                        signo = -1;
                        mult = 1;
                        break;
                    case "8":
                        grupo = "GASTO CORRIENTE IMPUESTO SOBRE LA RENTA";
                        signo = -1;
                        mult = 1;
                        break;
                }

                DataRow r = ds.Tables["BalanceGananciaPerdida"].NewRow();
                r["codigo"] = it.Codigo;
                r["descripcion"] = it.Nombre;
                //r["saldo"] = Math.Abs(it.Saldo);
                r["saldo"] = it.Saldo*mult;
                r["grupo"] = grupo;
                r["signo"] = signo ;
                ds.Tables["BalanceGananciaPerdida"].Rows.Add(r);
                tUtilidad += it.Saldo;
            }

            var pmt = new List<ReportParameter>();
            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("BalanceGananciaPerdida", ds.Tables["BalanceGananciaPerdida"]));
            pmt.Add(new ReportParameter("MesRelacion", periodo.Mes));
            pmt.Add(new ReportParameter("AnoRelacion", periodo.Ano));
            pmt.Add(new ReportParameter("RifNegocio", negocio.Rif));
            pmt.Add(new ReportParameter("NombreNegocio", negocio.NombreRazonSocial));
            var frp = new FReporte();
            frp.prmts = pmt;
            frp.rds = Rds;
            frp.Path = pt;
           frp.ShowDialog();
        }

        public void Balance_General(IEnumerable<OOB.Reportes.Balances.General.Ficha> data, 
            OOB.Contable.Periodo.Ficha periodo, OOB.Empresa.DatosNegocio.Ficha negocio)
        {
            var listTot = new List<OOB.Reportes.Balances.General.Ficha>();
            var list = new List<OOB.Reportes.Balances.General.Ficha>();

            var niv = 0;
            foreach (var it in data.OrderBy(o => o.Codigo).ToList())
            {
                if (it.Nivel < 6)
                {
                    if (it.Nivel > niv)
                    {
                        niv = it.Nivel;
                        var t = new OOB.Reportes.Balances.General.Ficha();
                        t.Codigo = "";
                        t.Nombre = "TOTAL De "+it.Codigo.Trim()+" "+it.Nombre.Trim();
                        t.Debe = it.Debe;
                        t.Haber = it.Haber;
                        t.Nivel = it.Nivel;
                        t.SaldoAnterior = it.SaldoAnterior ;
                        t.IsTotal = true;
                        listTot.Add(t);
                    }
                    else
                    {
                        for (int g = niv; g >= it.Nivel; g--)
                        {
                            if (listTot.Count > 0)
                            {
                                var t = listTot[listTot.Count - 1];
                                if (t.Nivel >= it.Nivel)
                                {
                                    niv = it.Nivel;
                                    list.Add(t);
                                    list.Add(new OOB.Reportes.Balances.General.Ficha());
                                    listTot.Remove(t);
                                }
                            }
                            else
                            {
                                niv = 0;
                            }
                        }

                        niv = it.Nivel;
                        var w = new OOB.Reportes.Balances.General.Ficha();
                        w.Codigo = "";
                        w.Nombre = "TOTAL De " + it.Codigo.Trim() + " " + it.Nombre.Trim();
                        w.Debe = it.Debe;
                        w.Haber = it.Haber;
                        w.Nivel = it.Nivel;
                        w.SaldoAnterior = it.SaldoAnterior;
                        w.IsTotal = true;
                        listTot.Add(w);
                    }
                }
                list.Add(it);
            }

            if (listTot.Count > 0)
            {
                for (int g = listTot.Count - 1; g >= 0; g--)
                {
                    var t = listTot[g];
                    list.Add(t);
                    list.Add(new OOB.Reportes.Balances.General.Ficha());
                }
            }

            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Report\BalanceGeneral.rdlc";
            var ds = new Contable();
            foreach (var it in list.Where(d=>d.SaldoMes!=0))
            {
                DataRow r = ds.Tables["BalanceGeneral"].NewRow();
                r["codigo"] = it.Codigo;
                r["descripcion"] = it.Nombre;
                r["nivel"] = (int)it.Nivel;
                r["saldo"] = it.SaldoMes;
                r["esTotal"] = it.IsTotal;
                ds.Tables["BalanceGeneral"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("BalanceGeneral", ds.Tables["BalanceGeneral"]));
            var frp = new FReporte();
            pmt.Add(new ReportParameter("MesRelacion", periodo.Mes));
            pmt.Add(new ReportParameter("AnoRelacion", periodo.Ano));
            pmt.Add(new ReportParameter("RifNegocio", negocio.Rif));
            pmt.Add(new ReportParameter("NombreNegocio", negocio.NombreRazonSocial));
            frp.prmts = pmt;
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();

        }

    }

}