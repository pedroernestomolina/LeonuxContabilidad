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

        public DTO.ResultadoLista<DTO.Contable.Cuenta.Movimiento> Contable_Cuenta_GetMovimiento(DTO.Contable.Cuenta.Filtro filt)
        {
            var result = new ResultadoLista<DTO.Contable.Cuenta.Movimiento>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_asiento_detalle.Where(d => d.idPlanCta == filt.IdCta).
                        Where(f => f.contabilidad_asiento_documento.fecha >= filt.Desde && f.contabilidad_asiento_documento.fecha <= filt.Hasta).
                        Where(a => a.contabilidad_asiento.estaProcesado=="S" && a.contabilidad_asiento.estaAnulado == "N").
                        ToList();

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Contable.Cuenta.Movimiento
                            {
                                tipoDocumento = d.contabilidad_asiento.tipoDocumento,
                                docRef = d.contabilidad_asiento_documento.documento,
                                docRefDescripcion = d.contabilidad_asiento_documento.descripcion,
                                docRefFecha = d.contabilidad_asiento_documento.fecha,
                                montoDebe = d.montoDebe,
                                montoHaber = d.montoHaber,
                                signo = d.contabilidad_asiento_documento.signo
                            };
                        })
                        .ToList();
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

        public ResultadoLista<DTO.Contable.Cuenta.Balance> Contable_Cuenta_GetBalance(DTO.Contable.Cuenta.Filtro filt)
        {
            var result = new ResultadoLista<DTO.Contable.Cuenta.Balance>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.contabilidad_asiento_detalle.Where(f => f.idPlanCta == filt.IdCta).
                        Where(f => f.contabilidad_asiento_documento.fecha >= filt.Desde && f.contabilidad_asiento_documento.fecha <= filt.Hasta).
                        Where(f => f.contabilidad_asiento.estaProcesado=="S" && f.contabilidad_asiento.estaAnulado == "N").
                        Select(s => s.contabilidad_asiento).
                        GroupBy(g => new { g.id }).
                        ToList();

                    if (q.Count > 0)
                    {
                        var list = new List<DTO.Contable.Cuenta.Balance>();
                        foreach (var a in q)
                        {
                            var xlist = ctx.contabilidad_asiento_resumen.Where(w => w.idAsiento == a.Key.id && w.idPlanCta == filt.IdCta).ToList();
                            foreach (var d in xlist) 
                            {
                                if (d != null)
                                {
                                    var r = new DTO.Contable.Cuenta.Balance
                                    {
                                        idAsiento = d.contabilidad_asiento.id,
                                        Comprobante = d.contabilidad_asiento.numeroComprobante,
                                        Fecha = d.contabilidad_asiento.fechaEmision,
                                        TipoAsiento = (DTO.Contable.Asiento.Enumerados.Tipo)d.contabilidad_asiento.tipoAsiento,
                                        TipoDocumento = d.contabilidad_asiento.tipoDocumento,
                                        MontoDebe = d.montoDebe,
                                        MontoHaber = d.montoHaber,
                                    };
                                    list.Add(r);
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

        public ResultadoEntidad<decimal> Contable_Cuenta_GetSaldoAl(int id, DateTime fecha)
        {
            var result = new ResultadoEntidad<Decimal>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {

                    var ent = ctx.contabilidad_plancta.Find(id);
                    if (ent == null) 
                    {
                        result.Mensaje = "[ ID ] Cuenta No Encontrada";
                        result.Result = DTO.EnumResult.isError;
                        return result;
                    }

                    var q = ctx.contabilidad_asiento_detalle.Where(d => d.idPlanCta == id).
                        Where(f => f.contabilidad_asiento_documento.fecha <= fecha).
                        Where(a => a.contabilidad_asiento.estaProcesado == "S" && a.contabilidad_asiento.estaAnulado == "N").
                        ToList();

                    var saldo = 0.0m;
                    var saldoInicial = ent.saldoApertura;
                    if (q.Count > 0)
                    {
                        var debe=q.Sum(m => m.montoDebe);
                        var haber = q.Sum(m => m.montoHaber);
                        saldo = debe - haber;
                    }
                    saldo += saldoInicial;
                    result.Entidad=saldo;
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