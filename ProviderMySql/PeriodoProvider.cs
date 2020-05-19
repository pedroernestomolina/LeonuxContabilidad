using DTO;
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

        public DTO.ResultadoEntidad<DTO.Contable.Periodo.Actual> Contable_PeridoActual_Get()
        {
            ResultadoEntidad<DTO.Contable.Periodo.Actual> result = new ResultadoEntidad<DTO.Contable.Periodo.Actual>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_periodo.FirstOrDefault(d => (d.estatusCierre == ""));
                    if (q == null)
                    {
                        result.Entidad = null;
                        return result;
                    }

                    var r = new DTO.Contable.Periodo.Actual()
                    {
                        Id = q.id,
                        MesActual = q.mes,
                        AnoActual = q.ano
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

        public ResultadoLista<DTO.Contable.Periodo.CuentaTotales> Contable_Perido_Utilidad()
        {
            var result = new ResultadoLista<DTO.Contable.Periodo.CuentaTotales>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_plancta.Where(d => d.codigo.Length == 1).ToList();
                    if (q == null)
                    {
                        result.Lista = null;
                        return result;
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Contable.Periodo.CuentaTotales()
                            {
                                Id = d.id,
                                Codigo = d.codigo,
                                Descripcion = d.descripcion,
                                Debe = d.debe,
                                Haber = d.haber
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
                result.Lista = null;
            }

            return result;
        }

        public Resultado Contable_Perido_Cerrar(DTO.Contable.Periodo.Cerrar ficha)
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

                            var entListaHistorico = ctx.contabilidad_plancta.ToList();
                            ctx.Configuration.AutoDetectChangesEnabled = false;
                            foreach (var r in entListaHistorico)
                            {
                                var entHist = new contabilidad_historico()
                                {
                                    idCta=r.id,
                                    codigo = r.codigo,
                                    descripcion = r.descripcion,
                                    tipo = r.tipo,
                                    naturaleza = r.naturaleza,
                                    saldoAperura = r.saldoApertura,
                                    saldoAnterior = r.saldoAnterior,
                                    debe = r.debe,
                                    haber = r.haber,
                                    estado = r.estado,
                                    idPadre = r.idPadre,
                                    nivel = r.nivel,
                                    debeAcumulado = r.debeAcumulado,
                                    haberAcumulado = r.haberAcumulado,
                                    mesHistorico = ficha.MesActual,
                                    anoHistorico = ficha.AnoActual,
                                };
                                ctx.contabilidad_historico.Add(entHist);
                                ctx.SaveChanges();
                            }
                            ctx.Configuration.AutoDetectChangesEnabled = true;

                            var entPeriodo = ctx.contabilidad_periodo.Find(ficha.IdPeriodoActual);
                            entPeriodo.estatusCierre = "S";
                            entPeriodo.utilidad = ficha.UtilidadPeriodo;
                            entPeriodo.utilidad_acumulada = ficha.UtilidadAcumulada;
                            ctx.SaveChanges();

                            var mes = ficha.MesActual;
                            var ano = ficha.AnoActual;
                            if (ficha.MesActual == 12)
                            {
                                mes = 1;
                                ano = ano + 1;
                            }
                            else
                            {
                                mes += 1;
                            }

                            var entPeriodoNuevo = new contabilidad_periodo()
                            {
                                mes = mes,
                                ano = ano,
                                estatusCierre = "",
                            };
                            ctx.contabilidad_periodo.Add(entPeriodoNuevo);
                            ctx.SaveChanges();

                            var ent = ctx.contabilidad_plancta.ToList();
                            foreach (var r in ent)
                            {
                                // PARA REVERSO DEL CIERRE, SE GUARDA 
                                r.rdebe = r.debe;
                                r.rhaber = r.haber;
                                r.rdebeAcumulado = r.debeAcumulado;
                                r.rhaberAcumulado = r.haberAcumulado;
                                r.rsaldoAnterior = r.saldoAnterior;
                                r.rsaldoApertura = r.saldoApertura;
                                //


                                ////LIMPIAR LAS CUENTAS REALES
                                //r.debeAcumulado += r.debe;
                                //r.haberAcumulado += r.haber;
                                //if (r.codigo.Substring(0, 1) == "1" || r.codigo.Substring(0, 1) == "2" || r.codigo.Substring(0, 1) == "3")
                                //{
                                //    var saldoFinal = r.saldoAnterior + r.debe + r.haber;
                                //    r.saldoAnterior = saldoFinal;
                                //}
                                //r.debe = 0.0m;
                                //r.haber = 0.0m;


                                ////LIMPIAR LAS CUENTAS REALES
                                //if (r.codigo.Substring(0, 1) == "1" || r.codigo.Substring(0, 1) == "2" || r.codigo.Substring(0, 1) == "3")
                                //{
                                //    //var saldoFinal = r.saldoAnterior + r.debe + r.haber;
                                //    //r.saldoAnterior = saldoFinal;
                                //}
                                //else
                                //{
                                //    r.debeAcumulado += r.debe;
                                //    r.haberAcumulado += r.haber;
                                //    r.debe = 0.0m;
                                //    r.haber = 0.0m;
                                //}


                                //LIMPIAR LAS CUENTAS REALES
                                r.debeAcumulado += r.debe;
                                r.haberAcumulado += r.haber;
                                //var saldoFinal = r.saldoAnterior + r.debe + r.haber;
                                var saldoFinal = r.saldoAnterior + (r.debe - r.haber);
                                r.saldoAnterior = saldoFinal;
                                r.debe = 0.0m;
                                r.haber = 0.0m;
                                ctx.SaveChanges();
                            }

                            ////ASIGNAR UTILIDAD DEL PERIODO A LA CUENTA DE AJUSTE DEL PATRIMONIO
                            //var entCtaCierre = ctx.contabilidad_plancta.Find(ficha.IdCtaCierre);
                            //entCtaCierre.saldoAnterior += (ficha.UtilidadPeriodo * (-1));
                            //ctx.SaveChanges();

                            //var nivel = entCtaCierre.nivel;
                            //if (nivel >= 1)
                            //{
                            //    var entNiv = entCtaCierre;
                            //    for (var nv = nivel; nv > 1; nv--)
                            //    {
                            //        entNiv = entNiv.contabilidad_plancta2;
                            //        entNiv.saldoAnterior += (ficha.UtilidadPeriodo * (-1));
                            //        ctx.SaveChanges();
                            //    }
                            //}

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

        public Resultado Contable_Periodo_VerificaSiHayMovimientos(int idPeriodo)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    var entPeriodo = ctx.contabilidad_periodo.Find(idPeriodo);
                    var mPeriodo = entPeriodo.mes;
                    var aPeriodo = entPeriodo.ano;

                    var list = ctx.contabilidad_asiento.Where(d =>
                        d.mesRelacion == mPeriodo &&
                        d.anoRelacion == aPeriodo &&
                        d.estaAnulado == "N" &&
                        d.estaProcesado == "S"
                        ).ToList();

                    if (list != null)
                    {
                        if (list.Count > 0)
                        {
                            result.Mensaje = "HAY MOVIMIENTOS PROCESADOS EN ESTE PERIODO";
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

        public Resultado Contable_Perido_Reversar(int IdPeriodoActual)
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
                            var entPeriodoActual = ctx.contabilidad_periodo.Find(IdPeriodoActual);
                            if (entPeriodoActual == null)
                            {
                                result.Mensaje = "[ ID ] PERIODO NO ENCONTRADO";
                                result.Result = EnumResult.isError;
                                return result;
                            }

                            var entPeriodos = ctx.contabilidad_periodo.OrderByDescending(d => d.id).ToList();
                            if (entPeriodos.Count == 1)
                            {
                                result.Mensaje = "NO HAY PERIODOS QUE REVERSAR";
                                result.Result = EnumResult.isError;
                                return result;
                            }

                            var entPeriodoAnt = entPeriodos.Where(d => d.estatusCierre == "S").FirstOrDefault();
                            if (entPeriodoAnt == null)
                            {
                                result.Mensaje = "NO HAY PERIODO ANTERIOR A REVERSAR";
                                result.Result = EnumResult.isError;
                                return result;
                            }

                            var entCtas = ctx.contabilidad_plancta.ToList();
                            foreach (var r in entCtas)
                            {
                                r.debe = r.rdebe;
                                r.haber = r.rhaber;
                                r.debeAcumulado = r.rdebeAcumulado;
                                r.haberAcumulado = r.rhaberAcumulado;
                                r.saldoAnterior = r.rsaldoAnterior;
                                r.saldoApertura = r.rsaldoApertura;
                                ctx.SaveChanges();
                            }

                            ctx.contabilidad_periodo.Remove(entPeriodoActual);
                            entPeriodoAnt.estatusCierre = "";
                            entPeriodoAnt.utilidad =0.0m;
                            entPeriodoAnt.utilidad_acumulada = 0.0m;
                            ctx.SaveChanges();

                            var entHistorico = ctx.contabilidad_historico.Where(d =>
                                d.mesHistorico == entPeriodoAnt.mes &&
                                d.anoHistorico == entPeriodoAnt.ano
                                ).ToList();
                            ctx.Configuration.AutoDetectChangesEnabled = false;
                            foreach (var r in entHistorico)
                            {
                                ctx.contabilidad_historico.Remove(r);
                                ctx.SaveChanges();
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

        public ResultadoLista<DTO.Contable.Periodo.Ficha> Contable_Periodo_Lista()
        {
            var result = new ResultadoLista<DTO.Contable.Periodo.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_periodo.Where(p=>p.estatusCierre=="S").ToList();
                    if (q == null)
                    {
                        result.Lista = null;
                        return result;
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Contable.Periodo.Ficha ()
                            {
                                Id = d.id,
                                AnoActual = d.ano,
                                MesActual=d.mes,
                                IsCerrado= true,
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
                result.Lista = null;
            }

            return result;
        }

        public ResultadoLista<DTO.Contable.Periodo.Ficha> Contable_Utilidad_Acumulada()
        {
            var result = new ResultadoLista<DTO.Contable.Periodo.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_periodo.Where(d=>d.estatusCierre=="S").ToList();
                    if (q == null)
                    {
                        result.Lista = null;
                        return result;
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Contable.Periodo.Ficha ()
                            {
                                Id = d.id,
                                MesActual=d.mes, 
                                AnoActual=d.ano,
                                Utilidad=d.utilidad_acumulada,
                                IsCerrado=true
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
                result.Lista = null;
            }

            return result;
        }

    }

}