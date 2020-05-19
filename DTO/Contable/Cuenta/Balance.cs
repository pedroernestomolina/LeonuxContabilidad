using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Cuenta
{

    public class Balance
    {

        public int idAsiento { get; set; }
        public int Comprobante { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoDocumento { get; set; }
        public Asiento.Enumerados.Tipo TipoAsiento { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }

    }

}
