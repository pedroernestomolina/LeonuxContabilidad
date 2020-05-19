using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Reportes.Balances.Comprobacion
{

    public class Ficha
    {

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public DTO.Contable.PlanCta.Enumerados.Naturaleza Naturaleza { get; set; }
        public decimal DebeAcumulado { get; set; }
        public decimal HaberAcumulado { get; set; }

    }

}
