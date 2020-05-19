using EntityMySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProviderMySql
{

    public partial class Provider : IProvider.InfraEstructura
    {

        //CXC
        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha> Reporte_CtaxCobrar_Documentos_Pendientes(DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Filtro filtros)
        {
            var result = new DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha>();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        var q = ctx.cxc.
            //            Where(d=>d.tipo_documento.Trim().ToUpper()!="PAG").
            //            Where(d => d.estatus_anulado == "0").
            //            Where(d => d.estatus_cancelado == "0").
            //            ToList();

            //        if (!string.IsNullOrEmpty(filtros.IdVendedor)) 
            //        {
            //            q = q.Where(d=>d.auto_vendedor==filtros.IdVendedor).ToList();
            //        }
            //        if (!string.IsNullOrEmpty(filtros.IdCliente))
            //        {
            //            q = q.Where(d => d.auto_cliente == filtros.IdCliente).ToList();
            //        }

            //        if (q.Count > 0)
            //        {
            //            var list = q.Select(d =>
            //            {
            //                var tipo=DTO.CtaxCobrar.Enumerados.PorTipoDocumento.SinDefinir;
            //                switch(d.tipo_documento.Trim().ToUpper())
            //                {
            //                    case "FAC":
            //                        tipo= DTO.CtaxCobrar.Enumerados.PorTipoDocumento.Factura;
            //                        break;
            //                    case "NDB":
            //                        tipo= DTO.CtaxCobrar.Enumerados.PorTipoDocumento.NtDebito ;
            //                        break;
            //                    case "NCR":
            //                        tipo= DTO.CtaxCobrar.Enumerados.PorTipoDocumento.NtCredito;
            //                        break;
            //                }
            //                return new DTO.Reportes.CtaxCobrar.Documentos.Pendiente.Ficha()
            //                {
            //                    DocFechaEmision=d.fecha,
            //                    DocFechaVencimiento=d.fecha_vencimiento,
            //                    DocNumero=d.documento,
            //                    DocTipo=tipo,
            //                    DocImporte = Math.Abs(d.importe),
            //                    DocResta=Math.Abs(d.resta),
            //                    DocSigno=d.signo,
            //                    ClienteCiRif=d.ci_rif,
            //                    ClienteCodigo=d.codigo_cliente,
            //                    ClienteNombre=d.cliente,
            //                    VendedorCodigo=d.vendedores.codigo,
            //                    VendedorNombre=d.vendedores.nombre,
            //                };
            //            }).ToList();
            //            result.cntRegistro = list.Count();
            //            result.Lista = list;
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.Mensaje = e.Message;
            //    result.Result = DTO.EnumResult.isError;
            //}

            return result;
        }


        //VENDEDORES
        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.Documentos> Reporte_CtaxCobrar_Vendedores_Documentos(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.Documentos>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.ventas.
                        Where(d => d.tipo=="01" || d.tipo=="02" || d.tipo=="03").
                        Where(d => d.estatus_anulado == "0").
                        ToList();

                    if (filtros.Desde.HasValue)
                    {
                        q = q.Where(d => d.fecha >= filtros.Desde.Value).ToList();
                    }
                    if (filtros.Hasta.HasValue)
                    {
                        q = q.Where(d => d.fecha <= filtros.Hasta.Value).ToList();
                    }
                    if (!string.IsNullOrEmpty(filtros.IdVendedor))
                    {
                        q = q.Where(d => d.auto_vendedor == filtros.IdVendedor).ToList();
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            var tipo = DTO.Reportes.CtaxCobrar.Enumerados.DocVenta.SinDefinir;
                            switch (d.tipo.Trim().ToUpper())
                            {
                                case "01":
                                    tipo = DTO.Reportes.CtaxCobrar.Enumerados.DocVenta.Factura  ;
                                    break;
                                case "02":
                                    tipo = DTO.Reportes.CtaxCobrar.Enumerados.DocVenta.NtDebito ;
                                    break;
                                case "03":
                                    tipo = DTO.Reportes.CtaxCobrar.Enumerados.DocVenta.NtCredito  ;
                                    break;
                            }
                            return new DTO.Reportes.CtaxCobrar.Vendedores.Documentos()
                            {
                                DocFechaEmision = d.fecha,
                                DocSerie=d.serie,
                                DocNumero = d.documento,
                                DocTipo = tipo,
                                DocCondicionPago=(d.condicion_pago.Trim().ToUpper()=="CONTADO"? 
                                DTO.Reportes.CtaxCobrar.Enumerados.CondicionPago.Contado: 
                                DTO.Reportes.CtaxCobrar.Enumerados.CondicionPago.Credito),
                                DocDiasCredito=d.dias ,
                                DocSubtotal=(d.total -d.impuesto),
                                DocTotal=d.total,
                                DocSigno=d.signo,
                                ClienteRif = d.ci_rif,
                                ClienteCodigo = d.codigo_cliente,
                                ClienteNombre = d.razon_social,
                                VendedorId = d.auto_vendedor,
                                VendedorCodigo = d.codigo_vendedor,
                                VendedorNombre=d.vendedor,
                            };
                        }).ToList();
                        result.cntRegistro = list.Count();
                        result.Lista = list;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.Consolidado> Reporte_CtaxCobrar_Vendedores_Consolidado(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.Consolidado>() ;

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.ventas.
                        Where(d => d.estatus_anulado == "0").
                        Where(d => d.tipo=="01" || d.tipo=="03").
                        ToList();

                    if (filtros.Desde.HasValue)
                    {
                        q = q.Where(d => d.fecha >= filtros.Desde.Value).ToList();
                    }
                    if (filtros.Hasta.HasValue)
                    {
                        q = q.Where(d => d.fecha <= filtros.Hasta.Value).ToList();
                    }
                    if (!string.IsNullOrEmpty(filtros.IdVendedor))
                    {
                        q = q.Where(d => d.auto_vendedor == filtros.IdVendedor).ToList();
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            var xbaseVta = 0.0m;
                            var ximpuestoVta= 0.0m;
                            var xexcentoVta = 0.0m;
                            var xbaseNcr = 0.0m;
                            var ximpuestoNcr = 0.0m;
                            var xtotalVta=0.0m;
                            var xtotalNcr=0.0m;

                            var tipo = DTO.Reportes.CtaxCobrar.Enumerados.DocVenta.SinDefinir;
                            switch (d.tipo.Trim().ToUpper())
                            {
                                case "01":
                                    xbaseVta = d.mbase;
                                    ximpuestoVta = d.impuesto;
                                    xexcentoVta=d.exento;
                                    xtotalVta=d.total;
                                    break;
                                case "03":
                                    xbaseNcr = d.mbase;
                                    ximpuestoNcr = d.impuesto;
                                    xtotalNcr=d.total;
                                    break;
                            }
                            return new DTO.Reportes.CtaxCobrar.Vendedores.Consolidado()
                            {
                                VendedorId = d.auto_vendedor,
                                VendedorCodigo = d.codigo_vendedor,
                                VendedorNombre = d.vendedor,
                                MontoBaseVenta=xbaseVta ,
                                MontoExcentoVenta=xexcentoVta,
                                MontoImpuestoVenta=ximpuestoVta ,
                                MontoBaseNcr=xbaseNcr,
                                MontoImpuestoNcr=ximpuestoNcr ,
                                MontoTotalNcr=xtotalNcr,
                                MontoTotalVenta=xtotalVta,
                            };
                        }).ToList();

                        result.cntRegistro = list.Count();
                        result.Lista = list;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.ComisionesPagar> Reporte_CtaxCobrar_Vendedores_ComisionesPagar(DTO.Reportes.CtaxCobrar.Vendedores.Filtro filtros)
        {
            var result = new DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Vendedores.ComisionesPagar>();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        var q = ctx.vendedores_comisiones.
            //            Where(d => d.estatus_anulado == "0").
            //            ToList();

            //        if (filtros.Desde.HasValue)
            //        {
            //            q = q.Where(d => d.fecha >= filtros.Desde.Value).ToList();
            //        }
            //        if (filtros.Hasta.HasValue)
            //        {
            //            q = q.Where(d => d.fecha <= filtros.Hasta.Value).ToList();
            //        }
            //        if (!string.IsNullOrEmpty(filtros.IdVendedor))
            //        {
            //            q = q.Where(d => d.auto_vendedor == filtros.IdVendedor).ToList();
            //        }

            //        if (q.Count > 0)
            //        {
            //            var list = q.Select(d =>
            //            {
            //                var docPagoNumero="";
            //                var entCxC = ctx.cxc.Find(d.auto_cxc);
            //                //var entMedioPago=ctx.cxc_medio_pago.FirstOrDefault(t=>t.id==d.idCxcMedioPago);
            //                //if (entMedioPago!=null)
            //                //{
            //                //    var entRecibo = ctx.cxc_recibos.Find(entMedioPago.auto_recibo);
            //                //    if (entRecibo!=null)
            //                //    {
            //                //        docPagoNumero=entRecibo.documento;
            //                //    }
            //                //}
            //                return new DTO.Reportes.CtaxCobrar.Vendedores.ComisionesPagar()
            //                {
            //                    ClienteCodigo=entCxC.codigo_cliente,
            //                    DocPagoNumero=docPagoNumero,
            //                    DocVentaNumero=entCxC.documento,
            //                    FechaRecepcionMerc=d.fecha_recepcion,
            //                    FechaMovPago=d.fecha_agencia,
            //                    DiasTranscurrido=d.dias_transcurridos,
            //                    BaseComision=d.base_comision,
            //                    ComisionPorc=d.comisionp,
            //                    ComisionCastigo=d.castigop,
            //                    AplicaCastigo=d.estatus_castigo=="1"?true:false,
            //                    Importe=d.importe,
            //                    VendedorId = d.auto_vendedor,
            //                    VendedorCodigo = d.codigo_vendedor,
            //                    VendedorNombre = d.vendedor,
            //                };
            //            }).ToList();
            //            result.cntRegistro = list.Count();
            //            result.Lista = list;
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.Mensaje = e.Message;
            //    result.Result = DTO.EnumResult.isError;
            //}

            return result;
        }


        //VENTAS
        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Ventas.LibroVenta> Reporte_CtaxCobrar_Ventas_LibroVenta(DTO.Reportes.CtaxCobrar.Ventas.Filtro filtros)
        {
            var result = new DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Ventas.LibroVenta>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    //DOCUMENTOS QUE APLICAN EN EL PERIODO
                    var q = ctx.ventas.
                        Where(d => d.tipo=="01" || d.tipo=="02" || d.tipo=="03").
                        ToList();

                    if (filtros.Desde.HasValue) 
                    {
                        q = q.Where(f => f.fecha >= filtros.Desde.Value).ToList();
                    }
                    if (filtros.Hasta.HasValue)
                    {
                        q = q.Where(f => f.fecha <= filtros.Hasta.Value).ToList();
                    }
                  
                    var list = new List<DTO.Reportes.CtaxCobrar.Ventas.LibroVenta>();
                    if (q.Count > 0)
                    {
                        list = q.Select(d =>
                        {
                            var fct="";
                            var ndb="";
                            var ncr="";
                            var tipo= DTO.Venta.Enumerados.TipoDocumento.SinDefinir;
                            switch (d.tipo)
                            {
                                case "01"://FACTURA
                                    fct=d.documento;
                                    tipo= DTO.Venta.Enumerados.TipoDocumento.Factura ;
                                    break;
                                case "02"://NDEBITO
                                    ndb=d.documento;
                                    tipo= DTO.Venta.Enumerados.TipoDocumento.NDebito ;
                                    break;
                                case "03"://NCREDITO
                                    ncr=d.documento;
                                    tipo= DTO.Venta.Enumerados.TipoDocumento.NCredito ;
                                    break;
                            }
                            return new DTO.Reportes.CtaxCobrar.Ventas.LibroVenta()
                            {
                                IdAuto=d.auto,
                                FechaEmision=d.fecha,
                                CiRif=d.ci_rif,
                                RazonSocial=d.razon_social,
                                ComprobanteRetencionNro=d.comprobante_retencion,
                                FacturaNro=fct,
                                NDebitoNro=ndb,
                                NCreditoNro=ncr,
                                ControlNro=d.control,
                                TipoDocumento=tipo,
                                DocumentoAfectaNro=d.aplica,
                                TotalVenta=d.total,
                                TotalExcento=d.exento,
                                TotalBase=d.mbase,
                                TotalImpuesto=d.impuesto,
                                TasaAlicuota=d.tasa1,
                                TotalIvaRetenido=d.retencion_iva,
                                FechaRetencion=d.fecha_retencion,
                                Signo=d.signo,
                                IsRetencion=false,
                                IsAnulado=d.estatus_anulado=="1"?true:false,
                            };
                        }).ToList();


                        //RETENCIONES QUE APLICAN EN EL PERIODO
                        var q1 = ctx.ventas_retenciones.
                            ToList();

                        if (filtros.Desde.HasValue)
                        {
                            q1 = q1.Where(f => f.fecha >= filtros.Desde.Value).ToList();
                        }
                        if (filtros.Hasta.HasValue)
                        {
                            q1 = q1.Where(f => f.fecha <= filtros.Hasta.Value).ToList();
                        }

                        foreach (var ret in q1) 
                        {
                            var ldet = ctx.ventas_retenciones_detalle.Where(r=>r.auto==ret.auto).ToList();
                            if (ldet != null) 
                            {
                                if (ldet.Count > 0) 
                                {
                                    foreach (var d in ldet) 
                                    {
                                        var fct = "";
                                        var ndb = "";
                                        var ncr = "";
                                        var tipo = DTO.Venta.Enumerados.TipoDocumento.SinDefinir;
                                        switch (d.tipo)
                                        {
                                            case "01"://FACTURA
                                                fct = d.documento;
                                                tipo = DTO.Venta.Enumerados.TipoDocumento.Factura;
                                                break;
                                            case "02"://NDEBITO
                                                ndb = d.documento;
                                                tipo = DTO.Venta.Enumerados.TipoDocumento.NDebito;
                                                break;
                                            case "03"://NCREDITO
                                                ncr = d.documento;
                                                tipo = DTO.Venta.Enumerados.TipoDocumento.NCredito;
                                                break;
                                        }

                                        var reg = new DTO.Reportes.CtaxCobrar.Ventas.LibroVenta()
                                        {
                                            IdAuto=d.auto_documento,
                                            FechaEmision = d.fecha,
                                            CiRif = d.ci_rif,
                                            RazonSocial = ret.razon_social,
                                            ComprobanteRetencionNro = d.comprobante,
                                            FacturaNro = fct,
                                            NDebitoNro = ndb,
                                            NCreditoNro = ncr,
                                            ControlNro = d.control,
                                            TipoDocumento = tipo,
                                            DocumentoAfectaNro = d.aplica,
                                            TotalVenta = d.total,
                                            TotalExcento = d.exento,
                                            TotalBase = d.@base,
                                            TotalImpuesto = d.impuesto,
                                            TasaAlicuota = d.tasa,
                                            TotalIvaRetenido = d.retencion ,
                                            FechaRetencion = d.fecha_retencion,
                                            Signo = d.signo,
                                            IsRetencion=true,
                                            IsAnulado=false,
                                        };
                                        list.Add(reg);
                                    }
                                }
                            }
                        }

                        result.cntRegistro = list.Count();
                        result.Lista = list;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }


        //CLIENTES
        public DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Clientes.Maestro.Ficha> Reporte_CtaxCobrar_Clientes_Maestro(DTO.Reportes.CtaxCobrar.Clientes.Maestro.Filtro filtros)
        {
            var result = new DTO.ResultadoLista<DTO.Reportes.CtaxCobrar.Clientes.Maestro.Ficha>();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        var q = ctx.clientes.
            //            ToList();

            //        if (!string.IsNullOrEmpty(filtros.IdVendedor))
            //        {
            //            q = q.Where(r => r.vendedores.auto == filtros.IdVendedor).ToList();
            //        }

            //        if (q.Count > 0)
            //        {
            //            var list = q.Select(d =>
            //            {
            //                return new DTO.Reportes.CtaxCobrar.Clientes.Maestro.Ficha()
            //                {
            //                     Codigo=d.codigo,
            //                     CiRif=d.ci_rif,
            //                     NombreRazonSocial=d.razon_social,
            //                     Telefono=d.telefono+","+d.telefono2,
            //                     DireccionFiscal=d.dir_fiscal,
            //                     NombreVendedor=d.vendedores.nombre,
            //                     CodigoVendedor=d.vendedores.codigo,
            //                };
            //            }).ToList();
            //            result.cntRegistro = list.Count();
            //            result.Lista = list;
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.Mensaje = e.Message;
            //    result.Result = DTO.EnumResult.isError;
            //}

            return result;
        }

    }

}