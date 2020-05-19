using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.Balances.GananciaPerdida
{

    public class Filtro : DTO.Reportes.Filtro
    {

        public Historico DesdePerido { get; set; }
        public Historico HastaPeriodo { get; set; }

    }

}