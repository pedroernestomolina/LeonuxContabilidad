using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Pago
{

    public class Comision
    {

        public int ClaveIdRelMedioPago { get; set; }
        public string IdDocCxc { get; set; }
        public DateTime FechaDocCxc { get; set; }
        public DateTime FechaRecepcionMercDocCxc { get; set; }
        public decimal MontoDocCxc { get; set; }
        public decimal ComisionPorc { get; set; }
        public decimal CastigoPorc { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal MontoRecibido { get; set; }
        public int ToleranciaDias { get; set; }
        public decimal TotalComision { get; set; }
        public bool IsCastigado { get; set; }
        public int DiasTranscurridos { get; set; }
        
    }

}