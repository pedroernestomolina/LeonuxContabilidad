using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.PlanCta
{

    public class Saldos
    {
        public decimal Apertura { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal Anterior { get; set; }
     
        public Saldos()
        {
            Apertura = 0.0m;
            Debe = 0.0m;
            Haber = 0.0m;
            Anterior= 0.0m;
        }
    }

}