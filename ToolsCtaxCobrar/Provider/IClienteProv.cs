using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public interface IClienteProv
    {

        ResultadoEntidad<OOB.Clientes.Cliente.Ficha> Cliente_Get_ById(string auto);
        ResultadoLista<OOB.Clientes.Cliente.Ficha> Cliente_Lista(OOB.Clientes.Cliente.Filtro filtro);

    }

}