using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.CtaxCobrar.Vendedores
{

    public class ComisionPagar
    {

        public string ClienteCodigo { get; set; }
        public string DocPagoNumero { get; set; }
        public string DocVentaNumero { get; set; }
        public DateTime FechaRecepcionMerc { get; set; }
        public DateTime FechaMovPago { get; set; }
        public int DiasTranscurrido { get; set; }
        public decimal BaseComision { get; set; }
        public decimal ComisionPorc { get; set; }
        public decimal ComisionCastigo { get; set; }
        public bool AplicaCastigo { get; set; }
        public decimal Importe { get; set; }

        public string VendedorId { get; set; }
        public string VendedorCodigo { get; set; }
        public string VendedorNombre { get; set; }

    }

}