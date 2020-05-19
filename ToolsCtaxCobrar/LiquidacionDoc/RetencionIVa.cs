using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.LiquidacionDoc
{

    public class RetencionIVa
    {

        public decimal MontoExcento { get; set; }
        public decimal MontoBase { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal TasaIva { get; set; }
        public decimal TasaRetencion { get; set; }
        public decimal MontoRetencion { get; set; }
        public string ComprobanteNro { get; set; }
        public string DocumentoNro { get; set; }
        public DateTime FechaEmision { get; set; }
        public string NroControl { get; set; }
        public DateTime FechaRetencion { get; set; }
        public OOB.Venta.Ficha Documento { get; set; }

    }

}