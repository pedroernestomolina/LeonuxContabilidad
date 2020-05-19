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

        public DTO.ResultadoLista<DTO.Contable.TipoDocumento.Ficha> Contable_TipoDocumento_Lista()
        {
            return provider.Contable_TipoDocumento_Lista();
        }

        public DTO.ResultadoId Contable_TipoDocumento_Insertar(DTO.Contable.TipoDocumento.Insertar ficha)
        {
            return provider.Contable_TipoDocumento_Insertar(ficha);
        }

        public DTO.Resultado Contable_TipoDocumento_Editar(DTO.Contable.TipoDocumento.Editar ficha)
        {
            return provider.Contable_TipoDocumento_Editar(ficha);
        }

        public DTO.Resultado Contable_TipoDocumento_Eliminar(DTO.Contable.TipoDocumento.Eliminar ficha)
        {
            var result = new Resultado();
            var r01 = provider.Contable_TipoDocumento_VerificarEliminar(ficha.Id);
            if (r01.Result == EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = EnumResult.isError;
                return result;
            }
            return provider.Contable_TipoDocumento_Eliminar(ficha);
        }

        public DTO.ResultadoEntidad<DTO.Contable.TipoDocumento.Ficha> Contable_TipoDocumento_Get(int id)
        {
            return provider.Contable_TipoDocumento_Get(id);
        }

    }

}