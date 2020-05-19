using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Integraciones
{

    public class Resumen
    {

        public string CodigoCta { get; set; }
        public string DescripcionCta { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }

    }

}