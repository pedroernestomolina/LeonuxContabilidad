using DTO;
using EntityMySQL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProviderMySql
{

    public partial class Provider : IProvider.InfraEstructura
    {

        public DTO.ResultadoLista<DTO.Contable.Integracion.Resumen> Contable_Integracion_Lista(DTO.Contable.Integracion.Filtro filt)
        {
            var result = new ResultadoLista<DTO.Contable.Integracion.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_integraciones.ToList();
                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Contable.Integracion.Resumen
                            {
                                Id = d.id,
                                Fecha=d.fecha,
                                DesdeFecha=d.desde,
                                HastaFecha=d.hasta,
                                Descripcion = d.descripcion,
                                ModuloAfecta= d.contabilidad_reglas_integracion.descripcion,
                                EstaAnulado = d.estaAnulado == "S" ? true : false,
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

        public Resultado Contable_Integracion_Anular(int id)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = ctx.Database.BeginTransaction())
                    {
                        var ent = ctx.contabilidad_integraciones.Find(id);
                        ent.estaAnulado = "S";
                        ctx.SaveChanges();

                        var idAsiento = ent.idAsiento;
                        var entAsiento = ctx.contabilidad_asiento.Find(idAsiento);
                        entAsiento.estaAnulado = "S";
                        ctx.SaveChanges();

                        var list = ctx.contabilidad_asiento_resumen.Where(d=> d.idAsiento==idAsiento).ToList();
                        foreach (var cta in list)
                        {
                            var mdebe = cta.montoDebe;
                            var mhaber = cta.montoHaber;
                            cta.contabilidad_plancta.debe -= cta.montoDebe;
                            cta.contabilidad_plancta.haber -= cta.montoHaber ;
                            ctx.SaveChanges();

                            var nivel = cta.contabilidad_plancta.nivel;
                            if (nivel >= 1)
                            {
                                var entNiv = cta.contabilidad_plancta;
                                for (var nv = nivel; nv > 1; nv--)
                                {
                                    entNiv = entNiv.contabilidad_plancta2;
                                    entNiv.debe -= mdebe ;
                                    entNiv.haber -= mhaber ;
                                    ctx.SaveChanges();
                                }
                            }
                        }

                        var doc = ctx.contabilidad_asiento_docadm.Where(d => d.idAsiento == idAsiento).ToList();
                        foreach (var it in doc) 
                        {
                            var tipDoc = (DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento)it.tipoDoc;

                            if (tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Venta)
                            {
                                var entVenta = ctx.ventas.Find(it.autoDoc);
                                entVenta.estatus_cierre_contable = "0";
                                ctx.SaveChanges();
                            }
                            if (tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Compra)
                            {
                                var entCompra = ctx.compras.Find(it.autoDoc);
                                entCompra.estatus_cierre_contable = "0";
                                ctx.SaveChanges();
                            }
                            if (tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.MovBanco)
                            {
                                var entMovBanco = ctx.bancos_movimientos.Find(it.autoDoc);
                                entMovBanco.estatus_cierre_contable = "0";
                                ctx.SaveChanges();
                            }
                            if (tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjuste ||
                                tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorCargo ||
                                tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAjustePorDescargo ||
                                tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvAutoConsumo ||
                                tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.InvCargo)
                            {
                                var entMovInv = ctx.productos_movimientos.Find(it.autoDoc);
                                entMovInv.estatus_cierre_contable = "0";
                                ctx.SaveChanges();
                            }

                            if (tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.Pago)
                            {
                                var entRecPago = ctx.cxp_recibos.Find(it.autoDoc);
                                var autoPago = entRecPago.auto_cxp;
                                var entPago = ctx.cxp.Find(autoPago);
                                entPago.estatus_cierre_contable = "0";
                                ctx.SaveChanges();
                            }

                            if (tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIva ||
                                tipDoc == DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento.RetencionIslr)
                            {
                                var entRetencion = ctx.compras_retenciones.Find(it.autoDoc);
                                entRetencion.estatus_cierre_contable = "0";
                                ctx.SaveChanges();
                            }
                        }

                        ts.Commit();
                    }
                }
            }

            catch (DbEntityValidationException e)
            {
                var ms = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        ms += ve.ErrorMessage+Environment.NewLine;
                    }
                }
                result.Mensaje = ms;
                result.Result = DTO.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public Resultado Contable_Integracion_VerificarAnular(int id)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_integraciones.Find(id);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] INTEGRACION NO ENCONTRADA";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    if (ent.estaAnulado=="S")
                    {
                        result.Mensaje = "REGISTRO YA ANULADO";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    if (ent.contabilidad_asiento.estaProcesado == "S")
                    {
                        var entPeriodo = ctx.contabilidad_periodo.Where(d => d.estatusCierre == "").FirstOrDefault();
                        if (entPeriodo == null)
                        {
                            result.Mensaje = "NO HAY PERIODO ACTIVO";
                            result.Result = DTO.EnumResult.isError;
                            return result;
                        }

                        if (ent.contabilidad_asiento.mesRelacion == entPeriodo.mes && ent.contabilidad_asiento.anoRelacion == entPeriodo.ano)
                        {
                        }
                        else
                        {
                            result.Mensaje = "ASIENTO NO CORRESPONDE AL PERIODO ACTUAL";
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

        public ResultadoEntidad<DTO.Contable.Integracion.Ficha> Contable_Integracion_GetById(int id)
        {
            var result = new ResultadoEntidad<DTO.Contable.Integracion.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var d = ctx.contabilidad_integraciones.Find(id);
                    if (d == null)
                    {
                        result.Mensaje = "[ ID ] INTEGRACION NO ENCONTRADA";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var r = new DTO.Contable.Integracion.Ficha()
                    {
                        Id = d.id,
                        IdAsiento=d.idAsiento, 
                        Fecha = d.fecha,
                        DesdeFecha = d.desde,
                        HastaFecha = d.hasta,
                        Descripcion = d.descripcion,
                        ModuloAfecta = d.contabilidad_reglas_integracion.descripcion,
                        EstaAnulado = d.estaAnulado == "S" ? true : false,
                    };

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

        public ResultadoEntidad<DTO.Contable.Integracion.Ficha> Contable_Integracion_GetByIdAsiento(int idAsiento)
        {
            var result = new ResultadoEntidad<DTO.Contable.Integracion.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var d = ctx.contabilidad_integraciones.FirstOrDefault(f=> f.idAsiento ==idAsiento);
                    if (d == null)
                    {
                        result.Mensaje = "[ ID ] INTEGRACION NO ENCONTRADA";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var r = new DTO.Contable.Integracion.Ficha()
                    {
                        Id = d.id,
                        IdAsiento = d.idAsiento,
                        Fecha = d.fecha,
                        DesdeFecha = d.desde,
                        HastaFecha = d.hasta,
                        Descripcion = d.descripcion,
                        ModuloAfecta = d.contabilidad_reglas_integracion.descripcion,
                        EstaAnulado = d.estaAnulado == "S" ? true : false,
                    };

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

    }

}