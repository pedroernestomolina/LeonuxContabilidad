using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{

    public partial class MiServicio : IServicio
    {
        
        public DTO.ResultadoEntidad<DateTime> Servidor_Get_Fecha()
        {
            return provider.FechaDelServidor();
        }

        public DTO.ResultadoEntidad<string> Servidor_Get_Datos()
        {
            return provider.DatosDelServidor();
        }

    }

}
