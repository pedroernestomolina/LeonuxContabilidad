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

        class HistGeneral
        {
            public int idCta { get; set; }
            public string codigo { get; set; }
            public string nombre { get; set; }
            public decimal debe { get; set; }
            public decimal haber { get; set; }
            public decimal saldoAnterior { get; set; }
            public int nivel { get; set; }
            public int? idPadre { get; set; }
        }

        public ResultadoLista<DTO.Reportes.PlanCta.Maestro.Ficha> Reporte_PlanCta_Maestro()
        {
            var result = new ResultadoLista<DTO.Reportes.PlanCta.Maestro.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_plancta.ToList();
                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Reportes.PlanCta.Maestro.Ficha()
                            {
                                Codigo = d.codigo,
                                Nombre = d.descripcion,
                                Nivel = d.nivel,
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

        public ResultadoLista<DTO.Reportes.Balances.Comprobacion.Ficha> Reporte_Balance_Comprobacion(DTO.Reportes.Balances.Comprobacion.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.Reportes.Balances.Comprobacion.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    if (filtro.DesdePeriodo != null && filtro.HastaPeriodo != null)
                    {
                        var q = ctx.contabilidad_historico.Where(h =>
                            h.mesHistorico >= filtro.DesdePeriodo.MesHistorico && h.anoHistorico >= filtro.DesdePeriodo.AnoHistorico &&
                            h.mesHistorico <= filtro.HastaPeriodo.MesHistorico && h.anoHistorico <= filtro.HastaPeriodo.AnoHistorico).
                            GroupBy(g => new { key = g.idCta, idCta = g.idCta, codigo = g.codigo, nombre = g.descripcion, nivel = g.nivel, naturaleza = g.naturaleza }).
                            Select(s => new
                            {
                                id = s.Key.idCta,
                                codigo = s.Key.codigo,
                                nombre = s.Key.nombre,
                                nivel = s.Key.nivel,
                                naturaleza = s.Key.naturaleza,
                                debe = s.Sum(x => x.debe),
                                haber = s.Sum(x => x.haber),
                                saldoInicial = s.Sum(x => x.saldoAperura),
                                debeAcumulado = s.Sum(x => x.debeAcumulado),
                                haberAcumulado = s.Sum(x => x.haberAcumulado)
                            }).
                            ToList();

                        if (q.Count > 0)
                        {
                            var list = q.Select(d =>
                            {
                                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                if (d.naturaleza == "A")
                                {
                                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                }

                                return new DTO.Reportes.Balances.Comprobacion.Ficha()
                                {
                                    Id = d.id,
                                    Codigo = d.codigo,
                                    Nombre = d.nombre,
                                    Nivel = d.nivel,
                                    Debe = d.debe,
                                    Haber = d.haber,
                                    SaldoInicial = d.saldoInicial,
                                    Naturaleza = nat,
                                    DebeAcumulado = d.debeAcumulado,
                                    HaberAcumulado = d.haberAcumulado
                                };
                            }).ToList();

                            result.cntRegistro = list.Count();
                            result.Lista = list;
                        }
                    }
                    else
                    {
                        var q = ctx.contabilidad_plancta.ToList();
                        if (q.Count > 0)
                        {
                            var list = q.Select(d =>
                            {
                                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                if (d.naturaleza == "A")
                                {
                                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                }

                                return new DTO.Reportes.Balances.Comprobacion.Ficha()
                                {
                                    Id = d.id,
                                    Codigo = d.codigo,
                                    Nombre = d.descripcion,
                                    Nivel = d.nivel,
                                    Debe = d.debe,
                                    Haber = d.haber,
                                    SaldoInicial = d.saldoAnterior,
                                    Naturaleza = nat,
                                    DebeAcumulado = d.debeAcumulado,
                                    HaberAcumulado = d.haberAcumulado
                                };
                            }).ToList();

                            result.cntRegistro = list.Count();
                            result.Lista = list;
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

        public ResultadoLista<DTO.Reportes.Balances.GananciaPerdida.Ficha> Reporte_Balance_GananciaPerdida(DTO.Reportes.Balances.GananciaPerdida.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.Reportes.Balances.GananciaPerdida.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    if (filtro.DesdePerido != null && filtro.HastaPeriodo != null)
                    {
                        var q = ctx.contabilidad_historico.Where(r =>
                            (r.mesHistorico >= filtro.DesdePerido.MesHistorico && r.anoHistorico >= filtro.DesdePerido.AnoHistorico &&
                            r.mesHistorico <= filtro.HastaPeriodo.MesHistorico && r.anoHistorico <= filtro.HastaPeriodo.AnoHistorico) &&
                            (r.codigo.Substring(0, 1) == "4" ||
                            r.codigo.Substring(0, 1) == "5" ||
                            r.codigo.Substring(0, 1) == "6" ||
                            r.codigo.Substring(0, 1) == "7" ||
                            r.codigo.Substring(0, 1) == "8"
                            ) &&
                            r.nivel == 6).
                            GroupBy(g => new
                            {
                                key = g.idCta,
                                codigo = g.codigo,
                                nombre = g.descripcion,
                                naturaleza = g.naturaleza
                            }).
                            Select(s => new
                            {
                                codigo = s.Key.codigo,
                                nombre = s.Key.nombre,
                                naturaleza = s.Key.naturaleza,
                                debe = s.Sum(t => t.debe),
                                haber = s.Sum(t => t.haber)
                            }).
                            ToList();

                        if (q.Count > 0)
                        {
                            var list = q.Select(d =>
                            {
                                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                if (d.naturaleza == "A")
                                {
                                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                }

                                return new DTO.Reportes.Balances.GananciaPerdida.Ficha
                                {
                                    Codigo = d.codigo,
                                    Nombre = d.nombre,
                                    Debe = d.debe,
                                    Haber = d.haber,
                                    Naturaleza = nat
                                };
                            }).ToList();

                            result.cntRegistro = list.Count();
                            result.Lista = list;
                        }
                    }
                    else
                    {
                        var q = ctx.contabilidad_plancta.Where(r =>
                            (r.codigo.Substring(0, 1) == "4" ||
                            r.codigo.Substring(0, 1) == "5" ||
                            r.codigo.Substring(0, 1) == "6" ||
                            r.codigo.Substring(0, 1) == "7" ||
                            r.codigo.Substring(0, 1) == "8"
                            ) &&
                            r.nivel == 6).ToList();

                        if (q.Count > 0)
                        {
                            var list = q.Select(d =>
                            {
                                var nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Deudora;
                                if (d.naturaleza == "A")
                                {
                                    nat = DTO.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;
                                }

                                return new DTO.Reportes.Balances.GananciaPerdida.Ficha
                                {
                                    Codigo = d.codigo,
                                    Nombre = d.descripcion,
                                    Debe = d.debe,
                                    Haber = d.haber,
                                    Naturaleza = nat
                                };
                            }).ToList();

                            result.cntRegistro = list.Count();
                            result.Lista = list;
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

        public ResultadoLista<DTO.Reportes.Balances.General.Ficha> Reporte_Balance_General(DTO.Reportes.Balances.General.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.Reportes.Balances.General.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    if (filtro.DesdePeriodo == null && filtro.HastaPeriodo == null)
                    {
                        var q = ctx.contabilidad_plancta.Where(t => (t.codigo.Substring(0, 1) == "1" || t.codigo.Substring(0, 1) == "2" || t.codigo.Substring(0, 1) == "3"))
                            .ToList();

                        if (q.Count > 0)
                        {
                            var entCtaCierre = q.FirstOrDefault(c => c.id == filtro.IdCtaCierre);
                            if (entCtaCierre != null)
                            {
                                var xmov = (entCtaCierre.debe - entCtaCierre.haber);

                                entCtaCierre.saldoAnterior = filtro.UtilidadPeriodo;
                                var nivel = entCtaCierre.nivel;
                                if (nivel >= 1)
                                {
                                    var entNiv = entCtaCierre;
                                    for (var nv = nivel; nv > 1; nv--)
                                    {
                                        entNiv = entNiv.contabilidad_plancta2;
                                        entNiv.saldoAnterior += (filtro.UtilidadPeriodo + filtro.SaldoCtaCierre)+ xmov;
                                    }
                                }
                            }

                            var xlista = q.Where(s => s.codigo.Length>=9 && s.codigo.Substring(0, 9) == "3.1.1.03.").ToList();

                            var list = q.Select(d =>
                            {
                                return new DTO.Reportes.Balances.General.Ficha()
                                {
                                    Id = d.id,
                                    Codigo = d.codigo,
                                    Nombre = d.descripcion,
                                    Nivel = d.nivel,
                                    SaldoAnterior = d.saldoAnterior,
                                    Debe = d.debe,
                                    Haber = d.haber,
                                };
                            }).ToList();

                            result.cntRegistro = list.Count();
                            result.Lista = list;
                        }
                    }
                    else
                    {
                        var q = ctx.contabilidad_historico.Where(t =>
                            (t.mesHistorico >= filtro.DesdePeriodo.MesHistorico && t.anoHistorico >= filtro.DesdePeriodo.AnoHistorico &&
                            t.mesHistorico <= filtro.HastaPeriodo.MesHistorico && t.anoHistorico <= filtro.HastaPeriodo.AnoHistorico) &&
                            (t.codigo.Substring(0, 1) == "1" || t.codigo.Substring(0, 1) == "2" || t.codigo.Substring(0, 1) == "3")).
                            GroupBy(g => new
                            {
                                key = g.idCta,
                                idCta = g.idCta,
                                idPadre = g.idPadre,
                                codigo = g.codigo,
                                nombre = g.descripcion,
                                nivel = g.nivel
                            }).
                            Select(s => new HistGeneral
                            {
                                idCta = s.Key.idCta,
                                idPadre = s.Key.idPadre,
                                codigo = s.Key.codigo,
                                nombre = s.Key.nombre,
                                nivel = s.Key.nivel,
                                debe = s.Sum(t => t.debe),
                                haber = s.Sum(t => t.haber),
                                saldoAnterior = s.Where(t => t.mesHistorico == filtro.DesdePeriodo.MesHistorico && t.anoHistorico == filtro.DesdePeriodo.AnoHistorico).FirstOrDefault().saldoAnterior
                            })
                            .ToList();

                        if (q.Count > 0)
                        {

                            ////ASIGNAR UTILIDAD DEL PERIODO A LA CUENTA DE AJUSTE DEL PATRIMONIO
                            var entCtaCierre = q.FirstOrDefault(c => c.idCta == filtro.IdCtaCierre);
                            if (entCtaCierre != null)
                            {
                                //var xmov = entCtaCierre.saldoAnterior 


                                var xmov = entCtaCierre.saldoAnterior + (entCtaCierre.debe - entCtaCierre.haber);
                                entCtaCierre.debe = 0.0m;
                                entCtaCierre.haber = 0.0m;


                                entCtaCierre.saldoAnterior = (filtro.UtilidadPeriodo * (-1));
                                var nivel = entCtaCierre.nivel;
                                if (nivel >= 1)
                                {
                                    var entNiv = entCtaCierre;
                                    for (var nv = nivel; nv > 1; nv--)
                                    {
                                        entNiv = q.FirstOrDefault(c => c.idCta == entNiv.idPadre);  //entNiv.contabilidad_plancta2;
                                        if (entNiv != null)
                                        {
                                            var xmv = (entCtaCierre.debe - entCtaCierre.haber);
                                            xmv = 0;
                                            entNiv.saldoAnterior -= xmov;
                                            entNiv.saldoAnterior += ((filtro.UtilidadPeriodo * (-1))+xmv);
                                           // entNiv.saldoAnterior += (filtro.UtilidadPeriodo * (-1));
                                        }
                                    }
                                }
                            }

                            var list = q.Select(d =>
                            {
                                return new DTO.Reportes.Balances.General.Ficha()
                                {
                                    Id = d.idCta,
                                    Codigo = d.codigo,
                                    Nombre = d.nombre,
                                    Nivel = d.nivel,
                                    SaldoAnterior = d.saldoAnterior,
                                    Debe = d.debe,
                                    Haber = d.haber,
                                };
                            }).ToList();

                            result.cntRegistro = list.Count();
                            result.Lista = list;
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

        public ResultadoEntidad<DTO.Reportes.Balances.ComprobanteDiario.Ficha> Reporte_Balance_ComprobanteDiario(int idComprobante)
        {
            var result = new ResultadoEntidad<DTO.Reportes.Balances.ComprobanteDiario.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.contabilidad_asiento.Find(idComprobante);
                    if (ent==null)
                    {
                        result.Mensaje = "[ ID ] Comprobante No Encontrado";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                    }

                    var entDet = ctx.contabilidad_asiento_detalle.Where(dt => dt.idAsiento == idComprobante).ToList();
                    var ficha = new DTO.Reportes.Balances.ComprobanteDiario.Ficha() 
                    {
                         ComprobanteNro=ent.numeroComprobante,
                         DeFecha=ent.fechaEmision,
                         Descripcion =ent.descripcion,
                         Importe =ent.importe,
                         Renglones=ent.renglones,
                    };

                    if (entDet.Count > 0)
                    {
                        var list = entDet.Select(d =>
                        {
                            var dt = new DTO.Reportes.Balances.ComprobanteDiario.Detalle()
                            {
                                 Renglon=d.numRenglon,
                                 CodigoCta=d.codigoCta,
                                 DescripcionCta=d.descripcionCta,
                                 Debitos =d.montoDebe,
                                 Creditos=d.montoHaber,
                                 Documento=d.contabilidad_asiento_documento.documento ,
                                 TipoDocumento ="",
                                 Descripcion = d.contabilidad_asiento_documento.descripcion 
                            };
                            return dt;
                        }).ToList();
                        ficha.Detalles = list;
                    }

                    result.Entidad = ficha;
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