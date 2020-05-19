using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Venta
{

    public class Enumerados
    {

        public enum TipoDocumento { SinDefinir=-1, Factura = 1, NDebito, NCredito };
        public enum CondicionPago { Contado = 1, Credito };

    }
}
