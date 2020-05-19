using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.Asiento
{
    public class FichaDetalle
    {
        public OOB.Cuenta.Ficha Cuenta { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }
        public int Renglon { get; set; }
    }
}
