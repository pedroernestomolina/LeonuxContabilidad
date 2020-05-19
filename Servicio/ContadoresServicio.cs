using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio
{

    public partial class MiServicio : IServicio
    {
        public DTO.ResultadoEntidad<DTO.Contable.Contador.Ficha> Contable_Contadores_Get()
        {
            return provider.Contable_Contadores_Get();
        }
    }

}