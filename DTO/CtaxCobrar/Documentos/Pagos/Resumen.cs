using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Documentos.Pagos
{

    public class Resumen
    {

        public string Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public string DocumentoNro { get; set; }
        public string ClienteCodigo { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCiRif { get; set; }
        public decimal Importe { get; set; }
        public string Notas { get; set; }
        public bool IsAnulado { get; set; }

    }

}