using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Cuenta
{

    public class Filtro
    {

        public OOB.Contable.PlanCta.Ficha Cta { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

    }

}