using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Pago
{

    public class MedioPago
    {

        public int IdClave { get; set; }
        public string MedioId { get; set; }
        public string BancoId { get; set; }
        public string MedioCodigo { get; set; }
        public string MedioDescripcion { get; set; }
        public decimal MontoRecibido { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string NroReferencia { get; set; }
        public string BancoDescripcion { get; set; }
        public string BancoCodigo { get; set; }
        public string BancoNroCta { get; set; }

    }

}
