using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.CtaxCobrar
{

    public class Enumerados
    {

        public enum PorTipoDocumento { SinDefinir=-1, Factura=1,NtDebito,NtCredito};
        public enum PorVencimiento { SinDefinir = -1, PorVencer = 1, Vencido, Todos };

    }

}