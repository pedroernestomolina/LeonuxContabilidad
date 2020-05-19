using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Pago
{

    public class DocLiquida
    {
        
        public string IdDoc { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public decimal MontoDoc { get; set; }
        public OOB.CtxCobrar.Enumerados.PorTipoDocumento TipoDoc { get; set; }
        public DateTime fechaRecepcion { get; set; }
        public int ToleranciaDias { get; set; }
        public decimal ComisionPorc { get; set; }
        public decimal CastigoPorc { get; set; }
        public OOB.CtxCobrar.Enumerados.PorTipoOpreacion TipoOeracion { get; set; }
        public decimal MontoAbonado { get; set; }

    }

}