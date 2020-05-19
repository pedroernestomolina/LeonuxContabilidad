using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.Balances.ComprobanteDiario
{

    public class Detalle
    {

        public int Renglon { get; set; }
        public string CodigoCta { get; set; }
        public string DescripcionCta { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Descripcion { get; set; }
        public decimal Debitos { get; set; }
        public decimal Creditos { get; set; }

    }

}
