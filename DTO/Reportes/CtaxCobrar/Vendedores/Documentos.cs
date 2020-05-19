using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.CtaxCobrar.Vendedores
{

    public class Documentos
    {

        public DateTime DocFechaEmision { get; set; }
        public String DocSerie { get; set; }
        public string DocNumero { get; set; }
        public Enumerados.DocVenta DocTipo { get; set; }
        public Enumerados.CondicionPago DocCondicionPago { get; set; }
        public int DocDiasCredito { get; set; }
        public decimal DocSubtotal { get; set; }
        public decimal DocTotal { get; set; }
        public int DocSigno { get; set; }
        public string ClienteCodigo { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteRif { get; set; }
        public string VendedorId { get; set; }
        public string VendedorCodigo { get; set; }
        public string VendedorNombre{ get; set; }

    }

}
