using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Asiento.Generar
{

    public class FiltroVenta
    {

        public string CodSucursal { get; set; }
        public string TipoDocumento { get; set; }
        public string CondicionPago { get; set; }
        public string DenominacionFiscal { get; set; }
        public OOB.Empresa.SerialesFiscales.Ficha SerialFiscal { get; set; }

    }

}