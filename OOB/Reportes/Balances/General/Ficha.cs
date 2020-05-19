using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.Balances.General
{

    public class Ficha
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal SaldoAnterior { get; set; }
        public bool IsTotal { get; set; }

        public decimal SaldoMes
        {
            get
            {
                var saldo = 0.0m;
                //saldo = (SaldoAnterior +Debe + Haber);
                saldo = (SaldoAnterior + (Debe - Haber));
                return saldo;
            }
        }

    }

}
