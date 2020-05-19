using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Generar
{

    public class FiltroVenta 
    {

        public string IdSucursal { get; set; }
        public string TipoDocumento { get; set; }
        public string CondicionPago { get; set; }
        public string DenominacionFiscal { get; set; }
        public string SerialFiscal { get; set; }

    }

}