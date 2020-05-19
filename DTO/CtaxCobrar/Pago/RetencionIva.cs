using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Pago
{

    public class RetencionIva
    {

        public string DocumentoId { get; set; }
        public string DocumentoNro { get; set; }
        public DateTime DocumentoFecha { get; set; }
        public string DocumentoControl { get; set; }
        public decimal DocumentoTasaIva { get; set; }
        public Enumerados.TipoDoc DocumentoTipo { get; set; }
        public string ComprobanteNro { get; set; }
        public DateTime DeFecha { get; set; }
        public decimal MontoExcento { get; set; }
        public decimal MontoBase { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal TasaRetencion { get; set; }
        public decimal MontoRetencion { get; set; }

    }

}
