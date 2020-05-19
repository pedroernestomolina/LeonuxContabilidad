using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public interface IClienteServicio
    {

        ResultadoEntidad<DTO.Clientes.Cliente.Ficha> Cliente_Get_ById(string auto);
        ResultadoLista<DTO.Clientes.Cliente.Resumen> Cliente_Lista(DTO.Clientes.Cliente.Filtro filtro);

    }

}
