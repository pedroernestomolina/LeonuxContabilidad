using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.Balances.ComprobanteDiario
{

    public class Detalle
    {

        public int Renglon { get; set; }
        public string CodigoCta { get; set; }
        public string DescripcionCta { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }

    }

}