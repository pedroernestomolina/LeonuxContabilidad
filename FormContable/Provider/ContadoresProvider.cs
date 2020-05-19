using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public partial class Provider : IProvider
    {

        public OOB.Resultado.ResultadoEntidad<OOB.Contable.Contadores.Ficha> Contadores_Get()
        {
            OOB.Resultado.ResultadoEntidad<OOB.Contable.Contadores.Ficha > result = new OOB.Resultado.ResultadoEntidad<OOB.Contable.Contadores.Ficha >();

            var resultDTO = _servicio.Contable_Contadores_Get ();
            if (resultDTO.Result == DTO.EnumResult.isError)
            {
                result.Result = OOB.Resultado.EnumResult.isError;
                result.Mensaje = resultDTO.Mensaje;
                return result;
            }

            result.Entidad = new OOB.Contable.Contadores.Ficha()
            {
                 CntAsiento = (resultDTO.Entidad.CntAsiento+1).ToString().Trim().PadLeft(10,'0') ,
                 CntAsientoPreview = "PV"+(resultDTO.Entidad.CntAsientoPreview+1).ToString().Trim().PadLeft(8,'0'), 
            };
            return result;
        }

    }

}