using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.Asiento.Apertura
{

    public class Insertar
    {
        public int Id { get; set; }
        public int PeriodoMes { get; set; }
        public int PeriodoAno { get; set; }
        public decimal Importe { get; set; }
        public bool IsPreview { get; set; }
        public string DescripcionDocumentoRef { get; set; }
        public DateTime FechaDocumentoRef { get; set; }
        public IEnumerable<InsertarCta> Ctas { get; set; }
    }

}
