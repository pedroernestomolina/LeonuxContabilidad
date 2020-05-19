using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.PlanCta
{

    public class Saldos
    {

        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal SaldoAnterior { get; set; }

        public Saldos()
        {
            Debe = 0.0m;
            Haber = 0.0m;
            SaldoAnterior = 0.0m;
        }
    }

}
