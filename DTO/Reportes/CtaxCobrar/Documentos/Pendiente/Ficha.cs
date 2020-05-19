using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.CtaxCobrar.Documentos.Pendiente
{

    public class Ficha
    {

        public DateTime DocFechaEmision { get; set; }
        public DateTime DocFechaVencimiento { get; set; }
        public string DocNumero { get; set; }
        public DTO.CtaxCobrar.Enumerados.PorTipoDocumento DocTipo { get; set; }
        public decimal DocImporte { get; set; }
        public decimal DocResta { get; set; }
        public int DocSigno { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCiRif { get; set; }
        public string ClienteCodigo { get; set; }
        public string VendedorNombre { get; set; }
        public string VendedorCodigo { get; set; }

    }

}