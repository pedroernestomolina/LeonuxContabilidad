using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoEntidad<DTO.Clientes.Cliente.Ficha> Cliente_Get_ById(string auto)
        {
            return provider.Cliente_Get_ById(auto);
        }

        public DTO.ResultadoLista<DTO.Clientes.Cliente.Resumen> Cliente_Lista(DTO.Clientes.Cliente.Filtro filtro)
        {
            return provider.Cliente_Lista(filtro);
        }

    }

}