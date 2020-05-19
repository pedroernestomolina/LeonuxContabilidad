using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public ResultadoLista<DTO.Contable.PlanCta.FichaResumen> Contable_PlanCta_Lista(DTO.Contable.PlanCta.Busqueda busq)
        {
            var result = new ResultadoLista<DTO.Contable.PlanCta.FichaResumen>(); 
          
            if (busq == null)
            {
                result.Mensaje ="OPCIONES DE BUSQUEDA NO DEFINIDA";
                result.Result= EnumResult .isError ;
                return result;
            }

            return provider.Contable_PlanCta_Lista(busq);
        }

        public ResultadoEntidad<DTO.Contable.PlanCta.Ficha> Contable_PlanCta_GetById(int id)
        {
            return provider.Contable_PlanCta_GetById(id);
        }

        public ResultadoId Contable_PlanCta_Insertar(DTO.Contable.PlanCta.Insertar insertar)
        {
            //var result= new ResultadoId();
            //var r01 = provider.Contable_PlanCta_VerificarInsertar(insertar.Codigo);
            //if (r01.Result == EnumResult.isError)
            //{
            //    result.Id = -1;
            //    result.Mensaje = r01.Mensaje;
            //    result.Result = EnumResult.isError;
            //    return result;
            //}
            return provider.Contable_PlanCta_Insertar(insertar);
        }

        public Resultado Contable_PlanCta_Editar(DTO.Contable.PlanCta.Editar editar)
        {
            return provider.Contable_PlanCta_Editar(editar);
        }

        public Resultado Contable_PlanCta_Eliminar(int id)
        {
            var result = new Resultado();
            var r01 = provider.Contable_PlanCta_VerificarEliminar(id);
            if (r01.Result == EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = EnumResult.isError;
                return result;
            }
            return provider.Contable_PlanCta_Eliminar(id);
        }

        public ResultadoEntidad<DTO.Contable.PlanCta.Padre> Contable_PlanCta_GetPadre(string codigoCta)
        {
            return provider.Contable_PlanCta_GetPadre(codigoCta);
        }

    }

}