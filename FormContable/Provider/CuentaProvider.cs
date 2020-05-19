using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoLista<OOB.Contable.Cuenta.Movimiento> Cuenta_GetMovimiento(OOB.Contable.Cuenta.Filtro filt)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Contable.Cuenta.Movimiento>();
            try
            {
                var filtDto = new DTO.Contable.Cuenta.Filtro() { IdCta = filt.Cta.Id, Desde = filt.Desde, Hasta = filt.Hasta };
                var resultDTO = _servicio.Contable_Cuenta_GetMovimiento(filtDto);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    result.Mensaje = resultDTO.Mensaje;
                    result.Result = OOB.Resultado.EnumResult.isError;
                    return result;
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Contable.Cuenta.Movimiento()
                        {
                            TipoDocumento = it.tipoDocumento,
                            DocumentoRef = it.docRef,
                            DescripcionDoc = it.docRefDescripcion,
                            FechaDoc = it.docRefFecha,
                            MontoDebe = it.montoDebe,
                            MontoHaber = it.montoHaber,
                            Signo = it.signo
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Contable.Cuenta.Movimiento>();
                    result.cntRegistro = 0;
                }

            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }

            return result;
        }

        public OOB.Resultado.ResultadoLista<OOB.Contable.Cuenta.Balance> Cuenta_GetBalance(OOB.Contable.Cuenta.Filtro filt)
        {
            var result = new OOB.Resultado.ResultadoLista<OOB.Contable.Cuenta.Balance>();
            try
            {
                var filtDto = new DTO.Contable.Cuenta.Filtro() { IdCta = filt.Cta.Id, Desde = filt.Desde, Hasta = filt.Hasta };
                var resultDTO = _servicio.Contable_Cuenta_GetBalance(filtDto);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    result.Mensaje = resultDTO.Mensaje;
                    result.Result = OOB.Resultado.EnumResult.isError;
                    return result;
                }

                if (resultDTO.Lista != null)
                {
                    result.cntRegistro = resultDTO.cntRegistro;
                    result.Lista = resultDTO.Lista.Select(it =>
                    {
                        return new OOB.Contable.Cuenta.Balance()
                        {
                            IdAsiento= it.idAsiento,
                            Comprobante=it.Comprobante.ToString().Trim().PadLeft(10,'0'),
                            Fecha=it.Fecha,
                            MontoDebe=it.MontoDebe,
                            MontoHaber=it.MontoHaber,
                            TipoDocumento=it.TipoDocumento,
                            TipoAsiento= (OOB.Contable.Asiento.Enumerados.Tipo) it.TipoAsiento 
                        };
                    }).ToList();
                }
                else
                {
                    result.Lista = new List<OOB.Contable.Cuenta.Balance>();
                    result.cntRegistro = 0;
                }

            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.EnumResult.isError;
            }

            return result;
        }

        public OOB.Resultado.ResultadoEntidad<decimal> Cuenta_GetSaldoAl(OOB.Contable.PlanCta.Ficha cta, DateTime al)
        {
            var result = new OOB.Resultado.ResultadoEntidad<decimal>(); 
            try
            {
                var ficha = new DTO.Contable.Cuenta.SaldoAl() { Al=al, idCta=cta.Id };
                var resultDTO = _servicio.Contable_Cuenta_GetSaldoAl(ficha);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    result.Mensaje = resultDTO.Mensaje;
                    result.Result = OOB.Resultado.EnumResult.isError;
                    return result;
                }

                result.Entidad=resultDTO.Entidad;
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