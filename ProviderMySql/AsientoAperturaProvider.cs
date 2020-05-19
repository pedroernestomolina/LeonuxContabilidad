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

        public ResultadoEntidad<int> Contable_Asiento_Apertura_Get_ID()
        {
            var result = new ResultadoEntidad<int>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var entAsiento = ctx.contabilidad_asiento.FirstOrDefault(d =>
                        (DTO.Contable.Asiento.Enumerados.Tipo)d.tipoAsiento == DTO.Contable.Asiento.Enumerados.Tipo.Apertura
                        && d.estaAnulado == "N");
                    if (entAsiento == null)
                    {
                        result.Mensaje = "ASIENTO DE APERTURA NO ENCONTRADO";
                        result.Entidad = -1;
                        return result;
                    }
                    result.Entidad = entAsiento.id;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = -1;
            }

            return result;
        }

        public ResultadoEntidad<bool> Contable_Asiento_Apertura_IsOk()
        {
            var result = new ResultadoEntidad<bool>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var entAsiento = ctx.contabilidad_asiento.FirstOrDefault(d =>
                        (DTO.Contable.Asiento.Enumerados.Tipo)d.tipoAsiento == DTO.Contable.Asiento.Enumerados.Tipo.Apertura
                        && d.estaAnulado == "N"
                        && d.estaProcesado == "S");

                    if (entAsiento == null)
                    {
                        result.Mensaje = "ASIENTO DE APERTURA TODAVÍA NO PROCESADO";
                        result.Entidad = false;
                        return result;
                    }
                    result.Entidad = true;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = false;
            }

            return result;
        }

        public Resultado Contable_Asiento_Apertura_Preview(DTO.Contable.Asiento.Apertura.Insertar ficha)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();

                        int cnt = 0;
                        if (ficha.Id != -1)
                        {
                            var entA = ctx.contabilidad_asiento.Find(ficha.Id);
                            var entADoc = ctx.contabilidad_asiento_documento.Where(d => d.idAsiento == ficha.Id).ToList();
                            var entADet = ctx.contabilidad_asiento_detalle.Where(d => d.idAsiento == ficha.Id).ToList();
                            cnt = entA.numeroComprobante;

                            foreach (var dt in entADet)
                            {
                                ctx.contabilidad_asiento_detalle.Remove(dt);
                            }
                            foreach (var doc in entADoc)
                            {
                                ctx.contabilidad_asiento_documento.Remove(doc);
                            }
                            ctx.contabilidad_asiento.Remove(entA);
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
                            tipoAsiento = (int)DTO.Contable.Asiento.Enumerados.Tipo.Apertura,
                            autoGenerado = "N",
                            estaAnulado = "N",
                            estaProcesado = "N",
                            numeroComprobante = cnt,
                            renglones = ficha.Ctas.Count(),
                            tipoDocumento = "",
                            idTipoDocumento = null,
                            reglaIntegracionCod = "",
                            reglaIntegracionDesc = "",
                            importe = ficha.Importe
                        };
                        ctx.contabilidad_asiento.Add(ent);
                        ctx.SaveChanges();

                        var entDoc = new contabilidad_asiento_documento()
                        {
                            idAsiento = ent.id,
                            documento = "",
                            fecha = ficha.FechaDocumentoRef,
                            descripcion = ficha.DescripcionDocumentoRef,
                            signo = 1,
                            incluir="S"
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
                            };
                            ctx.contabilidad_asiento_detalle.Add(entDet);
                            ctx.SaveChanges();
                        }

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

        public Resultado Contable_Asiento_Apertura_Insertar(DTO.Contable.Asiento.Apertura.Insertar ficha)
        {
            var result = new Resultado();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        using (var ts = ctx.Database.BeginTransaction())
            //        {

            //            try
            //            {

            //                int cnt = 0;
            //                if (ficha.Id != -1)
            //                {
            //                    var entA = ctx.contabilidad_asiento.Find(ficha.Id);
            //                    var entADoc = ctx.contabilidad_asiento_documento.Where(d => d.idAsiento == ficha.Id).ToList();
            //                    var entADet = ctx.contabilidad_asiento_detalle.Where(d => d.idAsiento == ficha.Id).ToList();
            //                    cnt = entA.numeroComprobante;

            //                    foreach (var dt in entADet)
            //                    {
            //                        ctx.contabilidad_asiento_detalle.Remove(dt);
            //                        ctx.SaveChanges();
            //                    }
            //                    foreach (var doc in entADoc)
            //                    {
            //                        ctx.contabilidad_asiento_documento.Remove(doc);
            //                        ctx.SaveChanges();
            //                    }
            //                    ctx.contabilidad_asiento.Remove(entA);
            //                    ctx.SaveChanges();
            //                }

            //                var FechaSistema = ctx.Database.SqlQuery<DateTime>("select NOW()").FirstOrDefault();
            //                var cont = ctx.contabilidad_contadores.Find(1);
            //                cont.cnt_aisento += 1;
            //                cnt = cont.cnt_aisento;
            //                ctx.SaveChanges();

            //                var ent = new contabilidad_asiento()
            //                {
            //                    fechaEmision = FechaSistema.Date,
            //                    mesRelacion = ficha.PeriodoMes,
            //                    anoRelacion = ficha.PeriodoAno,
            //                    descripcion = ficha.DescripcionDocumentoRef,
            //                    tipoAsiento = (int)DTO.Contable.Asiento.Enumerados.Tipo.Apertura,
            //                    autoGenerado = "N",
            //                    estaAnulado = "N",
            //                    estaProcesado = "S",
            //                    numeroComprobante = cnt,
            //                    renglones = ficha.Ctas.Count(),
            //                    tipoDocumento = "",
            //                    idTipoDocumento = null,
            //                    reglaIntegracionCod = "",
            //                    reglaIntegracionDesc = "",
            //                    importe = ficha.Importe
            //                };
            //                ctx.contabilidad_asiento.Add(ent);
            //                ctx.SaveChanges();

            //                var entDoc = new contabilidad_asiento_documento()
            //                {
            //                    idAsiento = ent.id,
            //                    documento = "",
            //                    fecha = ficha.FechaDocumentoRef,
            //                    descripcion = ficha.DescripcionDocumentoRef,
            //                    signo = 1,
            //                    incluir="S",
            //                };
            //                ctx.contabilidad_asiento_documento.Add(entDoc);
            //                ctx.SaveChanges();

            //                var reng = 0;
            //                foreach (var it in ficha.Ctas)
            //                {
            //                    reng += 1;
            //                    var entDet = new contabilidad_asiento_detalle()
            //                    {
            //                        idAsiento = ent.id,
            //                        idAsientoDocumento = entDoc.id,
            //                        idPlanCta = it.Id,
            //                        numRenglon = reng,
            //                        codigoCta = it.codigo,
            //                        descripcionCta = it.Descripcion,
            //                        montoDebe = it.MontoDebe,
            //                        montoHaber = it.MontoHaber,
            //                    };
            //                    ctx.contabilidad_asiento_detalle.Add(entDet);
            //                    ctx.SaveChanges();

            //                    var entResumen = new contabilidad_asiento_resumen()
            //                    {
            //                        idAsiento = ent.id,
            //                        idPlanCta = it.Id,
            //                        codigoCta = it.codigo,
            //                        descripcionCta = it.Descripcion,
            //                        montoDebe = it.MontoDebe,
            //                        montoHaber = it.MontoHaber
            //                    };
            //                    ctx.contabilidad_asiento_resumen.Add(entResumen);
            //                    ctx.SaveChanges();

            //                    var entPlanCta = ctx.contabilidad_plancta.Find(it.Id);
            //                    entPlanCta.saldoApertura += it.SaldoInicial;
            //                    ctx.SaveChanges();
            //                    var nivel = entPlanCta.nivel;

            //                    if (nivel >= 1)
            //                    {
            //                        var entNiv = entPlanCta;
            //                        for (var nv = nivel; nv > 1; nv--)
            //                        {
            //                            entNiv = entNiv.contabilidad_plancta2;
            //                            entNiv.saldoApertura += it.SaldoInicial;
            //                            ctx.SaveChanges();
            //                        }
            //                    }

            //                }
            //                ts.Commit();
            //            }
            //            catch (Exception ex)
            //            {
            //                throw new Exception(ex.Message);
            //            }
            //            finally
            //            {
            //                ctx.Configuration.AutoDetectChangesEnabled = true;
            //            }
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

        public Resultado Contable_Asiento_Anular_Apertura(int idAsiento)
        {
            var result = new Resultado();

            //try
            //{
            //    using (var ctx = new dBEntities(_cn.ConnectionString))
            //    {
            //        using (var ts = new TransactionScope())
            //        {
            //            var ent = ctx.contabilidad_asiento.Find(idAsiento);
            //            ent.estaAnulado = "S";
            //            ctx.SaveChanges();

            //            var list = ctx.contabilidad_asiento_resumen.Where(d => d.idAsiento == idAsiento).ToList();
            //            foreach (var cta in list)
            //            {
            //                cta.contabilidad_plancta.saldoApertura = 0.0m;
            //                ctx.SaveChanges();

            //                var entDt = cta.contabilidad_plancta;
            //                var nivel = entDt.nivel;

            //                if (nivel >= 1)
            //                {
            //                    var entNiv = entDt;
            //                    for (var nv = nivel; nv > 1; nv--)
            //                    {
            //                        entNiv = entNiv.contabilidad_plancta2;
            //                        entNiv.saldoApertura= 0.0m ;
            //                        ctx.SaveChanges();
            //                    }
            //                }
            //            }

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

    }
}