using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoEntidad<DTO.Vendedores.Vendedor.Ficha> Vendedor_Get_ById(string auto)
        {
            return provider.Vendedores_Vendedor_GetById (auto);
        }

        public DTO.ResultadoLista<DTO.Vendedores.Vendedor.Resumen> Vendedor_Lista()
        {
            return provider.Vendedores_Vendedor_Lista();
        }

    }

}