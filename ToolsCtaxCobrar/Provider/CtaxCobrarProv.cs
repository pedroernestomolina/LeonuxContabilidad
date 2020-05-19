using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoLista<OOB.CtxCobrar.Documentos.Pendiente.Ficha> CtaxCobrar_Documentos_Pendiente_Lista(OOB.CtxCobrar.Documentos.Pendiente.Filtro filtro)
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.CtxCobrar.Documentos.Pendiente.Ficha>();

            try
            {
                var filtroDTO = new DTO.CtaxCobrar.Documentos.Pendientes.Filtro();

                if (filtro.Desde.HasValue)
                {
                    filtroDTO.Desde = filtro.Desde.Value;
                }
                if (filtro.Hasta.HasValue)
                {
                    filtroDTO.Hasta = filtro.Hasta.Value;
                }

                filtroDTO.Cadena = filtro.Cadena;

                if (filtro.Cliente != null)
                {
                    filtroDTO.IdCliente = filtro.Cliente.IdAuto;
                }
                if (filtro.Vendedor != null)
                {
                    filtroDTO.IdVendedor = filtro.Vendedor.IdAuto;
                }
                if (filtro.PorTipoDocumento !=  OOB.CtxCobrar.Enumerados.PorTipoDocumento.SinDefinir)
                {
                    filtroDTO.PorTipoDocumento = (DTO.CtaxCobrar.Enumerados.PorTipoDocumento)filtro.PorTipoDocumento;
                }

               // filtroDTO.PorVencimiento = (DTO.CtaxCobrar.Enumerados.PorVencimiento)filtro.PorVencimiento;

                var resultDTO = _servicio.CtaxCobrar_Documentos_Pendientes(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.CtxCobrar.Documentos.Pendiente.Ficha>();
                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        foreach (var d in resultDTO.Lista)
                        {
                            var r = new OOB.CtxCobrar.Documentos.Pendiente.Ficha()
                            {
                                IdAuto = d.Id,
                                DocumentoNro = d.DocumentoNro,
                                DocumentoSerie = d.DocumentoSerie,
                                DocumentoTipo = (OOB.CtxCobrar.Enumerados.PorTipoDocumento)d.DocumentoTipo,
                                ClienteCiRif = d.ClienteCiRif,
                                ClienteNombre = d.ClienteNombre,
                                FechaEmision = d.FechaEmision,
                                FechaVencimiento = d.FechaVencimiento,
                                Detalle = d.Detalle,
                                Total = d.Importe,
                                Abonado = d.Abonado,
                                Signo=d.Signo,
                            };
                            list.Add(r);
                        }
                    }
                }
                rt.cntRegistro = resultDTO.cntRegistro;
                rt.Lista = list;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }

            return rt;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.CtxCobrar.Documentos.Pendiente.Ficha> CtaxCobrar_Documentos_Pendiente_Get_ById(string auto)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.CtxCobrar.Documentos.Pendiente.Ficha>();

            try
            {
                var resultDTO = _servicio.CtaxCobrar_Documentos_Pendientes_Get_ById(auto);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var r = new OOB.CtxCobrar.Documentos.Pendiente.Ficha()
                {
                    IdAuto = resultDTO.Entidad.IdAuto ,
                    IdAutCliente = resultDTO.Entidad.IdAutCliente ,
                    IdAutoVendedor = resultDTO.Entidad.IdAutoVendedor ,
                    IdAutoDocumentoVenta = resultDTO.Entidad.IdAutoDocumentoVenta ,
                    DocumentoNro = resultDTO.Entidad.DocumentoNro ,
                    DocumentoSerie = resultDTO.Entidad.DocumentoSerie ,
                    DocumentoTipo = (OOB.CtxCobrar.Enumerados.PorTipoDocumento) resultDTO.Entidad.DocumentoTipo ,
                    FechaEmision = resultDTO.Entidad.FechaEmision ,
                    FechaVencimiento = resultDTO.Entidad.FechaVencimiento ,
                    Detalle = resultDTO.Entidad.Detalle ,
                    Total = resultDTO.Entidad.Importe ,
                    Abonado = resultDTO.Entidad.Abonado,
                    Signo= resultDTO.Entidad.Signo,
                    IsAnulado = resultDTO.Entidad.IsAnulado,
                    IsCancelado = resultDTO.Entidad.IsCancelado ,
                    ClienteNombre = resultDTO.Entidad.ClienteNombre ,
                    ClienteCiRif = resultDTO.Entidad.ClienteCiRif ,
                    ClienteCodigo = resultDTO.Entidad.ClienteCodigo ,
                    ComisionCobranzaP = resultDTO.Entidad.ComisionCobranzaP ,
                    ComisionVentaP = resultDTO.Entidad.ComisionVentaP ,
                    ImporteNeto = resultDTO.Entidad.ImporteNeto ,
                    DiasTolerancia = resultDTO.Entidad.DiasTolerancia ,
                    CastigoP = resultDTO.Entidad.CastigoP,
                };
                if (resultDTO.Entidad.FechaRecepcionMercancia.Date <= new DateTime(2000,01,01).Date)
                {
                    r.FechaRecepcionMercancia = null;
                }
                else 
                {
                    r.FechaRecepcionMercancia = resultDTO.Entidad.FechaRecepcionMercancia;
                }
 
                rt.Entidad = r;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }

            return rt;
        }

        public OOB.Resultado.ResultadoLista<OOB.CtxCobrar.Documentos.Pago.Ficha> CtaxCobrar_Documentos_Pago_Lista(OOB.CtxCobrar.Documentos.Pago.Filtro filtro)
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.CtxCobrar.Documentos.Pago.Ficha>();

            try
            {
                var filtroDTO = new DTO.CtaxCobrar.Documentos.Pagos.Filtro();
                filtroDTO.Cadena = filtro.Cadena;
                if (filtro.Cliente != null)
                {
                    filtroDTO.IdCliente = filtro.Cliente.IdAuto;
                }
                if (filtro.Desde.HasValue)
                {
                    filtroDTO.Desde = filtro.Desde.Value;
                }
                if (filtro.Hasta.HasValue)
                {
                    filtroDTO.Hasta = filtro.Hasta.Value;
                }

                var resultDTO = _servicio.CtaxCobrar_Documentos_Pagos(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                var list = new List<OOB.CtxCobrar.Documentos.Pago.Ficha>();
                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        foreach (var d in resultDTO.Lista)
                        {
                            var r = new OOB.CtxCobrar.Documentos.Pago.Ficha()
                            {
                                IdAuto = d.Id,
                                DocumentoNro = d.DocumentoNro,
                                ClienteCiRif = d.ClienteCiRif,
                                ClienteCodigo=d.ClienteCodigo,
                                ClienteNombre = d.ClienteNombre,
                                FechaEmision = d.FechaEmision,
                                Importe = d.Importe,
                                Detalle=d.Notas,
                                IsAnulado=d.IsAnulado,
                            };
                            list.Add(r);
                        }
                    }
                }
                rt.cntRegistro = resultDTO.cntRegistro;
                rt.Lista = list;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }

            return rt;
        }

        public OOB.Resultado.ResultadoEntidad<string> CtaxCobrar_Pago_Procesar(OOB.CtxCobrar.Pago.Ficha pago)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<string>();

            try
            {
                var pagoDTO = new DTO.CtaxCobrar.Pago.Ficha()
                {
                    ClienteId = pago.ClienteId,
                    ClienteCodigo = pago.ClienteCodigo,
                    ClienteRif = pago.ClienteCiRif,
                    ClienteNombre = pago.ClienteRazonSocial,
                    ClienteDireccion = pago.ClienteDirFiscal,
                    ClienteTelefono = pago.ClienteTelefono,

                    VendedorId = pago.Vendedor.IdAuto,
                    VendedorCodigo = pago.Vendedor.Codigo,
                    VendedorNombre = pago.Vendedor.Nombre,
                    VendedorCiRif = pago.Vendedor.CiRif,

                    CobradorId = pago.Cobrador.IdAuto,
                    CobradorCodigo = pago.Cobrador.Codigo,
                    CobradorNombre = pago.Cobrador.Nombre,

                    UsuarioId = pago.Usuario.IdAuto,
                    UsuarioNombre = pago.Usuario.Nombre,

                    FechaRecibo = pago.FechaRecibo,
                    TotalMontoRecibo = pago.MontoRecibo,
                    TotalMontoRecibido = pago.MontoRecibido,
                    TotalMontoAnticipos = pago.MontoAnticipos,
                    TotalMontoDescuentos = pago.MontoDescuentos,
                    TotalMontoRetenciones = pago.MontoRetenciones,
                    Notas = pago.Notas,
                    MontoFavorCliente=pago.MontoFavorCliente,
                    GenerarNotaCreditoMontoFavorCliente=pago.GenerarNotaCreditoMontoFavorCliente,
                };

                var Comisiones = new List<DTO.CtaxCobrar.Pago.Comision>();
                if (pago.Comisiones != null)
                {
                    foreach (var com in pago.Comisiones)
                    {
                        var it = new DTO.CtaxCobrar.Pago.Comision()
                        {
                            IdClaveRelMedioPago = com.ClaveIdRelMedioPago,
                            DocCxc_Id = com.IdDocCxc,
                            DocCxc_Fecha = com.FechaDocCxc,
                            DocCxc_FechaRecepcion = com.FechaRecepcionMercDocCxc,
                            ComisionPorc = com.ComisionPorc,
                            CastigoPorc = com.CastigoPorc,
                            BaseCalculo = com.BaseCalculo,
                            MontoRecibido = com.MontoRecibido,
                            ToleranciaDias = com.ToleranciaDias,
                            TotalComision = com.TotalComision,
                            IsCastigado = com.IsCastigado,
                            DiasTranscurridos = com.DiasTranscurridos,
                        };
                        Comisiones.Add(it);
                    }
                }
                pagoDTO.Comisiones = Comisiones;

                var retenciones = new List<DTO.CtaxCobrar.Pago.RetencionIva>();
                if (pago.Retenciones != null)
                {
                    foreach (var _rt in pago.Retenciones)
                    {
                        var it = new DTO.CtaxCobrar.Pago.RetencionIva()
                        {
                            DocumentoId = _rt.DocumentoId,
                            DocumentoNro = _rt.DocumentoNro,
                            DocumentoFecha = _rt.DocumentoFecha,
                            DocumentoControl = _rt.DocumentoControl,
                            DocumentoTasaIva = _rt.DocumentoTasaIva,
                            DocumentoTipo = (DTO.CtaxCobrar.Pago.Enumerados.TipoDoc)_rt.DocumentoTipo,
                            ComprobanteNro = _rt.ComprobanteNro,
                            DeFecha = _rt.DeFecha,
                            MontoExcento = _rt.MontoExcento,
                            MontoBase = _rt.MontoBase,
                            MontoImpuesto = _rt.MontoImpuesto,
                            MontoTotal = _rt.MontoTotal,
                            TasaRetencion = _rt.TasaRetencion,
                            MontoRetencion = _rt.MontoRetencion,
                        };
                        retenciones.Add(it);
                    }
                }
                pagoDTO.RetencionesIva = retenciones;

                var mediosPago = new List<DTO.CtaxCobrar.Pago.MedioPago>();
                if (pago.MediosPago != null)
                {
                    foreach (var _mp in pago.MediosPago)
                    {
                        var it = new DTO.CtaxCobrar.Pago.MedioPago()
                        {
                            IdClave = _mp.IdClave,
                            autoMedioId = _mp.MedioId,
                            autoBancoId = _mp.BancoId,
                            CodigoMedio = _mp.MedioCodigo,
                            DescripcionMedio = _mp.MedioDescripcion,
                            MontoRecibido = _mp.MontoRecibido,
                            FechaMovimiento = _mp.FechaMovimiento,
                            Referencia = _mp.NroReferencia,
                            BancoCodigo = _mp.BancoCodigo,
                            BancoDescripcion = _mp.BancoDescripcion,
                            BancoNroCta = _mp.BancoNroCta,
                        };
                        mediosPago.Add(it);
                    }
                }
                pagoDTO.MediosPago = mediosPago;

                var doc = new List<DTO.CtaxCobrar.Pago.DocumentoCxC>();
                if (pago.DocLiquidar != null)
                {
                    foreach (var _doc in pago.DocLiquidar)
                    {
                        var it = new DTO.CtaxCobrar.Pago.DocumentoCxC()
                        {
                            autoId = _doc.IdDoc,
                            DocumentoNumero = _doc.NumeroDoc,
                            DocumentoFecha = _doc.FechaDoc,
                            DocumentoTipo = (DTO.CtaxCobrar.Pago.Enumerados.TipoDoc)_doc.TipoDoc,
                            DocumentoTotal = _doc.MontoDoc,
                            fechaRecepcion = _doc.fechaRecepcion,
                            ComisionPorc = _doc.ComisionPorc,
                            CastigoPorc = _doc.CastigoPorc,
                            TipoOeracion = (DTO.CtaxCobrar.Pago.Enumerados.Operacion)_doc.TipoOeracion,
                            MontoAbonado = _doc.MontoAbonado,
                            ToleranciaDias = _doc.ToleranciaDias,
                        };
                        doc.Add(it);
                    }
                }
                pagoDTO.DocumentosCxcPagar = doc;

                var resultDTO = _servicio.CtaxCobrar_Pago_Procesar(pagoDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                rt.Entidad = resultDTO.Entidad;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }

            return rt;
        }

        public OOB.Resultado.Resultado CtaxCobrar_Pago_Anular(OOB.CtxCobrar.Pago.Anular.Ficha ficha)
        {
            var rt = new OOB.Resultado.Resultado();

            try
            {
                var fichaDTO = new DTO.CtaxCobrar.Pago.Anular()
                {
                    IdPago=ficha.IdPago,
                    Notas =ficha.Notas,
                };
                var resultDTO = _servicio.CtaxCobrar_Pago_Anular(fichaDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }

            return rt;
        }

    }

}