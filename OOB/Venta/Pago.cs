using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Venta
{
    public class Pago
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public decimal Monto { get; set; }
        public string Lote { get; set; }
        public string Referencia { get; set; }
    }
}
