using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Cuenta
{
    public class Filtro
    {
        public int IdCta { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }
}
