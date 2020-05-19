using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.Balances.Comprobacion
{

    public class Filtro: DTO.Reportes.Filtro
    {

        public Historico DesdePeriodo { get; set; }
        public Historico HastaPeriodo { get; set; }

    }

}