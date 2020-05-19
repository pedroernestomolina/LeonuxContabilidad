using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.Periodo
{

    public class Cerrar
    {
        public int IdPeriodoActual { get; set; }
        public int MesActual { get; set; }
        public int AnoActual { get; set; }
        public decimal UtilidadPeriodo { get; set; }
        public decimal UtilidadAcumulada { get; set; }
        public int IdCtaCierre { get; set; }
    }

}
