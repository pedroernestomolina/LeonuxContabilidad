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

        public ResultadoLista<DTO.Contable.Asiento.Resumen> Contable_Asiento_Lista(DTO.Contable.Asiento.Busqueda busq)
        {
            ResultadoLista<DTO.Contable.Asiento.Resumen> result = new ResultadoLista<DTO.Contable.Asiento.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_asiento.ToList();
                    if (busq.Cadena != "")
                    {
                        //q.Where(d => d.codigo.Contains(busq.Cadena)).ToList();
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Contable.Asiento.Resumen
                            {
                                Id = d.id,
                                ComprobanteNro = d.numeroComprobante,
                                FechaEmision = d.fechaEmision,
                                Detalle = d.descripcion,
                                TipoAsiento = (DTO.Contable.Asiento.Enumerados.Tipo)d.tipoAsiento,
                                EstaAnulado = d.estaAnulado == "S" ? true : false,
                                EstaProcesado = d.estaProcesado == "S" ? true : false,
                                AutoGenerado = d.autoGenerado == "S" ? true : false,
                                TipoDocumento = d.tipoDocumento,
                                MesRelacion=d.mesRelacion,
                                AnoRelacion=d.anoRelacion,
                                ReglaDescripcion=d.reglaIntegracionDesc,
                                Importe = d.importe
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

        public ResultadoEntidad<DTO.Contable.Asiento.Ficha> Contable_Asiento_GetById(int id)
        {
            var result = new ResultadoEntidad<DTO.Contable.Asiento.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var entAsiento = ctx.contabilidad_asiento.Find(id);
                    if (entAsiento == null)
                    {
                        result.Mensaje = "[ ID ] ASIENTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var r = new DTO.Contable.Asiento.Ficha()
                    {
                        Id = entAsiento.id,
                        FechaEmision = entAsiento.fechaEmision,
                        MesRelacion = entAsiento.mesRelacion,
                        AnoRelacion = entAsiento.anoRelacion,
                        Descripcion = entAsiento.descripcion,
                        TipoAsiento = (DTO.Contable.Asiento.Enumerados.Tipo)entAsiento.tipoAsiento,
                        AutoGenerado = entAsiento.autoGenerado.Trim() == "S" ? true : false,
                        EstaAnulado = entAsiento.estaAnulado.Trim() == "S" ? true : false,
                        EstaProcesado = entAsiento.estaProcesado.Trim() == "S" ? true : false,
                        ComprobanteNro = entAsiento.numeroComprobante,
                        Renglones = entAsiento.renglones,
                        TipoDocumento = entAsiento.tipoDocumento,
                        IdTipoDocumento = entAsiento.idTipoDocumento.HasValue ? entAsiento.idTipoDocumento.Value : -1,
                        CodigoReglaIntegracion = entAsiento.reglaIntegracionCod,
                        DescripcionReglaIntegracion = entAsiento.reglaIntegracionDesc,
                        Importe = entAsiento.importe,
                    };

                    var entAsientoResumen = ctx.contabilidad_asiento_resumen.Where(f => f.idAsiento == id).ToList();
                    if (entAsientoResumen != null)
                    {
                        if (entAsientoResumen.Count() > 0)
                        {
                            var r1 = entAsientoResumen.Select(rr =>
                            {
                                return new DTO.Contable.Asiento.FichaResumen()
                                {
                                    IdCta = rr.idPlanCta,
                                    CodigoCta = rr.codigoCta,
                                    DescripcionCta = rr.descripcionCta,
                                    MontoDebe = rr.montoDebe,
                                    MontoHaber = rr.montoHaber
                                };
                            }).ToList();
                            r.Resumen = r1;
                        }
                    }

                    var entAsientoDoc = ctx.contabilidad_asiento_documento.Where(f => f.idAsiento == id).ToList();
                    if (entAsientoDoc != null)
                    {
                        if (entAsientoDoc.Count() > 0)
                        {
                            var r2 = entAsientoDoc.Select(rr =>
                            {
                                return new DTO.Contable.Asiento.FichaDocumento()
                                {
                                    Documento = rr.documento,
                                    Fecha = rr.fecha,
                                    Descripcion = rr.descripcion,
                                    Signo = rr.signo,
                                    DetalleCta = rr.contabilidad_asiento_detalle.
                                    Where(fdt => fdt.idAsientoDocumento == rr.id).
                                    Select(dt =>
                                    {
                                        return new DTO.Contable.Asiento.FichaDetalle()
                                        {
                                            IdCta = dt.idPlanCta,
                                            CodigoCta = dt.codigoCta,
                                            DescripcionCta = dt.descripcionCta,
                                            NaturalezaCta=  (dt.naturalezaCta == "D" ? 
                                            DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora: 
                                            DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora),
                                            MontoDebe = dt.montoDebe,
                                            MontoHaber = dt.montoHaber,
                                            Renglon = dt.numRenglon,
                                        };
                                    }).ToList()
                                };
                            }).ToList();
                            r.Documentos = r2;
                        }
                    }

                    result.Entidad = r;
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

        public ResultadoId Contable_Asiento_Preview(DTO.Contable.Asiento.Insertar ficha)
        {
            ResultadoId result = new ResultadoId();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();
                        int cnt = 0;

                        if (ficha.IdAsientoPreview != -1)
                        {
                            var entA = ctx.contabilidad_asiento.Find(ficha.IdAsientoPreview);
                            var entADoc = ctx.contabilidad_asiento_documento.Where(d => d.idAsiento == ficha.IdAsientoPreview).ToList();
                            var entADet = ctx.contabilidad_asiento_detalle.Where(d => d.idAsiento == ficha.IdAsientoPreview).ToList();
                            cnt = entA.numeroComprobante;

                            foreach (var dt in entADet)
                            {
                                ctx.contabilidad_asiento_detalle.Remove(dt);
                                ctx.SaveChanges();
                            }
                            foreach (var doc in entADoc)
                            {
                                ctx.contabilidad_asiento_documento.Remove(doc);
                                ctx.SaveChanges();
                            }
                            ctx.contabilidad_asiento.Remove(entA);
                            ctx.SaveChanges();
                        }
                        else
                        {
                            var cont = ctx.contabilidad_contadores.Find(1);
                            cont.cnt_aisento_preview += 1;
                            cnt = cont.cnt_aisento_preview;
                            ctx.SaveChanges();
                        }

                        var ent = new contabilidad_asiento()
                        {
                            fechaEmision = FechaSistema.Date,
                            mesRelacion = ficha.PeriodoMes,
                            anoRelacion = ficha.PeriodoAno,
                            descripcion = ficha.DescripcionDocumentoRef,
                            tipoAsiento = (int)ficha.TipoAsiento,
                            autoGenerado = "N",
                            estaAnulado = "N",
                            estaProcesado = "N",
                            numeroComprobante = cnt,
                            renglones = 1,
                            tipoDocumento = ficha.DescTipoDocumento,
                            idTipoDocumento = ficha.IdTipoDocumento,
                            reglaIntegracionCod = "",
                            reglaIntegracionDesc = "",
                            importe = ficha.Importe
                        };
                        ctx.contabilidad_asiento.Add(ent);
                        ctx.SaveChanges();

                        var entDoc = new contabilidad_asiento_documento()
                        {
                            idAsiento = ent.id,
                            documento = ficha.DocumentoRef,
                            fecha = ficha.FechaDocumentoRef,
                            descripcion = ficha.DescripcionDocumentoRef,
                            signo = 1,
                            incluir="S",
                        };
                        ctx.contabilidad_asiento_documento.Add(entDoc);
                        ctx.SaveChanges();

                        var reng = 0;
                        foreach (var it in ficha.Ctas)
                        {
                            reng += 1;
                            var entDet = new contabilidad_asiento_detalle()
                            {
                                idAsiento = ent.id,
                                idAsientoDocumento = entDoc.id,
                                idPlanCta = it.Id,
                                numRenglon = reng,
                                codigoCta = it.codigo,
                                descripcionCta = it.Descripcion,
                                montoDebe = it.MontoDebe,
                                montoHaber = it.MontoHaber,
                                naturalezaCta= (it.Naturaleza == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora ? "D" : "A"),
                            };
                            ctx.contabilidad_asiento_detalle.Add(entDet);
                            ctx.SaveChanges();
                        }

                        ts.Complete();
                        result.Id = ent.id;
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

        public ResultadoId Contable_Asiento_Insertar(DTO.Contable.Asiento.Insertar ficha)
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

                            if (ficha.IdAsientoPreview != -1)
                            {
                                var entA = ctx.contabilidad_asiento.Find(ficha.IdAsientoPreview);
                                var entADoc = ctx.contabilidad_asiento_documento.Where(d => d.idAsiento == ficha.IdAsientoPreview).ToList();
                                var entADet = ctx.contabilidad_asiento_detalle.Where(d => d.idAsiento == ficha.IdAsientoPreview).ToList();

                                foreach (var dt in entADet)
                                {
                                    ctx.contabilidad_asiento_detalle.Remove(dt);
                                    ctx.SaveChanges();
                                }
                                foreach (var doc in entADoc)
                                {
                                    ctx.contabilidad_asiento_documento.Remove(doc);
                                    ctx.SaveChanges();
                                }
                                ctx.contabilidad_asiento.Remove(entA);
                                ctx.SaveChanges();
                            }

                            int cnt = 0;
                            var cont = ctx.contabilidad_contadores.Find(1);
                            cont.cnt_aisento += 1;
                            cnt = cont.cnt_aisento;
                            ctx.SaveChanges();

                            var ent = new contabilidad_asiento()
                            {
                                fechaEmision = FechaSistema.Date,
                                mesRelacion = ficha.PeriodoMes,
                                anoRelacion = ficha.PeriodoAno,
                                descripcion = ficha.DescripcionDocumentoRef,
                                tipoAsiento = (int)ficha.TipoAsiento,
                                autoGenerado = "N",
                                estaAnulado = "N",
                                estaProcesado = "S",
                                numeroComprobante = cnt,
                                renglones = 1,
                                tipoDocumento = ficha.DescTipoDocumento,
                                idTipoDocumento = ficha.IdTipoDocumento,
                                reglaIntegracionCod = "",
                                reglaIntegracionDesc = "",
                                importe = ficha.Importe
                            };
                            ctx.contabilidad_asiento.Add(ent);
                            ctx.SaveChanges();

                            var entDoc = new contabilidad_asiento_documento()
                            {
                                idAsiento = ent.id,
                                documento = ficha.DocumentoRef,
                                fecha = ficha.FechaDocumentoRef,
                                descripcion = ficha.DescripcionDocumentoRef,
                                signo = 1,
                                incluir = "S",
                            };
                            ctx.contabilidad_asiento_documento.Add(entDoc);
                            ctx.SaveChanges();

                            var reng = 0;
                            foreach (var it in ficha.Ctas)
                            {
                                reng += 1;
                                var entDet = new contabilidad_asiento_detalle()
                                {
                                    idAsiento = ent.id,
                                    idAsientoDocumento = entDoc.id,
                                    idPlanCta = it.Id,
                                    numRenglon = reng,
                                    codigoCta = it.codigo,
                                    descripcionCta = it.Descripcion,
                                    montoDebe = it.MontoDebe,
                                    montoHaber = it.MontoHaber,
                                    naturalezaCta = (it.Naturaleza == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora ? "D" : "A"),
                                };
                                ctx.contabilidad_asiento_detalle.Add(entDet);
                                ctx.SaveChanges();

                                var entAsientoResumen = new contabilidad_asiento_resumen()
                                {
                                    idAsiento = ent.id,
                                    idPlanCta = it.Id,
                                    codigoCta = it.codigo,
                                    descripcionCta = it.Descripcion,
                                    montoDebe = it.MontoDebe,
                                    montoHaber = it.MontoHaber
                                };
                                ctx.contabilidad_asiento_resumen.Add(entAsientoResumen);
                                ctx.SaveChanges();

                                var entPlanCta = ctx.contabilidad_plancta.Find(it.Id);
                                entPlanCta.debe += it.MontoDebe;
                                entPlanCta.haber += it.MontoHaber;
                                ctx.SaveChanges();

                                var nivel = entPlanCta.nivel;
                                if (nivel >= 1)
                                {
                                    var entNiv = entPlanCta;
                                    for (var nv = nivel; nv > 1; nv--)
                                    {
                                        entNiv = entNiv.contabilidad_plancta2;
                                        entNiv.debe += it.MontoDebe;
                                        entNiv.haber += it.MontoHaber;
                                        ctx.SaveChanges();
                                    }
                                }
                            }

                            ctx.SaveChanges();
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

        public ResultadoId Contable_Asiento_Editar(DTO.Contable.Asiento.Insertar ficha)
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
                            var entA = ctx.contabilidad_asiento.Find(ficha.IdAsientoEditado);
                            var entADoc = ctx.contabilidad_asiento_documento.Where(d => d.idAsiento == ficha.IdAsientoEditado).ToList();
                            var entADet = ctx.contabilidad_asiento_detalle.Where(d => d.idAsiento == ficha.IdAsientoEditado).ToList();
                            var entARes = ctx.contabilidad_asiento_resumen.Where(d => d.idAsiento == ficha.IdAsientoEditado).ToList();
                            int cnt = entA.numeroComprobante;

                            foreach (var rs in entARes)
                            {
                                ctx.contabilidad_asiento_resumen.Remove(rs);
                                ctx.SaveChanges();
                            }

                            foreach (var dt in entADet)
                            {
                                var debe = dt.montoDebe;
                                var haber = dt.montoHaber;
                                var entDt = dt.contabilidad_plancta;
                                var nivel = entDt.nivel;
                                entDt.debe -= debe;
                                entDt.haber -= haber;
                                ctx.SaveChanges();

                                if (nivel >= 1)
                                {
                                    var entNiv = entDt;
                                    for (var nv = nivel; nv > 1; nv--)
                                    {
                                        entNiv = entNiv.contabilidad_plancta2;
                                        entNiv.debe -= debe;
                                        entNiv.haber -= haber;
                                        ctx.SaveChanges();
                                    }
                                }
                                ctx.contabilidad_asiento_detalle.Remove(dt);
                            }

                            foreach (var doc in entADoc)
                            {
                                ctx.contabilidad_asiento_documento.Remove(doc);
                            }
                            ctx.contabilidad_asiento.Remove(entA);

                            //
                            var ent = new contabilidad_asiento()
                            {
                                fechaEmision = FechaSistema.Date,
                                mesRelacion = ficha.PeriodoMes,
                                anoRelacion = ficha.PeriodoAno,
                                descripcion = ficha.DescripcionDocumentoRef,
                                tipoAsiento = (int)ficha.TipoAsiento,
                                autoGenerado = "N",
                                estaAnulado = "N",
                                estaProcesado = "S",
                                numeroComprobante = cnt,
                                renglones = 1,
                                tipoDocumento = ficha.DescTipoDocumento,
                                idTipoDocumento = ficha.IdTipoDocumento,
                                reglaIntegracionCod = "",
                                reglaIntegracionDesc = "",
                                importe = ficha.Importe
                            };
                            ctx.contabilidad_asiento.Add(ent);
                            ctx.SaveChanges();

                            var entDoc = new contabilidad_asiento_documento()
                            {
                                idAsiento = ent.id,
                                documento = ficha.DocumentoRef,
                                fecha = ficha.FechaDocumentoRef,
                                descripcion = ficha.DescripcionDocumentoRef,
                                signo = 1,
                                incluir = "S",
                            };
                            ctx.contabilidad_asiento_documento.Add(entDoc);
                            ctx.SaveChanges();

                            var reng = 0;
                            foreach (var it in ficha.Ctas)
                            {
                                reng += 1;
                                var entDet = new contabilidad_asiento_detalle()
                                {
                                    idAsiento = ent.id,
                                    idAsientoDocumento = entDoc.id,
                                    idPlanCta = it.Id,
                                    numRenglon = reng,
                                    codigoCta = it.codigo,
                                    descripcionCta = it.Descripcion,
                                    montoDebe = it.MontoDebe,
                                    montoHaber = it.MontoHaber,
                                    naturalezaCta = (it.Naturaleza == DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora ? "D" : "A"),
                                };
                                ctx.contabilidad_asiento_detalle.Add(entDet);
                                ctx.SaveChanges();

                                var entAsientoResumen = new contabilidad_asiento_resumen()
                                {
                                    idAsiento = ent.id,
                                    idPlanCta = it.Id,
                                    codigoCta = it.codigo,
                                    descripcionCta = it.Descripcion,
                                    montoDebe = it.MontoDebe,
                                    montoHaber = it.MontoHaber
                                };
                                ctx.contabilidad_asiento_resumen.Add(entAsientoResumen);
                                ctx.SaveChanges();

                                var entPlanCta = ctx.contabilidad_plancta.Find(it.Id);
                                entPlanCta.debe += it.MontoDebe;
                                entPlanCta.haber += it.MontoHaber;
                                ctx.SaveChanges();

                                var nivel = entPlanCta.nivel;
                                if (nivel >= 1)
                                {
                                    var entNiv = entPlanCta;
                                    for (var nv = nivel; nv > 1; nv--)
                                    {
                                        entNiv = entNiv.contabilidad_plancta2;
                                        entNiv.debe += it.MontoDebe;
                                        entNiv.haber += it.MontoHaber;
                                        ctx.SaveChanges();
                                    }
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

        public Resultado Contable_Asiento_Anular_Preview(int idAsiento)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = ctx.contabilidad_asiento.Find(idAsiento);
                        ent.estaAnulado = "S";
                        ctx.SaveChanges();
                        ts.Complete();
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

        public Resultado Contable_Asiento_Anular(int idAsiento)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = ctx.Database.BeginTransaction())
                    {

                        try
                        {

                            var ent = ctx.contabilidad_asiento.Find(idAsiento);
                            ent.estaAnulado = "S";
                            ctx.SaveChanges();

                            var list = ctx.contabilidad_asiento_detalle.Where(d => d.idAsiento == idAsiento).ToList();
                            foreach (var cta in list)
                            {
                                cta.contabilidad_plancta.debe -= cta.montoDebe;
                                cta.contabilidad_plancta.haber -= cta.montoHaber;
                                ctx.SaveChanges();

                                var debe = cta.montoDebe;
                                var haber = cta.montoHaber;
                                var entDt = cta.contabilidad_plancta;
                                var nivel = entDt.nivel;

                                if (nivel >= 1)
                                {
                                    var entNiv = entDt;
                                    for (var nv = nivel; nv > 1; nv--)
                                    {
                                        entNiv = entNiv.contabilidad_plancta2;
                                        entNiv.debe -= debe;
                                        entNiv.haber -= haber;
                                        ctx.SaveChanges();
                                    }
                                }
                            }

                            ts.Commit();
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
            }

            return result;
        }


        public Resultado Contable_Asiento_VerificarAnular(int idAsiento)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_asiento.Find(idAsiento);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] ASIENTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    if (ent.estaAnulado == "S")
                    {
                        result.Mensaje = "ASIENTO YA ANULADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    if (ent.autoGenerado == "S")
                    {
                        result.Mensaje = "ASIENTO ES AUTO-GENERADO, SE RECOMIENDA IR AL MANAGER DE INTEGRACION";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    if (ent.estaProcesado == "S")
                    {
                        var entPeriodo = ctx.contabilidad_periodo.Where(d => d.estatusCierre == "").FirstOrDefault();
                        if (entPeriodo == null)
                        {
                            result.Mensaje = "NO HAY PERIODO ACTIVO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
                        }

                        if (ent.mesRelacion == entPeriodo.mes && ent.anoRelacion == entPeriodo.ano)
                        {
                        }
                        else
                        {
                            result.Mensaje = "PROBLEMA AL INTENTAR ANULAR ASIENTO" + Environment.NewLine + "ASIENTO NO CORRESPONDE AL PERIODO ACTUAL";
                            result.Result = DTO.EnumResult.isError;
                            return result;
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

        public Resultado Contable_Asiento_VerificarEditar(int idAsiento)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_asiento.Find(idAsiento);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] ASIENTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    if (ent.estaAnulado == "S")
                    {
                        result.Mensaje = "ASIENTO ANULADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    if (ent.estaProcesado == "S")
                    {
                        var entPeriodo = ctx.contabilidad_periodo.Where(d => d.estatusCierre == "").FirstOrDefault();
                        if (entPeriodo == null)
                        {
                            result.Mensaje = "NO HAY PERIODO ACTIVO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
                        }

                        if (ent.mesRelacion == entPeriodo.mes && ent.anoRelacion == entPeriodo.ano)
                        {
                        }
                        else
                        {
                            result.Mensaje = "PROBLEMA AL INTENTAR EDITAR ASIENTO"+Environment.NewLine+"ASIENTO NO CORRESPONDE AL PERIODO ACTUAL";
                            result.Result = DTO.EnumResult.isError;
                            return result;
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