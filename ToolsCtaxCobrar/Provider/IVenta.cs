using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.Provider
{
    
    public interface IVenta
    {

        ResultadoEntidad<OOB.Venta.Ficha> Venta_GetById(string autoDoc);
        ResultadoEntidad<bool> Venta_Documento_Existe(string autoDoc);
        ResultadoEntidad<bool> Venta_Documento_Aplico_RetencionIva(string autoDoc, string numDocVenta="");

    }

}
