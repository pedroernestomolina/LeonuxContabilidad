using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.Libro.Diario
{

    public class Item
    {

        public string TipoDocumento { get; set; }
        public string DocumentoRef { get; set; }
        public string DescripcionDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }

    }

}