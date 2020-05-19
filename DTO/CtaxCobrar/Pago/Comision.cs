using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Pago
{

    public class Comision
    {

        public int IdClaveRelMedioPago { get; set; }
        public string DocCxc_Id { get; set; }
        public DateTime DocCxc_Fecha { get; set; }
        public DateTime DocCxc_FechaRecepcion { get; set; }
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
