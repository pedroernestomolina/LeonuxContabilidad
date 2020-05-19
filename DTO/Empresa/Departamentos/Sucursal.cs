using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Empresa.Departamentos
{

    public class Sucursal
    {

        public DTO.Cuenta.Ficha CtaInventario { get; set; }
        public DTO.Cuenta.Ficha CtaCosto { get; set; }
        public DTO.Cuenta.Ficha CtaVenta { get; set; }
        public DTO.Cuenta.Ficha CtaMerma { get; set; }
        public DTO.Cuenta.Ficha CtaConsumoInterno { get; set; }

    }

}
