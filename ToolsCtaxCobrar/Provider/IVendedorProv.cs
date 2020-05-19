using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public interface IVendedorProv
    {

        ResultadoEntidad<OOB.Vendedores.Vendedor.Ficha> Vendedor_Get_ById(string auto);
        ResultadoLista<OOB.Vendedores.Vendedor.Ficha> Vendedor_Lista();

    }

}
