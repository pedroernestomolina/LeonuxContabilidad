using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.Balances.General
{

    public class Filtro : OOB.Reportes.Filtro
    {

        public decimal UtilidadPeriodo { get; set; }
        public decimal SaldoCtaCierre { get; set; }
        public OOB.Contable.PlanCta.Ficha CuentaCierreMes { get; set; }
        public OOB.Contable.Periodo.Ficha Desde { get; set; }
        public OOB.Contable.Periodo.Ficha Hasta { get; set; }

    }

}