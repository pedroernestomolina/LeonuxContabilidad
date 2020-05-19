using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IProvider
{

    public interface IVendedor
    {

        ResultadoEntidad<DTO.Vendedores.Vendedor.Ficha> Vendedores_Vendedor_GetById(string auto);
        ResultadoLista<DTO.Vendedores.Vendedor.Resumen> Vendedores_Vendedor_Lista();

    }

}