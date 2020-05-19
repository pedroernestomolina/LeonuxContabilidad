using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Provider
{

    public interface ICompraProvider
    {

        //COMPRA
        ResultadoEntidad<OOB.Compra.Compra.Ficha> Compra_Documento_GetById(string autoDoc);
        Resultado Compra_Actualizar(OOB.Compra.Compra.ActualizarData ficha);
        //COMPRA-RETENCION IVA
        ResultadoEntidad<OOB.Compra.RetencionIva.Ficha> Compra_RetencionIva_GetById(string autoDoc);
        //COMPRA-RETENCION ISLR
        ResultadoEntidad<OOB.Compra.RetencionIslr.Ficha> Compra_RetencionIslr_GetById(string autoDoc);
        
    }

}