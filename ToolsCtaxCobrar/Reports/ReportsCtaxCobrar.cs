using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Reports
{

    public partial class Reports : IReports
    {

        //CXC
        public void CtaxCobrar_Documentos_Pendientes(IEnumerable<OOB.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha> data)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reports\Documentos_Pendientes.rdlc";
            // var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reports\Report1.rdlc";
            var ds = new CtxCobrarDs();
            foreach (var it in data.OrderBy(d => d.ClienteNombre).OrderBy(d => d.DocFechaEmision).ToList())
            {
                DataRow r = ds.Tables["Documento"].NewRow();
                r["docnumero"] = it.DocNumero;
                r["doctipo"] = it.DocTipoDescripcion;
                r["docimporte"] = it.DocImporte;
                r["docfechaemision"] = it.DocFechaEmision;
                r["docfechavencimiento"] = it.DocFechaVencimiento;
                r["docresta"] = it.DocResta;
                r["docsigno"] = it.DocSigno;
                r["clienterif"] = it.ClienteCiRif;
                r["clientecodigo"] = it.ClienteCodigo;
                r["clienterazonsocial"] = it.Cliente;
                r["cliente"] = it.Cliente;
                r["diasAtraso"] = it.DiasAtraso;
                r["vendedorCodigo"] = it.VendedorCodigo;
                r["vendedorNombre"] = it.Vendedor;
                ds.Tables["Documento"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("Documento", ds.Tables["Documento"]));
            var frp = new ReportForm();
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();
        }


        //VENDEDORES
        public void CtaxCobrar_Vendedores_Consolidado(IEnumerable<OOB.Reportes.CtaxCobrar.Vendedores.Consolidado> data)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reports\Vendedores_Consolidado.rdlc";
            var ds = new CtxCobrarDs();
            foreach (var it in data.OrderBy(d => d.VendedorCodigo).ToList())
            {
                DataRow r = ds.Tables["Vend_Consolidado"].NewRow();
                r["VendCodigo"] = it.VendedorCodigo;
                r["Vendedor"] = it.Vendedor;
                r["MontoBaseVenta"] = it.MontoBaseVenta;
                r["MontoExcentoVenta"] = it.MontoExcentoVenta;
                r["MontoImpuestoVenta"] = it.MontoImpuestoVenta;
                r["MontoBaseNcr"] = it.MontoBaseNcr;
                r["MontoImpuestoNcr"] = it.MontoImpuestoNcr;
                r["MontoNetoVenta"] = (it.MontoExcentoVenta + it.MontoBaseVenta);
                r["VentasNeta"] = (it.MontoExcentoVenta + it.MontoBaseVenta) - it.MontoBaseNcr;
                r["VentasReales"] = (it.MontoTotalVenta - it.MontoTotalNcr);
                ds.Tables["Vend_Consolidado"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("Vend_Consolidado", ds.Tables["Vend_Consolidado"]));
            var frp = new ReportForm();
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public void CtaxCobrar_Vendedores_Documentos(IEnumerable<OOB.Reportes.CtaxCobrar.Vendedores.Documento> data)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reports\Vendedores_Documentos.rdlc";
            var ds = new CtxCobrarDs();
            foreach (var it in data.OrderBy(d => d.VendedorCodigo).OrderBy(d => d.DocFechaEmision).ToList())
            {
                DataRow r = ds.Tables["Vend_Documento"].NewRow();
                r["Fecha"] = it.DocFechaEmision;
                r["Serie"] = it.DocSerie;
                r["DocumentoNro"] = it.DocNumero;
                r["CondicionPago"] = it.DocCondicionPago == OOB.Reportes.CtaxCobrar.Enumerados.CondicionPago.Contado ? "CONTADO" : "CREDITO";
                r["DiasCredito"] = it.DocDiasCredito;
                r["ClienteNombre"] = it.ClienteRif + Environment.NewLine + it.ClienteNombre;
                r["ClienteRif"] = it.ClienteRif;
                r["SubTotal"] = it.DocSubtotal * it.DocSigno;
                r["Total"] = it.DocTotal * it.DocSigno;
                r["VendedorNombre"] = it.VendedorNombre;
                r["VendedorCodigo"] = it.VendedorCodigo;
                ds.Tables["Vend_Documento"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("Vend_Documento", ds.Tables["Vend_Documento"]));
            var frp = new ReportForm();
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public void CtaxCobrar_Vendedores_Comisiones(IEnumerable<OOB.Reportes.CtaxCobrar.Vendedores.ComisionPagar> data)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reports\Vendedores_Comisiones.rdlc";
            var ds = new CtxCobrarDs();
            foreach (var it in data.OrderBy(d => d.VendedorCodigo).OrderBy(d => d.DocVentaNumero).ToList())
            {
                DataRow r = ds.Tables["Vend_Comision"].NewRow();
                r["ClienteCodigo"] = it.ClienteCodigo;
                r["DocPagoNumero"] = it.DocPagoNumero;
                r["DocVentaNumero"] = it.DocVentaNumero;
                r["DocVentaSerie"] = "";
                r["FechaRecepcion"] = it.FechaRecepcionMerc;
                r["FechaMovPago"] = it.FechaMovPago;
                r["DiasTranscurrido"] = it.DiasTranscurrido;
                r["BaseCalculo"] = it.BaseComision;
                r["ComisionPorc"] = it.AplicaCastigo ? it.ComisionCastigo : it.ComisionPorc;
                r["EscalaA"] = it.AplicaCastigo ? 0 : it.Importe;
                r["EscalaB"] = it.AplicaCastigo ? it.Importe : 0;
                r["VendedorCodigo"] = it.VendedorCodigo;
                ds.Tables["Vend_Comision"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("Vend_Comision", ds.Tables["Vend_Comision"]));
            var frp = new ReportForm();
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();
        }


        //VENTAS
        public void CtaxCobrar_Ventas_LibroVenta(IEnumerable<OOB.Reportes.CtaxCobrar.Ventas.LibroVenta.Ficha> data)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reports\Venta_LibroVenta.rdlc";
            var ds = new CtxCobrarDs();

            var i = 1;
            var doc = data.Where(d => d.IsRetencion == false).ToList();
            var ret = data.Where(d => d.IsRetencion == true).OrderBy(o => o.FechaEmision).ToList();
            foreach (var r in ret)
            {
                var encDoc = doc.FirstOrDefault(docBus => docBus.IdAuto == r.IdAuto);
                if (encDoc == null)
                {
                    DataRow rg = ds.Tables["Venta_LibroVenta"].NewRow();
                    rg["Id"] = i;
                    rg["Fecha"] = r.FechaEmision;
                    rg["CiRif"] = r.CiRif;
                    rg["RazonSocial"] = r.RazonSocial;
                    rg["ComprobanteNro"] = r.ComprobanteRetencionNro;
                    rg["FacturaNro"] = r.FacturaNro;
                    rg["ControlNro"] = r.ControlNro;
                    rg["NDebitoNro"] = r.NDebitoNro;
                    rg["NCreditoNro"] = r.NCreditoNro;
                    if (r.TipoDocumento == OOB.Venta.Enumerados.TipoDocumento.Factura)
                        rg["TipoTransaccion"] = "01";
                    else if (r.TipoDocumento == OOB.Venta.Enumerados.TipoDocumento.NDebito)
                        rg["TipoTransaccion"] = "02";
                    else
                        rg["TipoTransaccion"] = "03";
                    rg["FacturaAfecta"] = r.DocumentoAfectaNro;
                    rg["TotalVenta"] = 0.0m ;
                    rg["TotalExcento"] = 0.0m  ;
                    rg["MontoBase"] = 0.0m  ;
                    rg["Alicuota"] = 0.0m;
                    rg["MontoIva"] = 0.0m  ;
                    rg["MontoRetencion"] = r.TotalIvaRetenido;
                    rg["FechaRetencion"] = r.FechaRetencion;
                    ds.Tables["Venta_LibroVenta"].Rows.Add(rg);
                    i++;
                }
            }

            foreach (var r in doc)
            {
                DataRow rg = ds.Tables["Venta_LibroVenta"].NewRow();
                rg["Id"] = i;
                rg["Fecha"] = r.FechaEmision;
                rg["CiRif"] = r.CiRif;
                rg["ComprobanteNro"] = r.ComprobanteRetencionNro;
                rg["FacturaNro"] = r.FacturaNro;
                rg["ControlNro"] = r.ControlNro;
                rg["NDebitoNro"] = r.NDebitoNro;
                rg["NCreditoNro"] = r.NCreditoNro;
                if (r.TipoDocumento == OOB.Venta.Enumerados.TipoDocumento.Factura)
                    rg["TipoTransaccion"] = "01";
                else if (r.TipoDocumento == OOB.Venta.Enumerados.TipoDocumento.NDebito)
                    rg["TipoTransaccion"] = "02";
                else
                    rg["TipoTransaccion"] = "03";
                rg["FacturaAfecta"] = r.DocumentoAfectaNro;
                if (r.IsAnulado)
                {
                    rg["RazonSocial"] = "A N U L A D O";
                    rg["TotalVenta"] = 0.0m;
                    rg["TotalExcento"] = 0.0m;
                    rg["MontoBase"] = 0.0m;  
                    rg["Alicuota"] = r.TasaAlicuota;
                    rg["MontoIva"] = 0.0m;
                    rg["MontoRetencion"] = 0.0m;  
                    rg["FechaRetencion"] = DBNull.Value;
                }
                else
                {
                    rg["RazonSocial"] =r.RazonSocial;
                    rg["TotalVenta"] = r.TotalVenta * r.Signo;
                    rg["TotalExcento"] = r.TotalExcento * r.Signo;
                    rg["MontoBase"] = r.TotalBase * r.Signo;
                    rg["Alicuota"] = r.TasaAlicuota;
                    rg["MontoIva"] = r.TotalImpuesto * r.Signo;
                    rg["MontoRetencion"] = r.TotalIvaRetenido;
                    if (r.AplicaRetencion)
                    {
                        rg["FechaRetencion"] = r.FechaRetencion;
                    }
                    else
                    {
                        rg["FechaRetencion"] = DBNull.Value;
                    }
                }
                ds.Tables["Venta_LibroVenta"].Rows.Add(rg);
                i++;
            }

            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("Venta_LibroVenta", ds.Tables["Venta_LibroVenta"]));
            var frp = new ReportForm();
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();
        }


        //CLIENTES
        public void CtaxCobrar_Clientes_Maestro(IEnumerable<OOB.Reportes.CtaxCobrar.Clientes.Maestro> data)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reports\Cliente_Maestro.rdlc";
            var ds = new CtxCobrarDs();
            foreach (var it in data.OrderBy(d => d.CodigoVendedor).OrderBy(d => d.NombreRazonSocial).ToList())
            {
                DataRow r = ds.Tables["Cliente_Maestro"].NewRow();
                r["CodigoCliente"] = it.Codigo ;
                r["CiRifCliente"] = it.CiRif;
                r["NombreCliente"] = it.CiRif + Environment.NewLine+ it.NombreRazonSocial ;
                r["DirFiscalCliente"] = it.DireccionFiscal;
                r["TelefonoCliente"] = it.Telefono;
                r["CodigoVendedor"] = it.CodigoVendedor;
                r["NombreVendedor"] = it.NombreVendedor ;
                ds.Tables["Cliente_Maestro"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("Cliente_Maestro", ds.Tables["Cliente_Maestro"]));
            var frp = new ReportForm();
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();

        }

    }

}