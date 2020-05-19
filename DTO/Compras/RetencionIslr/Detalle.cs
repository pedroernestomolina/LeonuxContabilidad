using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Compras.RetencionIslr
{
    public class Detalle
    {

        public string DocumentoNro { get; set; }
        public string ControlNro { get; set; }
        public DTO.Compras.Enumerados.TipoDocumento TipoDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public string Aplica { get; set; }
        public decimal Exento { get; set; }
        public decimal Base { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public decimal Retencion { get; set; }
        public int Signo { get; set; }

    }
}
