using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Generar.DocAdm
{

    public class NotaDebito
    {

        public OOB.Clientes.Cliente.Ficha Cliente { get; set; }
        public DateTime FechaEmision { get; set; }
        public string NotaDetalle { get; set; }
        public decimal Monto { get; set; }

    }

}