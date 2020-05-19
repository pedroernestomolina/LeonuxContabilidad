using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoEntidad<OOB.Contable.Periodo.Ficha> Contadores_PeriodoActual_Get()
        {
            OOB.Resultado.ResultadoEntidad<OOB.Contable.Periodo.Ficha> result = new OOB.Resultado.ResultadoEntidad<OOB.Contable.Periodo.Ficha>();

            var resultDTO = _servicio.Contable_PeriodoActual_Get();
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = new OOB.Contable.Periodo.Ficha()
            {
                Id = resultDTO.Entidad.Id,
                AnoActual=resultDTO.Entidad.AnoActual,
                MesActual=resultDTO.Entidad.MesActual
            };
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<decimal> Periodo_Utilidad()
        {
            var result = new OOB.Resultado.ResultadoEntidad<decimal>();

            var resultDTO = _servicio.Contable_Periodo_CalculoUtilidad() ;
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            var utilidad = 0.0m;
            if (resultDTO.Lista != null) 
            {

                var ingresos = 0.0m;
                var costos = 0.0m;
                var gastos = 0.0m;
                var otrosIngresos = 0.0m;
                var otros = 0.0m;

                foreach (var it in resultDTO.Lista )
                {
                    //var saldo = Math.Abs(it.Debe - it.Haber);
                    var saldo = it.Debe - it.Haber;
                    switch (it.Codigo)
                    {
                        case "4":
                            ingresos = saldo;
                            break;
                        case "5":
                            costos = saldo;
                            break;
                        case "6":
                            gastos = saldo;
                            break;
                        case "7":
                            otrosIngresos = saldo;
                            break;
                        case "8":
                            otros = saldo;
                            break;
                    }
                }
                utilidad = ingresos + (costos + gastos + otrosIngresos + otros);
            }
            result.Entidad = utilidad;

            return result;
        }

        public OOB.Resultado.Resultado Periodo_Cerrar(OOB.Contable.Periodo.CerrarMes ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var fichaDTO = new DTO.Contable.Periodo.Cerrar()
            {
                IdCtaCierre = ficha.CuentaCierreMes.Id,
                MesActual = ficha.PeriodoActual.MesActual,
                AnoActual = ficha.PeriodoActual.AnoActual,
                IdPeriodoActual = ficha.PeriodoActual.Id,
                UtilidadPeriodo = ficha.UtilidadPeriodo,
                UtilidadAcumulada = ficha.UtilidadAcumulada,
            };
            var resultDTO = _servicio.Contable_Periodo_CerrarMes(fichaDTO);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            return result;
        }

        public OOB.Resultado.Resultado Periodo_Reversar(OOB.Contable.Periodo.Ficha ficha)
        {
            var result = new OOB.Resultado.Resultado();

            var resultDTO = _servicio.Contable_Periodo_Reversar(ficha.Id);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            return result;
        }

        public OOB.Resultado.ResultadoLista<OOB.Contable.Periodo.Ficha> Periodo_Lista()
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Contable.Periodo.Ficha >();
            try
            {
                var resultDTO = _servicio.Contable_Periodo_Lista();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                if (resultDTO.Lista != null)
                {
                    rt.cntRegistro = resultDTO.cntRegistro;
                    rt.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Contable.Periodo.Ficha()
                        {
                            Id = it.Id,
                            AnoActual=it.AnoActual,
                            MesActual=it.MesActual,
                        };
                    }).ToList();
                }
                else
                {
                    rt.cntRegistro = 0;
                    rt.Lista = new List<OOB.Contable.Periodo.Ficha>();
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }
            return rt;
        }

        public OOB.Resultado.ResultadoEntidad<decimal> Utilidad_Acumulada()
        {
            var rt = new OOB.Resultado.ResultadoEntidad<decimal>() ;
            try
            {
                var resultDTO = _servicio.Contable_Utilidad_Acumulada();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0) 
                    {
                        //rt.Entidad = resultDTO.Lista.Sum(t => t.Utilidad);
                        rt.Entidad = resultDTO.Lista.Last().Utilidad;
                    }
                }
                else
                {
                    rt.Entidad=0;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }
            return rt;
        }

        public OOB.Resultado.ResultadoEntidad<decimal> Utilidad_Acumulada_Hasta_Periodo(OOB.Contable.Periodo.Ficha ficha)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<decimal>();
            try
            {
                var resultDTO = _servicio.Contable_Utilidad_Acumulada();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                if (resultDTO.Lista != null)
                {
                    if (resultDTO.Lista.Count > 0)
                    {
                        //rt.Entidad = resultDTO.Lista.Where(p=>p.MesActual <=ficha.MesActual && p.AnoActual<=ficha.AnoActual).
                        //    Sum(t => t.Utilidad);
                        var rs = resultDTO.Lista.FirstOrDefault(p => p.MesActual == ficha.MesActual && p.AnoActual == ficha.AnoActual);
                        if (rs != null)
                        {
                            rt.Entidad = rs.Utilidad;
                        }
                        else 
                        {
                            rt.Entidad = 0.0m;
                        }
                    }
                }
                else
                {
                    rt.Entidad = 0;
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