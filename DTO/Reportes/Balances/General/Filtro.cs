using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Reportes.Balances.General
{

    public class Filtro : DTO.Reportes.Filtro
    {

        public Historico DesdePeriodo { get; set; }
        public Historico HastaPeriodo { get; set; }
        public int IdCtaCierre { get; set; }
        public decimal UtilidadPeriodo { get; set; }
        public decimal SaldoCtaCierre { get; set; }

    }

}