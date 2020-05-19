using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Generar
{

    public class FiltroCompra
    {

        public string TipoDocumento { get; set; }
        public string IdProveedor { get; set; }
        public string IdConcepto { get; set; }
        public int MesRelacion { get; set; }
        public int AnoRelacion { get; set; }
        public string IdSucursal {get;set;}

    }

}