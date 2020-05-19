using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Generar
{

    public class FiltroCxP
    {

        public int? IdSucursal { get; set; }
        public string IdProveedor { get; set; }
        public string IdConcepto { get; set; }
        public DTO.Contable.Asiento.Generar.Enumerados.TipoDocumento? TipoDocumento { get; set; }

    }

}