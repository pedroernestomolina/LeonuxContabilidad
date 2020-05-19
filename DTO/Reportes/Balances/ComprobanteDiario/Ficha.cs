using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.Balances.ComprobanteDiario
{

    public class Ficha
    {

        public int ComprobanteNro { get; set; }
        public DateTime DeFecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public int Renglones { get; set; }
        public List<Detalle> Detalles { get; set; }

    }

}
