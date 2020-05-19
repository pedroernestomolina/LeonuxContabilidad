using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoLista<OOB.Reportes.PlanCta.Maestro.Ficha> Reportes_PlanCta_Maestro()
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.PlanCta.Maestro.Ficha>();
            try
            {
                var resultDTO = _servicio.Reportes_PlanCta_Maestro();
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(item =>
                    {
                        return new OOB.Reportes.PlanCta.Maestro.Ficha()
                        {
                            Codigo = item.Codigo,
                            Nombre = item.Nombre,
                            Nivel = item.Nivel
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.PlanCta.Maestro.Ficha>();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }

        public OOB.Resultado.ResultadoLista<OOB.Reportes.Balances.Comprobacion.Ficha> Reportes_Balance_Comprobacion(OOB.Reportes.Balances.Comprobacion.Filtro filtro)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.Balances.Comprobacion.Ficha>();
            try
            {
                var filtroDTO = new DTO.Reportes.Balances.Comprobacion.Filtro();
                if (filtro != null)
                {
                    if (filtro.Desde != null && filtro.Hasta != null)
                    {
                        filtroDTO.DesdePeriodo = new DTO.Reportes.Balances.Historico()
                        {
                            MesHistorico = filtro.Desde.MesActual,
                            AnoHistorico = filtro.Desde.AnoActual
                        };
                        filtroDTO.HastaPeriodo = new DTO.Reportes.Balances.Historico()
                        {
                            MesHistorico = filtro.Hasta.MesActual,
                            AnoHistorico = filtro.Hasta.AnoActual
                        };
                    }
                }

                var resultDTO = _servicio.Reportes_Balances_Comprobacion(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.OrderBy(o => o.Codigo).Select(item =>
                    {
                        return new OOB.Reportes.Balances.Comprobacion.Ficha()
                        {
                            Codigo = item.Codigo,
                            Nombre = item.Nombre,
                            Nivel = item.Nivel,
                            Naturaleza = (OOB.Contable.PlanCta.Enumerados.Naturaleza)item.Naturaleza,
                            Debe = item.Debe,
                            Haber = item.Haber,
                            DebeAcumulado = item.DebeAcumulado,
                            HaberAcumulado = item.HaberAcumulado,
                            SaldoApertura = item.SaldoInicial,
                            IsTotal = false,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.Balances.Comprobacion.Ficha>();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }

        public OOB.Resultado.ResultadoLista<OOB.Reportes.Balances.GananciaPerdida.Ficha> Reportes_Balance_GananciaPerdida(OOB.Reportes.Balances.GananciaPerdida.Filtro filtro)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.Balances.GananciaPerdida.Ficha>();

            try
            {
                var filtroDTO = new DTO.Reportes.Balances.GananciaPerdida.Filtro();
                if (filtro != null)
                {
                    if (filtro.Desde != null && filtro.Hasta != null)
                    {
                        filtroDTO.DesdePerido = new DTO.Reportes.Balances.Historico()
                        {
                            MesHistorico = filtro.Desde.MesActual,
                            AnoHistorico = filtro.Desde.AnoActual
                        };
                        filtroDTO.HastaPeriodo = new DTO.Reportes.Balances.Historico()
                        {
                            MesHistorico = filtro.Hasta.MesActual,
                            AnoHistorico = filtro.Hasta.AnoActual
                        };
                    }
                }
                var resultDTO = _servicio.Reportes_Balances_GananciaPerdida(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.OrderBy(o => o.Codigo).Select(item =>
                    {
                        return new OOB.Reportes.Balances.GananciaPerdida.Ficha()
                        {
                            Codigo = item.Codigo,
                            Nombre = item.Nombre,
                            Debe = item.Debe,
                            Haber = item.Haber,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.Balances.GananciaPerdida.Ficha>();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }

        public OOB.Resultado.ResultadoLista<OOB.Reportes.Balances.General.Ficha> Reportes_Balance_General(OOB.Reportes.Balances.General.Filtro filtro)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Reportes.Balances.General.Ficha>();

            try
            {
                var filtroDTO = new DTO.Reportes.Balances.General.Filtro();
                filtroDTO.IdCtaCierre = filtro.CuentaCierreMes.Id;
                filtroDTO.UtilidadPeriodo = filtro.UtilidadPeriodo;
                filtroDTO.SaldoCtaCierre = filtro.SaldoCtaCierre;

                if (filtro.Desde != null && filtro.Hasta != null)
                {
                    filtroDTO.DesdePeriodo = new DTO.Reportes.Balances.Historico()
                    {
                        MesHistorico = filtro.Desde.MesActual,
                        AnoHistorico = filtro.Desde.AnoActual
                    };
                    filtroDTO.HastaPeriodo = new DTO.Reportes.Balances.Historico()
                    {
                        MesHistorico = filtro.Hasta.MesActual,
                        AnoHistorico = filtro.Hasta.AnoActual
                    };
                }

                var resultDTO = _servicio.Reportes_Balances_General(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.OrderBy(o => o.Codigo).Select(item =>
                    {
                        return new OOB.Reportes.Balances.General.Ficha()
                        {
                            Codigo = item.Codigo,
                            Nombre = item.Nombre,
                            Nivel = item.Nivel,
                            SaldoAnterior = item.SaldoAnterior,
                            Debe = item.Debe,
                            Haber = item.Haber,
                            IsTotal = false,
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Reportes.Balances.General.Ficha>();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Reportes.Balances.ComprobanteDiario.Ficha> Reportes_Balance_ComprobanteDiario(int IdComprobante)
        {
            var result = new OOB.Resultado.ResultadoEntidad<OOB.Reportes.Balances.ComprobanteDiario.Ficha>();

            try
            {
                var resultDTO = _servicio.Reportes_Balances_ComprobanteDiario(IdComprobante);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    throw new Exception(resultDTO.Mensaje);
                }

                var enc = new OOB.Reportes.Balances.ComprobanteDiario.Ficha() 
                {
                    ComprobanteNro= resultDTO.Entidad.ComprobanteNro.ToString().Trim().PadLeft(10,'0') ,
                    DeFecha=resultDTO.Entidad.DeFecha ,
                    Descripcion=resultDTO.Entidad.Descripcion ,
                    Importe =resultDTO.Entidad.Importe ,
                    Renglones =resultDTO.Entidad.Renglones ,
                };
                var det = resultDTO.Entidad.Detalles.Select(dt =>
                {
                    return new OOB.Reportes.Balances.ComprobanteDiario.Detalle()
                    {
                         CodigoCta = dt.CodigoCta,
                         DescripcionCta=dt.DescripcionCta,
                         MontoDebe=dt.Debitos,
                         MontoHaber=dt.Creditos,
                         Renglon =dt.Renglon,
                         Documento =dt.Documento ,
                         Descripcion =dt.Descripcion,
                         TipoDocumento=dt.TipoDocumento,
                    };
                }).ToList();
                enc.Detalles=det;
                result.Entidad = enc;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }

            return result;
        }

    }

}