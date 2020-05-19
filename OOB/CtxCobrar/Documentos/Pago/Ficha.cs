using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Documentos.Pago
{

    public class Ficha
    {

        public string IdAuto { get; set; }
        public string IdAutCliente { get; set; }
        public DateTime FechaEmision { get; set; }
        public string DocumentoNro { get; set; }
        public decimal Importe { get; set; }
        public string Detalle { get; set; }
        public bool IsAnulado { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCiRif { get; set; }
        public string ClienteCodigo { get; set; }

    }

}
