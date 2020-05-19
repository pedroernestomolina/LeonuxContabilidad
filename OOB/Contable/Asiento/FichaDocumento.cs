using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.Asiento
{
    public class FichaDocumento
    {
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Signo { get; set; }
        public List<FichaDetalle> Cuentas { get; set; }
    }
}
