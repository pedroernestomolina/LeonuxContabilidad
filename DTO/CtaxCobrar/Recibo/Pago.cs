using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Recibo
{

    public class Pago
    {

        public decimal MontoPorRetenciones { get; set; }
        public decimal MontoPorDescuento { get; set; }
        public decimal MontoPorAnticipos { get; set; }
        public Medio MedioPago { get; set; }

    }

}
