using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Contable.PlanCta
{
    public class Enumerados
    {
        public enum Tipo { SinDefinir=-1, Totalizadora = 1, Auxiliar }
        public enum Naturaleza { SinDefinir = -1, Deudora = 1, Acreedora }
        public enum EstadoSituacion { SinDefinir = -1, Financiero= 1, Resultados }
    }
}
