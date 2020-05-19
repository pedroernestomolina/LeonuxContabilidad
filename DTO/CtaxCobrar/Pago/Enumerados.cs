using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Pago
{

    public class Enumerados
    {

        public enum Operacion { SinDefinir = -1, Pago = 1, Abono };
        public enum TipoDoc { SinDefinir = -1, Factura=1, NtDebito, NtCredito };

    }

}