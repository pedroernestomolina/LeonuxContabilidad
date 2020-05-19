using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Bancos
{

    public class Enumerados
    {
        public enum TipMovimiento { SinDefinir = -1, DEPOSITO = 1, CHEQUE, NOTA_CREDITO, NOTA_DEBITO };
        public enum OrigenMovimiento { SinDefinir = -1, BANCO, CTA_PAGAR }
    }

}