using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.CtaxCobrar
{

    public class Enumerados
    {

        public enum CondicionPago { Contado = 0, Credito };
        public enum DocVenta { SinDefinir=-1, Factura=1, NtDebito, NtCredito };

    }

}
