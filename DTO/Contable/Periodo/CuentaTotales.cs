using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.Periodo
{

    public class CuentaTotales
    {

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }

    }

}
