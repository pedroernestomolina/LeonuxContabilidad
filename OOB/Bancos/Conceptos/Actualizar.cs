using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Bancos.Conceptos
{

    public class Actualizar
    {

        public string Id { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaGasto { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaPasivo { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaBanco { get; set; }

    }

}