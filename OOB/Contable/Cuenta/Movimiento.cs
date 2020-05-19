using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Cuenta
{

    public class Movimiento
    {

        public string TipoDocumento {get; set;}
        public string DocumentoRef { get; set; }
        public string DescripcionDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }
        public int Signo { get; set;}

    }

}