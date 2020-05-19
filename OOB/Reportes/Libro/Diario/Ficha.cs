using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.Libro.Diario
{

    public class Ficha
    {

        public OOB.Contable.PlanCta.Ficha Cuenta { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public List<Item> Data { get; set; }
        public decimal Saldo { get; set; }

    }

}
