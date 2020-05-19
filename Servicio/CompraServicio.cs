using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoEntidad<DTO.Compras.Compra.Ficha> Compra_Documento_GetById(string autoDoc)
        {
            return provider.Compras_Compra_GetById(autoDoc);
        }

        public DTO.ResultadoEntidad<DTO.Compras.RetencionIva.Ficha> Compra_RetencionIva_GetById(string autoDoc)
        {
            return provider.Compras_RetencionIva_GetById(autoDoc);
        }

        public DTO.ResultadoEntidad<DTO.Compras.RetencionIslr.Ficha> Compra_RetencionIslr_GetById(string autoDoc)
        {
            return provider.Compras_RetencionIslr_GetById(autoDoc);
        }

        public DTO.Resultado Compra_ActualizarData(DTO.Compras.Compra.ActualizarData ficha)
        {
            return provider.Compras_Compra_ActualizarData(ficha);
        }

    }
}