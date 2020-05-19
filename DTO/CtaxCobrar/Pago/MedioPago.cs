using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Pago
{

    public class MedioPago
    {

        public int IdClave { get; set; }
        public string autoMedioId { get; set; }
        public string autoBancoId { get; set; }
        public string CodigoMedio { get; set; }
        public string DescripcionMedio { get; set; }
        public decimal  MontoRecibido { get; set; }
        public DateTime FechaMovimiento{ get; set; }
        public string Referencia { get; set; }
        public string BancoDescripcion { get; set; }
        public string BancoCodigo { get; set; }
        public string BancoNroCta { get; set; }

    }

}
