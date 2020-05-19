using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.Libro.Mayor

{
    public class Item
    {

        public DateTime Fecha { get; set; }
        public string Comprobante { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }
        public string TipoDocumento { get; set; }
        public OOB.Contable.Asiento.Enumerados.Tipo TipoAsiento { get; set; }

    }

}