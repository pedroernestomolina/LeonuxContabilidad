using DTO;
using EntityMySQL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProviderMySql
{

    public partial class Provider : IProvider.InfraEstructura
    {

        class PagoRetencion
        {
            public enum enumTipo { Iva = 1, Isrl }
            public string Id { get; set; }
            public string IdProveedor { get; set; }
            public string NombreRazonSocial { get; set; }
            public string Rif { get; set; }
            public string Documento { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Monto { get; set; }
            public enumTipo Tipo { get; set; }
            public List<PagoRetencionDetalle> Detalle { get; set; }

            public string DescripcionDocumento
            {
                get
                {
                    if (Tipo == enumTipo.Iva)
                    {
                        return "RETENCION IVA, " + NombreRazonSocial.Trim() + ", " + Rif.Trim();
                    }
                    else
                    {
                        return "RETENCION ISLR, " + NombreRazonSocial.Trim() + ", " + Rif.Trim();
                    }
                }
            }
        };

        class PagoRetencionDetalle
        {
            public string AutoConcepto { get; set; }
            public int IdPlanCtaPago { get; set; }
            public string CodigoSucursal { get; set; }
            public decimal MontoRetencion { get; set; }
        }

        class DocRet
        {
            public enum enumTipo { Iva = 1, Isrl }
            public string Id { get; set; }
            public string IdProveedor { get; set; }
            public string NombreRazonSocial { get; set; }
            public string Rif { get; set; }
            public string Documento { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Monto { get; set; }
            public enumTipo Tipo { get; set; }
            public string AutoConcepto { get; set; }
            public int IdPlanCtaPago { get; set; }
            public int CodigoSucursal { get; set; }

            public string DescripcionDocumento
            {
                get
                {
                    if (Tipo == enumTipo.Iva)
                    {
                        return "RETENCION IVA, " + NombreRazonSocial.Trim() + ", " + Rif.Trim();
                    }
                    else
                    {
                        return "RETENCION ISLR, " + NombreRazonSocial.Trim() + ", " + Rif.Trim();
                    }
                }
            }

        }

        class PagoFactura
        {
            public string Id { get; set; }
            public string IdProveedor { get; set; }
            public int IdPlanCtaBanco { get; set; }
            public string NombreRazonSocial { get; set; }
            public string Rif { get; set; }
            public string Documento { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Monto { get; set; }
            public string Nota { get; set; }
            public List<PagoFacturaDetalle> Detalle { get; set; }

            public string DescripcionDocumento
            {
                get
                {
                    return "PAGO, " + NombreRazonSocial.Trim() + ", " + Rif.Trim() + ", " + Nota.Trim();
                }
            }
        };

        class PagoFacturaDetalle
        {
            public string IdConcepto { get; set; }
            public int IdPlanCtaPago { get; set; }
            public decimal Monto { get; set; }
            public decimal MontoNC { get; set; }
        }

        class MovInventario
        {
            public string Id { get; set; }
            public string Concepto { get; set; }
            public string Documento { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Monto { get; set; }
            public string Nota { get; set; }
            public int Signo { get; set; }
            public string AutoDeposito { get; set; }
            public string CodigoSucursal { get; set; }
            public List<MovInventarioDetalle> Detalle { get; set; }

            public string DescripcionDocumento
            {
                get
                {
                    return Concepto.Trim() + ", " + Nota.Trim();
                }
            }
        };

        class MovInventarioDetalle
        {
            public string IdDepartamento { get; set; }
            public decimal Monto { get; set; }
        }

        class MovBanco
        {
            public string Id { get; set; }
            public string IdBanco { get; set; }
            public string Documento { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Monto { get; set; }
            public string Nota { get; set; }
            public int Signo { get; set; }
            public string TipoDocumento { get; set; }
            public string Concepto { get; set; }
            public int IdPlanCta { get; set; }
            public int IdPlanCtaConcepto { get; set; }

            public string DescripcionDocumento
            {
                get
                {
                    return TipoDocumento.Trim() + ", " + Concepto.Trim() + ", " + Nota.Trim();
                }
            }
        };

        class MovCompra
        {
            public string tipo { get; set; }
            public string documento { get; set; }
            public string ci_rif { get; set; }
            public string razon_social { get; set; }
            public decimal subtotal_impuesto { get; set; }
            public decimal subtotal_neto { get; set; }
            public decimal total { get; set; }
            public string auto { get; set; }
            public DateTime fecha { get; set; }
            public int signo { get; set; }
            public string autoProv { get; set; }
            public string autoConcepto { get; set; }
            public int ctaGasto { get; set; }
            public int ctaPago { get; set; }
            public string CodigoSucursal { get; set; }
            public List<MovCompraDetalle> depart { get; set; }
        }

        class MovCompraDetalle
        {
            public string auto_departamento { get; set; }
            public decimal costo { get; set; }
        }

        class MovVenta
        {
            public string tipo { get; set; }
            public string documento { get; set; }
            public string condicion { get; set; }
            public string ci_rif { get; set; }
            public string razon_social { get; set; }
            public decimal subtotal_impuesto { get; set; }
            public decimal subtotal_neto { get; set; }
            public decimal total { get; set; }
            public string auto { get; set; }
            public DateTime fecha { get; set; }
            public int signo { get; set; }
            public string CodigoSucursal { get; set; }
            public MovVentaRec Recibo { get; set; }
            public List<MovVentaDep> depart { get; set; }


            public string TipoDoc
            {
                get
                {
                    var tipoDoc = "";
                    if (tipo == "01") { tipoDoc = "VENT. "; }
                    if (tipo == "02") { tipoDoc = "NDB. "; }
                    if (tipo == "03") { tipoDoc = "NCR. "; }
                    return tipoDoc;
                }
            }

            public string Desc
            {
                get
                {
                    var desc = TipoDoc + documento + ", CI:" + ci_rif.Trim() + ", " + razon_social.Trim();
                    return desc;
                }
            }

        }

        class MovVentaDep
        {
            public string auto_Departamento { get; set; }
            public decimal costo { get; set; }
            public decimal venta { get; set; }
        }

        class MovVentaRec
        {
            public decimal monto_recibido { get; set; }
            public decimal cambio { get; set; }
        }


        public ResultadoId Contable_Asiento_InsertarPreview_Integracion(DTO.Contable.Asiento.Generar.Insertar ficha)
        {
            ResultadoId result = new ResultadoId();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    using (var ts = ctx.Database.BeginTransaction())
                    {

                        try
                        {
                            var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();
                            var cont = ctx.contabilidad_contadores.Find(1);
                            var tipoDoc = ctx.contabilidad_tipo_documento.Find(ficha.IdTipoDocumento);
                            contabilidad_reglas_integracion entRegla = null;

                            switch (ficha.Modulo)
                            {
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Ventas:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(1);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Compras:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(2);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.PorPagar:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(3);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.PorCobrar:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(4);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Inventario:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(5);
                                    break;
                            }

                            int cnt = 0;
                            cont.cnt_aisento_preview += 1;
                            cnt = cont.cnt_aisento_preview;
                            ctx.SaveChanges();

                            var ent = new contabilidad_asiento()
                            {
                                fechaEmision = FechaSistema.Date,
                                mesRelacion = ficha.PeriodoMes,
                                anoRelacion = ficha.PeriodoAno,
                                descripcion = ficha.DescripcionAsiento,
                                tipoAsiento = (int)ficha.TipoAsiento,
                                autoGenerado = "S",
                                estaAnulado = "N",
                                estaProcesado = "N",
                                numeroComprobante = cnt,
                                renglones = ficha.Documentos.Count(),
                                tipoDocumento = tipoDoc.descripcion,
                                idTipoDocumento = ficha.IdTipoDocumento,
                                reglaIntegracionCod = entRegla.codigo,
                                reglaIntegracionDesc = entRegla.descripcion,
                                importe = ficha.Importe
                            };
                            ctx.contabilidad_asiento.Add(ent);
                            ctx.SaveChanges();

                            var entIntegracion = new contabilidad_integraciones()
                            {
                                fecha = FechaSistema.Date,
                                desde = ficha.Desde,
                                hasta = ficha.Hasta,
                                descripcion = ficha.DescripcionAsiento,
                                estaAnulado = "N",
                                idAsiento = ent.id,
                                idReglaIntegracion = entRegla.id
                            };
                            ctx.contabilidad_integraciones.Add(entIntegracion);
                            ctx.SaveChanges();

                            ctx.Configuration.AutoDetectChangesEnabled = false;
                            foreach (var it in ficha.Documentos)
                            {
                                var reng = 0;
                                var entDoc = new contabilidad_asiento_documento()
                                {
                                    idAsiento = ent.id,
                                    documento = it.DocumentoRef,
                                    fecha = it.FechaDocRef,
                                    descripcion = it.DescDocRef,
                                    signo = it.Signo,
                                    incluir = (it.Incluir == true ? "S" : "N"),
                                };
                                ctx.contabilidad_asiento_documento.Add(entDoc);
                                ctx.SaveChanges();

                                foreach (var itd in it.Detalles)
                                {
                                    reng += 1;
                                    var entDet = new contabilidad_asiento_detalle()
                                    {
                                        idAsiento = ent.id,
                                        idAsientoDocumento = entDoc.id,
                                        idPlanCta = itd.IdPlanCta,
                                        numRenglon = reng,
                                        codigoCta = itd.CodigoPlanCta,
                                        descripcionCta = itd.DescripcionPlanCta,
                                        naturalezaCta = (itd.NaturalezaPlanCta == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora ? "D" : "A"),
                                        montoDebe = itd.MontoDebe,
                                        montoHaber = itd.MontoHaber,
                                    };
                                    ctx.contabilidad_asiento_detalle.Add(entDet);
                                    ctx.SaveChanges();
                                }

                            }

                            ts.Commit();
                            result.Id = ent.id;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            ctx.Configuration.AutoDetectChangesEnabled = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Id = -1;
            }

            return result;
        }

        public ResultadoId Contable_Asiento_Insertar_Integracion(DTO.Contable.Asiento.Generar.Insertar ficha)
        {
            ResultadoId result = new ResultadoId();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    using (var ts = ctx.Database.BeginTransaction())
                    {

                        try
                        {
                            var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();
                            var cont = ctx.contabilidad_contadores.Find(1);
                            var tipoDoc = ctx.contabilidad_tipo_documento.Find(ficha.IdTipoDocumento);
                            contabilidad_reglas_integracion entRegla = null;

                            switch (ficha.Modulo)
                            {
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Ventas:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(1);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Compras:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(2);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.PorPagar:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(3);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.PorCobrar:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(4);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Inventario:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(5);
                                    break;
                                case DTO.Contable.Asiento.Generar.Enumerados.ModuloGenerar.Bancos:
                                    entRegla = ctx.contabilidad_reglas_integracion.Find(6);
                                    break;
                            }

                            int cnt = 0;
                            if (ficha.Procesado)
                            {
                                cont.cnt_aisento += 1;
                                cnt = cont.cnt_aisento;
                            }
                            else
                            {
                                cont.cnt_aisento_preview += 1;
                                cnt = cont.cnt_aisento_preview;
                            }
                            ctx.SaveChanges();

                            var ent = new contabilidad_asiento()
                            {
                                fechaEmision = FechaSistema.Date,
                                mesRelacion = ficha.PeriodoMes,
                                anoRelacion = ficha.PeriodoAno,
                                descripcion = ficha.DescripcionAsiento,
                                tipoAsiento = (int)ficha.TipoAsiento,
                                autoGenerado = "S",
                                estaAnulado = "N",
                                estaProcesado = ficha.Procesado == true ? "S" : "N",
                                numeroComprobante = cnt,
                                renglones = ficha.Documentos.Count(),
                                tipoDocumento = tipoDoc.descripcion,
                                idTipoDocumento = ficha.IdTipoDocumento,
                                reglaIntegracionCod = entRegla.codigo,
                                reglaIntegracionDesc = entRegla.descripcion,
                                importe = ficha.Importe
                            };
                            ctx.contabilidad_asiento.Add(ent);
                            ctx.SaveChanges();

                            var entIntegracion = new contabilidad_integraciones()
                            {
                                fecha = FechaSistema.Date,
                                desde = ficha.Desde,
                                hasta = ficha.Hasta,
                                descripcion = ficha.DescripcionAsiento,
                                estaAnulado = "N",
                                idAsiento = ent.id,
                                idReglaIntegracion = entRegla.id
                            };
                            ctx.contabilidad_integraciones.Add(entIntegracion);
                            ctx.SaveChanges();

                            if (ficha.Procesado)
                            {
                                foreach (var it in ficha.Documentos)
                                {
                                    if (it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Venta)
                                    {
                                        var entVenta = ctx.ventas.Find(it.IdDocumento);
                                        entVenta.estatus_cierre_contable = "1";
                                        ctx.SaveChanges();
                                    }

                                    if (it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Compra)
                                    {
                                        var entCompra = ctx.compras.Find(it.IdDocumento);
                                        entCompra.estatus_cierre_contable = "1";
                                        ctx.SaveChanges();
                                    }

                                    if (it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.MovBanco)
                                    {
                                        var entMovBanco = ctx.bancos_movimientos.Find(it.IdDocumento);
                                        entMovBanco.estatus_cierre_contable = "1";
                                        ctx.SaveChanges();
                                    }

                                    if (it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjuste ||
                                        it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorCargo ||
                                        it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorDescargo ||
                                        it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAutoConsumo ||
                                        it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvCargo)
                                    {
                                        var entMovInv = ctx.productos_movimientos.Find(it.IdDocumento);
                                        entMovInv.estatus_cierre_contable = "1";
                                        ctx.SaveChanges();
                                    }

                                    if (it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Pago)
                                    {
                                        var entRecPago = ctx.cxp_recibos.Find(it.IdDocumento);
                                        var autoPago = entRecPago.auto_cxp;
                                        var entPago = ctx.cxp.Find(autoPago);
                                        entPago.estatus_cierre_contable = "1";
                                        ctx.SaveChanges();
                                    }

                                    if (it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIva ||
                                        it.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIslr)
                                    {
                                        var entRetencion = ctx.compras_retenciones.Find(it.IdDocumento);
                                        entRetencion.estatus_cierre_contable = "1";
                                        ctx.SaveChanges();
                                    }
                                }

                                foreach (var it in ficha.Resumen)
                                {
                                    var entAsientoResumen = new contabilidad_asiento_resumen()
                                    {
                                        idAsiento = ent.id,
                                        idPlanCta = it.IdCta,
                                        codigoCta = it.CodigoCta,
                                        descripcionCta = it.DescripcionCta,
                                        montoDebe = it.MontoDebe,
                                        montoHaber = it.MontoHaber
                                    };
                                    ctx.contabilidad_asiento_resumen.Add(entAsientoResumen);
                                    ctx.SaveChanges();

                                    var planCta = ctx.contabilidad_plancta.Find(it.IdCta);
                                    planCta.debe += it.MontoDebe;
                                    planCta.haber += it.MontoHaber;
                                    ctx.SaveChanges();

                                    var nivel = planCta.nivel;
                                    if (nivel >= 1)
                                    {
                                        var entNiv = planCta;
                                        for (var nv = nivel; nv > 1; nv--)
                                        {
                                            entNiv = entNiv.contabilidad_plancta2;
                                            entNiv.debe += it.MontoDebe;
                                            entNiv.haber += it.MontoHaber;
                                            ctx.SaveChanges();
                                        }
                                    }
                                }
                            }

                            ctx.Configuration.AutoDetectChangesEnabled = false;
                            foreach (var it in ficha.Documentos)
                            {
                                var entDocAdm = new contabilidad_asiento_docadm()
                                {
                                    idAsiento = ent.id,
                                    autoDoc = it.IdDocumento,
                                    tipoDoc = (int)it.TipoDocumento,
                                };
                                ctx.contabilidad_asiento_docadm.Add(entDocAdm);
                                ctx.SaveChanges();

                                var descRef = it.DescDocRef.Trim();
                                if (descRef.Length > 120)
                                {
                                    descRef = descRef.Substring(0, 120);
                                }

                                var reng = 0;
                                var entDoc = new contabilidad_asiento_documento()
                                {
                                    idAsiento = ent.id,
                                    documento = it.DocumentoRef,
                                    fecha = it.FechaDocRef,
                                    descripcion = descRef,
                                    signo = it.Signo,
                                    incluir = (it.Incluir == true ? "S" : "N"),
                                };
                                ctx.contabilidad_asiento_documento.Add(entDoc);
                                ctx.SaveChanges();

                                foreach (var itd in it.Detalles)
                                {
                                    reng += 1;
                                    var entDet = new contabilidad_asiento_detalle()
                                    {
                                        idAsiento = ent.id,
                                        idAsientoDocumento = entDoc.id,
                                        idPlanCta = itd.IdPlanCta,
                                        numRenglon = reng,
                                        codigoCta = itd.CodigoPlanCta,
                                        descripcionCta = itd.DescripcionPlanCta,
                                        naturalezaCta = (itd.NaturalezaPlanCta == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora ? "D" : "A"),
                                        montoDebe = itd.MontoDebe,
                                        montoHaber = itd.MontoHaber,
                                    };
                                    ctx.contabilidad_asiento_detalle.Add(entDet);
                                    ctx.SaveChanges();
                                }

                            }

                            ts.Commit();
                            result.Id = ent.id;
                        }
                        catch (DbEntityValidationException e)
                        {
                            var ms = "";
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                //Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                //    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    ms += ve.ErrorMessage + Environment.NewLine;
                                    //Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    //    ve.PropertyName, ve.ErrorMessage);
                                }
                            }
                            throw new Exception(ms);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            ctx.Configuration.AutoDetectChangesEnabled = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Id = -1;
            }

            return result;
        }

        public Resultado Contable_Asiento_EditarPreview_Integracion(DTO.Contable.Asiento.Generar.Editar ficha)
        {
            ResultadoId result = new ResultadoId();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    using (var ts = ctx.Database.BeginTransaction())
                    {

                        try
                        {

                            var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();
                            var ent = ctx.contabilidad_asiento.Find(ficha.IdAsiento);
                            if (ent == null)
                            {
                                result.Mensaje = "[ ID ] ASIENTO NO ENCONTRADO";
                                result.Result = DTO.EnumResult.isError;
                            }

                            var entDet = ctx.contabilidad_asiento_detalle.Where(d => d.idAsiento == ficha.IdAsiento).ToList();
                            var entDoc = ctx.contabilidad_asiento_documento.Where(d => d.idAsiento == ficha.IdAsiento).ToList();
                            foreach (var det in entDet)
                            {
                                ctx.contabilidad_asiento_detalle.Remove(det);
                                ctx.SaveChanges();
                            }
                            foreach (var doc in entDoc)
                            {
                                ctx.contabilidad_asiento_documento.Remove(doc);
                                ctx.SaveChanges();
                            }

                            ent.fechaEmision = FechaSistema.Date;
                            ent.descripcion = ficha.DescripcionAsiento;
                            ent.renglones = ficha.Documentos.Count();
                            ent.tipoDocumento = ficha.TipoDocumento;
                            ent.idTipoDocumento = ficha.IdTipoDocumento;
                            ent.importe = ficha.Importe;
                            ctx.SaveChanges();

                            ctx.Configuration.AutoDetectChangesEnabled = false;
                            foreach (var it in ficha.Documentos)
                            {
                                var reng = 0;
                                var entDc = new contabilidad_asiento_documento()
                                {
                                    idAsiento = ent.id,
                                    documento = it.DocumentoRef,
                                    fecha = it.FechaDocRef,
                                    descripcion = it.DescDocRef,
                                    signo = it.Signo,
                                    incluir = (it.Incluir == true ? "S" : "N"),
                                };
                                ctx.contabilidad_asiento_documento.Add(entDc);
                                ctx.SaveChanges();

                                foreach (var itd in it.Detalles)
                                {
                                    reng += 1;
                                    var entDt = new contabilidad_asiento_detalle()
                                    {
                                        idAsiento = ent.id,
                                        idAsientoDocumento = entDc.id,
                                        idPlanCta = itd.IdPlanCta,
                                        numRenglon = reng,
                                        codigoCta = itd.CodigoPlanCta,
                                        descripcionCta = itd.DescripcionPlanCta,
                                        naturalezaCta = (itd.NaturalezaPlanCta == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora ? "D" : "A"),
                                        montoDebe = itd.MontoDebe,
                                        montoHaber = itd.MontoHaber,
                                    };
                                    ctx.contabilidad_asiento_detalle.Add(entDt);
                                    ctx.SaveChanges();
                                }

                            }

                            ts.Commit();
                            result.Id = ent.id;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            ctx.Configuration.AutoDetectChangesEnabled = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Id = -1;
            }

            return result;
        }

        public ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Compra_Generar(DTO.Contable.Asiento.Generar.Filtros ficha)
        {
            var result = new ResultadoLista<DTO.Contable.Asiento.Generar.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    var idRegla = 2;
                    var r = ctx.contabilidad_reglas_integracion.Find(idRegla);
                    var rd = ctx.contabilidad_reglas_integracion_detalle.
                        Where(d => d.idReglaIntegracion == idRegla).
                        ToList();

                    var qx = ctx.compras.ToList();
                    if (ficha.Compra.MesRelacion == -1 || ficha.Compra.AnoRelacion == -1)
                    {
                        qx = qx.Where(d =>
                            d.fecha >= ficha.Desde &&
                            d.fecha <= ficha.Hasta &&
                            d.estatus_anulado == "0" &&
                            (d.tipo == "01" || d.tipo == "02" || d.tipo == "03")
                            ).
                            ToList();
                    }
                    else
                    {
                        var mes = ficha.Compra.MesRelacion.ToString().Trim().PadLeft(2, '0');
                        var ano = ficha.Compra.AnoRelacion.ToString().Trim().PadLeft(4, '0');
                        qx = qx.Where(d =>
                            d.mes_relacion == mes &&
                            d.ano_relacion == ano &&
                            d.estatus_anulado == "0" &&
                            (d.tipo == "01" || d.tipo == "02" || d.tipo == "03")
                            ).
                            ToList();
                    }

                    if (ficha.Compra.IdSucursal != "")
                    {
                        var suc = ficha.Compra.IdSucursal;
                        qx = qx.Where(d => d.codigo_sucursal == suc).ToList();
                    }

                    var q = qx.Select(d =>
                        new MovCompra
                        {
                            tipo = d.tipo,
                            documento = d.documento,
                            ci_rif = d.ci_rif,
                            razon_social = d.razon_social,
                            subtotal_impuesto = d.impuesto,
                            subtotal_neto = d.neto,
                            total = d.total,
                            auto = d.auto,
                            fecha = d.fecha,
                            signo = d.signo,
                            autoProv = d.auto_proveedor,
                            autoConcepto = d.auto_concepto,
                            ctaGasto = -1,
                            ctaPago = -1,
                            CodigoSucursal = d.codigo_sucursal,
                            depart = ctx.compras_detalle.Where(det => det.auto_documento == d.auto).
                            Select(det =>
                                new MovCompraDetalle
                                {
                                    auto_departamento = det.auto_departamento,
                                    // costo = det.total_neto
                                    costo = Math.Round(det.costo_und * det.cantidad_und, 2),
                                })
                                .ToList()
                        }).ToList();

                    if (ficha.Compra != null)
                    {
                        if (ficha.Compra.TipoDocumento != null)
                        {
                            var td = "";
                            if (ficha.Compra.TipoDocumento == "FACTURA")
                                td = "01";
                            else if (ficha.Compra.TipoDocumento == "NOTA CREDITO")
                                td = "03";
                            else
                                td = "02";
                            q = q.Where(d => d.tipo == td).ToList();
                        }

                        if (ficha.Compra.IdProveedor != null)
                        {
                            var idProv = ficha.Compra.IdProveedor;
                            q = q.Where(d => d.autoProv == idProv).ToList();
                        }

                        if (ficha.Compra.IdConcepto != null)
                        {
                            var idConcepto = ficha.Compra.IdConcepto;
                            q = q.Where(d => d.autoConcepto == idConcepto).ToList();
                        }
                    }

                    var list = new List<DTO.Contable.Asiento.Generar.Ficha>();
                    decimal tdebe;
                    decimal thaber;
                    foreach (var doc in q)
                    {
                        tdebe = 0.0m;
                        thaber = 0.0m;
                        int numr = 0;

                        var tipoDoc = "";
                        if (doc.tipo == "01") { tipoDoc = "FACT. "; }
                        if (doc.tipo == "02") { tipoDoc = "NDB. "; }
                        if (doc.tipo == "03") { tipoDoc = "NCR. "; }
                        var desc = tipoDoc + doc.documento + ", CI:" + doc.ci_rif.Trim() + ", " + doc.razon_social.Trim();
                        var iva = doc.subtotal_impuesto;
                        var subtotalNetO = doc.subtotal_neto;
                        var montoPorPagar = 0.0m;
                        if (doc.tipo != "03")
                        {
                            montoPorPagar = doc.total;
                        }
                        else
                        {
                            montoPorPagar = doc.total;
                        }


                        var CtaGasto = -1;
                        var CtaPago = -1;
                        if (doc.autoConcepto != "")
                        {
                            contabilidad_banco_conceptos ent = null;
                            var autoConcepto = doc.autoConcepto;

                            var ents = ctx.contabilidad_banco_conceptos.Where(d => d.autoMovimientoConcepto == autoConcepto).ToList();
                            if (ents.Count > 1)
                            {
                                ent = ents.FirstOrDefault(s => s.idSucursal == doc.CodigoSucursal);
                            }
                            else
                            {
                                ent = ents.FirstOrDefault();
                            }

                            //var ent = ctx.contabilidad_banco_conceptos.FirstOrDefault(d => d.autoMovimientoConcepto == autoConcepto);
                            if (ent != null)
                            {
                                if (ent.idCtaGasto != -1)
                                    CtaGasto = ent.idCtaGasto;
                                if (ent.idCtaPasivo != -1)
                                    CtaPago = ent.idCtaPasivo;
                            }
                        }


                        var depart = doc.depart.GroupBy(d => new { key = d.auto_departamento }).
                            Select(g => new { autoDepartamento = g.Key.key, costo = g.Sum(t => t.costo) }).ToList();

                        DTO.Contable.Asiento.Generar.Ficha encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                        encabezado.Id = doc.auto;
                        encabezado.DocumentoRef = doc.documento;
                        encabezado.FechaDoc = doc.fecha;
                        encabezado.DescripcionDoc = desc;
                        encabezado.Signo = 1;
                        encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Compra;

                        List<DTO.Contable.Asiento.Generar.FichaDetalle> detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                        foreach (var cta in rd)
                        {
                            decimal monto = 0.0m;
                            switch (cta.referencia.Trim().ToUpper())
                            {
                                case "COSTO DEPART":
                                    //compra de mercancia
                                    if (doc.autoConcepto == "0000000001")
                                    {
                                        contabilidad_departamentos dep = null;
                                        if (doc.CodigoSucursal.Trim() == "01")
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta);
                                        }
                                        if (doc.CodigoSucursal.Trim() == "02")
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta);
                                        }
                                        if (doc.CodigoSucursal.Trim() == "03")
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta);
                                        }
                                        if (doc.CodigoSucursal.Trim() == "04")
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta);
                                        }
                                        if (doc.CodigoSucursal.Trim() == "05")
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta);
                                        }

                                        if (dep != null)
                                        {
                                            var dp = depart.FirstOrDefault(d => d.autoDepartamento == dep.auto_departamento);
                                            if (dp != null)
                                            {
                                                monto = dp.costo;
                                            }
                                        }
                                    }
                                    break;

                                case "GASTO":
                                    if (CtaGasto == cta.idPlanCta)
                                    {
                                        monto = doc.subtotal_neto;
                                    }
                                    break;

                                case "IVA COMPRA":
                                    var idSucursal = 0;
                                    switch (doc.CodigoSucursal.Trim())
                                    {
                                        case "01":
                                            idSucursal = 1;
                                            break;
                                        case "02":
                                            idSucursal = 2;
                                            break;
                                        case "03":
                                            idSucursal = 3;
                                            break;
                                        case "04":
                                            idSucursal = 4;
                                            break;
                                        case "05":
                                            idSucursal = 5;
                                            break;
                                    }
                                    if (cta.idSucursal == idSucursal)
                                    {
                                        monto = iva;
                                    }
                                    break;
                                case "MONTO POR PAGAR":
                                    if (CtaPago == cta.idPlanCta)
                                    {
                                        monto = montoPorPagar;
                                    }
                                    break;
                            }

                            if (monto > 0)
                            {
                                decimal mdebe = 0.0m;
                                decimal mhaber = 0.0m;

                                if (doc.signo == 1)
                                {
                                    if (cta.signo == 1)
                                    {
                                        mdebe = monto;
                                    }
                                    else
                                    {
                                        mhaber = monto;
                                    }
                                }
                                else
                                {
                                    if (cta.signo == 1)
                                    {
                                        mhaber = monto;
                                    }
                                    else
                                    {
                                        mdebe = monto;
                                    }
                                }


                                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                if (cta.contabilidad_plancta.naturaleza == "A")
                                {
                                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                }

                                numr += 1;
                                var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                detalle.IdCta = cta.idPlanCta;
                                detalle.Renglon = numr;
                                detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                detalle.Naturaleza = nat;
                                detalle.MontoDebe = mdebe;
                                detalle.MontoHaber = mhaber;
                                detalles.Add(detalle);

                                tdebe += mdebe;
                                thaber += mhaber;
                            }
                        }

                        encabezado.Detalles = detalles;
                        encabezado.IsOk = true;
                        if (tdebe != thaber)
                        {
                            encabezado.IsOk = false;
                        }
                        list.Add(encabezado);
                    }

                    result.Lista = list;
                    result.cntRegistro = list.Count();
                }

            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Venta_Generar(DTO.Contable.Asiento.Generar.Filtros ficha)
        {
            var result = new ResultadoLista<DTO.Contable.Asiento.Generar.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    List<MovVenta> listDoc = new List<MovVenta>();

                    var r = ctx.contabilidad_reglas_integracion.Find(1);
                    var rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == 1).
                        OrderBy(o => o.referencia).
                        ToList();

                    var vt = ctx.ventas.Where(d => d.fecha >= ficha.Desde
                        && d.fecha <= ficha.Hasta
                        && d.estatus_anulado == "0"
                        && (d.tipo == "01" || d.tipo == "02" || d.tipo == "03"))
                        .ToList();

                    var vtd = ctx.ventas_detalle.Where(d => d.ventas1.fecha >= ficha.Desde
                        && d.ventas1.fecha <= ficha.Hasta
                        && d.ventas1.estatus_anulado == "0"
                        && (d.ventas1.tipo == "01" || d.ventas1.tipo == "02" || d.ventas1.tipo == "03"))
                        .ToList();

                    if (ficha.Venta != null)
                    {
                        if (ficha.Venta.IdSucursal != "")
                        {
                            var sucursal = ficha.Venta.IdSucursal;
                            vt = vt.Where(d => d.codigo_sucursal == sucursal).ToList();
                            vtd = vtd.Where(d => d.ventas1.codigo_sucursal == sucursal).ToList();
                        }
                        if (ficha.Venta.TipoDocumento != null)
                        {
                            var td = "";
                            switch (ficha.Venta.TipoDocumento)
                            {
                                case "FACTURA":
                                    td = "01";
                                    break;
                                case "NOTA DEBITO":
                                    td = "02";
                                    break;
                                case "NOTA CREDITO":
                                    td = "03";
                                    break;
                            }
                            vt = vt.Where(d => d.tipo == td).ToList();
                            vtd = vtd.Where(d => d.ventas1.tipo == td).ToList();
                        }
                        if (ficha.Venta.CondicionPago != null)
                        {
                            vt = vt.Where(d => d.condicion_pago.Trim().ToUpper() == ficha.Venta.CondicionPago).ToList();
                            vtd = vtd.Where(d => d.ventas1.condicion_pago.Trim().ToUpper() == ficha.Venta.CondicionPago).ToList();
                        }
                        if (ficha.Venta.SerialFiscal != null)
                        {
                            vt = vt.Where(d => d.control.Trim().ToUpper() == ficha.Venta.SerialFiscal).ToList();
                            vtd = vtd.Where(d => d.ventas1.control.Trim().ToUpper() == ficha.Venta.SerialFiscal).ToList();
                        }
                        if (ficha.Venta.DenominacionFiscal != null)
                        {
                            vt = vt.Where(d => d.denominacion_fiscal.Trim().ToUpper() == ficha.Venta.DenominacionFiscal).ToList();
                            vtd = vtd.Where(d => d.ventas1.denominacion_fiscal.Trim().ToUpper() == ficha.Venta.DenominacionFiscal).ToList();
                        }
                    }

                    foreach (var d in vt)
                    {
                        var recibo = ctx.cxc_recibos.FirstOrDefault(rc => rc.auto == d.auto_recibo);
                        var rg = new MovVenta()
                        {
                            auto = d.auto,
                            CodigoSucursal = d.codigo_sucursal,
                            tipo = d.tipo,
                            documento = d.documento,
                            condicion = d.condicion_pago,
                            ci_rif = d.ci_rif,
                            razon_social = d.razon_social,
                            subtotal_impuesto = d.subtotal_impuesto,
                            subtotal_neto = d.subtotal_neto,
                            total = d.total,
                            fecha = d.fecha,
                            signo = d.signo,
                        };

                        if (recibo != null)
                        {
                            rg.Recibo = new MovVentaRec()
                            {
                                cambio = recibo.cambio,
                                monto_recibido = recibo.monto_recibido,
                            };
                        }
                        listDoc.Add(rg);
                    }


                    var list = new List<DTO.Contable.Asiento.Generar.Ficha>();
                    decimal tdebe;
                    decimal thaber;
                    foreach (var doc in listDoc)
                    {
                        tdebe = 0.0m;
                        thaber = 0.0m;
                        int numr = 0;

                        doc.depart = vtd.
                            Where(w => w.auto_documento == doc.auto).
                            GroupBy(g => new { g.auto_departamento }).
                            Select(s => new MovVentaDep { auto_Departamento = s.Key.auto_departamento, costo = s.Sum(t => t.costo_venta), venta = s.Sum(t => t.total_neto) }).
                            ToList();

                        var ivaVenta = doc.subtotal_impuesto;
                        var totalCobrado = 0.0m;
                        var total = doc.total;
                        if (doc.tipo != "03")
                        {
                            if (doc.condicion.Trim().ToUpper() == "CONTADO" && doc.Recibo != null)
                            {
                                totalCobrado = (doc.Recibo.monto_recibido - doc.Recibo.cambio);
                            }
                        }
                        else
                        {
                            totalCobrado = doc.total;
                        }

                        DTO.Contable.Asiento.Generar.Ficha encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                        encabezado.Id = doc.auto;
                        encabezado.DocumentoRef = doc.documento;
                        encabezado.FechaDoc = doc.fecha;
                        encabezado.DescripcionDoc = doc.Desc;
                        encabezado.Signo = 1;
                        encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Venta;

                        var idSucursal = 0;
                        switch (doc.CodigoSucursal.Trim())
                        {
                            case "01":
                                idSucursal = 1;
                                break;
                            case "02":
                                idSucursal = 2;
                                break;
                            case "03":
                                idSucursal = 3;
                                break;
                            case "04":
                                idSucursal = 4;
                                break;
                            case "05":
                                idSucursal = 5;
                                break;

                        }

                        List<DTO.Contable.Asiento.Generar.FichaDetalle> detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                        foreach (var cta in rd)
                        {
                            decimal monto = 0.0m;
                            switch (cta.referencia.Trim().ToUpper())
                            {
                                case "TOTAL COBRADO":
                                    if (doc.condicion.Trim().ToUpper() == "CONTADO" && doc.Recibo != null)
                                    {
                                        monto = totalCobrado;
                                    }
                                    break;
                                case "POR COBRAR":
                                    if (doc.condicion.Trim().ToUpper() != "CONTADO" || doc.Recibo == null)
                                    {
                                        monto = total;
                                    }
                                    break;
                                case "VENTA DEPART":
                                    List<contabilidad_departamentos> depV = null;
                                    if (idSucursal == 1)
                                    {
                                        depV = ctx.contabilidad_departamentos.Where(d => d.idPlanCta == cta.idPlanCta && d.Concepto == 3).ToList();
                                    }
                                    if (idSucursal == 2)
                                    {
                                        depV = ctx.contabilidad_departamentos.Where(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta && d.Concepto == 3).ToList();
                                    }
                                    if (idSucursal == 3)
                                    {
                                        depV = ctx.contabilidad_departamentos.Where(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta && d.Concepto == 3).ToList();
                                    }
                                    if (idSucursal == 4)
                                    {
                                        depV = ctx.contabilidad_departamentos.Where(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta && d.Concepto == 3).ToList();
                                    }
                                    if (idSucursal == 5)
                                    {
                                        depV = ctx.contabilidad_departamentos.Where(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta && d.Concepto == 3).ToList();
                                    }

                                    if (depV != null)
                                    {
                                        if (depV.Count > 0)
                                        {
                                            foreach (var n in depV)
                                            {
                                                var dp = doc.depart.FirstOrDefault(f => f.auto_Departamento == n.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto += dp.venta;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case "IVA VENTA":
                                    if (cta.idSucursal == idSucursal)
                                    {
                                        monto = ivaVenta;
                                    }
                                    break;
                                case "COSTO DEPART":
                                    if (cta.signo == -1)
                                    {
                                        contabilidad_departamentos dep = null;
                                        if (idSucursal == 1)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta && d.Concepto == 1);
                                        }
                                        if (idSucursal == 2)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta && d.Concepto == 1);
                                        }
                                        if (idSucursal == 3)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta && d.Concepto == 1);
                                        }
                                        if (idSucursal == 4)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta && d.Concepto == 1);
                                        }
                                        if (idSucursal == 5)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta && d.Concepto == 1);
                                        }

                                        if (dep != null)
                                        {
                                            var dp = doc.depart.FirstOrDefault(f => f.auto_Departamento == dep.auto_departamento);
                                            if (dp != null)
                                            {
                                                monto = dp.costo;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        contabilidad_departamentos dep = null;
                                        if (idSucursal == 1)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta && d.Concepto == 2);
                                        }
                                        if (idSucursal == 2)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta && d.Concepto == 2);
                                        }
                                        if (idSucursal == 3)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta && d.Concepto == 2);
                                        }
                                        if (idSucursal == 4)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta && d.Concepto == 2);
                                        }
                                        if (idSucursal == 5)
                                        {
                                            dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta && d.Concepto == 2);
                                        }

                                        if (dep != null)
                                        {
                                            var dp = doc.depart.FirstOrDefault(f => f.auto_Departamento == dep.auto_departamento);
                                            if (dp != null)
                                            {
                                                monto = dp.costo;
                                            }
                                        }
                                    }
                                    break;
                            }

                            if (monto > 0)
                            {
                                decimal mdebe = 0.0m;
                                decimal mhaber = 0.0m;

                                if (doc.signo == 1)
                                {
                                    if (cta.signo == 1)
                                    {
                                        mdebe = monto;
                                    }
                                    else
                                    {
                                        mhaber = monto;
                                    }
                                }
                                else
                                {
                                    if (cta.signo == 1)
                                    {
                                        mhaber = monto;
                                    }
                                    else
                                    {
                                        mdebe = monto;
                                    }
                                }


                                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                if (cta.contabilidad_plancta.naturaleza == "A")
                                {
                                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                }

                                numr += 1;
                                var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                detalle.IdCta = cta.idPlanCta;
                                detalle.Renglon = numr;
                                detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                detalle.Naturaleza = nat;
                                detalle.MontoDebe = mdebe;
                                detalle.MontoHaber = mhaber;
                                detalles.Add(detalle);

                                tdebe += mdebe;
                                thaber += mhaber;
                            }
                        }

                        encabezado.Detalles = detalles;
                        encabezado.IsOk = true;
                        if (tdebe != thaber)
                        {
                            encabezado.IsOk = false;
                        }
                        list.Add(encabezado);
                    }

                    result.Lista = list;
                    result.cntRegistro = list.Count();
                }

            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_CtasPorPagar_Generar(DTO.Contable.Asiento.Generar.Filtros ficha)
        {
            var result = new ResultadoLista<DTO.Contable.Asiento.Generar.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    var idRegla = 3;
                    var r = ctx.contabilidad_reglas_integracion.Find(idRegla);
                    var rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();

                    var qd = ctx.cxp_recibos.
                        Where(mp => mp.fecha >= ficha.Desde
                            && mp.fecha <= ficha.Hasta
                            && mp.estatus_anulado == "0"
                            && mp.documento != "IR").
                        Select(s => new PagoFactura()
                        {
                            Id = s.auto,
                            IdProveedor = s.auto_proveedor,
                            Documento = s.documento,
                            Fecha = s.fecha,
                            NombreRazonSocial = s.proveedor,
                            Rif = s.ci_rif,
                            Monto = s.monto_recibido,
                            Nota = s.nota,
                        }).ToList();

                    foreach (var doc in qd)
                    {
                        var entMedPago = ctx.cxp_medio_pago.FirstOrDefault(d => d.auto_recibo == doc.Id && d.monto_recibido > 0);
                        if (entMedPago != null)
                        {
                            var entBanco = ctx.bancos.FirstOrDefault(d => d.codigo == entMedPago.codigo_banco);
                            if (entBanco != null)
                            {
                                doc.IdPlanCtaBanco = -1;

                                var entContBanco = ctx.contabilidad_banco.FirstOrDefault(b => b.auto_banco == entBanco.auto);
                                if (entContBanco != null)
                                {
                                    if (entContBanco.idPlanCta.HasValue)
                                    {
                                        doc.IdPlanCtaBanco = entContBanco.idPlanCta.Value;
                                    };
                                }
                            }
                        }

                        var list = new List<PagoFacturaDetalle>();
                        var entPagos = ctx.cxp_documentos.Where(d => d.auto_cxp_recibo == doc.Id).ToList();
                        if (entPagos.Count() > 0)
                        {
                            foreach (var dp in entPagos)
                            {
                                var montoImporte = dp.importe;
                                var entCxp = ctx.cxp.Find(dp.auto_cxp);
                                if (entCxp != null)
                                {
                                    //doc origen compra
                                    if (entCxp.documento != entCxp.auto_documento)
                                    {
                                        var entCompra = ctx.compras.Find(entCxp.auto_documento);
                                        if (entCompra != null)
                                        {

                                            var entBancoMovConcepto = ctx.contabilidad_banco_conceptos.FirstOrDefault(ct => ct.autoMovimientoConcepto == entCompra.auto_concepto);
                                            if (entBancoMovConcepto != null)
                                            {
                                                var detalle = new PagoFacturaDetalle();
                                                detalle.IdPlanCtaPago = entBancoMovConcepto.idCtaPasivo;
                                                detalle.Monto = montoImporte;
                                                detalle.IdConcepto = entBancoMovConcepto.autoMovimientoConcepto;
                                                list.Add(detalle);
                                            }
                                        }
                                    }
                                    else  // doc origen adm
                                    {
                                        var detalle = new PagoFacturaDetalle();
                                        detalle.IdPlanCtaPago = -1; //1322
                                        detalle.Monto = montoImporte;
                                        detalle.IdConcepto = "";
                                        list.Add(detalle);
                                    }
                                }
                            }

                            var mNC = Math.Abs(list.Where(w => w.Monto < 0 && w.IdPlanCtaPago != -1).Sum(s => s.Monto));
                            if (mNC > 0)
                            {
                                //SI HAY NOTAS DE CREDITO, DEBO HACER UNA OPREACION DE DISMINUCION AL DOCUMENTO FAC/ND
                                foreach (var l in list.Where(w => w.Monto > 0).ToList())
                                {
                                    if (mNC > 0)
                                    {
                                        if (l.Monto >= mNC)
                                        {
                                            l.MontoNC = mNC;
                                            mNC = 0;
                                        }
                                        else
                                        {
                                            l.MontoNC = l.Monto;
                                            mNC -= l.Monto;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                        }

                        //DEPURAR CUENTAS
                        foreach (var l in list)
                        {
                            l.Monto -= l.MontoNC;
                        }

                        doc.Detalle = list.Where(w => w.Monto > 0).ToList();
                    }
                    qd = qd.Where(d => d.Detalle.Count() > 0).ToList();

                    if (ficha.CxP != null)
                    {
                        if (ficha.CxP.IdProveedor != null)
                        {
                            qd = qd.Where(s => s.IdProveedor == ficha.CxP.IdProveedor).ToList();
                        }
                        if (ficha.CxP.IdConcepto != null)
                        {
                            qd = qd.Where(ac => ac.Detalle.Exists(tt => tt.IdConcepto == ficha.CxP.IdConcepto)).ToList();
                        }
                    }

                    var listas = new List<DTO.Contable.Asiento.Generar.Ficha>();


                    if ((ficha.CxP.TipoDocumento.HasValue && ficha.CxP.TipoDocumento.Value == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Pago)
                        || (ficha.CxP.TipoDocumento.HasValue == false))
                    {
                        //PAGOS
                        foreach (var mov in qd)
                        {
                            decimal tdebe = 0.0m;
                            decimal thaber = 0.0m;
                            int numr = 0; ;

                            var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                            encabezado.Id = mov.Id;
                            encabezado.DocumentoRef = mov.Documento;
                            encabezado.FechaDoc = mov.Fecha;
                            encabezado.DescripcionDoc = mov.DescripcionDocumento;
                            encabezado.Signo = 1;
                            encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Pago;
                            var conceptoPlanCtaPago = mov.Detalle.
                                GroupBy(gg => new { idPlanCtaPago = gg.IdPlanCtaPago }).
                                Select(s => new { idPlanCtaPago = s.Key.idPlanCtaPago, monto = s.Sum(t => t.Monto) }).
                                ToList();

                            var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                            foreach (var cta in rd)
                            {
                                decimal monto = 0.0m;
                                var xsignoDoc = 1;
                                switch (cta.referencia.Trim().ToUpper())
                                {
                                    case "MONTO PAGADO":
                                        var conceptoPlanCta = conceptoPlanCtaPago.FirstOrDefault(ff => ff.idPlanCtaPago == cta.idPlanCta);
                                        if (conceptoPlanCta != null)
                                        {
                                            monto = conceptoPlanCta.monto;
                                            if (monto < 0)
                                            {
                                                xsignoDoc = -1;
                                                monto = Math.Abs(monto);
                                            }
                                        }
                                        break;
                                    case "BANCO":
                                        if (mov.IdPlanCtaBanco == cta.idPlanCta)
                                        {
                                            monto = mov.Monto;
                                        }
                                        break;
                                }

                                if (monto > 0) //monto > 0
                                {
                                    decimal mdebe = 0.0m;
                                    decimal mhaber = 0.0m;

                                    //if (cta.signo == 1)
                                    //{
                                    //    mdebe = monto;
                                    //}
                                    //else
                                    //{
                                    //    mhaber = monto;
                                    //}


                                    if (xsignoDoc == 1)
                                    {
                                        if (cta.signo == 1)
                                        {
                                            mdebe = monto;
                                        }
                                        else
                                        {
                                            mhaber = monto;
                                        }
                                    }
                                    else
                                    {
                                        if (cta.signo == 1)
                                        {
                                            mhaber = monto;
                                        }
                                        else
                                        {
                                            mdebe = monto;
                                        }
                                    }


                                    var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                    if (cta.contabilidad_plancta.naturaleza == "A")
                                    {
                                        nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                    }

                                    numr += 1;
                                    var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                    detalle.IdCta = cta.idPlanCta;
                                    detalle.Renglon = numr;
                                    detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                    detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                    detalle.MontoDebe = mdebe;
                                    detalle.MontoHaber = mhaber;
                                    detalle.Naturaleza = nat;
                                    detalles.Add(detalle);

                                    tdebe += mdebe;
                                    thaber += mhaber;
                                }
                            }

                            encabezado.Detalles = detalles;
                            encabezado.IsOk = true;
                            if (tdebe != thaber)
                            {
                                encabezado.IsOk = false;
                            }
                            listas.Add(encabezado);
                        }
                    }

                    if ((ficha.CxP.TipoDocumento.HasValue &&
                        ((ficha.CxP.TipoDocumento.Value == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIva) ||
                        (ficha.CxP.TipoDocumento.Value == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIslr)))
                     || (ficha.CxP.TipoDocumento.HasValue == false))
                    {

                        //RETENCIONES
                        var qx = ctx.compras_retenciones.
                            Where(cr => cr.fecha >= ficha.Desde && cr.fecha <= ficha.Hasta
                                && cr.estatus_anulado == "0"
                                && (cr.tipo == "07" || cr.tipo == "08")).
                                Select(ss => new PagoRetencion()
                                {
                                    Id = ss.auto,
                                    IdProveedor = ss.auto_proveedor,
                                    Documento = ss.documento,
                                    Fecha = ss.fecha,
                                    NombreRazonSocial = ss.razon_social,
                                    Rif = ss.ci_rif,
                                    Monto = ss.retencion,
                                    Tipo = ss.tipo == "07" ? PagoRetencion.enumTipo.Iva : PagoRetencion.enumTipo.Isrl,
                                }).
                                ToList();

                        foreach (var doc in qx)
                        {
                            var list = new List<PagoRetencionDetalle>();
                            var entRetDet = ctx.compras_retenciones_detalle.Where(d => d.auto == doc.Id).ToList();
                            if (entRetDet.Count() > 0)
                            {
                                foreach (var dt in entRetDet)
                                {
                                    var entCompra = ctx.compras.Find(dt.auto_documento);
                                    if (entCompra != null)
                                    {
                                        if (entCompra.auto_concepto != "")
                                        {
                                            var entBancoMovConcepto = ctx.contabilidad_banco_conceptos.FirstOrDefault(ct => ct.autoMovimientoConcepto == entCompra.auto_concepto);
                                            if (entBancoMovConcepto != null)
                                            {
                                                var det = new PagoRetencionDetalle()
                                                {
                                                    AutoConcepto = entCompra.auto_concepto,
                                                    IdPlanCtaPago = entBancoMovConcepto.idCtaPasivo,
                                                    CodigoSucursal = entCompra.codigo_sucursal,
                                                    MontoRetencion = dt.retencion,
                                                };
                                                list.Add(det);
                                            }
                                        }
                                    }
                                }
                            }
                            doc.Detalle = list;
                        };

                        //FILTROS QUE APLICAN A LAS RETENCIONES
                        if (ficha.CxP != null)
                        {
                            if (ficha.CxP.IdProveedor != null)
                            {
                                qx = qx.Where(f => f.IdProveedor == ficha.CxP.IdProveedor).ToList();
                            }
                            if (ficha.CxP.IdConcepto != null)
                            {
                                qx = qx.Where(f => f.Detalle.Exists(fd => fd.AutoConcepto == ficha.CxP.IdConcepto)).ToList();
                            }
                        }



                        var listDocRet = new List<DocRet>();
                        foreach (var ret in qx)
                        {
                            foreach (var retdet in ret.Detalle)
                            {
                                var idSucursal = 0;
                                switch (retdet.CodigoSucursal)
                                {
                                    case "01":
                                        idSucursal = 1;
                                        break;
                                    case "02":
                                        idSucursal = 2;
                                        break;
                                    case "03":
                                        idSucursal = 3;
                                        break;
                                    case "04":
                                        idSucursal = 4;
                                        break;
                                    case "05":
                                        idSucursal = 5;
                                        break;
                                }
                                var reg = new DocRet()
                                {
                                    Id = ret.Id,
                                    IdProveedor = ret.IdProveedor,
                                    Documento = ret.Documento,
                                    Fecha = ret.Fecha,
                                    NombreRazonSocial = ret.NombreRazonSocial,
                                    Rif = ret.Rif,
                                    Tipo = (DocRet.enumTipo)ret.Tipo,
                                    Monto = retdet.MontoRetencion,
                                    AutoConcepto = retdet.AutoConcepto,
                                    CodigoSucursal = idSucursal,
                                    IdPlanCtaPago = retdet.IdPlanCtaPago,
                                };
                                listDocRet.Add(reg);
                            }
                        }


                        foreach (var mov in listDocRet)
                        {
                            decimal tdebe = 0.0m;
                            decimal thaber = 0.0m;
                            int numr = 0; ;

                            var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                            encabezado.Id = mov.Id;
                            encabezado.DocumentoRef = mov.Documento;
                            encabezado.FechaDoc = mov.Fecha;
                            encabezado.DescripcionDoc = mov.DescripcionDocumento;
                            encabezado.TipoDoc = mov.Tipo == DocRet.enumTipo.Iva ?
                                DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIva :
                                DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIslr;
                            encabezado.Signo = 1;

                            var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                            foreach (var cta in rd)
                            {
                                decimal monto = 0.0m;
                                switch (cta.referencia.Trim().ToUpper())
                                {
                                    case "MONTO PAGADO":
                                        if (mov.IdPlanCtaPago == cta.idPlanCta)
                                        {
                                            monto = mov.Monto;
                                        }
                                        //var ent = mov.Detalle.FirstOrDefault(rr => rr.IdPlanCtaPago == cta.idPlanCta);
                                        //if (ent != null)
                                        //{
                                        //    monto = mov.Monto;
                                        //}
                                        break;
                                    case "RETENCION IVA":
                                        if (mov.Tipo == DocRet.enumTipo.Iva && mov.CodigoSucursal == cta.idSucursal)
                                        {
                                            monto = mov.Monto;
                                        }
                                        //if (mov.Tipo == PagoRetencion.enumTipo.Iva)
                                        //{
                                        //    monto = mov.Monto;
                                        //}
                                        break;
                                    case "RETENCION ISLR":
                                        if (mov.Tipo == DocRet.enumTipo.Isrl && mov.CodigoSucursal == cta.idSucursal)
                                        {
                                            monto = mov.Monto;
                                        }
                                        //if (mov.Tipo == PagoRetencion.enumTipo.Isrl)
                                        //{
                                        //    monto = mov.Monto;
                                        //}
                                        break;
                                }

                                if (Math.Abs(monto) > 0)
                                {
                                    decimal mdebe = 0.0m;
                                    decimal mhaber = 0.0m;

                                    if (cta.signo == 1)
                                    {
                                        mdebe = monto;
                                    }
                                    else
                                    {
                                        mhaber = monto;
                                    }

                                    var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                    if (cta.contabilidad_plancta.naturaleza == "A")
                                    {
                                        nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                    }

                                    numr += 1;
                                    var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                    detalle.IdCta = cta.idPlanCta;
                                    detalle.Renglon = numr;
                                    detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                    detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                    detalle.MontoDebe = mdebe;
                                    detalle.MontoHaber = mhaber;
                                    detalle.Naturaleza = nat;
                                    detalles.Add(detalle);

                                    tdebe += mdebe;
                                    thaber += mhaber;
                                }
                            }

                            encabezado.Detalles = detalles;
                            encabezado.IsOk = true;
                            if (tdebe != thaber)
                            {
                                encabezado.IsOk = false;
                            }
                            listas.Add(encabezado);
                        }
                    }

                    if (ficha.CxP != null)
                    {
                        if (ficha.CxP.TipoDocumento != null)
                        {
                            listas = listas.Where(d => d.TipoDoc == ficha.CxP.TipoDocumento).ToList();
                        }
                    }

                    result.cntRegistro = listas.Count();
                    result.Lista = listas;
                }

            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_CtasPorCobrar_Generar(DTO.Contable.Asiento.Generar.Filtros ficha)
        {
            var result = new ResultadoLista<DTO.Contable.Asiento.Generar.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    var idRegla = 4;
                    var r = ctx.contabilidad_reglas_integracion.Find(idRegla);
                    var rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();

                    var qd = ctx.cxc_recibos.Where(cx => cx.fecha >= ficha.Desde && cx.fecha <= ficha.Hasta).ToList();
                    qd=qd.Where(cx=>cx.estatus_anulado=="0").ToList();
                    qd=qd.Where(cx=>cx.auto_cobrador!="0000000001").ToList();

                    var list = new List<DTO.Contable.Asiento.Generar.Ficha>();
                    foreach (var mov in qd)
                    {
                        int numr = 0;
                        decimal tdebe = 0.0m;
                        decimal thaber = 0.0m;
                        var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                        encabezado.Id = mov.auto;
                        encabezado.DocumentoRef = mov.documento;
                        encabezado.FechaDoc = mov.fecha;
                        encabezado.DescripcionDoc = "COBRO, " + mov.cliente.Trim() + ", " + mov.ci_rif.Trim();
                        encabezado.Signo = 1;
                        encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Cobro;

                        var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                        foreach (var cta in rd)
                        {
                            decimal monto = 0.0m;
                            switch (cta.referencia.Trim().ToUpper())
                            {
                                case "BANCO":
                                    monto = mov.monto_recibido - (mov.anticipos + mov.descuentos + mov.retenciones);
                                    break;
                                case "RETENCION IVA":
                                    monto = mov.retenciones;
                                    break;
                                case "RETENCION ISLR":
                                    monto = mov.retenciones;
                                    break;
                                case "MONTO COBRADO":
                                    monto = mov.monto_recibido;
                                    break;
                            }

                            if (monto > 0 && cta.referencia.Trim().ToUpper() == "BANCO")
                            {
                                var mp = ctx.cxc_medio_pago.Where(w => w.auto_recibo == mov.auto).ToList();

                                foreach (var dt in mp)
                                {
                                    decimal mdebe = 0.0m;
                                    decimal mhaber = 0.0m;
                                    var cta2 = ctx.contabilidad_empresa_medio.FirstOrDefault(f => f.auto_empresa_medio == dt.auto_medio_pago);
                                    if (cta2 != null)
                                    {
                                        if (cta.signo == 1)
                                        {
                                            mdebe = dt.monto_recibido;
                                        }
                                        else
                                        {
                                            mhaber = dt.monto_recibido;
                                        }

                                        var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                        if (cta.contabilidad_plancta.naturaleza == "A")
                                        {
                                            nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                        }

                                        numr += 1;
                                        var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                        detalle.IdCta = cta2.idPlanCta;
                                        detalle.Renglon = numr;
                                        detalle.CodigoCta = cta2.contabilidad_plancta.codigo;
                                        detalle.DescripcionCta = cta2.contabilidad_plancta.descripcion;
                                        detalle.MontoDebe = mdebe;
                                        detalle.MontoHaber = mhaber;
                                        detalle.Naturaleza = nat;
                                        detalles.Add(detalle);

                                        tdebe += mdebe;
                                        thaber += mhaber;
                                    }
                                }
                                monto = 0;
                            }

                            if (monto > 0)
                            {
                                decimal mdebe = 0.0m;
                                decimal mhaber = 0.0m;

                                if (cta.signo == 1)
                                {
                                    mdebe = monto;
                                }
                                else
                                {
                                    mhaber = monto;
                                }

                                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                if (cta.contabilidad_plancta.naturaleza == "A")
                                {
                                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                }

                                numr += 1;
                                var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                detalle.IdCta = cta.idPlanCta;
                                detalle.Renglon = numr;
                                detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                detalle.MontoDebe = mdebe;
                                detalle.MontoHaber = mhaber;
                                detalle.Naturaleza = nat;
                                detalles.Add(detalle);

                                tdebe += mdebe;
                                thaber += mhaber;
                            }
                        }

                        encabezado.Detalles = detalles;
                        encabezado.IsOk = true;
                        if (tdebe != thaber)
                        {
                            encabezado.IsOk = false;
                        }
                        list.Add(encabezado);
                    }

                    result.cntRegistro = list.Count();
                    result.Lista = list;
                }

            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Inventario_Generar(DTO.Contable.Asiento.Generar.Filtros ficha)
        {
            var result = new ResultadoLista<DTO.Contable.Asiento.Generar.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    var idRegla = 5;
                    var r = ctx.contabilidad_reglas_integracion.Find(idRegla);
                    var rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();
                    var listas = new List<DTO.Contable.Asiento.Generar.Ficha>();


                    //// ASIENTO POR CARGOS
                    //if ((ficha.Inventario.TipoDocumento.HasValue && ficha.Inventario.TipoDocumento.Value == DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Cargo) || ficha.Inventario.TipoDocumento.HasValue == false)
                    //{
                    //    var yaZ = ctx.productos_movimientos.
                    //        Where(pmd =>
                    //            pmd.auto_deposito == "0000000001" &&
                    //            pmd.fecha >= ficha.Desde &&
                    //            pmd.fecha <= ficha.Hasta &&
                    //            pmd.estatus_anulado == "0" &&
                    //            pmd.auto_concepto != "0000000007" &&
                    //            pmd.documento_nombre == "CARGOS" &&
                    //            (pmd.tipo == "01" || pmd.tipo == "02" || pmd.tipo == "04")).
                    //            Select(s => new MovInventario()
                    //            {
                    //                Id = s.auto,
                    //                Documento = s.documento,
                    //                Fecha = s.fecha,
                    //                Concepto = "CARGOS",
                    //                Monto = s.total,
                    //                Nota = s.nota,
                    //                Signo = 1,
                    //            }).ToList();

                    //    foreach (var doc in yaZ)
                    //    {
                    //        var list = new List<MovInventarioDetalle>();
                    //        var entMovInvDetalle = ctx.productos_movimientos_detalle.Where(d => d.auto_documento == doc.Id).ToList();
                    //        if (entMovInvDetalle.Count > 0)
                    //        {
                    //            foreach (var prd in entMovInvDetalle)
                    //            {
                    //                var entPrd = ctx.productos.Find(prd.auto_producto);
                    //                if (entPrd != null)
                    //                {
                    //                    var entDep = ctx.empresa_departamentos.Find(entPrd.auto_departamento);
                    //                    if (entDep != null)
                    //                    {
                    //                        var det = new MovInventarioDetalle()
                    //                        {
                    //                            IdDepartamento = entDep.auto,
                    //                            Monto = prd.total,
                    //                        };
                    //                        list.Add(det);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        doc.Detalle = list;
                    //    }

                    //    foreach (var mov in yaZ)
                    //    {
                    //        decimal tdebe = 0.0m;
                    //        decimal thaber = 0.0m;
                    //        int numr = 0; ;

                    //        var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                    //        encabezado.Id = mov.Id;
                    //        encabezado.DocumentoRef = mov.Documento;
                    //        encabezado.FechaDoc = mov.Fecha;
                    //        encabezado.DescripcionDoc = mov.DescripcionDocumento;
                    //        encabezado.Signo = 1;
                    //        encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvCargo;
                    //        var depart = mov.Detalle.GroupBy(g => new { autoDep = g.IdDepartamento }).Select(s => new { autoDep = s.Key.autoDep, total = s.Sum(t => t.Monto) }).ToList();

                    //        var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                    //        rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();
                    //        rd = rd.Where(i => i.referencia == "INV" || i.referencia == "COST").OrderBy(o => o.referencia).ToList();
                    //        foreach (var cta in rd)
                    //        {
                    //            decimal monto = 0.0m;
                    //            switch (cta.referencia.Trim().ToUpper())
                    //            {
                    //                case "INV": // DEPART AJUSTE":
                    //                    var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                    //                        (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                    //                    if (dep0 != null)
                    //                    {
                    //                        var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                    //                        if (dp != null)
                    //                        {
                    //                            monto = dp.total;
                    //                        }
                    //                    }
                    //                    break;

                    //                case "COST": //MONTO AJUSTE":
                    //                    var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                    //                        (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Costo);
                    //                    if (dep1 != null)
                    //                    {
                    //                        var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                    //                        if (dp != null)
                    //                        {
                    //                            monto = dp.total;
                    //                        }
                    //                    }
                    //                    break;
                    //            }

                    //            if (monto > 0)
                    //            {
                    //                decimal mdebe = 0.0m;
                    //                decimal mhaber = 0.0m;

                    //                if (cta.signo == 1)
                    //                {
                    //                    mdebe = monto;
                    //                }
                    //                else
                    //                {
                    //                    mhaber = monto;
                    //                }

                    //                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                    //                if (cta.contabilidad_plancta.naturaleza == "A")
                    //                {
                    //                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                    //                }

                    //                numr += 1;
                    //                var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                    //                detalle.IdCta = cta.idPlanCta;
                    //                detalle.Renglon = numr;
                    //                detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                    //                detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                    //                detalle.MontoDebe = mdebe;
                    //                detalle.MontoHaber = mhaber;
                    //                detalle.Naturaleza = nat;
                    //                detalles.Add(detalle);

                    //                tdebe += mdebe;
                    //                thaber += mhaber;
                    //            }
                    //        }

                    //        encabezado.Detalles = detalles;
                    //        encabezado.IsOk = true;
                    //        if (tdebe != thaber)
                    //        {
                    //            encabezado.IsOk = false;
                    //        }
                    //        listas.Add(encabezado);
                    //    }
                    //}


                    //// ASIENTO DE AUTO CONSUMO DESCARGO
                    //if ((ficha.Inventario.TipoDocumento.HasValue && ficha.Inventario.TipoDocumento.Value == DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Descargo) || ficha.Inventario.TipoDocumento.HasValue == false)
                    //{
                    //    var yd = ctx.productos_movimientos.
                    //        Where(pmd =>
                    //            pmd.auto_deposito == "0000000001" &&
                    //            pmd.fecha >= ficha.Desde &&
                    //            pmd.fecha <= ficha.Hasta &&
                    //            pmd.estatus_anulado == "0" &&
                    //            pmd.auto_concepto != "0000000007" &&
                    //            pmd.documento_nombre == "DESCARGOS" &&
                    //            (pmd.tipo == "01" || pmd.tipo == "02" || pmd.tipo == "04")).
                    //            Select(s => new MovInventario()
                    //            {
                    //                Id = s.auto,
                    //                Documento = s.documento,
                    //                Fecha = s.fecha,
                    //                Concepto = "DESCARGO",
                    //                Monto = s.total,
                    //                Nota = s.nota,
                    //            }).ToList();

                    //    foreach (var doc in yd)
                    //    {
                    //        var list = new List<MovInventarioDetalle>();
                    //        var entMovInvDetalle = ctx.productos_movimientos_detalle.Where(d => d.auto_documento == doc.Id).ToList();
                    //        if (entMovInvDetalle.Count > 0)
                    //        {
                    //            foreach (var prd in entMovInvDetalle)
                    //            {
                    //                var entPrd = ctx.productos.Find(prd.auto_producto);
                    //                if (entPrd != null)
                    //                {
                    //                    var entDep = ctx.empresa_departamentos.Find(entPrd.auto_departamento);
                    //                    if (entDep != null)
                    //                    {
                    //                        var det = new MovInventarioDetalle()
                    //                        {
                    //                            IdDepartamento = entDep.auto,
                    //                            Monto = prd.total,
                    //                        };
                    //                        list.Add(det);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        doc.Detalle = list;
                    //    }

                    //    foreach (var mov in yd)
                    //    {
                    //        decimal tdebe = 0.0m;
                    //        decimal thaber = 0.0m;
                    //        int numr = 0; ;

                    //        var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                    //        encabezado.Id = mov.Id;
                    //        encabezado.DocumentoRef = mov.Documento;
                    //        encabezado.FechaDoc = mov.Fecha;
                    //        encabezado.DescripcionDoc = mov.DescripcionDocumento;
                    //        encabezado.Signo = 1;
                    //        encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAutoConsumo;
                    //        var depart = mov.Detalle.GroupBy(g => new { autoDep = g.IdDepartamento }).Select(s => new { autoDep = s.Key.autoDep, total = s.Sum(t => t.Monto) }).ToList();
                    //        rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();
                    //        rd = rd.Where(i => i.referencia == "DEPART AJUSTE" || i.referencia == "MONTO").OrderBy(o => o.referencia).ToList();

                    //        var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                    //        foreach (var cta in rd)
                    //        {
                    //            decimal monto = 0.0m;
                    //            switch (cta.referencia.Trim().ToUpper())
                    //            {
                    //                case "DEPART AJUSTE":
                    //                    var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                    //                        (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                    //                    if (dep0 != null)
                    //                    {
                    //                        var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                    //                        if (dp != null)
                    //                        {
                    //                            monto = dp.total;
                    //                        }
                    //                    }
                    //                    break;

                    //                case "MONTO":
                    //                    var dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                    //                        (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno);
                    //                    if (dep != null)
                    //                    {
                    //                        var dp = depart.FirstOrDefault(f => f.autoDep == dep.auto_departamento);
                    //                        if (dp != null)
                    //                        {
                    //                            monto = dp.total;
                    //                        }
                    //                    }
                    //                    break;
                    //            }

                    //            if (monto > 0)
                    //            {
                    //                decimal mdebe = 0.0m;
                    //                decimal mhaber = 0.0m;

                    //                if (cta.signo == 1)
                    //                {
                    //                    mdebe = monto;
                    //                }
                    //                else
                    //                {
                    //                    mhaber = monto;
                    //                }

                    //                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                    //                if (cta.contabilidad_plancta.naturaleza == "A")
                    //                {
                    //                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                    //                }

                    //                numr += 1;
                    //                var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                    //                detalle.IdCta = cta.idPlanCta;
                    //                detalle.Renglon = numr;
                    //                detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                    //                detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                    //                detalle.MontoDebe = mdebe;
                    //                detalle.MontoHaber = mhaber;
                    //                detalle.Naturaleza = nat;
                    //                detalles.Add(detalle);

                    //                tdebe += mdebe;
                    //                thaber += mhaber;
                    //            }
                    //        }

                    //        encabezado.Detalles = detalles;
                    //        encabezado.IsOk = true;
                    //        if (tdebe != thaber)
                    //        {
                    //            encabezado.IsOk = false;
                    //        }
                    //        listas.Add(encabezado);
                    //    }
                    //}


                    // ASIENTO DE AUTO CONSUMO DESCARGO
                    if ((ficha.Inventario.TipoDocumento.HasValue && ficha.Inventario.TipoDocumento.Value == DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Descargo) || ficha.Inventario.TipoDocumento.HasValue == false)
                    {
                        var yd = ctx.productos_movimientos.
                            Where(pmd =>
                                // pmd.auto_deposito == "0000000001" &&
                                pmd.fecha >= ficha.Desde &&
                                pmd.fecha <= ficha.Hasta &&
                                pmd.estatus_anulado == "0" &&
                                pmd.auto_concepto == "0000000006" &&
                                pmd.documento_nombre == "DESCARGOS" &&
                                (pmd.tipo == "01" || pmd.tipo == "02" || pmd.tipo == "04")).
                                Select(s => new MovInventario()
                                {
                                    Id = s.auto,
                                    Documento = s.documento,
                                    Fecha = s.fecha,
                                    Concepto = "DESCARGO POR AUTO CONSUMO",
                                    Monto = s.total,
                                    Nota = s.nota,
                                    AutoDeposito = s.auto_deposito,
                                }).ToList();

                        foreach (var doc in yd)
                        {
                            var codSuc = "";
                            var xentDep = ctx.contabilidad_deposito.FirstOrDefault(dp => dp.auto_deposito == doc.AutoDeposito);
                            if (xentDep != null)
                            {
                                codSuc = xentDep.codigo_sucursal.Trim();
                            }
                            doc.CodigoSucursal = codSuc;


                            var list = new List<MovInventarioDetalle>();
                            var entMovInvDetalle = ctx.productos_movimientos_detalle.Where(d => d.auto_documento == doc.Id).ToList();
                            if (entMovInvDetalle.Count > 0)
                            {
                                foreach (var prd in entMovInvDetalle)
                                {
                                    var entPrd = ctx.productos.Find(prd.auto_producto);
                                    if (entPrd != null)
                                    {
                                        var entDep = ctx.empresa_departamentos.Find(entPrd.auto_departamento);
                                        if (entDep != null)
                                        {
                                            var det = new MovInventarioDetalle()
                                            {
                                                IdDepartamento = entDep.auto,
                                                Monto = prd.total,
                                            };
                                            list.Add(det);
                                        }
                                    }
                                }
                            }
                            doc.Detalle = list;
                        }

                        foreach (var mov in yd)
                        {
                            decimal tdebe = 0.0m;
                            decimal thaber = 0.0m;
                            int numr = 0; ;

                            var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                            encabezado.Id = mov.Id;
                            encabezado.DocumentoRef = mov.Documento;
                            encabezado.FechaDoc = mov.Fecha;
                            encabezado.DescripcionDoc = mov.DescripcionDocumento;
                            encabezado.Signo = 1;
                            encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAutoConsumo;
                            var depart = mov.Detalle.GroupBy(g => new { autoDep = g.IdDepartamento }).Select(s => new { autoDep = s.Key.autoDep, total = s.Sum(t => t.Monto) }).ToList();
                            rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();
                            rd = rd.Where(i => i.referencia == "DEPART AJUSTE" || i.referencia == "MONTO").OrderBy(o => o.referencia).ToList();

                            var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                            foreach (var cta in rd)
                            {
                                decimal monto = 0.0m;
                                switch (cta.referencia.Trim().ToUpper())
                                {
                                    case "DEPART AJUSTE":
                                        if (mov.CodigoSucursal == "01")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "02")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "03")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "04")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "05")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }
                                        break;

                                    case "MONTO":
                                        if (mov.CodigoSucursal == "01")
                                        {
                                            var dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno);
                                            if (dep != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "02")
                                        {
                                            var dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno);
                                            if (dep != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "03")
                                        {
                                            var dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno);
                                            if (dep != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "04")
                                        {
                                            var dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno);
                                            if (dep != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "05")
                                        {
                                            var dep = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.ConsumoInterno);
                                            if (dep != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        break;
                                }

                                if (monto > 0)
                                {
                                    decimal mdebe = 0.0m;
                                    decimal mhaber = 0.0m;

                                    if (cta.signo == 1)
                                    {
                                        mdebe = monto;
                                    }
                                    else
                                    {
                                        mhaber = monto;
                                    }

                                    var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                    if (cta.contabilidad_plancta.naturaleza == "A")
                                    {
                                        nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                    }

                                    numr += 1;
                                    var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                    detalle.IdCta = cta.idPlanCta;
                                    detalle.Renglon = numr;
                                    detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                    detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                    detalle.MontoDebe = mdebe;
                                    detalle.MontoHaber = mhaber;
                                    detalle.Naturaleza = nat;
                                    detalles.Add(detalle);

                                    tdebe += mdebe;
                                    thaber += mhaber;
                                }
                            }

                            encabezado.Detalles = detalles;
                            encabezado.IsOk = true;
                            if (tdebe != thaber)
                            {
                                encabezado.IsOk = false;
                            }
                            listas.Add(encabezado);
                        }
                    }


                    // ASIENTO DE AJUSTE POR DESCARGO
                    if ((ficha.Inventario.TipoDocumento.HasValue && ficha.Inventario.TipoDocumento.Value == DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.AjustePorDescargo) || ficha.Inventario.TipoDocumento.HasValue == false)
                    {
                        var ya = ctx.productos_movimientos.
                            Where(pmd =>
                                //pmd.auto_deposito == "0000000001" &&
                                pmd.fecha >= ficha.Desde &&
                                pmd.fecha <= ficha.Hasta &&
                                pmd.estatus_anulado == "0" &&
                                pmd.auto_concepto == "0000000007" &&
                                pmd.tipo == "02").
                                Select(s => new MovInventario()
                                {
                                    Id = s.auto,
                                    Documento = s.documento,
                                    Fecha = s.fecha,
                                    Concepto = "AJUSTE POR DESCARGO",
                                    Monto = s.total,
                                    Nota = s.nota,
                                    Signo = 1,
                                    AutoDeposito = s.auto_deposito,
                                }).ToList();

                        foreach (var doc in ya)
                        {
                            var codSuc = "";
                            var xentDep = ctx.contabilidad_deposito.FirstOrDefault(dp => dp.auto_deposito == doc.AutoDeposito);
                            if (xentDep != null)
                            {
                                codSuc = xentDep.codigo_sucursal.Trim();
                            }
                            doc.CodigoSucursal = codSuc;


                            var list = new List<MovInventarioDetalle>();
                            var entMovInvDetalle = ctx.productos_movimientos_detalle.Where(d => d.auto_documento == doc.Id).ToList();
                            if (entMovInvDetalle.Count > 0)
                            {
                                foreach (var prd in entMovInvDetalle)
                                {
                                    var entPrd = ctx.productos.Find(prd.auto_producto);
                                    if (entPrd != null)
                                    {
                                        var entDep = ctx.empresa_departamentos.Find(entPrd.auto_departamento);
                                        if (entDep != null)
                                        {
                                            var det = new MovInventarioDetalle()
                                            {
                                                IdDepartamento = entDep.auto,
                                                Monto = prd.total,
                                            };
                                            list.Add(det);
                                        }
                                    }
                                }
                            }
                            doc.Detalle = list;
                        }

                        foreach (var mov in ya)
                        {
                            decimal tdebe = 0.0m;
                            decimal thaber = 0.0m;
                            int numr = 0; ;

                            var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                            encabezado.Id = mov.Id;
                            encabezado.DocumentoRef = mov.Documento;
                            encabezado.FechaDoc = mov.Fecha;
                            encabezado.DescripcionDoc = mov.DescripcionDocumento;
                            encabezado.Signo = 1;
                            encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorDescargo;
                            var depart = mov.Detalle.GroupBy(g => new { autoDep = g.IdDepartamento }).Select(s => new { autoDep = s.Key.autoDep, total = s.Sum(t => t.Monto) }).ToList();
                            rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();
                            rd = rd.Where(i => i.referencia == "DEPART AJUSTE" || i.referencia == "MONTO AJUSTE").OrderBy(o => o.referencia).ToList();

                            var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                            foreach (var cta in rd)
                            {
                                decimal monto = 0.0m;
                                switch (cta.referencia.Trim().ToUpper())
                                {
                                    case "DEPART AJUSTE":
                                        if (mov.CodigoSucursal == "01")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "02")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "03")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "04")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "05")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        break;

                                    case "MONTO AJUSTE":
                                        if (mov.CodigoSucursal == "01")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "02")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "03")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "04")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "05")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        break;
                                }

                                if (monto > 0)
                                {
                                    decimal mdebe = 0.0m;
                                    decimal mhaber = 0.0m;

                                    if (cta.signo == 1)
                                    {
                                        mdebe = monto;
                                    }
                                    else
                                    {
                                        mhaber = monto;
                                    }

                                    var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                    if (cta.contabilidad_plancta.naturaleza == "A")
                                    {
                                        nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                    }

                                    numr += 1;
                                    var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                    detalle.IdCta = cta.idPlanCta;
                                    detalle.Renglon = numr;
                                    detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                    detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                    detalle.MontoDebe = mdebe;
                                    detalle.MontoHaber = mhaber;
                                    detalle.Naturaleza = nat;
                                    detalles.Add(detalle);

                                    tdebe += mdebe;
                                    thaber += mhaber;
                                }
                            }

                            encabezado.Detalles = detalles;
                            encabezado.IsOk = true;
                            if (tdebe != thaber)
                            {
                                encabezado.IsOk = false;
                            }
                            listas.Add(encabezado);
                        }
                    }


                    // ASIENTO DE AJUSTE POR CARGO
                    if ((ficha.Inventario.TipoDocumento.HasValue && ficha.Inventario.TipoDocumento.Value == DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.AjustePorCargo) || ficha.Inventario.TipoDocumento.HasValue == false)
                    {
                        var yaA = ctx.productos_movimientos.
                            Where(pmd =>
                                // pmd.auto_deposito == "0000000001" &&
                                pmd.fecha >= ficha.Desde &&
                                pmd.fecha <= ficha.Hasta &&
                                pmd.estatus_anulado == "0" &&
                                pmd.auto_concepto == "0000000007" &&
                                pmd.tipo == "01").
                                Select(s => new MovInventario()
                                {
                                    Id = s.auto,
                                    Documento = s.documento,
                                    Fecha = s.fecha,
                                    Concepto = "AJUSTE POR CARGOS",
                                    Monto = s.total,
                                    Nota = s.nota,
                                    Signo = 1,
                                    AutoDeposito = s.auto_deposito,
                                }).ToList();

                        foreach (var doc in yaA)
                        {
                            var codSuc = "";
                            var xentDep = ctx.contabilidad_deposito.FirstOrDefault(dp => dp.auto_deposito == doc.AutoDeposito);
                            if (xentDep != null)
                            {
                                codSuc = xentDep.codigo_sucursal.Trim();
                            }
                            doc.CodigoSucursal = codSuc;


                            var list = new List<MovInventarioDetalle>();
                            var entMovInvDetalle = ctx.productos_movimientos_detalle.Where(d => d.auto_documento == doc.Id).ToList();
                            if (entMovInvDetalle.Count > 0)
                            {
                                foreach (var prd in entMovInvDetalle)
                                {
                                    var entPrd = ctx.productos.Find(prd.auto_producto);
                                    if (entPrd != null)
                                    {
                                        var entDep = ctx.empresa_departamentos.Find(entPrd.auto_departamento);
                                        if (entDep != null)
                                        {
                                            var det = new MovInventarioDetalle()
                                            {
                                                IdDepartamento = entDep.auto,
                                                Monto = prd.total,
                                            };
                                            list.Add(det);
                                        }
                                    }
                                }
                            }
                            doc.Detalle = list;
                        }

                        foreach (var mov in yaA)
                        {
                            decimal tdebe = 0.0m;
                            decimal thaber = 0.0m;
                            int numr = 0; ;

                            var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                            encabezado.Id = mov.Id;
                            encabezado.DocumentoRef = mov.Documento;
                            encabezado.FechaDoc = mov.Fecha;
                            encabezado.DescripcionDoc = mov.DescripcionDocumento;
                            encabezado.Signo = 1;
                            encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorCargo;
                            var depart = mov.Detalle.GroupBy(g => new { autoDep = g.IdDepartamento }).Select(s => new { autoDep = s.Key.autoDep, total = s.Sum(t => t.Monto) }).ToList();

                            var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                            rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();
                            rd = rd.Where(i => i.referencia == "INV" || i.referencia == "MONTO AJUSTE").OrderBy(o => o.referencia).ToList();
                            foreach (var cta in rd)
                            {
                                decimal monto = 0.0m;
                                switch (cta.referencia.Trim().ToUpper())
                                {
                                    case "INV": // DEPART AJUSTE":
                                        if (mov.CodigoSucursal == "01")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "02")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "03")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "04")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "05")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        break;
                                    case "MONTO AJUSTE": //MONTO AJUSTE":
                                        if (mov.CodigoSucursal == "01")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "02")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "03")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "04")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "05")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        break;
                                }

                                if (monto > 0)
                                {
                                    decimal mdebe = 0.0m;
                                    decimal mhaber = 0.0m;

                                    if (cta.referencia.Trim().ToUpper() == "INV")
                                    {
                                        if (cta.signo == 1)
                                        {
                                            mdebe = monto;
                                        }
                                        else
                                        {
                                            mhaber = monto;
                                        }
                                    }
                                    else 
                                    {
                                        if (cta.signo == 1)
                                        {
                                            mhaber = monto;
                                        }
                                        else
                                        {
                                            mdebe = monto;
                                        }
                                    }

                                    //if (cta.signo == 1)
                                    //{
                                    //    mdebe = monto;
                                    //}
                                    //else
                                    //{
                                    //    mhaber = monto;
                                    //}

                                    var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                    if (cta.contabilidad_plancta.naturaleza == "A")
                                    {
                                        nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                    }

                                    numr += 1;
                                    var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                    detalle.IdCta = cta.idPlanCta;
                                    detalle.Renglon = numr;
                                    detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                    detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                    detalle.MontoDebe = mdebe;
                                    detalle.MontoHaber = mhaber;
                                    detalle.Naturaleza = nat;
                                    detalles.Add(detalle);

                                    tdebe += mdebe;
                                    thaber += mhaber;
                                }
                            }

                            encabezado.Detalles = detalles;
                            encabezado.IsOk = true;
                            if (tdebe != thaber)
                            {
                                encabezado.IsOk = false;
                            }
                            listas.Add(encabezado);
                        }
                    }


                    // ASIENTO POR AJUSTE 
                    if ((ficha.Inventario.TipoDocumento.HasValue && ficha.Inventario.TipoDocumento.Value == DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Ajuste) || ficha.Inventario.TipoDocumento.HasValue == false)
                    {
                        var yaB = ctx.productos_movimientos.
                            Where(pmd =>
                                //pmd.auto_deposito == "0000000001" &&
                                pmd.fecha >= ficha.Desde &&
                                pmd.fecha <= ficha.Hasta &&
                                pmd.estatus_anulado == "0" &&
                                pmd.auto_concepto == "0000000007" &&
                                pmd.tipo == "04").
                                Select(s => new MovInventario()
                                {
                                    Id = s.auto,
                                    Documento = s.documento,
                                    Fecha = s.fecha,
                                    Concepto = "AJUSTES ",
                                    Monto = s.total,
                                    Nota = s.nota,
                                    Signo = 1,
                                    AutoDeposito = s.auto_deposito,
                                }).ToList();

                        foreach (var doc in yaB)
                        {
                            var codSuc = "";
                            var xentDep = ctx.contabilidad_deposito.FirstOrDefault(dp => dp.auto_deposito == doc.AutoDeposito);
                            if (xentDep != null)
                            {
                                codSuc = xentDep.codigo_sucursal.Trim();
                            }
                            doc.CodigoSucursal = codSuc;


                            var list = new List<MovInventarioDetalle>();
                            var entMovInvDetalle = ctx.productos_movimientos_detalle.Where(d => d.auto_documento == doc.Id).ToList();
                            if (entMovInvDetalle.Count > 0)
                            {
                                foreach (var prd in entMovInvDetalle)
                                {
                                    var entPrd = ctx.productos.Find(prd.auto_producto);
                                    if (entPrd != null)
                                    {
                                        var entDep = ctx.empresa_departamentos.Find(entPrd.auto_departamento);
                                        if (entDep != null)
                                        {
                                            var det = new MovInventarioDetalle()
                                            {
                                                IdDepartamento = entDep.auto,
                                                Monto = prd.total,
                                            };
                                            list.Add(det);
                                        }
                                    }
                                }
                            }
                            doc.Detalle = list;
                        }

                        foreach (var mov in yaB)
                        {
                            decimal tdebe = 0.0m;
                            decimal thaber = 0.0m;
                            int numr = 0; ;

                            var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                            encabezado.Id = mov.Id;
                            encabezado.DocumentoRef = mov.Documento;
                            encabezado.FechaDoc = mov.Fecha;
                            encabezado.DescripcionDoc = mov.DescripcionDocumento;
                            encabezado.Signo = 1;
                            encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjuste;
                            var depart = mov.Detalle.GroupBy(g => new { autoDep = g.IdDepartamento }).Select(s => new { autoDep = s.Key.autoDep, total = s.Sum(t => t.Monto) }).ToList();

                            var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                            rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();
                            rd = rd.Where(i => i.referencia == "INV" || i.referencia == "MONTO AJUSTE").OrderBy(o => o.referencia).ToList();
                            foreach (var cta in rd)
                            {
                                decimal monto = 0.0m;
                                switch (cta.referencia.Trim().ToUpper())
                                {
                                    case "INV": // DEPART AJUSTE":
                                        if (mov.CodigoSucursal == "01")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "02")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "03")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "04")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "05")
                                        {
                                            var dep0 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Inventario);
                                            if (dep0 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep0.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        break;

                                    case "MONTO AJUSTE": //MONTO AJUSTE":
                                        if (mov.CodigoSucursal == "01")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "02")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_2 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "03")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_3 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "04")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_4 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        if (mov.CodigoSucursal == "05")
                                        {
                                            var dep1 = ctx.contabilidad_departamentos.FirstOrDefault(d => d.idPlanCta_Sucursal_5 == cta.idPlanCta &&
                                                (DTO.Empresa.Departamentos.Enumerados.Concepto)d.Concepto == DTO.Empresa.Departamentos.Enumerados.Concepto.Ajuste);
                                            if (dep1 != null)
                                            {
                                                var dp = depart.FirstOrDefault(f => f.autoDep == dep1.auto_departamento);
                                                if (dp != null)
                                                {
                                                    monto = dp.total;
                                                }
                                            }
                                        }

                                        break;
                                }

                                if (monto != 0)
                                {
                                    decimal mdebe = 0.0m;
                                    decimal mhaber = 0.0m;

                                    if (cta.referencia.Trim().ToUpper() == "INV")
                                    {
                                        if (monto > 0)
                                        {
                                            if (cta.signo == 1)
                                            {
                                                mdebe = Math.Abs(monto);
                                            }
                                            else
                                            {
                                                mhaber = Math.Abs(monto);
                                            }
                                        }
                                        else
                                        {
                                            if (cta.signo == 1)
                                            {
                                                mhaber = Math.Abs(monto);
                                            }
                                            else
                                            {
                                                mdebe = Math.Abs(monto);
                                            }
                                        }
                                    }
                                    else 
                                    {
                                        if (monto > 0)
                                        {
                                            if (cta.signo == 1)
                                            {
                                                mhaber = Math.Abs(monto);
                                            }
                                            else
                                            {
                                                mdebe = Math.Abs(monto);
                                            }
                                        }
                                        else
                                        {
                                            if (cta.signo == 1)
                                            {
                                                mdebe = Math.Abs(monto);
                                            }
                                            else
                                            {
                                                mhaber = Math.Abs(monto);
                                            }
                                        }
                                    }

                                    //if (monto > 0)
                                    //{
                                    //    if (cta.signo == 1)
                                    //    {
                                    //        mdebe = Math.Abs(monto);
                                    //    }
                                    //    else
                                    //    {
                                    //        mhaber = Math.Abs(monto);
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    if (cta.signo == 1)
                                    //    {
                                    //        mhaber = Math.Abs(monto);
                                    //    }
                                    //    else
                                    //    {
                                    //        mdebe = Math.Abs(monto);
                                    //    }
                                    //}

                                    var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                    if (cta.contabilidad_plancta.naturaleza == "A")
                                    {
                                        nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                    }

                                    numr += 1;
                                    var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                    detalle.IdCta = cta.idPlanCta;
                                    detalle.Renglon = numr;
                                    detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                    detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                    detalle.MontoDebe = mdebe;
                                    detalle.MontoHaber = mhaber;
                                    detalle.Naturaleza = nat;
                                    detalles.Add(detalle);

                                    tdebe += mdebe;
                                    thaber += mhaber;
                                }
                            }

                            encabezado.Detalles = detalles;
                            encabezado.IsOk = true;
                            if (tdebe != thaber)
                            {
                                encabezado.IsOk = false;
                            }
                            listas.Add(encabezado);
                        }
                    }


                    // FILTRADO 
                    if (ficha.Inventario != null)
                    {
                        if (ficha.Inventario.TipoDocumento != null)
                        {
                            switch (ficha.Inventario.TipoDocumento.Value)
                            {
                                case DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Ajuste:
                                    listas = listas.Where(t => t.TipoDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjuste).ToList();
                                    break;
                                case DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.AjustePorCargo:
                                    listas = listas.Where(t => t.TipoDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorCargo).ToList();
                                    break;
                                case DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.AjustePorDescargo:
                                    listas = listas.Where(t => t.TipoDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorDescargo).ToList();
                                    break;
                                case DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Cargo:
                                    listas = listas.Where(t => t.TipoDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvCargo).ToList();
                                    break;
                                case DTO.Contable.Asiento.Generar.FiltroInventario.EnumTipoDocumento.Descargo:
                                    listas = listas.Where(t => t.TipoDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAutoConsumo).ToList();
                                    break;
                            }
                        }
                    }

                    result.cntRegistro = listas.Count();
                    result.Lista = listas;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Banco_Generar(DTO.Contable.Asiento.Generar.Filtros ficha)
        {
            var result = new ResultadoLista<DTO.Contable.Asiento.Generar.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    var idRegla = 6;
                    var r = ctx.contabilidad_reglas_integracion.Find(idRegla);
                    var rd = ctx.contabilidad_reglas_integracion_detalle.Where(d => d.idReglaIntegracion == idRegla).ToList();


                    // BANCO 
                    var yd = ctx.bancos_movimientos.
                        Where(pmd => pmd.fecha >= ficha.Desde &&
                            pmd.fecha <= ficha.Hasta &&
                            pmd.estatus_anulado == "0" &&
                            pmd.origen.Trim().ToUpper() == "BAN").
                            Select(s =>
                                new MovBanco()
                                {
                                    Id = s.auto,
                                    IdBanco = s.auto_banco,
                                    Documento = s.documento,
                                    Fecha = s.fecha,
                                    Concepto = s.entidad,
                                    Monto = s.importe,
                                    Nota = s.detalle,
                                    Signo = s.signo,
                                    TipoDocumento = s.tipo,
                                    IdPlanCta = -1,
                                    IdPlanCtaConcepto = -1,
                                }).ToList();

                    foreach (var mov in yd)
                    {
                        var idPlanCta = -1;
                        var EntContBanco = ctx.contabilidad_banco.FirstOrDefault(b => b.auto_banco == mov.IdBanco);
                        if (EntContBanco != null)
                        {
                            if (EntContBanco.idPlanCta.HasValue)
                            {
                                idPlanCta = EntContBanco.idPlanCta.Value;
                            }
                        }
                        mov.IdPlanCta = idPlanCta;

                        if (mov.TipoDocumento.Trim().ToUpper() == "DEP")
                        {
                            if (mov.Concepto.Trim().ToUpper() == "VENTAS POS" && mov.Nota.Trim().ToUpper() == "VENTAS POS")
                            {
                                mov.IdPlanCtaConcepto = int.MaxValue; //PARA MOVIMIENTOS PROVENIENTES DEL POS. CAJA TRANSITO MOVIMIENTO
                            }
                            else
                            {
                                var entBanConp = ctx.bancos_movimientos_conceptos.FirstOrDefault(ct => ct.nombre.Trim().ToUpper() == mov.Concepto.Trim().ToUpper());
                                if (entBanConp != null)
                                {
                                    var entContBancoConp = ctx.contabilidad_banco_conceptos.FirstOrDefault(d => d.autoMovimientoConcepto == entBanConp.auto);
                                    if (entContBancoConp != null)
                                    {
                                        mov.IdPlanCtaConcepto = entContBancoConp.idCtaBanco;
                                    }
                                }
                            }
                        }

                        if (mov.TipoDocumento.Trim().ToUpper() == "NDB")
                        {
                            var entBanConp = ctx.bancos_movimientos_conceptos.FirstOrDefault(ct => ct.nombre.Trim().ToUpper() == mov.Concepto.Trim().ToUpper());
                            if (entBanConp != null)
                            {
                                var entContBancoConp = ctx.contabilidad_banco_conceptos.FirstOrDefault(d => d.autoMovimientoConcepto == entBanConp.auto);
                                if (entContBancoConp != null)
                                {
                                    mov.IdPlanCtaConcepto = entContBancoConp.idCtaBanco;
                                }
                            }
                        }

                        if (mov.TipoDocumento.Trim().ToUpper() == "NCR")
                        {
                            var entBanConp = ctx.bancos_movimientos_conceptos.FirstOrDefault(ct => ct.nombre.Trim().ToUpper() == mov.Concepto.Trim().ToUpper());
                            if (entBanConp != null)
                            {
                                var entContBancoConp = ctx.contabilidad_banco_conceptos.FirstOrDefault(d => d.autoMovimientoConcepto == entBanConp.auto);
                                if (entContBancoConp != null)
                                {
                                    mov.IdPlanCtaConcepto = entContBancoConp.idCtaBanco;
                                }
                            }
                        }

                        if (mov.TipoDocumento.Trim().ToUpper() == "CHQ")
                        {
                            var entBanConp = ctx.bancos_movimientos_conceptos.FirstOrDefault(ct => ct.nombre.Trim().ToUpper() == mov.Concepto.Trim().ToUpper());
                            if (entBanConp != null)
                            {
                                var entContBancoConp = ctx.contabilidad_banco_conceptos.FirstOrDefault(d => d.autoMovimientoConcepto == entBanConp.auto);
                                if (entContBancoConp != null)
                                {
                                    mov.IdPlanCtaConcepto = entContBancoConp.idCtaBanco;
                                }
                            }
                        }

                        if (mov.TipoDocumento.Trim().ToUpper() == "ITF")
                        {
                            if (EntContBanco.idPlanCta_IGTF != null)
                            {
                                mov.IdPlanCtaConcepto = EntContBanco.idPlanCta_IGTF.Value;
                            }

                            //var entBanConp = ctx.bancos_movimientos_conceptos.FirstOrDefault(ct => ct.nombre.Trim().ToUpper() == mov.Concepto.Trim().ToUpper());
                            //if (entBanConp != null)
                            //{
                            //    var entContBancoConp = ctx.contabilidad_banco_conceptos.FirstOrDefault(d => d.autoMovimientoConcepto == entBanConp.auto);
                            //    if (entContBancoConp != null)
                            //    {
                            //        mov.IdPlanCtaConcepto = entContBancoConp.idCtaBanco;
                            //    }
                            //}
                        }
                    }

                    if (ficha.Banco != null)
                    {
                        if (ficha.Banco.TipoMovimiento.HasValue)
                        {
                            var td = "";
                            switch (ficha.Banco.TipoMovimiento.Value)
                            {
                                case DTO.Bancos.Enumerados.TipMovimiento.DEPOSITO:
                                    td = "DEP";
                                    break;
                                case DTO.Bancos.Enumerados.TipMovimiento.NOTA_DEBITO:
                                    td = "NDB";
                                    break;
                                case DTO.Bancos.Enumerados.TipMovimiento.NOTA_CREDITO:
                                    td = "NCR";
                                    break;
                                case DTO.Bancos.Enumerados.TipMovimiento.CHEQUE:
                                    td = "CHQ";
                                    break;
                                case DTO.Bancos.Enumerados.TipMovimiento.IGTF:
                                    td = "ITF";
                                    break;
                            }
                            yd = yd.Where(f => f.TipoDocumento == td).ToList();
                        }
                    }


                    var listas = new List<DTO.Contable.Asiento.Generar.Ficha>();
                    foreach (var mov in yd)
                    {
                        decimal tdebe = 0.0m;
                        decimal thaber = 0.0m;
                        int numr = 0; ;

                        var encabezado = new DTO.Contable.Asiento.Generar.Ficha();
                        encabezado.Id = mov.Id;
                        encabezado.DocumentoRef = mov.Documento;
                        encabezado.FechaDoc = mov.Fecha;
                        encabezado.DescripcionDoc = mov.DescripcionDocumento;
                        encabezado.Signo = 1;
                        encabezado.TipoDoc = DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.MovBanco;

                        var detalles = new List<DTO.Contable.Asiento.Generar.FichaDetalle>();
                        foreach (var cta in rd)
                        {
                            decimal monto = 0.0m;
                            switch (cta.referencia.Trim().ToUpper())
                            {
                                case "BANCO MOV":
                                    if (cta.idPlanCta == mov.IdPlanCta)
                                    {
                                        monto = mov.Monto;
                                    }
                                    break;
                                case "CAJA TRANS MOV": //PARA MOVIMIENTOS PROVENIENTES DEL POS. CAJA TRANSITO MOVIMIENTO
                                    if (mov.IdPlanCtaConcepto == int.MaxValue)
                                    {
                                        monto = mov.Monto;
                                    }
                                    break;
                                case "DEP":
                                    if (cta.idPlanCta == mov.IdPlanCtaConcepto && (mov.TipoDocumento == "NCR" || mov.TipoDocumento == "DEP"))
                                    {
                                        monto = mov.Monto;
                                    }
                                    break;
                                case "NDB":
                                    if (cta.idPlanCta == mov.IdPlanCtaConcepto && (mov.TipoDocumento == "NDB" || mov.TipoDocumento == "CHQ" || mov.TipoDocumento == "ITF"))
                                    {
                                        monto = mov.Monto;
                                    }
                                    break;
                            }

                            if (monto > 0)
                            {
                                decimal mdebe = 0.0m;
                                decimal mhaber = 0.0m;

                                if (mov.TipoDocumento == "DEP" || mov.TipoDocumento == "NCR")
                                {
                                    if (cta.signo == 1)
                                    {
                                        mdebe = monto;
                                    }
                                    else
                                    {
                                        mhaber = monto;
                                    }
                                }
                                else
                                {
                                    if (cta.signo == 1)
                                    {
                                        mhaber = monto;
                                    }
                                    else
                                    {
                                        mdebe = monto;
                                    }
                                }

                                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                if (cta.contabilidad_plancta.naturaleza == "A")
                                {
                                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                }

                                numr += 1;
                                var detalle = new DTO.Contable.Asiento.Generar.FichaDetalle();
                                detalle.IdCta = cta.idPlanCta;
                                detalle.Renglon = numr;
                                detalle.CodigoCta = cta.contabilidad_plancta.codigo;
                                detalle.DescripcionCta = cta.contabilidad_plancta.descripcion;
                                detalle.MontoDebe = mdebe;
                                detalle.MontoHaber = mhaber;
                                detalle.Naturaleza = nat;
                                detalles.Add(detalle);

                                tdebe += mdebe;
                                thaber += mhaber;
                            }
                        }

                        encabezado.Detalles = detalles;
                        encabezado.IsOk = true;
                        if (tdebe != thaber)
                        {
                            encabezado.IsOk = false;
                        }
                        listas.Add(encabezado);
                    }

                    result.cntRegistro = listas.Count();
                    result.Lista = listas;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public Resultado Contable_Asiento_Insertar_Integracion_Verificar(DTO.Contable.Asiento.Generar.Insertar ficha)
        {
            Resultado result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    foreach (var doc in ficha.Documentos)
                    {
                        if (doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Venta)
                        {
                            var entVenta = ctx.ventas.Find(doc.IdDocumento);
                            if (entVenta == null)
                            {
                                result.Mensaje = "DOCUMENTO DE VENTA NO ENCONTRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                            if (entVenta.estatus_cierre_contable == "1")
                            {
                                result.Mensaje = "DOCUMENTO DE VENTA YA INTEGRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

                        if (doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Compra)
                        {
                            var entCompra = ctx.compras.Find(doc.IdDocumento);
                            if (entCompra == null)
                            {
                                result.Mensaje = "DOCUMENTO DE COMPRA NO ENCONTRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                            if (entCompra.estatus_cierre_contable == "1")
                            {
                                result.Mensaje = "DOCUMENTO DE COMPRA YA INTEGRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

                        if (doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.MovBanco)
                        {
                            var entMovBanco = ctx.bancos_movimientos.Find(doc.IdDocumento);
                            if (entMovBanco == null)
                            {
                                result.Mensaje = "DOCUMENTO DE DE MOVIMIENTO BANCARIO NO ENCONTRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                            if (entMovBanco.estatus_cierre_contable == "1")
                            {
                                result.Mensaje = "DOCUMENTO DE MOVIMIENTO BANCARIO YA INTEGRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

                        if (doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjuste ||
                            doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorCargo ||
                            doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorDescargo ||
                            doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAutoConsumo ||
                            doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvCargo )
                        {
                            var entMovInv = ctx.productos_movimientos.Find(doc.IdDocumento);
                            if (entMovInv == null)
                            {
                                result.Mensaje = "DOCUMENTO DE DE MOVIMIENTO DE INVENTARIO NO ENCONTRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                            if (entMovInv.estatus_cierre_contable == "1")
                            {
                                result.Mensaje = "DOCUMENTO DE MOVIMIENTO DE INVENTARIO YA INTEGRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

                        if (doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Pago)
                        {
                            //BUSCO RECIBO DE CXP
                            var entRecPago = ctx.cxp_recibos.Find(doc.IdDocumento);
                            if (entRecPago == null)
                            {
                                result.Mensaje = "DOCUMENTO DE PAGO NO ENCONTRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                            var autoPago = entRecPago.auto_cxp;

                            //ESTE ME DA EL MOVIMIENTO DE PAGO EN CXP
                            var entPago = ctx.cxp.Find(autoPago);
                            if (entPago == null)
                            {
                                result.Mensaje = "DOCUMENTO DE PAGO NO ENCONTRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                            if (entPago.estatus_cierre_contable == "1")
                            {
                                result.Mensaje = "DOCUMENTO DE PAGO YA INTEGRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

                        if (doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIva ||
                            doc.TipoDocumento == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIslr)
                        {
                            var entRetencion = ctx.compras_retenciones.Find(doc.IdDocumento);
                            if (entRetencion == null)
                            {
                                result.Mensaje = "DOCUMENTO RETENCION NO ENCONTRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                            if (entRetencion .estatus_cierre_contable == "1")
                            {
                                result.Mensaje = "DOCUMENTO RETENCION YA INTEGRADO" + Environment.NewLine + doc.DescDocRef;
                                result.Result = EnumResult.isError;
                                return result;
                            }
                        }

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

    }

}
