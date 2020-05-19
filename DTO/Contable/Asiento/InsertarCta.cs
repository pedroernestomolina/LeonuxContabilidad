using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento
{
   
    public class InsertarCta
    {

        public int Id { get; set; }
        public string codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }
        public DTO.Contable.PlanCta.Enumerados.Naturaleza Naturaleza { get; set; }

    }

}