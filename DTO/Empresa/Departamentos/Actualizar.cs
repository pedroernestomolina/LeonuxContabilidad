using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Empresa.Departamentos
{

    public class Actualizar
    {

        public string IdDepartamento { get; set; }
        public int IdSucursal { get; set; }
        public int IdCtaInv { get; set; }
        public int IdCtaCosto { get; set; }
        public int IdCtaVenta { get; set; }
        public int IdCtaMerma { get; set; }
        public int IdCtaConsumoInterno { get; set; }

    }

}