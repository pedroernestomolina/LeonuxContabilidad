using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoEntidad<DTO.Venta.Ficha> Venta_GetById(string autoDoc)
        {
            return provider.Venta_GetById(autoDoc);
        }

        public DTO.ResultadoEntidad<bool> Venta_Documento_Existe(string autoDoc)
        {
            return provider.Venta_Documento_Existe(autoDoc);
        }

        public DTO.ResultadoEntidad<bool> Venta_Documento_Aplico_RetencionIva(string autoDoc)
        {
            return provider.Venta_Documento_Aplico_RetencionIva(autoDoc);
        }

        public DTO.ResultadoEntidad<bool> Venta_Documento_Aplico_RetencionIva_BuscaPorNumeroDocVenta(string numDocVenta)
        {
            return provider.Venta_Documento_Aplico_RetencionIva_BuscaPorNumeroDocVenta(numDocVenta);
        }

    }

}