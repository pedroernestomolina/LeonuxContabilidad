using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoLista<DTO.Contable.Integracion.Resumen> Contable_Integracion_Lista(DTO.Contable.Integracion.Filtro filt)
        {
            return provider.Contable_Integracion_Lista(filt);
        }

        public DTO.Resultado Contable_Integracion_Anular(int id)
        {
            var r01 = provider.Contable_Integracion_VerificarAnular(id);
            if (r01.Result == DTO.EnumResult.isError)
            {
                return r01;
            }

            return provider.Contable_Integracion_Anular(id);
        }
      
        public DTO.ResultadoEntidad<DTO.Contable.Integracion.Ficha> Contable_Integracion_GetBy(DTO.Contable.Integracion.FiltroID filtro)
        {
            var r= new DTO.ResultadoEntidad<DTO.Contable.Integracion.Ficha>();
 
            if (filtro.Id.HasValue) 
            {
                return provider.Contable_Integracion_GetById(filtro.Id.Value);
            }
            else if (filtro.IdAsiento.HasValue)
            {
                return provider.Contable_Integracion_GetByIdAsiento(filtro.IdAsiento.Value);
            }
            else
            {
                r.Mensaje = "FILTRO DE BUSQUEDA NO DEFINIDO";
                r.Result = DTO.EnumResult.isError;
                return r;
            }
        }

    }

}