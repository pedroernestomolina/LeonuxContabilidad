using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Cuenta
{

    public class Ficha
    {
        public int IdPlanCta { get; set; }
        public string CodigoCta { get; set; }
        public string DescripcionCta { get; set; }
        public OOB.Contable.PlanCta.Enumerados.Naturaleza NaturalezaCta { get; set; }

        public string Cuenta
        {
            get 
            {
                return CodigoCta.Trim() + Environment.NewLine + DescripcionCta.Trim();
            }
        }

        public Ficha ()
        {
            IdPlanCta = -1;
            CodigoCta = "";
            DescripcionCta = "";
            NaturalezaCta = Contable.PlanCta.Enumerados.Naturaleza.SinDefinir;
        }
    }

}