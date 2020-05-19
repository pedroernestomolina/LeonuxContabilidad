using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.Asiento.Apertura
{
    
    public class InsertarDetalles
    {
        public OOB.Contable.PlanCta.Ficha Cta { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
    }

}
