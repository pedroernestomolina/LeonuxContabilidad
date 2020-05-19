using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public interface IVendedorServicio
    {

        ResultadoEntidad<DTO.Vendedores.Vendedor.Ficha> Vendedor_Get_ById(string auto);
        ResultadoLista<DTO.Vendedores.Vendedor.Resumen> Vendedor_Lista();

    }

}