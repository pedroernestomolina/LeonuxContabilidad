using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Reportes.Balances.GananciaPerdida
{

    public class Ficha
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public DTO.Contable.PlanCta.Enumerados.Naturaleza Naturaleza { get; set; }

    }

}
