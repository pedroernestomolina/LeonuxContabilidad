using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoLista<OOB.Contable.Integracion.Ficha> Integracion_Lista(OOB.Contable.Integracion.Filtro filt)
        {
            var rt = new OOB.Resultado.ResultadoLista<OOB.Contable.Integracion.Ficha>();
            try
            {
                var filtDTO = new DTO.Contable.Integracion.Filtro();
                var resultDTO = _servicio.Contable_Integracion_Lista(filtDTO);
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
                        return new OOB.Contable.Integracion.Ficha()
                        {
                            Id = it.Id,
                            Descripcion = it.Descripcion,
                            Fecha = it.Fecha,
                            DesdeFecha = it.DesdeFecha,
                            HastaFecha = it.HastaFecha,
                            ModuloAfecta = it.ModuloAfecta,
                            EstaAnulado = it.EstaAnulado,
                        };
                    }).ToList();
                }
                else
                {
                    rt.cntRegistro = 0;
                    rt.Lista = new List<OOB.Contable.Integracion.Ficha>();
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.EnumResult.isError;
            }
            return rt;
        }

        public OOB.Resultado.Resultado Integracion_Anular(OOB.Contable.Integracion.Ficha ficha)
        {
            var rt = new OOB.Resultado.Resultado();

            var resultDTO = _servicio.Contable_Integracion_Anular(ficha.Id);
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                rt.Mensaje = resultDTO.Mensaje;
                rt.Result = OOB.Resultado.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado.ResultadoEntidad<OOB.Contable.Integracion.Ficha> Integracion_GetBy(OOB.Contable.Integracion.Ficha Integracion, OOB.Contable.Asiento.Ficha Asiento)
        {
            var rt = new OOB.Resultado.ResultadoEntidad<OOB.Contable.Integracion.Ficha>();
            try
            {
                var filtroDTO = new DTO.Contable.Integracion.FiltroID();
                if (Integracion != null)
                    filtroDTO.Id = Integracion.Id;
                if (Asiento != null)
                    filtroDTO.IdAsiento = Asiento.Id;

                var resultDTO = _servicio.Contable_Integracion_GetBy(filtroDTO);
                if (resultDTO.Result == DTO.EnumResult.isError)
                {
                    rt.Mensaje = resultDTO.Mensaje;
                    rt.Result = OOB.Resultado.EnumResult.isError;
                    return rt;
                }

                rt.Entidad = new OOB.Contable.Integracion.Ficha()
                {
                    Id = resultDTO.Entidad.Id,
                    IdAsiento = resultDTO.Entidad.IdAsiento,
                    Descripcion = resultDTO.Entidad.Descripcion,
                    Fecha = resultDTO.Entidad.Fecha,
                    DesdeFecha = resultDTO.Entidad.DesdeFecha,
                    HastaFecha = resultDTO.Entidad.HastaFecha,
                    ModuloAfecta = resultDTO.Entidad.ModuloAfecta,
                    EstaAnulado = resultDTO.Entidad.EstaAnulado,
                };

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