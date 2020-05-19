using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Contable.Asiento.Generar
{

    public class InsertarDetalle
    {
        public int IdPlanCta { get; set; }
        public string CodigoPlanCta { get; set; }
        public string DescripcionPlanCta { get; set; }
        public DTO.Contable.PlanCta.Enumerados.Naturaleza NaturalezaPlanCta { get; set; }
        public decimal MontoDebe { get; set; }
        public decimal MontoHaber { get; set; }
        public string DocumentoRef { get; set; }
        public DateTime FechaDocRef { get; set; }
        public string DescDocRef { get; set; }
        public int Signo { get; set; }
    }

}