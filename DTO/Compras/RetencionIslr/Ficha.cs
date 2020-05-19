using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Compras.RetencionIslr
{
    public class Ficha
    {
        public DateTime FechaEmision { get; set; }
        public DateTime FechaProceso { get; set; }
        public string DocumentoNro { get; set; }
        public string ProvCodigo { get; set; }
        public string ProvNombreRazonSocial { get; set; }
        public string ProvCiRif { get; set; }
        public string ProvDireccionFiscal { get; set; }
        public string ProvTelefono { get; set; }
        public decimal MontoExento { get; set; }
        public decimal MontoBase { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal Total { get; set; }
        public decimal TasaRetencion { get; set; }
        public decimal MontoRetencion { get; set; }
        public int MesRelacion { get; set; }
        public int AnoRelacion { get; set; }
        public int Renglones { get; set; }
        public IEnumerable<Detalle> Detalles { get; set; }
    }
}
