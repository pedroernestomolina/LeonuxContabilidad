using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento
{

    public class Resumen
    {

        public int Id { get; set; }
        public int ComprobanteNro { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Detalle { get; set; }
        public Enumerados.Tipo TipoAsiento { get; set; }
        public bool EstaAnulado { get; set; }
        public bool EstaProcesado { get; set; }
        public bool AutoGenerado { get; set; }
        public decimal Importe { get; set; }
        public string TipoDocumento { get; set; }
        public int MesRelacion { get; set; }
        public int AnoRelacion { get; set; }
        public string ReglaDescripcion { get; set; }

    }

}