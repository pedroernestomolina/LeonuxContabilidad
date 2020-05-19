using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.CtxPagar.Recibo
{

    public class Documento
    {
        public string DocumentoNro { get; set; }
        public DateTime Fecha { get; set; }
        public string Operacion { get; set; }
        public string TipoDocumento { get; set; }
        public decimal Importe { get; set; }
    }

}
