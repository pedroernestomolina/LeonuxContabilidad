using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Periodo
{

    public class CerrarMes
    {

        public decimal UtilidadPeriodo { get; set; }
        public decimal UtilidadAcumulada { get; set; }
        public Ficha PeriodoActual { get; set; }
        public OOB.Contable.PlanCta.Ficha  CuentaCierreMes { get; set; }

    }

}