using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoEntidad<DTO.CtaxPagar.Recibo.Ficha> CtaxPagar_Recibo_GetById(string autoRecibo)
        {
            return provider.CtaxPagar_Recibo_GetById(autoRecibo);
        }

    }

}