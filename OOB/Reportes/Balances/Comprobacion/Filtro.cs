using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.Balances.Comprobacion
{

    public class Filtro: OOB.Reportes.Filtro
    {

        public OOB.Contable.Periodo.Ficha Desde { get; set; }
        public OOB.Contable.Periodo.Ficha Hasta { get; set; }

    }

}