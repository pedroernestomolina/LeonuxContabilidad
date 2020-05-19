using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public async Task<OOB.Resultado.ResultadoLista<OOB.Contable.Asiento.Ficha>> Asiento_Lista()
        {
            return await Task.Run<OOB.Resultado.ResultadoLista<OOB.Contable.Asiento.Ficha>>(() =>
            {
                OOB.Resultado.ResultadoLista<OOB.Contable.Asiento.Ficha> rt = new OOB.Resultado.ResultadoLista<OOB.Contable.Asiento.Ficha>();
                try
                {
                    DTO.Contable.Asiento.Busqueda busq = new DTO.Contable.Asiento.Busqueda();
                    var resultDTO = _servicio.Contable_Asiento_Lista(busq);
                    if (resultDTO.Result == DTO.EnumResult.isError)
                    {
                        throw new Exception(resultDTO.Mensaje);
                    }

                    if (resultDTO.Lista != null)
                    {
                        rt.cntRegistro = resultDTO.cntRegistro;
                        rt.Lista = resultDTO.Lista.Select(item =>
                        {
                            var num = "";
                            if (item.EstaProcesado)
                            {
                                num = item.ComprobanteNro.ToString().Trim().PadLeft(10, '0');
                            }
                            else
                            {
                                num = "PV" + item.ComprobanteNro.ToString().Trim().PadLeft(8, '0');
                            }

                            return new OOB.Contable.Asiento.Ficha()
                            {
                                Id = item.Id,
                                Comprobante = num,
                                Detalle = item.Detalle,
                                FechaEmision = item.FechaEmision,
                                TipoAsiento = (OOB.Contable.Asiento.Enumerados.Tipo)item.TipoAsiento,
                                EstaAnulado = item.EstaAnulado,
                                EstaProcesado = item.EstaProcesado,
                                AutoGenerado = item.AutoGenerado,
                                Importe = item.Importe,
                                Periodo= new OOB.Contable.Periodo.Ficha(){ MesActual =item.MesRelacion, AnoActual=item.AnoRelacion },
                                ReglaIntegracion= new OOB.Contable.Integracion.Regla.Ficha(){ Descripcion =item.ReglaDescripcion },
                                TipoDocumento = new OOB.Contable.TipoDocumento.Ficha()
                                {
                                    Descripcion = item.TipoDocumento
                                },
                            };
                        }).ToList();
                    }
                    else
                    {
                        rt.cntRegistro = 0;
                        rt.Lista = new List<OOB.Contable.Asiento.Ficha>();
                    }
                }
                catch (Exception e)
                {
                    rt.Mensaje = e.Message;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                }
                return rt;
            });
        }

        public async Task<OOB.Resultado.ResultadoLista<OOB.Contable.Asiento.Generar.Ficha>> Asiento_Generar(OOB.Contable.Asiento.Generar.Filtro ficha)
        {
            return await Task.Run<OOB.Resultado.ResultadoLista<OOB.Contable.Asiento.Generar.Ficha>>(() =>
            {
                OOB.Resultado.ResultadoLista<OOB.Contable.Asiento.Generar.Ficha> rt = new OOB.Resultado.ResultadoLista<OOB.Contable.Asiento.Generar.Ficha>();
                try
                {
                    var filtDTO = new DTO.Contable.Asiento.Generar.Filtros()
                    {
                        Desde = ficha.Desde,
                        Hasta = ficha.Hasta,
                        Modulo = (DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar)ficha.Modulo,
                    };
                    if (ficha.Venta != null)
                    {
                        var Venta = new DTO.Contable.Asiento.Generar.FiltroVenta();
                        Venta.IdSucursal=ficha.Venta.CodSucursal;
                        if (ficha.Venta.TipoDocumento != null)
                        {
                            Venta.TipoDocumento = ficha.Venta.TipoDocumento;
                        }
                        if (ficha.Venta.CondicionPago != null)
                        {
                            Venta.CondicionPago = ficha.Venta.CondicionPago;
                        }
                        if (ficha.Venta.DenominacionFiscal != null)
                        {
                            Venta.DenominacionFiscal = ficha.Venta.DenominacionFiscal;
                        }
                        if (ficha.Venta.SerialFiscal != null)
                        {
                            Venta.SerialFiscal = ficha.Venta.SerialFiscal.Descripcion;
                        }
                        filtDTO.Venta = Venta;
                    }
                    if (ficha.Compra != null)
                    {
                        var Compra = new DTO.Contable.Asiento.Generar.FiltroCompra();
                        Compra.MesRelacion = ficha.Compra.MesRelacion;
                        Compra.AnoRelacion = ficha.Compra.AnoRelacion;
                        Compra.IdSucursal = ficha.Compra.CodigoSucursal;

                        if (ficha.Compra.TipoDocumento != null)
                        {
                            Compra.TipoDocumento = ficha.Compra.TipoDocumento;
                        }
                        if (ficha.Compra.Proveedor != null)
                        {
                            Compra.IdProveedor = ficha.Compra.Proveedor.Id;
                        }
                        if (ficha.Compra.Concepto  != null)
                        {
                            Compra.IdConcepto = ficha.Compra.Concepto.Id;
                        }
                        filtDTO.Compra = Compra;
                    }
                    if (ficha.CxP != null)
                    {
                        var CxP = new DTO.Contable.Asiento.Generar.FiltroCxP();
                        if (ficha.CxP.TipoDocumento != null)
                        {
                            switch (ficha.CxP.TipoDocumento)
                            {
                                case "PAGO":
                                    CxP.TipoDocumento = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Pago;
                                    break;
                                case "RETENCION IVA":
                                    CxP.TipoDocumento = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIva;
                                    break;
                                case "RETENCION ISLR":
                                    CxP.TipoDocumento = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIslr;
                                    break;
                            }
                        }
                        if (ficha.CxP.Proveedor != null)
                        {
                            CxP.IdProveedor = ficha.CxP.Proveedor.Id;
                        }
                        if (ficha.CxP.Concepto != null)
                        {
                            CxP.IdConcepto = ficha.CxP.Concepto.Id;
                        }
                        filtDTO.CxP = CxP;
                    }
                    if (ficha.Inventario != null)
                    {
                        var Inventario = new DTO.Contable.Asiento.Generar.FiltroInventario ();
                        if (ficha.Inventario.TipoDocumento.HasValue)
                        {
                            Inventario.TipoDocumento = (DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento) ficha.Inventario.TipoDocumento.Value ;
                        }
                        filtDTO.Inventario = Inventario;
                    }
                    if (ficha.Banco != null)
                    {
                        var Banco = new DTO.Contable.Asiento.Generar.FiltroBanco();
                        if (ficha.Banco.TipoMovimiento.HasValue)
                        {
                            Banco.TipoMovimiento= (DTO.Bancos.Enumerados.TipMovimiento) ficha.Banco.TipoMovimiento.Value;
                        }
                        filtDTO.Banco = Banco;
                    }


                    var resultDTO = _servicio.Contable_Asiento_Generar(filtDTO);
                    if (resultDTO.Result == DTO.EnumResult.isError)
                    {
                        throw new Exception(resultDTO.Mensaje);
                    }

                    rt.cntRegistro = resultDTO.cntRegistro;
                    rt.Lista = resultDTO.Lista.Select(item =>
                    {
                        return new OOB.Contable.Asiento.Generar.Ficha()
                        {
                            Id = item.Id,
                            TipoDoc = (OOB.Contable.Asiento.Generar.Enumerados.TipoDocumento)item.TipoDoc,
                            DocumentoRef = item.DocumentoRef,
                            FechaDoc = item.FechaDoc,
                            DescripcionDoc = item.DescripcionDoc,
                            IsOk = item.IsOk,
                            Incluir = true,
                            Signo = item.Signo,
                            Detalles = item.Detalles.Select((d) =>
                            {
                                return new OOB.Contable.Asiento.Generar.FichaDetalle()
                                {
                                    IdCta = d.IdCta,
                                    CodigoCta = d.CodigoCta,
                                    DescripcionCta = d.DescripcionCta,
                                    Naturaleza = (OOB.Contable.PlanCta.Enumerados.Naturaleza) d.Naturaleza,
                                    MontoDebe = d.MontoDebe,
                                    MontoHaber = d.MontoHaber,
                                    Renglon = d.Renglon,
                                    Signo = item.Signo
                                };
                            }).ToList()
                        };
                    }).ToList();
                }
                catch (Exception e)
                {
                    rt.Mensaje = e.Message;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                }
                return rt;
            });

        }

        public OOB.Resultado.ResultadoId Asiento_Insertar_Integracion(OOB.Contable.Asiento.Generar.Insertar ficha)
        {
            var result = new OOB.Resultado.ResultadoId();
            var idAsientoPreview=-1;
            if (ficha.AsientoPreview != null) 
            {
                idAsientoPreview = ficha.AsientoPreview.Id;
            }

            var fichaDTO = new DTO.Contable.Asiento.Generar.Insertar();
            fichaDTO.IdAsientoPreview = idAsientoPreview;
            fichaDTO.Modulo = (DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar)ficha.Modulo;
            fichaDTO.TipoAsiento = (DTO.Contable.Asiento.Enumerados.Tipo)ficha.TipoAsiento;
            fichaDTO.IdTipoDocumento = ficha.TipoDocumento.Id;
            fichaDTO.DescripcionAsiento = ficha.Descripcion;
            fichaDTO.Procesado = ficha.EstaProcesado;
            fichaDTO.PeriodoMes = ficha.Periodo.MesActual;
            fichaDTO.PeriodoAno = ficha.Periodo.AnoActual;
            fichaDTO.Desde = ficha.Desde;
            fichaDTO.Hasta = ficha.Hasta;
            fichaDTO.Importe = ficha.Importe;

            var list = new List<DTO.Contable.Asiento.Generar.InsertarDocumento>();
            foreach (var doc in ficha.Data)
            {
                var ndoc = new DTO.Contable.Asiento.Generar.InsertarDocumento();
                ndoc.IdDocumento = doc.Id;
                ndoc.TipoDocumento = (DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento) doc.TipoDoc; 
                ndoc.DocumentoRef = doc.DocumentoRef;
                ndoc.DescDocRef = doc.DescripcionDoc;
                ndoc.FechaDocRef = doc.FechaDoc;
                ndoc.Signo = doc.Signo;
                ndoc.Incluir = doc.Incluir;
                var ldet = new List<DTO.Contable.Asiento.Generar.InsertarDetalle>();

                foreach (var det in doc.Detalles)
                {

                    var signo = 1;
                    //if (det.Naturaleza == OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora)
                    //{
                    //    if (det.MontoHaber != 0)
                    //    {
                    //        signo = 1;
                    //    }
                    //}
                    //else
                    //{
                    //    signo = -1;
                    //    if (det.MontoDebe != 0)
                    //    {
                    //        signo = 1;
                    //    }
                    //}

                    var ndet = new DTO.Contable.Asiento.Generar.InsertarDetalle()
                    {
                        IdPlanCta = det.IdCta,
                        MontoDebe = det.MontoDebe*signo,
                        MontoHaber = det.MontoHaber*signo,
                        CodigoPlanCta = det.CodigoCta,
                        DescripcionPlanCta = det.DescripcionCta,
                        NaturalezaPlanCta= (DTO.Contable.PlanCta.Enumerados.Naturaleza) det.Naturaleza,
                    };
                    ldet.Add(ndet);
                }
                ndoc.Detalles = ldet;
                list.Add(ndoc);
            }
            fichaDTO.Documentos = list;

            var listCtas = new List<DTO.Contable.Asiento.Generar.InsertarResumen>();
            foreach (var g in ficha.Ctas)
            {
                var signo = 1;
                //if (g.Naturaleza == OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora)
                //{
                //    if (g.MontoHaber != 0)
                //    {
                //        signo = 1;
                //    }
                //}
                //else
                //{
                //    signo = -1;
                //    if (g.MontoDebe != 0)
                //    {
                //        signo = 1;
                //    }
                //}

                listCtas.Add(new DTO.Contable.Asiento.Generar.InsertarResumen()
                {
                    IdCta = g.IdCta,
                    MontoDebe = g.MontoDebe*signo,
                    MontoHaber = g.MontoHaber*signo,
                    CodigoCta = g.CodigoCta,
                    DescripcionCta = g.DescripcionCta
                });
            }
            fichaDTO.Resumen = listCtas;

            var resultDTO = _servicio.Contable_Asiento_Insertar_Integracion(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Id = -1;
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Id = resultDTO.Id;
            return result;
        }

        public OOB.Resultado.Resultado Asiento_Editar_Integracion(OOB.Contable.Asiento.Generar.Editar ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var fichaDTO = new DTO.Contable.Asiento.Generar.Insertar();
            fichaDTO.Modulo = (DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar)ficha.Modulo;
            fichaDTO.TipoAsiento = (DTO.Contable.Asiento.Enumerados.Tipo)ficha.TipoAsiento;
            fichaDTO.IdTipoDocumento = ficha.TipoDocumento.Id;
            fichaDTO.DescripcionAsiento = ficha.Descripcion;
            fichaDTO.Procesado = ficha.EstaProcesado;
            fichaDTO.PeriodoMes = ficha.Periodo.MesActual;
            fichaDTO.PeriodoAno = ficha.Periodo.AnoActual;
            fichaDTO.Desde = ficha.Desde;
            fichaDTO.Hasta = ficha.Hasta;
            fichaDTO.Importe = ficha.Importe;

            var list = new List<DTO.Contable.Asiento.Generar.InsertarDocumento>();
            foreach (var doc in ficha.Data)
            {
                var ndoc = new DTO.Contable.Asiento.Generar.InsertarDocumento();
                ndoc.DocumentoRef = doc.DocumentoRef;
                ndoc.DescDocRef = doc.DescripcionDoc;
                ndoc.FechaDocRef = doc.FechaDoc;
                ndoc.Signo = doc.Signo;
                ndoc.Incluir = doc.Incluir;
                var ldet = new List<DTO.Contable.Asiento.Generar.InsertarDetalle>();

                foreach (var det in doc.Detalles)
                {

                    var signo = 1;
                    if (det.Naturaleza == OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora)
                    {
                        if (det.MontoHaber != 0)
                        {
                            signo = -1;
                        }
                    }
                    else
                    {
                        signo = -1;
                        if (det.MontoDebe != 0)
                        {
                            signo = 1;
                        }
                    }

                    var ndet = new DTO.Contable.Asiento.Generar.InsertarDetalle()
                    {
                        IdPlanCta = det.IdCta,
                        MontoDebe = det.MontoDebe * signo,
                        MontoHaber = det.MontoHaber * signo,
                        CodigoPlanCta = det.CodigoCta,
                        DescripcionPlanCta = det.DescripcionCta,
                        NaturalezaPlanCta = (DTO.Contable.PlanCta.Enumerados.Naturaleza)det.Naturaleza,
                    };
                    ldet.Add(ndet);
                }
                ndoc.Detalles = ldet;
                list.Add(ndoc);
            }
            fichaDTO.Documentos = list;

            var listCtas = new List<DTO.Contable.Asiento.Generar.InsertarResumen>();
            foreach (var g in ficha.Ctas)
            {
                var signo = 1;
                if (g.Naturaleza == OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora)
                {
                    if (g.MontoHaber != 0)
                    {
                        signo = -1;
                    }
                }
                else
                {
                    signo = -1;
                    if (g.MontoDebe != 0)
                    {
                        signo = 1;
                    }
                }

                listCtas.Add(new DTO.Contable.Asiento.Generar.InsertarResumen()
                {
                    IdCta = g.IdCta,
                    MontoDebe = g.MontoDebe * signo,
                    MontoHaber = g.MontoHaber * signo,
                    CodigoCta = g.CodigoCta,
                    DescripcionCta = g.DescripcionCta
                });
            }
            fichaDTO.Resumen = listCtas;

            var resultDTO = _servicio.Contable_Asiento_Insertar_Integracion(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            return result;
        }


        //ASIENTO
        public OOB.Resultado.ResultadoEntidad<OOB.Contable.Asiento.Ficha> Asiento_GetById(int id)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Contable.Asiento.Ficha>();

            var resultDTO = _servicio.Contable_Asiento_GetById(id);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var regla = new OOB.Contable.Integracion.Regla.Ficha();
            if (resultDTO.Entidad.AutoGenerado)
            {
                 regla.Codigo =resultDTO.Entidad.CodigoReglaIntegracion;
                 regla.Descripcion = resultDTO.Entidad.DescripcionReglaIntegracion;
            };

            var comp = "";
            if (resultDTO.Entidad.EstaProcesado) 
            {
                comp = resultDTO.Entidad.ComprobanteNro.ToString().Trim().PadLeft(10, '0');
            } 
            else
            {
                comp = "PV"+resultDTO.Entidad.ComprobanteNro.ToString().Trim().PadLeft(8, '0');
            }

            result.Entidad = new OOB.Contable.Asiento.Ficha()
            {
                Id = resultDTO.Entidad.Id,
                AutoGenerado = resultDTO.Entidad.AutoGenerado,
                Comprobante = comp,
                Detalle = resultDTO.Entidad.Descripcion,
                EstaAnulado = resultDTO.Entidad.EstaAnulado,
                EstaProcesado = resultDTO.Entidad.EstaProcesado,
                FechaEmision = resultDTO.Entidad.FechaEmision,
                Importe = resultDTO.Entidad.Importe,
                TipoAsiento = (OOB.Contable.Asiento.Enumerados.Tipo)resultDTO.Entidad.TipoAsiento,
                Renglones = resultDTO.Entidad.Renglones,
                ReglaIntegracion = regla,
                Periodo = new OOB.Contable.Periodo.Ficha
                {
                    MesActual = resultDTO.Entidad.MesRelacion,
                    AnoActual = resultDTO.Entidad.AnoRelacion
                },
                TipoDocumento = new OOB.Contable.TipoDocumento.Ficha()
                {
                    Id = resultDTO.Entidad.IdTipoDocumento,
                    Descripcion = resultDTO.Entidad.TipoDocumento
                },
                Documentos = resultDTO.Entidad.Documentos.Select(d =>
                {
                    var doc = new OOB.Contable.Asiento.FichaDocumento()
                    {
                        Documento = d.Documento,
                        Fecha = d.Fecha,
                        Descripcion = d.Descripcion,
                        Signo = d.Signo,
                        Cuentas = d.DetalleCta.Select(dt => 
                        {
                            return new OOB.Contable.Asiento.FichaDetalle()
                            {
                                Cuenta = new OOB.Cuenta.Ficha() 
                                { 
                                    IdPlanCta=dt.IdCta, 
                                    CodigoCta=dt.CodigoCta, 
                                    DescripcionCta=dt.DescripcionCta, 
                                    NaturalezaCta= (OOB.Contable.PlanCta.Enumerados.Naturaleza) dt.NaturalezaCta,
                                },
                                MontoDebe= Math.Abs(dt.MontoDebe),
                                MontoHaber= Math.Abs(dt.MontoHaber),
                                Renglon=dt.Renglon
                            };
                        }).ToList()
                    };
                    
                    return doc;
                }).ToList(),
            };
            if (resultDTO.Entidad.Resumen != null && resultDTO.Entidad.Resumen.Count() > 0) 
            {
                var Resumen = resultDTO.Entidad.Resumen.Select(r =>
                {
                    return new OOB.Contable.Asiento.FichaResumen()
                    {
                        Cuenta = new OOB.Cuenta.Ficha()
                        {
                            IdPlanCta = r.IdCta,
                            CodigoCta = r.CodigoCta,
                            DescripcionCta = r.DescripcionCta
                        },
                        MontoDebe = r.MontoDebe,
                        MontoHaber = r.MontoHaber
                    };
                }).ToList();

                result.Entidad.Resumen = Resumen;
            }

            return result;
        }

        public OOB.Resultado.ResultadoId Asiento_Guardar(OOB.Contable.Asiento.Asiento.Guardar ficha)
        {
            var result = new OOB.Resultado.ResultadoId();

            int idAsientoEditado = -1;
            int idAsientoPreview = -1;
            if (ficha.Asiento != null) 
            {
                if (!ficha.Asiento.EstaProcesado)
                {
                    idAsientoPreview = ficha.Asiento.Id;
                }
                else 
                {
                    idAsientoEditado = ficha.Asiento.Id;
                }
            }

            var fichaDTO = new DTO.Contable.Asiento.Insertar()
            {
                IdAsientoPreview=idAsientoPreview,
                IdAsientoEditado=idAsientoEditado,
                IdTipoDocumento = ficha.TipoDocumento.Id,
                DescTipoDocumento = ficha.TipoDocumento.Descripcion,
                TipoAsiento = (DTO.Contable.Asiento.Enumerados.Tipo)ficha.TipoAsiento,
                PeriodoMes = ficha.Periodo.MesActual,
                PeriodoAno = ficha.Periodo.AnoActual,
                Importe = ficha.Importe,
                DocumentoRef = ficha.DocumentoRef,
                FechaDocumentoRef = ficha.Fecha,
                DescripcionDocumentoRef = ficha.Descripcion,
                IsPreview = ficha.IsPreview,
                Ctas = ficha.Detalles.Select((d) =>
                {
                    
                    var signo = 1;
                    //if (d.Cta.Naturaleza == OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora)
                    //{
                    //    if (d.Haber  != 0)
                    //    {
                    //        signo = 1;
                    //    }
                    //}
                    //else
                    //{
                    //    signo = -1;
                    //    if (d.Debe != 0)
                    //    {
                    //        signo = 1;
                    //    }
                    //}

                    return new DTO.Contable.Asiento.InsertarCta()
                    {
                        Id = d.Cta.Id,
                        MontoDebe = d.Debe*signo,
                        MontoHaber = d.Haber*signo,
                        codigo = d.Cta.Codigo,
                        Descripcion = d.Cta.Nombre,
                        Naturaleza=(DTO.Contable.PlanCta.Enumerados.Naturaleza ) d.Cta.Naturaleza,
                    };
                }).ToList()
            };

            var resultDTO = _servicio.Contable_Asiento_Guardar(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Mensaje = resultDTO.Mensaje;
                result.Result = OOB.Resultado.EnumResult.isError;
                return result;
            }

            result.Id = resultDTO.Id;
            return result;
        }

        public OOB.Resultado.Resultado Asiento_Anular(OOB.Contable.Asiento.Ficha ficha)
        {
            var rt = new OOB.Resultado.Resultado();

            var fichaDTO = new DTO.Contable.Asiento.Anular();
            fichaDTO.Id = ficha.Id;
            if (!ficha.EstaProcesado)
            {
                fichaDTO.Tipo = DTO.Contable.Asiento.Enumerados.TipoAsientoAnular.Preview;
            }
            else 
            {
                if (ficha.TipoAsiento == OOB.Contable.Asiento.Enumerados.Tipo.Apertura)
                {
                    fichaDTO.Tipo = DTO.Contable.Asiento.Enumerados.TipoAsientoAnular.Apertura;
                }
                else
                {
                    fichaDTO.Tipo = DTO.Contable.Asiento.Enumerados.TipoAsientoAnular.Asiento;
                }
            }

            var resultDTO = _servicio.Contable_Asiento_Anular(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                rt.Mensaje = resultDTO.Mensaje;
                rt.Result = OOB.Resultado.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado.ResultadoEntidad<bool> Asiento_Apertura_IsOk()
        {
            var result = new OOB.Resultado.ResultadoEntidad<bool>();

            var resultDTO = _servicio.Contable_Asiento_Apertura_IsOk();
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = resultDTO.Entidad;
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<int> Asiento_Apertura_Get_ID()
        {
            var result = new OOB.Resultado.ResultadoEntidad<int>();

            var resultDTO = _servicio.Contable_Asiento_Apertura_Get_ID();
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = resultDTO.Entidad ;
            return result;
        }

        public OOB.Resultado.Resultado Asiento_Apertura_Guardar(OOB.Contable.Asiento.Apertura.Insertar ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var idAsiento = -1;
            if (ficha.Asiento != null)
            {
                idAsiento = ficha.Asiento.Id;
            }

            var fichaDTO = new DTO.Contable.Asiento.Apertura.Insertar()
            {
                Id = idAsiento,
                PeriodoMes = ficha.Periodo.MesActual,
                PeriodoAno = ficha.Periodo.AnoActual,
                Importe = ficha.Importe,
                FechaDocumentoRef = ficha.Fecha,
                DescripcionDocumentoRef = ficha.Descripcion,
                IsPreview  = ficha.IsPreview,
                Ctas = ficha.Detalles.Select((d) =>
                {
                    return new DTO.Contable.Asiento.Apertura.InsertarCta()
                    {
                        Id = d.Cta.Id,
                        codigo = d.Cta.Codigo,
                        Descripcion = d.Cta.Nombre,
                        MontoDebe = d.Debe,
                        MontoHaber = d.Haber,
                        Signo= d.Cta.Naturaleza== OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora ?1:-1,
                    };
                }).ToList()
            };

            var resultDTO = _servicio.Contable_Asiento_Apertura_Guardar(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Mensaje = resultDTO.Mensaje;
                result.Result = OOB.Resultado.EnumResult.isError;
                return result;
            }

            return result;
        }

    }

}