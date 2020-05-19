using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.Asiento.Generar
{
    public class FichaDetalle
    {
        public int IdCta { get; set; }
        public string CodigoCta { get; set; }
        public string DescripcionCta { get; set; }
        public int Renglon { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }
        public int Signo { get; set; }
        public OOB.Contable.PlanCta.Enumerados.Naturaleza Naturaleza { get; set; }

        public decimal Diferencia
        {
            get 
            {
                return (MontoDebe - MontoHaber); 
            } 
        }

        public decimal Monto 
        {
            get 
            {
                var m = MontoDebe;
                if (MontoHaber != 0) { m = MontoHaber; }
                return m;
            }
        }

    }
}