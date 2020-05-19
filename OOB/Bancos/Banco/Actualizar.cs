using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Bancos.Banco
{

    public class Actualizar
    {

        public string Id { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaContable { get; set; }
        public OOB.Contable.PlanCta.Ficha CtaIGTF { get; set; }

    }

}