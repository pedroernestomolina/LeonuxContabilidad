using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.CtaxCobrar.Vendedores
{

    public class Consolidado
    {

        public string VendedorId { get; set; }
        public string VendedorCodigo { get; set; }
        public string VendedorNombre { get; set; }

        public decimal MontoBaseVenta { get; set; }
        public decimal MontoExcentoVenta { get; set; }
        public decimal MontoImpuestoVenta { get; set; }
        public decimal MontoTotalVenta { get; set; }

        public decimal MontoBaseNcr { get; set; }
        public decimal MontoImpuestoNcr { get; set; }
        public decimal MontoTotalNcr { get; set; }

    }

}