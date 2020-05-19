using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{

    public partial class MiServicio : IServicio
    {

        public DTO.ResultadoEntidad<DTO.Productos.Movimiento.Ficha> Productos_Movimiento_GetById(string autoDoc)
        {
            return provider.Productos_Movimiento_GetById(autoDoc);
        }

    }

}
