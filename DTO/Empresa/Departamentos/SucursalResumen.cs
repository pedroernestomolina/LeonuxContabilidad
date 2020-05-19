using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Empresa.Departamentos
{

    public class SucursalResumen
    {

        public DTO.Cuenta.Resumen CtaInventario { get; set; }
        public DTO.Cuenta.Resumen CtaCosto { get; set; }
        public DTO.Cuenta.Resumen CtaVenta { get; set; }
        public DTO.Cuenta.Resumen CtaMerma { get; set; }
        public DTO.Cuenta.Resumen CtaConcumoInterno { get; set; }

    }

}