using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Pago
{

    public class DocumentoCxC
    {

        public string autoId { get; set; }
        public string DocumentoNumero { get; set; }
        public DateTime DocumentoFecha { get; set; }
        public decimal DocumentoTotal { get; set; }
        public Enumerados.TipoDoc DocumentoTipo { get; set; }
        public DateTime fechaRecepcion { get; set; }
        public int ToleranciaDias { get; set; }
        public decimal ComisionPorc { get; set; }
        public decimal CastigoPorc { get; set; }
        public Enumerados.Operacion TipoOeracion { get; set; }
        public decimal MontoAbonado { get; set; }

    }

}