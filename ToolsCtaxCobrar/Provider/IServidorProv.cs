using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{

    public interface IServidorProv
    {

        ResultadoEntidad<DateTime> Servidor_GetFecha();
        ResultadoEntidad<String> Servidor_GetDatos();

    }

}