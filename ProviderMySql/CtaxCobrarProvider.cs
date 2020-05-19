using DTO;
using EntityMySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProviderMySql
{

    public partial class Provider : IProvider.InfraEstructura
    {

        //DOCUMENTOS LISTADOS
        public ResultadoLista<DTO.CtaxCobrar.Documentos.Pendientes.Resumen> CtaxCobrar_Documentos_Pendientes(DTO.CtaxCobrar.Documentos.Pendientes.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.CtaxCobrar.Documentos.Pendientes.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();

                    var q = ctx.cxc.
                        Where(f => f.estatus_anulado == "0").
                        Where(f => Math.Abs(f.importe) > Math.Abs(f.acumulado)).
                        Where(f => f.tipo_documento != "PAG").
                        ToList();

                    if (filtro.Desde.HasValue)
                    {
                        q = q.Where(f => f.fecha >= filtro.Desde.Value).ToList();
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        q = q.Where(f => f.fecha <= filtro.Hasta.Value).ToList();
                    }

                    if (filtro.Cadena != "")
                    {
                        q = q.Where(f =>
                            f.cliente.Trim().ToUpper().Contains(filtro.Cadena.Trim().ToUpper()) ||
                            f.codigo_cliente.Trim().ToUpper().Contains(filtro.Cadena.Trim().ToUpper()) ||
                            f.ci_rif.Trim().ToUpper().Contains(filtro.Cadena.Trim().ToUpper())
                            ).ToList();
                    }
                    if (filtro.IdCliente != "")
                    {
                        q = q.Where(f => f.auto_cliente == filtro.IdCliente).ToList();
                    }
                    if (filtro.IdVendedor != "")
                    {
                        q = q.Where(f => f.auto_vendedor == filtro.IdVendedor).ToList();
                    }
                    if (filtro.PorVencimiento != DTO.CtaxCobrar.Enumerados.PorVencimiento.SinDefinir)
                    {
                        if (filtro.PorVencimiento == DTO.CtaxCobrar.Enumerados.PorVencimiento.Vencido)
                        {
                            q = q.Where(f => FechaSistema.Date > f.fecha_vencimiento).ToList();
                        }
                        if (filtro.PorVencimiento == DTO.CtaxCobrar.Enumerados.PorVencimiento.PorVencer)
                        {
                            q = q.Where(f => f.fecha_vencimiento > FechaSistema.Date).ToList();
                        }
                    }

                    if (filtro.PorTipoDocumento != DTO.CtaxCobrar.Enumerados.PorTipoDocumento.SinDefinir)
                    {
                        switch (filtro.PorTipoDocumento)
                        {
                            case DTO.CtaxCobrar.Enumerados.PorTipoDocumento.Factura:
                                q = q.Where(f => f.tipo_documento == "FAC").ToList();
                                break;
                            case DTO.CtaxCobrar.Enumerados.PorTipoDocumento.NtDebito:
                                q = q.Where(f => f.tipo_documento == "NDB").ToList();
                                break;
                            case DTO.CtaxCobrar.Enumerados.PorTipoDocumento.NtCredito:
                                q = q.Where(f => f.tipo_documento == "NCR").ToList();
                                break;
                        }
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            var tipo = DTO.CtaxCobrar.Enumerados.PorTipoDocumento.SinDefinir;
                            switch (d.tipo_documento)
                            {
                                case "FAC":
                                    tipo = DTO.CtaxCobrar.Enumerados.PorTipoDocumento.Factura;
                                    break;
                                case "NCR":
                                    tipo = DTO.CtaxCobrar.Enumerados.PorTipoDocumento.NtCredito;
                                    break;
                                case "NDB":
                                    tipo = DTO.CtaxCobrar.Enumerados.PorTipoDocumento.NtDebito;
                                    break;
                            }
                            return new DTO.CtaxCobrar.Documentos.Pendientes.Resumen()
                            {
                                Id = d.auto,
                                DocumentoNro = d.documento,
                                DocumentoSerie = d.serie,
                                DocumentoTipo = tipo,
                                ClienteCiRif = d.ci_rif,
                                ClienteNombre = d.cliente,
                                FechaEmision = d.fecha,
                                FechaVencimiento = d.fecha_vencimiento,
                                Detalle = d.nota,
                                Importe = Math.Abs(d.importe),
                                Abonado = Math.Abs(d.acumulado),
                                Signo = d.signo,
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

        public ResultadoEntidad<DTO.CtaxCobrar.Documentos.Pendientes.Ficha> CtaxCobrar_Documentos_Pendientes_Get_ById(string auto)
        {
            var result = new ResultadoEntidad<DTO.CtaxCobrar.Documentos.Pendientes.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.cxc.Find(auto);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] DOCUMENTO POR COBRAR NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var tipo = DTO.CtaxCobrar.Enumerados.PorTipoDocumento.SinDefinir;
                    switch (ent.tipo_documento)
                    {
                        case "FAC":
                            tipo = DTO.CtaxCobrar.Enumerados.PorTipoDocumento.Factura;
                            break;
                        case "NCR":
                            tipo = DTO.CtaxCobrar.Enumerados.PorTipoDocumento.NtCredito;
                            break;
                        case "NDB":
                            tipo = DTO.CtaxCobrar.Enumerados.PorTipoDocumento.NtDebito;
                            break;
                    }

                    var autoDocumentoVenta = "";
                    if (ent.auto != ent.auto_documento)
                    {
                        autoDocumentoVenta = ent.auto_documento;
                    }

                    var doc = new DTO.CtaxCobrar.Documentos.Pendientes.Ficha()
                    {
                        IdAuto = ent.auto,
                        IdAutCliente = ent.auto_cliente,
                        IdAutoVendedor = ent.auto_vendedor,
                        IdAutoDocumentoVenta = autoDocumentoVenta,
                        DocumentoNro = ent.documento,
                        DocumentoSerie = ent.serie,
                        DocumentoTipo = tipo,
                        FechaEmision = ent.fecha,
                        FechaVencimiento = ent.fecha_vencimiento,
                        Detalle = ent.nota,
                        Importe = Math.Abs(ent.importe),
                        Abonado = Math.Abs(ent.acumulado),
                        Signo = ent.signo,
                        IsAnulado = ent.estatus_anulado == "1" ? true : false,
                        IsCancelado = ent.estatus_cancelado == "1" ? true : false,
                        ClienteNombre = ent.cliente,
                        ClienteCiRif = ent.ci_rif,
                        ClienteCodigo = ent.codigo_cliente,
                        ComisionCobranzaP = ent.c_cobranzap,
                        ComisionVentaP = ent.c_ventasp,
                        ImporteNeto = ent.importe_neto,
                        DiasTolerancia = ent.dias,
                        CastigoP = ent.castigop,
                       // FechaRecepcionMercancia = ent.fecha_recepcion
                    };

                    result.Entidad = doc;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = null;
            }

            return result;
        }

        public ResultadoLista<DTO.CtaxCobrar.Documentos.Pagos.Resumen> CtaxCobrar_Documentos_Pagos(DTO.CtaxCobrar.Documentos.Pagos.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.CtaxCobrar.Documentos.Pagos.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();

                    var q = ctx.cxc.
                        Where(f => f.tipo_documento == "PAG").
                        ToList();
                    if (filtro.Desde.HasValue)
                    {
                        q = q.Where(f => f.fecha>=filtro.Desde.Value).ToList();
                    }
                    if (filtro.Hasta.HasValue)
                    {
                        q = q.Where(f => f.fecha <= filtro.Hasta.Value).ToList();
                    }
                    if (filtro.Cadena != "")
                    {
                        q = q.Where(f =>
                            f.cliente.Trim().ToUpper().Contains(filtro.Cadena.Trim().ToUpper()) ||
                            f.codigo_cliente.Trim().ToUpper().Contains(filtro.Cadena.Trim().ToUpper()) ||
                            f.ci_rif.Trim().ToUpper().Contains(filtro.Cadena.Trim().ToUpper())
                            ).ToList();
                    }
                    if (filtro.IdCliente != "")
                    {
                        q = q.Where(f => f.auto_cliente == filtro.IdCliente).ToList();
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.CtaxCobrar.Documentos.Pagos.Resumen()
                            {
                                Id = d.auto,
                                DocumentoNro = d.documento,
                                ClienteCiRif = d.ci_rif,
                                ClienteCodigo = d.codigo_cliente,
                                ClienteNombre = d.cliente,
                                FechaEmision = d.fecha,
                                Importe = Math.Abs(d.importe),
                                Notas = d.nota,
                                IsAnulado = d.estatus_anulado == "0" ? false : true,
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


        //RECIBO
        public DTO.ResultadoEntidad<DTO.CtaxCobrar.Recibo.Ficha> CtaxCobrar_Recibo_GetById(string autoDoc)
        {
            var result = new ResultadoEntidad<DTO.CtaxCobrar.Recibo.Ficha>();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        var ent = ctx.cxc_recibos.Find(autoDoc);
            //        if (ent == null)
            //        {
            //            result.Mensaje = "[ ID ] RECIBO DE PAGO NO ENCONTRADO";
            //            result.Result = DTO.EnumResult.isError;
            //            result.Entidad = null;
            //            return result;
            //        }

            //        var doc = new DTO.CtaxCobrar.Recibo.Ficha()
            //        {
            //            FechaEmision = ent.fecha,
            //            Hora = ent.hora,
            //            DocumentoNro = ent.documento,
            //            CliCodigo = ent.codigo,
            //            CliNombre = ent.cliente,
            //            CliCiRif = ent.ci_rif,
            //            CliDireccionFiscal = ent.direccion,
            //            CliTelefono = ent.telefono,
            //            Usuario = ent.usuario,
            //            Estacion = "",
            //            Importe = ent.importe,
            //            Notas = ent.nota,
            //            CobCodigo = ent.codigo_cobrador,
            //            CobNombre = ent.cobrador
            //        };

            //        var pago = new DTO.CtaxCobrar.Recibo.Pago();
            //        pago.MontoPorAnticipos = ent.anticipos;
            //        pago.MontoPorDescuento = ent.descuentos;
            //        pago.MontoPorRetenciones = ent.retenciones;

            //        var entMedioPago = ctx.cxc_medio_pago.FirstOrDefault(mp => mp.auto_recibo == ent.auto);
            //        if (entMedioPago != null)
            //        {
            //            pago.MedioPago = new DTO.CtaxCobrar.Recibo.Medio()
            //            {
            //                Descripcion = entMedioPago.medio,
            //                Codigo = entMedioPago.codigo,
            //                Agencia = entMedioPago.agencia,
            //                MontoRecibido = entMedioPago.monto_recibido,
            //            };
            //        }
            //        doc.FormaPago = pago;

            //        var entDet = ctx.cxc_documentos.Where(d => d.auto_cxc_recibo == autoDoc).ToList();
            //        if (entDet.Count() > 0)
            //        {
            //            var det = entDet.Select((d) =>
            //            {
            //                return new DTO.CtaxCobrar.Recibo.Documento()
            //                {
            //                    DocumentoNro = d.documento,
            //                    TipoDocumento = d.tipo_documento,
            //                    Fecha = d.fecha,
            //                    Importe = d.importe,
            //                    Operacion = d.operacion
            //                };
            //            }).ToList();
            //            doc.Documentos = det;
            //        }

            //        result.Entidad = doc;
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.Mensaje = e.Message;
            //    result.Result = DTO.EnumResult.isError;
            //    result.Entidad = null;
            //}

            return result;
        }

        private class RelMedioPagoComision
        {
            public int Id { get; set; }
            public int IdMovGenerado { get; set; }
            public DateTime FechaMov { get; set; }
        };

        //PAGO
        public ResultadoEntidad<string> CtaxCobrar_Pago_Procesar(DTO.CtaxCobrar.Pago.Ficha pago)
        {
            var result = new ResultadoEntidad<string>();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        using (var ts = new TransactionScope())
            //        {
            //            var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();

            //            var entCnt = ctx.sistema_contadores.Find(1);
            //            entCnt.a_cxc += 1;
            //            entCnt.a_cxc_recibo += 1;
            //            entCnt.a_cxc_recibo_numero += 1;
            //            ctx.SaveChanges();

            //            var idPago = entCnt.a_cxc.ToString().Trim().PadLeft(10, '0');
            //            var idRecibo = entCnt.a_cxc_recibo.ToString().Trim().PadLeft(10, '0');
            //            var idReciboNumero = entCnt.a_cxc_recibo_numero.ToString().Trim().PadLeft(10, '0');

            //            var entCxcPago = new cxc()
            //            {
            //                auto = idPago,
            //                c_cobranza = 0,
            //                c_cobranzap = 0,
            //                fecha = pago.FechaRecibo,
            //                tipo_documento = "PAG",
            //                documento = idReciboNumero,
            //                fecha_vencimiento = pago.FechaRecibo,
            //                nota = pago.Notas,
            //                importe = pago.TotalMontoRecibo,
            //                acumulado = 0,
            //                auto_cliente = pago.ClienteId,
            //                cliente = pago.ClienteNombre,
            //                ci_rif = pago.ClienteRif,
            //                codigo_cliente = pago.ClienteCodigo,
            //                estatus_cancelado = "0",
            //                resta = 0,
            //                estatus_anulado = "0",
            //                auto_documento = idRecibo,
            //                numero = "",
            //                auto_agencia = "0000000001",
            //                agencia = "",
            //                signo = -1,
            //                auto_vendedor = "0000000001",
            //                c_departamento = 0,
            //                c_ventas = 0,
            //                c_ventasp = 0,
            //                serie = "",
            //                importe_neto = 0,
            //                dias = 0,
            //                castigop = 0,
            //               // fecha_recepcion = new DateTime(2000, 1, 1),
            //            };
            //            ctx.cxc.Add(entCxcPago);
            //            ctx.SaveChanges();

            //            var entRecibo = new cxc_recibos()
            //            {
            //                auto_cxc = idPago,
            //                auto = idRecibo,
            //                documento = idReciboNumero,
            //                fecha = pago.FechaRecibo,
            //                importe = pago.TotalMontoRecibo,
            //                monto_recibido = pago.TotalMontoRecibido,

            //                auto_cliente = pago.ClienteId,
            //                ci_rif = pago.ClienteRif,
            //                codigo = pago.ClienteCodigo,
            //                cliente = pago.ClienteNombre,
            //                direccion = pago.ClienteDireccion,
            //                telefono = pago.ClienteTelefono,

            //                auto_usuario = pago.UsuarioId,
            //                usuario = pago.UsuarioNombre,

            //                auto_cobrador = pago.CobradorId,
            //                cobrador = pago.CobradorNombre,
            //                codigo_cobrador = pago.CobradorCodigo,

            //                anticipos = pago.TotalMontoAnticipos,
            //                descuentos = pago.TotalMontoDescuentos,
            //                retenciones = pago.TotalMontoRetenciones,
            //                cambio = 0,
            //                nota = pago.Notas,
            //                estatus_anulado = "0",
            //                hora = "",
            //                cierre = "",
            //            };
            //            ctx.cxc_recibos.Add(entRecibo);
            //            ctx.SaveChanges();

            //            var _id = 0;
            //            foreach (var doc in pago.DocumentosCxcPagar)
            //            {
            //                _id += 1;
            //                var _tipo = "";
            //                switch (doc.DocumentoTipo)
            //                {
            //                    case DTO.CtaxCobrar.Pago.Enumerados.TipoDoc.Factura:
            //                        _tipo = "FAC";
            //                        break;
            //                    case DTO.CtaxCobrar.Pago.Enumerados.TipoDoc.NtDebito:
            //                        _tipo = "NDB";
            //                        break;
            //                    case DTO.CtaxCobrar.Pago.Enumerados.TipoDoc.NtCredito:
            //                        _tipo = "NCR";
            //                        break;
            //                }
            //                var _operacion = "";
            //                switch (doc.TipoOeracion)
            //                {
            //                    case DTO.CtaxCobrar.Pago.Enumerados.Operacion.Pago:
            //                        _operacion = "Pago";
            //                        break;
            //                    case DTO.CtaxCobrar.Pago.Enumerados.Operacion.Abono:
            //                        _operacion = "Abono";
            //                        break;
            //                }

            //                //REGISTRO DOCUMENTOS PAGADOS, Y COMO FUERON TRATADOS 
            //                var entDocumento = new cxc_documentos()
            //                {
            //                    id = _id,
            //                    fecha = doc.DocumentoFecha,
            //                    tipo_documento = _tipo,
            //                    documento = doc.DocumentoNumero,
            //                    importe = doc.MontoAbonado,
            //                    operacion = _operacion,
            //                    auto_cxc = doc.autoId,
            //                    auto_cxc_pago = idPago,
            //                    auto_cxc_recibo = idRecibo,
            //                    numero_recibo = idReciboNumero,
            //                    fecha_recepcion = doc.fechaRecepcion,
            //                    dias = doc.ToleranciaDias,
            //                    castigop = doc.CastigoPorc,
            //                    comisionp = doc.ComisionPorc,
            //                };
            //                ctx.cxc_documentos.Add(entDocumento);
            //                ctx.SaveChanges();

            //                //ACTUALIZO DOCUMENTO ORIGEN CXC; SALDO 
            //                var entCxc = ctx.cxc.Find(doc.autoId);
            //                if (entCxc == null)
            //                {
            //                    result.Mensaje = "ERROR AL PROCESAR PAGO" + Environment.NewLine + "DOCUMENTO (" + doc.DocumentoNumero + ") NO ENCONTRADO";
            //                    result.Result = DTO.EnumResult.isError;
            //                    result.Entidad = "";
            //                    return result;
            //                }

            //                if (entCxc.estatus_anulado == "0")
            //                {
            //                    if (entCxc.estatus_cancelado == "0")
            //                    {
            //                        if (Math.Abs(doc.MontoAbonado) > Math.Abs(entCxc.resta))
            //                        {
            //                            result.Mensaje = "ERROR AL PROCESAR PAGO" + Environment.NewLine + "DOCUMENTO (" + doc.DocumentoNumero + ") MONTO ABONADO SUPERA EL SALDO PENDIENTE";
            //                            result.Result = DTO.EnumResult.isError;
            //                            result.Entidad = "";
            //                            return result;
            //                        }
            //                        else
            //                        {
            //                            entCxc.acumulado += doc.MontoAbonado;
            //                           // entCxc.fecha_recepcion = doc.fechaRecepcion;
            //                            entCxc.resta -= doc.MontoAbonado;
            //                            entCxc.estatus_cancelado = entCxc.resta == 0.0m ? "1" : "0";
            //                            ctx.SaveChanges();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        result.Mensaje = "ERROR AL PROCESAR PAGO" + Environment.NewLine + "DOCUMENTO (" + doc.DocumentoNumero + ") YA PAGADO";
            //                        result.Result = DTO.EnumResult.isError;
            //                        result.Entidad = "";
            //                        return result;
            //                    }
            //                }
            //                else
            //                {
            //                    result.Mensaje = "ERROR AL PROCESAR PAGO" + Environment.NewLine + "DOCUMENTO (" + doc.DocumentoNumero + ") ANULADO";
            //                    result.Result = DTO.EnumResult.isError;
            //                    result.Entidad = "";
            //                    return result;
            //                }
            //            }

            //            var listRelMedioPagoComision = new List<RelMedioPagoComision>();
            //            //MEDIOS DE PAGO
            //            foreach (var mp in pago.MediosPago)
            //            {
            //                //
            //                var entMedioPago = new cxc_medio_pago()
            //                {
            //                    auto_recibo = idRecibo,
            //                    auto_medio_pago = mp.autoMedioId,
            //                    auto_agencia = mp.autoBancoId,
            //                    medio = mp.DescripcionMedio,
            //                    codigo = mp.CodigoMedio,
            //                    monto_recibido = mp.MontoRecibido,
            //                    fecha = FechaSistema.Date,
            //                    estatus_anulado = "0",
            //                    numero = mp.Referencia,
            //                    agencia = mp.BancoDescripcion,
            //                    auto_usuario = pago.UsuarioId,
            //                    lote = "",
            //                    referencia = "",
            //                    auto_cobrador = pago.CobradorId,
            //                    cierre = "",
            //                    fecha_agencia = mp.FechaMovimiento,
            //                };
            //                ctx.cxc_medio_pago.Add(entMedioPago);
            //                ctx.SaveChanges();

            //                var rel = new RelMedioPagoComision()
            //                {
            //                    Id = mp.IdClave,
            //                    FechaMov = mp.FechaMovimiento,
            //                  //  IdMovGenerado = entMedioPago.id,
            //                };
            //                listRelMedioPagoComision.Add(rel);

            //                //BANCOS MOVIMIENTOS
            //                entCnt.a_bancos_movimientos += 1;
            //                ctx.SaveChanges();
            //                var idBancoMov = entCnt.a_bancos_movimientos.ToString().Trim().PadLeft(10, '0');

            //                var entBancoMov = new bancos_movimientos()
            //                {
            //                    auto = idBancoMov,
            //                    fecha = mp.FechaMovimiento,
            //                    tipo = "DEP",
            //                    documento = "",
            //                    importe = mp.MontoRecibido,
            //                    signo = 1,
            //                    estatus_conciliado = "0",
            //                    auto_banco = mp.autoBancoId,
            //                    detalle = "COBRANZA ADMINISTRATIVA",
            //                    numero_cuenta = mp.BancoNroCta,
            //                    banco = mp.BancoDescripcion,
            //                    estatus_anulado = "0",
            //                    entidad = "COBRANZA ADMINISTRATIVA",
            //                    origen = "CXC",
            //                    comprobante_egreso = "N/A",
            //                    codigo_banco = mp.BancoCodigo,
            //                    fecha_cheque = new DateTime(2000, 1, 1),
            //                    auto_asiento = "0000000002",
            //                };
            //                ctx.bancos_movimientos.Add(entBancoMov);
            //                ctx.SaveChanges();
                            
            //                var entCxCBancoMovGen = new cxc_banco_movimientos_generados() 
            //                {
            //                     auto_cxc=idPago,
            //                     auto_banco_movimiento=idBancoMov,
            //                };
            //                ctx.cxc_banco_movimientos_generados.Add(entCxCBancoMovGen);
            //                ctx.SaveChanges();
            //            }

            //            //RETENCIONES IVA
            //            foreach (var rt in pago.RetencionesIva)
            //            {
            //                entCnt.a_ventas_retenciones += 1;
            //                ctx.SaveChanges();
            //                var idRetencion = entCnt.a_ventas_retenciones.ToString().Trim().PadLeft(10, '0');

            //                //
            //                var entRetencion = new ventas_retenciones()
            //                {
            //                    auto = idRetencion,
            //                    documento = rt.ComprobanteNro,
            //                    fecha = pago.FechaRecibo,
            //                    razon_social = pago.ClienteNombre,
            //                    dir_fiscal = pago.ClienteDireccion,
            //                    ci_rif = pago.ClienteRif,
            //                    tipo = "07",
            //                    exento = rt.MontoExcento,
            //                    @base = rt.MontoBase,
            //                    impuesto = rt.MontoImpuesto,
            //                    total = rt.MontoTotal,
            //                    tasa_retencion = rt.TasaRetencion,
            //                    retencion = rt.MontoRetencion,
            //                    auto_cliente = pago.ClienteId,
            //                    fecha_relacion = pago.FechaRecibo,
            //                    codigo_cliente = pago.ClienteCodigo,
            //                    ano_relacion = pago.FechaRecibo.Year.ToString().Trim(),
            //                    mes_relacion = pago.FechaRecibo.Month.ToString().Trim().PadLeft(2, '0'),
            //                    renglones = 1,
            //                    documento_nombre = "RETENCION IVA",
            //                };
            //                ctx.ventas_retenciones.Add(entRetencion);
            //                ctx.SaveChanges();

            //                var entRetencionDetalle = new ventas_retenciones_detalle()
            //                {
            //                    auto_documento = rt.DocumentoId,
            //                    documento = rt.DocumentoNro,
            //                    fecha = rt.DocumentoFecha,
            //                    ci_rif = pago.ClienteRif,
            //                    tipo = "01",
            //                    exento = rt.MontoExcento,
            //                    @base = rt.MontoBase,
            //                    impuesto = rt.MontoImpuesto,
            //                    total = rt.MontoTotal,
            //                    tasa_retencion = rt.TasaRetencion,
            //                    retencion = rt.MontoRetencion,
            //                    auto = idRetencion,
            //                    fecha_retencion = rt.DeFecha,
            //                    comprobante = rt.ComprobanteNro,
            //                    tipo_retencion = "07",
            //                    aplica = "",
            //                    control = rt.DocumentoControl,
            //                    tasa = rt.DocumentoTasaIva,
            //                    signo = 1,
            //                };
            //                ctx.ventas_retenciones_detalle.Add(entRetencionDetalle);
            //                ctx.SaveChanges();

            //                var entVenta = ctx.ventas.Find(rt.DocumentoId);
            //                if (entVenta != null)
            //                {
            //                    entVenta.comprobante_retencion = rt.ComprobanteNro;
            //                    entVenta.retencion_iva = rt.MontoRetencion;
            //                    entVenta.fecha_retencion = rt.DeFecha;
            //                    ctx.SaveChanges();
            //                }

            //                var entCxCRetGen = new cxc_retenciones_generadas()
            //                {
            //                    auto_cxc = idPago,
            //                    auto_ventas_retenciones = idRetencion,
            //                };
            //                ctx.cxc_retenciones_generadas.Add(entCxCRetGen );
            //                ctx.SaveChanges();
            //            }

            //            //COMISIONES
            //            foreach (var cv in pago.Comisiones)
            //            {

            //                entCnt.a_vendedores_comisiones += 1;
            //                ctx.SaveChanges();
            //                var idVendComision = entCnt.a_vendedores_comisiones.ToString().Trim().PadLeft(10, '0');

            //                //MEDIO DE PAGO RELACIONADO CON LA COMISION
            //                var mp = listRelMedioPagoComision.First(k => cv.IdClaveRelMedioPago == k.Id);

            //                //
            //                var entVendComision = new vendedores_comisiones()
            //                {
            //                    auto = idVendComision,
            //                    fecha = pago.FechaRecibo,
            //                    tipo_documento = "C02",
            //                    documento = idVendComision,
            //                    nota = "",
            //                    importe = cv.TotalComision,
            //                    auto_vendedor = pago.VendedorId,
            //                    vendedor = pago.VendedorNombre,
            //                    ci = pago.VendedorCiRif,
            //                    codigo_vendedor = pago.VendedorCodigo,
            //                    estatus_cancelado = "0",
            //                    estatus_anulado = "0",
            //                    auto_documento = idVendComision,
            //                    signo = 1,
            //                    comisionp = cv.ComisionPorc,
            //                    base_comision = cv.BaseCalculo,
            //                    castigop = cv.CastigoPorc,
            //                    auto_cxc = cv.DocCxc_Id,
            //                    dias = cv.ToleranciaDias,
            //                    monto_recibido = cv.MontoRecibido,
            //                    fecha_recepcion = cv.DocCxc_FechaRecepcion,
            //                    fecha_agencia = mp.FechaMov,
            //                    estatus_castigo = cv.IsCastigado == true ? "1" : "0",
            //                    dias_transcurridos = cv.DiasTranscurridos,
            //                    fecha_registro = FechaSistema,
            //                    idCxcMedioPago = mp.IdMovGenerado,
            //                };
            //                ctx.vendedores_comisiones.Add(entVendComision);
            //                ctx.SaveChanges();

            //                var entCxCVendComGen = new cxc_vendedor_comisiones_generadas()
            //                {
            //                    auto_cxc = idPago,
            //                    auto_vendedor_comision  = idVendComision,
            //                };
            //                ctx.cxc_vendedor_comisiones_generadas.Add(entCxCVendComGen);
            //                ctx.SaveChanges();
            //            }

            //            if (pago.GenerarNotaCreditoMontoFavorCliente) 
            //            {
            //                if (pago.MontoFavorCliente > 0) 
            //                {

            //                    entCnt.a_cxc+= 1;
            //                    entCnt.a_cxc_nc += 1;
            //                    ctx.SaveChanges();

            //                    var idDoc = entCnt.a_cxc.ToString().Trim().PadLeft(10, '0');
            //                    var idNcr = entCnt.a_cxc_nc.ToString().Trim().PadLeft(10, '0');
            //                    var entCxcNC = new cxc()
            //                    {
            //                        auto = idDoc,
            //                        c_cobranza = 0,
            //                        c_cobranzap = 0,
            //                        fecha = FechaSistema,
            //                        tipo_documento = "NCR",
            //                        documento = idNcr,
            //                        fecha_vencimiento = FechaSistema,
            //                        nota = "PAGO SUPERO EL MONTO A LIQUIDAR",
            //                        importe = pago.MontoFavorCliente*(-1),
            //                        acumulado = 0,
            //                        auto_cliente = pago.ClienteId,
            //                        cliente = pago.ClienteNombre,
            //                        ci_rif = pago.ClienteRif,
            //                        codigo_cliente = pago.ClienteCodigo,
            //                        estatus_cancelado = "0",
            //                        resta = 0,
            //                        estatus_anulado = "0",
            //                        auto_documento = idNcr,
            //                        numero = "",
            //                        auto_agencia = "0000000001",
            //                        agencia = "",
            //                        signo = -1,
            //                        auto_vendedor = "0000000001",
            //                        c_departamento = 0,
            //                        c_ventas = 0,
            //                        c_ventasp = 0,
            //                        serie = "",
            //                        importe_neto = 0,
            //                        dias = 0,
            //                        castigop = 0,
            //                       // fecha_recepcion = new DateTime(2000, 1, 1),
            //                    };
            //                    ctx.cxc.Add(entCxcNC);
            //                    ctx.SaveChanges();
            //                }
            //            }

            //            //ACTUALIZO CLIENTE; SALDOS 
            //            var entCliente = ctx.clientes.Find(pago.ClienteId);
            //            if (entCliente == null)
            //            {
            //                result.Mensaje = "ERROR AL PROCESAR PAGO" + Environment.NewLine + "CLIENTE NO ENCONTRADO";
            //                result.Result = DTO.EnumResult.isError;
            //                result.Entidad = "";
            //                return result;
            //            }

            //            entCliente.fecha_ult_pago = pago.FechaRecibo;
            //            entCliente.saldo -= pago.TotalMontoRecibo;
            //            entCliente.saldo -= pago.MontoFavorCliente;
            //            var d = entCliente.limite_credito - entCliente.saldo;
            //            entCliente.disponible = d;
            //            ctx.SaveChanges();

            //            ts.Complete();
            //            result.Entidad = idPago;
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    result.Mensaje = e.Message;
            //    result.Result = DTO.EnumResult.isError;
            //    result.Entidad = "";
            //}

            return result;
        }

        public Resultado CtaxCobrar_Pago_Anular(DTO.CtaxCobrar.Pago.Anular ficha)
        {
            var result = new Resultado();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        using (var ts = new TransactionScope())
            //        {
            //            var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();

            //            var entCxcPago = ctx.cxc.Find(ficha.IdPago);
            //            entCxcPago.estatus_anulado = "1";
            //            ctx.SaveChanges();
            //            var MontoPago = entCxcPago.importe;

            //            var entRecibo = ctx.cxc_recibos.FirstOrDefault(r => r.auto_cxc == ficha.IdPago);
            //            if (entRecibo == null)
            //            {
            //                result.Mensaje = "[ ID ] PAGO NO ENCONTRADO";
            //                result.Result = DTO.EnumResult.isError;
            //                return result;
            //            }
            //            entRecibo.estatus_anulado = "1";
            //            ctx.SaveChanges();

            //            var IdRecibo = entRecibo.auto;
            //            var IdCliente = entRecibo.auto_cliente;

            //            var entDocumentos = ctx.cxc_documentos.Where(d => d.auto_cxc_pago == ficha.IdPago).ToList();
            //            foreach (var doc in entDocumentos)
            //            {
            //                //ACTUALIZO DOCUMENTO ORIGEN CXC; SALDO 
            //                var entCxc = ctx.cxc.Find(doc.auto_cxc);
            //                if (entCxc != null)
            //                {
            //                    entCxc.acumulado -= doc.importe;
            //                    entCxc.resta += doc.importe;
            //                    entCxc.estatus_cancelado = "0";
            //                }
            //                ctx.SaveChanges();
            //            }

            //            var entMediosPago = ctx.cxc_medio_pago.Where(d => d.auto_recibo == IdRecibo).ToList();
            //            //MEDIOS DE PAGO
            //            foreach (var mp in entMediosPago)
            //            {
            //                mp.estatus_anulado = "1";
            //            }

            //            //ACTUALIZO CLIENTE; SALDOS 
            //            var entCliente = ctx.clientes.Find(IdCliente);
            //            entCliente.saldo += MontoPago;
            //            var disponible = entCliente.limite_credito - MontoPago;
            //            entCliente.disponible += disponible;
            //            ctx.SaveChanges();

            //            //ACTUALIZO MOVIMIENTOS DE BANCOS GENERADOS
            //            var entBancoMov = ctx.cxc_banco_movimientos_generados.Where(mv => mv.auto_cxc == ficha.IdPago).ToList();
            //            if (entBancoMov.Count() > 0)
            //            {
            //                foreach (var mov in entBancoMov)
            //                {
            //                    mov.bancos_movimientos.estatus_anulado = "1";
            //                    ctx.SaveChanges();
            //                }
            //            }

            //            //ACTUALIZO VENDEDORES COMISIONES GENERADAS
            //            var entVendComisiones = ctx.cxc_vendedor_comisiones_generadas.Where(mv => mv.auto_cxc == ficha.IdPago).ToList();
            //            if (entVendComisiones.Count() > 0) 
            //            {
            //                foreach (var mov in entVendComisiones)
            //                {
            //                    mov.vendedores_comisiones.estatus_anulado = "1";
            //                    ctx.SaveChanges();
            //                }
            //            }

            //            //ACTUALIZO RETENCIONES IVA VENTA GENERADAS
            //            var entRetenciones = ctx.cxc_retenciones_generadas.Where(mv => mv.auto_cxc == ficha.IdPago).ToList();
            //            if (entRetenciones.Count() > 0)
            //            {
            //                foreach (var mov in entRetenciones)
            //                {
            //                    var entRetDt = ctx.ventas_retenciones_detalle.FirstOrDefault(d => d.auto == mov.auto_ventas_retenciones);
            //                    if (entRetDt == null)
            //                    {
            //                        result.Mensaje = "[ RETENCION DETALLE ] NO ENCONTRADA";
            //                        result.Result = EnumResult.isError;
            //                        return result;
            //                    }
            //                    var autoDocVenta = entRetDt.auto_documento;
            //                    ctx.ventas_retenciones_detalle.Remove(entRetDt);
            //                    ctx.SaveChanges();

            //                    var entVenta = ctx.ventas.Find(autoDocVenta);
            //                    if (entVenta != null)
            //                    {
            //                        entVenta.comprobante_retencion = "";
            //                        entVenta.retencion_iva = 0.0m;
            //                        entVenta.fecha_retencion = new DateTime(2000, 01, 01);
            //                        ctx.SaveChanges();
            //                    }

            //                    var entRet = ctx.ventas_retenciones.Find(mov.auto_ventas_retenciones);
            //                    if (entRet == null)
            //                    {
            //                        result.Mensaje = "[ RETENCION ] NO ENCONTRADA";
            //                        result.Result = EnumResult.isError;
            //                        return result;
            //                    }
            //                    ctx.ventas_retenciones.Remove(entRet);
            //                    ctx.SaveChanges();
            //                }
            //            }

            //            ctx.SaveChanges();
            //            ts.Complete();
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

        public Resultado CtaxCobrar_Pago_Anular_Verificar(string idPago)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var entPago = ctx.cxc.Find(idPago);
                    if (entPago== null)
                    {
                        result.Mensaje = "[ ID ] PAGO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }
                    if (entPago.estatus_anulado=="1")
                    {
                        result.Mensaje = "PAGO YA ANULADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
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


        //GENERAR/DOCADM
        public ResultadoEntidad<string> CtaxCobrar_Generar_Documento_Adm_NotaCredito(DTO.CtaxCobrar.Generar.DocAdm.NtCredito ficha)
        {
            var result = new ResultadoEntidad<string>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();

                        var entCnt = ctx.sistema_contadores.Find(1);
                        entCnt.a_cxc += 1;
                        entCnt.a_cxc_nc += 1;
                        ctx.SaveChanges();

                        var idDoc = entCnt.a_cxc.ToString().Trim().PadLeft(10, '0');
                        var idNcr = entCnt.a_cxc_nc.ToString().Trim().PadLeft(10, '0');
                        var entCxcNC = new cxc()
                        {
                            auto = idDoc,
                            c_cobranza = 0,
                            c_cobranzap = 0,
                            fecha = FechaSistema,
                            tipo_documento = "NCR",
                            documento = idNcr,
                            fecha_vencimiento = FechaSistema,
                            nota = "PAGO SUPERO EL MONTO A LIQUIDAR",
                            importe = ficha.Monto * (-1),
                            acumulado = 0,
                            auto_cliente = ficha.IdCliente,
                            cliente = ficha.NombreCliente,
                            ci_rif = ficha.RifCliente,
                            codigo_cliente = ficha.CodigoCliente,
                            estatus_cancelado = "0",
                            resta = 0,
                            estatus_anulado = "0",
                            auto_documento = idNcr,
                            numero = "",
                            auto_agencia = "0000000001",
                            agencia = "",
                            signo = -1,
                            auto_vendedor = "0000000001",
                            c_departamento = 0,
                            c_ventas = 0,
                            c_ventasp = 0,
                            serie = "",
                            importe_neto = 0,
                            dias = 0,
                            castigop = 0,
                          //  fecha_recepcion = new DateTime(2000, 1, 1),
                        };
                        ctx.cxc.Add(entCxcNC);
                        ctx.SaveChanges();


                        //ACTUALIZO CLIENTE; SALDOS 
                        var entCliente = ctx.clientes.Find(ficha.IdCliente);
                        if (entCliente == null)
                        {
                            result.Mensaje = "ERROR AL PROCESAR PAGO" + Environment.NewLine + "CLIENTE NO ENCONTRADO";
                            result.Result = DTO.EnumResult.isError;
                            result.Entidad = "";
                            return result;
                        }

                        entCliente.saldo -= ficha.Monto ;
                        var d = entCliente.limite_credito - entCliente.saldo;
                        entCliente.disponible = d;
                        ctx.SaveChanges();

                        ts.Complete();
                        result.Entidad = idDoc;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = "";
            }

            return result;
        }

        public ResultadoEntidad<string> CtaxCobrar_Generar_Documento_Adm_NotaDebito(DTO.CtaxCobrar.Generar.DocAdm.NtDebito ficha)
        {
            var result = new ResultadoEntidad<string>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();

                        var entCnt = ctx.sistema_contadores.Find(1);
                        entCnt.a_cxc += 1;
                        entCnt.a_cxc_nd += 1;
                        ctx.SaveChanges();

                        var idDoc = entCnt.a_cxc.ToString().Trim().PadLeft(10, '0');
                        var idNdb = entCnt.a_cxc_nd.ToString().Trim().PadLeft(10, '0');
                        var entCxcNC = new cxc()
                        {
                            auto = idDoc,
                            c_cobranza = 0,
                            c_cobranzap = 0,
                            fecha = FechaSistema,
                            tipo_documento = "NDB",
                            documento = idNdb,
                            fecha_vencimiento = FechaSistema,
                            nota = "PAGO SUPERO EL MONTO A LIQUIDAR",
                            importe = ficha.Monto * (-1),
                            acumulado = 0,
                            auto_cliente = ficha.IdCliente,
                            cliente = ficha.NombreCliente,
                            ci_rif = ficha.RifCliente,
                            codigo_cliente = ficha.CodigoCliente,
                            estatus_cancelado = "0",
                            resta = 0,
                            estatus_anulado = "0",
                            auto_documento = idNdb,
                            numero = "",
                            auto_agencia = "0000000001",
                            agencia = "",
                            signo = -1,
                            auto_vendedor = "0000000001",
                            c_departamento = 0,
                            c_ventas = 0,
                            c_ventasp = 0,
                            serie = "",
                            importe_neto = 0,
                            dias = 0,
                            castigop = 0,
                          //  fecha_recepcion = new DateTime(2000, 1, 1),
                        };
                        ctx.cxc.Add(entCxcNC);
                        ctx.SaveChanges();


                        //ACTUALIZO CLIENTE; SALDOS 
                        var entCliente = ctx.clientes.Find(ficha.IdCliente);
                        if (entCliente == null)
                        {
                            result.Mensaje = "ERROR AL PROCESAR PAGO" + Environment.NewLine + "CLIENTE NO ENCONTRADO";
                            result.Result = DTO.EnumResult.isError;
                            result.Entidad = "";
                            return result;
                        }

                        entCliente.saldo += ficha.Monto;
                        var d = entCliente.limite_credito - entCliente.saldo;
                        entCliente.disponible = d;
                        ctx.SaveChanges();

                        ts.Complete();
                        result.Entidad = idDoc;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = "";
            }

            return result;
        }

    }

}