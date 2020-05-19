using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {
        public OOB.Resultado.ResultadoEntidad<DateTime> Servidor_GetFecha()
        {
            var result = new OOB.Resultado.ResultadoEntidad<DateTime>();
            var resultDTO = _servicio.Servidor_Get_Fecha();
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = resultDTO.Entidad;
            return result;
        }

        public OOB.Resultado.ResultadoEntidad<string> Servidor_GetDatos()
        {
            var result = new OOB.Resultado.ResultadoEntidad<string>();
            var resultDTO = _servicio.Servidor_Get_Datos();
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = resultDTO.Entidad;
            return result;
        }

    }

}