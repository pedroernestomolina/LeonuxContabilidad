using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public interface IBancoProv
    {

        //BANCO
        ResultadoLista<OOB.Bancos.Banco.Ficha> Bancos_Banco_Lista();
        ResultadoLista<OOB.Bancos.Banco.Ficha> Bancos_Banco_Lista_Resumen();
        ResultadoEntidad<OOB.Bancos.Banco.Ficha> Bancos_Banco_GetById(string autoBanco);

    }

}
