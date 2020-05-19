using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxPagar.Recibo
{
    
    public class Ficha
    {

        public DateTime FechaEmision { get; set; }
        public string DocumentoNro { get; set; }
        public string ProvCodigo { get; set; }
        public string ProvNombre { get; set; }
        public string ProvCiRif { get; set; }
        public string ProvDireccionFiscal { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public decimal Importe { get; set; }
        public string Notas { get; set; }
        public IEnumerable<Documento> Documentos { get; set; }
        public Pago FormaPago { get; set; }

    }

}