using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.Asiento
{
    public class FichaDocumento
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Documento { get; set; }
        public int Signo { get; set; }
        public IEnumerable<FichaDetalle> DetalleCta { get; set; }

    }
}
