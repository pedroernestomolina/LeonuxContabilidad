using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IProvider
{

    public interface IVenta
    {

        ResultadoEntidad<DTO.Venta.Ficha> Venta_GetById(string autoDoc);
        ResultadoEntidad<bool> Venta_Documento_Existe(string autoDoc);
        ResultadoEntidad<bool> Venta_Documento_Aplico_RetencionIva(string autoDoc);
        ResultadoEntidad<bool> Venta_Documento_Aplico_RetencionIva_BuscaPorNumeroDocVenta(string numDocVenta);

    }

}