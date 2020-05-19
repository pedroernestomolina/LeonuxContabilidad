using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar.Documentos.Pendientes
{

    public class Resumen
    {

        public string Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string DocumentoNro { get; set; }
        public string DocumentoSerie { get; set; }
        public Enumerados.PorTipoDocumento DocumentoTipo { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCiRif { get; set; }
        public decimal Importe { get; set; }
        public decimal Abonado { get; set; }
        public string Detalle { get; set;}
        public int Signo { get; set; }

    }

}
