using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Clientes
{
    
    public class Enumerados
    {

        public enum PorEstatus { SinDefinir = -1, Activo = 1, Inactivo, Todos };
        public enum PorSaldo { SinDefinir = -1, Pendiente = 1};

    }

}
