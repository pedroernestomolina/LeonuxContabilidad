using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Recibo
{

    public class Ficha
    {

        public DateTime FechaEmision { get; set; }
        public string Hora { get; set; }
        public string DocumentoNro { get; set; }
        public string CliCodigo { get; set; }
        public string CliNombre { get; set; }
        public string CliCiRif { get; set; }
        public string CliDireccionFiscal { get; set; }
        public string CliTelefono { get; set; }
        public string CobNombre { get; set; }
        public string CobCodigo { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public decimal Importe { get; set; }
        public string Notas { get; set; }
        public IEnumerable<Documento> Documentos { get; set; }
        public Pago FormaPago { get; set; }

    }

}